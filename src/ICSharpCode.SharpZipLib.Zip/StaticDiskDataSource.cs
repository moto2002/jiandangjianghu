using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class StaticDiskDataSource : IStaticDataSource
	{
		private readonly string fileName_;

		public StaticDiskDataSource(string fileName)
		{
			this.fileName_ = fileName;
		}

		public Stream GetSource()
		{
			return File.Open(this.fileName_, FileMode.Open, FileAccess.Read, FileShare.Read);
		}
	}
}
