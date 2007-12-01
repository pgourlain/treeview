using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Genius.Controls.TreeView.Colors;

namespace Genius.Controls
{
	/// <summary>
	/// Summary description for TabbedDemo.
	/// </summary>
	public class TabbedDemo : System.Windows.Forms.Form
	{
		private Genius.Controls.GeniusTab.HorizontalTabs horizontalTabs1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab2;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab3;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab4;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab5;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private Genius.Controls.TreeView.GeniusTreeView geniusTreeView1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TabbedDemo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.horizontalTabs1 = new Genius.Controls.GeniusTab.HorizontalTabs();
			this.horizontalTab2 = new Genius.Controls.GeniusTab.HorizontalTab();
			this.horizontalTab1 = new Genius.Controls.GeniusTab.HorizontalTab();
			this.horizontalTab3 = new Genius.Controls.GeniusTab.HorizontalTab();
			this.horizontalTab4 = new Genius.Controls.GeniusTab.HorizontalTab();
			this.horizontalTab5 = new Genius.Controls.GeniusTab.HorizontalTab();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.horizontalTab6 = new Genius.Controls.GeniusTab.HorizontalTab();
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.horizontalTabs1.SuspendLayout();
			this.horizontalTab5.SuspendLayout();
			this.SuspendLayout();
			// 
			// horizontalTabs1
			// 
			this.horizontalTabs1.Controls.Add(this.horizontalTab2);
			this.horizontalTabs1.Controls.Add(this.horizontalTab1);
			this.horizontalTabs1.Controls.Add(this.horizontalTab3);
			this.horizontalTabs1.Controls.Add(this.horizontalTab4);
			this.horizontalTabs1.Controls.Add(this.horizontalTab5);
			this.horizontalTabs1.Controls.Add(this.horizontalTab6);
			this.horizontalTabs1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTabs1.Location = new System.Drawing.Point(0, 0);
			this.horizontalTabs1.Margins = 5;
			this.horizontalTabs1.Name = "horizontalTabs1";
			this.horizontalTabs1.Orientation = Genius.Controls.GeniusTab.TabOrientation.Left;
			this.horizontalTabs1.SelectedIndex = 4;
			this.horizontalTabs1.Size = new System.Drawing.Size(576, 373);
			this.horizontalTabs1.TabIndex = 0;
			this.horizontalTabs1.TabsHeight = 30;
			this.horizontalTabs1.TabsWidth = 80;
			this.horizontalTabs1.Text = "standard 1";
			// 
			// horizontalTab2
			// 
			this.horizontalTab2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(241)), ((System.Byte)(229)));
			this.horizontalTab2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTab2.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
			this.horizontalTab2.Location = new System.Drawing.Point(86, 6);
			this.horizontalTab2.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
			this.horizontalTab2.Name = "horizontalTab2";
			this.horizontalTab2.Size = new System.Drawing.Size(484, 361);
			this.horizontalTab2.TabIndex = 1;
			this.horizontalTab2.Text = "standard 1";
			this.horizontalTab2.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// horizontalTab1
			// 
			this.horizontalTab1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(241)), ((System.Byte)(229)));
			this.horizontalTab1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTab1.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
			this.horizontalTab1.Location = new System.Drawing.Point(86, 6);
			this.horizontalTab1.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
			this.horizontalTab1.Name = "horizontalTab1";
			this.horizontalTab1.Size = new System.Drawing.Size(484, 361);
			this.horizontalTab1.TabIndex = 0;
			this.horizontalTab1.Text = "standard";
			this.horizontalTab1.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// horizontalTab3
			// 
			this.horizontalTab3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(241)), ((System.Byte)(229)));
			this.horizontalTab3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTab3.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
			this.horizontalTab3.Location = new System.Drawing.Point(86, 6);
			this.horizontalTab3.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
			this.horizontalTab3.Name = "horizontalTab3";
			this.horizontalTab3.Size = new System.Drawing.Size(484, 361);
			this.horizontalTab3.TabIndex = 2;
			this.horizontalTab3.Text = "standard 2";
			this.horizontalTab3.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// horizontalTab4
			// 
			this.horizontalTab4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(241)), ((System.Byte)(229)));
			this.horizontalTab4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTab4.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
			this.horizontalTab4.Location = new System.Drawing.Point(86, 6);
			this.horizontalTab4.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
			this.horizontalTab4.Name = "horizontalTab4";
			this.horizontalTab4.Size = new System.Drawing.Size(484, 361);
			this.horizontalTab4.TabIndex = 3;
			this.horizontalTab4.Text = "horizontalTab4";
			this.horizontalTab4.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// horizontalTab5
			// 
			this.horizontalTab5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(241)), ((System.Byte)(229)));
			this.horizontalTab5.Controls.Add(this.geniusTreeView1);
			this.horizontalTab5.Controls.Add(this.textBox1);
			this.horizontalTab5.Controls.Add(this.button1);
			this.horizontalTab5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTab5.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
			this.horizontalTab5.Location = new System.Drawing.Point(86, 6);
			this.horizontalTab5.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
			this.horizontalTab5.Name = "horizontalTab5";
			this.horizontalTab5.Size = new System.Drawing.Size(484, 361);
			this.horizontalTab5.TabIndex = 4;
			this.horizontalTab5.Text = "horizontalTab5";
			this.horizontalTab5.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 112);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(344, 216);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(80, 40);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// horizontalTab6
			// 
			this.horizontalTab6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(243)), ((System.Byte)(241)), ((System.Byte)(229)));
			this.horizontalTab6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.horizontalTab6.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
			this.horizontalTab6.Location = new System.Drawing.Point(86, 6);
			this.horizontalTab6.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
			this.horizontalTab6.Name = "horizontalTab6";
			this.horizontalTab6.Size = new System.Drawing.Size(484, 361);
			this.horizontalTab6.TabIndex = 5;
			this.horizontalTab6.Text = "horizontalTab6";
			this.horizontalTab6.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
			// GeniusTreeView By Pierrick Gourlain
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
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
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.Header.MainColumnIndex = -1;
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(216, 24);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.Size = new System.Drawing.Size(208, 80);
			this.geniusTreeView1.TabIndex = 2;
			this.geniusTreeView1.Text = "geniusTreeView1";
			// 
			// TabbedDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 373);
			this.Controls.Add(this.horizontalTabs1);
			this.Name = "TabbedDemo";
			this.Text = "TabbedDemo";
			this.horizontalTabs1.ResumeLayout(false);
			this.horizontalTab5.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			GeniusPen pen = new GeniusPen(Color.FromArgb(192,192,184), 1, DashStyle.Dot);
			geniusTreeView1.Colors.FocusedRectanglePenColor = pen;

			TypeConverter cnv = TypeDescriptor.GetConverter(typeof(GeniusPen));
			string str = cnv.ConvertToString(pen);
			textBox1.AppendText(Environment.NewLine);
			textBox1.AppendText(str);
			textBox1.AppendText(Environment.NewLine);
			GeniusPen pen1 = (GeniusPen)cnv.ConvertFrom(str);
			str = cnv.ConvertToString(pen1);
			textBox1.AppendText(str);
			str = cnv.ConvertToString(geniusTreeView1.Colors.FocusedRectanglePenColor);
			textBox1.AppendText(str);

		}
	}
}
