using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaoLa.Core;
using TaoLa.IServices;
using Himall.Model;

namespace TaoLa.Web.Framework
{
    public abstract class BaseController : Controller
    {
        public bool IsAutoJumpMobile = false;

        protected List<JumpUrlRoute> _JumpUrlRouteData
        {
            get;
            set;
        }
        public BaseController()
        {
            HttpContext current = System.Web.HttpContext.Current;
            if (this.IsInstalled())
            {
                ((dynamic)base.ViewBag).SEODescription = this.CurrentSiteSetting.Site_SEODescription;
                ((dynamic)base.ViewBag).SEOKeyword = this.CurrentSiteSetting.Site_SEOKeywords;
                ((dynamic)base.ViewBag).FlowScript = this.CurrentSiteSetting.FlowScript;
            }
            else
            {
                base.RedirectToAction("/Web/Installer/Agreement");
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.JumpMobileUrl(filterContext.RouteData, "");
            base.OnActionExecuting(filterContext);
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //this.InitVisitorTerminal();
            if ((!this.IsInstalled() ? false : this.CurrentSiteSetting.SiteIsClose))
            {
                if (filterContext.RouteData.Values["controller"].ToString().ToLower() != "admin")
                {
                    filterContext.Result = new RedirectResult("/common/site/close");
                }
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            BaseController.Result result;
            Exception exception = this.GerInnerException(filterContext.Exception);
            string message = exception.Message;
            base.OnException(filterContext);
            if (!(exception is TaoLaException))
            {
                string str = filterContext.RouteData.Values["controller"].ToString();
                string str1 = filterContext.RouteData.Values["action"].ToString();
                object item = filterContext.RouteData.DataTokens["area"];
                string str2 = string.Format("页面未捕获的异常：Area:{0},Controller:{1},Action:{2}", item, str, str1);
                Log.Error(str2, exception);
                message = "系统内部异常";
            }
            if (WebHelper.IsAjax())
            {
                result = new BaseController.Result()
                {
                    success = false,
                    msg = message,
                    status = -9999
                };
                filterContext.Result = base.Json(result);
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.ExceptionHandled = true;
                this.DisposeService(filterContext);
            }
            if (exception is HttpRequestValidationException)
            {
                if (!WebHelper.IsAjax())
                {
                    ContentResult contentResult = new ContentResult()
                    {
                        Content = "<script src='/Scripts/jquery-1.11.1.min.js'></script>"
                    };
                    ContentResult contentResult1 = contentResult;
                    contentResult1.Content = string.Concat(contentResult1.Content, "<script src='/Scripts/jquery.artDialog.js'></script>");
                    ContentResult contentResult2 = contentResult;
                    contentResult2.Content = string.Concat(contentResult2.Content, "<script src='/Scripts/artDialog.iframeTools.js'></script>");
                    ContentResult contentResult3 = contentResult;
                    contentResult3.Content = string.Concat(contentResult3.Content, "<link href='/Content/artdialog.css' rel='stylesheet' />");
                    ContentResult contentResult4 = contentResult;
                    contentResult4.Content = string.Concat(contentResult4.Content, "<link href='/Content/bootstrap.min.css' rel='stylesheet' />");
                    ContentResult contentResult5 = contentResult;
                    contentResult5.Content = string.Concat(contentResult5.Content, "<script>$(function(){$.dialog.errorTips('您提交了非法字符！',function(){window.history.back(-1)},2);});</script>");
                    filterContext.Result = contentResult;
                }
                else
                {
                    result = new BaseController.Result()
                    {
                        msg = "您提交了非法字符!"
                    };
                    filterContext.Result = base.Json(result);
                }
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.ExceptionHandled = true;
                this.DisposeService(filterContext);
            }
        }
        protected Exception GerInnerException(Exception ex)
        {
            Exception exception;
            exception = (ex.InnerException == null ? ex : this.GerInnerException(ex.InnerException));
            return exception;
        }

        private void DisposeService(ControllerContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                List<IService> item = filterContext.HttpContext.Session["_serviceInstace"] as List<IService>;
                if (item != null)
                {
                    foreach (IService service in item)
                    {
                        try
                        {
                            service.Dispose();
                        }
                        catch (Exception exception1)
                        {
                            Exception exception = exception1;
                            Log.Error(string.Concat(service.GetType().ToString(), "释放失败！"), exception);
                        }
                    }
                    filterContext.HttpContext.Session["_serviceInstace"] = null;
                }
            }
        }
        protected void JumpMobileUrl(RouteData route, string url = "")
        {
            string pathAndQuery = base.Request.Url.PathAndQuery;
            string wX = pathAndQuery;
            if (route != null)
            {
                string lower = route.Values["controller"].ToString().ToLower();
                string str = route.Values["action"].ToString().ToLower();
                string str1 = (route.DataTokens["area"] == null ? "" : route.DataTokens["area"].ToString().ToLower());
                if (!(str1 == "mobile"))
                {
                    if (str1 == "web")
                    {
                        this.IsAutoJumpMobile = true;
                    }
                    if ((!this.IsAutoJumpMobile ? false : this.IsMobileTerminal))
                    {
                        if (Regex.Match(pathAndQuery, "\\/m(\\-.*)?").Length < 1)
                        {
                            JumpUrlRoute routeUrl = this.GetRouteUrl(lower, str, str1, pathAndQuery);
                            switch (this.visitorTerminalInfo.Terminal)
                            {
                                case EnumVisitorTerminal.WeiXin:
                                    {
                                        if (routeUrl != null)
                                        {
                                            wX = routeUrl.WX;
                                        }
                                        wX = string.Concat("/m-weixin", wX);
                                        break;
                                    }
                                case EnumVisitorTerminal.IOS:
                                    {
                                        if (routeUrl != null)
                                        {
                                            wX = routeUrl.WAP;
                                        }
                                        wX = string.Concat("/m-ios", wX);
                                        break;
                                    }
                                default:
                                    {
                                        if (routeUrl != null)
                                        {
                                            wX = routeUrl.WAP;
                                        }
                                        wX = string.Concat("/m-wap", wX);
                                        break;
                                    }
                            }
                            if (routeUrl.IsSpecial)
                            {
                                if (routeUrl.PC.ToLower() == "/shop")
                                {
                                    //string str2 = route.Values["id"].ToString();
                                    //long num = (long)0;
                                    //long id = (long)0;
                                    //if (!long.TryParse(str2, out num))
                                    //{
                                    //    num = (long)0;
                                    //}
                                    //if (num > (long)0)
                                    //{
                                    //    VShopInfo vShopByShopId = ServiceHelper.Create<IVShopService>().GetVShopByShopId(num);
                                    //    if (vShopByShopId != null)
                                    //    {
                                    //        id = vShopByShopId.Id;
                                    //    }
                                    //}
                                    //wX = string.Concat(wX, "/", id.ToString());
                                }
                                if (routeUrl.PC.ToLower() == "/order/submit")
                                {
                                    string empty = string.Empty;
                                    object item = route.Values["cartitemids"];
                                    empty = (item != null ? item.ToString() : base.Request.QueryString["cartitemids"]);
                                    wX = string.Concat(wX, "/?cartItemIds=", empty);
                                }
                            }
                            if (!string.IsNullOrWhiteSpace(url))
                            {
                                wX = url;
                            }
                            if (!this.IsExistPage(string.Concat(base.Request.Url.Scheme, "://", base.Request.Url.Authority, wX)))
                            {
                                wX = (this.visitorTerminalInfo.Terminal != EnumVisitorTerminal.WeiXin ? "/m-wap/" : "/m-weixin/");
                            }
                            base.Response.Redirect(wX);
                        }
                    }
                }
            }
        }

        private bool IsExistPage(string url)
        {
            bool flag = false;
            HttpWebResponse uRLResponse = WebHelper.GetURLResponse(url, "get", "", null, 20000);
            if (uRLResponse != null)
            {
                if ((uRLResponse.StatusCode == HttpStatusCode.OK || uRLResponse.StatusCode == HttpStatusCode.Found ? true : uRLResponse.StatusCode == HttpStatusCode.MovedPermanently))
                {
                    flag = true;
                }
            }
            return flag;
        }
        public VisitorTerminal visitorTerminalInfo
        {
            get;
            set;
        }
        public bool IsMobileTerminal
        {
            get;
            set;
        }
        public JumpUrlRoute GetRouteUrl(string controller, string action, string area, string url)
        {
            JumpUrlRoute item;
            string lower = controller;
            string str = action;
            string lower1 = area;
            this.InitJumpUrlRoute();
            JumpUrlRoute jumpUrlRoute = null;
            url = url.ToLower();
            lower = lower.ToLower();
            str = str.ToLower();
            lower1 = lower1.ToLower();
            List<JumpUrlRoute> jumpUrlRouteData = this.JumpUrlRouteData;
            if (!string.IsNullOrWhiteSpace(lower1))
            {
                jumpUrlRouteData = jumpUrlRouteData.FindAll((JumpUrlRoute d) => d.Area.ToLower() == lower1);
            }
            if (!string.IsNullOrWhiteSpace(lower))
            {
                jumpUrlRouteData = jumpUrlRouteData.FindAll((JumpUrlRoute d) => d.Controller.ToLower() == lower);
            }
            if (!string.IsNullOrWhiteSpace(str))
            {
                jumpUrlRouteData = jumpUrlRouteData.FindAll((JumpUrlRoute d) => d.Action.ToLower() == str);
            }
            if (jumpUrlRouteData.Count > 0)
            {
                item = jumpUrlRouteData[0];
            }
            else
            {
                item = null;
            }
            jumpUrlRoute = item;
            if (jumpUrlRoute == null)
            {
                JumpUrlRoute jumpUrlRoute1 = new JumpUrlRoute()
                {
                    PC = url,
                    WAP = url,
                    WX = url
                };
                jumpUrlRoute = jumpUrlRoute1;
            }
            return jumpUrlRoute;
        }

        public void InitJumpUrlRoute()
        {
            this._JumpUrlRouteData = new List<JumpUrlRoute>();
            JumpUrlRoute jumpUrlRoute = new JumpUrlRoute()
            {
                Action = "Index",
                Area = "Web",
                Controller = "UserOrder",
                PC = "/userorder",
                WAP = "/member/orders",
                WX = "/member/orders"
            };
            this._JumpUrlRouteData.Add(jumpUrlRoute);
            JumpUrlRoute jumpUrlRoute1 = new JumpUrlRoute()
            {
                Action = "Index",
                Area = "Web",
                Controller = "UserCenter",
                PC = "/usercenter",
                WAP = "/member/center",
                WX = "/member/center"
            };
            this._JumpUrlRouteData.Add(jumpUrlRoute1);
            JumpUrlRoute jumpUrlRoute2 = new JumpUrlRoute()
            {
                Action = "Index",
                Area = "Web",
                Controller = "Login",
                PC = "/login",
                WAP = "/login/entrance",
                WX = "/login/entrance"
            };
            this._JumpUrlRouteData.Add(jumpUrlRoute2);
            JumpUrlRoute jumpUrlRoute3 = new JumpUrlRoute()
            {
                Action = "Home",
                Area = "Web",
                Controller = "Shop",
                PC = "/shop",
                WAP = "/vshop/detail",
                WX = "/vshop/detail",
                IsSpecial = true
            };
            this._JumpUrlRouteData.Add(jumpUrlRoute3);
            JumpUrlRoute jumpUrlRoute4 = new JumpUrlRoute()
            {
                Action = "Submit",
                Area = "Web",
                Controller = "Order",
                PC = "/order/submit",
                WAP = "/order/SubmiteByCart",
                WX = "/order/SubmiteByCart",
                IsSpecial = true
            };
            this._JumpUrlRouteData.Add(jumpUrlRoute4);
        }
        public List<JumpUrlRoute> JumpUrlRouteData
        {
            get
            {
                return this._JumpUrlRouteData;
            }
        }
        public SiteSettingsInfo CurrentSiteSetting
        {
            get
            {
                return ServiceHelper.Create<ISiteSettingService>().GetSiteSettings();
            }
        }
        private bool IsInstalled()
        {
            string item = ConfigurationManager.AppSettings["IsInstalled"];
            if (item == null)
            {
                return true;
            }
            return bool.Parse(item);
        }

        public class Result
        {
            public string msg
            {
                get;
                set;
            }

            public int status
            {
                get;
                set;
            }

            public bool success
            {
                get;
                set;
            }

            public Result()
            {
            }
        }

    }


}
