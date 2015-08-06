using System;
using System.Text;

namespace MasterDevs.Lib.Common.Utils
{
	static public class StringUtils
	{
		private static string _RandomChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
		private static Random _Random = new Random();

		static public string GenerateRandom(int length)
		{
			var stringBuilder = new StringBuilder();
			for(var i = 0; i < length; ++i)
			{
				var randomIndex = _Random.Next(0, _RandomChars.Length - 1);
				var randomChar = _RandomChars[randomIndex];
				stringBuilder.Append(randomChar);
			}
			return stringBuilder.ToString();
		}
	}
}

