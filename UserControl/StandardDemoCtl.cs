using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using Genius.Controls.TreeView;

namespace Genius.Controls.UserControls
{
	/// <summary>
	/// Summary description for StandardDemoCtl.
	/// </summary>
	public class StandardDemoCtl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Genius.Controls.TreeView.GeniusTreeView geniusTreeView1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lblAddResult;
		private System.Windows.Forms.TextBox textBoxAdd;
		private System.Windows.Forms.Button bClear;
		private System.Windows.Forms.Button bAdd;
		private System.Windows.Forms.Panel pnlContext;
		private System.Windows.Forms.CheckBox cbHasCheck;
		private System.Windows.Forms.CheckBox cbHasChildren;
		private System.Windows.Forms.CheckBox cbHasSignaled;
		private System.Windows.Forms.TextBox textboxImageIndex;
		private System.Windows.Forms.TextBox textboxImageStateIndex;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList imageList2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
		private System.ComponentModel.IContainer components;

		public StandardDemoCtl()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(StandardDemoCtl));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlContext = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textboxImageStateIndex = new System.Windows.Forms.TextBox();
			this.textboxImageIndex = new System.Windows.Forms.TextBox();
			this.cbHasSignaled = new System.Windows.Forms.CheckBox();
			this.cbHasChildren = new System.Windows.Forms.CheckBox();
			this.cbHasCheck = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblAddResult = new System.Windows.Forms.Label();
			this.textBoxAdd = new System.Windows.Forms.TextBox();
			this.bClear = new System.Windows.Forms.Button();
			this.bAdd = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.panel1.SuspendLayout();
			this.pnlContext.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pnlContext);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(208, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(168, 280);
			this.panel1.TabIndex = 0;
			// 
			// pnlContext
			// 
			this.pnlContext.Controls.Add(this.label2);
			this.pnlContext.Controls.Add(this.label1);
			this.pnlContext.Controls.Add(this.textboxImageStateIndex);
			this.pnlContext.Controls.Add(this.textboxImageIndex);
			this.pnlContext.Controls.Add(this.cbHasSignaled);
			this.pnlContext.Controls.Add(this.cbHasChildren);
			this.pnlContext.Controls.Add(this.cbHasCheck);
			this.pnlContext.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContext.Enabled = false;
			this.pnlContext.Location = new System.Drawing.Point(0, 0);
			this.pnlContext.Name = "pnlContext";
			this.pnlContext.Size = new System.Drawing.Size(168, 208);
			this.pnlContext.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 128);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "StateImageIndex";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "ImageIndex";
			// 
			// textboxImageStateIndex
			// 
			this.textboxImageStateIndex.Location = new System.Drawing.Point(8, 144);
			this.textboxImageStateIndex.Name = "textboxImageStateIndex";
			this.textboxImageStateIndex.Size = new System.Drawing.Size(40, 20);
			this.textboxImageStateIndex.TabIndex = 4;
			this.textboxImageStateIndex.Text = "-1";
			this.textboxImageStateIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxImageStateIndex_KeyDown);
			// 
			// textboxImageIndex
			// 
			this.textboxImageIndex.Location = new System.Drawing.Point(8, 104);
			this.textboxImageIndex.Name = "textboxImageIndex";
			this.textboxImageIndex.Size = new System.Drawing.Size(40, 20);
			this.textboxImageIndex.TabIndex = 3;
			this.textboxImageIndex.Text = "-1";
			this.textboxImageIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxImageIndex_KeyDown);
			// 
			// cbHasSignaled
			// 
			this.cbHasSignaled.Location = new System.Drawing.Point(8, 56);
			this.cbHasSignaled.Name = "cbHasSignaled";
			this.cbHasSignaled.TabIndex = 2;
			this.cbHasSignaled.Text = "Surligné ?";
			this.cbHasSignaled.CheckedChanged += new System.EventHandler(this.cbHasSignaled_CheckedChanged);
			// 
			// cbHasChildren
			// 
			this.cbHasChildren.Location = new System.Drawing.Point(8, 32);
			this.cbHasChildren.Name = "cbHasChildren";
			this.cbHasChildren.TabIndex = 1;
			this.cbHasChildren.Text = "Children ?";
			this.cbHasChildren.CheckedChanged += new System.EventHandler(this.cbHasChildren_CheckedChanged);
			// 
			// cbHasCheck
			// 
			this.cbHasCheck.Location = new System.Drawing.Point(8, 8);
			this.cbHasCheck.Name = "cbHasCheck";
			this.cbHasCheck.TabIndex = 0;
			this.cbHasCheck.Text = "CheckBox ?";
			this.cbHasCheck.CheckedChanged += new System.EventHandler(this.cbHasCheck_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lblAddResult);
			this.panel3.Controls.Add(this.textBoxAdd);
			this.panel3.Controls.Add(this.bClear);
			this.panel3.Controls.Add(this.bAdd);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 208);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(168, 72);
			this.panel3.TabIndex = 1;
			// 
			// lblAddResult
			// 
			this.lblAddResult.Location = new System.Drawing.Point(80, 8);
			this.lblAddResult.Name = "lblAddResult";
			this.lblAddResult.Size = new System.Drawing.Size(80, 23);
			this.lblAddResult.TabIndex = 8;
			this.lblAddResult.Text = "label1";
			// 
			// textBoxAdd
			// 
			this.textBoxAdd.Location = new System.Drawing.Point(8, 8);
			this.textBoxAdd.Name = "textBoxAdd";
			this.textBoxAdd.Size = new System.Drawing.Size(64, 20);
			this.textBoxAdd.TabIndex = 7;
			this.textBoxAdd.Text = "1000";
			// 
			// bClear
			// 
			this.bClear.Location = new System.Drawing.Point(88, 40);
			this.bClear.Name = "bClear";
			this.bClear.TabIndex = 6;
			this.bClear.Text = "Clear";
			this.bClear.Click += new System.EventHandler(this.bClear_Click);
			// 
			// bAdd
			// 
			this.bAdd.Location = new System.Drawing.Point(8, 40);
			this.bAdd.Name = "bAdd";
			this.bAdd.TabIndex = 5;
			this.bAdd.Text = "Add";
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.geniusTreeView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(208, 280);
			this.panel2.TabIndex = 1;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AllowDrag = true;
			this.geniusTreeView1.AllowDrop = true;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																										 this.geniusTreeViewColonne2,
																										 this.geniusTreeViewColonne3,
																										 this.geniusTreeViewColonne1,
																										 this.geniusTreeViewColonne4});
			this.geniusTreeView1.ImageList = this.imageList1;
			this.geniusTreeView1.ImageStateList = this.imageList2;
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.Size = new System.Drawing.Size(208, 280);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.OnAfterSelect += new Genius.Controls.TreeView.OnSelectedDelegate(this.geniusTreeView1_OnSelected);
			this.geniusTreeView1.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.geniusTreeView1_OnGetNodeText);
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.ImageIndex = 0;
			this.geniusTreeViewColonne2.Text = "Colonne 0";
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.ImageIndex = 0;
			this.geniusTreeViewColonne3.Text = "Colonne 1";
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.ImageIndex = 0;
			this.geniusTreeViewColonne1.Text = "Colonne 2";
			// 
			// geniusTreeViewColonne4
			// 
			this.geniusTreeViewColonne4.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.ImageIndex = 0;
			this.geniusTreeViewColonne4.Text = "Colonne 3";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// imageList2
			// 
			this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// StandardDemoCtl
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "StandardDemoCtl";
			this.Size = new System.Drawing.Size(376, 280);
			this.Load += new System.EventHandler(this.StandardDemoCtl_Load);
			this.panel1.ResumeLayout(false);
			this.pnlContext.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void StandardDemoCtl_Load(object sender, System.EventArgs e)
		{
		}

		private void geniusTreeView1_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			if (e.Text == null || e.Text.Length == 0)
				e.Text = "Node " + e.Node.Index.ToString();
		}

		private void bAdd_Click(object sender, System.EventArgs e)
		{
			geniusTreeView1.BeginUpdate();
			try
			{
				int nb = int.Parse(textBoxAdd.Text);
				long start = DateTime.Now.Ticks;
				for (int i =0; i < nb; i++)
				{
					INode n = geniusTreeView1.Add(null, null);
				}
				long end = DateTime.Now.Ticks;
				lblAddResult.Text = ((double)((end-start)/1000.0f)).ToString() + " ms";
				Debug.WriteLine(String.Format("temps : {0}", end-start));
			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}		
		}

		private void bClear_Click(object sender, System.EventArgs e)
		{
			geniusTreeView1.Clear();
			pnlContext.Enabled = false;
		}

		private void geniusTreeView1_OnSelected(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.SelectedEventArgs e)
		{
			pnlContext.Enabled = true;
			cbHasCheck.Checked = (e.Node.State & NodeState.HasCheck) == NodeState.HasCheck;
			cbHasChildren.Checked = (e.Node.State & NodeState.HasChildren) == NodeState.HasChildren;
			cbHasSignaled.Checked = (e.Node.State & NodeState.Signaled) == NodeState.Signaled;
			textboxImageIndex.Text = e.Node.ImageIndex.ToString();
			textboxImageStateIndex.Text = e.Node.ImageStateIndex.ToString();
		}

		private void cbHasCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			INode selected = geniusTreeView1.SelectedNode;
			if ( selected != null)
			{
				if ((sender as CheckBox).Checked)
					selected.State |= NodeState.HasCheck;
				else
					selected.State &= (~NodeState.HasCheck);
			}
		}

		private void cbHasChildren_CheckedChanged(object sender, System.EventArgs e)
		{
			INode selected = geniusTreeView1.SelectedNode;
			if ( selected != null)
			{
				if ((sender as CheckBox).Checked)
					selected.State |= NodeState.HasChildren;
				else
					selected.State &= (~NodeState.HasChildren);
			}		
		}

		private void cbHasSignaled_CheckedChanged(object sender, System.EventArgs e)
		{
			INode selected = geniusTreeView1.SelectedNode;
			if ( selected != null)
			{
				if ((sender as CheckBox).Checked)
					selected.State |= NodeState.Signaled;
				else
					selected.State &= (~NodeState.Signaled);
			}		
		}

		private void textboxImageIndex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				e.Handled = true;
				int imgIndex = -1;
				try
				{
					int value = int.Parse((sender as TextBox).Text);
					if (value > 2 || value < -1)
						value = -1;
					imgIndex = value;
				}
				catch {}
				INode selected = geniusTreeView1.SelectedNode;
				if ( selected != null)
				{
					selected.ImageIndex = imgIndex;
				}		
			}
		}

		private void textboxImageStateIndex_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				e.Handled = true;
				int imgIndex = -1;
				try
				{
					int value = int.Parse((sender as TextBox).Text);
					if (value > 2 || value < -1)
						value = -1;
					imgIndex = value;
				}
				catch {}
				INode selected = geniusTreeView1.SelectedNode;
				if ( selected != null)
				{
					selected.ImageStateIndex = imgIndex;
				}		
			}

		}
	}
}
