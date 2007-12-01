using System;
using Genius.Controls.TreeView.Core;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// classe interne pour le dessin du hint personalisé.
	/// </summary>
	class HintHelper
	{
		public Node Node;
		public string Text;
		public int Column;

		public HintHelper(string aText, Node aNode, int aDisplayColumn)
		{
			Node = aNode;
			Text = aText;
			Column = aDisplayColumn;
		}
	}
}
