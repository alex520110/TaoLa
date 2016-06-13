using TaoLa.Core;
using Himall.Entity;
using TaoLa.IServices;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Himall.Model;

namespace TaoLa.Service
{
    public class SiteSettingService : ServiceBase, ISiteSettingService, IService, IDisposable
    {
        public SiteSettingService()
        {
        }

        public SiteSettingsInfo GetSiteSettings()
        {
            SiteSettingsInfo siteSettingsInfo;
            if (Cache.Get("Cache-SiteSettings") == null)
            {
                IEnumerable<SiteSettingsInfo> array = this.context.SiteSettingsInfo.FindAll<SiteSettingsInfo>().ToArray<SiteSettingsInfo>();
                siteSettingsInfo = new SiteSettingsInfo();
                PropertyInfo[] properties = siteSettingsInfo.GetType().GetProperties();
                for (int i = 0; i < (int)properties.Length; i++)
                {
                    PropertyInfo propertyInfo = properties[i];
                    if (propertyInfo.Name != "Id")
                    {
                        SiteSettingsInfo siteSettingsInfo1 = array.FirstOrDefault<SiteSettingsInfo>((SiteSettingsInfo item) => item.Key == propertyInfo.Name);
                        if (siteSettingsInfo1 != null)
                        {
                            propertyInfo.SetValue(siteSettingsInfo, Convert.ChangeType(siteSettingsInfo1.Value, propertyInfo.PropertyType));
                        }
                    }
                }
                Cache.Insert("Cache-SiteSettings", siteSettingsInfo);
            }
            else
            {
                siteSettingsInfo = (SiteSettingsInfo)Cache.Get("Cache-SiteSettings");
            }
            return siteSettingsInfo;
        }

        public void SaveSetting(string key, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("值不能为null");
            }
            if (typeof(SiteSettingsInfo).GetProperties().FirstOrDefault<PropertyInfo>((PropertyInfo item) => item.Name == key) == null)
            {
                throw new ApplicationException(string.Concat("未找到", key, "对应的配置项"));
            }
            SiteSettingsInfo siteSettingsInfo = this.context.SiteSettingsInfo.FindBy<SiteSettingsInfo>((SiteSettingsInfo item) => item.Key == key).FirstOrDefault<SiteSettingsInfo>();
            if (siteSettingsInfo == null)
            {
                siteSettingsInfo = new SiteSettingsInfo();
                this.context.SiteSettingsInfo.Add(siteSettingsInfo);
            }
            siteSettingsInfo.Key = key;
            siteSettingsInfo.Value = value.ToString();
            this.context.SaveChanges();
            Cache.Remove("Cache-SiteSettings");
        }

        public void SetSiteSettings(SiteSettingsInfo siteSettingsInfo)
        {
            string str;
            PropertyInfo[] properties = siteSettingsInfo.GetType().GetProperties();
            IEnumerable<SiteSettingsInfo> array = this.context.SiteSettingsInfo.FindAll<SiteSettingsInfo>().ToArray<SiteSettingsInfo>();
            PropertyInfo[] propertyInfoArray = properties;
            for (int i = 0; i < (int)propertyInfoArray.Length; i++)
            {
                PropertyInfo propertyInfo = propertyInfoArray[i];
                object value = propertyInfo.GetValue(siteSettingsInfo);
                str = (value == null ? "" : value.ToString());
                if (propertyInfo.Name != "Id")
                {
                    SiteSettingsInfo siteSettingsInfo1 = array.FirstOrDefault<SiteSettingsInfo>((SiteSettingsInfo item) => item.Key == propertyInfo.Name);
                    if (siteSettingsInfo1 != null)
                    {
                        siteSettingsInfo1.Value = str;
                    }
                    else
                    {
                        DbSet<SiteSettingsInfo> siteSettingsInfos = this.context.SiteSettingsInfo;
                        SiteSettingsInfo siteSettingsInfo2 = new SiteSettingsInfo()
                        {
                            Key = propertyInfo.Name,
                            Value = str
                        };
                        siteSettingsInfos.Add(siteSettingsInfo2);
                    }
                }
            }
            IEnumerable<string> name =
                from item in (IEnumerable<PropertyInfo>)properties
                select item.Name;
            this.context.SiteSettingsInfo.RemoveRange(
                from item in array
                where !name.Contains<string>(item.Key)
                select item);
            this.context.SaveChanges();
            Cache.Remove("Cache-SiteSettings");
        }
    }
}
