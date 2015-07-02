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

using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Web;


namespace ReflectiveCode.GMinder
{
    public class Gvent : IComparable<Gvent>, IXmlSerializable
    {
        #region Properties

        public Calendar Calendar {get; private set; }

        private List<GVentMinder> _Minders = new List<GVentMinder>();

        private string _Id;
        public string Id { get { return _Id; } }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Title));
                }
            }
        }

        private string _Location;
        public string Location
        {
            get { return _Location; }
            set
            {
                if (_Location != value)
                {
                    _Location = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Location));
                }
            }
        }

        private DateTime _Start;
        public DateTime Start
        {
            get { return _Start; }
            set
            {
                if (_Start != value)
                {
                    _Start = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Start));
                    foreach (var minder in _Minders)
                    {
                        minder.Done = false;
                    }
                }
            }
        }

        private DateTime _Stop;
        public DateTime Stop
        {
            get { return _Stop; }
            set
            {
                if (_Stop != value)
                {
                    _Stop = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Stop));
                }
            }
        }

        private string _Url;
        public string Url
        {
            get { return _Url; }
            set
            {
                if (_Url != value)
                {
                    _Url = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Url));
                }
            }
        }

        private string _HangoutUrl;
        public string HangoutUrl
        {
            get { return _HangoutUrl; }
            set
            {
                if (_HangoutUrl != value)
                {
                    _HangoutUrl = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.HangoutUrl));
                }
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value) {
                    _Description = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Description));
                }
            }
        }

        private GventAppendix _Organizer;
        public GventAppendix Organizer
        {
            get { return _Organizer; }
            set
            {
                if (_Organizer != value) {
                    _Organizer = value;
                    NotifyChange(new GventAppendixEventArgs(this, Organizer, GventChanges.Organizer));
                }
            }
        }

        private bool _IsRecurrence;
        public bool IsRecurrence
        {
            get { return _IsRecurrence; }
            set
            {
                if (_IsRecurrence != value) {
                    _IsRecurrence = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.IsRecurrence));
                }
            }
        }

        private GventAppendix _LocationResource;
        public GventAppendix LocationResource
        {
            get { return _LocationResource; }
            set
            {
                if (_LocationResource != value) {
                    _LocationResource = value;
                    NotifyChange(new GventAppendixEventArgs(this, LocationResource, GventChanges.LocationResource));
                }
            }
        }

        private List<GventAppendix> _Attendees;
        public List<GventAppendix> Attendees
        {
            get { return _Attendees; }
            set
            {
                if (_Attendees != value) {
                    _Attendees = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Attendees));
                }
            }
        }

        private List<GventAppendix> _Resources;
        public List<GventAppendix> Resources
        {
            get { return _Resources; }
            set
            {
                if (_Resources != value)
                {
                    _Resources = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Resources));
                }
            }
        }

        private GventStatus _Status;
        public GventStatus Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    NotifyChange(new GventEventArgs(this, GventChanges.Status));
                }
            }
        }

        public bool Processed { get; set; }

        public TimeSpan Length { get { return Stop - Start; } }

        public bool AllDay
        {
            get
            {
                var length = Length;

                var days = length.TotalDays;
                var hours = length.Hours;
                var minutes = length.Minutes;

                return ((days > 0) && (hours == 0) && (minutes == 0));
            }
        }

        public string LengthString
        {
            get
            {
                TimeSpan length = Length;

                int days = (int)Math.Floor(length.TotalDays);
                int hours = length.Hours;
                int minutes = length.Minutes;

                if (AllDay && days == 1)
                    return Properties.Resources.sAllDay;

                StringBuilder result = new StringBuilder();

                if (days > 0)
                {
                    result.Append(days);
                    if (days > 1) {
                        result.Append(" ");
                        result.Append(Properties.Resources.UnitDays);
                    }
                    else {
                        result.Append(" ");
                        result.Append(Properties.Resources.UnitDay);
                    }
                }

                if (hours > 0)
                {
                    if (result.Length > 0)
                        result.Append(" ");
                    result.Append(hours);
                    result.Append(" ");
                    result.Append(Properties.Resources.UnitHour);
                }

                if (minutes > 0)
                {
                    if (result.Length > 0)
                        result.Append(" ");
                    result.Append(minutes);
                    result.Append(" ");
                    result.Append(Properties.Resources.UnitMinute);
                }

                return result.ToString();
            }
        }

        public string WhenString
        {
            get
            {
                DateTime start = Start;
                DateTime stop = Stop;
                string when;

                // Time
                if (start.Date == stop.AddSeconds(-1).Date) {
                    if (start.Hour == 0 && start.Minute == 0 && stop.Hour == 0 && stop.Minute == 0)
                        when = "{0:ddd}, {0:m} ({2})";
                    else
                        when = "{0:ddd}, {0:m} {0:t} - {1:t} ({2})";
                }
                else {
                    if (start.Hour == 0 && start.Minute == 0 && stop.Hour == 0 && stop.Minute == 0)
                        when = "{0:ddd}, {0:m} - {1:ddd}, {1:m} ({2})";
                    else
                        when = "{0:ddd}, {0:m} {0:t} - {1:ddd}, {1:m} {1:t} ({2})";
                }

                return String.Format(when, start, stop, LengthString);
            }
        }

        public string GetDescriptionText()
        {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrEmpty(Calendar.Name)) {
                    sb.Append(Properties.Resources.sCalendar);
                    sb.Append(": ");
                    sb.AppendLine(Calendar.Name);
                }

                if (!string.IsNullOrEmpty(Location)) {
                    sb.Append(Properties.Resources.sLocation);
                    sb.Append(": ");
                    sb.AppendLine(Location);
                }

                if (Organizer != null && !Organizer.Self)
                {
                    sb.Append(Properties.Resources.sOrganizer);
                    sb.Append(": ");
                    sb.AppendLine(Organizer.Name);
                }

                return sb.ToString();
        }

        public string GetDescriptionHtml( bool Enhanced = false )
        {
            StringBuilder sb = new StringBuilder();

            // Title
            sb.Append("<h3 style=\"display: inline\">");
            if (!Enhanced || string.IsNullOrEmpty(this.Url)) {
                sb.Append(this.Title);
            }
            else {
                sb.Append("<a href=\"");
                sb.Append(this.Url);
                sb.Append("\">");
                sb.Append(this.Title);
                sb.Append("</a>");
            }
            sb.Append("</h3>");

            sb.Append("<br /><span style=\"font-size: small\">");
            // Time
            sb.Append(this.WhenString);

            // Location
            if (this.LocationResource != null) {
                sb.Append("<br />");
                sb.Append(this.LocationResource.Name);

                if (Enhanced) {
                    if (!string.IsNullOrEmpty(this.LocationResource.Url)) {
                        sb.Append("&nbsp;&nbsp;<a href=\"");
                        sb.Append(this.LocationResource.Url);
                        sb.Append("\" Title=\"");
                        sb.Append(this.LocationResource.Url);
                        sb.Append("\">");
                        sb.Append(Properties.Resources.sLinkLocation);
                        sb.Append("</a>");
                    }

                    if (!string.IsNullOrEmpty(this.LocationResource.UrlLayout)) {
                        sb.Append("&nbsp;&nbsp;<a href=\"");
                        sb.Append(this.LocationResource.UrlLayout);
                        sb.Append("\" Title=\"");
                        sb.Append(this.LocationResource.UrlLayout);
                        sb.Append("\">");
                        sb.Append(Properties.Resources.sLinkLayout);
                        sb.Append("</a>");
                    }

                    sb.Append("&nbsp;&nbsp;(<a href=\"");
                    sb.Append(string.Format(Properties.Resources.GoogleMapsLink, HttpUtility.UrlEncode(this.Location)));
                    sb.Append("\" Title=\"Google Maps Link\">");
                    sb.Append(Properties.Resources.sLinkGoogleMap);
                    sb.Append("</a>)");
                    sb.Append(this.LocationResource.Comment);
                }
            }
            else if (!string.IsNullOrEmpty(this.Location)) {
                sb.Append("<br />");
                sb.Append(this.Location);

                if (Enhanced) {
                    sb.Append("&nbsp;&nbsp;(<a href=\"");
                    sb.Append(string.Format(Properties.Resources.GoogleMapsLink, HttpUtility.UrlEncode(this.Location)));
                    sb.Append("\" Title=\"Google Maps Link\">");
                    sb.Append(Properties.Resources.sLinkGoogleMap);
                    sb.Append("</a>)");
                }
            }

            if (!string.IsNullOrEmpty(Calendar.Name)) {
                sb.Append("<br />");
                sb.Append(Properties.Resources.sCalendar);
                sb.Append(":&nbsp;");
                sb.AppendLine(Calendar.Name);
                sb.Append("<br />");
            }

            if (this.Organizer != null && !this.Organizer.Self) {
                sb.Append("<br />");
                sb.Append(Properties.Resources.sOrganizer);
                sb.Append(":&nbsp;");
                sb.Append(this.Organizer.Name);
            }
            sb.Append("</span>");

            if (Enhanced && !string.IsNullOrEmpty(this.Description)) {
                sb.Append("<br /><span style=\"font-size: small\">");
                sb.Append(this.Description);
                sb.Append("</span>");
            }


            if (Enhanced && this.Attendees.Count > 0) {
                sb.Append("<br /><span style=\"font-size: x-small\">");
                sb.Append(Properties.Resources.sAttendees);
                sb.Append(":&nbsp;");

                for (int i = 0; i < this.Attendees.Count; i++) {
                    if (i > 0)
                        sb.Append(", ");

                    sb.Append("<span style=\"");
                    {
                        var ev = this.Attendees[i];

                        if (ev.Optional)
                            sb.Append(" color:#888;");

                        if (ev.State == GventAppendixResponseStatus.Declined)
                            sb.Append(" text-decoration: line-through;");
                        else if (ev.State == GventAppendixResponseStatus.Tentative)
                            sb.Append(" font-style: italic;");

                        sb.Append("\">");

                        if (ev.State == GventAppendixResponseStatus.NeedsAction)
                            sb.Append("?");

                        if (!string.IsNullOrEmpty(ev.Url)) {
                            sb.Append("<a href=\"");
                            sb.Append(ev.Url);
                            sb.Append("\" Title=\"");
                            sb.Append(ev.Email);
                            sb.Append("\">");
                            sb.Append(ev.Name);
                            sb.Append("</a>");
                        }
                        else {
                            sb.Append("<span Title=\"");
                            sb.Append(ev.Email);
                            sb.Append("\">");
                            sb.Append(ev.Name);
                            sb.Append("</span>");
                        }
                    }
                    sb.Append("</span>");
                }
                sb.Append("</span>");
            }

            return sb.ToString();
        }
        #endregion

        #region Constructors
        public Gvent(Calendar calendar) 
        {
            _Attendees = new List<GventAppendix>();
            _Resources = new List<GventAppendix>();
            this.Calendar = calendar;
        }
        //Func<string, string> GetLocationUrl

        public Gvent( Event entry, Calendar calendar)
            : this(calendar)
        {
            if (entry == null)
                throw new ArgumentNullException("entry");

            _Id = entry.HtmlLink;
            Update(entry);
        }
        #endregion

        #region Methods
        public void Add(GVentMinder minder)
        {
            if (_Minders.Contains(minder))
                return;

            minder.GVent = this;
            _Minders.Add(minder);
            minder.Processed = true;
            NotifyChange(new GventEventArgs(this, GventChanges.AddedReminder));
        }

        public void Remove(GVentMinder minder)
        {
            if (!_Minders.Contains(minder))
                return;

            _Minders.Remove(minder);
            NotifyChange(new GventEventArgs(this, GventChanges.DeletedReminder));
        }

        public void AddResource(GventAppendix resource)
        {
             
            if (_Resources.Contains(resource))
                return;

            resource.GVent = this;
            _Resources.Add(resource);
            NotifyChange(new GventAppendixEventArgs(this, resource, GventChanges.AddedAppendix));
        }

        public void RemoveResource(GventAppendix resource)
        {
            if (!_Resources.Contains(resource))
                return;

            _Resources.Remove(resource);
            NotifyChange(new GventAppendixEventArgs(this, resource, GventChanges.DeletedAppendix));
        }

        public void AddAttendee( GventAppendix attendee )
        {
            if (_Attendees.Contains(attendee))
                return;
            attendee.GVent = this;
            _Attendees.Add(attendee);
            NotifyChange(new GventAppendixEventArgs(this, attendee, GventChanges.AddedAppendix));
        }

        public void RemoveAttendee( GventAppendix attendee )
        {
            if (!_Attendees.Contains(attendee))
                return;
            _Attendees.Remove(attendee);
            NotifyChange(new GventAppendixEventArgs(this, attendee, GventChanges.DeletedAppendix));
        }

        public bool Update( Event entry )
        {
            if (entry.HtmlLink != Id)
                return false;

            Title = (entry.Summary ?? string.Empty).Trim('\r', '\n', ' ');
            Url = entry.HtmlLink;
            HangoutUrl = entry.HangoutLink;

            // Location
            Location = ( entry.Location ?? string.Empty ).Trim('\r', '\n', ' ');

            //Description
            Description = (entry.Description ?? string.Empty).Trim('\r', '\n', ' ');
            if (!string.IsNullOrEmpty(Description))
            {
                string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
                Regex r = new Regex(regex, RegexOptions.IgnoreCase);
                Description = r.Replace(Description, "<a href=\"$1\" title=\"Click to open\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
            }

            //Organizer
            if (entry.Organizer != null)
                Organizer = new GventAppendix(this, entry.Organizer);

            //RecurrenceEvent
            IsRecurrence = (entry.Recurrence != null);

            foreach (var attendee in Attendees)
                attendee.Processed = false;

            foreach (var resource in Resources)
                resource.Processed = false; 
            
            if (entry.Attendees != null)
            {
                foreach (var attendee in entry.Attendees)
                {
                    if (attendee.Organizer == true)
                    {
                        if (Organizer == null)
                            Organizer = new GventAppendix(this, attendee);
                        else
                            Organizer.Update(attendee);
                    }
                    else if (attendee.Resource == true)
                    {
                        bool matched = false;
                        foreach (var res in Resources)
                        {
                            matched = (res.Name == attendee.DisplayName);
                            if (matched)
                            {
                                res.Update(attendee);
                                NotifyChange(new GventAppendixEventArgs(this, res, GventChanges.UpdatedAppendix));
                                break;
                            }
                        }
                        if (!matched)
                            AddResource(new GventAppendix(this, attendee));
                    }
                    else if (attendee.Self != true)
                    {
                        bool matched = false;
                        foreach (var att in Attendees)
                        {
                            matched = (att.Name == attendee.DisplayName);
                            if (matched)
                            {
                                att.Update(attendee);
                                NotifyChange(new GventAppendixEventArgs(this, att, GventChanges.UpdatedAppendix));
                                break;
                            }
                        }
                        if (!matched) 
                            AddAttendee(new GventAppendix(this, attendee));
                    }
                }
                Attendees.Sort();
                Resources.Sort();
            }

            for (int i = Attendees.Count -1; i >0; i--)
                if (!Attendees[i].Processed)
                    RemoveAttendee(Attendees[i]);

            for (int i = Resources.Count - 1; i > 0; i--)
                if (!Resources[i].Processed)
                    RemoveResource(Resources[i]);

            // Times
            if (entry.Start.DateTime == null)
            {
                Start = DateTime.Parse(entry.Start.Date);
            }
            else
            {
                Start = entry.Start.DateTime ?? new DateTime();
            }

            if (entry.End.DateTime == null)
            {
                Stop = DateTime.Parse(entry.End.Date);
            }
            else
            {
                Stop = entry.End.DateTime ?? new DateTime();
            }            

            foreach (var gminder in _Minders)
                gminder.Processed = false;
            
            IList<EventReminder> reminders = null;
            if (entry.Reminders != null)
            {
                if (entry.Reminders.UseDefault == true)
                {
                    reminders = this.Calendar.DefaultReminders;
                }
                else
                {
                    reminders = entry.Reminders.Overrides;
                }
            }

            if (reminders != null)
            {
                foreach (var reminder in reminders)
                {
                    if (reminder.Method == GReminder.REMINDER_TYPE_POPUP)
                    {
                        bool matched = false;

                        foreach (var minder in _Minders)
                        {
                            matched = minder.Update(reminder);
                            if (matched)
                                break;
                        }

                        if (!matched)
                            Add(new GVentMinder(reminder));
                    }
                }
            }

            foreach (var minder in _Minders.ToArray())
            {
                if (!minder.Processed)
                    Remove(minder);
            }

            Processed = true;
            return true;
        }

        public void Update(DateTime nowTime, DateTime soonTime)
        {
            if (Status == GventStatus.Dismissed)
                return;

            if (nowTime < Start)
            {
                if (_Minders.Count == 0)
                {
                    if (soonTime < Start)
                        Status = GventStatus.Future;
                    else
                        Status = GventStatus.Soon;
                }
                else
                {
                    bool isSoon = false;
                    foreach (var minder in _Minders)
                    {
                        minder.Update(nowTime);
                        isSoon = isSoon || minder.Done;
                    }

                    if (isSoon)
                        Status = GventStatus.Soon;
                    else
                        Status = GventStatus.Future;
                }
            }
            else if (nowTime < Stop)
                Status = GventStatus.Now;
            else
                Status = GventStatus.Past;
        }

        public void OpenBrowser()
        {
            if (!String.IsNullOrEmpty(Url))
            {
                try
                {
                    System.Diagnostics.Process.Start(Url);
                }
                catch (Exception e)
                {
                    Logging.LogException(false, e,
                        "Error opening event in browser",
                        String.Format("Event: {0}", Title),
                        String.Format("Url: {0}", Url));
                }
            }
        }

        public void Dismiss()
        {
            Status = GventStatus.Dismissed;
        }

        public int CompareTo(Gvent other)
        {
            if (this.Start > other.Start)
                return 1;
            if (this.Start < other.Start)
                return -1;
            if (!this.AllDay && other.AllDay)
                return 1;
            if (this.AllDay && !other.AllDay)
                return -1;
            return this.Id.CompareTo(other.Id);
        }

        private void NotifyChange(GventEventArgs e)
        {
            if (Calendar != null && Calendar.Schedule != null)
                Calendar.Schedule.NotifyChange(e);
        }
        private void NotifyChange(GventAppendixEventArgs e)
        {
            if (Calendar != null && Calendar.Schedule != null)
                Calendar.Schedule.NotifyChange(e);
        }
        #endregion

        #region Methods from IXmlSerializable - Serialization
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element && reader.LocalName == "Event")
            {
                _Id = reader["Id"];
                _Title = reader["Title"];
                _Location = reader["Location"];
                _Start = DateTime.FromBinary(Int64.Parse(reader["Start"]));
                _Stop = DateTime.FromBinary(Int64.Parse(reader["Stop"]));
                _Url = reader["Url"];
                _Status = (GventStatus)Int32.Parse(reader["Status"]);
                _Description = reader["Description"];
                _IsRecurrence = Convert.ToBoolean(reader["IsRecurrence"]);

                reader.ReadStartElement();

                while (reader.IsStartElement() && reader.LocalName != "Event")
                {
                    if (reader.LocalName == "Organizer") {
                        this._Organizer = new GventAppendix(this);
                        _Organizer.ReadXml(reader);
                    }
                    else if (reader.LocalName == "Attendee") {
                        var person = new GventAppendix(this);
                            person.ReadXml(reader);
                            AddAttendee(person);
                    }
                    else if (reader.LocalName == "Resource") {
                        var resource = new GventAppendix(this);
                        resource.ReadXml(reader);
                        AddResource(resource);
                    }
                    else if (reader.LocalName == "Reminder") {
                        var minder = new GVentMinder();
                        minder.ReadXml(reader);
                        Add(minder);
                    }
                    else {
                        Logging.LogException(false, new ArgumentException("found unknown Element " + reader.LocalName));
                        reader.Read();
                    }
                    //reader.Read();
                }
                if (!reader.IsEmptyElement && !reader.IsStartElement()) {
                    reader.ReadEndElement();
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", _Id);
            writer.WriteAttributeString("Title", _Title);
            writer.WriteAttributeString("Location", _Location);
            writer.WriteAttributeString("Start", _Start.ToBinary().ToString());
            writer.WriteAttributeString("Stop", _Stop.ToBinary().ToString());
            writer.WriteAttributeString("Url", _Url);
            writer.WriteAttributeString("Status", ((int)_Status).ToString());
            writer.WriteAttributeString("Description", _Description);
            writer.WriteAttributeString("IsRecurrence", _IsRecurrence.ToString().ToLower());

            if (_Organizer != null) {
                writer.WriteStartElement("Organizer");
                _Organizer.WriteXml(writer);
                writer.WriteEndElement();
            }
            
            foreach (var attendee in _Attendees)
            {
                writer.WriteStartElement("Attendee");
                attendee.WriteXml(writer);
                writer.WriteEndElement();
            }

            foreach (var resource in _Resources)
            {
                writer.WriteStartElement("Resource");
                resource.WriteXml(writer);
                writer.WriteEndElement();
            }

            foreach (var reminder in _Minders)
            {
                writer.WriteStartElement("Reminder");
                reminder.WriteXml(writer);
                writer.WriteEndElement();
            }
        }

        #endregion
    }

    public enum GventStatus
    {
        Future,
        Soon,
        Now,
        Past,
        Dismissed
    }
}
