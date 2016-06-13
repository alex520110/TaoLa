using Autofac;
using Autofac.Builder;
using Autofac.Configuration;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;

namespace TaoLa.Web
{
    public class AutoFacContainer : IinjectContainer
    {
        private ContainerBuilder builder;

        private IContainer container;

        public AutoFacContainer()
        {
            this.builder = new ContainerBuilder();
            this.SetupResolveRules(this.builder);
            ContainerBuilder containerBuilder = this.builder;
            Assembly[] executingAssembly = new Assembly[] { Assembly.GetExecutingAssembly() };
            containerBuilder.RegisterControllers(executingAssembly);
            this.container = this.builder.Build(ContainerBuildOptions.None);
            DependencyResolver.SetResolver((IDependencyResolver)(new AutofacDependencyResolver(this.container)));
        }

        public void RegisterType<T>()
        {
            this.builder.RegisterType<T>();
        }

        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }

        private void SetupResolveRules(ContainerBuilder builder)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("TaoLa.IServices");
            System.Reflection.Assembly assembly2 = System.Reflection.Assembly.Load("TaoLa.Service");
            (from t in builder.RegisterAssemblyTypes(new System.Reflection.Assembly[]
            {
                assembly2,
                assembly
            })
             where t.Name.EndsWith("Service")
             select t).AsImplementedInterfaces<object>();
            ConfigurationSettingsReader module = new ConfigurationSettingsReader("autofac");
            builder.RegisterModule(module);
        }
    }
}