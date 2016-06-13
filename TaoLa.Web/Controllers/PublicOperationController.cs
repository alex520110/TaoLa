using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaoLa.Core;

namespace TaoLa.Web.Controllers
{
    public class PublicOperationController : Controller
    {
        public PublicOperationController()
        {
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            object obj;
            string str = "NoFile";
            if (base.Request.Files.Count > 0)
            {
                HttpPostedFileBase item = base.Request.Files[0];
                if (item.ContentLength != 0)
                {
                    Random random = new Random();
                    DateTime now = DateTime.Now;
                    string str1 = string.Concat(now.ToString("yyyyMMddHHmmssfff"), random.Next(1000, 9999), item.FileName.Substring(item.FileName.LastIndexOf("\\") + 1));
                    string str2 = base.Server.MapPath("~/temp/");
                    if (!Directory.Exists(str2))
                    {
                        Directory.CreateDirectory(str2);
                    }
                    string str3 = str1;
                    try
                    {
                        obj = Cache.Get("Cache-UserImportOpCount");
                        if (obj != null)
                        {
                            Cache.Insert("Cache-UserImportOpCount", int.Parse(obj.ToString()) + 1);
                        }
                        else
                        {
                            Cache.Insert("Cache-UserImportOpCount", 1);
                        }
                        item.SaveAs(Path.Combine(str2, str1));
                    }
                    catch (Exception exception1)
                    {
                        Exception exception = exception1;
                        obj = Cache.Get("Cache-UserImportOpCount");
                        if (obj != null)
                        {
                            Cache.Insert("Cache-UserImportOpCount", int.Parse(obj.ToString()) - 1);
                        }
                        Log.Error(string.Concat("商品导入上传文件异常：", exception.Message));
                        str3 = "Error";
                    }
                    str = str3;
                }
                else
                {
                    str = "文件长度为0,格式异常。";
                }
            }
            return base.Content(str, "text/html");
        }

        [HttpPost]
        public ActionResult UploadPic()
        {
            ActionResult actionResult;
            string str = "";
            string str1 = "";
            List<string> strs = new List<string>();
            if (base.Request.Files.Count != 0)
            {
                int num = 0;
                while (num < base.Request.Files.Count)
                {
                    HttpPostedFileBase item = base.Request.Files[num];
                    if ((item == null ? false : item.ContentLength > 0))
                    {
                        Random random = new Random();
                        DateTime now = DateTime.Now;
                        str1 = string.Concat(now.ToString("yyyyMMddHHmmssffffff"), num, Path.GetExtension(item.FileName));
                        string str2 = base.Server.MapPath("~/temp/");
                        if (!Directory.Exists(str2))
                        {
                            Directory.CreateDirectory(str2);
                        }
                        str = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "/temp/");
                        strs.Add(string.Concat("/temp/", str1));
                        try
                        {
                            item.SaveAs(Path.Combine(str, str1));
                        }
                        catch (Exception exception)
                        {
                        }
                        num++;
                    }
                    else
                    {
                        actionResult = base.Content("格式不正确！", "text/html");
                        return actionResult;
                    }
                }
                actionResult = base.Content(string.Join(",", strs), "text/html");
            }
            else
            {
                actionResult = base.Content("NoFile", "text/html");
            }
            return actionResult;
        }

        public ActionResult UploadPictures()
        {
            return base.View();
        }
    }
}