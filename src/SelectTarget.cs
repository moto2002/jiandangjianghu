using System;
using UnityEngine;

public class SelectTarget : MonoBehaviour
{
	public SceneEntity _self;

	public SceneEntity _selectObj
	{
		get;
		private set;
	}

	public SceneEntity attackTarget
	{
		get;
		private set;
	}

	private void Start()
	{
	}

	private void OnDisable()
	{
		this.clear();
	}

	public void OnSelected(SceneEntity obj)
	{
		if (obj == null)
		{
			this.CancelSelect();
			return;
		}
		if (!obj.selectable)
		{
			Debug.LogError("id: " + obj.id + "can not be clicked!");
			return;
		}
		this.OnTargetSelected(obj);
	}

	public void OnTargetSelected(SceneEntity obj)
	{
		if (this._selectObj != null && this._selectObj.id != obj.id)
		{
			this.CancelSelect();
		}
		this._selectObj = obj;
		if (obj.canAttack && obj.hp > 0)
		{
			this.attackTarget = obj;
			if (this._self.entityType == RoleManager.EntityType.EntityType_Self && obj.selectEffectGo != null)
			{
				obj.selectEffectGo.SetActive(true);
			}
		}
		else if (obj.entityType == RoleManager.EntityType.EntityType_Npc || obj.entityType == RoleManager.EntityType.EntityType_XunLuo)
		{
			obj.transform.LookAt(base.transform);
			obj.DelayRotateBackAfterSelected();
		}
	}

	public void CancelSelect()
	{
		if (this._selectObj != null && this._selectObj.selectEffectGo != null)
		{
			this._selectObj.selectEffectGo.SetActive(false);
		}
		this.clear();
	}

	private void clear()
	{
		this._selectObj = null;
		this.attackTarget = null;
	}
}
