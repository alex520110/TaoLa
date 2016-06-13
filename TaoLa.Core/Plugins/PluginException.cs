using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class PluginException : TaoLaException
    {
        public PluginException()
        {
            Log.Info(this.Message, this);
        }

        public PluginException(string message) : base(message)
        {
            Log.Info(message, this);
        }

        public PluginException(string message, System.Exception inner) : base(message, inner)
        {
            Log.Info(message, inner);
        }
    }
}
