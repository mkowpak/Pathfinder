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
using System.IO;

public class CardSheetGenerator : MonoBehaviour 
{
	#region Private Variables and Properties
    // consts
	private const string SPELLCARD_PATH = "SavedPNG";

    // Enums

    // public variables

    // protected variables

    // private variables
	[SerializeField] private Camera m_Camera;
	[SerializeField] private GameObject m_CopyObject;
	[SerializeField] private List<Texture2D> m_TexturesToUse = new List<Texture2D>();
	[SerializeField] private Color m_ColorToDiscard;
	private List<GameObject> m_Sheets = new List<GameObject>();
	private float m_Width = 0;
	private float m_Height = 0;

    // properties
    #endregion

    #region Unity API
    #endregion

    #region Public Functions
	public void CreateSheets()
	{
		if (m_TexturesToUse.Count > 0)
		{
			m_Width = m_Camera.targetTexture.width;
			m_Height = m_Camera.targetTexture.height;

			if (m_Width > 0 && m_Height > 0)
			{
				CreateSheetMeshes();
				this.StartCoroutine(CreateAllSheets());
			}
		}
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
	private void CreateSheetMeshes()
	{
		int counter = 1;
		while (m_TexturesToUse.Count > 0)
		{
			int width = m_TexturesToUse[0].width;
			int height = m_TexturesToUse[0].height;

			int columns = Mathf.FloorToInt(m_Width / width);
			int rows = Mathf.FloorToInt(m_Height / height);
			
			GameObject sheet = new GameObject("Sheet" + (counter));
			m_Sheets.Add(sheet);
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < columns; ++j)
				{
					if (m_TexturesToUse.Count > 0)
					{
						GameObject go = GameObject.Instantiate(m_CopyObject);
						go.transform.parent = sheet.transform;
						go.name = "Mesh" + i + j;
						MeshRenderer mesh = go.GetComponent<MeshRenderer>();
						if (mesh != null)
						{
							mesh.transform.localScale = new Vector3(width, height, 1);
							mesh.material.SetTexture("_MainTex", m_TexturesToUse[0]);
							m_TexturesToUse.RemoveAt(0);
						}
						go.transform.position = new Vector3((-m_Width/2 + width/2) + width * j, (m_Height/2 - height/2) - height * i, 0);
					}
				}
			}

			counter++;
		}

		for (int i = 0; i < m_Sheets.Count; ++i)
		{
			m_Sheets[i].SetActive(false);
		}

		m_CopyObject.gameObject.SetActive(false);
	}

	private IEnumerator CreateAllSheets()
	{
		int counter = 0;

		while (m_Sheets.Count > 0)
		{
			m_Sheets[0].SetActive(true);

			yield return new WaitForEndOfFrame();

			// Create a texture the size of the screen, RGB24 format
			Texture2D tex = new Texture2D((int)m_Width, (int)m_Height, TextureFormat.ARGB32, false);
			RenderTexture.active = m_Camera.targetTexture;
			
			// Read screen contents into the texture
			tex.ReadPixels(new Rect(0, 0, m_Width, m_Height), 0, 0);

			Color[] pixels =  tex.GetPixels();
			for (int i = 0; i < pixels.Length; ++i)
			{
				if (pixels[i].r == m_ColorToDiscard.r &&
					pixels[i].g == m_ColorToDiscard.g &&
					pixels[i].b == m_ColorToDiscard.b)
				{
					pixels[i].a = 0;
				}
			}

			tex.SetPixels(pixels);
			tex.Apply();
			// Encode texture into PNG
			byte[] bytes = tex.EncodeToPNG();
			Object.Destroy(tex);
			RenderTexture.active = null;

			// For testing purposes, also write to a file in the project folder
			File.WriteAllBytes(Application.dataPath + "/Resources/PNG/SavedPNGSheet/Sheet" + counter + ".png", bytes);

			m_Sheets[0].SetActive(false);
			m_Sheets.RemoveAt(0);

			counter++;
		}
	}
    #endregion
}
