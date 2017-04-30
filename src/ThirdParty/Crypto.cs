using System;
using System.IO;
using System.Security.Cryptography;

namespace ThirdParty
{
	public class Crypto
	{
		public interface IProxy
		{
			void SetKey(byte[] key, byte[] iv);

			byte[] Encode(byte[] buf);

			byte[] Decode(byte[] buf);
		}

		private class AesProxy : Crypto.IProxy
		{
			private readonly SymmetricAlgorithm algorithm = new AesManaged
			{
				KeySize = 128
			};

			private SecretBytes IV;

			private SecretBytes KEY;

			public void SetKey(byte[] key, byte[] iv)
			{
				this.KEY = new SecretBytes
				{
					Bytes = key
				};
				this.IV = new SecretBytes
				{
					Bytes = iv
				};
			}

			public byte[] Encode(byte[] buf)
			{
				byte[] result;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, this.algorithm.CreateEncryptor(this.KEY.Bytes, this.IV.Bytes), CryptoStreamMode.Write))
					{
						cryptoStream.Write(buf, 0, buf.Length);
						cryptoStream.FlushFinalBlock();
						cryptoStream.Close();
						result = memoryStream.ToArray();
					}
				}
				return result;
			}

			public byte[] Decode(byte[] buf)
			{
				byte[] result;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, this.algorithm.CreateDecryptor(this.KEY.Bytes, this.IV.Bytes), CryptoStreamMode.Write))
					{
						cryptoStream.Write(buf, 0, buf.Length);
						cryptoStream.FlushFinalBlock();
						cryptoStream.Close();
						result = memoryStream.ToArray();
					}
				}
				return result;
			}
		}

		public static Crypto.IProxy Proxy
		{
			get;
			set;
		}

		static Crypto()
		{
			Crypto.Proxy = new Crypto.AesProxy();
			Crypto.Proxy.SetKey(MD5.ComputeHash(Encoding.GetBytes("com.505+key_jianghu@hw")), Encoding.GetBytes("jianghu505+iv@hw"));
		}

		public static byte[] Encode(byte[] buf)
		{
			return Crypto.Proxy.Encode(buf);
		}

		public static byte[] Decode(byte[] buf)
		{
			return Crypto.Proxy.Decode(buf);
		}
	}
}
