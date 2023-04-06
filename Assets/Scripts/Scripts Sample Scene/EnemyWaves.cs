using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemies = 3;

    // Start is called before the first frame update
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Destruir")
        {
            
        }    
    }

}