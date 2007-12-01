using System;

namespace Genius.Controls.TreeView.Core
{
	/// <summary>
	/// Summary description for Set.
	/// </summary>
	internal class Set
	{
		private Set()
		{
		}

		internal static void Exclude(ref NodeState ens, NodeState value)
		{
			ens &= (~value);
		}
		
		internal static void Include(ref NodeState ens, NodeState value)
		{
			ens |= value;
		}

		internal static bool Contains(int ens, int value)
		{
			return ((ens & value) == value);
		}

		internal static bool Contains(NodeState ens, NodeState value)
		{
			//j'ai gagn� enorm�ment en evitant un appel supl�mentaire
			//return Contains((int)ens, (int)value);
			return ((ens & value) == value);
		}
	}
}
