using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChifreDaMaria : MonoBehaviour
{

    public Transform Player;
    public Vector3 targetPosition;
    public GameObject sniperShootPrefab;
    public Transform pontaArma;

    public float speed;
    public float sniperShoot;
    public float sniperCDR;
    public float shootingSpeed;
    private Vector3 _startPos;
    // Start is called before the first frame update
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
        GameObject tiro = Instantiate(sniperShootPrefab, pontaArma.position, pontaArma.rotation);
        Vector3 vector3 = transform.forward * shootingSpeed;
        tiro.GetComponent<Rigidbody>().velocity = vector3;
        sniperShoot = 0f;
    }
    public void Suicidio()
    {
        if (Player != null)
        {
            targetPosition = Player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);
        }

    }
}
