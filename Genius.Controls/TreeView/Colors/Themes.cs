using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Genius.Controls.TreeView.Colors
{
	/// <summary>
	/// Summary description for Themes.
	/// </summary>
	public class Themes
	{
		private Themes()
		{
		}

		/// <summary>
		/// Thème Genius 
		/// </summary>
		/// <param name="aColors"></param>
		public static void GeniusTreeViewTheme(GenuisTreeViewColors aColors)
		{
			aColors.SelectedTextColor = aColors.TextColor;
			aColors.SelectedUnfocusedColor= new GeniusLinearGradientBrush(Color.FromArgb(225, 230, 232));
			aColors.SelectedColor = new GeniusLinearGradientBrush(Color.FromArgb(193, 210, 238));
			aColors.UnFocusedRectanglePenColor = new GeniusPen(Color.FromArgb(152,181,226), 1, DashStyle.Solid);
			aColors.FocusedRectanglePenColor = new GeniusPen(Color.FromArgb(49, 106, 197), 1, DashStyle.Solid);
		}
	}
}
