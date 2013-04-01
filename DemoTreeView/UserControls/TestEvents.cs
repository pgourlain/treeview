using Genius.Controls.TreeView;

namespace DemoTreeView.UserControls
{
	/// <summary>
	/// Summary description for TestEvents.
	/// </summary>
	public class TestEvents : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox edResult;
		private Genius.Controls.TreeView.GeniusTreeView geniusTreeView1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestEvents()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.edResult = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 192);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(520, 112);
			this.panel1.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.edResult);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 32);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(520, 80);
			this.panel4.TabIndex = 1;
			// 
			// edResult
			// 
			this.edResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.edResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edResult.Location = new System.Drawing.Point(0, 0);
			this.edResult.Multiline = true;
			this.edResult.Name = "edResult";
			this.edResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.edResult.Size = new System.Drawing.Size(520, 80);
			this.edResult.TabIndex = 0;
			this.edResult.Text = "";
			this.edResult.WordWrap = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(520, 32);
			this.panel3.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(8, 6);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Clear";
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 189);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(520, 3);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.geniusTreeView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(520, 189);
			this.panel2.TabIndex = 2;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.geniusTreeView1.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.geniusTreeView1.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.geniusTreeView1.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.ElapsedHint = 500;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.Header.ImageList = null;
			this.geniusTreeView1.Header.MainColumnIndex = 0;
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																												  this.geniusTreeViewColonne1,
																												  this.geniusTreeViewColonne2,
																												  this.geniusTreeViewColonne3,
																												  this.geniusTreeViewColonne4});
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.ShowHeader = true;
			this.geniusTreeView1.Size = new System.Drawing.Size(520, 189);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.OnBeforeSelect += new Genius.Controls.TreeView.OnSelectDelegate(this.geniusTreeView1_OnBeforeSelect);
			this.geniusTreeView1.OnCellMouseLeave += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.geniusTreeView1_OnCellMouseLeave);
			this.geniusTreeView1.OnCellMouseDown += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.geniusTreeView1_OnCellMouseDown);
			this.geniusTreeView1.OnBeforeExpand += new Genius.Controls.TreeView.OnExpandDelegate(this.geniusTreeView1_OnBeforeExpand);
			this.geniusTreeView1.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.geniusTreeView1_OnGetNodeText);
			this.geniusTreeView1.OnBeforeCollapse += new Genius.Controls.TreeView.OnCollapseDelegate(this.geniusTreeView1_OnBeforeCollapse);
			this.geniusTreeView1.OnAfterSelect += new Genius.Controls.TreeView.OnSelectedDelegate(this.geniusTreeView1_OnAfterSelect);
			this.geniusTreeView1.OnAfterCollapse += new Genius.Controls.TreeView.OnNodeDelegate(this.geniusTreeView1_OnAfterCollapse);
			this.geniusTreeView1.OnCellMouseUp += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.geniusTreeView1_OnCellMouseUp);
			this.geniusTreeView1.OnAfterExpand += new Genius.Controls.TreeView.OnNodeDelegate(this.geniusTreeView1_OnAfterExpand);
			this.geniusTreeView1.OnCellMouseEnter += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.geniusTreeView1_OnCellMouseEnter);
			this.geniusTreeView1.OnCellMouseMove += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.geniusTreeView1_OnCellMouseMove);
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
			// geniusTreeViewColonne4
			// 
			this.geniusTreeViewColonne4.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.Text = "Colonne 3";
			// 
			// TestEvents
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Name = "TestEvents";
			this.Size = new System.Drawing.Size(520, 304);
			this.Load += new System.EventHandler(this.TestEvents_Load);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void TestEvents_Load(object sender, System.EventArgs e)
		{
			geniusTreeView1.BeginUpdate();
			try
			{
				for (int i = 0; i < 20; i++)
				{
					INode aParent = geniusTreeView1.Add(null, "Node "  + i.ToString(), null);
					for(int j =0; j < 2;j++)
						geniusTreeView1.Add(aParent, "Child " + j.ToString(), null);
				}
			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}
		}

		private void geniusTreeView1_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			if (e.DisplayColumn > 0)
			{
				e.Text = string.Format("Cell({0},{1})", e.DisplayColumn, e.Node.Index);
			}
		}

		private void geniusTreeView1_OnBeforeSelect(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.CanSelectEventArgs e)
		{
			edResult.AppendText(string.Format("OnBeforeSelect({0}, {1})\r\n", e.DisplayColumn, e.Node.Index));
		}

		private void geniusTreeView1_OnAfterSelect(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.SelectedEventArgs e)
		{
			edResult.AppendText(string.Format("OnAfterSelect({0}, {1})\r\n", e.DisplayColumn, e.Node.Index));		
		}

		private void geniusTreeView1_OnBeforeExpand(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.ExpandEventArgs e)
		{
			edResult.AppendText(string.Format("OnBeforeExpand({0})\r\n", e.Node.Index));				
		}

		private void geniusTreeView1_OnAfterExpand(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeEventArgs e)
		{
			edResult.AppendText(string.Format("OnAfterExpand({0})\r\n", e.Node.Index));				
		}

		private void geniusTreeView1_OnBeforeCollapse(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.CollapseEventArgs e)
		{
			edResult.AppendText(string.Format("OnBeforeCollapse({0})\r\n", e.Node.Index));						
		}

		private void geniusTreeView1_OnAfterCollapse(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeEventArgs e)
		{
			edResult.AppendText(string.Format("OnAfterCollapse({0})\r\n", e.Node.Index));
		}

		private void geniusTreeView1_OnBeforeUnSelect(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.CanUnSelectEventArgs e)
		{
			edResult.AppendText(string.Format("OnBeforeUnSelect({0})\r\n", e.Node.Index));
		}

		private void geniusTreeView1_OnCellMouseEnter(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			edResult.AppendText(string.Format("OnCellMouseEnter({0}, {1})\r\n", e.DisplayColumn, e.Node.Index));		
		}

		private void geniusTreeView1_OnCellMouseLeave(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			edResult.AppendText(string.Format("OnCellMouseLeave({0}, {1})\r\n", e.DisplayColumn, e.Node.Index));				
		}

		private void geniusTreeView1_OnCellMouseDown(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			edResult.AppendText(string.Format("OnCellMouseDown({0}, {1})\r\n", e.DisplayColumn, e.Node.Index));				
		}

		private void geniusTreeView1_OnCellMouseMove(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			edResult.AppendText(string.Format("OnCellMouseMove({0}, {1})\r\n", e.DisplayColumn, e.Node.Index));				
		}

		private void geniusTreeView1_OnCellMouseUp(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
		
		}
	}
}
