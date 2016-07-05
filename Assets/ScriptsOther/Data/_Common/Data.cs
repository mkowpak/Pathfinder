using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Data 
{
	#region Fields & Properties
	#endregion

	#region Unity Methods
	#endregion

	#region Public Methods
	/// <summary>
	/// Populate the specified data.
	/// </summary>
	/// <param name="data">Data.</param>
	public abstract void Populate(Dictionary<string, object> data);
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion
}
