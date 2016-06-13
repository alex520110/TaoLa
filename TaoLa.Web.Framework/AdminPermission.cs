using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Himall.Model;

namespace TaoLa.Web.Framework
{
    public static class AdminPermission
    {
        private static readonly Dictionary<AdminPrivilege, IEnumerable<ActionPermission>> privileges;

        public static bool CheckPermissions(List<AdminPrivilege> userprivileages, string controllerName, string actionName)
        {
            return userprivileages.Contains((AdminPrivilege)0) || (from a in AdminPermission.privileges
                                                                   where userprivileages.Contains(a.Key)
                                                                   select a).Any((KeyValuePair<AdminPrivilege, IEnumerable<ActionPermission>> b) => b.Value.Any((ActionPermission c) => c.ControllerName.ToLower() == controllerName.ToLower() && c.ActionName.ToLower() == actionName.ToLower()));
        }
    }
}
