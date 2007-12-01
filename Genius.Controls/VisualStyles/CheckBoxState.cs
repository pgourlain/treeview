
namespace Genius.Controls.VisualStyles
{
	//reprise des états du framework 2.0
	/// <summary>
	/// détermine l'état du dessin lors de l'appel à <see cref="Genius.Controls.Drawing.DrawCheckBox"/>
	/// </summary>
	public enum CheckBoxState
	{
		/// <summary>
		/// Coché et grisé
		/// </summary>
		CheckedDisabled = 8,
		/// <summary>
		/// coché et souris au dessus
		/// </summary>
		CheckedHot = 6,
		/// <summary>
		/// coché
		/// </summary>
		CheckedNormal = 5,
		/// <summary>
		/// coché et souris bouton gauche enfoncé
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
		/// décoché et grisé
		/// </summary>
		UncheckedDisabled = 4,
		/// <summary>
		/// décoché et souris au dessus
		/// </summary>
		UncheckedHot = 2,
		/// <summary>
		/// décoché
		/// </summary>
		UncheckedNormal = 1,
		/// <summary>
		/// Décoché et bouton gauche souris enfoncé
		/// </summary>
		UncheckedPressed = 3
	} 

	public enum ComboBoxState
	{
		/// <summary>
		/// grisé
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
		/// enfoncé
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
		/// grisé
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
		/// enfoncé
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
	/// enumération représentant l'état de l'icone [+-]
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
