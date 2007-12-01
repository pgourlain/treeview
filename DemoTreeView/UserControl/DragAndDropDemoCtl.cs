using System;
using System.Diagnostics;

namespace DemoTreeView.UserControl
{
	/// <summary>
	/// Summary description for DragAndDropDemoCtl.
	/// </summary>
	public class DragAndDropDemoCtl : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private Genius.Controls.TreeView.GeniusTreeView gtvSource;
		private Genius.Controls.TreeView.GeniusTreeView gtvDest;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DragAndDropDemoCtl()
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
			this.gtvSource = new Genius.Controls.TreeView.GeniusTreeView();
			this.label1 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.gtvDest = new Genius.Controls.TreeView.GeniusTreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.gtvSource);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(224, 376);
			this.panel1.TabIndex = 0;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtvSource
			// 
			this.gtvSource.Alignment = System.Drawing.StringAlignment.Near;
			this.gtvSource.AllowDrag = true;
			this.gtvSource.AutoSort = false;
			this.gtvSource.BackColor = System.Drawing.SystemColors.Window;
			this.gtvSource.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtvSource.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtvSource.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtvSource.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtvSource.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtvSource.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.gtvSource.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtvSource.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtvSource.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.gtvSource.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtvSource.ElapsedHint = 500;
			this.gtvSource.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtvSource.Header.ImageList = null;
			this.gtvSource.Header.MainColumnIndex = -1;
			this.gtvSource.KeysGridMode = false;
			this.gtvSource.Location = new System.Drawing.Point(0, 23);
			this.gtvSource.Name = "gtvSource";
			this.gtvSource.Size = new System.Drawing.Size(224, 353);
			this.gtvSource.TabIndex = 1;
			this.gtvSource.Text = "geniusTreeView1";
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Source";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(224, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 376);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.gtvDest);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(227, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(221, 376);
			this.panel2.TabIndex = 2;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtvDest
			// 
			this.gtvDest.Alignment = System.Drawing.StringAlignment.Near;
			this.gtvDest.AllowDrag = true;
			this.gtvDest.AllowDrop = true;
			this.gtvDest.AutoSort = false;
			this.gtvDest.BackColor = System.Drawing.SystemColors.Window;
			this.gtvDest.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtvDest.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtvDest.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtvDest.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtvDest.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtvDest.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.gtvDest.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtvDest.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtvDest.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.gtvDest.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtvDest.ElapsedHint = 500;
			this.gtvDest.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtvDest.Header.ImageList = null;
			this.gtvDest.Header.MainColumnIndex = -1;
			this.gtvDest.KeysGridMode = false;
			this.gtvDest.Location = new System.Drawing.Point(0, 23);
			this.gtvDest.Name = "gtvDest";
			this.gtvDest.Size = new System.Drawing.Size(221, 353);
			this.gtvDest.TabIndex = 2;
			this.gtvDest.Text = "geniusTreeView2";
			this.gtvDest.OnCanDragTo += new Genius.Controls.TreeView.OnCanDragToDelegate(this.gtvDest_OnCanDragTo);
            this.gtvDest.DragOver += new System.Windows.Forms.DragEventHandler(gtvDest_DragOver);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(221, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Destination";
			// 
			// DragAndDropDemoCtl
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Name = "DragAndDropDemoCtl";
			this.Size = new System.Drawing.Size(448, 376);
			this.Load += new System.EventHandler(this.DragAndDropDemoCtl_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        void gtvDest_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //e.Effect = System.Windows.Forms.DragDropEffects.Copy;
            //e. = System.Windows.Forms.DragDropEffects.Copy;
        }
		#endregion

		private void DragAndDropDemoCtl_Load(object sender, System.EventArgs e)
		{
			gtvSource.BeginUpdate();
			try
			{
				for (int i = 0; i < 10; i++)
					for (int j =0; j < 10; j++)
					{
						gtvSource.Add(null, String.Format("Node_{0}.{1}", i, j), null);
					}
			}
			finally
			{
				gtvSource.EndUpdate();
			}
			gtvDest.Add(null, "DropHere", null);
		}

		private void gtvDest_OnCanDragTo(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.CanDragToEventArgs e)
		{
			Debug.WriteLine("CanDragTo");
		}
	}
}
