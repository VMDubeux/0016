using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private AudioManager audioManager;

    public void OnTriggerEnter(Collider other)
    {
        PlayerShield(other);
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
    public void PlayerShield(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Personagem>().PlayerShield();
            AudioManager.Instance.PlaySFX("PickPowerUp", 0.05f); //teste
            Destroy(this.gameObject);
        }
    }
}
