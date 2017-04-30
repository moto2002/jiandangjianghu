using System;
using UnityEngine;

[RequireComponent(typeof(UIPanel))]
public class AvatarSystemClipper : MonoBehaviour
{
	private const string AvatarShaderName = "Custom/Avatar Texture Area Clip";

	private const string ParticleShaderName = "Custom/Particle Texture Area Clip";

	private const float ClipInterval = 0.5f;

	private UIPanel m_targetPanel;

	private Shader m_shaderAvatar;

	private Shader m_shaderParticle;

	private void Start()
	{
		this.m_targetPanel = base.GetComponent<UIPanel>();
		if (this.m_targetPanel == null)
		{
			throw new ArgumentNullException("Cann't find the right UIPanel");
		}
		if (this.m_targetPanel.clipping != UIDrawCall.Clipping.SoftClip)
		{
			throw new InvalidOperationException("Don't need to clip");
		}
		this.m_shaderAvatar = Shader.Find("Custom/Avatar Texture Area Clip");
		this.m_shaderParticle = Shader.Find("Custom/Particle Texture Area Clip");
		if (!base.IsInvoking("Clip"))
		{
			base.InvokeRepeating("Clip", 0f, 0.5f);
		}
	}

	private Vector4 CalcClipArea()
	{
		Vector4 finalClipRegion = this.m_targetPanel.finalClipRegion;
		Vector4 vector = new Vector4
		{
			x = finalClipRegion.x - finalClipRegion.z / 2f,
			y = finalClipRegion.y - finalClipRegion.w / 2f,
			z = finalClipRegion.x + finalClipRegion.z / 2f,
			w = finalClipRegion.y + finalClipRegion.w / 2f
		};
		UIRoot component = NGUITools.GetRoot(base.gameObject).GetComponent<UIRoot>();
		Vector3 vector2 = this.m_targetPanel.transform.position - component.transform.position;
		float num = 2f;
		float num2 = num / (float)component.manualHeight;
		return new Vector4
		{
			x = vector2.x + vector.x * num2,
			y = vector2.y + vector.y * num2,
			z = vector2.x + vector.z * num2,
			w = vector2.y + vector.w * num2
		};
	}

	private void Clip()
	{
		Vector4 vector = this.CalcClipArea();
		AvatarBase[] componentsInChildren = base.GetComponentsInChildren<AvatarBase>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Renderer[] componentsInChildren2 = componentsInChildren[i].GetComponentsInChildren<Renderer>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				Material material = componentsInChildren2[j].material;
				int renderQueue = material.renderQueue;
				if (material.shader.name != "Custom/Avatar Texture Area Clip")
				{
					material.shader = this.m_shaderAvatar;
					material.renderQueue = renderQueue;
				}
				material.SetVector("_Area", vector);
			}
			ParticleSystem[] componentsInChildren3 = componentsInChildren[i].GetComponentsInChildren<ParticleSystem>();
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				ParticleSystem particleSystem = componentsInChildren3[k];
				Material material2 = particleSystem.GetComponent<Renderer>().material;
				int renderQueue2 = material2.renderQueue;
				if (material2.shader.name != "Custom/Particle Texture Area Clip")
				{
					material2.shader = this.m_shaderParticle;
					material2.renderQueue = renderQueue2;
				}
				material2.SetVector("_Area", vector);
			}
		}
	}

	private void OnDestroy()
	{
		base.CancelInvoke("Clip");
	}
}
