using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Genius.Controls.TreeView;

namespace Genius.Controls.UserControls
{
	/// <summary>
	/// Summary description for StandardDemo1Ctl.
	/// </summary>
	public class StandardDemo1Ctl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private Genius.Controls.TreeView.GeniusTreeView geniusTreeView1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
		private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
		private System.ComponentModel.IContainer components;

		public StandardDemo1Ctl()
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
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(504, 40);
			this.panel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "List Image(s)";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.geniusTreeView1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(504, 296);
			this.panel2.TabIndex = 1;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.geniusTreeView1.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.geniusTreeView1.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.GrayText, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0))), 2F);
			this.geniusTreeView1.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.geniusTreeView1.DefaultNodeHeight = 32;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
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
			this.geniusTreeView1.Size = new System.Drawing.Size(504, 296);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.UseKeyTab = true;
			this.geniusTreeView1.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.geniusTreeView1_OnGetNodeText);
			this.geniusTreeView1.OnBeforeExpand += new Genius.Controls.TreeView.OnExpandDelegate(this.geniusTreeView1_OnBeginExpand);
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Text = "coucou";
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
			// StandardDemo1Ctl
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "StandardDemo1Ctl";
			this.Size = new System.Drawing.Size(504, 336);
			this.Load += new System.EventHandler(this.StandardDemo1Ctl_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			geniusTreeView1.Clear();
			geniusTreeView1.BeginUpdate();
			try
			{
				INode n = geniusTreeView1.Add(null, new DataNode("c:\\"));
				n.Text = "c:\\";
				n.State |= NodeState.HasChildren;
			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}
		}

		private void StandardDemo1Ctl_Load(object sender, System.EventArgs e)
		{
		}

		private void geniusTreeView1_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			if (Sender.Header.DisplayIndexToIndex(e.DisplayColumn) == 2)
			{
				DataNodeImage data = e.Node.Data as DataNodeImage;
				if (data != null)
				{
					LoadBitmap(data);
					if (data.Bmp != null)
						e.Text = data.size.ToString();
				}
			}
		}

		private void FillFileNode(INode n, string aDir, string afilter)
		{
			foreach (string file in Directory.GetFiles(aDir, afilter))
			{
				INode child = geniusTreeView1.Add(n, new DataNodeImage(file));
				child.Text = Path.GetFileName(file);
				child.Height = 105;
			}
		}
		private void FillNode(INode n, string aDir)
		{
			geniusTreeView1.BeginUpdate();
			try
			{
				try
				{
					foreach (string dir in Directory.GetDirectories(aDir))
					{
						INode child = geniusTreeView1.Add(n, new DataNode(dir));
						child.Text = Path.GetFileName(dir);
						child.State |= NodeState.HasChildren;
					}
				FillFileNode(n, aDir, "*.jpg");
				FillFileNode(n, aDir, "*.jpeg");
				FillFileNode(n, aDir, "*.bmp");
				}
				catch
				{}
			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}
		}

		private void geniusTreeView1_OnBeginExpand(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.ExpandEventArgs e)
		{
			DataNode aDir = e.Node.Data as DataNode;
			if (e.Node.Count == 0)
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					FillNode(e.Node, aDir.FileName);
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void LoadBitmap(DataNodeImage data)
		{
			if (data.Bmp == null && File.Exists(data.FileName))
			{
				Cursor = Cursors.WaitCursor;
				try
				{
					using (Bitmap bmp = new Bitmap(data.FileName))
					{
						double ratio = 105.0f / bmp.Size.Height;
						data.Bmp = bmp.GetThumbnailImage((int)(bmp.Size.Width * ratio), 105, 
							new System.Drawing.Image.GetThumbnailImageAbort(OnGetThumbnail), IntPtr.Zero);
						data.size = bmp.Size;
					}
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private bool OnGetThumbnail(/*object o, IntPtr method*/)
		{
			return true;
		}
	}

	class DataNode
	{
		public string FileName;

		public DataNode(string aFileName)
		{
			FileName = aFileName;
		}
	}

	class DataNodeImage : DataNode
	{
		public Image Bmp;
		public Size size;
		public DataNodeImage(string aFilename) : base(aFilename)
		{
			Bmp = null;
		}
	}

}
