using System;
using UnityEngine;

public class UvAnimator : MonoBehaviour
{
	public float tileX = 24f;

	public float tileY = 1f;

	public float fps = 10f;

	private void Update()
	{
		int num = (int)(Time.time * this.fps);
		num %= (int)(this.tileX * this.tileY);
		Vector2 scale = new Vector2(1f / this.tileX, 1f / this.tileY);
		int num2 = (int)((float)num % this.tileX);
		int num3 = (int)((float)num / this.tileX);
		Vector2 offset = new Vector2((float)num2 * scale.x, (float)num3 * scale.y);
		base.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
		base.GetComponent<Renderer>().material.SetTextureScale("_MainTex", scale);
	}
}
