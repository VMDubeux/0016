using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public GameObject SerraPrefab;
    public Transform Player;
    public float EnemySpeed = 0.1f;
    private Vector3 targetPosition;
    private bool enemyLook;
    private float _serraNumber;

    //Vector3 -> position Background:
    private Vector3 _startPos;

    //Time to Instantiate:
    private float _timeToRepeat = 10.0f;
    private float _timeLastInstantiate = 0.0f;

    void Start()
    {
        _startPos = new Vector3(300, Random.Range(-160, 135), 11);
        transform.position = _startPos;
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        AIserra();
        SpawnSerra();
    }

    private void AIserra()
    {
        if (Player != null)
        {
            targetPosition = Player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed * Time.fixedDeltaTime);

            /*enemyLook = targetPosition.x - transform.position.x >= 0;

            if (enemyLook == true)
            {
                transform.rotation = Quaternion.Euler(-90f, -180f, -90f);

            }

            if (enemyLook == false)
            {
                transform.rotation = Quaternion.Euler(-90f, 0f, -90);
            }*/
        }
    }

    void SpawnSerra()
    {
        float timer = Time.time;

        if (timer > _timeLastInstantiate + _timeToRepeat)
        {
            Vector3 _objectRot = new Vector3(0, 90, 0);
            Instantiate(SerraPrefab, _startPos, Quaternion.Euler(_objectRot));
            _timeLastInstantiate = timer;
        }
    }
}




