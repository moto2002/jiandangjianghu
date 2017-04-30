using System;
using UnityEngine;

public class AvatarBase : MonoBehaviour
{
	private Transform avatar;

	private Animator ani;

	private AnimationEventReceiver aniEventReceier;

	private int curStatus;

	public bool canClick;

	public bool canRotate;

	public int clickAction;

	public int showAction;

	private void Awake()
	{
	}

	private void Start()
	{
		if (this.ani && !this.showAction.Equals(RoleAction.state.none))
		{
			this.curStatus = this.showAction;
			this.ani.SetInteger("status", this.curStatus);
		}
	}

	private void OnEnable()
	{
		this.Start();
	}

	private void OnDrag(Vector2 delta)
	{
		if (!this.canRotate)
		{
			return;
		}
		float x = delta.x;
		this.avatar.Rotate(0f, -x * 0.5f, 0f);
	}

	private void OnClick()
	{
		if (!this.canClick)
		{
			return;
		}
		this.curStatus = this.clickAction;
		this.ani.SetInteger("status", this.curStatus);
	}

	public void SetAvatar(GameObject go, bool click = true, bool rotate = false)
	{
		this.avatar = go.transform;
		this.canClick = click;
		this.canRotate = rotate;
		this.ani = go.transform.GetComponent<Animator>();
		this.aniEventReceier = go.transform.GetComponent<AnimationEventReceiver>();
		if (this.canClick)
		{
			AnimationEventReceiver expr_4D = this.aniEventReceier;
			expr_4D.ActionFinish = (Action<int>)Delegate.Combine(expr_4D.ActionFinish, new Action<int>(this.ActionFinished));
		}
	}

	private void ActionFinished(int action)
	{
		if (action == this.clickAction)
		{
			this.ani.SetInteger("status", 1);
		}
	}
}
