using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveSin : MonoBehaviour
{
    [SerializeField] float _amplitude = 2;
    [SerializeField] float _frequency = 0.5f;
    [SerializeField] bool _inverted = false;
    float _sinCenterY;
    
    void Start()
    {
        _sinCenterY = transform.position.y;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        float sin = Mathf.Sin(position.x * _frequency) * _amplitude;
        if (_inverted)
            sin *= -1;
        position.y = _sinCenterY + sin;
        transform.position = position;
    }
}
