using System;
using ThirdParty;
using UnityEngine;

public class GMCommandParser
{
	public static void ParserWalkTo(string command)
	{
		string[] array = command.Split(new char[]
		{
			' '
		});
		if (array.Length == 2)
		{
			string[] array2 = array[1].TrimStart(new char[]
			{
				' '
			}).TrimEnd(new char[]
			{
				' '
			}).Split(new char[]
			{
				','
			});
			Vector3 dst = new Vector3(Convert.ToSingle(array2[0]), Convert.ToSingle(array2[1]), Convert.ToSingle(array2[2]));
			Singleton<RoleManager>.Instance.mainRole.move.WalkTo(dst, 0.1f, 0, null, false);
		}
		else if (array.Length == 3)
		{
			int toMap = Convert.ToInt32(array[1]);
			string[] array3 = array[2].TrimStart(new char[]
			{
				' '
			}).TrimEnd(new char[]
			{
				' '
			}).Split(new char[]
			{
				','
			});
			Vector3 vector = new Vector3((float)Convert.ToInt32(array3[0]), Convert.ToSingle(array3[1]), (float)Convert.ToInt32(array3[2]));
			Singleton<WorldPathfinding>.Instance.BeginWorldPathfinding(toMap, (int)vector.x, vector.y, (int)vector.z, 0.1f, delegate
			{
				Debug.Log("This is path finished callback");
			}, false);
		}
	}
}
