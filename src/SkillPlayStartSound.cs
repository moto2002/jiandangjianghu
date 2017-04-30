using LuaFramework;
using System;
using ThirdParty;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillPlayStartSound : SkillBase
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

	private GameObject audioGo;

	private void AddSound()
	{
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component == null || component.startGo == null || Singleton<RoleManager>.Instance.mainRole == null)
		{
			return;
		}
		SceneEntity component2 = component.startGo.GetComponent<SceneEntity>();
		if (component2 == null)
		{
			return;
		}
		if ((((component2.entityType == RoleManager.EntityType.EntityType_Lingqi || component2.entityType == RoleManager.EntityType.EntityType_Partner) && component2.ownerId == Singleton<RoleManager>.Instance.mainRole.id) || component2.entityType == RoleManager.EntityType.EntityType_Self) && this.sounds.Length > 0)
		{
			SoundManager manager = AppFacade.Instance.GetManager<SoundManager>("SoundManager");
			int num = UnityEngine.Random.Range(0, this.sounds.Length);
			string name = this.sounds[(num != this.sounds.Length) ? num : (num - 1)];
			if (this.minPitch > this.maxPitch)
			{
				this.maxPitch = this.minPitch;
			}
			manager.PlaySkillSound(name, this.volume, this.delay, component.startGo.transform.position, this.priority, this.loop, this.minPitch, this.maxPitch, this.extension);
		}
	}

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
		this.AddSound();
		UnityEngine.Object.Destroy(this);
	}
}
