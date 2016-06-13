using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Web.Framework
{
    public class ActionPermission
    {
        public string ActionName
        {
            get;
            set;
        }

        public string ControllerName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
