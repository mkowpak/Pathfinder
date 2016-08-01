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

public class CardGenerator : MonoBehaviour 
{
	#region Private Variables and Properties
    // consts

    // Enums

    // public variables

    // protected variables

    // private variables

	[SerializeField] protected Card m_Card;

    // properties
	public Card Card
	{
		get { return m_Card; }
		set { m_Card = value; }
	}
    #endregion

    #region Unity API
    #endregion

    #region Public Functions
	public virtual void CreateCard(Card card = null)
	{
		if (card != null)
		{
			m_Card = card;
		}
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
