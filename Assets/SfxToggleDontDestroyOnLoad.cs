using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxToggleDontDestroyOnLoad : MonoBehaviour
{
    public static SfxToggleDontDestroyOnLoad instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
}
