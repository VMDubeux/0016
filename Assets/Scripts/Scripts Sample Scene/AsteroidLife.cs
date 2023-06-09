using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{

    public float vidaAsteroid;
    public int pointsForGive;

    private AudioManager audioManager;

    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    public AudioSource PlayerIsAudioSource;

    public GameObject[] powerUp;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tiro"))
        {

            vidaAsteroid--;
            if (vidaAsteroid == 0)
            {
                //PlayerIsAudioSource.PlayOneShot(AudioClipEnemiesExplosion, 0.35f);
                audioManager.PlaySFX("Explosion");
                Destroy(gameObject);
                GameManager.instance.RecordPlus(pointsForGive);
                summonPowerUp();
                ExplodeEnemyShip();
            }

        }

    }
    private void summonPowerUp()        // Invoca o power up baseado em %
    {
        int porcentagem = Random.Range(0, 101);
        if (porcentagem >= 10)
        {
            int powerUps = Random.Range(0, powerUp.Length);
            GameObject tirasso = Instantiate(powerUp[powerUps], transform.position, transform.rotation);
            Vector3 vector3 = Vector3.left * 100f;
            tirasso.GetComponent<Rigidbody>().velocity = vector3;


        }
    }
    void ExplodeEnemyShip()
    {
        GameObject ExplosionFX = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(ExplosionFX, 0.75f);
    }
}

