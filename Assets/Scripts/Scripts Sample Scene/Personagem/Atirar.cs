using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public Transform[] pontaDaArma;
    public GameObject prefab;
    public float velocidadeDisparo;
    



    public void TiroPlayer()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
           var tiroplayer = Instantiate(prefab, pontaDaArma[1].position, pontaDaArma[1].rotation);
            tiroplayer.GetComponent<Rigidbody>().velocity = pontaDaArma[1].right * velocidadeDisparo;
        }
    }

    public void ShootSpeed()
    {
        transform.Translate(Vector3.up * velocidadeDisparo * Time.deltaTime);
    }
    private void Update()
    {
        ShootSpeed(); 
    }
}
