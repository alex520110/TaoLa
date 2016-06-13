using System;
using System.Collections.Generic;

namespace Himall.Model
{
	public class ShopBonusGrantInfo : BaseModel
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

		public long ShopBonusId
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public long OrderId
		{
			get;
			set;
		}

		public string BonusQR
		{
			get;
			set;
		}

		public virtual UserMemberInfo Himall_Members
		{
			get;
			set;
		}

		public virtual ShopBonusInfo Himall_ShopBonus
		{
			get;
			set;
		}

		public virtual ICollection<ShopBonusReceiveInfo> Himall_ShopBonusReceive
		{
			get;
			set;
		}

		public ShopBonusGrantInfo()
		{
			this.Himall_ShopBonusReceive = new HashSet<ShopBonusReceiveInfo>();
		}
	}
}
