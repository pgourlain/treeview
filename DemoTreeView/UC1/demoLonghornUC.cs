using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Genius.Controls;
using Genius.Controls.TreeView;

namespace DemoTreeView.UC1
{
	/// <summary>
	/// Summary description for demoLonghornUC.
	/// </summary>
	public class demoLonghornUC : System.Windows.Forms.UserControl
	{
		INode FUnderMouse;
		IDictionary FSelecteds;
		private static Pen FSelLinePen;
		private static GeniusLinearGradientBrush FSelectedBrush;
		private static GeniusLinearGradientBrush FOverBrush;

		private Genius.Controls.TreeView.GeniusTreeView gtv;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtcName;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtcSize;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtcType;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtcDateM;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbNoGroup;
		private System.Windows.Forms.RadioButton rbByName;
		private System.Windows.Forms.RadioButton rbByType;
		private System.ComponentModel.IContainer components;

		static demoLonghornUC()
		{
			FSelLinePen = new Pen(Color.FromArgb(183, 201, 221));
			//couleur de la selection 234, 251, 255 -> 189, 215, 255
			FSelectedBrush = new GeniusLinearGradientBrush(Color.FromArgb(243, 251, 255), Color.FromArgb(189, 215, 255), 90);
			//242, 249, 255 -> 226, 232, 244
			FOverBrush = new GeniusLinearGradientBrush(Color.FromArgb(242, 249, 255), Color.FromArgb(226, 232, 244), 90);
		}

		public demoLonghornUC()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			FSelecteds = new Hashtable();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(demoLonghornUC));
			this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
			this.gtcName = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.gtcSize = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.gtcType = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.gtcDateM = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.rbNoGroup = new System.Windows.Forms.RadioButton();
			this.rbByName = new System.Windows.Forms.RadioButton();
			this.rbByType = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AllowEdit = false;
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
			this.gtv.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.ElapsedHint = 500;
			this.gtv.FullRowSelect = true;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.ImageList = null;
			this.gtv.Header.MainColumnIndex = 0;
			this.gtv.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																									  this.gtcName,
																									  this.gtcSize,
																									  this.gtcType,
																									  this.gtcDateM});
			this.gtv.HeaderHeight = 30;
			this.gtv.ImageList = this.imageList1;
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 32);
			this.gtv.Name = "gtv";
			this.gtv.ShowHeader = true;
			this.gtv.Size = new System.Drawing.Size(328, 224);
			this.gtv.TabIndex = 0;
			this.gtv.Text = "geniusTreeView1";
			this.gtv.UseColumns = true;
			this.gtv.Click += new System.EventHandler(this.gtv_Click);
			this.gtv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gtv_MouseMove);
			this.gtv.OnInitNode += new Genius.Controls.TreeView.OnNodeDelegate(this.gtv_OnInitNode);
			this.gtv.OnGetNodeValue += new Genius.Controls.TreeView.OnGetNodeValueForComparisonDelegate(this.gtv_OnGetNodeValue);
			this.gtv.OnBeforePaintHeader += new Genius.Controls.TreeView.OnDrawHeaderColDelegate(this.gtv_OnDrawHeaderCol);
			this.gtv.OnPaintNodeBackGround += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnPaintNodeBackGround);
			this.gtv.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.gtv_OnGetNodeText);
			this.gtv.OnGetImageIndex += new Genius.Controls.TreeView.OnGetImageIndexDelegate(this.gtv_OnGetImageIndex);
			this.gtv.OnBeforeNodePainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnBeforeNodePainting);
			// 
			// gtcName
			// 
			this.gtcName.Alignment = System.Drawing.StringAlignment.Near;
			this.gtcName.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcName.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcName.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcName.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtcName.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcName.Text = "Name";
			this.gtcName.VAlignment = System.Drawing.StringAlignment.Near;
			this.gtcName.Width = 150;
			// 
			// gtcSize
			// 
			this.gtcSize.Alignment = System.Drawing.StringAlignment.Far;
			this.gtcSize.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcSize.ContentAlignment = System.Drawing.StringAlignment.Far;
			this.gtcSize.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcSize.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcSize.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtcSize.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcSize.Text = "Size";
			this.gtcSize.VAlignment = System.Drawing.StringAlignment.Near;
			// 
			// gtcType
			// 
			this.gtcType.Alignment = System.Drawing.StringAlignment.Near;
			this.gtcType.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcType.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcType.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcType.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtcType.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcType.Text = "Type";
			this.gtcType.VAlignment = System.Drawing.StringAlignment.Near;
			// 
			// gtcDateM
			// 
			this.gtcDateM.Alignment = System.Drawing.StringAlignment.Near;
			this.gtcDateM.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcDateM.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcDateM.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtcDateM.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtcDateM.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.gtcDateM.Text = "Date Modified";
			this.gtcDateM.VAlignment = System.Drawing.StringAlignment.Near;
			this.gtcDateM.Width = 150;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rbByType);
			this.panel1.Controls.Add(this.rbByName);
			this.panel1.Controls.Add(this.rbNoGroup);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(328, 32);
			this.panel1.TabIndex = 1;
			// 
			// rbNoGroup
			// 
			this.rbNoGroup.Checked = true;
			this.rbNoGroup.Location = new System.Drawing.Point(8, 8);
			this.rbNoGroup.Name = "rbNoGroup";
			this.rbNoGroup.Size = new System.Drawing.Size(104, 16);
			this.rbNoGroup.TabIndex = 0;
			this.rbNoGroup.TabStop = true;
			this.rbNoGroup.Text = "Pas de groupe";
			this.rbNoGroup.CheckedChanged += new System.EventHandler(this.rbByName_CheckedChanged);
			// 
			// rbByName
			// 
			this.rbByName.Location = new System.Drawing.Point(112, 8);
			this.rbByName.Name = "rbByName";
			this.rbByName.Size = new System.Drawing.Size(104, 16);
			this.rbByName.TabIndex = 1;
			this.rbByName.Text = "by Name";
			this.rbByName.CheckedChanged += new System.EventHandler(this.rbByName_CheckedChanged);
			// 
			// rbByType
			// 
			this.rbByType.Location = new System.Drawing.Point(224, 8);
			this.rbByType.Name = "rbByType";
			this.rbByType.Size = new System.Drawing.Size(104, 16);
			this.rbByType.TabIndex = 2;
			this.rbByType.Text = "by Type";
			this.rbByType.CheckedChanged += new System.EventHandler(this.rbByName_CheckedChanged);
			// 
			// demoLonghornUC
			// 
			this.Controls.Add(this.gtv);
			this.Controls.Add(this.panel1);
			this.Name = "demoLonghornUC";
			this.Size = new System.Drawing.Size(328, 256);
			this.Load += new System.EventHandler(this.demoLonghornUC_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void demoLonghornUC_Load(object sender, System.EventArgs e)
		{
			gtv.BackColor = Color.FromArgb(244,244,244);
			this.gtv.DefaultDrawingOption = DrawingOptions.HideTreeLines | DrawingOptions.ShowVertLines | DrawingOptions.AlwaysHideSelection | DrawingOptions.HideFocusRect | DrawingOptions.HideSelection | DrawingOptions.HideButtons;
			this.gtv.Indentation = 2;
			this.gtv.LeftMargin = 5;
			this.gtv.Colors.GridLinesColor = new Pen(Color.FromArgb(231, 231, 231));
			this.gtcSize.BackColor = new GeniusLinearGradientBrush(Color.FromArgb(244,244,244));
			this.gtcType.BackColor = new GeniusLinearGradientBrush(Color.FromArgb(244,244,244));
			this.gtcDateM.BackColor = new GeniusLinearGradientBrush(Color.FromArgb(244,244,244));
			this.gtv.Colors.HeaderColor = new GeniusLinearGradientBrush(Color.WhiteSmoke);
			if (!DesignMode)
			{
				FillTree(DefaultFolder, GroupBy.None);
			}
		}

		private string DefaultFolder
		{
			get
			{
				return @"c:\";
			}
		}

		private void DrawRoundRect(GeniusLinearGradientBrush geniusBr, Pen pen, Rectangle r, Graphics g)
		{
			using(Brush br = geniusBr.GetBrush(r))
			{
				DrawingHelper.FillRoundRect(g, br, r, 5, 5);
			}
			DrawingHelper.DrawRoundRect(g, pen, r, 5, 5);
		}

		private void gtv_OnPaintNodeBackGround(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			//painture du noeud sous la souris ou du noeud selectionné
			if ((e.Node == FUnderMouse || IsSelected(e.Node) && !(e.Node.Data is VistaGroup)))
			{
				Rectangle r = e.Info.NodeRect;
				r.Width = gtv.RangeX;
				r.Inflate(-2, 0);
				r.Height -= 1;

				//RoundRect
				GeniusLinearGradientBrush geniusBr = e.Node == FUnderMouse ? FOverBrush : FSelectedBrush;
				DrawRoundRect(geniusBr, FSelLinePen, r, e.Info.graphics);
			}		
		}

		private void gtv_MouseMove(object sender, MouseEventArgs e)
		{
			INode n = gtv.GetNodeAtPoint(new Point(e.X, e.Y));
			if (FUnderMouse != n)
			{
				if (n != null)
				{
					FUnderMouse = n;
					gtv.Invalidate();
				}
			}
			else if (n != null)
			{
				if (n.Data is VistaGroup)
					gtv.Invalidate(n);
			}
		}

		const int VK_CONTROL		= 0x11;
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		static internal extern Int16 GetKeyState(int nVirtKey);

		private void gtv_Click(object sender, EventArgs e)
		{
			bool ctrlIsPressed = (GetKeyState(VK_CONTROL) & 0x80) > 0;

			Point ptMouse = gtv.PointToClient(Cursor.Position);
			INode aNode = gtv.GetNodeAtPoint(ptMouse);
			if (aNode != null && aNode.Data is VistaGroup)
			{
				Rectangle r = gtv.GetNodeRect(aNode);
				r = new Rectangle(r.Right-15, (r.Top+r.Bottom) / 2, 0,0);
				r.Inflate(7, 7);
				if (r.Contains(ptMouse))
				{
					gtv.ExpandCollapseNode(aNode);
					return;
				}
	
			}
			if (gtv.SelectedNode != null)
				AddSelection(gtv.SelectedNode, ctrlIsPressed);
		}

		private bool IsSelected(INode aNode)
		{
			return FSelecteds.Contains(aNode);
		}

		private void AddSelection(INode aNode, bool addToSelection)
		{
			if (!addToSelection)
				FSelecteds.Clear();
			FSelecteds.Add(aNode, aNode);
			if (aNode.Count > 0)
			{
				foreach (INode child in aNode.Enumerable.GetVisibleNodes(false))
					FSelecteds.Add(child, child);
			}
			gtv.Invalidate();
		}

		private void FillTree(string aPath, GroupBy aGroupBy)
		{
			gtv.DataSource = VistaItemFS.EnumereFS(aPath, aGroupBy);
			gtv.ExpandAll();
		}

		private void gtv_OnGetNodeText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeTextEventArgs e)
		{
			VistaItem aItem = e.Node.Data as VistaItem;
			switch(e.DisplayColumn)
			{
				case 0 :
					e.Text = aItem.Name;
					break;
				case 1 :
					Int64 size = aItem.Size;
					if (size >= 0)
						e.Text = size.ToString();
					else 
						e.Text = string.Empty;
					break;
				case 2 :
					e.Text = aItem.FileType;
					break;
				case 3 :
					if (aItem.Date > DateTime.MinValue)
						e.Text = aItem.Date.ToString();
					break;
			}
		}

		private void gtv_OnGetImageIndex(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeImageIndexEventArgs e)
		{
			if (e.ImageIndexType == ImageIndexType.NormalImage)
			{
				e.ImageIndex = e.Node.Data is VistaFolder ? 0 : 
					e.Node.Data is VistaGroup ? -1 : 1;
			}
		}

		private System.IComparable gtv_OnGetNodeValue(Genius.Controls.TreeView.INode A, int aDisplayColumn)
		{
			VistaItem aItem = A.Data as VistaItem;
			if (aItem is VistaGroup)
				return aItem.Name;
			switch(aDisplayColumn)
			{
				case 0 :
					return aItem.Name;
				case 1 :
					return aItem.Size;
				case 2 :
					return aItem.FileType;
				case 3 :
					return aItem.Date;
			}
			return null;
		}

		private void gtv_OnBeforeNodePainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Node.Data is VistaGroup)
			{
				Rectangle r;
				VistaGroup group = e.Node.Data as VistaGroup;
				e.Info.DefaultDrawing = false;
				//painture du noeud sous la souris ou du noeud selectionné
				if (e.Node == FUnderMouse || IsSelected(e.Node))
				{
					r = e.Info.NodeRect;
					r.Inflate(-2, 0);
					r.Height -= 1;

					//RoundRect
					GeniusLinearGradientBrush geniusBr = e.Node == FUnderMouse ? FOverBrush : FSelectedBrush;
					DrawRoundRect(geniusBr, FSelLinePen, r, e.Info.graphics);
				}
				SizeF size = e.Info.graphics.MeasureString(group.Name, gtv.Font);
				e.Info.graphics.DrawString(group.Name, gtv.Font, Brushes.Black, e.Info.NodeRect.X + 5, e.Info.NodeRect.Y + e.Info.NodeRect.Height / 2 - size.Height / 2);
				int y = (e.Info.ContentRect.Bottom + e.Info.ContentRect.Top) / 2;
				int x = (int)size.Width + e.Info.ContentRect.X + 10;
				e.Info.graphics.DrawLine(Pens.LightGray, x, y, e.Info.ContentRect.Right-25, y);
				//dessin des ligne des colonne
				//à faire
				x = e.Info.NodeRect.Left;
				foreach (GeniusTreeViewColonne aCol in gtv.Header.Displays)
				{
					e.Info.graphics.DrawLine(gtv.Colors.GridLinesColor, x, e.Info.NodeRect.Top, x, e.Info.NodeRect.Bottom);					
					x += aCol.Width;
				}
				//e.Info.graphics.DrawLine(gtv.Colors.GridLinesColor, e.Info.NodeRect.Left, e.Info.NodeRect.Top, e.Info.NodeRect.Left, e.Info.NodeRect.Bottom);
				//dessin de l'expand à droite
				Pen p = new Pen(Brushes.Gray);
				p.Width = 3;
				p.EndCap = LineCap.ArrowAnchor;
				r = new Rectangle(e.Info.ContentRect.Right-15, y, 0,0);
				r.Inflate(7, 7);
				Debug.WriteLine(string.Format("m : {0}, r:{1}",e.Info.MousePosition, r));
				if (r.Contains(e.Info.MousePosition))
				{
					using (Brush br = FSelectedBrush.GetBrush(r))
					{
						e.Info.graphics.FillEllipse(br, r);
						e.Info.graphics.DrawEllipse(Pens.LightGray, r);
					}
				}
				if (e.Node.IsExpanded)
					e.Info.graphics.DrawLine(p, e.Info.ContentRect.Right-15, y+2, e.Info.ContentRect.Right-15, y-3);
				else
					e.Info.graphics.DrawLine(p, e.Info.ContentRect.Right-15, y-2, e.Info.ContentRect.Right-15, y+3);
			}
		}

		private void gtv_OnInitNode(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeEventArgs e)
		{
			if (e.Node.Data is VistaGroup)
			{
				e.Node.Height = gtv.DefaultNodeHeight + gtv.DefaultNodeHeight/ 2;
			}
		}

		private void rbByName_CheckedChanged(object sender, System.EventArgs e)
		{
			if (sender == rbByName)
				FillTree(DefaultFolder, GroupBy.Name);
			else if (sender == rbByType)
				FillTree(DefaultFolder, GroupBy.Type);
			else if (sender== rbNoGroup)
				FillTree(DefaultFolder, GroupBy.None);
		}

		private void gtv_OnDrawHeaderCol(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.DrawHeaderColEventArgs e)
		{
			Rectangle rCol = e.ColumnRect;
			e.Graphics.FillRectangle(Brushes.WhiteSmoke, rCol);
			rCol = e.ColumnRect;
			rCol.Height = 6;
			SortDirection sortCol = gtv.Header.GetSorting(e.Column);
			if (sortCol != SortDirection.None)
			{
				using (GeniusLinearGradientBrush gbrush = new GeniusLinearGradientBrush(FSelectedBrush.EndColor, FSelectedBrush.BeginColor, 90))
				{
					using (Brush br = gbrush.GetBrush(rCol))
					{
						e.Graphics.FillRectangle(br, rCol);
					}				
				}
				DrawSortingIcone(e.Graphics,rCol, sortCol);
			}
			rCol = e.ColumnRect;
			rCol.Height -= 7;
			rCol.Y += 7;
			StringFormat sf = new StringFormat(StringFormatFlags.NoWrap);

			sf.LineAlignment = e.Column.VAlignment;
			sf.Alignment = e.Column.Alignment;
			using (Brush br = new SolidBrush(e.Column.ForeColor))
			{
				e.Graphics.DrawString(e.Column.Text, e.Column.Font, br, rCol, sf);
			}
			e.Graphics.DrawLine(gtv.Colors.GridLinesColor, rCol.Left, e.ColumnRect.Top,  rCol.Left, rCol.Bottom);
			e.Graphics.DrawLine(gtv.Colors.GridLinesColor, rCol.Right, e.ColumnRect.Top,  rCol.Right, rCol.Bottom);
			e.DefaultDrawing = false;
		}

		private void DrawSortingIcone(Graphics g, Rectangle rCol, SortDirection sortCol)
		{
			using (GraphicsPath path = new GraphicsPath())
			{
				Point centre = new Point(rCol.Width / 2 + rCol.Left, rCol.Top);
				int xMin = centre.X - 2;
				int xMin1 = centre.X + 2;
				int xMax = centre.X - 8;
				int xMax1 = centre.X + 8;
				if (sortCol == SortDirection.Descending)
				{
					int tmp = xMin;
					xMin = xMax;
					xMax = tmp;
					tmp =xMin1;
					xMin1 = xMax1;
					xMax1 = tmp;
					xMin--;
					xMin1++;
				}
				else
				{
					xMin++;
					xMin1--;
				}
				path.AddPolygon(new Point[]{new Point(xMin, rCol.Top), new Point(xMax, rCol.Top +6), new Point(xMax1, rCol.Top+6 ),  new Point(xMin1, rCol.Top), new Point(xMin, rCol.Top)});
				g.FillPath(Brushes.WhiteSmoke, path);
				using (Pen p = new Pen(Color.FromArgb(169,205,203), 2))
				{
					//g.DrawPath(p, path);
					g.DrawLine(p, new Point(xMin, rCol.Top-1), new Point(xMax, rCol.Top +6));
					g.DrawLine(p, new Point(xMax1, rCol.Top +6), new Point(xMin1, rCol.Top-1));					
				}
			}
		}
	}
}
