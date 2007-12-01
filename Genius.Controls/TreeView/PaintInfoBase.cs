using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// Summary description for PaintInfoBase.
	/// </summary>
	public class PaintInfoBase
	{
		internal Graphics FGraphics;
		internal Rectangle FClipRect;
		internal MouseButtons FButtons;
		internal Point FMousePosition;
        internal bool FTreeFocused;

		public PaintInfoBase()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// la column à dessiner
		/// </summary>
		public int DisplayColumn;
		/// <summary>
		/// le rectangle de clip
		/// </summary>
		public Rectangle ClipRect
		{
			get
			{
				return FClipRect;
			}
		}
		/// <summary>
		/// le canevas à utiliser pour dessiner
		/// </summary>
		public Graphics graphics
		{
			get
			{
				return FGraphics;
			}
		}
		
		public Point MousePosition
		{
			get
			{
				return FMousePosition;
			}
		}

		public MouseButtons Buttons
		{
			get
			{
				return FButtons;
			}
		}

        public bool TreeFocused
        {
            get
            {
                return FTreeFocused;
            }
        }
	}
}
