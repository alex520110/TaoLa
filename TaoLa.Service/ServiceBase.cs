using Himall.Entity;
using System;
using System.Data.Entity;


namespace TaoLa.Service
{
    public class ServiceBase
    {
        protected Entities context = null;

        public ServiceBase()
        {
            this.context = new Entities();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }
    }
}
