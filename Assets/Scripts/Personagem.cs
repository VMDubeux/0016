using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    Rigidbody rb;
    
    public float moveSpeed = 190f;
    public float vidaPlayer = 5f;
    public shoot arma;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical,0f ) * moveSpeed * Time.deltaTime;

          
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

        if (vidaPlayer == 0 || other.tag == "Destruir")
        {
            Destroy(gameObject);
        }
    }


}
