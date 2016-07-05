using UnityEngine;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class DataList<T> where T : Data
{
	#region Fields & Properties
	protected List<T> m_DataList = new List<T>();

	protected Action<DataList<T>> m_OnInitializatonComplete = null;
	#endregion

	#region Public Methods
	public virtual void AddDataElement(T data)
	{
		if (!m_DataList.Contains(data))
		{
			m_DataList.Add(data);
		}
		else
		{
			Debug.LogWarningFormat("{0} already contains {1}.", this.GetType(), data);
		}
	}

	public virtual void RemoveDataElement(T data)
	{
		m_DataList.Remove(data);
	}

	public virtual void Initialize(Action<DataList<T>> onInitializationComplete)
	{
		m_OnInitializatonComplete = onInitializationComplete;
	}
	#endregion

	#region Protected Methods
	protected abstract void FetchData();
	protected abstract void ParseData(JsonData[] data);
	#endregion

	#region Private Methods
	#endregion
}
