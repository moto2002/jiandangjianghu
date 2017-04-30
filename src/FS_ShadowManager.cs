using System;
using System.Collections;
using UnityEngine;

public class FS_ShadowManager : MonoBehaviour
{
	private static FS_ShadowManager _manager;

	private Hashtable shadowMeshes = new Hashtable();

	private Hashtable shadowMeshesStatic = new Hashtable();

	private int frameCalcedFustrum;

	private Plane[] fustrumPlanes;

	private void Start()
	{
	}

	private void OnApplicationQuit()
	{
		this.shadowMeshes.Clear();
		this.shadowMeshesStatic.Clear();
	}

	public static FS_ShadowManager Manager()
	{
		if (FS_ShadowManager._manager == null)
		{
			GameObject gameObject = new GameObject("FS_ShadowManager");
			FS_ShadowManager._manager = gameObject.AddComponent<FS_ShadowManager>();
		}
		return FS_ShadowManager._manager;
	}

	public void registerGeometry(FS_ShadowSimple s, FS_MeshKey meshKey)
	{
		FS_ShadowManagerMesh fS_ShadowManagerMesh;
		if (meshKey.isStatic)
		{
			if (!this.shadowMeshesStatic.ContainsKey(meshKey))
			{
				fS_ShadowManagerMesh = new GameObject("ShadowMeshStatic_" + meshKey.mat.name)
				{
					transform = 
					{
						parent = base.transform
					}
				}.AddComponent<FS_ShadowManagerMesh>();
				fS_ShadowManagerMesh.shadowMaterial = s.shadowMaterial;
				fS_ShadowManagerMesh.isStatic = true;
				this.shadowMeshesStatic.Add(meshKey, fS_ShadowManagerMesh);
			}
			else
			{
				fS_ShadowManagerMesh = (FS_ShadowManagerMesh)this.shadowMeshesStatic[meshKey];
			}
		}
		else if (!this.shadowMeshes.ContainsKey(meshKey))
		{
			fS_ShadowManagerMesh = new GameObject("ShadowMesh_" + meshKey.mat.name)
			{
				transform = 
				{
					parent = base.transform
				}
			}.AddComponent<FS_ShadowManagerMesh>();
			fS_ShadowManagerMesh.shadowMaterial = s.shadowMaterial;
			fS_ShadowManagerMesh.isStatic = false;
			this.shadowMeshes.Add(meshKey, fS_ShadowManagerMesh);
		}
		else
		{
			fS_ShadowManagerMesh = (FS_ShadowManagerMesh)this.shadowMeshes[meshKey];
		}
		fS_ShadowManagerMesh.registerGeometry(s);
	}

	public Plane[] getCameraFustrumPlanes()
	{
		if (Time.frameCount != this.frameCalcedFustrum || this.fustrumPlanes == null)
		{
			Camera main = Camera.main;
			if (main == null)
			{
				Debug.LogWarning("No main camera could be found for visibility culling.");
				this.fustrumPlanes = null;
			}
			else
			{
				this.fustrumPlanes = GeometryUtility.CalculateFrustumPlanes(main);
				this.frameCalcedFustrum = Time.frameCount;
			}
		}
		return this.fustrumPlanes;
	}
}
