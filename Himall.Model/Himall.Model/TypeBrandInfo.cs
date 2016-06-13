using System;

namespace Himall.Model
{
	public class TypeBrandInfo : BaseModel
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

		public long TypeId
		{
			get;
			set;
		}

		public long BrandId
		{
			get;
			set;
		}

		public virtual BrandInfo BrandInfo
		{
			get;
			set;
		}

		public virtual ProductTypeInfo TypeInfo
		{
			get;
			set;
		}
	}
}
