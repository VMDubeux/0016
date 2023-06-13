using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    [Header("Complementar GameObject 1:")]
    public GameObject[] powerUp;

    [Header("Complementars Audio Explosion GameObjects 2:")]
    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;

    [Header("Complementar Bar GameObject 4:")]
    public Slider hpBossBar;

    private GameObject Enemies;

    //Private Variables:
    //HP:
    public float vidaBoss;
    public float vidaBossAtual;
    //Points:
    public int pointsForGive;

    void Start()
    {
        vidaBossAtual = vidaBoss;
        hpBossBar.maxValue = vidaBoss;
        hpBossBar.value = vidaBossAtual;

        Enemies = GameObject.FindGameObjectWithTag("Inimigo");
    }

    void Update()  //Dano do inimigo no player
    {
        if (Enemies.GetComponent<VidaEnemy>().vidaEnemy <= 0)
        {
            vidaBossAtual -= 1;
            hpBossBar.value = vidaBossAtual;

            if (vidaBossAtual == 0)
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
