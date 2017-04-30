using System;
using UnityEngine;

[ExecuteInEditMode]
public class UIParticles : MonoBehaviour
{
	private const float UPDATE_RENDER_TIME = 0.2f;

	private float lastTime;

	private Renderer[] rendererArray;

	private bool isWidgetOK;

	private bool isRendererArrayOK;

	private Renderer tempMeshRenderer;

	public int RenderQueue = 3000;

	public UIWidget parentWidget;

	public bool IsForward = true;

	private ParticleSystem ps;

	private float rosx;

	private float rosy;

	private float rosz;

	private bool IsSetRotation;

	private void OnDestroy()
	{
		this.rendererArray = null;
		this.parentWidget = null;
	}

	private void Start()
	{
		this.ps = base.transform.GetComponentInChildren<ParticleSystem>();
		this.ps.Play();
		if (this.IsSetRotation)
		{
			this.SetParticleRotation(this.rosx, this.rosy, this.rosz);
		}
	}

	private void LateUpdate()
	{
		this.lastTime += Time.deltaTime;
		if (this.lastTime < 0.2f)
		{
			return;
		}
		this.lastTime = -UnityEngine.Random.Range(0f, 0.2f);
		if (this.parentWidget == null)
		{
			this.parentWidget = NGUITools.FindInParents<UIWidget>(base.gameObject);
		}
		if (this.rendererArray == null || this.rendererArray.Length == 0)
		{
			this.rendererArray = base.GetComponentsInChildren<Renderer>(true);
		}
		this.isWidgetOK = (this.parentWidget != null && this.parentWidget.drawCall != null);
		this.isRendererArrayOK = (this.rendererArray != null && this.rendererArray.Length > 0);
		if (this.isWidgetOK && this.isRendererArrayOK)
		{
			this.OnChangeRenderQueue();
		}
	}

	private void OnChangeRenderQueue()
	{
		int num = this.isWidgetOK ? this.parentWidget.drawCall.finalRenderQueue : this.RenderQueue;
		if (num != this.RenderQueue)
		{
			if (this.IsForward)
			{
				num++;
			}
			else
			{
				num--;
			}
			this.RenderQueue = num;
			for (int num2 = 0; num2 != this.rendererArray.Length; num2++)
			{
				this.tempMeshRenderer = this.rendererArray[num2];
				if (this.tempMeshRenderer != null)
				{
					this.tempMeshRenderer.material.renderQueue = this.RenderQueue;
				}
			}
		}
	}

	public void Play()
	{
		if (this.ps == null)
		{
			return;
		}
		this.ps.Play();
	}

	public void Pause()
	{
		if (this.ps == null)
		{
			return;
		}
		this.ps.Pause();
	}

	public void Stop()
	{
		if (this.ps == null)
		{
			return;
		}
		this.ps.Stop();
	}

	public void SetParticleRotation(float x, float y, float z)
	{
		if (this.ps == null)
		{
			this.IsSetRotation = true;
			this.rosx = x;
			this.rosy = y;
			this.rosz = z;
			return;
		}
		this.ps.startRotation3D = new Vector3(x, y, z);
	}
}
