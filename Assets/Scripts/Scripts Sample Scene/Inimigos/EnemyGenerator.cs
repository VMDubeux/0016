using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject[] Enemy;

    //Private Variables:
    //Spawn Time:
    private sbyte _spawnDelay = 2;
    private float _spawnRepeatTime = 3f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", _spawnDelay, _spawnRepeatTime);
    }

    void Update()
    {

    }

    void SpawnEnemies()
    {
        int _naveIndex = Random.Range(0, Enemy.Length);
        Vector3 _naveStartPos = new Vector3(300, Random.Range(-130, 105), 11);
        GameObject _nave = Instantiate(Enemy[_naveIndex], _naveStartPos, Enemy[_naveIndex].transform.rotation);
        _nave.tag = "Inimigo";
    }
}
