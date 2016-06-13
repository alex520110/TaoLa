using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class FloorTablsInfo : BaseModel
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

		public string Name
		{
			get;
			set;
		}

		public virtual ICollection<FloorTablDetailsInfo> Himall_FloorTablDetails
		{
			get;
			set;
		}

		public virtual HomeFloorInfo Himall_HomeFloors
		{
			get;
			set;
		}

		public FloorTablsInfo()
		{
			this.Himall_FloorTablDetails = new HashSet<FloorTablDetailsInfo>();
		}
	}
}
