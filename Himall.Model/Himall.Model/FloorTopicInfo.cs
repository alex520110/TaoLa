using System;

namespace Himall.Model
{
	public class FloorTopicInfo : BaseModel
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

		public long FloorId
		{
			get;
			set;
		}

		public Position TopicType
		{
			get;
			set;
		}

		private string topicImage
		{
			get;
			set;
		}

		public string TopicName
		{
			get;
			set;
		}

		public string Url
		{
			get;
			set;
		}

		public virtual HomeFloorInfo HomeFloorInfo
		{
			get;
			set;
		}

		public string TopicImage
		{
			get
			{
				return this.ImageServerUrl + this.topicImage;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(this.ImageServerUrl))
				{
					this.topicImage = value.Replace(this.ImageServerUrl, "");
				}
				else
				{
					this.topicImage = value;
				}
			}
		}
	}
}
