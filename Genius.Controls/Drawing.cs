using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Genius.Controls.VisualStyles;

namespace Genius.Controls
{
	/// <summary>
	/// encapsulation de méthodes de dessin n'existant pas dans le GDI+ du framework 1.1
	/// </summary>
	public sealed class Drawing
	{
		private Drawing() {}

		private static GraphicsPath CreateRoundRect(Rectangle aRect, int nWidth, int nHeight)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddArc(aRect.Left, aRect.Top, nWidth, nHeight, 180, 90);
			path.AddLine(nWidth, aRect.Top,  aRect.Right-nWidth,aRect.Top);
			path.AddArc(aRect.Right-nWidth, aRect.Top, nWidth, nHeight, 270, 90);
			path.AddLine(aRect.Right, aRect.Top+nHeight, aRect.Right, aRect.Bottom-nHeight);
			path.AddArc(aRect.Right-nWidth, aRect.Bottom-nHeight, nWidth, nHeight, 0, 90);
			path.AddLine(aRect.Right-nWidth, aRect.Bottom, aRect.Left+nWidth, aRect.Bottom);
			path.AddArc(aRect.Left, aRect.Bottom-nHeight, nWidth, nHeight, 90, 90);
			path.CloseFigure();
			return path;
		}

		private static GraphicsPath RoundRectPath(Rectangle rc)
		{
			rc.Height -= 1;
			rc.Width -= 1;
			GraphicsPath Result= new GraphicsPath();
			//je prend le plus petit coté pour calculé l'arrondi
			int h = (rc.Height <= rc.Width) ? rc.Height : rc.Width; 
			int h4 = Convert.ToInt32(h / 2);
			//int adjust = h4 % 2 == 0 ? 0 : 1;
			Result.AddLine(rc.Left + h4 / 2, rc.Top,  rc.Right - h4, rc.Top );
			Result.AddArc(rc.Right - h4, rc.Top,  h4, h4, 270, 90);		
			Result.AddLine(rc.Right, rc.Top + h4, rc.Right, rc.Bottom - h4);
			Result.AddArc(rc.Right-h4, rc.Bottom-h4,  h4, h4, 0, 90);
			Result.AddLine(rc.Right-h4, rc.Bottom, rc.Left+h4, rc.Bottom);
			Result.AddArc(rc.Left, rc.Bottom-h4,  h4, h4, 90, 90);
			Result.AddLine(rc.Left, rc.Bottom-h4, rc.Left, rc.Top+h4);
			Result.AddArc(rc.Left, rc.Top,  h4, h4, 180, 90);
			return Result;
		}

		/// <summary>
		/// dessine un rectangle aux coins arrondis
		/// </summary>
		/// <param name="g"></param>
		/// <param name="p"></param>
		/// <param name="rc"></param>
		public static void DrawRoundRect(Graphics g, Pen p, Rectangle rc)
		{
			int h = (rc.Height <= rc.Width) ? rc.Height : rc.Width; 
			h /= 2;
			DrawRoundRect(g, p, rc, h, h);
		}

		/// <summary>
		/// dessine un rectangle aux coins arrondis
		/// </summary>
		/// <param name="g"></param>
		/// <param name="p"></param>
		/// <param name="rc"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		public static void DrawRoundRect(Graphics g, Pen p, Rectangle rc, int nWidth, int nHeight)
		{
			int h = (rc.Height <= rc.Width) ? rc.Height : rc.Width; 
			h /= 2;
			using (GraphicsPath path = CreateRoundRect(rc, nWidth, nHeight))
			{
				g.DrawPath(p, path);
			}
		}
		/// <summary>
		/// rempli un rectangle aux coins arrondis
		/// </summary>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="rc"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		public static void FillRoundRect(Graphics g, Brush b, Rectangle rc, int nWidth, int nHeight)
		{
			using (GraphicsPath path = CreateRoundRect(rc, nWidth, nHeight))
			{
				g.FillPath(b, path);
			}
		}

		/// <summary>
		/// rempli un rectangle aux coins arrondis
		/// </summary>
		/// <param name="g"></param>
		/// <param name="b"></param>
		/// <param name="rc"></param>
		public static void FillRoundRect(Graphics g, Brush b, Rectangle rc)
		{
			int h = (rc.Height <= rc.Width) ? rc.Height : rc.Width; 
			h /= 2;
			using (GraphicsPath path = CreateRoundRect(rc, h, h))
			{
				g.FillPath(b, path);
			}
		}

        public static TextFormatFlags StringFormatToTextFormatFlags(StringFormat sf)
        {
            //TextFormatFlags.PreserveGraphicsClipping ralenti forcement un peu plus le dessin
            TextFormatFlags Result = TextFormatFlags.Default | TextFormatFlags.PreserveGraphicsClipping;
            //TextFormatFlags Result = TextFormatFlags.Default;
            switch (sf.Alignment)
            {
                case StringAlignment.Center:
                    Result |= TextFormatFlags.HorizontalCenter;
                    break;
                case StringAlignment.Near:
                    Result |= TextFormatFlags.Left;
                    break;
                case StringAlignment.Far:
                    Result |= TextFormatFlags.Right;
                    break;
            }
            switch (sf.LineAlignment)
            {
                case StringAlignment.Center:
                    Result |= TextFormatFlags.VerticalCenter;
                    break;
                case StringAlignment.Near:
                    Result |= TextFormatFlags.Top;
                    break;
                case StringAlignment.Far:
                    Result |= TextFormatFlags.Bottom;
                    break;
            }

            switch (sf.Trimming)
            {
                case StringTrimming.EllipsisWord:
                    Result |= TextFormatFlags.WordEllipsis;
                    break;
                case StringTrimming.EllipsisCharacter:
                    Result |= TextFormatFlags.EndEllipsis;
                    break;
                case StringTrimming.EllipsisPath:
                    Result |= TextFormatFlags.PathEllipsis;
                    break;
            }
            if ((sf.FormatFlags & StringFormatFlags.NoClip) == StringFormatFlags.NoClip)
                Result |= TextFormatFlags.NoClipping;
            if ((sf.FormatFlags & StringFormatFlags.NoWrap) == StringFormatFlags.NoWrap)
                Result |= TextFormatFlags.SingleLine;
            if ((sf.FormatFlags & StringFormatFlags.DirectionRightToLeft) == StringFormatFlags.DirectionRightToLeft)
                Result |= TextFormatFlags.RightToLeft;
            if ((sf.FormatFlags & StringFormatFlags.DisplayFormatControl) == StringFormatFlags.DisplayFormatControl)
                Result |= TextFormatFlags.TextBoxControl;
            return Result;
        }

		#region Buttons et checkBox
		/// <summary>
		/// dessine une checkbox avec le theme windows
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rc"></param>
		/// <param name="rClip"></param>
		/// <param name="state"></param>
		public static void DrawCheckBox(Graphics g, Rectangle rc, Rectangle rClip, CheckBoxState state)
		{
			IntPtr dc = g.GetHdc();
			try
			{
				DrawCheckBox(dc, rc, rClip, state);
			}
			finally
			{
				g.ReleaseHdc(dc);
			}
		}

		/// <summary>
		/// dessine une checkbox avec le theme windows
		/// </summary>
		/// <param name="dc"></param>
		/// <param name="rc"></param>
		/// <param name="rClip"></param>
		/// <param name="state"></param>
		public static void DrawCheckBox(IntPtr dc, Rectangle rc, Rectangle rClip, CheckBoxState state)
		{
			RECT pRect = RECT.FromRectangle(rc);
			RECT pRectClip = RECT.FromRectangle(rClip);
			NativeMethods.DrawThemeBackground(Themes.Theme("Button"), dc, (int)ButtonPart.BP_CHECKBOX, (int)state, ref pRect, ref pRectClip);
		}

		/// <summary>
		/// dessine un bouton avec le theme windows
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rc"></param>
		/// <param name="rClip"></param>
		/// <param name="state"></param>
		public static void DrawButton(Graphics g, Rectangle rc, Rectangle rClip, PushButtonState state)
		{
			IntPtr dc = g.GetHdc();
			try
			{
				DrawButton(dc, rc, rClip, state);
			}
			finally
			{
				g.ReleaseHdc(dc);
			}			
		}

		/// <summary>
		/// dessine un bouton avec le theme windows
		/// </summary>
		/// <param name="dc"></param>
		/// <param name="rc"></param>
		/// <param name="rClip"></param>
		/// <param name="state"></param>
		public static void DrawButton(IntPtr dc, Rectangle rc, Rectangle rClip, PushButtonState state)
		{
			RECT pRect = RECT.FromRectangle(rc);
			RECT pRectClip = RECT.FromRectangle(rClip);
			IntPtr hTheme = Themes.Theme("BUTTON");
			NativeMethods.DrawThemeBackground(hTheme, dc, (int)ButtonPart.BP_PUSHBUTTON, (int)state, ref pRect, ref pRectClip);			
		}

		/// <summary>
		/// permet de dessiner le +/- d'un treeview avce le theme windows
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rc"></param>
		/// <param name="rClip"></param>
		/// <param name="state"></param>
		public static void DrawTreeviewButton(Graphics g, Rectangle rc, Rectangle rClip, TreeViewGlyghState state)
		{
			IntPtr dc = g.GetHdc();
			try
			{
				DrawTreeviewButton(dc, rc, rClip, state);
			}
			finally
			{
				g.ReleaseHdc(dc);
			}			
		}

		/// <summary>
		/// permet de dessiner le button d'un treeview en utilisant le theme windows
		/// </summary>
		/// <param name="dc">le Hdc </param>
		/// <param name="rc">le rectangle pour dessiner le bouton </param>
		/// <param name="rClip"></param>
		/// <param name="state">l'état du bouton (+, -)</param>
		public static void DrawTreeviewButton(IntPtr dc, Rectangle rc, Rectangle rClip, TreeViewGlyghState state)
		{
			RECT pRect = RECT.FromRectangle(rc);
			RECT pRectClip = RECT.FromRectangle(rClip);
			IntPtr hTheme = Themes.Theme("TREEVIEW");
			NativeMethods.DrawThemeBackground(hTheme, dc, (int)TreeViewPart.TVP_GLYPH, (int)state, ref pRect, ref pRectClip);	
		}

		#endregion
	}
}
