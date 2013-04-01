namespace DemoTreeView
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.horizontalTabs2 = new Genius.Controls.GeniusTab.HorizontalTabs();
            this.horizontalTab21 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.autoSizeColumnUC1 = new DemoTreeView.Samples1.AutoSizeColumnUC();
            this.horizontalTab1 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne5 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne6 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne7 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.horizontalTabs2.SuspendLayout();
            this.horizontalTab21.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.horizontalTabs2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 485);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "basic samples";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // horizontalTabs2
            // 
            this.horizontalTabs2.Controls.Add(this.horizontalTab21);
            this.horizontalTabs2.Controls.Add(this.horizontalTab1);
            this.horizontalTabs2.Dock = System.Windows.Forms.DockStyle.Top;
            this.horizontalTabs2.Location = new System.Drawing.Point(3, 3);
            this.horizontalTabs2.Margins = 5;
            this.horizontalTabs2.Name = "horizontalTabs2";
            this.horizontalTabs2.Orientation = Genius.Controls.GeniusTab.TabOrientation.Left;
            this.horizontalTabs2.SelectedIndex = 1;
            this.horizontalTabs2.Size = new System.Drawing.Size(599, 474);
            this.horizontalTabs2.TabIndex = 0;
            this.horizontalTabs2.TabsHeight = 30;
            this.horizontalTabs2.TabsWidth = 105;
            this.horizontalTabs2.Text = "horizontalTabs2";
            // 
            // horizontalTab21
            // 
            this.horizontalTab21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab21.Controls.Add(this.autoSizeColumnUC1);
            this.horizontalTab21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab21.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab21.Location = new System.Drawing.Point(111, 6);
            this.horizontalTab21.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab21.Name = "horizontalTab21";
            this.horizontalTab21.Size = new System.Drawing.Size(482, 462);
            this.horizontalTab21.TabIndex = 0;
            this.horizontalTab21.Text = "AutoSizeColumn";
            this.horizontalTab21.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // autoSizeColumnUC1
            // 
            this.autoSizeColumnUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoSizeColumnUC1.Location = new System.Drawing.Point(0, 0);
            this.autoSizeColumnUC1.Name = "autoSizeColumnUC1";
            this.autoSizeColumnUC1.Size = new System.Drawing.Size(482, 462);
            this.autoSizeColumnUC1.TabIndex = 2;
            this.autoSizeColumnUC1.Load += new System.EventHandler(this.autoSizeColumnUC1_Load);
            // 
            // horizontalTab1
            // 
            this.horizontalTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab1.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab1.Location = new System.Drawing.Point(111, 6);
            this.horizontalTab1.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab1.Name = "horizontalTab1";
            this.horizontalTab1.Size = new System.Drawing.Size(482, 462);
            this.horizontalTab1.TabIndex = 1;
            this.horizontalTab1.Text = "horizontalTab1";
            this.horizontalTab1.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 485);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "others samples";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "click to show other samples";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // geniusTreeViewColonne1
            // 
            this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne1.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne1.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne1.Text = "Colonne 0";
            this.geniusTreeViewColonne1.Width = 25;
            // 
            // geniusTreeViewColonne2
            // 
            this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne2.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne2.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne2.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne2.Text = "Colonne 1";
            this.geniusTreeViewColonne2.Width = 25;
            // 
            // geniusTreeViewColonne3
            // 
            this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne3.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne3.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne3.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne3.Text = "Colonne 2";
            this.geniusTreeViewColonne3.Width = 131;
            // 
            // geniusTreeViewColonne4
            // 
            this.geniusTreeViewColonne4.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne4.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne4.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne4.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne4.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne4.Text = "Colonne 3";
            // 
            // geniusTreeViewColonne5
            // 
            this.geniusTreeViewColonne5.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne5.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne5.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne5.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne5.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne5.Text = "Colonne 4";
            // 
            // geniusTreeViewColonne6
            // 
            this.geniusTreeViewColonne6.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne6.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne6.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne6.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne6.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne6.Text = "Colonne 5";
            // 
            // geniusTreeViewColonne7
            // 
            this.geniusTreeViewColonne7.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne7.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.geniusTreeViewColonne7.ForeColor = System.Drawing.Color.Black;
            this.geniusTreeViewColonne7.ForeTextColor = System.Drawing.Color.Empty;
            this.geniusTreeViewColonne7.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.geniusTreeViewColonne7.Text = "Colonne 6";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 511);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainFrm";
            this.Text = "geniustreeview samples demo ";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.horizontalTabs2.ResumeLayout(false);
            this.horizontalTab21.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Genius.Controls.UserControls.StandardDemoCtl standardDemoCtl1;
        private Genius.Controls.UserControls.StandardDemo1Ctl standardDemo1Ctl1;
        private DemoTreeView.UserControls.DragAndDropDemoCtl dragAndDropDemoCtl1;
        private Genius.Controls.UserControls.CustomDrawDemoCtl customDrawDemoCtl1;
        private DemoTreeView.UserControls.FixedColumnDemoCtl fixedColumnDemoCtl1;
        private DemoTreeView.UserControls.TestEvents testEvents1;
        private DemoTreeView.UserControls.DemoEditors demoEditors1;
        private DemoTreeView.UserControls.TestChapter testChapter1;
        private DemoTreeView.UserControls.TestDrawingOptions testDrawingOptions1;
        private DemoTreeView.UserControls.TestDataSource testDataSource2;
        private DemoTreeView.UserControls.TestVisibility testVisibility1;
        private DemoTreeView.UserControls.TestHeader testHeader1;
        private DemoTreeView.UserControls.GeniusDocTabDemo geniusDocTabDemo1;
        private DemoTreeView.UC1.demoLonghornUC demoLonghornUC1;
        private DemoTreeView.UC1.DemoGrille demoGrille1;
        private DemoTreeView.UC1.demoSerialization demoSerialization1;
        private DemoTreeView.UserControls.TestIncrementalSearch testIncrementalSearch1;
        private DemoTreeView.UserControls.TestCheckBoxes testCheckBoxes1;
        private DemoTreeView.UC1.demoIStringNodeProvider demoIStringNodeProvider1;
        private Genius.Controls.GeniusTab.HorizontalTabs horizontalTabs2;
        private Genius.Controls.GeniusTab.HorizontalTab horizontalTab21;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne5;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne6;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne7;
        private System.Windows.Forms.Button button1;
        private DemoTreeView.Samples1.AutoSizeColumnUC autoSizeColumnUC1;
        private Genius.Controls.GeniusTab.HorizontalTab horizontalTab1;
    }
}