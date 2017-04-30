using System;

namespace ThirdParty
{
	public class SecretBoolean : SecretBytes
	{
		public bool Value
		{
			get
			{
				return BitConverter.ToBoolean(base.Bytes, 0);
			}
			set
			{
				base.Bytes = BitConverter.GetBytes(value);
			}
		}

		public SecretBoolean(bool value = false)
		{
			this.Value = value;
		}

		public override string ToString()
		{
			return this.Value.ToString();
		}

		public static implicit operator bool(SecretBoolean s)
		{
			return s.Value;
		}

		public static implicit operator SecretBoolean(bool value)
		{
			return new SecretBoolean(value);
		}
	}
}
