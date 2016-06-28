using Himall.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.ServiceProvider;

namespace TaoLa.Web.Framework
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OperationLogAttribute : ActionFilterAttribute
    {
        public string ParameterNameList;

        public string Message
        {
            get;
            set;
        }

        public OperationLogAttribute()
        {
        }

        public OperationLogAttribute(string message, string parameterNameList = "")
        {
            this.Message = message;
            this.ParameterNameList = parameterNameList;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                string str = filterContext.RouteData.Values["controller"].ToString();
                string str2 = filterContext.RouteData.Values["action"].ToString();
                object obj = filterContext.RouteData.Values["area"];
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(this.Message + ",操作记录:");
                if (!string.IsNullOrEmpty(this.ParameterNameList))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    string[] array = this.ParameterNameList.Split(new char[]
                    {
                        ',',
                        '|'
                    });
                    for (int i = 0; i < array.Length; i++)
                    {
                        string key = array[i];
                        ValueProviderResult value = filterContext.Controller.ValueProvider.GetValue(key);
                        if (value != null && !dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, value.AttemptedValue);
                        }
                    }
                    foreach (KeyValuePair<string, string> current in dictionary)
                    {
                        stringBuilder.AppendFormat("{0}:{1} ", current.Key, current.Value);
                    }
                }
                LogInfo model = new LogInfo
                {
                    Date = DateTime.Now,
                    IPAddress = WebHelper.GetIP(),
                    UserName = (filterContext.Controller as BaseAdminController).CurrentManager.UserName,
                    PageUrl = str + "/" + str2,
                    Description = stringBuilder.ToString()
                };
                Task.Factory.StartNew(delegate
                {
                    Instance<IOperationLogService>.Create.AddPlatformOperationLog(model);
                });
                base.OnActionExecuted(filterContext);
            }
        }
    }
}
