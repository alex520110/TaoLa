using Himall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaoLa.Web.Framework
{
    public class PrivilegeHelper
    {
        private static Privileges adminPrivileges;

        private static Privileges sellerAdminPrivileges;

        private static Privileges userPrivileges;

        public static Privileges UserPrivileges
        {
            get
            {
                if (PrivilegeHelper.userPrivileges == null)
                {
                    PrivilegeHelper.userPrivileges = PrivilegeHelper.GetPrivileges<UserPrivilege>();
                }
                return PrivilegeHelper.userPrivileges;
            }
            set
            {
                PrivilegeHelper.userPrivileges = value;
            }
        }

        public static Privileges AdminPrivileges
        {
            get
            {
                if (PrivilegeHelper.adminPrivileges == null)
                {
                    PrivilegeHelper.adminPrivileges = PrivilegeHelper.GetPrivileges<AdminPrivilege>();
                }
                return PrivilegeHelper.adminPrivileges;
            }
            set
            {
                PrivilegeHelper.adminPrivileges = value;
            }
        }

        public static Privileges SellerAdminPrivileges
        {
            get
            {
                if (PrivilegeHelper.sellerAdminPrivileges == null)
                {
                    PrivilegeHelper.sellerAdminPrivileges = PrivilegeHelper.GetPrivileges<SellerPrivilege>();
                }
                return PrivilegeHelper.sellerAdminPrivileges;
            }
            set
            {
                PrivilegeHelper.sellerAdminPrivileges = value;
            }
        }

        public static Privileges GetPrivileges<TEnum>()
        {
            Func<PrivilegeAttribute, bool> func = null;
            Type typeFromHandle = typeof(TEnum);
            FieldInfo[] fields = typeFromHandle.GetFields();
            Privileges result;
            if (fields.Length == 1)
            {
                result = null;
            }
            else
            {
                Privileges privileges = new Privileges();
                FieldInfo[] array = fields;
                for (int i = 0; i < array.Length; i++)
                {
                    FieldInfo fieldInfo = array[i];
                    object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(PrivilegeAttribute), true);
                    if (customAttributes.Length != 0)
                    {
                        GroupActionItem group = new GroupActionItem();
                        ActionItem actionItem = new ActionItem();
                        List<string> list = new List<string>();
                        List<PrivilegeAttribute> list2 = new List<PrivilegeAttribute>();
                        List<Controllers> list3 = new List<Controllers>();
                        object[] array2 = customAttributes;
                        for (int j = 0; j < array2.Length; j++)
                        {
                            object obj = array2[j];
                            Controllers controllers = new Controllers();
                            PrivilegeAttribute privilegeAttribute = obj as PrivilegeAttribute;
                            controllers.ControllerName = privilegeAttribute.Controller;
                            controllers.ActionNames.AddRange(privilegeAttribute.Action.Split(new char[]
                            {
                                ','
                            }));
                            list3.Add(controllers);
                            list2.Add(privilegeAttribute);
                        }
                        IEnumerable<PrivilegeAttribute> arg_13A_0 = list2;
                        if (func == null)
                        {
                            func = ((PrivilegeAttribute a) => !string.IsNullOrEmpty(a.GroupName));
                        }
                        PrivilegeAttribute privilegeAttribute2 = arg_13A_0.FirstOrDefault(func);
                        group.GroupName = privilegeAttribute2.GroupName;
                        actionItem.PrivilegeId = privilegeAttribute2.Pid;
                        actionItem.Name = privilegeAttribute2.Name;
                        actionItem.Url = privilegeAttribute2.Url;
                        actionItem.Controllers.AddRange(list3);
                        GroupActionItem groupActionItem = privileges.Privilege.FirstOrDefault((GroupActionItem a) => a.GroupName == group.GroupName);
                        if (groupActionItem == null)
                        {
                            group.Items.Add(actionItem);
                            privileges.Privilege.Add(group);
                        }
                        else
                        {
                            groupActionItem.Items.Add(actionItem);
                        }
                    }
                }
                result = privileges;
            }
            return result;
        }
    }
}
