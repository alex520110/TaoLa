using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class Plugin<T> : PluginBase where T : IPlugin
    {
        public T Biz
        {
            get;
            set;
        }
    }
}
