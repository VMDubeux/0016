using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidaextra : MonoBehaviour
{
   
    public float _vidaParaDar;

    private void OnTriggerEnter(Collider other)
    {
        GanharVida(other);
    }

    public void GanharVida(Collider other)     //Adiciona vida ao player
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personagem>().ganharVida(_vidaParaDar);
            Destroy(this.gameObject);
        }
    }

}
