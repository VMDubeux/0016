using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy = 3f;
    public int pointsForGive;
    public GameObject multGun;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tiro")
        {
            Debug.Log(other.name);
            vidaEnemy --;
            

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
        if (porcentagem >= 70)
        {
            GameObject tirasso = Instantiate(multGun, transform.position, transform.rotation);
            Vector3 vector3 = tirasso.transform.up * -100f;
            tirasso.GetComponent<Rigidbody>().velocity = vector3;
        }
    }

        


}
