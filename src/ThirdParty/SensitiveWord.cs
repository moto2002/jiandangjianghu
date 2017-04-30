using System;

namespace ThirdParty
{
	public static class SensitiveWord
	{
		private static string[] _words = new string[]
		{
			"钓鱼岛",
			"习大大"
		};

		public static string filter(string src, string replace = "*")
		{
			try
			{
				int num = SensitiveWord._words.Length;
				for (int i = 0; i < num; i++)
				{
					src = src.Replace(SensitiveWord._words[i], replace);
				}
			}
			catch (Exception)
			{
			}
			return src;
		}

		public static bool isSensitive(string src)
		{
			int num = SensitiveWord._words.Length;
			for (int i = 0; i < num; i++)
			{
				if (src.IndexOf(SensitiveWord._words[i]) >= 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
