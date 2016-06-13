using System;

namespace Himall.Model
{
	public class PhotoSpaceCategoryInfo : BaseModel
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

		public string PhotoSpaceCatrgoryName
		{
			get;
			set;
		}

		public long? DisplaySequence
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}
	}
}
