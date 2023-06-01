using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy;
    private bool _FoiDestruido = false;
    public int pointsForGive;

    [Header("Complementar GameObject 1:")]
    public GameObject[] powerUp;

    [Header("Complementars Audio Explosion GameObjects 2:")]
    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        EnemyTakeDamage(other);
    }

    private void EnemyTakeDamage(Collider other)  //Inimigo tomando dano do player
    {
        if (other.tag == "Tiro")
        {
            Debug.Log(other.name);
            vidaEnemy--;
        }
        if (vidaEnemy == 0)
        {

            PlayerIsAudioSource.PlayOneShot(AudioClipEnemiesExplosion,0.35f);
            summonPowerUp();
            Destroy(gameObject);
            GameManager.instance.RecordPlus(pointsForGive);
            ExplodeEnemyShip();
            
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
        if (porcentagem >= 60)
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
