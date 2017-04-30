using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

namespace UIHelper
{
	public class UIPanelRoot : MonoBehaviour
	{
		public string Field;

		public string LuaRequirePath;

		public string FilePath = string.Empty;

		public int Depth = -1;

		public GameObject RelactiveRoot;

		public string relativePath;

		public string initRelativeHierarchy(GameObject root)
		{
			this.Depth = 0;
			Transform transform = base.transform;
			List<string> list = new List<string>();
			while (transform && !transform.gameObject.Equals(root))
			{
				list.Add(transform.name);
				transform = transform.parent;
				this.Depth++;
			}
			list.Reverse();
			this.relativePath = string.Join(".", list.ToArray());
			return this.relativePath;
		}

		public void BuildPanel(XmlDocument doc, GameObject root)
		{
			this.initRelativeHierarchy(root);
			if (string.IsNullOrEmpty(this.FilePath))
			{
				Debug.LogError("请先配置PanelRoot导出的脚本文件路径! Hierarchy:" + this.relativePath);
				return;
			}
			UIPanelRoot[] componentsInChildren = base.GetComponentsInChildren<UIPanelRoot>();
			List<UIPanelRoot> list = new List<UIPanelRoot>();
			UIPanelRoot[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				UIPanelRoot uIPanelRoot = array[i];
				if (!uIPanelRoot.gameObject.Equals(base.gameObject))
				{
					list.Add(uIPanelRoot);
					uIPanelRoot.BuildPanel(doc, root);
				}
			}
			List<UIGenFlag> list2 = new List<UIGenFlag>();
			this.findBuildComponent(base.gameObject, list2);
			string templetPath = (!(root == base.gameObject)) ? "Scripts/Editor/UITools/88-ToLua# Panel Script-SubPanel.lua.txt" : "Scripts/Editor/UITools/88-ToLua# Panel Script-Panel.lua.txt";
			this.writeScriptFile(list, list2, templetPath);
		}

		private void findBuildComponent(GameObject gObj, List<UIGenFlag> childFlags)
		{
			UIGenFlag component = gObj.GetComponent<UIGenFlag>();
			if (component)
			{
				childFlags.Add(component);
			}
			foreach (Transform transform in gObj.transform)
			{
				UIPanelRoot component2 = transform.GetComponent<UIPanelRoot>();
				if (!component2)
				{
					if (transform.childCount > 0)
					{
						this.findBuildComponent(transform.gameObject, childFlags);
					}
					else
					{
						component = transform.GetComponent<UIGenFlag>();
						if (component)
						{
							childFlags.Add(component);
						}
					}
				}
			}
		}

		private void writeScriptFile(List<UIPanelRoot> panelRoots, List<UIGenFlag> flags, string templetPath)
		{
			string text = Path.Combine(Application.dataPath, this.FilePath);
			string directoryName = Path.GetDirectoryName(text);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			string path = Path.Combine(Application.dataPath, templetPath);
			string text2 = string.Empty;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!File.Exists(text))
			{
				text2 = File.ReadAllText(path);
			}
			else
			{
				text2 = this.readLocalFile(text, dictionary);
			}
			StringBuilder stringBuilder = new StringBuilder();
			string text3 = ",path=";
			foreach (UIPanelRoot current in panelRoots)
			{
				string text4 = string.Format("\t\t{{field=\"{0}\",path=\"{1}\",src=LuaScript , requirePath=\"{2}\"}},", (!string.IsNullOrEmpty(current.Field)) ? current.Field : current.gameObject.name, current.relativePath, (!string.IsNullOrEmpty(current.LuaRequirePath)) ? current.LuaRequirePath : current.FilePath);
				string[] array = text4.Split(new string[]
				{
					text3
				}, StringSplitOptions.None);
				if (dictionary.ContainsKey(array[0]))
				{
					dictionary.Remove(array[0]);
				}
				stringBuilder.AppendLine(text4);
			}
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			foreach (UIGenFlag current2 in flags)
			{
				string text5 = (!string.IsNullOrEmpty(current2.Field)) ? current2.Field : current2.gameObject.name;
				string text6 = current2.initRelativeHierarchy(base.gameObject);
				if (dictionary2.ContainsKey(text5))
				{
					Debug.LogError(string.Format("PanelRoot have same field [\"{0}\"] ! hierarchy is \"{1}\" . Src [\"{2}\"]", text5, text6, dictionary2[text5]));
				}
				dictionary2[text5] = text6;
				string text7 = this.formatExport(current2);
				string[] array2 = text7.Split(new string[]
				{
					text3
				}, StringSplitOptions.None);
				if (dictionary.ContainsKey(array2[0]))
				{
					string dest = dictionary[array2[0]];
					if (current2.ScriptType == typeof(UIButton).FullName)
					{
						text7 = this.replace(text7, dest, "onClick");
					}
					else if (current2.ScriptType == typeof(UIToggle).FullName)
					{
						text7 = this.replace(text7, dest, "onChange");
					}
					else if (current2.ScriptType == typeof(UIInput).FullName)
					{
						text7 = this.replace(text7, dest, "onChange");
						text7 = this.replace(text7, dest, "onSubmit");
					}
					else if (current2.ScriptType == typeof(UISlider).FullName || current2.ScriptType == typeof(UIScrollBar).FullName)
					{
						text7 = this.replace(text7, dest, "onValueChange");
					}
					dictionary.Remove(array2[0]);
				}
				stringBuilder.AppendLine(text7);
			}
			if (dictionary.Count > 0)
			{
				stringBuilder.AppendLine("\t\t---custom extendsion");
				foreach (string current3 in dictionary.Values)
				{
					stringBuilder.AppendLine(current3);
				}
			}
			text2 = text2.Replace("#SCRIPTNAME#", Path.GetFileNameWithoutExtension(text));
			text2 = text2.Replace("#WIDGETS#", stringBuilder.ToString());
			if (!string.IsNullOrEmpty(text2))
			{
				File.WriteAllText(text, text2);
			}
		}

		private string replace(string src, string dest, string key)
		{
			int num = src.IndexOf(key);
			int num2 = dest.IndexOf(key);
			if (num < 0 || num2 < 0)
			{
				return src;
			}
			int num3 = src.IndexOf(",", num);
			string oldValue = src.Substring(num + 1, num3 - num - 2);
			int num4 = dest.IndexOf(",", num2);
			string newValue = dest.Substring(num2 + 1, num4 - num2 - 2);
			return src.Replace(oldValue, newValue);
		}

		private string readLocalFile(string filePath, Dictionary<string, string> localWidgets)
		{
			string text = File.ReadAllText(filePath);
			text = text.Replace("\r\n", "\n");
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			bool flag = false;
			string value = "widgets = {";
			string value2 = "}";
			string text2 = ",path=";
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Contains(value))
				{
					num = i;
					flag = true;
				}
				if (flag && array[i].Trim().Equals(value2))
				{
					num2 = i;
					break;
				}
				if (array[i].Contains(text2))
				{
					string[] array2 = array[i].Split(new string[]
					{
						text2
					}, StringSplitOptions.None);
					localWidgets[array2[0]] = array[i];
				}
			}
			string[] array3 = new string[array.Length - (num2 - num) + 2];
			Array.Copy(array, 0, array3, 0, num + 1);
			Array.Copy(array, num2, array3, num + 2, array.Length - num2);
			array3[num + 1] = "#WIDGETS#";
			return string.Join("\r\n", array3);
		}

		private string formatExport(UIGenFlag genFlag)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("\t\t{{field=\"{0}\",path=\"{1}\",", (!string.IsNullOrEmpty(genFlag.Field)) ? genFlag.Field : genFlag.gameObject.name, genFlag.relativeHierarchy);
			if (genFlag.ScriptType == typeof(UILabel).FullName)
			{
				stringBuilder.Append("src=LuaText");
			}
			else if (genFlag.ScriptType == typeof(UISprite).FullName)
			{
				stringBuilder.Append("src=LuaImage");
			}
			else if (genFlag.ScriptType == typeof(UIButton).FullName)
			{
				stringBuilder.Append("src=LuaButton, onClick = function (gObj)  --[===[todo click]===]  end ");
			}
			else if (genFlag.ScriptType == typeof(UIToggle).FullName)
			{
				stringBuilder.Append("src=LuaToggle , onChange = function (toggle) --[===[todo toggle.onchange]===] end");
			}
			else if (genFlag.ScriptType == typeof(UIPanel).FullName)
			{
				stringBuilder.Append("src=LuaPanel");
			}
			else if (genFlag.ScriptType == typeof(UIInput).FullName)
			{
				stringBuilder.Append("src=LuaInput, onChange = function (input) --[===[todo input change]===]  end , onSubmit = function (input) --[===[todo input onSubmit]===]  end");
			}
			else if (genFlag.ScriptType == typeof(UISlider).FullName)
			{
				stringBuilder.Append("src=LuaSlider, onValueChange = function (slider) --[===[todo change]===]  end ");
			}
			else if (genFlag.ScriptType == typeof(UIScrollBar).FullName)
			{
				stringBuilder.Append("src=LuaScrollBar, onValueChange = function (scrollBar) --[===[todo change]===]  end ");
			}
			else
			{
				stringBuilder.AppendFormat("src=\"{0}\"", genFlag.ScriptType);
			}
			stringBuilder.Append("},");
			return stringBuilder.ToString();
		}

		public void serializePanelRoot(XmlDocument doc, List<UIGenFlag> flags)
		{
			XmlNode xmlNode = doc.SelectSingleNode("panelRoots");
			if (xmlNode == null)
			{
				xmlNode = doc.CreateElement("panelRoots");
				doc.AppendChild(xmlNode);
			}
			XmlElement xmlElement = doc.CreateElement("panelRoot");
			xmlElement.SetAttribute("field", this.Field);
			xmlElement.SetAttribute("filePath", this.FilePath);
			xmlElement.SetAttribute("luaRequirePath", this.LuaRequirePath);
			xmlElement.SetAttribute("hierarchy", (!string.IsNullOrEmpty(this.relativePath)) ? this.relativePath : base.gameObject.name);
			foreach (UIGenFlag current in flags)
			{
				XmlElement xmlElement2 = doc.CreateElement("flag");
				current.serializeFlag(xmlElement2);
				xmlElement.AppendChild(xmlElement2);
			}
			xmlNode.AppendChild(xmlElement);
		}

		public void deserializePanelRoot(XmlElement ele)
		{
			this.Field = ele.GetAttribute("field");
			this.FilePath = ele.GetAttribute("filePath");
			this.LuaRequirePath = ele.GetAttribute("luaRequirePath");
			if (string.IsNullOrEmpty(this.LuaRequirePath))
			{
				this.LuaRequirePath = this.FilePath.Replace(".lua", string.Empty).Replace("/", ".");
			}
			foreach (XmlElement xmlElement in ele.ChildNodes)
			{
				string text = xmlElement.GetAttribute("hierarchy");
				text = text.Replace(".", "/");
				Transform transform = base.transform.FindChild(text);
				if (!(transform == null))
				{
					UIGenFlag uIGenFlag = transform.GetComponent<UIGenFlag>();
					if (uIGenFlag == null)
					{
						uIGenFlag = transform.gameObject.AddComponent<UIGenFlag>();
					}
					uIGenFlag.deserializeFlag(xmlElement);
				}
			}
		}
	}
}
