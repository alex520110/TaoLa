using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace TaoLa.Core
{
    public static class EnumHelper
    {
        private static System.Collections.Hashtable enumDesciption = EnumHelper.GetDescriptionContainer();

        public static string ToDescription(this System.Enum value)
        {
            string result;
            if (value == null)
            {
                result = "";
            }
            else
            {
                System.Type type = value.GetType();
                string name = System.Enum.GetName(type, value);
                result = EnumHelper.GetDescription(type, name);
            }
            return result;
        }

        public static Dictionary<int, string> ToDescriptionDictionary<TEnum>()
        {
            System.Type typeFromHandle = typeof(TEnum);
            System.Array values = System.Enum.GetValues(typeFromHandle);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (System.Enum value in values)
            {
                dictionary.Add(System.Convert.ToInt32(value), value.ToDescription());
            }
            return dictionary;
        }

        public static Dictionary<int, string> ToDictionary<TEnum>()
        {
            System.Type typeFromHandle = typeof(TEnum);
            System.Array values = System.Enum.GetValues(typeFromHandle);
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (System.Enum @enum in values)
            {
                dictionary.Add(System.Convert.ToInt32(@enum), @enum.ToString());
            }
            return dictionary;
        }

        private static bool IsIntType(double d)
        {
            return (double)((int)d) != d;
        }

        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, bool perfix = true, bool onlyFlag = false)
        {
            var source = from TEnum e in System.Enum.GetValues(typeof(TEnum))
                         select new
                         {
                             Id = System.Convert.ToInt32(e),
                             Name = EnumHelper.GetDescription(typeof(TEnum), e.ToString())
                         };
            var list = source.ToList();
            var item = new
            {
                Id = 0,
                Name = "请选择..."
            };
            if (perfix)
            {
                list.Insert(0, item);
            }
            return new SelectList(list, "Id", "Name", enumObj);
        }

        private static System.Collections.Hashtable GetDescriptionContainer()
        {
            EnumHelper.enumDesciption = new System.Collections.Hashtable();
            return EnumHelper.enumDesciption;
        }

        private static void AddToEnumDescription(System.Type enumType)
        {
            EnumHelper.enumDesciption.Add(enumType, EnumHelper.GetEnumDic(enumType));
        }

        private static Dictionary<string, string> GetEnumDic(System.Type enumType)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            System.Reflection.FieldInfo[] array = fields;
            for (int i = 0; i < array.Length; i++)
            {
                System.Reflection.FieldInfo fieldInfo = array[i];
                if (fieldInfo.FieldType.IsEnum)
                {
                    object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    dictionary.Add(fieldInfo.Name, ((DescriptionAttribute)customAttributes[0]).Description);
                }
            }
            return dictionary;
        }

        private static string GetDescription(System.Type enumType, string enumText)
        {
            string result;
            if (string.IsNullOrEmpty(enumText))
            {
                result = null;
            }
            else
            {
                if (!EnumHelper.enumDesciption.ContainsKey(enumType))
                {
                    EnumHelper.AddToEnumDescription(enumType);
                }
                object obj = EnumHelper.enumDesciption[enumType];
                if (obj == null || string.IsNullOrEmpty(enumText))
                {
                    throw new System.ApplicationException("不存在枚举的描述");
                }
                Dictionary<string, string> dictionary = (Dictionary<string, string>)obj;
                result = dictionary[enumText];
            }
            return result;
        }
    }
}
