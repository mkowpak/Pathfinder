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

[CustomEditor(typeof(CardGenerator), true)]
public class CardGeneratorEditor : Editor 
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
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		serializedObject.Update();

		if (GUILayout.Button("Generate Card"))
		{
			if (serializedObject.targetObject is CardGenerator)
			{
				((CardGenerator)serializedObject.targetObject).CreateCard();
			}
		}

		serializedObject.ApplyModifiedProperties();
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
