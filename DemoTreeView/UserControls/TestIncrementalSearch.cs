using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Genius.Controls.TreeView;
using System.IO;
using System.Reflection;

namespace DemoTreeView.UserControls
{
	/// <summary>
	/// Summary description for TestIncrementalSearch.
	/// </summary>
	public class TestIncrementalSearch : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private Genius.Controls.TreeView.GeniusTreeView gtv;
        private System.Windows.Forms.TextBox tbSearch;
        private CheckBox checkBox1;
        private Label label1;
        private IContainer components;

		public TestIncrementalSearch()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestIncrementalSearch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 56);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Centrer la vue";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Location = new System.Drawing.Point(208, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(136, 20);
            this.tbSearch.TabIndex = 0;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gtv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 248);
            this.panel2.TabIndex = 1;
            // GeniusTreeView By Pierrick Gourlain
            // 
            // gtv
            // 
            this.gtv.Alignment = System.Drawing.StringAlignment.Near;
            this.gtv.AutoSort = false;
            this.gtv.BackColor = System.Drawing.SystemColors.Window;
            this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gtv.Colors.FocusedRectanglePenColor = ((Genius.Controls.TreeView.Colors.GeniusPen)(resources.GetObject("gtv.Colors.FocusedRectanglePenColor")));
            this.gtv.Colors.SelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.gtv.Colors.SignaledPenColor = ((Genius.Controls.TreeView.Colors.GeniusPen)(resources.GetObject("gtv.Colors.SignaledPenColor")));
            this.gtv.Colors.TextColor = System.Drawing.Color.Black;
            this.gtv.Colors.UnFocusedRectanglePenColor = ((Genius.Controls.TreeView.Colors.GeniusPen)(resources.GetObject("gtv.Colors.UnFocusedRectanglePenColor")));
            this.gtv.DefaultDrawingOption = ((Genius.Controls.TreeView.DrawingOptions)((Genius.Controls.TreeView.DrawingOptions.ShowVertLines | Genius.Controls.TreeView.DrawingOptions.ShowHorzLines)));
            this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtv.ElapsedHint = 500;
            this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtv.Header.ImageList = null;
            this.gtv.Header.MainColumnIndex = -1;
            this.gtv.KeysGridMode = false;
            this.gtv.Location = new System.Drawing.Point(0, 0);
            this.gtv.Name = "gtv";
            this.gtv.Size = new System.Drawing.Size(352, 248);
            this.gtv.TabIndex = 1;
            this.gtv.Text = "geniusTreeView1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // TestIncrementalSearch
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TestIncrementalSearch";
            this.Size = new System.Drawing.Size(352, 304);
            this.Load += new System.EventHandler(this.TestIncrementalSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void tbSearch_TextChanged(object sender, System.EventArgs e)
		{
			INode n = gtv.Search(tbSearch.Text);
			if (n != null)
			{
				gtv.SelectNode(n);
				gtv.ShowNode(n,checkBox1.Checked);
			}
		}

		private void TestIncrementalSearch_Load(object sender, System.EventArgs e)
		{
			gtv.BeginUpdate();
			try
			{
                string location = Assembly.GetExecutingAssembly().Location;
                location = Path.GetDirectoryName(location);
                location = Path.Combine(location, "list-raw.txt");
                if (File.Exists(location))
                {
                    string file = location;
                    using (StreamReader sr = File.OpenText(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            gtv.Add(null, line, null);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 26; i++)
                    {
                        char c = (char)(i + 97);
                        INode n = gtv.Add(null, new string(c, 1), null);
                        Add(n, c);
                    }
                }
                label1.Text = "nodes count :" + gtv.Count.ToString();
				gtv.ExpandAll();
			}
			finally
			{
				gtv.EndUpdate();	
			}
		}

		private void Add(INode n, char c)
		{
			switch(c)
			{
				case 'a' :
					gtv.Add(n, "ananas", null);
					break;
				case 'b' :
					gtv.Add(n, "banane", null);
					break;
				case 'c' :
					gtv.Add(n, "clementine", null);
					break;
				case 'd' :
					gtv.Add(n, "date", null);
					break;
				case 'e' :
					gtv.Add(n, "echalote", null);
					break;
				case 'f' :
					gtv.Add(n, "fraise", null);
					break;
				case 'g' :
					gtv.Add(n, "goyave", null);
					break;
				case 'h' :
					gtv.Add(n, "haricot", null);
					break;
				case 'i' :
					gtv.Add(n, "iris", null);
					break;
				case 'j' :
					gtv.Add(n, "jasmin", null);
					gtv.Add(n, "jonquille", null);
					break;
				case 'm' :
					gtv.Add(n, "myrtille", null);
					gtv.Add(n, "marguerite", null);
					gtv.Add(n, "mure", null);
					break;
			}
		}
	}
}
