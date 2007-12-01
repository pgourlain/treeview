using System.Collections;

namespace Genius.Controls.DocTabs
{
	/// <summary>
	/// Summary description for GeniusTabs.
	/// </summary>
	public class GeniusTabs : CollectionBase
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public GeniusTabs()
		{
		}

		/// <summary>
		/// indexer par défaut
		/// </summary>
		public GeniusTab this[int index]
		{
			get
			{
				return (GeniusTab)this.InnerList[index];
			}
			set
			{
				this.InnerList[index] = value;
			}
		}

		/// <summary>
		/// ajout d'un tab
		/// </summary>
		/// <param name="aTab"></param>
		/// <returns></returns>
		public int Add(GeniusTab aTab)
		{
			return this.InnerList.Add(aTab);
		}

		/// <summary>
		/// ajout d'une liste de tab
		/// </summary>
		/// <param name="aTabs"></param>
		public void AddRange(GeniusTab[] aTabs)
		{
			this.InnerList.AddRange(aTabs);
		}
	}
}
