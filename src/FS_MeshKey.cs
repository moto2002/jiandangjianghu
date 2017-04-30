using System;
using UnityEngine;

public class FS_MeshKey
{
	public bool isStatic;

	public Material mat;

	public FS_MeshKey(Material m, bool s)
	{
		this.isStatic = s;
		this.mat = m;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FS_MeshKey))
		{
			return false;
		}
		FS_MeshKey fS_MeshKey = (FS_MeshKey)obj;
		return fS_MeshKey.isStatic == this.isStatic && fS_MeshKey.mat == this.mat;
	}

	public override int GetHashCode()
	{
		return this.isStatic.GetHashCode() ^ this.mat.GetHashCode();
	}
}
