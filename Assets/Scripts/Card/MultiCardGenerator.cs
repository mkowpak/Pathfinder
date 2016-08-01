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

public class MultiCardGenerator : MonoBehaviour 
{
	#region Private Variables and Properties
    // consts
	private const string SPELLCARD_PATH = "SpellCards";
    // Enums

    // public variables

    // protected variables

    // private variables
	[SerializeField] private CardGenerator m_CardGenerator;
	[SerializeField] private CardScreenshot m_Screenshot;

	[SerializeField] private List<Card> m_CardsToGenerate = new List<Card>();

    // properties
    #endregion

    #region Unity API
    #endregion

    #region Public Functions
	public void TakeSnapshots()
	{
		m_CardGenerator.Card = null;

		if (m_CardsToGenerate.Count > 0)
		{
			m_CardsToGenerate.Add(m_CardsToGenerate[0]);
		}

		this.StartCoroutine(TakeAllSnapshots());
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
	private IEnumerator TakeAllSnapshots()
	{
		while (m_CardsToGenerate.Count > 0)
		{
			m_CardGenerator.CreateCard(m_CardsToGenerate[0]);
			m_Screenshot.SaveCard();

			yield return null;

			m_CardsToGenerate.RemoveAt(0);
		}
	}
    #endregion
}
