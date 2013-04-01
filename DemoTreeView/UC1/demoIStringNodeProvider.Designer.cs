namespace DemoTreeView.UC1
{
    partial class demoIStringNodeProvider
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
            this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // GeniusTreeView By Pierrick Gourlain
            // 
            // gtv
            // 
            this.gtv.Alignment = System.Drawing.StringAlignment.Near;
            this.gtv.AutoSort = false;
            this.gtv.BackColor = System.Drawing.SystemColors.Window;
            this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gtv.Colors.FocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
            this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
            this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
            this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
            this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
            this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0))))), 2F, System.Drawing.Drawing2D.DashStyle.Solid);
            this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
            this.gtv.Colors.UnFocusedRectanglePenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F, System.Drawing.Drawing2D.DashStyle.Dot);
            this.gtv.DataIsStringProvider = true;
            this.gtv.DefaultDrawingOption = ((Genius.Controls.TreeView.DrawingOptions)((Genius.Controls.TreeView.DrawingOptions.ShowVertLines | Genius.Controls.TreeView.DrawingOptions.ShowHorzLines)));
            this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gtv.ElapsedHint = 500;
            this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtv.Header.ImageList = null;
            this.gtv.Header.MainColumnIndex = -1;
            this.gtv.KeysGridMode = false;
            this.gtv.Location = new System.Drawing.Point(0, 0);
            this.gtv.Name = "gtv";
            this.gtv.Size = new System.Drawing.Size(427, 345);
            this.gtv.TabIndex = 0;
            this.gtv.Text = "geniusTreeView1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // demoIStringNodeProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gtv);
            this.Name = "demoIStringNodeProvider";
            this.Size = new System.Drawing.Size(427, 345);
            this.Load += new System.EventHandler(this.demoIStringNodeProvider_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Genius.Controls.TreeView.GeniusTreeView gtv;
        private System.Windows.Forms.Timer timer1;
    }
}
