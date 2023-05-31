using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    private float _leftBound = -295f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World); // Move to the left

        if (transform.position.x < _leftBound && !gameObject.CompareTag("Inimigo")) Destroy(gameObject);// If object goes off screen that is NOT the background, destroy it
    }
}
