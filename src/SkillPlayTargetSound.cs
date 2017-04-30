using LuaFramework;
using System;
using UnityEngine;

public class SkillPlayTargetSound : SkillBase
{
	public float delay;

	public string[] sounds;

	public bool loop;

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(0f, 255f)]
	public int priority = 128;

	[Range(0f, 3f)]
	public float minPitch = 0.6f;

	[Range(0f, 3f)]
	public float maxPitch = 1.2f;

	public string extension = "ogg";

	private void ApplyTargetEvent()
	{
		if (this.sounds == null)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component == null || component.startGo == null)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		SceneEntity component2 = component.startGo.GetComponent<SceneEntity>();
		if (component2 == null || component2.entityType != RoleManager.EntityType.EntityType_Self)
		{
			UnityEngine.Object.Destroy(this);
			return;
		}
		for (int i = 0; i < component.targetGos.Count; i++)
		{
			if (!(component.targetGos[i] == null))
			{
				if (i > 1)
				{
					break;
				}
				this.AddSound(component.targetGos[i]);
			}
		}
		UnityEngine.Object.Destroy(this);
	}

	private void AddSound(GameObject target)
	{
		if (this.sounds.Length <= 0)
		{
			return;
		}
		int num = UnityEngine.Random.Range(0, this.sounds.Length);
		SoundManager manager = AppFacade.Instance.GetManager<SoundManager>("SoundManager");
		string name = this.sounds[(num != this.sounds.Length) ? num : (num - 1)];
		if (this.minPitch > this.maxPitch)
		{
			this.maxPitch = this.minPitch;
		}
		manager.PlaySkillSound(name, this.volume, this.delay, target.transform.position, this.priority, this.loop, this.minPitch, this.maxPitch, this.extension);
	}
}
