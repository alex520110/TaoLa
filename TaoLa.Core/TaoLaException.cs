using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class TaoLaException : ApplicationException
    {
        public TaoLaException()
        {
            Log.Info(Message, this);
        }

        public TaoLaException(string message) : base(message)
        {
            Log.Info(message, this);
        }

        public TaoLaException(string message, Exception inner) : base(message, inner)
        {
            Log.Info(message, inner);
        }
    }
}
