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

public class CardMenuItems 
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

	[MenuItem("Assets/Create/Weapon Card")]
	public static WeaponCard CreateWeapon()
	{
		WeaponCard asset = ScriptableObject.CreateInstance<WeaponCard>();

		AssetDatabase.CreateAsset(asset, "Assets/Resources/Cards/WeaponCards/Weapon.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}

	[MenuItem("Assets/Create/Feat Card")]
	public static FeatCard CreateFeat()
	{
		FeatCard asset = ScriptableObject.CreateInstance<FeatCard>();

		AssetDatabase.CreateAsset(asset, "Assets/Resources/Cards/FeatCards/Feat.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
