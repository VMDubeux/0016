using UnityEngine;

public class VidaEnemy : MonoBehaviour
{
    public float vidaEnemy = 3f;
    public int pointsForGive;
    public GameObject powerUp;


    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Tiro")
        {
            vidaEnemy --;
        }   
            if (vidaEnemy == 0 || other.tag == "Player")
            {

            GameManager.instance.RecordPlus(pointsForGive);
            summonPowerUp();
            Destroy(gameObject);
            
            
            }
        
        
    }

    private void summonPowerUp() 
    {
        int porcentagem = Random.Range(0,101);
        if (porcentagem >= 70)
        {
            GameObject tirasso = Instantiate(powerUp, transform.position, transform.rotation);
            Vector3 vector3 = tirasso.transform.up * -100f;
            tirasso.GetComponent<Rigidbody>().velocity = vector3;
        }
    }

        


}
