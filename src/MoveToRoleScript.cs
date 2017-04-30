using DG.Tweening;
using System;
using ThirdParty;
using UnityEngine;

public class MoveToRoleScript : MonoBehaviour
{
	private enum State
	{
		delay,
		move
	}

	public GameObject[] addEffectGos;

	public Transform efTrans;

	public float speed = 5f;

	public float delay;

	public float a = 10f;

	private MoveToRoleScript.State state;

	public Transform role
	{
		get;
		set;
	}

	private void Start()
	{
		this.role = Singleton<RoleManager>.Instance.mainRole.gameObject.transform;
		if (this.addEffectGos != null)
		{
			for (int i = 0; i < this.addEffectGos.Length; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.addEffectGos[i]);
				gameObject.transform.SetParent(this.efTrans);
				gameObject.SetActive(false);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.SetActive(true);
			}
		}
		this.PopUpItemGo();
	}

	private void Update()
	{
		if (this.role == null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (this.state == MoveToRoleScript.State.delay)
		{
			this.delay -= Time.deltaTime;
			if (this.delay <= 0f)
			{
				this.state = MoveToRoleScript.State.move;
			}
		}
		if (this.state == MoveToRoleScript.State.move)
		{
			Vector3 target = new Vector3(this.role.position.x, this.role.position.y + 1f, this.role.position.z);
			this.speed += this.a * Time.deltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, target, this.speed * Time.deltaTime);
			base.transform.LookAt(this.role.transform);
			if ((target - base.transform.position).magnitude < 0.01f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	private void PopUpItemGo()
	{
		float f = UnityEngine.Random.Range(0f, 6.28318548f);
		float num = 3f * UnityEngine.Random.Range(0.3f, 0.8f);
		Vector3 vector = base.transform.position + new Vector3(num * Mathf.Sin(f), 0f, num * Mathf.Cos(f));
		base.transform.DOLocalMoveX(vector.x, 0.5f, false).SetEase(Ease.Linear);
		base.transform.DOLocalMoveZ(vector.z, 0.5f, false).SetEase(Ease.Linear);
		base.transform.DOLocalMoveY(base.transform.position.y + 1f, 0.2f, false).SetEase(Ease.Linear).OnComplete(delegate
		{
			base.transform.DOLocalMoveY(base.transform.position.y - 1f, 0.3f, false);
		});
	}
}
