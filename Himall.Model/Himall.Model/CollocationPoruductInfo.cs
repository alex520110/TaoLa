using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class CollocationPoruductInfo : BaseModel
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

		public long ProductId
		{
			get;
			set;
		}

		public long ColloId
		{
			get;
			set;
		}

		public bool IsMain
		{
			get;
			set;
		}

		public int? DisplaySequence
		{
			get;
			set;
		}

		public virtual CollocationInfo Himall_Collocation
		{
			get;
			set;
		}

		public virtual ICollection<CollocationSkuInfo> Himall_CollocationSkus
		{
			get;
			set;
		}

		public virtual ProductInfo Himall_Products
		{
			get;
			set;
		}

		public CollocationPoruductInfo()
		{
			this.Himall_CollocationSkus = new HashSet<CollocationSkuInfo>();
		}
	}
}
