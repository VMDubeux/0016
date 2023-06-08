using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy;
    private bool _FoiDestruido = false;
    public int pointsForGive;

    private AudioManager audioManager;

   [Header("Complementar GameObject 1:")]
    public GameObject[] powerUp;

    [Header("Complementars Audio Explosion GameObjects 2:")]
    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
    public void OnTriggerEnter(Collider other)
    {
        EnemyTakeDamage(other);
    }

    public void EnemyTakeDamage(Collider other)  //Inimigo tomando dano do player
    {
        if (other.tag == "Tiro")
        {
            Debug.Log(other.name);
            vidaEnemy--;
        }
        if (vidaEnemy == 0)
        {

            audioManager.PlaySFX("Explosion");
            summonPowerUp();
            Destroy(gameObject);
            GameManager.instance.RecordPlus(pointsForGive);
            ExplodeEnemyShip();

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        PlayerGetPowerUp(collision);
    }

    public void PlayerGetPowerUp(Collision collision)      //Power up colide com o "Player"
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag != "Boss")
        {
            GameManager.instance.RecordPlus(pointsForGive);
            summonPowerUp();
            Destroy(gameObject);
        }
    }
    public void summonPowerUp()        // Invoca o power up baseado em %
    {
        int porcentagem = Random.Range(0, 101);
        if (porcentagem >= 60)
        {
            int powerUps = Random.Range(0, powerUp.Length);
            GameObject tirasso = Instantiate(powerUp[powerUps], transform.position, transform.rotation);
            Vector3 vector3 = Vector3.left * 100f;
            tirasso.GetComponent<Rigidbody>().velocity = vector3;
        }
    }

    public void ExplodeEnemyShip()
    {
        GameObject ExplosionFX = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(ExplosionFX, 0.75f);

    }
}
