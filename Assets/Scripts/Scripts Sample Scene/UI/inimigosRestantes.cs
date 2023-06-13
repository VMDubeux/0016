using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inimigosRestantes : MonoBehaviour
{
    [SerializeField] private string gameSceneRespawn;
    public GameObject []enemies;
    private int enemiesCount;

    void sceneManager(SampleSceneManagerScript uIcontroller)
    {
        
        if (enemiesCount == 0)
        {
                {
                  SceneManager.LoadScene(gameSceneRespawn);
                }
        }
    }
}
