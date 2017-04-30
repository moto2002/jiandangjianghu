using System;

namespace ICSharpCode.SharpZipLib.Checksum
{
	public sealed class Adler32 : IChecksum
	{
		private static readonly uint BASE = 65521u;

		private uint checkValue;

		public long Value
		{
			get
			{
				return (long)((ulong)this.checkValue);
			}
		}

		public Adler32()
		{
			this.Reset();
		}

		public void Reset()
		{
			this.checkValue = 1u;
		}

		public void Update(int bval)
		{
			uint num = this.checkValue & 65535u;
			uint num2 = this.checkValue >> 16;
			num = (num + (uint)(bval & 255)) % Adler32.BASE;
			num2 = (num + num2) % Adler32.BASE;
			this.checkValue = (num2 << 16) + num;
		}

		public void Update(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			this.Update(buffer, 0, buffer.Length);
		}

		public void Update(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "cannot be less than zero");
			}
			if (offset >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "cannot be less than zero");
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
			}
			uint num = this.checkValue & 65535u;
			uint num2 = this.checkValue >> 16;
			while (count > 0)
			{
				int num3 = 3800;
				if (num3 > count)
				{
					num3 = count;
				}
				count -= num3;
				while (--num3 >= 0)
				{
					num += (uint)(buffer[offset++] & 255);
					num2 += num;
				}
				num %= Adler32.BASE;
				num2 %= Adler32.BASE;
			}
			this.checkValue = (num2 << 16 | num);
		}
	}
}
