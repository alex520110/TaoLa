using System;

namespace Himall.Model
{
	public class FlashSaleConfigModel
	{
		public int Preheat
		{
			get;
			set;
		}

		public bool IsNormalPurchase
		{
			get;
			set;
		}

		public FlashSaleConfigModel()
		{
		}

		public FlashSaleConfigModel(int preheat, bool isNormalPurchase)
		{
			this.Preheat = preheat;
			this.IsNormalPurchase = isNormalPurchase;
		}
	}
}
