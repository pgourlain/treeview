using System;

namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// Summary description for TabChangeEventArgs.
	/// </summary>
	public class TabChangeEventArgs : EventArgs
	{
		private int FSrc;
		private int FDst;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="aTabSrc"></param>
		/// <param name="aTabDest"></param>
		public TabChangeEventArgs(int aTabSrc, int aTabDest)
		{
			FSrc = aTabSrc;
			FDst = aTabDest;
		}

		/// <summary>
		/// 
		/// </summary>
		public int From
		{
			get
			{
				return FSrc;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int To
		{
			get
			{
				return FDst;
			}
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class TabBeforeChangeEventArgs : TabChangeEventArgs
	{
		private bool FAllow;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="aTabSrc"></param>
		/// <param name="aTabDest"></param>
		public TabBeforeChangeEventArgs(int aTabSrc, int aTabDest) : base (aTabSrc, aTabDest)
		{
			FAllow = true;
		}

		/// <summary>
		/// 
		/// </summary>
		public bool Allow
		{
			get
			{
				return FAllow;
			}
			set
			{
				FAllow = value;
			}
		}
	}
}
