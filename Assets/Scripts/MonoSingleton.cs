﻿using UnityEngine;
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
	private static T m_Instance = null;
	public static T Instance
	{
		get
		{
			// Instance requiered for the first time, we look for it
			if( m_Instance == null)
			{
				m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
				
				// Object not found, we create a temporary one
				if( m_Instance == null )
				{
					Debug.LogWarning("No instance of " + typeof(T).ToString() + ", a temporary one is created.");
					m_Instance = new GameObject("Temp Instance of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
					DontDestroyOnLoad(m_Instance);
					// Problem during the creation, this should not happen
					if( m_Instance == null )
					{
						Debug.LogError("Problem during the creation of " + typeof(T).ToString());
					}
				}
				
				m_Instance.DoInitialize();
			}
			return m_Instance;
		}
	}
	
	private bool _isInitialized = false;
	
	// If no other monobehaviour request the instance in an awake function
	// executing before this one, no need to search the object.
	private void Awake()
	{
		if( m_Instance != null && m_Instance != this) {
			DestroyImmediate(gameObject);
		}else if( m_Instance == null) {
			m_Instance = this as T;
			m_Instance.DoInitialize();
		}
	}
	
	// This function is called when the instance is used the first time
	// Put all the initializations you need here, as you would do in Awake
	public virtual void Init(){}
	
	private void DoInitialize() {
		if(!_isInitialized) {
			_isInitialized = true;
			Init();
		}
	}
}