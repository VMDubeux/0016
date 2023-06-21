using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigoBoss : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject[] Enemy;

    //Private Variables:
    //Spawn Time:
    private readonly sbyte _spawnDelay = 1;
    private readonly float _spawnRepeatTime = 0.75f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), _spawnDelay, _spawnRepeatTime);
    }

    void SpawnEnemies()
    {
        int _naveIndex = Random.Range(0, Enemy.Length);
        
        if (Enemy[_naveIndex].name == "Nave_01_I" || Enemy[_naveIndex].name == "Nave_01_N") //Cabeça meio
        {
            Vector3 _naveStartPos = new(205, -3.25f, 11);
            GameObject _nave = Instantiate(Enemy[_naveIndex], _naveStartPos, Enemy[_naveIndex].transform.rotation);
            _nave.tag = "Inimigo";
        }
        else if (Enemy[_naveIndex].name == "Cornasso_Esp") //Cabeça cima
        {
            Vector3 _naveStartPos = new(176, 98, 11);
            GameObject _nave = Instantiate(Enemy[_naveIndex], _naveStartPos, Enemy[_naveIndex].transform.rotation);
            _nave.tag = "Inimigo";
        }
        else if (Enemy[_naveIndex].name == "Serra_Esp") //Cabeça baixo
        {
            Vector3 _naveStartPos = new(161, -111, 11);
            GameObject _nave = Instantiate(Enemy[_naveIndex], _naveStartPos, Enemy[_naveIndex].transform.rotation);
            _nave.tag = "Inimigo";
        }
    }
}
