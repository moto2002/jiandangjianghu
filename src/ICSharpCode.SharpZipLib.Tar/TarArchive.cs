using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ICSharpCode.SharpZipLib.Tar
{
	public class TarArchive : IDisposable
	{
		private bool keepOldFiles;

		private bool asciiTranslate;

		private int userId;

		private string userName = string.Empty;

		private int groupId;

		private string groupName = string.Empty;

		private string rootPath;

		private string pathPrefix;

		private bool applyUserInfoOverrides;

		private TarInputStream tarIn;

		private TarOutputStream tarOut;

		private bool isDisposed;

		public event ProgressMessageHandler ProgressMessageEvent
		{
			[MethodImpl(32)]
			add
			{
				this.ProgressMessageEvent = (ProgressMessageHandler)Delegate.Combine(this.ProgressMessageEvent, value);
			}
			[MethodImpl(32)]
			remove
			{
				this.ProgressMessageEvent = (ProgressMessageHandler)Delegate.Remove(this.ProgressMessageEvent, value);
			}
		}

		public bool AsciiTranslate
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.asciiTranslate;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.asciiTranslate = value;
			}
		}

		public string PathPrefix
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.pathPrefix;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.pathPrefix = value;
			}
		}

		public string RootPath
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.rootPath;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.rootPath = value.Replace('\\', '/').TrimEnd(new char[]
				{
					'/'
				});
			}
		}

		public bool ApplyUserInfoOverrides
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.applyUserInfoOverrides;
			}
			set
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				this.applyUserInfoOverrides = value;
			}
		}

		public int UserId
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.userId;
			}
		}

		public string UserName
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.userName;
			}
		}

		public int GroupId
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.groupId;
			}
		}

		public string GroupName
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				return this.groupName;
			}
		}

		public int RecordSize
		{
			get
			{
				if (this.isDisposed)
				{
					throw new ObjectDisposedException("TarArchive");
				}
				if (this.tarIn != null)
				{
					return this.tarIn.RecordSize;
				}
				if (this.tarOut != null)
				{
					return this.tarOut.RecordSize;
				}
				return 10240;
			}
		}

		public bool IsStreamOwner
		{
			set
			{
				if (this.tarIn != null)
				{
					this.tarIn.IsStreamOwner = value;
				}
				else
				{
					this.tarOut.IsStreamOwner = value;
				}
			}
		}

		protected TarArchive()
		{
		}

		protected TarArchive(TarInputStream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.tarIn = stream;
		}

		protected TarArchive(TarOutputStream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			this.tarOut = stream;
		}

		protected virtual void OnProgressMessageEvent(TarEntry entry, string message)
		{
			ProgressMessageHandler progressMessageEvent = this.ProgressMessageEvent;
			if (progressMessageEvent != null)
			{
				progressMessageEvent(this, entry, message);
			}
		}

		public static TarArchive CreateInputTarArchive(Stream inputStream)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			TarInputStream tarInputStream = inputStream as TarInputStream;
			TarArchive result;
			if (tarInputStream != null)
			{
				result = new TarArchive(tarInputStream);
			}
			else
			{
				result = TarArchive.CreateInputTarArchive(inputStream, 20);
			}
			return result;
		}

		public static TarArchive CreateInputTarArchive(Stream inputStream, int blockFactor)
		{
			if (inputStream == null)
			{
				throw new ArgumentNullException("inputStream");
			}
			if (inputStream is TarInputStream)
			{
				throw new ArgumentException("TarInputStream not valid");
			}
			return new TarArchive(new TarInputStream(inputStream, blockFactor));
		}

		public static TarArchive CreateOutputTarArchive(Stream outputStream)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			TarOutputStream tarOutputStream = outputStream as TarOutputStream;
			TarArchive result;
			if (tarOutputStream != null)
			{
				result = new TarArchive(tarOutputStream);
			}
			else
			{
				result = TarArchive.CreateOutputTarArchive(outputStream, 20);
			}
			return result;
		}

		public static TarArchive CreateOutputTarArchive(Stream outputStream, int blockFactor)
		{
			if (outputStream == null)
			{
				throw new ArgumentNullException("outputStream");
			}
			if (outputStream is TarOutputStream)
			{
				throw new ArgumentException("TarOutputStream is not valid");
			}
			return new TarArchive(new TarOutputStream(outputStream, blockFactor));
		}

		public void SetKeepOldFiles(bool keepExistingFiles)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			this.keepOldFiles = keepExistingFiles;
		}

		[Obsolete("Use the AsciiTranslate property")]
		public void SetAsciiTranslation(bool translateAsciiFiles)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			this.asciiTranslate = translateAsciiFiles;
		}

		public void SetUserInfo(int userId, string userName, int groupId, string groupName)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			this.userId = userId;
			this.userName = userName;
			this.groupId = groupId;
			this.groupName = groupName;
			this.applyUserInfoOverrides = true;
		}

		[Obsolete("Use Close instead")]
		public void CloseArchive()
		{
			this.Close();
		}

		public void ListContents()
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			while (true)
			{
				TarEntry nextEntry = this.tarIn.GetNextEntry();
				if (nextEntry == null)
				{
					break;
				}
				this.OnProgressMessageEvent(nextEntry, null);
			}
		}

		public void ExtractContents(string destinationDirectory)
		{
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			while (true)
			{
				TarEntry nextEntry = this.tarIn.GetNextEntry();
				if (nextEntry == null)
				{
					break;
				}
				if (nextEntry.TarHeader.TypeFlag != 49 && nextEntry.TarHeader.TypeFlag != 50)
				{
					this.ExtractEntry(destinationDirectory, nextEntry);
				}
			}
		}

		private void ExtractEntry(string destDir, TarEntry entry)
		{
			this.OnProgressMessageEvent(entry, null);
			string text = entry.Name;
			if (Path.IsPathRooted(text))
			{
				text = text.Substring(Path.GetPathRoot(text).Length);
			}
			text = text.Replace('/', Path.DirectorySeparatorChar);
			string text2 = Path.Combine(destDir, text);
			if (entry.IsDirectory)
			{
				TarArchive.EnsureDirectoryExists(text2);
			}
			else
			{
				string directoryName = Path.GetDirectoryName(text2);
				TarArchive.EnsureDirectoryExists(directoryName);
				bool flag = true;
				FileInfo fileInfo = new FileInfo(text2);
				if (fileInfo.Exists)
				{
					if (this.keepOldFiles)
					{
						this.OnProgressMessageEvent(entry, "Destination file already exists");
						flag = false;
					}
					else if ((fileInfo.Attributes & FileAttributes.ReadOnly) != (FileAttributes)0)
					{
						this.OnProgressMessageEvent(entry, "Destination file already exists, and is read-only");
						flag = false;
					}
				}
				if (flag)
				{
					bool flag2 = false;
					Stream stream = File.Create(text2);
					if (this.asciiTranslate)
					{
						flag2 = !TarArchive.IsBinary(text2);
					}
					StreamWriter streamWriter = null;
					if (flag2)
					{
						streamWriter = new StreamWriter(stream);
					}
					byte[] array = new byte[32768];
					while (true)
					{
						int num = this.tarIn.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						if (flag2)
						{
							int num2 = 0;
							for (int i = 0; i < num; i++)
							{
								if (array[i] == 10)
								{
									string @string = Encoding.ASCII.GetString(array, num2, i - num2);
									streamWriter.WriteLine(@string);
									num2 = i + 1;
								}
							}
						}
						else
						{
							stream.Write(array, 0, num);
						}
					}
					if (flag2)
					{
						streamWriter.Close();
					}
					else
					{
						stream.Close();
					}
				}
			}
		}

		public void WriteEntry(TarEntry sourceEntry, bool recurse)
		{
			if (sourceEntry == null)
			{
				throw new ArgumentNullException("sourceEntry");
			}
			if (this.isDisposed)
			{
				throw new ObjectDisposedException("TarArchive");
			}
			try
			{
				if (recurse)
				{
					TarHeader.SetValueDefaults(sourceEntry.UserId, sourceEntry.UserName, sourceEntry.GroupId, sourceEntry.GroupName);
				}
				this.WriteEntryCore(sourceEntry, recurse);
			}
			finally
			{
				if (recurse)
				{
					TarHeader.RestoreSetValues();
				}
			}
		}

		private void WriteEntryCore(TarEntry sourceEntry, bool recurse)
		{
			string text = null;
			string text2 = sourceEntry.File;
			TarEntry tarEntry = (TarEntry)sourceEntry.Clone();
			if (this.applyUserInfoOverrides)
			{
				tarEntry.GroupId = this.groupId;
				tarEntry.GroupName = this.groupName;
				tarEntry.UserId = this.userId;
				tarEntry.UserName = this.userName;
			}
			this.OnProgressMessageEvent(tarEntry, null);
			if (this.asciiTranslate && !tarEntry.IsDirectory && !TarArchive.IsBinary(text2))
			{
				text = Path.GetTempFileName();
				using (StreamReader streamReader = File.OpenText(text2))
				{
					using (Stream stream = File.Create(text))
					{
						while (true)
						{
							string text3 = streamReader.ReadLine();
							if (text3 == null)
							{
								break;
							}
							byte[] bytes = Encoding.ASCII.GetBytes(text3);
							stream.Write(bytes, 0, bytes.Length);
							stream.WriteByte(10);
						}
						stream.Flush();
					}
				}
				tarEntry.Size = new FileInfo(text).Length;
				text2 = text;
			}
			string text4 = null;
			if (this.rootPath != null && tarEntry.Name.StartsWith(this.rootPath, StringComparison.OrdinalIgnoreCase))
			{
				text4 = tarEntry.Name.Substring(this.rootPath.Length + 1);
			}
			if (this.pathPrefix != null)
			{
				text4 = ((text4 != null) ? (this.pathPrefix + "/" + text4) : (this.pathPrefix + "/" + tarEntry.Name));
			}
			if (text4 != null)
			{
				tarEntry.Name = text4;
			}
			this.tarOut.PutNextEntry(tarEntry);
			if (tarEntry.IsDirectory)
			{
				if (recurse)
				{
					TarEntry[] directoryEntries = tarEntry.GetDirectoryEntries();
					for (int i = 0; i < directoryEntries.Length; i++)
					{
						this.WriteEntryCore(directoryEntries[i], recurse);
					}
				}
			}
			else
			{
				using (Stream stream2 = File.OpenRead(text2))
				{
					byte[] array = new byte[32768];
					while (true)
					{
						int num = stream2.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						this.tarOut.Write(array, 0, num);
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					File.Delete(text);
				}
				this.tarOut.CloseEntry();
			}
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.isDisposed)
			{
				this.isDisposed = true;
				if (disposing)
				{
					if (this.tarOut != null)
					{
						this.tarOut.Flush();
						this.tarOut.Close();
					}
					if (this.tarIn != null)
					{
						this.tarIn.Close();
					}
				}
			}
		}

		public virtual void Close()
		{
			this.Dispose(true);
		}

		~TarArchive()
		{
			this.Dispose(false);
		}

		private static void EnsureDirectoryExists(string directoryName)
		{
			if (!Directory.Exists(directoryName))
			{
				try
				{
					Directory.CreateDirectory(directoryName);
				}
				catch (Exception ex)
				{
					throw new TarException("Exception creating directory '" + directoryName + "', " + ex.Message, ex);
				}
			}
		}

		private static bool IsBinary(string filename)
		{
			using (FileStream fileStream = File.OpenRead(filename))
			{
				int num = Math.Min(4096, (int)fileStream.Length);
				byte[] array = new byte[num];
				int num2 = fileStream.Read(array, 0, num);
				for (int i = 0; i < num2; i++)
				{
					byte b = array[i];
					if (b < 8 || (b > 13 && b < 32) || b == 255)
					{
						return true;
					}
				}
			}
			return false;
		}
	}
}
