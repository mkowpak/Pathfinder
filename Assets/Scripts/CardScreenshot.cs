// CardScreenshot
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
using System.IO;

public class CardScreenshot : MonoBehaviour 
{
	#region Private Variables and Properties
    // consts

    // Enums

    // public variables

    // protected variables

    // private variables
	[SerializeField] private CardGenerator m_CardGenerator;
	[SerializeField] private Camera m_Camera;

    // properties
    #endregion

    #region Unity API
	private void Awake()
	{
		SaveCard();
	}
    #endregion

    #region Public Functions
	public void SaveCard()
	{
		m_CardGenerator.GenerateSpellCard();
		this.StartCoroutine(SaveToPNG());
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
	private IEnumerator SaveToPNG()
	{
		// We should only read the screen buffer after rendering is complete
		yield return new WaitForEndOfFrame();

		Bounds bounds = GetBoundsOfRoot();

		// Create a texture the size of the screen, RGB24 format
		int width = (int)bounds.size.x;
		int height = (int)bounds.size.y;
		Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Object.Destroy(tex);

		// For testing purposes, also write to a file in the project folder
		File.WriteAllBytes(Application.dataPath + "/Resources/SavedPNG/" + m_CardGenerator.SpellCard.name + ".png", bytes);
	}

	private Bounds GetBoundsOfRoot()
	{
		Renderer[] renderers = m_CardGenerator.GetComponentsInChildren<Renderer>();
		Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
		for (int i = 0; i < renderers.Length; ++i)
		{
			bounds.Encapsulate(renderers[i].bounds);
		}

		return bounds;
	}
    #endregion
}
