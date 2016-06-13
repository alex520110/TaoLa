using System;
using System.ComponentModel;

namespace Himall.Model
{
	public enum SpecificationType
	{
		[Description("颜色")]
		Color = 1,
		[Description("尺码")]
		Size,
		[Description("规格")]
		Version
	}
}
