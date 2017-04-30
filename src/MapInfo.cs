using System;
using System.Collections;
using System.IO;
using System.Text;

public class MapInfo
{
	public static Hashtable mapInfo = new Hashtable();

	public static void LoadMap(string path)
	{
		MapInfo.mapInfo.Clear();
		using (FileStream fileStream = File.OpenRead(path))
		{
			using (BinaryReader binaryReader = new BinaryReader(fileStream, Encoding.UTF8))
			{
				MapInfo.mapInfo.Add("tilesize", binaryReader.ReadSingle());
				MapInfo.mapInfo.Add("maxfalldownheight", binaryReader.ReadSingle());
				MapInfo.mapInfo.Add("climblimit", binaryReader.ReadSingle());
				MapInfo.mapInfo.Add("mapstartpositionx", binaryReader.ReadSingle());
				MapInfo.mapInfo.Add("mapstartpositiony", binaryReader.ReadSingle());
				MapInfo.mapInfo.Add("mapendpositionx", binaryReader.ReadSingle());
				MapInfo.mapInfo.Add("mapendpositiony", binaryReader.ReadSingle());
				int num = binaryReader.ReadInt32();
				int num2 = binaryReader.ReadInt32();
				int i = binaryReader.ReadInt32();
				MapInfo.mapInfo.Add("mapheight", num);
				MapInfo.mapInfo.Add("mapwidth", num2);
				MapInfo.mapInfo.Add("totalnodes", i);
				ArrayList arrayList = new ArrayList();
				while (i > 0)
				{
					arrayList.Add(new Hashtable
					{
						{
							"yCoord",
							binaryReader.ReadSingle()
						},
						{
							"xCoord",
							binaryReader.ReadSingle()
						},
						{
							"zCoord",
							binaryReader.ReadSingle()
						},
						{
							"x",
							binaryReader.ReadInt32()
						},
						{
							"y",
							binaryReader.ReadInt32()
						},
						{
							"RID",
							binaryReader.ReadInt32()
						},
						{
							"walkable",
							binaryReader.ReadBoolean()
						}
					});
					i--;
				}
				MapInfo.mapInfo.Add("mapnodes", arrayList);
			}
		}
	}
}
