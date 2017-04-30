using System;
using UnityEngine;

public class DrawGrid : MonoBehaviour
{
	public GameObject gridEntity;

	public float Tilesize = 1f;

	public float MaxFalldownHeight = 1.5f;

	public float ClimbLimit = 0.8f;

	public float MapStartPositionX = -120f;

	public float MapStartPositionY = -66f;

	public float MapEndPositionX = 67f;

	public float MapEndPositionY = 73f;

	public Node[,] Map;

	public float HighestPoint = 100f;

	public float LowestPoint = -50f;

	public string[] DisallowedTags = new string[]
	{
		"Wall",
		"Water"
	};

	public string[] IgnoreTags = new string[]
	{
		"Player",
		"Enemy",
		"Npc",
		"Terrain"
	};

	public string OutputFilePath = string.Empty;
}
