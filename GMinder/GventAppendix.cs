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

using System;
using Google.Apis.Calendar.v3.Data;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Xml;
using System.Collections.Generic;

namespace ReflectiveCode.GMinder
{
    [Serializable]
    public class GventAppendix :  GVentElement, IXmlSerializable, IComparer<GventAppendix>, IComparable
    {
        public const string UNDEFINED = "undefined";
        public const string RESPONSE_STATUS_ACCEPTED = "accepted";
        public const string RESPONSE_STATUS_DECLINED = "declined";
        public const string RESPONSE_STATUS_NEEDS_ACTION = "needsaction";
        public const string RESPONSE_STATUS_TENTATIVE = "tentative";
        public const string DEFAULT_NAME = "NoName";

        public const string RESOURCETYPE_ORGANISATOR = "organisator";
        public const string RESOURCETYPE_ATTENDEE = "attendee";
        public const string RESOURCETYPE_RESOURCE = "Resource";

        #region Properties
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        private string _Url;
        public string Url
        {
            get
            {
                if (string.IsNullOrEmpty(this._Url))
                    return _Url;
                else if (!string.IsNullOrEmpty(this.Email) &&
                        this.Type != GventAppendixType.Resource)
                    return "mailto:" + this.Email;
                else
                    return string.Empty;
            }
            set
            {
                if (value != this.Url) {
                    this._Url = value;
                }
            }
        }

        public string UrlLayout { get; set; }
        public bool Optional { get; set; }
        public bool Self { get; set; }
        public GventAppendixType Type { get; set; }
        public GventAppendixResponseStatus State { get; set; }

        public string StateName
        {
            get
            {
                switch (this.State) {
                    case GventAppendixResponseStatus.Accepted:
                        return Properties.Resources.PersonStateAccepted;
                    case GventAppendixResponseStatus.Declined:
                        return Properties.Resources.PersonStateDeclined;
                    case GventAppendixResponseStatus.Tentative:
                        return Properties.Resources.PersonStateTentative;
                    case GventAppendixResponseStatus.NeedsAction:
                        return Properties.Resources.PersonStateNeedsAction;
                    default:
                        return string.Empty;
                }
            }
        }
        #endregion

        #region Constructor
        public GventAppendix( Gvent gevent )
            : base(gevent)
        {
		    this.Id = string.Empty;
            this.Name = DEFAULT_NAME;
            this.Email = string.Empty;
            this.Url = string.Empty;
            this.UrlLayout = string.Empty;
            this.Comment = string.Empty;
			this.Type = GventAppendixType.None;
            this.State = GventAppendixResponseStatus.None;
            this.Processed = true;
        }

        public GventAppendix(Gvent gevent, string id, string name)
            : this(gevent)
        {
            this.Id = (id ?? string.Empty);
            this.Name = (name ?? DEFAULT_NAME);
            this.Processed = true;
        }

        public GventAppendix( Gvent gevent, EventAttendee Attendee )
            : this(gevent)
        {
			this.Update(Attendee);
        }

        public GventAppendix( Gvent gevent, Event.OrganizerData Organizer )
            : this(gevent)
        {
            this.Update(Organizer);
        }
        #endregion

        #region Methods
        public void Update(EventAttendee Attendee)
        {
			if (Attendee == null)
				return;

            if (Attendee.Resource == true)
                this.Type = GventAppendixType.Resource;
            else if (Attendee.Organizer == true)
                this.Type = GventAppendixType.Organisator;
            else
                this.Type = GventAppendixType.Attendee;

            if (this.Type == GventAppendixType.Resource) {
                if (GVent != null && Name == GVent.Location)
                    GVent.LocationResource = this;
            }

            if (Attendee.Id != null)
                this.Id = Attendee.Id.Trim('\r', '\n', ' ');
				
            if (Attendee.DisplayName != null)
                this.Name = Attendee.DisplayName.Trim('\r', '\n', ' ');

            if (Attendee.Email != null)
                this.Email = Attendee.Email.Trim();
            
            if (Attendee.Comment != null)
                this.Comment = Attendee.Comment.Trim('\r', '\n', ' ');

            if (Attendee.Optional != null)
                this.Optional = ( Attendee.Optional == true );

            if (Attendee.Self != null)
                this.Self = ( Attendee.Self == true );

            switch (Attendee.ResponseStatus.ToLower())
            {
                case RESPONSE_STATUS_ACCEPTED:
                    this.State = GventAppendixResponseStatus.Accepted;
                    break;
                case RESPONSE_STATUS_DECLINED:
                    this.State = GventAppendixResponseStatus.Declined;
                    break;
                case RESPONSE_STATUS_NEEDS_ACTION:
                    this.State = GventAppendixResponseStatus.NeedsAction;
                    break;
                case RESPONSE_STATUS_TENTATIVE:
                    this.State = GventAppendixResponseStatus.Tentative;
                    break;
                default:
                    this.State = GventAppendixResponseStatus.None;
                    break;
            }


            this.Processed = true;
        }

        public void Update( Event.OrganizerData Organizer )
        {
            this.Type = GventAppendixType.Organisator;

            if (Organizer == null)
                return;

            if (Organizer.Id != null)
                this.Id = Organizer.Id.Trim('\r', '\n', ' ');

            if (Organizer.DisplayName != null)
                this.Name = Organizer.DisplayName.Trim('\r', '\n', ' ');

            if (Organizer.Email != null)
                this.Email = Organizer.Email.Trim();

            if (Organizer.Self != null)
                this.Self = ( Organizer.Self == true );

            if (GVent != null)
                GVent.Organizer = this;

            this.Processed = true;
        }

        public override string ToString()
        {
            string name = Name;
            if (!string.IsNullOrEmpty(Email) && Name != Email)
                name = string.Format("{0} <{1}>", Name, Email);

            string state = StateName;
            if (string.IsNullOrEmpty(state)) {
                return string.Format(Properties.Resources.PersonToString, name, Email);
            }

            return string.Format(Properties.Resources.PersonToStringState, name, Email, state);
        }
        #endregion

        #region Serialization
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToContent() == XmlNodeType.Element &&
                ( reader.LocalName == "Organizer" ||
                reader.LocalName.IndexOf("Attendee") > -1 ||
                reader.LocalName.IndexOf("Resource") > -1 ))
            {
                Id = reader["Id"];
                Name = reader["Name"];
                Email = reader["Email"];
                Comment = reader["Comment"];
                _Url = reader["Url"];
                Optional = Convert.ToBoolean(reader["Optional"]);
                Self = Convert.ToBoolean(reader["Self"]);
                State = (GventAppendixResponseStatus)Int32.Parse(reader["State"]);
                Type = (GventAppendixType)Int32.Parse(reader["Type"]);                
                reader.Read();
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", Id);
            writer.WriteAttributeString("Name", Name);
            writer.WriteAttributeString("Email", Email);
            writer.WriteAttributeString("Comment", Comment);
            writer.WriteAttributeString("Url", _Url);
            writer.WriteAttributeString("Optional", ( Optional ).ToString().ToLower());
            writer.WriteAttributeString("Self", ( Self ).ToString().ToLower());
            writer.WriteAttributeString("State", ( (int)State ).ToString());
            writer.WriteAttributeString("Type", ((int)Type).ToString());
        }
        #endregion

        #region IComparer, IComparable Member

        public int Compare( GventAppendix a1, GventAppendix a2 )
        {
            if (a1 == null && a2 == null)
                return 0;
            else if (a1 == null)
                return 1;
            else if (a2 == null)
                return -1;

            int cmp = a1.Type.CompareTo(a2.Type);
            if (cmp == 0) {
                cmp = a1.Optional.CompareTo(a2.Optional);
                if (cmp == 0) {
                    cmp = a1.State.CompareTo(a2.State);
                    if (cmp == 0) {
                        return a1.Name.CompareTo(a2.Name);
                    }
                }
            }
            return cmp;
        }

        public int CompareTo( object obj )
        {
            return this.Compare(this, obj as GventAppendix);
        }

        #endregion
    }

    [Serializable]
    public enum GventAppendixType
    {
        [XmlEnum(GventAppendix.UNDEFINED)]
        None = 0,
        [XmlEnum(GventAppendix.RESOURCETYPE_ORGANISATOR)]
        Organisator = 1,
        [XmlEnum(GventAppendix.RESOURCETYPE_ATTENDEE)]
        Attendee = 1 << 1,
        [XmlEnum(GventAppendix.RESOURCETYPE_RESOURCE)]
        Resource = 1 << 3
    }
    
    [Serializable]
    public enum GventAppendixResponseStatus
    {
        [XmlEnum(GventAppendix.UNDEFINED)]
        None = 0,
        [XmlEnum(GventAppendix.RESPONSE_STATUS_ACCEPTED)]
        Accepted = 1,
        [XmlEnum(GventAppendix.RESPONSE_STATUS_DECLINED)]
        Declined = 1 << 1,
        [XmlEnum(GventAppendix.RESPONSE_STATUS_NEEDS_ACTION)]
        NeedsAction = 1 << 2,
        [XmlEnum(GventAppendix.RESPONSE_STATUS_TENTATIVE)]
        Tentative = 1 << 3
    }
}