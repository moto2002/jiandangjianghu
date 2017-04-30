using System;
using UnityEngine;

public class SkillView : MonoBehaviour
{
	public GameObject startGo;

	public GameObject targetGo;

	public GameObject skillGo;

	public GameObject buffGo;

	private void Start()
	{
	}

	[ContextMenu("start skill")]
	public void startSkill()
	{
	}

	[ContextMenu("start buff")]
	public void startBuff()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.buffGo);
		gameObject.GetComponent<Buff>().StartBuff(this.startGo);
	}
}
