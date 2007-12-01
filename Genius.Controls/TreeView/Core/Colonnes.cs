using System;
using System.Collections;

namespace Genius.Controls.TreeView.Core
{
	/// <summary>
	/// Collections des colonnes
	/// </summary>
	public class Colonnes : CollectionBase
	{
		private GeniusHeader FOwner;
		internal ArrayList		FDisplays;

		/// <summary>
		/// constructeur par défaut, mais vous n'avez pas besoin de 
		/// de créer cette collections
		/// </summary>
		/// <param name="aOwner"></param>
		public Colonnes(GeniusHeader aOwner)
		{
			FOwner = aOwner;
			FDisplays = new ArrayList();
		}

		/// <summary>
		/// renvoi une instance de <see cref="GeniusTreeViewColonne"/> à l'index index
		/// </summary>
		public GeniusTreeViewColonne this[int index]
		{
			get
			{
				return (GeniusTreeViewColonne)List[index];
			}
			set
			{
				List[index] = value;
			}
		}

		/// <summary>
		/// renvoi l'index d'un colonne
		/// </summary>
		/// <param name="aCol">la colonne dont on désire l'index</param>
		/// <returns></returns>
		public int IndexOf(GeniusTreeViewColonne aCol)
		{
			return List.IndexOf(aCol);
		}

		/// <summary>
		/// ajout d'une colonne, mais passé plutôt par <see cref="GeniusHeader.Add"/>
		/// </summary>
		/// <param name="aCol"></param>
		/// <returns>la position dans la liste</returns>
		public int Add(GeniusTreeViewColonne aCol)
		{
			return this.List.Add(aCol);
		}

		/// <summary>
		/// ajoute une liste de colonnes
		/// </summary>
		/// <param name="actions"></param>
		public void AddRange(GeniusTreeViewColonne[] actions)
		{
			foreach (GeniusTreeViewColonne a in actions)
			{
				a.Owner = FOwner;
				List.Add(a);
			}
			if (FOwner != null)
			{
				FOwner.MainColumnIndex = FOwner.MainColumnIndex;
				FOwner.RecalcLastColWidth();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void OnClear()
		{
			FDisplays.Clear();
			base.OnClear ();
		}

		private void AddDisplay(GeniusTreeViewColonne aCol)
		{
			if (aCol.Text == null || aCol.Text.Length == 0)
				aCol.Text = "Colonne " + List.Count.ToString();
			FDisplays.Add(aCol);
		}

		private void CheckType(object value)
		{
			if (!(value is GeniusTreeViewColonne))
				throw new ArgumentException("Type de l'argument invalide !");			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnInsert(int index, object value)
		{
			(value as GeniusTreeViewColonne).Owner = FOwner;
			base.OnInsert (index, value);
			AddDisplay(value as GeniusTreeViewColonne);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete (index, value);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="oldValue"></param>
		/// <param name="newValue"></param>
		protected override void OnSet(int index, object oldValue, object newValue)
		{
			(newValue as GeniusTreeViewColonne).Owner = FOwner;
			base.OnSet (index, oldValue, newValue);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete (index, value);
			FDisplays.Remove(value);
		}
	}
}
