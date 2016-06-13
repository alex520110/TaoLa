using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class PluginNotFoundException : PluginException
    {
        public PluginNotFoundException(string pluginId) : base("未找到插件" + pluginId)
        {
        }
    }
}
