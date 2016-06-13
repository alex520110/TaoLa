using System;

namespace Himall.Model
{
	public class CapitalDetailModel
	{
		private string _createTime;

		public long Id
		{
			get;
			set;
		}

		public long UserId
		{
			get;
			set;
		}

		public long CapitalID
		{
			get;
			set;
		}

		public CapitalDetailInfo.CapitalDetailType SourceType
		{
			get;
			set;
		}

		public decimal Amount
		{
			get;
			set;
		}

		public string SourceData
		{
			get;
			set;
		}

		public string CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				this._createTime = value;
			}
		}

		public string Remark
		{
			get;
			set;
		}

		public string PayWay
		{
			get;
			set;
		}

		public CapitalDetailModel()
		{
			this._createTime = DateTime.Now.ToString();
		}
	}
}
