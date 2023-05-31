using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGeneratorSniper : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject Enemy;

    //Private Variables:
    //Transform:
    Transform Player;
    //Spawn Time:
    private float _spawnDelay = 3.0f;
    private float _spawnRepeatTime = 20.0f;

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
            Vector3 _naveStartPos = new Vector3(300, Random.Range(80, 100), 11);
            GameObject _nave = Instantiate(Enemy, _naveStartPos, Enemy.transform.rotation);
            _nave.tag = "Inimigo";
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            Vector3 _naveStartPos = new Vector3(300, Random.Range(-125, -150), 11);
            GameObject _nave = Instantiate(Enemy, _naveStartPos, Enemy.transform.rotation);
            _nave.tag = "Inimigo";
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
