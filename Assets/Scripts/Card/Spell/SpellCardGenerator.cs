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

public class SpellCardGenerator : CardGenerator 
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
	[SerializeField] private BoundedText m_PageNumber;

	// properties
	#endregion

	#region Unity API
	#endregion

	#region Public Functions
	public override void CreateCard(Card card = null)
	{
		base.CreateCard(card);
			
		if (m_Card != null)
		{
			m_SpellName.SetText(((SpellCard)m_Card).SpellName);
			m_SpellLevel.text = ((SpellCard)m_Card).SpellLevel;

			m_Target.SetText(((SpellCard)m_Card).Target);
			m_CastingTime.SetText(((SpellCard)m_Card).CastingTime);
			m_Duration.SetText(((SpellCard)m_Card).Duration);

			m_RangeAndArea.SetText(((SpellCard)m_Card).RangeAndArea);

			m_Verbal.SetActive(((SpellCard)m_Card).Verbal);
			m_Somatic.SetActive(((SpellCard)m_Card).Somatic);
			m_Material.SetActive(((SpellCard)m_Card).Material);

			m_Description.SetText(((SpellCard)m_Card).Description);
			m_PageNumber.SetText(((SpellCard)m_Card).PageNumber);
		}
	}
	#endregion

	#region Protected Functions
	#endregion

	#region Private Functions
	#endregion
}
