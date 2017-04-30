using Pathfinding.Util;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	public static class PathPool
	{
		private static readonly Dictionary<Type, Stack<Path>> pool = new Dictionary<Type, Stack<Path>>();

		private static readonly Dictionary<Type, int> totalCreated = new Dictionary<Type, int>();

		public static void Pool(Path path)
		{
			Dictionary<Type, Stack<Path>> obj = PathPool.pool;
			lock (obj)
			{
				if (path.pooled)
				{
					throw new ArgumentException("The path is already pooled.");
				}
				Stack<Path> stack;
				if (!PathPool.pool.TryGetValue(path.GetType(), out stack))
				{
					stack = new Stack<Path>();
					PathPool.pool[path.GetType()] = stack;
				}
				path.pooled = true;
				path.OnEnterPool();
				stack.Push(path);
			}
		}

		public static int GetTotalCreated(Type type)
		{
			int result;
			if (PathPool.totalCreated.TryGetValue(type, out result))
			{
				return result;
			}
			return 0;
		}

		public static int GetSize(Type type)
		{
			Stack<Path> stack;
			if (PathPool.pool.TryGetValue(type, out stack))
			{
				return stack.Count;
			}
			return 0;
		}

		public static T GetPath<T>() where T : Path, new()
		{
			Dictionary<Type, Stack<Path>> obj = PathPool.pool;
			T result;
			lock (obj)
			{
				Stack<Path> stack;
				T t;
				if (PathPool.pool.TryGetValue(typeof(T), out stack) && stack.Count > 0)
				{
					t = (stack.Pop() as T);
				}
				else
				{
					t = Activator.CreateInstance<T>();
					if (!PathPool.totalCreated.ContainsKey(typeof(T)))
					{
						PathPool.totalCreated[typeof(T)] = 0;
					}
					Dictionary<Type, int> dictionary;
					Dictionary<Type, int> expr_82 = dictionary = PathPool.totalCreated;
					Type typeFromHandle;
					Type expr_8E = typeFromHandle = typeof(T);
					int num = dictionary[typeFromHandle];
					expr_82[expr_8E] = num + 1;
				}
				t.pooled = false;
				t.Reset();
				result = t;
			}
			return result;
		}
	}
	[Obsolete("Genric version is now obsolete to trade an extremely tiny performance decrease for a large decrease in boilerplate for Path classes")]
	public static class PathPool<T> where T : Path, new()
	{
		public static void Recycle(T path)
		{
			PathPool.Pool(path);
		}

		public static void Warmup(int count, int length)
		{
			ListPool<GraphNode>.Warmup(count, length);
			ListPool<Vector3>.Warmup(count, length);
			Path[] array = new Path[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = PathPool<T>.GetPath();
				array[i].Claim(array);
			}
			for (int j = 0; j < count; j++)
			{
				array[j].Release(array, false);
			}
		}

		public static int GetTotalCreated()
		{
			return PathPool.GetTotalCreated(typeof(T));
		}

		public static int GetSize()
		{
			return PathPool.GetSize(typeof(T));
		}

		[Obsolete("Use PathPool.GetPath<T> instead of PathPool<T>.GetPath")]
		public static T GetPath()
		{
			return PathPool.GetPath<T>();
		}
	}
}
