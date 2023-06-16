using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{

    public Canvas victoryCanvas;
    public KeyCode victoryKey = KeyCode.V;

    private bool hasWon = false;
 
    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(victoryKey) && !hasWon)
        {
            ActivateVictory();
        }
    }

    void ActivateVictory()
    {
        hasWon = true;
        Time.timeScale = 0.0f;
        victoryCanvas.gameObject.SetActive(true);

    }


}
