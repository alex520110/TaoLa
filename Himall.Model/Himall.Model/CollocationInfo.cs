using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class CollocationInfo : BaseModel
	{
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

		public string Title
		{
			get;
			set;
		}

		public DateTime StartTime
		{
			get;
			set;
		}

		public DateTime EndTime
		{
			get;
			set;
		}

		public string ShortDesc
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public DateTime? CreateTime
		{
			get;
			set;
		}

		public virtual ICollection<CollocationPoruductInfo> Himall_CollocationPoruducts
		{
			get;
			set;
		}

		[NotMapped]
		public long ProductId
		{
			get;
			set;
		}

		[NotMapped]
		public string ShopName
		{
			get;
			set;
		}

		public string Status
		{
			get
			{
				string result;
				if (this.EndTime < DateTime.Now)
				{
					result = "已结束";
				}
				else if (this.StartTime > DateTime.Now)
				{
					result = "未开始";
				}
				else
				{
					result = "进行中";
				}
				return result;
			}
		}

		public CollocationInfo()
		{
			this.Himall_CollocationPoruducts = new HashSet<CollocationPoruductInfo>();
		}
	}
}
