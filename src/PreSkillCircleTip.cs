using DG.Tweening;
using System;
using UnityEngine;

public class PreSkillCircleTip : MonoBehaviour
{
	public Transform circleInTrans;

	public Transform circleOutTrans;

	private float org_radius = 0.5f;

	private void Start()
	{
		this.Circle();
	}

	private void Update()
	{
	}

	public void SetPreSkillCircleTip(int r)
	{
		this.circleInTrans.localScale = new Vector3((float)r / this.org_radius, (float)r / this.org_radius, 1f);
		this.circleOutTrans.localScale = new Vector3((float)r / this.org_radius, (float)r / this.org_radius, 1f);
	}

	private void Circle()
	{
		Tweener t = DOTween.To(delegate(float value)
		{
			this.circleInTrans.localEulerAngles = new Vector3(0f, 0f, value);
			this.circleOutTrans.localEulerAngles = new Vector3(0f, 0f, -value);
		}, 0f, 360f, 15f);
		t.SetEase(Ease.Linear);
		t.OnComplete(delegate
		{
			this.Circle();
		});
		t.Play<Tweener>();
	}
}
