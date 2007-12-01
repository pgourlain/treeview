using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Genius.Controls.VisualStyles
{
	/// <summary>
	/// Méthodes pour dessiner les avec les themes windows
	/// </summary>
	public sealed class Themes
	{
		private static IDictionary FThemes = new HybridDictionary();

		private Themes()
		{
		}

		/// <summary>
		/// récupère le handle d'un ThemeData
		/// </summary>
		/// <param name="aClassName">BUTTON, TREEVIEW, TOOLTIP, ... <a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/shellcc/platform/commctls/userex/topics/partsandstates.asp">msdn</a></param>
		/// <returns></returns>
		public static IntPtr Theme(string aClassName)
		{
			if (!FThemes.Contains(aClassName))
				FThemes.Add(aClassName, NativeMethods.OpenThemeData(IntPtr.Zero, aClassName));
				
			return (IntPtr)FThemes[aClassName];
		}		
	}
}
