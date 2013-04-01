using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Genius.Controls.TreeView.Core
{
	/// <summary>
	/// Collections des colonnes
	/// </summary>
	public class GeniusTreeViewColumnCollection : System.Collections.ObjectModel.Collection<GeniusTreeViewColonne>
	{
		private GeniusHeader FOwner;
        internal List<GeniusTreeViewColonne> FDisplays;

		/// <summary>
		/// constructeur par défaut, mais vous n'avez pas besoin de 
		/// de créer cette collections
		/// </summary>
		/// <param name="owner"></param>
		public GeniusTreeViewColumnCollection(GeniusHeader owner)
		{
			FOwner = owner;
            FDisplays = new List<GeniusTreeViewColonne>();
		}

        //// Provide the explicit interface member for ICollection. 
        //void ICollection.CopyTo(Array array, int index)
        //{
        //    this.List.CopyTo(array, index);
        //}

        ///// <summary>
        ///// renvoi une instance de <see cref="GeniusTreeViewColonne"/> à l'index index
        ///// </summary>
        //public GeniusTreeViewColonne this[int index]
        //{
        //    get
        //    {
        //        return (GeniusTreeViewColonne)Items[index];
        //    }
        //    set
        //    {
        //        List[index] = value;
        //    }
        //}

        ///// <summary>
        ///// renvoi l'index d'un colonne
        ///// </summary>
        ///// <param name="aCol">la colonne dont on désire l'index</param>
        ///// <returns></returns>
        //public int IndexOf(GeniusTreeViewColonne aCol)
        //{
        //    return this.Items.IndexOf(aCol);
        //}

        ///// <summary>
        ///// ajout d'une colonne, mais passé plutôt par <see cref="GeniusHeader.Add"/>
        ///// </summary>
        ///// <param name="aCol"></param>
        ///// <returns>la position dans la liste</returns>
        //public int Add(GeniusTreeViewColonne aCol)
        //{
        //    return this.List.Add(aCol);
        //}

		/// <summary>
		/// ajoute une liste de colonnes
		/// </summary>
		/// <param name="actions"></param>
		public void AddRange(GeniusTreeViewColonne[] actions)
		{
            if (actions == null)
                throw new ArgumentNullException("actions");
			foreach (GeniusTreeViewColonne a in actions)
			{
				a.Owner = FOwner;
				this.Add(a);
			}
			if (FOwner != null)
			{
				FOwner.MainColumnIndex = FOwner.MainColumnIndex;
				FOwner.RecalcLastColWidth();
			}
		}


        protected override void ClearItems()
        {
            FDisplays.Clear();
            base.ClearItems();
        }

		private void AddDisplay(GeniusTreeViewColonne aCol)
		{
			if (aCol.Text == null || aCol.Text.Length == 0)
				aCol.Text = string.Format(CultureInfo.InvariantCulture, "Colonne {0}", this.Items.Count);
			FDisplays.Add(aCol);
		}

        //private static void CheckType(object value)
        //{
        //    if (!(value is GeniusTreeViewColonne))
        //        throw new ArgumentException("Type de l'argument invalide !");			
        //}

        protected override void InsertItem(int index, GeniusTreeViewColonne item)
        {
            if (item != null)
                item.Owner = FOwner;
            base.InsertItem(index, item);
            if (item != null)
                AddDisplay(item);
        }

        protected override void SetItem(int index, GeniusTreeViewColonne item)
        {
            if (item != null)
                item.Owner = FOwner;
            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            FDisplays.RemoveAt(index);
        }
	}
}
