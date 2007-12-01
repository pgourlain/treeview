using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// Summary description for HorizontalTab.
	/// </summary>
	[DefaultProperty("Text"), Designer("System.Windows.Forms.Design.TabPageDesigner, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ToolboxItem(false), DefaultEvent("Click"), DesignTimeVisible(false)]
	public class HorizontalTab : Panel
	{
		private StringAlignment FVerticalTextAlignment;
		private StringAlignment FHorizontalTextAlignment;
		private TabMargins FMargins;
		private bool FTabVisible;

		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public HorizontalTab()
		{
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.BackColor = System.Drawing.Color.FromArgb(243,241,229);
			this.Dock = DockStyle.Fill;
			FVerticalTextAlignment = StringAlignment.Center;
			FMargins = TabMargins.Empty;
			FTabVisible = true;
		}

		private void UpdateNeeded()
		{
			HorizontalTabs tabs = this.Parent as HorizontalTabs;
			if (tabs != null)
				tabs.InvalidateTab(this);
		}

		/// <summary>
		/// le rectangle disponible pour les controls enfant
		/// </summary>
		public override Rectangle DisplayRectangle
		{
			get
			{
				Rectangle r = base.DisplayRectangle;
				r.X += FMargins.Left;
				r.Y += FMargins.Top;
				r.Width -= (FMargins.Left + FMargins.Right);
				r.Height -= (FMargins.Top + FMargins.Bottom);
				return r;
			}
		}


		/// <summary>
		/// alignement vertical du texte
		/// </summary>
		public StringAlignment VerticalTextAlignment
		{
			get
			{
				return 	FVerticalTextAlignment;
			}
			set
			{
				if (value != VerticalTextAlignment)
				{
					FVerticalTextAlignment = value;
					UpdateNeeded();
				}
			}
		}

		/// <summary>
		/// alignement horizontal du texte
		/// </summary>
		public StringAlignment HorizontalTextAlignement
		{
			get
			{
				return FHorizontalTextAlignment;
			}
			set
			{
				if (value != FHorizontalTextAlignment)
				{
					FHorizontalTextAlignment = value;
					UpdateNeeded();
				}
			}
		}
		
		/// <summary>
		/// le texte du tab
		/// </summary>
		[Browsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;	
			}
			set
			{
				base.Text = value;	
				UpdateNeeded();
			}
		}

		/// <summary>
		/// les marges, influe directement sur le <see cref="DisplayRectangle"/>
		/// </summary>
		[DefaultValue("0; 0; 0; 0")]
		public TabMargins Margins
		{
			get
			{
				return FMargins;
			}
			set
			{
				if (FMargins != value)
				{
					FMargins = value;
					this.PerformLayout();
				}
			}
		}

		/// <summary>
		/// visibilité du tab
		/// </summary>
		[DefaultValue(true)]
		public bool TabVisible
		{
			get
			{
				return FTabVisible;
			}
			set
			{
				if (value != FTabVisible)
				{
					FTabVisible = value;
					HorizontalTabs tabs = this.Parent as HorizontalTabs;
					if (tabs != null)
					{
						tabs.UpdateRegion();
						tabs.SelectFirstVisible();
					}
				}
			}
		}
	}
}
