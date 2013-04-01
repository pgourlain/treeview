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
    /// énumération de la position du noeud en cours de drag par rapport au noeud "drop"
    /// </summary>
    public enum DragPosition
    {
        /// <summary>
        /// null part
        /// </summary>
        None,
        /// <summary>
        /// avant le noeud indiqué dans l'évènement
        /// </summary>
        Before,
        /// <summary>
        /// après le noeud indiqué dans l'évènement
        /// </summary>
        After,
        /// <summary>
        /// en dessous du noeud indiqué dans l'évènement
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
        /// valeur par défaut
        /// </summary>
        None = 0

    };

    /// <summary>
    /// option pour la recherche incrémentale
    /// </summary>
    public enum IncrementalSearchOption
    {
        /// <summary>
        /// la recherche est désactivée
        /// </summary>
        None,
        /// <summary>
        /// recherche partout, même les noeuds repliées
        /// </summary>
        All,
        /// <summary>
        /// recherche seulement sur les noeuds visibles
        /// </summary>
        VisibleOnly
    };

    /// <summary>
    /// ou démarre la recherche incrémentale, <see cref="GeniusTreeView.SearchStart"/>
    /// </summary>
    public enum SearchStartOption
    {
        /// <summary>
        /// commence la recherche toujours au début
        /// </summary>
        AlwaysStartOver,
        /// <summary>
        /// commence la recherche depuis le dernier noeud trouvé
        /// </summary>
        LastHit,
        /// <summary>
        /// utilise le noeud sélectionné pour commencer la recherche
        /// </summary>
        FocusedNode
    };

    /// <summary>
    /// le sens de la recherche incrémentale, <see cref="GeniusTreeView.SearchDirection"/>
    /// pour changer de sens, utilisez la touche BackSpace
    /// </summary>
    public enum SearchDirectionOption
    {
        /// <summary>
        /// en avant
        /// </summary>
        Forward,
        /// <summary>
        /// en arrière
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
