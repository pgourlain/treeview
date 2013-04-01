namespace DemoTreeView.Samples1
{
    partial class AutoSizeColumnUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gtvAutoSizeColumn = new Genius.Controls.TreeView.GeniusTreeView();
            this.geniusTreeViewColonne1 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne2 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne3 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne4 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne5 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne6 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.geniusTreeViewColonne7 = new Genius.Controls.TreeView.GeniusTreeViewColonne();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // GeniusTreeView By Pierrick Gourlain
            // 
            // gtvAutoSizeColumn
            // 
            this.gtvAutoSizeColumn.Alignment = System.Drawing.StringAlignment.Near;
            this.gtvAutoSizeColumn.AutoSort = false;
            this.gtvAutoSizeColumn.BackColor = System.Drawing.SystemColors.Window;
            this.gtvAutoSizeColumn.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.SystemColors.HighlightText, 1F, System.Drawing.Drawing2D.DashStyle.Dot);
            this.gtvAutoSizeColumn.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
            this.gtvAutoSizeColumn.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
            this.gtvAutoSizeColumn.Colors.SelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.gtvAutoSizeColumn.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
            this.gtvAutoSizeColumn.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0))))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
            this.gtvAutoSizeColumn.Colors.TextColor = System.Drawing.Color.Black;
            this.gtvAutoSizeColumn.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
            this.gtvAutoSizeColumn.DefaultDrawingOption = ((Genius.Controls.TreeView.DrawingOptions)((Genius.Controls.TreeView.DrawingOptions.ShowVertLines | Genius.Controls.TreeView.DrawingOptions.ShowHorzLines)));
            this.gtvAutoSizeColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtvAutoSizeColumn.ElapsedHint = 500;
            this.gtvAutoSizeColumn.Header.AllowDrag = true;
            this.gtvAutoSizeColumn.Header.AutoColHeight = true;
            this.gtvAutoSizeColumn.Header.AutoSizeColIndex = 2;
            this.gtvAutoSizeColumn.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtvAutoSizeColumn.Header.ImageList = null;
            this.gtvAutoSizeColumn.Header.MainColumnIndex = 0;
            this.gtvAutoSizeColumn.HeaderColonnes.AddRange(new Genius.Controls.TreeView.GeniusTreeViewColonne[] {
            this.geniusTreeViewColonne1,
            this.geniusTreeViewColonne2,
            this.geniusTreeViewColonne3,
            this.geniusTreeViewColonne4,
            this.geniusTreeViewColonne5,
            this.geniusTreeViewColonne6,
            this.geniusTreeViewColonne7});
            this.gtvAutoSizeColumn.KeysGridMode = false;
            this.gtvAutoSizeColumn.Location = new System.Drawing.Point(0, 13);
            this.gtvAutoSizeColumn.Name = "gtvAutoSizeColumn";
            this.gtvAutoSizeColumn.ShowHeader = true;
            this.gtvAutoSizeColumn.Size = new System.Drawing.Size(409, 210);
            this.gtvAutoSizeColumn.TabIndex = 3;
            this.gtvAutoSizeColumn.UseColumns = true;
            this.gtvAutoSizeColumn.OnGetNodeText += new Genius.Controls.TreeView.OnGetNodeTextDelegate(this.gtvAutoSizeColumn_OnGetNodeText);
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
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Colonne 2 en autosize en largeur et en hauteur";
            // 
            // AutoSizeColumnUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gtvAutoSizeColumn);
            this.Controls.Add(this.label1);
            this.Name = "AutoSizeColumnUC";
            this.Size = new System.Drawing.Size(409, 223);
            this.Load += new System.EventHandler(this.AutoSizeColumnUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Genius.Controls.TreeView.GeniusTreeView gtvAutoSizeColumn;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne1;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne2;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne3;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne4;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne5;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne6;
        private Genius.Controls.TreeView.GeniusTreeViewColonne geniusTreeViewColonne7;
        private System.Windows.Forms.Label label1;
    }
}
