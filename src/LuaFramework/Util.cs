using LuaInterface;
using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using ThirdParty;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LuaFramework
{
	public class Util
	{
		public enum SoundType
		{
			BGM,
			Skill,
			Talk,
			UI
		}

		public static string DataPath
		{
			get
			{
				string text = AppConst.AppName.ToLower();
				if (Application.isMobilePlatform)
				{
					return Application.persistentDataPath + "/" + text + "/";
				}
				if (Application.platform == RuntimePlatform.WindowsPlayer)
				{
					return Application.streamingAssetsPath + "/";
				}
				if (Application.platform == RuntimePlatform.OSXEditor)
				{
					int num = Application.dataPath.LastIndexOf('/');
					return Application.dataPath.Substring(0, num + 1) + text + "/";
				}
				string path = System.IO.Path.Combine(Application.dataPath, "../game/");
				return System.IO.Path.GetFullPath(path);
			}
		}

		public static string LuaPath
		{
			get
			{
				return Util.DataPath + "lua/";
			}
		}

		public static int Int(object o)
		{
			return Convert.ToInt32(o);
		}

		public static float Float(object o)
		{
			return (float)Math.Round((double)Convert.ToSingle(o), 2);
		}

		public static long Long(object o)
		{
			return Convert.ToInt64(o);
		}

		public static int Random(int min, int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static float Random(float min, float max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static string Uid(string uid)
		{
			int num = uid.LastIndexOf('_');
			return uid.Remove(0, num + 1);
		}

		public static long GetTime()
		{
			long arg_27_0 = DateTime.UtcNow.Ticks;
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			TimeSpan timeSpan = new TimeSpan(arg_27_0 - dateTime.Ticks);
			return (long)timeSpan.TotalMilliseconds;
		}

		public static void SetWrapLabel(UILabel lab, string text, int height)
		{
			string text2 = null;
			lab.UpdateNGUIText();
			if (!lab.Wrap(text, out text2, height))
			{
				text2 = text2.Substring(0, text2.Length - 1);
				text2 += "...";
			}
			lab.text = text2;
		}

		public static T Get<T>(GameObject go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform transform = go.transform.FindChild(subnode);
				if (transform != null)
				{
					return transform.GetComponent<T>();
				}
			}
			return (T)((object)null);
		}

		public static T Get<T>(Transform go, string subnode) where T : Component
		{
			if (go != null)
			{
				Transform transform = go.FindChild(subnode);
				if (transform != null)
				{
					return transform.GetComponent<T>();
				}
			}
			return (T)((object)null);
		}

		public static T Get<T>(Component go, string subnode) where T : Component
		{
			return go.transform.FindChild(subnode).GetComponent<T>();
		}

		public static T Add<T>(GameObject go) where T : Component
		{
			if (go != null)
			{
				T[] components = go.GetComponents<T>();
				for (int i = 0; i < components.Length; i++)
				{
					if (components[i] != null)
					{
						UnityEngine.Object.Destroy(components[i]);
					}
				}
				return go.gameObject.AddComponent<T>();
			}
			return (T)((object)null);
		}

		public static T Add<T>(Transform go) where T : Component
		{
			return Util.Add<T>(go.gameObject);
		}

		public static GameObject Child(GameObject go, string subnode)
		{
			return Util.Child(go.transform, subnode);
		}

		public static GameObject Child(Transform go, string subnode)
		{
			Transform transform = go.FindChild(subnode);
			if (transform == null)
			{
				return null;
			}
			return transform.gameObject;
		}

		public static GameObject Peer(GameObject go, string subnode)
		{
			return Util.Peer(go.transform, subnode);
		}

		public static GameObject Peer(Transform go, string subnode)
		{
			Transform transform = go.parent.FindChild(subnode);
			if (transform == null)
			{
				return null;
			}
			return transform.gameObject;
		}

		public static string md5(string source)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(source);
			byte[] array = mD5CryptoServiceProvider.ComputeHash(bytes, 0, bytes.Length);
			mD5CryptoServiceProvider.Clear();
			string text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				text += Convert.ToString(array[i], 16).PadLeft(2, '0');
			}
			return text.PadLeft(32, '0');
		}

		public static string md5file(string file)
		{
			string result;
			try
			{
				FileStream fileStream = new FileStream(file, FileMode.Open);
				System.Security.Cryptography.MD5 mD = new MD5CryptoServiceProvider();
				byte[] array = mD.ComputeHash(fileStream);
				fileStream.Close();
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				result = stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				throw new Exception("md5file() fail, error:" + ex.Message);
			}
			return result;
		}

		public static void ClearChild(Transform go)
		{
			if (go == null)
			{
				return;
			}
			for (int i = go.childCount - 1; i >= 0; i--)
			{
				UnityEngine.Object.Destroy(go.GetChild(i).gameObject);
			}
		}

		public static void ClearMemory()
		{
			GC.Collect();
			Resources.UnloadUnusedAssets();
			LuaManager manager = AppFacade.Instance.GetManager<LuaManager>("LuaScriptMgr");
			if (manager != null)
			{
				manager.LuaGC();
			}
		}

		public static string AppContentPath()
		{
			string result = string.Empty;
			switch (Application.platform)
			{
			case RuntimePlatform.IPhonePlayer:
				result = Application.dataPath + "/Raw/";
				return result;
			case RuntimePlatform.Android:
				result = "jar:file://" + Application.dataPath + "!/assets/";
				return result;
			}
			result = Application.dataPath + "/StreamingAssets/";
			return result;
		}

		public static void AddClick(GameObject go, object luafuc)
		{
			UIEventListener expr_13 = UIEventListener.Get(go);
			expr_13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(expr_13.onClick, new UIEventListener.VoidDelegate(delegate(GameObject o)
			{
				LuaFunction luaFunction = (LuaFunction)luafuc;
				luaFunction.Call();
			}));
		}

		public static void Log(string str)
		{
			Debugger.Log(str);
		}

		public static void LogWarning(string str)
		{
			Debugger.LogWarning(str);
		}

		public static void LogError(string str)
		{
			Debugger.LogError(str);
		}

		public static Component AddComponent(GameObject go, string assembly, string classname)
		{
			Assembly assembly2 = Assembly.Load(assembly);
			Type type = assembly2.GetType(assembly + "." + classname);
			return go.AddComponent(type);
		}

		public static GameObject LoadPrefab(string name)
		{
			return Singleton<AssetBundleManager>.Instance.LoadPrefab(name);
		}

		public static GameObject LoadBucket(Transform parent)
		{
			GameObject original = Resources.Load("Other/bucket", typeof(GameObject)) as GameObject;
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original);
			if (parent != null)
			{
				gameObject.transform.SetParent(parent);
			}
			return gameObject;
		}

		[DebuggerHidden]
		public static IEnumerator LoadPrefabAsync(string name, Action<GameObject, string> callback)
		{
			Util.<LoadPrefabAsync>c__Iterator23 <LoadPrefabAsync>c__Iterator = new Util.<LoadPrefabAsync>c__Iterator23();
			<LoadPrefabAsync>c__Iterator.name = name;
			<LoadPrefabAsync>c__Iterator.callback = callback;
			<LoadPrefabAsync>c__Iterator.<$>name = name;
			<LoadPrefabAsync>c__Iterator.<$>callback = callback;
			return <LoadPrefabAsync>c__Iterator;
		}

		public static UIAtlas loadAtlas(string name)
		{
			return Singleton<AssetBundleManager>.Instance.LoadAtlas(name);
		}

		[DebuggerHidden]
		public static IEnumerator LoadAudioClipAsync(GameObject go, string name, string extension, Action<AudioClip, string> callback)
		{
			Util.<LoadAudioClipAsync>c__Iterator24 <LoadAudioClipAsync>c__Iterator = new Util.<LoadAudioClipAsync>c__Iterator24();
			<LoadAudioClipAsync>c__Iterator.go = go;
			<LoadAudioClipAsync>c__Iterator.name = name;
			<LoadAudioClipAsync>c__Iterator.extension = extension;
			<LoadAudioClipAsync>c__Iterator.callback = callback;
			<LoadAudioClipAsync>c__Iterator.<$>go = go;
			<LoadAudioClipAsync>c__Iterator.<$>name = name;
			<LoadAudioClipAsync>c__Iterator.<$>extension = extension;
			<LoadAudioClipAsync>c__Iterator.<$>callback = callback;
			return <LoadAudioClipAsync>c__Iterator;
		}

		[DebuggerHidden]
		public static IEnumerator LoadBGMAudioAsync(GameObject go, string name, string extension, Action<AudioClip, string> callback)
		{
			Util.<LoadBGMAudioAsync>c__Iterator25 <LoadBGMAudioAsync>c__Iterator = new Util.<LoadBGMAudioAsync>c__Iterator25();
			<LoadBGMAudioAsync>c__Iterator.go = go;
			<LoadBGMAudioAsync>c__Iterator.name = name;
			<LoadBGMAudioAsync>c__Iterator.extension = extension;
			<LoadBGMAudioAsync>c__Iterator.callback = callback;
			<LoadBGMAudioAsync>c__Iterator.<$>go = go;
			<LoadBGMAudioAsync>c__Iterator.<$>name = name;
			<LoadBGMAudioAsync>c__Iterator.<$>extension = extension;
			<LoadBGMAudioAsync>c__Iterator.<$>callback = callback;
			return <LoadBGMAudioAsync>c__Iterator;
		}

		public static object[] CallMethod(string module, string func, params object[] args)
		{
			LuaManager manager = AppFacade.Instance.GetManager<LuaManager>("LuaScriptMgr");
			if (manager == null)
			{
				return null;
			}
			return manager.CallFunction(module + "." + func, args);
		}

		private static int CheckRuntimeFile()
		{
			if (!Application.isEditor)
			{
				return 0;
			}
			return 0;
		}

		public static bool CheckEnvironment()
		{
			return true;
		}

		public static void LoadScene(string name)
		{
			PanelManager.ModifyDontDestroyPanel();
			SceneManager.LoadScene(name);
		}

		public static void LoadSceneViaPreloading(string name)
		{
			PreLoadingScene.next_scene = name;
			Util.LoadScene("PreloadingScene");
		}

		public static void OnSceneLoaded()
		{
			PreLoadingScene.DestroySelf();
		}

		public static string GetDeviceIdentifierString()
		{
			return Math.Abs(SystemInfo.deviceUniqueIdentifier.GetHashCode()).ToString();
		}

		public static void SetUILabelFont(UILabel label, string fontStr, int fontsize = 0, int overflow = 0)
		{
			if (label == null)
			{
				return;
			}
			GameObject gameObject = Util.LoadPrefab(fontStr);
			label.bitmapFont = gameObject.GetComponent<UIFont>();
			label.fontSize = label.defaultFontSize;
			label.overflowMethod = (UILabel.Overflow)overflow;
		}

		public static void SetUISprite(UISprite spr, string atlas, string name)
		{
			if (spr == null)
			{
				return;
			}
			spr.atlas = Util.loadAtlas(atlas);
			spr.spriteName = name;
			spr.MakePixelPerfect();
		}

		public static Vector3 WorldToUI(Vector3 point)
		{
			if (Camera.main == null)
			{
				return Vector3.zero;
			}
			Camera camera = UICamera.currentCamera;
			if (camera == null)
			{
				PanelManager manager = AppFacade.Instance.GetManager<PanelManager>("PanelManager");
				camera = manager.Parent.GetComponent<Camera>();
			}
			if (camera == null)
			{
				return Vector3.zero;
			}
			Vector3 position = Camera.main.WorldToScreenPoint(point);
			Vector3 result = camera.ScreenToWorldPoint(position);
			result.z = 0f;
			return result;
		}

		public static int GetEntityType(SceneEntity obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return (int)obj.entityType;
		}

		public static Vector3 Convert2RealPosition(int x, float height, int z)
		{
			GridGraph gridGraph = AstarPath.active.astarData.gridGraph;
			Int3 ob = gridGraph.GraphPointToWorld(x, z, height - gridGraph.center.y);
			return (Vector3)ob;
		}

		public static Vector3 Convert2RealPosition(int x, int z)
		{
			if (AstarPath.active == null)
			{
				return Vector3.zero;
			}
			GridGraph gridGraph = AstarPath.active.astarData.gridGraph;
			int num = z * gridGraph.Width + x;
			if (num >= gridGraph.nodes.Length || num < 0)
			{
				return Vector3.zero;
			}
			GridNode gridNode = gridGraph.nodes[num];
			if (gridNode != null && gridNode.Walkable)
			{
				return (Vector3)gridNode.position;
			}
			return Vector3.zero;
		}

		public static Vector3 Convert2MapPosition(float x, float z, float y)
		{
			NNInfo nearest = AstarPath.active.GetNearest(new Vector3(x, y, z));
			if (nearest.node != null && nearest.node.Walkable)
			{
				GridNode gridNode = (GridNode)nearest.node;
				return gridNode.Point2GraphSpace(y);
			}
			return Vector3.zero;
		}

		public static void OpenConsole()
		{
			GameObject gameObject = GameObject.Find("GameManager");
			if (gameObject != null)
			{
				DebugConsole component = gameObject.GetComponent<DebugConsole>();
				if (component != null)
				{
					component.enabled = true;
					component._isOpen = true;
				}
			}
		}

		public static int CalculateGridDirection(Vector3 dir)
		{
			if (dir.x == 0f && dir.z < 0f)
			{
				return 0;
			}
			if (dir.x > 0f && dir.z == 0f)
			{
				return 1;
			}
			if (dir.x == 0f && dir.z > 0f)
			{
				return 2;
			}
			if (dir.x < 0f && dir.z == 0f)
			{
				return 3;
			}
			if (dir.x > 0f && dir.z < 0f)
			{
				return 4;
			}
			if (dir.x > 0f && dir.z > 0f)
			{
				return 5;
			}
			if (dir.x < 0f && dir.z > 0f)
			{
				return 6;
			}
			if (dir.x < 0f && dir.z < 0f)
			{
				return 7;
			}
			return -1;
		}

		public static Transform Find(Transform parent, string childname)
		{
			Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == childname)
				{
					return componentsInChildren[i];
				}
			}
			return null;
		}

		public static Transform[] GetAllChildren(Transform root)
		{
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < root.childCount; i++)
			{
				Transform child = root.GetChild(i);
				list.Add(child);
				if (child.childCount > 0)
				{
					list.AddRange(Util.GetAllChildren(child));
				}
			}
			return list.ToArray();
		}

		public static void SetRenderQueue(Transform parent, int renderQ, float scaleFactor = 1f)
		{
			Renderer[] componentsInChildren = parent.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material.renderQueue = renderQ;
				componentsInChildren[i].gameObject.layer = LayerMask.NameToLayer("UIModel");
			}
			PrefabLoader[] componentsInChildren2 = parent.GetComponentsInChildren<PrefabLoader>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].renderQ = renderQ;
				componentsInChildren2[j].scaleFactor = scaleFactor;
			}
		}

		public static void ChangeToClipShader(Transform trans)
		{
			Renderer[] componentsInChildren = trans.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				int renderQueue = componentsInChildren[i].material.renderQueue;
				componentsInChildren[i].material.shader = Shader.Find("Custom/Avatar Texture Area Clip");
				componentsInChildren[i].material.renderQueue = renderQueue;
			}
			PrefabLoader[] componentsInChildren2 = trans.GetComponentsInChildren<PrefabLoader>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				componentsInChildren2[j].changeToClipShader = true;
			}
		}

		public static void ChangeToClipShader1(Transform trans)
		{
			Renderer[] componentsInChildren = trans.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				int renderQueue = componentsInChildren[i].material.renderQueue;
				componentsInChildren[i].material.shader = Shader.Find("Custom/Particle Texture Area Clip");
				componentsInChildren[i].material.renderQueue = renderQueue;
			}
		}

		public static bool IsDebugBuild()
		{
			return Debug.isDebugBuild;
		}

		public static string GetCurrentSceneName()
		{
			return SceneManager.GetActiveScene().name.ToLower();
		}

		public static Texture2D CaptureCamera(Camera camera, Rect rect)
		{
			RenderTexture renderTexture = new RenderTexture(1920, 1080, 0);
			camera.targetTexture = renderTexture;
			camera.Render();
			RenderTexture.active = renderTexture;
			Texture2D texture2D = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
			texture2D.ReadPixels(rect, 0, 0);
			texture2D.Apply();
			camera.targetTexture = null;
			RenderTexture.active = null;
			UnityEngine.Object.Destroy(renderTexture);
			return texture2D;
		}

		public static void AddAutoRecycleParticle(Transform parent, string particalPath)
		{
			GameObject gameObject = ObjectPool.instance.PushToPool(particalPath, 20, parent, 0f, 0f, 0f);
			if (gameObject == null)
			{
				return;
			}
			gameObject.transform.GetOrAddComponent<AutoRecycle>().Play();
		}

		public static void SetGameObjectLayer(Transform trans, int layer)
		{
			if (trans == null)
			{
				return;
			}
			Transform[] componentsInChildren = trans.GetComponentsInChildren<Transform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer = layer;
			}
		}

		public static void ResetShader(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			MeshRenderer[] componentsInChildren = go.transform.GetComponentsInChildren<MeshRenderer>();
			MeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				MeshRenderer meshRenderer = array[i];
				meshRenderer.sharedMaterial.shader = Shader.Find(meshRenderer.sharedMaterial.shader.name);
			}
			SkinnedMeshRenderer[] componentsInChildren2 = go.transform.GetComponentsInChildren<SkinnedMeshRenderer>();
			SkinnedMeshRenderer[] array2 = componentsInChildren2;
			for (int j = 0; j < array2.Length; j++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
				skinnedMeshRenderer.sharedMaterial.shader = Shader.Find(skinnedMeshRenderer.sharedMaterial.shader.name);
			}
			ParticleSystem[] componentsInChildren3 = go.transform.GetComponentsInChildren<ParticleSystem>();
			ParticleSystem component = go.transform.GetComponent<ParticleSystem>();
			if (component != null)
			{
				component.GetComponent<Renderer>().sharedMaterial.shader = Shader.Find(component.GetComponent<Renderer>().sharedMaterial.shader.name);
			}
			ParticleSystem[] array3 = componentsInChildren3;
			for (int k = 0; k < array3.Length; k++)
			{
				ParticleSystem particleSystem = array3[k];
				particleSystem.GetComponent<Renderer>().sharedMaterial.shader = Shader.Find(particleSystem.GetComponent<Renderer>().sharedMaterial.shader.name);
			}
		}
	}
}
