using System.Drawing;
using Genius.Controls;
using Genius.Controls.TreeView;

namespace DemoTreeView.UserControls
{
	/// <summary>
	/// Summary description for TestDrawingOptions.
	/// </summary>
	public class TestDrawingOptions : System.Windows.Forms.UserControl
	{
		private Genius.Controls.TreeView.GeniusTreeView gtv;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TestDrawingOptions()
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
			this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AutoSort = false;
			this.gtv.BackColor = System.Drawing.SystemColors.Window;
			this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192))), System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F);
			this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.FullRowSelect = true;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.MainColumnIndex = -1;
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 0);
			this.gtv.Name = "gtv";
			this.gtv.Size = new System.Drawing.Size(368, 320);
			this.gtv.TabIndex = 0;
			this.gtv.OnAfterCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnAfterCellPainting);
			this.gtv.OnBeforeNodePainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnBeforeNodePainting);
			this.gtv.OnDrawTreeLines += new Genius.Controls.TreeView.OnDrawingNodeTreeLinesDelegate(this.gtv_OnDrawTreeLines);
			// 
			// TestDrawingOptions
			// 
			this.Controls.Add(this.gtv);
			this.Name = "TestDrawingOptions";
			this.Size = new System.Drawing.Size(368, 320);
			this.Load += new System.EventHandler(this.TestDrawingOptions_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void gtv_OnBeforeNodePainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Node.Level == 2)
			//
				e.Info.DrawingOptions = DrawingOptions.HideTreeLines;
		}

		private void TestDrawingOptions_Load(object sender, System.EventArgs e)
		{
			/*
			gtv.Colors.SelectedColor = new GeniusLinearGradientBrush(Color.FromArgb(204,218,241));
			gtv.Colors.FocusedRectangleColor = new Pen(Color.FromArgb(49,106,197));
			gtv.Colors.SelectedTextColor = new GeniusLinearGradientBrush(Color.Black);
			gtv.Colors.UnFocusedRectangleColor = new Pen(Color.FromArgb(152,181,226));
			gtv.Colors.SelectedUnfocusedColor = new GeniusLinearGradientBrush(Color.FromArgb(229,236,248));
			*/
			Genius.Controls.TreeView.Colors.Themes.GeniusTreeViewTheme(gtv.Colors);
			gtv.BeginUpdate();
			try
			{
				for (int i =0; i < 10; i++)
				{
					INode n = gtv.Add(null, i.ToString(), null);
					for (int j =0; j < 10; j++)
					{
						INode n1 = gtv.Add(n, j.ToString(), null);						
						for (int k=0; k < 10; k++)
							gtv.Add(n1, k.ToString(), null);						
					}
				}
			}
			finally
			{
				gtv.EndUpdate();
			}
		}

		private void gtv_OnAfterCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			//e.Info.DrawingOptions = DrawingOption.HideTreeLines;
		}

		private void gtv_OnDrawTreeLines(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeDrawingTreeLinesEventArgs e)
		{
			e.Draw = e.Node.Level != 2;
		}

	}
}
