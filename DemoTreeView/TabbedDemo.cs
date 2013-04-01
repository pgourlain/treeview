using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using DemoTreeView.UC1;
using Genius.Controls.Diagnostics;

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
		private Genius.Controls.UserControls.StandardDemoCtl standardDemoCtl1;
		private Genius.Controls.UserControls.StandardDemo1Ctl standardDemo1Ctl1;
		private DemoTreeView.UserControls.DragAndDropDemoCtl dragAndDropDemoCtl1;
		private Genius.Controls.UserControls.CustomDrawDemoCtl customDrawDemoCtl1;
		private DemoTreeView.UserControls.FixedColumnDemoCtl fixedColumnDemoCtl1;
		private DemoTreeView.UserControls.TestEvents testEvents1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab7;
		private DemoTreeView.UserControls.DemoEditors demoEditors1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab8;
		private DemoTreeView.UserControls.TestChapter testChapter1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab9;
		private DemoTreeView.UserControls.TestDrawingOptions testDrawingOptions1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab10;
		private DemoTreeView.UserControls.TestDataSource testDataSource1;
		private DemoTreeView.UserControls.TestDataSource testDataSource2;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab11;
		private DemoTreeView.UserControls.TestVisibility testVisibility1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab12;
		private DemoTreeView.UserControls.TestHeader testHeader1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab13;
		private System.Windows.Forms.Label label1;
		private Genius.MyTreeView.GtvToolbox2005 gtvToolbox20051;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab14;
		private DemoTreeView.UserControls.GeniusDocTabDemo geniusDocTabDemo1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab15;
		private DemoTreeView.UC1.demoLonghornUC demoLonghornUC1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab16;
		private DemoTreeView.UC1.DemoGrille	demoGrille1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab17;
		private DemoTreeView.UC1.demoSerialization demoSerialization1;
		private Genius.Controls.GeniusTab.HorizontalTab horizontalTab18;
		private DemoTreeView.UserControls.TestIncrementalSearch testIncrementalSearch1;
        private Genius.Controls.GeniusTab.HorizontalTab horizontalTab19;
        private DemoTreeView.UserControls.TestCheckBoxes testCheckBoxes1;
        private Genius.Controls.GeniusTab.HorizontalTab horizontalTab20;
        private DemoTreeView.UC1.demoIStringNodeProvider demoIStringNodeProvider1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabbedDemo));
            this.horizontalTabs1 = new Genius.Controls.GeniusTab.HorizontalTabs();
            this.horizontalTab1 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.standardDemoCtl1 = new Genius.Controls.UserControls.StandardDemoCtl();
            this.horizontalTab2 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.standardDemo1Ctl1 = new Genius.Controls.UserControls.StandardDemo1Ctl();
            this.horizontalTab3 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.dragAndDropDemoCtl1 = new DemoTreeView.UserControls.DragAndDropDemoCtl();
            this.horizontalTab4 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.customDrawDemoCtl1 = new Genius.Controls.UserControls.CustomDrawDemoCtl();
            this.horizontalTab5 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.fixedColumnDemoCtl1 = new DemoTreeView.UserControls.FixedColumnDemoCtl();
            this.horizontalTab6 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testEvents1 = new DemoTreeView.UserControls.TestEvents();
            this.horizontalTab7 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.demoEditors1 = new DemoTreeView.UserControls.DemoEditors();
            this.horizontalTab8 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testChapter1 = new DemoTreeView.UserControls.TestChapter();
            this.horizontalTab9 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testDrawingOptions1 = new DemoTreeView.UserControls.TestDrawingOptions();
            this.horizontalTab10 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testDataSource2 = new DemoTreeView.UserControls.TestDataSource();
            this.horizontalTab11 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testVisibility1 = new DemoTreeView.UserControls.TestVisibility();
            this.horizontalTab12 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testHeader1 = new DemoTreeView.UserControls.TestHeader();
            this.horizontalTab13 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.gtvToolbox20051 = new Genius.MyTreeView.GtvToolbox2005();
            this.label1 = new System.Windows.Forms.Label();
            this.horizontalTab14 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.geniusDocTabDemo1 = new DemoTreeView.UserControls.GeniusDocTabDemo();
            this.horizontalTab15 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.demoLonghornUC1 = new DemoTreeView.UC1.demoLonghornUC();
            this.horizontalTab16 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.demoGrille1 = new DemoTreeView.UC1.DemoGrille();
            this.horizontalTab17 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.demoSerialization1 = new DemoTreeView.UC1.demoSerialization();
            this.horizontalTab18 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testIncrementalSearch1 = new DemoTreeView.UserControls.TestIncrementalSearch();
            this.horizontalTab19 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.testCheckBoxes1 = new DemoTreeView.UserControls.TestCheckBoxes();
            this.horizontalTab20 = new Genius.Controls.GeniusTab.HorizontalTab();
            this.demoIStringNodeProvider1 = new DemoTreeView.UC1.demoIStringNodeProvider();
            this.testDataSource1 = new DemoTreeView.UserControls.TestDataSource();
            this.horizontalTabs1.SuspendLayout();
            this.horizontalTab1.SuspendLayout();
            this.horizontalTab2.SuspendLayout();
            this.horizontalTab3.SuspendLayout();
            this.horizontalTab4.SuspendLayout();
            this.horizontalTab5.SuspendLayout();
            this.horizontalTab6.SuspendLayout();
            this.horizontalTab7.SuspendLayout();
            this.horizontalTab8.SuspendLayout();
            this.horizontalTab9.SuspendLayout();
            this.horizontalTab10.SuspendLayout();
            this.horizontalTab11.SuspendLayout();
            this.horizontalTab12.SuspendLayout();
            this.horizontalTab13.SuspendLayout();
            this.horizontalTab14.SuspendLayout();
            this.horizontalTab15.SuspendLayout();
            this.horizontalTab16.SuspendLayout();
            this.horizontalTab17.SuspendLayout();
            this.horizontalTab18.SuspendLayout();
            this.horizontalTab19.SuspendLayout();
            this.horizontalTab20.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontalTabs1
            // 
            this.horizontalTabs1.Controls.Add(this.horizontalTab1);
            this.horizontalTabs1.Controls.Add(this.horizontalTab2);
            this.horizontalTabs1.Controls.Add(this.horizontalTab3);
            this.horizontalTabs1.Controls.Add(this.horizontalTab4);
            this.horizontalTabs1.Controls.Add(this.horizontalTab5);
            this.horizontalTabs1.Controls.Add(this.horizontalTab6);
            this.horizontalTabs1.Controls.Add(this.horizontalTab7);
            this.horizontalTabs1.Controls.Add(this.horizontalTab8);
            this.horizontalTabs1.Controls.Add(this.horizontalTab9);
            this.horizontalTabs1.Controls.Add(this.horizontalTab10);
            this.horizontalTabs1.Controls.Add(this.horizontalTab11);
            this.horizontalTabs1.Controls.Add(this.horizontalTab12);
            this.horizontalTabs1.Controls.Add(this.horizontalTab13);
            this.horizontalTabs1.Controls.Add(this.horizontalTab14);
            this.horizontalTabs1.Controls.Add(this.horizontalTab15);
            this.horizontalTabs1.Controls.Add(this.horizontalTab16);
            this.horizontalTabs1.Controls.Add(this.horizontalTab17);
            this.horizontalTabs1.Controls.Add(this.horizontalTab18);
            this.horizontalTabs1.Controls.Add(this.horizontalTab19);
            this.horizontalTabs1.Controls.Add(this.horizontalTab20);
            this.horizontalTabs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTabs1.Location = new System.Drawing.Point(0, 0);
            this.horizontalTabs1.Margins = 5;
            this.horizontalTabs1.Name = "horizontalTabs1";
            this.horizontalTabs1.Orientation = Genius.Controls.GeniusTab.TabOrientation.Left;
            this.horizontalTabs1.SelectedIndex = 0;
            this.horizontalTabs1.Size = new System.Drawing.Size(544, 631);
            this.horizontalTabs1.TabIndex = 0;
            this.horizontalTabs1.TabsHeight = 30;
            this.horizontalTabs1.TabsWidth = 85;
            this.horizontalTabs1.Text = "FixedColumn";
            // 
            // horizontalTab1
            // 
            this.horizontalTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab1.Controls.Add(this.standardDemoCtl1);
            this.horizontalTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab1.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab1.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab1.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab1.Name = "horizontalTab1";
            this.horizontalTab1.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab1.TabIndex = 0;
            this.horizontalTab1.Text = "standard";
            this.horizontalTab1.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // standardDemoCtl1
            // 
            this.standardDemoCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardDemoCtl1.Location = new System.Drawing.Point(0, 0);
            this.standardDemoCtl1.Name = "standardDemoCtl1";
            this.standardDemoCtl1.Size = new System.Drawing.Size(447, 619);
            this.standardDemoCtl1.TabIndex = 0;
            // 
            // horizontalTab2
            // 
            this.horizontalTab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab2.Controls.Add(this.standardDemo1Ctl1);
            this.horizontalTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab2.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab2.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab2.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab2.Name = "horizontalTab2";
            this.horizontalTab2.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab2.TabIndex = 1;
            this.horizontalTab2.Text = "tree-listview demo";
            this.horizontalTab2.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // standardDemo1Ctl1
            // 
            this.standardDemo1Ctl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standardDemo1Ctl1.Location = new System.Drawing.Point(0, 0);
            this.standardDemo1Ctl1.Name = "standardDemo1Ctl1";
            this.standardDemo1Ctl1.Size = new System.Drawing.Size(447, 619);
            this.standardDemo1Ctl1.TabIndex = 0;
            // 
            // horizontalTab3
            // 
            this.horizontalTab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab3.Controls.Add(this.dragAndDropDemoCtl1);
            this.horizontalTab3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab3.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab3.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab3.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab3.Name = "horizontalTab3";
            this.horizontalTab3.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab3.TabIndex = 2;
            this.horizontalTab3.Text = "drag and drop";
            this.horizontalTab3.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // dragAndDropDemoCtl1
            // 
            this.dragAndDropDemoCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dragAndDropDemoCtl1.Location = new System.Drawing.Point(0, 0);
            this.dragAndDropDemoCtl1.Name = "dragAndDropDemoCtl1";
            this.dragAndDropDemoCtl1.Size = new System.Drawing.Size(447, 619);
            this.dragAndDropDemoCtl1.TabIndex = 0;
            // 
            // horizontalTab4
            // 
            this.horizontalTab4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab4.Controls.Add(this.customDrawDemoCtl1);
            this.horizontalTab4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab4.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab4.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab4.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab4.Name = "horizontalTab4";
            this.horizontalTab4.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab4.TabIndex = 3;
            this.horizontalTab4.Text = "CustomDraw";
            this.horizontalTab4.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // customDrawDemoCtl1
            // 
            this.customDrawDemoCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customDrawDemoCtl1.Location = new System.Drawing.Point(0, 0);
            this.customDrawDemoCtl1.Name = "customDrawDemoCtl1";
            this.customDrawDemoCtl1.Size = new System.Drawing.Size(447, 619);
            this.customDrawDemoCtl1.TabIndex = 0;
            // 
            // horizontalTab5
            // 
            this.horizontalTab5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab5.Controls.Add(this.fixedColumnDemoCtl1);
            this.horizontalTab5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab5.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab5.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab5.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab5.Name = "horizontalTab5";
            this.horizontalTab5.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab5.TabIndex = 4;
            this.horizontalTab5.Text = "FixedColumns";
            this.horizontalTab5.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // fixedColumnDemoCtl1
            // 
            this.fixedColumnDemoCtl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fixedColumnDemoCtl1.Location = new System.Drawing.Point(0, 0);
            this.fixedColumnDemoCtl1.Name = "fixedColumnDemoCtl1";
            this.fixedColumnDemoCtl1.Size = new System.Drawing.Size(447, 619);
            this.fixedColumnDemoCtl1.TabIndex = 0;
            // 
            // horizontalTab6
            // 
            this.horizontalTab6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab6.Controls.Add(this.testEvents1);
            this.horizontalTab6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab6.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab6.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab6.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab6.Name = "horizontalTab6";
            this.horizontalTab6.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab6.TabIndex = 5;
            this.horizontalTab6.Text = "TestEvents";
            this.horizontalTab6.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testEvents1
            // 
            this.testEvents1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testEvents1.Location = new System.Drawing.Point(0, 0);
            this.testEvents1.Name = "testEvents1";
            this.testEvents1.Size = new System.Drawing.Size(447, 619);
            this.testEvents1.TabIndex = 0;
            // 
            // horizontalTab7
            // 
            this.horizontalTab7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab7.Controls.Add(this.demoEditors1);
            this.horizontalTab7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab7.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab7.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab7.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab7.Name = "horizontalTab7";
            this.horizontalTab7.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab7.TabIndex = 6;
            this.horizontalTab7.Text = "Editor Démo";
            this.horizontalTab7.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // demoEditors1
            // 
            this.demoEditors1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.demoEditors1.Location = new System.Drawing.Point(0, 0);
            this.demoEditors1.Name = "demoEditors1";
            this.demoEditors1.Size = new System.Drawing.Size(447, 619);
            this.demoEditors1.TabIndex = 0;
            // 
            // horizontalTab8
            // 
            this.horizontalTab8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab8.Controls.Add(this.testChapter1);
            this.horizontalTab8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab8.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab8.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab8.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab8.Name = "horizontalTab8";
            this.horizontalTab8.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab8.TabIndex = 7;
            this.horizontalTab8.Text = "Chapter";
            this.horizontalTab8.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testChapter1
            // 
            this.testChapter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testChapter1.Location = new System.Drawing.Point(0, 0);
            this.testChapter1.Name = "testChapter1";
            this.testChapter1.Size = new System.Drawing.Size(447, 619);
            this.testChapter1.TabIndex = 0;
            // 
            // horizontalTab9
            // 
            this.horizontalTab9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab9.Controls.Add(this.testDrawingOptions1);
            this.horizontalTab9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab9.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab9.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab9.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab9.Name = "horizontalTab9";
            this.horizontalTab9.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab9.TabIndex = 8;
            this.horizontalTab9.Text = "DrawingOption";
            this.horizontalTab9.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testDrawingOptions1
            // 
            this.testDrawingOptions1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testDrawingOptions1.Location = new System.Drawing.Point(0, 0);
            this.testDrawingOptions1.Name = "testDrawingOptions1";
            this.testDrawingOptions1.Size = new System.Drawing.Size(447, 619);
            this.testDrawingOptions1.TabIndex = 0;
            // 
            // horizontalTab10
            // 
            this.horizontalTab10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab10.Controls.Add(this.testDataSource2);
            this.horizontalTab10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab10.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab10.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab10.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab10.Name = "horizontalTab10";
            this.horizontalTab10.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab10.TabIndex = 9;
            this.horizontalTab10.Text = "DataSource";
            this.horizontalTab10.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testDataSource2
            // 
            this.testDataSource2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testDataSource2.Location = new System.Drawing.Point(0, 0);
            this.testDataSource2.Name = "testDataSource2";
            this.testDataSource2.Size = new System.Drawing.Size(447, 619);
            this.testDataSource2.TabIndex = 0;
            // 
            // horizontalTab11
            // 
            this.horizontalTab11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab11.Controls.Add(this.testVisibility1);
            this.horizontalTab11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab11.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab11.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab11.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab11.Name = "horizontalTab11";
            this.horizontalTab11.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab11.TabIndex = 10;
            this.horizontalTab11.Text = "test visibilité";
            this.horizontalTab11.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testVisibility1
            // 
            this.testVisibility1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testVisibility1.Location = new System.Drawing.Point(0, 0);
            this.testVisibility1.Name = "testVisibility1";
            this.testVisibility1.Size = new System.Drawing.Size(447, 619);
            this.testVisibility1.TabIndex = 0;
            // 
            // horizontalTab12
            // 
            this.horizontalTab12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab12.Controls.Add(this.testHeader1);
            this.horizontalTab12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab12.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab12.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab12.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab12.Name = "horizontalTab12";
            this.horizontalTab12.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab12.TabIndex = 11;
            this.horizontalTab12.Text = "Test Header";
            this.horizontalTab12.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testHeader1
            // 
            this.testHeader1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testHeader1.Location = new System.Drawing.Point(0, 0);
            this.testHeader1.Name = "testHeader1";
            this.testHeader1.Size = new System.Drawing.Size(447, 619);
            this.testHeader1.TabIndex = 0;
            // 
            // horizontalTab13
            // 
            this.horizontalTab13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab13.Controls.Add(this.gtvToolbox20051);
            this.horizontalTab13.Controls.Add(this.label1);
            this.horizontalTab13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab13.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab13.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab13.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab13.Name = "horizontalTab13";
            this.horizontalTab13.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab13.TabIndex = 12;
            this.horizontalTab13.Text = "ToolBox 2005";
            this.horizontalTab13.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // gtvToolbox20051
            // 
            this.gtvToolbox20051.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtvToolbox20051.Location = new System.Drawing.Point(0, 23);
            this.gtvToolbox20051.Name = "gtvToolbox20051";
            this.gtvToolbox20051.Size = new System.Drawing.Size(447, 596);
            this.gtvToolbox20051.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "cela ne vous rappelle rien... et oui, la toolbox de Visual Studio 2005";
            // 
            // horizontalTab14
            // 
            this.horizontalTab14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab14.Controls.Add(this.geniusDocTabDemo1);
            this.horizontalTab14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab14.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab14.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab14.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab14.Name = "horizontalTab14";
            this.horizontalTab14.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab14.TabIndex = 13;
            this.horizontalTab14.Text = "DocTab Demo";
            this.horizontalTab14.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // geniusDocTabDemo1
            // 
            this.geniusDocTabDemo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geniusDocTabDemo1.Location = new System.Drawing.Point(0, 0);
            this.geniusDocTabDemo1.Name = "geniusDocTabDemo1";
            this.geniusDocTabDemo1.Size = new System.Drawing.Size(447, 619);
            this.geniusDocTabDemo1.TabIndex = 0;
            // 
            // horizontalTab15
            // 
            this.horizontalTab15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab15.Controls.Add(this.demoLonghornUC1);
            this.horizontalTab15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab15.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab15.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab15.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab15.Name = "horizontalTab15";
            this.horizontalTab15.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab15.TabIndex = 14;
            this.horizontalTab15.Text = "Longhorn démo";
            this.horizontalTab15.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // demoLonghornUC1
            // 
            this.demoLonghornUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.demoLonghornUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.demoLonghornUC1.Location = new System.Drawing.Point(0, 0);
            this.demoLonghornUC1.Name = "demoLonghornUC1";
            this.demoLonghornUC1.Size = new System.Drawing.Size(447, 619);
            this.demoLonghornUC1.TabIndex = 0;
            // 
            // horizontalTab16
            // 
            this.horizontalTab16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab16.Controls.Add(this.demoGrille1);
            this.horizontalTab16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab16.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab16.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab16.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab16.Name = "horizontalTab16";
            this.horizontalTab16.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab16.TabIndex = 15;
            this.horizontalTab16.Text = "TestGrille";
            this.horizontalTab16.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // demoGrille1
            // 
            this.demoGrille1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.demoGrille1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.demoGrille1.Location = new System.Drawing.Point(0, 0);
            this.demoGrille1.Name = "demoGrille1";
            this.demoGrille1.Size = new System.Drawing.Size(447, 619);
            this.demoGrille1.TabIndex = 0;
            // 
            // horizontalTab17
            // 
            this.horizontalTab17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab17.Controls.Add(this.demoSerialization1);
            this.horizontalTab17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab17.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab17.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab17.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab17.Name = "horizontalTab17";
            this.horizontalTab17.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab17.TabIndex = 16;
            this.horizontalTab17.Text = "Démo sérialisation";
            this.horizontalTab17.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // demoSerialization1
            // 
            this.demoSerialization1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.demoSerialization1.Location = new System.Drawing.Point(0, 0);
            this.demoSerialization1.Name = "demoSerialization1";
            this.demoSerialization1.Size = new System.Drawing.Size(447, 619);
            this.demoSerialization1.TabIndex = 0;
            // 
            // horizontalTab18
            // 
            this.horizontalTab18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab18.Controls.Add(this.testIncrementalSearch1);
            this.horizontalTab18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab18.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab18.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab18.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab18.Name = "horizontalTab18";
            this.horizontalTab18.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab18.TabIndex = 17;
            this.horizontalTab18.Text = "Incremental Search";
            this.horizontalTab18.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testIncrementalSearch1
            // 
            this.testIncrementalSearch1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testIncrementalSearch1.Location = new System.Drawing.Point(0, 0);
            this.testIncrementalSearch1.Name = "testIncrementalSearch1";
            this.testIncrementalSearch1.Size = new System.Drawing.Size(447, 619);
            this.testIncrementalSearch1.TabIndex = 0;
            // 
            // horizontalTab19
            // 
            this.horizontalTab19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab19.Controls.Add(this.testCheckBoxes1);
            this.horizontalTab19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab19.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab19.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab19.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab19.Name = "horizontalTab19";
            this.horizontalTab19.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab19.TabIndex = 18;
            this.horizontalTab19.Text = "Démo CheckBox ";
            this.horizontalTab19.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // testCheckBoxes1
            // 
            this.testCheckBoxes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testCheckBoxes1.Location = new System.Drawing.Point(0, 0);
            this.testCheckBoxes1.Name = "testCheckBoxes1";
            this.testCheckBoxes1.Size = new System.Drawing.Size(447, 619);
            this.testCheckBoxes1.TabIndex = 0;
            // 
            // horizontalTab20
            // 
            this.horizontalTab20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(241)))), ((int)(((byte)(229)))));
            this.horizontalTab20.Controls.Add(this.demoIStringNodeProvider1);
            this.horizontalTab20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalTab20.HorizontalTextAlignement = System.Drawing.StringAlignment.Near;
            this.horizontalTab20.Location = new System.Drawing.Point(91, 6);
            this.horizontalTab20.Margins = new Genius.Controls.GeniusTab.TabMargins(0, 0, 0, 0);
            this.horizontalTab20.Name = "horizontalTab20";
            this.horizontalTab20.Size = new System.Drawing.Size(447, 619);
            this.horizontalTab20.TabIndex = 19;
            this.horizontalTab20.Text = "Démo IString Node Provider";
            this.horizontalTab20.VerticalTextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // demoIStringNodeProvider1
            // 
            this.demoIStringNodeProvider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.demoIStringNodeProvider1.Location = new System.Drawing.Point(0, 0);
            this.demoIStringNodeProvider1.Name = "demoIStringNodeProvider1";
            this.demoIStringNodeProvider1.Size = new System.Drawing.Size(447, 619);
            this.demoIStringNodeProvider1.TabIndex = 0;
            // 
            // testDataSource1
            // 
            this.testDataSource1.Location = new System.Drawing.Point(0, 0);
            this.testDataSource1.Name = "testDataSource1";
            this.testDataSource1.Size = new System.Drawing.Size(304, 320);
            this.testDataSource1.TabIndex = 0;
            // 
            // TabbedDemo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(544, 631);
            this.Controls.Add(this.horizontalTabs1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TabbedDemo";
            this.Text = "TabbedDemo";
            this.horizontalTabs1.ResumeLayout(false);
            this.horizontalTab1.ResumeLayout(false);
            this.horizontalTab2.ResumeLayout(false);
            this.horizontalTab3.ResumeLayout(false);
            this.horizontalTab4.ResumeLayout(false);
            this.horizontalTab5.ResumeLayout(false);
            this.horizontalTab6.ResumeLayout(false);
            this.horizontalTab7.ResumeLayout(false);
            this.horizontalTab8.ResumeLayout(false);
            this.horizontalTab9.ResumeLayout(false);
            this.horizontalTab10.ResumeLayout(false);
            this.horizontalTab11.ResumeLayout(false);
            this.horizontalTab12.ResumeLayout(false);
            this.horizontalTab13.ResumeLayout(false);
            this.horizontalTab14.ResumeLayout(false);
            this.horizontalTab15.ResumeLayout(false);
            this.horizontalTab16.ResumeLayout(false);
            this.horizontalTab17.ResumeLayout(false);
            this.horizontalTab18.ResumeLayout(false);
            this.horizontalTab19.ResumeLayout(false);
            this.horizontalTab20.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	}
}
