using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class MessageController : BaseAdminController
    {
        private ISiteSettingService _iSiteSettingService;

        //private IWXMsgTemplateService _iWXMsgTemplateService;

        private string wxtmppluginsid = "Himall.Plugin.Message.WXTMMSG";

        public MessageController(ISiteSettingService iSiteSettingService)
        {
            this._iSiteSettingService = iSiteSettingService;
        }
        public ActionResult Management()
        {
            //IEnumerable<object> objs = PluginsManagement.GetPlugins<IMessagePlugin>().Select<Plugin<IMessagePlugin>, object>((Plugin<IMessagePlugin> item) => {
            //    dynamic expandoObjects = new ExpandoObject();
            //    expandoObjects.name = item.PluginInfo.DisplayName;
            //    expandoObjects.pluginId = item.PluginInfo.PluginId;
            //    expandoObjects.enable = item.PluginInfo.Enable;
            //    expandoObjects.status = item.Biz.GetAllStatus();
            //    return expandoObjects;
            //});

            return View();
        }
    }
}