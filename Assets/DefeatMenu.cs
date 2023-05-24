using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatMenu : MonoBehaviour
{
    [Header("Main GameObject:")]
    public GameObject LoseCanvasMenu;

    [Header("Complementar GameObject:")]
    public GameObject Player;

    private void Update()
    {
        if (Player.GetComponent<Personagem>().vidaPlayer <= 0.0f)
        {
            if (LoseCanvasMenu.activeSelf)
            {
                LoseCanvasMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                LoseCanvasMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}