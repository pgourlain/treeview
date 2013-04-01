using System;
using System.Globalization;
using System.Windows.Forms;

namespace Genius.Controls.TreeView.Editors
{
	/// <summary>
	/// Editeur de Date via un <see cref="DateTimePicker"/>
	/// </summary>
	public class DateTimeEditor : GeniusTreeViewEditorBase
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="treeView"></param>
		public DateTimeEditor(GeniusTreeView treeView) : base(treeView)
		{
		}

		/// <summary>
		/// retourne la date Selectionner
		/// </summary>
		public override object Value
		{
			get
			{
				return (FControl as DateTimePicker).Value;
			}
			set
			{
				(FControl as DateTimePicker).Value = Convert.ToDateTime(value, CultureInfo.CurrentCulture);
			}
		}

		/// <summary>
		/// créer un <see cref="DateTimePicker"/>
		/// </summary>
		/// <returns></returns>
		protected override Control CreateEditorControl()
		{
			return new DateTimePicker();
		}
	}
}
