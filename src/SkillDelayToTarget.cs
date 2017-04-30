using LuaFramework;
using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillDelayToTarget : SendTargetEventBase
{
	public float delay;

	private float TIME_INTVERAL = 0.3f;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
	}

	private void Update()
	{
		this.delay -= Time.deltaTime;
		if (this.delay <= 0f)
		{
			this.StartTargetEvent();
		}
	}

	private void StartTargetEvent()
	{
		Skill component = base.gameObject.GetComponent<Skill>();
		if (!component.needFeedback)
		{
			if (this.sendTargetEvent)
			{
				base.gameObject.SendMessage("ApplyTargetEvent", null, SendMessageOptions.DontRequireReceiver);
			}
			UnityEngine.Object.Destroy(this);
			return;
		}
		if (component.startGo.name.IndexOf("Self") < 0)
		{
			return;
		}
		int num = Convert.ToInt32(component.name.Split(new char[]
		{
			'_'
		})[0]);
		if (component.targetGo == null)
		{
			Util.CallMethod("HEROSKILLMGR", "SendSkillPb", new object[]
			{
				num,
				component.startGo.transform.position,
				component.targetPos,
				0,
				component.timestamp
			});
		}
		else
		{
			SceneEntity component2 = component.targetGo.GetComponent<SceneEntity>();
			if (component2 == null)
			{
				Util.CallMethod("HEROSKILLMGR", "SendSkillPb", new object[]
				{
					num,
					component.startGo.transform.position,
					component.targetPos,
					0,
					component.timestamp
				});
			}
			else
			{
				Util.CallMethod("HEROSKILLMGR", "SendSkillPb", new object[]
				{
					num,
					component.startGo.transform.position,
					component.targetGo.transform.position,
					component2.id,
					component.timestamp
				});
			}
		}
		this.delay += this.TIME_INTVERAL;
	}
}
