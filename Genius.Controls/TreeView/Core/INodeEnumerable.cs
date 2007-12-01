using System;
using System.Collections;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// interface d'�num�ration
	/// </summary>
	public interface INodeEnumerable
	{
		/// <summary>
		/// renvoi un <see cref="IEnumerable"/> sur l'ensemble des noeuds
		/// </summary>
		/// <returns></returns>
		IEnumerable GetNodes();
		/// <summary>
		/// renvoi l'ensemble des noeuds d'un niveau ou plus
		/// </summary>
		/// <param name="recurse"></param>
		/// <returns></returns>
		IEnumerable GetNodes(bool recurse);
		/// <summary>
		/// renvoi l'ensemble des noeuds visible d'un niveau ou plus
		/// </summary>
		/// <param name="recurse"></param>
		/// <returns></returns>
		IEnumerable GetVisibleNodes(bool recurse);

		/// <summary>
		/// renoiv le index "ieme" noeud
		/// </summary>
		INode this[int index] { get; }

		/// <summary>
		/// renvoi le nombre de noeuds du premier niveau
		/// </summary>
		int Count {get;}
	}
}