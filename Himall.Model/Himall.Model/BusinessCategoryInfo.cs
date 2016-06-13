using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class BusinessCategoryInfo : BaseModel
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

		public long ShopId
		{
			get;
			set;
		}

		public long CategoryId
		{
			get;
			set;
		}

		public decimal CommisRate
		{
			get;
			set;
		}

		public virtual CategoryInfo CategoryInfo
		{
			get;
			set;
		}

		[NotMapped]
		public string CategoryName
		{
			get;
			set;
		}
	}
}
