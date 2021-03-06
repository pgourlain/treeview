using System;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Genius.Controls.VisualStyles
{
	/// <summary>
	/// M�thodes pour dessiner les avec les themes windows
	/// </summary>
	public sealed class Themes
	{
		private static IDictionary FThemes = new HybridDictionary();

		private Themes()
		{
		}

		/// <summary>
		/// r�cup�re le handle d'un ThemeData
		/// </summary>
		/// <param name="className">BUTTON, TREEVIEW, TOOLTIP, ... <a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/shellcc/platform/commctls/userex/topics/partsandstates.asp">msdn</a></param>
		/// <returns></returns>
		public static IntPtr Theme(string className)
		{
			if (!FThemes.Contains(className))
				FThemes.Add(className, NativeMethods.OpenThemeData(IntPtr.Zero, className));
				
			return (IntPtr)FThemes[className];
		}		
	}
}
