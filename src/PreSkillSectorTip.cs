using System;
using UnityEngine;

public class PreSkillSectorTip : MonoBehaviour
{
	public Transform sectorTrans;

	private float org_radiu = 10f;

	public void SetPreSkillSectorTip(float radius)
	{
		this.sectorTrans.localScale = new Vector3(radius / this.org_radiu, radius / this.org_radiu, 1f);
	}
}
