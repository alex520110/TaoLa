using Himall.Model;
using System;

namespace TaoLa.IServices.QueryModel
{
	public class IntegralRecordQuery : QueryBase
	{
		public DateTime? StartDate
		{
			get;
			set;
		}

		public DateTime? EndDate
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public long? UserId
		{
			get;
			set;
		}

		public MemberIntegral.IntegralType? IntegralType
		{
			get;
			set;
		}
	}
}
