using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Himall.Model
{
	public class ManagerInfo : BaseModel, ISellerManager, IPaltManager, IManager
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

		public long RoleId
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string PasswordSalt
		{
			get;
			set;
		}

		public DateTime CreateDate
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public string RealName
		{
			get;
			set;
		}

		[NotMapped]
		public string RoleName
		{
			get;
			set;
		}

		[NotMapped]
		public List<AdminPrivilege> AdminPrivileges
		{
			get;
			set;
		}

		[NotMapped]
		public List<SellerPrivilege> SellerPrivileges
		{
			get;
			set;
		}

		[NotMapped]
		public string Description
		{
			get;
			set;
		}

		[NotMapped]
		public long VShopId
		{
			get;
			set;
		}
	}
}
