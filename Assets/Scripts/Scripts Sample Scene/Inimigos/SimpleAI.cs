using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    
    public Transform Player;
    public float EnemySpeed = 0.1f;
    private Vector3 targetPosition;

    private void Start()
    {
        Player.transform.position = GameObject.Find("Nave do player").transform.position;

    }
    void FixedUpdate()
    {
        AIserra();
    }

    private void AIserra()
    {
        if (Player != null)
        {
            targetPosition = Player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed * Time.fixedDeltaTime);

        }
    }

   
    
}




