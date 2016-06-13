using System;

namespace TaoLa.Core
{
	public class TypeHelper
	{
		public static int StringToInt(string s, int defaultValue)
		{
			int result;
			if (!string.IsNullOrWhiteSpace(s))
			{
				int num;
				if (int.TryParse(s, out num))
				{
					result = num;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}

		public static int StringToInt(string s)
		{
			return TypeHelper.StringToInt(s, 0);
		}

		public static int ObjectToInt(object o, int defaultValue)
		{
			int result;
			if (o != null)
			{
				result = TypeHelper.StringToInt(o.ToString(), defaultValue);
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static int ObjectToInt(object o)
		{
			return TypeHelper.ObjectToInt(o, 0);
		}

		public static bool StringToBool(string s, bool defaultValue)
		{
			return !(s == "false") && (s == "true" || defaultValue);
		}

		public static bool ToBool(string s)
		{
			return TypeHelper.StringToBool(s, false);
		}

		public static bool ObjectToBool(object o, bool defaultValue)
		{
			bool result;
			if (o != null)
			{
				result = TypeHelper.StringToBool(o.ToString(), defaultValue);
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static bool ObjectToBool(object o)
		{
			return TypeHelper.ObjectToBool(o, false);
		}

		public static System.DateTime StringToDateTime(string s, System.DateTime defaultValue)
		{
			System.DateTime result;
			if (!string.IsNullOrWhiteSpace(s))
			{
				System.DateTime dateTime;
				if (System.DateTime.TryParse(s, out dateTime))
				{
					result = dateTime;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}

		public static System.DateTime StringToDateTime(string s)
		{
			return TypeHelper.StringToDateTime(s, System.DateTime.Now);
		}

		public static System.DateTime ObjectToDateTime(object o, System.DateTime defaultValue)
		{
			System.DateTime result;
			if (o != null)
			{
				result = TypeHelper.StringToDateTime(o.ToString(), defaultValue);
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static System.DateTime ObjectToDateTime(object o)
		{
			return TypeHelper.ObjectToDateTime(o, System.DateTime.Now);
		}

		public static decimal StringToDecimal(string s, decimal defaultValue)
		{
			decimal result;
			if (!string.IsNullOrWhiteSpace(s))
			{
				decimal num;
				if (decimal.TryParse(s, out num))
				{
					result = num;
					return result;
				}
			}
			result = defaultValue;
			return result;
		}

		public static decimal StringToDecimal(string s)
		{
			return TypeHelper.StringToDecimal(s, 0m);
		}

		public static decimal ObjectToDecimal(object o, decimal defaultValue)
		{
			decimal result;
			if (o != null)
			{
				result = TypeHelper.StringToDecimal(o.ToString(), defaultValue);
			}
			else
			{
				result = defaultValue;
			}
			return result;
		}

		public static decimal ObjectToDecimal(object o)
		{
			return TypeHelper.ObjectToDecimal(o, 0m);
		}
	}
}
