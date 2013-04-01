using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Genius.Controls.TreeView.Serialization;

namespace DemoTreeView.UC1
{
	/// <summary>
	/// Summary description for demoSerialization.
	/// </summary>
	public class demoSerialization : System.Windows.Forms.UserControl
	{
		private Genius.Controls.TreeView.GeniusTreeView gtv;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mitCopy;
		private System.Windows.Forms.MenuItem mitPasteUnder;
		private System.Windows.Forms.MenuItem mitCut;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mitLoad;
		private System.Windows.Forms.Label lblInfo;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public demoSerialization()
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
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mitCut = new System.Windows.Forms.MenuItem();
			this.mitCopy = new System.Windows.Forms.MenuItem();
			this.mitPasteUnder = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mitLoad = new System.Windows.Forms.MenuItem();
			this.lblInfo = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AutoSort = false;
			this.gtv.BackColor = System.Drawing.SystemColors.Window;
			this.gtv.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
			this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
			this.gtv.ContextMenu = this.contextMenu1;
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOptions.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.ElapsedHint = 500;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.ImageList = null;
			this.gtv.Header.MainColumnIndex = -1;
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 0);
			this.gtv.Name = "gtv";
			this.gtv.Size = new System.Drawing.Size(352, 241);
			this.gtv.TabIndex = 0;
			this.gtv.Text = "geniusTreeView1";
			this.gtv.Click += new System.EventHandler(this.gtv_Click);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.mitCut,
																						 this.mitCopy,
																						 this.mitPasteUnder,
																						 this.menuItem1,
																						 this.mitLoad});
			this.contextMenu1.Popup += new System.EventHandler(this.contextMenu1_Popup);
			// 
			// mitCut
			// 
			this.mitCut.Index = 0;
			this.mitCut.Text = "C&ut";
			this.mitCut.Click += new System.EventHandler(this.mitCut_Click);
			// 
			// mitCopy
			// 
			this.mitCopy.Index = 1;
			this.mitCopy.Text = "&Copy";
			this.mitCopy.Click += new System.EventHandler(this.mitCopy_Click);
			// 
			// mitPasteUnder
			// 
			this.mitPasteUnder.Index = 2;
			this.mitPasteUnder.Text = "&Paste Under";
			this.mitPasteUnder.Click += new System.EventHandler(this.mitPasteUnder_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// mitLoad
			// 
			this.mitLoad.Index = 4;
			this.mitLoad.Text = "&Load";
			this.mitLoad.Click += new System.EventHandler(this.mitLoad_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblInfo.Location = new System.Drawing.Point(0, 241);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(352, 23);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text = "utilisez le clic droit, Copy, Paste, ... utilise la sérialisation";
			// 
			// demoSerialization
			// 
			this.Controls.Add(this.gtv);
			this.Controls.Add(this.lblInfo);
			this.Name = "demoSerialization";
			this.Size = new System.Drawing.Size(352, 264);
			this.ResumeLayout(false);

		}
		#endregion

		private void contextMenu1_Popup(object sender, System.EventArgs e)
		{
			mitPasteUnder.Enabled = gtv.SelectedNode != null && HaveClipBoard;
			mitCopy.Enabled = gtv.SelectedNode != null;
			mitCut.Enabled = mitCopy.Enabled;
		}

		private void mitCut_Click(object sender, System.EventArgs e)
		{
			mitCopy_Click(sender, e);
			gtv.Delete(gtv.SelectedNode);
		}

		private void mitCopy_Click(object sender, System.EventArgs e)
		{
			DataFormats.Format myFormat = DataFormats.GetFormat("demoSerialisation");
			
			MemoryStream mem = new MemoryStream(); 
			SerializationHelper.Serialize(gtv, mem, gtv.SelectedNode, false);
			DataObject myDataObject = new DataObject(myFormat.Name, mem);
			Clipboard.SetDataObject(myDataObject);
		}

		private void mitLoad_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog of = new OpenFileDialog();
			of.InitialDirectory = Application.ExecutablePath;
			if (of.ShowDialog() == DialogResult.OK)
			{
				SerializationHelper.DeSerialize(gtv, of.FileName);
			}
		}

		private void mitPasteUnder_Click(object sender, System.EventArgs e)
		{
			SerializationHelper.DeSerialize(gtv, Clipboard.GetDataObject().GetData("demoSerialisation") as Stream, gtv.SelectedNode);
		}

		private void gtv_Click(object sender, System.EventArgs e)
		{
		
		}

		private bool HaveClipBoard
		{
			get
			{
				return Clipboard.GetDataObject().GetDataPresent("demoSerialisation");
			}
		}
	}
}
