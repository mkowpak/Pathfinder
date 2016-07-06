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
	[Header("Top")]
	[SerializeField] private BoundedText m_SpellName;
	[SerializeField] private TextMesh m_SpellLevel;

	[Header("Top Left")]
	[SerializeField] private BoundedText m_Target;
	[SerializeField] private BoundedText m_CastingTime;
	[SerializeField] private BoundedText m_Duration;

	[Header("Middle Left")]
	[SerializeField] private BoundedText m_RangeAndArea;

	[Header("Right")]
	[SerializeField] private GameObject m_Verbal;
	[SerializeField] private GameObject m_Somatic;
	[SerializeField] private GameObject m_Material;

	[Header("Bottom")]
	[SerializeField] private BoundedText m_Description;

	[Header("Card to Generate")]
	[SerializeField] private SpellCard m_SpellCard;

    // properties
	public SpellCard SpellCard
	{
		get { return m_SpellCard; }
	}
    #endregion

    #region Unity API
    #endregion

    #region Public Functions
	[ContextMenu("Generate")]
	public void GenerateSpellCard()
	{
		if (m_SpellCard != null)
		{
			m_SpellName.SetText(m_SpellCard.SpellName);
			m_SpellLevel.text = m_SpellCard.SpellLevel;
			
			m_Target.SetText(m_SpellCard.Target);
			m_CastingTime.SetText(m_SpellCard.CastingTime);
			m_Duration.SetText(m_SpellCard.Duration);
			
			m_RangeAndArea.SetText(m_SpellCard.RangeAndArea);
			
			m_Verbal.SetActive(m_SpellCard.Verbal);
			m_Somatic.SetActive(m_SpellCard.Somatic);
			m_Material.SetActive(m_SpellCard.Material);
			
			m_Description.SetText(m_SpellCard.Description);
		}
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
