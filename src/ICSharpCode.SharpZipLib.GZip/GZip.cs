using ICSharpCode.SharpZipLib.Core;
using System;
using System.IO;
using YZL.Compress.GZip;

namespace ICSharpCode.SharpZipLib.GZip
{
	public static class GZip
	{
		public static void Decompress(Stream inStream, Stream outStream, bool isStreamOwner, GZipFile.CodeProgress progress)
		{
			if (inStream == null || outStream == null)
			{
				throw new Exception("Null Stream");
			}
			try
			{
				using (GZipInputStream gZipInputStream = new GZipInputStream(inStream))
				{
					gZipInputStream.IsStreamOwner = isStreamOwner;
					StreamUtils.Copy(gZipInputStream, outStream, new byte[4096], progress);
				}
			}
			finally
			{
				if (isStreamOwner)
				{
					outStream.Close();
				}
			}
		}

		public static void Compress(Stream inStream, Stream outStream, bool isStreamOwner, GZipFile.CodeProgress progress)
		{
			if (inStream == null || outStream == null)
			{
				throw new Exception("Null Stream");
			}
			try
			{
				using (GZipOutputStream gZipOutputStream = new GZipOutputStream(outStream))
				{
					gZipOutputStream.IsStreamOwner = isStreamOwner;
					StreamUtils.Copy(inStream, gZipOutputStream, new byte[4096], progress);
				}
			}
			finally
			{
				if (isStreamOwner)
				{
					inStream.Close();
				}
			}
		}
	}
}
