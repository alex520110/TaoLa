using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TaoLa.Core
{
    public class PluginInfo
    {
        public string PluginId
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public string ClassFullName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string PluginDirectory
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        [XmlIgnore]
        public System.Collections.Generic.IEnumerable<PluginType> PluginTypes
        {
            get
            {
                return from item in this.Type.Split(new char[]
                {
                    ','
                })
                       select (PluginType)int.Parse(item);
            }
        }

        public string Author
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public System.DateTime? AddedTime
        {
            get;
            set;
        }

        public string MinHimallVersion
        {
            get;
            set;
        }

        public string MaxHimallVersion
        {
            get;
            set;
        }

        public string Logo
        {
            get;
            set;
        }

        public bool Enable
        {
            get;
            set;
        }

        public int DisplayIndex
        {
            get;
            set;
        }
    }
}
