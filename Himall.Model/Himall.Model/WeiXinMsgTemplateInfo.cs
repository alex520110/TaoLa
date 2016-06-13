using System;

namespace Himall.Model
{
	public class WeiXinMsgTemplateInfo : BaseModel
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

		public int? MessageType
		{
			get;
			set;
		}

		public string TemplateNum
		{
			get;
			set;
		}

		public string TemplateId
		{
			get;
			set;
		}

		public DateTime? UpdateDate
		{
			get;
			set;
		}

		public bool IsOpen
		{
			get;
			set;
		}
	}
}
