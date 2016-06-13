using System;

namespace Himall.Model
{
	public class MessageLog : BaseModel
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

		public long? ShopId
		{
			get;
			set;
		}

		public string TypeId
		{
			get;
			set;
		}

		public string MessageContent
		{
			get;
			set;
		}

		public DateTime? SendTime
		{
			get;
			set;
		}

		public virtual ShopInfo Shops
		{
			get;
			set;
		}
	}
}
