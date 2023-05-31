using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinibossLifeBar : MonoBehaviour
{
 
    [Header("Complementar GameObject 1:")]
    public GameObject[] powerUp;

    [Header("Complementars Audio Explosion GameObjects 2:")]
    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;

    [Header("Complementar Bar GameObject 4:")]
    public Slider hpMinibossBar;

    //Private Variables:
    //HP:
    public float vidaMiniboss;
    public float vidaMinibossAtual;
    //Points:
    public int pointsForGive;

    private void Start()
    {
        vidaMinibossAtual = vidaMiniboss;
        hpMinibossBar.maxValue = vidaMiniboss;
        hpMinibossBar.value = vidaMinibossAtual;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerTakeDamage(other);
    }

    public void PlayerTakeDamage(Collider other)  //Dano do inimigo no player
    {
        if (other.tag == "Tiro")
        {
            vidaMinibossAtual--;
            hpMinibossBar.value = vidaMinibossAtual;

            if (vidaMiniboss == 0 || other.tag == "Player")
            {
                PlayerIsAudioSource.PlayOneShot(AudioClipEnemiesExplosion, 0.35f);
                GameManager.instance.RecordPlus(pointsForGive);
                summonPowerUp();
                Destroy(gameObject);
                ExplodeEnemyShip();
            }
        }
    }

        private void OnCollisionEnter(Collision collision)
        {
            PlayerGetPowerUp(collision);
        }

        private void PlayerGetPowerUp(Collision collision)      //Power up colide com o "Player"
        {
            if (collision.gameObject.tag == "Player")
            {
                GameManager.instance.RecordPlus(pointsForGive);
                summonPowerUp();
                Destroy(gameObject);
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
