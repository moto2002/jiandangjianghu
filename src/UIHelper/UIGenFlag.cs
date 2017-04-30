using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace UIHelper
{
	public class UIGenFlag : MonoBehaviour
	{
		public string Uri;

		public string Field;

		public string ScriptType;

		public int Depth = -1;

		public string relativeHierarchy;

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
			if (string.IsNullOrEmpty(this.ScriptType))
			{
				this.ScriptType = this.FindWidgetTypes()[0];
			}
			this.relativeHierarchy = string.Join(".", list.ToArray());
			return this.relativeHierarchy;
		}

		public List<string> FindWidgetTypes()
		{
			List<string> list = new List<string>();
			UIRect[] components = base.gameObject.GetComponents<UIRect>();
			UIRect[] array = components;
			for (int i = 0; i < array.Length; i++)
			{
				UIRect uIRect = array[i];
				list.Add(uIRect.GetType().FullName);
			}
			UIWidgetContainer[] components2 = base.gameObject.GetComponents<UIWidgetContainer>();
			UIWidgetContainer[] array2 = components2;
			for (int j = 0; j < array2.Length; j++)
			{
				UIWidgetContainer uIWidgetContainer = array2[j];
				list.Add(uIWidgetContainer.GetType().FullName);
			}
			UIInput component = base.gameObject.GetComponent<UIInput>();
			if (component)
			{
				list.Add(component.GetType().FullName);
			}
			list.Add("GameObject");
			list.Add("Transform");
			return list;
		}

		public void serializeFlag(XmlElement ele)
		{
			ele.SetAttribute("field", this.Field);
			ele.SetAttribute("ScriptType", this.ScriptType);
			ele.SetAttribute("hierarchy", this.relativeHierarchy);
		}

		public void deserializeFlag(XmlElement ele)
		{
			this.Field = ele.GetAttribute("field");
			this.ScriptType = ele.GetAttribute("ScriptType");
			this.relativeHierarchy = ele.GetAttribute("hierarchy");
		}
	}
}
