using System;
using System.Collections.Generic;

namespace TaoLa.IServices.QueryModel
{
	public class MemberQuery : QueryBase
	{
		public string keyWords
		{
			get;
			set;
		}

		public bool? Status
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int CityId
		{
			get;
			set;
		}

		public int ProvinceId
		{
			get;
			set;
		}

		public int CountyId
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public List<int> RegionIds
		{
			get;
			set;
		}

		public DateTime? RegistTimeStart
		{
			get;
			set;
		}

		public DateTime? RegistTimeEnd
		{
			get;
			set;
		}

		public DateTime? LoginTimeStart
		{
			get;
			set;
		}

		public DateTime? LoginTimeEnd
		{
			get;
			set;
		}

		public bool? IsSeller
		{
			get;
			set;
		}

		public bool? IsFocusWeiXin
		{
			get;
			set;
		}

		public long[] LabelId
		{
			get;
			set;
		}

		public bool? IsHaveEmail
		{
			get;
			set;
		}

		public MemberQuery()
		{
			this.RegionIds = new List<int>();
		}
	}
}
