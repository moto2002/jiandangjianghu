using Pathfinding.Ionic.Zip;
using Pathfinding.Serialization.JsonFx;
using Pathfinding.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Pathfinding.Serialization
{
	public class AstarSerializer
	{
		private const string binaryExt = ".binary";

		private const string jsonExt = ".json";

		private AstarData data;

		public JsonWriterSettings writerSettings;

		public JsonReaderSettings readerSettings;

		private ZipFile zip;

		private MemoryStream zipStream;

		private GraphMeta meta;

		private SerializeSettings settings;

		private NavGraph[] graphs;

		private Dictionary<NavGraph, int> graphIndexInZip;

		private int graphIndexOffset;

		private uint checksum = 4294967295u;

		private UTF8Encoding encoding = new UTF8Encoding();

		private static StringBuilder _stringBuilder = new StringBuilder();

		public AstarSerializer(AstarData data)
		{
			this.data = data;
			this.settings = SerializeSettings.Settings;
		}

		public AstarSerializer(AstarData data, SerializeSettings settings)
		{
			this.data = data;
			this.settings = settings;
		}

		private static StringBuilder GetStringBuilder()
		{
			AstarSerializer._stringBuilder.Length = 0;
			return AstarSerializer._stringBuilder;
		}

		public void SetGraphIndexOffset(int offset)
		{
			this.graphIndexOffset = offset;
		}

		private void AddChecksum(byte[] bytes)
		{
			this.checksum = Checksum.GetChecksum(bytes, this.checksum);
		}

		public uint GetChecksum()
		{
			return this.checksum;
		}

		public void OpenSerialize()
		{
			this.zip = new ZipFile();
			this.zip.AlternateEncoding = Encoding.UTF8;
			this.zip.AlternateEncodingUsage = ZipOption.Always;
			this.writerSettings = new JsonWriterSettings();
			this.writerSettings.AddTypeConverter(new VectorConverter());
			this.writerSettings.AddTypeConverter(new BoundsConverter());
			this.writerSettings.AddTypeConverter(new LayerMaskConverter());
			this.writerSettings.AddTypeConverter(new MatrixConverter());
			this.writerSettings.AddTypeConverter(new GuidConverter());
			this.writerSettings.AddTypeConverter(new UnityObjectConverter());
			this.writerSettings.PrettyPrint = this.settings.prettyPrint;
			this.meta = new GraphMeta();
		}

		public byte[] CloseSerialize()
		{
			byte[] array = this.SerializeMeta();
			this.AddChecksum(array);
			this.zip.AddEntry("meta.json", array);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			foreach (ZipEntry current in this.zip.Entries)
			{
				current.AccessedTime = dateTime;
				current.CreationTime = dateTime;
				current.LastModified = dateTime;
				current.ModifiedTime = dateTime;
			}
			MemoryStream memoryStream = new MemoryStream();
			this.zip.Save(memoryStream);
			array = memoryStream.ToArray();
			memoryStream.Dispose();
			this.zip.Dispose();
			this.zip = null;
			return array;
		}

		public void SerializeGraphs(NavGraph[] _graphs)
		{
			if (this.graphs != null)
			{
				throw new InvalidOperationException("Cannot serialize graphs multiple times.");
			}
			this.graphs = _graphs;
			if (this.zip == null)
			{
				throw new NullReferenceException("You must not call CloseSerialize before a call to this function");
			}
			if (this.graphs == null)
			{
				this.graphs = new NavGraph[0];
			}
			for (int i = 0; i < this.graphs.Length; i++)
			{
				if (this.graphs[i] != null)
				{
					byte[] array = this.Serialize(this.graphs[i]);
					this.AddChecksum(array);
					this.zip.AddEntry("graph" + i + ".json", array);
				}
			}
		}

		private byte[] SerializeMeta()
		{
			if (this.graphs == null)
			{
				throw new Exception("No call to SerializeGraphs has been done");
			}
			this.meta.version = AstarPath.Version;
			this.meta.graphs = this.graphs.Length;
			this.meta.guids = new string[this.graphs.Length];
			this.meta.typeNames = new string[this.graphs.Length];
			this.meta.nodeCounts = new int[this.graphs.Length];
			for (int i = 0; i < this.graphs.Length; i++)
			{
				if (this.graphs[i] != null)
				{
					this.meta.guids[i] = this.graphs[i].guid.ToString();
					this.meta.typeNames[i] = this.graphs[i].GetType().FullName;
				}
			}
			StringBuilder stringBuilder = AstarSerializer.GetStringBuilder();
			JsonWriter jsonWriter = new JsonWriter(stringBuilder, this.writerSettings);
			jsonWriter.Write(this.meta);
			return this.encoding.GetBytes(stringBuilder.ToString());
		}

		public byte[] Serialize(NavGraph graph)
		{
			StringBuilder stringBuilder = AstarSerializer.GetStringBuilder();
			JsonWriter jsonWriter = new JsonWriter(stringBuilder, this.writerSettings);
			jsonWriter.Write(graph);
			return this.encoding.GetBytes(stringBuilder.ToString());
		}

		[Obsolete("Not used anymore. You can safely remove the call to this function.")]
		public void SerializeNodes()
		{
		}

		private static int GetMaxNodeIndexInAllGraphs(NavGraph[] graphs)
		{
			int maxIndex = 0;
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					graphs[i].GetNodes(delegate(GraphNode node)
					{
						maxIndex = Math.Max(node.NodeIndex, maxIndex);
						if (node.NodeIndex == -1)
						{
							Debug.LogError("Graph contains destroyed nodes. This is a bug.");
						}
						return true;
					});
				}
			}
			return maxIndex;
		}

		private static byte[] SerializeNodeIndices(NavGraph[] graphs)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter wr = new BinaryWriter(memoryStream);
			int maxNodeIndexInAllGraphs = AstarSerializer.GetMaxNodeIndexInAllGraphs(graphs);
			wr.Write(maxNodeIndexInAllGraphs);
			int maxNodeIndex2 = 0;
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] != null)
				{
					graphs[i].GetNodes(delegate(GraphNode node)
					{
						maxNodeIndex2 = Math.Max(node.NodeIndex, maxNodeIndex2);
						wr.Write(node.NodeIndex);
						return true;
					});
				}
			}
			if (maxNodeIndex2 != maxNodeIndexInAllGraphs)
			{
				throw new Exception("Some graphs are not consistent in their GetNodes calls, sequential calls give different results.");
			}
			byte[] result = memoryStream.ToArray();
			wr.Close();
			return result;
		}

		private static byte[] SerializeGraphExtraInfo(NavGraph graph)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			GraphSerializationContext ctx = new GraphSerializationContext(binaryWriter);
			graph.SerializeExtraInfo(ctx);
			byte[] result = memoryStream.ToArray();
			binaryWriter.Close();
			return result;
		}

		private static byte[] SerializeGraphNodeReferences(NavGraph graph)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			GraphSerializationContext ctx = new GraphSerializationContext(binaryWriter);
			graph.GetNodes(delegate(GraphNode node)
			{
				node.SerializeReferences(ctx);
				return true;
			});
			binaryWriter.Close();
			return memoryStream.ToArray();
		}

		public void SerializeExtraInfo()
		{
			if (!this.settings.nodes)
			{
				return;
			}
			if (this.graphs == null)
			{
				throw new InvalidOperationException("Cannot serialize extra info with no serialized graphs (call SerializeGraphs first)");
			}
			byte[] array = AstarSerializer.SerializeNodeIndices(this.graphs);
			this.AddChecksum(array);
			this.zip.AddEntry("graph_references.binary", array);
			for (int i = 0; i < this.graphs.Length; i++)
			{
				if (this.graphs[i] != null)
				{
					array = AstarSerializer.SerializeGraphExtraInfo(this.graphs[i]);
					this.AddChecksum(array);
					this.zip.AddEntry("graph" + i + "_extra.binary", array);
					array = AstarSerializer.SerializeGraphNodeReferences(this.graphs[i]);
					this.AddChecksum(array);
					this.zip.AddEntry("graph" + i + "_references.binary", array);
				}
			}
		}

		public void SerializeEditorSettings(GraphEditorBase[] editors)
		{
			if (editors == null || !this.settings.editorSettings)
			{
				return;
			}
			for (int i = 0; i < editors.Length; i++)
			{
				if (editors[i] == null)
				{
					return;
				}
				StringBuilder stringBuilder = AstarSerializer.GetStringBuilder();
				JsonWriter jsonWriter = new JsonWriter(stringBuilder, this.writerSettings);
				jsonWriter.Write(editors[i]);
				byte[] bytes = this.encoding.GetBytes(stringBuilder.ToString());
				if (bytes.Length > 2)
				{
					this.AddChecksum(bytes);
					this.zip.AddEntry("graph" + i + "_editor.json", bytes);
				}
			}
		}

		public bool OpenDeserialize(byte[] bytes)
		{
			this.readerSettings = new JsonReaderSettings();
			this.readerSettings.AddTypeConverter(new VectorConverter());
			this.readerSettings.AddTypeConverter(new BoundsConverter());
			this.readerSettings.AddTypeConverter(new LayerMaskConverter());
			this.readerSettings.AddTypeConverter(new MatrixConverter());
			this.readerSettings.AddTypeConverter(new GuidConverter());
			this.readerSettings.AddTypeConverter(new UnityObjectConverter());
			this.zipStream = new MemoryStream();
			this.zipStream.Write(bytes, 0, bytes.Length);
			this.zipStream.Position = 0L;
			try
			{
				this.zip = ZipFile.Read(this.zipStream);
			}
			catch (Exception arg)
			{
				Debug.LogError("Caught exception when loading from zip\n" + arg);
				this.zipStream.Dispose();
				return false;
			}
			this.meta = this.DeserializeMeta(this.zip["meta.json"]);
			if (AstarSerializer.FullyDefinedVersion(this.meta.version) > AstarSerializer.FullyDefinedVersion(AstarPath.Version))
			{
				Debug.LogWarning(string.Concat(new object[]
				{
					"Trying to load data from a newer version of the A* Pathfinding Project\nCurrent version: ",
					AstarPath.Version,
					" Data version: ",
					this.meta.version,
					"\nThis is usually fine as the stored data is usually backwards and forwards compatible.\nHowever node data (not settings) can get corrupted between versions (even though I try my best to keep compatibility), so it is recommended to recalculate any caches (those for faster startup) and resave any files. Even if it seems to load fine, it might cause subtle bugs.\n"
				}));
			}
			else if (AstarSerializer.FullyDefinedVersion(this.meta.version) < AstarSerializer.FullyDefinedVersion(AstarPath.Version))
			{
				Debug.LogWarning(string.Concat(new object[]
				{
					"Trying to load data from an older version of the A* Pathfinding Project\nCurrent version: ",
					AstarPath.Version,
					" Data version: ",
					this.meta.version,
					"\nThis is usually fine, it just means you have upgraded to a new version.\nHowever node data (not settings) can get corrupted between versions (even though I try my best to keep compatibility), so it is recommended to recalculate any caches (those for faster startup) and resave any files. Even if it seems to load fine, it might cause subtle bugs.\n"
				}));
			}
			return true;
		}

		private static Version FullyDefinedVersion(Version v)
		{
			return new Version(Mathf.Max(v.Major, 0), Mathf.Max(v.Minor, 0), Mathf.Max(v.Build, 0), Mathf.Max(v.Revision, 0));
		}

		public void CloseDeserialize()
		{
			this.zipStream.Dispose();
			this.zip.Dispose();
			this.zip = null;
			this.zipStream = null;
		}

		private NavGraph DeserializeGraph(int zipIndex, int graphIndex)
		{
			Type graphType = this.meta.GetGraphType(zipIndex);
			if (object.Equals(graphType, null))
			{
				return null;
			}
			ZipEntry zipEntry = this.zip["graph" + zipIndex + ".json"];
			if (zipEntry == null)
			{
				throw new FileNotFoundException(string.Concat(new object[]
				{
					"Could not find data for graph ",
					zipIndex,
					" in zip. Entry 'graph",
					zipIndex,
					".json' does not exist"
				}));
			}
			NavGraph navGraph = this.data.CreateGraph(graphType);
			navGraph.graphIndex = (uint)graphIndex;
			string @string = AstarSerializer.GetString(zipEntry);
			JsonReader jsonReader = new JsonReader(@string, this.readerSettings);
			jsonReader.PopulateObject<NavGraph>(ref navGraph);
			if (navGraph.guid.ToString() != this.meta.guids[zipIndex])
			{
				throw new Exception(string.Concat(new object[]
				{
					"Guid in graph file not equal to guid defined in meta file. Have you edited the data manually?\n",
					navGraph.guid,
					" != ",
					this.meta.guids[zipIndex]
				}));
			}
			return navGraph;
		}

		public NavGraph[] DeserializeGraphs()
		{
			List<NavGraph> list = new List<NavGraph>();
			this.graphIndexInZip = new Dictionary<NavGraph, int>();
			for (int i = 0; i < this.meta.graphs; i++)
			{
				int graphIndex = list.Count + this.graphIndexOffset;
				NavGraph navGraph = this.DeserializeGraph(i, graphIndex);
				if (navGraph != null)
				{
					list.Add(navGraph);
					this.graphIndexInZip[navGraph] = i;
				}
			}
			this.graphs = list.ToArray();
			return this.graphs;
		}

		private bool DeserializeExtraInfo(NavGraph graph)
		{
			int num = this.graphIndexInZip[graph];
			ZipEntry zipEntry = this.zip["graph" + num + "_extra.binary"];
			if (zipEntry == null)
			{
				return false;
			}
			BinaryReader binaryReader = AstarSerializer.GetBinaryReader(zipEntry);
			GraphSerializationContext ctx = new GraphSerializationContext(binaryReader, null, graph.graphIndex);
			graph.DeserializeExtraInfo(ctx);
			return true;
		}

		private bool AnyDestroyedNodesInGraphs()
		{
			bool result = false;
			for (int i = 0; i < this.graphs.Length; i++)
			{
				this.graphs[i].GetNodes(delegate(GraphNode node)
				{
					if (node.Destroyed)
					{
						result = true;
					}
					return true;
				});
			}
			return result;
		}

		private GraphNode[] DeserializeNodeReferenceMap()
		{
			ZipEntry zipEntry = this.zip["graph_references.binary"];
			if (zipEntry == null)
			{
				throw new Exception("Node references not found in the data. Was this loaded from an older version of the A* Pathfinding Project?");
			}
			BinaryReader reader = AstarSerializer.GetBinaryReader(zipEntry);
			int num = reader.ReadInt32();
			GraphNode[] int2Node = new GraphNode[num + 1];
			try
			{
				for (int i = 0; i < this.graphs.Length; i++)
				{
					this.graphs[i].GetNodes(delegate(GraphNode node)
					{
						int num2 = reader.ReadInt32();
						int2Node[num2] = node;
						return true;
					});
				}
			}
			catch (Exception innerException)
			{
				throw new Exception("Some graph(s) has thrown an exception during GetNodes, or some graph(s) have deserialized more or fewer nodes than were serialized", innerException);
			}
			if (reader.BaseStream.Position != reader.BaseStream.Length)
			{
				throw new Exception(string.Concat(new object[]
				{
					reader.BaseStream.Length / 4L,
					" nodes were serialized, but only data for ",
					reader.BaseStream.Position / 4L,
					" nodes was found. The data looks corrupt."
				}));
			}
			reader.Close();
			return int2Node;
		}

		private void DeserializeNodeReferences(NavGraph graph, GraphNode[] int2Node)
		{
			int num = this.graphIndexInZip[graph];
			ZipEntry zipEntry = this.zip["graph" + num + "_references.binary"];
			if (zipEntry == null)
			{
				throw new Exception("Node references for graph " + num + " not found in the data. Was this loaded from an older version of the A* Pathfinding Project?");
			}
			BinaryReader binaryReader = AstarSerializer.GetBinaryReader(zipEntry);
			GraphSerializationContext ctx = new GraphSerializationContext(binaryReader, int2Node, graph.graphIndex);
			graph.GetNodes(delegate(GraphNode node)
			{
				node.DeserializeReferences(ctx);
				return true;
			});
		}

		public void DeserializeExtraInfo()
		{
			bool flag = false;
			for (int i = 0; i < this.graphs.Length; i++)
			{
				flag |= this.DeserializeExtraInfo(this.graphs[i]);
			}
			if (!flag)
			{
				return;
			}
			if (this.AnyDestroyedNodesInGraphs())
			{
				Debug.LogError("Graph contains destroyed nodes. This is a bug.");
			}
			GraphNode[] int2Node = this.DeserializeNodeReferenceMap();
			for (int j = 0; j < this.graphs.Length; j++)
			{
				this.DeserializeNodeReferences(this.graphs[j], int2Node);
			}
		}

		public void PostDeserialization()
		{
			for (int i = 0; i < this.graphs.Length; i++)
			{
				this.graphs[i].PostDeserialization();
			}
		}

		public void DeserializeEditorSettings(GraphEditorBase[] graphEditors)
		{
			if (graphEditors == null)
			{
				return;
			}
			for (int i = 0; i < graphEditors.Length; i++)
			{
				if (graphEditors[i] != null)
				{
					for (int j = 0; j < this.graphs.Length; j++)
					{
						if (graphEditors[i].target == this.graphs[j])
						{
							int num = this.graphIndexInZip[this.graphs[j]];
							ZipEntry zipEntry = this.zip["graph" + num + "_editor.json"];
							if (zipEntry != null)
							{
								string @string = AstarSerializer.GetString(zipEntry);
								JsonReader jsonReader = new JsonReader(@string, this.readerSettings);
								GraphEditorBase graphEditorBase = graphEditors[i];
								jsonReader.PopulateObject<GraphEditorBase>(ref graphEditorBase);
								graphEditors[i] = graphEditorBase;
								break;
							}
						}
					}
				}
			}
		}

		private static BinaryReader GetBinaryReader(ZipEntry entry)
		{
			MemoryStream memoryStream = new MemoryStream();
			entry.Extract(memoryStream);
			memoryStream.Position = 0L;
			return new BinaryReader(memoryStream);
		}

		private static string GetString(ZipEntry entry)
		{
			MemoryStream memoryStream = new MemoryStream();
			entry.Extract(memoryStream);
			memoryStream.Position = 0L;
			StreamReader streamReader = new StreamReader(memoryStream);
			string result = streamReader.ReadToEnd();
			memoryStream.Position = 0L;
			streamReader.Dispose();
			return result;
		}

		private GraphMeta DeserializeMeta(ZipEntry entry)
		{
			if (entry == null)
			{
				throw new Exception("No metadata found in serialized data.");
			}
			string @string = AstarSerializer.GetString(entry);
			JsonReader jsonReader = new JsonReader(@string, this.readerSettings);
			return (GraphMeta)jsonReader.Deserialize(typeof(GraphMeta));
		}

		public static void SaveToFile(string path, byte[] data)
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Create))
			{
				fileStream.Write(data, 0, data.Length);
			}
		}

		public static byte[] LoadFromFile(string path)
		{
			byte[] result;
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				byte[] array = new byte[(int)fileStream.Length];
				fileStream.Read(array, 0, (int)fileStream.Length);
				result = array;
			}
			return result;
		}
	}
}
