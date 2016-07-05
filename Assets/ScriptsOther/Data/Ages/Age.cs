using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Age : Data
{
	#region Fields & Properties
	protected Dictionary<GlobalEnums.eAbilityTypes, short> m_AbilityModifiers = new Dictionary<GlobalEnums.eAbilityTypes, short>();
	#endregion

	#region Public Methods
	/// <summary>
	/// Populate the specified data.
	/// </summary>
	/// <param name="data">Data.</param>
	public override void Populate(Dictionary<string, object> data)
	{
		if (data.ContainsKey(AgeListParser.AGE_MOD_LIST_KEY))
		{
			m_AbilityModifiers = (Dictionary<GlobalEnums.eAbilityTypes, short>)data[AgeListParser.AGE_MOD_LIST_KEY];
		}
	}

	/// <summary>
	/// Gets the modifier for the provided ability.
	/// </summary>
	/// <returns>The modifier.</returns>
	/// <param name="abilityType">Ability type.</param>
	public short GetModifierForAbility(GlobalEnums.eAbilityTypes abilityType)
	{
		if (m_AbilityModifiers.ContainsKey(abilityType))
		{
			return m_AbilityModifiers[abilityType];
		}
		else
		{
			return short.MaxValue;
		}
	}
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion
}
