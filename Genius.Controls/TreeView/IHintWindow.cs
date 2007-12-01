namespace Genius.Controls.TreeView
{
	/// <summary>
	/// interface pour à implémenter pour personaliser le paint du hint.
	/// ou dérivez de la classe <see cref="Genius.Controls.NativeWindow.BaseHintWindow"/>
	/// </summary>
	public interface IHintWindow
	{
		/// <summary>
		/// le noeud en cours pour le hint
		/// </summary>
		INode Node {get; set;}
		/// <summary>
		/// la colonne en cours pour le hint
		/// </summary>
		int DisplayColumn {get; set;}
		/// <summary>
		/// le texte du hint
		/// </summary>
		string Text {get; set;}
		/// <summary>
		/// affichage du hint a la position x, y
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		void ShowHint(int x, int y);
		/// <summary>
		/// masque le fenêtre du hint
		/// </summary>
		void Hide();
		/// <summary>
		/// la fenêtre du hint est-elle visible
		/// </summary>
		bool IsVisible {get;}
	}
}
