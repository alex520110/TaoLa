using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class SpecificationValueInfo : BaseModel
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

		public virtual ICollection<SellerSpecificationValueInfo> SellerSpecificationValueInfo
		{
			get;
			set;
		}

		public virtual ProductTypeInfo TypeInfo
		{
			get;
			set;
		}

		public SpecificationValueInfo()
		{
			this.SellerSpecificationValueInfo = new HashSet<SellerSpecificationValueInfo>();
		}
	}
}
