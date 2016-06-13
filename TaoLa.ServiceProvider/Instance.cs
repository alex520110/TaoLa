using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using Autofac.Configuration.Core;
using Autofac.Configuration.Elements;
using TaoLa.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Proxies;
using TaoLa.AOPProxy;
using TaoLa.Core;

namespace TaoLa.ServiceProvider
{
    public class Instance<T> where T : IService
    {
        public static T Create
        {
            get
            {
                return ObjectContainer.Current.Resolve<T>();
            }
        }
    }
}
