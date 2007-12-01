
namespace Genius.Controls.TreeView
{
	/// <summary>
	/// interface � impl�menter pour fournir le texte des colonnes.
	/// cette interface doit �tre impl�menter par l'objet de <see cref="Genius.Controls.TreeView.Core.INode.Data"/>
	/// et activez la propri�t� <see cref="Genius.Controls.GeniusTreeView.DataIsStringProvider"/>
	/// </summary>
	public interface IStringNodeProvider
	{
		/// <summary>
		/// retourne le texte de la colonne concern�e
		/// </summary>
		/// <param name="aDisplayColumn"></param>
		/// <returns></returns>
		string GetText(int aDisplayColumn);
	}
}
