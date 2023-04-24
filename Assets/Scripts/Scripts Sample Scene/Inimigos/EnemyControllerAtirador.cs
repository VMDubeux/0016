using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerAtirador : MonoBehaviour
{
    public GameObject Player; //Usar como parâmetro de chegada
    [SerializeField] float _enemySpeed = 50; //Velocidade do inimigo
    [SerializeField] float _amplitude = 2; //Amplitude (tamanho) da "onda"
    [SerializeField] float _frequency = 0.5f; //Frequência (espaço) entre "ondas"
    [SerializeField] bool _inverted = false; //Espelhar movimentação da "onda"
    float _sinCenterY;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        _sinCenterY = transform.position.y;
        EnemyGenerator(); //Método gerador de inimigos
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x -= _enemySpeed * Time.fixedDeltaTime;
        float sin = Mathf.Sin(position.x * _frequency) * _amplitude;
        DestroyGameObject(position); //Destrói objeto após passar determinada área
        transform.position = position;
    }

    private void EnemyGenerator() //Método gerador de inimigo
    {
        int _enemyGenerator = 1;
        transform.GetChild(_enemyGenerator).gameObject.SetActive(true);
    }

    private void DestroyGameObject(Vector2 position) //Método destrói inimigo
    {
        if (position.x < -1000)
            Destroy(gameObject);
    }
}
