namespace Genius.Controls.TreeView
{
	/// <summary>
	/// Position de la souris par rapport au noeud
	/// </summary>
	public enum MousePosition 
	{
        /// <summary>
        /// la souris est dans la zone cliente, mais pas sur un noeud
        /// </summary>
		Nowhere = 0x04,        // no node is involved (possible only if the tree is not as tall as the client area)
		OnItem = 0x08,         // on the bitmaps/buttons or label associated with an item
		OnItemButton = 0x10,   // on the button associated with an item
		OnItemCheckbox = 0x20, // on the checkbox if enabled
		OnItemIndent   = 0x40,   // in the indentation area in front of a node
		OnItemLabel   = 0x80,    // on the normal text area associated with an item
		OnItemLeft   =0x100,     // in the area to the left of a node's text area (e.g. when right aligned or centered)
		OnItemRight  =0x200,    // in the area to the right of a node's text area (e.g. if left aligned or centered)
		OnNormalIcon = 0x400,   // on the "normal" image
		OnStateIcon = 0x800,    // on the state image
		ToLeft      = 0x1000,         // to the left of the client area (if relative) or the absolute tree area
		ToRight     = 0x2000    // to the right of the client area (if relative) or the absolute tree area
	};
}
