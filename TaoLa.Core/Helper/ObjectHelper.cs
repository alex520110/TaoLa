using Newtonsoft.Json;
using System;

namespace TaoLa.Core
{
	public static class ObjectHelper
	{
		public static object DeepColne(object obj)
		{
			string value = JsonConvert.SerializeObject(obj);
			return JsonConvert.DeserializeObject(value);
		}

		public static T DeepColne<T>(T t)
		{
			string value = JsonConvert.SerializeObject(t);
			return JsonConvert.DeserializeObject<T>(value);
		}
	}
}
