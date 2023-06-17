using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy;
    public int pointsForGive;

    private AudioManager audioManager;

   [Header("Complementar GameObject 1:")]
    public GameObject[] powerUp;

    [Header("Complementars Audio Explosion GameObjects 2:")]
    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;

    private GameObject fase5;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    private void Start()
    {
        fase5 = GameObject.FindGameObjectWithTag("Fase5");

    }

    private void Update()
    {
        DefeatMode();
    }

    private void DefeatMode()
    {
        if (vidaEnemy <= 1.0f)
        {
            /*fase5.GetComponent<Fase5Manager>().enemiesDestroyed++;
            Debug.Log(fase5.GetComponent<Fase5Manager>().enemiesDestroyed);*/
            SummonPowerUp();
            Destroy(gameObject);
            GameManager.instance.RecordPlus(pointsForGive);
            audioManager.PlaySFX("Explosion", 0.15f);
            ExplodeEnemyShip();

            BossLifeBar boss = FindObjectOfType<BossLifeBar>(); //modifiquei essa parte
            if (boss != null)
            {
                boss.PerderVida(1);
                boss.hpBossBar.value = boss.vidaBossAtual;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        EnemyTakeDamage(other);
    }

    public void EnemyTakeDamage(Collider other)  //Inimigo tomando dano do player
    {
        if (other.CompareTag("Tiro"))
        {
            vidaEnemy--;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerGetPowerUp(collision);
    }

    public void PlayerGetPowerUp(Collision collision)      //Power up colide com o "Player"
    {
        if (collision.gameObject.CompareTag("Player") && !gameObject.CompareTag("Boss"))
        {
            GameManager.instance.RecordPlus(pointsForGive);
            SummonPowerUp();
            Destroy(gameObject);
        }
    }
    public void SummonPowerUp()        // Invoca o power up baseado em %
    {
        int porcentagem = Random.Range(0, 101);
        if (porcentagem >= 60)
        {
            int powerUps = Random.Range(0, powerUp.Length);
            GameObject tirasso = Instantiate(powerUp[powerUps], transform.position, powerUp[powerUps].transform.rotation);
            Vector3 vector3 = (Vector3.left * 100f);
            tirasso.GetComponent<Rigidbody>().velocity = vector3;
        }
    }

    public void ExplodeEnemyShip()
    {
        GameObject ExplosionFX = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(ExplosionFX, 0.75f);

    }
}
