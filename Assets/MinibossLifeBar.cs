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
        if (other.CompareTag("Tiro") || other.CompareTag("Player"))
        {
            vidaMinibossAtual--;
            hpMinibossBar.value = vidaMinibossAtual;

            if (vidaMinibossAtual == 0)
            {
                PlayerIsAudioSource.PlayOneShot(AudioClipEnemiesExplosion, 0.35f);
                GameManager.instance.RecordPlus(pointsForGive);
                SummonPowerUp();
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
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.RecordPlus(pointsForGive);
                SummonPowerUp();
                Destroy(gameObject);
            }
        }
        private void SummonPowerUp()        // Invoca o power up baseado em %
        {
            int porcentagem = Random.Range(0, 101);
            if (porcentagem >= 1)
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
