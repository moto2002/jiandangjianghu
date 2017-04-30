using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Skill))]
public class SkillPlayStartLightning : SkillBase
{
	public float time;

	public string mountOfStartGo;

	public string mountOfTargetGo;

	public int branchesPerReceiver = 1;

	public int sectionsPerBranch = 10;

	public float lightningBoltJitter = 5f;

	public float lightningWidth = 1f;

	public float lightningFrequency = 60f;

	public Material lightningMaterial;

	private GameObject[] lightningReceivers;

	private List<LineRenderer> lineRenderers = new List<LineRenderer>();

	private float timeCount;

	private float timeTotal;

	private List<GameObject> lightningGo = new List<GameObject>();

	private Transform mountStartGo;

	public override void StartSkill(float speed)
	{
		Skill component = base.gameObject.GetComponent<Skill>();
		if (!component || !component.startGo || !component.targetGo)
		{
			this.Finish();
			return;
		}
		GameObject targetGo = component.targetGo;
		this.mountStartGo = SkillBase.Find(component.startGo.transform, this.mountOfStartGo);
		if (!this.mountStartGo)
		{
			this.mountStartGo = component.startGo.transform;
		}
		Transform transform = SkillBase.Find(targetGo.transform, this.mountOfTargetGo);
		if (!transform)
		{
			transform = targetGo.transform;
		}
		this.lightningReceivers = new GameObject[]
		{
			transform.gameObject
		};
		this.InitialiseLineRenderers();
	}

	private void Finish()
	{
		foreach (GameObject current in this.lightningGo)
		{
			UnityEngine.Object.Destroy(current);
		}
		UnityEngine.Object.Destroy(this);
	}

	private void Update()
	{
		this.timeTotal += Time.deltaTime;
		if (this.timeTotal > this.time)
		{
			this.Finish();
			return;
		}
		if (!this.mountStartGo || !this.lightningReceivers[0])
		{
			this.Finish();
			return;
		}
		this.timeCount += Time.deltaTime;
		if (this.timeCount < 1f / this.lightningFrequency)
		{
			return;
		}
		this.timeCount = 0f;
		int num = 0;
		for (int i = 0; i < this.lightningReceivers.Length; i++)
		{
			Vector3 a = (this.lightningReceivers[i].transform.position - this.mountStartGo.position) / (float)this.sectionsPerBranch;
			Vector3[] array = new Vector3[this.sectionsPerBranch];
			for (int j = 1; j < array.Length - 1; j++)
			{
				array[j] = this.mountStartGo.position + a * (float)j;
			}
			int num2 = 0;
			for (int k = 0; k < this.branchesPerReceiver; k++)
			{
				if (this.lineRenderers[num])
				{
					if (k % 2 == 0)
					{
						this.lineRenderers[num].SetPosition(num2, this.mountStartGo.position);
						this.lineRenderers[num].SetPosition(num2 + array.Length - 1, this.lightningReceivers[i].transform.position);
						this.lineRenderers[num].SetWidth(this.lightningWidth, this.lightningWidth);
						for (int l = 1; l < this.sectionsPerBranch - 1; l++)
						{
							this.lineRenderers[num].SetPosition(num2 + l, this.AddVectorJitter(array[l], this.lightningBoltJitter));
						}
					}
					else
					{
						this.lineRenderers[num].SetPosition(num2, this.lightningReceivers[i].transform.position);
						this.lineRenderers[num].SetPosition(num2 + array.Length - 1, this.mountStartGo.position);
						this.lineRenderers[num].SetWidth(this.lightningWidth, this.lightningWidth);
						for (int m = 1; m < this.sectionsPerBranch - 1; m++)
						{
							this.lineRenderers[num].SetPosition(num2 + m, this.AddVectorJitter(array[this.sectionsPerBranch - m - 1], this.lightningBoltJitter));
						}
					}
					num2 += this.sectionsPerBranch;
				}
			}
			num++;
		}
	}

	public Vector3 AddVectorJitter(Vector3 vector, float jitter)
	{
		vector += Vector3.left * UnityEngine.Random.Range(-jitter, jitter);
		vector += Vector3.up * UnityEngine.Random.Range(-jitter, jitter);
		vector += Vector3.forward * UnityEngine.Random.Range(-jitter, jitter);
		return vector;
	}

	public void InitialiseLineRenderers()
	{
		for (int i = 0; i < this.lightningReceivers.Length; i++)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = base.gameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.name = "Line Renderer " + (i + 1);
			LineRenderer item = gameObject.AddComponent<LineRenderer>();
			this.lightningGo.Add(gameObject);
			this.lineRenderers.Add(item);
		}
		for (int j = 0; j < this.lineRenderers.Count; j++)
		{
			this.lineRenderers[j].shadowCastingMode = ShadowCastingMode.Off;
			this.lineRenderers[j].receiveShadows = false;
			this.lineRenderers[j].material = this.lightningMaterial;
			this.lineRenderers[j].SetVertexCount(this.sectionsPerBranch * this.branchesPerReceiver);
			this.lineRenderers[j].SetWidth(this.lightningWidth, this.lightningWidth);
		}
	}

	private void InitialiseLights()
	{
	}

	private void RandomiseLights()
	{
	}
}
