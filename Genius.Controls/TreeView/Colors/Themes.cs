using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Genius.Controls.TreeView.Colors
{
	/// <summary>
	/// Summary description for Themes.
	/// </summary>
	public static class Themes
	{
		/// <summary>
		/// Thème Genius 
		/// </summary>
		/// <param name="colors"></param>
		public static void GeniusTreeViewTheme(GenuisTreeViewColors colors)
		{
            if (colors == null)
                throw new ArgumentNullException("colors");
			colors.SelectedTextColor = colors.TextColor;
			colors.SelectedUnfocusedColor= new GeniusLinearGradientBrush(Color.FromArgb(225, 230, 232));
			colors.SelectedColor = new GeniusLinearGradientBrush(Color.FromArgb(193, 210, 238));
			colors.UnFocusedRectanglePenColor = new GeniusPen(Color.FromArgb(152,181,226), 1, DashStyle.Solid);
			colors.FocusedRectanglePenColor = new GeniusPen(Color.FromArgb(49, 106, 197), 1, DashStyle.Solid);
		}
	}
}
