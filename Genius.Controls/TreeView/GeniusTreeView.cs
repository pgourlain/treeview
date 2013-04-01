using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

using System.Drawing.Drawing2D;
using Genius.Controls.NativeWindow;
using Genius.Controls.TreeView.Core;
using Genius.Controls.TreeView.Editors;
using Genius.Controls.TreeView.Serialization;
using Genius.Controls.TreeView;
using System.Windows.Forms.VisualStyles;
using Genius.Controls.TreeView.DragDrop;
using System.Drawing.Imaging;
using System.Threading;
using System.Collections.ObjectModel;

/******************************************************************************
 * Lexique :
 * + : ajout de fonctionnalité
 * - : retrait de fonctionnalité pour cause de bug
 * . : correction de bug
 *
 * 2.0.6 17/02/2009
 * . correction multiselection => navigation des noeuds
 * + ajout d'un propriété permettant de désactiver la multiselection
 * + TODO: editeur de colonnes font et couleur par défaut, ne pas tout sérializer
 * + TODO: refaire le retaillage des colonnes quand il y a un autosizecolonne
 * 
 * 
 * 2.0.4 01/12/2007
 * + multiselection (by Giorgio)
 * . correction du Drag&Drop (initiative by Giorgio)
 * + ajout  de la propriété AutomaticDropNode, vous permet de gérer vous même le drop quand cette propriété vaut false  
 * 
 * 2.0.3 23/08/2006
 * - TextColor et SelectedColor ne sont plus des gradients, Graphics.DrawString dessine mal le texte
 *  et TextRenderer.DrawText, n'accepte qu'une couleur pour le texte (pas un brush)
 * + //TODO: helper pour grouper des données
 * . scrolling sur colonne fixe à revoir, bug !
 * 
 * 2.0.2 14/08/2006
 * . correction ShowNode, ajout d'un paramètre à ScrollDown
 * . changement de l'event CreateHintwindow
 * 
 * 2.0.1 10/02/2006
 * + //TODO: multiselection
 * + //TODO: proposer des zones sensibles à la souris
 * + événement OnGetNodeWidth, permet de spécifier la largeur noeud, du dessin quand vous effectuer votre
 * 
 * 2.0.0 16/01/2006
 * + passage en .Net 2.0
 * + changement des images des checkbox, check xp
 * + ChecksAreIndependant
 * + utiliser les méthodes de dessins du framework pour le dessin des check box
 * - : suppression de la propriété ImageCheckList
 * + OnDragBegin : permet à l'utilisateur de mettre sa propre donnée dans le drag
 * + Ajout d'une ShowNode pour afficher le noeud au milieu du contrôle
 * + Ajout d'un Designer pour VS 2005
 * . correction drag and drop pb quand le drag voulais demarrer et que l'utilisateur ne l'autorise pas
 * + bien gérer les MouseLeave quand la souris quitte le contrôle
 * 
 * 0.9.0
 * + TODO: Gestion du selected par l'utilisateur (il peut me fournir le noeud selectionner)
 * + 
 * 
 * 0.8.9 27/11/2005
 * + correction ShowNode,
 * + ajout des commentaires 
 * 
 * 0.8.8 16/11/2005
 * + Ajout de Search
 * + Ajout de SelectNode
 * + Ajout de ShowNode, mais petit bug -> ne scroll pas correctement, le noeud reste caché (j'ai l'impression qu'il manque "1" scroll)
 * 
 * 0.8.7 18/08/2005
 * .correction touche tab entre les colonnes
 * + Ajout de OnGetEditRect
 * . renommage de TextAlignment dans la colonne en ContentAlignment
 * + Ajout de AllowEdit sur chaque colonne
 * + Ajout de ContentRect dans PaintInfo
 * + Ajout de OnCellMouseMove
 * + Ajout de OnCellMouseUp
 * + Ajout de Invalidate(INode aNode)
 * + ajout de GetCellRect
 * + ajout du footer
 * . homogénéïsation des paints entre le header et le footer (Before, After)
 * 
 * 0.8.6 18/07/2005
 * . correction clic souris, mousemove
 * + ajout de GeniusDocTab dans l'assembly
 * . Réorganisation des namespaces
 * + Ajout du tri multi-colonnes touche-Ctrl pour ajouter une colonne au tri
 * . correction du tri
 * . gestion de la touche Escape pendant le drag des colonnes
 * 
 * 0.8.5
 * . Correction Drag and drop
 * + Ajout de OnCanDragNode
 * + AutoSizeLastCol dans le header 
 * + indexer [] pour un manipulation des enfant d'un noeud plus rapide
 * 
 * 0.8.4
 * . correction beginEdit
 * + Ajout de l'orientation du texte dans le header
 * 
 * 0.8.3
 * . correction des touches +,-,*,/ quand on est en fullrowselect
 * + customisation du hint window, via IHintWindow 
 * . correction du drag and drop
 * 
 * 0.8.2
 * + style sur GeniusPen
 * 
 * 0.8.1
 * + CellGridLines dans PaintInfo
 * + Colors.FocusedRectangleColor
 * + Colors.UnFocusedRectangleColor
 * 
 * 0.8.0 30/03/2005
 * + CheckNode, unCheckNode
 * . bug HideButtons
 * . bug DrawingOption
 * . bug sur Colors -> serialization des couleurs
 * 
 * 0.7.9  28/03/2005
 * + OnInitEdit
 * + OnAfterEdit
 * 
 * 0.7.8
 * + AllowSort sur le header
 * + GetNodeAtPoint pour l'utilisateur
 * . correction de l'énumeration
 * + DataIsStringProvider
 * + BorderStyle
 * + correction de l'éditeur de texte
 * + UseKeyTab
 * + OnBeforeUnSelect
 * + ImageTreeList
 * 
 * * 0.7.7
 * . correction bug sur le RankNode
 * . correction bug sur OnPaintBackGround, GetBrush(avec un rectangle.width = 0)
 * . élargissement width de noeud de 3 pixels, en mode standard pour avoir un meilleur effet visuel lors de la selection
 * 
 * 0.7.5
 * + recherche incrémentale
 * . renommage de certains évènements 
 * + évènements pour Delete
 * 
 * 0.7.1
 * . scrolls flêche haut et bas
 * .ajout d'interface d'énumération
 * 
 * 0.7.0
 * + FixedColumnCount
 * + si une ligne ne peut être selectionner est que l'on scroll au clavier je passe à la suivante
 * + OnGetHint
 * 
 * 0.6.0
 * + Custom paint
 * . correction du scroll quand les noeud sont de hauteurs differentes
 * . designer de colonnes
 * . FullRowSelect dessin de SelectTextColor sur toute les colonnes, et pas seulement la colonne selectionnée
 * . drag and drop on pouvait dragger un noeud sur lui même
 * 
 * 0.5.0
 * . Performance en ajout
 * . Correction drag-drop entre treeview, il reste un bug quand on drag dans le même tree-view
 * + ajout d'aide sur les méthodes publiques (début)
 * + on peut editer les colonnes en design
 * + on peut personaliser les couleurs en design
 * + bitmap dans la toolbox
 * + custompaint sur le header
 * + FullRowSelect
 * . double-clic n'étendait pas le noeud
 * 
 * 0.1.7
 * . resize des colonnes possible quand il n'existe aucun noeuds
 * . scrollup et scrolldown bug (décalage entre le vue et la position de la scrollbar)
 * + Evenement OnCreateEditor
 * + AutoSort
 * + ComboBoxEditor
 * 0.1.6
 * - HotTrack sur le header
 * 0.1.5
 * + surligner un chemin de la racine jusqu'au(x) noeud(s) choisi(s)
 * ***************************************************************************/
/* **************************************************************************
 * TODO
 * (ok)+ Personalisation des Couleurs
 * (ok)+ Editeurs de colonnes en design
 * + CheckExclusive sur les noeuds d'un même niveau
 * + column Flag devant les noeuds (MainColumn) (peut être, car on peut simuler cet effet avec une colonne suplémentaire)
 * (ok)+ dessin du Drag'n Drop à corriger en mode grille
 * (ok)+ scroll du treeview en drag
 * (ok)+ BeforeDelete, AfterDelete
 * + GeniusLinearGradientBrush : inclure des propriétés de transformation, SetSigmaBellShape, ... 
 * (ok)+ AutoSort
 * + ajouter un cache pour les textes des colonnes 
 * (ok) + selection ligne complète
 * + améliorer l'édition des noeuds, fournir d'autre éditeur Combo, DateTimePicker,...
 * + lors du drag ne pas dessiner la selection
 * + multiselection
 * (ok)+ recherche incrémentale
 * + Hot track sur les noeuds
 * + aide
 * (ok) + image dans le header
 * (ok)+ Icone dans la toolbox de VS2003
 * + personaliser le style et la couleur des lignes de la grille
 * + en mode grille prévoir la selection soit du text, soit de la cellule
 * (ok)+ personaliser les "+"/"-" avec des bitmap fourni par exemple
 * + proposer des thèmes
 * (ok) + trier sur plusieurs colonnes
 * (ok)+ PaintInfo pour la painture personnaliser
 * (ok)+ revoir la gestion des colonnes en design, afin de supprimer ce dummycolonne
 * + Hint sur les headers de colonnes
 * + Escape pendant le drag d'un colonne doit annuler le drag
 * (pas possible)+ permettre le Add au niveau du noeuds
 * + proposer des fonctions CheckNode, UnCheck, SelectPathNode(), UnSelectPathNode, ...
 * + DoCanSelectNode en changement de ligne avec les flêches
 * + GetNodeAt()
 * (ok)+ AllowSort on Colonne
 * (ok)+ BorderStyle
 * (ok)+ Ajouter Count, TotalCount sur Nodes
 * + Gestion de la touche tab dans les editeurs
 * + Gestion de la touche tab sur la dernière colonne
 * + lors du dessin proposer le dessin des lignes en mode grille pour chaque cellule sous forme d'un flag
 * + lors du dessin du noeud principale proposer la liste des treelines parent dans un tableau de booleen
 * (ok)+ bug quand on est en mode grille, avec la selection couleur "emule", quand il perd le focus, 
 *(ok)  la ligne de la grille "top" de le selection s'éfface, 
 *(ok) -> piste invalidaterect(), diminuer le rect du noeud en mode grille
 * . pb lorsque l'on change la visibilité du TopNode 
 * (ok) + ajouter une interface de gestion pour le hint IHintWindow
 * + FixedRows
 * (ok) + image list dans le header
 * .problème de lenteur avec plus de 500 000 noeuds sur un même niveau
 * (ok) + autosize de n'importe qu'elle colonne
 *  
 * *****************************/
namespace Genius.Controls.TreeView
{
    /// <summary>
    /// déléguée pour la demande de la font pour un noeud
    /// </summary>
    public delegate void OnNodeFontDelegate(GeniusTreeView Sender, NodeFontEventArgs e);
    /// <summary>
    /// déléguée pour le clic d'un noeud
    /// </summary>
    public delegate void OnNodeCellMouseDelegate(GeniusTreeView Sender, NodeCellMouseEventArgs e);

    #region Help
    /// <summary>
    /// le contrôle visuel affichant un arbre
    /// </summary>
    #endregion
    [DesignerSerializer(typeof(GeniusTreeViewSerializer), typeof(CodeDomSerializer))]
    [ToolboxBitmap(typeof(GeniusTreeView), "Genius.Controls.Resources.treeview.bmp")]
    [Designer("Genius.Controls.Design.GeniusTreeViewDesigner, Genius.Controls.Design")]
    //, "System.Windows.Forms.Design.ControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class GeniusTreeView : System.Windows.Forms.Control
    {
        #region Variables Membres
        private StringAlignment FAlignment;
        private bool FAllowDrag;
        private bool FAutomaticDropNode;
        private bool FAutoSort;
        private Node FBottomNode;
        /// <summary>
        /// dernier noeud entièrement visible
        /// </summary>
        private Node FLastVisibleNode;
        private GenuisTreeViewColors FColors;
        private IEnumerable FDataSource;
        private int FDefaultNodeHeight;
        private bool FDropHere;
        private Node FDragNode;
        private ITreeViewEdit FEditor;
        private GeniusHeader FHeader;
        private int FHeaderHeight;
        private IHintWindow FHint;
        private ImageList FImageList;
        private ImageList FImageStateList;
        private ImageList FImageTreeList;
        private int FIndentation;
        private bool FInGridMode;
        private Point FLastClick;
        private Nodes FNodes;
        private DrawingOptions FDrawingOption;
        private Node FRoot;
        private ScrollBarsHelper FScrolls;
        private bool FShowHeader;
        private TreeStateEnum FStates;
        private Graphics FTemporaryGraphics;
        private Timers FTimers;
        private Node FTopNode;
        private int FUpdateCount;
        private bool FUpdateScrollBarsNeeded;
        private bool FUseColumns;
        /// <summary>
        /// sert lors du tri afin d'eviter de demander sans arrêt 
        /// le texte du noeud
        /// </summary>
        private IDictionary FCachedText;
        private bool FFullRowSelect;
        /// <summary>
        /// la marge à laisser au début de la colonne principale
        /// </summary>
        private int FMargin;
        private bool FAllowEdit;

        private SearchHelper FSearchHelper;
        /// <summary>
        /// dernier noeud trouvé
        /// </summary>
        private IncrementalSearchOption FIncrementalSearch;
        private SearchDirectionOption FSearchDirection;
        private SearchStartOption FSearchStart;
        private int FSearchColumn;
        /// <summary>
        /// indique si le texte du noeud est fourni par la donnée associée
        /// </summary>
        private bool FDataIsStringProvider;

        private BorderStyle FBorderStyle;
        //private bool					FAutoEdit;
        private bool FUseKeyTab;
        //private int					FFixedRowsCount;
        private Node FLastNodeUnderMouse;
        private int FLastColUnDerMouse;
        private int FFooterHeight;
        private Size FCheckSize;
        private bool FOverCheck;
        private bool FWaitForMouseUp;
        private bool FFastDrawString = true;
        private bool SelectionUP;
        private bool SelectionDOWN;
        private bool _AllowMultiSelect = true;

        #region DragAndDrop
        private DragPosition FDropPosition;
        private Node FDropNode;
        #endregion
        //
        #region Evènements
        /// <summary>
        /// évènement appelé lors de l'initialisation d'un noeud
        /// </summary>
        [Category("Behavior"), Description("appelé lors de l'initialisation d'un noeud")]
        public event OnNodeDelegate OnInitNode;
        /// <summary>
        /// évènement appelé pour demandé le Text du Hint
        /// </summary>
        [Category("Behavior")]
        [Description("permet d'afficher un hint sous la souris")]
        public event OnGetHintDelegate OnGetHint;
        [Category("Behavior"), Description("permet d'interdire/autorise l'expansion d'un noeud, ou d'ajouter des enfants dynamiquement par exemple")]
        public event OnExpandDelegate OnBeforeExpand;
        [Category("Behavior"), Description("se produit après l'expansion d'un noeud")]
        public event OnNodeDelegate OnAfterExpand;
        [Category("Behavior"), Description("se produit avant le replie d'un noeud, il faut passer par cet évènement pour interdire ou pas le replie")]
        public event OnCollapseDelegate OnBeforeCollapse;
        [Category("Behavior"), Description("se produit après le replie d'un noeud")]
        public event OnNodeDelegate OnAfterCollapse;
        [Category("Behavior"), Description("se produit avant l'édition d'un noeud, interdit/autorise l'édition")]
        public event OnCanEditDelegate OnBeforeEdit;
        [Category("Behavior"), Description("se produit avant la selection d'un noeud, autorise/interdit la selection d'un noeud")]
        public event OnSelectDelegate OnBeforeSelect;
        [Category("Behavior"), Description("se produit après la selection d'un noeud")]
        public event OnSelectedDelegate OnAfterSelect;
        //TODO: à passer en public, mais gérer le unselect
        [Category("Behavior")]
        internal event OnUnSelectDelegate OnBeforeUnSelect;
        [Category("Behavior"), Description("spécifie votre méthode de comparaison lors du tri des noeuds")]
        public event OnCompareNodeDelegate OnCompareNode;

        /// <summary>
        /// recupérer la valeur associé au noeud dans le but de comparaison, pour le tri
        /// </summary>
        [Category("Behavior"), Description("utilisé lors du tri, pour comparer sur les valeurs associées au noeuds plutôt qu'aux textes")]
        public event OnGetNodeValueForComparisonDelegate OnGetNodeValue;
        [Category("Behavior"), Description("se produit avant le check d'un noeud, autorise/interdit le check")]
        public event OnCheckDelegate OnBeforeCheck;
        [Category("Behavior"), Description("se produit avant le uncheck d'un noeud, autorise/interdit le uncheck")]
        public event OnUnCheckDelegate OnBeforeUnCheck;
        [Category("Behavior")]
        public event OnNodeDelegate OnAfterCheck;
        [Category("Behavior")]
        public event OnNodeDelegate OnAfterUnCheck;
        [Category("Behavior")]
        public event OnCanDragToDelegate OnCanDragTo;

        [Category("Behavior")]
        [Description("autorise ou interdit le drag d'un noeud")]
        public event OnCanDragDelegate OnCanDragNode;

        [Category("Behavior")]
        public event OnBeforeDeleteDelegate OnBeforeDelete;
        [Category("Behavior")]
        public event OnNodeDelegate OnAfterDelete;
        #region events sur l'edition
        /// <summary>
        /// utilisez cet évènement pour initialiser l'editeur,
        /// comme remplir un combobox
        /// </summary>
        [Category("Behavior")]
        [Description("utilisez cet évènement pour initialiser l'editeur, comme remplir un combobox, affecter la valeur à éditer")]
        public event OnInitEditDelegate OnInitEdit;

        /// <summary>
        /// survient après l'édition
        /// </summary>
        [Category("Behavior")]
        public event OnAfterEditDelegate OnAfterEdit;
        /// <summary>
        /// Permet de définir son propre éditeur
        /// </summary>
        [Category("Behavior"),
        Description("Permet de définir son propre éditeur")]
        public event OnCreateEditorDelegate OnCreateEditor;

        [Category("Behavior"),
        Description("Permet de redéfinir une zone d'édition différente de la zone visuel")]
        public event OnGetEditRectDelegate OnGetEditRect;
        #endregion

        #region events sur le paint
        [Category("Paint"), Description("se produit pour obtenir le texte d'un noeud (ou d'une cellule en mode grille) lors du paint")]
        public event OnGetNodeTextDelegate OnGetNodeText;
        [Category("Paint")]
        public event OnDrawDragNodeDelegate OnDrawDrag;
        [Category("Paint")]
        public event OnPrepareDragNodeDelegate OnPrepareDrag;
        [Category("Paint"), Description("évènement soulevé pour obtenir l'index de l'image (état ou standard) lors du paint d'un noeud")]
        public event OnGetImageIndexDelegate OnGetImageIndex;
        [Category("Paint"), Description("se produit avant la painture des noeuds visible")]
        public event OnPaintNodeDelegate OnBeforePainting;
        /// <summary>
        /// se produit avant le paint d'un noeud, c'est ici que vous coder votre paint
        /// </summary>
        [Category("Paint"), Description("se produit avant le paint d'un noeud, c'est ici que vous coder votre paint")]
        public event OnPaintNodeDelegate OnBeforeNodePainting;
        [Category("Paint"), Description("se produit avant le paint du noeud, placer votre code pour dessiner l'arrière plan du noeud")]
        public event OnPaintNodeDelegate OnPaintNodeBackGround;
        [Category("Paint")]
        public event OnPaintNodeDelegate OnBeforeCellPainting;
        [Category("Paint")]
        public event OnPaintNodeDelegate OnAfterCellPainting;
        [Category("Paint")]
        public event OnPaintNodeDelegate OnAfterNodePainting;
        [Category("Paint")]
        public event OnPaintNodeDelegate OnAfterPainting;
        [Category("Paint"), Description("se produit lors du paint de chaque colonne du header")]
        public event OnDrawHeaderColDelegate OnBeforePaintHeader
        {
            add
            {
                FHeader.OnBeforePaintHeader += value;
            }
            remove
            {
                FHeader.OnBeforePaintHeader -= value;
            }
        }
        [Category("Paint"), Description("se produit à la fin du paint de chaque colonne du header")]
        public event OnDrawHeaderColDelegate OnAfterPaintHeader
        {
            add
            {
                FHeader.OnAfterPaintHeader += value;
            }
            remove
            {
                FHeader.OnAfterPaintHeader -= value;
            }
        }
        [Category("Paint")]
        public event OnNodeFontDelegate OnGetFontNode;

        [Category("Paint")]
        public event OnDrawingNodeTreeLinesDelegate OnDrawTreeLines;

        /// <summary>
        /// événement pour spécifier la largeur que prend le noeud à l'écran, peut être utilisé lorsque vous effectuez votre custom-paint
        /// </summary>
        [Category("Paint"), Description("événement pour spécifier la largeur que prend le noeud à l'écran, peut être utilisé lorsque vous effectuez votre custom-paint")]
        public event EventHandler<GetNodeWidthEventArgs> OnGetNodeWidth;

        [Category("Paint-Footer"), Description("se produit avant le paint du footer")]
        public event OnPaintFooterDelegate OnBeforePaintFooter;
        [Category("Paint-Footer"), Description("se produit après le paint du footer")]
        public event OnPaintFooterDelegate OnAfterPaintFooter;
        [Category("Paint-Footer"),
        Description("récupère le texte du footer à afficher")]
        public event OnFooterGetTextDelegate OnFooterGetText;
        #endregion
        /// <summary>
        /// survient quand on a cliquer sur une cellule
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand on clic sur une cellule")]
        public event OnNodeCellMouseDelegate OnCellMouseDown;

        /// <summary>
        /// survient quand on relache un bouton de la souris
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand on le bouton de la souris est relaché sur une cellule")]
        public event OnNodeCellMouseDelegate OnCellMouseUp;

        /// <summary>
        /// survient quand la souris bouge
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand la souris bouge dans une cellule")]
        public event OnNodeCellMouseDelegate OnCellMouseMove;

        /// <summary>
        /// survient quand la souris quitte une cellule
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand la souris quitte une cellule")]
        public event OnNodeCellMouseDelegate OnCellMouseLeave;

        /// <summary>
        /// survient quand la souris entre dans une cellule
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand la souris entre dans une cellule")]
        public event OnNodeCellMouseDelegate OnCellMouseEnter;

        /// <summary>
        /// survient quant la souris survole un noeud
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand la souris entre sur un noeud")]
        public event OnNodeCellMouseDelegate OnItemMouseEnter;

        /// <summary>
        /// survient quand la souris quitte un noeud
        /// </summary>
        [Category("Mouse"),
        Description("Survient quand la souris quitte un noeud")]
        public event OnNodeCellMouseDelegate OnItemMouseLeave;

        [Description("Permet de définir une autre fenêtre de Hint")]
        [Category("Behavior")]
        public event OnCreateHintWindowDelegate OnCreateHintWindow;

        #region Drag and Drop
        /// <summary>
        /// se déclenche lors du commencement du drag, permet de personaliser la donnée qui est 'dragger'.
        /// Attention ! : vous ne devriez jamais affecter DataToDrag avec un noeud de l'arbre
        /// </summary>
        [Description("se déclenche lors du commencement du drag, permet de personaliser la donnée qui est 'dragger'")]
        [Category("Drag Drop")]
        public event EventHandler<BeginDragEventArgs> OnDragBegin;
        #endregion
        #endregion

        #endregion

        #region constructeur
        /// <summary>
        /// constructeur par défaut
        /// </summary>
        public GeniusTreeView()
        {
            FScrolls = new ScrollBarsHelper(this);
            FColors = new GenuisTreeViewColors();
            FNodes = new Nodes();
            FHeader = new GeniusHeader(this);
            FNodes.OnBeginCheck += new OnCheckInternalDelegate(FNodes_OnBeginCheck);
            FNodes.OnBeginCollapse += new OnCollapseInternalDelegate(FNodes_OnBeginCollapse);
            FNodes.OnBeginExpand += new OnExpandInternalDelegate(FNodes_OnBeginExpand);
            FNodes.OnBeginSelect += new OnSelectInternalDelegate(FNodes_OnBeginSelect);
            FNodes.OnBeginUnCheck += new OnUnCheckInternalDelegate(FNodes_OnBeginUnCheck);
            FNodes.OnBeginUnSelect += new OnUnSelectInternalDelegate(FNodes_OnBeginUnSelect);
            FNodes.OnInitNode = FNodes_OnInitNode;
            FNodes.OnInvalidateNodeNeeded += new OnNodeInternalDelegate(FNodes_OnInvalidateNodeNeeded);
            Clear();
            FDefaultNodeHeight = 18;
            BackColor = SystemColors.Window;
            FIndentation = 16;
            FScrolls.ScrollBars = ScrollBars.Both;
            FScrolls.ScrollBarsAlwaysVisible = false;
            this.SetStyle(ControlStyles.ResizeRedraw
                | ControlStyles.EnableNotifyMessage
                | ControlStyles.Selectable
                | ControlStyles.UserMouse
                , true);
            DoubleBuffered = true;
            FMargin = 0;
            FCheckSize = new Size(13, 13);
            FHeaderHeight = 20;
            FDrawingOption = DrawingOptions.ShowGridLines;
            //FImageCheckList = new ImageList();
            LoadCheckImage();
            FImageTreeList = new ImageList();
            FImageTreeList.ImageSize = new Size(9, 9);
            LoadTreeImage();
            FTimers = new Timers();
            FTimers.OnBeginEdit += new EventHandler(EditTimer_Tick);
            FTimers.OnBeginDragExpand += new EventHandler(ExpandTimer_Tick);
            FTimers.OnBeginScroll += new EventHandler(ScrollTimer_Tick);
            FTimers.OnEndSearch += new EventHandler(FTimers_OnEndSearch);
            FTimers.OnBeginHint += new EventHandler(FTimers_OnBeginHint);
            FFullRowSelect = false;
            FAllowEdit = true;
            FSearchStart = SearchStartOption.FocusedNode;
            FIncrementalSearch = IncrementalSearchOption.VisibleOnly;
            //SystemInformation.MenuCheckSize
            FSearchHelper = null;
            FBorderStyle = BorderStyle.None;
            //FFixedRowsCount = 3;
            FLastNodeUnderMouse = null;
            FLastColUnDerMouse = Constants.InvalidColumn;
            FFooterHeight = 0;
            FAutomaticDropNode = true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Result = base.CreateParams;

                Result.Style |= 0xc0;
                Result.ExStyle &= -513;
                Result.Style &= -8388609;

                switch (this.BorderStyle)
                {
                    case BorderStyle.FixedSingle:
                        {
                            Result.Style |= 0x800000;
                            break;
                        }
                    case BorderStyle.Fixed3D:
                        {
                            Result.ExStyle |= 0x200;
                            break;
                        }
                }
                Result.ClassStyle |= (int)(WindowClassStyle.CS_HREDRAW | WindowClassStyle.CS_VREDRAW);
                return Result;
            }
        }

        #endregion

        #region méthodes privées
        private Assembly CurrentAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        private void LoadImages(ImageList images, string[] resources, Assembly assembly)
        {
            foreach (string image in resources)
            {
                Stream stm = assembly.GetManifestResourceStream(image);
                images.Images.Add(new Bitmap(stm), Color.Fuchsia);
            }
        }

        private void LoadCheckImage()
        {
            string[] checks = new string[]{"Genius.Controls.Resources.uncheck.bmp",
			"Genius.Controls.Resources.uncheckdisabled.bmp",
			"Genius.Controls.Resources.check.bmp",
			"Genius.Controls.Resources.checkdisabled.bmp",
            "Genius.Controls.Resources.checkindeterminate.bmp",
            "Genius.Controls.Resources.checkindeterminatedisabled.bmp"};

            //LoadImages(FImageCheckList, checks, CurrentAssembly);
            using (Graphics g = this.CreateGraphics())
            {
                FCheckSize = CheckBoxRenderer.GetGlyphSize(g, System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
        }

        private void LoadTreeImage()
        {
            string[] images = new string[]{"Genius.Controls.Resources.plus.bmp",
											  "Genius.Controls.Resources.moins.bmp"};

            LoadImages(FImageTreeList, images, CurrentAssembly);
        }

        #region gestion des ensembles
        private void Exclude(ref TreeStateEnum ens, TreeStateEnum value)
        {
            ens &= (~value);
        }

        private void Include(ref TreeStateEnum ens, TreeStateEnum value)
        {
            ens |= value;
        }

        private bool Contains(TreeStateEnum ens, TreeStateEnum value)
        {
            return Contains((int)ens, (int)value);
        }

        private void Include(ref HitPositionsEnum ens, HitPositionsEnum value)
        {
            ens |= value;
        }

        private bool Contains(HitPositionsEnum ens, HitPositionsEnum value)
        {
            return Contains((int)ens, (int)value);
        }

        private void Exclude(ref NodeState ens, NodeState value)
        {
            ens &= (~value);
        }

        internal bool Contains(int ens, int value)
        {
            return ((ens & value) == value);
        }

        private bool Contains(NodeState ens, NodeState value)
        {
            return Contains((int)ens, (int)value);
        }

        private bool Contains(DrawingOptions ens, DrawingOptions value)
        {
            return Contains((int)ens, (int)value);
        }

        #endregion

        #region gestion des noeuds et de leur propriétés
        internal Timers GetTimers
        {
            get
            {
                return FTimers;
            }
        }

        #endregion

        private Node InternalBottomNode()
        {
            if (FBottomNode == null)
            {
                int h;
                FBottomNode = CalcBottomOfHeight(InternalTopNode(), this.TreeRectangle.Height, out h, false);
                FLastVisibleNode = CalcLastVisibleNode(InternalTopNode(), this.TreeRectangle.Height, true);
            }
            return FBottomNode;
        }

        private Node LastVisibleNode()
        {
            if (FLastVisibleNode == null)
            {
                FLastVisibleNode = CalcLastVisibleNode(InternalTopNode(), this.TreeRectangle.Height, true);
            }
            return FLastVisibleNode;
        }

        private Node InternalTopNode()
        {
            if (FTopNode == null)
                FTopNode = NextVisibleNode(FRoot);
            return FTopNode;
        }

        private void RecalculTopNode()
        {
            int ypos = 0;
            FTopNode = null;
            InternalTopNode();
            int dy = FScrolls.OffsetY;
            while (dy > 0 && FTopNode != null && dy >= FTopNode.Height)
            {
                dy -= FTopNode.Height;
                ypos += FTopNode.Height;
                FTopNode = NextVisibleNode(FTopNode);
            }
            if (ypos > 0 && ypos != dy)
            {
                FScrolls.OffsetY = ypos;
            }
        }

        private int ImageStateWidth()
        {
            return (FImageStateList != null ? FImageStateList.ImageSize.Width : 0);
        }

        private int ImageStateHeight()
        {
            return (FImageStateList != null ? FImageStateList.ImageSize.Height : 0);
        }

        private int ImageWidth()
        {
            return (FImageList != null ? FImageList.ImageSize.Width : 0);
        }

        private int ImageCheckWidth()
        {
            return FCheckSize.Width;
            //return (FImageCheckList != null ? FImageCheckList.ImageSize.Width : 0);
        }

        private int ImageCheckHeight()
        {
            return FCheckSize.Height;
            //return (FImageCheckList != null ? FImageCheckList.ImageSize.Height : 0);
        }

        private int ImageHeight()
        {
            return (FImageList != null ? FImageList.ImageSize.Height : 0);
        }
        private int GetHeaderHeight()
        {
            return (ShowHeader ? HeaderHeight : 0);
        }

        private int MainColumnX
        {
            get
            {
                if (UseColumns && FHeader.MainColumnIndex > Constants.NoColumn)
                    return FHeader.Left(FHeader.MainColumnDisplayIndex);
                else
                    return 0;
            }
        }

        private int MainColumnIndex
        {
            get
            {
                return UseColumns ? FHeader.MainColumnDisplayIndex : 0;
            }
        }
        #endregion

        #region méthodes privées
        private Node NextSiblingVisibleNode(Node aNode)
        {
            return Node.NextSiblingVisibleNode(aNode);
        }

        internal Node NextVisibleNode(Node aNode)
        {
            return Node.NextVisibleNode(aNode);
        }

        private Node LastVisibleNode(Node aParent)
        {
            return Node.LastVisibleNode(aParent);
        }

        private bool IsFullyVisible(Node aNode)
        {
            return Node.IsFullyVisible(aNode);
        }

        private bool IsExpanded(Node aNode)
        {
            return Node.IsExpanded(aNode);
        }

        internal Node PrevVisibleNode(Node aNode)
        {
            return Node.PrevVisibleNode(aNode);
        }

        internal Node NextVisibleOrNotNode(Node aNode)
        {
            Node run = Node.NextNode(aNode);
            while (run != null && !Set.Contains(aNode.State, NodeState.Visible))
            {
                run = Node.NextNode(run);
            }
            return run;
        }

        internal Node PrevVisibleOrNotNode(Node aNode)
        {
            Node run = Node.PrevNode(aNode);
            while (run != null && !Set.Contains(aNode.State, NodeState.Visible))
            {
                run = Node.PrevNode(run);
            }
            return run;
        }

        private Node GetNodeAt(Point aPt, out Point aNodePoint)
        {
            Node Result;
            Rectangle rNode;
            int startY;

            startY = 0;
            aNodePoint = new Point(0, 0);

            Result = InternalTopNode();
            while (Result != null)
            {
                rNode = new Rectangle(0, startY, this.Width, Result.TotalHeight);
                startY += Result.Height;
                if (rNode.Contains(aPt))
                {
                    rNode.Height = Result.Height;
                    if (Result.ChildCount > 0 && !rNode.Contains(aPt))
                        Result = NextVisibleNode(Result);
                    else
                    {
                        aNodePoint.X = MainColumnX + MainNodeWidth(Result);
                        aNodePoint.Y = rNode.Top;
                        return Result;
                    }
                }
                else
                    Result = NextVisibleNode(Result);
            }
            return null;
        }

        private int GetNodeLevel(Node aNode)
        {
            return Node.GetNodeLevel(aNode);
        }

        #region dessin
        private Graphics TemporaryGraphics
        {
            get
            {
                if (FTemporaryGraphics == null)
                    FTemporaryGraphics = this.CreateGraphics();
                return FTemporaryGraphics;
            }
        }

        private int GetColumnAndBounds(Point aPt, ref int ColumnLeft, ref int ColumnRight, bool relative)
        {
            if (relative)
                ColumnLeft = -FScrolls.OffsetX;
            else
                ColumnLeft = 0;
            if (UseColumns && aPt.X < FHeader.FixedColumnWidth)
            {
                ColumnLeft = 0;
            }
            for (int i = 0; i < FHeader.Count; i++)
            {
                GeniusTreeViewColonne col = FHeader.DisplayColonnes(i);
                if (col.Visible)
                {
                    ColumnRight = ColumnLeft + col.Width;
                    if (aPt.X < ColumnRight)
                        return i;
                }
                ColumnLeft = ColumnRight;
            }
            return Constants.InvalidColumn;
        }

        internal void InvalidateTree()
        {
            if (FUpdateCount == 0)
            {
                if (FUpdateScrollBarsNeeded)
                {
                    FUpdateScrollBarsNeeded = false;
                    UpdateScrollBars(true);
                }
                StartPaint(this.ClientRectangle);
                //Invalidate();
                if (FHeader != null && ShowHeader)
                    FHeader.Invalidate();
            }
        }

        private Rectangle FooterRect
        {
            get
            {
                Rectangle Result = this.ClientRectangle;
                Result.Y = Result.Bottom - FFooterHeight;
                Result.Height = FFooterHeight;
                return Result;
            }
        }

        private Rectangle TreeRectangle
        {
            get
            {
                Rectangle Result = this.ClientRectangle;
                Result.Height -= (FFooterHeight);
                return Result;
            }
        }

        private Rectangle GetNodeRect(Node aNode)
        {
            Rectangle Result = TreeRectangle;
            Node n = InternalTopNode();
            Node nb = NextVisibleNode(LastVisibleNode());
            while (n != nb)
            {
                Result.Height = n.Height;
                if (n == aNode)
                    return Result;
                Result.Offset(0, n.Height);
                n = NextVisibleNode(n);
            }
            return Rectangle.Empty;
        }

        private Rectangle GetMainNodeRect(Node aNode)
        {
            Rectangle Result = GetNodeRect(aNode);
            if (!Result.IsEmpty)
            {
                Result.X = MainColumnX;
                if (UseColumns)
                    Result.Width = FHeader.DisplayColonnes(MainColumnIndex).Width;
                else
                    Result.Width = GetMaxWidth();
            }
            return Result;
        }

        /// <summary>
        /// renvoi le rectangle du texte de la colonne principale
        /// </summary>
        /// <param name="aNode"></param>
        /// <returns></returns>
        private Rectangle GetTextRect(Node aNode)
        {
            Rectangle Result;

            Result = GetNodeRect(aNode);
            Result.Width = aNode.Width;
            //int cx = MainNodeWidth(aNode) + MainColumnX - FScrolls.OffsetX;
            int cx = MainNodeWidth(aNode) + MainColumnX;
            if (Contains(aNode.State, NodeState.HasCheck))
                cx += FCheckSize.Width;
            if (aNode.ImageIndex >= 0 && FImageList != null && FImageList.Images.Count > aNode.ImageIndex)
                cx += ImageWidth() + 2;
            if (aNode.ImageStateIndex >= 0 && FImageStateList != null && FImageStateList.Images.Count > aNode.ImageStateIndex)
                cx += ImageStateWidth() + 2;
            Result.Offset(cx, 0);
            if (UseColumns)
                Result.Width = FHeader.DisplayColonnes(FHeader.MainColumnDisplayIndex).Width - (Result.Left - MainColumnX);
            return Result;
        }

        private Rectangle GetTextRect(Node aNode, int aColIndex)
        {
            if (!UseColumns || aColIndex == MainColumnIndex)
                return GetTextRect(aNode);
            else
            {
                Rectangle Result = GetNodeRect(aNode);
                //int left = FHeader.Left(aColIndex) - FScrolls.OffsetX;
                int left = FHeader.Left(aColIndex);
                Result.Width = FHeader.DisplayColonnes(aColIndex).Width;
                Result.X = left;
                return Result;
            }
        }

        /// <summary>
        /// retourne le rectangle visuel d'une cellule
        /// </summary>
        /// <param name="aNode">le noeud dont on veut le rectangle</param>
        /// <param name="aDisplayColumn">la colonne concernée</param>
        /// <returns>un rectangle vide si le noeud nexiste pas 
        ///  ou aDisplayColumn n'est pas dans la plage des colonnes visible
        ///  ou la colonne est caché pas les colonnes fixent
        /// </returns>
        public Rectangle GetCellRect(INode aNode, int aDisplayColumn)
        {

            if (aNode == null || aDisplayColumn < 0 || aDisplayColumn >= FHeader.Displays.Count)
                return Rectangle.Empty;

            Rectangle Result = GetNodeRect((Node)aNode);
            if (Result.IsEmpty)
                return Result;
            Result.X = FHeader.Left(aDisplayColumn);
            Result.Width = FHeader.DisplayColonnes(aDisplayColumn).Width;
            int fixedWith = FHeader.FixedColumnWidth;
            if (aDisplayColumn > FHeader.FixedColumnCount && Result.Left < fixedWith)
            {
                int diff = fixedWith - Result.Left;
                Result.X = fixedWith;
                Result.Width -= fixedWith;
                if (Result.Width < 0)
                    Result = Rectangle.Empty;
            }
            return Result;
        }

        /// <summary>
        /// renvoi le rectangle d'une ligne complète pour un noeud donné
        /// </summary>
        /// <param name="aNode"></param>
        /// <returns></returns>
        public Rectangle GetNodeRect(INode aNode)
        {
            return this.GetNodeRect((Node)aNode);
        }

        internal void InvalidateNode(Node aNode)
        {
            if (FUpdateCount != 0)
                return;
            string rankTop = FNodes.RankNode(InternalTopNode());
            string rankBottom = FNodes.RankNode(InternalBottomNode());
            string rank = FNodes.RankNode(aNode);
            if (rank.CompareTo(rankTop) >= 0 && rank.CompareTo(rankBottom) <= 0)
            {
                Rectangle rNode = GetNodeRect(aNode);
                Rectangle rRect = TreeRectangle;
                if (rRect.IntersectsWith(rNode))
                {
                    rRect.Intersect(rNode);
                    //TODO: revoir la mise à jour des scrolls car GetMaxWidth peut être pénalisant en terme de perf...
                    UpdateScrollBars(aNode, 0);
                    //Invalidate(rRect);
                    StartPaint(rRect);
                }
            }
        }

        /// <summary>
        /// invalide un noeud, provoque le redessin
        /// </summary>
        /// <param name="aNode"></param>
        public void Invalidate(INode aNode)
        {
            InvalidateNode((Node)aNode);
        }

        #region dessin des lignes
        private bool HasSignaledAfter(Node aNode)
        {

            while (aNode != null)
            {
                if (aNode.TotalSignaled > 0 || Set.Contains(aNode.State, NodeState.Signaled))
                    return true;
                aNode = NextSiblingVisibleNode(aNode);
            }
            return false;
        }
        private void DrawLines(Node aNode, Graphics g, Point NodePoint, DrawingOptions option)
        {
            Pen linecolor = FColors.LinesColor;
            Pen sigColor = FColors.SignaledColor;
            Rectangle rExpand = Rectangle.Empty;
            RectangleF rClip = RectangleF.Empty;
            int aLevel = GetNodeLevel(aNode);
            int DecalX = NodePoint.X;
            int height = aNode.Height;
            bool signaled = Set.Contains(aNode.State, NodeState.Signaled) | (aNode.TotalSignaled > 0);
            bool otherSignaled = (aNode.Parent.TotalSignaled > 0) && HasSignaledAfter(NextSiblingVisibleNode(aNode));
            Node nextSibling = NextSiblingVisibleNode(aNode);
            Node prevSibling = aNode.PrevSibling; /*PrevSiblingVisibleNode(aNode)*/

            while (prevSibling != null && !Set.Contains(prevSibling.State, NodeState.Visible))
                prevSibling = prevSibling.PrevSibling;
            if (Contains(aNode.State, NodeState.HasChildren))
            {
                Point centre = new Point(DecalX - Indentation / 2, NodePoint.Y + height / 2);
                rExpand = new Rectangle(centre, new Size(0, 0));
                if (FImageTreeList != null)
                    rExpand.Inflate(FImageTreeList.ImageSize.Width / 2, FImageTreeList.ImageSize.Height / 2);
                else
                    rExpand.Inflate(4, 4);
                rClip = g.ClipBounds;
                g.ExcludeClip(rExpand);
            }
            if (!Contains(option, DrawingOptions.HideTreeLines))
            {
                if (prevSibling != null)
                {
                    if (nextSibling != null)
                    {
                        if (signaled)
                        {
                            g.DrawLine(otherSignaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y + aNode.Height / 2),
                                new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height));
                            g.DrawLine(sigColor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y),
                                new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height / 2));
                        }
                        else
                        {
                            //dessin de la ligne vertical entre mon "frère" précédent et le suivant
                            g.DrawLine(otherSignaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y),
                                new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height));
                        }
                    }
                    else
                    {
                        //dessin de la ligne vertical du dernier fils
                        g.DrawLine(signaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y),
                            new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height / 2));
                    }
                }
                else
                {
                    if (nextSibling != null)
                    {
                        if (aNode.Parent != FRoot)
                        {
                            if (signaled)
                            {
                                g.DrawLine(otherSignaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y + aNode.Height / 2),
                                    new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height));
                                g.DrawLine(sigColor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y),
                                    new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height / 2));
                            }
                            else
                                //dessin de la ligne vertical entre mon "père"  et le noeud suivant
                                g.DrawLine(otherSignaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y),
                                    new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height));
                        }
                        else
                        {
                            //dessin de la ligne vertical entre moi et le noeud suivant
                            g.DrawLine(/*signaled |*/ otherSignaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y + aNode.Height / 2),
                                new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height));
                        }
                    }
                    else if (aNode.Parent != FRoot)
                    {
                        //je suis le seul fils
                        g.DrawLine(signaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2, NodePoint.Y),
                            new Point(NodePoint.X - Indentation / 2, NodePoint.Y + height / 2));
                    }
                }
                //ligne horizontale qui relie (link) le noeud à sa ligne de vie
                g.DrawLine(signaled ? sigColor : linecolor, new Point(NodePoint.X - Indentation / 2 + 1, NodePoint.Y + height / 2),
                    new Point(NodePoint.X, NodePoint.Y + height / 2));

            }
            //dessin de l'expand
            if (rExpand != Rectangle.Empty && !Contains(DefaultDrawingOption, DrawingOptions.HideButtons))
            {
                g.SetClip(rClip, System.Drawing.Drawing2D.CombineMode.Replace);
                if (FImageTreeList != null)
                {
                    FImageTreeList.Draw(g, rExpand.X, rExpand.Y, Contains(aNode.State, NodeState.Expanded) ? 1 : 0);
                }
                else
                    using (Pen p = new Pen(linecolor.Color, 1))
                    {
                        g.DrawRectangle(p, rExpand);
                        if (!Contains(aNode.State, NodeState.Expanded))
                        {
                            g.DrawLine(p, new Point(NodePoint.X - Indentation / 2, rExpand.Top + 2),
                                new Point(NodePoint.X - Indentation / 2, rExpand.Bottom - 2));

                        }
                        g.DrawLine(p, new Point(rExpand.Left + 2, NodePoint.Y + height / 2),
                            new Point(rExpand.Right - 2, NodePoint.Y + height / 2));
                    }
            }
            NodeDrawingTreeLinesEventArgs ev = null;
            //dessin (drawing) des lignes des parents
            ev = new NodeDrawingTreeLinesEventArgs(aNode);

            while (--aLevel > 0)
            {
                aNode = aNode.Parent;
                DecalX -= Indentation;
                if (NextSiblingVisibleNode(aNode) != null)
                {
                    ev.Draw = !Contains(DefaultDrawingOption, DrawingOptions.HideTreeLines);
                    if (OnDrawTreeLines != null)
                    {
                        ev.SetNode(aNode);
                        OnDrawTreeLines(this, ev);
                    }
                    if (ev.Draw)
                    {
                        otherSignaled = (aNode.Parent.TotalSignaled > 0) && HasSignaledAfter(NextSiblingVisibleNode(aNode));
                        g.DrawLine(otherSignaled ? sigColor : linecolor, new Point(DecalX - Indentation / 2, NodePoint.Y),
                            new Point(DecalX - Indentation / 2, NodePoint.Y + height));
                    }
                }

            }
        }
        #endregion

        private void DrawCheck(Node aNode, Graphics g, Point NodePoint, PaintInfo paintinfo)
        {
            if (Contains(aNode.State, NodeState.HasCheck))
            {
                CheckBoxState checkstate = CheckBoxState.UncheckedNormal;
                int cy = (aNode.Height - ImageCheckHeight()) / 2;
                Rectangle r = new Rectangle(NodePoint.X, NodePoint.Y, ImageCheckWidth(), ImageCheckWidth());
                Point p = paintinfo.MousePosition;
                if (this.IndependantCheckboxes)
                {
                    checkstate = (CheckBoxState)((int)checkstate + Convert.ToInt16(Contains(aNode.State, NodeState.Checked)) * 4);
                }
                else
                {
                    if (aNode.TotalCheck != aNode.TotalChecked && aNode.TotalChecked > 0)
                        checkstate = CheckBoxState.MixedNormal;
                    else if ((aNode.TotalCheck == aNode.TotalChecked && aNode.TotalChecked > 0)
                                 || (aNode.TotalCheck == 0 && Contains(aNode.State, NodeState.Checked)))
                        checkstate = CheckBoxState.CheckedNormal;
                    else
                        checkstate = CheckBoxState.UncheckedNormal;
                }
                if (r.Contains(p))
                    checkstate = (CheckBoxState)((int)checkstate + 1);
                CheckBoxRenderer.DrawCheckBox(g, new Point(NodePoint.X, NodePoint.Y + cy), checkstate);
                //0 : uncheck
                //1 : uncheck disabled
                //2 : check
                //3 : check disabled
                //4 : indeterminé
                //5 : indeterminé disabled
                /*
				Image check;
                int thisIsEnabled = (int)Convert.ToInt16(!Enabled);
                if (this.IndependantCheckboxes)
                {
                    int checkindex = Convert.ToInt16(Contains(aNode.State, NodeState.Checked)) * 2;
                    check = FImageCheckList.Images[checkindex + thisIsEnabled];
                }
                else
                {
                    if (aNode.TotalCheck != aNode.TotalChecked && aNode.TotalChecked > 0)
                        check = FImageCheckList.Images[4 + thisIsEnabled];
                    else if ((aNode.TotalCheck == aNode.TotalChecked && aNode.TotalChecked > 0)
                        || (aNode.TotalCheck == 0 && Contains(aNode.State, NodeState.Checked)))
                        check = FImageCheckList.Images[2 + thisIsEnabled];
                    else
                        check = FImageCheckList.Images[0 + thisIsEnabled];
                }
				int cy = (aNode.Height - ImageCheckHeight()) / 2;
				g.DrawImage(check, NodePoint.X, NodePoint.Y + cy, ImageCheckHeight(), ImageCheckWidth());
                 * 
                */
            }
        }

        #region calcul largeur noeud
        private int GetMaxWidth()
        {
            Rectangle rClient = TreeRectangle;
            int Result = 0;
            if (!UseColumns)
            {
                Node top = InternalTopNode();
                while (top != null && rClient.Height > 0)
                {
                    int nodeWidth = Indentation * GetNodeLevel(top);
                    if (top.ImageIndex >= 0)
                        nodeWidth += ImageWidth() + 2;
                    if (top.ImageStateIndex >= 0)
                        nodeWidth += ImageStateWidth() + 2;
                    if (Contains(top.State, NodeState.HasCheck))
                        nodeWidth += FCheckSize.Width + 2;
                    if (top.Width == 0)
                        top.Width = GetNodeWidth(top, MainColumnIndex);
                    nodeWidth += top.Width;
                    Result = Math.Max(Result, nodeWidth);
                    rClient.Height -= top.Height;
                    top = NextVisibleNode(top);
                }
                Result += FMargin;
            }
            else
            {
                Result = FHeader.Width;
            }
            return Result;
        }

        internal void UpdateScrollBars(bool redraw)
        {
            FScrolls.RangeY = FRoot.TotalHeight;//+ (ShowHeader ? HeaderHeight : 0);
            UpdateHorizontalScrollBar();
        }

        internal void UpdateHorizontalScrollBar()
        {
            FScrolls.RangeX = GetMaxWidth() + 1;
        }

        private void UpdateScrollBars(Node n, int height)
        {
            FScrolls.RangeY = FRoot.TotalHeight;
            if (height != 0 && FTopNode != null && FNodes.RankNode(n).CompareTo(FNodes.RankNode(InternalTopNode())) < 0)
            {
                FScrolls.OffsetY += height;
                if (FScrolls.OffsetY < 0)
                    FScrolls.OffsetY = 0;
            }
            UpdateHorizontalScrollBar();
        }
        #endregion

        #region Dessin du noeud principal
        private void DrawDropMark(Graphics g, Node aNode, Rectangle aRect)
        {
            if (FDropPosition != DragPosition.None)
            {
                using (Pen p = new Pen(Color.Black, 3))
                {
                    p.EndCap = LineCap.ArrowAnchor;

                    int x = aRect.Left + MainNodeWidth(aNode);
                    if (FDropPosition == DragPosition.Before)
                    {
                        g.DrawLine(Pens.Black, aRect.Left, aRect.Top, aRect.Right, aRect.Top);
                        g.DrawLine(p, x, aRect.Top, x + 1, aRect.Top);
                    }
                    else
                    {
                        g.DrawLine(Pens.Black, aRect.Left, aRect.Bottom, aRect.Right, aRect.Bottom);
                        if (FDropPosition == DragPosition.After)
                            g.DrawLine(p, x, aRect.Bottom, x + 1, aRect.Bottom);
                        else
                            g.DrawLine(p, x + 16, aRect.Bottom, x + 17, aRect.Bottom);
                    }
                }
            }
        }
        #endregion

        #region dessin du footer
        private void PaintFooterCol(GeniusTreeViewColonne col, Graphics g, Rectangle rCol)
        {
            Brush br = null;
            int aDisplayCol = col != null ? this.Header.IndexOfDisplay(col) : Constants.NoColumn;

            PaintFooterEventArgs e = new PaintFooterEventArgs(g, aDisplayCol, rCol);
            if (DoBeforePaintFooter(e))
            {
                if (col != null)
                    br = col.BackColor.GetBrush(rCol);
                if (br == null)
                    br = new SolidBrush(this.BackColor);
                using (br)
                {
                    FooterTextEventArgs ev = new FooterTextEventArgs(aDisplayCol);
                    ev.Font = col != null ? col.FontColonne : this.Font;
                    ev.ForeColor = col != null ? col.ForeColor : Color.Empty;
                    StringFormat sf = new StringFormat();
                    sf.Alignment = col != null ? col.ContentAlignment : StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Center;
                    ev.Format = sf;
                    DoGetFooterText(ev);

                    g.FillRectangle(br, rCol);

                    if (ev.Text != null && ev.Text.Length > 0 && ev.Font != null)
                    {
                        Color foreColor = ev.ForeColor;
                        if (foreColor == Color.Empty)
                            foreColor = this.ForeColor;
                        if (this.FastDrawString)
                            g.DrawString(ev.Text, ev.Font, new SolidBrush(foreColor), rCol, ev.Format);
                        else
                            TextRenderer.DrawText(g, ev.Text, ev.Font, rCol, foreColor, DrawingHelper.StringFormatToTextFormatFlags(ev.Format));
                    }
                }
            }
            DoAfterPaintFooter(e);
        }

        private bool DoBeforePaintFooter(PaintFooterEventArgs e)
        {
            if (OnBeforePaintFooter != null)
                OnBeforePaintFooter(this, e);
            return e.DefaultDrawing;
        }

        private void DoAfterPaintFooter(PaintFooterEventArgs e)
        {
            if (OnAfterPaintFooter != null)
                OnAfterPaintFooter(this, e);
        }

        private void DoGetFooterText(FooterTextEventArgs e)
        {
            if (OnFooterGetText != null)
                OnFooterGetText(this, e);
        }

        private void PaintFooter(Graphics g, Rectangle aRect, Rectangle aClipRect)
        {
            if (FFooterHeight > 0 && aRect.IntersectsWith(aClipRect))
            {
                #region Dessine en mode grille
                if (UseColumns)
                {
                    Rectangle rCol = aRect;
                    rCol.Offset(-this.OffsetX, 0);
                    int fixedWidth = FHeader.FixedColumnWidth;
                    int i = -1;
                    foreach (GeniusTreeViewColonne col in FHeader.Displays)
                    {
                        if (!col.Visible)
                            continue;
                        i++;
                        rCol.Width = col.Width;
                        if (aRect.IntersectsWith(rCol) && rCol.Width > 0 && i >= FHeader.FixedColumnCount && rCol.Right > fixedWidth)
                            PaintFooterCol(col, g, rCol);
                        rCol.Offset(col.Width, 0);
                    }
                    if (FHeader.FixedColumnCount > 0)
                    {
                        //dessin des colonnes fixes
                        rCol = aRect;
                        i = 0;
                        foreach (GeniusTreeViewColonne col in FHeader.Displays)
                        {
                            if (!col.Visible)
                                continue;
                            if (i < FHeader.FixedColumnCount)
                            {
                                rCol.Width = col.Width;
                                if (aRect.IntersectsWith(rCol) && rCol.Width > 0)
                                    PaintFooterCol(col, g, rCol);
                                rCol.Offset(col.Width, 0);
                                i++;
                            }
                            else
                                break;
                        }
                    }
                }
                #endregion
                #region Dessin en mode normal
                else
                {
                    PaintFooterCol(null, g, aRect);
                }
                #endregion
            }
        }
        #endregion

        private Node PaintTree(Graphics g, Rectangle aRect)
        {
            Point NodePointOrg;
            Node n = GetNodeAt(new Point(aRect.Left, aRect.Top), out NodePointOrg);
            return PaintTree(g, aRect, n, false);
        }

        private Node PaintTree(Graphics g, Rectangle aRect, Node aNode, bool dragImage)
        {
            Rectangle rCell;
            int fixedWidth = FHeader.FixedColumnWidth;
            Node bottom;
            Lines currentNodeLines;

            bottom = null;

            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            //g.InterpolationMode = InterpolationMode.Default;
            //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            Rectangle R = aRect;
            Rectangle rNode = aRect;

            PaintInfo paintinfo = CreatePaintInfo();
            paintinfo.FNode = aNode;
            paintinfo.FClipRect = aRect;
            paintinfo.FNodeRect = Rectangle.Empty;
            paintinfo.ContentRect = Rectangle.Empty;
            paintinfo.FGraphics = g;
            paintinfo.DisplayColumn = Constants.NoColumn;
            paintinfo.FButtons = System.Windows.Forms.Control.MouseButtons;
            DoBeginPainting(paintinfo);
            if (paintinfo.FNode != null && !dragImage)
            {
                R.X = 0;
                R.Y = paintinfo.FNode.TopPosition - FScrolls.OffsetY;
                R.Width = TreeRectangle.Width + this.OffsetX - 0;
                R.Offset(-this.OffsetX, 0);
            }
            while (paintinfo.FNode != null && R.Top < aRect.Bottom)
            {
                R.Height = paintinfo.FNode.Height;
                paintinfo.FNodeRect = R;
                rNode = R;
                paintinfo.ContentRect = R;
                paintinfo.DrawingOptions = this.DefaultDrawingOption;
                if (!DoBeforeNodePainting(paintinfo))
                {
                    #region dessin en mode grille
                    if (UseColumns)
                    {
                        if (Contains(paintinfo.DrawingOptions, DrawingOptions.ShowHorzLines))
                        {
                            if (paintinfo.FNode == this.TopNode())
                            {   //FColors.GridLinesColor.DashStyle = DashStyle.DashDot;
                                int maxwidth = Math.Min(FHeader.Width - FScrolls.OffsetX, TreeRectangle.Width);
                                g.DrawLine(FColors.GridLinesColor, 0, R.Y, maxwidth, R.Y);
                            }
                            paintinfo.FNodeRect.Height -= 1;
                            paintinfo.FNodeRect.Offset(0, 1);
                            rNode = paintinfo.FNodeRect;
                        }
                        DoPaintNodeBackGround(paintinfo);
                        RectangleF oldClip;

                        oldClip = g.ClipBounds;
                        try
                        {
                            int offset = 0;
                            //iDisplayColumn = 0;
                            GeniusTreeViewColonne[] displays = FHeader.GetDisplays();
                            for (int i = 0; i < displays.Length; i++)
                            {
                                GeniusTreeViewColonne colonne = displays[i];
                                if (!colonne.Visible)
                                    continue;
                                if (fixedWidth > 0)
                                {
                                    if (i == 0)
                                        paintinfo.FNodeRect.Offset(this.OffsetX, 0);
                                    else if (i < FHeader.FixedColumnCount)
                                        paintinfo.FNodeRect.Offset(offset, 0);
                                    else if (i == FHeader.FixedColumnCount)
                                        paintinfo.FNodeRect.Offset(-this.OffsetX + offset, 0);
                                    else
                                        paintinfo.FNodeRect.Offset(offset, 0);
                                }
                                else
                                    paintinfo.FNodeRect.Offset(offset, 0);
                                paintinfo.FNodeRect.Width = colonne.Width;
                                paintinfo.DisplayColumn = i;//iDisplayColumn++;
                                offset = colonne.Width;
                                if (!aRect.IntersectsWith(paintinfo.FNodeRect))
                                    continue;

                                g.SetClip(paintinfo.FNodeRect, CombineMode.Replace);
                                if (fixedWidth > 0 && i >= FHeader.FixedColumnCount)
                                    g.ExcludeClip(new Rectangle(0, 0, fixedWidth, TreeRectangle.Height));
                                paintinfo.Font = GetFontNode(paintinfo.FNode, paintinfo.DisplayColumn);
                                paintinfo.ForeColor = GetForeColor(paintinfo.FNode, paintinfo.DisplayColumn);
                                paintinfo.StringFormat = GetStringFormat(paintinfo.FNode, paintinfo.DisplayColumn);
                                paintinfo.CellGridLines = Contains(paintinfo.DrawingOptions, DrawingOptions.ShowHorzLines) ? Lines.Horizontal : Lines.None;
                                paintinfo.CellGridLines |= Contains(paintinfo.DrawingOptions, DrawingOptions.ShowVertLines) ? Lines.Vertical : Lines.None;
                                paintinfo.ContentRect = paintinfo.NodeRect;
                                paintinfo.FClipRect = Rectangle.Round(g.ClipBounds);
                                if (!DoBeforeCellPainting(paintinfo))
                                {
                                    rCell = paintinfo.FNodeRect;
                                    DoPaintCell(paintinfo);
                                    paintinfo.FNodeRect = rCell;
                                    DoAfterCellPainting(paintinfo);
                                }
                                //Dessin des lignes de la cellule
                                currentNodeLines = paintinfo.CellGridLines;
                                if (currentNodeLines != 0)
                                {
                                    g.SetClip(oldClip, CombineMode.Replace);
                                    DrawCellLines(paintinfo, currentNodeLines, fixedWidth, i);
                                }
                            }
                        }
                        finally
                        {
                            g.SetClip(oldClip, CombineMode.Replace);
                        }
                    }
                    #endregion
                    else
                    {
                        paintinfo.ForeColor = GetForeColor(paintinfo.FNode, paintinfo.DisplayColumn);
                        DoPaintNodeBackGround(paintinfo);
                        paintinfo.Font = GetFontNode(paintinfo.FNode, paintinfo.DisplayColumn);
                        paintinfo.StringFormat = GetStringFormat(paintinfo.FNode, paintinfo.DisplayColumn);
                        DoPaintCell(paintinfo);
                    }
                    paintinfo.FNodeRect = rNode;
                    DoAfterNodePainting(paintinfo);
                }
                if (FDropNode == paintinfo.FNode && !dragImage)
                {
                    if (!UseColumns)
                        paintinfo.FNodeRect.Width = FScrolls.RangeX;
                    DrawDropMark(g, paintinfo.FNode, paintinfo.FNodeRect);
                }
                R.Offset(0, R.Height);
                if (R.Y <= aRect.Bottom)
                    bottom = paintinfo.FNode;
                paintinfo.FNode = Node.NextVisibleNode(paintinfo.FNode);
            }
            EndPainting(paintinfo);
#if DEBUG
			//if (InEdit && !FEditor.EditRect.IsEmpty)
			//	g.DrawRectangle(Pens.Black, FEditor.EditRect);
			//dessin pour de la ligne max en X
			g.DrawLine(Pens.Green, FScrolls.RangeX - FScrolls.OffsetX, 0, FScrolls.RangeX - FScrolls.OffsetX, TreeRectangle.Bottom);
			Debug.WriteLine(string.Format("bottom node is {0}", bottom != null ? bottom.Text : "null"));
#endif
            return bottom;
        }

        private void DrawHorizontalLine(PaintInfo paintinfo, int fixedWidth, int aCol, Rectangle rCol, int y)
        {
            int xLine = rCol.X + rCol.Width;
            int xDeb = rCol.X;
            if (xDeb >= fixedWidth || aCol < FHeader.FixedColumnCount)
            {
                paintinfo.graphics.DrawLine(FColors.GridLinesColor, xDeb, y, xLine, y);
            }
            else if (xDeb < fixedWidth && xLine > fixedWidth)
            {
                xDeb = fixedWidth;
                paintinfo.graphics.DrawLine(FColors.GridLinesColor, xDeb, y, xLine, y);
            }

        }

        private void DrawCellLines(PaintInfo paintinfo, Lines lines, int fixedWidth, int aCol)
        {
            Graphics g = paintinfo.graphics;
            Rectangle rCol = paintinfo.NodeRect;
            int xLine = rCol.X + rCol.Width;
            if ((lines & Lines.Bottom) == Lines.Bottom)
            {
                DrawHorizontalLine(paintinfo, fixedWidth, aCol, rCol, rCol.Y + rCol.Height);
            }
            if ((lines & Lines.Top) == Lines.Top)
            {
                DrawHorizontalLine(paintinfo, fixedWidth, aCol, rCol, rCol.Y - 1);
            }
            if ((lines & Lines.Right) == Lines.Right)
            {
                if (xLine >= fixedWidth || aCol < FHeader.FixedColumnCount)
                {
                    g.DrawLine(FColors.GridLinesColor, xLine, rCol.Y, xLine, rCol.Y + rCol.Height);
                }
            }
        }

        private int MainNodeWidth(Node aNode)
        {
            return GetNodeLevel(aNode) * Indentation + FMargin;
        }

        private void DoPaintCell(PaintInfo paintinfo)
        {
            if (!paintinfo.BackColor.IsEmpty && !(FullRowSelect && IsSelectedNode(paintinfo.FNode)))
            {
                using (Brush br = paintinfo.BackColor.GetBrush(paintinfo.FNodeRect))
                {
                    Rectangle r = paintinfo.FNodeRect;
                    //si j'ai des lignes verticales il ne faut pas que je "mange" la ligne de ma colonne précedente
                    if (paintinfo.DisplayColumn > 0 && Contains(paintinfo.DrawingOptions, DrawingOptions.ShowVertLines))
                    {
                        r.Offset(1, 0);
                        r.Width -= 1;
                    }
                    paintinfo.graphics.FillRectangle(br, r);
                }
            }
            if ((paintinfo.DisplayColumn == this.MainColumnIndex && UseColumns) || paintinfo.DisplayColumn == Constants.NoColumn)
            {
                Node aNode = paintinfo.FNode;
                Graphics g = paintinfo.graphics;
                Point pt = new Point(paintinfo.FNodeRect.Left, paintinfo.FNodeRect.Top);
                pt.X += MainNodeWidth(paintinfo.FNode);
                DrawLines(aNode, paintinfo.graphics, pt, paintinfo.DrawingOptions);
                DrawCheck(aNode, paintinfo.graphics, pt, paintinfo);
                if (Contains(aNode.State, NodeState.HasCheck))
                    pt.X += FCheckSize.Width;
                int imageindex = DoGetImageIndex(aNode, ImageIndexType.NormalImage);
                if (imageindex >= 0 && FImageList != null && FImageList.Images.Count > imageindex)
                {
                    Rectangle rImg = new Rectangle(pt.X + 1, pt.Y, ImageWidth(), aNode.Height);
                    rImg.Height = ImageHeight();
                    int diffY = (aNode.Height - rImg.Height) / 2;
                    rImg.Offset(0, diffY);
                    Image img = FImageList.Images[imageindex];
                    g.DrawImage(img, rImg);
                    pt.X += ImageWidth() + 2;
                }
                imageindex = DoGetImageIndex(aNode, ImageIndexType.StateImage);
                if (imageindex >= 0 && FImageStateList != null && FImageStateList.Images.Count > imageindex)
                {
                    Rectangle rImg = new Rectangle(pt.X + 1, pt.Y, ImageStateWidth(), aNode.Height);
                    rImg.Height = ImageStateHeight();
                    int diffY = (aNode.Height - rImg.Height) / 2;
                    rImg.Offset(0, diffY);
                    g.DrawImage(FImageStateList.Images[imageindex], rImg);
                    pt.X += ImageStateWidth() + 2;
                }
                int ecartX = pt.X - paintinfo.FNodeRect.X;
                paintinfo.FNodeRect.X = pt.X;
                if (!UseColumns)
                {
                    paintinfo.FNodeRect.Width = GetNodeWidth(aNode, MainColumnIndex);
                    paintinfo.ContentRect = paintinfo.FNodeRect;
                }
                else
                {
                    paintinfo.FNodeRect.Width -= ecartX;
                    if (!paintinfo.ContentRect.IsEmpty)
                    {
                        if (paintinfo.ContentRect.X < paintinfo.FNodeRect.X)
                        {
                            int diffX = paintinfo.FNodeRect.X - paintinfo.ContentRect.X;
                            paintinfo.ContentRect.X = paintinfo.FNodeRect.X;
                            paintinfo.ContentRect.Width -= diffX;
                        }
                        if (paintinfo.ContentRect.Right > paintinfo.FNodeRect.Right)
                        {
                            int diffX = paintinfo.ContentRect.Right - paintinfo.FNodeRect.Right;
                            paintinfo.ContentRect.Width -= diffX;
                        }
                    }
                }
            }
            DoPaintCellText(paintinfo);
        }

        private bool IsSelectedNode(Node node)
        {
            return node.Selected;
        }

        private int DoGetImageIndex(Node node, ImageIndexType indexType)
        {
            int imageIndex;
            if (indexType == ImageIndexType.NormalImage)
                imageIndex = node.ImageIndex;
            else
                imageIndex = node.ImageStateIndex;

            if (OnGetImageIndex != null)
            {
                NodeImageIndexEventArgs e = new NodeImageIndexEventArgs(node, indexType);
                e.ImageIndex = imageIndex;
                OnGetImageIndex(this, e);
                imageIndex = e.ImageIndex;
            }
            return imageIndex;
        }

        private void DoPaintCellText(PaintInfo paintinfo)
        {
            //Brush aTextColor;
            Color aTextColor;
            string sText = GetNodeText(paintinfo.FNode, paintinfo.DisplayColumn);
            bool nodeIsSelected = IsSelectedNode(paintinfo.FNode);
            bool isSelected = nodeIsSelected && paintinfo.DisplayColumn == FNodes.CurrentColIndex;
            bool hideSelection = Contains(paintinfo.DrawingOptions, DrawingOptions.AlwaysHideSelection);
            if (!FullRowSelect && isSelected)
            {
                if (!hideSelection)
                {
                    if (paintinfo.TreeFocused || !Contains(paintinfo.DrawingOptions, DrawingOptions.HideSelection))
                    {
                        DrawSelectedRectangle(paintinfo.graphics, paintinfo.ContentRect, false, paintinfo);
                    }
                    else
                        isSelected = false;
                }
                else
                    isSelected = false;
            }
            if (paintinfo.ForeColor.IsEmpty)
            {
                if ((isSelected || (nodeIsSelected && FullRowSelect)) && !hideSelection)
                    aTextColor = FColors.SelectedTextColor;
                //aTextColor = FColors.SelectedTextColor.GetBrush();
                else
                    aTextColor = FColors.TextColor;
                //aTextColor = FColors.TextColor.GetBrush();
            }
            else
                aTextColor = paintinfo.ForeColor;
            //aTextColor = paintinfo.ForeColor.GetBrush(paintinfo.ContentRect);

            StringFormat sf = paintinfo.StringFormat;
            if (sf == null)
                sf = GetStringFormat(paintinfo.FNode, paintinfo.DisplayColumn);
            Rectangle rText = paintinfo.ContentRect;
            //TODO: demander la font pour le noeuds
            Font f = paintinfo.Font;
            if (f == null)
                f = this.Font;

            if (FastDrawString)
                paintinfo.graphics.DrawString(sText, f, new SolidBrush(aTextColor), rText, sf);
            else
                TextRenderer.DrawText(paintinfo.graphics, sText, f, rText, aTextColor, DrawingHelper.StringFormatToTextFormatFlags(sf));
            //paintinfo.graphics.DrawString(sText, f, new SolidBrush(aTextColor), rText, sf);
            if (isSelected && !FullRowSelect &&
                !Contains(paintinfo.DrawingOptions, DrawingOptions.HideFocusRect) &&
                !hideSelection)
                DrawFocusedRectangle(paintinfo.graphics, paintinfo.ContentRect, paintinfo);
        }

        private void DoAfterCellPainting(PaintInfo paintinfo)
        {
            if (OnAfterCellPainting != null)
                OnAfterCellPainting(this, new PaintNodeEventArgs(paintinfo));
        }

        private bool DoBeforeCellPainting(PaintInfo paintinfo)
        {
            paintinfo.DefaultDrawing = true;

            paintinfo.StringFormat = GetStringFormat(paintinfo.FNode, paintinfo.DisplayColumn);
            if (OnBeforeCellPainting != null)
                OnBeforeCellPainting(this, new PaintNodeEventArgs(paintinfo));
            return !paintinfo.DefaultDrawing;
        }

        private void EndPainting(PaintInfo paintinfo)
        {
            if (OnAfterPainting != null)
                OnAfterPainting(this, new PaintNodeEventArgs(paintinfo));
        }

        private void DoAfterNodePainting(PaintInfo paintinfo)
        {
            paintinfo.DefaultDrawing = true;
            if (OnAfterNodePainting != null)
                OnAfterNodePainting(this, new PaintNodeEventArgs(paintinfo));
            if (paintinfo.DefaultDrawing)
            {
                if (FullRowSelect && IsSelectedNode(paintinfo.FNode) && !Contains(paintinfo.DrawingOptions, DrawingOptions.AlwaysHideSelection))
                    DrawFocusedRectangle(paintinfo.graphics, paintinfo.FNodeRect, paintinfo);
            }
        }

        private void DoPaintNodeBackGround(PaintInfo paintinfo)
        {
            paintinfo.DefaultDrawing = true;
            if (OnPaintNodeBackGround != null)
                OnPaintNodeBackGround(this, new PaintNodeEventArgs(paintinfo));
            if (paintinfo.DefaultDrawing)
            {
                if (FullRowSelect && IsSelectedNode(paintinfo.FNode) && !Contains(paintinfo.DrawingOptions, DrawingOptions.AlwaysHideSelection))
                    DrawSelectedRectangle(paintinfo.graphics, paintinfo.FNodeRect, false, paintinfo);
            }
        }

        private bool DoBeforeNodePainting(PaintInfo paintinfo)
        {
            paintinfo.DefaultDrawing = true;
            paintinfo.DrawingOptions = DefaultDrawingOption;
            if (OnBeforeNodePainting != null)
                OnBeforeNodePainting(this, new PaintNodeEventArgs(paintinfo));

            return !paintinfo.DefaultDrawing;
        }

        private void DoBeginPainting(PaintInfo paintinfo)
        {
            paintinfo.DrawingOptions = DefaultDrawingOption;
            if (OnBeforePainting != null)
                OnBeforePainting(this, new PaintNodeEventArgs(paintinfo));
        }

        /// <summary>
        /// point d'ntrée du paint
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                DoPaint(e.Graphics, e.ClipRectangle);
            }
            catch (Exception ex)
            {
                throw new Exception("problème dans le paint", ex);
            }
        }

        #region asynchrone paint
        void StartPaint(Rectangle aClipRect)
        {
            Invalidate(aClipRect);
        }

        void DoPaint(Graphics g, Rectangle clipRect)
        {
            Rectangle aRect;
            Rectangle aTreeRect;
            aRect = clipRect;
            aTreeRect = TreeRectangle;
            Debug.WriteLine(string.Format("Rectangle d'invalidation : {0}", aRect));
            //recalcul du rectangle (cliprect) par rapport au treerectangle
            if (aRect.IsEmpty)
                aRect = aTreeRect;
            else if (aRect.Bottom > aTreeRect.Bottom)
                aRect.Width -= (aRect.Bottom - aTreeRect.Bottom);

            PaintTree(g, aRect);
            PaintFooter(g, FooterRect, clipRect);
        }

        delegate PaintInfo CreatePaintInfoDelegate();
        PaintInfo CreatePaintInfo()
        {
            if (this.InvokeRequired)
                return (PaintInfo)this.Invoke(new CreatePaintInfoDelegate(CreatePaintInfo));
            else
            {
                PaintInfo paintinfo = new PaintInfo();
                paintinfo.FMousePosition = this.PointToClient(System.Windows.Forms.Control.MousePosition);
                paintinfo.FTreeFocused = this.Focused;
                return paintinfo;
            }

        }
        #endregion

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            if (UseColumns)
            {
                Rectangle rCol = TreeRectangle;
                foreach (GeniusTreeViewColonne col in FHeader.Displays)
                {
                    if (!col.Visible || col.Width <= 0 || col.BackColor.IsEmpty)
                        continue;
                    int aDisplayIndex = FHeader.IndexOfDisplay(col);
                    //rCol.X = FHeader.Left(aDisplayIndex) -  ((aDisplayIndex >= FHeader.FixedColumnCount) ? FScrolls.OffsetX : 0);
                    rCol.X = FHeader.Left(aDisplayIndex);
                    rCol.Width = col.Width;
                    int fixedw = 0;
                    if (aDisplayIndex >= FHeader.FixedColumnCount)
                    {
                        fixedw = FHeader.FixedColumnWidth;
                        if (rCol.X < fixedw)
                        {
                            fixedw -= rCol.X;
                            rCol.Offset(fixedw, 0);
                            rCol.Width -= fixedw;
                        }
                        else
                            fixedw = 0;
                    }
                    if (!pevent.ClipRectangle.IntersectsWith(rCol) || rCol.Width <= 0)
                        continue;
                    using (Brush br = col.BackColor.GetBrush(rCol))
                    {
                        if (br is TextureBrush)
                            ((TextureBrush)br).TranslateTransform(rCol.X - fixedw, 0);
                        pevent.Graphics.FillRectangle(br, rCol);
                    }
                }
            }
        }

        private bool IsVisibleNode(Node n)
        {
            string rankTop = FNodes.RankNode(InternalTopNode());
            string rankBottom = FNodes.RankNode(LastVisibleNode());
            string rank = FNodes.RankNode(n);
            return (rank.CompareTo(rankTop) >= 0) && (rank.CompareTo(rankBottom) <= 0);
        }

        private bool ShowSelectedColumn()
        {
            if (Selected == null || !UseColumns)
                return false;
            int left = FHeader.Left(FNodes.CurrentColIndex);
            int right = left + FHeader.DisplayColonnes(FNodes.CurrentColIndex).Width;
            if (left < FHeader.FixedColumnWidth && FNodes.CurrentColIndex >= FHeader.FixedColumnCount)
            {
                FScrolls.OffsetX += (left - FHeader.FixedColumnWidth);
                return true;
            }
            else if (left > 0 && right > TreeRectangle.Right)
            {
                //TODO voir quand la largeur de la colonne est supérieur à la largeur disponible (que fait-on ?)
                left = Math.Min(left, right - TreeRectangle.Right);
                FScrolls.OffsetX += left;
                return true;
            }
            return false;
        }

        internal bool ShowNode(Node n)
        {
            return ShowNode(n, false);
        }

        internal bool ShowNode(Node n, bool centerOnView)
        {
            string rankTop = FNodes.RankNode(InternalTopNode());
            string rankBottom = FNodes.RankNode(LastVisibleNode());
            string rank = FNodes.RankNode(n);

            int hNode = n.Height;
            if (rank.CompareTo(rankTop) < 0)
            {
                int h = 0;
                while (n != FTopNode)
                {
                    h += n.Height;
                    n = NextVisibleNode(n);
                }
                if (centerOnView)
                {
                    h += (this.TreeRectangle.Height - hNode) / 2;
                }
                ScrollUp(h);
                return true;
            }
            else if (rank.CompareTo(rankBottom) > 0)
            {
                int h = 0;
                //calcul de la hauteur à scroller pour voir complètement le noeud
                while (n != FLastVisibleNode)
                {
                    h += n.Height;
                    n = PrevVisibleNode(n);
                }
                h += FLastVisibleNode.Height;

                if (centerOnView && hNode < this.TreeRectangle.Height)
                {
                    h += (this.TreeRectangle.Height - hNode) / 2;
                }
                /*
				//calcul de la hauteur à réellement scroller
				n = FTopNode;
				int hreal = 0;
				while (h > 0 && n != null)
				{
					h -= n.Height;
					hreal += n.Height;
					n = NextVisibleNode(n);
				}
				h = hreal;
                */
                ScrollDown(h, true);
                return true;
            }
            return false;
        }
        #endregion

        private int PrevColumn()
        {
            int Result = FNodes.CurrentColIndex - 1;
            int tours = 0;
            while ((Result < 0 || !FHeader.DisplayColonnes(Result).Visible ||
                !DoCanSelectNode(Selected, Result)) && tours++ < FHeader.Count)
            {
                if (Result < 0)
                    Result = FHeader.Count - 1;
                else
                    Result--;
            }
            if (tours >= FHeader.Count)
                return -1;
            else
                return Result;
        }

        private int NextColumn()
        {
            int Result = FNodes.CurrentColIndex + 1;
            int tours = 0;

            while ((Result >= FHeader.Count || !FHeader.DisplayColonnes(Result).Visible ||
                !DoCanSelectNode(Selected, Result)) &&
                tours++ < FHeader.Count)
            {
                if (Result >= FHeader.Count)
                    Result = 0;
                else
                    Result++;
            }
            if (tours >= FHeader.Count)
                return -1;
            else
                return Result;
        }
        // method called from keyboard
        // if th user navigate through the cells all the active selections are cleared
        private void GotoColumn(int aColIndex)
        {
            Node selected = Selected;
            if (InternalSelectNode(selected, aColIndex, false))
            {
                bool dejadessine = ShowNode(selected);
                if (ShowSelectedColumn())
                {
                    if (!dejadessine)
                        InvalidateTree();
                }
                else if (!dejadessine)
                    InvalidateNode(selected);
                DoAfterSelect(selected, aColIndex);
            }
        }

        /*
        private int ClickedColumn(int x, int defaultColumn)
        {
            int clickedCol;

            x += FScrolls.OffsetX;

            if (UseColumns)
            {
                clickedCol = FHeader.ColumnIndexAt(x);
                return clickedCol == -1 ? defaultColumn : clickedCol;
            }
            else
                return 0;
        }
        */

        private bool DoCanSelectNode(Node n, int colIndex)
        {
            if (OnBeforeSelect != null)
            {
                CanSelectEventArgs ev = new CanSelectEventArgs(n, colIndex);
                OnBeforeSelect(this, ev);
                return ev.CanSelect;
            }
            return true;
        }
        // method call from keyboard events
        private bool InternalSelectNode(Node n, int colIndex, bool multiSelect)
        {
            Node oldSelected = Selected;
            bool canSelect = true;
            if (n != oldSelected || (UseColumns && colIndex != FNodes.CurrentColIndex && !FFullRowSelect))
            {
                canSelect = false;
                if (UseColumns)
                {
                    if (colIndex >= FHeader.Count)
                        colIndex = 0;
                    else if (colIndex < 0)
                        colIndex = FHeader.Count - 1;
                }
                //gp canSelect = FNodes.InternalSelectNode(n, false, colIndex);
                canSelect = FNodes.InternalSelectNode(n, multiSelect, colIndex);
            }
            else
                canSelect = false;
            return canSelect;
        }
        // method call from mouse click events or keyboard events
        internal bool SelectNode(Node n)
        {
            return SelectNode(n, FNodes.CurrentColIndex);
        }

        private void DoAfterSelect(Node n, int aCol)
        {
            if (OnAfterSelect != null)
                OnAfterSelect(this, new SelectedEventArgs(n, aCol));
            //TODO: à faire plus tard
            /*
            if (UseColumns && !FullRowSelect && AllowEdit && FAutoEdit)
                BeginEdit();
            */
        }

        private bool SelectNode(Node n, int aCol)
        {
            //gp : ADD Shift & Controls keys
            bool Shift_Control = false;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift || (Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                Shift_Control = _AllowMultiSelect;
#if DEBUG				    
			        Debug.WriteLine("mouse click with controlol-shift= " + Shift_Control.ToString());
#endif
            }
            bool Result = InternalSelectNode(n, aCol, Shift_Control);
            if (Result)
            {
                DoAfterSelect(n, aCol);
                InvalidateTree();
            }
            return Result;
        }

        #region ancien code
        /*
		private void UnCheck(Node n)
		{
			Node child = n.FirstChild;
			Exclude(ref n.State, NodeState.Checked);
			while (child != null)
			{
				if (Contains(child.State, NodeState.HasCheck))
					UnCheck(child);
				child = child.NextSibling;
			}
			UpdateTotalCheckedCount(n.Parent, -1);
		}
		private void Check(Node n)
		{
			Node child = n.FirstChild;
			Include(ref n.State, NodeState.Checked);
			while (child != null)
			{
				if (Contains(child.State, NodeState.HasCheck))
					Check(child);
				child = child.NextSibling;
			}
			UpdateTotalCheckedCount(n.Parent, 1);
		}
*/
        #endregion

        private bool CheckUnCheckNode(Node n)
        {
            if (Contains(n.State, NodeState.Checked))
                return InternalUnCheckNode(n);
            else
                return InternalCheckNode(n);
        }

        private bool InternalCheckNode(Node n)
        {
            bool Result = false;
            Result = FNodes.Check(n);
            if (Result && OnAfterCheck != null)
                OnAfterCheck(this, new NodeEventArgs(n));
            return Result;
        }

        private bool InternalUnCheckNode(Node n)
        {
            bool Result = false;
            Result = FNodes.UnCheck(n);
            if (Result && OnAfterUnCheck != null)
                OnAfterUnCheck(this, new NodeEventArgs(n));
            return Result;
        }

        private Node Selected
        {
            get
            {
                return FNodes.Selected;
            }
        }

        private void ExpandNode(Node n)
        {
            int aHeight;
            if (FNodes.InternalExpand(n, out aHeight))
            {
                FBottomNode = FLastVisibleNode = null;
                UpdateScrollBars(n, aHeight);
                InvalidateTree();
                if (OnAfterExpand != null)
                    OnAfterExpand(this, new NodeEventArgs(n));
            }
        }

        private void CollapseNode(Node n)
        {
            int aHeight;
            if (FNodes.InternalCollapse(n, out aHeight))
            {
                //si le noeud est au dessu du dernier visible alors il faut recalculer le dernier noeud visible 
                if (FLastVisibleNode != null && FNodes.RankNode(n).CompareTo(FNodes.RankNode(FLastVisibleNode)) <= 0)
                    FBottomNode = FLastVisibleNode = null;
                UpdateScrollBars(n, aHeight);
                InvalidateTree();
                if (OnAfterCollapse != null)
                    OnAfterCollapse(this, new NodeEventArgs(n));
            }
        }

        private void ExpandCollapse(Node n)
        {
            if (IsExpanded(n))
                CollapseNode(n);
            else
                ExpandNode(n);
        }

        private Node CalcTopOfHeight(Node aBottomNode, int aHeight, out int realHeight, bool integralHeight)
        {
            Node Result = aBottomNode;
            Node tmp = aBottomNode;
            realHeight = 0;
            if (tmp != null)
            {
                while (aHeight > 0 && (tmp = PrevVisibleNode(tmp)) != null)
                {
                    aHeight -= tmp.Height;
                    if (!integralHeight || aHeight >= 0)
                    {
                        realHeight += tmp.Height;
                        Result = tmp;
                    }
                }
            }
            return Result;
        }

        private Node CalcBottomOfHeight(Node aTopNode, int aHeight, out int realHeight, bool integralHeight)
        {
            return CalcBottomOfHeight(aTopNode, aHeight, out realHeight, integralHeight, null);
        }

        private Node CalcBottomOfHeight(Node aTopNode, int aHeight, out int realHeight, bool integralHeight, Node aBottomLimit)
        {
            Node Result = aTopNode;
            Node tmp = aTopNode;
            realHeight = 0;
            if (tmp != null)
            {
                while (aHeight > 0 && (tmp = NextVisibleNode(tmp)) != aBottomLimit)
                {
                    aHeight -= Result.Height;
                    if (!integralHeight || aHeight >= 0)
                    {
                        realHeight += Result.Height;
                        Result = tmp;
                    }
                }
            }
            return Result;
        }

        private Node CalcLastVisibleNode(Node aTopNode, int aHeight, bool integralHeight)
        {
            Node Result;
            if (aTopNode == null)
                return null;
            Result = aTopNode;
            Node tmp = aTopNode;
            if (tmp != null)
            {
                while (aHeight > 0 && (tmp = NextVisibleNode(tmp)) != null)
                {
                    aHeight -= Result.Height;
                    if (aHeight > 0)
                    {
                        if (integralHeight && (aHeight - tmp.Height < 0))
                            break;
                        Result = tmp;
                    }
                }
            }
            return Result;
        }

        private void ScrollUp(int h)
        {
            if (h > 0 && FTopNode != null && FScrolls.CanScrollUp())
            {
                int realHeight;

                Node n = CalcTopOfHeight(FTopNode, h, out realHeight, true);
                if (n == FTopNode)
                {
                    //si n == FTopNode alors je scroll de 1 noeud vers le haut, car j'ai demnder un scroll
                    n = PrevVisibleNode(FTopNode);
                    //puis-je scroller ??
                    if (n != null)
                    {
                        FTopNode = n;
                        realHeight = n.Height;
                    }
                }
                else
                    FTopNode = n;
                if (realHeight != 0)
                {
                    FBottomNode = null;
                    FLastVisibleNode = null;
                    FScrolls.OffsetY -= realHeight;
                    if (FScrolls.OffsetY < 0)
                        FScrolls.OffsetY = 0;
                    //Debug.WriteLine("end ScollUp : "+ FScrolls.OffsetY.ToString());
                    UpdateHorizontalScrollBar();
                    InvalidateTree();
                }
            }
        }

        private void ScrollDown(int h, bool noLimit)
        {
            if (FTopNode != null && FScrolls.CanScrollDown())
            {
                int realHeight = 0;
                Node bottom = LastVisibleNode();

                if (bottom == null)
                    return;

                //Node n = NextVisibleNode(bottom);
                Node n = bottom;

                bottom = CalcBottomOfHeight(n, h, out realHeight, true);
                if (realHeight == 0)
                    realHeight = n.Height;
                //la limite est par défaut le noeud suivant le dernier visible
                if (!noLimit)
                {
                    n = NextVisibleNode(n);
                    if (n != null)
                        n = NextVisibleNode(n);
                }
                n = CalcBottomOfHeight(FTopNode, realHeight, out realHeight, false, noLimit ? null : n);
                if (n == FTopNode)
                {
                    FTopNode = NextVisibleNode(FTopNode);
                    realHeight = n.Height;
                }
                else
                    FTopNode = n;

                FBottomNode = null;
                FLastVisibleNode = null;
                if (realHeight > 0)
                {
                    FScrolls.OffsetY += realHeight;
                    UpdateHorizontalScrollBar();
                    InvalidateTree();
                }
            }
        }
        #endregion

        #region Gestion du Hint

        private IHintWindow CreateHintWindow(IHintWindow aCurrent, INode aNode, int aDisplayColumn)
        {
            if (OnCreateHintWindow != null)
            {
                NodeHintWindowEventArgs e = new NodeHintWindowEventArgs(aNode, aDisplayColumn, aCurrent);
                OnCreateHintWindow(this, e);
                return e.HintWindow;
            }
            if (aCurrent == null)
                aCurrent = new BaseHintWindow(this);
            return aCurrent;
        }

        private void ShowHintTimer(string aText, Node aNode, int aColumn)
        {
            if ((FHint == null) ||
                !FTimers.IsStarted(KindTimer.Hint) &&
                (FHint.Node != aNode || FHint.DisplayColumn != aColumn)
                )
            {
                FTimers.Start(KindTimer.Hint, new HintHelper(aText, aNode, aColumn));
            }
        }

        private void ShowHint(string aText, Node aNode, int aColumn)
        {
            FHint = CreateHintWindow(FHint, aNode, aColumn);
            if (FHint != null /*&& (FHint.Node != aNode || FHint.DisplayColumn != aColumn)*/)
            {
                FHint.Node = aNode;
                FHint.DisplayColumn = aColumn;
                FHint.Text = aText;
                FHint.ShowHint(Cursor.Position.X + 15, Cursor.Position.Y + 15);
            }
        }

        private void HideHint()
        {
            FTimers.Stop(KindTimer.Hint);
            if (FHint != null)
            {
                FHint.Hide();
                FHint.Node = null;
            }
        }
        #endregion

        #region Gestion du drag and drop
        private DragForm FDragFrm;
        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            //Debug.WriteLine("givefeeback = " + gfbevent.Effect.ToString());
            base.OnGiveFeedback(gfbevent);
            if (FDragFrm != null)
                FDragFrm.Forbiden = (gfbevent.Effect == DragDropEffects.None);
        }

        protected override void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent)
        {
            DragTo(Cursor.Position);
            base.OnQueryContinueDrag(qcdevent);
            if (qcdevent.EscapePressed)
            {
                qcdevent.Action = DragAction.Cancel;
                FDropNode = null;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            Node n = drgevent.Data.GetData("GTV") as Node;
#if DEBUG
            bool pippo = FAutomaticDropNode;			// debug scope
#endif
            if (!FAutomaticDropNode)
            {	// creation of node is manual by user in dragdrop event
                base.OnDragDrop(drgevent);
            }
            if (FAutomaticDropNode && n != null && FDropNode != null)
            {
                FDropHere = true;
                this.BeginUpdate();
                try
                {
                    if (FDragNode != null && drgevent.Effect == DragDropEffects.Move)
                        this.Delete(FDragNode, false);
                    if (Contains(n.State, NodeState.Selected))
                        Exclude(ref n.State, NodeState.Selected);
                    this.Insert(n, FDropNode, FDropPosition);
                    if (FDropNode == FTopNode && FDropPosition == DragPosition.Before)
                        FTopNode = null;
                    FBottomNode = null;
                    FLastVisibleNode = null;
                    //je suis recepteur seulement, c'est un autre treeview qui est émetteur
                    if (!Contains(FStates, TreeStateEnum.Dragging))
                    {
                        FDropNode = null;
                        FDropPosition = DragPosition.None;
                    }
                    FUpdateScrollBarsNeeded = true;
                }
                finally
                {
                    this.EndUpdate();
                }
                base.OnDragDrop(drgevent);
            }
            Debug.WriteLine("ondragdrop= " + drgevent.Effect.ToString());
        }

        private bool CanDragTo(Node aSource, Node aDrop, DragPosition aPos)
        {
            if (aDrop != null && aSource.Parent == aDrop.Parent && aSource.Index == aDrop.Index)
                return false;
            //aSource etant une copie, il faut regarder dans son parent pour
            if (aDrop != null && aDrop.IsChild(aSource.Parent.Children[aSource.Index]))
                return false;
            if (OnCanDragTo != null)
            {
                CanDragToEventArgs e = new CanDragToEventArgs(aSource, aDrop, aPos);
                OnCanDragTo(this, e);
                return e.CanDrop;
            }
            return true;
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if ((drgevent.KeyState & 0x08) == 0x08)
                drgevent.Effect = DragDropEffects.Copy;
            else
                drgevent.Effect = DragDropEffects.Move;
            base.OnDragOver(drgevent);
            Node node = drgevent.Data.GetData("GTV") as Node;
            if (node != null && drgevent.Effect != DragDropEffects.None)
            {
                Point pt = this.PointToClient(new Point(drgevent.X, drgevent.Y));
                //Debug.WriteLine(string.Format("ondragover : {0}", pt));
                //Debug.WriteLine(String.Format("{0}, {1}", pt, TreeRectangle));
                if (pt.Y > TreeRectangle.Bottom)
                {
                    drgevent.Effect = DragDropEffects.None;
                    return;
                }
                Point aNodePoint;
                Node dropNode = GetNodeAt(pt, out aNodePoint);
                DragPosition oldDropPos = FDropPosition;

                FDropPosition = DragPosition.None;
                if (FDropNode != null)
                {
                    Rectangle rc = GetMainNodeRect(FDropNode);
                    if (oldDropPos == DragPosition.Before)
                        rc.Offset(0, -FDropNode.Height / 2);
                    else
                        rc.Offset(0, +FDropNode.Height / 2);
                    //Invalidate(rc);
                    StartPaint(rc);
                }
                if (FDropNode != dropNode)
                    FTimers.Stop(KindTimer.DragExpand);
                FDropNode = dropNode;
                if (FDropNode != null)
                {
                    int bottom = FDropNode.Height + aNodePoint.Y;
                    if (pt.Y > (bottom + aNodePoint.Y) / 2)
                    {
                        FDropPosition = DragPosition.After;
                        Rectangle rText = GetTextRect(FDropNode);
                        if (pt.X > rText.X)
                            FDropPosition = DragPosition.Under;
                    }
                    else
                        FDropPosition = DragPosition.Before;
                    InvalidateNode(FDropNode);
                    if (!CanDragTo(node, FDropNode, FDropPosition))
                        drgevent.Effect = DragDropEffects.None;
                    FTimers.Start(KindTimer.DragExpand);
                }
                else
                    drgevent.Effect = DragDropEffects.None;
            }
            else
                FTimers.Stop(KindTimer.DragExpand);
        }

        private void PrepareDrag(Point aStart, HitNodeInfo ahit)
        {
            Bitmap bmp;
            //int width = ahit.HitNode.Width;
            Rectangle rNode = GetNodeRect(ahit.HitNode);
            Rectangle rBmp;
            if (UseColumns)
                rNode.Width = FHeader.DisplayColonnes(MainColumnIndex).Width;
            else
                rNode.Width = GetMaxWidth();
            rNode.Height = ahit.HitNode.TotalHeight;
            rNode.Y = 0;

            rBmp = new Rectangle(0, 0, Math.Min(rNode.Width, this.Width), Math.Min(rNode.Height, this.Height));
            if (OnPrepareDrag != null)
            {
                PrepareDragEventArgs e = new PrepareDragEventArgs(rBmp);
                OnPrepareDrag(this, e);
                rBmp = e.Bounds;
            }
            bmp = new Bitmap(rBmp.Width, rBmp.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
                g.TranslateTransform(-MainColumnX, 0);
                DrawingOptions oldpaintoptions = DefaultDrawingOption;
                try
                {
                    DefaultDrawingOption = DrawingOptions.AlwaysHideSelection;
                    PaintTree(g, rNode, ahit.HitNode, true);
                }
                finally
                {
                    DefaultDrawingOption = oldpaintoptions;
                }
            }
            FDragFrm = new DragForm(bmp, this);
            FDragFrm.OnDrawDrag += OnDrawDrag;
        }

        private void DragTo(Point pt)
        {
            if (FDragFrm.Visible == false)
                FDragFrm.Show(pt.X + 5, pt.Y + 5);
            FDragFrm.Position(pt.X + 5, pt.Y + 5);
        }

        private void StopDrag()
        {
            FTimers.Stop(KindTimer.DragExpand);
            FTimers.Stop(KindTimer.Scroll);
            if (FDragFrm != null)
            {
                FDragFrm.Dispose();
                FDragFrm.OnDrawDrag -= OnDrawDrag;
            }
            FDragFrm = null;
            if (FDropNode != null)
            {
                FDropNode = null;
                InvalidateTree();
            }
        }

        protected virtual bool CanDragNode(INode aNode)
        {
            if (OnCanDragNode != null)		// if defined a user function 
            {
                CanDragEventArgs ev = new CanDragEventArgs(aNode);
                OnCanDragNode(this, ev);
                return ev.CanDrag;
            }
            return true;
        }

        /// <summary>
        /// interrogation de l'utilisateur pour le drag, quel object est à dragger
        /// </summary>
        /// <param name="aNode"></param>
        /// <param name="aDataToDrag"></param>
        protected virtual void DoDragBegin(INode aNode, ref object aDataToDrag)
        {
            if (OnDragBegin != null)
            {
                BeginDragEventArgs ev = new BeginDragEventArgs(aNode, aDataToDrag);
                OnDragBegin(this, ev);		// if defined a user function 
                aDataToDrag = ev.DataToDrag;
            }
        }
        #endregion

        #region gestion du remplissage de l'arbre
        private void FillTree(INode aParent, IEnumerable aEnum)
        {
            foreach (object o in aEnum)
            {
                INode n = this.Add(aParent, o);
                if (o is IEnumerable && !(o is string))
                    FillTree(n, o as IEnumerable);
            }
        }

        private void FillTree()
        {
            BeginUpdate();
            try
            {
                this.Clear();
                if (FDataSource != null)
                    FillTree(null, FDataSource);
            }
            finally
            {
                EndUpdate();
            }
            if (FDataSource != null && AutoSort)
                SortTree(FHeader.SortColumns, FHeader.SortingDirections);
        }
        #endregion

        #region méthodes protégées
        /// <summary>
        /// dispose du control
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                HideHint();
                if (FHint != null && FHint is IDisposable)
                    ((IDisposable)FHint).Dispose();
                FHeader.Dispose();
                FColors.Dispose();
                if (FTemporaryGraphics != null)
                {
                    FTemporaryGraphics.Dispose();
                    FTemporaryGraphics = null;
                }
            }
        }

        /// <summary>
        /// changement de la taille du treeview
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            FBottomNode = null;
            FLastVisibleNode = null;
            FScrolls.Update();
            RecalculTopNode();
            FHeader.RecalcLastColWidth();
            Debug.WriteLine(string.Format("offsety : {0}, range : {1}", FScrolls.OffsetY, FScrolls.RangeY));
            base.OnSizeChanged(e);
        }


        #region HitInfo
        private StringFormat GetStringFormat(Node aNode, int aColumn)
        {
            StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
            if (UseColumns && aColumn == FHeader.AutoSizeColIndex)
            {
                sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Near;
            }
            else
            {
                sf.Trimming = UseColumns ? StringTrimming.EllipsisCharacter : StringTrimming.None;
                sf.LineAlignment = StringAlignment.Center;
            }
            if (UseColumns)
            {
                sf.Alignment = FHeader.DisplayColonnes(aColumn).ContentAlignment;
            }
            return sf;
        }

        private int CalculateTextWidth(Graphics g, Node aNode, int aColumn, string aText, StringFormat sf)
        {
            int Result = 0;
            if (aText != null && aText != string.Empty)
            {
                TextFormatFlags tf = DrawingHelper.StringFormatToTextFormatFlags(sf);
                Size sizeText = TextRenderer.MeasureText(aText, GetFontNode(aNode, aColumn), Size.Empty, tf);
                Result = sizeText.Width;
            }
            return Result;
        }

        private Font GetFontNode(Node node, int column)
        {
            Font Result = this.Font;
            if (UseColumns)
                Result = FHeader.DisplayColonnes(column).FontColonne;
            if (OnGetFontNode != null)
            {
                NodeFontEventArgs e = new NodeFontEventArgs(node, column);
                e.Font = Result;
                OnGetFontNode(this, e);
                Result = e.Font;
            }
            return Result;
        }

        private Color GetForeColor(Node node, int column)
        {
            Color Result = this.ForeColor;
            if (UseColumns)
                Result = FHeader.DisplayColonnes(column).ForeTextColor;
            return Result;
        }

        private int GetNodeWidth(Node aNode, int aColumn)
        {
            int Result = 0;

            if (aColumn == MainColumnIndex)
            {
                Result = aNode.Width;
                if (Result == 0)
                {
                    if (!DoGetNodeWidth(aNode, aColumn, TemporaryGraphics, ref Result))
                        Result = CalculateTextWidth(TemporaryGraphics, aNode, aColumn, GetNodeText(aNode, aColumn),
                            GetStringFormat(aNode, aColumn));
                    aNode.Width = Result;
                }
            }
            else
            {
                if (!DoGetNodeWidth(aNode, aColumn, TemporaryGraphics, ref Result))
                    Result = CalculateTextWidth(TemporaryGraphics, aNode, aColumn, GetNodeText(aNode, aColumn),
                    GetStringFormat(aNode, aColumn));
            }
            return Result;
        }

        private bool DoGetNodeWidth(Node aNode, int aColumn, Graphics aTemporaryGraphics, ref int Result)
        {
            if (OnGetNodeWidth != null)
            {
                GetNodeWidthEventArgs e = new GetNodeWidthEventArgs(aNode, aColumn, aTemporaryGraphics);
                OnGetNodeWidth(this, e);
                Result = e.Width;
                return Result >= 0;
            }
            return false;
        }

        private int GetImageIndex(Node aNode, int aColumn, ImageKindEnum aKind)
        {
            switch (aKind)
            {
                case ImageKindEnum.Normal:
                    return aNode.ImageIndex;
                case ImageKindEnum.State:
                    return aNode.ImageStateIndex;
            }
            return -1;
        }

        private void DetermineHitPositionLTR(ref HitNodeInfo aHi, int offset, int right, StringAlignment alignment)
        {
            bool mainColumnHit;
            Node run;
            int indent = 0;
            int imageoffset = 0;

            mainColumnHit = (aHi.HitColumn == MainColumnIndex || (!UseColumns && aHi.HitColumn == Constants.NoColumn));
            if (mainColumnHit)
            {
                indent = FMargin;
                run = aHi.HitNode;
                while (run.Parent != FRoot)
                {
                    indent += Indentation;
                    run = run.Parent;
                }
                indent += Indentation;
            }
            if (offset < indent)
            {
                if (!Contains(DefaultDrawingOption, DrawingOptions.HideButtons) && Contains(aHi.HitNode.State, NodeState.HasChildren))
                {
                    if (offset >= indent - Indentation)
                        Include(ref aHi.HitPositions, HitPositionsEnum.OnItemButton);
                }
                if (aHi.HitPositions == HitPositionsEnum.OnItemIndent)
                    Include(ref aHi.HitPositions, HitPositionsEnum.OnItemIndent);
            }
            else
            {
                if (mainColumnHit)
                {
                    imageoffset = indent;
                    if (Contains(aHi.HitNode.State, NodeState.HasCheck))
                    {
                        imageoffset += ImageCheckWidth() + 2;
                    }
                    if (offset < imageoffset)
                    {
                        Include(ref aHi.HitPositions, HitPositionsEnum.OnItem);
                        Include(ref aHi.HitPositions, HitPositionsEnum.OnItemCheckbox);
                    }
                    else
                    {
                        if (FImageStateList != null && GetImageIndex(aHi.HitNode, aHi.HitColumn, ImageKindEnum.State) > -1)
                        {
                            imageoffset += ImageStateWidth() + 2;
                        }
                        if (offset < imageoffset)
                            Include(ref aHi.HitPositions, HitPositionsEnum.OnStateIcon);
                        else
                        {
                            if (FImageList != null && GetImageIndex(aHi.HitNode, aHi.HitColumn, ImageKindEnum.Normal) > -1)
                                imageoffset += ImageWidth() + 2;
                            if (offset < imageoffset)
                                Include(ref aHi.HitPositions, HitPositionsEnum.OnNormalIcon);
                            else
                            {
                                int textWidth = GetNodeWidth(aHi.HitNode, aHi.HitColumn);
                                if (textWidth > right - imageoffset)
                                    Include(ref aHi.HitPositions, HitPositionsEnum.OnItemLabel);
                                else
                                {
                                    switch (alignment)
                                    {
                                        case StringAlignment.Center:
                                            indent = (imageoffset + right - textWidth) / 2;
                                            if (offset < indent)
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemLeft);
                                            else if (offset < indent + textWidth)
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemLabel);
                                            else
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemRight);
                                            break;
                                        case StringAlignment.Far:
                                            indent = right - textWidth;
                                            if (offset < indent)
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemLeft);
                                            else
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemLabel);
                                            break;
                                        case StringAlignment.Near:
                                            if (offset < imageoffset + textWidth)
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemLabel);
                                            else
                                                Include(ref aHi.HitPositions, HitPositionsEnum.OnItemRight);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region gestion de la souris

        private string HitPositionsEnumToString(HitPositionsEnum en)
        {
            string Result = string.Empty;

            for (int i = 1; i <= (int)HitPositionsEnum.ToRight; i = i << 1)
            {
                if (Contains(en, (HitPositionsEnum)i))
                {
                    if (Result != string.Empty)
                        Result += ", ";
                    Result += ((HitPositionsEnum)i).ToString();
                }
            }
            return Result;
        }

        private void GetHitTestInfoAt(int X, int Y, bool ignoreTreeArea, ref HitNodeInfo aHi)
        {
            int ColLeft = 0, ColRight = 0;
            StringAlignment currenAlignment;

            aHi.HitNode = null;
            aHi.HitPositions = (HitPositionsEnum)0;
            aHi.HitColumn = Constants.NoColumn;
            // Determine if point lies in the tree's client area.
            if (X < 0)
                Include(ref aHi.HitPositions, HitPositionsEnum.ToLeft);
            else if ((X + FScrolls.OffsetX > FScrolls.RangeX) || (X > this.TreeRectangle.Width))
                Include(ref aHi.HitPositions, HitPositionsEnum.ToRight);
            if (Y < 0)
                Include(ref aHi.HitPositions, HitPositionsEnum.Above);
            else if ((Y + FScrolls.OffsetY > FScrolls.RangeY) || (Y > this.TreeRectangle.Height))
                Include(ref aHi.HitPositions, HitPositionsEnum.Below);

            if (aHi.HitPositions == (HitPositionsEnum)0 || ignoreTreeArea)
            {
                Point aNodePoint;
                aHi.HitNode = GetNodeAt(new Point(X, Y), out aNodePoint);
                if (aHi.HitNode == null)
                {
                    Include(ref aHi.HitPositions, HitPositionsEnum.Nowhere);
                    return;
                }
                if (UseColumns)
                {
                    aHi.HitColumn = GetColumnAndBounds(new Point(X, Y), ref ColLeft, ref ColRight, true);
                    X -= ColLeft;
                    ColRight -= ColLeft;
                }
                else
                {
                    ColRight = Math.Max(FScrolls.RangeX, TreeRectangle.Width);
                    aHi.HitColumn = Constants.NoColumn;
                }
                ColLeft = 0;
                if (aHi.HitColumn == Constants.InvalidColumn)
                    Include(ref aHi.HitPositions, HitPositionsEnum.Nowhere);
                else
                {
                    Include(ref aHi.HitPositions, HitPositionsEnum.OnItem);
                    if (aHi.HitColumn == Constants.NoColumn)
                    {
                        currenAlignment = this.Alignment;
                    }
                    else
                    {
                        currenAlignment = FHeader.DisplayColonnes(aHi.HitColumn).ContentAlignment;
                    }
                    DetermineHitPositionLTR(ref aHi, X, ColRight, currenAlignment);
                }
            }
        }


        private bool DoEndEdit()
        {
            //TODO: DoEndEdit() à finir
            return true;
        }

        private void HandleMouseDblClk(MouseEventArgs e, HitNodeInfo aHi)
        {
            FTimers.Stop(KindTimer.Edit);
            if (Contains(aHi.HitPositions, HitPositionsEnum.OnItemLabel) && Contains(aHi.HitNode.State, NodeState.HasChildren))
            {
                ExpandCollapse(aHi.HitNode);
                return;
            }
        }

        private void HandleMouseDown(MouseEventArgs e, HitNodeInfo aHi)
        {
            SelectionUP = true;
            SelectionDOWN = true;
#if DEBUG
			Debug.WriteLine(HitPositionsEnumToString(aHi.HitPositions));
			/*
			using (Graphics gd = this.CreateGraphics())
			{

				gd.DrawString(HitPositionsEnumToString(aHi.HitPositions), this.Font, Brushes.Black, 0,0);

			}
			*/

#endif
            if (!InEdit || DoEndEdit())
            {
                //if (!Focused)
                //	Focus();
                if (Contains(FStates, TreeStateEnum.EditPending))
                    FTimers.Stop(KindTimer.Edit);
                FHeader.SetClickIndex(aHi.HitColumn);
                if (Contains(aHi.HitPositions, HitPositionsEnum.OnItemButton))
                {
                    ExpandCollapse(aHi.HitNode);
                    return;
                }
                if (Contains(aHi.HitPositions, HitPositionsEnum.OnItemCheckbox))
                {
                    //TODO: tester si le noeud est disabled
                    //if (!IsDisabled(aHi.HitNode))
                    if (Contains(aHi.HitNode.State, NodeState.HasCheck))
                    {
                        if (CheckUnCheckNode(aHi.HitNode))
                        {
                            if (aHi.HitNode.ChildCount > 0)
                                InvalidateTree();
                            else
                            {
                                Node n = aHi.HitNode;
                                while (n != null)
                                {
                                    if (Contains(n.State, NodeState.HasCheck))
                                        InvalidateNode(n);
                                    n = n.Parent;
                                }
                            }
                        }
                    }
                    return;
                }
                if (e.Button == MouseButtons.Left && (Contains(aHi.HitPositions, HitPositionsEnum.OnItemLabel) ||
                    (Contains(aHi.HitPositions, HitPositionsEnum.OnItem) && UseColumns)))
                {
                    if ((aHi.HitNode == this.Selected) && !UseColumns)
                        Include(ref FStates, TreeStateEnum.EditPending);
                    else if (UseColumns && (aHi.HitNode == this.Selected) && this.SelectedColumn == aHi.HitColumn)
                        Include(ref FStates, TreeStateEnum.EditPending);
                }
                if (Contains(aHi.HitPositions, HitPositionsEnum.OnItem))
                {
                    //TODO: revoir le double-clic
                    Debug.WriteLine("nb clicks :" + e.Clicks.ToString());
                    if (e.Button == MouseButtons.Left)
                    {
                        if (e.Clicks == 2 && Contains(aHi.HitPositions, HitPositionsEnum.OnItemLabel))
                        {
                            if (aHi.HitNode != null && Contains(aHi.HitNode.State, NodeState.HasChildren))
                            {
                                ExpandCollapse(aHi.HitNode);
                            }
                        }
                        else //TODO GP:gestire select con ctrl
                            SelectNode(aHi.HitNode, aHi.HitColumn);
                    }
                    else if (e.Button == MouseButtons.Right)
                        SelectNode(aHi.HitNode, aHi.HitColumn);
                }
            }
        }

        private void HandleMouseUp(MouseEventArgs e, HitNodeInfo aHi)
        {
            if (Contains(FStates, TreeStateEnum.EditPending))
            {
                Exclude(ref FStates, TreeStateEnum.EditPending);
                if (FAllowEdit)
                    FTimers.Start(KindTimer.Edit);
            }
        }

        /// <summary>
        /// double clic
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoubleClick(EventArgs e)
        {
            //MouseEventArgs ea = e as MouseEventArgs est impossible car e == EventArgs.Empty, c'est nul !;
            //Cursor.Position
            //HandleMouseDoubleClick();
            base.OnDoubleClick(e);
        }

        /// <summary>
        /// surcharge OnMouseLeave la souris quitte le controle
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            //TODO: générer les évènement OnCellMouseLeave, OnItemMouseLeave si besoin
            if (UseColumns)
            {
                if (FLastNodeUnderMouse != null && FLastColUnDerMouse != Constants.InvalidColumn)
                    DoCellMouseEvent(OnCellMouseLeave, FLastNodeUnderMouse, FLastColUnDerMouse, HitPositionsEnum.OnItem, new Point(-1, -1), MouseButtons.None);
                FLastNodeUnderMouse = null;
                FLastColUnDerMouse = Constants.InvalidColumn;
            }
            else
            {
                if (FLastNodeUnderMouse != null)
                    DoCellMouseEvent(OnItemMouseLeave, FLastNodeUnderMouse, -1, HitPositionsEnum.OnItem, new Point(-1, -1), MouseButtons.None);
                FLastNodeUnderMouse = null;
            }
            base.OnMouseLeave(e);
            HideHint();
        }

        private void DoCellMouseEvent(OnNodeCellMouseDelegate eventToFire, HitNodeInfo hitInfo, MouseEventArgs e)
        {
            if (eventToFire != null)
                DoCellMouseEvent(eventToFire, hitInfo.HitNode, hitInfo.HitColumn, hitInfo.HitPositions, new Point(e.X, e.Y), e.Button);
        }

        private void DoCellMouseEvent(OnNodeCellMouseDelegate eventToFire, INode aNode, int aDisplayColumn, HitPositionsEnum aHitPositions, Point CurSorPos, MouseButtons buttons)
        {
            if (eventToFire != null)
            {
                NodeCellMouseEventArgs ev = new NodeCellMouseEventArgs(aNode, aDisplayColumn);
                ev.Button = buttons;
                ev.MousePosition = (MousePosition)aHitPositions;
                ev.Position = CurSorPos;
                eventToFire(this, ev);
            }
        }

        /// <summary>
        /// appui d'un bouton de la souris
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            HitNodeInfo hitInfo = new HitNodeInfo();

            GetHitTestInfoAt(e.X, e.Y, false, ref hitInfo);
            if (e.Clicks >= 2)
            {
                FLastClick = new Point(-1, -1);
                HandleMouseDblClk(e, hitInfo);
            }
            else
            {
                FLastClick = new Point(e.X, e.Y);
                HandleMouseDown(e, hitInfo);
            }

            if (hitInfo.HitPositions == HitPositionsEnum.Nowhere)
                return;
            DoCellMouseEvent(OnCellMouseDown, hitInfo, e);
            base.OnMouseDown(e);
        }

        /// <summary>
        /// relachement d'un bouton de la souris
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            FWaitForMouseUp = false;
            if (FDragFrm != null)
            {
                StopDrag();
            }
            else
            {
                HitNodeInfo hitInfo = new HitNodeInfo();

                GetHitTestInfoAt(e.X, e.Y, false, ref hitInfo);
                HandleMouseUp(e, hitInfo);
                this.Capture = false;
                DoCellMouseEvent(OnCellMouseUp, hitInfo, e);
            }
            base.OnMouseUp(e);
        }

        /// <summary>
        /// la souris se déplace
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
            if (InEdit || FWaitForMouseUp)
                return;
            HitNodeInfo hitInfo = new HitNodeInfo();

            GetHitTestInfoAt(e.X, e.Y, false, ref hitInfo);
            //Debug.WriteLine(String.Format("MouseMove Column : {0}", hitInfo.HitColumn));
            //Debug.WriteLine(String.Format("Mouse : {0}", e.X));
            if (e.Button == MouseButtons.Left && hitInfo.HitNode != null && (Math.Abs(FLastClick.X - e.X) >= 4 || Math.Abs(FLastClick.Y - e.Y) >= 4)
                && AllowDrag)
            {
                if (CanDragNode(hitInfo.HitNode))
                {
                    DragDropEffects effects;
                    PrepareDrag(Cursor.Position, hitInfo);
                    Include(ref FStates, TreeStateEnum.Dragging);
                    FDropHere = false;
                    FTimers.Start(KindTimer.Scroll);
                    FDragNode = hitInfo.HitNode;
                    object dataToDrag = hitInfo.HitNode.Clone(true);
                    DoDragBegin(hitInfo.HitNode, ref dataToDrag);
                    //Pendant DoDragDrop "le Code reste bloqué ici"
                    effects = DoDragDrop(new TreeViewDataObject(dataToDrag), DragDropEffects.All);
                    //if (!FDropHere && effects == DragDropEffects.Move && FMoveOnDrop)
                    if (!FDropHere && effects == DragDropEffects.Move)
                            this.Delete(hitInfo.HitNode);
                    FDragNode = null;
                    Debug.WriteLine("drag terminé");
                    StopDrag();
                    Exclude(ref FStates, TreeStateEnum.DragPending);
                    Exclude(ref FStates, TreeStateEnum.Dragging);
                    Exclude(ref FStates, TreeStateEnum.EditPending);
                    //Invalidate();
                    StartPaint(this.ClientRectangle);
                }
                else
                    FWaitForMouseUp = true;
            }
            else if (hitInfo.HitNode != null &&
                Contains(hitInfo.HitPositions, HitPositionsEnum.OnItem))
            {
                string aText = string.Empty;
                if (GetHintText(hitInfo, ref aText))
                {
                    ShowHintTimer(aText, hitInfo.HitNode, hitInfo.HitColumn);
                }
                else
                    HideHint();
                if (Contains(hitInfo.HitPositions, HitPositionsEnum.OnItemCheckbox))
                {
                    FOverCheck = true;
                    //Invalidate();
                    StartPaint(this.ClientRectangle);
                }
                else if (FOverCheck)
                {
                    FOverCheck = false;
                    //Invalidate();
                    StartPaint(this.ClientRectangle);
                }
            }
            else
            {
                HideHint();
            }
            //gestion des Mouse... Enter, Leave et Move
            if (UseColumns)
            {
                if (hitInfo.HitNode != FLastNodeUnderMouse || hitInfo.HitColumn != FLastColUnDerMouse)
                {
                    if (FLastNodeUnderMouse != null && FLastColUnDerMouse != Constants.InvalidColumn)
                        DoCellMouseEvent(OnCellMouseLeave, FLastNodeUnderMouse, FLastColUnDerMouse, HitPositionsEnum.OnItem, new Point(e.X, e.Y), e.Button);
                    FLastNodeUnderMouse = hitInfo.HitNode;
                    FLastColUnDerMouse = hitInfo.HitColumn;
                    if (FLastNodeUnderMouse != null && FLastColUnDerMouse != Constants.InvalidColumn)
                        DoCellMouseEvent(OnCellMouseEnter, FLastNodeUnderMouse, FLastColUnDerMouse, HitPositionsEnum.OnItem, new Point(e.X, e.Y), e.Button);
                }
                if (hitInfo.HitNode != null)
                {
                    if (!Contains(hitInfo.HitPositions, HitPositionsEnum.Nowhere))
                        DoCellMouseEvent(OnCellMouseMove, hitInfo, e);
                }
            }
            else
            {
                if (hitInfo.HitNode != FLastNodeUnderMouse)
                {
                    if (FLastNodeUnderMouse != null)
                        DoCellMouseEvent(OnItemMouseLeave, FLastNodeUnderMouse, -1, hitInfo.HitPositions, new Point(e.X, e.Y), e.Button);
                    FLastNodeUnderMouse = hitInfo.HitNode;
                    FLastColUnDerMouse = hitInfo.HitColumn;
                    if (FLastNodeUnderMouse != null)
                        DoCellMouseEvent(OnItemMouseEnter, FLastNodeUnderMouse, -1, HitPositionsEnum.OnItem, new Point(e.X, e.Y), e.Button);
                }
            }
            base.OnMouseMove(e);
        }

        private bool GetHintText(HitNodeInfo hitInfo, ref string aText)
        {
            aText = string.Empty;
            if (OnGetHint != null)
            {
                NodeGetHintEventArgs e = new NodeGetHintEventArgs(hitInfo.HitNode, hitInfo.HitColumn);
                OnGetHint(this, e);
                aText = e.HintText;
            }
            if (aText == null || aText.Length == 0)
            {
                if (!UseColumns || (UseColumns && hitInfo.HitColumn == MainColumnIndex))
                {
                    Rectangle rText = GetTextRect(hitInfo.HitNode);
                    rText.X += FScrolls.OffsetX - MainColumnX;
                    bool showhint = false;
                    showhint = rText.Right > this.TreeRectangle.Width;
                    if (showhint)
                        aText = GetNodeText(hitInfo.HitNode, MainColumnIndex);
                }
            }
            return (aText != null && aText.Length > 0);
        }

        /// <summary>
        /// la molette bouge
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (InEdit)
                return;
            if (e.Delta > 0)
            {
                ScrollUp(e.Delta);
            }
            else if (e.Delta < 0)
            {
                ScrollDown(-e.Delta, false);
            }
            base.OnMouseWheel(e);
        }
        #endregion

        #region gestion du clavier
        /// <summary>
        /// appui d'une touche
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Node tmp;
            Node oldSelected;
            switch ((VirtualKeys)e.KeyValue)
            {
                //case VirtualKeys.VK_F1 :
                //	ArrayList slist = FNodes.SelectedNodes;
                //	 break;
                case VirtualKeys.VK_HOME:
                    tmp = NextVisibleNode(FRoot);
                    if (Selected != tmp)
                    {
                        SelectNode(tmp);
                        ShowNode(tmp);
                    }
                    break;
                case VirtualKeys.VK_END:
                    tmp = LastVisibleNode(FRoot);
                    if (tmp != Selected)
                    {
                        SelectNode(tmp);
                        ShowNode(tmp);
                    }
                    break;
                case VirtualKeys.VK_PRIOR:
                    if (Selected != null)
                    {
                        if (IsVisibleNode(Selected) || LastVisibleNode() == Selected)
                        {
                            int h;
                            Node newSelected = CalcTopOfHeight(Selected, TreeRectangle.Height, out h, true);
                            if (SelectNode(newSelected))
                                ShowNode(newSelected);
                        }
                        else
                            ShowNode(Selected);
                    }
                    break;
                case VirtualKeys.VK_NEXT:
                    if (Selected != null)
                    {
                        if (IsVisibleNode(Selected))
                        {
                            int h = 0;

                            Node newSelected = CalcBottomOfHeight(Selected, TreeRectangle.Height, out h, true);
                            CalcBottomOfHeight(InternalTopNode(), h, out h, true);
                            if (SelectNode(newSelected))
                                ShowNode(newSelected);
                        }
                        else
                            ShowNode(Selected);
                    }
                    break;
                case VirtualKeys.VK_UP:

                    if (Selected != null)			//?????
                    {
                        oldSelected = Selected;		// read last node selected
                        tmp = oldSelected;

                        if (!e.Shift && FNodes.SelectedNodes.Count > 1)
                        {
                            FNodes.UnSelectAll();
                            InvalidateTree();
                        }

                        if (FNodes.FirstSelectedNode == oldSelected)
                        {
                            if (SelectionUP)
                            {
                                SelectionUP = false;
                                SelectionDOWN = true;
                            }
                            else
                                SelectionUP = true;
                        }
                        if (e.Shift && SelectionUP)
                        {
                            FNodes.InternalSelectNode(tmp, e.Shift && _AllowMultiSelect, FNodes.CurrentColIndex);
                            if (!ShowNode(tmp))
                            {
                                Rectangle rNode = GetNodeRect(tmp);
                                StartPaint(rNode);
                                rNode = GetNodeRect(tmp);
                                StartPaint(rNode);
                            }
                            if (IsSelectedNode(PrevVisibleNode(tmp)))
                                return;		// if prev node is selected leave all things 
                        }
                        bool hasSelected = false; 
                        do
                        {
                            tmp = PrevVisibleNode(tmp);
                            if (tmp != null && InternalSelectNode(tmp, FNodes.CurrentColIndex, e.Shift && _AllowMultiSelect))
                            {
                                hasSelected = true;
                                if (!ShowNode(tmp))
                                {
                                    Rectangle rNode = GetNodeRect(oldSelected);
                                    //Invalidate(rNode);
                                    StartPaint(rNode);
                                    rNode = GetNodeRect(tmp);
                                    //Invalidate(rNode);
                                    StartPaint(rNode);
                                }
                                DoAfterSelect(tmp, FNodes.CurrentColIndex);
                                tmp = null;
                            }
                        }
                        while (tmp != null);
                        if (!hasSelected)
                        {
                            InternalSelectNode(oldSelected, FNodes.CurrentColIndex, e.Shift && _AllowMultiSelect);
                        }
                    }
                    break;
                case VirtualKeys.VK_DOWN:


                    if (Selected != null)
                    {
                        oldSelected = Selected;
                        tmp = oldSelected;
                        bool tempSel = SelectionDOWN;

                        if (!e.Shift && FNodes.SelectedNodes.Count > 1)
                        {
                            FNodes.UnSelectAll();
                            InvalidateTree();
                        }

                        if (FNodes.FirstSelectedNode == oldSelected)
                        {
                            if (SelectionDOWN)
                            {
                                SelectionDOWN = false;
                                SelectionUP = true;
                            }
                            else
                                SelectionDOWN = true;
                        }
                        if (e.Shift && SelectionDOWN)
                        {
                            FNodes.InternalSelectNode(tmp, e.Shift && _AllowMultiSelect, FNodes.CurrentColIndex);
                            if (!ShowNode(tmp))
                            {
                                Rectangle rNode = GetNodeRect(tmp);
                                StartPaint(rNode);
                                rNode = GetNodeRect(tmp);
                                StartPaint(rNode);
                            }
                            if (IsSelectedNode(NextVisibleNode(tmp)))
                                return;		// if prev node is selected leave all things 
                        }

                        bool hasSelected = false; 
                        //la boucle est présente pour passer tout les noeuds que je ne peux selectionner
                        do
                        {
                            tmp = NextVisibleNode(tmp);
                            if (tmp != null && InternalSelectNode(tmp, FNodes.CurrentColIndex, e.Shift && _AllowMultiSelect))
                            {
                                hasSelected = true;
                                if (!ShowNode(tmp))
                                {
                                    Rectangle rNode;
                                    rNode = GetNodeRect(oldSelected);
                                    //Invalidate(rNode);
                                    StartPaint(rNode);
                                    rNode = GetNodeRect(tmp);
                                    //Invalidate(rNode);
                                    StartPaint(rNode);
                                }
                                DoAfterSelect(tmp, FNodes.CurrentColIndex);
                                tmp = null;
                            }                            
                        }
                        while (tmp != null);
                        if (!hasSelected)
                        {
                            InternalSelectNode(oldSelected, FNodes.CurrentColIndex, e.Shift && _AllowMultiSelect);
                        }
                    }
                    break;
                case VirtualKeys.VK_RIGHT:
                    if (Selected != null)
                    {
                        if ((FNodes.CurrentColIndex == MainColumnIndex && !KeysGridMode) ||
                            !UseColumns && FNodes.CurrentColIndex == -1)
                        {
                            if (IsExpanded(Selected))
                                goto case VirtualKeys.VK_DOWN;
                            else if (Selected.ChildCount > 0)
                            {
                                ExpandNode(Selected);
                            }
                            else
                                GotoColumn(NextColumn());
                        }
                        else
                            GotoColumn(NextColumn());
                    }
                    break;
                case VirtualKeys.VK_LEFT:
                    if (Selected != null)
                    {
                        if ((FNodes.CurrentColIndex == MainColumnIndex && !KeysGridMode) ||
                            !UseColumns && FNodes.CurrentColIndex == -1)
                        {
                            if (IsExpanded(Selected))
                            {
                                CollapseNode(Selected);
                            }
                            else if (Selected.Parent != FRoot)
                            {
                                SelectNode(Selected.Parent);
                                ShowNode(Selected);
                            }
                            else
                                GotoColumn(PrevColumn());
                        }
                        else
                            GotoColumn(PrevColumn());
                    }
                    break;
                case VirtualKeys.VK_TAB:
                    if (FUseKeyTab && UseColumns && !FFullRowSelect)
                    {
                        if (!e.Shift && !e.Alt && !e.Control)
                            goto case VirtualKeys.VK_RIGHT;
                        else if (e.Shift && !e.Alt && !e.Control)
                            goto case VirtualKeys.VK_LEFT;
                    }
                    break;
                case VirtualKeys.VK_F2:
                    if (AllowEdit)
                        BeginEdit();
                    break;
                case VirtualKeys.VK_SPACE:
                    if (Selected != null && Contains(Selected.State, NodeState.HasCheck) &&
                        (!UseColumns || (UseColumns && FNodes.CurrentColIndex == MainColumnIndex) ||
                            FullRowSelect))
                    {
                        CheckUnCheckNode(Selected);
                        InvalidateNode(Selected);
                    }
                    else
                        goto default;
                    break;
                case VirtualKeys.VK_ADD:
                    if (!Contains(FStates, TreeStateEnum.IncrementalSearching))
                    {
                        if (Selected != null &&
                            (FNodes.CurrentColIndex == MainColumnIndex || !UseColumns || FullRowSelect)
                            )
                        {
                            if (!IsExpanded(Selected))
                            {
                                ExpandNode(Selected);
                                InvalidateNode(Selected);
                            }
                        }
                    }
                    else
                        Include(ref FStates, TreeStateEnum.IncrementalSearchPending);
                    break;
                case VirtualKeys.VK_SUBTRACT:
                    if (!Contains(FStates, TreeStateEnum.IncrementalSearching))
                    {
                        if (Selected != null && (FNodes.CurrentColIndex == MainColumnIndex || !UseColumns || FullRowSelect))
                        {
                            if (IsExpanded(Selected))
                            {
                                CollapseNode(Selected);
                                InvalidateNode(Selected);
                            }
                        }
                    }
                    else
                        Include(ref FStates, TreeStateEnum.IncrementalSearchPending);
                    break;
                case VirtualKeys.VK_MULTIPLY:
                    if (Selected != null && (FNodes.CurrentColIndex == MainColumnIndex || !UseColumns || FullRowSelect))
                    {
                        ExpandAll(Selected);
                    }
                    break;
                case VirtualKeys.VK_DIVIDE:
                    if (Selected != null && (FNodes.CurrentColIndex == MainColumnIndex || !UseColumns || FullRowSelect))
                    {
                        CollapseAll(Selected);
                    }
                    break;
                case VirtualKeys.VK_ESCAPE:
                    this.Cancel();
                    break;
                default:
                    if (e.KeyValue > 32)
                    {
                        Include(ref FStates, TreeStateEnum.IncrementalSearchPending);
                    }
                    base.OnKeyDown(e);
                    break;
            }
            /*
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(Brushes.White, 100,50,50,50);
                g.DrawString(String.Format("{0} : {1:X}", e.KeyCode, e.KeyValue), this.Font, Brushes.Black, 100,50);
            }
            */
        }

        protected void Cancel()
        {
            FHeader.Cancel();
            Debug.WriteLine("Cancel()");
        }

        /// <summary>
        /// une touche est pressé lancement de la recherche incrémentale
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            if (Contains(FStates, TreeStateEnum.IncrementalSearchPending) && (!UseColumns || SelectedColumn == MainColumnIndex))
            {
                HandleIncrementalSearch(e.KeyChar);
            }
        }

        private void HandleIncrementalSearch(char keyChar)
        {
            FTimers.Stop(KindTimer.Search);
            if (FSearchHelper == null)
            {
                FSearchHelper = new SearchHelper(this);
            }
            if (FSearchHelper.HandleIncrementalSearch(keyChar))
            {
                FTimers.Start(KindTimer.Search);
            }
        }

        internal bool DoIncrementalSearch(Node run, string search)
        {
            if (run != null)
            {
                int aDisplayColumn = SelectedColumn;
                if (FullRowSelect && UseColumns)
                {
                    if (SearchColumn >= 0 && SearchColumn < Header.Colonnes.Count)
                        aDisplayColumn = Header.IndexOfDisplay(Header.Colonnes[SearchColumn]);
                }
                string text = GetNodeText(run, aDisplayColumn);
                if (text != null && text.StartsWith(search))
                    return true;
            }
            return false;
        }

        internal bool DoIncrementalSearch1(Node run, string search, int aDisplayColumn)
        {
            if (run != null)
            {
                string text = GetNodeText(run, aDisplayColumn);
                if (text != null && text.StartsWith(search))
                    return true;
            }
            return false;
        }

        #endregion

        #region gestion de l'édition
        /// <summary>
        /// indique que l'édition d'un noeud est en cours
        /// </summary>
        protected bool InEdit
        {
            get
            {
                return FEditor != null;
            }
        }

        /// <summary>
        /// effectue la fin de l'édition, renvoi true si réussi
        /// </summary>
        /// <returns></returns>
        public bool TryEndEdit()
        {
            if (InEdit)
            {
                DoAfterEdit(FEditor, Selected, FNodes.CurrentColIndex);
                FEditor.EndEdit();
                DisposeEdit();
                InvalidateNode(Selected);
            }
            return true;
        }

        private void DoAfterEdit(ITreeViewEdit editor, INode n, int aDisplayColumn)
        {
            if (OnAfterEdit != null)
                OnAfterEdit(this, new EditEventArgs(n, aDisplayColumn, editor));
        }

        public bool CancelEdit()
        {
            if (InEdit)
            {
                FEditor.CancelEdit();
                DisposeEdit();
            }
            return true;
        }

        protected void DisposeEdit()
        {
            if (FEditor != null)
            {
                //FEditor.OnKeyDown -=new KeyEventHandler(Editor_OnKeyDown);
                if (FEditor is IDisposable)
                    ((IDisposable)FEditor).Dispose();
                FEditor = null;
            }
        }

        public bool BeginEdit()
        {
            if (Selected != null && !InEdit && CanEdit(Selected, FNodes.CurrentColIndex))
            {
                FTimers.Stop(KindTimer.Edit);
                HideHint();
                bool redessine = ShowSelectedColumn();
                if (!ShowNode(Selected) && redessine)
                    InvalidateTree();

                FEditor = CreateEditor(Selected, FNodes.CurrentColIndex);
                Rectangle rNode = GetEditRect(Selected, FNodes.CurrentColIndex);
                if (!UseColumns)
                    rNode.Width += 20;

                object Value = DoInitEdit(FEditor, Selected, FNodes.CurrentColIndex);
                FEditor.BeginEdit(Selected, FNodes.CurrentColIndex, rNode, Value);
                return true;
            }
            return false;
        }

        private Rectangle GetEditRect(Node aNode, int aDisplayColumn)
        {
            Rectangle Result = GetTextRect(Selected, FNodes.CurrentColIndex);
            if (OnGetEditRect != null)
            {
                EditRectEventArgs ev = new EditRectEventArgs(aNode, aDisplayColumn);
                OnGetEditRect(this, ev);
                Result = ev.EditRect;
            }
            return Result;
        }

        private object DoInitEdit(ITreeViewEdit editor, INode n, int aDisplayColumn)
        {
            if (OnInitEdit != null)
            {
                EditEventArgs e = new EditEventArgs(n, aDisplayColumn, editor);
                OnInitEdit(this, e);
                return e.Value;
            }
            return GetNodeText(n, aDisplayColumn);
        }

        private ITreeViewEdit CreateEditor(INode aNode, int aCol)
        {
            ITreeViewEdit editor = null;
            if (OnCreateEditor != null)
            {
                NodeEditorEventArgs e = new NodeEditorEventArgs(aNode, aCol);
                OnCreateEditor(this, e);
                editor = e.Editor;
                if (editor == null)
                    editor = new GeniusTreeViewEditor(this);
            }
            else
                editor = new GeniusTreeViewEditor(this);
            return editor;
        }
        #endregion

        private string GetNodeText(Node aNode, int aColIndex)
        {
            if (FDataIsStringProvider)
            {
                IStringNodeProvider stringProvider = aNode.Data as IStringNodeProvider;
                if (stringProvider != null)
                {
                    if (!UseColumns)
                    {
                        string st = stringProvider.GetText(-1);
                        if (string.Compare(st, aNode.Text, StringComparison.InvariantCulture) != 0)
                        {
                            aNode.Text = st;
                            aNode.Width = 0;
                            UpdateHorizontalScrollBar();
                            return st;
                        }
                    }
                    return stringProvider.GetText(aColIndex);
                }
                else
                    return string.Empty;
            }
            else
            {

                if (OnGetNodeText != null)
                {
                    NodeTextEventArgs ev = new NodeTextEventArgs(aNode, aColIndex,
                        UseColumns ? (aColIndex == MainColumnIndex ? aNode.Text : string.Empty)
                        : aNode.Text);
                    OnGetNodeText(this, ev);
                    return ev.Text;
                }
                else
                {
                    return UseColumns ? (aColIndex == MainColumnIndex ? aNode.Text : string.Empty) : aNode.Text;
                }
            }
        }

        private void SetNodeText(Node aNode, int aColIndex, string aText)
        {
            //TODO: faire un cache pour les textes des colonnes
            if (aColIndex == MainColumnIndex)
            {
                ((INode)aNode).Text = aText;
            }
        }

        /// <summary>
        /// récupère le texte d'un noeud et d'une colonne
        /// </summary>
        /// <param name="aNode"></param>
        /// <param name="aColIndex"></param>
        /// <returns></returns>
        public string GetNodeText(INode aNode, int aColIndex)
        {
            return GetNodeText((Node)aNode, aColIndex);
        }

        /// <summary>
        /// place un texte d'un noeud et d'un colonne 
        /// cette méthode n'a d'effet que sur la colonne principale
        /// </summary>
        /// <param name="aNode"></param>
        /// <param name="aColIndex"></param>
        /// <param name="aText"></param>
        public void SetNodeText(INode aNode, int aColIndex, string aText)
        {
            SetNodeText((Node)aNode, aColIndex, aText);
        }


        private bool CanEdit(Node aNode, int aDisplayCol)
        {
            bool Result = true;
            if (UseColumns)
                Result = FHeader.DisplayColonnes(aDisplayCol).AllowEdit;
            if (OnBeforeEdit != null)
            {
                CanEditEventArgs ev = new CanEditEventArgs(aNode, aDisplayCol);
                ev.CanEdit = Result;
                OnBeforeEdit(this, ev);
                return ev.CanEdit;
            }
            return Result;
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);
            e.Cancel = !TryEndEdit();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (Selected != null)
                InvalidateNode(Selected);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            FTimers.StopAll();
            Exclude(ref FStates, TreeStateEnum.IncrementalSearching);
            Exclude(ref FStates, TreeStateEnum.IncrementalSearchPending);
            FSearchHelper = null;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        /// <summary>
        /// redessin de la selection sur la perte de focus
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            FTimers.Stop(KindTimer.Edit);
            base.OnLostFocus(e);
            if (Selected != null)
                InvalidateNode(Selected);
        }

        /// <summary>
        /// Gestion du header qui se trouve dans la zone NonClient
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)Msgs.WM_NCHITTEST:
                    base.WndProc(ref m);
                    //uniquement pour recevoir les nc_buttonxx dans le header
                    //car on ne recoit pas tous les messages dans OnNotifyMessage
                    if (ShowHeader)
                    {
                        int y = (int)((long)m.LParam & (long)0xffff0000) >> 16;
                        Point p = new Point(0, y);
                        p = this.PointToClient(p);
                        if (p.Y < 0)
                            m.Result = new IntPtr((int)HitTest.HTBORDER);
                    }
                    break;
                case (int)Msgs.WM_MOUSEMOVE:
                    if (ShowHeader)
                    {
                        if (FHeader.HandleMessage(m))
                            return;
                    }
                    base.WndProc(ref m);
                    break;
                case (int)Msgs.WM_CANCELMODE:
                    FTimers.StopAll();
                    Debug.WriteLine("CancelMode");
                    break;
                case (int)Msgs.WM_GETDLGCODE:
                    m.Result = new IntPtr((int)(DialogCodes.DLGC_WANTARROWS | (FUseKeyTab ? DialogCodes.DLGC_WANTTAB : 0)));
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// surchage de OnNotifyMessage pour les message de gestion de la scrollpbar et du NCPaint
        /// </summary>
        /// <param name="m"></param>
        protected override void OnNotifyMessage(Message m)
        {
            //OnNotifyMessage est bien mais on ne peut empecher le traitement du message par l'ancêtre
            /*
            if ((m.Msg >= (int)Msgs.WM_NCMOUSEMOVE && m.Msg <= (int)Msgs.WM_NCMBUTTONDBLCLK) ||
                (m.Msg >= (int)Msgs.WM_MOUSEMOVE && m.Msg <= (int)Msgs.WM_MOUSEWHEEL) || m.Msg != 32)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    g.FillRectangle(Brushes.White, 100,50,50,50);
                    g.DrawString(String.Format("{0} : {1:X}", m.Msg, m.Msg), this.Font, Brushes.Black, 100,50);
                }
            }
            */
            if (ShowHeader)
            {
                if (FHeader.HandleMessage(m))
                    return;
            }
            switch ((Msgs)m.Msg)
            {
                case Msgs.WM_NCCALCSIZE:
                    int a = (int)m.WParam;
                    if (a != 0)
                    {
                        if (ShowHeader)
                        {
                            NCCalcSizeParams size = (NCCalcSizeParams)Marshal.PtrToStructure(m.LParam, typeof(NCCalcSizeParams));
                            size.rgrc0.Top += GetHeaderHeight();
                            Marshal.StructureToPtr(size, m.LParam, false);
                        }
                        //Debug.WriteLine("WM_NCCALCSIZE fCalcValidRects = true");
                    }
                    else
                        Debug.WriteLine("WM_NCCALCSIZE fCalcValidRects = false");
                    break;
                case Msgs.WM_NCPAINT:
                    if (FShowHeader)
                    {
                        FlagsDCX flags = FlagsDCX.DCX_CACHE | FlagsDCX.DCX_CLIPSIBLINGS | FlagsDCX.DCX_WINDOW | FlagsDCX.DCX_VALIDATE;
                        //IntPtr.Zero w.Wparam plante sous Vista
                        IntPtr dc = NativeMethods.GetDCEx(this.Handle, IntPtr.Zero/*m.WParam*/, flags);
                        try
                        {
                            using (Graphics g = Graphics.FromHdc(dc))
                            {
                                Rectangle rectRegion = Rectangle.Empty;
                                if (rectRegion.IsEmpty)
                                {
                                    rectRegion = new Rectangle(0, 0, this.Size.Width, this.HeaderHeight);
                                    switch (this.BorderStyle)
                                    {
                                        case BorderStyle.FixedSingle:
                                            g.TranslateTransform(1, 1);
                                            rectRegion.Width -= 1;
                                            break;
                                        case BorderStyle.Fixed3D:
                                            g.TranslateTransform(2, 2);
                                            rectRegion.Width -= 2;
                                            break;
                                    }
                                }
                                if (this.Size.Width > 0)
                                    FHeader.PaintHeader(g, rectRegion, -FScrolls.OffsetX);
                            }
                        }
                        finally
                        {
                            NativeMethods.ReleaseDC(this.Handle, dc);
                        }
                        m.Result = IntPtr.Zero;
                    }
                    break;
            }
            if (m.Msg == 277) //WM_VSCROLL
            {
                #region Help Win32
                /*
					 * WM_VSCROLL  
nScrollCode = (int) LOWORD(wParam); // scroll bar value 
nPos = (short int) HIWORD(wParam);  // scroll box position 
hwndScrollBar = (HWND) lParam;      // handle of scroll bar 
nScrollCode

Value of the low-order word of wParam. Specifies a scroll bar value that indicates the user's scrolling request. This parameter can be one of the following values: 

Value	Meaning
SB_BOTTOM	Scrolls to the lower right.
SB_ENDSCROLL	Ends scroll.
SB_LINEDOWN	Scrolls one line down.
SB_LINEUP	Scrolls one line up.
SB_PAGEDOWN	Scrolls one page down.
SB_PAGEUP	Scrolls one page up.
SB_THUMBPOSITION	Scrolls to the absolute position. The current position is specified by the nPos parameter.
SB_THUMBTRACK	Drags scroll box to the specified position. The current position is specified by the nPos parameter.
SB_TOP	Scrolls to the upper left.
 

nPos

Value of the high-order word of wParam. Specifies the current position of the scroll box if the nScrollCode parameter is SB_THUMBPOSITION or SB_THUMBTRACK; otherwise, nPos is not used. 
					 * */
                #endregion

                #region WM_VSCROLL
                int wparam = m.WParam.ToInt32();
                int scrollcode = (wparam & 0x0000FFFF);
                //pas de scrollpos il est limite à 65535, trop peu, mais pour windows 2000, je suis obligé
                int scrollpos = ((wparam >> 16) & 0x0000FFFF);
                switch (scrollcode)
                {
                    case 0: //:SB_LINEUP
                        ScrollLineUp();
                        break;
                    case 1: //SB_LINEDOWN
                        ScrollLineDown();
                        break;
                    case 2: //SB_PAGEUP
                        ScrollUp(this.TreeRectangle.Height);
                        break;
                    case 3:
                        ScrollDown(this.TreeRectangle.Height, false);
                        break;
                    case 5: //SB_THUMBTRACK ou SB_THUMBPOSITION
                        if (FTopNode != null)
                        {
                            //pb avec Windows 2000, GetScrollInfo ne renvoi pas la position du track
                            if (System.Environment.OSVersion.Version.Major >= 5 && System.Environment.OSVersion.Version.Minor >= 1)
                                scrollpos = FScrolls.VScrollPos;
                            Debug.WriteLine("scrollpos :" + scrollpos.ToString());
                            int sens = scrollpos - FScrolls.OffsetY;
                            if (sens > 0 && FScrolls.CanScrollDown())
                            {
                                scrollpos = 0;
                                while (FTopNode != null && sens >= FTopNode.Height && FScrolls.CanScrollDown())
                                {
                                    sens -= FTopNode.Height;
                                    scrollpos += FTopNode.Height;
                                    FTopNode = NextVisibleNode(FTopNode);
                                }
                                if (scrollpos != 0)
                                {
                                    FBottomNode = null;
                                    FLastVisibleNode = null;
                                    FScrolls.OffsetY += scrollpos;
                                    UpdateHorizontalScrollBar();
                                    InvalidateTree();
                                }
                            }
                            else if (sens < 0 && FScrolls.CanScrollUp())
                            {
                                Node tmp;
                                bool change = false;
                                sens = -sens;
                                scrollpos = 0;
                                do
                                {
                                    tmp = PrevVisibleNode(FTopNode);
                                    if (tmp != null && sens >= tmp.Height)
                                    {
                                        sens -= tmp.Height;
                                        scrollpos += tmp.Height;
                                        FTopNode = tmp;
                                        change = true;
                                    }
                                }
                                while (tmp != null && sens >= tmp.Height && FScrolls.CanScrollUp());

                                if (change)
                                {
                                    FBottomNode = null;
                                    FLastVisibleNode = null;
                                    FScrolls.OffsetY -= scrollpos;
                                    if (FScrolls.OffsetY < 0)
                                        FScrolls.OffsetY = 0;
                                    UpdateHorizontalScrollBar();
                                    InvalidateTree();
                                }
                            }

                        }
                        break;
                }
                if (!this.Focused)
                    this.Focus();
                #endregion
            }
            else if (m.Msg == 276) //WM_HSCROLL
            {
                #region WM_HSCROLL
                int maxx;
                int wparam = m.WParam.ToInt32();
                int scrollcode = (wparam & 0x0000FFFF);
                int scrollpos = ((wparam >> 16) & 0x0000FFFF);
                switch (scrollcode)
                {
                    case 0:
                        if (FScrolls.OffsetX > 0)
                        {
                            FScrolls.OffsetX -= 8;
                            if (FScrolls.OffsetX < 0)
                                FScrolls.OffsetX = 0;
                            InvalidateTree();
                        }
                        break;
                    case 1:
                        maxx = FScrolls.RangeX - this.TreeRectangle.Width;
                        if (FScrolls.OffsetX < maxx)
                        {
                            FScrolls.OffsetX += 8;
                            if (FScrolls.OffsetX > maxx)
                                FScrolls.OffsetX = maxx;
                            InvalidateTree();
                        }
                        break;
                    case 2:
                        if (FScrolls.OffsetX > 0)
                        {
                            FScrolls.OffsetX -= this.TreeRectangle.Width;
                            if (FScrolls.OffsetX < 0)
                                FScrolls.OffsetX = 0;
                            InvalidateTree();
                        }
                        break;
                    case 3:
                        maxx = FScrolls.RangeX - this.TreeRectangle.Width;
                        if (FScrolls.OffsetX < maxx)
                        {
                            FScrolls.OffsetX += this.TreeRectangle.Width; ;
                            if (FScrolls.OffsetX > maxx)
                                FScrolls.OffsetX = maxx;
                            InvalidateTree();
                        }
                        break;
                    case 5: //SB_THUMBTRACK
                        if (FScrolls.OffsetX != scrollpos)
                        {
                            FScrolls.OffsetX = scrollpos;
                            InvalidateTree();
                        }
                        break;
                }
                if (!this.Focused)
                    this.Focus();
                #endregion
            }
            else
                base.OnNotifyMessage(m);
        }

        private void ScrollLineUp()
        {
            if (FTopNode != null && FScrolls.CanScrollUp())
            {
                Node tmp = PrevVisibleNode(FTopNode);
                if (tmp != null)
                {
                    FScrolls.OffsetY -= tmp.Height;
                    if (FScrolls.OffsetY < 0)
                        FScrolls.OffsetY = 0;
                    FTopNode = tmp;
                    FBottomNode = null;
                    FLastVisibleNode = null;
                    UpdateHorizontalScrollBar();
                    InvalidateTree();
                }
                else
                    FScrolls.OffsetY = 0;
            }
        }

        private void ScrollLineDown()
        {
            if (FTopNode != null && FScrolls.CanScrollDown())
            {
                FScrolls.OffsetY = FScrolls.OffsetY + FTopNode.Height;
                FTopNode = NextVisibleNode(FTopNode);
                FBottomNode = null;
                FLastVisibleNode = null;
                UpdateHorizontalScrollBar();
                InvalidateTree();
            }
        }

        private bool CanDelete(Node aNode)
        {
            if (OnBeforeDelete != null)
            {
                NodeDeleteEventArgs e = new NodeDeleteEventArgs(aNode);
                OnBeforeDelete(this, e);
                return e.CanDelete;
            }
            return true;
        }

        private void DoAfterDelete(Node aNode)
        {
            if (OnAfterDelete != null)
                OnAfterDelete(this, new NodeEventArgs(aNode));
        }
        #endregion

        #region méthodes publiques
        #region gestion des noeuds
        /// <summary>
        /// rend un noeud visible (scroll si nécessaire pour que l'utilisateur puisse le voir à l'écran)
        /// </summary>
        /// <param name="n"></param>
        /// <returns>return true si le noeud est visible</returns>
        public bool ShowNode(INode n)
        {
            return ShowNode((Node)n);
        }

        /// <summary>
        /// idem que <see cref="ShowNode(INode)"/>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="centerOnView"></param>
        /// <returns></returns>
        public bool ShowNode(INode n, bool centerOnView)
        {
            return ShowNode((Node)n, centerOnView);
        }
        /// <summary>
        /// selection d'un noeud et d'un colonne
        /// </summary>
        /// <param name="n">la noeud à selectioner</param>
        /// <param name="aCol">la colonne</param>
        /// <returns></returns>
        public bool SelectNode(INode n, int aCol)
        {
            return SelectNode((Node)n, aCol);
        }

        /// <summary>
        /// Gets the selected node collection as readonlycollection
        /// </summary>
        [Category("Misc"), Description("Gets the selected node collection"), Browsable(false)]
        public ReadOnlyCollection<INode> SelectedNodes
        {
            get
            {
                return FNodes.SelectedNodes;
            }
        }
        /// <summary>
        /// Root node of treeview
        /// </summary>
        [Category("Misc"), Description("Gets the tree root node"), Browsable(false)]
        public INode Root
        {
            get
            {
                return FNodes.RootNode;
            }
        }

        /// <summary>
        /// selection d'un noeud sur la colonne courante
        /// </summary>
        /// <param name="n">le noeud à selectionner</param>
        /// <returns></returns>
        public bool SelectNode(INode n)
        {
            if (n == null)
                return false;
            return SelectNode((Node)n, FNodes.CurrentColIndex);
        }
        /// <summary>
        /// Ajout d'un noeud
        /// </summary>
        /// <param name="aParent">le noeud parent</param>
        /// <param name="aData">la donnée utilisateur à associée</param>
        /// <returns><see cref="INode"/></returns>
        public INode Add(INode aParent, object aData)
        {
            return Add(aParent, null, aData);
        }

        /// <summary>
        /// ajout d'un noeud
        /// </summary>
        /// <param name="aParent"></param>
        /// <param name="aText"></param>
        /// <param name="aData"></param>
        /// <returns></returns>
        public INode Add(INode aParent, string aText, object aData)
        {
            Node Result;
            FUpdateCount++;
            try
            {
                Result = FNodes.InternalAdd((Node)aParent, aData);
                if (aText != null && (Result.Text == null || Result.Text.Length == 0))
                    Result.Text = aText;
            }
            finally
            {
                FUpdateCount--;
            }
            if (FUpdateCount == 0)
            {
                if (AutoSort)
                {
                    if (aParent.Count > 2)
                        FCachedText = new Hashtable();
                    try
                    {
                        FNodes.DoSort((Node)aParent, FHeader.SortColumns, FHeader.SortingDirections, new OnCompareNodeDelegate(this.DoCompare), false);
                    }
                    finally
                    {
                        FCachedText = null;
                    }
                }
                UpdateScrollBars(true);
                InvalidateTree();
            }
            else
                FUpdateScrollBarsNeeded = true;
            return Result;
        }

        private void Delete(Node n, bool askUser)
        {
            Node aNode = n;
            if (!askUser || (askUser && CanDelete(aNode)))
            {
                bool isfullyvisible = IsFullyVisible(aNode);
                if (FNodes.InternalDelete(aNode))
                {
                    if (FTopNode == aNode)
                    {
                        RecalculTopNode();
                        FBottomNode = null;
                        FLastVisibleNode = null;
                    }
                    if (FBottomNode == aNode)
                    {
                        FBottomNode = null;
                        FLastVisibleNode = null;
                    }
                    //le noeud que j'efface est-il visible
                    if (isfullyvisible)
                    {
                        InvalidateTree();
                    }
                }
                if (askUser)
                    DoAfterDelete(aNode);
            }
        }

        /// <summary>
        /// enlève un ou plusieurs noeud de l'arbre
        /// </summary>
        /// <param name="noeuds">le(s) noeud(s) à supprimer</param>
        public void Delete(params INode[] noeuds)
        {
            foreach (INode n in noeuds)
                Delete((Node)n, true);
        }

        private void Insert(Node aNode, Node where, DragPosition position)
        {
            FNodes.InternalInsert(aNode, where, position);
            if (position == DragPosition.Under && !Set.Contains(where.State, NodeState.Expanded))
                ExpandNode(where);
        }

        /// <summary>
        /// vide l'arbre
        /// </summary>
        public void Clear()
        {
            CancelEdit();
            FNodes.Clear();
            FRoot = FNodes.RootNode;
            FTopNode = null;
            FBottomNode = null;
            FLastVisibleNode = null;
            FScrolls.OffsetY = 0;
            FScrolls.RangeY = 0;
            FLastNodeUnderMouse = null;
            FLastColUnDerMouse = Constants.InvalidColumn;
            InvalidateTree();
        }


        /// <summary>
        /// vide un noeud de ses enfants
        /// </summary>
        /// <param name="aParent">le noeud à vider</param>
        public void ClearChild(INode aParent)
        {
            if (aParent.Count > 0)
            {
                BeginUpdate();
                try
                {
                    INode n = aParent.Last;
                    while (n != null)
                    {
                        INode aPrec = n.PrevSibling;
                        Delete(n);
                        n = aPrec;
                    }
                }
                finally
                {
                    EndUpdate();
                }
            }
        }

        /// <summary>
        /// retourne le premier noeud visible du control
        /// </summary>
        /// <returns></returns>
        public INode TopNode()
        {
            return InternalTopNode();
        }

        /// <summary>
        /// le dernier noeud visible du control
        /// </summary>
        /// <returns></returns>
        public INode BottomNode()
        {
            return InternalBottomNode();
        }


        /// <summary>
        /// renvoi le premier noeud
        /// </summary>
        /// <returns></returns>
        public INode First()
        {
            return FRoot.FirstChild;
        }

        /// <summary>
        /// renvoi le premier noeud visible
        /// </summary>
        /// <returns></returns>
        public INode FirstVisible()
        {
            Node n = FRoot.FirstChild;
            if (!IsFullyVisible(n))
                n = Node.NextVisibleNode(n);
            return n;
        }


        public void SetVisibleNode(INode aNode, bool value)
        {
            CancelEdit();
            Node n = (Node)aNode;
            if (n == Selected && value == false)
                FLastClick = new Point(-1, -1);
            int aHeight;
            if (FNodes.InternalSetVisible(n, value, out aHeight))
            {
                if (FTopNode == n)
                    FTopNode = null;

                UpdateScrollBars(n, aHeight);
                InvalidateTree();
            }
        }

        /// <summary>
        /// déplie ou replie un noeud
        /// </summary>
        /// <param name="aNode">le noeud à replier, <seealso cref="INode"/></param>
        public void ExpandCollapseNode(INode aNode)
        {
            ExpandCollapse((Node)aNode);
        }

        private int ExpandAllNode(Node aNode)
        {
            int Result = 0;
            if (!Set.Contains(aNode.State, NodeState.Expanded) && Set.Contains(aNode.State, NodeState.HasChildren))
            {
                int aHeight;
                if (FNodes.InternalExpand(aNode, out aHeight))
                {
                    Result += aHeight;
                    if (OnAfterExpand != null)
                        OnAfterExpand(this, new NodeEventArgs(aNode));
                }
            }
            if (aNode.ChildCount > 0)
            {
                foreach (Node child in aNode.Children)
                {
                    Result += ExpandAllNode(child);
                }
            }
            return Result;
        }

        /// <summary>
        /// deplie le noeud et tous ses fils
        /// </summary>
        /// <param name="aNode">le noeud à deplier</param>
        public void ExpandAll(INode aNode)
        {
            int aHeight = ExpandAllNode((Node)aNode);
            if (aHeight > 0)
            {
                UpdateScrollBars(true);
                FScrolls.OffsetY = InternalTopNode().TopPosition;
                InvalidateTree();
            }
        }

        /// <summary>
        /// deplie tous les noeuds de l'arbre
        /// </summary>
        public void ExpandAll()
        {
            ExpandAll(FRoot);
        }

        private int CollapseAllNode(Node aNode)
        {
            int Result = 0;
            if (aNode.ChildCount > 0)
            {
                foreach (Node child in aNode.Children)
                {
                    Result += CollapseAllNode(child);
                }
            }
            if (Set.Contains(aNode.State, NodeState.Expanded))
            {
                int aHeight;
                if (FNodes.InternalCollapse(aNode, out aHeight))
                {
                    Result += aHeight;
                    if (OnAfterCollapse != null)
                        OnAfterCollapse(this, new NodeEventArgs(aNode));
                }
            }
            return Result;
        }

        /// <summary>
        /// replie le noeud et tous ses fils
        /// </summary>
        /// <param name="aNode">le noeud à replier</param>
        public void CollapseAll(INode aNode)
        {
            int aHeight = CollapseAllNode((Node)aNode);
            if (aHeight < 0)
            {
                UpdateScrollBars(true);
                FScrolls.OffsetY = InternalTopNode().TopPosition;
                InvalidateTree();
            }
        }

        /// <summary>
        /// renvoi le noeud sous le point pt
        /// </summary>
        /// <param name="pt">le point à tester</param>
        /// <returns>un <see cref="INode"/>, ou null si aucun point</returns>
        public INode GetNodeAtPoint(Point pt)
        {
            MousePosition dummy;
            int aDisplayColumn;
            return GetNodeAtPoint(pt, out aDisplayColumn, out dummy);
        }

        /// <summary>
        /// renvoi le noeud sous le point pt, ainsi que la colonne concernée
        /// </summary>
        /// <param name="pt">le point à tester</param>
        /// <param name="aDisplayColumn">la colonne concernée, en mode grille uniquement</param>
        /// <returns>un <see cref="INode"/></returns>
        public INode GetNodeAtPoint(Point pt, out int aDisplayColumn)
        {
            MousePosition dummy;

            return GetNodeAtPoint(pt, out aDisplayColumn, out dummy);
        }

        /// <summary>
        /// renvoi le noeud sous le point pt, la colonne concernée, la position de la souris
        /// sur ce noeud
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="aDisplayColumn"></param>
        /// <param name="aMousePosition"></param>
        /// <returns></returns>
        public INode GetNodeAtPoint(Point pt, out int aDisplayColumn, out MousePosition aMousePosition)
        {
            HitNodeInfo hitInfo = new HitNodeInfo();
            GetHitTestInfoAt(pt.X, pt.Y, true, ref hitInfo);
            aDisplayColumn = hitInfo.HitColumn;
            aMousePosition = (MousePosition)hitInfo.HitPositions;
            return hitInfo.HitNode;
        }

        /// <summary>
        /// check un noeud
        /// </summary>
        /// <param name="n"></param>
        public void CheckNode(INode n)
        {
            InternalCheckNode((Node)n);
        }

        /// <summary>
        /// uncheck un noeud
        /// </summary>
        /// <param name="n"></param>
        public void UnCheckNode(INode n)
        {
            InternalUnCheckNode((Node)n);
        }
        #endregion

        #region BeginUpdate-EndUpdate
        /// <summary>
        /// lors d'ajout, de suppression massive,utilisez cette méthode
        /// afin d'empêcher le raffraichissement pendant vos opérations
        /// ATTENTION : à chaque appel à <see cref="BeginUpdate"/>, il faut un appel à <see cref="EndUpdate"/>.
        /// </summary>
        public void BeginUpdate()
        {
            FUpdateCount++;
        }

        /// <summary>
        /// la méthode correspondante à <see cref="BeginUpdate"/>
        /// lorsque le nombre d'appel à EndUpdate, correspond au nombre d'appel
        /// à <see cref="BeginUpdate"/>, le control est raffraichit
        /// </summary>
        public void EndUpdate()
        {
            FUpdateCount--;
            if (FUpdateCount <= 0)
            {
                FUpdateCount = 0;
                InvalidateTree();
            }
        }
        #endregion

        #region gestion des colonnes visuels
        /// <summary>
        /// échange deux colonnes, les index sont des index visuels. 
        /// l'index visuel 0, correspond à la première colonne visible à l'écran !
        /// </summary>
        /// <param name="index1">l'index "visuel" de la première colonne</param>
        /// <param name="index2">l'index "visuel" de la deuxième colonne</param>
        public void SwapColonnes(int index1, int index2)
        {
            FHeader.SwapColonnes(index1, index2);
        }
        #endregion

        #region gestion du tri
        private string DoGetNodeText(INode A, int acol)
        {
            string aText;
            if (FCachedText != null && FCachedText.Contains(A))
                aText = (string)FCachedText[A];
            else
            {
                aText = GetNodeText(A, acol);
                if (FCachedText != null)
                    FCachedText[A] = aText;
            }
            return aText;
        }

        private IComparable DoGetNodeValue(INode A, int acol)
        {
            IComparable aValue;
            IDictionary aValues;

            if (FCachedText != null)
            {
                if (FCachedText.Contains(acol))
                {
                    aValues = (IDictionary)FCachedText[acol];
                }
                else
                {
                    aValues = new Hashtable();
                    FCachedText[acol] = aValues;
                }
                if (aValues.Contains(A))
                    aValue = (IComparable)aValues[A];
                else
                {
                    aValue = OnGetNodeValue(A, acol);
                    aValues[A] = aValue;
                }
            }
            else
            {
                aValue = OnGetNodeValue(A, acol);
            }
            return aValue;
        }

        private int DoCompare(IComparable A, IComparable B)
        {
            if (A == null)
                return B != null ? -1 : 0;
            if (B == null)
                return 1;
            return A.CompareTo(B);
        }

        private int DoCompare(INode A, INode B, int aCol)
        {
            if (OnGetNodeValue != null)
            {
                IComparable aValue = DoGetNodeValue(A, aCol);
                IComparable bValue = DoGetNodeValue(B, aCol);
                return DoCompare(aValue, bValue);
            }
            if (OnCompareNode != null)
                return OnCompareNode(A, B, aCol);
            else
            {
                string aText = DoGetNodeText(A, aCol);
                string bText = DoGetNodeText(B, aCol);

                return DoCompare(aText, bText);
            }
        }

        /// <summary>
        /// trie l'arbre en entier sur un colonne, et met à jour le header, en fonction du tri
        /// </summary>
        /// <param name="aDisplayCol"></param>
        /// <param name="aDirection"></param>
        public void SortTree(int aDisplayCol, SortDirection aDirection)
        {
            SortTree(new int[] { aDisplayCol }, new SortDirection[] { aDirection });
        }

        /// <summary>
        /// trie l'arbre en entier, et met à jour le header, en fonction du tri
        /// </summary>
        /// <param name="aDisplayCols"></param>
        /// <param name="aDirections"></param>
        /// <example>
        /// <code>
        /// ...
        /// gtv.SortTree(new int[2]{0,1}, new SortDirection[]{SortDirection.Ascending, SortDirection.Descending});
        /// </code>
        /// </example>
        public void SortTree(int[] aDisplayCols, SortDirection[] aDirections)
        {
            if (aDisplayCols[0] > Constants.NoColumn)
            {
                FHeader.SetSortColumn(Header.DisplayIndexToIndex(aDisplayCols), aDirections);
                SortChildNodes(FRoot, aDisplayCols, aDirections, true);
            }
        }


        /// <summary>
        /// tri les noeuds d'un noeud parent, utilisé pour effectuer des tris différents en fonction du niveau des noeuds par exemple
        /// </summary>
        /// <param name="aNode"></param>
        /// <param name="aCols"></param>
        /// <param name="aDirections"></param>
        /// <param name="recurse"></param>
        public void SortChildNodes(INode aNode, int[] aCols, SortDirection[] aDirections, bool recurse)
        {
            if (aCols == null || aDirections == null)
                throw new Exception("les arguments aCols et aDirections ne peuvent être null !");
            if (aCols.Length != aDirections.Length)
                throw new Exception("les arguments aCols et aDirections doivent être de même longueur");
            if (aCols.Length == 0)
                throw new Exception("les arguments aCols et aDirections doivent avoir une longueur > 0");
            FUpdateCount++;
            try
            {
                //if (aCol > Constantes.NoColumn)
                {
                    FCachedText = new Hashtable();
                    try
                    {
                        FNodes.DoSort((Node)aNode, aCols, aDirections, new OnCompareNodeDelegate(this.DoCompare), recurse);
                        RecalculTopNode();
                        FBottomNode = null;
                        FLastVisibleNode = null;
                    }
                    finally
                    {
                        FCachedText = null;
                    }
                }
            }
            finally
            {
                if (FUpdateCount > 0)
                    FUpdateCount--;
                if (FUpdateCount == 0)
                    InvalidateTree();
            }
        }
        #endregion

        #region fonctions de Paint pour le user
        /// <summary>
        /// dessine une rectangle de plein (<see cref="Colors.SelectedColor" />, <see cref="Colors.SelectedUnfocusedColor"/>) />
        /// et eventuellement un rectangle en pointillé
        /// </summary>
        /// <param name="g"></param>
        /// <param name="aRect"></param>
        /// <param name="drawFocused"></param>
        public void DrawSelectedRectangle(Graphics g, Rectangle aRect, bool drawFocused, PaintInfo paintinfo)
        {
            GeniusLinearGradientBrush geniusBr;

            geniusBr = paintinfo.TreeFocused ? FColors.SelectedColor : FColors.SelectedUnfocusedColor;
            using (Brush br = geniusBr.GetBrush(aRect))
            {
                g.FillRectangle(br, aRect);
            }
            if (drawFocused)
                DrawFocusedRectangle(g, aRect, paintinfo);
        }

        /// <summary>
        /// dessine un rectangle au couleur de <see cref="GeniusTreeView.Colors.FocusedRectangleColor"/>
        /// </summary>
        /// <param name="g"></param>
        /// <param name="aRect"></param>
        public void DrawFocusedRectangle(Graphics g, Rectangle aRect, PaintInfo paintinfo)
        {
            Rectangle r = aRect;
            r.Width -= 1;
            r.Height -= 1;
            //Colors.FocusedRectangleColor.Width = 1.0f;
            g.DrawRectangle(paintinfo.TreeFocused ? Colors.FocusedRectangleColor : Colors.UnFocusedRectangleColor, r);
        }
        #endregion
        #region gestion de la recherche
        /// <summary>
        /// Recherche d'un noeud à partir de son texte, sur la colonne principale
        /// </summary>
        /// <param name="aText"></param>
        /// <returns></returns>
        public INode Search(string aText)
        {
            return Search(null, aText, FNodes.CurrentColIndex, SearchDirectionOption.Forward, true);
        }

        public INode Search(string aText, int aDisplayColumn)
        {
            return Search(null, aText, aDisplayColumn, SearchDirectionOption.Forward, true);
        }

        public INode Search(INode aStart, string aText, int aDisplayColumn, SearchDirectionOption aDirection, bool aVisibleOnly)
        {
            SearchHelper sh = new SearchHelper(this);
            sh.Direction = aDirection;

            return sh.Search((Node)aStart, aText, aVisibleOnly ? IncrementalSearchOption.VisibleOnly : IncrementalSearchOption.All, aDisplayColumn);
        }

        public INode Search(INode aStart, string aText)
        {
            return Search(aStart, aText, FNodes.CurrentColIndex, SearchDirectionOption.Forward, true);
        }

        public INode Search(INode aStart, string aText, int aDisplayColumn)
        {
            return Search(aStart, aText, aDisplayColumn, SearchDirectionOption.Forward, true);
        }
        #endregion
        #endregion

        #region propriétés publiques
        #region Timers
        /// <summary>
        /// obtient ou défini le temps pour l'affichage du Hint
        /// </summary>
        [Description("Fixe le temps en ms, pour l'affichage du Hint"),
        Category("Timers")]
        public int ElapsedHint
        {
            get
            {
                return FTimers[KindTimer.Hint];
            }
            set
            {
                FTimers[KindTimer.Hint] = value;
            }
        }

        #endregion

        /// <summary>
        /// Permet/interdit l'édition des noeuds
        /// </summary>
        [Description("Permet/interdit l'édition des noeuds")]
        [DefaultValue(true)]
        public bool AllowEdit
        {
            get
            {
                return FAllowEdit;
            }
            set
            {
                FAllowEdit = value;
            }
        }

        /* 
         //à faire plus tard
        [Description("Auto edit en mode grille")]
        [DefaultValue(false)]
        public bool AutoEditInGridMode
        {
            get	{
                return FAutoEdit; 
            }
            set	{
                FAutoEdit = value;
            }
        }
        */

        /// <summary>
        /// obtient ou défini la capacité à effectuer un drag avec les noeud présent dans le treeview
        /// </summary>
        [DefaultValue(false)]
        [Description("Permet/interdit le drag des noeuds de ce treeview ")]
        public bool AllowDrag
        {
            get
            {
                return FAllowDrag;
            }
            set
            {
                FAllowDrag = value;
            }
        }

        /// <summary>
        /// obtient ou définit le drop en automatic (true pas défaut)
        /// lorsque cette propriété est à false, il faut gérer le DragDrop via l'événement <see cref="DragDrop"/>
        /// </summary>
        [Category("Misc"), Description("Drop node is authomatic or manual (by DragDrop event"), Browsable(true)]
        [DefaultValue(true)]
        public bool AutomaticDropNode
        {
            get
            {
                return FAutomaticDropNode;
            }
            set
            {
                FAutomaticDropNode = value;
            }
        }
        
        //[Category("Misc"), Description("Drop node type used by dragdrop ( Move;copy )"), Browsable(true), DefaultValue(true)]
        //public bool MoveOnDrop
        //{
        //    get
        //    {
        //        return FMoveOnDrop;
        //    }
        //    set
        //    {
        //        FMoveOnDrop = value;
        //    }
        //}

        /// <summary>
        /// alilgnement des noeuds en mode arbre
        /// </summary>
        [Browsable(false)]
        public StringAlignment Alignment
        {
            get
            {
                return FAlignment;
            }
            set
            {
                FAlignment = value;
            }
        }

        /// <summary>
        /// renvoi le noeud selectionné
        /// </summary>
        [Browsable(false)]
        public INode SelectedNode
        {
            get
            {
                return Selected;
            }
        }

        /// <summary>
        /// la largeur du scroll horizontal
        /// </summary>
        [Browsable(false)]
        public int RangeX
        {
            get
            {
                return FScrolls.RangeX;
            }
        }

        /// <summary>
        /// le déplacement du scroll horizontal
        /// </summary>
        [Browsable(false)]
        public int OffsetX
        {
            get
            {
                return FScrolls.OffsetX;
            }
        }

        /// <summary>
        /// les options de dessin <see cref="DrawingOptions"/>
        /// </summary>
        [Description("Option de dessin, afficher/cacher les lignes de l'arbre, afficher/cacher les lignes de la grille, afficher/cacher les buttons, ...")]
        public DrawingOptions DefaultDrawingOption
        {
            get
            {
                return FDrawingOption;
            }
            set
            {
                FDrawingOption = value;
                InvalidateTree();
            }
        }

        /// <summary>
        /// la hauteur par défaut des noeuds
        /// </summary>
        [Description("Hauteur des noeud par défaut")]
        [DefaultValue(18)]
        public int DefaultNodeHeight
        {
            get
            {
                return FDefaultNodeHeight;
            }
            set
            {
                FDefaultNodeHeight = value;
            }
        }

        /// <summary>
        /// l'indentation horizontal entre les noeuds
        /// </summary>
        [Description("Indentation horizontal entre les noeuds")]
        [DefaultValue(16)]
        public int Indentation
        {
            get
            {
                return FIndentation;
            }
            set
            {
                FIndentation = value;
            }
        }

        /// <summary>
        /// nombre de noeuds à la racine
        /// </summary>
        [Browsable(false)]
        public int Count
        {
            get
            {
                return FRoot.ChildCount;
            }
        }

        /// <summary>
        /// renvoi le nombre total de noeud dans l'arbre
        /// </summary>
        [Browsable(false)]
        public int TotalCount
        {
            get
            {
                return FRoot.TotalCount;
            }
        }

        /// <summary>
        /// obtient ou défini la liste d'images pour décrire un noeud
        /// </summary>
        [Description("Liste d'images pour décrire noeud")]
        [DefaultValue(null)]
        public ImageList ImageList
        {
            get
            {
                return FImageList;
            }
            set
            {
                FImageList = value;
                InvalidateTree();
            }
        }

        /// <summary>
        /// obtient ou défini la liste d'images pour représenter l'état d'un noeud
        /// </summary>
        [Description("Liste d'images pour représenter l'état d'un noeud")]
        [DefaultValue(null)]
        public ImageList ImageStateList
        {
            get
            {
                return FImageStateList;
            }
            set
            {
                FImageStateList = value;
                InvalidateTree();
            }
        }

        /// <summary>
        /// liste des images + et - pour les noeuds
        /// </summary>
        [Description("Liste des images expand/collapse")]
        [DefaultValue(null)]
        public ImageList ImageTreeList
        {
            get
            {
                return FImageTreeList;
            }
            set
            {
                FImageTreeList = value;
                InvalidateTree();
            }
        }

        /// <summary>
        /// affiche ou cache le header
        /// </summary>
        [Description("Permet d'affiche ou de cacher le header")]
        [Browsable(true)]
        [DefaultValue(false)]
        public bool ShowHeader
        {
            get
            {
                return FShowHeader;
            }
            set
            {
                if (value != FShowHeader)
                {
                    FShowHeader = value;
                    FHeader.Redraw(false);
                }
            }
        }

        /// <summary>
        /// obtient ou défini la hauteur du header
        /// </summary>
        [Description("Hauteur du header")]
        [DefaultValue(20)]
        public int HeaderHeight
        {
            get
            {
                return FHeaderHeight;
            }
            set
            {
                if (value != HeaderHeight)
                {
                    FHeaderHeight = value;
                    FHeader.Redraw(false);
                }
            }
        }

        /// <summary>
        /// obtient ou défini l'utilisation du treeview en grille
        /// </summary>
        [Description("utiliser le treeview avec des colonnes (grille)")]
        [DefaultValue(false)]
        public bool UseColumns
        {
            get
            {
                return FUseColumns;
            }
            set
            {
                if (FUseColumns != value)
                {
                    FUseColumns = value;
                    if (value && FHeader.MainColumnIndex <= Constants.NoColumn)
                        FHeader.SetMainColumnIndex(0);
                    UpdateHorizontalScrollBar();
                    InvalidateTree();
                }
            }
        }

        /// <summary>
        /// le header
        /// </summary>
        [Description("propriétés du header")]
        [TypeConverter(typeof(System.ComponentModel.ComponentConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GeniusHeader Header
        {
            get
            {
                return FHeader;
            }
        }

        /// <summary>
        /// propriétés présente uniquement pour le designer, en runtime utilisez la propriété <see cref="Header.Colonnes"/>
        /// </summary>
        [Description("Définir les colonnes pour ce treeview")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GeniusTreeViewColumnCollection HeaderColonnes
        {
            get
            {
                return FHeader.Colonnes;
            }
        }

        /// <summary>
        /// les couleurs de l'arbre
        /// </summary>
        [
        Category("Style"),
        Description("Personalisation des couleurs du treeview")
        ]
        [TypeConverter(typeof(System.ComponentModel.ComponentConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GenuisTreeViewColors Colors
        {
            get
            {
                return FColors;
            }
        }

        /// <summary>
        /// les touches gauche et droite réagissent normalement
        /// en mode grille, alors qu'en mode "Arbre", elles deplie/replie le noeud 
        /// sélectionné
        /// </summary>
        [Description("Active / désactive le mode grille pour les touches de directions")]
        [Browsable(true)]
        public bool KeysGridMode
        {
            get
            {
                return FInGridMode;
            }
            set
            {
                FInGridMode = value;
            }
        }

        /// <summary>
        /// retourne l'index de la colonne selectionnée
        /// </summary>
        [Browsable(false)]
        public int SelectedColumn
        {
            get
            {
                return FNodes.CurrentColIndex;
            }
        }

        /// <summary>
        /// un <see cref="IEnumerable"/>, dont chaque
        /// élément doit être lui même un <see cref="IEnumerable"/> pour être énumerer
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable DataSource
        {
            get
            {
                return FDataSource;
            }
            set
            {
                if (FDataSource != value)
                {
                    FDataSource = value;
                    FillTree();
                }
            }
        }

        /// <summary>
        /// trie automatique, à chaque ajout de noeud
        /// </summary>
        [Description("Trie automatique après chaque ajout")]
        public bool AutoSort
        {
            get
            {
                return FAutoSort;
            }
            set
            {
                FAutoSort = value;
            }
        }

        /// <summary>
        /// selection de la ligne complète
        /// </summary>
        [Description("Active/désactive la selection de la ligne complète")]
        [DefaultValue(false)]
        public bool FullRowSelect
        {
            get
            {
                return FFullRowSelect;
            }
            set
            {
                if (FFullRowSelect != value)
                {
                    FFullRowSelect = value;
                    InvalidateTree();
                }
            }
        }

        /// <summary>
        /// marge gauche de l'arbre
        /// </summary>
        [Description("Marge gauche de l'arbre")]
        [DefaultValue(0)]
        public int LeftMargin
        {
            get
            {
                return FMargin;
            }
            set
            {
                if (value != FMargin)
                {
                    FMargin = value;
                    InvalidateTree();
                }
            }
        }

        /// <summary>
        /// renvoi un <see cref="INodeEnumerable"/>
        /// </summary>
        [Browsable(false)]
        public INodeEnumerable Enumerable
        {
            get
            {
                return FNodes;
            }
        }

        /// <summary>
        /// recherche incrémentale
        /// </summary>
        [Description("Active /desactive la recherche incrémentale")]
        [DefaultValue(IncrementalSearchOption.VisibleOnly)]
        [Category("IncrementalSearch")]
        public IncrementalSearchOption IncrementalSearch
        {
            get
            {
                return FIncrementalSearch;
            }
            set
            {
                FIncrementalSearch = value;
            }
        }

        /// <summary>
        /// fixe le démarrage de la recherche
        /// </summary>
        [Description("fixe le démarrage de la recherche")]
        [DefaultValue(SearchStartOption.FocusedNode)]
        [Category("IncrementalSearch")]
        public SearchStartOption SearchStart
        {
            get
            {
                return FSearchStart;
            }
            set
            {
                FSearchStart = value;
            }
        }

        /// <summary>
        /// obtient/défini le sens de la recherche
        /// </summary>
        [Description("Direction de la recherche")]
        [DefaultValue(SearchDirectionOption.Forward)]
        [Category("IncrementalSearch")]
        public SearchDirectionOption SearchDirection
        {
            get
            {
                return FSearchDirection;
            }
            set
            {
                FSearchDirection = value;
            }
        }


        /// <summary>
        /// index de la colonne sur laquelle s'effectue la recherche incrémental
        /// l'index est par rapport au colonnes dans le header, et non DisplayColumn
        /// </summary>
        [Description("Colonne sur laquelle la recherche s'effectue quand FullRowSelect vaut true.spécifier l'index de la colonne dans la liste des colonnes Header.Colonnes")]
        [Category("IncrementalSearch")]
        [DefaultValue(0)]
        public int SearchColumn
        {
            get
            {
                return FSearchColumn;
            }
            set
            {
                FSearchColumn = value;
            }
        }

        [Browsable(false)]
        public INodeEnumerable Nodes
        {
            get
            {
                return FRoot;
            }
        }

        /// <summary>
        /// <see cref="INode.Data"/> fournit le texte pour chaque colonne, en implémentant
        /// <see cref="IStringNodeProvider"/>
        /// </summary>
        [Description("La Data du noeud fournit le texte des colonnes, en implementant IStringNodeProvider")]
        [DefaultValue(false)]
        public bool DataIsStringProvider
        {
            get
            {
                return FDataIsStringProvider;
            }
            set
            {
                FDataIsStringProvider = value;
            }
        }

        /// <summary>
        /// Style du contour du controle
        /// </summary>
        [Description("style de la bordure du control")]
        [DefaultValue(BorderStyle.None)]
        public BorderStyle BorderStyle
        {
            get
            {
                return FBorderStyle;
            }
            set
            {
                if (FBorderStyle != value)
                {
                    FBorderStyle = value;
                    RecreateHandle();
                }
            }
        }

        /// <summary>
        /// utilise la touche tab pour passer de cellule en cellule, en mode grille uniquement
        /// ne fonctionne pas avec <see cref="FullRowSelect"/>
        /// </summary>
        [Description("utilise la touche tab pour passer de cellule en cellule (en mode grille)")]
        [DefaultValue(false)]
        public bool UseKeyTab
        {
            get
            {
                return FUseKeyTab;
            }
            set
            {
                FUseKeyTab = value;
            }
        }

        /// <summary>
        /// défini/obtient la hauteur du footer
        /// </summary>
        [Description("défini/obtient la hauteur du footer"),
        DefaultValue(0)]
        public int FooterHeight
        {
            get
            {
                return FFooterHeight;
            }
            set
            {
                if (FFooterHeight != value)
                {
                    if (value < 0)
                        value = 0;
                    if (IsHandleCreated && value > this.ClientRectangle.Height)
                        value = this.ClientRectangle.Height;
                    FFooterHeight = value;
                    FScrolls.MarginHeight = FFooterHeight;
                    InvalidateTree();
                }
            }
        }

        /// <summary>
        /// True : Les checkbox sont indépendantes les unes des autres (pere-fils)\r\n False: lorsque l'on clic sur un noeud père ses fils sont automatique cochés/décochés.
        /// </summary>
        [Description("True : Les checkbox sont indépendantes les unes des autres (pere-fils)\r\n False: lorsque l'on clic sur un noeud père ses fils sont automatique cochés/décochés.")]
        [DefaultValue(false)]
        public bool IndependantCheckboxes
        {
            get
            {
                return FNodes.ChecksAreIndependant;
            }
            set
            {
                if (value != FNodes.ChecksAreIndependant)
                {
                    FNodes.ChecksAreIndependant = value;
                    InvalidateTree();
                }
            }
        }

        [Description("True : c'est la méthode Graphics.DrawString est utilisée pour dessiner les textes, False : c'est la méthode TextRenderer.DrawText. DrawString est environ 8 fois plus performante, mais la qualité n'est pas toujours au rendez-vous.")]
        [DefaultValue(true)]
        public bool FastDrawString
        {
            get
            {
                return FFastDrawString;
            }
            set
            {
                if (FFastDrawString != value)
                {
                    FFastDrawString = value;
                }
            }
        }

        /// <summary>
        /// Permet d'autoriser/interdire la multiselection
        /// </summary>
        [Description("Permet d'autoriser/interdire la multiselection")]
        [DefaultValue(true)]
        public bool AllowMultiSelect
        {
            get
            {
                return _AllowMultiSelect;
            }
            set
            {
                if (_AllowMultiSelect != value)
                {
                    _AllowMultiSelect = value;
                    if (!_AllowMultiSelect && FNodes.SelectedNodes.Count > 1)
                    {
                        Node oldSelected = Selected;
                        FNodes.UnSelectAll();
                        SelectNode(oldSelected);
                        InvalidateTree();
                    }
                }
            }
        }
        #endregion

        #region propriétés interne
        /*
		internal int FixedRowsHeight
		{
			get	{
				int Result = 0;
				int nb = FixedRowsCount;
				if (nb > 0)
				{
					Node n = NextVisibleNode(FRoot);
					while (nb-- > 0 && n != null)
					{
						Result += n.Height;
						n = NextVisibleNode(n);
					}
				}
				return Result;
			}
		}
		*/
        internal int InternalSelectedColumn
        {
            get
            {
                return FNodes.CurrentColIndex;
            }
            set
            {
                FNodes.CurrentColIndex = value;
            }
        }

        internal new bool DesignMode
        {
            get
            {
                return base.DesignMode;
            }
        }
        #endregion

        #region évènement de FNodes et timers
        internal void Editor_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                CancelEdit();
            }
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                TryEndEdit();
            }
            if (e.KeyCode == Keys.Tab && FUseKeyTab && !FullRowSelect && UseColumns && !e.Alt && !e.Control)
            {
                TryEndEdit();
                OnKeyDown(e);
                e.Handled = true;
            }
        }

        private void FNodes_OnBeginCheck(Nodes Sender, CheckEventArgs e)
        {
            if (OnBeforeCheck != null)
                OnBeforeCheck(this, e);
        }

        private void FNodes_OnBeginCollapse(Nodes Sender, CollapseEventArgs e)
        {
            if (OnBeforeCollapse != null)
                OnBeforeCollapse(this, e);
        }

        private void FNodes_OnBeginExpand(Nodes Sender, ExpandEventArgs e)
        {
            if (OnBeforeExpand != null)
                OnBeforeExpand(this, e);
        }

        private void FNodes_OnBeginSelect(Nodes Sender, CanSelectEventArgs e)
        {
            if (OnBeforeSelect != null)
                OnBeforeSelect(this, e);
        }

        private void FNodes_OnBeginUnCheck(Nodes Sender, UnCheckEventArgs e)
        {
            if (OnBeforeUnCheck != null)
                OnBeforeUnCheck(this, e);
        }

        private void FNodes_OnBeginUnSelect(Nodes Sender, CanUnSelectEventArgs e)
        {
            if (OnBeforeUnSelect != null)
                OnBeforeUnSelect(this, e);
        }

        private void FNodes_OnInitNode(NodeEventArgs e)
        {
            e.Node.Height = DefaultNodeHeight;
            //le fait d'avoir des noeud en auto height affecte les performances
            if (FHeader.AutoColHeight && FHeader.AutoSizeColIndex >= 0)
            {
                int height;
                if (CalculateTextHeight((Node)e.Node, FHeader.Colonnes[FHeader.AutoSizeColIndex], FHeader.AutoSizeColIndex, out height))
                {
                    e.Node.Height = height;
                }
            }
            if (OnInitNode != null)
                OnInitNode(this, e);
        }

        private void FNodes_OnInvalidateNodeNeeded(NodeEventArgs e)
        {
            if (e.Node == null)
                this.InvalidateTree();
            else
                this.InvalidateNode((Node)e.Node);
        }

        private void EditTimer_Tick(object sender, EventArgs e)
        {
            BeginEdit();
        }

        private void ExpandTimer_Tick(object sender, EventArgs e)
        {
            if (FDropNode != null && FDropNode.ChildCount > 0)
            {
                if (!IsExpanded(FDropNode))
                    ExpandNode(FDropNode);
            }
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            Point pt = this.PointToClient(Cursor.Position);
            if (pt.Y < 0)
            {
                ScrollLineUp();
            }
            else if (pt.Y > TreeRectangle.Bottom)
            {
                ScrollLineDown();
            }
        }
        private void FTimers_OnEndSearch(object sender, EventArgs e)
        {
            FTimers.Stop(KindTimer.Search);
            FSearchHelper = null;
        }

        private void FTimers_OnBeginHint(object sender, EventArgs e)
        {
            HintHelper helper = (HintHelper)FTimers.GetTimerData(KindTimer.Hint);
            FTimers.Stop(KindTimer.Hint);
            ShowHint(helper.Text, helper.Node, helper.Column);
        }
        #endregion

        internal bool RecalcHeightAutoSizeColumn(GeniusTreeViewColonne aCol, int aColIndex)
        {
            bool beginUpdateCalled = false;
            try
            {
                Node n = NextVisibleNode(FRoot);
                while (n != null)
                {
                    int height;
                    if (CalculateTextHeight(n, aCol, aColIndex, out height))
                    {
                        if (!beginUpdateCalled)
                        {
                            beginUpdateCalled = true;
                            this.BeginUpdate();
                        }
                        int newHeight = Math.Max(DefaultNodeHeight, height);
                        ((INode)n).Height = newHeight;
                    }
                    n = NextVisibleNode(n);
                }
            }
            finally
            {
                if (beginUpdateCalled)
                    this.EndUpdate();

            }
            return beginUpdateCalled;
        }

        private bool CalculateTextHeight(Node n, GeniusTreeViewColonne aCol, int aColIndex, out int height)
        {
            string text = GetNodeText(n, aColIndex);
            if (!string.IsNullOrEmpty(text))
            {
                Font fnt = GetFontNode(n, aColIndex);

                StringFormat sf = GetStringFormat(n, aColIndex);
                TextFormatFlags tf = DrawingHelper.StringFormatToTextFormatFlags(sf);
                tf |= TextFormatFlags.WordBreak;
                Size sizeText = TextRenderer.MeasureText(text, fnt, new Size(aCol.Width, Int32.MaxValue), tf);
                height = sizeText.Height;
                return true;
            }
            height = 0;
            return false;
        }
    }
}
