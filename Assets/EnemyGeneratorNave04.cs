using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorNave04 : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject Enemy;

    //Private Variables:
    //Transform:
    Transform Player;
    //Spawn Time:
    private float _spawnDelay = 3.0f;
    private float _spawnRepeatTime = 35.0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", _spawnDelay, _spawnRepeatTime);
    }

    void Update()
    {

    }

    void SpawnEnemies()
    {
        float _yScene = Random.Range(0, 2);
        if (_yScene == 1)
        {
            Vector3 _naveStartPos = new Vector3(250, Random.Range(100, 120), 11);
            GameObject _nave = Instantiate(Enemy, _naveStartPos, Enemy.transform.rotation);
            _nave.tag = "Inimigo";
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Vector3 _naveStartPos = new Vector3(250, Random.Range(-150, -175), 11);
            GameObject _nave = Instantiate(Enemy, _naveStartPos, Enemy.transform.rotation);
            _nave.tag = "Inimigo";
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
