using System;
using System.Drawing;
using Genius.Controls.TreeView;

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
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomDrawDemoCtl()
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
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.SuspendLayout();
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																										 this.geniusTreeViewColonne1,
																										 this.geniusTreeViewColonne2,
																										 this.geniusTreeViewColonne3});
			this.geniusTreeView1.ImageList = null;
			this.geniusTreeView1.ImageStateList = null;
			this.geniusTreeView1.Indentation = 10;
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.SearchDirection = Genius.Controls.TreeView.SearchDirectionEnum.Forward;
			this.geniusTreeView1.ShowHeader = true;
			this.geniusTreeView1.Size = new System.Drawing.Size(480, 384);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.OnBeforeCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.geniusTreeView1_OnBeforeCellPainting);
			this.geniusTreeView1.OnAfterCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.geniusTreeView1_OnAfterCellPainting);
			this.geniusTreeView1.OnBeforeNodePainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.geniusTreeView1_OnBeforeNodePainting);
			this.geniusTreeView1.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.geniusTreeView1_OnGetNodeText);
			this.geniusTreeView1.OnBeforeSelect += new Genius.Controls.TreeView.OnSelectDelegate(this.geniusTreeView1_OnBeginSelect);
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.ImageIndex = 0;
			this.geniusTreeViewColonne1.Text = "Colonne 0";
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.ImageIndex = 0;
			this.geniusTreeViewColonne2.Text = "Colonne 1";
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.ImageIndex = 0;
			this.geniusTreeViewColonne3.Text = "Colonne 2";
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

		class Group
		{
			
		}

		class GroupTotal
		{
			public double value;	
		}

		class GroupItem
		{
			public double value;
		}

		private void CustomDrawDemoCtl_Load(object sender, System.EventArgs e)
		{
			geniusTreeView1.BeginUpdate();
			try
			{
				Random r = new Random();
				for (int i = 0; i < 10; i++)
				{
					INode parent = geniusTreeView1.Add(null, "Groupe " + i.ToString(), new Group());
					parent.Height *= 2;
					geniusTreeView1.ExpandCollapseNode(parent);
					double totalValue = 0;
					for (int j =0; j < 10; j++ )
					{
						object o = null;
						double value = r.NextDouble() * (r.NextDouble()*100);
						value = Math.Round(value, 4);
						totalValue += value;
						if (j < 9)
						{
							o = new GroupItem();
							((GroupItem)o).value = value;

						}
						else
						{
							o = new GroupTotal();
							((GroupTotal)o).value = totalValue;
						}
						INode n = geniusTreeView1.Add(parent, "Node " + j.ToString(), o);
					}
				}
				geniusTreeView1.DefaultDrawingOption |= DrawingOption.HideTreeLines ;
				//geniusTreeView1.DefaultDrawingOption &= (~DrawingOption.ShowHorzLines);
				geniusTreeView1.FullRowSelect = true;
			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}
		}

		private void geniusTreeView1_OnBeforeNodePainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Node.Data is Group)
			{
				Graphics g = e.Info.graphics;
				using (Font f = new Font(this.Font.Name, this.Font.Size, FontStyle.Bold))
				{
					StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);
					sf.LineAlignment = StringAlignment.Center;
					g.DrawString(e.Node.Text, f, Brushes.Black, e.Info.NodeRect,sf);
				}
				Rectangle r = e.Info.NodeRect;
				r.Width /= 2;
				GeniusLinearGradientBrush glb = new GeniusLinearGradientBrush(Color.LightBlue, Color.White);
				using (Brush br = glb.GetBrush(r))
				{
					using (Pen p = new Pen(br, 1))
					{
						g.DrawLine(p, r.X, r.Bottom-1, r.Right-1, r.Bottom-1);						
					}
				}
				e.Info.Font = null;
				e.Info.DefaultDrawing = false;
			}
			else
			{
				if (e.Node.Data is GroupTotal)
				{
					e.Info.DrawingOptions &= ~DrawingOption.ShowGridLines;
					e.Info.Font = new Font(this.geniusTreeView1.Font.Name, this.geniusTreeView1.Font.Size, FontStyle.Bold);
				}
				e.Info.DefaultDrawing = true;
			}
		}

		private void geniusTreeView1_OnBeforeCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Node.Index != 9)
			{
				if (e.Info.DisplayColumn != 0)
					e.Info.StringFormat.Alignment = StringAlignment.Far;
				if ((e.Info.DisplayColumn % 2 == 0 && e.Node.Index % 2 == 0) ||
					(e.Info.DisplayColumn % 2 == 1 && e.Node.Index % 2 == 1))
				{
					e.Info.BackColor = new GeniusLinearGradientBrush(Color.LightBlue, Color.White);				
				}
				else
					e.Info.BackColor = GeniusLinearGradientBrush.Empty;
			}
			else
			{
				e.Info.StringFormat.Alignment = StringAlignment.Far;
				e.Info.BackColor = new GeniusLinearGradientBrush(Color.WhiteSmoke);
				if (e.Info.DisplayColumn < 2)
					e.Info.DefaultDrawing = false;
				if (e.Info.DisplayColumn >= 1)
					e.Info.DrawingOptions |= DrawingOption.ShowGridLines;
			}
		}

		private void geniusTreeView1_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			if (e.DisplayColumn == 2)
			{
				GroupItem item = e.Node.Data as GroupItem;
				if (item != null)
					e.Text = item.value.ToString();
				else
				{
					GroupTotal tot = e.Node.Data as GroupTotal;
					if (tot != null)
						e.Text = tot.value.ToString();
				}

			}
		}

		private void geniusTreeView1_OnAfterCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Node.Index == 9)
			{
				RectangleF r = e.Info.graphics.ClipBounds;
				Rectangle rclip = e.Info.NodeRect;
				rclip.Inflate(0,1);
				e.Info.graphics.SetClip(rclip);
				Point p1 = new Point(e.Info.NodeRect.X, e.Info.NodeRect.Bottom);
				Point p2 = new Point(e.Info.NodeRect.Right, e.Info.NodeRect.Bottom);
				e.Info.graphics.DrawLine(geniusTreeView1.Colors.GridLinesColor, p1, p2);
				p1 = new Point(e.Info.NodeRect.X, e.Info.NodeRect.Top);
				p2 = new Point(e.Info.NodeRect.Right, e.Info.NodeRect.Top);
				e.Info.graphics.DrawLine(geniusTreeView1.Colors.GridLinesColor, p1, p2);
			}

		}

		private void geniusTreeView1_OnBeginSelect(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.CanSelectEventArgs e)
		{
			e.CanSelect = !(e.Node.Data is Group);
		}

	}
}
