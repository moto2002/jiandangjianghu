using System;
using UnityEngine;

[RequireComponent(typeof(Skill))]
public class SkillCurveToTargetInSpeed : SendTargetEventBase
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

	public Vector3 deviationDegree;

	public bool orientToPath = true;

	public bool particleAutoDestroy = true;

	private GameObject particleGo;

	private Transform mountTargetGo;

	private Vector3[] path;

	private float movePosition;

	private SkillCurveToTargetInSpeed.State state;

	public override void StartSkill(float speed)
	{
		this.delay += this.delay - this.delay * speed;
	}

	private void Update()
	{
		if (this.state == SkillCurveToTargetInSpeed.State.delay)
		{
			this.delay -= Time.deltaTime;
			if (this.delay <= 0f)
			{
				this.state = SkillCurveToTargetInSpeed.State.start;
			}
		}
		if (this.state == SkillCurveToTargetInSpeed.State.start)
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
				this.particleGo.transform.position = transform.transform.position;
				this.particleGo.AddComponent<SkillClearParticle>().onClear = delegate
				{
					UnityEngine.Object.Destroy(this);
				};
			}
			this.path = new Vector3[3];
			this.path[0] = transform.transform.position;
			this.state = SkillCurveToTargetInSpeed.State.move;
		}
		else if (this.state == SkillCurveToTargetInSpeed.State.move)
		{
			if (!this.mountTargetGo || !this.particleGo)
			{
				this.StartTargetEvent();
				return;
			}
			float magnitude = (this.mountTargetGo.transform.position - this.particleGo.transform.position).magnitude;
			if (magnitude <= 0.01f)
			{
				this.StartTargetEvent();
			}
			else
			{
				this.path[2] = this.mountTargetGo.transform.position;
				Vector3 a = this.path[2] - this.path[0];
				float num = a.magnitude * 0.5f;
				this.path[1] = a * 0.5f + new Vector3(num * Mathf.Tan(0.0174532924f * this.deviationDegree.x), num * Mathf.Tan(0.0174532924f * this.deviationDegree.y), num * Mathf.Tan(0.0174532924f * this.deviationDegree.z));
				float num2 = Spline.PathLength(this.path);
				if (this.movePosition > num2)
				{
					this.movePosition = num2;
				}
				this.movePosition = Mathf.MoveTowards(this.movePosition, num2, this.speed * Time.deltaTime);
				if (this.movePosition > num2)
				{
					this.movePosition = num2;
				}
				if (this.movePosition >= num2)
				{
					this.StartTargetEvent();
				}
				else
				{
					float num3 = this.movePosition / num2;
					Vector3 position = Spline.InterpConstantSpeed(this.path, num3, Easing.EaseType.linear);
					this.particleGo.transform.position = position;
					if (this.orientToPath)
					{
						this.particleGo.transform.LookAt(Spline.InterpConstantSpeed(this.path, num3 + 0.05f, Easing.EaseType.linear));
					}
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
			else if (this.particleAutoDestroy)
			{
				this.particleGo.GetComponent<ParticleParentAutoDestroy>().SetOnce();
			}
		}
		base.gameObject.SendMessage("ApplyTargetEvent", null, SendMessageOptions.DontRequireReceiver);
		UnityEngine.Object.Destroy(this);
	}
}
