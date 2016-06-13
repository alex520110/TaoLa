using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.IServices
{
    public interface IShopService : IService, IDisposable
    {
        ShopInfo GetShop(long id, bool businessCategoryOn = false);


        PlatConsoleModel GetPlatConsoleMode();
    }
}
