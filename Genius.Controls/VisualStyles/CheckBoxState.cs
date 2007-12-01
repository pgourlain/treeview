
namespace Genius.Controls.VisualStyles
{
	//reprise des �tats du framework 2.0
	/// <summary>
	/// d�termine l'�tat du dessin lors de l'appel � <see cref="Genius.Controls.Drawing.DrawCheckBox"/>
	/// </summary>
	public enum CheckBoxState
	{
		/// <summary>
		/// Coch� et gris�
		/// </summary>
		CheckedDisabled = 8,
		/// <summary>
		/// coch� et souris au dessus
		/// </summary>
		CheckedHot = 6,
		/// <summary>
		/// coch�
		/// </summary>
		CheckedNormal = 5,
		/// <summary>
		/// coch� et souris bouton gauche enfonc�
		/// </summary>
		CheckedPressed = 7,
		/// <summary>
		/// 
		/// </summary>
		MixedDisabled = 12,
		/// <summary>
		/// 
		/// </summary>
		MixedHot = 10,
		/// <summary>
		/// 
		/// </summary>
		MixedNormal = 9,
		/// <summary>
		/// 
		/// </summary>
		MixedPressed = 11,
		/// <summary>
		/// d�coch� et gris�
		/// </summary>
		UncheckedDisabled = 4,
		/// <summary>
		/// d�coch� et souris au dessus
		/// </summary>
		UncheckedHot = 2,
		/// <summary>
		/// d�coch�
		/// </summary>
		UncheckedNormal = 1,
		/// <summary>
		/// D�coch� et bouton gauche souris enfonc�
		/// </summary>
		UncheckedPressed = 3
	} 

	public enum ComboBoxState
	{
		/// <summary>
		/// gris�
		/// </summary>
		Disabled = 4,
		/// <summary>
		/// souris au dessus
		/// </summary>
		Hot = 2,
		/// <summary>
		/// normal
		/// </summary>
		Normal = 1,
		/// <summary>
		/// enfonc�
		/// </summary>
		Pressed = 3
	}

	public enum PushButtonState
	{
		// Fields
		/// <summary>
		/// default
		/// </summary>
		Default = 5,
		/// <summary>
		/// gris�
		/// </summary>
		Disabled = 4,
		/// <summary>
		/// souris au dessus
		/// </summary>
		Hot = 2,
		/// <summary>
		/// normal
		/// </summary>
		Normal = 1,
		/// <summary>
		/// enfonc�
		/// </summary>
		Pressed = 3
	}

	enum ButtonPart
	{
		BP_None			   = 0,
		BP_PUSHBUTTON      = 1,
		BP_RADIOBUTTON     = 2,
		BP_CHECKBOX        = 3,
		BP_GROUPBOX        = 4,
		BP_USERBUTTON      = 5		
	}
	
	/// <summary>
	/// enum�ration repr�sentant l'�tat de l'icone [+-]
	/// </summary>
	public enum TreeViewGlyghState
	{
		/// <summary>
		/// None
		/// </summary>
		GLPS_None  = 0,
		/// <summary>
		/// affiche +
		/// </summary>
		GLPS_CLOSED        = 1,
		/// <summary>
		/// affiche -
		/// </summary>
		GLPS_OPENED        = 2
	}

	enum TreeViewPart
	{
		TREEVIEWPartFiller0  = 0,
		TVP_TREEITEM         = 1,
		TVP_GLYPH            = 2,
		TVP_BRANCH           = 3
	}

	enum ToolTipPart
	{
		TOOLTIPPartFiller0  = 0,
		TTP_STANDARD        = 1,
		TTP_STANDARDTITLE   = 2,
		TTP_BALLOON         = 3,
		TTP_BALLOONTITLE    = 4,
		TTP_CLOSE           = 5		
	}
}
