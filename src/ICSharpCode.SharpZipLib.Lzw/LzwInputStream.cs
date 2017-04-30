using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Lzw
{
	public class LzwInputStream : Stream
	{
		private const int TBL_CLEAR = 256;

		private const int TBL_FIRST = 257;

		private const int EXTRA = 64;

		private Stream baseInputStream;

		private bool isStreamOwner = true;

		private bool isClosed;

		private readonly byte[] one = new byte[1];

		private bool headerParsed;

		private int[] tabPrefix;

		private byte[] tabSuffix;

		private readonly int[] zeros = new int[256];

		private byte[] stack;

		private bool blockMode;

		private int nBits;

		private int maxBits;

		private int maxMaxCode;

		private int maxCode;

		private int bitMask;

		private int oldCode;

		private byte finChar;

		private int stackP;

		private int freeEnt;

		private readonly byte[] data = new byte[8192];

		private int bitPos;

		private int end;

		private int got;

		private bool eof;

		public bool IsStreamOwner
		{
			get
			{
				return this.isStreamOwner;
			}
			set
			{
				this.isStreamOwner = value;
			}
		}

		public override bool CanRead
		{
			get
			{
				return this.baseInputStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		public override long Length
		{
			get
			{
				return (long)this.got;
			}
		}

		public override long Position
		{
			get
			{
				return this.baseInputStream.Position;
			}
			set
			{
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		public LzwInputStream(Stream baseInputStream)
		{
			this.baseInputStream = baseInputStream;
		}

		public override int ReadByte()
		{
			int num = this.Read(this.one, 0, 1);
			if (num == 1)
			{
				return (int)(this.one[0] & 255);
			}
			return -1;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			if (!this.headerParsed)
			{
				this.ParseHeader();
			}
			if (this.eof)
			{
				return 0;
			}
			int num = offset;
			int[] array = this.tabPrefix;
			byte[] array2 = this.tabSuffix;
			byte[] array3 = this.stack;
			int num2 = this.nBits;
			int num3 = this.maxCode;
			int num4 = this.maxMaxCode;
			int num5 = this.bitMask;
			int num6 = this.oldCode;
			byte b = this.finChar;
			int num7 = this.stackP;
			int num8 = this.freeEnt;
			byte[] array4 = this.data;
			int i = this.bitPos;
			int num9 = array3.Length - num7;
			if (num9 > 0)
			{
				int num10 = (num9 < count) ? num9 : count;
				Array.Copy(array3, num7, buffer, offset, num10);
				offset += num10;
				count -= num10;
				num7 += num10;
			}
			if (count == 0)
			{
				this.stackP = num7;
				return offset - num;
			}
			int j;
			while (true)
			{
				IL_D8:
				if (this.end < 64)
				{
					this.Fill();
				}
				int num11 = (this.got <= 0) ? ((this.end << 3) - (num2 - 1)) : (this.end - this.end % num2 << 3);
				while (i < num11)
				{
					if (count == 0)
					{
						goto Block_8;
					}
					if (num8 > num3)
					{
						int num12 = num2 << 3;
						i = i - 1 + num12 - (i - 1 + num12) % num12;
						num2++;
						num3 = ((num2 != this.maxBits) ? ((1 << num2) - 1) : num4);
						num5 = (1 << num2) - 1;
						i = this.ResetBuf(i);
						goto IL_D8;
					}
					int num13 = i >> 3;
					j = (((int)(array4[num13] & 255) | (int)(array4[num13 + 1] & 255) << 8 | (int)(array4[num13 + 2] & 255) << 16) >> (i & 7) & num5);
					i += num2;
					if (num6 == -1)
					{
						if (j >= 256)
						{
							goto Block_12;
						}
						b = (byte)(num6 = j);
						buffer[offset++] = b;
						count--;
					}
					else
					{
						if (j == 256 && this.blockMode)
						{
							Array.Copy(this.zeros, 0, array, 0, this.zeros.Length);
							num8 = 256;
							int num14 = num2 << 3;
							i = i - 1 + num14 - (i - 1 + num14) % num14;
							num2 = 9;
							num3 = (1 << num2) - 1;
							num5 = num3;
							i = this.ResetBuf(i);
							goto IL_D8;
						}
						int num15 = j;
						num7 = array3.Length;
						if (j >= num8)
						{
							if (j > num8)
							{
								goto Block_16;
							}
							array3[--num7] = b;
							j = num6;
						}
						while (j >= 256)
						{
							array3[--num7] = array2[j];
							j = array[j];
						}
						b = array2[j];
						buffer[offset++] = b;
						count--;
						num9 = array3.Length - num7;
						int num16 = (num9 < count) ? num9 : count;
						Array.Copy(array3, num7, buffer, offset, num16);
						offset += num16;
						count -= num16;
						num7 += num16;
						if (num8 < num4)
						{
							array[num8] = num6;
							array2[num8] = b;
							num8++;
						}
						num6 = num15;
						if (count == 0)
						{
							goto Block_20;
						}
					}
				}
				i = this.ResetBuf(i);
				if (this.got <= 0)
				{
					goto Block_22;
				}
			}
			Block_8:
			this.nBits = num2;
			this.maxCode = num3;
			this.maxMaxCode = num4;
			this.bitMask = num5;
			this.oldCode = num6;
			this.finChar = b;
			this.stackP = num7;
			this.freeEnt = num8;
			this.bitPos = i;
			return offset - num;
			Block_12:
			throw new LzwException("corrupt input: " + j + " > 255");
			Block_16:
			throw new LzwException(string.Concat(new object[]
			{
				"corrupt input: code=",
				j,
				", freeEnt=",
				num8
			}));
			Block_20:
			this.nBits = num2;
			this.maxCode = num3;
			this.bitMask = num5;
			this.oldCode = num6;
			this.finChar = b;
			this.stackP = num7;
			this.freeEnt = num8;
			this.bitPos = i;
			return offset - num;
			Block_22:
			this.nBits = num2;
			this.maxCode = num3;
			this.bitMask = num5;
			this.oldCode = num6;
			this.finChar = b;
			this.stackP = num7;
			this.freeEnt = num8;
			this.bitPos = i;
			this.eof = true;
			return offset - num;
		}

		private int ResetBuf(int bitPosition)
		{
			int num = bitPosition >> 3;
			Array.Copy(this.data, num, this.data, 0, this.end - num);
			this.end -= num;
			return 0;
		}

		private void Fill()
		{
			this.got = this.baseInputStream.Read(this.data, this.end, this.data.Length - 1 - this.end);
			if (this.got > 0)
			{
				this.end += this.got;
			}
		}

		private void ParseHeader()
		{
			this.headerParsed = true;
			byte[] array = new byte[3];
			int num = this.baseInputStream.Read(array, 0, array.Length);
			if (num < 0)
			{
				throw new LzwException("Failed to read LZW header");
			}
			if (array[0] != 31 || array[1] != 157)
			{
				throw new LzwException(string.Format("Wrong LZW header. Magic bytes don't match. 0x{0:x2} 0x{1:x2}", array[0], array[1]));
			}
			this.blockMode = ((array[2] & 128) > 0);
			this.maxBits = (int)(array[2] & 31);
			if (this.maxBits > 16)
			{
				throw new LzwException(string.Concat(new object[]
				{
					"Stream compressed with ",
					this.maxBits,
					" bits, but decompression can only handle ",
					16,
					" bits."
				}));
			}
			if ((array[2] & 96) > 0)
			{
				throw new LzwException("Unsupported bits set in the header.");
			}
			this.maxMaxCode = 1 << this.maxBits;
			this.nBits = 9;
			this.maxCode = (1 << this.nBits) - 1;
			this.bitMask = this.maxCode;
			this.oldCode = -1;
			this.finChar = 0;
			this.freeEnt = ((!this.blockMode) ? 256 : 257);
			this.tabPrefix = new int[1 << this.maxBits];
			this.tabSuffix = new byte[1 << this.maxBits];
			this.stack = new byte[1 << this.maxBits];
			this.stackP = this.stack.Length;
			for (int i = 255; i >= 0; i--)
			{
				this.tabSuffix[i] = (byte)i;
			}
		}

		public override void Flush()
		{
			this.baseInputStream.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}

		public override void Close()
		{
			if (!this.isClosed)
			{
				this.isClosed = true;
				if (this.isStreamOwner)
				{
					this.baseInputStream.Close();
				}
			}
		}
	}
}
