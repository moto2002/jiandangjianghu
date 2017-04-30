using LuaFramework;
using System;
using UnityEngine;

public class HeadBloodScript : MonoBehaviour
{
	public UISprite bloodSpr;

	public SceneEntity self
	{
		get;
		set;
	}

	private void Awake()
	{
	}

	private void Start()
	{
		this.SetHpStyle();
	}

	private void Update()
	{
	}

	private void SetHpStyle()
	{
		if (this.self == null)
		{
			return;
		}
		if (this.self.entityType == RoleManager.EntityType.EntityType_Self)
		{
			this.bloodSpr.spriteName = "ui_self_blood";
		}
		else if (this.self.entityType == RoleManager.EntityType.EntityType_Role)
		{
			object[] array = Util.CallMethod("FIGHTMGR", "ChangeTargetBloodColor", new object[]
			{
				this.self.pkInfo,
				this.self.transform.position.x,
				this.self.transform.position.y,
				this.self.transform.position.z
			});
			if (array == null || array.Length == 0)
			{
				Debug.LogError("角色获取pk模式信息错误");
				return;
			}
			if (Convert.ToBoolean(array[0]))
			{
				this.bloodSpr.spriteName = "ui_can_attack_blood";
			}
			else
			{
				this.bloodSpr.spriteName = "ui_donot_attack_blood";
			}
		}
	}

	public void updateHp(float amount)
	{
		if (this.bloodSpr != null)
		{
			this.bloodSpr.fillAmount = amount;
		}
	}

	public void UpdateMood()
	{
		this.SetHpStyle();
	}
}
