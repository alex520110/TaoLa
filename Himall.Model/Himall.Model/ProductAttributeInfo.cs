using System;

namespace Himall.Model
{
	public class ProductAttributeInfo : BaseModel
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

		public long AttributeId
		{
			get;
			set;
		}

		public long ValueId
		{
			get;
			set;
		}

		public virtual AttributeInfo AttributesInfo
		{
			get;
			set;
		}

		public virtual ProductInfo ProductsInfo
		{
			get;
			set;
		}
	}
}
