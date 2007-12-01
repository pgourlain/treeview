using System;
using System.Windows.Forms;

namespace Genius.Controls.TreeView.Editors
{
	/// <summary>
	/// editeur ComboBoText
	/// </summary>
	public class ComboBoxEditor : GeniusTreeViewEditorBase
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="tv"></param>
		public ComboBoxEditor(GeniusTreeView tv) : base(tv)
		{
		}

		/// <summary>
		/// retourne le texte du combo
		/// </summary>
		public override object Value
		{
			get
			{
				return (FControl  as ComboBox).Text;
			}

		}

		/// <summary>
		/// création effective du control (Combobox)
		/// </summary>
		/// <returns></returns>
		protected override Control CreateEditorControl()
		{
			ComboBox cbx = new ComboBox();
			return cbx;
		}
	}
}
