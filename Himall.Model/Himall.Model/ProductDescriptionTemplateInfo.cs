using System;
using System.ComponentModel;

namespace Himall.Model
{
	public class ProductDescriptionTemplateInfo : BaseModel
	{
		public enum TemplatePosition
		{
			[Description("顶部")]
			Top = 1,
			[Description("底部")]
			Bottom
		}

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

		public string Name
		{
			get;
			set;
		}

		public ProductDescriptionTemplateInfo.TemplatePosition Position
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}
	}
}
