using System;
using System.Linq;
using UnityEngine;

public static class Spline
{
	public class Path
	{
		private Vector3[] _path;

		public Vector3[] path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = value;
			}
		}

		public int Length
		{
			get
			{
				return (this.path == null) ? 0 : this.path.Length;
			}
		}

		public Vector3 this[int index]
		{
			get
			{
				return this.path[index];
			}
		}

		public static implicit operator Spline.Path(Vector3[] path)
		{
			return new Spline.Path
			{
				path = path
			};
		}

		public static implicit operator Vector3[](Spline.Path p)
		{
			return (p == null) ? new Vector3[0] : p.path;
		}

		public static implicit operator Spline.Path(Transform[] path)
		{
			Spline.Path path2 = new Spline.Path();
			path2.path = (from p in path
			select p.position).ToArray<Vector3>();
			return path2;
		}

		public static implicit operator Spline.Path(GameObject[] path)
		{
			Spline.Path path2 = new Spline.Path();
			path2.path = (from p in path
			select p.transform.position).ToArray<Vector3>();
			return path2;
		}
	}

	public static Vector3 Interp(Spline.Path pts, float t, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		t = Easing.ease(easeType, t, 0f, 1f);
		if (pts.Length == 0)
		{
			return Vector3.zero;
		}
		if (pts.Length == 1)
		{
			return pts[0];
		}
		if (pts.Length == 2)
		{
			return Vector3.Lerp(pts[0], pts[1], t);
		}
		if (pts.Length == 3)
		{
			return QuadBez.Interp(pts[0], pts[2], pts[1], t);
		}
		if (pts.Length == 4)
		{
			return CubicBez.Interp(pts[0], pts[3], pts[1], pts[2], t);
		}
		return CRSpline.Interp(Spline.Wrap(pts), t);
	}

	public static Vector3 InterpConstantSpeed(Spline.Path pts, float t, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		t = Easing.ease(easeType, t, 0f, 1f);
		if (pts.Length == 0)
		{
			return Vector3.zero;
		}
		if (pts.Length == 1)
		{
			return pts[0];
		}
		if (pts.Length == 2)
		{
			return Vector3.Lerp(pts[0], pts[1], t);
		}
		if (pts.Length == 3)
		{
			return QuadBez.Interp(pts[0], pts[2], pts[1], t);
		}
		if (pts.Length == 4)
		{
			return CubicBez.Interp(pts[0], pts[3], pts[1], pts[2], t);
		}
		return CRSpline.InterpConstantSpeed(Spline.Wrap(pts), t);
	}

	public static Vector3 MoveOnPath(Spline.Path pts, Vector3 currentPosition, ref float pathPosition, float maxSpeed = 1f, float smoothnessFactor = 100f, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		maxSpeed *= Time.deltaTime;
		pathPosition = Mathf.Clamp01(pathPosition);
		Vector3 vector = Spline.Interp(pts, pathPosition, easeType);
		float magnitude;
		while ((magnitude = (vector - currentPosition).magnitude) <= maxSpeed && pathPosition < 1f)
		{
			currentPosition = vector;
			maxSpeed -= magnitude;
			pathPosition = Mathf.Clamp01(pathPosition + 1f / smoothnessFactor);
			vector = Spline.Interp(pts, pathPosition, easeType);
		}
		if (magnitude != 0f)
		{
			currentPosition = Vector3.MoveTowards(currentPosition, vector, maxSpeed);
		}
		return currentPosition;
	}

	public static Vector3 MoveOnPath(Spline.Path pts, Vector3 currentPosition, ref float pathPosition, ref Quaternion rotation, float maxSpeed = 1f, float smoothnessFactor = 100f, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		Vector3 vector = Spline.MoveOnPath(pts, currentPosition, ref pathPosition, maxSpeed, smoothnessFactor, easeType);
		rotation = ((!vector.Equals(currentPosition)) ? Quaternion.LookRotation(vector - currentPosition) : Quaternion.identity);
		return vector;
	}

	public static Quaternion RotationBetween(Spline.Path pts, float t1, float t2, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		return Quaternion.LookRotation(Spline.Interp(pts, t2, easeType) - Spline.Interp(pts, t1, easeType));
	}

	public static float PathLength(Spline.Path pts)
	{
		float num = 0f;
		Vector3 a = Spline.Interp(pts, 0f, Easing.EaseType.linear);
		int num2 = pts.Length * 20;
		for (int i = 1; i <= num2; i++)
		{
			float t = (float)i / (float)num2;
			Vector3 vector = Spline.Interp(pts, t, Easing.EaseType.linear);
			num += Vector3.Distance(a, vector);
			a = vector;
		}
		return num;
	}

	public static Vector3 Velocity(Spline.Path pts, float t, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		t = Easing.ease(easeType, t, 0f, 1f);
		if (pts.Length == 0)
		{
			return Vector3.zero;
		}
		if (pts.Length == 1)
		{
			return pts[0];
		}
		if (pts.Length == 2)
		{
			return Vector3.Lerp(pts[0], pts[1], t);
		}
		if (pts.Length == 3)
		{
			return QuadBez.Velocity(pts[0], pts[2], pts[1], t);
		}
		if (pts.Length == 4)
		{
			return CubicBez.Velocity(pts[0], pts[3], pts[1], pts[2], t);
		}
		return CRSpline.Velocity(Spline.Wrap(pts), t);
	}

	public static Vector3[] Wrap(Vector3[] path)
	{
		return new Vector3[]
		{
			path[0]
		}.Concat(path).Concat(new Vector3[]
		{
			path[path.Length - 1]
		}).ToArray<Vector3>();
	}

	public static void GizmoDraw(Vector3[] pts, float t, Easing.EaseType easeType = Easing.EaseType.linear)
	{
		Gizmos.color = Color.white;
		Vector3 to = Spline.Interp(pts, 0f, Easing.EaseType.linear);
		for (int i = 1; i <= 20; i++)
		{
			float t2 = (float)i / 20f;
			Vector3 vector = Spline.Interp(pts, t2, easeType);
			Gizmos.DrawLine(vector, to);
			to = vector;
		}
		Gizmos.color = Color.blue;
		Vector3 vector2 = Spline.Interp(pts, t, easeType);
		Gizmos.DrawLine(vector2, vector2 + Spline.Velocity(pts, t, easeType));
	}
}
