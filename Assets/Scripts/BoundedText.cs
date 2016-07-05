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

[RequireComponent(typeof(BoxCollider2D))]
public class BoundedText : MonoBehaviour 
{
	#region Private Variables and Properties
    // consts

    // enums

    // public variables

    // protected variables

    // private variables
	[SerializeField] private bool m_IsMultiline = false;
	[SerializeField] private bool m_MaximizeText = false;

	private TextMesh m_TextMesh = null;
	private BoxCollider2D m_BoxCollider2D = null;

	private bool m_WasLarger = false;

    // properties
    #endregion

    #region Unity API
    #endregion

	#region Public Functions
	public void Initialize()
	{
		m_WasLarger = false;
		m_TextMesh = GetComponentInChildren<TextMesh>();

		if (m_TextMesh == null)
		{
			m_TextMesh = CreateTextMesh();
		}

		m_BoxCollider2D = GetComponent<BoxCollider2D>();
	}

	public void SetText(string text)
	{
		Initialize();

		m_TextMesh.text = text;

		ResizeText();
	}

	public void ResizeText()
	{
		// make sure the components are accessible
		if (m_TextMesh == null || m_BoxCollider2D == null)
		{
			Initialize();
		}

		RepositionTextMesh();

		if (m_IsMultiline)
		{
			DoMultilineSeparation();
		}

		// recursive check, increment/decrement font size by 1 every time
		if (CheckSuccess())
		{
			if (!m_MaximizeText || m_WasLarger)
			{
				return;
			}

			m_TextMesh.fontSize += 1;
			ResizeText();
		}
		else
		{
			m_WasLarger = true;

			m_TextMesh.fontSize -= 1;
			ResizeText();
		}
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
	private TextMesh CreateTextMesh()
	{
		TextMesh textMesh = new GameObject("BoundedText").AddComponent<TextMesh>();
		textMesh.transform.parent = transform;
		textMesh.transform.localPosition = Vector3.zero;

		textMesh.characterSize = 10;
		textMesh.text = "Test text";
		textMesh.fontSize = 20;

		return textMesh;
	}

	private void RepositionTextMesh()
	{
		Bounds textMeshBounds = m_TextMesh.GetComponent<Renderer>().bounds;

		// find to left corner of each box
		Vector3 textTopLeft = new Vector3(textMeshBounds.min.x, textMeshBounds.max.y, transform.position.z);
		Vector3 boxTopLeft = new Vector3(m_BoxCollider2D.bounds.min.x, m_BoxCollider2D.bounds.max.y, transform.position.z);

		// reposition
		m_TextMesh.transform.position += boxTopLeft - textTopLeft;
	}

	private void DoMultilineSeparation()
	{
		if (CheckSuccess())
		{
			return;
		}

		string[] wordArray = m_TextMesh.text.Split(' ');
		int wordIndex = 0;

		string fullText = m_TextMesh.text;
		string previousText = "";
		bool hasJustFailed = false;

		do 
		{
			m_TextMesh.text = previousText + wordArray[wordIndex];
			m_TextMesh.text += " ";

			if (CheckSuccess())
			{
				wordIndex++;
				hasJustFailed = false;
			}
			else
			{
				if (wordIndex == 0 || hasJustFailed)
				{
					m_TextMesh.text = fullText;
					return;
				}

				hasJustFailed = true;
				m_TextMesh.text = previousText + "\n";
			}

			previousText = m_TextMesh.text;
		} while(wordIndex < wordArray.Length);

		m_TextMesh.text = m_TextMesh.text.Trim();
	}

	/// <summary>
	/// Checks the success.
	/// True if smaller.
	/// False if larger.
	/// </summary>
	private bool CheckSuccess()
	{
		Bounds textMeshBounds = m_TextMesh.GetComponent<Renderer>().bounds;

		return m_BoxCollider2D.bounds.Contains(textMeshBounds.min) && m_BoxCollider2D.bounds.Contains(textMeshBounds.max);
	}
    #endregion
}
