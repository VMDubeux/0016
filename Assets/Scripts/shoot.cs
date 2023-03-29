using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject[] pontoDeOrigem; 
    public GameObject tiroPrefab; 
    public float timeToShoot = 0.1f;
    private float timeSinceLastShot = 0.2f;
    public float quantidadeArmas;


       // Update is called once per frame
    void Update()
    {
                
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timeSinceLastShot >= timeToShoot) 
        {
            for (int i = 0; i < quantidadeArmas; i++)
            {
            GameObject tiro = Instantiate(tiroPrefab, pontoDeOrigem[i].transform.position, pontoDeOrigem[i].transform.rotation);
            Vector3 vector3 = transform.right * 500f;
            tiro.GetComponent<Rigidbody>().velocity = vector3;
            timeSinceLastShot = 0.7f; 
        }
            }

        
    }

 


}
