using System;

namespace ThirdParty
{
	public class SecretDouble : SecretBytes
	{
		public double Value
		{
			get
			{
				return BitConverter.ToDouble(base.Bytes, 0);
			}
			set
			{
				base.Bytes = BitConverter.GetBytes(value);
			}
		}

		public SecretDouble(double value = 0.0)
		{
			this.Value = value;
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		public static implicit operator double(SecretDouble s)
		{
			return s.Value;
		}

		public static implicit operator SecretDouble(double value)
		{
			return new SecretDouble(value);
		}
	}
}
