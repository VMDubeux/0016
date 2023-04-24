using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerAtirador : MonoBehaviour
{
    public GameObject Player; //Usar como par�metro de chegada
    [SerializeField] float _enemySpeed = 50; //Velocidade do inimigo
    [SerializeField] float _amplitude = 2; //Amplitude (tamanho) da "onda"
    [SerializeField] float _frequency = 0.5f; //Frequ�ncia (espa�o) entre "ondas"
    [SerializeField] bool _inverted = false; //Espelhar movimenta��o da "onda"
    float _sinCenterY;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        _sinCenterY = transform.position.y;
        EnemyGenerator(); //M�todo gerador de inimigos
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x -= _enemySpeed * Time.fixedDeltaTime;
        float sin = Mathf.Sin(position.x * _frequency) * _amplitude;
        DestroyGameObject(position); //Destr�i objeto ap�s passar determinada �rea
        transform.position = position;
    }

    private void EnemyGenerator() //M�todo gerador de inimigo
    {
        int _enemyGenerator = 1;
        transform.GetChild(_enemyGenerator).gameObject.SetActive(true);
    }

    private void DestroyGameObject(Vector2 position) //M�todo destr�i inimigo
    {
        if (position.x < -1000)
            Destroy(gameObject);
    }
}
