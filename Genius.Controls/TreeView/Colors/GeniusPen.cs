using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Genius.Controls.TreeView.Converter;

namespace Genius.Controls.TreeView.Colors
{
	/// <summary>
	/// cette classe est surtout présente pour le designer de visual studio
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(GeniusPenConverter))]
	public struct GeniusPen
	{
		private Color FColor;
		private float		FWidth;
		private DashStyle FDashStyle;

		/// <summary>
		/// contructeur
		/// </summary>
		/// <param name="aColor">couleur du stylo</param>
		/// <param name="aWidth">épaisseur</param>
		public GeniusPen(Color aColor, float aWidth) : this(aColor, aWidth, DashStyle.Solid)
		{
		}

		/// <summary>
		/// constructeur
		/// </summary>
		/// <param name="aColor"></param>
		/// <param name="aWidth"></param>
		/// <param name="aStyle"></param>
		public GeniusPen(Color aColor, float aWidth, DashStyle aStyle)
		{
			FColor = aColor;
			FWidth = aWidth;
			FDashStyle = aStyle;			
		}

		/// <summary>
		/// couleur du stylo
		/// </summary>
		public Color Color
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
		/// épaisseur du stylo
		/// </summary>
		public float Width
		{
			get
			{
				return FWidth;
			}
			set
			{
				FWidth = value;
			}
		}

		/// <summary>
		/// style du stylo
		/// </summary>
		public DashStyle Style
		{
			get
			{
				return FDashStyle;
			}
			set
			{
				FDashStyle = value;
			}
		}
	}
}
