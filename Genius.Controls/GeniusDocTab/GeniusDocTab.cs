using System;
#if VS2005
using System.Collections.Generic;
#endif
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Genius.Controls.DocTabs
{
	/// <summary>
	/// orientation visuel des tabs <see cref="GeniusDocTab.TabOrientation"/>
	/// </summary>
    public enum TabOrientation
	{
		/// <summary>
		/// horizontal, prévu pour docker le control en haut
		/// </summary>
		Top, 
		/// <summary>
		/// Vertical, prévu pour docker le control à droite
		/// </summary>
		Right, 
		/// <summary>
		/// Vertical, prévu pour docker le control à gauche
		/// </summary>
		Left
	};

	/// <summary>
	/// deleguée utilise par <see cref="GeniusDocTab.OnSelectedIndexChanged"/>
	/// </summary>
    public delegate void SelectedIndexChangedEventHandler(object Sender, int oldIndex, int newIndex);

	/// <summary>
	/// control visuel représentant une zone avec des "tabs"
	/// </summary>
	[ToolboxBitmap(typeof(GeniusDocTab), "Resources.geniusDocTab.bmp")]
#if VS2005
    public partial class GeniusDocTab : Control
#else
	public class GeniusDocTab : Control
#endif
	
    {
		#region variables statiques
		#endregion

        #region variables
#if VS2005
        private List<GeniusTab> FTabs;
#else
		private GeniusTabs FTabs;
#endif
						
        private int FTopMargin;
        private int FSelected;
        private bool FUseTabColor;
        private int FStartIndex;
        private Color FUnSelectedColor;
        private Color FSelectedColor;
        private Color FUnSelectedLineColor;
        private Color FSelectedLineColor;
        private TabOrientation FOrientation;

        #endregion

        #region events
		/// <summary>
		/// évènement déclenché lorsque <see cref="GeniusDocTab.SelectedIndex"/> change
		/// </summary>
        public event SelectedIndexChangedEventHandler OnSelectedIndexChanged;
        #endregion

		/// <summary>
		/// constructeur par défaut
		/// </summary>
        public GeniusDocTab()
        {
			try
			{
				Height = 17;
				this.BackColor = Color.FromArgb(228, 226, 213);
				this.FUnSelectedColor = Color.FromArgb(228, 226, 213);
				//this.FUnSelectedColor = Color.FromArgb(247, 246, 239);
				this.FSelectedColor = Color.White;
				FUnSelectedLineColor = Color.FromArgb(172, 158, 153);
				FSelectedLineColor = Color.FromArgb(127, 157, 185);

#if VS2005
            FTabs = new List<GeniusTab>();
#else
				FTabs = new GeniusTabs();
#endif
				FTopMargin = 2;
				FSelected = -1;
				FStartIndex = 0;
#if VS2005
            DoubleBuffered = true;
#else
				SetStyle(ControlStyles.DoubleBuffer, true);
#endif
				this.Font = new Font("MS Reference Sans Serif", 7.75f);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Exception");
			}
        }

		#region méthodes privées
        private void RecalcTabPath(GeniusTab aTab)
        {
            if (aTab != null)
            {
                using (Graphics g = this.CreateGraphics())
                {
                    string sText = aTab.Text;
                    SizeF size = g.MeasureString(sText, this.Font);
                    aTab.Path = TabPath(Hauteur, Size.Truncate(size).Width + 3);
                }
            }
            else
            {
                foreach (GeniusTab tab in Tabs)
                    RecalcTabPath(tab);
            }
        }

        private int Hauteur
        {
            get
            {
                return (TabOrientation == TabOrientation.Top ? this.ClientRectangle.Height : this.ClientRectangle.Width) - FTopMargin;
            }
        }

        private int GetRight
        {
            get
            {
                return TabOrientation == TabOrientation.Top ? this.ClientRectangle.Right : this.ClientRectangle.Bottom;
            }
        }

        private int GetHeight
        {
            get
            {
                return TabOrientation == TabOrientation.Top ? this.ClientRectangle.Height : this.ClientRectangle.Width;
            }
        }

        private void RecalcTabRect()
        {
            if (Tabs.Count == 0)
                return;

            GeniusTab tab = Tabs[StartIndex];
            if (tab.Path == null)
                return;
            tab.PathOffset = (GraphicsPath)tab.Path.Clone();
            using (Matrix m = new Matrix())
            {
                m.Translate(0, FTopMargin);
                tab.PathOffset.Transform(m);
            }
            int hauteur = Hauteur;
            float w = tab.Width - hauteur / 2;
            for (int i = StartIndex - 1; i > 0; i--)
                Tabs[i].PathOffset = null;

            for (int i = StartIndex + 1; i < Tabs.Count; i++)
            {
                tab = Tabs[i];
                tab.PathOffset = (GraphicsPath)tab.Path.Clone();
                using (Matrix m = new Matrix())
                {
                    m.Translate(w, FTopMargin);
                    tab.PathOffset.Transform(m);
                }
                w += tab.Width - hauteur / 2;
            }
        }

        private static GraphicsPath TabPath(int hauteur, int largeur)
        {
            GraphicsPath Result = new GraphicsPath();
            var tempResult = Result;
            try
            {
                hauteur -= 4;
                if (hauteur < 0)
                    hauteur = 0;
                int x1 = 5 + hauteur + largeur;
                Result.AddCurve(new Point[] { new Point(0, 3 + hauteur), new Point(hauteur, 3), new Point(5 + hauteur, 0) }, 0.4f);
                Result.AddLine(5 + hauteur, 0, x1 - 2, 0);
                Result.AddLine(x1 - 2, 0, x1, 2);
                Result.AddLine(x1, 2, x1, 3 + hauteur);
                tempResult = null;
            }
            finally
            {
                if (tempResult != null)
                    tempResult.Dispose();
            }
            return Result;
        }

        private void DrawTab(GeniusTab tab, Graphics g, int hauteur, bool isSelected)
        {
			//pas de dessin du tab, s'il n'est pas entier, sauf pour le premier
			if (tab.PathOffset == null || (tab.PathOffset.GetBounds().Right > GetRight && tab != Tabs[StartIndex]))
				return;
			string sText = tab.Text;
			SizeF size = g.MeasureString(sText, this.Font);
			RectangleF r = Rectangle.Empty;
			r = tab.PathOffset.GetBounds();
			Color unselectedColor = FUnSelectedColor;
			if (FUseTabColor)
				unselectedColor = tab.Color;
			using (Pen p = new Pen(isSelected ? FSelectedColor : unselectedColor))
			{
				using (Brush b = new SolidBrush(isSelected ? FSelectedColor : unselectedColor))
				{
					g.FillPath(b, tab.PathOffset);
					g.DrawLine(p, r.Left, r.Bottom, r.Right, r.Bottom);
				}
			}
			using (Pen p = new Pen(isSelected ? FSelectedLineColor : FUnSelectedLineColor))
			{
				g.DrawPath(p, tab.PathOffset);
				if (isSelected)
				{
					g.DrawLine(p, 0, r.Bottom, r.Left, r.Bottom);
					g.DrawLine(p, r.Right, r.Bottom, GetRight, r.Bottom);
				}
			}
            using (var brush = new SolidBrush(this.ForeColor))
            {
			    g.DrawString(sText, this.Font, brush, r.Left + hauteur, (GetHeight - size.Height) / 2);
            }
        }
		#endregion

        #region override 
		/// <summary>
		/// dessin des tabs
		/// </summary>
		/// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
			try
			{
				bool recalcPathOffset = false;
				if (this.Count <= 0)
					return;
				int hauteur = Hauteur;
				//calcul du path
				foreach (GeniusTab tab in this.Tabs)
				{
					if (tab.DocTabs == null)
						tab.DocTabs = this;
					if (tab.Path == null)
					{
						RecalcTabPath(tab);
						recalcPathOffset = true;
					}
				}
				if (recalcPathOffset)
					RecalcTabRect();
				if (FOrientation == TabOrientation.Right)
				{
                    using (Matrix m = new Matrix())
                    {
                        m.Translate(this.ClientRectangle.Width, 0);
                        m.Rotate(90);
                        e.Graphics.Transform = m;
                    }
				}
				else if (FOrientation == TabOrientation.Left)
				{
                    using (Matrix m = new Matrix())
                    {
                        m.Translate(0, this.ClientRectangle.Height);
                        m.Rotate(270);
                        e.Graphics.Transform = m;
                    }
				}
				for (int i = Tabs.Count - 1; i >= StartIndex; i--)
				{
					GeniusTab tab = Tabs[i];
					if (i == SelectedIndex)
						continue;
					DrawTab(Tabs[i], e.Graphics, hauteur, false);
				}
				if (SelectedIndex >= 0)
				{
					GeniusTab tab = Tabs[SelectedIndex];
					DrawTab(tab, e.Graphics, hauteur, true);              
				}
			}
			catch (Exception ex)
			{
                Debug.WriteLine(ex.ToString());
                Trace.TraceError("OnPaint error : {0}", ex);
			}
        }

		/// <summary>
		/// déplacement de la souris
		/// </summary>
		/// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int index = GetTabUnderMouse(e.X, e.Y);
            if (index != -1)
            {
                Debug.WriteLine(string.Format("under ({0}, {1})", e.X, e.Y));
            }            
        }

		/// <summary>
		/// clic de la souris
		/// </summary>
		/// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index = GetTabUnderMouse(e.X, e.Y);
            if (index >= 0)
                SelectedIndex = index;
			base.OnMouseDown(e);
        }

		/// <summary>
		/// la taille du control change
		/// </summary>
		/// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
			if (this.Created)
			{
				RecalcTabPath(null);
				RecalcTabRect();
				Invalidate();
			}
			base.OnResize(e);
        }
        #endregion

        #region protégées
		/// <summary>
		/// index séléectionné à changé
		/// </summary>
		/// <param name="old"></param>
		/// <param name="aNew"></param>
        protected virtual void DoSelectedIndexChanged(int old, int aNew)
        {
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged(this, old, aNew);
        }
        #endregion

        #region propriétés publiques
		/// <summary>
		/// index du premier tab affiché
		/// </summary>
		[DefaultValue(0)]
		public int StartIndex
		{
			get
			{
				if (FStartIndex >= Count)
					FStartIndex = Count-1;
				if (FStartIndex < 0)
					FStartIndex = 0;
				return FStartIndex;
			}
			set
			{
				if (FStartIndex != value && FStartIndex >= 0)
				{
					FStartIndex = value;
					RecalcTabRect();
					Invalidate();
				}
			}
		}
		/// <summary>
		/// nombre de tabs
		/// </summary>
        [Browsable(false)]
        public int Count
        {
            get
            {
                return FTabs.Count;
            }
        }

		/// <summary>
		/// l'index du tab selectionné
		/// </summary>
        public int SelectedIndex
        {
            get
            {
                return FSelected;
            }
            set
            {
                if (value != FSelected && FSelected < Count)
                {
                    int old = FSelected;
                    FSelected = value;
                    DoSelectedIndexChanged(old, FSelected);
                    Invalidate();
                }
            }
        }
		/// <summary>
		/// retourne la liste des tabs
		/// </summary>
#if VS2005
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<GeniusTab> Tabs
#else
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public GeniusTabs Tabs
#endif
        {
            get { return FTabs; }
#if VS2005
            set 
            { 
                FTabs = value; 
            }
#endif
        }

		/// <summary>
		/// marge au dessus des tabs
		/// </summary>
        [DefaultValue(2)]
        public int TopMargin
        {
            get
            {
                return FTopMargin;
            }
            set
            {
                if (value != FTopMargin && FTopMargin >= 0)
                {
                    FTopMargin = value;
                    RecalcTabRect();
                    Invalidate();
                }
            }
        }

		/// <summary>
		/// activer ou pas l'utilisation des couleurs de chaque tab
		/// </summary>
        [DefaultValue(false)]
        public bool UseTabColor
        {
            get
            {
                return FUseTabColor;
            }
            set
            {
                if (FUseTabColor != value)
                {
                    FUseTabColor = value;
                    Invalidate();
                }
            }
        }

		/// <summary>
		/// couleur des tabs non sélectionnés
		/// </summary>
        public Color UnSelectedColor
        {
            get { return FUnSelectedColor; }
            set
            {
                if (FUnSelectedColor != value)
                {
                    FUnSelectedColor = value;
                    Invalidate();
                }
            }
        }

		/// <summary>
		/// couleur du tab selectionné
		/// </summary>
        public Color SelectedColor
        {
            get { return FSelectedColor; }
            set
            {
                if (value != FSelectedColor)
                {
                    FSelectedColor = value;
                    Invalidate();
                }
            }
        }

		/// <summary>
		/// couleur de la ligne des tab non selectionné
		/// </summary>
        public Color UnSelectedLineColor
        {
            get { return FUnSelectedLineColor; }
            set
            {
                if (value != FUnSelectedLineColor)
                {
                    FUnSelectedLineColor = value;
                    Invalidate();
                }
            }
        }

		/// <summary>
		/// couleur de ligne selectionné
		/// </summary>
        public Color SelectedLineColor
        {
            get { return FSelectedLineColor; }
            set
            {
                if (value != FSelectedLineColor)
                {
                    FSelectedLineColor = value;
                    Invalidate();
                }
            }
        }

		/// <summary>
		/// orientation des tabs
		/// </summary>
        [DefaultValue(TabOrientation.Top)]
        public TabOrientation TabOrientation
        {
            get { return FOrientation; }
            set
            {
                if (FOrientation != value)
                {
                    FOrientation = value;
                    Invalidate();
                }
            }
        }
        #endregion
		#region méthodes publiques
		/// <summary>
		/// obtenir l'index du sous la souris
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int GetTabUnderMouse(int x, int y)
		{
			if (TabOrientation == TabOrientation.Right)
			{
				int oldX = x;
				x = y;
				y = this.ClientRectangle.Width - oldX;
			}
			else if (TabOrientation == TabOrientation.Left)
			{
				int oldY = y;
				y = x;
				x = this.ClientRectangle.Height - oldY;
			}
			if (SelectedIndex >= 0 && SelectedIndex < Tabs.Count)
			{
				GeniusTab tab = Tabs[SelectedIndex];
				if (tab.PathOffset != null && tab.PathOffset.IsVisible(x, y))
					return SelectedIndex;
			}
			for (int index = StartIndex; x >=0 && index < Tabs.Count; index++)
			{
				GeniusTab tab = Tabs[index];
				if (tab.PathOffset != null && tab.PathOffset.IsVisible(x, y))
					return index;
			}
			return -1;
		}
		#endregion
    }
}
