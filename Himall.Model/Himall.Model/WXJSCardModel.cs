using System;

namespace Himall.Model
{
	public class WXJSCardModel
	{
		public string cardId
		{
			get;
			set;
		}

		public WXJSCardExtModel cardExt
		{
			get;
			set;
		}

		public WXJSCardModel()
		{
			this.cardExt = new WXJSCardExtModel();
		}
	}
}
