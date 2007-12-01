using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Genius.Controls.TreeView.Converter
{
	/// <summary>
	/// TypeConverter de base pour tout les autres convertisseur de cette assembly
	/// </summary>
	public class GeniusBaseConverter : TypeConverter
	{
		/// <summary>
		/// construteur par défaut
		/// </summary>
		public GeniusBaseConverter()
		{
		}

		/// <summary>
		/// return true si le type source est une <see cref="string"/>
		/// </summary>
		/// <param name="context"></param>
		/// <param name="sourceType"></param>
		/// <returns></returns>
		public override bool CanConvertFrom(ITypeDescriptorContext context, System.Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom (context, sourceType);
		}

		/// <summary>
		/// renvoi true si le type est <see cref="InstanceDescriptor"/>, sinon c'est l'ancêtre qui gère
		/// </summary>
		/// <param name="context"></param>
		/// <param name="destinationType"></param>
		/// <returns></returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo (context, destinationType);
		}

		/// <summary>
		/// renvoi true, pour indiqeur que les propriétés sont supportées
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
