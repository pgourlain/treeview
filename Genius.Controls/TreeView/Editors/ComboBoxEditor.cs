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
		/// constructeur par d�faut
		/// </summary>
		/// <param name="treeView"></param>
		public ComboBoxEditor(GeniusTreeView treeView) : base(treeView)
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
		/// cr�ation effective du control (Combobox)
		/// </summary>
		/// <returns></returns>
		protected override Control CreateEditorControl()
		{
			ComboBox cbx = new ComboBox();
			return cbx;
		}
	}
}
