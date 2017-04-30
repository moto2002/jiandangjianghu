using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillCurveToTargetInTime : SendTargetEventBase
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

	public float time;

	public Vector3 deviationDegree;

	public Easing.EaseType easeType = Easing.EaseType.linear;

	public bool orientToPath = true;

	public bool particleAutoDestroy = true;

	private GameObject particleGo;

	private Transform mountTargetGo;

	private Vector3[] path;

	private float curTime;

	private SkillCurveToTargetInTime.State state;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
	}

	private void Update()
	{
		if (this.state == SkillCurveToTargetInTime.State.delay)
		{
			this.delay -= Time.deltaTime;
			if (this.delay <= 0f)
			{
				this.state = SkillCurveToTargetInTime.State.start;
			}
		}
		if (this.state == SkillCurveToTargetInTime.State.start)
		{
			Skill component = base.gameObject.GetComponent<Skill>();
			if (!component || !component.startGo || !component.targetGo)
			{
				this.StartTargetEvent();
				return;
			}
			GameObject targetGo = component.targetGo;
			Transform transform = SkillBase.Find(component.startGo.transform, this.mountOfStartGo);
			if (!transform)
			{
				transform = component.startGo.transform;
			}
			this.mountTargetGo = SkillBase.Find(targetGo.transform, this.mountOfTargetGo);
			if (!this.mountTargetGo)
			{
				this.mountTargetGo = targetGo.transform;
			}
			if (this.enableParticle)
			{
				this.particleGo = UnityEngine.Object.Instantiate<GameObject>(this.particle);
				if (this.particleAutoDestroy && this.particleGo.GetComponent<ParticleParentAutoDestroy>() == null)
				{
					this.particleGo.AddComponent<ParticleParentAutoDestroy>();
				}
				this.particleGo.transform.localPosition = Vector3.zero;
				this.particleGo.AddComponent<SkillClearParticle>().onClear = delegate
				{
					UnityEngine.Object.Destroy(this);
				};
			}
			this.path = new Vector3[3];
			this.path[0] = transform.transform.position;
			this.curTime = 0f;
			this.state = SkillCurveToTargetInTime.State.move;
		}
		else if (this.state == SkillCurveToTargetInTime.State.move)
		{
			this.curTime += Time.deltaTime;
			float num = this.curTime / this.time;
			if (num >= 1f)
			{
				this.StartTargetEvent();
			}
			if (this.particleGo && this.mountTargetGo)
			{
				this.path[2] = this.mountTargetGo.transform.position;
				Vector3 a = this.path[2] - this.path[0];
				float num2 = a.magnitude * 0.5f;
				this.path[1] = a * 0.5f + new Vector3(num2 * Mathf.Tan(0.0174532924f * this.deviationDegree.x), num2 * Mathf.Tan(0.0174532924f * this.deviationDegree.y), num2 * Mathf.Tan(0.0174532924f * this.deviationDegree.z));
				Vector3 position = Spline.InterpConstantSpeed(this.path, num, this.easeType);
				this.particleGo.transform.position = position;
				if (this.orientToPath)
				{
					this.particleGo.transform.LookAt(Spline.InterpConstantSpeed(this.path, num + 0.05f, this.easeType));
				}
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
		if (!component.needFeedback)
		{
			if (this.sendTargetEvent)
			{
				base.gameObject.SendMessage("ApplyTargetEvent", null, SendMessageOptions.DontRequireReceiver);
			}
		}
		UnityEngine.Object.Destroy(this);
	}
}
