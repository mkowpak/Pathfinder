// Loader
//
// Author:
// Eric Robitaille
//
// Edited By:
// 
// 
// Description:
// 
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellCard : ScriptableObject
{
	#region Private Variables and Properties
    // consts

    // Enums

    // public variables
	// top
	public string SpellName = "Enlarge Person";
	public string SpellLevel = "1";

	// topleft	
	public string Target = "Self";
	public string CastingTime = "1 round";
	public string Duration = "1 min / level";

	// middle left
	public string RangeAndArea = "Humanoid touched.";

	// right
	public bool Verbal = true;
	public bool Somatic = true;
	public bool Material = false;

	// bottom
	public string Description = "Target becomes enlarged.";
    // protected variables

    // private variables

    // properties
    #endregion

    #region Unity API
    #endregion

    #region Public Functions

    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
