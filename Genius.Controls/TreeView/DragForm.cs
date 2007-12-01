using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// classe fenêtre utilisée pour le drag-drop
	/// </summary>
	class DragForm : GeniusNativeWindow
	{
		private Image FBmp;
		private ImageAttributes FAttr;
		private ColorMatrix		FMatrix;
		private bool			FForbiden;
		public event OnDrawDragNodeDelegate OnDrawDrag;

		public DragForm(Image bmp, GeniusTreeView tv) : base(tv)
		{
			FBmp = bmp;
			FAttr = new ImageAttributes();
			FMatrix = new ColorMatrix();
			FMatrix.Matrix00 = 1.00f; // Red
			FMatrix.Matrix11 = 1.00f; // Green
			FMatrix.Matrix22 = 1.00f; // Blue
			//permet de rendre transparent le bitmap, par rapport à la couleur de fond
			//ainsi quand le drag est interdit le dessin est "rougeatre"
			FMatrix.Matrix33 = 0.5f; // alpha
			FMatrix.Matrix44 = 1.0f; // w
			FAttr.SetColorMatrix(FMatrix);
		}
	
		public override void Show(int x, int y)
		{
			Show(x, y, FBmp.Width, FBmp.Height, 170);
		}

		public bool Visible
		{
			get
			{
				return this.Handle != IntPtr.Zero;
			}
		}

		public bool Forbiden
		{
			get
			{
				return FForbiden;
			}
			set
			{
				if (value != FForbiden)
				{
					FForbiden = value;
					NativeMethods.InvalidateRect(this.Handle, new Rectangle(0,0,FBmp.Width, FBmp.Height), 0);
				}
			}
		}
		
		protected override void DoPaint(Graphics g)
		{
			Rectangle r = new Rectangle(0,0,FBmp.Width, FBmp.Height);
			bool defaultdrawing = true;
			if (OnDrawDrag != null)
			{
				DrawDragEventArgs e = new DrawDragEventArgs(g, r);
				e.Forbiden = Forbiden;
				OnDrawDrag(FTree, e);
			}
			if (defaultdrawing)
			{
				if (Forbiden)
				{
					g.FillRectangle(Brushes.Red, r);
					g.DrawImage(FBmp, r, 0,0,r.Width,r.Height, GraphicsUnit.Pixel,FAttr );
				}
				else
					g.DrawImage(FBmp, 0,0);
			}
		}

	}
}
