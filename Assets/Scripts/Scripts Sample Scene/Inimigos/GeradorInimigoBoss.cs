using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigoBoss : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject[] Enemy;
    public Transform[] pontaArma;

    //Private Variables:
    //Spawn Time:
    private readonly sbyte _spawnDelay = 2;
    private readonly float _spawnRepeatTime = 3f;

    void Start()
    {
        InvokeRepeating("SpawnEnemies", _spawnDelay, _spawnRepeatTime);
    }

    void SpawnEnemies()
    {
        int _naveIndex = Random.Range(0, Enemy.Length);
        int _pontaArmaIndex = Random.Range(0, pontaArma.Length);
        //Vector3 _naveStartPos = new(215, -12.5f, 11);
        GameObject _nave = Instantiate(Enemy[_naveIndex], pontaArma[_pontaArmaIndex].transform.position, Enemy[_naveIndex].transform.rotation);
        _nave.tag = "Inimigo";
    }
}
