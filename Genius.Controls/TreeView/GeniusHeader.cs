using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Genius.Controls.TreeView.Core;
using System.Collections.Generic;
using System.Globalization;

namespace Genius.Controls.TreeView
{

	[Flags]
	enum HeaderStateEnum 
	{
		TackPending = 0x01, 
		Tracking = 0x02,
		DragPending = 0x04,
		Dragging    = 0x08
	}

	/// <summary>
	/// classe représentant le header
	/// </summary>
	public class GeniusHeader : IDisposable
	{
		private GeniusTreeViewColumnCollection		FColonnes;
		private List<GeniusTreeViewColonne>		FDisplays;
		private int				FMainColumnIndex;
		private int				FClickIndex;
		internal GeniusTreeView	FTree;
		private Point			FDragStart;
		private Point			FDragDecal;
		private int				FTrackIndex;
		private int				FLeftTrackPos;
		private HeaderStateEnum FStates;
		private int				FDownIndex;
		private int				FHoverIndex;

		private int				FDragIndex;
		private int				FDropTarget;
		private bool			FDropBefore;
		private ImageList		FImageDropTarget;
		private Image			FDragImage;
		private DragForm		FDrag;

		private IDictionary		FSortColumns;
		private Font		FFont;
		private bool		FAllowDrag;
		private int			FFixedColumnCount;
		private int			FMainColumnDisplayIndex;
		private bool		FAllowSort;
		private ImageList	FImageList;
        //gestion de la colonne en autosize
		private bool		FAutoSizeCol;
		private int			FAutoSizeColIndex;
		private int			FLastColWidth;
		private int			FLastIndex;
		/// <summary>
		/// utilisée lors du recalcul de la colonne automatique
		/// </summary>
		private bool		InUpdateLayout;
		private ImageSortAlignment	FSortAlign;
		private Font				FFontSort;


		/// <summary>
		/// évènement paint sur le header
		/// </summary>
		[Browsable(false)]
		public event OnDrawHeaderColDelegate	OnBeforePaintHeader;

		/// <summary>
		/// évènement qui survient en fin de paint de chaque colonne du header
		/// </summary>
		[Browsable(false)]
		public event OnDrawHeaderColDelegate	OnAfterPaintHeader;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="aTv"></param>
		public GeniusHeader(GeniusTreeView aTv)
		{
			FColonnes = new GeniusTreeViewColumnCollection(this);
			FDisplays = FColonnes.FDisplays;
			FImageDropTarget = new ImageList();
			FMainColumnIndex = Constants.NoColumn;
			FClickIndex = Constants.NoColumn;
			FDownIndex = Constants.NoColumn;
			FDropTarget = Constants.NoColumn;
			FDragIndex = Constants.NoColumn;
			FHoverIndex = Constants.NoColumn;
			//l'ordre est important
			FSortColumns = new ListDictionary();
			FDropBefore = false;
			FAllowDrag = false;
			FAllowSort = true;
			FDragImage = null;
			FTree = aTv;
			FLastIndex = -1;
			FAutoSizeColIndex = -1;
			FDragDecal = new Point(0,0);
			FSortAlign = ImageSortAlignment.RightCenter;
			FFontSort = new Font("Courier New", 6, FontStyle.Bold);
			LoadDropTargetImage();
		}

        ~GeniusHeader()
        {
            Dispose(false);
        }

		#region méthodes privées
		private static void Exclude(ref HeaderStateEnum ens, HeaderStateEnum value)
		{
			ens &= (~value);
		}

        private static void Include(ref HeaderStateEnum ens, HeaderStateEnum value)
		{
			ens |= value;
		}

		private bool Contains(HeaderStateEnum ens, HeaderStateEnum value)
		{
			return FTree.Contains((int)ens, (int)value);
		}

		
		#region gestion des images pour le drag
		private void LoadDropTargetImage()
		{
			Assembly a;

			string[] checks = new string[]{"Genius.Controls.Resources.dragtargetleft.bmp",
											  "Genius.Controls.Resources.dragtargetright.bmp",
											  "Genius.Controls.Resources.sortasc.bmp",
											  "Genius.Controls.Resources.sortdesc.bmp"			
										  };
			
			//On récupère l'assembly en cours d'exécution
			a = Assembly.GetExecutingAssembly();
			foreach(string check in checks)
			{
				Stream stm = a.GetManifestResourceStream(check);
				FImageDropTarget.Images.Add(new Bitmap(stm), Color.Fuchsia);
			}
		}
		
		private void DrawDropTarget(Graphics g, Point pt)
		{
			FImageDropTarget.Draw(g, pt, FDropBefore ? 0 : 1);
		}
		#endregion
		private bool DetermineSplitterIndex(Point p)
		{
			FTrackIndex = Constants.NoColumn;
			if (this.Count > 0)
			{
				int splitPoint;

				if (p.X <= FixedColumnWidth && FixedColumnCount > 0)
				{
					int nbFixed = 0;
					splitPoint = 0;
					for (int i = 0; i < FDisplays.Count && nbFixed < FixedColumnCount; i++)
					{
						GeniusTreeViewColonne col = DisplayColonnes(i);
						if (col.Visible)
						{
							splitPoint += col.Width;
							nbFixed++;
						}
						if (col.Visible && col.AllowSize)
						{
							if (p.X < splitPoint+5 && p.X > splitPoint - 3)
							{
								FTrackIndex = i;
								FLeftTrackPos = splitPoint - col.Width;
								return true;
							}
						}				
					}
				}
				else
				{
                    //calcul du point de retaillage d'une colonne
					splitPoint = -FTree.OffsetX + FTree.RangeX;
					for (int i = FDisplays.Count-1; i >=0; i--)
					{
						GeniusTreeViewColonne col = DisplayColonnes(i);
                        if (col.Visible && col.AllowSize && i != FAutoSizeColIndex)
						{
							if (p.X < splitPoint+5 && p.X > splitPoint - 3)
							{
								FTrackIndex = i;
								FLeftTrackPos = splitPoint - col.Width;
								return true;
							}
						}
						if (col.Visible)
							splitPoint -= col.Width;
					}
				}
			}
			return false;
		}

		private void InitFromLastCol()
		{
			FLastColWidth = -1;
			FLastIndex = -1;
			if (FAutoSizeCol)
			{
				GeniusTreeViewColonne col = VisibleColumn(FAutoSizeColIndex);
				if (col != null)
				{
					FLastIndex = IndexOf(col);
					FLastColWidth = col.Width;
				}
				else
					FLastIndex = -1;
			}
		}

		private void RestoreLastColWidth()
		{
			if (FLastIndex > -1)
				this.Colonnes[FLastIndex].Width = FLastColWidth;
		}

		internal void RecalcLastColWidth()
		{
			if (FAutoSizeCol)
			{
				if (FLastIndex == -1)
					InitFromLastCol();
				GeniusTreeViewColonne col = VisibleColumn(FAutoSizeColIndex);
				if (col != null)
				{
					int w = this.Width - col.Width;
					
					int diffW = (this.FTree.ClientRectangle.Width-1) - w ;
					if (diffW > 0)
						col.Width = diffW > FLastColWidth ? diffW : FLastColWidth;
					else
						col.Width = FLastColWidth;
				}
			}
		}

		private GeniusTreeViewColonne VisibleColumn(int aDisplayCol)
		{
			ArrayList visibles = VisibleColumns;
			if (aDisplayCol >= 0 && aDisplayCol < visibles.Count)
			{
				return ((GeniusTreeViewColonne)visibles[aDisplayCol]);
			}
			return null;
		}

		private void SetAutoSizeCol(int aDisplayCol)
		{
			if (aDisplayCol < 0)
				RestoreLastColWidth();

			FAutoSizeColIndex = aDisplayCol;
			FAutoSizeCol = aDisplayCol >= 0;
			InitFromLastCol();
			if (FAutoSizeCol)
				RecalcLastColWidth();
			
		}

		private int AdjustDownColumn(Point p)
		{
			int Result = Constants.NoColumn;

			p.Y += FTree.HeaderHeight;
			Result = ColumnIndexAt(p.X + FTree.OffsetX);
			//Debug.WriteLine(String.Format("AdjustDownColumn -> FDownIndex ={0}, Result={1}", FDownIndex, Result));
			if (Result > Constants.NoColumn && Result != FDownIndex)
			{
				if (FDownIndex > Constants.NoColumn)
					Invalidate(this.DisplayColonnes(FDownIndex));
				if (Result > Constants.NoColumn && !this.DisplayColonnes(Result).AllowClick)
				{
					FDownIndex = Constants.NoColumn;
					return Result;
				}
				FDownIndex = Result;
				Invalidate(this.DisplayColonnes(FDownIndex));
			}
			return Result;
		}

		private bool AdjustDropTargetColumn(Point p)
		{
			int newIndex;
			bool newDropBefore = FDropBefore;

			p.Y += FTree.HeaderHeight;
			newIndex = this.ColumnIndexAt(p.X + FTree.OffsetX);
			if (newIndex > Constants.NoColumn)
			{
				Rectangle rCol = this.ColumnRect(newIndex);
				newDropBefore = p.X <= (rCol.Right + rCol.Left) / 2;
			}
			
			if (newIndex != FDropTarget || FDropBefore != newDropBefore)
			{
				if (newIndex != FDropTarget && FDropTarget > Constants.NoColumn)
					Invalidate(DisplayColonnes(FDropTarget));
				FDropTarget = newIndex;
				FDropBefore = newDropBefore;
				if (FDropTarget > Constants.NoColumn)
					Invalidate(DisplayColonnes(FDropTarget));
				return true;
			}
			return false;
		}

		private bool GetNewIndex(Point p, ref int OldIndex)
		{
			int newIndex;

			p.Y += FTree.HeaderHeight;
			if (FixedColumnCount > 0 && p.X <= FixedColumnWidth)
			{
				newIndex = this.ColumnIndexAt(p.X);				
			}
			else
				newIndex = this.ColumnIndexAt(p.X + FTree.OffsetX);

			if (newIndex != OldIndex)
			{
				if (OldIndex > Constants.NoColumn)
					Invalidate(DisplayColonnes(OldIndex));
				OldIndex = newIndex;
				if (OldIndex > Constants.NoColumn)
					Invalidate(DisplayColonnes(OldIndex));
				return true;
			}
			return false;
		}

		private bool AdjustHoverColumn(Point p)
		{
			return GetNewIndex(p, ref FHoverIndex);
		}

		private Rectangle ColumnRect(int aColIndex)
		{
			Rectangle Result = new Rectangle(Left(aColIndex), 0, DisplayColonnes(aColIndex).Width, FTree.HeaderHeight);
			return Result;
		}

		private void PrepareDrag(Point aStart)
		{
			FDropTarget = Constants.NoColumn;
			aStart = FTree.PointToClient(aStart);
			aStart.Y += FTree.HeaderHeight;
			FDragIndex = ColumnIndexAt(aStart.X + FTree.OffsetX);
			
			Rectangle rCol = ColumnRect(FDragIndex);
			FDragDecal.X = rCol.X - aStart.X;
			FDragDecal.Y = rCol.Y - aStart.Y;
			rCol.X = 0;
			if (FDrag != null)
			{
				FDrag.Dispose();
				FDrag = null;
			}
			FDragImage = new Bitmap(rCol.Width, rCol.Height);
			using (Graphics g = Graphics.FromImage(FDragImage))
			{
				InternalDrawHeaderCol(g, DisplayColonnes(FDragIndex), rCol);
			}
			FDrag = new DragForm(FDragImage, FTree);
			DragTo(Cursor.Position);
		}

		private void DragTo(Point p)
		{
			//Debug.WriteLine("droptarget :" + FDropTarget.ToString());
			FDrag.Forbiden =  FDropTarget == Constants.NoColumn;
			if (!FDrag.Visible)
				FDrag.Show(p.X + FDragDecal.X, p.Y + FDragDecal.Y);
			else
				FDrag.Position(p.X + FDragDecal.X, p.Y + FDragDecal.Y);
		}

		private void EndDrag()
		{
			DisposeImage(ref FDragImage);
			if (FDrag != null)
			{
				FDrag.Dispose();
				FDrag = null;
			}
		}

		private static void DisposeImage(ref Image aImg)
		{
			if (aImg != null)
			{
				aImg.Dispose();
				aImg = null;
			}
		}
		
		private void RecalcMainDisplayIndex()
		{
			if (FMainColumnIndex>= 0 && FMainColumnIndex < Count)
				FMainColumnDisplayIndex = FDisplays.IndexOf(this.FColonnes[FMainColumnIndex]);
			else
				FMainColumnDisplayIndex = -1;
		}
		#region gestion du tri des colonnes
		private void AddOrModifiySortColumn(int aCol, SortDirection aDir)
		{
			FSortColumns[aCol] = aDir;
		}

		private SortDirection IsSort(int aDisplayCol)
		{
			if (FSortColumns.Contains(aDisplayCol))
				return (SortDirection)FSortColumns[aDisplayCol];

			return SortDirection.None;
		}

		/// <summary>
		/// renvoi le numéro d'ordre dans le tri dans le cas du tri multi-colonnes 
		/// </summary>
		/// <param name="aCol"></param>
		/// <returns></returns>
		private int SortOrder(int aCol)
		{
			int Result = 0;
			foreach (int col in FSortColumns.Keys)
			{
				if (aCol == col)
				{
					return Result;
				}
				Result++;
			}
			return -1;
		}

		#endregion
		private static bool CtrlIsDown()
		{
			Int16 state = NativeMethods.GetKeyState(VirtualKeys.VK_CONTROL);
			return (state & 0x80) > 0;
		}
		#endregion

		#region méthodes interne
		internal bool HandleMessage(Message m)
		{
			Point p;
			switch ((Msgs)m.Msg)
			{
				case Msgs.WM_NCLBUTTONDOWN :
					if (!FTree.Focused)
						FTree.Focus();
					FTree.GetTimers.Stop(KindTimer.Edit);
					FDragStart = Cursor.Position;
					p = FTree.PointToClient(FDragStart);
					if (p.Y < 0)
					{
						if (DetermineSplitterIndex(p))
						{
							FTree.Cursor = System.Windows.Forms.Cursors.VSplit;
							//FTrackStart = p;
							Include(ref FStates, HeaderStateEnum.TackPending);
							FTree.Capture = true;
						}
						else
						{
							int HitIndex = AdjustDownColumn(p);
							if (HitIndex > Constants.NoColumn)
							{
								if (AllowDrag && this.DisplayColonnes(HitIndex).AllowDrag)
								{
									Include(ref FStates, HeaderStateEnum.DragPending);
									FTree.Capture = true;
								}
								else if (!AllowSort)
									FDownIndex = Constants.NoColumn;
							}
							//Debug.WriteLine(HitIndex);
							//Debug.WriteLine(FDownIndex);
						}
					}
					break;
				case Msgs.WM_LBUTTONUP :
				case Msgs.WM_NCLBUTTONUP :
					if (FStates != 0)
					{
						FTree.GetTimers.Stop(KindTimer.Edit);
						if (Contains(FStates, HeaderStateEnum.Dragging))
						{
							EndDrag();
							FTree.Capture = false;
							if (FDropTarget > Constants.NoColumn && FDropTarget != FDragIndex)
							{
								if (FTree.SelectedColumn == FDragIndex)
									FTree.InternalSelectedColumn = FDropTarget;
								else if (FTree.SelectedColumn != Constants.NoColumn)
								{
									if (FTree.SelectedColumn >= FDropTarget && FTree.SelectedColumn < FDragIndex)
										FTree.InternalSelectedColumn++;
									else if (FTree.SelectedColumn > FDragIndex && FTree.SelectedColumn <= FDropTarget )
										FTree.InternalSelectedColumn--;
								}
								if (FDropTarget > FDragIndex)
									FDropTarget--;
								if (FDropBefore)
									MoveColumnTo(FDragIndex, FDropTarget);
								else
									MoveColumnTo(FDragIndex, FDropTarget+1);

								FTree.InvalidateTree();
							}
							FDropTarget = Constants.NoColumn;
							Invalidate();
							//AdjustDropTargetColumn(new Point(-1,-1));
						}
						FStates = 0;
					}
					if (FDownIndex > Constants.NoColumn && AllowSort)
					{
						int acol = this.DisplayIndexToIndex(FDownIndex);
						FDownIndex = Constants.NoColumn;
						Invalidate(this.DisplayColonnes(acol));
						SortDirection aDir = IsSort(acol);
						if (aDir != SortDirection.None)
						{
							if (aDir == SortDirection.Ascending)
								aDir = SortDirection.Descending;
							else
								aDir = SortDirection.Ascending;
						}
						else
						{
							aDir = SortDirection.Ascending;
						}
						if (!CtrlIsDown())
							FSortColumns.Clear();
						AddOrModifiySortColumn(acol, aDir);
						FTree.SortTree(SortColumns, SortingDirections);
					}
					break;
				case Msgs.WM_MOUSELEAVE :
					break;
				case Msgs.WM_NCMOUSEMOVE :
					p = FTree.PointToClient(Cursor.Position);
					if (p.Y < 0)
					{
						if (DetermineSplitterIndex(p))
						{
							FTree.Cursor = System.Windows.Forms.Cursors.VSplit;
							m.Result = new IntPtr(1);
							return true;
						}
						AdjustHoverColumn(p);
					}
					break;
				case Msgs.WM_MOUSEMOVE :
					if (FStates != 0)
					{
						if (Contains(FStates, HeaderStateEnum.TackPending))
						{
							Exclude(ref FStates, HeaderStateEnum.TackPending);
							Include(ref FStates, HeaderStateEnum.Tracking);
							m.Result = new IntPtr(0);
							return true;
						}
						else if (Contains(FStates, HeaderStateEnum.Tracking))
						{
							FTree.Cursor = System.Windows.Forms.Cursors.VSplit;
							p = FTree.PointToClient(Cursor.Position);
							//Debug.WriteLine("Tracking : " + FTrackIndex.ToString() + " :" + (p.X - FLeftTrackPos).ToString());
							DisplayColonnes(FTrackIndex).Width = p.X - FLeftTrackPos; 
							FTree.UpdateHorizontalScrollBar();
							FTree.InvalidateTree();
							m.Result = new IntPtr(0);
							return true;
						}
						else if (Contains(FStates, HeaderStateEnum.DragPending))
						{
							p = Cursor.Position;
							if (Math.Abs(FDragStart.X - p.X) > 4 ||
								Math.Abs(FDragStart.Y - p.Y) > 4)
							{
								int aDownIndex = FDownIndex;
								FHoverIndex = Constants.NoColumn;
								FDownIndex = Constants.NoColumn;
								if (aDownIndex > Constants.NoColumn)
									Invalidate(this.DisplayColonnes(aDownIndex));
									//Invalidate(this.FColonnes[aDownIndex]);
								PrepareDrag(FDragStart);
								Exclude(ref FStates, HeaderStateEnum.DragPending);
								Include(ref FStates, HeaderStateEnum.Dragging);
								m.Result = new IntPtr(1);
								return true;
							}
						}
						else if (Contains(FStates, HeaderStateEnum.Dragging))
						{
							p = FTree.PointToClient(Cursor.Position);
							//Debug.WriteLine("dragging : " + p.ToString());
							DragTo(Cursor.Position);
							AdjustDropTargetColumn(p);
							m.Result = IntPtr.Zero;
							return true;
						}
					}
					else
					{
						AdjustHoverColumn(new Point(-9999,-1));
					}
					break;
			}
			return false;
		} 

		internal bool ColSizeChanged(GeniusTreeViewColonne column)
		{
            bool result = false;
            if (!InUpdateLayout)
            {
                if (this.FAutoSizeCol && FAutoColHeight)
                {
                    //recalcul la hauteur
                    result = FTree.RecalcHeightAutoSizeColumn(FDisplays[FAutoSizeColIndex], FAutoSizeColIndex);
                }
                UpdateLayoutForLastCol();
                result = true;
            }
            return result;
		}
		#endregion

		/// <summary>
		/// ajout d'une colonne dans le header
		/// </summary>
		/// <returns></returns>
		public GeniusTreeViewColonne Add()
		{
			GeniusTreeViewColonne n = new GeniusTreeViewColonne(this);
			AddInstance(n);
			return n;
		}

		private void AddInstance(GeniusTreeViewColonne aCol)
		{
            this.FColonnes.Add(aCol);
		}

		/// <summary>
		/// retourne la largeur total de toutes les colonnes
		/// précédentes ansi que aDisplayIndex
		/// </summary>
		/// <param name="displayIndex"></param>
		/// <returns>la largeur totale des colonnes includant aDisplayIndex</returns>
		public int GetWidthFromStart(int displayIndex)
		{
			int Result = 0;
			if (displayIndex >= Count || displayIndex < 0)
				return 0;
			for(int i=0; i <= displayIndex; i++)
			{
				if (!DisplayColonnes(i).Visible)
					continue;
				Result += DisplayColonnes(i).Width;
			}
			return Result;			
		}

		/// <summary>
		/// renvoi la position gauche d'une colonne, en fonction de la position du scroll horizontal
		/// </summary>
		/// <param name="displayIndex"></param>
		/// <returns></returns>
		public int Left(int displayIndex)
		{
			int Result = GetWidthFromStart(displayIndex-1);
			Result -= (displayIndex >= FixedColumnCount) ? FTree.OffsetX : 0;
			return Result;
		}
		
		/// <summary>
		/// renvoi la position gauche d'une colonne
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public int Left(GeniusTreeViewColonne column)
		{
			return Left(FDisplays.IndexOf(column));
		}

		/// <summary>
		/// renvoi l'index d'une colonne
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public int IndexOf(GeniusTreeViewColonne column)
		{
			return this.FColonnes.IndexOf(column);
		}

		/// <summary>
		/// renvoi l'index visuel d'une colonne
		/// </summary>
		/// <param name="aCol"></param>
		/// <returns></returns>
        public int IndexOfDisplay(GeniusTreeViewColonne column)
		{
            return FDisplays.IndexOf(column);
		}

		/// <summary>
		/// quelle colonne sous x
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public GeniusTreeViewColonne ColumnAt(int x)
		{
			int startx = 0;
			int width;

			foreach (GeniusTreeViewColonne col in this.FDisplays)
			{
				if (!col.Visible)
					continue;
				width = col.Width;
				if (x >= startx && x <= startx+ width)
					return col;
				startx += width;
			}
			return null;
		}

		/// <summary>
		/// quelle index de colonne sous x
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		public int ColumnIndexAt(int x)
		{
			int startx = 0;
			int width;

			//x += FTree.OffsetX;

			for (int i=0; i < Count; i++)
			{
				if (!DisplayColonnes(i).Visible)
					continue;
				width = DisplayColonnes(i).Width;
				if (x >= startx && x <= startx+ width)
					return i;
				startx += width;
			}
			return Constants.NoColumn;
		}

		/// <summary>
		/// renvoi la indexième colonne du tableau des DisplayColonnes
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public GeniusTreeViewColonne DisplayColonnes(int index)
		{
			return (GeniusTreeViewColonne)FDisplays[index];
		}

		/// <summary>
		/// retourne index d'une colonne par rapport à son index du tableau des 
		/// DisplayColonnes
		/// </summary>
		/// <param name="displayIndex"></param>
		/// <returns></returns>
		public int DisplayIndexToIndex(int displayIndex)
		{
			return IndexOf(DisplayColonnes(displayIndex));
		}

		/// <summary>
		/// retourne les index des colonnes par rapport à leurs index du tableau des 
		/// DisplayColonnes
		/// </summary>
		/// <param name="displayIndex"></param>
		/// <returns></returns>
		public int[] DisplayIndexToIndex(int[] displayIndex)
		{
			int[] Result = new int[displayIndex.Length];
			for(int i = 0; i < Result.Length; i++)
				Result[i] = IndexOf(DisplayColonnes(displayIndex[i]));
			return Result;
		}

		/// <summary>
		/// l'ensemble des colonnes visible, dans l'ordre des colonnes affichées
		/// </summary>
		[Browsable(false)]
		public ArrayList VisibleColumns
		{
			get
			{
				ArrayList Result = new ArrayList();
				foreach (GeniusTreeViewColonne col in FDisplays)
				{
					if (col.Visible)
						Result.Add(col);
				}
				return Result;
			}
		}

		/// <summary>
		/// liste des colonne affichés, identique aux colonnes à l'ordre près
		/// </summary>
		[Browsable(false)]
		public List<GeniusTreeViewColonne> Displays
		{
			get
			{
				return FDisplays;
			}
		}

		/// <summary>
		/// index de la colonne triée
		/// </summary>
		[Browsable(false)]
		public int[] SortColumns
		{
			get
			{
				int[] Result = new int[FSortColumns.Keys.Count];
				FSortColumns.Keys.CopyTo(Result, 0);
				return Result;
			}
		}
			
		/// <summary>
		/// sens du tri pour le tri principal
		/// </summary>
		[Browsable(false)]
		public SortDirection[] SortingDirections
		{
			get
			{
				SortDirection[] Result = new SortDirection[FSortColumns.Values.Count];
				FSortColumns.Values.CopyTo(Result, 0);
				return Result;
			}
		}

		/// <summary>
		/// Fonte pour le header
		/// </summary>
		[DefaultValue(null)]
		public Font Font
		{
			get
			{
				if (FFont == null)
					return FTree.Font;
				return FFont;
			}
			set
			{
				if (FFont != value)
				{
					FFont = value;
					Invalidate();
				}
			}
		}

		/// <summary>
		/// positionnement de l'image du tri dans
		/// </summary>
		[DefaultValue(ImageSortAlignment.RightCenter)]
		public ImageSortAlignment SortImageAlignment
		{
			get
			{
				return FSortAlign;
			}
			set
			{
				if (FSortAlign != value)
				{
					FSortAlign = value;
					Invalidate();
				}
			}
		}

		/// <summary>
		/// ajoute un tableau de colonne
		/// </summary>
		/// <param name="range"></param>
		public void AddRange(GeniusTreeViewColonne[] range)
		{
			foreach(GeniusTreeViewColonne col in range)
			{
				AddInstance(col);
			}
			RecalcMainDisplayIndex();
			InitFromLastCol();
		}

		#region méthodes publiques
		internal void SetMainColumnIndex(int amain)
		{
			FMainColumnIndex = amain;
			RecalcMainDisplayIndex();
		}

		internal void SetSortColumn(int[] aCol, SortDirection[] aDirection)
		{
			FSortColumns.Clear();
			for(int i =0; i < aCol.Length; i++)
			{
				FSortColumns[aCol[i]] = aDirection[i];
			}
		}

		[Browsable(false)]
		public int MainColumnIndex
		{
			get
			{
				return FMainColumnIndex;
			}
			set
			{
				SetMainColumnIndex(value);
			}
		}

		[Browsable(false)]
		public int MainColumnDisplayIndex
		{
			get
			{
				return FMainColumnDisplayIndex;
			}
		}

		[Browsable(false)]
		public int Width
		{
			get
			{
				int Result = 0;
				foreach(GeniusTreeViewColonne col in this.FColonnes)
				{
					if (col.Visible)
						Result += col.Width;
				}
				return Result;
			}
		}

		internal void SetClickIndex(int aclick)
		{
			FClickIndex = aclick;
		}

		[Browsable(false)]
        [Description("indique quelle est la colonne concernée par le dernier clic de la souris")]
		public int ClickIndex
		{
			get
			{
				return FClickIndex;
			}
		}

		[DefaultValue(false)]
		[Description("Permettre le drag and drop des colonnes")]
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

		[DefaultValue(true)]
		[Description("Permettre le tri des colonnes")]
		public bool AllowSort
		{
			get
			{
				return FAllowSort;
			}
			set
			{
				FAllowSort = value;
			}
		}

		/// <summary>
		/// retourne la largeur total des colonnes fixes
		/// </summary>
		[Browsable(false)]
		[Description("retourne la largeur total des colonnes fixes")]
		public int FixedColumnWidth
		{
			get
			{
				if (FixedColumnCount > 0)
					return GetWidthFromStart(FixedColumnCount-1);
				return 0;
			}
		}

		/// <summary>
		/// force le changement de la largeur de la n'ième colonne
		/// pour que celle-ci "complète" la zone restante du treeview
		/// la taille minimale de cette colonne est sa taille spécifié par 
		/// la propriété Width
		/// </summary>
		[DefaultValue(-1)]
		[Description("la n'ième colonne est à taille variable en largeur")]
		public int AutoSizeColIndex
		{
			get
			{
				return FAutoSizeColIndex;
			}
			set
			{
				if (value != FAutoSizeColIndex)
				{
					SetAutoSizeCol(value);
				}
			}
		}


        private bool FAutoColHeight = true;
        /// <summary>
        /// la colonne en autosize, est-elle aussi en autoheight (hauteur du noeud 'variable')
        /// </summary>
        [DefaultValue(false)]
        [Description("permet d'indiquer si la colonne spécifiée par 'AutoSizeColIndex' est à taille variable en hauteur")]
        public bool AutoColHeight
        {
            get { return FAutoColHeight; }
            set
            {
                if (value != FAutoColHeight)
                {
                    FAutoColHeight = value;
                }
            }
        }

		public void SwapColonnes(int index1, int index2)
		{
			bool lastColIsConcerned = index1 == FAutoSizeColIndex || index2 == FAutoSizeColIndex;
			GeniusTreeViewColonne aCol = FDisplays[index1];
			FDisplays[index1] = FDisplays[index2];
			FDisplays[index2] = aCol;
			if (lastColIsConcerned)
				UpdateLayoutForLastCol();
			RecalcMainDisplayIndex();
		}

		/// <summary>
		/// deplace une colonne, vers une position
		/// </summary>
		/// <param name="displayStart">index de la colonne à déplacer, index visuel</param>
		/// <param name="displayTo">index </param>
		public void MoveColumnTo(int displayStart, int displayTo)
		{

			if (displayTo < 0 || displayTo >= FDisplays.Count || displayStart < 0 || displayStart > FDisplays.Count)
				throw new Exception(String.Format("Impossible de déplacer la colonne {0}, index d'arrivé \"{1}\" invalide", displayStart, displayTo));

			bool lastColIsConcerned = displayStart == FAutoSizeColIndex || displayTo <= FAutoSizeColIndex ||
				(displayStart < FAutoSizeColIndex && displayTo >= FAutoSizeColIndex) ||
				(displayStart > FAutoSizeColIndex && displayTo <= FAutoSizeColIndex);
			GeniusTreeViewColonne o = FDisplays[displayStart];
			FDisplays.RemoveAt(displayStart);
			if (displayTo < displayStart)
				FDisplays.Insert(displayTo, o);
			else
			{
				if (displayStart >= FDisplays.Count)
					FDisplays.Add(o);
				else
					FDisplays.Insert(displayTo, o);
			}
			if (lastColIsConcerned)
				UpdateLayoutForLastCol();
			RecalcMainDisplayIndex();
		}
		#endregion

		#region IDisposable Members

		/// <summary>
		/// Dispose
		/// </summary>
		public void Dispose()
		{
            Dispose(true);
            GC.SuppressFinalize(this);
		}


        protected virtual void Dispose(bool disposing)
        {
            FColonnes.Clear();
            if (FFontSort != null)
            {
                FFontSort.Dispose();
                FFontSort = null;
            }
            if (this.FImageDropTarget != null)
            {
                this.FImageDropTarget.Dispose();
                this.FImageDropTarget = null;
            }
            DisposeImage(ref FDragImage);
        }

		#endregion

		#region Paint
		#region dessin du header

		private void InternalDrawHeaderCol(Graphics graphics, GeniusTreeViewColonne column, Rectangle columnRect)
		{
			DrawHeaderColEventArgs args = new DrawHeaderColEventArgs(graphics, column, columnRect);
			if (DoBeforePaintHeader(args))
			{
				int iCol = IndexOf(column);
				bool hasImage = column.ImageIndex > -1 && this.ImageList != null;
				GeniusLinearGradientBrush colColor = (!column.HeadColor.IsEmpty) ? column.HeadColor : FTree.Colors.HeaderColor;
				using (Brush br = colColor.GetBrush(columnRect))
				{
					graphics.FillRectangle(br, columnRect);
					graphics.DrawLine(Pens.LightGray, columnRect.Right-2, columnRect.Top+4, columnRect.Right-2, columnRect.Bottom-4);
					graphics.DrawLine(Pens.WhiteSmoke, columnRect.Right-1, columnRect.Top+4, columnRect.Right-1, columnRect.Bottom-4);
				}
				//je retire un pixel pour le dessin de la ligne de séparation
				columnRect.Width -= 1;
                //StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
                //sf.Trimming = StringTrimming.EllipsisCharacter;
                //sf.Alignment = column.Alignment;
                //sf.LineAlignment = column.VAlignment;
				if (column.ForeColor.IsEmpty)
					column.ForeColor = new GeniusLinearGradientBrush(Color.Black);
				Rectangle OldrCol = columnRect;
				Rectangle rTextCol = columnRect;
				if (hasImage)
				{
					//dessin de l'image
					//faire un test quand les images sont de taille <> en X et en Y
					Point ImgPosition = new Point(columnRect.Left, columnRect.Top);

					switch(column.ImageAlignment)
					{
						case ImageAlignment.Left :
							ImgPosition.Y += columnRect.Height / 2 - this.ImageList.ImageSize.Height / 2;
							columnRect.Width -= this.ImageList.ImageSize.Width;
							break;
						case ImageAlignment.Top :
							ImgPosition.X += columnRect.Width / 2 - this.ImageList.ImageSize.Width / 2;
							columnRect.Height -= this.ImageList.ImageSize.Height;
							break;
						case ImageAlignment.Right :
							ImgPosition.Y += columnRect.Height / 2 - this.ImageList.ImageSize.Height / 2;
							ImgPosition.X = columnRect.Right - this.ImageList.ImageSize.Width; 
							columnRect.Width -= this.ImageList.ImageSize.Width;
							break;
						case ImageAlignment.Bottom :
							ImgPosition.X += columnRect.Width / 2 - this.ImageList.ImageSize.Width / 2;
							ImgPosition.Y = columnRect.Bottom - this.ImageList.ImageSize.Height;
							columnRect.Height -= this.ImageList.ImageSize.Height;
							break;
					}
					graphics.DrawImage(this.ImageList.Images[column.ImageIndex], ImgPosition);
					//this.ImageList.Draw(g, ImgPosition, aCol.ImageIndex);
				}
                Color foreColor = column.ForeColor;
				{
					GraphicsState state = null;
					if (column.TextOrientation != 0)
					{
						state = graphics.Save();
                        using (Matrix m = new Matrix())
                        {
                            switch (Convert.ToInt32(column.TextOrientation))
                            {
                                case 90:
                                    rTextCol.Width = columnRect.Height;
                                    m.RotateAt(90, new PointF(columnRect.Left, columnRect.Top));
                                    rTextCol.Height = columnRect.Width;
                                    m.Translate(0, -columnRect.Width);
                                    if (hasImage && column.ImageAlignment == ImageAlignment.Left)
                                        m.Translate(0, -this.ImageList.ImageSize.Width);
                                    else if (hasImage && column.ImageAlignment == ImageAlignment.Top)
                                        m.Translate(this.ImageList.ImageSize.Height, 0);
                                    break;
                                case 180:
                                    m.RotateAt(180, new PointF(columnRect.Left, columnRect.Top));
                                    m.Translate(-columnRect.Width, -columnRect.Height);
                                    rTextCol.Width = columnRect.Width;
                                    break;
                                case -90:
                                case 270:
                                    m.RotateAt(270, new PointF(columnRect.Left, columnRect.Top));
                                    m.Translate(-columnRect.Height, 0);
                                    rTextCol.Width = columnRect.Height;
                                    rTextCol.Height = columnRect.Width;
                                    if (hasImage && column.ImageAlignment == ImageAlignment.Left)
                                        m.Translate(0/*-this.ImageList.ImageSize.Width*/, this.ImageList.ImageSize.Width);
                                    else if (hasImage && column.ImageAlignment == ImageAlignment.Top)
                                        m.Translate(-this.ImageList.ImageSize.Height, 0);
                                    break;
                                default:
                                    m.RotateAt(Convert.ToInt32(column.TextOrientation), new PointF((columnRect.Right + columnRect.Left) / 2, (columnRect.Top + columnRect.Bottom) / 2), MatrixOrder.Append);
                                    break;
                            }
                            graphics.Transform = m;
                        }
					}
					else
					{
						rTextCol = columnRect;
						if (hasImage)
						{
							switch(column.ImageAlignment)
							{
								case ImageAlignment.Left :
									rTextCol.Offset(this.ImageList.ImageSize.Width, 0);
									break;
								case ImageAlignment.Top :
									rTextCol.Offset(0, this.ImageList.ImageSize.Height);
									break;
							}
						}	
					}
                    if (rTextCol.Width > 0)
                    {
                        using (StringFormat sf = new StringFormat(StringFormatFlags.NoWrap))
                        {
                            sf.Trimming = StringTrimming.EllipsisCharacter;
                            sf.Alignment = column.Alignment;
                            sf.LineAlignment = column.VAlignment;

                            if (FTree.FastDrawString)
                            {
                                using (var brush = new SolidBrush(foreColor))
                                {
                                    graphics.DrawString(column.Text, column.Font, brush, rTextCol, sf);
                                }
                            }
                            else
                                TextRenderer.DrawText(graphics, column.Text, column.Font, rTextCol, foreColor, DrawingHelper.StringFormatToTextFormatFlags(sf));
                        }
                        
                    }
					//pour deboggage
					//g.DrawRectangle(Pens.Red, rTextCol);
					if (state != null)
					{
						graphics.Restore(state);
					}
				}
				columnRect = OldrCol;
				if (FDownIndex == IndexOfDisplay(column))
				{
					Rectangle rColBis = columnRect;
					rColBis.Width -= 1;
					rColBis.Height -= 1;
					graphics.DrawRectangle(Pens.Black, rColBis);
				}
				//Debug.WriteLine(String.Format("InternalDrawHeaderCol -> FDownIndex ={0}", FDownIndex));
				//dessin de l'icône de tri
				SortDirection aDir = IsSort(iCol);
				if (aDir != SortDirection.None)
				{
					int y = 0;
					int x = 0;
					switch (SortImageAlignment)
					{
						default :
						case ImageSortAlignment.RightCenter :
							y = columnRect.Height / 2 - 8;
							x = columnRect.Right - 20;
							break;
						case ImageSortAlignment.LeftCenter :
							y = columnRect.Height / 2 - 8;
							x = columnRect.Left;
							break;
						case ImageSortAlignment.TopLeft :
							y = columnRect.Top;
							x = columnRect.Left;
							break;
						case ImageSortAlignment.TopCenter :
							y = columnRect.Top;
							x = columnRect.Width / 2 - 8;
							break;
						case ImageSortAlignment.TopRight :
							y = columnRect.Top;
							x = columnRect.Right - 20;
							break;
						case ImageSortAlignment.BottomLeft :
							y = columnRect.Bottom -20;
							x = columnRect.Left;
							break;
						case ImageSortAlignment.BottomCenter :
							y = columnRect.Bottom -20;
							x = columnRect.Width / 2 - 8;
							break;
						case ImageSortAlignment.BottomRight :
							y = columnRect.Bottom - 20;
							x = columnRect.Right - 20;
							break;
					}
					FImageDropTarget.Draw(graphics, x, y, aDir == SortDirection.Ascending ? 2 : 3);				
					int sortOrder = SortOrder(iCol) + 1;
					if (sortOrder > 1)
						graphics.DrawString(sortOrder.ToString(CultureInfo.CurrentCulture), FFontSort, Brushes.Black, x, y  + 8);
				}
			}
			if (FDropTarget == IndexOfDisplay(column))
			{
				int y = columnRect.Height / 2 - 8;
				int x ;
			
				if (FDropBefore)
					x = columnRect.Left;
				else
					x = columnRect.Right - 16;
			
				DrawDropTarget(graphics, new Point(x, y));
			}
			DoAfterPaintHeader(args);
		}

		private void DoAfterPaintHeader(DrawHeaderColEventArgs e)
		{
			if (OnAfterPaintHeader != null)
				OnAfterPaintHeader(FTree, e);
		}

		private bool DoBeforePaintHeader(DrawHeaderColEventArgs e)
		{
			if (OnBeforePaintHeader != null)
				OnBeforePaintHeader(FTree, e);
			return e.DefaultDrawing;
		}

		private void DrawHeader(Graphics g, Rectangle r, int offsetx)
		{
			Rectangle rCol = r;
			int fixedWidth = FixedColumnWidth;
			rCol.Offset(offsetx, 0);
			int i = -1;
			foreach( GeniusTreeViewColonne col in FDisplays)
			{
				if (!col.Visible)
					continue;
				i++;
				rCol.Width = col.Width;
				if (r.IntersectsWith(rCol) && rCol.Width > 0 && i >= FixedColumnCount && rCol.Right > fixedWidth)
				{
					using (Bitmap bmp = new Bitmap(rCol.Width, r.Height))
					{
						using (Graphics gBmp = Graphics.FromImage(bmp))
						{
							InternalDrawHeaderCol(gBmp, col, new Rectangle(0,0, col.Width, r.Height));	
							g.DrawImage(bmp, rCol.X, rCol.Y);
						}
					}
				}
				rCol.Offset(col.Width, 0);
			}
			if (FixedColumnCount > 0)
			{
				rCol = r;
				i = 0;
				foreach( GeniusTreeViewColonne col in FDisplays)
				{
					if (!col.Visible)
						continue;
					if (i < FixedColumnCount)
					{						
						rCol.Width = col.Width;
						if (r.IntersectsWith(rCol) && rCol.Width > 0)
						{
							using (Bitmap bmp = new Bitmap(rCol.Width, r.Height))
							{
								using (Graphics gBmp = Graphics.FromImage(bmp))
								{
									InternalDrawHeaderCol(gBmp, col, new Rectangle(0,0, col.Width, r.Height));	
									g.DrawImage(bmp, rCol.X, rCol.Y);
								}
							}							
						}
						rCol.Offset(col.Width, 0);
						i++;
					}
					else
						break;
				}
			}
		}
		#endregion

		internal void PaintHeader(Graphics g, Rectangle r, int offsetx)
		{
            using (Bitmap bmp = new Bitmap(r.Width, r.Height))
            {
                using (Graphics gBmp = Graphics.FromImage(bmp))
                {
                    using (Brush br = FTree.Colors.HeaderColor.GetBrush(r))
                    {
                        gBmp.FillRectangle(br, r);
                    }
                    DrawHeader(gBmp, r, offsetx);
                    g.DrawImage(bmp, 0, 0);
                }
            }
		}

		internal void Redraw(bool updatescrolls)
		{
			if (InUpdateLayout)
				return;
			if (updatescrolls)
			{
				FTree.UpdateScrollBars(false);
				FTree.Invalidate();
			}
			//FlagsSetWindowPos.SWP_FRAMECHANGED provoque un NC_CalcSize
			NativeMethods.SetWindowPos(FTree.Handle, IntPtr.Zero,0,0,0,0, FlagsSetWindowPos.SWP_FRAMECHANGED |
				FlagsSetWindowPos.SWP_NOMOVE |FlagsSetWindowPos.SWP_NOSIZE | FlagsSetWindowPos.SWP_NOZORDER | FlagsSetWindowPos.SWP_NOACTIVATE);
		}
		
		/// <summary>
		/// provoque le redessin du header
		/// </summary>
		public void Invalidate()
		{
			Invalidate(FTree.Bounds);
		}

		/// <summary>
		/// provode le redessin d'une partie du header
		/// </summary>
		/// <param name="rect"></param>
		public void Invalidate(Rectangle rect)
		{
			Rectangle r = rect;
			RECT RW;

			r.Height = FTree.HeaderHeight;
			r.Y = - r.Height;
			RW = RECT.FromRectangle(r);
			NativeMethods.RedrawWindow(FTree.Handle, ref RW, IntPtr.Zero, FlagsRDW.RDW_FRAME | FlagsRDW.RDW_INVALIDATE |
				FlagsRDW.RDW_NOERASE); 
		}
		
		public void Invalidate(GeniusTreeViewColonne column)
		{
            if (column != null)
            {
                int left = Left(column);
                Rectangle r = new Rectangle(left, 0, column.Width - 10, FTree.HeaderHeight);
                Invalidate(r);
            }
		}
		#endregion

		/// <summary>
		/// renvoi le nombre de colonnes
		/// </summary>
		[Browsable(false)]
        [Description("Renvoi le nombre de colonne dans le header")]
		public int Count
		{
			get
			{
				return FColonnes.Count;
			}
		}

		/// <summary>
		/// renvoi la liste des colonnes définies
		/// </summary>
		[Browsable(false)]
		public GeniusTreeViewColumnCollection Colonnes
		{
			get
			{
				return FColonnes;
			}
		}

		/// <summary>
		/// renvoi la liste des colonnes dans l'ordre d'affichage
		/// </summary>
		/// <returns></returns>
		public GeniusTreeViewColonne[] GetDisplays()
		{
			return FDisplays.ToArray();
		}

		/// <summary>
		/// renvoi la direction du tri pour une colonne
		/// </summary>
		/// <param name="displayCol"></param>
		/// <returns></returns>
		public SortDirection GetSorting(int displayCol)
		{			
			return IsSort(displayCol);
		}

		/// <summary>
		/// renvoi la direction du tri pour une colonne
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		public SortDirection GetSorting(GeniusTreeViewColonne column)
		{			
			return IsSort(IndexOfDisplay(column));
		}

		#region propriétés publiques
		/// <summary>
		/// le nombre de colonne fixe à gauche
		/// </summary>
		[Description("Fixe le nombre de colonnes fixes")]
		[DefaultValue(0)]
		public int FixedColumnCount
		{
			get { return FFixedColumnCount; }
			set
			{
				FFixedColumnCount = value;
			}
		}

		/// <summary>
		/// La liste d'images pour les colonnes du header
		/// </summary>
		[Description("La liste d'images pour les colonnes du header")]
		public ImageList ImageList
		{
			get
			{
				return FImageList;
			}
			set
			{
				FImageList = value;
			}
		}

		internal void VisibleColumnChanged(GeniusTreeViewColonne aCol)
		{
			UpdateLayoutForLastCol();
		}

		internal void UpdateLayoutForLastCol()
		{
			if (InUpdateLayout || FTree.DesignMode)
				return;
			if (FAutoSizeCol)
			{
				InUpdateLayout = true;
				try
				{
					RestoreLastColWidth();
					InitFromLastCol();
					RecalcLastColWidth();
				}
				finally
				{
					InUpdateLayout = false;
				}
				Redraw(!this.AutoColHeight);
			}
		}

		#endregion

		internal void Cancel()
		{
			if (Contains(FStates, HeaderStateEnum.Dragging))
			{
				FDragIndex = Constants.NoColumn;
				FDragIndex = Constants.NoColumn;
				FDropTarget = Constants.NoColumn;
				EndDrag();
				FTree.Capture = false;
			}
			if (FStates != 0 || FDownIndex != Constants.NoColumn)
			{
				FStates = 0;
				FDownIndex = Constants.NoColumn;
                Invalidate();
			}
		}
	}
}
