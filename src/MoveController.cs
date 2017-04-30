using LuaFramework;
using System;
using ThirdParty;
using UnityEngine;

[RequireComponent(typeof(SceneEntity))]
public class MoveController : MonoBehaviour
{
	public enum MoveType
	{
		None,
		Joystick,
		Keyboard
	}

	private readonly float TALK_DISTANCE = 2f;

	public int PROTO_INTERVAL = 4;

	public SceneEntity _self;

	private Camera mainCamera;

	public GameObject clickParticle;

	private bool bUpState;

	private bool bDownState;

	private bool bLeftState;

	private bool bRightState;

	public bool canMove
	{
		get;
		set;
	}

	public MoveController.MoveType moveType
	{
		get;
		set;
	}

	private void Awake()
	{
		this.canMove = true;
	}

	private void Start()
	{
		this.mainCamera = Singleton<RoleManager>.Instance.mainCamera;
	}

	private void OnEnable()
	{
		if (this.mainCamera == null)
		{
			this.mainCamera = Singleton<RoleManager>.Instance.mainCamera;
		}
	}

	private void OnDisable()
	{
		this.mainCamera = null;
	}

	private void Update()
	{
		if (this._self.hp <= 0)
		{
			return;
		}
		if (Input.GetMouseButtonDown(0))
		{
			if (!UICamera.isOverUI && this._self.move.jumpMode == 0)
			{
				Singleton<WorldPathfinding>.Instance.StopWorldPathfinding();
				this.OnShortClick(Input.mousePosition);
			}
		}
		else if (this.moveType != MoveController.MoveType.Joystick)
		{
			this.MoveByKeyboard();
		}
	}

	private void OnShortClick(Vector3 curPos)
	{
		if (Singleton<RoleManager>.Instance.sceneType == 5)
		{
			return;
		}
		Ray ray = this.mainCamera.ScreenPointToRay(curPos);
		RaycastHit[] array = Physics.RaycastAll(ray, 500f, LayerMask.GetMask(new string[]
		{
			"SceneEntity"
		}));
		for (int i = 0; i < array.Length; i++)
		{
			Transform transform = array[i].transform;
			SceneEntity component = transform.GetComponent<SceneEntity>();
			if (component != null && component.selectable && component.model.activeSelf)
			{
				if (component.entityType == RoleManager.EntityType.EntityType_Role)
				{
					object[] array2 = Util.CallMethod("FIGHTMGR", "ChangeTargetBloodColor", new object[]
					{
						component.pkInfo,
						component.transform.position.x,
						component.transform.position.y,
						component.transform.position.z
					});
					if (array2 == null || array2.Length == 0)
					{
						Debug.LogError("角色获取pk模式信息错误");
						return;
					}
					if (Convert.ToBoolean(array2[0]))
					{
						Util.CallMethod("HEROSKILLMGR", "SetHeroAttackTarget", new object[]
						{
							component,
							1
						});
					}
					else
					{
						Util.CallMethod("HEROSKILLMGR", "CancelTarget", new object[0]);
					}
				}
				else if (component.entityType == RoleManager.EntityType.EntityType_Monster)
				{
					Util.CallMethod("HEROSKILLMGR", "SetHeroAttackTarget", new object[]
					{
						component,
						1
					});
				}
				else
				{
					Util.CallMethod("HEROSKILLMGR", "CancelTarget", new object[0]);
				}
				if (array[i].collider.CompareTag("Npc"))
				{
					this.TalkToNpc(component.id, component.char_id, transform.position);
				}
				if (!this._self.roleState.IsInState(64))
				{
					this._self.roleState.RemoveState(16384);
				}
				return;
			}
		}
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit, 100f, LayerMask.GetMask(new string[]
		{
			"Ground"
		})) && raycastHit.transform)
		{
			this.ShowClickEffect(raycastHit.point);
			if (Vector3.Distance(raycastHit.point, this._self.transform.position) > this._self.move.radius)
			{
				this._self.runToTarget.Target(raycastHit.point, 0.1f, null, 0);
				this._self.roleState.RemoveState(16);
				if (!this._self.roleState.IsInState(64))
				{
					this._self.roleState.RemoveState(16384);
				}
			}
		}
	}

	private void ShowClickEffect(Vector3 pos)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.clickParticle);
		gameObject.AddComponent<AutoDestroy>().lifetime = 0.5f;
		gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);
	}

	public void MoveByJoystick(float horizontal, float vertical, bool pressed)
	{
		if (Singleton<RoleManager>.Instance.mainCamera == null)
		{
			return;
		}
		if (!pressed)
		{
			if (this.moveType == MoveController.MoveType.Joystick)
			{
				this.moveType = MoveController.MoveType.None;
				this._self.move.StopPath();
				PositionSync.SyncSelfPosition();
			}
			return;
		}
		Vector3 point = new Vector3(horizontal, 0f, vertical);
		Vector3 forward = Singleton<RoleManager>.Instance.mainCamera.transform.forward;
		forward.y = 0f;
		Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, forward);
		Vector3 vecDir = rotation * point;
		if (!vecDir.Equals(Vector3.zero))
		{
			this.moveType = MoveController.MoveType.Joystick;
			this._self.move.WalkOnDirection(vecDir);
		}
	}

	public void TalkToNpc(string id, int npcNo, Vector3 npcPos)
	{
		this._self.move.StopPath();
		this._self.runToTarget.Target(npcPos, this.TALK_DISTANCE, delegate
		{
			object[] array = Util.CallMethod("COMMONCTRL", "NpcClick", new object[]
			{
				id,
				npcNo
			});
			if (Convert.ToBoolean(array[0]))
			{
				if (RoleManager.sceneEntities.ContainsKey(id))
				{
					this._self.selectTarget.OnSelected(RoleManager.sceneEntities[id]);
				}
				else
				{
					SceneEntity xunLuoNpc = Singleton<RoleManager>.Instance.GetXunLuoNpc(npcNo);
					if (xunLuoNpc != null)
					{
						this._self.selectTarget.OnSelected(xunLuoNpc);
					}
				}
			}
		}, 0);
	}

	public void MoveByKeyboard()
	{
		if (UICamera.inputHasFocus)
		{
			return;
		}
		this.bUpState = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
		this.bDownState = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
		this.bLeftState = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow));
		this.bRightState = (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
		if (!this.bUpState && !this.bDownState && !this.bLeftState && !this.bRightState)
		{
			if (this.moveType == MoveController.MoveType.Keyboard)
			{
				this.moveType = MoveController.MoveType.None;
				this._self.move.StopPath();
				PositionSync.SyncSelfPosition();
			}
			return;
		}
		if (Camera.main == null)
		{
			return;
		}
		this.moveType = MoveController.MoveType.Keyboard;
		Vector3 v = Camera.main.transform.rotation * Vector3.forward;
		v.y = 0f;
		v.Normalize();
		float y = 0f;
		if (this.bUpState)
		{
			if (this.bLeftState)
			{
				y = -45f;
			}
			else if (this.bRightState)
			{
				y = 45f;
			}
		}
		else if (this.bDownState)
		{
			if (this.bLeftState)
			{
				y = -135f;
			}
			else if (this.bRightState)
			{
				y = 135f;
			}
			else
			{
				y = 180f;
			}
		}
		else if (this.bLeftState)
		{
			y = -90f;
		}
		else if (this.bRightState)
		{
			y = 90f;
		}
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(new Vector3(0f, y, 0f)), Vector3.one);
		this._self.move.WalkOnDirection(matrix4x.MultiplyVector(v));
	}
}
