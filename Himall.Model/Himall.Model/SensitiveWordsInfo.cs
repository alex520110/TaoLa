using System;

namespace Himall.Model
{
	public class SensitiveWordsInfo : BaseModel
	{
		private int _id;

		public new int Id
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

		public string SensitiveWord
		{
			get;
			set;
		}

		public string CategoryName
		{
			get;
			set;
		}
	}
}
