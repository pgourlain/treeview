using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// Classe de base pour les evènements du <see cref="GeniusTreeView"/>
	/// </summary>
	public class NodeEventArgs : EventArgs
	{
		private INode FNode;
		
		/// <summary>
		/// construteur par défaut
		/// </summary>
		/// <param name="node"></param>
		public NodeEventArgs(INode node) : base()
		{
			FNode = node;
		}

		internal void SetNode(INode n)
		{
			FNode = n;
		}
		/// <summary>
		/// noeud concerner par l'évènement en cours
		/// </summary>
		public INode Node
		{
			get
			{
				return FNode;
			}
		}
	}

	/// <summary>
	/// classe de base de gestion des évènements lors du mode grille
	/// </summary>
	public class NodeCellEventArgs : NodeEventArgs
	{
		private int FDisplayColumn;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="displayColumn"></param>
		public NodeCellEventArgs(INode node, int displayColumn) : base(node)
		{
			FDisplayColumn = displayColumn;
		}

		/// <summary>
		/// Colonne concernée par l'évènement en cours
		/// </summary>
		public int DisplayColumn
		{
			get
			{
				return FDisplayColumn;
			}
		}
	}

	/// <summary>
	/// évènement lors de l'expand d'un noeud
	/// </summary>
	public class ExpandEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		public ExpandEventArgs(INode node) : base(node)
		{
			CanExpand = true;
		}

		/// <summary>
		/// autorise ou pas l'expansion du noeud en cours
		/// </summary>
        public bool CanExpand { get; set; }
	}

	/// <summary>
	/// évènement lors de replie d'un noeud
	/// </summary>
	public class CollapseEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		public CollapseEventArgs(INode node) : base(node)
		{
			CanCollapse = true;
		}

		/// <summary>
		/// autosie ou pas le replie du noeuds en cours
		/// </summary>
        public bool CanCollapse { get; set; }
	}

	/// <summary>
	/// <see cref="GeniusTreeView.OnBeforeCheck"/>
	/// </summary>
	public class CheckEventArgs : NodeEventArgs
	{
		/// <summary>
		/// construteur par défaut
		/// </summary>
		/// <param name="node"></param>
		public CheckEventArgs(INode node) : base(node)
		{
			CanCheck = true;
		}

		/// <summary>
		/// autorise ou pas le check sur le noeud courant
		/// </summary>
        public bool CanCheck { get; set; }
	}

	/// <summary>
	/// évènement sur le "uncheck", <see cref="GeniusTreeView.OnBeforeUnCheck"/>
	/// </summary>
	public class UnCheckEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		public UnCheckEventArgs(INode node) : base(node)
		{
			CanUnCheck = true;
		}

		/// <summary>
		/// peut-on décocher le noeud en cours
		/// </summary>
        public bool CanUnCheck { get; set; }
	}

	/// <summary>
	/// voir <see cref="GeniusTreeView.OnBeforeEdit"/>
	/// </summary>
	public class CanEditEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="aDisplayCol"></param>
		public CanEditEventArgs(INode aNode, int aDisplayCol) : base(aNode, aDisplayCol)
		{
			CanEdit = true;
		}
		/// <summary>
		/// peuit on editer le noeud en cours
		/// </summary>
        public bool CanEdit { get; set; }
	}
	
	/// <summary>
	/// <see cref="GeniusTreeView.OnBeforeSelect"/>
	/// </summary>
	public class CanSelectEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		/// <param name="colIndex"></param>
		public CanSelectEventArgs(INode node, int colIndex) : base(node)
		{
			CanSelect = true;
			DisplayColumn = colIndex;
		}
		/// <summary>
		/// puis-je selectionner le noeud
		/// </summary>
        public bool CanSelect { get; set; }
		/// <summary>
		/// la colonne que l'on tente de selectionné, en mode grille
		/// </summary>
        public int DisplayColumn { get; set; }
	}

	/// <summary>
	/// <see cref="GeniusTreeView.OnBeforeUnSelect"/>
	/// </summary>
	public class CanUnSelectEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constrcuteur par défaut, vous n'avez pas à instancier cette classe
		/// </summary>
		/// <param name="node"></param>
		/// <param name="colIndex"></param>
		public CanUnSelectEventArgs(INode node, int colIndex) : base(node)
		{
			CanUnSelect = true;
			DisplayColumn = colIndex;
		}
		/// <summary>
		/// peut deselectioner le noeuds
		/// </summary>
        public bool CanUnSelect { get; set; }
		/// <summary>
		/// la colonne concerné
		/// </summary>
        public int DisplayColumn { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class SelectedEventArgs : NodeEventArgs
	{
		private int FColumn;

		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="node"></param>
		/// <param name="colIndex"></param>
		public SelectedEventArgs(INode node, int colIndex) : base (node)
		{
			FColumn = colIndex;
		}

		/// <summary>
		/// la display colonne concernée
		/// </summary>
		public int DisplayColumn
		{
			get
			{
				return FColumn;
			}
		}
	}

	/// <summary>
	/// arguments de l'évènement <see cref="GeniusTreeView.OnGetNodeText"/>
	/// </summary>
	public class NodeTextEventArgs : SelectedEventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		/// <param name="colIndex"></param>
		/// <param name="defaultText"></param>
		public NodeTextEventArgs(INode node, int colIndex, string defaultText) : base(node, colIndex)
		{
			Text = defaultText;
		}

		/// <summary>
		/// le texte
		/// </summary>
        public string Text { get; set; }
	}

	/// <summary>
	/// argument de l'évènement <see cref="GeniusTreeView.OnAfterCellPainting"/>, 
	/// <see cref="GeniusTreeView.OnBeforeCellPainting"/>, <see cref="GeniusTreeView.OnAfterPainting"/>,
	/// <see cref="GeniusTreeView.OnAfterNodePainting"/>,<see cref="GeniusTreeView.OnPaintNodeBackGround"/>,
	/// <see cref="GeniusTreeView.OnBeforeNodePainting"/>, <see cref="GeniusTreeView.OnBeforePainting"/>
	/// </summary>
	public class PaintNodeEventArgs : NodeEventArgs
	{
		private PaintInfo FInfo;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="paintInfo"></param>
		public PaintNodeEventArgs(PaintInfo paintInfo) : base(paintInfo.Node)
		{
			FInfo = paintInfo;
		}

		/// <summary>
		/// 
		/// </summary>
		public PaintInfo Info
		{
			get
			{
				return FInfo;
			}
		}
	}

	/// <summary>
	/// paramètre de l'événement <see cref="GeniusTreeView.OnDrawDrag"/>
	/// </summary>
	public class DrawDragEventArgs : EventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="rect"></param>
		public DrawDragEventArgs(Graphics graphics, Rectangle rect )
		{
			Graphics = graphics;
			Bounds = rect;
			DefaultDrawing = true;
			Forbiden = false;
		}
		/// <summary>
		/// canevas pour le dessin
		/// </summary>
        public Graphics Graphics { get; private set; }
		/// <summary>
		/// zone de dessin
		/// </summary>
        public Rectangle Bounds { get; set; }
		/// <summary>
		/// dessin par defaut
		/// </summary>
        public bool DefaultDrawing { get; set; }
		/// <summary>
		/// interdiction du drag
		/// </summary>
        public bool Forbiden { get; set; }
	}

	/// <summary>
	/// <see cref="GeniusTreeView.PrepareDrag"/>
	/// </summary>
	public class PrepareDragEventArgs : EventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="r"></param>
		public PrepareDragEventArgs(Rectangle r )
		{
			Bounds = r;
		}
		/// <summary>
		/// rectangle désirer pour le dessin du drag
		/// </summary>
        public Rectangle Bounds { get; set; }
	}

	/// <summary>
	/// <see cref="GeniusTreeView.CanDragTo"/>
	/// </summary>
	public class CanDragToEventArgs : NodeEventArgs
	{
		private INode FDropNode;
		private DragPosition FPosition;
		
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="n"></param>
		/// <param name="aDrop"></param>
		/// <param name="aPosition"></param>
		public CanDragToEventArgs(INode n, INode aDrop, DragPosition aPosition) : base(n)
		{
			FDropNode = aDrop;
			FPosition = aPosition;
			CanDrop = true;
		}

		/// <summary>
		/// le noeud qui recoit le drop
		/// </summary>
		public INode DropNode
		{
			get
			{
				return FDropNode;
			}
		}

		/// <summary>
		/// position par rapport au noeud destination
		/// </summary>
		public DragPosition Position
		{
			get
			{
				return FPosition;
			}
		}

		/// <summary>
		/// autorise ou pas le drop
		/// </summary>
        public bool CanDrop { get; set; }
	}

	/// <summary>
	/// argument de l'évènement <see cref="GeniusTreeView.OnCanDragNode"/>
	/// </summary>
	public class CanDragEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="aNode"></param>
		public CanDragEventArgs(INode aNode) : base(aNode)
		{
			CanDrag = true;
		}

		/// <summary>
		/// peut -on demarrer le drag
		/// </summary>
        public bool CanDrag { get; set; }
	}

	/// <summary>
	/// classe liée à la création d'un éditeur
	/// </summary>
	public class NodeEditorEventArgs : NodeEventArgs
	{
		private int FColumn;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		/// <param name="column"></param>
		public NodeEditorEventArgs(INode node, int column) : base(node)
		{
			Editor = null;
			FColumn = column;
		}

		/// <summary>
		/// Placez votre propre éditeur
		/// </summary>
        public ITreeViewEdit Editor { get; set; }

		/// <summary>
		/// indique la colonne en édition
		/// </summary>
		public int DisplayColumn
		{
			get
			{
				return FColumn;
			}
		}
	}
	
	/// <summary>
	/// classe passé en argument des événements <see cref="GeniusTreeView.OnBeforePaintHeader"/> et <see cref="GeniusTreeView.OnAfterPaintHeader"/>
	/// </summary>
	public class DrawHeaderColEventArgs : EventArgs
	{
		private Rectangle FRectCol;
		private Graphics FGraphics;
		private GeniusTreeViewColonne FCol;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="column"></param>
		/// <param name="columnRect"></param>
		public DrawHeaderColEventArgs(Graphics graphics, GeniusTreeViewColonne column, Rectangle columnRect)
		{
			DefaultDrawing = true;
			FGraphics = graphics;
			FRectCol = columnRect;
			FCol = column;
		}

		/// <summary>
		/// si cette propriété est positionnée à false, le dessin par défaut ne sera pas fait
		/// </summary>
        public bool DefaultDrawing { get; set; }
		/// <summary>
		/// le graphics à utiliser pour déssiner
		/// </summary>
		public Graphics Graphics {get {return FGraphics;}}
		/// <summary>
		/// la colonne concernée par le dessin
		/// </summary>
		public GeniusTreeViewColonne Column {get { return FCol;}}
		/// <summary>
		/// le rectangle dans lequel il faut dessiner, représentant l'entête de la colonne
		/// </summary>
		public Rectangle ColumnRect {get {return FRectCol;}}
	}

	/// <summary>
	/// type d'image demandée lors de l'évènement <see cref="GeniusTreeView.OnGetImageIndex"/>
	/// </summary>
	public enum ImageIndexType
	{
		/// <summary>
		/// image normal
		/// </summary>
		NormalImage, 
		/// <summary>
		/// image d'état
		/// </summary>
		StateImage
	};

	/// <summary>
	/// Classe associée à l'évènement <see cref="GeniusTreeView.OnGetImageIndex"/>
	/// </summary>
	public class NodeImageIndexEventArgs : NodeEventArgs
	{
		private ImageIndexType FImageIndexType;
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		/// <param name="imageType"></param>
		public NodeImageIndexEventArgs(INode node, ImageIndexType imageType) : base(node)
		{
			FImageIndexType = imageType;
		}

		/// <summary>
		/// index de l'image
		/// </summary>
        public int ImageIndex { get; set; }
		/// <summary>
		/// le type de l'image
		/// </summary>
		public ImageIndexType ImageIndexType
		{
			get
			{
				return FImageIndexType;
			}
		}
	}

	/// <summary>
	/// classe passé en argument de <see cref="GeniusTreeView.OnGetHint"/>, afin de récupérer le hint à afficher pour le noeud sous la souris
	/// vous n'avez pas à instancier cette classe
	/// </summary>
	public class NodeGetHintEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		/// <param name="displayColumn"></param>
		public NodeGetHintEventArgs(INode node, int displayColumn) : base(node, displayColumn)
		{
			
		}

		/// <summary>
		/// propriété représentant le texte du hint
		/// </summary>
        public string HintText { get; set; }
	}

	/// <summary>
	/// argument pour l'événement <see cref="GeniusTreeView.OnBeforeDelete"/>
	/// </summary>
	public class NodeDeleteEventArgs : NodeEventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public NodeDeleteEventArgs(INode node) : base(node)
		{
			CanDelete = true;
		}

		/// <summary>
		/// peut-on uspprimer le noeud en cours
		/// </summary>
        public bool CanDelete { get; set; }
	}

	/// <summary>
	/// classe utiliser lors de l'évènement <see cref="GeniusTreeView.OnInitEdit"/>, <see cref="GeniusTreeView.OnAfterEdit"/>
	/// </summary>
	public class EditEventArgs : NodeCellEventArgs
	{
		private ITreeViewEdit FEditor;
		private object FValue;
		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="node"></param>
		/// <param name="displayColumn"></param>
		/// <param name="editor"></param>
		public EditEventArgs(INode node, int displayColumn, ITreeViewEdit editor): base(node, displayColumn)
		{
			FEditor = editor;
		}

		/// <summary>
		/// editeur en cours
		/// </summary>
		public ITreeViewEdit Editor
		{
			get
			{
				return FEditor;
			}
		}

		/// <summary>
		/// valeur associé à l'edition
		/// </summary>
		public object Value
		{
			get
			{
				return FValue;
			}
			set
			{
				FValue = value;
			}
		}
	}

	/// <summary>
	/// classe passé dans l'événement <see cref="GeniusTreeView.OnGetFontNode"/>, afin de récupérer la font pour la cellule en cours de dessin
	/// </summary>
	public class NodeFontEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		/// <param name="displayColumn"></param>
		public NodeFontEventArgs(INode node, int displayColumn) : base(node, displayColumn)
		{
			
		}
		/// <summary>
		/// la font associé à la cellule
		/// </summary>
        public Font Font { get; set; }
	}

	/// <summary>
	/// 
	/// </summary>
	public class NodeDrawingTreeLinesEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="node"></param>
		public NodeDrawingTreeLinesEventArgs(INode node) : base(node)
		{
			Draw = true;
		}

		/// <summary>
		/// doit-je dessiner les lignes de l'arbre ?
		/// </summary>
        public bool Draw { get; set; }
	}

	/// <summary>
	/// EventArgs pour la création du Hint
	/// </summary>
    public class NodeHintWindowEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
        public NodeHintWindowEventArgs(INode node, int displayColumn, IHintWindow currentHint) : base(node, displayColumn)
		{
            HintWindow = currentHint;
		}
		/// <summary>
		/// user HintWindow
		/// </summary>
        public IHintWindow HintWindow { get; set; }
	}

	#region Cell Mouse events
	/// <summary>
	/// evenement lorsque lié a la souris et à une cellule
	/// </summary>
	public class NodeCellMouseEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="n"></param>
		/// <param name="aDisplayCol"></param>
		public NodeCellMouseEventArgs(INode n, int aDisplayCol) : base(n, aDisplayCol)
		{
				
		}
		/// <summary>
		/// position de la souris par rapport à une cellule
		/// </summary>
        public MousePosition MousePosition { get; set; }
		/// <summary>
		/// état des boutons de la souris
		/// </summary>
        public MouseButtons Button { get; set; }
		/// <summary>
		/// coordonées de la souris
		/// </summary>
        public Point Position { get; set; }
	}
	#endregion

	/// <summary>
	/// evenement pour demander la zone d'édition
	/// </summary>
	public class EditRectEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="node"></param>
		/// <param name="displayColumn"></param>
		public EditRectEventArgs(INode node, int displayColumn) : base(node, displayColumn)
		{
			
		}

		/// <summary>
		/// le rectangle visuel de la zone d'édition
		/// </summary>
        public Rectangle EditRect { get; set; }
	}

	/// <summary>
	/// class d'arguments pour le paint du footer
	/// </summary>
	public class PaintFooterEventArgs : EventArgs
	{
		private Graphics FGraphics;
		private Rectangle FFooterRect;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="displayColumn"></param>
		/// <param name="rect"></param>
		public PaintFooterEventArgs(Graphics graphics, int displayColumn, Rectangle rect)
		{
			DefaultDrawing = true;
			FGraphics = graphics;
			DisplayColumn = displayColumn;
			FFooterRect = rect;
		}

		/// <summary>
		/// le rectangle du dessin (soit d'un cellule du footer, soit du footer complet)
		/// </summary>
		public Rectangle	FooterRect
		{
			get
			{
				return FFooterRect;
			}
		}
		/// <summary>
		/// la display column concernée par le dessin en mode grille, -1 dans les autres cas
		/// </summary>
        public int DisplayColumn { get; set; }
		/// <summary>
		/// utiliser par <see cref="GeniusTreeView.OnBeforePaintFooter"/>. via cette propriété l'utilisateur peut
		/// empecher le paint par défaut du footer pour y mettre le sien
		/// </summary>
        public bool DefaultDrawing { get; set; }
		/// <summary>
		/// le canevas à utiliser pour le dessin du footer
		/// </summary>
		public Graphics Graphics
		{
			get
			{
				return FGraphics;
			}
		}
	}

	/// <summary>
	/// class utilisée pour le paint du footer, demande du texte à afficher
	/// </summary>
	public class FooterTextEventArgs : EventArgs
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="displayColumn"></param>
		public FooterTextEventArgs(int displayColumn)
		{
			DisplayColumn = displayColumn;
			Text = string.Empty;
		}
		/// <summary>
		/// la colonne concernée par le dessin
		/// </summary>
        public int DisplayColumn { get; set; }
		/// <summary>
		/// le texte à afficher
		/// </summary>
        public string Text { get; set; }
		/// <summary>
		/// la font du texte à afficher
		/// </summary>
        public Font Font { get; set; }
		/// <summary>
		/// la couleur du texte à afficher
		/// </summary>
        public Color ForeColor { get; set; }

		/// <summary>
		/// format d'affichage pour le texte du footer
		/// </summary>
        public StringFormat Format { get; set; }
	}

    /// <summary>
    /// classe utilisée par <see cref="GeniusTreeView.OnBeginDrag"/>
    /// </summary>
    public class BeginDragEventArgs : NodeEventArgs
    {
        /// <summary>
        /// constructeur par défaut
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dataToDrag"></param>
        public BeginDragEventArgs(INode node, object dataToDrag) : base(node)
        {
            DataToDrag = dataToDrag;
        }

        /// <summary>
        /// permet à l'utilisateur de définir l'objet à dragger, il n'est pas conseillé d'affecter cette propriété avec un noeud de l'arbre
        /// </summary>
        public object DataToDrag { get; set; }
    }

    /// <summary>
    /// classe utilisée comme argument de l'événement <see cref="GeniusTreeView.OnGetNodeWidth"/>
    /// </summary>
    public class GetNodeWidthEventArgs : NodeCellEventArgs
    {
        private Graphics FGraphics;
        public GetNodeWidthEventArgs(INode node, int column, Graphics graphics)
            : base(node, column)
        {
            Width = 0;
            FGraphics = graphics;
        }

        /// <summary>
        /// largeur du noeud
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// pour calculer éventuellement la largeur du noeud
        /// </summary>
        public Graphics Graphics
        {
            get { return FGraphics; }
        }
    }
}