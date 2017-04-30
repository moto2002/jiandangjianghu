using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ThirdParty;

public class SensitiveWordLogic : Singleton<SensitiveWordLogic>
{
	private List<string> SensitiveWord = new List<string>();

	public static SensitiveWordLogic GetInstance()
	{
		return Singleton<SensitiveWordLogic>.Instance;
	}

	private void Awake()
	{
		base.StartCoroutine("LoadSensitiveWord");
	}

	[DebuggerHidden]
	private IEnumerator LoadSensitiveWord()
	{
		SensitiveWordLogic.<LoadSensitiveWord>c__Iterator36 <LoadSensitiveWord>c__Iterator = new SensitiveWordLogic.<LoadSensitiveWord>c__Iterator36();
		<LoadSensitiveWord>c__Iterator.<>f__this = this;
		return <LoadSensitiveWord>c__Iterator;
	}

	public string filter(string src, string replace = "*")
	{
		try
		{
			int count = this.SensitiveWord.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.SensitiveWord[i].Length != 0)
				{
					byte[] bytes = System.Text.Encoding.UTF8.GetBytes(src);
					src = System.Text.Encoding.UTF8.GetString(bytes);
					src = src.Replace(this.SensitiveWord[i], replace);
				}
			}
		}
		catch (Exception)
		{
		}
		return src;
	}

	public bool isSensitive(string src)
	{
		int count = this.SensitiveWord.Count;
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(src);
		src = System.Text.Encoding.UTF8.GetString(bytes);
		for (int i = 0; i < count; i++)
		{
			if (this.SensitiveWord[i].Length > 0 && src.Contains(this.SensitiveWord[i]))
			{
				return true;
			}
		}
		return false;
	}
}
