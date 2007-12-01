using System;
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
		/// <param name="tv"></param>
		public DateTimeEditor(GeniusTreeView tv) : base(tv)
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
				(FControl as DateTimePicker).Value = Convert.ToDateTime(value);
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
