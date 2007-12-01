using System.Drawing;
using System.Windows.Forms;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// Summary description for ITreeViewEdit.
	/// </summary>
	public interface ITreeViewEdit
	{
		/// <summary>
		/// demarrage de l'édition
		/// </summary>
		/// <param name="aNode">le noeud en cours d'édition</param>
		/// <param name="aCol">la colonne en cours d'édition</param>
		/// <param name="aRect">le rectangle d'édition</param>
		/// <param name="aValue">la valeur à éditer</param>
		void BeginEdit(INode aNode, int aCol, Rectangle aRect, object aValue);
		/// <summary>
		/// fin de l'édition
		/// </summary>
		void EndEdit();
		/// <summary>
		/// 
		/// </summary>
		void CancelEdit();
		/*
		/// <summary>
		/// l'implémentation de ITreeViewEDit, doit appeler cet event lors de l'appuie sur une touche
		/// car le TreeView gère le Escape et Enter
		/// </summary>
		event KeyEventHandler OnKeyDown;
		*/
		/// <summary>
		/// le rectangle d'édition
		/// </summary>
		Rectangle EditRect {get; set;}

		/// <summary>
		/// le control associé à l'édition
		/// </summary>
		Control Control {get;}

		/// <summary>
		/// valeur associé à l'édition
		/// </summary>
		object Value {get; set;}
	}
}
