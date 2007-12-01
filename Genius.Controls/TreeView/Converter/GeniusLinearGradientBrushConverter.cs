using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Genius.Controls.TreeView.Converter
{
	/// <summary>
	/// convertiseur pour le <see cref="GeniusLinearGradientBrush"/>
	/// </summary>
	public class GeniusLinearGradientBrushConverter : GeniusBaseConverter
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public GeniusLinearGradientBrushConverter()
		{
		}

		/// <summary>
		/// renvoi la liste des propriétés disponible pour l'inspecteur de propriétés
		/// </summary>
		/// <param name="context"></param>
		/// <param name="value"></param>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] attributes)
		{
			PropertyDescriptorCollection collection1 = TypeDescriptor.GetProperties(typeof(GeniusLinearGradientBrush), attributes);
			string[] textArray1 = new string[3] {"Angle", "BeginColor", "EndColor" } ;
			return collection1.Sort(textArray1);
		}

		/// <summary>
		/// Convertit un <see cref="GeniusLinearGradientBrush"/> en string ou en <see cref="InstanceDescriptor"/>
		/// </summary>
		/// <param name="context"></param>
		/// <param name="culture"></param>
		/// <param name="value"></param>
		/// <param name="destinationType"></param>
		/// <returns></returns>
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, System.Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value == null)
				return string.Empty;
			if ((destinationType == typeof(string)) && (value is GeniusLinearGradientBrush))
			{
				GeniusLinearGradientBrush br = (GeniusLinearGradientBrush) value;
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}

				TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));
				TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(Color));
				string text1 = culture.TextInfo.ListSeparator + " ";
				string[] properties = new string[4];
				int index = 0;
				properties[index++] = floatConverter.ConvertToString(context, culture, br.Angle);
				properties[index++] = colorConverter.ConvertToString(context, culture, br.BeginColor);
				properties[index++] = colorConverter.ConvertToString(context, culture, br.EndColor);
				return string.Join(text1, properties);
			}
            if ((destinationType == typeof(Color)) && (value is GeniusLinearGradientBrush))
                return ((GeniusLinearGradientBrush)value).Color;
                
            if ((destinationType != typeof(InstanceDescriptor)) || !(value is GeniusLinearGradientBrush))
				return base.CanConvertTo(context, destinationType);
			
			Type[] array = new Type[]{typeof(Color), typeof(Color), typeof(float)};
			ConstructorInfo constructor = typeof(GeniusLinearGradientBrush).GetConstructor(array);
			if (constructor != null)
			{
				GeniusLinearGradientBrush br = (GeniusLinearGradientBrush)value;
				object[] objArray = new object[]{br.BeginColor, br.EndColor, br.Angle};
				return new InstanceDescriptor(constructor, objArray);
			}
			/*
			if ((destinationType == typeof(InstanceDescriptor)) && (value is Point))
			{
				Point point2 = (Point) value;
				Type[] typeArray1 = new Type[2] { typeof(int), typeof(int) } ;
				ConstructorInfo info1 = typeof(Point).GetConstructor(typeArray1);
				if (info1 != null)
				{
					object[] objArray1 = new object[2] { point2.X, point2.Y } ;
					return new InstanceDescriptor(info1, objArray1);
				}
			}
			*/

			return base.CanConvertTo (context, destinationType);
		}

		/// <summary>
		/// convertit un chaîne en <see cref="GeniusLinearGradientBrush"/>
		/// </summary>
		/// <param name="context"></param>
		/// <param name="culture"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (!(value is string))
			{
				return base.ConvertFrom(context, culture, value);
			}
			string text1 = ((string) value).Trim();
			if (text1.Length == 0)
			{
				return null;
			}
			if (culture == null)
			{
				culture = CultureInfo.CurrentCulture;
			}
			char ch1 = culture.TextInfo.ListSeparator[0];
			string[] textArray1 = text1.Split(ch1);

			if (textArray1.Length != 3)
			{
				throw new ArgumentException("Format de chaine invalide !, format attendu : xxxxxx");
			}
			TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));
			TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(Color));

			float angle = (float)floatConverter.ConvertFromString(context, culture, textArray1[0]);
			Color[] colors = new Color[2];

			for (int index = 0; index < 2; index++)
			{
				colors[index] = (Color)colorConverter.ConvertFromString(context, culture, textArray1[1+index]);
			}
			return new GeniusLinearGradientBrush(colors[0], colors[1], angle);
		}

		/// <summary>
		/// indique que la création d'instance est supporté par le converter
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		/// créer un instance de <see cref="GeniusLinearGradientBrush"/>
		/// </summary>
		/// <param name="context"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
		{
			return new GeniusLinearGradientBrush((Color)propertyValues["BeginColor"], (Color)propertyValues["EndColor"], (float)propertyValues["Angle"]);
		}

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Color))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
	}
}
