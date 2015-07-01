using Google.Apis.Calendar.v3.Data;
using System;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ReflectiveCode.GMinder
{
    [Serializable]
    public abstract class GVentElement 
    {
        #region Constructor
        public GVentElement()
        {
        }

        public GVentElement(Gvent gevent)
        {
            this.GVent = gevent;
        }
        #endregion


        #region Properties

        private Gvent _GVent;
        public Gvent GVent
        {
            get { return _GVent; }
            set
            {
                if (_GVent == null || _GVent == value)
                    _GVent = value;
                else
                    throw new InvalidOperationException("A GVentElement's owning Gvent cannot be changed");
            }
        }

        public bool Processed { get; set; }

        #endregion
    }
}
