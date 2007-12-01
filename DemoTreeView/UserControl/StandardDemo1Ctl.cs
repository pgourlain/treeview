using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Genius.Controls.NativeWindow;
using Genius.Controls.TreeView;

namespace Genius.Controls.UserControl
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
		private System.Windows.Forms.CheckBox checkBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(504, 40);
			this.panel1.TabIndex = 0;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(248, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "FullRowSelect";
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
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
			this.geniusTreeView1.AllowEdit = false;
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
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.geniusTreeView1.DefaultNodeHeight = 32;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.Header.MainColumnIndex = 0;
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.ShowHeader = true;
			this.geniusTreeView1.Size = new System.Drawing.Size(504, 296);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.OnBeforeCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.geniusTreeView1_OnDrawCellNode);
			this.geniusTreeView1.OnBeforeExpand += new Genius.Controls.TreeView.OnExpandDelegate(this.geniusTreeView1_OnBeginExpand);
			this.geniusTreeView1.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.geniusTreeView1_OnGetNodeText);
			this.geniusTreeView1.OnCreateHintWindow += new Genius.Controls.TreeView.OnCreateHintWindowDelegate(this.geniusTreeView1_OnCreateHintWindow);
			this.geniusTreeView1.OnGetHint += new Genius.Controls.TreeView.OnGetHintDelegate(this.geniusTreeView1_OnGetHint);
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
			geniusTreeView1.Colors.SelectedColor = new GeniusLinearGradientBrush(Color.FromArgb(204,218,241));
			geniusTreeView1.Colors.FocusedRectangleColor = new Pen(Color.FromArgb(49,106,197));
			geniusTreeView1.Colors.SelectedTextColor = new GeniusLinearGradientBrush(Color.Black);
			geniusTreeView1.Colors.UnFocusedRectangleColor = new Pen(Color.FromArgb(152,181,226));
			geniusTreeView1.Colors.SelectedUnfocusedColor = new GeniusLinearGradientBrush(Color.FromArgb(229,236,248));
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
			Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream("DemoTreeView.images.fond1.jpg");

			Image bmp = Bitmap.FromStream(stm);
			

			geniusTreeView1.Header.Colonnes.Clear();
			GeniusTreeViewColonne col = geniusTreeView1.Header. Add();
			col.AllowClick = false;
			col.BackColor = new GeniusLinearGradientBrush(Color.White, Color.LightBlue, 90);
			col.ForeColor = new GeniusLinearGradientBrush(Color.White, Color.Black, 90);
			col.Font = new Font("Tahoma", 13, FontStyle.Bold | FontStyle.Italic);
			col.Text = "Image file name";
			col.Width = 218;
			col = geniusTreeView1.Header.Add();
			col.AllowClick = false;
			col.Text = "Thumbnail";
			col.Width = 160;
			col = geniusTreeView1.Header.Add();
			col.AllowClick = false;
			col.Text = "Properties";
			col.Width = 120;	
			TextureBrush br = new TextureBrush(bmp, WrapMode.Tile);
			br.RotateTransform(25);
			//br.ScaleTransform(2,2,MatrixOrder.Append);
			col.BackColor = new GeniusLinearGradientBrush(br);
			geniusTreeView1.DefaultNodeHeight = 32;
			geniusTreeView1.Colors.GridLinesColor = new Pen(Color.LightGray, 1);
			geniusTreeView1.Header.MainColumnIndex = 0;
		}

		private void geniusTreeView1_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			if (geniusTreeView1.Header.DisplayIndexToIndex(e.DisplayColumn) == 2)
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

		private void geniusTreeView1_OnDrawCellNode(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			int colindex;
			colindex = Sender.Header.DisplayIndexToIndex(e.Info.DisplayColumn);
			DataNodeImage data = e.Node.Data as DataNodeImage;
			if (data != null)
			{
				if (colindex == 1)
				{
					e.Info.DefaultDrawing = false;
					LoadBitmap(data);
					//e.graphics.DrawImage(data.Bmp, e.CellRect);
					
					Rectangle destRect = new Rectangle(e.Info.NodeRect.Location, data.Bmp.Size);
					int offsetx = (e.Info.NodeRect.Width - data.Bmp.Size.Width) / 2;
					destRect.Offset(offsetx, 0);
					e.Info.graphics.DrawImage(data.Bmp, destRect, 0,0,data.Bmp.Size.Width, data.Bmp.Size.Height, GraphicsUnit.Pixel);
					
				}
			}
			else if (colindex == 1)
			{
				bool selected = false;
				e.Info.DefaultDrawing = false;
				System.Random rnd = new Random();
				Rectangle r = e.Info.NodeRect;
				if ((e.Node.State & NodeState.Selected) == NodeState.Selected && geniusTreeView1.SelectedColumn == 1)
				{
					selected = true;
					geniusTreeView1.DrawSelectedRectangle(e.Info.graphics, e.Info.NodeRect, true,e.Info);
				}
				r.Y += 1;
				r.Height -= 1;
				r.Inflate(-2,-5);
				r.Width = rnd.Next(r.Width) + 1; //car je ne veux pas de zéro
				int pourcent = (int)(((double)r.Width / (double)(e.Info.NodeRect.Width - 4)) * 100);
				using (GeniusLinearGradientBrush br = new GeniusLinearGradientBrush(Color.Blue, Color.LightBlue, 90))
				{
					using (Brush b = br.GetBrush(r))
					{
						/*
						Pen p = new Pen(b, r.Height);
						p.DashCap = DashCap.Flat;
						p.DashStyle = DashStyle.Custom;
						p.DashPattern = new float[]{0,10,11,20};
						e.graphics.DrawLine(p, r.Left+1, r.Top + r.Height / 2, r.Right, r.Top + r.Height / 2); 
						*/
						
						e.Info.graphics.FillRectangle(b, r);
						r.Width = e.Info.NodeRect.Width - 4;
						if (r.Width == 0)
							r.Width = 1;
						e.Info.graphics.DrawRectangle(selected ? Pens.White : Pens.Black, r);
						StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
						sf.LineAlignment = StringAlignment.Center;
						sf.Alignment = StringAlignment.Center;
						sf.Trimming = StringTrimming.EllipsisCharacter;
						e.Info.graphics.DrawString(String.Format("{0} %", pourcent), this.Font, 
												pourcent >= 55 || selected ? Brushes.White : Brushes.Black, 
												e.Info.NodeRect, sf);
					}
				}
			}
		}

		private bool OnGetThumbnail(/*object o, IntPtr method*/)
		{
			return true;
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			geniusTreeView1.FullRowSelect = checkBox1.Checked;
		}

		private void geniusTreeView1_OnCreateHintWindow(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeHintWindowEventArgs e)
		{
            if (e.HintWindow == null)
			    e.HintWindow = new HintImageWindow(geniusTreeView1);
		}

		private void geniusTreeView1_OnGetHint(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeGetHintEventArgs e)
		{
			if (e.Node.Data is DataNodeImage)
			{
				if (e.DisplayColumn == 1)
					e.HintText = (e.Node.Data as DataNodeImage).FileName;
			}
		}
	}

	internal class HintImageWindow : BaseHintWindow
	{
		Image FImg;
		public HintImageWindow(GeniusTreeView gtv) : base (gtv)
		{
			
		}

		protected override Size CalculateSize(Graphics g)
		{
			FImg = null;
			if (this.Node != null)
			{
				DataNodeImage data = this.Node.Data as DataNodeImage;
				if (data != null)
				{
					using (Bitmap bmp = new Bitmap(data.FileName))
					{
						double ratio = 300.0f / bmp.Size.Height;
						FImg = bmp.GetThumbnailImage((int)(bmp.Size.Width * ratio), 300, 
							new System.Drawing.Image.GetThumbnailImageAbort(OnGetThumbnail), IntPtr.Zero);
						return FImg.Size;
					}
				}
				else
					return base.CalculateSize(g);
			}
			else
				return base.CalculateSize(g);
		}

		private bool OnGetThumbnail(/*object o, IntPtr method*/)
		{
			return true;
		}

		protected override void DoPaint(Graphics g)
		{
			DataNodeImage data = this.Node.Data as DataNodeImage;
			if (FImg != null)
			{
				Rectangle destRect = this.ClientRectangle;
				g.DrawImage(FImg, destRect, 0,0, FImg.Size.Width, FImg.Size.Height, GraphicsUnit.Pixel);	
			}
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
