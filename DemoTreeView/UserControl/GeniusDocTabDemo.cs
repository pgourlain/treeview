using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace DemoTreeView.UserControl
{
	/// <summary>
	/// Summary description for GeniusDocTabDemo.
	/// </summary>
	public class GeniusDocTabDemo : System.Windows.Forms.UserControl
	{
		private Genius.Controls.DocTabs.GeniusDocTab geniusDocTab1;
		private Genius.Controls.DocTabs.GeniusTab geniusTab1;
		private Genius.Controls.DocTabs.GeniusTab geniusTab2;
		private Genius.Controls.DocTabs.GeniusDocTab geniusDocTab2;
		private Genius.Controls.DocTabs.GeniusTab geniusTab3;
		private Genius.Controls.DocTabs.GeniusTab geniusTab4;
		private Genius.Controls.DocTabs.GeniusTab geniusTab5;
		private Genius.Controls.DocTabs.GeniusTab geniusTab6;
		private Genius.Controls.DocTabs.GeniusDocTab geniusDocTab3;
		private Genius.Controls.DocTabs.GeniusTab geniusTab7;
		private Genius.Controls.DocTabs.GeniusTab geniusTab8;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GeniusDocTabDemo()
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
			this.geniusDocTab1 = new Genius.Controls.DocTabs.GeniusDocTab();
			this.geniusTab1 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusTab2 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusTab5 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusTab6 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusDocTab2 = new Genius.Controls.DocTabs.GeniusDocTab();
			this.geniusTab3 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusTab4 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusDocTab3 = new Genius.Controls.DocTabs.GeniusDocTab();
			this.geniusTab7 = new Genius.Controls.DocTabs.GeniusTab();
			this.geniusTab8 = new Genius.Controls.DocTabs.GeniusTab();
			this.SuspendLayout();
			// 
			// geniusDocTab1
			// 
			this.geniusDocTab1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(213)));
			this.geniusDocTab1.Dock = System.Windows.Forms.DockStyle.Top;
			this.geniusDocTab1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
			this.geniusDocTab1.Location = new System.Drawing.Point(0, 0);
			this.geniusDocTab1.Name = "geniusDocTab1";
			this.geniusDocTab1.SelectedColor = System.Drawing.Color.White;
			this.geniusDocTab1.SelectedIndex = 0;
			this.geniusDocTab1.SelectedLineColor = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(157)), ((System.Byte)(185)));
			this.geniusDocTab1.Size = new System.Drawing.Size(184, 17);
			this.geniusDocTab1.TabIndex = 0;
			this.geniusDocTab1.Tabs.AddRange(new Genius.Controls.DocTabs.GeniusTab[] {
																						 this.geniusTab1,
																						 this.geniusTab2,
																						 this.geniusTab5,
																						 this.geniusTab6});
			this.geniusDocTab1.Text = "geniusDocTab1";
			this.geniusDocTab1.UnSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(213)));
			this.geniusDocTab1.UnSelectedLineColor = System.Drawing.Color.FromArgb(((System.Byte)(172)), ((System.Byte)(158)), ((System.Byte)(153)));
			// 
			// geniusTab1
			// 
			this.geniusTab1.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab1.Text = "abc";
			// 
			// geniusTab2
			// 
			this.geniusTab2.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab2.Text = "def";
			// 
			// geniusTab5
			// 
			this.geniusTab5.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab5.Text = "ghi";
			// 
			// geniusTab6
			// 
			this.geniusTab6.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab6.Text = "klm";
			// 
			// geniusDocTab2
			// 
			this.geniusDocTab2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(213)));
			this.geniusDocTab2.Dock = System.Windows.Forms.DockStyle.Left;
			this.geniusDocTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
			this.geniusDocTab2.Location = new System.Drawing.Point(0, 17);
			this.geniusDocTab2.Name = "geniusDocTab2";
			this.geniusDocTab2.SelectedColor = System.Drawing.Color.White;
			this.geniusDocTab2.SelectedIndex = -1;
			this.geniusDocTab2.SelectedLineColor = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(157)), ((System.Byte)(185)));
			this.geniusDocTab2.Size = new System.Drawing.Size(17, 103);
			this.geniusDocTab2.TabIndex = 1;
			this.geniusDocTab2.TabOrientation = Genius.Controls.DocTabs.TabOrientation.Left;
			this.geniusDocTab2.Tabs.AddRange(new Genius.Controls.DocTabs.GeniusTab[] {
																						 this.geniusTab3,
																						 this.geniusTab4});
			this.geniusDocTab2.Text = "geniusDocTab2";
			this.geniusDocTab2.UnSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(213)));
			this.geniusDocTab2.UnSelectedLineColor = System.Drawing.Color.FromArgb(((System.Byte)(172)), ((System.Byte)(158)), ((System.Byte)(153)));
			// 
			// geniusTab3
			// 
			this.geniusTab3.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab3.Text = "abc";
			// 
			// geniusTab4
			// 
			this.geniusTab4.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab4.Text = "def";
			// 
			// geniusDocTab3
			// 
			this.geniusDocTab3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(213)));
			this.geniusDocTab3.Dock = System.Windows.Forms.DockStyle.Right;
			this.geniusDocTab3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
			this.geniusDocTab3.Location = new System.Drawing.Point(167, 17);
			this.geniusDocTab3.Name = "geniusDocTab3";
			this.geniusDocTab3.SelectedColor = System.Drawing.Color.White;
			this.geniusDocTab3.SelectedIndex = -1;
			this.geniusDocTab3.SelectedLineColor = System.Drawing.Color.FromArgb(((System.Byte)(127)), ((System.Byte)(157)), ((System.Byte)(185)));
			this.geniusDocTab3.Size = new System.Drawing.Size(17, 103);
			this.geniusDocTab3.TabIndex = 2;
			this.geniusDocTab3.TabOrientation = Genius.Controls.DocTabs.TabOrientation.Right;
			this.geniusDocTab3.Tabs.AddRange(new Genius.Controls.DocTabs.GeniusTab[] {
																						 this.geniusTab7,
																						 this.geniusTab8});
			this.geniusDocTab3.Text = "geniusDocTab3";
			this.geniusDocTab3.UnSelectedColor = System.Drawing.Color.FromArgb(((System.Byte)(228)), ((System.Byte)(226)), ((System.Byte)(213)));
			this.geniusDocTab3.UnSelectedLineColor = System.Drawing.Color.FromArgb(((System.Byte)(172)), ((System.Byte)(158)), ((System.Byte)(153)));
			// 
			// geniusTab7
			// 
			this.geniusTab7.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab7.Text = "nop";
			// 
			// geniusTab8
			// 
			this.geniusTab8.Color = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(246)), ((System.Byte)(239)));
			this.geniusTab8.Text = "qrst";
			// 
			// GeniusDocTabDemo
			// 
			this.Controls.Add(this.geniusDocTab3);
			this.Controls.Add(this.geniusDocTab2);
			this.Controls.Add(this.geniusDocTab1);
			this.Name = "GeniusDocTabDemo";
			this.Size = new System.Drawing.Size(184, 120);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
