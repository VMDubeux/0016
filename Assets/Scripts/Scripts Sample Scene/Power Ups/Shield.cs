using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        PlayerShield(other);
    }
    public void PlayerShield(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            other.GetComponent<Personagem>().PlayerShield();
            Destroy(this.gameObject);
        }
    }
}
