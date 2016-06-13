using System;
using System.ComponentModel;

namespace Himall.Model
{
	public enum CompanyEmployeeCount
	{
		[Description("5人以下")]
		LessThanFive = 1,
		[Description("5-10人")]
		FiveToTen,
		[Description("11-50人")]
		EleToFifty,
		[Description("51-100人")]
		ElevenToFifty,
		[Description("101-200人")]
		OneHundredToTwoHundred,
		[Description("201-300人")]
		TwoHundredToThreeHundred,
		[Description("301-500人")]
		ThreeHundredToFiveHundred,
		[Description("501-1000人")]
		FiveHundredToThousand,
		[Description("1000人以上")]
		MoreThanThousand
	}
}
