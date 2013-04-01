using System;
using System.Collections;
using System.Collections.Generic;

namespace Genius.Controls.TreeView.Core
{
	/// <summary>
	/// classe d'�num�ration pour les noeuds
	/// </summary>
    internal class NodeEnumerator : IEnumerable<INode>, IEnumerator<INode>, IEnumerator, IDisposable
	{
		private Node FParent;
		private bool FRecurse;
		private bool FReset;
		private bool FVisible;
		private Node FCurrent;

		public NodeEnumerator(Node aParent, bool recurse) : this(aParent, recurse, false)
		{
		}

		public NodeEnumerator(Node aParent, bool recurse, bool visible)
		{
			FParent = aParent;
			FRecurse = recurse;
			FVisible = visible;
			Reset();
		}

		#region IEnumerable Members

		/// <summary>
		/// renvoi un <see cref="IEnumerator"/> sur un ensemble de noeuds
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return this;
		}

		#endregion

		#region IEnumerator Members

		public void Reset()
		{
			FReset = true;
			FCurrent = null;
		}

		/// <summary>
		/// renvoi le noeud en cours d'�num�ration, de type <see cref="INode"/>
		/// </summary>
        public INode Current
		{
			get
			{
				return FCurrent;
			}
		}

		/// <summary>
		/// avance l'�num�ration, et renvoi true si <see cref="Current"/> est valide 
		/// </summary>
		/// <returns>true si <see cref="Current"/> est valide</returns>
		public bool MoveNext()
		{
			if (FReset)
			{
				if (FVisible)
				{
					if (FRecurse || FParent is Root)
						FCurrent = Node.NextVisibleNode(FParent);
					else
					{
						FCurrent = FParent.FirstChild;
						if (FCurrent != null && !FCurrent.IsVisible)
							FCurrent = Node.NextSiblingVisibleNode(FCurrent);
					}
				}
				else
					FCurrent = FParent.FirstChild;
				FReset = false;
			}
			else
			{
				if (FCurrent == null)
					return false;
				if (FRecurse)
				{
					if (FVisible)
						FCurrent = Node.NextVisibleNode(FCurrent);
					else
						FCurrent = Node.NextNode(FCurrent);
				}
				else
				{
					if (FVisible)
						FCurrent = Node.NextSiblingVisibleNode(FCurrent);
					else
						FCurrent = FCurrent.NextSibling;
				}
			}
            ////---- Check that we have not reach the same level          
            //// It mean it remain no node to return.         
            //if (Node.GetNodeLevel(FCurrent) == Node.GetNodeLevel(FParent))
            //{
            //    FCurrent = null;
            //    return false;
            //}
            return FCurrent != null;
		}

		#endregion

        #region IEnumerable<Node> Members

        IEnumerator<INode> IEnumerable<INode>.GetEnumerator()
        {
            return this;
        }

        #endregion

        #region IEnumerator Members

        object IEnumerator.Current
        {
            get { return FCurrent; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}
