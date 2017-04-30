using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class LuaBehaviour : Base
	{
		public delegate void UiExtendEventDeal(GameObject go, string type);

		private Dictionary<UIInput, Dictionary<string, LuaFunction>> inputControls = new Dictionary<UIInput, Dictionary<string, LuaFunction>>();

		private Dictionary<UIWidgetContainer, LuaFunction> widgetContainers = new Dictionary<UIWidgetContainer, LuaFunction>();

		private Dictionary<string, Dictionary<string, LuaFunction>> controls = new Dictionary<string, Dictionary<string, LuaFunction>>();

		private Dictionary<UIPlayTween, LuaFunction> playTweens = new Dictionary<UIPlayTween, LuaFunction>();

		private static List<LuaBehaviour.UiExtendEventDeal> extendEventDeals = new List<LuaBehaviour.UiExtendEventDeal>();

		protected void Awake()
		{
			Util.CallMethod(base.name, "Awake", new object[]
			{
				base.gameObject
			});
		}

		protected void Start()
		{
			Util.CallMethod(base.name, "Start", new object[0]);
		}

		protected void OnClick()
		{
			Util.CallMethod(base.name, "OnClick", new object[0]);
		}

		protected void OnClickEvent(GameObject go)
		{
			Util.CallMethod(base.name, "OnClick", new object[]
			{
				go
			});
		}

		public void OnInit()
		{
			Util.CallMethod(base.name, "OnInit", new object[0]);
			Debug.LogWarning("OnInit---->>>" + base.name);
		}

		public void OnClose()
		{
			Util.CallMethod(base.name, "OnClose", new object[0]);
		}

		public void OnChangeSceneHide()
		{
			Util.CallMethod(base.name, "OnChangeSceneHide", new object[0]);
		}

		protected void OnDestroy()
		{
			Util.CallMethod(base.name, "OnDestroy", new object[]
			{
				base.gameObject
			});
			this.ClearUIEvent();
			Util.ClearMemory();
			Debug.Log("~" + base.name + " was destroy!");
		}

		public void AddSubmit(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			UIInput input = go.GetComponent<UIInput>();
			if (input == null)
			{
				return;
			}
			if (!this.inputControls.ContainsKey(input))
			{
				Dictionary<string, LuaFunction> dictionary = new Dictionary<string, LuaFunction>();
				dictionary.Add("onsubmit", luafunc);
				this.inputControls.Add(input, dictionary);
			}
			else if (!this.inputControls[input].ContainsKey("onsubmit"))
			{
				this.inputControls[input].Add("onsubmit", luafunc);
			}
			EventDelegate.Add(input.onSubmit, delegate
			{
				luafunc.Call(new object[]
				{
					input
				});
			});
		}

		public void AddValueChange(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			UIInput input = go.GetComponent<UIInput>();
			if (input == null)
			{
				return;
			}
			if (!this.inputControls.ContainsKey(input))
			{
				Dictionary<string, LuaFunction> dictionary = new Dictionary<string, LuaFunction>();
				dictionary.Add("onchange", luafunc);
				this.inputControls.Add(input, dictionary);
			}
			else if (!this.inputControls[input].ContainsKey("onchange"))
			{
				this.inputControls[input].Add("onchange", luafunc);
			}
			EventDelegate.Add(input.onChange, delegate
			{
				luafunc.Call(new object[]
				{
					input
				});
			});
		}

		public void RemoveSubmit(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UIInput component = go.GetComponent<UIInput>();
			this.RemoveUIInputEvent(component, "onsubmit");
		}

		public void RemoveValueChange(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UIInput component = go.GetComponent<UIInput>();
			this.RemoveUIInputEvent(component, "onchange");
		}

		private void RemoveUIInputEvent(UIInput input, string eventType)
		{
			if (input == null)
			{
				return;
			}
			Dictionary<string, LuaFunction> dictionary = null;
			if (this.inputControls.TryGetValue(input, out dictionary))
			{
				LuaFunction luaFunction = null;
				if (dictionary.TryGetValue(eventType, out luaFunction))
				{
					luaFunction.Dispose();
					luaFunction = null;
					input.onSubmit.Clear();
					dictionary.Remove(eventType);
				}
				if (dictionary.Count == 0)
				{
					this.inputControls.Remove(input);
				}
			}
		}

		private void InputUIEventClear()
		{
			foreach (KeyValuePair<UIInput, Dictionary<string, LuaFunction>> current in this.inputControls)
			{
				foreach (KeyValuePair<string, LuaFunction> current2 in current.Value)
				{
					if (current2.Value != null)
					{
						current2.Value.Dispose();
					}
				}
				current.Key.onSubmit.Clear();
				current.Key.onChange.Clear();
			}
			this.inputControls.Clear();
		}

		public void AddWidgetContainerChangeEvent(UIWidgetContainer container, LuaFunction luafunc)
		{
			if (!this.widgetContainers.ContainsKey(container))
			{
				this.widgetContainers.Add(container, luafunc);
			}
		}

		public void AddPopupListChange(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			UIPopupList popuplist = go.GetComponent<UIPopupList>();
			if (popuplist == null)
			{
				return;
			}
			this.AddWidgetContainerChangeEvent(popuplist, luafunc);
			EventDelegate.Add(popuplist.onChange, delegate
			{
				luafunc.Call(new object[]
				{
					popuplist
				});
			});
		}

		public void AddProgressBarChange(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			UIProgressBar progressbar = go.GetComponent<UIProgressBar>();
			if (progressbar == null)
			{
				return;
			}
			this.AddWidgetContainerChangeEvent(progressbar, luafunc);
			EventDelegate.Add(progressbar.onChange, delegate
			{
				luafunc.Call(new object[]
				{
					progressbar
				});
			});
		}

		public void AddToggleChange(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			UIToggle toggle = go.GetComponent<UIToggle>();
			if (toggle == null)
			{
				return;
			}
			this.AddWidgetContainerChangeEvent(toggle, luafunc);
			EventDelegate.Add(toggle.onChange, delegate
			{
				luafunc.Call(new object[]
				{
					toggle
				});
			});
		}

		public void RemoveWidgetContainerEvent(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UIWidgetContainer component = go.GetComponent<UIWidgetContainer>();
			if (component == null)
			{
				return;
			}
			LuaFunction luaFunction = null;
			if (this.widgetContainers.TryGetValue(component, out luaFunction))
			{
				luaFunction.Dispose();
				luaFunction = null;
				if (component is UIPopupList)
				{
					UIPopupList uIPopupList = component as UIPopupList;
					uIPopupList.onChange.Clear();
				}
				else if (component is UIProgressBar)
				{
					UIProgressBar uIProgressBar = component as UIProgressBar;
					uIProgressBar.onChange.Clear();
				}
				else if (component is UIToggle)
				{
					UIToggle uIToggle = component as UIToggle;
					uIToggle.onChange.Clear();
				}
				this.widgetContainers.Remove(component);
			}
		}

		private void WidgetContainerEventClear()
		{
			foreach (KeyValuePair<UIWidgetContainer, LuaFunction> current in this.widgetContainers)
			{
				if (current.Value != null)
				{
					current.Value.Dispose();
				}
				if (current.Key is UIPopupList)
				{
					UIPopupList uIPopupList = current.Key as UIPopupList;
					uIPopupList.onChange.Clear();
				}
				else if (current.Key is UIProgressBar)
				{
					UIProgressBar uIProgressBar = current.Key as UIProgressBar;
					uIProgressBar.onChange.Clear();
				}
				else if (current.Key is UIToggle)
				{
					UIToggle uIToggle = current.Key as UIToggle;
					uIToggle.onChange.Clear();
				}
			}
			this.widgetContainers.Clear();
		}

		private void AddEventListener(string goname, string eventType, LuaFunction luafunc)
		{
			if (!this.controls.ContainsKey(goname))
			{
				Dictionary<string, LuaFunction> dictionary = new Dictionary<string, LuaFunction>();
				dictionary.Add(eventType, luafunc);
				this.controls.Add(goname, dictionary);
			}
			else if (!this.controls[goname].ContainsKey(eventType))
			{
				this.controls[goname].Add(eventType, luafunc);
			}
		}

		public void AddClick(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "onclick", luafunc);
			UIEventListener.Get(go).onClick = delegate(GameObject o)
			{
				LuaBehaviour.ExtendEventDeal(go, "onclick");
				luafunc.Call(new object[]
				{
					go
				});
			};
		}

		public void AddDoubleClick(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondoubleclick", luafunc);
			UIEventListener.Get(go).onDoubleClick = delegate(GameObject o)
			{
				LuaBehaviour.ExtendEventDeal(go, "ondoubleclick");
				luafunc.Call(new object[]
				{
					go
				});
			};
		}

		public void AddHovor(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "onhovor", luafunc);
			UIEventListener.Get(go).onHover = delegate(GameObject o, bool isOver)
			{
				luafunc.Call(new object[]
				{
					go,
					isOver
				});
			};
		}

		public void AddPress(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "onpress", luafunc);
			UIEventListener.Get(go).onPress = delegate(GameObject o, bool isPressed)
			{
				LuaBehaviour.ExtendEventDeal(go, "onpress");
				luafunc.Call(new object[]
				{
					go,
					isPressed
				});
			};
		}

		public void AddSelect(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "onselect", luafunc);
			UIEventListener.Get(go).onSelect = delegate(GameObject o, bool selected)
			{
				luafunc.Call(new object[]
				{
					go,
					selected
				});
			};
		}

		public void AddScroll(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "onscroll", luafunc);
			UIEventListener.Get(go).onScroll = delegate(GameObject o, float delta)
			{
				luafunc.Call(new object[]
				{
					go,
					delta
				});
			};
		}

		public void AddDragStart(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondragstart", luafunc);
			UIEventListener.Get(go).onDragStart = delegate(GameObject o)
			{
				LuaBehaviour.ExtendEventDeal(go, "ondragstart");
				luafunc.Call(new object[]
				{
					go
				});
			};
		}

		public void AddDrag(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondrag", luafunc);
			UIEventListener.Get(go).onDrag = delegate(GameObject o, Vector2 delta)
			{
				luafunc.Call(new object[]
				{
					go,
					delta
				});
			};
		}

		public void AddDragOver(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondragover", luafunc);
			UIEventListener.Get(go).onDragOver = delegate(GameObject o)
			{
				luafunc.Call(new object[]
				{
					go
				});
			};
		}

		public void AddDragOut(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondragout", luafunc);
			UIEventListener.Get(go).onDragOut = delegate(GameObject o)
			{
				luafunc.Call(new object[]
				{
					go
				});
			};
		}

		public void AddDragEnd(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondragend", luafunc);
			UIEventListener.Get(go).onDragEnd = delegate(GameObject o)
			{
				luafunc.Call(new object[]
				{
					go
				});
			};
		}

		public void AddDrop(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ondrop", luafunc);
			UIEventListener.Get(go).onDrop = delegate(GameObject o, GameObject dropGo)
			{
				luafunc.Call(new object[]
				{
					go,
					dropGo
				});
			};
		}

		public void AddKey(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "onkey", luafunc);
			UIEventListener.Get(go).onKey = delegate(GameObject o, KeyCode key)
			{
				LuaBehaviour.ExtendEventDeal(go, "onkey");
				luafunc.Call(new object[]
				{
					go,
					key
				});
			};
		}

		public void AddTooltip(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			this.AddEventListener(go.name, "ontooltip", luafunc);
			UIEventListener.Get(go).onTooltip = delegate(GameObject o, bool show)
			{
				luafunc.Call(new object[]
				{
					go,
					show
				});
			};
		}

		public void RemoveClick(GameObject go)
		{
			this.RemoveUIEvent(go, "onclick");
		}

		public void RemoveHovor(GameObject go)
		{
			this.RemoveUIEvent(go, "onhover");
		}

		public void RemoveUIEvent(GameObject go, string eventType)
		{
			if (go == null)
			{
				return;
			}
			Dictionary<string, LuaFunction> dictionary = null;
			if (this.controls.TryGetValue(go.name, out dictionary))
			{
				LuaFunction luaFunction = null;
				if (dictionary.TryGetValue(eventType, out luaFunction))
				{
					dictionary.Remove(eventType);
					luaFunction.Dispose();
					luaFunction = null;
				}
				if (dictionary.Count == 0)
				{
					this.controls.Remove(go.name);
				}
			}
		}

		private void OtherUIEventClear()
		{
			foreach (KeyValuePair<string, Dictionary<string, LuaFunction>> current in this.controls)
			{
				foreach (KeyValuePair<string, LuaFunction> current2 in current.Value)
				{
					if (current2.Value != null)
					{
						current2.Value.Dispose();
					}
				}
			}
			this.controls.Clear();
		}

		public void AddUIPlayTweenEvent(GameObject go, LuaFunction luafunc)
		{
			if (go == null || luafunc == null)
			{
				return;
			}
			UIPlayTween playTween = go.GetComponent<UIPlayTween>();
			if (playTween == null)
			{
				return;
			}
			if (!this.playTweens.ContainsKey(playTween))
			{
				this.playTweens.Add(playTween, luafunc);
			}
			EventDelegate.Add(playTween.onFinished, delegate
			{
				luafunc.Call(new object[]
				{
					playTween
				});
			});
		}

		public void RemoveUIPlayTweenEvent(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UIPlayTween component = go.GetComponent<UIPlayTween>();
			if (component == null)
			{
				return;
			}
			LuaFunction luaFunction = null;
			if (this.playTweens.TryGetValue(component, out luaFunction))
			{
				luaFunction.Dispose();
				luaFunction = null;
				component.onFinished.Clear();
				this.playTweens.Remove(component);
			}
		}

		private void UIPlayTweenEventClear()
		{
			foreach (KeyValuePair<UIPlayTween, LuaFunction> current in this.playTweens)
			{
				if (current.Value != null)
				{
					current.Value.Dispose();
				}
				current.Key.onFinished.Clear();
			}
		}

		public void ClearUIEvent()
		{
			this.WidgetContainerEventClear();
			this.InputUIEventClear();
			this.OtherUIEventClear();
			this.UIPlayTweenEventClear();
		}

		public static void ExtendEventDeal(GameObject go, string type)
		{
			for (int i = 0; i < LuaBehaviour.extendEventDeals.Count; i++)
			{
				LuaBehaviour.extendEventDeals[i](go, type);
			}
		}

		public static void AddExtendEvent(LuaBehaviour.UiExtendEventDeal func)
		{
			for (int i = 0; i < LuaBehaviour.extendEventDeals.Count; i++)
			{
				if (LuaBehaviour.extendEventDeals[i] == func)
				{
					return;
				}
			}
			LuaBehaviour.extendEventDeals.Add(func);
		}

		public static void RemoveExtendEvent(LuaBehaviour.UiExtendEventDeal func)
		{
			for (int i = 0; i < LuaBehaviour.extendEventDeals.Count; i++)
			{
				if (LuaBehaviour.extendEventDeals[i] == func)
				{
					LuaBehaviour.extendEventDeals.RemoveAt(i);
					return;
				}
			}
		}
	}
}
