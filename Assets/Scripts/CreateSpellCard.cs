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
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CreateSpellCard 
{
	#region Private Variables and Properties
    // consts

    // Enums

    // public variables

    // protected variables

    // private variables

    // properties
    #endregion

    #region Unity API
    #endregion

    #region Public Functions
	[MenuItem("Assets/Create/Spell Card")]
	public static SpellCard Create()
	{
		SpellCard asset = ScriptableObject.CreateInstance<SpellCard>();

		AssetDatabase.CreateAsset(asset, "Assets/Resources/Spellcards/EnlargePerson.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
