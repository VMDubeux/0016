using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidaextra : MonoBehaviour
{
    private AudioManager audioManager;
    public int _vidaParaDar;


    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GanharVida(other);
    }

    public void GanharVida(Collider other)     //Adiciona vida ao player
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personagem>().GanharVida(_vidaParaDar);
            audioManager.PlaySFX("PickPowerUp", 0.65f);
            Destroy(this.gameObject);
        }
    }

}
