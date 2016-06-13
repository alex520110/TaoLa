using Himall.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private IManagerService _iManagerService;

        public LoginController(IManagerService iManagerService)
        {
            this._iManagerService = iManagerService;
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            ActionResult action;
            string item = ConfigurationManager.AppSettings["IsInstalled"];
            if ((item == null ? true : bool.Parse(item)))
            {
                action = View();
            }
            else
            {
                action = base.RedirectToAction("Agreement", "Installer", new { area = "Web" });
            }
            return action;
        }
        [HttpPost]
        public JsonResult Login(string username, string password, string checkCode)
        {
            int num;
            JsonResult jsonResult;
            string host = System.Web.HttpContext.Current.Request.Url.Host;
            try
            {
                this.CheckInput(username, password);
                this.CheckCheckCode(username, checkCode);
                ManagerInfo managerInfo = this._iManagerService.Login(username, password, true);
                if (managerInfo == null)
                {
                    throw new TaoLaException("用户名和密码不匹配");
                }
                this.ClearErrorTimes(username);
                jsonResult = base.Json(new { success = true, userId = UserCookieEncryptHelper.Encrypt(managerInfo.Id, "Admin") });
            }
            catch (TaoLaException himallException1)
            {
                TaoLaException ex = himallException1;
                num = this.SetErrorTimes(username);
                jsonResult = base.Json(new { success = false, msg = ex.Message, errorTimes = num, minTimesWithoutCheckCode = 3 });
            }
            catch (Exception exception2)
            {
                Exception exception = exception2;
                num = this.SetErrorTimes(username);
                Exception exception1 = base.GerInnerException(exception);
                string message = "未知错误";
                if (!(exception1 is TaoLaException))
                {
                    Log.Error(string.Concat("用户", username, "登录时发生异常"), exception);
                }
                else
                {
                    message = exception1.Message;
                }
                jsonResult = base.Json(new { success = false, msg = message, errorTimes = num, minTimesWithoutCheckCode = 3 });
            }
            return jsonResult;
        }
        /// <summary>
        /// 验证表单  记录日志
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        private void CheckInput(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new TaoLaException("请填写用户名");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new TaoLaException("请填写密码");
            }
        }
        /// <summary>
        /// 验证 错误次数
        /// </summary>
        /// <param name="username"></param>
        /// <param name="checkCode"></param>
        private void CheckCheckCode(string username, string checkCode)
        {
            if (this.GetErrorTimes(username) >= 3)
            {
                if (string.IsNullOrWhiteSpace(checkCode))
                {
                    throw new TaoLaException("30分钟内登录错误3次以上需要提供验证码");
                }
                if ((base.Session["checkCode"] as string).ToLower() != checkCode.ToLower())
                {
                    throw new TaoLaException("验证码错误");
                }
                base.Session["checkCode"] = Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// 获取缓存中 错误次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private int GetErrorTimes(string username)
        {
            object obj = Cache.Get(CacheKeyCollection.ManagerLoginError(username));
            return (obj == null ? 0 : (int)obj);
        }
        /// <summary>
        /// 清除登陆缓存错误次数记录
        /// </summary>
        /// <param name="username"></param>
        private void ClearErrorTimes(string username)
        {
            Cache.Remove(CacheKeyCollection.ManagerLoginError(username));
        }
        /// <summary>
        /// 设置 登陆错误次数 记录
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private int SetErrorTimes(string username)
        {
            int errorTimes = this.GetErrorTimes(username) + 1;
            string str = CacheKeyCollection.ManagerLoginError(username);
            object obj = errorTimes;
            DateTime now = DateTime.Now;
            Cache.Insert(str, obj, now.AddMinutes(30));
            return errorTimes;
        }
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCheckCode()
        {
            string str;
            MemoryStream memoryStream = ImageHelper.GenerateCheckCode(out str);
            base.Session["checkCode"] = str;
            return base.File(memoryStream.ToArray(), "image/png");
        }
    }
}