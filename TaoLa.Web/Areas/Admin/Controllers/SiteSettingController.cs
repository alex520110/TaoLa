using AutoMapper;
using Himall.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;
using TaoLa.IServices;
using TaoLa.Web.Areas.Admin.Models;
using TaoLa.Web.Framework;

namespace TaoLa.Web.Areas.Admin.Controllers
{
    public class SiteSettingController : BaseAdminController
    {
        private ISiteSettingService _iSiteSettingService;

        public SiteSettingController(ISiteSettingService iSiteSettingService)
        {
            this._iSiteSettingService = iSiteSettingService;
        }


        // GET: Admin/SiteSetting
        public ActionResult Index()
        {
            SiteSettingsInfo siteSettings = this._iSiteSettingService.GetSiteSettings();
            Mapper.CreateMap<SiteSettingsInfo, SiteSettingModel>().ForMember((SiteSettingModel a) => (dynamic)a.SiteIsOpen, (IMemberConfigurationExpression<SiteSettingsInfo> b) => b.MapFrom<bool>((SiteSettingsInfo s) => s.SiteIsClose));
            return base.View(Mapper.Map<SiteSettingsInfo, SiteSettingModel>(siteSettings));
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Index(SiteSettingModel siteSettingModel)
        {
            JsonResult jsonResult;
            if (!string.IsNullOrWhiteSpace(siteSettingModel.WXLogo))
            {
                string mapPath = IOHelper.GetMapPath(siteSettingModel.Logo);
                string str = IOHelper.GetMapPath(siteSettingModel.MemberLogo);
                string mapPath1 = IOHelper.GetMapPath(siteSettingModel.QRCode);
                string str1 = IOHelper.GetMapPath(siteSettingModel.PCLoginPic);
                string str2 = string.Concat("logo", (new FileInfo(mapPath)).Extension);
                string str3 = string.Concat("memberLogo", (new FileInfo(mapPath)).Extension);
                string str4 = string.Concat("qrCode", (new FileInfo(mapPath)).Extension);
                string str5 = string.Concat("pcloginpic", (new FileInfo(mapPath)).Extension);
                string str6 = "/Storage/Plat/Site/";
                string mapPath2 = IOHelper.GetMapPath(str6);
                if (!Directory.Exists(mapPath2))
                {
                    Directory.CreateDirectory(mapPath2);
                }
                if (!siteSettingModel.Logo.Contains("/Storage"))
                {
                    IOHelper.CopyFile(mapPath, mapPath2, false, str2);
                }
                if (!siteSettingModel.MemberLogo.Contains("/Storage"))
                {
                    IOHelper.CopyFile(str, mapPath2, false, str3);
                }
                if (!siteSettingModel.QRCode.Contains("/Storage"))
                {
                    IOHelper.CopyFile(mapPath1, mapPath2, false, str4);
                }
                if (siteSettingModel.PCLoginPic != null)
                {
                    if (!siteSettingModel.PCLoginPic.Contains("/Storage"))
                    {
                        IOHelper.CopyFile(str1, mapPath2, true, str5);
                        siteSettingModel.PCLoginPic = Path.Combine(str6, str5);
                    }
                }
                if (!siteSettingModel.WXLogo.Contains("/Storage"))
                {
                    string str7 = string.Concat(str6, "wxlogo.png");
                    string mapPath3 = IOHelper.GetMapPath(siteSettingModel.WXLogo);
                    string mapPath4 = IOHelper.GetMapPath(str7);
                    Image image = Image.FromFile(mapPath3);
                    try
                    {
                        image.Save(string.Concat(mapPath3, ".png"), ImageFormat.Png);
                        if (System.IO.File.Exists(mapPath4))
                        {
                            System.IO.File.Delete(mapPath4);
                        }
                        ImageHelper.CreateThumbnail(string.Concat(mapPath3, ".png"), mapPath4, 100, 100);
                    }
                    finally
                    {
                        if (image != null)
                        {
                            ((IDisposable)image).Dispose();
                        }
                    }
                    siteSettingModel.WXLogo = str7;
                }
                BaseController.Result result = new BaseController.Result();
                SiteSettingsInfo siteSettings = this._iSiteSettingService.GetSiteSettings();
                siteSettings.SiteName = siteSettingModel.SiteName;
                siteSettings.SiteIsClose = siteSettingModel.SiteIsOpen;
                siteSettings.Logo = string.Concat(str6, str2);
                siteSettings.MemberLogo = string.Concat(str6, str3);
                siteSettings.QRCode = string.Concat(str6, str4);
                siteSettings.FlowScript = siteSettingModel.FlowScript;
                siteSettings.Site_SEOTitle = siteSettingModel.Site_SEOTitle;
                siteSettings.Site_SEOKeywords = siteSettingModel.Site_SEOKeywords;
                siteSettings.Site_SEODescription = siteSettingModel.Site_SEODescription;
                siteSettings.MobileVerifOpen = siteSettingModel.MobileVerifOpen;
                siteSettings.WXLogo = siteSettingModel.WXLogo;
                siteSettings.PCLoginPic = siteSettingModel.PCLoginPic;
                siteSettings.AndriodDownLoad = siteSettingModel.AndriodDownLoad;
                siteSettings.IOSDownLoad = siteSettingModel.IOSDownLoad;
                siteSettings.CanDownload = siteSettingModel.CanDownload;
                this._iSiteSettingService.SetSiteSettings(siteSettings);
                result.success = true;
                jsonResult = base.Json(result);
            }
            else
            {
                BaseController.Result result1 = new BaseController.Result()
                {
                    success = false,
                    msg = "请上传微信Logo",
                    status = 1
                };
                jsonResult = base.Json(result1);
            }
            return jsonResult;
        }
    }
}