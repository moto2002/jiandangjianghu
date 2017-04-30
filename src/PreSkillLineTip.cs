using System;
using UnityEngine;

public class PreSkillLineTip : MonoBehaviour
{
	public GameObject line;

	private float org_length = 10f;

	private float org_width = 1f;

	public void SetPreSkillLineTip(float len, float width)
	{
		this.line.transform.localScale = new Vector3(width / this.org_width, len / this.org_length, 1f);
	}
}
