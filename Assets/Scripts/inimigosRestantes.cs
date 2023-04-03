using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inimigosRestantes : MonoBehaviour
{

    public GameObject enemies;
    private int enemiesCount;

    private UIcontroller GetUIcontroller()
    {
        return enemies.GetComponent<UIcontroller>();
    }

    void FixedUpdate(UIcontroller uIcontroller)
    {
        
        if (enemiesCount == 0)
        {
                {
                  SceneManager.LoadScene(0);
                }
        }
    }
}
