using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CashDepositInfo : BaseModel
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

		public decimal CurrentBalance
		{
			get;
			set;
		}

		public decimal TotalBalance
		{
			get;
			set;
		}

		public DateTime Date
		{
			get;
			set;
		}

		public bool EnableLabels
		{
			get;
			set;
		}

		public virtual ShopInfo Himall_Shops
		{
			get;
			set;
		}

		public virtual ICollection<CashDepositDetailInfo> Himall_CashDepositDetail
		{
			get;
			set;
		}

		public CashDepositInfo()
		{
			this.Himall_CashDepositDetail = new HashSet<CashDepositDetailInfo>();
		}
	}
}
