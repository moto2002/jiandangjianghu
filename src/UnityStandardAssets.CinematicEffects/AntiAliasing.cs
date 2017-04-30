using System;
using UnityEngine;

namespace UnityStandardAssets.CinematicEffects
{
	[AddComponentMenu("Image Effects/Cinematic/Anti-aliasing"), ExecuteInEditMode, RequireComponent(typeof(Camera))]
	public class AntiAliasing : MonoBehaviour
	{
		public enum Method
		{
			Smaa,
			Fxaa
		}

		[SerializeField]
		private SMAA m_SMAA = new SMAA();

		[SerializeField]
		private FXAA m_FXAA = new FXAA();

		[HideInInspector, SerializeField]
		private int m_Method;

		private Camera m_Camera;

		public int method
		{
			get
			{
				return this.m_Method;
			}
			set
			{
				if (this.m_Method == value)
				{
					return;
				}
				this.m_Method = value;
			}
		}

		public IAntiAliasing current
		{
			get
			{
				if (this.method == 0)
				{
					return this.m_SMAA;
				}
				return this.m_FXAA;
			}
		}

		public Camera cameraComponent
		{
			get
			{
				if (this.m_Camera == null)
				{
					this.m_Camera = base.GetComponent<Camera>();
				}
				return this.m_Camera;
			}
		}

		private void Awake()
		{
			this.m_SMAA.Awake();
			this.m_FXAA.Awake();
		}

		private void OnEnable()
		{
			this.m_SMAA.OnEnable(this);
			this.m_FXAA.OnEnable(this);
		}

		private void OnDisable()
		{
			this.m_SMAA.OnDisable();
			this.m_FXAA.OnDisable();
		}

		private void OnPreCull()
		{
			this.current.OnPreCull(this.cameraComponent);
		}

		private void OnPostRender()
		{
			this.current.OnPostRender(this.cameraComponent);
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			this.current.OnRenderImage(this.cameraComponent, source, destination);
		}
	}
}
