using System;
using System.Drawing;
using System.Windows.Forms;
using Genius.Controls.TreeView;
using Genius.Controls.TreeView.Core;

namespace Genius.Controls.NativeWindow
{
    using System.Security.Permissions;
    using GeniusTreeView = Control;
	/// <summary>
	/// fenêtre de base pour la gestion des hint
	/// </summary>
	public class BaseHintWindow : BaseNativeWindow, IHintWindow
	{
		private int FDisplayColumn;
		private string FText;
		private Font FFont;
		private bool FCalculateSizeNeeded;
		private INode FNode;

		/// <summary>
		/// constrcuteur par défaut
		/// </summary>
		/// <param name="treeView"></param>
		public BaseHintWindow(GeniusTreeView treeView) : base(treeView)
		{
            if (treeView == null)
                throw new ArgumentNullException("treeView");
			FFont = (Font)treeView.Font.Clone();
			FCalculateSizeNeeded = false;
		}

		private void DoCalculateSize()
		{
			if (HandleCreated)
			{
				FCalculateSizeNeeded = false;
                using (Graphics g = Graphics.FromHwnd(this.Handle))
                {
                    this.WindowSize = CalculateSize(g);
                }
			}
			else
			{
				FCalculateSizeNeeded = true;
			}
		}

		#region méthodes protégées
		/// <summary>
		/// surcharge de la WndProc pour le traitement du WM_NCHITTEST
		/// </summary>
		/// <param name="m"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)Msgs.WM_NCHITTEST)
				m.Result = new IntPtr((int)HitTest.HTTRANSPARENT);
			else
				base.WndProc (ref m);
		}

		/// <summary>
		/// à surcharger par les descendant pour renvoyer la taille de la fenêtre de
		/// hint
		/// </summary>
		/// <param name="graphics"></param>
		/// <returns></returns>
		protected virtual Size CalculateSize(Graphics graphics)
		{
            SizeF size;
            //size = g.MeasureString(this.Text, this.Font);
			size = TextRenderer.MeasureText(this.Text, this.Font, Size.Empty, TextFormatFlags.ExpandTabs);

			return size.ToSize() + new Size(2,2);	
		}

		/// <summary>
		/// à surcharger par les descendants, pour customiser le paint
		/// </summary>
		/// <param name="graphics"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification="Validate by caller")]
        protected override void DoPaint(Graphics graphics)
		{
            Rectangle r = this.ClientRectangle;
            graphics.FillRectangle(SystemBrushes.Info, r);
            graphics.DrawString(FText, FFont, Brushes.Black, r);
            r.Width -= 1;
            r.Height -= 1;
            graphics.DrawRectangle(Pens.Black, r);
		}

		/// <summary>
		/// methode invoqué après la création du control
		/// </summary>
		protected override void AfterHandleCreated()
		{
			if (FCalculateSizeNeeded)
				DoCalculateSize();
		}

		#endregion

		/// <summary>
		/// la font utilisée pour le hint
		/// </summary>
		public Font Font
		{
			get
			{
				return FFont;
			}
			set
			{
				FFont = value;
			}
		}

		#region IHintWindow Members

		/// <summary>
		/// colonne en cours du display
		/// </summary>
		public int DisplayColumn
		{
			get
			{
				return FDisplayColumn;
			}
			set
			{
				FDisplayColumn = value;
			}
		}

		/// <summary>
		/// le texte à afficher dans le hint
		/// </summary>
		public string Text
		{
			get
			{
				return FText;
			}
			set
			{
				FText = value;
				DoCalculateSize();
				Invalidate();
			}
		}

		/// <summary>
		/// le noeud concerner par le hint
		/// </summary>
		public INode Node
		{
			get
			{
				return FNode;
			}
			set
			{
				FNode = value;
			}
		}

		/// <summary>
		/// afficher le hint
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public virtual void ShowHint(int x, int y)
		{
			Rectangle scr = Screen.FromHandle(this.Handle).WorkingArea;
			
			Position = new Point(x,y);
			Point pt = new Point(x, y);
			//recalcul de la position si le bas dépasse de l'écran
			Rectangle rWindow = this.WindowRect;
			int ay = rWindow.Bottom;
			int ax = rWindow.Right;
			if (ay > scr.Bottom)
				pt.Y -= ay - scr.Bottom;
			if (ax > scr.Right)
				pt.X -= ax - scr.Right;
			Position = pt;
			if (!Visible)
				Visible = true;
		}

		/// <summary>
		/// cacher le hint
		/// </summary>
		public virtual void Hide()
		{
			Visible = false;
		}

		/// <summary>
		/// le hint est-il visible
		/// </summary>
		public bool IsVisible
		{
			get
			{
				return Visible;
			}
		}

		/// <summary>
		/// dispose du hint
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (FFont != null)
				FFont.Dispose();
			FFont = null;
			base.Dispose (disposing);
		}

		#endregion
	}
}
