using LuaFramework;
using LuaInterface;
using System;
using System.Collections.Generic;
using ThirdParty;
using UnityEngine;

public class PlotJumpLogic : MonoBehaviour
{
	private SceneEntity _self;

	private List<Vector3> targetPosition;

	private List<float> startVerSpeed;

	private List<float> vertAccSpeed;

	private List<int> actionIndex;

	private int curIndex;

	private PlotJump plotJumpSystem;

	private JumpBase normalJumpSystem;

	private int gateNo;

	private int endMapId;

	public Vector3 finalPosition
	{
		get
		{
			if (this.targetPosition != null && this.targetPosition.Count > 0)
			{
				return this.targetPosition[this.targetPosition.Count - 1];
			}
			return Vector3.zero;
		}
	}

	private void Awake()
	{
		this.targetPosition = new List<Vector3>();
		this.startVerSpeed = new List<float>();
		this.vertAccSpeed = new List<float>();
		this.actionIndex = new List<int>();
		this._self = base.GetComponent<SceneEntity>();
	}

	public void StartPlotJump(int doorNo, int endMap, Action onJumpFinished)
	{
		if (this.curIndex == 0)
		{
			this.gateNo = doorNo;
			this.endMapId = endMap;
			this.InitJumpData(doorNo);
			JumpBase[] components = this._self.GetComponents<JumpBase>();
			for (int i = 0; i < components.Length; i++)
			{
				if (components[i] is PlotJump)
				{
					PlotJump x = (PlotJump)components[i];
					if (x != null)
					{
						this.plotJumpSystem = x;
						this.plotJumpSystem.enabled = true;
					}
				}
				else
				{
					this.normalJumpSystem = components[i];
					this.normalJumpSystem.enabled = false;
				}
			}
		}
		else if (this.curIndex == this.targetPosition.Count)
		{
			this.plotJumpSystem.PlotJumpClear();
			this.plotJumpSystem.enabled = false;
			this.normalJumpSystem.enabled = true;
			if (onJumpFinished != null)
			{
				onJumpFinished();
			}
			onJumpFinished = null;
			if (this._self.entityType == RoleManager.EntityType.EntityType_Self)
			{
				Singleton<RoleManager>.Instance.cf.CameraTargetToSelf(false);
			}
			this.SendPlotJumpOver();
			UnityEngine.Object.Destroy(this);
			return;
		}
		if (this.plotJumpSystem != null)
		{
			this._self.move.StopPath();
			this.plotJumpSystem.StartPlotJump(this.targetPosition[this.curIndex], this.startVerSpeed[this.curIndex], this.vertAccSpeed[this.curIndex], this.actionIndex[this.curIndex], delegate
			{
				this.curIndex++;
				this.StartPlotJump(doorNo, endMap, onJumpFinished);
			});
		}
	}

	private void InitJumpData(int doorNo)
	{
		this.targetPosition.Clear();
		this.startVerSpeed.Clear();
		this.vertAccSpeed.Clear();
		this.actionIndex.Clear();
		LuaManager manager = AppFacade.Instance.GetManager<LuaManager>("LuaScriptMgr");
		string filename = string.Format("PlotJump/{0}_{1}", Singleton<RoleManager>.Instance.curSceneNo, doorNo);
		object[] array = manager.DoFile(filename);
		LuaTable luaTable = (LuaTable)array[0];
		if (luaTable != null)
		{
			LuaTable luaTable2 = (LuaTable)luaTable["targetPosition"];
			if (luaTable2 != null)
			{
				for (int i = 1; i <= luaTable2.Length; i++)
				{
					LuaTable luaTable3 = (LuaTable)luaTable2[i];
					if (luaTable3.Length == 3)
					{
						this.targetPosition.Add(new Vector3(Convert.ToSingle(luaTable3[1]), Convert.ToSingle(luaTable3[2]), Convert.ToSingle(luaTable3[3])));
					}
					else
					{
						Debug.LogError("剧情跳lua表格坐标填写错误");
					}
				}
			}
			LuaTable luaTable4 = (LuaTable)luaTable["startVertSpeed"];
			if (luaTable4 != null)
			{
				for (int j = 1; j <= luaTable4.Length; j++)
				{
					this.startVerSpeed.Add(Convert.ToSingle(luaTable4[j]));
				}
			}
			LuaTable luaTable5 = (LuaTable)luaTable["vertAccSpeed"];
			if (luaTable5 != null)
			{
				for (int k = 1; k <= luaTable5.Length; k++)
				{
					this.vertAccSpeed.Add(Convert.ToSingle(luaTable5[k]));
				}
			}
			LuaTable luaTable6 = (LuaTable)luaTable["action"];
			if (luaTable6 != null)
			{
				for (int l = 1; l <= luaTable6.Length; l++)
				{
					this.actionIndex.Add(Convert.ToInt32(luaTable6[l]));
				}
			}
			luaTable.Dispose();
		}
	}

	public void SendPlotJumpOver()
	{
		if (this._self.entityType != RoleManager.EntityType.EntityType_Self)
		{
			return;
		}
		List<object> list = new List<object>();
		list.Add(this.gateNo);
		list.Add(this.endMapId);
		list.Add(2);
		Vector3 vector = Util.Convert2MapPosition(this._self.transform.position.x, this._self.transform.position.z, this._self.transform.position.y);
		list.Add(vector.x);
		list.Add(vector.z);
		list.Add(this._self.transform.position.x);
		list.Add(this._self.transform.position.y);
		list.Add(this._self.transform.position.z);
		Util.CallMethod("Network", "SendPlotJump", new object[]
		{
			list
		});
	}
}
