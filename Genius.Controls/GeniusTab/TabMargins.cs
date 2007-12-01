using System;
using System.ComponentModel;

namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable, TypeConverter(typeof(TabMarginsConverter))]
	public struct TabMargins
	{
		private int FLeft;
		private int FTop;
		private int FRight;
		private int FBottom;

		/// <summary>
		/// 
		/// </summary>
		public static TabMargins Empty
		{
			get
			{
				return new TabMargins();
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Left
		{
			get
			{
				return FLeft;
			}
			set
			{
				FLeft = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Top
		{
			get
			{
				return FTop;
			}
			set
			{
				FTop = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Right
		{
			get
			{
				return FRight;
			}
			set
			{
				FRight = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Bottom
		{
			get
			{
				return FBottom;
			}
			set
			{
				FBottom = value;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="left"></param>
		/// <param name="top"></param>
		/// <param name="right"></param>
		/// <param name="bottom"></param>
		public TabMargins(int left, int top, int right, int bottom)
		{
			FLeft = left;
			FTop = top;
			FRight = right;
			FBottom = bottom;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj is TabMargins)
			{
				TabMargins other = (TabMargins)obj;
				return (other.Bottom == FBottom) && (other.Top == FTop) &&
					(other.Left == FLeft) && (other.Right == FRight);
			}
			return false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return Left ^ Top ^ Right ^ Bottom;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator !=(TabMargins left, TabMargins right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator ==(TabMargins left, TabMargins right)
		{
			return left.Equals(right);
		}
	}
}
