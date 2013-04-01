using System.Collections;
using System.Drawing;
using Genius.Controls;
using Genius.Controls.TreeView;

namespace DemoTreeView.UserControls
{
	/// <summary>
	/// Summary description for TestDataSource.
	/// </summary>
	public class TestDataSource : System.Windows.Forms.UserControl
	{
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private Genius.Controls.TreeView.GeniusTreeView gtv;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestDataSource()
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
			this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AutoSort = false;
			this.gtv.BackColor = System.Drawing.SystemColors.Window;
			this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F);
			this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.FullRowSelect = true;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.MainColumnIndex = 0;
			this.gtv.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																							 this.geniusTreeViewColonne1,
																							 this.geniusTreeViewColonne2,
																							 this.geniusTreeViewColonne3});
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 0);
			this.gtv.Name = "gtv";
			this.gtv.ShowHeader = true;
			this.gtv.Size = new System.Drawing.Size(304, 320);
			this.gtv.TabIndex = 0;
			this.gtv.Text = "geniusTreeView1";
			this.gtv.UseColumns = true;
			this.gtv.OnBeforeNodePainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnBeforeNodePainting);
			this.gtv.OnBeforeCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnBeforeCellPainting);
			this.gtv.OnInitNode += new Genius.Controls.TreeView.OnNodeDelegate(this.gtv_OnInitNode);
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Text = "Colonne 0";
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Text = "Colonne 1";
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Text = "Colonne 2";
			// 
			// TestDataSource
			// 
			this.Controls.Add(this.gtv);
			this.Name = "TestDataSource";
			this.Size = new System.Drawing.Size(304, 320);
			this.Load += new System.EventHandler(this.TestDataSource_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void TestDataSource_Load(object sender, System.EventArgs e)
		{
			gtv.Colors.SelectedColor = new GeniusLinearGradientBrush(Color.FromArgb(204,218,241));
			gtv.Colors.FocusedRectangleColor = new Pen(Color.FromArgb(49,106,197));
			gtv.Colors.SelectedTextColor = new GeniusLinearGradientBrush(Color.Black);
			gtv.Colors.UnFocusedRectangleColor = new Pen(Color.FromArgb(152,181,226));
			gtv.Colors.SelectedUnfocusedColor = new GeniusLinearGradientBrush(Color.FromArgb(229,236,248));
			ArrayList l = new ArrayList();
			l.AddRange("toto;titi;tata;tagada tsoin tsoin;VFR 800;SV 650".Split(';'));
			ArrayList l1 = new ArrayList();
			l1.AddRange("sub 1;sub 2;sub 3".Split(';'));
			l[3] = l1;

			gtv.DataSource = l ;
			gtv.SortTree(0, SortDirection.Ascending);
		}

		private void gtv_OnInitNode(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeEventArgs e)
		{
			if (e.Node.Data is ArrayList)
				e.Node.Text = "Node with sub-nodes";
			else
				e.Node.Text = e.Node.Data.ToString();
		}

		private void gtv_OnBeforeNodePainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			//
		}

		private void gtv_OnBeforeCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Info.DisplayColumn == 0)
			{
				if (e.Node.IsExpanded || (e.Node.NextSibling != null && e.Node.Level == 2))
					e.Info.CellGridLines = Lines.Vertical;
				if (( e.Node.Level == 2 && e.Node.NextSibling == null))
					e.Info.CellGridLines = Lines.Vertical | Lines.Bottom;
			}
		}
	}
}
