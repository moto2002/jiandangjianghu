using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Core
{
	[Obsolete("Use ExtendedPathFilter instead")]
	public class NameAndSizeFilter : PathFilter
	{
		private long minSize_;

		private long maxSize_ = 9223372036854775807L;

		public long MinSize
		{
			get
			{
				return this.minSize_;
			}
			set
			{
				if (value < 0L || this.maxSize_ < value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.minSize_ = value;
			}
		}

		public long MaxSize
		{
			get
			{
				return this.maxSize_;
			}
			set
			{
				if (value < 0L || this.minSize_ > value)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this.maxSize_ = value;
			}
		}

		public NameAndSizeFilter(string filter, long minSize, long maxSize) : base(filter)
		{
			this.MinSize = minSize;
			this.MaxSize = maxSize;
		}

		public override bool IsMatch(string name)
		{
			bool flag = base.IsMatch(name);
			if (flag)
			{
				FileInfo fileInfo = new FileInfo(name);
				long length = fileInfo.Length;
				flag = (this.MinSize <= length && this.MaxSize >= length);
			}
			return flag;
		}
	}
}
