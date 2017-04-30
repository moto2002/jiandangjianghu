using System;
using UnityEngine;

namespace UnityStandardAssets.CinematicEffects
{
	[Serializable]
	public class FXAA : IAntiAliasing
	{
		[Serializable]
		public struct QualitySettings
		{
			[Range(0f, 1f), Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
			public float subpixelAliasingRemovalAmount;

			[Range(0.063f, 0.333f), Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			public float edgeDetectionThreshold;

			[Range(0f, 0.0833f), Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			public float minimumRequiredLuminance;
		}

		[Serializable]
		public struct ConsoleSettings
		{
			[Range(0.33f, 0.5f), Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
			public float subpixelSpreadAmount;

			[Range(2f, 8f), Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
			public float edgeSharpnessAmount;

			[Range(0.125f, 0.25f), Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			public float edgeDetectionThreshold;

			[Range(0.04f, 0.06f), Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			public float minimumRequiredLuminance;
		}

		[Serializable]
		public struct Preset
		{
			[AttributeUsage(AttributeTargets.Field)]
			public class LayoutAttribute : PropertyAttribute
			{
			}

			[FXAA.Preset.LayoutAttribute]
			public FXAA.QualitySettings qualitySettings;

			[FXAA.Preset.LayoutAttribute]
			public FXAA.ConsoleSettings consoleSettings;

			private static readonly FXAA.Preset s_ExtremePerformance = new FXAA.Preset
			{
				qualitySettings = new FXAA.QualitySettings
				{
					subpixelAliasingRemovalAmount = 0f,
					edgeDetectionThreshold = 0.333f,
					minimumRequiredLuminance = 0.0833f
				},
				consoleSettings = new FXAA.ConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.06f
				}
			};

			private static readonly FXAA.Preset s_Performance = new FXAA.Preset
			{
				qualitySettings = new FXAA.QualitySettings
				{
					subpixelAliasingRemovalAmount = 0.25f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.0833f
				},
				consoleSettings = new FXAA.ConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.06f
				}
			};

			private static readonly FXAA.Preset s_Default = new FXAA.Preset
			{
				qualitySettings = new FXAA.QualitySettings
				{
					subpixelAliasingRemovalAmount = 0.75f,
					edgeDetectionThreshold = 0.166f,
					minimumRequiredLuminance = 0.0833f
				},
				consoleSettings = new FXAA.ConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.05f
				}
			};

			private static readonly FXAA.Preset s_Quality = new FXAA.Preset
			{
				qualitySettings = new FXAA.QualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.0625f
				},
				consoleSettings = new FXAA.ConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 4f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				}
			};

			private static readonly FXAA.Preset s_ExtremeQuality = new FXAA.Preset
			{
				qualitySettings = new FXAA.QualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.063f,
					minimumRequiredLuminance = 0.0312f
				},
				consoleSettings = new FXAA.ConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 2f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				}
			};

			public static FXAA.Preset extremePerformancePreset
			{
				get
				{
					return FXAA.Preset.s_ExtremePerformance;
				}
			}

			public static FXAA.Preset performancePreset
			{
				get
				{
					return FXAA.Preset.s_Performance;
				}
			}

			public static FXAA.Preset defaultPreset
			{
				get
				{
					return FXAA.Preset.s_Default;
				}
			}

			public static FXAA.Preset qualityPreset
			{
				get
				{
					return FXAA.Preset.s_Quality;
				}
			}

			public static FXAA.Preset extremeQualityPreset
			{
				get
				{
					return FXAA.Preset.s_ExtremeQuality;
				}
			}
		}

		private Shader m_Shader;

		private Material m_Material;

		[HideInInspector, SerializeField]
		public FXAA.Preset preset = FXAA.Preset.defaultPreset;

		public static FXAA.Preset[] availablePresets = new FXAA.Preset[]
		{
			FXAA.Preset.extremePerformancePreset,
			FXAA.Preset.performancePreset,
			FXAA.Preset.defaultPreset,
			FXAA.Preset.qualityPreset,
			FXAA.Preset.extremeQualityPreset
		};

		private int m_QualitySettings;

		private int m_ConsoleSettings;

		private Shader shader
		{
			get
			{
				if (this.m_Shader == null)
				{
					this.m_Shader = Shader.Find("Hidden/Fast Approximate Anti-aliasing");
				}
				return this.m_Shader;
			}
		}

		public Material material
		{
			get
			{
				if (this.m_Material == null)
				{
					this.m_Material = ImageEffectHelper.CheckShaderAndCreateMaterial(this.shader);
				}
				return this.m_Material;
			}
		}

		public bool validSourceFormat
		{
			get;
			private set;
		}

		public void Awake()
		{
			this.m_QualitySettings = Shader.PropertyToID("_QualitySettings");
			this.m_ConsoleSettings = Shader.PropertyToID("_ConsoleSettings");
		}

		public void OnEnable(AntiAliasing owner)
		{
			if (!ImageEffectHelper.IsSupported(this.shader, true, false, owner))
			{
				owner.enabled = false;
			}
		}

		public void OnDisable()
		{
			if (this.m_Material != null)
			{
				UnityEngine.Object.DestroyImmediate(this.m_Material);
			}
		}

		public void OnPreCull(Camera camera)
		{
		}

		public void OnPostRender(Camera camera)
		{
		}

		public void OnRenderImage(Camera camera, RenderTexture source, RenderTexture destination)
		{
			this.material.SetVector(this.m_QualitySettings, new Vector3(this.preset.qualitySettings.subpixelAliasingRemovalAmount, this.preset.qualitySettings.edgeDetectionThreshold, this.preset.qualitySettings.minimumRequiredLuminance));
			this.material.SetVector(this.m_ConsoleSettings, new Vector4(this.preset.consoleSettings.subpixelSpreadAmount, this.preset.consoleSettings.edgeSharpnessAmount, this.preset.consoleSettings.edgeDetectionThreshold, this.preset.consoleSettings.minimumRequiredLuminance));
			Graphics.Blit(source, destination, this.material, 0);
		}
	}
}
