using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Core
{
    public class InstanceCreateException : TaoLaException
    {
        public InstanceCreateException()
        {
        }

        public InstanceCreateException(string message) : base(message)
        {
        }

        public InstanceCreateException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
