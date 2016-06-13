using System;
using System.ComponentModel;

namespace Himall.Model
{
	public enum Position
	{
		[Description("左1")]
		LeftOne = 1,
		[Description("左2")]
		LeftTwo,
		[Description("中1")]
		MiddleOne,
		[Description("中2")]
		MiddleTwo,
		[Description("中3")]
		MiddleThree,
		[Description("中4")]
		MiddleFour,
		[Description("中5")]
		MiddleFive,
		[Description("右1")]
		RightOne,
		[Description("右2")]
		RightTwo,
		[Description("右3")]
		RightThree,
		[Description("文本")]
		Top,
		[Description("右1")]
		ROne = 21,
		[Description("右2")]
		RTwo,
		[Description("右3")]
		RThree,
		[Description("右4")]
		RFour,
		[Description("右5")]
		RFive,
		[Description("右6")]
		RSix,
		[Description("右7")]
		RSeven,
		[Description("右8")]
		REight,
		[Description("轮播图1")]
		ScrollOne,
		[Description("轮播图2")]
		ScrollTwo,
		[Description("轮播图3")]
		ScrollThree,
		[Description("轮播图4")]
		ScrollFour
	}
}
