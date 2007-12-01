using System;
using System.Drawing;
using System.Windows.Forms;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// Classe de base pour les ev�nements du <see cref="GeniusTreeView"/>
	/// </summary>
	public class NodeEventArgs : EventArgs
	{
		private INode FNode;
		
		/// <summary>
		/// construteur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		public NodeEventArgs(INode aNode) : base()
		{
			FNode = aNode;
		}

		internal void SetNode(INode n)
		{
			FNode = n;
		}
		/// <summary>
		/// noeud concerner par l'�v�nement en cours
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
	/// classe de base de gestion des �v�nements lors du mode grille
	/// </summary>
	public class NodeCellEventArgs : NodeEventArgs
	{
		private int FDisplayColumn;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="aDisplayColumn"></param>
		public NodeCellEventArgs(INode aNode, int aDisplayColumn) : base(aNode)
		{
			FDisplayColumn = aDisplayColumn;
		}

		/// <summary>
		/// Colonne concern�e par l'�v�nement en cours
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
	/// �v�nement lors de l'expand d'un noeud
	/// </summary>
	public class ExpandEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		public ExpandEventArgs(INode aNode) : base(aNode)
		{
			CanExpand = true;
		}

		/// <summary>
		/// autorise ou pas l'expansion du noeud en cours
		/// </summary>
		public bool CanExpand;
	}

	/// <summary>
	/// �v�nement lors de replie d'un noeud
	/// </summary>
	public class CollapseEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		public CollapseEventArgs(INode aNode) : base(aNode)
		{
			CanCollapse = true;
		}

		/// <summary>
		/// autosie ou pas le replie du noeuds en cours
		/// </summary>
		public bool CanCollapse;
	}

	/// <summary>
	/// <see cref="GeniusTreeView.OnBeforeCheck"/>
	/// </summary>
	public class CheckEventArgs : NodeEventArgs
	{
		/// <summary>
		/// construteur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		public CheckEventArgs(INode aNode) : base(aNode)
		{
			CanCheck = true;
		}

		/// <summary>
		/// autorise ou pas le check sur le noeud courant
		/// </summary>
		public bool CanCheck;
	}

	/// <summary>
	/// �v�nement sur le "uncheck", <see cref="GeniusTreeView.OnBeforeUnCheck"/>
	/// </summary>
	public class UnCheckEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		public UnCheckEventArgs(INode aNode) : base(aNode)
		{
			CanUnCheck = true;
		}

		/// <summary>
		/// peut-on d�cocher le noeud en cours
		/// </summary>
		public bool CanUnCheck;
	}

	/// <summary>
	/// voir <see cref="GeniusTreeView.OnBeforeEdit"/>
	/// </summary>
	public class CanEditEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
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
		public bool CanEdit;
	}
	
	/// <summary>
	/// <see cref="GeniusTreeView.OnBeforeSelect"/>
	/// </summary>
	public class CanSelectEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="colindex"></param>
		public CanSelectEventArgs(INode aNode, int colindex) : base(aNode)
		{
			CanSelect = true;
			DisplayColumn = colindex;
		}
		/// <summary>
		/// puis-je selectionner le noeud
		/// </summary>
		public bool CanSelect;
		/// <summary>
		/// la colonne que l'on tente de selectionn�, en mode grille
		/// </summary>
		public int DisplayColumn;
	}

	/// <summary>
	/// <see cref="GeniusTreeView.OnBeforeUnSelect"/>
	/// </summary>
	public class CanUnSelectEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constrcuteur par d�faut, vous n'avez pas � instancier cette classe
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="colindex"></param>
		public CanUnSelectEventArgs(INode aNode, int colindex) : base(aNode)
		{
			CanUnSelect = true;
			DisplayColumn = colindex;
		}
		/// <summary>
		/// peut deselectioner le noeuds
		/// </summary>
		public bool CanUnSelect;
		/// <summary>
		/// la colonne concern�
		/// </summary>
		public int DisplayColumn;
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
		/// <param name="aNode"></param>
		/// <param name="colindex"></param>
		public SelectedEventArgs(INode aNode, int colindex) : base (aNode)
		{
			FColumn = colindex;
		}

		/// <summary>
		/// la display colonne concern�e
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
	/// arguments de l'�v�nement <see cref="GeniusTreeView.OnGetNodeText"/>
	/// </summary>
	public class NodeTextEventArgs : SelectedEventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="colindex"></param>
		/// <param name="defaultText"></param>
		public NodeTextEventArgs(INode aNode, int colindex, string defaultText) : base(aNode, colindex)
		{
			Text = defaultText;
		}

		/// <summary>
		/// le texte
		/// </summary>
		public string Text;
	}

	/// <summary>
	/// argument de l'�v�nement <see cref="GeniusTreeView.OnAfterCellPainting"/>, 
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
		/// <param name="paintinfo"></param>
		public PaintNodeEventArgs(PaintInfo paintinfo) : base(paintinfo.Node)
		{
			FInfo = paintinfo;
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
	/// param�tre de l'�v�nement <see cref="GeniusTreeView.OnDrawDrag"/>
	/// </summary>
	public class DrawDragEventArgs : EventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="g"></param>
		/// <param name="r"></param>
		public DrawDragEventArgs(Graphics g, Rectangle r )
		{
			graphics = g;
			Bounds = r;
			DefaultDrawing = true;
			Forbiden = false;
		}
		/// <summary>
		/// canevas pour le dessin
		/// </summary>
		public Graphics graphics;
		/// <summary>
		/// zone de dessin
		/// </summary>
		public Rectangle Bounds;
		/// <summary>
		/// dessin par defaut
		/// </summary>
		public bool DefaultDrawing;
		/// <summary>
		/// interdiction du drag
		/// </summary>
		public bool Forbiden;
	}

	/// <summary>
	/// <see cref="GeniusTreeView.PrepareDrag"/>
	/// </summary>
	public class PrepareDragEventArgs : EventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="r"></param>
		public PrepareDragEventArgs(Rectangle r )
		{
			Bounds = r;
		}
		/// <summary>
		/// rectangle d�sirer pour le dessin du drag
		/// </summary>
		public Rectangle Bounds;
	}

	/// <summary>
	/// <see cref="GeniusTreeView.CanDragTo"/>
	/// </summary>
	public class CanDragToEventArgs : NodeEventArgs
	{
		private INode FDropNode;
		private DragPosition FPosition;
		
		/// <summary>
		/// constructeur par d�faut
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
		public bool CanDrop;
	}

	/// <summary>
	/// argument de l'�v�nement <see cref="GeniusTreeView.OnCanDragNode"/>
	/// </summary>
	public class CanDragEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		public CanDragEventArgs(INode aNode) : base(aNode)
		{
			CanDrag = true;
		}

		/// <summary>
		/// peut -on demarrer le drag
		/// </summary>
		public bool CanDrag;
	}

	/// <summary>
	/// classe li�e � la cr�ation d'un �diteur
	/// </summary>
	public class NodeEditorEventArgs : NodeEventArgs
	{
		private int FColumn;

		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="acol"></param>
		public NodeEditorEventArgs(INode aNode, int acol) : base(aNode)
		{
			Editor = null;
			FColumn = acol;
		}

		/// <summary>
		/// Placez votre propre �diteur
		/// </summary>
		public ITreeViewEdit Editor;

		/// <summary>
		/// indique la colonne en �dition
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
	/// classe pass� en argument des �v�nements <see cref="GeniusTreeView.OnBeforePaintHeader"/> et <see cref="GeniusTreeView.OnAfterPaintHeader"/>
	/// </summary>
	public class DrawHeaderColEventArgs : EventArgs
	{
		private Rectangle FRectCol;
		private Graphics FGraphics;
		private GeniusTreeViewColonne FCol;

		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="g"></param>
		/// <param name="aCol"></param>
		/// <param name="rCol"></param>
		public DrawHeaderColEventArgs(Graphics g, GeniusTreeViewColonne aCol, Rectangle rCol)
		{
			DefaultDrawing = true;
			FGraphics = g;
			FRectCol = rCol;
			FCol = aCol;
		}

		/// <summary>
		/// si cette propri�t� est positionn�e � false, le dessin par d�faut ne sera pas fait
		/// </summary>
		public bool DefaultDrawing;
		/// <summary>
		/// le graphics � utiliser pour d�ssiner
		/// </summary>
		public Graphics graphics {get {return FGraphics;}}
		/// <summary>
		/// la colonne concern�e par le dessin
		/// </summary>
		public GeniusTreeViewColonne Col {get { return FCol;}}
		/// <summary>
		/// le rectangle dans lequel il faut dessiner, repr�sentant l'ent�te de la colonne
		/// </summary>
		public Rectangle RectCol {get {return FRectCol;}}
	}

	/// <summary>
	/// type d'image demand�e lors de l'�v�nement <see cref="GeniusTreeView.OnGetImageIndex"/>
	/// </summary>
	public enum ImageIndexType
	{
		/// <summary>
		/// image normal
		/// </summary>
		NormalImage, 
		/// <summary>
		/// image d'�tat
		/// </summary>
		StateImage
	};

	/// <summary>
	/// Classe associ�e � l'�v�nement <see cref="GeniusTreeView.OnGetImageIndex"/>
	/// </summary>
	public class NodeImageIndexEventArgs : NodeEventArgs
	{
		private ImageIndexType FImageIndexType;
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="n"></param>
		/// <param name="aImageType"></param>
		public NodeImageIndexEventArgs(INode n, ImageIndexType aImageType) : base(n)
		{
			FImageIndexType = aImageType;
		}

		/// <summary>
		/// index de l'image
		/// </summary>
		public int ImageIndex;
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
	/// classe pass� en argument de <see cref="GeniusTreeView.OnGetHint"/>, afin de r�cup�rer le hint � afficher pour le noeud sous la souris
	/// vous n'avez pas � instancier cette classe
	/// </summary>
	public class NodeGetHintEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="aDisplayColumn"></param>
		public NodeGetHintEventArgs(INode aNode, int aDisplayColumn) : base(aNode, aDisplayColumn)
		{
			
		}

		/// <summary>
		/// propri�t� repr�sentant le texte du hint
		/// </summary>
		public string HintText;
	}

	/// <summary>
	/// argument pour l'�v�nement <see cref="GeniusTreeView.OnBeforeDelete"/>
	/// </summary>
	public class NodeDeleteEventArgs : NodeEventArgs
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="n"></param>
		public NodeDeleteEventArgs(INode n) : base(n)
		{
			CanDelete = true;
		}

		/// <summary>
		/// peut-on uspprimer le noeud en cours
		/// </summary>
		public bool CanDelete;
	}

	/// <summary>
	/// classe utiliser lors de l'�v�nement <see cref="GeniusTreeView.OnInitEdit"/>, <see cref="GeniusTreeView.OnAfterEdit"/>
	/// </summary>
	public class EditEventArgs : NodeCellEventArgs
	{
		private ITreeViewEdit FEditor;
		private object FValue;
		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="n"></param>
		/// <param name="aDisplayColumn"></param>
		/// <param name="editor"></param>
		public EditEventArgs(INode n, int aDisplayColumn, ITreeViewEdit editor): base(n, aDisplayColumn)
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
		/// valeur associ� � l'edition
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
	/// classe pass� dans l'�v�nement <see cref="GeniusTreeView.OnGetFontNode"/>, afin de r�cup�rer la font pour la cellule en cours de dessin
	/// </summary>
	public class NodeFontEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="n"></param>
		/// <param name="aDisplayColumn"></param>
		public NodeFontEventArgs(INode n, int aDisplayColumn) : base(n, aDisplayColumn)
		{
			
		}
		/// <summary>
		/// la font associ� � la cellule
		/// </summary>
		public Font Font;
	}

	/// <summary>
	/// 
	/// </summary>
	public class NodeDrawingTreeLinesEventArgs : NodeEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="n"></param>
		public NodeDrawingTreeLinesEventArgs(INode n) : base(n)
		{
			Draw = true;
		}

		/// <summary>
		/// doit-je dessiner les lignes de l'arbre ?
		/// </summary>
		public bool Draw;
	}

	/// <summary>
	/// EventArgs pour la cr�ation du Hint
	/// </summary>
    public class NodeHintWindowEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
        public NodeHintWindowEventArgs(INode aNode, int aDisplayColumn, IHintWindow aCurrentHint) : base(aNode, aDisplayColumn)
		{
            HintWindow = aCurrentHint;
		}
		/// <summary>
		/// user HintWindow
		/// </summary>
		public IHintWindow HintWindow;
	}

	#region Cell Mouse events
	/// <summary>
	/// evenement lorsque li� a la souris et � une cellule
	/// </summary>
	public class NodeCellMouseEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="n"></param>
		/// <param name="aDisplayCol"></param>
		public NodeCellMouseEventArgs(INode n, int aDisplayCol) : base(n, aDisplayCol)
		{
				
		}
		/// <summary>
		/// position de la souris par rapport � une cellule
		/// </summary>
		public MousePosition MousePosition;
		/// <summary>
		/// �tat des boutons de la souris
		/// </summary>
		public MouseButtons Button;
		/// <summary>
		/// coordon�es de la souris
		/// </summary>
		public Point Position;
	}
	#endregion

	/// <summary>
	/// evenement pour demander la zone d'�dition
	/// </summary>
	public class EditRectEventArgs : NodeCellEventArgs
	{
		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="aNode"></param>
		/// <param name="aDisplayColumn"></param>
		public EditRectEventArgs(INode aNode, int aDisplayColumn) : base(aNode, aDisplayColumn)
		{
			
		}

		/// <summary>
		/// le rectangle visuel de la zone d'�dition
		/// </summary>
		public Rectangle EditRect;
	}

	/// <summary>
	/// class d'arguments pour le paint du footer
	/// </summary>
	public class PaintFooterEventArgs : EventArgs
	{
		private Graphics FGraphics;
		private Rectangle FFooterRect;

		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="g"></param>
		/// <param name="aDisplayColumn"></param>
		/// <param name="aRect"></param>
		public PaintFooterEventArgs(Graphics g, int aDisplayColumn, Rectangle aRect)
		{
			DefaultDrawing = true;
			FGraphics = g;
			DisplayColumn = aDisplayColumn;
			FFooterRect = aRect;
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
		/// la display column concern�e par le dessin en mode grille, -1 dans les autres cas
		/// </summary>
		public int			DisplayColumn;
		/// <summary>
		/// utiliser par <see cref="GeniusTreeView.OnBeforePaintFooter"/>. via cette propri�t� l'utilisateur peut
		/// empecher le paint par d�faut du footer pour y mettre le sien
		/// </summary>
		public bool			DefaultDrawing;
		/// <summary>
		/// le canevas � utiliser pour le dessin du footer
		/// </summary>
		public Graphics		graphics
		{
			get
			{
				return FGraphics;
			}
		}
	}

	/// <summary>
	/// class utilis�e pour le paint du footer, demande du texte � afficher
	/// </summary>
	public class FooterTextEventArgs : EventArgs
	{
		/// <summary>
		/// constructeur par d�faut
		/// </summary>
		/// <param name="aDisplayColumn"></param>
		public FooterTextEventArgs(int aDisplayColumn)
		{
			DisplayColumn = aDisplayColumn;
			Text = string.Empty;
		}
		/// <summary>
		/// la colonne concern�e par le dessin
		/// </summary>
		public int		DisplayColumn;
		/// <summary>
		/// le texte � afficher
		/// </summary>
		public string	Text;
		/// <summary>
		/// la font du texte � afficher
		/// </summary>
		public Font		Font;
		/// <summary>
		/// la couleur du texte � afficher
		/// </summary>
		public Color ForeColor;	

		/// <summary>
		/// format d'affichage pour le texte du footer
		/// </summary>
		public StringFormat	Format;
	}

    /// <summary>
    /// classe utilis�e par <see cref="GeniusTreeView.OnBeginDrag"/>
    /// </summary>
    public class BeginDragEventArgs : NodeEventArgs
    {
        /// <summary>
        /// constructeur par d�faut
        /// </summary>
        /// <param name="n"></param>
        /// <param name="aDataToDrag"></param>
        public BeginDragEventArgs(INode n, object aDataToDrag) : base(n)
        {
            DataToDrag = aDataToDrag;
        }

        /// <summary>
        /// permet � l'utilisateur de d�finir l'objet � dragger, il n'est pas conseill� d'affecter cette propri�t� avec un noeud de l'arbre
        /// </summary>
        public object DataToDrag;
    }

    /// <summary>
    /// classe utilis�e comme argument de l'�v�nement <see cref="GeniusTreeView.OnGetNodeWidth"/>
    /// </summary>
    public class GetNodeWidthEventArgs : NodeCellEventArgs
    {
        private Graphics FGraphics;
        public GetNodeWidthEventArgs(INode aNode, int aColumn, Graphics aGraphics)
            : base(aNode, aColumn)
        {
            Width = 0;
            FGraphics = aGraphics;
        }

        /// <summary>
        /// largeur du noeud
        /// </summary>
        public int Width;
        /// <summary>
        /// pour calculer �ventuellement la largeur du noeud
        /// </summary>
        public Graphics graphics
        {
            get { return FGraphics; }
        }
    }
}