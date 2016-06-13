using System;
using System.ComponentModel;

namespace Himall.Model
{
	public enum QR_SCENE_Type
	{
		[Description("提现")]
		WithDraw = 1,
		[Description("红包")]
		Bonus,
		[Description("限时购开团提醒")]
		FlashSaleRemind
	}
}
