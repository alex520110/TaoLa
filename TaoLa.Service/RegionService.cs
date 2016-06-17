using Himall.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaoLa.Core;
using TaoLa.IServices;

namespace TaoLa.Service
{
    public class RegionService : ServiceBase, IRegionService, IService, IDisposable
    {
        public RegionService()
        {
        }

        public int GetCityId(string regionIdPath)
        {
            int num = 0;
            if (!string.IsNullOrEmpty(regionIdPath))
            {
                string[] strArrays = new string[] { "," };
                string[] strArrays1 = regionIdPath.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
                if ((int)strArrays1.Length > 1)
                {
                    num = int.Parse(strArrays1[1]);
                }
            }
            return num;
        }

        public long GetCityIdByName(string CityName, long RegionId, bool NullGetFirst = false)
        {
            long id = (long)0;
            IEnumerable<ProvinceMode> regions = this.GetRegions();
            ProvinceMode provinceMode = regions.FirstOrDefault<ProvinceMode>((ProvinceMode d) => d.Id == RegionId);
            if (provinceMode != null)
            {
                CityMode cityMode = provinceMode.City.FirstOrDefault<CityMode>((CityMode d) => d.Name.Contains(CityName));
                if ((cityMode != null ? false : NullGetFirst))
                {
                    cityMode = provinceMode.City.FirstOrDefault<CityMode>();
                }
                if (cityMode != null)
                {
                    id = cityMode.Id;
                }
            }
            return id;
        }

        public IEnumerable<KeyValuePair<long, string>> GetRegion(long parentId)
        {
            IEnumerable<KeyValuePair<long, string>> county;
            IEnumerable<ProvinceMode> regions = this.GetRegions();
            if (parentId > (long)0)
            {
                ProvinceMode provinceMode = (
                    from item in regions
                    where item.Id == parentId
                    select item).FirstOrDefault<ProvinceMode>();
                if (provinceMode == null)
                {
                    foreach (ProvinceMode list in regions.ToList<ProvinceMode>())
                    {
                        CityMode cityMode = (
                            from item in list.City
                            where item.Id == parentId
                            select item).FirstOrDefault<CityMode>();
                        if ((cityMode == null || cityMode.County == null ? false : cityMode.County.Count<CountyMode>() > 0))
                        {
                            county =
                                from item in cityMode.County
                                select new KeyValuePair<long, string>(item.Id, item.Name);
                            return county;
                        }
                    }
                    county = null;
                }
                else
                {
                    county =
                        from item in provinceMode.City
                        select new KeyValuePair<long, string>(item.Id, item.Name);
                }
            }
            else
            {
                county =
                    from item in regions
                    select new KeyValuePair<long, string>(item.Id, item.Name);
            }
            return county;
        }

        public long GetRegionByIPInTaobao(string ip)
        {
            string str = "http://ip.taobao.com/service/getIpInfo.php?ip={0}";
            long num = (long)0;
            str = string.Format(str, ip);
            try
            {
                TaobaoIpDataModel taobaoIpDataModel = JsonConvert.DeserializeObject<TaobaoIpDataModel>(WebHelper.GetRequestData(str, ""));
                if ((taobaoIpDataModel == null ? false : taobaoIpDataModel.code == 0))
                {
                    if (!string.IsNullOrWhiteSpace(taobaoIpDataModel.data.region))
                    {
                        long regionIdByName = this.GetRegionIdByName(taobaoIpDataModel.data.region);
                        if (regionIdByName > (long)0)
                        {
                            long cityIdByName = (long)0;
                            if (!string.IsNullOrWhiteSpace(taobaoIpDataModel.data.city))
                            {
                                cityIdByName = this.GetCityIdByName(taobaoIpDataModel.data.city, regionIdByName, true);
                            }
                            num = cityIdByName;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                string message = exception.ToString();
            }
            return num;
        }

        public string GetRegionFullName(long regionId, string seperator = " ")
        {
            string name;
            List<ProvinceMode>.Enumerator enumerator = this.GetRegions().ToList<ProvinceMode>().GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ProvinceMode current = enumerator.Current;
                    if (current.Id != regionId)
                    {
                        List<CityMode>.Enumerator enumerator1 = current.City.ToList<CityMode>().GetEnumerator();
                        try
                        {
                            while (enumerator1.MoveNext())
                            {
                                CityMode cityMode = enumerator1.Current;
                                if (cityMode.Id == regionId)
                                {
                                    name = string.Concat(current.Name, seperator, cityMode.Name);
                                    return name;
                                }
                                else if (cityMode.County != null)
                                {
                                    List<CountyMode>.Enumerator enumerator2 = cityMode.County.ToList<CountyMode>().GetEnumerator();
                                    try
                                    {
                                        while (enumerator2.MoveNext())
                                        {
                                            CountyMode countyMode = enumerator2.Current;
                                            if (countyMode.Id != regionId)
                                            {
                                                continue;
                                            }
                                            string[] strArrays = new string[] { current.Name, seperator, cityMode.Name, seperator, countyMode.Name };
                                            name = string.Concat(strArrays);
                                            return name;
                                        }
                                    }
                                    finally
                                    {
                                        ((IDisposable)enumerator2).Dispose();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            ((IDisposable)enumerator1).Dispose();
                        }
                    }
                    else
                    {
                        name = current.Name;
                        return name;
                    }
                }
                name = string.Empty;
                return name;
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            return name;
        }

        public long GetRegionIdByName(string RegionName)
        {
            long id = (long)0;
            string shortAddressName = this.GetShortAddressName(RegionName);
            IEnumerable<ProvinceMode> regions = this.GetRegions();
            ProvinceMode provinceMode = regions.FirstOrDefault<ProvinceMode>((ProvinceMode d) => d.Name.Contains(shortAddressName));
            if (provinceMode != null)
            {
                id = provinceMode.Id;
            }
            return id;
        }

        public string GetRegionIdPath(long regionId)
        {
            string str;
            long id;
            List<ProvinceMode>.Enumerator enumerator = this.GetRegions().ToList<ProvinceMode>().GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ProvinceMode current = enumerator.Current;
                    if (current.Id != regionId)
                    {
                        List<CityMode>.Enumerator enumerator1 = current.City.ToList<CityMode>().GetEnumerator();
                        try
                        {
                            while (enumerator1.MoveNext())
                            {
                                CityMode cityMode = enumerator1.Current;
                                if (cityMode.Id == regionId)
                                {
                                    string str1 = current.Id.ToString();
                                    id = cityMode.Id;
                                    str = string.Concat(str1, ",", id.ToString());
                                    return str;
                                }
                                else if (cityMode.County != null)
                                {
                                    List<CountyMode>.Enumerator enumerator2 = cityMode.County.ToList<CountyMode>().GetEnumerator();
                                    try
                                    {
                                        while (enumerator2.MoveNext())
                                        {
                                            CountyMode countyMode = enumerator2.Current;
                                            if (countyMode.Id != regionId)
                                            {
                                                continue;
                                            }
                                            string[] strArrays = new string[5];
                                            id = current.Id;
                                            strArrays[0] = id.ToString();
                                            strArrays[1] = ",";
                                            id = cityMode.Id;
                                            strArrays[2] = id.ToString();
                                            strArrays[3] = ",";
                                            id = countyMode.Id;
                                            strArrays[4] = id.ToString();
                                            str = string.Concat(strArrays);
                                            return str;
                                        }
                                    }
                                    finally
                                    {
                                        ((IDisposable)enumerator2).Dispose();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            ((IDisposable)enumerator1).Dispose();
                        }
                    }
                    else
                    {
                        str = current.Id.ToString();
                        return str;
                    }
                }
                str = string.Empty;
                return str;
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            return str;
        }

        public string GetRegionName(string regionIds, string seperator)
        {
            string[] strArrays = new string[] { seperator };
            string[] strArrays1 = regionIds.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
            string empty = string.Empty;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                long num = long.Parse(strArrays1[i]);
                empty = string.Concat(empty, this.GetRegionName(num), seperator);
            }
            if (empty.EndsWith(seperator))
            {
                empty = empty.Substring(0, empty.Length - seperator.Length);
            }
            return empty;
        }

        private string GetRegionName(long regionId)
        {
            string name;
            List<ProvinceMode>.Enumerator enumerator = this.GetRegions().ToList<ProvinceMode>().GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ProvinceMode current = enumerator.Current;
                    if (current.Id != regionId)
                    {
                        List<CityMode>.Enumerator enumerator1 = current.City.ToList<CityMode>().GetEnumerator();
                        try
                        {
                            while (enumerator1.MoveNext())
                            {
                                CityMode cityMode = enumerator1.Current;
                                if (cityMode.Id == regionId)
                                {
                                    name = cityMode.Name;
                                    return name;
                                }
                                else if (cityMode.County != null)
                                {
                                    List<CountyMode>.Enumerator enumerator2 = cityMode.County.ToList<CountyMode>().GetEnumerator();
                                    try
                                    {
                                        while (enumerator2.MoveNext())
                                        {
                                            CountyMode countyMode = enumerator2.Current;
                                            if (countyMode.Id != regionId)
                                            {
                                                continue;
                                            }
                                            name = countyMode.Name;
                                            return name;
                                        }
                                    }
                                    finally
                                    {
                                        ((IDisposable)enumerator2).Dispose();
                                    }
                                }
                            }
                        }
                        finally
                        {
                            ((IDisposable)enumerator1).Dispose();
                        }
                    }
                    else
                    {
                        name = current.Name;
                        return name;
                    }
                }
                name = string.Empty;
                return name;
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
            return name;
        }

        public IEnumerable<ProvinceMode> GetRegions()
        {
            IEnumerable<ProvinceMode> provinceModes;
            if (Cache.Get("Cache-Regions") == null)
            {
                string empty = string.Empty;
                FileStream fileStream = new FileStream(IOHelper.GetMapPath("/Scripts/Region.js"), FileMode.Open);
                try
                {
                    StreamReader streamReader = new StreamReader(fileStream);
                    try
                    {
                        empty = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                }
                finally
                {
                    if (fileStream != null)
                    {
                        ((IDisposable)fileStream).Dispose();
                    }
                }
                empty = empty.Replace("var province=", "");
                provinceModes = JsonConvert.DeserializeObject<IEnumerable<ProvinceMode>>(empty);
                Cache.Insert("Cache-Regions", provinceModes);
            }
            else
            {
                provinceModes = (IEnumerable<ProvinceMode>)Cache.Get("Cache-Regions");
            }
            return provinceModes;
        }

        public string GetRegionShortName(long regionId)
        {
            string empty = string.Empty;
            foreach (ProvinceMode list in this.GetRegions().ToList<ProvinceMode>())
            {
                if (list.Id == regionId)
                {
                    empty = list.Name;
                }
                foreach (CityMode cityMode in list.City.ToList<CityMode>())
                {
                    if (cityMode.Id == regionId)
                    {
                        empty = string.Concat(list.Name, " ", cityMode.Name);
                    }
                    if (cityMode.County != null)
                    {
                        foreach (CountyMode countyMode in cityMode.County.ToList<CountyMode>())
                        {
                            if (countyMode.Id != regionId)
                            {
                                continue;
                            }
                            string[] name = new string[] { list.Name, " ", cityMode.Name, " ", countyMode.Name };
                            empty = string.Concat(name);
                        }
                    }
                }
            }
            return this.GetShortAddress(empty);
        }

        public string GetShortAddress(string regionFullName)
        {
            string empty = string.Empty;
            string[] strArrays = regionFullName.Split(new char[] { ' ' });
            if (!(strArrays[0] == "北京" || strArrays[0] == "上海" || strArrays[0] == "天津" ? false : !(strArrays[0] == "重庆")))
            {
                empty = strArrays[0];
            }
            else if (!strArrays[0].Contains("特别行政区"))
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(strArrays[0]);
                stringBuilder = stringBuilder.Replace("省", "");
                stringBuilder = stringBuilder.Replace("维吾尔", "");
                stringBuilder = stringBuilder.Replace("回族", "");
                stringBuilder = stringBuilder.Replace("壮族", "");
                stringBuilder = stringBuilder.Replace("自治区", "");
                StringBuilder stringBuilder1 = new StringBuilder();
                if ((int)strArrays.Length > 1)
                {
                    stringBuilder1.Append(strArrays[1]);
                    stringBuilder1 = stringBuilder1.Replace("市", "");
                    stringBuilder1 = stringBuilder1.Replace("盟", "");
                    stringBuilder1 = stringBuilder1.Replace("林区", "");
                    stringBuilder1 = stringBuilder1.Replace("地区", "");
                    stringBuilder1 = stringBuilder1.Replace("土家族", "");
                    stringBuilder1 = stringBuilder1.Replace("苗族", "");
                    stringBuilder1 = stringBuilder1.Replace("回族", "");
                    stringBuilder1 = stringBuilder1.Replace("黎族", "");
                    stringBuilder1 = stringBuilder1.Replace("藏族", "");
                    stringBuilder1 = stringBuilder1.Replace("傣族", "");
                    stringBuilder1 = stringBuilder1.Replace("彝族", "");
                    stringBuilder1 = stringBuilder1.Replace("哈尼族", "");
                    stringBuilder1 = stringBuilder1.Replace("壮族", "");
                    stringBuilder1 = stringBuilder1.Replace("白族", "");
                    stringBuilder1 = stringBuilder1.Replace("景颇族", "");
                    stringBuilder1 = stringBuilder1.Replace("傈僳族", "");
                    stringBuilder1 = stringBuilder1.Replace("朝鲜族", "");
                    stringBuilder1 = stringBuilder1.Replace("蒙古", "");
                    stringBuilder1 = stringBuilder1.Replace("哈萨克", "");
                    stringBuilder1 = stringBuilder1.Replace("柯尔克孜", "");
                    stringBuilder1 = stringBuilder1.Replace("自治州", "");
                    stringBuilder1 = stringBuilder1.Replace("自治县", "");
                    stringBuilder1 = stringBuilder1.Replace("县", "");
                }
                empty = string.Concat(stringBuilder.ToString(), stringBuilder1.ToString());
            }
            else
            {
                empty = strArrays[0].Replace("特别行政区", "");
            }
            return empty;
        }

        private string GetShortAddressName(string str)
        {
            string str1 = str.Replace("特别行政区", "");
            str1 = str1.Replace("省", "");
            str1 = str1.Replace("维吾尔", "");
            str1 = str1.Replace("回族", "");
            str1 = str1.Replace("壮族", "");
            str1 = str1.Replace("自治区", "");
            str1 = str1.Replace("市", "");
            str1 = str1.Replace("盟", "");
            str1 = str1.Replace("林区", "");
            str1 = str1.Replace("地区", "");
            str1 = str1.Replace("土家族", "");
            str1 = str1.Replace("苗族", "");
            str1 = str1.Replace("回族", "");
            str1 = str1.Replace("黎族", "");
            str1 = str1.Replace("藏族", "");
            str1 = str1.Replace("傣族", "");
            str1 = str1.Replace("彝族", "");
            str1 = str1.Replace("哈尼族", "");
            str1 = str1.Replace("壮族", "");
            str1 = str1.Replace("白族", "");
            str1 = str1.Replace("景颇族", "");
            str1 = str1.Replace("傈僳族", "");
            str1 = str1.Replace("朝鲜族", "");
            str1 = str1.Replace("蒙古", "");
            str1 = str1.Replace("哈萨克", "");
            str1 = str1.Replace("柯尔克孜", "");
            str1 = str1.Replace("自治州", "");
            str1 = str1.Replace("自治县", "");
            return str1.Replace("县", "");
        }
    }
}
