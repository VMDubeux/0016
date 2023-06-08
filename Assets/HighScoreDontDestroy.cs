using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreDontDestroy : MonoBehaviour
{
    public static HighScoreDontDestroy instance;

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
