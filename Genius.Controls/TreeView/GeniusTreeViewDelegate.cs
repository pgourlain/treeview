using System;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// delegate de base
	/// </summary>
	public delegate void OnNodeDelegate(GeniusTreeView Sender, NodeEventArgs e);

	/// <summary>
	/// delegate utiliser avec <see cref="GeniusTreeView.OnGetHint"/>
	/// </summary>
	public delegate void OnGetHintDelegate(GeniusTreeView Sender, NodeGetHintEventArgs e);

    /// <summary>
    /// événement soulevé lorsque l'utilisateur étend un noeud
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e"></param>
	public delegate void OnExpandDelegate(GeniusTreeView Sender, ExpandEventArgs e);
    /// <summary>
    /// événement soulevé lorsque l'utilisateur repli un noeud
    /// </summary>
    /// <param name="Sender"></param>
    /// <param name="e">information sur le noeud que l'utilisateur replie</param>
	public delegate void OnCollapseDelegate(GeniusTreeView sender, CollapseEventArgs e);
	public delegate void OnCheckDelegate(GeniusTreeView sender, CheckEventArgs e);
	public delegate void OnUnCheckDelegate(GeniusTreeView sender, UnCheckEventArgs e);

	public delegate void OnCanEditDelegate(GeniusTreeView sender, CanEditEventArgs e);
	public delegate void OnInitEditDelegate(GeniusTreeView sender, EditEventArgs e);
	public delegate void OnAfterEditDelegate(GeniusTreeView sender, EditEventArgs e);
	public delegate void OnSelectDelegate(GeniusTreeView sender, CanSelectEventArgs e);
	public delegate void OnUnSelectDelegate(GeniusTreeView Sender, CanUnSelectEventArgs e);
	public delegate void OnSelectedDelegate(GeniusTreeView sender, SelectedEventArgs e);
	public delegate void OnGetNodeTextDelegate(GeniusTreeView sender, NodeTextEventArgs e);
	
	/// <summary>
	/// delegate pour le custom paint
	/// </summary>
	public delegate void OnPaintNodeDelegate(GeniusTreeView Sender, PaintNodeEventArgs e);
	
	public delegate int OnCompareNodeDelegate(INode A, INode B, int aDisplayColumn);
	public delegate IComparable  OnGetNodeValueForComparisonDelegate(INode A, int aDisplayColumn);
	public delegate void OnDrawDragNodeDelegate(GeniusTreeView sender, DrawDragEventArgs e);
	public delegate void OnPrepareDragNodeDelegate(GeniusTreeView sender, PrepareDragEventArgs e);
	public delegate void OnCanDragToDelegate(GeniusTreeView sender, CanDragToEventArgs e);
	public delegate void OnCanDragDelegate(GeniusTreeView sender, CanDragEventArgs e);
	public delegate void OnDrawHeaderColDelegate(GeniusTreeView sender, DrawHeaderColEventArgs e);
	/// <summary>
	/// méthode délégée liée à la création d'un éditeur 
	/// </summary>
	public delegate void OnCreateEditorDelegate(GeniusTreeView sender, NodeEditorEventArgs e);

	/// <summary>
	/// déléguée liée a <see cref="GeniusTreeView.OnGetEditRect"/>
	/// </summary>
	public delegate void OnGetEditRectDelegate(GeniusTreeView sender, EditRectEventArgs e);

	/// <summary>
	/// méthode déléguée afin de recupérer l'index de l'image durant le paint <see cref="GeniusTreeView.OnGetImageIndex"/>
	/// </summary>
	public delegate void OnGetImageIndexDelegate(GeniusTreeView sender, NodeImageIndexEventArgs e);

	public delegate void OnBeforeDeleteDelegate(GeniusTreeView sender, NodeDeleteEventArgs e);

	public delegate void OnDrawingNodeTreeLinesDelegate(GeniusTreeView sender, NodeDrawingTreeLinesEventArgs e);

	/// <summary>
	/// déléguée pour la création des HintWindow
	/// </summary>
	public delegate void OnCreateHintWindowDelegate(GeniusTreeView sender, NodeHintWindowEventArgs e);

	/// <summary>
	/// déléguée pour le paint du footer
	/// </summary>
	public delegate void OnPaintFooterDelegate(GeniusTreeView sender, PaintFooterEventArgs e);
	/// <summary>
	/// déléguée pour la demande du texte
	/// </summary>
	public delegate void OnFooterGetTextDelegate(GeniusTreeView sender, FooterTextEventArgs e);
}
