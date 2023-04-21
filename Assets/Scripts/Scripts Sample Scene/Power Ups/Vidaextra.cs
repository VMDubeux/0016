using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidaextra : MonoBehaviour
{
   
    public float vidaParaDar;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personagem>().ganharVida(vidaParaDar);
            Destroy(this.gameObject);
        }
    }
}
