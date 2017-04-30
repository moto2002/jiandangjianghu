using System;

namespace ICSharpCode.SharpZipLib.Core
{
	public class DirectoryEventArgs : ScanEventArgs
	{
		private readonly bool hasMatchingFiles_;

		public bool HasMatchingFiles
		{
			get
			{
				return this.hasMatchingFiles_;
			}
		}

		public DirectoryEventArgs(string name, bool hasMatchingFiles) : base(name)
		{
			this.hasMatchingFiles_ = hasMatchingFiles;
		}
	}
}
