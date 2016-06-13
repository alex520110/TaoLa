using Himall.Model;
using System;
using System.Linq.Expressions;

namespace TaoLa.IServices.QueryModel
{
	public class QueryBase
	{
		public int PageNo
		{
			get;
			set;
		}

		public int PageSize
		{
			get;
			set;
		}

		public string Sort
		{
			get;
			set;
		}

		public bool IsAsc
		{
			get;
			set;
		}
	}
	public class QueryBase<T, Tout> where T : BaseModel
	{
		public int PageNo
		{
			get;
			set;
		}

		public int PageSize
		{
			get;
			set;
		}

		public Expression<Func<T, Tout>> Sort
		{
			get;
			set;
		}

		public bool IsAsc
		{
			get;
			set;
		}
	}
}
