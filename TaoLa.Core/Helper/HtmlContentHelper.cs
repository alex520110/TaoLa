using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace TaoLa.Core
{
	public static class HtmlContentHelper
	{
		public static string TransferToLocalImage(string htmlText, string relativeRootPath, string desDir, string imgSrcPreText = "")
		{
			if (!relativeRootPath.EndsWith("/"))
			{
				relativeRootPath += "/";
			}
			if (!System.IO.Directory.Exists(desDir))
			{
				System.IO.Directory.CreateDirectory(desDir);
			}
			int num = 0;
			List<string> list = HtmlContentHelper.GetHtmlImageUrlList(htmlText).ToList<string>();
			List<string> list2 = list.FindAll((string imgurl) => !imgurl.StartsWith("data:"));
			WebClient webClient = new WebClient();
			foreach (string current in list2)
			{
				string[] array = current.Split(new char[]
				{
					'.'
				});
				string str = array[array.Length - 1];
				string text = System.Guid.NewGuid().ToString("N") + "." + str;
				string text2 = desDir + "/" + text;
				try
				{
					if (current.StartsWith("http://"))
					{
						webClient.DownloadFile(current, text2);
					}
					else
					{
						System.IO.File.Copy(relativeRootPath + current, text2, true);
					}
					htmlText = htmlText.Replace(current, imgSrcPreText + text);
				}
				catch
				{
				}
				num++;
			}
			htmlText = htmlText.Replace("<IMG", "<img").Replace("</IMG", "</img");
			return htmlText;
		}

		private static IEnumerable<string> GetHtmlImageUrlList(string htmlText)
		{
			Regex regex = new Regex("<img\\b[^<>]*?\\bsrc[\\s\\t\\r\\n]*=[\\s\\t\\r\\n]*[\"']?[\\s\\t\\r\\n]*(?<imgUrl>[^\\s\\t\\r\\n\"'<>]*)[^<>]*?/?[\\s\\t\\r\\n]*>", RegexOptions.IgnoreCase);
			MatchCollection matchCollection = regex.Matches(htmlText);
			int num = 0;
			string[] array = new string[matchCollection.Count];
			foreach (Match match in matchCollection)
			{
				array[num++] = match.Groups["imgUrl"].Value;
			}
			return array;
		}

		public static string RemoveScriptsAndStyles(string htmlText)
		{
			htmlText = Regex.Replace(htmlText, "<\\s*script[^>]*?>.*?<\\s*/\\s*script\\s*>", "", RegexOptions.IgnoreCase);
			htmlText = Regex.Replace(htmlText, "<\\s*style[^>]*?>.*?<\\s*/\\s*style\\s*>", "", RegexOptions.IgnoreCase);
			return htmlText;
		}
	}
}
