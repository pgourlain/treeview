using System;
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Genius.Controls.GeniusTab
{
	/// <summary>
	/// classe necessaire pour l'inspecteur de propriétés, la liste des marges
	/// </summary>
	public class TabMarginsConverter : TypeConverter
	{
		/// <summary>
		/// 
		/// </summary>
		public TabMarginsConverter()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="sourceType"></param>
		/// <returns></returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom (context, sourceType);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="destinationType"></param>
		/// <returns></returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
				return true;
			return base.CanConvertTo (context, destinationType);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="culture"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			if (!(value is string))
			{
				return base.ConvertFrom(context, culture, value);
			}
			string sText = ((string) value).Trim();
			if (sText.Length == 0)
				return null;
			if (culture == null)
				culture = CultureInfo.CurrentCulture;

			char ch1 = culture.TextInfo.ListSeparator[0];
			char[] chArray1 = new char[1] { ch1 } ;
			string[] sTextArray = sText.Split(chArray1);
			int[] numArray1 = new int[sTextArray.Length];
			TypeConverter converter1 = TypeDescriptor.GetConverter(typeof(int));
			for (int num1 = 0; num1 < numArray1.Length; num1++)
			{
				numArray1[num1] = (int) converter1.ConvertFromString(context, culture, sTextArray[num1]);
			}
			if (numArray1.Length == 4)
				return new TabMargins(numArray1[0], numArray1[1], numArray1[2], numArray1[3]);

			object[] objArray1 = new object[2] { sText, "left, top, right, bottom" } ;
			throw new ArgumentException(String.Format("Format invalide de '{0}', alors que '{1}' attendu", objArray1));
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
				throw new ArgumentNullException("destinationType");
			}
			if ((destinationType == typeof(string)) && (value is TabMargins))
			{
				TabMargins margins = (TabMargins) value;
				if (culture == null)
					culture = CultureInfo.CurrentCulture;
				string text1 = culture.TextInfo.ListSeparator + " ";
				TypeConverter converter1 = TypeDescriptor.GetConverter(typeof(int));
				string[] textArray1 = new string[4];
				int num1 = 0;
				textArray1[num1++] = converter1.ConvertToString(context, culture, margins.Left);
				textArray1[num1++] = converter1.ConvertToString(context, culture, margins.Top);
				textArray1[num1++] = converter1.ConvertToString(context, culture, margins.Right);
				textArray1[num1++] = converter1.ConvertToString(context, culture, margins.Bottom);
				return string.Join(text1, textArray1);
			}
			if ((destinationType == typeof(InstanceDescriptor)) && (value is TabMargins))
			{
				TabMargins margins = (TabMargins) value;
				Type[] typeArray1 = new Type[4] { typeof(int), typeof(int), typeof(int), typeof(int) } ;
				ConstructorInfo info1 = typeof(TabMargins).GetConstructor(typeArray1);
				if (info1 != null)
				{
					object[] objArray1 = new object[4] { margins.Left, margins.Top, margins.Right, margins.Bottom } ;
					return new InstanceDescriptor(info1, objArray1);
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="propertyValues"></param>
		/// <returns></returns>
		public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
		{
			return new TabMargins((int)propertyValues["Left"], (int)propertyValues["Top"], 
									(int)propertyValues["Right"], (int)propertyValues["Bottom"]);
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
		/// <param name="value"></param>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, System.Attribute[] attributes)
		{
			PropertyDescriptorCollection collection1 = TypeDescriptor.GetProperties(typeof(TabMargins), attributes);
			string[] textArray1 = new string[] { "Left", "Top", "Right", "Bottom" } ;
			return collection1.Sort(textArray1);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
