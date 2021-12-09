using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Singleton<T> where T : new()
{

    private static T _instance;

    public static T Instance
    {
        get { 
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance; 
        }
    }

}

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T Instance { 
        get {  return _instance;  }
    }

    protected void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            // instance = obj.AddComponent<T>();
            DontDestroyOnLoad(_instance);
        }
        else if (_instance != this as T)
        {
            Object.Destroy(_instance);
        }
    }
}
