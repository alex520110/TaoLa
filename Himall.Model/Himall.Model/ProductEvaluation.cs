using System;

namespace Himall.Model
{
	public class ProductEvaluation : BaseModel
	{
		public new long Id
		{
			get;
			set;
		}

		public long ProductId
		{
			get;
			set;
		}

		public string ProductName
		{
			get;
			set;
		}

		public string ThumbnailsUrl
		{
			get;
			set;
		}

		public DateTime BuyTime
		{
			get;
			set;
		}

		public bool EvaluationStatus
		{
			get;
			set;
		}

		public string EvaluationContent
		{
			get;
			set;
		}

		public DateTime EvaluationTime
		{
			get;
			set;
		}

		public DateTime ReplyTime
		{
			get;
			set;
		}

		public string ReplyContent
		{
			get;
			set;
		}

		public int EvaluationRank
		{
			get;
			set;
		}

		public long OrderId
		{
			get;
			set;
		}

		public ProductCommentInfo ProductComment
		{
			get;
			set;
		}

		public string Color
		{
			get;
			set;
		}

		public string Size
		{
			get;
			set;
		}

		public string Version
		{
			get;
			set;
		}
	}
}
