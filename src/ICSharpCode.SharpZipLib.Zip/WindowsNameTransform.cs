using ICSharpCode.SharpZipLib.Core;
using System;
using System.IO;
using System.Text;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class WindowsNameTransform : INameTransform
	{
		private const int MaxPath = 260;

		private string _baseDirectory;

		private bool _trimIncomingPaths;

		private char _replacementChar = '_';

		private static readonly char[] InvalidEntryChars;

		public string BaseDirectory
		{
			get
			{
				return this._baseDirectory;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this._baseDirectory = Path.GetFullPath(value);
			}
		}

		public bool TrimIncomingPaths
		{
			get
			{
				return this._trimIncomingPaths;
			}
			set
			{
				this._trimIncomingPaths = value;
			}
		}

		public char Replacement
		{
			get
			{
				return this._replacementChar;
			}
			set
			{
				for (int i = 0; i < WindowsNameTransform.InvalidEntryChars.Length; i++)
				{
					if (WindowsNameTransform.InvalidEntryChars[i] == value)
					{
						throw new ArgumentException("invalid path character");
					}
				}
				if (value == Path.DirectorySeparatorChar || value == Path.AltDirectorySeparatorChar)
				{
					throw new ArgumentException("invalid replacement character");
				}
				this._replacementChar = value;
			}
		}

		public WindowsNameTransform(string baseDirectory)
		{
			if (baseDirectory == null)
			{
				throw new ArgumentNullException("baseDirectory", "Directory name is invalid");
			}
			this.BaseDirectory = baseDirectory;
		}

		public WindowsNameTransform()
		{
		}

		static WindowsNameTransform()
		{
			char[] invalidPathChars = Path.GetInvalidPathChars();
			int num = invalidPathChars.Length + 3;
			WindowsNameTransform.InvalidEntryChars = new char[num];
			Array.Copy(invalidPathChars, 0, WindowsNameTransform.InvalidEntryChars, 0, invalidPathChars.Length);
			WindowsNameTransform.InvalidEntryChars[num - 1] = '*';
			WindowsNameTransform.InvalidEntryChars[num - 2] = '?';
			WindowsNameTransform.InvalidEntryChars[num - 3] = ':';
		}

		public string TransformDirectory(string name)
		{
			name = this.TransformFile(name);
			if (name.Length > 0)
			{
				while (name.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
				{
					name = name.Remove(name.Length - 1, 1);
				}
				return name;
			}
			throw new ZipException("Cannot have an empty directory name");
		}

		public string TransformFile(string name)
		{
			if (name != null)
			{
				name = WindowsNameTransform.MakeValidName(name, this._replacementChar);
				if (this._trimIncomingPaths)
				{
					name = Path.GetFileName(name);
				}
				if (this._baseDirectory != null)
				{
					name = Path.Combine(this._baseDirectory, name);
				}
			}
			else
			{
				name = string.Empty;
			}
			return name;
		}

		public static bool IsValidName(string name)
		{
			return name != null && name.Length <= 260 && string.Compare(name, WindowsNameTransform.MakeValidName(name, '_'), StringComparison.Ordinal) == 0;
		}

		public static string MakeValidName(string name, char replacement)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			name = WindowsPathUtils.DropPathRoot(name.Replace("/", Path.DirectorySeparatorChar.ToString()));
			while (name.Length > 0 && name[0] == Path.DirectorySeparatorChar)
			{
				name = name.Remove(0, 1);
			}
			while (name.Length > 0 && name[name.Length - 1] == Path.DirectorySeparatorChar)
			{
				name = name.Remove(name.Length - 1, 1);
			}
			int i;
			for (i = name.IndexOf(string.Format("{0}{0}", Path.DirectorySeparatorChar), StringComparison.Ordinal); i >= 0; i = name.IndexOf(string.Format("{0}{0}", Path.DirectorySeparatorChar), StringComparison.Ordinal))
			{
				name = name.Remove(i, 1);
			}
			i = name.IndexOfAny(WindowsNameTransform.InvalidEntryChars);
			if (i >= 0)
			{
				StringBuilder stringBuilder = new StringBuilder(name);
				while (i >= 0)
				{
					stringBuilder[i] = replacement;
					if (i >= name.Length)
					{
						i = -1;
					}
					else
					{
						i = name.IndexOfAny(WindowsNameTransform.InvalidEntryChars, i + 1);
					}
				}
				name = stringBuilder.ToString();
			}
			if (name.Length > 260)
			{
				throw new PathTooLongException();
			}
			return name;
		}
	}
}
