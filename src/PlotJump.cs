using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlotJump : JumpBase
{
	public List<GameObject> targets = new List<GameObject>();

	private Vector3 targetPosition;

	private float vertAcceleration;

	private Action onJumpFinished;

	public override void UpdateJump(bool isGrounded, Vector3 finalPosition, bool shakeCamera = false)
	{
		if (!isGrounded)
		{
			Vector3 zero = Vector3.zero;
			this.curTime += Time.deltaTime;
			if (base.jumpMode == 1 || base.jumpMode == 3)
			{
				base.curVertSpeed -= this.vertAcceleration * Time.deltaTime;
				this.offsetY += base.curVertSpeed * Time.deltaTime;
				this.offsetX += base.startHorizSpeed * Time.deltaTime;
				Vector3 vector = this._self.transform.forward * this.offsetX;
				zero = new Vector3(base.startPos.x + vector.x, base.startPos.y + this.offsetY, base.startPos.z + vector.z);
				if (base.curVertSpeed <= 0f && base.jumpMode == 1)
				{
					base.jumpMode = 3;
					this._self.roleAction.SetRoleFall(this.curJumpAction);
				}
				this._self.transform.position = zero;
			}
			if (this.curTime > this.MAX_JUMP_PROTECTTIME && base.jumpMode != 0)
			{
				this.FinishJump();
				Debug.LogWarning("超出跳跃最大时间限制");
				return;
			}
		}
		else
		{
			this.JumpClear();
			this._self.transform.position = finalPosition;
			this._self.roleAction.SetRoleIdle();
			base.StartCoroutine(this.WaitForJumpFinished());
		}
	}

	[DebuggerHidden]
	private IEnumerator WaitForJumpFinished()
	{
		PlotJump.<WaitForJumpFinished>c__Iterator3F <WaitForJumpFinished>c__Iterator3F = new PlotJump.<WaitForJumpFinished>c__Iterator3F();
		<WaitForJumpFinished>c__Iterator3F.<>f__this = this;
		return <WaitForJumpFinished>c__Iterator3F;
	}

	public void StartPlotJump(Vector3 target, float vertSpeed, float vertAccSpeed, int actionIndex, Action onJumpFinished)
	{
		this.JumpClear();
		Vector3 worldPosition = new Vector3(target.x, this._self.transform.position.y, target.z);
		this._self.transform.LookAt(worldPosition);
		this.targetPosition = target;
		base.startVertSpeed = vertSpeed;
		base.curVertSpeed = vertSpeed;
		this.vertAcceleration = ((vertAccSpeed > 0f) ? vertAccSpeed : this.gravity);
		base.startPos = this._self.transform.position;
		base.startHorizSpeed = this.CalculateHorizSpeed(target, vertSpeed, this.vertAcceleration);
		this.onJumpFinished = onJumpFinished;
		base.jumpMode = 1;
		this.curJumpAction = this._self.roleAction.SetRoleJump(actionIndex);
	}

	private float CalculateHorizSpeed(Vector3 targetPosition, float vertSpeed, float vertAccSpeed)
	{
		float num = vertSpeed * vertSpeed * 0.5f / vertAccSpeed;
		float num2 = vertSpeed / vertAccSpeed;
		float num3 = Mathf.Sqrt((num - (targetPosition.y - this._self.transform.position.y)) * 2f / vertAccSpeed);
		Vector3 a = new Vector3(targetPosition.x, this._self.transform.position.y, targetPosition.z);
		float magnitude = (a - this._self.transform.position).magnitude;
		return magnitude / (num2 + num3);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (base.jumpMode != 0 && this.targetPosition != Vector3.zero)
		{
			if (collider.gameObject.layer == LayerMask.NameToLayer("Ground") && base.jumpMode == 3)
			{
				this.UpdateJump(true, this.targetPosition, false);
			}
			else if (collider.gameObject.CompareTag("AutoJumpTarget"))
			{
				if (!this.targets.Contains(collider.gameObject))
				{
					this.UpdateJump(true, this.targetPosition, false);
					this.targets.Add(collider.gameObject);
				}
			}
			else if (collider.gameObject.CompareTag("JumpProtect"))
			{
				this.FinishJump();
			}
		}
	}

	private void FinishJump()
	{
		PlotJumpLogic component = base.GetComponent<PlotJumpLogic>();
		this.UpdateJump(true, component.finalPosition, false);
		component.SendPlotJumpOver();
	}

	protected override void JumpClear()
	{
		base.startPos = Vector3.zero;
		base.curVertSpeed = 0f;
		base.startVertSpeed = 0f;
		this.offsetX = 0f;
		this.offsetY = 0f;
		base.startHorizSpeed = 0f;
		base.jumpMode = 4;
		this.targetPosition = Vector3.zero;
		this.vertAcceleration = this.gravity;
	}

	public void PlotJumpClear()
	{
		this.curTime = 0f;
		base.jumpMode = 0;
		this.targets.Clear();
		this.onJumpFinished = null;
	}
}
