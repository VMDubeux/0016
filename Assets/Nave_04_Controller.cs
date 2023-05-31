using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave_04_Controller : MonoBehaviour
{
    Transform Player;
    public GameObject sniperShootPrefab;
    public Transform pontaSniper;
    public float sniperShoot;
    public float sniperCDR;
    public float shootingSpeed;
    private Vector3 Rot = new Vector3(-105,20,170f);

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log($"Este é o player: {Player.transform}");
        Debug.Log($"Este é o transform position: {transform.rotation}");
    }

    void Update()
    {
        transform.LookAt(Player, Rot);
        sniperShoot += Time.deltaTime;

        if (sniperShoot >= sniperCDR)
        {
            SniperShoot();
        }
    }

    private void SniperShoot()
    {
        GameObject tiro = Instantiate(sniperShootPrefab, pontaSniper.position, pontaSniper.rotation);
        Vector3 vector3 = transform.right * shootingSpeed;
        tiro.GetComponent<Rigidbody>().velocity = vector3;
        sniperShoot = 0f;
    }
}
