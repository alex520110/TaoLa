using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class PromoterQuery : QueryBase
	{
		public string UserName
		{
			get;
			set;
		}

		public PromoterInfo.PromoterStatus? Status
		{
			get;
			set;
		}
	}
}
