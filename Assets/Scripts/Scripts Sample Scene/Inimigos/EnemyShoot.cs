using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //Script que faz o inimigo atirar pra frente 
    public Transform pontaDaArma;
    public GameObject tiroPrefab;
    public float timeToShootEnemy = 0.1f;
    private float timeSinceLastShotEnemy = 0.1f; 

    void FixedUpdate()
    {
        timeSinceLastShotEnemy += Time.fixedDeltaTime; 

        if (timeSinceLastShotEnemy >= timeToShootEnemy)
        {
            GameObject tiro =  Instantiate(tiroPrefab, pontaDaArma.position, tiroPrefab.transform.rotation);
            tiro.GetComponent<Rigidbody>().velocity = new Vector3 (-250f,0f,0f);
            timeSinceLastShotEnemy = 0.001f;
        }
    }
}
