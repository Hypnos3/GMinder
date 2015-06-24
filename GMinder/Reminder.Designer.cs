using ReflectiveCode.GMinder.Controls;

namespace ReflectiveCode.GMinder
{
    partial class GReminder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GReminder));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.calendarsTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarRefresher = new System.ComponentModel.BackgroundWorker();
            this.reminderFormTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.eventText = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();
            this.agenda = new ReflectiveCode.GMinder.Controls.Agenda();
            this.reminderButtonsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.newButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.dismissButton = new System.Windows.Forms.Button();
            this.snoozeLengthInteger = new ReflectiveCode.GMinder.Controls.IntegerUpDown();
            this.snoozeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.snoozeButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.minuteTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.snoozeTimer = new System.Windows.Forms.Timer(this.components);
            this.trayMenu.SuspendLayout();
            this.reminderFormTableLayoutPanel.SuspendLayout();
            this.reminderButtonsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snoozeLengthInteger)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HandleTrayClick);
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HandleTrayDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarsTrayMenuItem,
            this.optionsTrayMenuItem,
            this.trayMenuToolStripSeparator2,
            this.resetTrayMenuItem,
            this.refreshTrayMenuItem,
            this.addTrayMenuItem,
            this.trayMenuToolStripSeparator1,
            this.aboutTrayMenuItem,
            this.exitTrayMenuItem});
            this.trayMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.trayMenu, "trayMenu");
            // 
            // calendarsTrayMenuItem
            // 
            this.calendarsTrayMenuItem.Name = "calendarsTrayMenuItem";
            resources.ApplyResources(this.calendarsTrayMenuItem, "calendarsTrayMenuItem");
            this.calendarsTrayMenuItem.Click += new System.EventHandler(this.HandleTrayCalendars);
            // 
            // optionsTrayMenuItem
            // 
            this.optionsTrayMenuItem.Name = "optionsTrayMenuItem";
            resources.ApplyResources(this.optionsTrayMenuItem, "optionsTrayMenuItem");
            this.optionsTrayMenuItem.Click += new System.EventHandler(this.HandleTrayOptions);
            // 
            // trayMenuToolStripSeparator2
            // 
            this.trayMenuToolStripSeparator2.Name = "trayMenuToolStripSeparator2";
            resources.ApplyResources(this.trayMenuToolStripSeparator2, "trayMenuToolStripSeparator2");
            // 
            // resetTrayMenuItem
            // 
            this.resetTrayMenuItem.Name = "resetTrayMenuItem";
            resources.ApplyResources(this.resetTrayMenuItem, "resetTrayMenuItem");
            this.resetTrayMenuItem.Click += new System.EventHandler(this.HandleTrayReset);
            // 
            // refreshTrayMenuItem
            // 
            this.refreshTrayMenuItem.Name = "refreshTrayMenuItem";
            resources.ApplyResources(this.refreshTrayMenuItem, "refreshTrayMenuItem");
            this.refreshTrayMenuItem.Click += new System.EventHandler(this.HandleTrayRefresh);
            // 
            // addTrayMenuItem
            // 
            this.addTrayMenuItem.Name = "addTrayMenuItem";
            resources.ApplyResources(this.addTrayMenuItem, "addTrayMenuItem");
            this.addTrayMenuItem.Click += new System.EventHandler(this.HandleAddButton);
            // 
            // trayMenuToolStripSeparator1
            // 
            this.trayMenuToolStripSeparator1.Name = "trayMenuToolStripSeparator1";
            resources.ApplyResources(this.trayMenuToolStripSeparator1, "trayMenuToolStripSeparator1");
            // 
            // aboutTrayMenuItem
            // 
            this.aboutTrayMenuItem.Name = "aboutTrayMenuItem";
            resources.ApplyResources(this.aboutTrayMenuItem, "aboutTrayMenuItem");
            this.aboutTrayMenuItem.Click += new System.EventHandler(this.HandleTrayAbout);
            // 
            // exitTrayMenuItem
            // 
            this.exitTrayMenuItem.Name = "exitTrayMenuItem";
            resources.ApplyResources(this.exitTrayMenuItem, "exitTrayMenuItem");
            this.exitTrayMenuItem.Click += new System.EventHandler(this.HandleTrayExit);
            // 
            // calendarRefresher
            // 
            this.calendarRefresher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.HandleCalendarRefresherWork);
            this.calendarRefresher.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.HandleCalendarRefresherCompleted);
            // 
            // reminderFormTableLayoutPanel
            // 
            resources.ApplyResources(this.reminderFormTableLayoutPanel, "reminderFormTableLayoutPanel");
            this.reminderFormTableLayoutPanel.Controls.Add(this.eventText, 0, 0);
            this.reminderFormTableLayoutPanel.Controls.Add(this.agenda, 0, 1);
            this.reminderFormTableLayoutPanel.Controls.Add(this.reminderButtonsTableLayoutPanel, 0, 2);
            this.reminderFormTableLayoutPanel.Name = "reminderFormTableLayoutPanel";
            // 
            // eventText
            // 
            resources.ApplyResources(this.eventText, "eventText");
            this.eventText.BackColor = System.Drawing.SystemColors.Control;
            this.eventText.BaseStylesheet = null;
            this.eventText.MaximumSize = new System.Drawing.Size(0, 200);
            this.eventText.Name = "eventText";
            this.eventText.LinkClicked += new System.EventHandler<TheArtOfDev.HtmlRenderer.Core.Entities.HtmlLinkClickedEventArgs>(this.eventTextLinkClicked);
            // 
            // agenda
            // 
            resources.ApplyResources(this.agenda, "agenda");
            this.agenda.ForeColor = System.Drawing.Color.Black;
            this.agenda.FullRowSelect = true;
            this.agenda.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.agenda.HideSelection = false;
            this.agenda.MultiSelect = false;
            this.agenda.Name = "agenda";
            this.agenda.UseCompatibleStateImageBehavior = false;
            this.agenda.View = System.Windows.Forms.View.Details;
            this.agenda.SelectedChanged += new System.EventHandler(this.HandleAgendaSelectionChanged);
            // 
            // reminderButtonsTableLayoutPanel
            // 
            resources.ApplyResources(this.reminderButtonsTableLayoutPanel, "reminderButtonsTableLayoutPanel");
            this.reminderButtonsTableLayoutPanel.Controls.Add(this.newButton, 0, 0);
            this.reminderButtonsTableLayoutPanel.Controls.Add(this.openButton, 1, 0);
            this.reminderButtonsTableLayoutPanel.Controls.Add(this.dismissButton, 2, 0);
            this.reminderButtonsTableLayoutPanel.Controls.Add(this.snoozeLengthInteger, 3, 0);
            this.reminderButtonsTableLayoutPanel.Controls.Add(this.snoozeButton, 4, 0);
            this.reminderButtonsTableLayoutPanel.Controls.Add(this.hideButton, 5, 0);
            this.reminderButtonsTableLayoutPanel.Name = "reminderButtonsTableLayoutPanel";
            // 
            // newButton
            // 
            resources.ApplyResources(this.newButton, "newButton");
            this.newButton.Name = "newButton";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.HandleAddButton);
            // 
            // openButton
            // 
            resources.ApplyResources(this.openButton, "openButton");
            this.openButton.Name = "openButton";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.HandleOpenButton);
            // 
            // dismissButton
            // 
            resources.ApplyResources(this.dismissButton, "dismissButton");
            this.dismissButton.Name = "dismissButton";
            this.dismissButton.UseVisualStyleBackColor = true;
            this.dismissButton.Click += new System.EventHandler(this.HandleDismissClick);
            // 
            // snoozeLengthInteger
            // 
            resources.ApplyResources(this.snoozeLengthInteger, "snoozeLengthInteger");
            this.snoozeLengthInteger.ContextMenuStrip = this.snoozeMenu;
            this.snoozeLengthInteger.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.snoozeLengthInteger.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.snoozeLengthInteger.Name = "snoozeLengthInteger";
            this.snoozeLengthInteger.Value = 10;
            this.snoozeLengthInteger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleSnoozeKeyPress);
            // 
            // snoozeMenu
            // 
            this.snoozeMenu.Name = "snoozeMenu";
            resources.ApplyResources(this.snoozeMenu, "snoozeMenu");
            // 
            // snoozeButton
            // 
            resources.ApplyResources(this.snoozeButton, "snoozeButton");
            this.snoozeButton.ContextMenuStrip = this.snoozeMenu;
            this.snoozeButton.Name = "snoozeButton";
            this.snoozeButton.UseVisualStyleBackColor = true;
            this.snoozeButton.Click += new System.EventHandler(this.HandleSnoozeButton);
            // 
            // hideButton
            // 
            resources.ApplyResources(this.hideButton, "hideButton");
            this.hideButton.Name = "hideButton";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.HandleHideButton);
            // 
            // minuteTimer
            // 
            this.minuteTimer.Enabled = true;
            this.minuteTimer.Tick += new System.EventHandler(this.HandleMinuteTimerTick);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.HandleRefreshTimerTick);
            // 
            // snoozeTimer
            // 
            this.snoozeTimer.Tick += new System.EventHandler(this.HandleSnoozeTimerTick);
            // 
            // GReminder
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reminderFormTableLayoutPanel);
            this.DataBindings.Add(new System.Windows.Forms.Binding("TopMost", global::ReflectiveCode.GMinder.Properties.Settings.Default, "OnTop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "GReminder";
            this.TopMost = global::ReflectiveCode.GMinder.Properties.Settings.Default.OnTop;
            this.Resize += new System.EventHandler(this.OnFormRezize);
            this.trayMenu.ResumeLayout(false);
            this.reminderFormTableLayoutPanel.ResumeLayout(false);
            this.reminderFormTableLayoutPanel.PerformLayout();
            this.reminderButtonsTableLayoutPanel.ResumeLayout(false);
            this.reminderButtonsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.snoozeLengthInteger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer minuteTimer;
        private System.Windows.Forms.Timer snoozeTimer;
        private System.ComponentModel.BackgroundWorker calendarRefresher;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem calendarsTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsTrayMenuItem;
        private System.Windows.Forms.ToolStripSeparator trayMenuToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem refreshTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTrayMenuItem;
        private System.Windows.Forms.ToolStripSeparator trayMenuToolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitTrayMenuItem;
        private System.Windows.Forms.TableLayoutPanel reminderFormTableLayoutPanel;
        private TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel eventText;
        private Agenda agenda;
        private System.Windows.Forms.TableLayoutPanel reminderButtonsTableLayoutPanel;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button dismissButton;
        private Controls.IntegerUpDown snoozeLengthInteger;
        private System.Windows.Forms.Button snoozeButton;
        private System.Windows.Forms.Button hideButton;		
        private System.Windows.Forms.ContextMenuStrip snoozeMenu;
    }
}

