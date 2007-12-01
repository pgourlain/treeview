using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Genius.Controls;
using Genius.Controls.TreeView;
using Genius.Controls.TreeView.Core;

namespace Genius.MyTreeView
{
	/// <summary>
	/// Summary description for GtvToolbox2005.
	/// </summary>
	public class GtvToolbox2005 : UserControl
	{
		GeniusTreeView gtv;
		INode FUnderMouse;
		INode FSelected;
		private ImageList imageList1;
		private IContainer components;

		private static Color FSelectedColor;
		private static Color FOverColor;
		private static Pen FSelLinePen;
		private static Brush FSelectedBrush;
		private static Brush FOverBrush;

		static GtvToolbox2005()
		{
			FSelectedColor = Color.FromArgb(225, 230, 232);
			FOverColor = Color.FromArgb(193, 210, 238);
			FSelLinePen = new Pen(Color.FromArgb(49, 106, 197));
			FSelectedBrush = new SolidBrush(FSelectedColor);
			FOverBrush = new SolidBrush(FOverColor);
		}

		public GtvToolbox2005()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(GtvToolbox2005));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// GtvToolbox2005
			// 
			this.Name = "GtvToolbox2005";
			this.Size = new System.Drawing.Size(280, 232);
			this.Load += new System.EventHandler(this.GtvToolbox2005_Load);

		}
		#endregion

		private void GtvToolbox2005_Load(object sender, EventArgs e)
		{
			gtv = new GeniusTreeView();
			gtv.DefaultNodeHeight = 17;
			gtv.Dock = DockStyle.Fill;
			gtv.AllowEdit = false;
			gtv.Font = new Font("Tahoma", 8, FontStyle.Bold);
			this.Controls.Add(gtv);
			gtv.OnBeforePainting += new OnPaintNodeDelegate(gtv_OnBeforePainting);
			gtv.OnPaintNodeBackGround += new OnPaintNodeDelegate(gtv_OnPaintNodeBackGround);
			gtv.OnGetFontNode += new OnNodeFontDelegate(gtv_OnGetFontNode);
			gtv.MouseMove += new MouseEventHandler(gtv_MouseMove);
			gtv.Click += new EventHandler(gtv_Click);
			gtv.ImageList = imageList1;
			gtv.BeginUpdate();
			gtv.DefaultDrawingOption = DrawingOption.HideTreeLines | DrawingOption.AlwaysHideSelection | DrawingOption.HideFocusRect;
			try
			{
				INode n = gtv.Add(null, "All Windows Forms", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Common Controls", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Containers", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Menus & Toolbars", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Data", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Components", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Printing", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Dialogs", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Crystal Reports", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
				n = gtv.Add(null, "Genius", null);
				INode child = gtv.Add(n, "Pointer", null);
				child.Height = 20;
				child.ImageIndex = 0;
				child = gtv.Add(n, "GeniusTreeView", null);
				child.Height = 20;
				child.ImageIndex = 1;
				n = gtv.Add(null, "General", null);
				n = gtv.Add(n, "Pointer", null);
				n.Height = 20;
				n.ImageIndex = 0;
			}
			finally
			{
				gtv.EndUpdate();
			}
		}
		void gtv_OnBeforePainting(GeniusTreeView Sender, PaintNodeEventArgs e)
		{
			//painture du dégradé dans le fond du control
			GeniusLinearGradientBrush br = new GeniusLinearGradientBrush(Color.FromArgb(243, 241, 230), Color.FromArgb(227, 225, 208));

			e.Info.graphics.FillRectangle(br.GetBrush(this.ClientRectangle), this.ClientRectangle);
		}

		void gtv_OnPaintNodeBackGround(GeniusTreeView Sender, PaintNodeEventArgs e)
		{
			//paint du noeud racine
			if (e.Node.Level == 1)
			{
				using (GeniusLinearGradientBrush br = new GeniusLinearGradientBrush(Color.FromArgb(220, 221, 203), Color.FromArgb(196, 193, 176), 90))
				{
					Rectangle r = e.Info.NodeRect;
					r.Inflate(0, -1);
					r.Height -= 1;
					using (Brush b = br.GetBrush(r))
					{
						e.Info.graphics.FillRectangle(b, r);
						using (Pen p = new Pen(Color.FromArgb(220, 221, 203)))
						{
							e.Info.graphics.DrawLine(p, r.Left, r.Top, r.Right, r.Top);
						}
						using (Pen p = new Pen(b))
						{
							e.Info.graphics.DrawLine(p, r.Left, r.Bottom + 1, r.Right, r.Bottom + 1);
						}
					}
				}
			}
			else if (e.Node.Level == 2)
			{
				//painture du noeud sous la souris ou du noeud selectionné
				if (e.Node == FUnderMouse || e.Node == FSelected)
				{
					Rectangle r = e.Info.NodeRect;
					r.Inflate(-4, 0);
					r.Height -= 1;

					e.Info.graphics.FillRectangle(e.Node == FUnderMouse ? FOverBrush : FSelectedBrush, r);
					e.Info.graphics.DrawRectangle(FSelLinePen, r);
				}
			}
		}

		/// <summary>
		/// selection d'un noeud ou Expand/collapse pour les noeud du premier niveau
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void gtv_Click(object sender, EventArgs e)
		{
			MousePosition position;
			int aColumn;

			Point pt= gtv.PointToClient(Cursor.Position);
			INode n = gtv.GetNodeAtPoint(pt, out aColumn, out position);
			bool underButton = ((position & Genius.Controls.TreeView.MousePosition.OnItemButton) == Genius.Controls.TreeView.MousePosition.OnItemButton);
			if (n != null && n.Level == 1 && !underButton)
				gtv.ExpandCollapseNode(n);
			else if (n != null && n.Level == 2)
			{
				FSelected = n;
				gtv.Invalidate();
			}
		}

		/// <summary>
		/// gestion du noeud sous la souris
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void gtv_MouseMove(object sender, MouseEventArgs e)
		{
			//Debug.WriteLine("mousemove");
			INode n = gtv.GetNodeAtPoint(new Point(e.X, e.Y));
			if (FUnderMouse != n)
			{
				if (n != null && n.Level == 2)
				{
					FUnderMouse = n;
					gtv.Invalidate();
				}
				else if (((n == null) || (n != null && n.Level != 2)) && FUnderMouse != null)
				{
					FUnderMouse = null;
					gtv.Invalidate();
				}
			}
		}

		/// <summary>
		/// spécification d'un fonte différente en fonction du niveau
		/// </summary>
		/// <param name="Sender"></param>
		/// <param name="e"></param>
		void gtv_OnGetFontNode(GeniusTreeView Sender, NodeFontEventArgs e)
		{
			if (e.Node.Level == 2)
				e.Font = new Font(e.Font.Name, e.Font.SizeInPoints);
		}
	}
}
