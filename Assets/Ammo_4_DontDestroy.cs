using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_4_DontDestroy : MonoBehaviour
{
    public static Ammo_4_DontDestroy instance;

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
