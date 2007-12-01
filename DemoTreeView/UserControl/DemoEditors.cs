using System;
using System.ComponentModel;
using System.Windows.Forms;
using Genius.Controls.TreeView;
using Genius.Controls.TreeView.Editors;

namespace DemoTreeView.UserControl
{
	/// <summary>
	/// Summary description for DemoEditors.
	/// </summary>
	public class DemoEditors : System.Windows.Forms.UserControl
	{
		private GeniusTreeView geniusTreeView1;
		private GeniusTreeViewColonne geniusTreeViewColonne1;
		private GeniusTreeViewColonne geniusTreeViewColonne2;
		private GeniusTreeViewColonne geniusTreeViewColonne3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public DemoEditors()
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
			this.geniusTreeView1 = new Genius.Controls.TreeView.GeniusTreeView();
			this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
			this.SuspendLayout();
			// GeniusTreeView By Pierrick Gourlain
			// 
			// geniusTreeView1
			// 
			this.geniusTreeView1.Alignment = System.Drawing.StringAlignment.Near;
			this.geniusTreeView1.AutoSort = false;
			this.geniusTreeView1.BackColor = System.Drawing.SystemColors.Window;
			this.geniusTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.geniusTreeView1.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.geniusTreeView1.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F);
			this.geniusTreeView1.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeView1.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.geniusTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.geniusTreeView1.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeView1.Header.MainColumnIndex = 0;
			this.geniusTreeView1.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
																										 this.geniusTreeViewColonne1,
																										 this.geniusTreeViewColonne2,
																										 this.geniusTreeViewColonne3});
			this.geniusTreeView1.KeysGridMode = false;
			this.geniusTreeView1.Location = new System.Drawing.Point(0, 0);
			this.geniusTreeView1.Name = "geniusTreeView1";
			this.geniusTreeView1.ShowHeader = true;
			this.geniusTreeView1.Size = new System.Drawing.Size(376, 328);
			this.geniusTreeView1.TabIndex = 0;
			this.geniusTreeView1.Text = "geniusTreeView1";
			this.geniusTreeView1.UseColumns = true;
			this.geniusTreeView1.OnInitEdit += new Genius.Controls.TreeView.OnInitEditDelegate(this.geniusTreeView1_OnInitEdit);
			this.geniusTreeView1.OnCreateEditor += new Genius.Controls.TreeView.OnCreateEditorDelegate(this.geniusTreeView1_OnCreateEditor);
			this.geniusTreeView1.OnAfterCheck += new Genius.Controls.TreeView.OnNodeDelegate(this.geniusTreeView1_OnAfterCheck);
			this.geniusTreeView1.OnBeforeEdit += new Genius.Controls.TreeView.OnCanEditDelegate(this.geniusTreeView1_OnBeforeEdit);
			this.geniusTreeView1.OnAfterEdit += new Genius.Controls.TreeView.OnAfterEditDelegate(this.geniusTreeView1_OnAfterEdit);
			// 
			// geniusTreeViewColonne1
			// 
			this.geniusTreeViewColonne1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne1.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne1.Text = "TreeColumn";
			this.geniusTreeViewColonne1.Width = 200;
			// 
			// geniusTreeViewColonne2
			// 
			this.geniusTreeViewColonne2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne2.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne2.Text = "TextEditor";
			// 
			// geniusTreeViewColonne3
			// 
			this.geniusTreeViewColonne3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.geniusTreeViewColonne3.ForeColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
			this.geniusTreeViewColonne3.Text = "ComboEditor";
			// 
			// DemoEditors
			// 
			this.Controls.Add(this.geniusTreeView1);
			this.Name = "DemoEditors";
			this.Size = new System.Drawing.Size(376, 328);
			this.Load += new System.EventHandler(this.DemoEditors_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void geniusTreeView1_OnInitEdit(GeniusTreeView Sender, EditEventArgs e)
		{
			if (e.Editor != null && e.Editor.Control is ComboBox && e.DisplayColumn == 2)
			{
				(e.Editor.Control as ComboBox).Items.Clear();
				(e.Editor.Control as ComboBox).Items.Add("Item 1");
				(e.Editor.Control as ComboBox).Items.Add("Item 2");
				(e.Editor.Control as ComboBox).Items.Add("Item 3");
			}
		}

		private void DemoEditors_Load(object sender, EventArgs e)
		{
			geniusTreeView1.BeginUpdate();
			try
			{
				for (int i=0; i < 10; i++)
				{
					INode n = geniusTreeView1.Add(null, "Node "+ i.ToString(), null);
					n.State |= NodeState.HasCheck;
					for (int j=0; j < 2; j++)
					{
						INode child = geniusTreeView1.Add(n, "custom edit", null);
						child.Height = 250;
					}
				}

			}
			finally
			{
				geniusTreeView1.EndUpdate();
			}
		}

		private void geniusTreeView1_OnBeforeEdit(GeniusTreeView Sender, CanEditEventArgs e)
		{
			//
		}

		private void geniusTreeView1_OnAfterEdit(GeniusTreeView Sender, EditEventArgs e)
		{
			object value = e.Editor.Value;
			/*
			if (value != null)
				edTrace.AppendText("AfterEdit :" + value.ToString()+Environment.NewLine);
			*/
		}

		private void geniusTreeView1_OnCreateEditor(GeniusTreeView Sender, NodeEditorEventArgs e)
		{
			if (e.DisplayColumn == 2)
				e.Editor = new ComboBoxEditor(geniusTreeView1);
			else if (e.DisplayColumn == 1)
				e.Editor = new MyDateEditor(geniusTreeView1);
			else if (e.DisplayColumn == 0 && e.Node.Level == 2)
			{
				e.Editor = new MyUCEditor(geniusTreeView1);
			}
		}

		private void geniusTreeView1_OnAfterCheck(GeniusTreeView Sender, NodeEventArgs e)
		{
			INode n = e.Node.Parent;
			foreach (INode child in n.Enumerable.GetVisibleNodes(false))
			{
				if (child != e.Node)
					child.State &= ~NodeState.Checked;
			}
		}

		private class MyDateEditor : Genius.Controls.TreeView.Editors.GeniusTreeViewEditorBase
		{
			public MyDateEditor(GeniusTreeView tv) : base(tv)
			{
				
			}

			public override object Value
			{
				get
				{
					return (FControl as DateTimePicker).Value;
				}
			}

			protected override Control CreateEditorControl()
			{
				return new DateTimePicker();
			}

		}

		private class MyUCEditor : Genius.Controls.TreeView.Editors.GeniusTreeViewEditorBase
		{
			public MyUCEditor(GeniusTreeView tv) : base(tv)
			{
				
			}

			public override object Value
			{
				get
				{
					return null;
				}
			}

			protected override Control CreateEditorControl()
			{
				return new DemoEditors();
			}
			
		}
	}
}
