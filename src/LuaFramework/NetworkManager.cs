using System;
using System.Collections.Generic;
using UnityEngine;

namespace LuaFramework
{
	public class NetworkManager : Manager
	{
		private const int RECONNECT_MAX_COUNT = 3;

		private const float RECONNECT_DURATION = 3f;

		private SocketClient socket;

		private static readonly object m_lockObject = new object();

		private static Queue<KeyValuePair<int, ByteBuffer>> mEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

		private float reconnectTime;

		public bool inReconnect
		{
			get;
			set;
		}

		public bool lostConnect
		{
			get;
			private set;
		}

		private SocketClient SocketClient
		{
			get
			{
				if (this.socket == null)
				{
					this.socket = new SocketClient();
				}
				return this.socket;
			}
		}

		private new void Awake()
		{
			this.inReconnect = false;
			this.lostConnect = false;
		}

		public void Init()
		{
			this.SocketClient.OnRegister();
		}

		public void OnInit()
		{
			this.CallMethod("Start", new object[0]);
		}

		public void Unload()
		{
			this.CallMethod("Unload", new object[0]);
		}

		public void Close()
		{
			this.SocketClient.OnRemove();
		}

		public object[] CallMethod(string func, params object[] args)
		{
			return Util.CallMethod("Network", func, args);
		}

		public static void AddEvent(int _event, ByteBuffer data)
		{
			object lockObject = NetworkManager.m_lockObject;
			lock (lockObject)
			{
				NetworkManager.mEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
			}
		}

		private void Update()
		{
			if (NetworkManager.mEvents.Count > 0)
			{
				while (NetworkManager.mEvents.Count > 0)
				{
					KeyValuePair<int, ByteBuffer> keyValuePair = NetworkManager.mEvents.Dequeue();
					base.facade.SendMessageCommand("DispatchMessage", keyValuePair);
				}
			}
			if (this.lostConnect && !this.inReconnect)
			{
				this.reconnectTime -= Time.deltaTime;
				if (this.reconnectTime <= 0f)
				{
					if (this.SocketClient != null)
					{
						this.SocketClient.Close();
					}
					NetworkManager.AddEvent(107, new ByteBuffer());
					this.reconnectTime = 3f;
					this.inReconnect = true;
					this.SendConnect();
					Debug.LogWarning("reconnecting to the server...");
				}
			}
		}

		public void SendConnect()
		{
			this.SocketClient.SendConnect();
		}

		public void LostConnect()
		{
			this.inReconnect = false;
			this.lostConnect = true;
			this.reconnectTime = 0f;
		}

		public void ResetConnect()
		{
			this.lostConnect = false;
			this.inReconnect = false;
		}

		public void SendMessage(ByteBuffer buffer)
		{
			this.SocketClient.SendMessage(buffer);
		}

		private void OnDestroy()
		{
			this.Close();
			Debug.Log("~NetworkManager was destroy");
		}
	}
}
