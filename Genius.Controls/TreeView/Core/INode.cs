using System;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// état du noeud
	/// </summary>
	[Flags]
	public enum NodeState
	{
		/// <summary>
		/// visibilité
		/// </summary>
		Visible = 0x01,
		/// <summary>
		/// le noeud est étendu
		/// </summary>
		Expanded = 0x02,
		/// <summary>
		/// le noeud est coché
		/// </summary>
		Checked = 0x04,
		/// <summary>
		/// le noeud possède des enfants
		/// </summary>
		HasChildren = 0x08,
		/// <summary>
		/// le noeud est selectioné
		/// </summary>
		Selected    = 0x10,
		/// <summary>
		/// le noeud possède un case à coché
		/// </summary>
		HasCheck    = 0x20,
		/// <summary>
		/// le noeud est "signalé"
		/// </summary>
		Signaled = 0x40
	}

	/// <summary>
	/// interface de maniement d'un noeud
	/// </summary>
	public interface INode
	{
		/// <summary>
		/// Hauteur du noeud
		/// </summary>
		int Height {get; set;}
		/// <summary>
		/// index dans la liste de son père
		/// </summary>
		int Index {get;}
		/// <summary>
		/// l'index de l'image à utiliser lors du dessin, -1 pas d'image
		/// </summary>
		int ImageIndex {get; set;}
		/// <summary>
		/// index de l'image d'état
		/// </summary>
		int ImageStateIndex {get; set;}
		/// <summary>
		/// permet de stockée une donnée utilisateur, sur chaque noeud
		/// </summary>
		object Data {get; set;}
		/// <summary>
		/// Texte du noeud, dans le cas d'un affichage en mode grille, cette propriété représente 
		/// le texte de la colonne principale
		/// </summary>
		string Text {get; set;}
		/// <summary>
		/// état du noeud, <see cref="NodeState.Visible"/> et <see cref="NodeState.Selected"/> ne
		/// peuvent pas être modifié via cette propriété
		/// </summary>
		NodeState State {get; set;}
		/// <summary>
		/// renvoi true si le noeud est sélectionné
		/// </summary>
		bool IsSelected {get;}

		#region Navigation
		/// <summary>
		/// renvoi le premier enfant du noeud
		/// </summary>
		INode First {get;}
		/// <summary>
		/// renvoi le dernier enfant du noeud
		/// </summary>
		INode Last {get;}
		/// <summary>
		/// renvoi le prochain noeud visible
		/// </summary>
		INode NextVisible {get;}
		/// <summary>
		/// renvoi le noeud visible précédent
		/// </summary>
		INode PrevVisible {get;}
		/// <summary>
		/// renvoi le noeud frèere suivant
		/// </summary>
		INode NextSibling {get;}
		/// <summary>
		/// renvoi le noeud frère précédent
		/// </summary>
		INode PrevSibling {get;}
		/// <summary>
		/// renvoi le nombre d'enfant
		/// </summary>
		int Count {get;}
		/// <summary>
		/// renvoi le premier noeud dont la propriété <see cref="Text"/>, correspond au paramètre
		/// </summary>
		/// <param name="aText"></param>
		/// <returns></returns>
		INode Find(string aText);
		/// <summary>
		/// renvoi le premier noeud dont la data correspond au paramètre
		/// </summary>
		/// <param name="aData"></param>
		/// <returns></returns>
		INode Find(object aData);
		/// <summary>
		/// permet d'énumérer les noeuds enfants
		/// </summary>
		INodeEnumerable Enumerable {get;}

		/// <summary>
		/// renvoi le parent du noeud en cours
		/// </summary>
		INode Parent {get;}
		#endregion
		/// <summary>
		/// renvoi true si le noeud est étendu
		/// </summary>
		bool IsExpanded {get;}
		/// <summary>
		/// renvoi le niveau du noeud à partir de la racine
		/// </summary>
		int Level {get;}

		/// <summary>
		/// retourne true si le noeud est visible
		/// </summary>
		bool IsVisible {get;}

        /// <summary>
        /// retourne true si le noeud est coché, ne prend pas en compte l'état de ses enfant pour déterminer s'il est coché, pour cela voir
        /// </summary>
        bool IsChecked { get;}

		/// <summary>
		/// retourne le ième noeud enfant
		/// </summary>
		INode this[int index] { get; }
	}
}
