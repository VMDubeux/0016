using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject[] pontoDeOrigem; 
    public GameObject tiroPrefab; 
    public float timeToShoot;
    private float timeSinceLastShot = 0f;
    public float quantidadeArmas;
    public AudioSource audioSource;
  
    // Update is called once per frame
    void Update()
    {
                
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timeSinceLastShot >= timeToShoot) 
        {
            for (int i = 0; i < quantidadeArmas; i++)
            {
            GameObject tiro = Instantiate(tiroPrefab, pontoDeOrigem[i].transform.position, pontoDeOrigem[i].transform.rotation);             
            Vector3 vector3 = transform.up * 500f;
            tiro.GetComponent<Rigidbody>().velocity = vector3;
            timeSinceLastShot = 0f; 

            audioSource.Play();
            }
        }

        
    }

 


}
