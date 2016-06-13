using System;

namespace Himall.Model
{
	public class OrderOperationLogInfo : BaseModel
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

		public long OrderId
		{
			get;
			set;
		}

		public string Operator
		{
			get;
			set;
		}

		public DateTime OperateDate
		{
			get;
			set;
		}

		public string OperateContent
		{
			get;
			set;
		}

		public virtual OrderInfo OrderInfo
		{
			get;
			set;
		}
	}
}
