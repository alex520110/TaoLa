using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;

namespace TaoLa.ServiceProvider
{
    public class ServiceInstacnceCreateException : TaoLaException
    {
        public ServiceInstacnceCreateException()
        {
        }

        public ServiceInstacnceCreateException(string message) : base(message)
        {
        }

        public ServiceInstacnceCreateException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
