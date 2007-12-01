using System;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// alignement des images dans le header
	/// </summary>
	public enum ImageAlignment
	{
		/// <summary>
		/// Align� � gauche
		/// </summary>
		Left, 
		/// <summary>
		/// align� e haut
		/// </summary>
		Top, 
		/// <summary>
		/// align� � droite
		/// </summary>
		Right, 
		/// <summary>
		/// align� en bas
		/// </summary>
		Bottom
	};

	/// <summary>
	/// alignement de l'image du tri
	/// </summary>
	public enum ImageSortAlignment
	{
		/// <summary>
		/// centr� verticalement, align� � gauche
		/// </summary>
		LeftCenter,
		/// <summary>
		/// centr� verticalement, align� � droite
		/// </summary>
		RightCenter,
		/// <summary>
		/// centr� horizontalement, align� en haut
		/// </summary>
		TopCenter,
		/// <summary>
		/// centr� horizontalement, align� en bas
		/// </summary>
		BottomCenter,
		/// <summary>
		/// coin en haut � gauche
		/// </summary>
		TopLeft,
		/// <summary>
		/// coin en haut � droite
		/// </summary>
		TopRight,
		/// <summary>
		/// coin en bas � gauche
		/// </summary>
		BottomLeft,
		/// <summary>
		/// coin en bas � droite
		/// </summary>
		BottomRight
	};
}
