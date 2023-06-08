using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_1_DontDestroy : MonoBehaviour
{
    public static Ammo_1_DontDestroy instance;

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
