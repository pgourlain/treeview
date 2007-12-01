using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Genius.Controls;

namespace DemoTreeView
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		Image bmp = null;
		private Genius.Controls.GeniusTreeView geniusTreeView1;
		private Genius.Controls.GeniusTreeViewColonne geniusTreeViewColonne1;
		private Genius.Controls.GeniusTreeViewColonne geniusTreeViewColonne2;
		private Genius.Controls.GeniusTreeViewColonne geniusTreeViewColonne3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream("DemoTreeView.images.fond1.jpg");

			bmp = Bitmap.FromStream(stm);
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.geniusTreeView1 = new Genius.Controls.GeniusTreeView();
			this.geniusTreeViewColonne1 = new Genius.Controls.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.GeniusTreeViewColonne();
			this.SuspendLayout();
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.DataSource = null;
			this.geniusTreeView1.DefaultNodeHeight = 18;
			this.geniusTreeView1.FixedColumnCount = 0;
			this.geniusTreeView1.FullRowSelect = false;
			this.geniusTreeView1.Header.AllowDrag = false;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.GeniusTreeViewColonne[] {
																										 this.geniusTreeViewColonne1,
																										 this.geniusTreeViewColonne2,
																										 this.geniusTreeViewColonne3});
			this.geniusTreeView1.HeaderHeight = 20;
			this.geniusTreeView1.ImageList = null;
			this.geniusTreeView1.ImageStateList = null;
			this.geniusTreeView1.Indentation = 16;
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(40, 72);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.PaintOptions = ((Genius.Controls.PaintOptionsEnum)((Genius.Controls.PaintOptionsEnum.ShowButtons | Genius.Controls.PaintOptionsEnum.ShowTreeLines)));
			this.geniusTreeView1.ShowHeader = true;
			this.geniusTreeView1.Size = new System.Drawing.Size(376, 240);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.Alignment = System.Drawing.StringAlignment.Center;
			this.geniusTreeViewColonne1.AllowClick = true;
			this.geniusTreeViewColonne1.AllowDrag = true;
			this.geniusTreeViewColonne1.AllowSize = true;
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = null;
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.TextAlignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeViewColonne1.Titre = null;
			this.geniusTreeViewColonne1.VAlignment = System.Drawing.StringAlignment.Center;
			this.geniusTreeViewColonne1.Visible = true;
			this.geniusTreeViewColonne1.Width = 75;
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.Alignment = System.Drawing.StringAlignment.Center;
			this.geniusTreeViewColonne2.AllowClick = true;
			this.geniusTreeViewColonne2.AllowDrag = true;
			this.geniusTreeViewColonne2.AllowSize = true;
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = null;
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.TextAlignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeViewColonne2.Titre = null;
			this.geniusTreeViewColonne2.VAlignment = System.Drawing.StringAlignment.Center;
			this.geniusTreeViewColonne2.Visible = true;
			this.geniusTreeViewColonne2.Width = 75;
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.Alignment = System.Drawing.StringAlignment.Center;
			this.geniusTreeViewColonne3.AllowClick = true;
			this.geniusTreeViewColonne3.AllowDrag = true;
			this.geniusTreeViewColonne3.AllowSize = true;
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = null;
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.TextAlignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeViewColonne3.Titre = null;
			this.geniusTreeViewColonne3.VAlignment = System.Drawing.StringAlignment.Center;
			this.geniusTreeViewColonne3.Visible = true;
			this.geniusTreeViewColonne3.Width = 75;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 366);
			this.Controls.Add(this.geniusTreeView1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.ResumeLayout(false);

		}
		#endregion

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			using (TextureBrush br = new TextureBrush(bmp, WrapMode.Tile))
			{
				br.RotateTransform(25);
				GeniusLinearGradientBrush gbr = new GeniusLinearGradientBrush(br);

				e.Graphics.FillRectangle(gbr.GetBrush(this.DisplayRectangle), this.DisplayRectangle);
			}

		}
	}
}
