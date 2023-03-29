using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiBalaEnemy : MonoBehaviour
{
 //Destói a porra do tiro do inimigo
 void OnTriggerEnter(Collider other) 
 {
    if (other.tag == "TiroEnemy")
    {
        Destroy(other.gameObject);
    }  
 }
 
 
 
 
 
 
 
}