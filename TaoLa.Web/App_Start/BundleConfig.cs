using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace TaoLa.Web
{
    public class BundleConfig
    {
        public BundleConfig()
        {
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add((new ScriptBundle("~/bundles/jquery")).Include("~/Scripts/jquery-{version}.js", new IItemTransform[0]));
            bundles.Add((new ScriptBundle("~/bundles/jqueryval")).Include("~/Scripts/jquery.validate*", new IItemTransform[0]));
            ScriptBundle scriptBundle = new ScriptBundle("~/bundles/bootstrap");
            string[] strArrays = new string[] { "~/Scripts/bootstrap.js", "~/Scripts/respond.js" };
            bundles.Add(scriptBundle.Include(strArrays));
            StyleBundle styleBundle = new StyleBundle("~/Content/css");
            strArrays = new string[] { "~/Content/bootstrap.css", "~/Content/site.css" };
            bundles.Add(styleBundle.Include(strArrays));
            BundleTable.EnableOptimizations = true;
        }
    }
}