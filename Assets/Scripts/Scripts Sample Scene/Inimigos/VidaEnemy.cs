using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy;
    public int pointsForGive;
    public GameObject[] powerUp;


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

            GameManager.instance.RecordPlus(pointsForGive);
            summonPowerUp();
            Destroy(gameObject);


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
        int porcentagem = Random.Range(0,101);
        if (porcentagem >= 10)
        {
            int powerUps = Random.Range(0, powerUp.Length);
            GameObject tirasso = Instantiate(powerUp[powerUps], transform.position, transform.rotation);
            Vector3 vector3 = tirasso.transform.up * -100f;
            tirasso.GetComponent<Rigidbody>().velocity = vector3;
        }
    }

        


}
