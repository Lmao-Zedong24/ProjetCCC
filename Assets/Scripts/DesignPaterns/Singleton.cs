using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; protected set; }

    protected virtual void Awake()
    {
        if (!Instance)
        {
            Instance = this as T;
            DontDestroyOnLoad(Instance);
        }

        else if (this != Instance)
            Destroy(this);
    }

    private void OnDestroy()
    {
        if (this == Instance)
            Instance = null;
    }

    //private static T LoadGameObj()
    //{
    //    var obj = new GameObject();
    //    DontDestroyOnLoad(Instance);
    //    return obj.AddComponent<T>();
    //}
}
