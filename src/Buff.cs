using System;
using UnityEngine;

public class Buff : MonoBehaviour
{
	public GameObject particleGo;

	public string mount;

	public AudioClip sound;

	public float soundDelay;

	[Range(0f, 1f)]
	public float volume = 1f;

	public bool loop;

	public GameObject StartBuff(GameObject target)
	{
		if (!target)
		{
			return null;
		}
		Transform transform = SkillBase.Find(target.transform, this.mount);
		if (!transform)
		{
			transform = target.transform;
		}
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.particleGo);
		if (gameObject)
		{
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = Vector2.zero;
			gameObject.transform.localScale = Vector3.one;
			this.AddSound(gameObject);
		}
		UnityEngine.Object.Destroy(base.gameObject);
		return gameObject;
	}

	private void AddSound(GameObject mount)
	{
		AudioSource orAddComponent = mount.transform.GetOrAddComponent<AudioSource>();
		orAddComponent.clip = this.sound;
		orAddComponent.playOnAwake = false;
		orAddComponent.loop = this.loop;
		orAddComponent.bypassEffects = true;
		orAddComponent.PlayDelayed(this.soundDelay);
	}
}
