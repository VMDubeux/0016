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
    private GameObject _boss;

    //Internal Variable (Enemies destroy):
    internal int enemiesDestroyed = 0;

    //Private Variable:
    private GameManager _gameManager;

    void Start()
    {
        Time.timeScale = 1.0f;
        Player = GameObject.FindGameObjectWithTag("Player");
        _boss = GameObject.FindGameObjectWithTag("Boss");
    }

    private void Update()
    {
        if (Player == null)
        {
            LoseMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (_boss == null || _boss.GetComponent<BossLifeBar>().vidaBoss <= 0)
        {
            GameManager.instance.CheckHighScore();
            WinMenu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void RestartGame()
    {
        GameManager.instance.Current = GameManager.instance.Definitive;
        SceneManager.LoadScene(_CurrentGameScene);
        Time.timeScale = 1.0f;
    }

    public void NextGameScene()
    {
        GameManager.instance.Definitive = GameManager.instance.Current;
        SceneManager.LoadScene(_NextGameScene);
        Time.timeScale = 1.0f;
    }

    public void ReturnToMainMenu()
    {
        GameManager.instance.Current = 0;
        GameManager.instance.Definitive = 0;
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
