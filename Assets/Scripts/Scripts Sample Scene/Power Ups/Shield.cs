using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerShield(other);
    }
    private void PlayerShield(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personagem>().PlayerShield();
            Destroy(this.gameObject);
        }
    }
}
