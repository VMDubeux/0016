using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public Transform player;
    public GameObject sniperShootPrefab;
    public Transform pontaSniper;
    public float sniperShoot;
    public float sniperCDR;
    public float shootingSpeed;



    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform, Vector3.forward);
            sniperShoot += Time.deltaTime;
            if (sniperShoot >= sniperCDR)
            {
                SniperShoot();
            }

        }
    }

    private void SniperShoot()
    {
        GameObject tiro = Instantiate(sniperShootPrefab, pontaSniper.position, pontaSniper.rotation);
        Vector3 vector3 = transform.forward * shootingSpeed;
        tiro.GetComponent<Rigidbody>().velocity = vector3;
        sniperShoot = 0f;


    }

}
