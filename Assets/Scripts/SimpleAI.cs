using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 0.1f;
    private Vector3 targetPosition;    
    
     
    void FixedUpdate()
    {
        targetPosition = player.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.fixedDeltaTime);
    }
}
