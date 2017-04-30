using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class ExtendedUnixData : ITaggedData
	{
		[Flags]
		public enum Flags : byte
		{
			ModificationTime = 1,
			AccessTime = 2,
			CreateTime = 4
		}

		private ExtendedUnixData.Flags _flags;

		private DateTime _modificationTime = new DateTime(1970, 1, 1);

		private DateTime _lastAccessTime = new DateTime(1970, 1, 1);

		private DateTime _createTime = new DateTime(1970, 1, 1);

		public short TagID
		{
			get
			{
				return 21589;
			}
		}

		public DateTime ModificationTime
		{
			get
			{
				return this._modificationTime;
			}
			set
			{
				if (!ExtendedUnixData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._flags |= ExtendedUnixData.Flags.ModificationTime;
				this._modificationTime = value;
			}
		}

		public DateTime AccessTime
		{
			get
			{
				return this._lastAccessTime;
			}
			set
			{
				if (!ExtendedUnixData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._flags |= ExtendedUnixData.Flags.AccessTime;
				this._lastAccessTime = value;
			}
		}

		public DateTime CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				if (!ExtendedUnixData.IsValidValue(value))
				{
					throw new ArgumentOutOfRangeException("value");
				}
				this._flags |= ExtendedUnixData.Flags.CreateTime;
				this._createTime = value;
			}
		}

		public ExtendedUnixData.Flags Include
		{
			get
			{
				return this._flags;
			}
			set
			{
				this._flags = value;
			}
		}

		public void SetData(byte[] data, int index, int count)
		{
			using (MemoryStream memoryStream = new MemoryStream(data, index, count, false))
			{
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(memoryStream))
				{
					this._flags = (ExtendedUnixData.Flags)zipHelperStream.ReadByte();
					if ((byte)(this._flags & ExtendedUnixData.Flags.ModificationTime) != 0)
					{
						int seconds = zipHelperStream.ReadLEInt();
						this._modificationTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, seconds, 0);
						if (count <= 5)
						{
							return;
						}
					}
					if ((byte)(this._flags & ExtendedUnixData.Flags.AccessTime) != 0)
					{
						int seconds2 = zipHelperStream.ReadLEInt();
						this._lastAccessTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, seconds2, 0);
					}
					if ((byte)(this._flags & ExtendedUnixData.Flags.CreateTime) != 0)
					{
						int seconds3 = zipHelperStream.ReadLEInt();
						this._createTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(0, 0, 0, seconds3, 0);
					}
				}
			}
		}

		public byte[] GetData()
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ZipHelperStream zipHelperStream = new ZipHelperStream(memoryStream))
				{
					zipHelperStream.IsStreamOwner = false;
					zipHelperStream.WriteByte((byte)this._flags);
					if ((byte)(this._flags & ExtendedUnixData.Flags.ModificationTime) != 0)
					{
						int value = (int)(this._modificationTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
						zipHelperStream.WriteLEInt(value);
					}
					if ((byte)(this._flags & ExtendedUnixData.Flags.AccessTime) != 0)
					{
						int value2 = (int)(this._lastAccessTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
						zipHelperStream.WriteLEInt(value2);
					}
					if ((byte)(this._flags & ExtendedUnixData.Flags.CreateTime) != 0)
					{
						int value3 = (int)(this._createTime - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
						zipHelperStream.WriteLEInt(value3);
					}
					result = memoryStream.ToArray();
				}
			}
			return result;
		}

		public static bool IsValidValue(DateTime value)
		{
			return value >= new DateTime(1901, 12, 13, 20, 45, 52) || value <= new DateTime(2038, 1, 19, 3, 14, 7);
		}
	}
}
