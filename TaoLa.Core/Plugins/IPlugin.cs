using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public interface IPlugin
    {
        string WorkDirectory
        {
            set;
        }

        void CheckCanEnable();
    }
}
