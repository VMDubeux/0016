using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiBalaEnemy : MonoBehaviour
{

 void OnTriggerEnter(Collider other) 
 {
   destroiTiroEnemy(other);
 }
 
 private void destroiTiroEnemy(Collider other)
    {
        if (other.tag == "TiroEnemy")
        {
            Destroy(other.gameObject);
        }
    }
 
 
 
 
 
}