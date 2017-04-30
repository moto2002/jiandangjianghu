using System;
using System.Collections;
using System.Collections.Generic;
using ThirdParty;

public class CustomEventManager : Singleton<CustomEventManager>
{
	private Hashtable _eventTable;

	private void Awake()
	{
		this._eventTable = new Hashtable();
	}

	public void DispatchCustomEvent(int type, List<KeyValuePair<string, object>> infoList)
	{
		if (this._eventTable.ContainsKey(type))
		{
			List<CustomEvent> list = this._eventTable[type] as List<CustomEvent>;
			if (list == null || list.Count <= 0)
			{
				return;
			}
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				CustomEvent customEvent = list[i];
				customEvent.callBack(infoList);
			}
		}
	}

	public void AddEventListener(CustomEvent aEvent)
	{
		if (aEvent == null)
		{
			return;
		}
		if (this._eventTable.ContainsKey(aEvent.eventType))
		{
			List<CustomEvent> list = this._eventTable[aEvent.eventType] as List<CustomEvent>;
			list.Add(aEvent);
		}
		else
		{
			List<CustomEvent> list = new List<CustomEvent>();
			list.Add(aEvent);
			this._eventTable.Add(aEvent.eventType, list);
		}
	}

	public void RemvoeCustomEventListener(CustomEvent aEvent)
	{
		if (aEvent == null || this._eventTable == null)
		{
			return;
		}
		if (this._eventTable.ContainsKey(aEvent.eventType))
		{
			List<CustomEvent> list = this._eventTable[aEvent.eventType] as List<CustomEvent>;
			list.Remove(aEvent);
		}
	}

	public void DeleteEventListenerByType(int type)
	{
		if (this._eventTable.ContainsKey(type))
		{
			this._eventTable.Remove(type);
		}
	}

	public void ClearEventListener()
	{
		this._eventTable.Clear();
	}
}
