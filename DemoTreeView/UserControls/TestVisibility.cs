using System;
using System.Diagnostics;
using Genius.Controls.TreeView;

namespace DemoTreeView.UserControls
{
	/// <summary>
	/// Summary description for TestVisibility.
	/// </summary>
	public class TestVisibility : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel pnlHaut;
		private System.Windows.Forms.Panel panel1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private System.Windows.Forms.RadioButton rbAll;
		private System.Windows.Forms.RadioButton rbPair;
		private System.Windows.Forms.RadioButton rbImpair;
		private Genius.Controls.TreeView.GeniusTreeView gtv;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestVisibility()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			Genius.Controls.TreeView.Colors.Themes.GeniusTreeViewTheme(gtv.Colors);
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
			this.pnlHaut = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.rbImpair = new System.Windows.Forms.RadioButton();
			this.rbPair = new System.Windows.Forms.RadioButton();
			this.rbAll = new System.Windows.Forms.RadioButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.pnlHaut.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHaut
			// 
			this.pnlHaut.Controls.Add(this.button1);
			this.pnlHaut.Controls.Add(this.rbImpair);
			this.pnlHaut.Controls.Add(this.rbPair);
			this.pnlHaut.Controls.Add(this.rbAll);
			this.pnlHaut.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHaut.Location = new System.Drawing.Point(0, 0);
			this.pnlHaut.Name = "pnlHaut";
			this.pnlHaut.Size = new System.Drawing.Size(376, 64);
			this.pnlHaut.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(264, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// rbImpair
			// 
			this.rbImpair.Checked = true;
			this.rbImpair.Location = new System.Drawing.Point(240, 16);
			this.rbImpair.Name = "rbImpair";
			this.rbImpair.TabIndex = 2;
			this.rbImpair.TabStop = true;
			this.rbImpair.Text = "Noeud Impairs";
			this.rbImpair.CheckedChanged += new System.EventHandler(this.rbImpair_CheckedChanged);
			// 
			// rbPair
			// 
			this.rbPair.Location = new System.Drawing.Point(128, 16);
			this.rbPair.Name = "rbPair";
			this.rbPair.TabIndex = 1;
			this.rbPair.Text = "Noeuds Pairs";
			this.rbPair.CheckedChanged += new System.EventHandler(this.rbPair_CheckedChanged);
			// 
			// rbAll
			// 
			this.rbAll.Location = new System.Drawing.Point(8, 16);
			this.rbAll.Name = "rbAll";
			this.rbAll.TabIndex = 0;
			this.rbAll.Text = "Tous";
			this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.gtv);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 64);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(376, 264);
			this.panel1.TabIndex = 1;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AutoSort = false;
			this.gtv.BackColor = System.Drawing.SystemColors.Window;
			this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gtv.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.gtv.ContextMenu = this.contextMenu1;
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.ElapsedHint = 500;
			this.gtv.Header.AllowDrag = true;
			this.gtv.Header.AutoSizeColIndex = 1;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.ImageList = null;
			this.gtv.Header.MainColumnIndex = 0;
			this.gtv.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																									  this.geniusTreeViewColonne1,
																									  this.geniusTreeViewColonne2,
																									  this.geniusTreeViewColonne3});
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 0);
			this.gtv.Name = "gtv";
			this.gtv.ShowHeader = true;
			this.gtv.Size = new System.Drawing.Size(376, 264);
			this.gtv.TabIndex = 0;
			this.gtv.Text = "geniusTreeView1";
			this.gtv.UseColumns = true;
			this.gtv.OnInitNode += new Genius.Controls.TreeView.OnNodeDelegate(this.gtv_OnInitNode);
			this.gtv.OnGetNodeValue += new Genius.Controls.TreeView.OnGetNodeValueForComparisonDelegate(this.gtv_OnGetNodeValue);
			this.gtv.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.gtv_OnGetNodeText);
			this.gtv.OnGetHint += new Genius.Controls.TreeView.OnGetHintDelegate(this.gtv_OnGetHint);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Cacher";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
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
			// TestVisibility
			// 
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlHaut);
			this.Name = "TestVisibility";
			this.Size = new System.Drawing.Size(376, 328);
			this.Load += new System.EventHandler(this.TestVisibility_Load);
			this.pnlHaut.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void rbAll_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbAll.Checked)
				ShowAll();
		}

		private void TestVisibility_Load(object sender, System.EventArgs e)
		{
			for (int i = 0; i < 10; i++)
			{
				INode parent = gtv.Add(null,
				                       String.Format("Node {0}", i), i);
				for (int j = 0; j < 10; j++)
				{
					INode child = gtv.Add(parent,
						String.Format("Node {0}.{1}", i, j), i * j);
				}
			}		
			gtv.Header.MoveColumnTo(2, 0);
		}

		private void rbPair_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbPair.Checked)
				ShowPairs();
		}

		private void rbImpair_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbImpair.Checked)
				ShowImpairs();
		}
		private void ShowAll()
		{
			gtv.BeginUpdate();
			try
			{
				foreach (INode n in
					gtv.Enumerable.GetNodes(false))
				{
					foreach (INode child in
						n.Enumerable.GetNodes(false))
					{
						gtv.SetVisibleNode(child,
							true);
					}
				}
			}
			finally
			{
				gtv.EndUpdate();
			}
		}

		private void ShowPairs()
		{
			gtv.BeginUpdate();
			try
			{ 
				foreach (INode n in
					gtv.Enumerable.GetNodes(false))
				{
					foreach (INode child in
						n.Enumerable.GetNodes(false))
					{
						int value =
							(int)child.Data;
						gtv.SetVisibleNode(child,
							(value % 2 == 0));
					}
				}
			}
			finally
			{
				gtv.EndUpdate();
			} 
		}

		private void ShowImpairs()
		{
			gtv.BeginUpdate();
			try
			{
				foreach (INode n in
					gtv.Enumerable.GetNodes(false))
				{
					foreach (INode child in
						n.Enumerable.GetNodes(false))
					{
						int value =
							(int)child.Data;
						gtv.SetVisibleNode(child,
							(value % 2 != 0));
					}
				}
			}
			finally
			{
				gtv.EndUpdate();
			} 
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			foreach (INode n in gtv.Enumerable.GetNodes(true) )
			{
				Debug.WriteLine(n.Text);
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			gtv.SetVisibleNode(gtv.SelectedNode, false);
		}

		private void gtv_OnInitNode(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeEventArgs e)
		{
			int value = (int)e.Node.Data;
			if (value % 2 == 0)
				e.Node.State &= (~NodeState.Visible);
		}

		private System.IComparable gtv_OnGetNodeValue(Genius.Controls.TreeView.INode A, int aDisplayColumn)
		{
			return A.Text;
		}

		private void gtv_OnGetHint(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeGetHintEventArgs e)
		{
			e.HintText = string.Format("Class {0} {1}", e.Node.GetType().FullName, Environment.NewLine);
			if (e.Node.Data != null)
				e.HintText += String.Format("User data type : {0}\r\nUser data value : {1}", e.Node.Data.GetType().ToString(), e.Node.Data);
		}

		private void gtv_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			int aCol = gtv.Header.DisplayIndexToIndex(e.DisplayColumn);
			if (aCol == 0)
			{
				e.Text = (e.Node.Level * 10 + e.Node.Index).ToString();
			}
		}

	}
}
