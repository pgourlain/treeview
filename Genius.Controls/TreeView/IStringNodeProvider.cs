
namespace Genius.Controls.TreeView
{
	/// <summary>
	/// interface à implémenter pour fournir le texte des colonnes.
	/// cette interface doit être implémenter par l'objet de <see cref="Genius.Controls.TreeView.Core.INode.Data"/>
	/// et activez la propriété <see cref="Genius.Controls.GeniusTreeView.DataIsStringProvider"/>
	/// </summary>
	public interface IStringNodeProvider
	{
		/// <summary>
		/// retourne le texte de la colonne concernée
		/// </summary>
		/// <param name="aDisplayColumn"></param>
		/// <returns></returns>
		string GetText(int aDisplayColumn);
	}
}
