using System;
using System.Collections;
using System.Windows.Forms;

namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// Summary description for HorizontalTabCollection.
	/// </summary>
	public class HorizontalTabCollection : IList, IEnumerable, ICollection
	{
		private HorizontalTabs FOwner;

		/// <summary>
		/// constructeur de la collection de tab
		/// </summary>
		/// <param name="owner"></param>
		public HorizontalTabCollection(HorizontalTabs owner)
		{
			if (owner == null)
				throw new ArgumentNullException("owner");
			FOwner = owner;
		}

		/// <summary>
		/// ajoute un <see cref="HorizontalTab"/>
		/// </summary>
		/// <param name="value"></param>
		public void AddTab(HorizontalTab value)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			FOwner.Controls.Add(value);
		}

		/// <summary>
		/// ajoute une liste de <see cref="HorizontalTab"/>, utiliser par le designer de visual studio
		/// </summary>
		/// <param name="value"></param>
		public void AddRange(HorizontalTab[] value)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			foreach(HorizontalTab tab in value)
				this.AddTab(tab);
		}

		/// <summary>
		/// suppression d'un <see cref="HorizontalTab"/>
		/// </summary>
		/// <param name="value"></param>
		public void Remove(HorizontalTab value)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			this.FOwner.Controls.Remove(value);
		}

		/// <summary>
		/// renvoi l'index d'un <see cref="HorizontalTab"/>
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(HorizontalTab value)
		{
			for (int i =0; i < Count; i++)
			{
				if (this[i] == value)
					return i;
			}
			return -1;
		}

		/// <summary>
		/// renvoi un <see cref="HorizontalTab"/> à l'index "index"
		/// </summary>
		public HorizontalTab this[int index]
		{
			get
			{
				return this.FOwner.GetTab(index);
			}
			set
			{
				MessageBox.Show("coucou");
			}
		}
			
		/// <summary>
		/// renvoi true si un <see cref="HorizontalTab"/> fait parti de la collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(HorizontalTab value)
		{
			if (value == null)
				throw new ArgumentNullException("value");
			return IndexOf(value) != -1;
		}

		#region IList Members

		/// <summary>
		/// la collection est elle en lecture seule
		/// </summary>
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		object System.Collections.IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				MessageBox.Show("tentative de setter sur this[index]");
				//throw new NotImplementedException("setter de this[index]");
			}
		}

		/// <summary>
		/// enleve un <see cref="HorizontalTab"/> à un position précise
		/// </summary>
		/// <param name="index"></param>
		public void RemoveAt(int index)
		{
			Remove(IndexOf(index));
		}

		/// <summary>
		/// insère un <see cref="HorizontalTab"/> à un position précise
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, object value)
		{
			FOwner.InsertTab(index, value as HorizontalTab);
		}

		/// <summary>
		/// retire un <see cref="HorizontalTab"/> de la collection
		/// </summary>
		/// <param name="value"></param>
		public void Remove(object value)
		{
			if (value is HorizontalTab)
			{
				Remove((HorizontalTab)value);
			}
			else
			{
				MessageBox.Show("argument de mauvais type");
				throw new ArgumentException("tagada bad type argument" + value.ToString(), "value");
			}
		}

		/// <summary>
		/// renvoi true si la collection contient value
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(object value)
		{
			if (value is HorizontalTab)
			{
				return Contains((HorizontalTab)value);
			}
			return false;
		}

		/// <summary>
		/// vide la collection
		/// </summary>
		public void Clear()
		{
			FOwner.RemoveAll();
		}

		/// <summary>
		/// renvoi l'index d'un objet de la collection
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(object value)
		{
			return this.IndexOf((HorizontalTab)value);
		}

		int System.Collections.IList.Add(object value)
		{
			if (value is HorizontalTab)
			{
				this.AddTab((HorizontalTab)value);
				return this.IndexOf((HorizontalTab)value);
			}
			MessageBox.Show("argument de mauvais type");
			throw new ArgumentException("bad type of argument" + value.ToString(), "value");
		}

		/// <summary>
		/// la taille de la colleciton est-elle fixe ?
		/// </summary>
		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region ICollection Members

		/// <summary>
		/// 
		/// </summary>
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// renvoi le nombre de <see cref="HorizontalTab"/> dans la collection
		/// </summary>
		public int Count
		{
			get
			{
				return FOwner.TabsCount;
			}
		}

		/// <summary>
		/// copy le contenu de la collection dans un tableau
		/// </summary>
		/// <param name="array"></param>
		/// <param name="index"></param>
		public void CopyTo(Array array, int index)
		{
			if (Count > 0)
				Array.Copy(FOwner.GetTabs(), 0, array, index, Count);
		}

		/// <summary>
		/// renvoi l'object SyncRoot
		/// </summary>
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		#endregion

		#region IEnumerable Members

		/// <summary>
		/// renvoi un enumérateur sur la collection
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			HorizontalTab[] tabs = FOwner.GetTabs();
			if (tabs == null)
				tabs = new HorizontalTab[0];

			return tabs.GetEnumerator();
		}

		#endregion
	}
}
