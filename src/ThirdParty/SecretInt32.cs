using System;

namespace ThirdParty
{
	public class SecretInt32 : SecretBytes
	{
		public int Value
		{
			get
			{
				return BitConverter.ToInt32(base.Bytes, 0);
			}
			set
			{
				base.Bytes = BitConverter.GetBytes(value);
			}
		}

		public SecretInt32(int value = 0)
		{
			this.Value = value;
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		public static implicit operator int(SecretInt32 s)
		{
			return s.Value;
		}

		public static implicit operator SecretInt32(int value)
		{
			return new SecretInt32(value);
		}
	}
}
