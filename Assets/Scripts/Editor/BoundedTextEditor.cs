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

[CustomEditor(typeof(BoundedText))]
public class BoundedTextEditor : Editor 
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

		EditorGUILayout.BeginVertical();
		{
			if (GUILayout.Button("Resize"))
			{
				if (serializedObject.targetObject is BoundedText)
				{
					((BoundedText)serializedObject.targetObject).Initialize();
					((BoundedText)serializedObject.targetObject).ResizeText();
				}
			}
		}
		EditorGUILayout.EndVertical();

		serializedObject.ApplyModifiedProperties();
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
