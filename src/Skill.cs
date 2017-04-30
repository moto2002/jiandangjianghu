using System;
using System.Collections.Generic;
using UnityEngine;

public class Skill : SkillBase
{
	public GameObject startGo;

	public GameObject targetGo;

	public List<GameObject> targetGos = new List<GameObject>();

	public Action<bool> onDestory;

	public Vector3 targetPos
	{
		get;
		set;
	}

	public bool needFeedback
	{
		get;
		set;
	}

	public bool needDestoryCastSkill
	{
		get;
		set;
	}

	private void FixedUpdate()
	{
		if (base.GetComponents<SkillBase>().Length == 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			if (this.onDestory != null)
			{
				this.onDestory(this.needDestoryCastSkill);
			}
		}
	}
}
