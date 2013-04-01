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
	public static class DrawingHelper
	{
		private static GraphicsPath CreateRoundRect(Rectangle aRect, int nWidth, int nHeight)
		{
			GraphicsPath path = new GraphicsPath();
            GraphicsPath tmpPath = path;
            try
            {
                path.AddArc(aRect.Left, aRect.Top, nWidth, nHeight, 180, 90);
                path.AddLine(nWidth, aRect.Top, aRect.Right - nWidth, aRect.Top);
                path.AddArc(aRect.Right - nWidth, aRect.Top, nWidth, nHeight, 270, 90);
                path.AddLine(aRect.Right, aRect.Top + nHeight, aRect.Right, aRect.Bottom - nHeight);
                path.AddArc(aRect.Right - nWidth, aRect.Bottom - nHeight, nWidth, nHeight, 0, 90);
                path.AddLine(aRect.Right - nWidth, aRect.Bottom, aRect.Left + nWidth, aRect.Bottom);
                path.AddArc(aRect.Left, aRect.Bottom - nHeight, nWidth, nHeight, 90, 90);
                path.CloseFigure();
                tmpPath = null;
            }
            finally
            {
                if (tmpPath != null)
                    tmpPath.Dispose();
            }
			return path;
		}

        //private static GraphicsPath RoundRectPath(Rectangle rc)
        //{
        //    rc.Height -= 1;
        //    rc.Width -= 1;
        //    GraphicsPath Result= new GraphicsPath();
        //    //je prend le plus petit coté pour calculé l'arrondi
        //    int h = (rc.Height <= rc.Width) ? rc.Height : rc.Width; 
        //    int h4 = Convert.ToInt32(h / 2);
        //    //int adjust = h4 % 2 == 0 ? 0 : 1;
        //    Result.AddLine(rc.Left + h4 / 2, rc.Top,  rc.Right - h4, rc.Top );
        //    Result.AddArc(rc.Right - h4, rc.Top,  h4, h4, 270, 90);		
        //    Result.AddLine(rc.Right, rc.Top + h4, rc.Right, rc.Bottom - h4);
        //    Result.AddArc(rc.Right-h4, rc.Bottom-h4,  h4, h4, 0, 90);
        //    Result.AddLine(rc.Right-h4, rc.Bottom, rc.Left+h4, rc.Bottom);
        //    Result.AddArc(rc.Left, rc.Bottom-h4,  h4, h4, 90, 90);
        //    Result.AddLine(rc.Left, rc.Bottom-h4, rc.Left, rc.Top+h4);
        //    Result.AddArc(rc.Left, rc.Top,  h4, h4, 180, 90);
        //    return Result;
        //}

		/// <summary>
		/// dessine un rectangle aux coins arrondis
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		/// <param name="rect"></param>
		public static void DrawRoundRect(Graphics graphics, Pen pen, Rectangle rect)
		{
			int h = (rect.Height <= rect.Width) ? rect.Height : rect.Width; 
			h /= 2;
			DrawRoundRect(graphics, pen, rect, h, h);
		}

		/// <summary>
		/// dessine un rectangle aux coins arrondis
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="pen"></param>
		/// <param name="rect"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public static void DrawRoundRect(Graphics graphics, Pen pen, Rectangle rect, int width, int height)
		{
			int h = (rect.Height <= rect.Width) ? rect.Height : rect.Width; 
			h /= 2;
			using (GraphicsPath path = CreateRoundRect(rect, width, height))
			{
				graphics.DrawPath(pen, path);
			}
		}
		/// <summary>
		/// rempli un rectangle aux coins arrondis
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="brush"></param>
		/// <param name="rect"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public static void FillRoundRect(Graphics graphics, Brush brush, Rectangle rect, int width, int height)
		{
			using (GraphicsPath path = CreateRoundRect(rect, width, height))
			{
				graphics.FillPath(brush, path);
			}
		}

		/// <summary>
		/// rempli un rectangle aux coins arrondis
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="brush"></param>
		/// <param name="rect"></param>
		public static void FillRoundRect(Graphics graphics, Brush brush, Rectangle rect)
		{
			int h = (rect.Height <= rect.Width) ? rect.Height : rect.Width; 
			h /= 2;
			using (GraphicsPath path = CreateRoundRect(rect, h, h))
			{
				graphics.FillPath(brush, path);
			}
		}

        public static TextFormatFlags StringFormatToTextFormatFlags(StringFormat format)
        {
            //TextFormatFlags.PreserveGraphicsClipping ralenti forcement un peu plus le dessin
            TextFormatFlags Result = TextFormatFlags.Default | TextFormatFlags.PreserveGraphicsClipping;
            //TextFormatFlags Result = TextFormatFlags.Default;
            switch (format.Alignment)
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
            switch (format.LineAlignment)
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

            switch (format.Trimming)
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
            if ((format.FormatFlags & StringFormatFlags.NoClip) == StringFormatFlags.NoClip)
                Result |= TextFormatFlags.NoClipping;
            if ((format.FormatFlags & StringFormatFlags.NoWrap) == StringFormatFlags.NoWrap)
                Result |= TextFormatFlags.SingleLine;
            if ((format.FormatFlags & StringFormatFlags.DirectionRightToLeft) == StringFormatFlags.DirectionRightToLeft)
                Result |= TextFormatFlags.RightToLeft;
            if ((format.FormatFlags & StringFormatFlags.DisplayFormatControl) == StringFormatFlags.DisplayFormatControl)
                Result |= TextFormatFlags.TextBoxControl;
            return Result;
        }

		#region Buttons et checkBox
		/// <summary>
		/// dessine une checkbox avec le theme windows
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="rect"></param>
		/// <param name="clip"></param>
		/// <param name="state"></param>
		public static void DrawCheckBox(Graphics graphics, Rectangle rect, Rectangle clip, CheckBoxState state)
		{
			IntPtr dc = graphics.GetHdc();
			try
			{
				DrawCheckBox(dc, rect, clip, state);
			}
			finally
			{
				graphics.ReleaseHdc(dc);
			}
		}

		/// <summary>
		/// dessine une checkbox avec le theme windows
		/// </summary>
		/// <param name="dc"></param>
		/// <param name="rect"></param>
		/// <param name="clip"></param>
		/// <param name="state"></param>
		public static void DrawCheckBox(IntPtr dc, Rectangle rect, Rectangle clip, CheckBoxState state)
		{
			RECT pRect = RECT.FromRectangle(rect);
			RECT pRectClip = RECT.FromRectangle(clip);
			NativeMethods.DrawThemeBackground(Themes.Theme("Button"), dc, (int)ButtonPart.BP_CHECKBOX, (int)state, ref pRect, ref pRectClip);
		}

		/// <summary>
		/// dessine un bouton avec le theme windows
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="rect"></param>
		/// <param name="clip"></param>
		/// <param name="state"></param>
		public static void DrawButton(Graphics graphics, Rectangle rect, Rectangle clip, PushButtonState state)
		{
			IntPtr dc = graphics.GetHdc();
			try
			{
				DrawButton(dc, rect, clip, state);
			}
			finally
			{
				graphics.ReleaseHdc(dc);
			}			
		}

		/// <summary>
		/// dessine un bouton avec le theme windows
		/// </summary>
		/// <param name="dc"></param>
		/// <param name="rect"></param>
		/// <param name="clip"></param>
		/// <param name="state"></param>
		public static void DrawButton(IntPtr dc, Rectangle rect, Rectangle clip, PushButtonState state)
		{
			RECT pRect = RECT.FromRectangle(rect);
			RECT pRectClip = RECT.FromRectangle(clip);
			IntPtr hTheme = Themes.Theme("BUTTON");
			NativeMethods.DrawThemeBackground(hTheme, dc, (int)ButtonPart.BP_PUSHBUTTON, (int)state, ref pRect, ref pRectClip);			
		}

		/// <summary>
		/// permet de dessiner le +/- d'un treeview avce le theme windows
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="rect"></param>
		/// <param name="clip"></param>
		/// <param name="state"></param>
		public static void DrawTreeviewButton(Graphics graphics, Rectangle rect, Rectangle clip, TreeViewGlyghState state)
		{
			IntPtr dc = graphics.GetHdc();
			try
			{
				DrawTreeviewButton(dc, rect, clip, state);
			}
			finally
			{
				graphics.ReleaseHdc(dc);
			}			
		}

		/// <summary>
		/// permet de dessiner le button d'un treeview en utilisant le theme windows
		/// </summary>
		/// <param name="dc">le Hdc </param>
		/// <param name="rect">le rectangle pour dessiner le bouton </param>
		/// <param name="clip"></param>
		/// <param name="state">l'état du bouton (+, -)</param>
		public static void DrawTreeviewButton(IntPtr dc, Rectangle rect, Rectangle clip, TreeViewGlyghState state)
		{
			RECT pRect = RECT.FromRectangle(rect);
			RECT pRectClip = RECT.FromRectangle(clip);
			IntPtr hTheme = Themes.Theme("TREEVIEW");
			NativeMethods.DrawThemeBackground(hTheme, dc, (int)TreeViewPart.TVP_GLYPH, (int)state, ref pRect, ref pRectClip);	
		}

		#endregion
	}
}
