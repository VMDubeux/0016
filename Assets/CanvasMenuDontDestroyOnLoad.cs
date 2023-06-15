using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMenuDontDestroyOnLoad : MonoBehaviour
{
    public static CanvasMenuDontDestroyOnLoad instance;

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
