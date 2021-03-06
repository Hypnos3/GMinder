/// Copyright (c) 2009, Greg Todd
/// All rights reserved.
///
/// Redistribution and use in source and binary forms, with or without modification,
/// are permitted provided that the following conditions are met:
/// 
/// * Redistributions of source code must retain the above copyright notice,
///   this list of conditions and the following disclaimer.
///   
/// * Redistributions in binary form must reproduce the above copyright notice,
///   this list of conditions and the following disclaimer in the documentation
///   and/or other materials provided with the distribution.
///   
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
/// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
/// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
/// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
/// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
/// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
/// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
/// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
/// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
/// OF THE POSSIBILITY OF SUCH DAMAGE.

using ReflectiveCode.GMinder.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ReflectiveCode.GMinder
{
    public partial class GReminder : PositionalForm
    {
        public const string REMINDER_TYPE_EMAIL = "email";
        public const string REMINDER_TYPE_SMS = "sms";
        public const string REMINDER_TYPE_POPUP = "popup";

        const int ONE_MINUTE = 60 * 1000;

        private bool _UserExit;
        private bool _OptionsLock;

        private bool Hidden
        {
            get { return !Visible; }
            set
            {
                if (value == Visible)
                {
                    if (value)
                    {
                        Hide();
                    }
                    else
                    {
                        snoozeTimer.Stop();
                        Show();
                    }
                }
            }
        }

        private Gvent _Selected;
        public Gvent Selected
        {
            get { return _Selected; }
            set
            {
                _Selected = value;
                DisplayEventDetails(value);
                dismissButton.Enabled = openButton.Enabled = (_Selected != null);
            }
        }

        public GReminder() : base("WindowSize", "WindowLocation")
        {
            InitializeComponent();            

            //Make sure we are not on top of any browser or dialog that happens during the authorzation
            Calendar.StartingAuth += (sender, args) => { this.TopMost = false; };
            Calendar.EndingAuth += (sender, args) => { this.TopMost = global::ReflectiveCode.GMinder.Properties.Settings.Default.OnTop; };

            //If we have already established OAuth, load the proper objects
            if (Properties.Settings.Default.LoggedIn) {
                Calendar.SetUserCredentials(false);
                Schedule.Current.Load();
            }
            
            Selected = null;
            Schedule.Current.GventChanged += (sender, e) =>
            {
                if (e.Changes == GventChanges.Status)
                    StatusAlert(e.Gvent);
            };
            if (Schedule.Current.Count == 0)
                HandleTrayCalendars(null, null);
            UpdateStatus();
            StartCalendarRefresher();
            ApplyRefreshTimerInterval();
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(Tray);
            timer.Start();
        }

        void Tray(object sender, EventArgs e)
        {
            Hidden = true;
            var timer = (System.Windows.Forms.Timer)sender;
            timer.Stop();
            timer.Dispose();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_UserExit && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hidden = true;
            }
            base.OnFormClosing(e);
        }
	
        #region Status Update

        private void UpdateStatus()
        {
            var now = DateTime.Now;
            var soon = now.AddMinutes(Properties.Settings.Default.SoonTime);
            Schedule.Current.UpdateStatus(now, soon);
        }

        private void StatusAlert(Gvent gvent)
        {
            switch (gvent.Status)
            {
                case GventStatus.Soon:
                    if (Properties.Settings.Default.SoonPopup)
                        Hidden = false;
                    if (Properties.Settings.Default.SoonSound)
                        Sound.MakeSound(Properties.Settings.Default.SoundPath);
                    if (Properties.Settings.Default.SoonVerbal)
                        Sound.Speak(gvent);
                    return;

                case GventStatus.Now:
                    if (Properties.Settings.Default.NowPopup)
                        Hidden = false;
                    if (Properties.Settings.Default.NowSound)
                        Sound.MakeSound(Properties.Settings.Default.SoundPath);
                    if (Properties.Settings.Default.NowVerbal)
                        Sound.Speak(gvent);
                    return;

                case GventStatus.Past:
                    if (Properties.Settings.Default.PastDismiss)
                        gvent.Dismiss();
                    return;
            }
        }

        #endregion


        #region Calendar Refresh

        private void StartCalendarRefresher()
        {
            if (!calendarRefresher.IsBusy)
                calendarRefresher.RunWorkerAsync();
        }

        private void HandleCalendarRefresherWork(object sender, DoWorkEventArgs e)
        {
            int days = Properties.Settings.Default.LoadDays;
            Schedule.Current.DownloadUpdates(days);
        }

        private void HandleCalendarRefresherCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Schedule.Current.ProcessUpdates();
            UpdateStatus();

            Schedule.Current.Save();
        }

        private void ApplyRefreshTimerInterval()
        {
            if (Properties.Settings.Default.RefreshRate > 0)
            {
                refreshTimer.Interval = Properties.Settings.Default.RefreshRate * ONE_MINUTE;
                refreshTimer.Enabled = true;
            }
            else
            {
                refreshTimer.Enabled = false;
            }
        }

        private void HandleRefreshTimerTick(object sender, EventArgs e)
        {
            StartCalendarRefresher();
        }

        #endregion


        #region Tray Icon

        private void HandleTrayClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var preview = new Preview();

                int x = Cursor.Position.X - preview.Size.Width;
                int y = Cursor.Position.Y - preview.Size.Height - 10;
                if (y < 0)
                    y = Cursor.Position.Y;
                if (x < 0)
                    x = Cursor.Position.X; // Taskbar may be on left side

                preview.SetDesktopLocation(x, y);
                preview.Show();
            }
        }

        private void HandleTrayDoubleClick(object sender, MouseEventArgs e)
        {
            if (Hidden)
                Hidden = false;
            else
                Activate();
        }

        private void HandleTrayOptions(object sender, EventArgs e)
        {
            if (_OptionsLock)
                return;
            else
                _OptionsLock = true;

            using (var options = new Options())
            {
                if (options.ShowDialog(this) == DialogResult.OK)
                {
                    ApplyRefreshTimerInterval();
                    Schedule.Current.Redraw();
                }
            }

            _OptionsLock = false;
        }

        private void HandleTrayReset(object sender, EventArgs e)
        {
            Schedule.Current.Reset();
            Schedule.Current.Redraw();
        }

        private void HandleTrayRefresh(object sender, EventArgs e)
        {
            StartCalendarRefresher();
        }

        private void HandleTrayExit(object sender, EventArgs e)
        {
            _UserExit = true;
            Schedule.Current.Save();
            Close();
        }

        private void HandleTrayCalendars(object sender, EventArgs e)
        {
            if (_OptionsLock)
                return;
            else
                _OptionsLock = true;

            using (var calendars = new Calendars())
            {
                if (calendars.ShowDialog(this) == DialogResult.OK)
                {
                    StartCalendarRefresher();
                    Schedule.Current.Redraw();
                }
            }

            _OptionsLock = false;
        }

        #endregion


        #region Minute Timer

        private DateTime _PreviousMinute = DateTime.MinValue;

        private void HandleMinuteTimerTick(object sender, EventArgs e)
        {
            DateTime thisMinute = DateTime.Now;

            this.minuteTimer.Interval = ((60 - thisMinute.Second) * 1000 - thisMinute.Millisecond);
            thisMinute = new DateTime(thisMinute.Year, thisMinute.Month, thisMinute.Day, thisMinute.Hour, thisMinute.Minute, 0);

            if (thisMinute.Date != _PreviousMinute.Date)
                Schedule.Current.Redraw();
            _PreviousMinute = thisMinute;
            UpdateStatus();
        }

        #endregion


        #region Agenda Selection

        private void HandleAgendaSelectionChanged(object sender, EventArgs e)
        {
            Selected = agenda.Selected;
        }
        
        #endregion


        #region Event Panel

        private void DisplayEventDetails(Gvent gvent)
        {
            reminderFormTableLayoutPanel.SuspendLayout();

            snoozeMenu.Items.Clear();
            snoozeLengthInteger.Minimum = 1;
            CheckButtons();

            if (gvent != null)
            {
                // Title
                eventWhat.Text = gvent.Title;

                DateTime start = gvent.Start;
                DateTime stop = gvent.Stop;
                string when;

                // Time
                if (start.Date == stop.AddSeconds(-1).Date)
                {
                    if (start.Hour == 0 && start.Minute == 0 && stop.Hour == 0 && stop.Minute == 0)
                        when = "{0:ddd}, {0:m}";
                    else
                        when = "{0:ddd}, {0:m} {0:t} - {1:t}";
                }
                else
                {
                    if (start.Hour == 0 && start.Minute == 0 && stop.Hour == 0 && stop.Minute == 0)
                        when = "{0:ddd}, {0:m} - {1:ddd}, {1:m}";
                    else
                        when = "{0:ddd}, {0:m} {0:t} - {1:ddd}, {1:m} {1:t}";
                }

                when = String.Format(when, start, stop);
                when = String.Format("{0}  ({1})", when, gvent.LengthString);
                
                eventWhen.Text =  when;

                // Location
                eventWhere.Text = gvent.Location;

                //get Minimum
                int minutes = (int)Math.Truncate(( Selected.Start - DateTime.Now ).TotalMinutes);
                if (minutes > 1) {
                    snoozeLengthInteger.Minimum = ( minutes * -1 );

                    //Snooze Helper menu
                    snoozeMenu.Items.Clear();
                    if (minutes > 5)
                        addSnoozeMenuItem(5);
                    if (minutes > 10)
                        addSnoozeMenuItem(10);
                    if (minutes > 15)
                        addSnoozeMenuItem(15);
                    if (minutes > 30)
                        addSnoozeMenuItem(30);
                    if (minutes > 60)
                        addSnoozeMenuItem(60);
                }
            }
            else
            {
                eventWhat.Text = null;
                eventWhen.Text = "No event selected";
                eventWhere.Text = null;
            }

            reminderFormTableLayoutPanel.ResumeLayout();
        }

        private void addSnoozeMenuItem(int minutes)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(string.Format("{0} min before start", minutes),null,HandleSnoozeMenuItemClick);
            item.Tag = minutes * -1;
            snoozeMenu.Items.Add(item);
        }
        #endregion


        #region Update Display
        private void CheckButtons()
        {
            this.snoozeButton.Enabled = ( snoozeLengthInteger.Value != 0 );
        }
        #endregion

        private void HandleOpenButton(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected.OpenBrowser();
        }

        private void HandleDismissClick(object sender, EventArgs e)
        {
            if (Selected != null)
                Selected.Dismiss();
        }

        private void HandleSnoozeKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                HandleSnoozeButton(sender, e);
        }

        private void HandleSnoozeMenuButton( object sender, EventArgs e )
        {
            throw new NotImplementedException("Not implemented");
        }

        private void HandleSnoozeMenuItemClick( object sender, EventArgs e )
        {
            ToolStripMenuItem item = ( sender as ToolStripMenuItem );
            snoozeLengthInteger.Value = (int)( item.Tag ?? 1 );
        }

        private void HandleSnoozeButton(object sender, EventArgs e)
        {
            int snoozeLength = snoozeLengthInteger.Value;
            if (snoozeLength == 0) {
                return;
            } else if (snoozeLength < 0) {
                snoozeLength = Math.Abs(snoozeLength);

                if (Selected != null) {
                    int dif = (int)Math.Truncate(( Selected.Start - DateTime.Now ).TotalMinutes);
                    if (snoozeLength >= dif)
                        snoozeLength = dif;
                    else
                        snoozeLength = dif - snoozeLength;
                    MessageBox.Show(string.Format("{0} Minutes now to time; snooze for {1} Minutes", dif, snoozeLength));
                }
            }

            snoozeTimer.Interval = snoozeLength * ONE_MINUTE;
            snoozeTimer.Start();
            Hidden = true;
        }

        private void HandleSnoozeLengthIntegerChanged( object sender, EventArgs e )
        {
            CheckButtons();
        }

        private void HandleSnoozeTimerTick(object sender, EventArgs e)
        {
            snoozeTimer.Stop();
            Hidden = false;

            if (Properties.Settings.Default.SoonSound || Properties.Settings.Default.NowSound)
                Sound.MakeSound(Properties.Settings.Default.SoundPath);
        }

        private void HandleHideButton(object sender, EventArgs e)
        {
            Hidden = true;
        }

        private void HandleAddButton(object sender, EventArgs e)
        {
            using (var create = new Create())
                create.ShowDialog(this);
        }

        private void HandleTrayAbout(object sender, EventArgs e)
        {
            using (var about = new About())
                about.ShowDialog(this);
        }

    }
}