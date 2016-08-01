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

public class FeatCardGenerator : CardGenerator 
{
	#region Private Variables and Properties
    // consts

    // Enums

    // public variables

    // protected variables

    // private variables
	[SerializeField] private BoundedText m_FeatName;
	[SerializeField] private BoundedText m_Description;
	[SerializeField] private BoundedText m_PageNumber;

    // properties
    #endregion

    #region Unity API
    #endregion

    #region Public Functions
	public override void CreateCard(Card card)
	{
		base.CreateCard(card);

		if (m_Card != null)
		{
			m_FeatName.SetText(((FeatCard)m_Card).FeatName);
			m_Description.SetText(((FeatCard)m_Card).Description);
			m_PageNumber.SetText(((FeatCard)m_Card).PageNumber);
		}
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
