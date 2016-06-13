using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class TopicModuleInfo : BaseModel
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

		public long TopicId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public virtual ICollection<ModuleProductInfo> ModuleProductInfo
		{
			get;
			set;
		}

		public virtual TopicInfo TopicInfo
		{
			get;
			set;
		}

		public TopicModuleInfo()
		{
			this.ModuleProductInfo = new HashSet<ModuleProductInfo>();
		}
	}
}
