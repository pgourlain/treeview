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
		/// le graphics � utiliser pour dessiner
		/// </summary>
		public Graphics graphics
		{
			get
			{
				return FGraphics;
			}
		}

		/// <summary>
		/// le retangle concern�
		/// </summary>
		public Rectangle Rect
		{
			get
			{
				return FRect;
			}
		}
		/// <summary>
		/// indique si le dessin par d�faut doit �tre fait
		/// </summary>
		public bool DefaultDrawing;
	}
}
