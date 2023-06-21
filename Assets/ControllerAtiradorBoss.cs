using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAtiradorBoss : MonoBehaviour
{
    [Header("Public Variable:")]
    public bool _inverted = false; //Espelhar movimentação da "onda"

    //Not Serialized Private Variables:
    private readonly float _enemySpeed = 75; //Velocidade do inimigo
    private readonly float _amplitude = 50; //Amplitude (tamanho) da "onda"
    private readonly float _frequency = 0.02f; //Frequência (espaço) entre "ondas"
    private float _sinCenterY;

    void Start()
    {
        _sinCenterY = transform.position.y;
    }

    void Update()
    {
        DestroyGameObject(); //Destrói objeto após passar determinada área
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;
        position.x -= _enemySpeed * Time.fixedDeltaTime;
        float sin = Mathf.Sin(position.x * _frequency) * _amplitude;
        if (_inverted)
            sin *= -1;
        position.y = _sinCenterY + sin;
        transform.position = position;
    }

    private void DestroyGameObject() //Método destrói inimigo
    {
        if (transform.position.x < -370)
            Destroy(gameObject);
    }
}
