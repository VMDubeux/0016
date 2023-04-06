using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Canvas canvas;
    public float moveSpeed = 190f;
    public float vidaPlayer = 5f;
    public shoot arma;
   
        void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TiroEnemy")
        {
            vidaPlayer --;
            if (arma.quantidadeArmas != 1)
            {
                arma.quantidadeArmas--;
            }
        }

        if (vidaPlayer == 0 || other.tag == "Inimigo")
        {
            Destroy(gameObject);
            canvas.gameObject.SetActive(true);

        }
    }


}
