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

    [Flags]
    enum TreeStateEnum
    {
        DragPending = 0x04,
        Dragging = 0x08,
        EditPending = 0x10,
        IncrementalSearchPending = 0x01,
        IncrementalSearching = 0x02
    }

    /// <summary>
    /// �num�ration de la position du noeud en cours de drag par rapport au noeud "drop"
    /// </summary>
    public enum DragPosition
    {
        /// <summary>
        /// null part
        /// </summary>
        None,
        /// <summary>
        /// avant le noeud indiqu� dans l'�v�nement
        /// </summary>
        Before,
        /// <summary>
        /// apr�s le noeud indiqu� dans l'�v�nement
        /// </summary>
        After,
        /// <summary>
        /// en dessous du noeud indiqu� dans l'�v�nement
        /// </summary>
        Under
    }

    /// <summary>
    /// option de dessin
    /// </summary>
    [Flags]
    public enum DrawingOptions
    {
        /// <summary>
        /// cache la selection, si le treeview n'a pas le focus
        /// </summary>
        HideSelection = 0x01,
        /// <summary>
        /// cache le focusrect
        /// </summary>
        HideFocusRect = 0x02,
        /// <summary>
        /// cache les "boutons" deplier/replier
        /// </summary>
        HideButtons = 0x04,
        /// <summary>
        /// cache les lignes du treeview
        /// </summary>
        HideTreeLines = 0x08,
        /// <summary>
        /// affiche les lignes verticales en mode grille
        /// </summary>
        ShowVertLines = 0x10,
        /// <summary>
        /// affiche les lignes horizontales en mode grille
        /// </summary>
        ShowHorzLines = 0x20,
        /// <summary>
        /// Combinaison de <see cref="ShowVertLines"/> et <see cref="ShowHorzLines"/>
        /// </summary>
        ShowGridLines = DrawingOptions.ShowHorzLines | DrawingOptions.ShowVertLines,
        /// <summary>
        /// ne dessine jamais la selection
        /// </summary>
        AlwaysHideSelection = 0x40,
        /// <summary>
        /// valeur par d�faut
        /// </summary>
        None = 0

    };

    /// <summary>
    /// option pour la recherche incr�mentale
    /// </summary>
    public enum IncrementalSearchOption
    {
        /// <summary>
        /// la recherche est d�sactiv�e
        /// </summary>
        None,
        /// <summary>
        /// recherche partout, m�me les noeuds repli�es
        /// </summary>
        All,
        /// <summary>
        /// recherche seulement sur les noeuds visibles
        /// </summary>
        VisibleOnly
    };

    /// <summary>
    /// ou d�marre la recherche incr�mentale, <see cref="GeniusTreeView.SearchStart"/>
    /// </summary>
    public enum SearchStartOption
    {
        /// <summary>
        /// commence la recherche toujours au d�but
        /// </summary>
        AlwaysStartOver,
        /// <summary>
        /// commence la recherche depuis le dernier noeud trouv�
        /// </summary>
        LastHit,
        /// <summary>
        /// utilise le noeud s�lectionn� pour commencer la recherche
        /// </summary>
        FocusedNode
    };

    /// <summary>
    /// le sens de la recherche incr�mentale, <see cref="GeniusTreeView.SearchDirection"/>
    /// pour changer de sens, utilisez la touche BackSpace
    /// </summary>
    public enum SearchDirectionOption
    {
        /// <summary>
        /// en avant
        /// </summary>
        Forward,
        /// <summary>
        /// en arri�re
        /// </summary>
        Backward
    };


    /// <summary>
    /// direction du tri
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// pas de sens 
        /// </summary>
        None,
        /// <summary>
        /// tri ascendant
        /// </summary>
        Ascending,
        /// <summary>
        /// tri descendant
        /// </summary>
        Descending
    }
}
