using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inimigosRestantes : MonoBehaviour
{
    [SerializeField] private string gameSceneRespawn;
    public GameObject enemies;
    private int enemiesCount;

    private SampleSceneManagerScript GetSampleSceneManagerScript()
    {
        return enemies.GetComponent<SampleSceneManagerScript>();
    }

    void FixedUpdate(SampleSceneManagerScript uIcontroller)
    {
        
        if (enemiesCount == 0)
        {
                {
                  SceneManager.LoadScene(gameSceneRespawn);
                }
        }
    }
}
