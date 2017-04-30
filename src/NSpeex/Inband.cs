using System;

namespace NSpeex
{
	internal class Inband
	{
		private Stereo stereo;

		public Inband(Stereo stereo)
		{
			this.stereo = stereo;
		}

		public void SpeexInbandRequest(Bits bits)
		{
			switch (bits.Unpack(4))
			{
			case 0:
				bits.Advance(1);
				break;
			case 1:
				bits.Advance(1);
				break;
			case 2:
				bits.Advance(4);
				break;
			case 3:
				bits.Advance(4);
				break;
			case 4:
				bits.Advance(4);
				break;
			case 5:
				bits.Advance(4);
				break;
			case 6:
				bits.Advance(4);
				break;
			case 7:
				bits.Advance(4);
				break;
			case 8:
				bits.Advance(8);
				break;
			case 9:
				this.stereo.Init(bits);
				break;
			case 10:
				bits.Advance(16);
				break;
			case 11:
				bits.Advance(16);
				break;
			case 12:
				bits.Advance(32);
				break;
			case 13:
				bits.Advance(32);
				break;
			case 14:
				bits.Advance(64);
				break;
			case 15:
				bits.Advance(64);
				break;
			}
		}

		public void UserInbandRequest(Bits bits)
		{
			int num = bits.Unpack(4);
			bits.Advance(5 + 8 * num);
		}
	}
}
