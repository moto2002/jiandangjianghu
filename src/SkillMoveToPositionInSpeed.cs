using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillMoveToPositionInSpeed : SendTargetEventBase
{
	private enum State
	{
		delay,
		start,
		move
	}

	public GameObject particle;

	public string mountOfStartGo;

	public string mountOfTargetGo;

	public float delay;

	public float speed;

	public bool orientToPath = true;

	public bool particleAutoDestroy = true;

	private GameObject particleGo;

	private Vector3 mountTargetVec;

	private SkillMoveToPositionInSpeed.State state;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
	}

	private void Update()
	{
		if (this.state == SkillMoveToPositionInSpeed.State.delay)
		{
			this.delay -= Time.deltaTime;
			if (this.delay <= 0f)
			{
				this.state = SkillMoveToPositionInSpeed.State.start;
			}
		}
		if (this.state == SkillMoveToPositionInSpeed.State.start)
		{
			Skill component = base.gameObject.GetComponent<Skill>();
			if (!component || !component.startGo)
			{
				this.StartTargetEvent();
				return;
			}
			Transform transform = SkillBase.Find(component.startGo.transform, this.mountOfStartGo);
			if (!transform)
			{
				transform = component.startGo.transform;
			}
			this.mountTargetVec = component.targetPos;
			if (this.enableParticle)
			{
				this.particleGo = UnityEngine.Object.Instantiate<GameObject>(this.particle);
				if (this.particleAutoDestroy && this.particleGo.GetComponent<ParticleParentAutoDestroy>() == null)
				{
					this.particleGo.AddComponent<ParticleParentAutoDestroy>();
				}
				this.particleGo.transform.localPosition = Vector3.zero;
				this.particleGo.transform.position = transform.transform.position;
				this.particleGo.AddComponent<SkillClearParticle>().onClear = delegate
				{
					UnityEngine.Object.Destroy(this);
				};
			}
			this.state = SkillMoveToPositionInSpeed.State.move;
		}
		else if (this.state == SkillMoveToPositionInSpeed.State.move)
		{
			if (!this.particleGo)
			{
				this.StartTargetEvent();
				return;
			}
			this.particleGo.transform.position = Vector3.MoveTowards(this.particleGo.transform.position, this.mountTargetVec, this.speed * Time.deltaTime);
			if (this.orientToPath)
			{
				this.particleGo.transform.LookAt(this.mountTargetVec);
			}
			if ((this.mountTargetVec - this.particleGo.transform.position).magnitude <= 0.01f)
			{
				this.StartTargetEvent();
			}
		}
	}

	private void StartTargetEvent()
	{
		if (this.sendMessage)
		{
			return;
		}
		if (this.particleGo != null)
		{
			if (this.immediateDeleteParticle)
			{
				UnityEngine.Object.Destroy(this.particleGo);
			}
			else
			{
				this.particleGo.GetComponent<ParticleParentAutoDestroy>().SetOnce();
			}
		}
		Skill component = base.gameObject.GetComponent<Skill>();
		if (component.needFeedback)
		{
			this.sendMessage = true;
		}
		else if (this.sendTargetEvent)
		{
			base.gameObject.SendMessage("ApplyTargetEvent", null, SendMessageOptions.DontRequireReceiver);
		}
		UnityEngine.Object.Destroy(this);
	}
}
