using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Genius.Controls;
using Genius.Controls.TreeView;
using Genius.Controls.VisualStyles;

namespace DemoTreeView.UC1
{
	/// <summary>
	/// Summary description for FeuilleMaitresseGrille.
	/// </summary>
	public class DemoGrille : System.Windows.Forms.UserControl
	{
		#region variables membres
		private bool FChecked;

		private Genius.Controls.TreeView.GeniusTreeView gtv;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc1;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc2;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc3;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc4;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc5;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc6;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc7;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc8;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc9;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc10;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc11;
		private Genius.Controls.TreeView.GeniusTreeViewColonne gtc12;
        private System.Windows.Forms.Label lblInfo;
		#endregion
        private IContainer components;
		#region constructeur
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public DemoGrille()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}
		#endregion

		#region dispose
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
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
            this.gtc1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc5 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc6 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc7 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc8 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc9 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc10 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc11 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.gtc12 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // GeniusTreeView By Pierrick Gourlain
            // 
            // gtv
            // 
            this.gtv.Alignment = System.Drawing.StringAlignment.Near;
            this.gtv.AutoSort = false;
            this.gtv.BackColor = System.Drawing.SystemColors.Window;
            this.gtv.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.SystemColors.HighlightText, 1F, System.Drawing.Drawing2D.DashStyle.Dot);
            this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
            this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
            this.gtv.Colors.SelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
            this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0))))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
            this.gtv.Colors.TextColor = System.Drawing.Color.Black;
            this.gtv.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
            this.gtv.DefaultDrawingOption = ((Genius.Controls.TreeView.DrawingOptions)((Genius.Controls.TreeView.DrawingOptions.ShowVertLines | Genius.Controls.TreeView.DrawingOptions.ShowHorzLines)));
            this.gtv.Dock = System.Windows.Forms.DockStyle.Top;
            this.gtv.ElapsedHint = 500;
            this.gtv.Header.AllowSort = false;
            this.gtv.Header.FixedColumnCount = 5;
            this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtv.Header.ImageList = null;
            this.gtv.Header.MainColumnIndex = 0;
            this.gtv.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
            this.gtc1,
            this.gtc2,
            this.gtc3,
            this.gtc4,
            this.gtc5,
            this.gtc6,
            this.gtc7,
            this.gtc8,
            this.gtc9,
            this.gtc10,
            this.gtc11,
            this.gtc12});
            this.gtv.Indentation = 0;
            this.gtv.KeysGridMode = false;
            this.gtv.Location = new System.Drawing.Point(0, 0);
            this.gtv.Name = "gtv";
            this.gtv.ShowHeader = true;
            this.gtv.Size = new System.Drawing.Size(472, 288);
            this.gtv.TabIndex = 2;
            this.gtv.Text = "geniusTreeView1";
            this.gtv.UseColumns = true;
            this.gtv.UseKeyTab = true;
            this.gtv.OnBeforeCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnBeforeCellPainting);
            this.gtv.OnCellMouseUp += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.gtv_OnCellMouseUp);
            this.gtv.OnCellMouseLeave += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.gtv_OnCellMouseLeave);
            this.gtv.OnFooterGetText += new Genius.Controls.TreeView.OnFooterGetTextDelegate(this.gtv_OnFooterGetText);
            this.gtv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gtv_KeyDown);
            this.gtv.OnCellMouseDown += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.gtv_OnCellMouseDown);
            this.gtv.OnCellMouseMove += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.gtv_OnCellMouseMove);
            this.gtv.OnAfterPaintFooter += new Genius.Controls.TreeView.OnPaintFooterDelegate(this.gtv_OnAfterPaintFooter);
            this.gtv.OnCellMouseEnter += new Genius.Controls.TreeView.OnNodeCellMouseDelegate(this.gtv_OnCellMouseEnter);
            this.gtv.OnAfterCellPainting += new Genius.Controls.TreeView.OnPaintNodeDelegate(this.gtv_OnAfterCellPainting);
            this.gtv.OnCreateEditor += new Genius.Controls.TreeView.OnCreateEditorDelegate(this.gtv_OnCreateEditor);
            this.gtv.OnInitEdit += new Genius.Controls.TreeView.OnInitEditDelegate(this.gtv_OnInitEdit);
            this.gtv.OnAfterSelect += new Genius.Controls.TreeView.OnSelectedDelegate(this.gtv_OnAfterSelect);
            // 
            // gtc1
            // 
            this.gtc1.AllowClick = false;
            this.gtc1.AllowEdit = false;
            this.gtc1.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc1.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc1.ForeColor = System.Drawing.Color.Black;
            this.gtc1.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc1.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc1.Text = "Colonne1";
            this.gtc1.Width = 110;
            // 
            // gtc2
            // 
            this.gtc2.AllowClick = false;
            this.gtc2.AllowEdit = false;
            this.gtc2.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc2.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc2.ForeColor = System.Drawing.Color.Black;
            this.gtc2.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc2.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc2.Text = "Colonne2";
            this.gtc2.Width = 150;
            // 
            // gtc3
            // 
            this.gtc3.AllowClick = false;
            this.gtc3.AllowEdit = false;
            this.gtc3.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc3.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc3.ForeColor = System.Drawing.Color.Black;
            this.gtc3.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc3.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc3.Text = "Colonne 3";
            this.gtc3.Width = 30;
            // 
            // gtc4
            // 
            this.gtc4.AllowClick = false;
            this.gtc4.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc4.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc4.ForeColor = System.Drawing.Color.Black;
            this.gtc4.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc4.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc4.Text = "Colonne 4";
            // 
            // gtc5
            // 
            this.gtc5.AllowClick = false;
            this.gtc5.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc5.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc5.ForeColor = System.Drawing.Color.Black;
            this.gtc5.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc5.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc5.Text = "Colonne 5";
            // 
            // gtc6
            // 
            this.gtc6.AllowClick = false;
            this.gtc6.AllowEdit = false;
            this.gtc6.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc6.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc6.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc6.ForeColor = System.Drawing.Color.Black;
            this.gtc6.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc6.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc6.Text = "Colonne 6";
            // 
            // gtc7
            // 
            this.gtc7.AllowClick = false;
            this.gtc7.AllowEdit = false;
            this.gtc7.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc7.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc7.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc7.ForeColor = System.Drawing.Color.Empty;
            this.gtc7.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc7.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc7.Text = "Colonne 7";
            // 
            // gtc8
            // 
            this.gtc8.AllowClick = false;
            this.gtc8.AllowEdit = false;
            this.gtc8.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc8.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc8.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc8.ForeColor = System.Drawing.Color.Empty;
            this.gtc8.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc8.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc8.Text = "Colonne 8";
            // 
            // gtc9
            // 
            this.gtc9.AllowClick = false;
            this.gtc9.AllowEdit = false;
            this.gtc9.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc9.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc9.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc9.ForeColor = System.Drawing.Color.Empty;
            this.gtc9.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc9.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc9.Text = "Colonne 9";
            // 
            // gtc10
            // 
            this.gtc10.AllowClick = false;
            this.gtc10.AllowEdit = false;
            this.gtc10.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc10.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc10.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc10.ForeColor = System.Drawing.Color.Empty;
            this.gtc10.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc10.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc10.Text = "Colonne 10";
            // 
            // gtc11
            // 
            this.gtc11.AllowClick = false;
            this.gtc11.AllowEdit = false;
            this.gtc11.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc11.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc11.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc11.ForeColor = System.Drawing.Color.Empty;
            this.gtc11.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc11.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc11.Text = "Colonne 11";
            // 
            // gtc12
            // 
            this.gtc12.AllowClick = false;
            this.gtc12.AllowEdit = false;
            this.gtc12.BackColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc12.ContentAlignment = System.Drawing.StringAlignment.Far;
            this.gtc12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc12.FontColonne = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtc12.ForeColor = System.Drawing.Color.Empty;
            this.gtc12.ForeTextColor = System.Drawing.Color.Empty;
            this.gtc12.HeadColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Empty, System.Drawing.Color.Empty, 0F);
            this.gtc12.Text = "Colonne 12";
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(0, 288);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(472, 72);
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "label1";
            // 
            // DemoGrille
            // 
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.gtv);
            this.Name = "DemoGrille";
            this.Size = new System.Drawing.Size(472, 360);
            this.Load += new System.EventHandler(this.DemoGrille_Load);
            this.ResumeLayout(false);

		}
		#endregion		

		private void DemoGrille_Load(object sender, System.EventArgs e)
		{
			gtv.DefaultDrawingOption = DrawingOptions.ShowVertLines | DrawingOptions.HideButtons | DrawingOptions.HideTreeLines;
			Color c = SystemColors.Control;
			int offset = -5;
			gtc7.BackColor = new GeniusLinearGradientBrush(Color.FromArgb(c.R+offset, c.G+offset, c.B+offset));
			gtc9.BackColor = gtc7.BackColor;
			gtc11.BackColor = gtc7.BackColor;

			gtv.BeginUpdate();
			try
			{
				gtv.Add(null, "VFR800", null);
				gtv.Add(null, "SV650", null);
				gtv.Add(null, "CBR900", null);
				gtv.Add(null, "Moto est la plus belle", null);
			}
			finally
			{
				gtv.EndUpdate();	
			}
			lblInfo.Text = "utilisation de OnBeforeCellPainting, OnAfterCellPainting, OnCellMouseMove, OnCellMouseDown, OnCellMouseUp, OnCellMouseLeave, OnCellMouseEnter, \r\nFooterHeight = 18, OnFooterGetText";
		}

		private void gtv_OnAfterSelect(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.SelectedEventArgs e)
		{
			gtv.BeginEdit();
		}

		private void gtv_OnBeforeCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Info.DisplayColumn == 0)
			{
				e.Info.ContentRect.Width -= e.Info.ContentRect.Height;
			}
		}

		private void gtv_OnAfterCellPainting(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintNodeEventArgs e)
		{
			if (e.Info.DisplayColumn == 0)
			{
				//dessine d'un bouton
				Rectangle r = new Rectangle(e.Info.ContentRect.Right, e.Info.ContentRect.Top, e.Info.ContentRect.Height, e.Info.ContentRect.Height);
				PushButtonState state = PushButtonState.Normal;
				if (r.Contains(e.Info.MousePosition))
				{
					if (e.Info.Buttons == MouseButtons.Left)
						state = PushButtonState.Pressed;
					else
						state = PushButtonState.Hot;
				}
				Genius.Controls.DrawingHelper.DrawButton(e.Info.graphics, r, e.Info.ClipRect, state);
				StringFormat sf= new StringFormat(StringFormatFlags.NoWrap);
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				e.Info.graphics.DrawString("...", this.gtv.Font, SystemBrushes.WindowText,r, sf);
			}
			else if (e.Info.DisplayColumn == 2)
			{
				CheckBoxState state = FChecked ? CheckBoxState.CheckedNormal : CheckBoxState.UncheckedNormal;
				Genius.Controls.DrawingHelper.DrawCheckBox(e.Info.graphics, e.Info.NodeRect,e.Info.ClipRect, state);				
			}		
		}

		private void gtv_OnCreateEditor(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeEditorEventArgs e)
		{
			if (e.DisplayColumn == 3)
				e.Editor = new Genius.Controls.TreeView.Editors.ComboBoxEditor(this.gtv);
		}

		private void gtv_OnInitEdit(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.EditEventArgs e)
		{
			if (e.DisplayColumn == 3)
			{							
				ComboBox cb = (ComboBox)e.Editor.Control;
				cb.Items.Add("[Ajouter]");
				cb.Items.Add("[Supprimer]");
				e.Value = "coucou";
				cb.SelectionChangeCommitted +=new EventHandler(cb_SelectionChangeCommitted);
			}
		}

		private void gtv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				FChecked = !FChecked;
				gtv.Invalidate();
			}
		}

		private void gtv_OnCellMouseMove(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			if (e.DisplayColumn == 0)
				gtv.Invalidate(e.Node);		
		}

		private void gtv_OnCellMouseDown(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			if (e.DisplayColumn == 0)
			{
				gtv.Invalidate(e.Node);		
			}
		}

		private void gtv_OnCellMouseLeave(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			if (e.DisplayColumn == 0)
				gtv.Invalidate(e.Node);				
		}

		private void gtv_OnCellMouseEnter(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			if (e.DisplayColumn == 0)
				gtv.Invalidate(e.Node);
		}

		private void gtv_OnCellMouseUp(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.NodeCellMouseEventArgs e)
		{
			if (e.DisplayColumn == 0)
			{
				Rectangle r = gtv.GetCellRect(e.Node, 0);
				r = new Rectangle(r.Right - r.Height, r.Top,  r.Height, r.Height);
				Debug.WriteLine(string.Format("Capture = {0}", gtv.Capture));
				if (r.Contains(e.Position))
					MessageBox.Show("click on button !!");
			}
		}

		private void gtv_OnFooterGetText(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.FooterTextEventArgs e)
		{
			if (e.DisplayColumn > 4)
			{
				if (e.DisplayColumn % 2 == 0)
				{
					e.Format.Alignment = StringAlignment.Far;
					e.Font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Italic);
				}
				e.Text = "Total " + e.DisplayColumn.ToString();
			}
			else if (e.DisplayColumn == 4)
			{
				e.Text = "Totaux :";
				e.Format.Alignment = StringAlignment.Far;
				e.Font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
			}
		}

		private void gtv_OnAfterPaintFooter(Genius.Controls.TreeView.GeniusTreeView Sender, Genius.Controls.TreeView.PaintFooterEventArgs e)
		{
			Rectangle r = e.FooterRect;
			r.Height -= 1;
			e.Graphics.DrawLine(Pens.LightGray, r.Left, r.Top,  r.Right, r.Top);
			e.Graphics.DrawLine(Pens.White, r.Left, r.Top+1,  r.Right, r.Top+1);
			if (e.DisplayColumn > 4)
			{
				e.Graphics.DrawLine(Pens.LightGray, r.Left, r.Top+3, r.Left, r.Bottom-3);
				e.Graphics.DrawLine(Pens.White, r.Left+1, r.Top+3, r.Left+1, r.Bottom-3);
			}
		}

		private void cb_SelectionChangeCommitted(object sender, EventArgs e)
		{
		}
	}
}
