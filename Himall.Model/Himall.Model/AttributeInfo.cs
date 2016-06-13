using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class AttributeInfo : BaseModel
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

		public string Name
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public bool IsMust
		{
			get;
			set;
		}

		public bool IsMulti
		{
			get;
			set;
		}

		public virtual ICollection<AttributeValueInfo> AttributeValueInfo
		{
			get;
			set;
		}

		public virtual ProductTypeInfo TypesInfo
		{
			get;
			set;
		}

		public virtual ICollection<ProductAttributeInfo> ProductAttributesInfo
		{
			get;
			set;
		}

		[NotMapped]
		public string AttrValue
		{
			get;
			set;
		}

		public AttributeInfo()
		{
			this.AttributeValueInfo = new HashSet<AttributeValueInfo>();
			this.ProductAttributesInfo = new HashSet<ProductAttributeInfo>();
		}
	}
}
