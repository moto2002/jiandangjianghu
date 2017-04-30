using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameVersion
{
	public int majorVersion
	{
		get;
		private set;
	}

	public int assistantVersion
	{
		get;
		private set;
	}

	public int bundleVersion
	{
		get;
		private set;
	}

	private GameVersion(string version)
	{
		string[] array = version.Split(new char[]
		{
			'.'
		});
		if (array.Length >= 3)
		{
			this.majorVersion = Convert.ToInt32(array[0]);
			this.assistantVersion = Convert.ToInt32(array[1]);
			this.bundleVersion = Convert.ToInt32(array[2]);
		}
		else if (array.Length == 2)
		{
			this.majorVersion = Convert.ToInt32(array[0]);
			this.assistantVersion = Convert.ToInt32(array[1]);
			this.bundleVersion = 0;
		}
		else if (array.Length == 1)
		{
			this.majorVersion = Convert.ToInt32(array[0]);
			this.assistantVersion = 0;
			this.bundleVersion = 0;
		}
		else
		{
			this.majorVersion = 1;
			this.assistantVersion = 0;
			this.bundleVersion = 0;
		}
	}

	public static GameVersion CreateVersion(string version)
	{
		if (Regex.IsMatch(version, "^\\d+\\.\\d+\\.\\d+$"))
		{
			return new GameVersion(version);
		}
		if (Regex.IsMatch(version, "^\\d+\\.\\d+\\$"))
		{
			return new GameVersion(string.Format("{0}.0", version));
		}
		return new GameVersion("1.0.0");
	}

	public static GameVersion CreateVersion(string fileName, string defaultVersion)
	{
		if (File.Exists(fileName))
		{
			string text = File.ReadAllText(fileName);
			Debug.Log("Read version file: " + fileName + ", " + text);
			return GameVersion.CreateVersion(text);
		}
		return GameVersion.CreateVersion(defaultVersion);
	}

	public void VersionIncrease()
	{
		this.bundleVersion++;
		if (this.bundleVersion > 5000)
		{
			this.bundleVersion = 0;
			this.assistantVersion++;
			if (this.assistantVersion > 10)
			{
				this.majorVersion++;
			}
		}
	}

	public void VersionDecrease()
	{
		this.bundleVersion--;
		if (this.bundleVersion < 0)
		{
			this.bundleVersion = 5000;
			this.assistantVersion--;
			if (this.assistantVersion < 0)
			{
				this.assistantVersion = 10;
				this.majorVersion--;
			}
		}
	}

	public override int GetHashCode()
	{
		return RuntimeHelpers.GetHashCode(this);
	}

	public override string ToString()
	{
		return string.Format("{0}.{1}.{2}", this.majorVersion, this.assistantVersion, this.bundleVersion);
	}

	private int ToInt()
	{
		return this.majorVersion * 10 * 5000 + this.assistantVersion * 5000 + this.bundleVersion;
	}

	public static bool operator <(GameVersion lgv, GameVersion rgv)
	{
		return lgv.ToInt() < rgv.ToInt();
	}

	public static bool operator >(GameVersion lgv, GameVersion rgv)
	{
		return lgv.ToInt() > rgv.ToInt();
	}

	public static bool operator >=(GameVersion lgv, GameVersion rgv)
	{
		return lgv.ToInt() >= rgv.ToInt();
	}

	public static bool operator <=(GameVersion lgv, GameVersion rgv)
	{
		return lgv.ToInt() <= rgv.ToInt();
	}
}
