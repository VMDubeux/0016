using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotParticle : MonoBehaviour
{
    public ParticleSystem part;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            part.Play();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Tiro"))
        {
            Debug.Log("morreu!");
        }
    }
}
