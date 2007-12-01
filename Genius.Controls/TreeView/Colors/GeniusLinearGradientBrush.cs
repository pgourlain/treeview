using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using Genius.Controls.TreeView.Converter;

namespace Genius.Controls
{

	/// <summary>
	/// Summary description for GeniusLinearGradientBrush.
	/// </summary>
	[TypeConverter(typeof(GeniusLinearGradientBrushConverter))]
	public struct GeniusLinearGradientBrush : IDisposable
	{
		const string InvalidCastExceptionStr = "invalide cast GeniusLinearBrush -> {0}";
		private Color FColor;
		private Color FEndColor;
		private float FAngle;
		private Brush FBrush;

		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="aSolidColor">à partir d'un couleur</param>
		public GeniusLinearGradientBrush(Color aSolidColor) : this(aSolidColor, Color.Empty)
		{
		}

		/// <summary>
		/// construteur à partir de deux couleurs
		/// </summary>
		/// <param name="begin">couleur de debut</param>
		/// <param name="end">couleur de fin</param>
		public GeniusLinearGradientBrush(Color begin, Color end) : this (begin, end, 0.0f)
		{
		}

		/// <summary>
		/// constructeur avec deux couleurs et un angle
		/// </summary>
		/// <param name="begin">couleur de début</param>
		/// <param name="end">couleur de fin</param>
		/// <param name="angle">angle</param>
		public GeniusLinearGradientBrush(Color begin, Color end, float angle)
		{
			FColor = begin;
			FEndColor = end;
			FAngle = angle;
			FBrush = null;
		}

		/// <summary>
		/// constructeur à partir d'un brush
		/// </summary>
		/// <param name="aBrush"></param>
		public GeniusLinearGradientBrush(Brush aBrush)
		{
			FBrush = aBrush;
			FColor = Color.Empty;
			FEndColor = Color.Empty;
			FAngle = 0;
		}

		#region propriétés publiques
		/// <summary>
		/// couleur du brush, si on modifie cette propriété, le brush sera
		/// uni, il faut affecter <see cref="BeginColor"/> et <see cref="EndColor"/>
		/// pour obtenir un brush à deux couleur
		/// </summary>
		[Browsable(false)]
		public Color Color
		{
			get
			{
				return FColor;	
			}
			set
			{
				FColor = value;
				FEndColor = Color.Empty;
				FAngle = 0;
			}
		}

		/// <summary>
		/// couleur de début du gradient
		/// </summary>
		public Color BeginColor
		{
			get
			{
				return FColor;
			}
			set
			{
				FColor = value;
			}
		}

		/// <summary>
		/// couleur de fin pour le gradient
		/// </summary>
		public Color EndColor
		{
			get
			{
				return FEndColor;
			}
			set
			{
				FEndColor = value;
			}
		}

		/// <summary>
		/// angle du gradient
		/// </summary>
		public float Angle
		{
			get
			{
				return FAngle;
			}
			set
			{
				FAngle = value;
			}
		}

		/// <summary>
		/// construit un brush mais à partir d'un rectangle vide
		/// cette méthode ne doit pas être utilisée si <see cref="BeginColor"/> et <see cref="EndColor"/> sont valides
		/// </summary>
		/// <returns></returns>
		public Brush GetBrush()
		{
			return GetBrush(Rectangle.Empty);
		}

		/// <summary>
		/// construit un <see cref="LinearGradientBrush"/>, ou un <see cref="SolidBrush"/>
		/// </summary>
		/// <param name="aRect"></param>
		/// <returns></returns>
		public Brush GetBrush(Rectangle aRect)
		{
			if (FBrush != null)
				return (Brush)FBrush.Clone(); 
			if (FColor.IsEmpty)
				return null;
			if (EndColor.IsEmpty)
				return new SolidBrush(FColor);
			return new LinearGradientBrush(aRect,  FColor, FEndColor, FAngle);
		}

		/// <summary>
		/// renvoi true si le brush est vide et que <see cref="Color"/> est vide
		/// </summary>
		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				return FBrush == null && FColor.IsEmpty;
			}
		}
		#endregion

		#region IDisposable Members
		/// <summary>
		/// dispose le brush contenu, si le cette structure à été instancié à partir d'un brush
		/// </summary>
		public void Dispose()
		{
			if (FBrush != null)
			{
				FBrush.Dispose();
				FBrush = null;
			}
		}

		#endregion

        /// <summary>
        /// convertit le brush en Color, seule <see cref="GeniusLinearGradientBrush.BeginColor"/> est prise en compte
        /// </summary>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static implicit operator Color(GeniusLinearGradientBrush brush)
        {
            return brush.Color;
        }

        //public static explicit operator Color(GeniusLinearGradientBrush brush)
        //{
        //    return brush.Color;
        //}

		/// <summary>
		/// réprésente un Brusg vide
		/// </summary>
		public static GeniusLinearGradientBrush Empty = new GeniusLinearGradientBrush(Color.Empty);
	}
}
