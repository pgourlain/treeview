#region Imports

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Genius.Controls
{
	/// <summary>
	/// classe Helper pour la gestion des scrollbars d'une fenêtre
	/// </summary>
	[EditorBrowsable()]
	public class ScrollBarsHelper
	{
		#region variables
		private Control FControl;
		private ScrollBars FScrollBars;
		private int FRangeX;
		private int FRangeY;
		private int FOffsetX;
		private int FOffsetY;
		private bool FScrollBarsAlwaysVisible;
		private int FMarginHeight;
		private int FMarginWidth;
		#endregion

		#region contructeurs
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		/// <param name="aControl">le control dont on veut associer une scrollbar</param>
		public ScrollBarsHelper(Control aControl)
		{
			FMarginHeight = 0;
			FControl = aControl;
			if (FControl != null)
				FControl.Resize +=new EventHandler(Control_Resize);
		}
		#endregion

		#region méthodes protégées
		protected int ScrollMask(bool value)
		{
			if (value)
				return NativeMethods.SIF_DISABLENOSCROLL;
			else
				return 0;
		}

		/// <summary>
		/// handle du control associé au helper
		/// </summary>
		protected IntPtr Handle
		{
			get
			{
				return FControl.Handle;
			}
		}

		/// <summary>
		/// mise à jour des scrollbars
		/// </summary>
		protected void UpdateScrollBars()
		{
			UpdateHorizontalScrollBar(true);
			UpdateVerticalScrollBar(true);
		}

		/// <summary>
		/// update de la scrollbar horizontale
		/// </summary>
		/// <param name="aRepaint"></param>
		protected void UpdateHorizontalScrollBar(bool aRepaint)
		{
			if (FScrollBars == ScrollBars.Both || FScrollBars == ScrollBars.Horizontal)
			{
				SCROLLINFO info = new SCROLLINFO();
				info.fMask = NativeMethods.SIF_ALL;
				NativeMethods.GetScrollInfo(this.Handle, NativeMethods.SB_HORZ, ref info);
				int diffX = FRangeX - ClientRectangle.Width ;
				if (diffX > 0 || ScrollBarsAlwaysVisible)
				{
					info.nMin = 0;
					info.nMax = FRangeX;
					info.nPos = FOffsetX;
					info.nPage = Math.Max(0, ClientRectangle.Width + 1);
					info.fMask = NativeMethods.SIF_ALL | ScrollMask(ScrollBarsAlwaysVisible);
					NativeMethods.SetScrollInfo(this.Handle, NativeMethods.SB_HORZ, ref info, aRepaint);
					NativeMethods.ShowScrollBar(this.Handle, NativeMethods.SB_HORZ, true);

					//recalcul de l'offset pour éviter, d'avoir un offset négatif
					if (FOffsetX > 0 && diffX - FOffsetX < 0)
						FOffsetX -= (FOffsetX-diffX);
					if (FOffsetX < 0)
						FOffsetX = 0;
				}
				else
				{
					info.nMin = 0;
					info.nMax = 0;
					info.nPos = 0;
					info.nPage = 0;
					NativeMethods.ShowScrollBar(this.Handle, NativeMethods.SB_HORZ, false);
					NativeMethods.SetScrollInfo(this.Handle, NativeMethods.SB_HORZ, ref info, false);
				}
			}
			else
			{
				NativeMethods.ShowScrollBar(this.Handle, NativeMethods.SB_HORZ, false);
			}
		}

		/// <summary>
		/// update de la scrollbar verticale
		/// </summary>
		/// <param name="aRepaint"></param>
		protected void UpdateVerticalScrollBar(bool aRepaint)
		{
			if (FScrollBars == ScrollBars.Both || FScrollBars == ScrollBars.Vertical)
			{
				SCROLLINFO info = new SCROLLINFO();
				info.fMask = NativeMethods.SIF_ALL;
				NativeMethods.GetScrollInfo(this.Handle, NativeMethods.SB_VERT, ref info);
				if (FRangeY > ClientRectangle.Height || ScrollBarsAlwaysVisible)
				{
					info.nMin = 0;
					info.nMax = FRangeY;
					info.nPos = FOffsetY;
					info.nPage = Math.Max(0, ClientRectangle.Height + 1);
					info.fMask = NativeMethods.SIF_ALL | ScrollMask(ScrollBarsAlwaysVisible);
                    NativeMethods.SetScrollInfo(this.Handle, NativeMethods.SB_VERT, ref info, aRepaint);
                    NativeMethods.ShowScrollBar(this.Handle, NativeMethods.SB_VERT, true);
				}
				else
				{
					info.nMin = 0;
					info.nMax = 0;
					info.nPos = 0;
					info.nPage = 0;
					FOffsetY = 0;
					NativeMethods.ShowScrollBar(this.Handle, NativeMethods.SB_VERT, false);
					NativeMethods.SetScrollInfo(this.Handle, NativeMethods.SB_VERT, ref info, false);
				}
			}
			else
			{
				NativeMethods.ShowScrollBar(this.Handle, NativeMethods.SB_VERT, false);
			}
		}
		#endregion

		#region Propriétés
		/// <summary>
		/// quelles sont les scrollbars à afficher
		/// </summary>
		[Browsable(true)]
		public ScrollBars ScrollBars
		{
			get {return FScrollBars;}
			set 
			{
				if (FScrollBars != value)
				{
					FScrollBars = value;
				}
			}
		}

		/// <summary>
		/// largeur total
		/// </summary>
		[Browsable(true)]
		public int RangeX
		{
			get
			{
				return FRangeX;
			}
			set
			{
				if (FRangeX != value)
				{
					FRangeX = value;
					UpdateHorizontalScrollBar(true);
				}
			}
		}

		/// <summary>
		/// hauteur totale
		/// </summary>
		[Browsable(true)]
		public int RangeY
		{
			get
			{
				return FRangeY;
			}
			set
			{
				if (FRangeY != value)
				{
					FRangeY = value;
					UpdateVerticalScrollBar(true);
				}
			}
		}

		/// <summary>
		/// déplacement en largeur
		/// </summary>
		[Browsable(true)]
		public int OffsetX
		{
			get
			{
				return FOffsetX;
			}
			set
			{
				if (OffsetX != value)
				{
					FOffsetX = value;
					UpdateHorizontalScrollBar(true);
					DoHorizontalScrollChange();
				}
			}
		}

		/// <summary>
		/// déplacement en hauteur
		/// </summary>
		[Browsable(true)]
		public int OffsetY
		{
			get
			{
				return FOffsetY;
			}
			set
			{
				if (FOffsetY != value)
				{
					FOffsetY = value;
					UpdateVerticalScrollBar(true);
					DoVerticalScrollChange();
				}
			}
		}

		/// <summary>
		/// les scrollbars sont elles toujours visible
		/// </summary>
		[Browsable(true)]
		public bool ScrollBarsAlwaysVisible
		{
			get 
			{
				return FScrollBarsAlwaysVisible;
			}
			set
			{
				if (FScrollBarsAlwaysVisible != value)
				{
					FScrollBarsAlwaysVisible = value;
					UpdateScrollBars();
				}
			}
		}

		/// <summary>
		/// retourne la position de la scrollbar verticale
		/// </summary>
		[Browsable(false)]
		public int VScrollPos
		{
			get
			{
				SCROLLINFO info = new SCROLLINFO();
				info.fMask = NativeMethods.SIF_TRACKPOS;
				NativeMethods.GetScrollInfo(this.Handle, NativeMethods.SB_VERT, ref info);
				return info.nTrackPos;
			}
		}

		/// <summary>
		/// marge en hauteur à prendre en compte dans le calcul de la hauteur de la page affichée
		/// </summary>
		public int MarginHeight
		{
			get
			{
				return FMarginHeight;
			}
			set
			{
				if (value != FMarginHeight)
				{
					FMarginHeight = value;
					UpdateVerticalScrollBar(true);
				}
			}
		}

		/// <summary>
		/// marge en largeur à prendre en compte dans le calcul de la largeur de la page affichée
		/// </summary>
		public int MarginWidth
		{
			get
			{
				return FMarginWidth;
			}
			set
			{
				if (value != FMarginWidth)
				{
					FMarginWidth = value;
					UpdateHorizontalScrollBar(true);
				}
			}
		}
		#endregion

		private void Control_Resize(object sender, EventArgs e)
		{
			UpdateScrollBars();
			SynchroVScroll();
		}

		private void SynchroVScroll()
		{
			if (FScrollBars == ScrollBars.Both || FScrollBars == ScrollBars.Vertical)
			{
				SCROLLINFO info = new SCROLLINFO();
				info.fMask = NativeMethods.SIF_ALL;
				NativeMethods.GetScrollInfo(this.Handle, NativeMethods.SB_VERT, ref info);
				FOffsetY = info.nPos;
			}			
		}

		#region méthodes publiques
        /// <summary>
        /// peut-on scroller vers le bas
        /// </summary>
        /// <returns></returns>
		public bool CanScrollDown()
		{
			return FRangeY - ClientRectangle.Height > FOffsetY;
		}

        /// <summary>
        /// peut-on scroller vers le haute
        /// </summary>
        /// <returns></returns>
		public bool CanScrollUp()
		{
			return FOffsetY > 0;
		}

        /// <summary>
        /// peut-on scroller vers la gauche
        /// </summary>
        /// <returns></returns>
		public bool CanScrollLeft()
		{
			return FOffsetX > 0;
		}

        /// <summary>
        /// peut-on scroller vers la droite
        /// </summary>
        /// <returns></returns>
		public bool CanScrollRight()
		{
			return FRangeX -ClientRectangle.Width > FOffsetX;
		}

		/// <summary>
		/// mise à jour des scrollbars
		/// </summary>
		public void Update()
		{
			UpdateScrollBars();
		}

		/// <summary>
		/// renvoi le rectangle de la page affichée en prenant en compte les marges
		/// </summary>
		public Rectangle ClientRectangle
		{
			get
			{
				Rectangle Result = FControl.ClientRectangle;
				Result.Width -= FMarginWidth;
				Result.Height -= FMarginHeight;
				return Result;
			}
		}
		#endregion

		private void DoHorizontalScrollChange()
		{
			//TODO: event
		}

		private void DoVerticalScrollChange()
		{
			//TODO: event
		}
	}
}
