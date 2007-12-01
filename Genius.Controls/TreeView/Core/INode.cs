using System;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// �tat du noeud
	/// </summary>
	[Flags]
	public enum NodeState
	{
		/// <summary>
		/// visibilit�
		/// </summary>
		Visible = 0x01,
		/// <summary>
		/// le noeud est �tendu
		/// </summary>
		Expanded = 0x02,
		/// <summary>
		/// le noeud est coch�
		/// </summary>
		Checked = 0x04,
		/// <summary>
		/// le noeud poss�de des enfants
		/// </summary>
		HasChildren = 0x08,
		/// <summary>
		/// le noeud est selection�
		/// </summary>
		Selected    = 0x10,
		/// <summary>
		/// le noeud poss�de un case � coch�
		/// </summary>
		HasCheck    = 0x20,
		/// <summary>
		/// le noeud est "signal�"
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
		/// index dans la liste de son p�re
		/// </summary>
		int Index {get;}
		/// <summary>
		/// l'index de l'image � utiliser lors du dessin, -1 pas d'image
		/// </summary>
		int ImageIndex {get; set;}
		/// <summary>
		/// index de l'image d'�tat
		/// </summary>
		int ImageStateIndex {get; set;}
		/// <summary>
		/// permet de stock�e une donn�e utilisateur, sur chaque noeud
		/// </summary>
		object Data {get; set;}
		/// <summary>
		/// Texte du noeud, dans le cas d'un affichage en mode grille, cette propri�t� repr�sente 
		/// le texte de la colonne principale
		/// </summary>
		string Text {get; set;}
		/// <summary>
		/// �tat du noeud, <see cref="NodeState.Visible"/> et <see cref="NodeState.Selected"/> ne
		/// peuvent pas �tre modifi� via cette propri�t�
		/// </summary>
		NodeState State {get; set;}
		/// <summary>
		/// renvoi true si le noeud est s�lectionn�
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
		/// renvoi le noeud visible pr�c�dent
		/// </summary>
		INode PrevVisible {get;}
		/// <summary>
		/// renvoi le noeud fr�ere suivant
		/// </summary>
		INode NextSibling {get;}
		/// <summary>
		/// renvoi le noeud fr�re pr�c�dent
		/// </summary>
		INode PrevSibling {get;}
		/// <summary>
		/// renvoi le nombre d'enfant
		/// </summary>
		int Count {get;}
		/// <summary>
		/// renvoi le premier noeud dont la propri�t� <see cref="Text"/>, correspond au param�tre
		/// </summary>
		/// <param name="aText"></param>
		/// <returns></returns>
		INode Find(string aText);
		/// <summary>
		/// renvoi le premier noeud dont la data correspond au param�tre
		/// </summary>
		/// <param name="aData"></param>
		/// <returns></returns>
		INode Find(object aData);
		/// <summary>
		/// permet d'�num�rer les noeuds enfants
		/// </summary>
		INodeEnumerable Enumerable {get;}

		/// <summary>
		/// renvoi le parent du noeud en cours
		/// </summary>
		INode Parent {get;}
		#endregion
		/// <summary>
		/// renvoi true si le noeud est �tendu
		/// </summary>
		bool IsExpanded {get;}
		/// <summary>
		/// renvoi le niveau du noeud � partir de la racine
		/// </summary>
		int Level {get;}

		/// <summary>
		/// retourne true si le noeud est visible
		/// </summary>
		bool IsVisible {get;}

        /// <summary>
        /// retourne true si le noeud est coch�, ne prend pas en compte l'�tat de ses enfant pour d�terminer s'il est coch�, pour cela voir
        /// </summary>
        bool IsChecked { get;}

		/// <summary>
		/// retourne le i�me noeud enfant
		/// </summary>
		INode this[int index] { get; }
	}
}
