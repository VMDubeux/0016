using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{

    public float vidaAsteroid;
    public int pointsForGive;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tiro"))
        {
            vidaAsteroid--;
            if(vidaAsteroid == 0)
            {
                Destroy(gameObject);
                GameManager.instance.RecordPlus(pointsForGive);
            }
                
        }
        
    }
}
