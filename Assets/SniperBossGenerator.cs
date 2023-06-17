using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossGenerator : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject Enemy;

    //Private Variables:
    //Transform:
    private Transform Player;
    //Spawn Time:
    private readonly float _spawnDelay = 0.5f;
    private readonly float _spawnRepeatTime = 2.0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), _spawnDelay, _spawnRepeatTime);
    }

    void SpawnEnemies()
    {
        GameObject _nave = Instantiate(Enemy, transform.position, Enemy.transform.rotation);
        _nave.tag = "Inimigo";
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
