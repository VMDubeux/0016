using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    public Canvas victoryCanvas;
    public KeyCode victoryKey = KeyCode.F2;
    public KeyCode moremorepoints = KeyCode.F5;

    private bool hasWon = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(victoryKey) && !hasWon)
        {
            ActivateVictory();
        }

        if (Input.GetKeyDown(moremorepoints))
        {
            GameManager.instance.RecordPlus(100);
        }

    }

    void ActivateVictory()
    {
        hasWon = true;
        Time.timeScale = 0.0f;
        victoryCanvas.gameObject.SetActive(true);

    }


}
