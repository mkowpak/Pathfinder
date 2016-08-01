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

[CustomEditor(typeof(MultiCardGenerator))]
public class MultiCardGeneratorEditor : Editor 
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

		if (GUILayout.Button("Take All Screenshots"))
		{
			if (serializedObject.targetObject is MultiCardGenerator)
			{
				((MultiCardGenerator)serializedObject.targetObject).TakeSnapshots();
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
