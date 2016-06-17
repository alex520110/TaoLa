using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface IRegionService : IService, IDisposable
    {
        IEnumerable<ProvinceMode> GetRegions();

        IEnumerable<KeyValuePair<long, string>> GetRegion(long parentId);

        string GetRegionIdPath(long regionId);

        string GetRegionFullName(long regionId, string seperator = " ");

        string GetRegionName(string regionIds, string seperator = ",");

        int GetCityId(string regionIdPath);

        string GetRegionShortName(long regionId);

        long GetRegionIdByName(string RegionName);

        long GetCityIdByName(string CityName, long RegionId, bool NullGetFirst = false);

        long GetRegionByIPInTaobao(string ip);
    }
}
