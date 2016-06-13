using System;

namespace Himall.Model
{
	public class PhotoSpaceInfo : BaseModel
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

		public long PhotoCategoryId
		{
			get;
			set;
		}

		public string PhotoName
		{
			get;
			set;
		}

		public string PhotoPath
		{
			get;
			set;
		}

		public long? FileSize
		{
			get;
			set;
		}

		public DateTime? UploadTime
		{
			get;
			set;
		}

		public DateTime? LastUpdateTime
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
