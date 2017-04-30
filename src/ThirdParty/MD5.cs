using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ThirdParty
{
	public class MD5
	{
		[ThreadStatic]
		private static System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

		public static string ComputeHashString(byte[] data)
		{
			return MD5.ToString(MD5.ComputeHash(data));
		}

		public static byte[] ComputeHash(byte[] data)
		{
			if (MD5.md5 == null)
			{
				MD5.md5 = System.Security.Cryptography.MD5.Create();
			}
			return MD5.md5.ComputeHash(data);
		}

		public static string ComputeHashString(string filename)
		{
			return MD5.ToString(MD5.ComputeHash(filename));
		}

		public static byte[] ComputeHash(string filename)
		{
			return MD5.ComputeHash(File.ReadAllBytes(filename));
		}

		public static string ComputeString(string sDataIn)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sDataIn);
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes);
			mD5CryptoServiceProvider.Clear();
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("X").PadLeft(2, '0');
			}
			return text.ToLower();
		}

		public static string ToString(byte[] data)
		{
			return BitConverter.ToString(data).Replace("-", string.Empty).ToLowerInvariant();
		}
	}
}
