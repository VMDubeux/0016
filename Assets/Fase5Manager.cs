using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase5Manager : MonoBehaviour
{
    [Header("Escreva o nome da cena menu:")]
    [SerializeField] private string _Menu;

    [Header("Escreva o nome da cena atual:")]
    [SerializeField] private string _CurrentGameScene;

    [Header("Escreva o nome da próxima cena:")]
    [SerializeField] private string _NextGameScene;

    [Header("GameObject Complementar 1:")]
    public Transform PauseMenu;

    [Header("GameObject Complementar 2:")]
    public Transform LoseMenu;

    [Header("GameObject Complementar 3:")]
    public Transform WinMenu;

    [Header("Player:")]
    private GameObject Player;

    [Header("Enemy:")]
    private GameObject Enemy;

    void Start()
    {
        Time.timeScale = 1.0f;
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = GameObject.FindGameObjectWithTag("Boss");
    }

    private void Update()
    {
        if (Player == null)
        {
            LoseMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (Enemy.GetComponent<BossLifeBar>().vidaBoss <= 0)
        {
            WinMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(_CurrentGameScene);
        Time.timeScale = 1.0f;
    }

    public void NextGameScene()
    {
        SceneManager.LoadScene(_NextGameScene);
        Time.timeScale = 1.0f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(_Menu);
        Time.timeScale = 1.0f;
    }

    public void ResumeGame()
    {
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
