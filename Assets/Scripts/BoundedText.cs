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
	private enum eXAlignment
	{
		LEFT,
		CENTER,
		RIGHT
	}

	private enum eYAlignment
	{
		TOP,
		CENTER,
		BOTTOM
	}

    // public variables

    // protected variables

    // private variables
	[SerializeField] private bool m_IsMultiline = false;
	[SerializeField] private bool m_MaximizeText = false;
	[SerializeField] private int m_MaxFontSize = 50;
	[SerializeField] private eXAlignment m_XAlignment = eXAlignment.LEFT;
	[SerializeField] private eYAlignment m_YAlignment = eYAlignment.TOP;

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
		if (m_MaximizeText)
		{
			m_TextMesh.fontSize = m_MaxFontSize;
		}

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
		if (CheckSuccess() || m_TextMesh.fontSize <= 0)
		{
			if (!m_MaximizeText || m_WasLarger || (m_MaximizeText && m_TextMesh.fontSize >= m_MaxFontSize))
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

		Vector3 destination = Vector3.zero; // location on the box
		Vector3 source = Vector3.zero; // location on the text mesh

		float x1 = 0;
		float y1 = 0;
		float x2 = 0;
		float y2 = 0;

		// setup x pos
		if (m_XAlignment == eXAlignment.LEFT)
		{
			x1 = textMeshBounds.min.x;
			x2 = m_BoxCollider2D.bounds.min.x;
		}
		else if (m_XAlignment == eXAlignment.CENTER)
		{
			x1 = textMeshBounds.center.x;
			x2 = m_BoxCollider2D.bounds.center.x;
		}
		else if (m_XAlignment == eXAlignment.RIGHT)
		{
			x1 = textMeshBounds.max.x;
			x2 = m_BoxCollider2D.bounds.max.x;
		}

		// setup y pos
		if (m_YAlignment == eYAlignment.TOP)
		{
			y1 = textMeshBounds.max.y;
			y2 = m_BoxCollider2D.bounds.max.y;
		}
		else if (m_YAlignment == eYAlignment.CENTER)
		{
			y1 = textMeshBounds.center.y;
			y2 = m_BoxCollider2D.bounds.center.y;
		}
		else if (m_YAlignment == eYAlignment.BOTTOM)
		{
			y1 = textMeshBounds.min.y;
			y2 = m_BoxCollider2D.bounds.min.y;
		}
			
		source = new Vector3(x1, y1, transform.position.z);
		destination = new Vector3(x2, y2, transform.position.z);

		// reposition
		m_TextMesh.transform.position += destination - source;
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
