using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDontDestroy : MonoBehaviour
{
    public static ScoreDontDestroy instance;

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