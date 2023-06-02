using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{

    public float vidaAsteroid;
    public int pointsForGive;

    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    public AudioSource PlayerIsAudioSource;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tiro"))
        {
            vidaAsteroid--;
            if(vidaAsteroid == 0)
            {
                PlayerIsAudioSource.PlayOneShot(AudioClipEnemiesExplosion, 0.35f);
                Destroy(gameObject);
                GameManager.instance.RecordPlus(pointsForGive);
                ExplodeEnemyShip();
            }
                
        }
        
    }
    void ExplodeEnemyShip()
    {
        GameObject ExplosionFX = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(ExplosionFX, 0.75f);
    }
}
