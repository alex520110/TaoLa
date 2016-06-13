using System;

namespace Himall.Model
{
	public class GiftModel : GiftInfo
	{
		public string ShowSalesStatus
		{
			get
			{
				string result = "有错误";
				if (this != null)
				{
					switch (base.GetSalesStatus)
					{
					case GiftInfo.GiftSalesStatus.IsDelete:
						result = "己删除";
						break;
					case GiftInfo.GiftSalesStatus.OffShelves:
						result = "己下架";
						break;
					case GiftInfo.GiftSalesStatus.Normal:
						result = "可兑换";
						break;
					case GiftInfo.GiftSalesStatus.HasExpired:
						result = "己过期";
						break;
					}
				}
				return result;
			}
		}
	}
}
