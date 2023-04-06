using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   [SerializeField] private float speedPowerUp;
   private shoot armaPlayer;
  private void OnTriggerEnter(Collider other)
  {
     if (other.CompareTag("Player"))
     {
      Debug.Log("Entrou em colisão");
        //lançar o efeito
        armaPlayer = other.GetComponent<shoot>();
        if (armaPlayer.quantidadeArmas < 3)
        {
            armaPlayer.quantidadeArmas++;
        }
        
         
        //aplicar efeito (no caso, não vai ter inicialmente)

        //destruir o powerup

        Destroy(gameObject);
     }
  }

}