using TaoLa.Core;
using System;

namespace Himall.Model
{
	public class MobileHomeTopicsInfo : BaseModel
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

		public PlatformType Platform
		{
			get;
			set;
		}

		public long TopicId
		{
			get;
			set;
		}

		public int Sequence
		{
			get;
			set;
		}

		public virtual TopicInfo Himall_Topics
		{
			get;
			set;
		}
	}
}
