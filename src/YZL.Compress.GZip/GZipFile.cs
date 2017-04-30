using ICSharpCode.SharpZipLib.GZip;
using System;
using System.IO;
using System.Threading;
using YZL.Compress.Info;

namespace YZL.Compress.GZip
{
	public class GZipFile
	{
		public class CodeProgress
		{
			public ProgressDelegate m_ProgressDelegate;

			public CodeProgress(ProgressDelegate del)
			{
				this.m_ProgressDelegate = del;
			}

			public void SetProgress(long inSize, long outSize)
			{
			}

			public void SetProgressPercent(long fileSize, long processSize)
			{
				this.m_ProgressDelegate(fileSize, processSize);
			}
		}

		public static Thread CompressAsync(string inpath, string outpath, ProgressDelegate progress)
		{
			Thread thread = new Thread(new ParameterizedThreadStart(GZipFile.Compress));
			thread.Start(new FileChangeInfo
			{
				inpath = inpath,
				outpath = outpath,
				progressDelegate = progress
			});
			return thread;
		}

		public static Thread DeCompressAsync(string inpath, string outpath, ProgressDelegate progress)
		{
			Thread thread = new Thread(new ParameterizedThreadStart(GZipFile.DeCompress));
			thread.Start(new FileChangeInfo
			{
				inpath = inpath,
				outpath = outpath,
				progressDelegate = progress
			});
			return thread;
		}

		private static void Compress(object obj)
		{
			FileChangeInfo fileChangeInfo = (FileChangeInfo)obj;
			string inpath = fileChangeInfo.inpath;
			string outpath = fileChangeInfo.outpath;
			GZipFile.CodeProgress progress = null;
			if (fileChangeInfo.progressDelegate != null)
			{
				progress = new GZipFile.CodeProgress(fileChangeInfo.progressDelegate);
			}
			GZip.Compress(File.OpenRead(inpath), File.Create(outpath), true, progress);
		}

		public static void Compress(string inpath, string outpath, ProgressDelegate progress)
		{
			GZipFile.Compress(new FileChangeInfo
			{
				inpath = inpath,
				outpath = outpath,
				progressDelegate = progress
			});
		}

		private static void DeCompress(object obj)
		{
			FileChangeInfo fileChangeInfo = (FileChangeInfo)obj;
			string inpath = fileChangeInfo.inpath;
			string outpath = fileChangeInfo.outpath;
			GZipFile.CodeProgress progress = null;
			if (fileChangeInfo.progressDelegate != null)
			{
				progress = new GZipFile.CodeProgress(fileChangeInfo.progressDelegate);
			}
			GZip.Decompress(File.OpenRead(inpath), File.Create(outpath), true, progress);
		}

		public static void DeCompress(string inpath, string outpath, ProgressDelegate progress)
		{
			GZipFile.DeCompress(new FileChangeInfo
			{
				inpath = inpath,
				outpath = outpath,
				progressDelegate = progress
			});
		}
	}
}
