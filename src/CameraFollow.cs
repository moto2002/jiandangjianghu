using System;
using ThirdParty;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public const float DISTANCE_DEAFULT = 18f;

	public static bool followEnable;

	public float distance = 16f;

	public float target_offsety = 2.2f;

	public Vector3 playerTarget;

	private Transform cameraTarget;

	private Camera mainCamera;

	private int _jumpMode;

	private Vector3 startPos = Vector3.zero;

	private float curVertSpeed;

	private float offsetY;

	private float gravity = 9.80665f;

	private bool reset;

	private bool startMove;

	public Transform cameraFollow
	{
		get;
		private set;
	}

	public int jumpMode
	{
		get
		{
			return this._jumpMode;
		}
		set
		{
			this._jumpMode = value;
			if (this._jumpMode == 0)
			{
				this.startPos = Vector3.zero;
				this.curVertSpeed = 0f;
				this.offsetY = 0f;
			}
			else if (this._jumpMode == 3)
			{
				this.curVertSpeed = 0f;
			}
		}
	}

	private void Awake()
	{
		this.distance = 18f;
		this.mainCamera = Singleton<RoleManager>.Instance.mainCamera;
		CameraFollow.followEnable = true;
		this.cameraFollow = this.mainCamera.transform;
		this.cameraTarget = base.transform;
		base.transform.position = Singleton<RoleManager>.Instance.mainRole.transform.position;
		this.playerTarget = new Vector3(base.transform.position.x, base.transform.position.y + this.target_offsety, base.transform.position.z);
		Quaternion rotation = Quaternion.Euler(30f, this.cameraFollow.eulerAngles.y, 0f);
		Vector3 vector = this.playerTarget;
		vector += rotation * Vector3.back * this.distance;
		this.cameraFollow.position = vector;
	}

	private void LateUpdate()
	{
		if (Singleton<RoleManager>.Instance.mainRole == null)
		{
			return;
		}
		if (!CameraFollow.followEnable)
		{
			return;
		}
		if (Singleton<RoleManager>.Instance.mainRole.roleState.IsInState(1024))
		{
			return;
		}
		base.transform.position = this.cameraTarget.position;
		base.transform.rotation = this.cameraTarget.rotation;
		this.playerTarget = new Vector3(base.transform.position.x, base.transform.position.y + this.target_offsety, base.transform.position.z);
		Quaternion rotation = Quaternion.Euler(30f, this.cameraFollow.eulerAngles.y, 0f);
		Vector3 vector = this.playerTarget + rotation * Vector3.back * this.distance;
		this.cameraFollow.position = Vector3.Lerp(this.cameraFollow.position, vector, 0.3f);
		Debug.DrawRay(this.playerTarget, vector - this.playerTarget, Color.red);
	}

	public void CameraTargetToSelf(bool toSelf)
	{
		if (toSelf)
		{
			if (this.cameraTarget != Singleton<RoleManager>.Instance.mainRole.transform)
			{
				this.cameraTarget = Singleton<RoleManager>.Instance.mainRole.transform;
			}
		}
		else if (this.cameraTarget != base.transform)
		{
			this.cameraTarget = base.transform;
		}
	}

	private void Update()
	{
		if (!Singleton<RoleManager>.Instance.mainRole)
		{
			return;
		}
		if (this.cameraTarget == Singleton<RoleManager>.Instance.mainRole)
		{
			return;
		}
		SceneEntity mainRole = Singleton<RoleManager>.Instance.mainRole;
		if (this.cameraTarget.position != mainRole.transform.position)
		{
			float num = Vector3.Distance(this.cameraTarget.position, mainRole.transform.position);
			if (num > 10f)
			{
				this.CameraTargetToSelf(true);
				return;
			}
			this.reset = (!mainRole.move.InMoving() && mainRole.move.jumpMode == 0);
			if (this.jumpMode != 0 && this.reset)
			{
				this.jumpMode = 0;
			}
			if (num > 0.8f || ((this.reset || this.jumpMode != 0) && this.startMove))
			{
				if (!this.startMove)
				{
					this.startMove = true;
				}
				this.cameraTarget.rotation = mainRole.transform.rotation;
				if (this.jumpMode == 0)
				{
					float num2 = mainRole.move.speed * mainRole.move.speedFactor;
					if (num > 1.5f)
					{
						num2 *= 1.5f;
					}
					float maxDistanceDelta = num2 * Time.deltaTime;
					Vector3 position = Vector3.MoveTowards(this.cameraTarget.transform.position, mainRole.transform.position, maxDistanceDelta);
					this.cameraTarget.position = position;
				}
				else
				{
					JumpBase jumpSystem = mainRole.move.jumpSystem;
					if (this.startPos == Vector3.zero)
					{
						if (this.cameraTarget.position.y - mainRole.transform.position.y > 0.1f)
						{
							this.startPos = mainRole.transform.position;
						}
						else
						{
							this.startPos = this.cameraTarget.position;
						}
						this.curVertSpeed = mainRole.move.jumpSystem.startVertSpeed;
					}
					else
					{
						Vector3 vector = this.cameraTarget.forward * jumpSystem.offsetX;
						if (this.jumpMode != 2)
						{
							if (this.jumpMode != 3 || this.cameraTarget.position.y >= mainRole.transform.position.y + 0.3f)
							{
								this.curVertSpeed -= this.gravity * Time.deltaTime;
								this.offsetY += this.curVertSpeed * Time.deltaTime;
							}
						}
						this.cameraTarget.position = new Vector3(this.startPos.x + vector.x, this.startPos.y + this.offsetY, this.startPos.z + vector.z);
					}
				}
			}
		}
		else
		{
			if (this.startPos != Vector3.zero)
			{
				this.startPos = Vector3.zero;
			}
			if (this.reset)
			{
				this.reset = false;
			}
			if (this.startMove)
			{
				this.startMove = false;
			}
		}
	}
}
