using LuaFramework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CastSkill : MonoBehaviour
{
	public static int SKILL_SINGLE = 100;

	public static int SKILL_AOE = 101;

	private static string SKILL_ACT = "ACT";

	private static string SKILL_HIT = "HIT";

	private Dictionary<string, GameObject> curSkills = new Dictionary<string, GameObject>();

	private void Start()
	{
	}

	private void OnDisable()
	{
		this.ClearAllSkill();
	}

	public GameObject StartSkill(int skillId, int skillType, int stamp, string folderName, string prefabName, string target_id, Vector3 targetPos, bool needneedFeedback, string[] targetIds, bool isAct)
	{
		List<string> list = new List<string>(this.curSkills.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].IndexOf(skillId.ToString()) >= 0)
			{
				if (list[i].IndexOf(stamp.ToString()) < 0 || (stamp == 0 && this.curSkills[list[i]] != null && this.curSkills[list[i]].name.IndexOf(CastSkill.SKILL_HIT) >= 0))
				{
					UnityEngine.Object.Destroy(this.curSkills[list[i]]);
					this.curSkills.Remove(list[i]);
				}
			}
		}
		SceneEntity component = base.gameObject.GetComponent<SceneEntity>();
		if (component == null)
		{
			return null;
		}
		string key = string.Format("{0}_{1}", skillId, stamp);
		GameObject gameObject;
		if (this.curSkills.ContainsKey(key))
		{
			gameObject = this.curSkills[key];
			gameObject.name = string.Format("{0}_{1}", key, (!isAct) ? CastSkill.SKILL_HIT : CastSkill.SKILL_ACT);
		}
		else
		{
			GameObject gameObject2;
			if (component.entityType == RoleManager.EntityType.EntityType_Self || component.entityType == RoleManager.EntityType.EntityType_Role)
			{
				gameObject2 = Util.LoadPrefab(string.Format("Prefab/skill/common/{0}{1}", (component.sex != 1) ? "female/f" : "male/m", (!string.IsNullOrEmpty(prefabName)) ? prefabName : skillId.ToString()));
			}
			else
			{
				gameObject2 = Util.LoadPrefab(string.Format("Prefab/skill/common/{0}/{1}", folderName, (!string.IsNullOrEmpty(prefabName)) ? prefabName : skillId.ToString()));
			}
			if (gameObject2 == null)
			{
				Debug.Log("找不到prefab" + skillId);
				return null;
			}
			gameObject = UnityEngine.Object.Instantiate<GameObject>(gameObject2);
			gameObject.name = string.Format("{0}_{1}", key, (!isAct) ? CastSkill.SKILL_HIT : CastSkill.SKILL_ACT);
			this.curSkills.Add(key, gameObject);
		}
		if (gameObject == null)
		{
			return null;
		}
		Skill component2 = gameObject.GetComponent<Skill>();
		component2.timestamp = stamp;
		component2.startGo = base.gameObject;
		component2.needDestoryCastSkill = (base.gameObject.GetComponent<SceneEntity>() == null);
		if (RoleManager.sceneEntities.ContainsKey(target_id))
		{
			component2.targetGo = RoleManager.sceneEntities[target_id].gameObject;
		}
		component2.targetPos = targetPos;
		if (component2.onDestory == null)
		{
			component2.onDestory = delegate(bool needDestory)
			{
				this.DestroySkill(key);
				if (needDestory)
				{
					UnityEngine.Object.Destroy(this.gameObject);
				}
			};
		}
		if (targetIds != null)
		{
			for (int j = 0; j < targetIds.Length; j++)
			{
				if (RoleManager.sceneEntities.ContainsKey(targetIds[j]))
				{
					component2.targetGos.Add(RoleManager.sceneEntities[targetIds[j]].gameObject);
					RoleManager.sceneEntities[targetIds[j]].attacker = component;
				}
			}
		}
		component2.needFeedback = needneedFeedback;
		return gameObject;
	}

	public void SetSkillInfo(GameObject skill, int skillType, bool showEff)
	{
		int num = 0;
		SendTargetEventBase[] components = skill.GetComponents<SendTargetEventBase>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i].sendTargetEvent)
			{
				num++;
			}
			if (num >= 2)
			{
				Debug.LogError("技能(" + skill + ")有多个发送到达目标的组件");
				return;
			}
		}
		SkillBase[] components2 = skill.GetComponents<SkillBase>();
		for (int j = 0; j < components2.Length; j++)
		{
			components2[j].enableParticle = showEff;
		}
		if (skillType == 1)
		{
			skill.SendMessage("ApplyTargetEvent", null, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			if (skillType == 0)
			{
				SendTargetEventBase[] components3 = skill.GetComponents<SendTargetEventBase>();
				for (int k = 0; k < components3.Length; k++)
				{
					components3[k].sendTargetEvent = false;
				}
			}
			for (int l = 0; l < components2.Length; l++)
			{
				components2[l].StartSkill(1f);
			}
		}
		skill.transform.parent = base.transform;
		skill.transform.localPosition = Vector3.zero;
	}

	public void DestroySkill(string key)
	{
		if (this.curSkills.ContainsKey(key))
		{
			this.curSkills.Remove(key);
		}
	}

	public void ClearAllSkill()
	{
		List<GameObject> list = new List<GameObject>(this.curSkills.Values);
		for (int i = 0; i < list.Count; i++)
		{
			UnityEngine.Object.Destroy(list[i]);
		}
		this.curSkills.Clear();
	}
}
