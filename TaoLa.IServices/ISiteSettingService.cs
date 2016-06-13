using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Model;

namespace TaoLa.IServices
{
    public interface ISiteSettingService : IService, IDisposable
    {
        SiteSettingsInfo GetSiteSettings();

        void SetSiteSettings(SiteSettingsInfo siteSettingsInfo);

        void SaveSetting(string key, object value);
    }
}
