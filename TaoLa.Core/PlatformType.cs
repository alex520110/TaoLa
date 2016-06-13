using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public enum PlatformType
    {
        [Description("PC")]
        PC,
        [Description("微信")]
        WeiXin,
        [Description("Android")]
        Android,
        [Description("IOS")]
        IOS,
        [Description("触屏")]
        Wap,
        [Description("移动端")]
        Mobile = 99
    }
}
