using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy = 3f;
    public GameObject powerUp;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Tiro")
        {
            vidaEnemy --;
        }   
            if (vidaEnemy <= 0 || other.tag == "Player")
            {
                Destroy(gameObject);
            }
        
        
    }

    private void OnDestroy() 
    {
        int porcentagem = Random.Range(0,101);
        if (porcentagem >= 50)
        {
            GameObject tirasso = Instantiate(powerUp, transform.position, transform.rotation);
                             
        }
    }

        


}
