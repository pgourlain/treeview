using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Genius.Controls.TreeView.Serialization
{
	/// <summary>
	/// class Helper pour la sérialisation des noeuds d'un arbre
	/// </summary>
	public class SerializationHelper
	{
		private GeniusTreeView FTree;
		public SerializationHelper(GeniusTreeView gtv)
		{
			FTree = gtv;
		}

		#region sérialisation
		public void Save(string aFileName)
		{
			INode n = FTree.First();
			if (n != null)
				Save(aFileName, n.Parent, true);
		}

        /// <summary>
        /// Sauvegarde d'un sous arbre dans un fichier
        /// </summary>
        /// <param name="aFileName">le nom de fichier</param>
        /// <param name="aNode">le noeud à sauvegarder</param>
        /// <param name="onlyChild">True pour sauvegarder uniquement ses fils</param>
		public void Save(string aFileName, INode aNode, bool onlyChild)
		{
			if (File.Exists(aFileName))
				File.Delete(aFileName);
			using (FileStream fs = new FileStream(aFileName, FileMode.Create))
			{
				Save(fs, aNode, onlyChild);
				fs.Flush();
			}
		}

		public void Save(Stream aStream)
		{
			INode n = FTree.First();
			if (n != null)
				Save(aStream, n.Parent, true);
		}

		public void Save(Stream aStream, INode aNode, bool onlyChild)
		{
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(aStream, SerializableNode.Serialize(aNode, onlyChild));
		}
		#endregion

		#region déserialisation

		private SerializableNode Deserialize(Stream aStream)
		{
			BinaryFormatter bf = new BinaryFormatter();
			SerializableNode ob = (SerializableNode)bf.Deserialize(aStream);
			return ob;
		}

		/// <summary>
		/// charge un arbre depuis fichier, l'arbre est vidé au préalable
		/// </summary>
		/// <param name="aFileName"></param>
		public void Load(string aFileName)
		{
			if (File.Exists(aFileName))
			{
				using (FileStream fs = new FileStream(aFileName, FileMode.Open))
				{
					Load(fs);
				}
			}
		}
		
		/// <summary>
		/// charge un arbre, sous un noeud donné, depuis un fichier
		/// </summary>
		/// <param name="aFileName">le nom du fichier</param>
		/// <param name="aParent">le noeud parent pour le sous-arbre nouvellement chargé</param>
		public void Load(string aFileName, INode aParent)
		{
			if (File.Exists(aFileName))
			{
				using (FileStream fs = new FileStream(aFileName, FileMode.Open))
				{
					Load(fs, aParent);
				}
			}
		}

		/// <summary>
		/// charge un sous-arbre, depuis un flux
		/// </summary>
		/// <param name="inStream">le flux pour le chargement</param>
		/// <param name="aParent">la parent ou sera insérer les nouveaux noeuds</param>
		public void Load(Stream inStream, INode aParent)
		{
			SerializableNode ob = Deserialize(inStream);
			ob.Deserialize(this.FTree, aParent);					
		}

		/// <summary>
		/// charge un arbre depuis un flux, l'arbre est préalablement vidé
		/// </summary>
		/// <param name="inStream"></param>
		public void Load(Stream inStream)
		{
			SerializableNode ob = Deserialize(inStream);
			ob.Deserialize(this.FTree);			
		}
		#endregion

		#region méthode statiques
		/// <summary>
		/// sérialize les noeuds d'un treeview dans un fichier, celui -ci est détruit s'il existe
		/// </summary>
		/// <param name="tree">le treeview à sauvegarder</param>
		/// <param name="aFileName">le nom du fichier</param>
		public static void Serialize(GeniusTreeView tree, string aFileName)
		{
			new SerializationHelper(tree).Save(aFileName);
		}

		/// <summary>
		/// sérialize les noeuds d'un treeview dans un flux
		/// </summary>
		/// <param name="tree"></param>
		/// <param name="aStream"></param>
		public static void Serialize(GeniusTreeView tree, Stream aStream)
		{
			new SerializationHelper(tree).Save(aStream);			
		}

		/// <summary>
		/// sérialize un sous-arbre d'un treeview dans un fichier
		/// </summary>
		/// <param name="tree">le treeview concerné</param>
		/// <param name="aFileName">le nom du fichier pour la sauvegarde</param>
		/// <param name="aNode">le noeud a partir duquel la sauvegarde s'effectue</param>
		/// <param name="onlyChild">sauvegarde des fils et sous fils uniquement, si la valeur vaux vrai, à la relecture "aNode" ne sera pas pris en compte</param>
		public static void Serialize(GeniusTreeView tree, string aFileName, INode aNode, bool onlyChild)
		{
			new SerializationHelper(tree).Save(aFileName, aNode, onlyChild);			
		}

		/// <summary>
		/// sérialize un sous-arbre d'un treeview dans un fichier
		/// </summary>
		/// <param name="tree">le treeview concerné</param>
		/// <param name="aStream">le flux pour la sauvegarde</param>
		/// <param name="aNode">le noeud a partir duquel la sauvegarde s'effectue</param>
		/// <param name="onlyChild">sauvegarde des fils et sous fils uniquement, si la valeur vaux vrai, à la relecture "aNode" ne sera pas pris en compte</param>
		public static void Serialize(GeniusTreeView tree, Stream aStream, INode aNode, bool onlyChild)
		{
			new SerializationHelper(tree).Save(aStream, aNode, onlyChild);						
		}

		/// <summary>
		/// charge les noeuds d'un arbre depuis un fichier, l'arbre est préalablement vidé
		/// </summary>
		/// <param name="tree"></param>
		/// <param name="aFileName"></param>
		public static void DeSerialize(GeniusTreeView tree, string aFileName)
		{
			new SerializationHelper(tree).Load(aFileName);
		}

		/// <summary>
		/// charge les noeuds d'une arbre depuis un fichier, les insères en dessous de aParent
		/// </summary>
		/// <param name="tree"></param>
		/// <param name="aFileName"></param>
		/// <param name="aParent"></param>
		public static void DeSerialize(GeniusTreeView tree, string aFileName, INode aParent)
		{
			new SerializationHelper(tree).Load(aFileName, aParent);			
		}

		/// <summary>
		/// charge les noeuds d'une arbre depuis un fichier, l'arbre est préalablement vidé
		/// </summary>
		/// <param name="tree"></param>
		/// <param name="aStream"></param>
		public static void DeSerialize(GeniusTreeView tree, Stream aStream)
		{
			new SerializationHelper(tree).Load(aStream);
		}

		/// <summary>
		/// charge les noeuds d'une arbre depuis un flux, les insères en dessous de aParent
		/// </summary>
		/// <param name="tree"></param>
		/// <param name="aStream"></param>
		/// <param name="aParent"></param>
		public static void DeSerialize(GeniusTreeView tree, Stream aStream, INode aParent)
		{
			new SerializationHelper(tree).Load(aStream, aParent);			
		}
		#endregion

		#region classe pour la sérialization des noeuds
		[Serializable]
		class SerializableNode
		{
			/// <summary>
			/// constructeur par défaut
			/// </summary>
			public SerializableNode()
			{				
			}

			/// <summary>
			/// constructeur utile pour la sérialization
			/// </summary>
			/// <param name="aNode"></param>
			/// <param name="onlyChild"></param>
			public SerializableNode(INode aNode, bool onlyChild)
			{
				OnlyChild = onlyChild;
				this.ImageIndex = aNode.ImageIndex;
				this.ImageStateIndex = aNode.ImageStateIndex;
				this.Height = aNode.Height;
				this.Text = aNode.Text;
				this.UserData = aNode.Data;
				this.State = aNode.State;
			}

			#region Deserialisation
			public void Deserialize(GeniusTreeView tree, INode aParent)
			{
				INode n = tree.Add(aParent, Text, UserData);
				//le flags visible ne peut être changé par ce biais
				n.State = this.State;
				
				if (((this.State & NodeState.Visible) != NodeState.Visible))
					tree.SetVisibleNode(n, false);
				n.Height = this.Height;
				n.ImageIndex = this.ImageIndex;
				n.ImageStateIndex = this.ImageStateIndex;
				if (Children != null)
					foreach (SerializableNode child in Children)
						child.Deserialize(tree, n);
			}

			public void Deserialize(GeniusTreeView tree)
			{
				tree.BeginUpdate();
				try
				{
					tree.Clear();
					if (!OnlyChild)
						Deserialize(tree, null);
					else
					{
						foreach (SerializableNode child in Children)
							child.Deserialize(tree, null);
					}
				}
				finally
				{
					tree.EndUpdate();
				}
			}
			#endregion

			#region sérialization
			private static SerializableNode Serialize(INode aRoot, SerializableNode stream)
			{
				stream.Children = new SerializableNode[aRoot.Count];
				int i = 0;
				foreach (INode child in aRoot.Enumerable.GetNodes(false))
				{
					SerializableNode childSer = new SerializableNode(child, false);
					stream.Children[i++] = childSer;
					Serialize(child, childSer);
				}
				return stream;
			}

			public static SerializableNode Serialize(INode aRoot, bool onlyChild)
			{
				SerializableNode Result = new SerializableNode(aRoot, onlyChild);
				Serialize(aRoot, Result);
				return Result;
			}
			#endregion

			#region donnée à sauvegarder
			public int Height;
			public int ImageStateIndex;
			public int ImageIndex;
			public string Text;
			public object UserData;
			public NodeState State;
			public bool OnlyChild;		
			public SerializableNode[] Children;
			#endregion
		}
		#endregion
	}
}
