using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class GiftInfo : BaseModel
	{
		public enum GiftSalesStatus
		{
			[Description("删除")]
			IsDelete = -1,
			[Description("下架")]
			OffShelves,
			[Description("正常")]
			Normal,
			[Description("过期")]
			HasExpired
		}

		public enum ImageSize
		{
			[Description("50×50")]
			Size_50 = 50,
			[Description("100×100")]
			Size_100 = 100,
			[Description("150×150")]
			Size_150 = 150,
			[Description("220×220")]
			Size_220 = 220,
			[Description("350×350")]
			Size_350 = 350,
			[Description("400×400")]
			Size_400 = 400,
			[Description("500×500")]
			Size_500 = 500
		}

		private long _id;

		public new long Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
				base.Id = value;
			}
		}

		public string GiftName
		{
			get;
			set;
		}

		public int NeedIntegral
		{
			get;
			set;
		}

		public int LimtQuantity
		{
			get;
			set;
		}

		public int StockQuantity
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public int NeedGrade
		{
			get;
			set;
		}

		public int VirtualSales
		{
			get;
			set;
		}

		public int RealSales
		{
			get;
			set;
		}

		public GiftInfo.GiftSalesStatus SalesStatus
		{
			get;
			set;
		}

		public string ImagePath
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public decimal? GiftValue
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public DateTime? AddDate
		{
			get;
			set;
		}

		[NotMapped]
		public string NeedGradeName
		{
			get;
			set;
		}

		public int GradeIntegral
		{
			get;
			set;
		}

		public long SumSales
		{
			get
			{
				return (long)(this.VirtualSales + this.RealSales);
			}
		}

		[NotMapped]
		public string ShowImagePath
		{
			get
			{
				return this.ImageServerUrl + this.ImagePath;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.ImagePath = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.ImagePath = value;
				}
			}
		}

		[NotMapped]
		public GiftInfo.GiftSalesStatus GetSalesStatus
		{
			get
			{
				GiftInfo.GiftSalesStatus giftSalesStatus = this.SalesStatus;
				if (giftSalesStatus == GiftInfo.GiftSalesStatus.Normal)
				{
					if (this.EndDate < DateTime.Now)
					{
						giftSalesStatus = GiftInfo.GiftSalesStatus.HasExpired;
					}
				}
				return giftSalesStatus;
			}
		}

		[NotMapped]
		public string ShowLimtQuantity
		{
			get
			{
				string result;
				if (this.LimtQuantity == 0)
				{
					result = "不限";
				}
				else
				{
					result = this.LimtQuantity.ToString();
				}
				return result;
			}
		}

		public string GetImage(GiftInfo.ImageSize imageSize, int imageIndex = 1)
		{
			return string.Format(this.ShowImagePath + "/{0}_{1}.png", imageIndex, (int)imageSize);
		}
	}
}
