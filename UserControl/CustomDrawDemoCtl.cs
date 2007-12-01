using System.Drawing;

namespace Genius.Controls.UserControl
{
	/// <summary>
	/// Summary description for CustomDrawDemo.
	/// </summary>
	public class CustomDrawDemoCtl : System.Windows.Forms.UserControl
	{
		private Genius.Controls.TreeView.GeniusTreeView geniusTreeView1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne5;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne6;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne7;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne8;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne9;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne10;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomDrawDemoCtl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			
			Bitmap bitmap = new Bitmap("fond1.jpg");
			TextureBrush br = new TextureBrush(bitmap);
			geniusTreeView1.HeaderColonnes[2].BackColor = new GeniusLinearGradientBrush(br);

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
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne5 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne6 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne7 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne8 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne9 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne10 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.SuspendLayout();
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.FullRowSelect = true;
			this.geniusTreeView1.Header.AllowDrag = true;
			this.geniusTreeView1.Header.FixedColumnCount = 2;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																										 this.geniusTreeViewColonne1,
																										 this.geniusTreeViewColonne2,
																										 this.geniusTreeViewColonne3,
																										 this.geniusTreeViewColonne4,
																										 this.geniusTreeViewColonne5,
																										 this.geniusTreeViewColonne6,
																										 this.geniusTreeViewColonne7,
																										 this.geniusTreeViewColonne8,
																										 this.geniusTreeViewColonne9,
																										 this.geniusTreeViewColonne10});
			this.geniusTreeView1.ImageList = null;
			this.geniusTreeView1.ImageStateList = null;
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.SearchDirection = Genius.Controls.TreeView.SearchDirectionEnum.Forward;
			this.geniusTreeView1.ShowHeader = true;
			this.geniusTreeView1.Size = new System.Drawing.Size(480, 384);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.OnGetHint += new Genius.Controls.TreeView.OnGetHintDelegate(this.geniusTreeView1_OnGetHint);
			this.geniusTreeView1.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.geniusTreeView1_OnGetNodeText);
			this.geniusTreeView1.OnBeforeSelect += new Genius.Controls.TreeView.OnSelectDelegate(this.geniusTreeView1_OnBeginSelect);
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224))), System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Text = "Fixe 1";
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224))), System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Text = "Fixe 2";
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Text = "Colonne 2";
			// 
			// geniusTreeViewColonne4
			// 
			this.geniusTreeViewColonne4.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne4.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne4.Text = "Colonne 3";
			// 
			// geniusTreeViewColonne5
			// 
			this.geniusTreeViewColonne5.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne5.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne5.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne5.Text = "Colonne 4";
			// 
			// geniusTreeViewColonne6
			// 
			this.geniusTreeViewColonne6.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne6.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne6.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne6.Text = "Colonne 5";
			// 
			// geniusTreeViewColonne7
			// 
			this.geniusTreeViewColonne7.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne7.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne7.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne7.Text = "Colonne 6";
			// 
			// geniusTreeViewColonne8
			// 
			this.geniusTreeViewColonne8.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne8.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne8.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne8.Text = "Colonne 7";
			// 
			// geniusTreeViewColonne9
			// 
			this.geniusTreeViewColonne9.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne9.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne9.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne9.Text = "Colonne 8";
			// 
			// geniusTreeViewColonne10
			// 
			this.geniusTreeViewColonne10.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne10.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne10.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne10.Text = "Colonne 9";
			// 
			// CustomDrawDemoCtl
			// 
			this.Controls.Add(this.geniusTreeView1);
			this.Name = "CustomDrawDemoCtl";
			this.Size = new System.Drawing.Size(480, 384);
			this.Load += new System.EventHandler(this.CustomDrawDemoCtl_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void CustomDrawDemoCtl_Load(object sender, System.EventArgs e)
		{
			geniusTreeView1.BeginUpdate();
			try
			{
				for (int i = 0; i < 50; i++)
				{
					geniusTreeView1.Add(null, "Node "+i.ToString(), null);
				}
				geniusTreeView1.Add(null, "a", null);
				geniusTreeView1.Add(null, "ab", null);
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
				e.Text = "Cell " + e.Node.Index.ToString() + ":" + e.DisplayColumn.ToString();
			}
		}

		private void geniusTreeView1_OnBeginSelect(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.CanSelectEventArgs e)
		{
			e.CanSelect = (e.Node.Index != 2);
		}

		private void geniusTreeView1_OnGetHint(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeGetHintEventArgs e)
		{
			if (e.DisplayColumn == 2)
			{
				e.HintText = "coucou";
			}
		}
	}
}
