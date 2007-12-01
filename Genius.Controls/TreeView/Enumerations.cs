using System;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// alignement des images dans le header
	/// </summary>
	public enum ImageAlignment
	{
		/// <summary>
		/// Aligné à gauche
		/// </summary>
		Left, 
		/// <summary>
		/// aligné e haut
		/// </summary>
		Top, 
		/// <summary>
		/// aligné à droite
		/// </summary>
		Right, 
		/// <summary>
		/// aligné en bas
		/// </summary>
		Bottom
	};

	/// <summary>
	/// alignement de l'image du tri
	/// </summary>
	public enum ImageSortAlignment
	{
		/// <summary>
		/// centré verticalement, aligné à gauche
		/// </summary>
		LeftCenter,
		/// <summary>
		/// centré verticalement, aligné à droite
		/// </summary>
		RightCenter,
		/// <summary>
		/// centré horizontalement, aligné en haut
		/// </summary>
		TopCenter,
		/// <summary>
		/// centré horizontalement, aligné en bas
		/// </summary>
		BottomCenter,
		/// <summary>
		/// coin en haut à gauche
		/// </summary>
		TopLeft,
		/// <summary>
		/// coin en haut à droite
		/// </summary>
		TopRight,
		/// <summary>
		/// coin en bas à gauche
		/// </summary>
		BottomLeft,
		/// <summary>
		/// coin en bas à droite
		/// </summary>
		BottomRight
	};
}
