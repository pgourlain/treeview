using System;
using System.Drawing;

namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// Summary description for DrawTabEventArgs.
	/// </summary>
	public class DrawTabEventArgs : EventArgs
	{
		private Graphics FGraphics;
		private Rectangle FRect;

		internal DrawTabEventArgs(Graphics g, Rectangle r )
		{
			FGraphics = g;
			FRect = r;
			DefaultDrawing = true;
		}

		/// <summary>
		/// le graphics à utiliser pour dessiner
		/// </summary>
		public Graphics graphics
		{
			get
			{
				return FGraphics;
			}
		}

		/// <summary>
		/// le retangle concerné
		/// </summary>
		public Rectangle Rect
		{
			get
			{
				return FRect;
			}
		}
		/// <summary>
		/// indique si le dessin par défaut doit être fait
		/// </summary>
		public bool DefaultDrawing;
	}
}
