namespace DemoTreeView.Editor
{
	/// <summary>
	/// Summary description for UCEditor.
	/// </summary>
	public class UCEditor : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label label1;
		private Genius.Controls.TreeView.GeniusTreeView gtv;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public UCEditor()
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
			this.label1 = new System.Windows.Forms.Label();
			this.gtv = new Genius.Controls.TreeView.GeniusTreeView();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "mon editor";
			// GeniusTreeView By Pierrick Gourlain
			// 
			// gtv
			// 
			this.gtv.Alignment = System.Drawing.StringAlignment.Near;
			this.gtv.AutoSort = false;
			this.gtv.BackColor = System.Drawing.SystemColors.Window;
			this.gtv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.gtv.Colors.HeaderColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.White, System.Drawing.Color.LightGray, 90F);
			this.gtv.Colors.SelectedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.Highlight, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedTextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SelectedUnfocusedColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.SystemColors.InactiveCaption, System.Drawing.Color.Empty, 0F);
			this.gtv.Colors.SignaledPenColor = new Genius.Controls.TreeView.Colors.GeniusPen(System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(165)), ((System.Byte)(0))), 2F);
			this.gtv.Colors.TextColor = new Genius.Controls.GeniusLinearGradientBrush(System.Drawing.Color.Black, System.Drawing.Color.Empty, 0F);
			this.gtv.DefaultDrawingOption = Genius.Controls.TreeView.DrawingOption.ShowGridLines;
			this.gtv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gtv.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gtv.Header.MainColumnIndex = -1;
			this.gtv.KeysGridMode = false;
			this.gtv.Location = new System.Drawing.Point(0, 23);
			this.gtv.Name = "gtv";
			this.gtv.Size = new System.Drawing.Size(312, 281);
			this.gtv.TabIndex = 2;
			this.gtv.Text = "geniusTreeView1";
			// 
			// UCEditor
			// 
			this.BackColor = System.Drawing.Color.IndianRed;
			this.Controls.Add(this.gtv);
			this.Controls.Add(this.label1);
			this.Name = "UCEditor";
			this.Size = new System.Drawing.Size(312, 304);
			this.Load += new System.EventHandler(this.UCEditor_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void UCEditor_Load(object sender, System.EventArgs e)
		{
			gtv.BeginUpdate();
			try
			{
				for (int i = 0; i < 100; i++)
					gtv.Add(null, i.ToString(), i)	;
			}
			finally
			{
				gtv.EndUpdate();
			}
		}
	}
}
