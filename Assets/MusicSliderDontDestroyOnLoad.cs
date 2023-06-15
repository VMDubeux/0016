using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSliderDontDestroyOnLoad : MonoBehaviour
{
    public static MusicSliderDontDestroyOnLoad instance;

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
