using TaoLa.Core;

namespace TaoLa.IServices.QueryModel
{
    public class TopicQuery : QueryBase
	{
		public string Name
		{
			get;
			set;
		}

		public string Tags
		{
			get;
			set;
		}

		public long ShopId
		{
			get;
			set;
		}

		public PlatformType PlatformType
		{
			get;
			set;
		}

		public bool? IsRecommend
		{
			get;
			set;
		}

		public TopicQuery()
		{
			this.PlatformType = PlatformType.PC;
		}
	}
}
