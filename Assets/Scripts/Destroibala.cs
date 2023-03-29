using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroibala : MonoBehaviour
{
 //Destói a porra do tiro do player
 void OnTriggerEnter(Collider other) 
 {
    if (other.tag == "Tiro" )
    {
        Destroy(other.gameObject);
    }  
 }
 
 
 
 
 
 
 
}