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

public class WeaponCardGenerator : CardGenerator 
{
	#region Private Variables and Properties
    // consts

    // Enums

    // public variables

    // protected variables

    // private variables
	[SerializeField] private BoundedText m_WeaponName;

	[SerializeField] private BoundedText m_Attack;
	[SerializeField] private BoundedText m_Critical;
	[SerializeField] private BoundedText m_Range;

	[SerializeField] private BoundedText m_Enchant;

	[SerializeField] private BoundedText m_Materials;

	[SerializeField] private BoundedText m_Special;
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
			m_WeaponName.SetText(((WeaponCard)m_Card).WeaponName);
			m_Attack.SetText(((WeaponCard)m_Card).Attack);
			m_Critical.SetText(((WeaponCard)m_Card).Critical);
			m_Range.SetText(((WeaponCard)m_Card).Range);
			m_Enchant.SetText(((WeaponCard)m_Card).Enchant);
			m_Materials.SetText(((WeaponCard)m_Card).Materials);
			m_Special.SetText(((WeaponCard)m_Card).Special);
		}
	}
    #endregion

    #region Protected Functions
    #endregion

    #region Private Functions
    #endregion
}
