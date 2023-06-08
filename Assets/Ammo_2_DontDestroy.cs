using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_2_DontDestroy : MonoBehaviour
{
    public static Ammo_2_DontDestroy instance;

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
