using System;
using System.Linq;
using UnityEngine;

namespace ThirdParty
{
	public class SecretBytes
	{
		private readonly byte seed1 = (byte)UnityEngine.Random.Range(0, 255);

		private readonly byte seed2 = (byte)UnityEngine.Random.Range(0, 255);

		private byte[] bytes1;

		private byte[] bytes2;

		public byte[] Bytes
		{
			get
			{
				if (this.bytes1 == null)
				{
					return null;
				}
				byte[] array = (from b in this.bytes1
				select b ^ this.seed1).ToArray<byte>();
				if (array.SequenceEqual(from b in this.bytes2
				select b ^ this.seed2))
				{
					return array;
				}
				Application.Quit();
				throw new InvalidOperationException();
			}
			set
			{
				if (value == null)
				{
					this.bytes1 = null;
					this.bytes2 = null;
				}
				else
				{
					this.bytes1 = (from b in value
					select b ^ this.seed1).ToArray<byte>();
					this.bytes2 = (from b in value
					select b ^ this.seed2).ToArray<byte>();
				}
			}
		}
	}
}
