using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPowerUp : MonoBehaviour
{
    public float tempoDeVida;
    private float _leftBound = -370f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _leftBound && gameObject.CompareTag("PowerUp")) Destroy(gameObject);
    }
}
