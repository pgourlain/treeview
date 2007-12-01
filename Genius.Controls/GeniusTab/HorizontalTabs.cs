/****************************************************************************************
 * Auteur : Pierrick Gourlain Décembre 2004
 * + : Ajout
 * - : Suppression de fonctionnalité
 * . : correction de bugs
 * 
 * 
 * Last changes : 29/12/2004
 * + évènements de changement de tabulations
 * + propriété TabVisible sur les "HorizontalTab"
 **************************************************************************************/
#region Imports
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;
#endregion


/****************************************************************************************
 * RoadMap
 *  + CustomPaint autre que la zone de texte
 *  + gérer une zone de défilement dans le cas ou le nombre de "tabs" depasse la zone d'affichage
 * *************************************************************************************/
namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// défini l'orientation des tabs
	/// </summary>
	public enum TabOrientation 
		{
		/// <summary>
		/// les tabs sont horizontal situés à gauche
		/// </summary>
		Left, 
		/// <summary>
		/// les tabs sont vertical situés en bas
		/// </summary>
		Bottom
		};

	/// <summary>
	/// <see cref="HorizontalTabs.OnDrawTab"/>
	/// </summary>
	public delegate void OnDrawTabDelegate(object Sender, DrawTabEventArgs e);
	/// <summary>
	/// delegate lors du changement de tab
	/// </summary>
	public delegate void OnBeforeTabChangeDelegate(object Sender, TabBeforeChangeEventArgs e);
	/// <summary>
	/// delegate lors du changement de tab
	/// </summary>
	public delegate void OnAfterTabChangeDelegate(object Sender, TabChangeEventArgs e);
	/// <summary>
	/// Summary description for HorizontalTabs.
	/// </summary>
	[DefaultProperty("Tabs")]
	[Designer("Genius.Controls.Design.HorizontalTabDesigner, Genius.Controls.Design")]
	public class HorizontalTabs : Control
	{
		const int NoIndex = -1;
		private int FTabsWidth;
		private int FTabsHeight;
		private HorizontalTabCollection FTabs;
		private int FMargins;
		private int FHoverIndex;
		private int FSelectedIndex;
		private HorizontalTab[] FTabControls;
		private TabOrientation FOrientation;
		private bool FUseRegion;

		#region events
		/// <summary>
		/// delegate pour le dessin des tabs
		/// </summary>
		public event OnDrawTabDelegate				OnDrawTab;
		/// <summary>
		/// 
		/// </summary>
		public event OnBeforeTabChangeDelegate		OnBeforeTabChange;
		/// <summary>
		/// 
		/// </summary>
		public event OnAfterTabChangeDelegate		OnAfterTabChange;
		#endregion

		/// <summary>
		/// contructeur par défaut
		/// </summary>
		public HorizontalTabs()
		{
			FTabs = new HorizontalTabCollection(this);
			this.SetStyle(ControlStyles.ContainerControl, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			FTabsWidth = 105;
			FTabsHeight = 30;
			FMargins = 5;
			FHoverIndex = NoIndex;
			FSelectedIndex = NoIndex;
			FTabControls = null;
			FUseRegion = true;
		}

		#region méthodes privées
		/// <summary>
		/// renvoi l'index du tab en dessous du point défini par x,y
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		private int GetHitTestInfo(int x, int y)
		{
			if (Orientation == TabOrientation.Bottom)
			{
				int oldx = x;
				x = this.ClientRectangle.Height - y;
				y = oldx;
			}
			if (x >= 0 && x < FTabsWidth && y >= FMargins && y <= FTabsHeight * Count + FMargins)
			{
				y-= FMargins;
				int ieme = y / FTabsHeight;
				if (DesignMode)
					return ieme;
				if (FTabControls != null)
				{
					for (int i =0; i < FTabControls.Length; i++)
					{
						if (FTabControls[i].TabVisible)
						{
							if (ieme == 0)
								return i;
							ieme--;
						}
					}
				}
			}
			return NoIndex;
		}

		private void AdjustHoverIndex(ref int hoverIndex, int x, int y)
		{
			int currentTab = GetHitTestInfo(x, y);
			if (currentTab != hoverIndex)
			{
				if (hoverIndex != NoIndex)
				{
					int oldindex = hoverIndex;
					hoverIndex = NoIndex;
					InvalidateTab(oldindex);
				}
				hoverIndex = currentTab;
				if (hoverIndex != NoIndex)
					InvalidateTab(hoverIndex);
			}
		}

		internal void InvalidateTab(HorizontalTab aTab)
		{
			if (aTab != null)	
				InvalidateTab(Tabs.IndexOf(aTab));
		}
		internal void InvalidateTab(int index)
		{
			Rectangle r = GetTabRect(index);
			Invalidate(r);
		}

		private Rectangle GetTabRect(int index)
		{
			switch (Orientation) 
			{
				default :
					return new Rectangle(0, FMargins + index * FTabsHeight, FTabsWidth + FMargins, FTabsHeight);
				case TabOrientation.Bottom :
					return new Rectangle(FMargins + index * FTabsHeight, this.ClientRectangle.Height - (FTabsWidth + FMargins), FTabsHeight, FTabsWidth + FMargins);
			}
		}

		private void SelectTab(int index)
		{
			if (index <= NoIndex || index == FSelectedIndex)
				return;
			if (!CanSelectTab(FSelectedIndex, index))
				return;
			int oldindex = FSelectedIndex;
			if (FSelectedIndex > NoIndex)
			{
				int old = FSelectedIndex;
				FSelectedIndex = NoIndex;
				InvalidateTab(old);
			}
			FSelectedIndex = index;
			if (FSelectedIndex > NoIndex)
				InvalidateTab(FSelectedIndex);
			this.UpdateSelection(false);
			if (OnAfterTabChange != null)
				OnAfterTabChange(this, new TabChangeEventArgs(oldindex, FSelectedIndex));
		}

		private bool CanSelectTab(int oldindex, int newindex)
		{
			if (!IsVisible(newindex))
				return false;
			if (OnBeforeTabChange != null)
			{
				TabBeforeChangeEventArgs e = new TabBeforeChangeEventArgs(oldindex, newindex);
				OnBeforeTabChange(this, e);
				return e.Allow;
			}
			return true;
		}

		private void UpdateSizeOfTab()
		{
			if (FTabControls != null)
			{
				foreach(HorizontalTab tab in FTabControls)
					tab.Bounds = this.DisplayRectangle;
			}
		}

		private bool IsVisible(int aIndex)
		{
			if (DesignMode)
				return true;
			if (FTabControls != null && aIndex >=0 && aIndex < FTabControls.Length)
			{
				return FTabControls[aIndex].TabVisible;
			}
			return false;
		}
		#endregion

		#region méthodes interne
		internal HorizontalTab[] GetTabs()
		{
			return FTabControls;
		}

		internal HorizontalTab GetTab(int index)
		{
			try
			{
				return FTabControls[index];
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString())	;
			}
			return null;
		}

		internal int TabsCount
		{
			get
			{
				if (FTabControls != null)
					return FTabControls.Length;
				else
					return 0;
			}
		}

		internal void UpdateSelection(bool uiselected)
		{
			if (!base.IsHandleCreated)
				return;
			int curSel = SelectedIndex;
			HorizontalTab[] tabs = GetTabs();
			if (tabs == null)
				return;
			if (curSel != -1)
			{
				tabs[curSel].Bounds = this.DisplayRectangle;
				tabs[curSel].Visible = true;
			}
			for (int i =0; i < tabs.Length; i++)
			{
				if (i != curSel)
					tabs[i].Visible = false;
			}
		}

		internal void SelectFirstVisible()
		{
			if (FTabControls != null)
			{
				int index= NoIndex;
				for (int i=0; i < FTabControls.Length; i++)
					if (FTabControls[i].TabVisible)
					{
						index = i;
						break;
					}
				if (index != FSelectedIndex)
				{
					FSelectedIndex = index;
					UpdateSelection(false);
				}
			}
		}

		#endregion

		#region protected
		/// <summary>
		/// le rectangle contenant les contrôles enfants
		/// </summary>
		public override System.Drawing.Rectangle DisplayRectangle
		{
			get
			{
				Rectangle r = base.DisplayRectangle;
				switch(Orientation)
				{
					case TabOrientation.Left :
						r.X += FTabsWidth;
						r.Width -= (FTabsWidth);
						break;
					case TabOrientation.Bottom :
						r.Height -= (FTabsWidth );
						break;
				}
				r.Inflate(-(FMargins+1),-(FMargins+1));
				return r;
			}
		}

		private Rectangle OrientationRectangle(Rectangle r)
		{
			Rectangle Result = r;
			switch(Orientation)
			{
				case TabOrientation.Bottom :
					Result.X = r.Y;
					Result.Y = r.X;
					Result.Width = r.Height;
					Result.Height = r.Width;
					break;
			}
			return Result;
		}

		private void DrawTabCadre(Graphics g, int i)
		{
			int xStart = Orientation == TabOrientation.Left ? 0 : 1;
			g.DrawLines(Pens.Gray, new Point[]{new Point(FTabsWidth+FMargins, FMargins + i * FTabsHeight),
														   new Point(xStart, FMargins + i * FTabsHeight),
														   new Point(xStart, FMargins-1 + (i+1) * FTabsHeight),
														   new Point(FTabsWidth + FMargins, FMargins-1 + (i+1) * FTabsHeight)});
			using (Brush selBrush = new SolidBrush(Color.FromArgb(255,194,95)))
			{
				g.FillEllipse(selBrush, -1, FMargins + i * FTabsHeight, 3, FTabsHeight-1);
			}
		}

		/// <summary>
		/// dessin des tabs
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			int nbTabsHide = 0;
			Rectangle r = OrientationRectangle(this.ClientRectangle);
			Color col1 = Color.FromArgb(245,250,245);
			Color col2 = Color.FromArgb(240,250,234);
			using (LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, col1,col2, 90))
			{
				Matrix m = OrientationMatrix;
				if (m != null)
					e.Graphics.Transform = m;
				e.Graphics.FillRectangle(br, r);			
				Color tour = Color.FromArgb(109,139,164);
				using (Pen pTour = new Pen(tour))
				{
					r = DisplayRectangle;

					//le DisplayRectangle est déjà tourné
					e.Graphics.ResetTransform();
					//dessin du tour du tabpage
					e.Graphics.DrawRectangle(pTour, r.X-1, r.Y-1, r.Width+1, r.Height+1);				
					if (m != null)
						e.Graphics.Transform = m;
					using (GraphicsPath path = TabsRegion)
					{
						pTour.Width = UseRegion ? 2 : 1;
						e.Graphics.DrawPath(pTour, path);
					}
					using (Pen pLine = new Pen(Color.FromArgb(232,231,223), 1))
					{
						nbTabsHide = 0;
						//dessin des lignes
						for (int i =0; i < Count; i++)
						{
							if (!IsVisible(i))
							{
								nbTabsHide++;
								continue;
							}
							//dessin de la ligne blanche au dessus
							e.Graphics.DrawLine(Pens.White, new Point(FMargins, FMargins + (i - nbTabsHide) * FTabsHeight - 1), new Point(FTabsWidth, FMargins + (i - nbTabsHide) * FTabsHeight -1));
							//dessin de la ligne grise au dessus
							e.Graphics.DrawLine(pLine, new Point(FMargins, FMargins + (i - nbTabsHide) * FTabsHeight), new Point(FTabsWidth, FMargins + (i - nbTabsHide) * FTabsHeight));
							//dessin de la ligne grise au dessous
							e.Graphics.DrawLine(Pens.White, new Point(FMargins, FMargins + (i - nbTabsHide) * FTabsHeight + FTabsHeight-1), new Point(FTabsWidth, FMargins + (i - nbTabsHide) * FTabsHeight + FTabsHeight-1));
							//dessin de la ligne grise au dessous
							e.Graphics.DrawLine(pLine, new Point(FMargins, FMargins + (i - nbTabsHide) * FTabsHeight + FTabsHeight), new Point(FTabsWidth, FMargins + (i - nbTabsHide) * FTabsHeight + FTabsHeight));
						}
					}
					nbTabsHide = 0;
					for (int i = 0; i < Count; i++)
					{
						if (!IsVisible(i))
						{
							nbTabsHide++;
							continue;
						}
						//dessin du selectionné
						if (i == FSelectedIndex)
						{
							Rectangle rSel = new Rectangle(0, FTabsHeight * (i - nbTabsHide) + FMargins, FTabsWidth + FMargins-1, FTabsHeight);
							e.Graphics.FillRectangle(Brushes.White, rSel);
							DrawTabCadre(e.Graphics, i- nbTabsHide);
							using (Pen pLine = new Pen(Color.FromArgb(173,139,164)))
							{
								e.Graphics.DrawLine(pLine, FTabsWidth + FMargins+1, FTabsHeight * (i - nbTabsHide) + FMargins, FTabsWidth + FMargins+1, FTabsHeight * ((i - nbTabsHide)+1) + FMargins);
							}
						}
						if (i == FHoverIndex)
						{
							DrawTabCadre(e.Graphics, i - nbTabsHide);
						}
						//dessin du texte
						Rectangle rTab = new Rectangle(FMargins, FMargins + 1 + (i - nbTabsHide) * FTabsHeight, FTabsWidth - 5, FTabsHeight-1);
						bool defaultDrawing = true;
						if (OnDrawTab != null)
						{
							DrawTabEventArgs ev = new DrawTabEventArgs(e.Graphics, rTab);
							OnDrawTab(this, ev);
							defaultDrawing = ev.DefaultDrawing;
						}
						if (defaultDrawing)
						{
							StringFormat sf = new StringFormat();
							sf.Alignment = FTabControls[i].HorizontalTextAlignement;
							sf.LineAlignment = FTabControls[i].VerticalTextAlignment;
							e.Graphics.DrawString(FTabControls[i].Text, this.Font, Brushes.Black, rTab, sf);		
						}
					}
				}
			}
		}

		[DefaultValue(true)]
		private bool UseRegion
		{
			get { return FUseRegion; }
			set { FUseRegion = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		protected Matrix OrientationMatrix
		{
			get
			{
				Matrix m = null;
				if (Orientation != TabOrientation.Left)
				{
					m = new Matrix();
					switch(Orientation)
					{
						case TabOrientation.Bottom :
							m.Rotate(-90.0f);
							m.Translate(0, this.ClientRectangle.Height, MatrixOrder.Append);
							break;
					}
				}	
				return m;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		protected GraphicsPath TabsRegion
		{
			get
			{
				Rectangle r = OrientationRectangle(this.ClientRectangle);
				if (r.IsEmpty)
					return null;
				int visibleCount = VisibleCount;
				GraphicsPath path = new GraphicsPath();
				path.AddArc(0,0,10,10, 180, 90);
				path.AddLine(5,0, r.Width, 0);
				path.AddLine(r.Width,0,r.Width, r.Height);
				path.AddLine(r.Width,r.Height,FTabsWidth, r.Height);
				path.AddLine(FTabsWidth,r.Height,FTabsWidth, (visibleCount+1) * FTabsHeight + 10 + FMargins);
				path.AddBezier(FTabsWidth, (visibleCount+1) * FTabsHeight + 10 + FMargins, FTabsWidth, (visibleCount+1) * FTabsHeight + 5 + FMargins,
											0, (visibleCount+0) * FTabsHeight + 10 + FMargins, 0, (visibleCount+0) * FTabsHeight + 5 + FMargins);
				path.AddLine(0, (visibleCount+0) * FTabsHeight,0, 10 + FMargins);
				path.CloseFigure();
				return path;
			}
		}

		/// <summary>
		/// met à jour la region du contrôle
		/// </summary>
		internal void UpdateRegion()
		{
			GraphicsPath path = TabsRegion;
			if (path != null)
			{
				Matrix m = OrientationMatrix;
				if (m != null)
					path.Transform(m);
				if (FUseRegion)
				{
					if (this.Region != null)
						this.Region.Dispose();
					this.Region = new Region(path);
				}
				Invalidate(true);
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSizeChanged(EventArgs e)
		{
			UpdateRegion();
			base.OnSizeChanged (e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);
			AdjustHoverIndex(ref FHoverIndex, -1,-1);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Clicks == 1 && e.Button == MouseButtons.Left)
			{
					SelectTab(GetHitTestInfo(e.X, e.Y));
			}
			else
				base.OnMouseDown (e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.None)
			{
				AdjustHoverIndex(ref FHoverIndex, e.X, e.Y);
			}
			else
				base.OnMouseMove (e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		protected override System.Windows.Forms.Control.ControlCollection CreateControlsInstance()
		{
			return new TabControlCollection(this);
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void CreateHandle()
		{
			base.CreateHandle ();
			UpdateRegion();
			UpdateSelection(false);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated (e);
		}

		#endregion

		#region publiques
		internal void AddTab(HorizontalTab value)
		{
			InsertTab(TabsCount, value);
		}

		internal void InsertTab(int index, HorizontalTab value)
		{
			int length = 1;
			if (FTabControls != null)
				length = FTabControls.Length+1;
			HorizontalTab[] tmpArray = new HorizontalTab[length];
			if (length > 1)
				Array.Copy(FTabControls, 0, tmpArray, 0, length-1);
			FTabControls = tmpArray;
			if (index < TabsCount)
			{
				Array.Copy(FTabControls, index, FTabControls, index+1, TabsCount-index-1);
			}
			FTabControls[index] = value;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		public void RemoveTabAt(int index)
		{
			//TODO: à debugger
			if (index < 0 || index >= TabsCount)
				throw new ArgumentException("index hors limite", "index");
			HorizontalTab[] tmpArray = new HorizontalTab[TabsCount-1];
			if (index < tmpArray.Length)
				Array.Copy(FTabControls, index+1, FTabControls, index, tmpArray.Length - index);
			if (tmpArray.Length > 0)
				Array.Copy(FTabControls, 0, tmpArray, 0, tmpArray.Length);
			FTabControls = tmpArray;
		}

		internal int FindTab(HorizontalTab value)
		{
			int i = 0;
			if (FTabControls != null)
				foreach (HorizontalTab tab in FTabControls)
				{
					if (tab == value)
						return i;
					i++;
				}
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		public void RemoveAll()
		{
			Controls.Clear();
			FTabControls = null;
			FSelectedIndex = -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		public HorizontalTab GetTabOnPoint(Point pt)
		{
			int index = GetHitTestInfo(pt.X, pt.Y);
			if (index > NoIndex)
			{
				return FTabControls[index];
			}
			return null;
		}
		#endregion
		
		#region propriétés publiques
		/// <summary>
		/// 
		/// </summary>
		public int TabsWidth
		{
			get
			{
				return FTabsWidth;
			}
			set
			{
				if (value > 0)
				{
					FTabsWidth = value;
					UpdateRegion();
					UpdateSizeOfTab();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int TabsHeight
		{
			get
			{
				return FTabsHeight;
			}
			set
			{
				if (value > 0)
				{
					FTabsHeight = value;
					UpdateRegion();
					UpdateSizeOfTab();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int Count
		{
			get
			{
				return TabsCount;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int VisibleCount
		{
			get
			{
				if (DesignMode)
					return Count;
				int Result = 0;
				if (FTabControls != null)
					foreach(HorizontalTab tab in FTabControls)
						if (tab.TabVisible)
							Result++;
				return Result;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MergableProperty(false)]
		public HorizontalTabCollection Tabs
		{
			get
			{
				return FTabs;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int SelectedIndex
		{
			get
			{
				return FSelectedIndex;
			}
			set
			{
				if (value >= 0 && value < Count && value != FSelectedIndex)
				{
					SelectTab(value);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(false)]
		public HorizontalTab SelectedTab
		{
			get
			{
				if (FSelectedIndex != -1)
					return GetTab(FSelectedIndex);
				else
					return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public TabOrientation Orientation
		{
			get
			{
				return FOrientation;
			}
			set
			{
				if (FOrientation != value)
				{
					FOrientation = value;
					UpdateRegion();
					UpdateSizeOfTab();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[Browsable(true)]
		public int Margins
		{
			get
			{
				return FMargins;
			}
			set
			{
				if (value != FMargins)
				{
					if (value < 1) 
						value = 1;
					FMargins = value;
					UpdateSizeOfTab();
					UpdateRegion();
				}
			}
		}
		#endregion

		#region nested class
		/// <summary>
		/// classe "container" des <see cref="HorizontalTab"/>
		/// cette classe est instanciée <see cref="Control.CreateControlsInstance"/>
		/// </summary>
		public class TabControlCollection : Control.ControlCollection
		{
			private HorizontalTabs FOwner;
			/// <summary>
			/// 
			/// </summary>
			/// <param name="owner"></param>
			public TabControlCollection(HorizontalTabs owner) : base(owner)
			{
				FOwner = owner;
			}

			/// <summary>
			/// Ajout d'un control, seul les <see cref="HorizontalTab"/> sont admis
			/// </summary>
			/// <param name="value"></param>
			/// <exception cref="ArgumentException">est soulevée si value n'est pas un <see cref="HorizontalTab"/></exception>
			public override void Add(Control value)
			{
				if (!(value is HorizontalTab))
					throw new ArgumentException("bad argument type", "value");
				HorizontalTab tab = (HorizontalTab)value;
				if (FOwner.IsHandleCreated)
					FOwner.AddTab(tab);
				else
					FOwner.InsertTab(FOwner.TabsCount, tab);
				base.Add (value);
				tab.Visible = false;
				if (FOwner.IsHandleCreated)
					tab.Bounds = FOwner.DisplayRectangle;
				ISite site1 = FOwner.Site;
				if (site1 != null && tab.Site == null)
					site1.Container.Add(tab);
				if (Count > 0 && FOwner.FSelectedIndex < 0)
					FOwner.SelectFirstVisible();
				FOwner.UpdateRegion();
				FOwner.UpdateSelection(false);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="value"></param>
			public override void Remove(Control value)
			{
				base.Remove (value);
				if (value is HorizontalTab)
				{
					int index = FOwner.FindTab((HorizontalTab)value);
					if (index != -1)
					{
						FOwner.RemoveTabAt(index);
						FOwner.SelectedIndex = Math.Max(index-1, 0);
						if (Count == 0)
							FOwner.FSelectedIndex = -1;
					}
					FOwner.UpdateRegion();
					FOwner.UpdateSelection(false);
				}
			}
		}
		#endregion
	}
}
