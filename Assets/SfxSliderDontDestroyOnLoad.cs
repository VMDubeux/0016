using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSliderDontDestroyOnLoad : MonoBehaviour
{
    public static SfxSliderDontDestroyOnLoad instance;

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
