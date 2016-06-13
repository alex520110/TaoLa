using System;
using System.Text;

namespace TaoLa.Core
{
	public class DateTimeHelper
	{
		public static System.DateTime GetStartDayOfWeeks(int year, int month, int index)
		{
			System.DateTime result;
			if (year < 1600 || year > 9999)
			{
				result = System.DateTime.MinValue;
			}
			else if (month < 0 || month > 12)
			{
				result = System.DateTime.MinValue;
			}
			else if (index < 1)
			{
				result = System.DateTime.MinValue;
			}
			else
			{
				System.DateTime dateTime = new System.DateTime(year, month, 1);
				int num = 7;
				if (System.Convert.ToInt32(dateTime.DayOfWeek.ToString("d")) > 0)
				{
					num = System.Convert.ToInt32(dateTime.DayOfWeek.ToString("d"));
				}
				System.DateTime dateTime2 = dateTime.AddDays((double)(1 - num)).AddDays((double)(index * 7));
				if ((dateTime2 - dateTime.AddMonths(1)).Days > 0)
				{
					result = System.DateTime.MinValue;
				}
				else
				{
					result = dateTime2;
				}
			}
			return result;
		}

		public static string GetWeekSpanOfMonth(int year, int month)
		{
			string result;
			if (year < 1600 || year > 9999)
			{
				result = "";
			}
			else if (month < 0 || month > 12)
			{
				result = "";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				for (int i = 1; i < 5; i++)
				{
					System.DateTime dateTime = new System.DateTime(year, month, 1);
					int num = 7;
					if (System.Convert.ToInt32(dateTime.DayOfWeek.ToString("d")) > 0)
					{
						num = System.Convert.ToInt32(dateTime.DayOfWeek.ToString("d"));
					}
					System.DateTime d = dateTime.AddDays((double)(1 - num)).AddDays((double)(i * 7));
					if ((d - dateTime.AddMonths(1)).Days > 0)
					{
						result = "";
						return result;
					}
					stringBuilder.Append(d.ToString("yyyy-MM-dd"));
					stringBuilder.Append(" ~ ");
					stringBuilder.Append(d.AddDays(6.0).ToString("yyyy-MM-dd"));
					stringBuilder.Append(System.Environment.NewLine);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}
	}
}
