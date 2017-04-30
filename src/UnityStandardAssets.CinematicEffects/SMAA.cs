using System;
using UnityEngine;

namespace UnityStandardAssets.CinematicEffects
{
	[Serializable]
	public class SMAA : IAntiAliasing
	{
		[AttributeUsage(AttributeTargets.Field)]
		public class SettingsGroup : Attribute
		{
		}

		[AttributeUsage(AttributeTargets.Field)]
		public class TopLevelSettings : Attribute
		{
		}

		[AttributeUsage(AttributeTargets.Field)]
		public class ExperimentalGroup : Attribute
		{
		}

		public enum DebugPass
		{
			Off,
			Edges,
			Weights,
			Accumulation
		}

		public enum QualityPreset
		{
			Low,
			Medium,
			High,
			Ultra,
			Custom
		}

		public enum EdgeDetectionMethod
		{
			Luma = 1,
			Color,
			Depth
		}

		[Serializable]
		public struct GlobalSettings
		{
			[Tooltip("Use this to fine tune your settings when working in Custom quality mode. \"Accumulation\" only works when \"Temporal Filtering\" is enabled.")]
			public SMAA.DebugPass debugPass;

			[Tooltip("Low: 60% of the quality.\nMedium: 80% of the quality.\nHigh: 95% of the quality.\nUltra: 99% of the quality (overkill).")]
			public SMAA.QualityPreset quality;

			[Tooltip("You've three edge detection methods to choose from: luma, color or depth.\nThey represent different quality/performance and anti-aliasing/sharpness tradeoffs, so our recommendation is for you to choose the one that best suits your particular scenario:\n\n- Depth edge detection is usually the fastest but it may miss some edges.\n- Luma edge detection is usually more expensive than depth edge detection, but catches visible edges that depth edge detection can miss.\n- Color edge detection is usually the most expensive one but catches chroma-only edges.")]
			public SMAA.EdgeDetectionMethod edgeDetectionMethod;

			public static SMAA.GlobalSettings defaultSettings
			{
				get
				{
					return new SMAA.GlobalSettings
					{
						debugPass = SMAA.DebugPass.Off,
						quality = SMAA.QualityPreset.High,
						edgeDetectionMethod = SMAA.EdgeDetectionMethod.Color
					};
				}
			}
		}

		[Serializable]
		public struct QualitySettings
		{
			[Tooltip("Enables/Disables diagonal processing.")]
			public bool diagonalDetection;

			[Tooltip("Enables/Disables corner detection. Leave this on to avoid blurry corners.")]
			public bool cornerDetection;

			[Range(0f, 0.5f), Tooltip("Specifies the threshold or sensitivity to edges. Lowering this value you will be able to detect more edges at the expense of performance.\n0.1 is a reasonable value, and allows to catch most visible edges. 0.05 is a rather overkill value, that allows to catch 'em all.")]
			public float threshold;

			[Tooltip("Specifies the threshold for depth edge detection. Lowering this value you will be able to detect more edges at the expense of performance."), Min(0.0001f)]
			public float depthThreshold;

			[Range(0f, 112f), Tooltip("Specifies the maximum steps performed in the horizontal/vertical pattern searches, at each side of the pixel.\nIn number of pixels, it's actually the double. So the maximum line length perfectly handled by, for example 16, is 64 (by perfectly, we meant that longer lines won't look as good, but still antialiased).")]
			public int maxSearchSteps;

			[Range(0f, 20f), Tooltip("Specifies the maximum steps performed in the diagonal pattern searches, at each side of the pixel. In this case we jump one pixel at time, instead of two.\nOn high-end machines it is cheap (between a 0.8x and 0.9x slower for 16 steps), but it can have a significant impact on older machines.")]
			public int maxDiagonalSearchSteps;

			[Range(0f, 100f), Tooltip("Specifies how much sharp corners will be rounded.")]
			public int cornerRounding;

			[Tooltip("If there is an neighbor edge that has a local contrast factor times bigger contrast than current edge, current edge will be discarded.\nThis allows to eliminate spurious crossing edges, and is based on the fact that, if there is too much contrast in a direction, that will hide perceptually contrast in the other neighbors."), Min(0f)]
			public float localContrastAdaptationFactor;

			public static SMAA.QualitySettings[] presetQualitySettings = new SMAA.QualitySettings[]
			{
				new SMAA.QualitySettings
				{
					diagonalDetection = false,
					cornerDetection = false,
					threshold = 0.15f,
					depthThreshold = 0.01f,
					maxSearchSteps = 4,
					maxDiagonalSearchSteps = 8,
					cornerRounding = 25,
					localContrastAdaptationFactor = 2f
				},
				new SMAA.QualitySettings
				{
					diagonalDetection = false,
					cornerDetection = false,
					threshold = 0.1f,
					depthThreshold = 0.01f,
					maxSearchSteps = 8,
					maxDiagonalSearchSteps = 8,
					cornerRounding = 25,
					localContrastAdaptationFactor = 2f
				},
				new SMAA.QualitySettings
				{
					diagonalDetection = true,
					cornerDetection = true,
					threshold = 0.1f,
					depthThreshold = 0.01f,
					maxSearchSteps = 16,
					maxDiagonalSearchSteps = 8,
					cornerRounding = 25,
					localContrastAdaptationFactor = 2f
				},
				new SMAA.QualitySettings
				{
					diagonalDetection = true,
					cornerDetection = true,
					threshold = 0.05f,
					depthThreshold = 0.01f,
					maxSearchSteps = 32,
					maxDiagonalSearchSteps = 16,
					cornerRounding = 25,
					localContrastAdaptationFactor = 2f
				}
			};
		}

		[Serializable]
		public struct TemporalSettings
		{
			[Tooltip("Temporal filtering makes it possible for the SMAA algorithm to benefit from minute subpixel information available that has been accumulated over many frames.")]
			public bool enabled;

			[Range(0.5f, 10f), Tooltip("The size of the fuzz-displacement (jitter) in pixels applied to the camera's perspective projection matrix.\nUsed for 2x temporal anti-aliasing.")]
			public float fuzzSize;

			public static SMAA.TemporalSettings defaultSettings
			{
				get
				{
					return new SMAA.TemporalSettings
					{
						enabled = false,
						fuzzSize = 2f
					};
				}
			}

			public bool UseTemporal()
			{
				return this.enabled;
			}
		}

		[Serializable]
		public struct PredicationSettings
		{
			[Tooltip("Predicated thresholding allows to better preserve texture details and to improve performance, by decreasing the number of detected edges using an additional buffer (the detph buffer).\nIt locally decreases the luma or color threshold if an edge is found in an additional buffer (so the global threshold can be higher).")]
			public bool enabled;

			[Tooltip("Threshold to be used in the additional predication buffer."), Min(0.0001f)]
			public float threshold;

			[Range(1f, 5f), Tooltip("How much to scale the global threshold used for luma or color edge detection when using predication.")]
			public float scale;

			[Range(0f, 1f), Tooltip("How much to locally decrease the threshold.")]
			public float strength;

			public static SMAA.PredicationSettings defaultSettings
			{
				get
				{
					return new SMAA.PredicationSettings
					{
						enabled = false,
						threshold = 0.01f,
						scale = 2f,
						strength = 0.4f
					};
				}
			}
		}

		[SMAA.TopLevelSettings]
		public SMAA.GlobalSettings settings = SMAA.GlobalSettings.defaultSettings;

		[SMAA.SettingsGroup]
		public SMAA.QualitySettings quality = SMAA.QualitySettings.presetQualitySettings[2];

		[SMAA.SettingsGroup]
		public SMAA.PredicationSettings predication = SMAA.PredicationSettings.defaultSettings;

		[SMAA.ExperimentalGroup, SMAA.SettingsGroup]
		public SMAA.TemporalSettings temporal = SMAA.TemporalSettings.defaultSettings;

		private Matrix4x4 m_ProjectionMatrix;

		private Matrix4x4 m_PreviousViewProjectionMatrix;

		private float m_FlipFlop = 1f;

		private RenderTexture m_Accumulation;

		private Shader m_Shader;

		private Texture2D m_AreaTexture;

		private Texture2D m_SearchTexture;

		private Material m_Material;

		private int m_AreaTex;

		private int m_SearchTex;

		private int m_Metrics;

		private int m_Params1;

		private int m_Params2;

		private int m_Params3;

		private int m_ReprojectionMatrix;

		private int m_SubsampleIndices;

		private int m_BlendTex;

		private int m_AccumulationTex;

		public Shader shader
		{
			get
			{
				if (this.m_Shader == null)
				{
					this.m_Shader = Shader.Find("Hidden/Subpixel Morphological Anti-aliasing");
				}
				return this.m_Shader;
			}
		}

		private Texture2D areaTexture
		{
			get
			{
				if (this.m_AreaTexture == null)
				{
					this.m_AreaTexture = Resources.Load<Texture2D>("AreaTex");
				}
				return this.m_AreaTexture;
			}
		}

		private Texture2D searchTexture
		{
			get
			{
				if (this.m_SearchTexture == null)
				{
					this.m_SearchTexture = Resources.Load<Texture2D>("SearchTex");
				}
				return this.m_SearchTexture;
			}
		}

		private Material material
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

		public void Awake()
		{
			this.m_AreaTex = Shader.PropertyToID("_AreaTex");
			this.m_SearchTex = Shader.PropertyToID("_SearchTex");
			this.m_Metrics = Shader.PropertyToID("_Metrics");
			this.m_Params1 = Shader.PropertyToID("_Params1");
			this.m_Params2 = Shader.PropertyToID("_Params2");
			this.m_Params3 = Shader.PropertyToID("_Params3");
			this.m_ReprojectionMatrix = Shader.PropertyToID("_ReprojectionMatrix");
			this.m_SubsampleIndices = Shader.PropertyToID("_SubsampleIndices");
			this.m_BlendTex = Shader.PropertyToID("_BlendTex");
			this.m_AccumulationTex = Shader.PropertyToID("_AccumulationTex");
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
			if (this.m_Accumulation != null)
			{
				UnityEngine.Object.DestroyImmediate(this.m_Accumulation);
			}
			this.m_Material = null;
			this.m_Accumulation = null;
		}

		public void OnPreCull(Camera camera)
		{
			if (this.temporal.UseTemporal())
			{
				this.m_ProjectionMatrix = camera.projectionMatrix;
				this.m_FlipFlop -= 2f * this.m_FlipFlop;
				Matrix4x4 identity = Matrix4x4.identity;
				identity.m03 = 0.25f * this.m_FlipFlop * this.temporal.fuzzSize / (float)camera.pixelWidth;
				identity.m13 = -0.25f * this.m_FlipFlop * this.temporal.fuzzSize / (float)camera.pixelHeight;
				camera.projectionMatrix = identity * camera.projectionMatrix;
			}
		}

		public void OnPostRender(Camera camera)
		{
			if (this.temporal.UseTemporal())
			{
				camera.ResetProjectionMatrix();
			}
		}

		public void OnRenderImage(Camera camera, RenderTexture source, RenderTexture destination)
		{
			int pixelWidth = camera.pixelWidth;
			int pixelHeight = camera.pixelHeight;
			bool flag = false;
			SMAA.QualitySettings qualitySettings = this.quality;
			if (this.settings.quality != SMAA.QualityPreset.Custom)
			{
				qualitySettings = SMAA.QualitySettings.presetQualitySettings[(int)this.settings.quality];
			}
			int edgeDetectionMethod = (int)this.settings.edgeDetectionMethod;
			int pass = 4;
			int pass2 = 5;
			int pass3 = 6;
			Matrix4x4 matrix4x = GL.GetGPUProjectionMatrix(this.m_ProjectionMatrix, true) * camera.worldToCameraMatrix;
			this.material.SetTexture(this.m_AreaTex, this.areaTexture);
			this.material.SetTexture(this.m_SearchTex, this.searchTexture);
			this.material.SetVector(this.m_Metrics, new Vector4(1f / (float)pixelWidth, 1f / (float)pixelHeight, (float)pixelWidth, (float)pixelHeight));
			this.material.SetVector(this.m_Params1, new Vector4(qualitySettings.threshold, qualitySettings.depthThreshold, (float)qualitySettings.maxSearchSteps, (float)qualitySettings.maxDiagonalSearchSteps));
			this.material.SetVector(this.m_Params2, new Vector2((float)qualitySettings.cornerRounding, qualitySettings.localContrastAdaptationFactor));
			this.material.SetMatrix(this.m_ReprojectionMatrix, this.m_PreviousViewProjectionMatrix * Matrix4x4.Inverse(matrix4x));
			float num = (this.m_FlipFlop >= 0f) ? 1f : 2f;
			this.material.SetVector(this.m_SubsampleIndices, new Vector4(num, num, num, 0f));
			Shader.DisableKeyword("USE_PREDICATION");
			if (this.settings.edgeDetectionMethod == SMAA.EdgeDetectionMethod.Depth)
			{
				camera.depthTextureMode |= DepthTextureMode.Depth;
			}
			else if (this.predication.enabled)
			{
				camera.depthTextureMode |= DepthTextureMode.Depth;
				Shader.EnableKeyword("USE_PREDICATION");
				this.material.SetVector(this.m_Params3, new Vector3(this.predication.threshold, this.predication.scale, this.predication.strength));
			}
			Shader.DisableKeyword("USE_DIAG_SEARCH");
			Shader.DisableKeyword("USE_CORNER_DETECTION");
			if (qualitySettings.diagonalDetection)
			{
				Shader.EnableKeyword("USE_DIAG_SEARCH");
			}
			if (qualitySettings.cornerDetection)
			{
				Shader.EnableKeyword("USE_CORNER_DETECTION");
			}
			Shader.DisableKeyword("USE_UV_BASED_REPROJECTION");
			if (this.temporal.UseTemporal())
			{
				Shader.EnableKeyword("USE_UV_BASED_REPROJECTION");
			}
			if (this.m_Accumulation == null || this.m_Accumulation.width != pixelWidth || this.m_Accumulation.height != pixelHeight)
			{
				if (this.m_Accumulation)
				{
					RenderTexture.ReleaseTemporary(this.m_Accumulation);
				}
				this.m_Accumulation = RenderTexture.GetTemporary(pixelWidth, pixelHeight, 0, source.format, RenderTextureReadWrite.Linear);
				this.m_Accumulation.hideFlags = HideFlags.HideAndDontSave;
				flag = true;
			}
			RenderTexture renderTexture = this.TempRT(pixelWidth, pixelHeight, source.format);
			Graphics.Blit(null, renderTexture, this.material, 0);
			Graphics.Blit(source, renderTexture, this.material, edgeDetectionMethod);
			if (this.settings.debugPass == SMAA.DebugPass.Edges)
			{
				Graphics.Blit(renderTexture, destination);
			}
			else
			{
				RenderTexture renderTexture2 = this.TempRT(pixelWidth, pixelHeight, source.format);
				Graphics.Blit(null, renderTexture2, this.material, 0);
				Graphics.Blit(renderTexture, renderTexture2, this.material, pass);
				if (this.settings.debugPass == SMAA.DebugPass.Weights)
				{
					Graphics.Blit(renderTexture2, destination);
				}
				else
				{
					this.material.SetTexture(this.m_BlendTex, renderTexture2);
					if (this.temporal.UseTemporal())
					{
						Graphics.Blit(source, renderTexture, this.material, pass2);
						if (this.settings.debugPass == SMAA.DebugPass.Accumulation)
						{
							Graphics.Blit(this.m_Accumulation, destination);
						}
						else if (!flag)
						{
							this.material.SetTexture(this.m_AccumulationTex, this.m_Accumulation);
							Graphics.Blit(renderTexture, destination, this.material, pass3);
						}
						else
						{
							Graphics.Blit(renderTexture, destination);
						}
						Graphics.Blit(destination, this.m_Accumulation);
						RenderTexture.active = null;
					}
					else
					{
						Graphics.Blit(source, destination, this.material, pass2);
					}
				}
				RenderTexture.ReleaseTemporary(renderTexture2);
			}
			RenderTexture.ReleaseTemporary(renderTexture);
			this.m_PreviousViewProjectionMatrix = matrix4x;
		}

		private RenderTexture TempRT(int width, int height, RenderTextureFormat format)
		{
			int depthBuffer = 0;
			return RenderTexture.GetTemporary(width, height, depthBuffer, format, RenderTextureReadWrite.Linear);
		}
	}
}
