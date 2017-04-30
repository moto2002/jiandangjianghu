using System;
using UnityEngine;

public class CommonTools
{
	public static Color ConvertStringToColor(string colorStr)
	{
		if (colorStr.Length != 9)
		{
			Debug.LogWarning("颜色码位数不对");
			return Color.white;
		}
		float num = (float)Convert.ToInt32(colorStr.Substring(1, 2), 16);
		float num2 = (float)Convert.ToInt32(colorStr.Substring(3, 2), 16);
		float num3 = (float)Convert.ToInt32(colorStr.Substring(5, 2), 16);
		float num4 = (float)Convert.ToInt32(colorStr.Substring(7, 2), 16);
		return new Color(num / 255f, num2 / 255f, num3 / 255f, num4 / 255f);
	}

	public static int GetPlayerShape(int shape, int setno, int fashion)
	{
		if (shape == 2010019)
		{
			return shape;
		}
		if (fashion != 0)
		{
			return fashion;
		}
		if (setno != 0)
		{
		}
		return shape;
	}

	public static void SetGameObjectSortOrder(GameObject go, int order)
	{
		if (go == null)
		{
			return;
		}
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
		Renderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Renderer renderer = array[i];
			renderer.sortingOrder = order;
		}
	}
}
