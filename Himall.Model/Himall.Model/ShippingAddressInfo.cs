using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ShippingAddressInfo : BaseModel
	{
		private long _id;

		[NotMapped]
		public string RegionFullName
		{
			get;
			set;
		}

		[NotMapped]
		public string RegionIdPath
		{
			get;
			set;
		}

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

		public long UserId
		{
			get;
			set;
		}

		public int RegionId
		{
			get;
			set;
		}

		public string ShipTo
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

		public string Phone
		{
			get;
			set;
		}

		public bool IsDefault
		{
			get;
			set;
		}

		public bool IsQuick
		{
			get;
			set;
		}

		public virtual UserMemberInfo MemberInfo
		{
			get;
			set;
		}
	}
}
