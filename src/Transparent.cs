using System;
using UnityEngine;

public class Transparent : MonoBehaviour
{
	private string defaultShaderName;

	private void Start()
	{
	}

	private void OnDestroy()
	{
		this.CancelTransparent();
	}

	public void InvokeTranparent()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		Shader shader = component.material.shader;
		this.defaultShaderName = shader.name;
		if (!shader.name.Equals("Custom/Transparent/Cutout/Soft Edge Unlit"))
		{
			component.material.shader = Shader.Find("Custom/Transparent/Cutout/Soft Edge Unlit");
			Color color = component.material.color;
			color.a = 0.2f;
			if (component.material.GetColor("_Color").a > 0.3f)
			{
				component.material.SetColor("_Color", color);
			}
		}
	}

	public void CancelTransparent()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		Shader shader = component.material.shader;
		if (shader.name.Equals("Custom/Transparent/Cutout/Soft Edge Unlit"))
		{
			component.material.shader = Shader.Find(this.defaultShaderName);
			Color color = component.material.color;
			color.a = 1f;
			component.material.SetColor("_Color", color);
		}
	}

	private void Update()
	{
	}
}
