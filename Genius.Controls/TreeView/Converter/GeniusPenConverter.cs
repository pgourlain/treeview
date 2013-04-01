using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using Genius.Controls.TreeView.Colors;

namespace Genius.Controls.TreeView.Converter
{
	/// <summary>
	/// Summary description for GeniusPenConverter.
	/// </summary>
	public class GeniusPenConverter : GeniusBaseConverter
	{
		/// <summary>
		/// constructeur par défaut
		/// </summary>
		public GeniusPenConverter()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="value"></param>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] attributes)
		{
			PropertyDescriptorCollection collection1 = TypeDescriptor.GetProperties(typeof(GeniusPen), attributes);
			string[] textArray1 = new string[3] {"Color", "Width", "Style" } ;
			return collection1.Sort(textArray1);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
		{
			return new GeniusPen((Color)propertyValues["Color"], (float)propertyValues["Width"], (DashStyle)propertyValues["Style"]);
		}

		/// <summary>
		/// 
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
				//MessageBox.Show("Erreur ! destinationType");
				throw new ArgumentNullException("destinationType");
			}
			if (value == null)
				return string.Empty;
            if ((destinationType == typeof(GeniusPen)) && (value is GeniusPen))
                return value;
			if ((destinationType == typeof(string)) && (value is GeniusPen))
			{
				GeniusPen br = (GeniusPen) value;
				if (culture == null)
				{
					culture = CultureInfo.CurrentCulture;
				}

				TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));
				TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(Color));
				TypeConverter DashConverter = TypeDescriptor.GetConverter(typeof(DashStyle));
				string text1 = culture.TextInfo.ListSeparator + " ";
				string[] properties = new string[3];
				int index = 0;
				properties[index++] = floatConverter.ConvertToString(context, culture, br.Width);
				properties[index++] = colorConverter.ConvertToString(context, culture, br.Color);
				properties[index++] = DashConverter.ConvertToString(context, culture, br.Style);
				return string.Join(text1, properties);
			}
			if ((destinationType != typeof(InstanceDescriptor)) || !(value is GeniusPen))
				return base.CanConvertTo(context, destinationType);
			
			Type[] array = new Type[]{typeof(Color), typeof(float), typeof(DashStyle)};
			ConstructorInfo constructor = typeof(GeniusPen).GetConstructor(array);
			if (constructor != null)
			{
				GeniusPen pen = (GeniusPen)value;
				object[] objArray = new object[]{pen.Color, pen.Width, pen.Style};
				return new InstanceDescriptor(constructor, objArray);
			}
			return base.CanConvertTo (context, destinationType);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="culture"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
            if (value is GeniusPen)
                return (GeniusPen)value;
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

			if (textArray1.Length != 3 && textArray1.Length != 5)
			{
				throw new ArgumentException(String.Format("Format de chaine invalide !, format attendu : xxxxxx : longueur : {0}", textArray1.Length));
			}
			TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));
			TypeConverter colorConverter = TypeDescriptor.GetConverter(typeof(Color));
			TypeConverter DashConverter = TypeDescriptor.GetConverter(typeof(DashStyle));

			float angle = (float)floatConverter.ConvertFromString(context, culture, textArray1[0]);
			Color color;
			string strColor = textArray1.Length == 3 ? textArray1[1] : string.Join(";", textArray1, 1, 3);
			color = (Color)colorConverter.ConvertFromString(context, culture, strColor.Trim());
			DashStyle style = (DashStyle)DashConverter.ConvertFromString(context, culture, textArray1.Length == 3 ? textArray1[2] : textArray1[4]);
			return new GeniusPen( color, angle, style);
		}
	}
}
