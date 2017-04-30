using System;
using System.Text;

namespace ThirdParty
{
	public class Encoding
	{
		private static readonly System.Text.Encoding encoding = System.Text.Encoding.UTF8;

		public static byte[] GetBytes(string s)
		{
			return Encoding.encoding.GetBytes(s);
		}

		public static string GetString(byte[] bytes)
		{
			return Encoding.encoding.GetString(bytes);
		}
	}
}
