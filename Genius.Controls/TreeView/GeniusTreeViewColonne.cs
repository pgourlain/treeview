using System;
using System.ComponentModel;
using System.Drawing;
using Genius.Controls.TreeView;

namespace Genius.Controls.TreeView
{
	/// <summary>
	/// classe représentant une entête de colonne
	/// </summary>
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	public class GeniusTreeViewColonne : Component
	{
		private string	FTitre;
		private int		FWidth;
		private StringAlignment FAlignment;
		private StringAlignment FVAlignment;
		private StringAlignment FTextAlignment;
		private Color	FForeColor;
		private GeniusLinearGradientBrush	FBackColor;
		private GeniusLinearGradientBrush FHeadColor;
		private bool		FVisible;
		private bool		FSizable;
		private bool		FDraggable;
		private bool		FAllowClick;
		private GeniusHeader FOwner;
		private Font		FFont;
		private int			FImageIndex;
		private Font		FFontColonne;
		private float		FTextOrientation;
		private ImageAlignment FImageAlignment;
		private bool		FAllowEdit;
        private Color _ForeTextColor;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
		public GeniusTreeViewColonne() : this(null)
		{
			FTitre = string.Empty;
		}

		public GeniusTreeViewColonne(GeniusHeader aOwner) : base()
		{
			//Valeur par défaut
			FWidth = 75;
			FAlignment = StringAlignment.Center;
			FVAlignment = StringAlignment.Center;
			FTextAlignment = StringAlignment.Near;
			FVisible = true;
			FSizable = true;
			FDraggable = true;
			FAllowClick = true;
			FAllowEdit = true;
			FOwner = aOwner;
			FFont = null;
			FFontColonne = null;
			FImageIndex = -1;
			FTextOrientation = 0.0f;
			FImageAlignment = ImageAlignment.Left;
		}

		[DefaultValue("")]
		public string Text
		{
			get
			{
				return FTitre;
			}
			set
			{
				FTitre = value;
			}
		}

		[DefaultValue(75)]
		public int Width
		{
			get
			{
				return FWidth;
			}
			set
			{
				if (FWidth != value)
				{
					FWidth = value;
					if (FWidth < 0)
						FWidth = 0;
					if (FOwner != null)
					{
                        FOwner.ColSizeChanged(this);
                        FOwner.Redraw(true);
					}
				}
			}
		}

		/// <summary>
		/// Alignement horizontal dans le header
		/// </summary>
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment Alignment
		{
			get
			{

				return FAlignment;
			}
			set
			{
				FAlignment = value;
			}
		}

		/// <summary>
		/// alignement vertical dans le header
		/// </summary>
		[DefaultValue(StringAlignment.Center)]
		public StringAlignment VAlignment
		{
			get
			{
				return FVAlignment;
			}
			set
			{
				FVAlignment = value;
			}
		}

		/// <summary>
		/// alignement du text dans la colonne
		/// </summary>
		[DefaultValue(StringAlignment.Near)]
		public StringAlignment ContentAlignment
		{
			get
			{
				return FTextAlignment;
			}
			set
			{
				FTextAlignment = value;
			}
		}

		/// <summary>
		/// couleur du Text (header)
		/// </summary>
		//[DefaultValue(GeniusLinearGradientBrush.Empty)]
		public Color ForeColor
		{
			get
			{
				return FForeColor;
			}
			set
			{
				FForeColor = value;
			}
		}

        public Color ForeTextColor
        {
            get
            {
                return _ForeTextColor;
            }
            set
            {
                _ForeTextColor = value;
            }
        }

		/// <summary>
		/// couleur de fond de la colonne dans son header
		/// </summary>
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public GeniusLinearGradientBrush HeadColor
		{
			get
			{
				return FHeadColor;
			}
			set
			{
				FHeadColor = value;
			}
		}

		/// <summary>
		/// couleur de fond de la colonne
		/// </summary>
		//[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public GeniusLinearGradientBrush BackColor
		{
			get
			{
				return FBackColor;
			}
			set
			{
				FBackColor = value;
			}
		}

		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return FVisible;
			}
			set
			{
				if (FVisible != value)
				{
					FVisible = value;
					if (FOwner != null)
						FOwner.VisibleColumnChanged(this);
				}
			}
		}

		/// <summary>
		/// permet à la colonne d'être retaillée
		/// </summary>
		[Description("La colonne est elle resizable")]
		[DefaultValue(true)]
		public bool AllowSize
		{
			get
			{
				return FSizable;
			}
			set
			{
				FSizable = value;
			}
		}

		/// <summary>
		/// autorise ou pas le drag de la colonne
		/// </summary>
		[DefaultValue(true)]
		public bool AllowDrag
		{
			get
			{
				return FDraggable;
			}
			set
			{
				FDraggable = value;
			}
		}

		/// <summary>
		/// autorise ou pas le clic sur la colonne
		/// </summary>
		[DefaultValue(true)]
		public bool AllowClick
		{
			get
			{
				return FAllowClick;
			}
			set
			{
				FAllowClick = value;
			}
		}

		/// <summary>
		/// autorise ou pas l'édition dans cette colonne
		/// </summary>
		[DefaultValue(true)]
		public bool AllowEdit
		{
			get
			{
				return FAllowEdit;
			}
			set
			{
				FAllowEdit = value;
			}
		}

		internal GeniusHeader Owner
		{
			get
			{
				return FOwner;
			}
			set
			{
				FOwner = value;
			}
		}

		/// <summary>
		/// font de la colonne (header)
		/// </summary>
		[DefaultValue(null)]
		public Font Font
		{
			get
			{
				if (FFont == null && FOwner != null)
					return FOwner.Font;
				return FFont;
			}
			set
			{
				if (FFont != value)
				{
					FFont = value;
					if (FFont != null && FOwner != null && FFont.Equals(FOwner.Font))
						FFont = null;
					if (FOwner != null)
						FOwner.Redraw(true);
				}
			}
		}

		/// <summary>
		/// font de la colonne
		/// </summary>
		[DefaultValue(null)]
		public Font FontColonne
		{
			get
			{
				if (FFontColonne == null)
					return Font;
				return FFontColonne;
			}
			set
			{
				if (FFontColonne != value)
				{
					FFontColonne = value;
					if (FFontColonne != null && FOwner != null && FFontColonne.Equals(FOwner.Font))
						FFontColonne = null;
					if (FOwner != null)
						FOwner.Redraw(true);
				}			
			}
		}

		[DefaultValue(-1)]
		public int ImageIndex
		{
			get
			{
				return FImageIndex;
			}
			set
			{
				if (value != FImageIndex)
				{
					FImageIndex = value;
					if (FOwner != null)
						FOwner.Redraw(false);
				}
			}
		}
        /// <summary>
        /// Alignement de l'image de la colonne, à gauche par défaut 
        /// </summary>
		[DefaultValue(ImageAlignment.Left)]
		public ImageAlignment ImageAlignment
		{
			get
			{
				return FImageAlignment;
			}
			set
			{
				if (FImageAlignment != value)
				{
					FImageAlignment	= value;
					if (FOwner != null)
						FOwner.Redraw(false);
				}
			}
		}

        /// <summary>
        /// orientation du texte du header en degré
        /// </summary>
		[DefaultValue(0.0f)]
		public float TextOrientation
		{
			get
			{
				return FTextOrientation;
			}
			set
			{
				FTextOrientation = value;
			}
		}
		#region IDisposable Members

		protected override void Dispose(bool disposing)
		{
			base.Dispose (disposing);
			if (disposing)
			{
				//FForeColor.Dispose();				
				FBackColor.Dispose();
				FHeadColor.Dispose();
			}
		}

		#endregion
	}
}
