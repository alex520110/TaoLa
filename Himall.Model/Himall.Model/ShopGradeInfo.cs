using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ShopGradeInfo : BaseModel
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

		public string Name
		{
			get;
			set;
		}

		public int ProductLimit
		{
			get;
			set;
		}

		public int ImageLimit
		{
			get;
			set;
		}

		public int TemplateLimit
		{
			get;
			set;
		}

		public decimal ChargeStandard
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public virtual ICollection<ShopInfo> ShopInfo
		{
			get;
			set;
		}

		public ShopGradeInfo()
		{
			this.ShopInfo = new HashSet<ShopInfo>();
		}
	}
}
