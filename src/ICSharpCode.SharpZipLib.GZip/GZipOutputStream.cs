using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.GZip
{
	public class GZipOutputStream : DeflaterOutputStream
	{
		private enum OutputState
		{
			Header,
			Footer,
			Finished,
			Closed
		}

		protected Crc32 crc = new Crc32();

		private GZipOutputStream.OutputState state_;

		public GZipOutputStream(Stream baseOutputStream) : this(baseOutputStream, 4096)
		{
		}

		public GZipOutputStream(Stream baseOutputStream, int size) : base(baseOutputStream, new Deflater(-1, true), size)
		{
		}

		public void SetLevel(int level)
		{
			if (level < 1)
			{
				throw new ArgumentOutOfRangeException("level");
			}
			this.deflater_.SetLevel(level);
		}

		public int GetLevel()
		{
			return this.deflater_.GetLevel();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.state_ == GZipOutputStream.OutputState.Header)
			{
				this.WriteHeader();
			}
			if (this.state_ != GZipOutputStream.OutputState.Footer)
			{
				throw new InvalidOperationException("Write not permitted in current state");
			}
			this.crc.Update(buffer, offset, count);
			base.Write(buffer, offset, count);
		}

		public override void Close()
		{
			try
			{
				this.Finish();
			}
			finally
			{
				if (this.state_ != GZipOutputStream.OutputState.Closed)
				{
					this.state_ = GZipOutputStream.OutputState.Closed;
					if (base.IsStreamOwner)
					{
						this.baseOutputStream_.Close();
					}
				}
			}
		}

		public override void Finish()
		{
			if (this.state_ == GZipOutputStream.OutputState.Header)
			{
				this.WriteHeader();
			}
			if (this.state_ == GZipOutputStream.OutputState.Footer)
			{
				this.state_ = GZipOutputStream.OutputState.Finished;
				base.Finish();
				uint num = (uint)(this.deflater_.TotalIn & (long)((ulong)-1));
				uint num2 = (uint)(this.crc.Value & (long)((ulong)-1));
				byte[] array = new byte[]
				{
					(byte)num2,
					(byte)(num2 >> 8),
					(byte)(num2 >> 16),
					(byte)(num2 >> 24),
					(byte)num,
					(byte)(num >> 8),
					(byte)(num >> 16),
					(byte)(num >> 24)
				};
				this.baseOutputStream_.Write(array, 0, array.Length);
			}
		}

		private void WriteHeader()
		{
			if (this.state_ == GZipOutputStream.OutputState.Header)
			{
				this.state_ = GZipOutputStream.OutputState.Footer;
				long arg_34_0 = DateTime.Now.Ticks;
				DateTime dateTime = new DateTime(1970, 1, 1);
				int num = (int)((arg_34_0 - dateTime.Ticks) / 10000000L);
				byte[] expr_45 = new byte[]
				{
					31,
					139,
					8,
					0,
					0,
					0,
					0,
					0,
					0,
					255
				};
				expr_45[4] = (byte)num;
				expr_45[5] = (byte)(num >> 8);
				expr_45[6] = (byte)(num >> 16);
				expr_45[7] = (byte)(num >> 24);
				byte[] array = expr_45;
				this.baseOutputStream_.Write(array, 0, array.Length);
			}
		}
	}
}
