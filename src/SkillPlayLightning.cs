using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayLightning : SkillBase
{
	public GameObject lightning;

	public float deleteDelay;

	public override void StartSkill(float speed)
	{
		if (this.lightning == null)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		Skill component = base.gameObject.GetComponent<Skill>();
		if (!component || !component.startGo || component.targetGos.Count == 0)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		GameObject gameObject = component.startGo;
		for (int i = 0; i < component.targetGos.Count; i++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.lightning);
			AutoDestroy autoDestroy = gameObject2.AddComponent<AutoDestroy>();
			autoDestroy.lifetime = this.deleteDelay;
			LineRenderer[] componentsInChildren = gameObject2.GetComponentsInChildren<LineRenderer>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				componentsInChildren[j].SetVertexCount(2);
				componentsInChildren[j].SetPosition(0, gameObject.transform.position);
				componentsInChildren[j].SetPosition(1, component.targetGos[i].transform.position);
			}
			gameObject = component.targetGos[i];
		}
		UnityEngine.Object.Destroy(this);
	}
}
