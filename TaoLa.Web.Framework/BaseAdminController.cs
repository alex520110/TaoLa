using System;
using System.Configuration;
using System.Web.Mvc;
using TaoLa.Core;
using Himall.Model;
using TaoLa.IServices;

namespace TaoLa.Web.Framework
{
    public abstract class BaseAdminController : BaseController
    {
        public IPaltManager CurrentManager
        {
            get
            {
                string cookie = WebHelper.GetCookie("TaoLa-PlatformManager");
                long num = UserCookieEncryptHelper.Decrypt(cookie, "Admin");
                IPaltManager result;
                if (num != 0L)
                {
                    object obj = Cache.Get(cookie);
                    if (null == obj)
                    {
                        obj = ServiceHelper.Create<IManagerService>().GetPlatformManager(num);
                        Cache.Insert(cookie, obj, DateTime.Now.AddMinutes(30.0));
                    }
                    result = (ManagerInfo)obj;
                }
                else
                {
                    result = null;
                }
                return result;
            }
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //  base.InitVisitorTerminal();
            string text = ConfigurationManager.AppSettings["IsInstalled"];
            if (text == null || bool.Parse(text))
            {
                if (!filterContext.IsChildAction)
                {
                    if (this.CurrentManager == null)
                    {
                        if (WebHelper.IsAjax())
                        {
                            filterContext.Result = base.Json(new BaseController.Result
                            {
                                msg = "登录超时,请重新登录！",
                                success = false
                            });
                        }
                        else
                        {
                            RedirectToRouteResult result = base.RedirectToAction("", "Login", new
                            {
                                area = "admin"
                            });
                            filterContext.Result = result;
                        }
                    }
                    else
                    {
                        object[] customAttributes = filterContext.ActionDescriptor.GetCustomAttributes(typeof(UnAuthorize), false);
                        if (customAttributes.Length != 1)
                        {
                            string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
                            string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
                            if (this.CurrentManager.AdminPrivileges == null || this.CurrentManager.AdminPrivileges.Count == 0 || !AdminPermission.CheckPermissions(this.CurrentManager.AdminPrivileges, controllerName, actionName))
                            {
                                if (WebHelper.IsAjax())
                                {
                                    filterContext.Result = base.Json(new BaseController.Result
                                    {
                                        msg = "你没有访问的权限！",
                                        success = false
                                    });
                                }
                                else
                                {
                                    ViewResult viewResult = new ViewResult
                                    {
                                        ViewName = "NoAccess"
                                    };
                                    viewResult.TempData.Add("Message", "你没有权限访问此页面");
                                    viewResult.TempData.Add("Title", "你没有权限访问此页面！");
                                    filterContext.Result = viewResult;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                string text = filterContext.RouteData.Values["controller"].ToString().ToLower();
                string text2 = filterContext.RouteData.Values["action"].ToString().ToLower();
            }
        }

        protected ActionResult SuccessfulRedirectView(string viewName, object routeData = null)
        {
            return base.RedirectToAction(viewName, routeData);
        }
    }
}
