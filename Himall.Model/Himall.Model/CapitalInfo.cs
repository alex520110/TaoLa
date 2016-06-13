using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CapitalInfo : BaseModel
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

		public long MemId
		{
			get;
			set;
		}

		public decimal? Balance
		{
			get;
			set;
		}

		public decimal? FreezeAmount
		{
			get;
			set;
		}

		public decimal? ChargeAmount
		{
			get;
			set;
		}

		public virtual ICollection<CapitalDetailInfo> Himall_CapitalDetail
		{
			get;
			set;
		}

		public CapitalInfo()
		{
			this.Himall_CapitalDetail = new HashSet<CapitalDetailInfo>();
		}
	}
}
