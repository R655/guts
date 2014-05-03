//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public static class Vector2Extensions
	{
		public static Int2 ToInt2(this Vector2 vector2)
		{
			return new Int2
			(
				vector2.x,
				vector2.y
			);
		}
	}


	public struct Int2
	{
		public int x;
		public int y;

		public Int2 (int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Int2 (float x, float y)
		{
			this.x = Mathf.RoundToInt(x);
			this.y = Mathf.RoundToInt(y);
		}

		public static Int2 Zero
		{
			get
			{
				return new Int2(0, 0);
			}
		}

		public static Int2 operator -(Int2 a, Int2 b)
		{
			return new Int2(
					a.x - b.x,
					a.y - b.y
				);
		}

		public static Int2 operator +(Int2 a, Int2 b)
		{
			return new Int2(
				a.x + b.x,
				a.y + b.y
				);
		}

		public static Int2 operator *(Int2 a, int d)
		{
			return new Int2(
				a.x * d,
				a.y * d
				);
		}

		public static Int2 operator *(int d, Int2 a)
		{
			return new Int2(
				a.x * d,
				a.y * d
				);
		}

		public static Int2 operator /(Int2 a, int d)
		{
			return new Int2(
				a.x / d,
				a.y / d
				);
		}

		public static bool operator ==(Int2 a, Int2 b)
		{
			return (a.x == b.x && a.y == b.y);
		}

		public static bool operator !=(Int2 a, Int2 b)
		{
			return (a.x != b.x || a.y != b.y);
		}

		public static bool Equals(Int2 a, Int2 b)
		                          {
			return (a.x == b.x && a.y == b.y);
		}

		public static float Distance(Vector2 a, Vector2 b)
		{
			return Mathf.Sqrt(
					Mathf.Pow(a.x - b.x, 2f)
					+ Mathf.Pow(a.y - b.y, 2f)
				);
		}

		public override string ToString()
		{
			return "{"+x+", "+y+"}";
		}

		public int this[int i]
		{
			get{return (i == 0)? x : y;}
			set{
				if(i == 0)
					x = value;
				else
					y = value;
			}
		}

	}
}
