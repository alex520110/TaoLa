using System;

namespace Himall.Model
{
	public class SellerSpecificationValueInfo : BaseModel
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

		public long ValueId
		{
			get;
			set;
		}

		public SpecificationType Specification
		{
			get;
			set;
		}

		public long TypeId
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}

		public virtual SpecificationValueInfo SpecificationValueInfo
		{
			get;
			set;
		}
	}
}
