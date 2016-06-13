using System;

namespace Himall.Model
{
	public class FreightAreaContentInfo : BaseModel
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

		public long FreightTemplateId
		{
			get;
			set;
		}

		public string AreaContent
		{
			get;
			set;
		}

		public int? FirstUnit
		{
			get;
			set;
		}

		public float? FirstUnitMonry
		{
			get;
			set;
		}

		public int? AccumulationUnit
		{
			get;
			set;
		}

		public float? AccumulationUnitMoney
		{
			get;
			set;
		}

		public sbyte? IsDefault
		{
			get;
			set;
		}

		public virtual FreightTemplateInfo Himall_FreightTemplate
		{
			get;
			set;
		}
	}
}
