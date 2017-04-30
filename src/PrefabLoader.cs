using System;
using UnityEngine;

public class PrefabLoader : MonoBehaviour
{
	public GameObject[] prefabs;

	public Vector3[] scale;

	public Vector3[] position;

	public Vector3[] rotation;

	public int renderQ;

	public float scaleFactor = 1f;

	[HideInInspector]
	public bool changeToClipShader;

	public bool Done
	{
		get;
		private set;
	}

	private void Start()
	{
		if (this.prefabs == null)
		{
			this.Done = true;
			return;
		}
		for (int i = 0; i < this.prefabs.Length; i++)
		{
			if (!(this.prefabs[i] == null))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefabs[i]);
				gameObject.transform.SetParent(base.transform);
				gameObject.transform.localScale = ((this.scale.Length != 0) ? this.scale[i] : Vector3.one);
				gameObject.transform.localPosition = ((this.position.Length != 0) ? this.position[i] : Vector3.zero);
				gameObject.transform.localRotation = ((this.rotation.Length != 0) ? Quaternion.Euler(this.rotation[i]) : Quaternion.identity);
				if (this.renderQ > 0)
				{
					UIRoot component = NGUITools.GetRoot(base.gameObject).GetComponent<UIRoot>();
					if (component)
					{
						ParticleSystem[] componentsInChildren = base.transform.GetComponentsInChildren<ParticleSystem>(true);
						for (int j = 0; j < componentsInChildren.Length; j++)
						{
							componentsInChildren[j].transform.localScale = component.transform.localScale * this.scaleFactor;
						}
						Renderer[] componentsInChildren2 = gameObject.GetComponentsInChildren<Renderer>();
						for (int k = 0; k < componentsInChildren2.Length; k++)
						{
							if (this.changeToClipShader)
							{
								componentsInChildren2[k].material.shader = Shader.Find("Custom/Particle Texture Area Clip");
							}
							componentsInChildren2[k].material.renderQueue = this.renderQ;
							if (base.gameObject.layer == LayerMask.NameToLayer("UI"))
							{
								componentsInChildren2[k].gameObject.layer = LayerMask.NameToLayer("UI");
							}
							else
							{
								componentsInChildren2[k].gameObject.layer = LayerMask.NameToLayer("UIModel");
							}
						}
					}
				}
			}
		}
		this.Done = true;
	}

	public void ResetRenderQ()
	{
		base.Invoke("delayCall", 0.3f);
	}

	private void delayCall()
	{
		Renderer[] componentsInChildren = base.transform.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].material.renderQueue = this.renderQ;
		}
	}
}
