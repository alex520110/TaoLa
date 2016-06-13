using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TaoLa.IServices;
using TaoLa.ServiceProvider;

namespace TaoLa.Web.Framework
{
    public static class ServiceHelper
    {
        public static T Create<T>()
      where T : IService
        {
            T create = Instance<T>.Create;
            if (HttpContext.Current != null)
            {
                List<IService> item = HttpContext.Current.Session["_serviceInstace"] as List<IService>;
                if (item != null)
                {
                    item.Add(create);
                }
                else
                {
                    item = new List<IService>()
                    {
                        create
                    };
                }
                HttpContext.Current.Session["_serviceInstace"] = item;
            }
            return create;
        }
    }
}
