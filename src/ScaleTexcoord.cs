using System;
using UnityEngine;

[ExecuteInEditMode]
public class ScaleTexcoord : MonoBehaviour
{
	private float wr;

	private float hr;

	private float offX;

	private float offY;

	private UISprite s;

	public int maskRadius = 120;

	private void Awake()
	{
		this.s = base.GetComponent<UISprite>();
		this.wr = (float)this.maskRadius * 1f / (float)this.s.atlas.spriteMaterial.mainTexture.width;
		this.offX = (float)(this.s.GetAtlasSprite().x + (this.s.GetAtlasSprite().width - this.maskRadius) / 2) * 1f / (float)this.s.atlas.spriteMaterial.mainTexture.width;
		this.hr = (float)this.maskRadius * 1f / (float)this.s.atlas.spriteMaterial.mainTexture.height;
		this.offY = (float)(this.s.GetAtlasSprite().y + this.s.GetAtlasSprite().height - (this.s.GetAtlasSprite().height - this.maskRadius) / 2) * 1f / (float)this.s.atlas.spriteMaterial.mainTexture.height;
	}

	private void Start()
	{
		this.s.atlas.spriteMaterial.SetFloat("_WidthRate", this.wr);
		this.s.atlas.spriteMaterial.SetFloat("_HeightRate", this.hr);
		this.s.atlas.spriteMaterial.SetFloat("_XOffset", this.offX);
		this.s.atlas.spriteMaterial.SetFloat("_YOffset", this.offY);
	}

	public void Update()
	{
	}
}
