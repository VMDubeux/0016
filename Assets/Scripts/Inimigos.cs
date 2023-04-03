using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{

    public GameObject inimigos;
    public Canvas canvas;
    
   

    private void FixedUpdate()
    {
        GameObject[] inimigosArray = GameObject.FindGameObjectsWithTag("Inimigo");
        if (inimigosArray.Length == 0)
        {
            canvas.gameObject.SetActive(true);
            
        }
    }
}