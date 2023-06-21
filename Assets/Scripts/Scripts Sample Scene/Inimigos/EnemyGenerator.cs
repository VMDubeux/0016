using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject[] Enemy;

    //Private Variables:
    //Spawn Time:
    private readonly float _spawnDelay = 1.5f;
    private readonly float _spawnRepeatTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", _spawnDelay, _spawnRepeatTime);
    }

    void SpawnEnemies()
    {
        int _naveIndex = Random.Range(0, Enemy.Length);
        Vector3 _naveStartPos = new(300, Random.Range(-130, 105), 11);
        GameObject _nave = Instantiate(Enemy[_naveIndex], _naveStartPos, Enemy[_naveIndex].transform.rotation);
        _nave.tag = "Inimigo";
    }
}
