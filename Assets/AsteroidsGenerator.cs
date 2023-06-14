using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsGenerator : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject[] Asteroids;

    //Private Variables:
    //Spawn Time:
    private sbyte _spawnDelay = 1;
    private float _spawnRepeatTime = 0.6f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", _spawnDelay, _spawnRepeatTime);
    }

    void Update()
    {

    }

    void SpawnEnemies()
    {
        int _AsteroidsIndex = Random.Range(0, Asteroids.Length);
        Vector3 _naveStartPos = new Vector3(300, Random.Range(-165, 150), 11);
        GameObject _nave = Instantiate(Asteroids[_AsteroidsIndex], _naveStartPos, Asteroids[_AsteroidsIndex].transform.rotation);
        _nave.tag = "Inimigo";
    }
}
