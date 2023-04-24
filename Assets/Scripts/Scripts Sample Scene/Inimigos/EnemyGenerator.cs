using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Enemy;
    public float TimeToGenerate = 2;
    private float _timeCounter = 0;

    void Start()
    {

    }

    void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= TimeToGenerate)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            _timeCounter = 0;
        }
    }
}
