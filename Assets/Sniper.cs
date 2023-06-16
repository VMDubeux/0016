using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    Transform Player;
    public GameObject sniperShootPrefab;
    public Transform pontaSniper;
    public float sniperShoot;
    public float sniperCDR;
    public float shootingSpeed;
    private Vector3 _startPos;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.LookAt(Player);
        sniperShoot += Time.deltaTime;
        
        if (sniperShoot >= sniperCDR)
        {
            SniperShoot();
        }
    }

    public void SniperShoot()
    {
        GameObject tiro = Instantiate(sniperShootPrefab, pontaSniper.position, sniperShootPrefab.transform.rotation);
        Vector3 vector3 = transform.forward * shootingSpeed;
        tiro.GetComponent<Rigidbody>().velocity = vector3;
        sniperShoot = 0f;
    }
}
