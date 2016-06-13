using System;

namespace Himall.Model
{
	public class ModuleProductInfo : BaseModel
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

		public long ModuleId
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public long DisplaySequence
		{
			get;
			set;
		}

		public virtual TopicModuleInfo TopicModuleInfo
		{
			get;
			set;
		}

		public virtual ProductInfo ProductInfo
		{
			get;
			set;
		}
	}
}
