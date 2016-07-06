// CardScreenshotEditor
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

[CustomEditor(typeof(CardScreenshot))]
public class CardScreenshotEditor : Editor 
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

		if (GUILayout.Button("Save PNG"))
		{
			if (serializedObject.targetObject is CardScreenshot)
			{
				((CardScreenshot)serializedObject.targetObject).SaveCard();
			}

			AssetDatabase.Refresh();
		}

		serializedObject.ApplyModifiedProperties();
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
