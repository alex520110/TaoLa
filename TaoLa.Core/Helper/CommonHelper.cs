using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TaoLa.Core
{
	public class CommonHelper
	{
		private static string[] _weekdays = new string[]
		{
			"星期日",
			"星期一",
			"星期二",
			"星期三",
			"星期四",
			"星期五",
			"星期六"
		};

		private static Regex _tbbrRegex = new Regex("\\s*|\\t|\\r|\\n", RegexOptions.IgnoreCase);

		public static string GetDateTimeMS()
		{
			return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
		}

		public static string GetDateTimeU()
		{
			return string.Format("{0:U}", System.DateTime.Now);
		}

		public static string GetDateTime()
		{
			return System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		public static string GetDate()
		{
			return System.DateTime.Now.ToString("yyyy-MM-dd");
		}

		public static string GetChineseDate()
		{
			return System.DateTime.Now.ToString("yyyy月MM日dd");
		}

		public static string GetTime()
		{
			return System.DateTime.Now.ToString("HH:mm:ss");
		}

		public static string GetHour()
		{
			return System.DateTime.Now.Hour.ToString("00");
		}

		public static string GetDay()
		{
			return System.DateTime.Now.Day.ToString("00");
		}

		public static string GetMonth()
		{
			return System.DateTime.Now.Month.ToString("00");
		}

		public static string GetYear()
		{
			return System.DateTime.Now.Year.ToString();
		}

		public static string GetDayOfWeek()
		{
			return ((int)System.DateTime.Now.DayOfWeek).ToString();
		}

		public static string GetWeek()
		{
			return CommonHelper._weekdays[(int)System.DateTime.Now.DayOfWeek];
		}

		public static int GetIndexInArray(string s, string[] array, bool ignoreCase)
		{
			int result;
			if (string.IsNullOrEmpty(s) || array == null || array.Length == 0)
			{
				result = -1;
			}
			else
			{
				int num = 0;
				if (ignoreCase)
				{
					s = s.ToLower();
				}
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					string b;
					if (ignoreCase)
					{
						b = text.ToLower();
					}
					else
					{
						b = text;
					}
					if (s == b)
					{
						result = num;
						return result;
					}
					num++;
				}
				result = -1;
			}
			return result;
		}

		public static int GetIndexInArray(string s, string[] array)
		{
			return CommonHelper.GetIndexInArray(s, array, false);
		}

		public static bool IsInArray(string s, string[] array, bool ignoreCase)
		{
			return CommonHelper.GetIndexInArray(s, array, ignoreCase) > -1;
		}

		public static bool IsInArray(string s, string[] array)
		{
			return CommonHelper.IsInArray(s, array, false);
		}

		public static bool IsInArray(string s, string array, string splitStr, bool ignoreCase)
		{
			return CommonHelper.IsInArray(s, StringHelper.SplitString(array, splitStr), ignoreCase);
		}

		public static bool IsInArray(string s, string array, string splitStr)
		{
			return CommonHelper.IsInArray(s, StringHelper.SplitString(array, splitStr), false);
		}

		public static bool IsInArray(string s, string array)
		{
			return CommonHelper.IsInArray(s, StringHelper.SplitString(array, ","), false);
		}

		public static string ObjectArrayToString(object[] array, string splitStr)
		{
			string result;
			if (array == null || array.Length == 0)
			{
				result = "";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.AppendFormat("{0}{1}", array[i], splitStr);
				}
				result = stringBuilder.Remove(stringBuilder.Length - splitStr.Length, splitStr.Length).ToString();
			}
			return result;
		}

		public static string ObjectArrayToString(object[] array)
		{
			return CommonHelper.ObjectArrayToString(array, ",");
		}

		public static string StringArrayToString(string[] array, string splitStr)
		{
			return CommonHelper.ObjectArrayToString(array, splitStr);
		}

		public static string StringArrayToString(string[] array)
		{
			return CommonHelper.StringArrayToString(array, ",");
		}

		public static string IntArrayToString(int[] array, string splitStr)
		{
			string result;
			if (array == null || array.Length == 0)
			{
				result = "";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.AppendFormat("{0}{1}", array[i], splitStr);
				}
				result = stringBuilder.Remove(stringBuilder.Length - splitStr.Length, splitStr.Length).ToString();
			}
			return result;
		}

		public static string IntArrayToString(int[] array)
		{
			return CommonHelper.IntArrayToString(array, ",");
		}

		public static string[] RemoveArrayItem(string[] array, string removeItem, bool removeBackspace, bool ignoreCase)
		{
			string[] result;
			if (array != null && array.Length > 0)
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				if (ignoreCase)
				{
					removeItem = removeItem.ToLower();
				}
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					string a;
					if (ignoreCase)
					{
						a = text.ToLower();
					}
					else
					{
						a = text;
					}
					if (a != removeItem)
					{
						stringBuilder.AppendFormat("{0}_", removeBackspace ? text.Trim() : text);
					}
				}
				result = StringHelper.SplitString(stringBuilder.Remove(stringBuilder.Length - 1, 1).ToString(), "_");
			}
			else
			{
				result = array;
			}
			return result;
		}

		public static string[] RemoveArrayItem(string[] array)
		{
			return CommonHelper.RemoveArrayItem(array, "", true, false);
		}

		public static string[] RemoveStringItem(string s, string splitStr)
		{
			return CommonHelper.RemoveArrayItem(StringHelper.SplitString(s, splitStr), "", true, false);
		}

		public static string[] RemoveStringItem(string s)
		{
			return CommonHelper.RemoveArrayItem(StringHelper.SplitString(s), "", true, false);
		}

		public static int[] RemoveRepeaterItem(int[] array)
		{
			int[] result;
			if (array == null || array.Length < 2)
			{
				result = array;
			}
			else
			{
				System.Array.Sort<int>(array);
				int num = 1;
				for (int i = 1; i < array.Length; i++)
				{
					if (array[i] != array[i - 1])
					{
						num++;
					}
				}
				int[] array2 = new int[num];
				array2[0] = array[0];
				int num2 = 1;
				for (int i = 1; i < array.Length; i++)
				{
					if (array[i] != array[i - 1])
					{
						array2[num2++] = array[i];
					}
				}
				result = array2;
			}
			return result;
		}

		public static string[] RemoveRepeaterItem(string[] array)
		{
			string[] result;
			if (array == null || array.Length < 2)
			{
				result = array;
			}
			else
			{
				System.Array.Sort<string>(array);
				int num = 1;
				for (int i = 1; i < array.Length; i++)
				{
					if (array[i] != array[i - 1])
					{
						num++;
					}
				}
				string[] array2 = new string[num];
				array2[0] = array[0];
				int num2 = 1;
				for (int i = 1; i < array.Length; i++)
				{
					if (array[i] != array[i - 1])
					{
						array2[num2++] = array[i];
					}
				}
				result = array2;
			}
			return result;
		}

		public static string GetUniqueString(string s)
		{
			return CommonHelper.GetUniqueString(s, ",");
		}

		public static string GetUniqueString(string s, string splitStr)
		{
			return CommonHelper.ObjectArrayToString(CommonHelper.RemoveRepeaterItem(StringHelper.SplitString(s, splitStr)), splitStr);
		}

		public static string TBBRTrim(string str)
		{
			string result;
			if (!string.IsNullOrEmpty(str))
			{
				result = str.Trim().Trim(new char[]
				{
					'\r'
				}).Trim(new char[]
				{
					'\n'
				}).Trim(new char[]
				{
					'\t'
				});
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public static string ClearTBBR(string str)
		{
			string result;
			if (!string.IsNullOrEmpty(str))
			{
				result = CommonHelper._tbbrRegex.Replace(str, "");
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public static string DeleteNullOrSpaceRow(string s)
		{
			string result;
			if (string.IsNullOrEmpty(s))
			{
				result = "";
			}
			else
			{
				string[] array = StringHelper.SplitString("\r\n");
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					if (!string.IsNullOrWhiteSpace(text))
					{
						stringBuilder.AppendFormat("{0}\r\n", text);
					}
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Remove(stringBuilder.Length - 2, 2);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static string GetHtmlBS(int count)
		{
			string result;
			if (count == 1)
			{
				result = "&nbsp;&nbsp;&nbsp;&nbsp;";
			}
			else if (count == 2)
			{
				result = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
			}
			else if (count == 3)
			{
				result = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				for (int i = 0; i < count; i++)
				{
					stringBuilder.Append("&nbsp;&nbsp;&nbsp;&nbsp;");
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static string GetHtmlSpan(int count)
		{
			string result;
			if (count <= 0)
			{
				result = "";
			}
			else if (count == 1)
			{
				result = "<span></span>";
			}
			else if (count == 2)
			{
				result = "<span></span><span></span>";
			}
			else if (count == 3)
			{
				result = "<span></span><span></span><span></span>";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				for (int i = 0; i < count; i++)
				{
					stringBuilder.Append("<span></span>");
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static decimal SubDecimal(decimal dec, int pointCount)
		{
			string text = dec.ToString();
			return TypeHelper.StringToDecimal(text.Substring(0, text.IndexOf('.') + pointCount + 1));
		}

		public static string GetEmailProvider(string email)
		{
			int num = email.LastIndexOf('@');
			string result;
			if (num > 0)
			{
				result = email.Substring(num + 1);
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		public static string EscapeRegex(string s)
		{
			string[] array = new string[]
			{
				"\\",
				".",
				"+",
				"*",
				"?",
				"{",
				"}",
				"[",
				"^",
				"]",
				"$",
				"(",
				")",
				"=",
				"!",
				"<",
				">",
				"|",
				":"
			};
			string[] array2 = new string[]
			{
				"\\\\",
				"\\.",
				"\\+",
				"\\*",
				"\\?",
				"\\{",
				"\\}",
				"\\[",
				"\\^",
				"\\]",
				"\\$",
				"\\(",
				"\\)",
				"\\=",
				"\\!",
				"\\<",
				"\\>",
				"\\|",
				"\\:"
			};
			for (int i = 0; i < array.Length; i++)
			{
				s = s.Replace(array[i], array2[i]);
			}
			return s;
		}

		public static long ConvertIPToInt64(string ip)
		{
			return System.Convert.ToInt64(ip.Replace(".", string.Empty));
		}

		public static string HideEmail(string email)
		{
			int num = email.LastIndexOf('@');
			string result;
			if (num == 1)
			{
				result = "*" + email.Substring(num);
			}
			else if (num == 2)
			{
				result = email[0] + "*" + email.Substring(num);
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.Append(email.Substring(0, 2));
				for (int i = num - 2; i > 0; i--)
				{
					stringBuilder.Append("*");
				}
				stringBuilder.Append(email.Substring(num));
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static string HideMobile(string mobile)
		{
			return mobile.Substring(0, 3) + "*****" + mobile.Substring(8);
		}
	}
}
