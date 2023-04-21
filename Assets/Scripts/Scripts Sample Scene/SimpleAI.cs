using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public Transform player;
    public float enemySpeed = 0.1f;
    private Vector3 targetPosition;
    private bool enemyLook;


    void FixedUpdate()
    {
        targetPosition = player.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, enemySpeed * Time.fixedDeltaTime);

        enemyLook = targetPosition.x - transform.position.x >= 0;

        if (enemyLook == true)
        {
            transform.rotation = Quaternion.Euler(-90f, -180f, -90f);

        }

        if (enemyLook == false)
        {
            transform.rotation = Quaternion.Euler(-90f, 0f, -90);
        }
    }

    
}

    

    
