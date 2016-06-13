using System;

namespace Himall.Model
{
	public class AttributeValueInfo : BaseModel
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

		public long AttributeId
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public virtual AttributeInfo AttributesInfo
		{
			get;
			set;
		}
	}
}
