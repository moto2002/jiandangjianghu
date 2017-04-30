using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace ThirdParty
{
	public class IniFile
	{
		private bool debug;

		private string fileName;

		private Dictionary<string, Dictionary<string, string>> storedData;

		private Dictionary<string, string> currentSelctor;

		public IniFile(string _fileString, bool _debug = false)
		{
			this.debug = _debug;
			this.storedData = new Dictionary<string, Dictionary<string, string>>();
			this.Clear();
			this.Read_From_String(_fileString);
		}

		public IniFile(bool _debug = false)
		{
			this.debug = _debug;
			this.storedData = new Dictionary<string, Dictionary<string, string>>();
			this.Clear();
		}

		public void Clear()
		{
			this.storedData.Clear();
			this.currentSelctor = null;
		}

		public void Read_From_String(string data)
		{
			if (this.debug)
			{
				Debug.Log("IniFile Read String: " + data);
			}
			string[] array = data.Split(new char[]
			{
				'\n'
			});
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				text = text.Trim();
				if (text.Length != 0)
				{
					if (text.ToCharArray()[0] != '#')
					{
						if (text.ToCharArray()[0] == '[')
						{
							text = text.Split(new char[]
							{
								'['
							})[1].Split(new char[]
							{
								']'
							})[0];
							text = text.Trim();
							if (!this.storedData.ContainsKey(text))
							{
								this.currentSelctor = new Dictionary<string, string>();
								this.currentSelctor.Clear();
								this.storedData.Add(text, this.currentSelctor);
							}
							else
							{
								this.currentSelctor = this.storedData[text];
							}
						}
						else
						{
							int num = text.IndexOf('=');
							if (num >= 0)
							{
								string key = text.Substring(0, num);
								string value = text.Substring(num + 1, text.Length - num - 1);
								if (this.currentSelctor != null)
								{
									this.currentSelctor.Add(key, value);
								}
							}
						}
					}
				}
			}
			this.currentSelctor = null;
		}

		public void Read_From_Resource(string _fileName)
		{
			UnityEngine.Object @object = Resources.Load<UnityEngine.Object>(_fileName);
			if (this.debug)
			{
				Debug.Log("IniFile Read File from Resource:\n" + @object);
			}
			this.Read_From_String(@object.ToString());
		}

		public void Read_From_File(string _fileName)
		{
			string data = File.ReadAllText(_fileName);
			if (this.debug)
			{
				Debug.Log("IniFile Read File: " + _fileName);
			}
			this.Read_From_String(data);
		}

		public bool goTo(string selctor)
		{
			if (!this.storedData.ContainsKey(selctor))
			{
				return false;
			}
			this.currentSelctor = this.storedData[selctor];
			return true;
		}

		public string GetValue_String(string _name, string defaultValue = "")
		{
			string result = defaultValue;
			if (this.currentSelctor != null && this.currentSelctor.ContainsKey(_name))
			{
				result = this.currentSelctor[_name];
			}
			return result;
		}

		public int GetValue_Int(string _name, int defaultValue = 0)
		{
			return int.Parse(this.GetValue_String(_name, defaultValue + string.Empty));
		}

		public float GetValue_Float(string _name, float defaultValue = 0f)
		{
			return float.Parse(this.GetValue_String(_name, defaultValue + string.Empty));
		}

		public bool IsContainsName(string _name)
		{
			return this.currentSelctor != null && this.currentSelctor.ContainsKey(_name);
		}

		public void SetSelctor(string selctor)
		{
			this.currentSelctor = null;
			if (this.storedData.ContainsKey(selctor))
			{
				this.currentSelctor = this.storedData[selctor];
			}
			else
			{
				this.currentSelctor = new Dictionary<string, string>();
				this.storedData.Add(selctor, this.currentSelctor);
			}
		}

		public void SetString(string _name, string _value)
		{
			if (this.currentSelctor == null)
			{
				return;
			}
			if (this.currentSelctor.ContainsKey(_name))
			{
				this.currentSelctor[_name] = _value;
			}
			else
			{
				this.currentSelctor.Add(_name, _value);
			}
		}

		public void SetInt(string _name, int _value)
		{
			this.SetString(_name, _value.ToString());
		}

		public void SetFloat(string _name, float _value)
		{
			this.SetString(_name, _value.ToString());
		}

		public void RemoveSelector(string _name)
		{
			if (this.storedData.ContainsKey(_name))
			{
				if (this.currentSelctor == this.storedData[_name])
				{
					this.currentSelctor = null;
				}
				this.storedData[_name].Clear();
				this.storedData.Remove(_name);
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string current in this.storedData.Keys)
			{
				stringBuilder.AppendFormat("[{0}]\n", current);
				Dictionary<string, string> dictionary = this.storedData[current];
				foreach (string current2 in dictionary.Keys)
				{
					stringBuilder.AppendFormat("{0}={1}\n", current2, dictionary[current2]);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
