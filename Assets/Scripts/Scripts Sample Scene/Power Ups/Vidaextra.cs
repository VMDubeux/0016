using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidaextra : MonoBehaviour
{
   
    internal float _vidaParaDar = 15.0f;

    private void OnTriggerEnter(Collider other)
    {
        GanharVida(other);
    }

    private void GanharVida(Collider other)     //Adiciona vida ao player
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personagem>().ganharVida(_vidaParaDar);
            Destroy(this.gameObject);
        }
    }

}
