using System.Drawing;
using Genius.Controls.TreeView;

namespace DemoTreeView.UserControl
{
	/// <summary>
	/// Summary description for TestChapter.
	/// </summary>
	public class TestChapter : System.Windows.Forms.UserControl
	{
		private Genius.Controls.TreeView.GeniusTreeView geniusTreeView1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestChapter()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AllowEdit = false;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.geniusTreeView1.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.geniusTreeView1.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F);
			this.geniusTreeView1.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.Default;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.Header.MainColumnIndex = 0;
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																										 this.geniusTreeViewColonne1});
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.Size = new System.Drawing.Size(440, 328);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.OnBeforeNodePainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.geniusTreeView1_OnBeforeNodePainting);
			this.geniusTreeView1.OnBeforeCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.geniusTreeView1_OnBeforeCellPainting);
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Text = "Colonne 0";
			// 
			// TestChapter
			// 
			this.Controls.Add(this.geniusTreeView1);
			this.Name = "TestChapter";
			this.Size = new System.Drawing.Size(440, 328);
			this.Load += new System.EventHandler(this.TestChapter_Load);
			this.SizeChanged += new System.EventHandler(this.TestChapter_SizeChanged);
			this.ResumeLayout(false);

		}
		#endregion

		private void TestChapter_Load(object sender, System.EventArgs e)
		{
			//geniusTreeView1.Header.MainColumnIndex = 0;
			geniusTreeView1.BeginUpdate();
			try
			{
				geniusTreeView1.DefaultDrawingOption = DrawingOption.HideButtons | DrawingOption.HideTreeLines | DrawingOption.HideSelection;
				geniusTreeView1.OnGetFontNode +=new Genius.Controls.TreeView.OnNodeFontDelegate(geniusTreeView1_OnGetFontNode);
				INode n = geniusTreeView1.Add(null, "1. GeniustreeView", null);
				n.Height = 40;
				INode child = geniusTreeView1.Add(n, "ceci est un texte", null);
				child.Height = 200;
				n = geniusTreeView1.Add(null, "2. Exemple sous forme de chapitre", null);
				n.Height = 40;
				child = geniusTreeView1.Add(n, "ceci est un deuxiéme texte", null);
				child.Height = 200;
				geniusTreeView1.ExpandAll();
			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}
		}

		private void geniusTreeView1_OnBeforeNodePainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			e.Info.StringFormat = new StringFormat();
			e.Info.StringFormat.LineAlignment = StringAlignment.Near;
			/*if (e.Node.Level == 1)
			{
				e.Info.Font	= new Font("Times News Roman", 20, FontStyle.Bold);
			}
			*/
		}

		private void geniusTreeView1_OnGetFontNode(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeFontEventArgs e)
		{
			if (e.Node.Level == 1)
			{
				e.Font	= new Font("Times News Roman", 20, FontStyle.Bold);
			}
			else if (e.Node.Level == 2)
			{
				e.Font	= new Font("Times News Roman", 12, FontStyle.Bold);				
			}
		}

		private void TestChapter_SizeChanged(object sender, System.EventArgs e)
		{
			if (!DesignMode)
				geniusTreeViewColonne1.Width = geniusTreeView1.ClientSize.Width-2;		
		}

		private void geniusTreeView1_OnBeforeCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Node.Level == 2)
			{
				e.Info.StringFormat.FormatFlags = 0;
				e.Info.StringFormat.LineAlignment = StringAlignment.Near;
			}
			else if (e.Node.Level == 1)
			{
				e.Info.StringFormat.Trimming = StringTrimming.EllipsisCharacter;
			}
		}
	}
}
