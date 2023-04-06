using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneManagerScript : MonoBehaviour
{
    [SerializeField] private string mainMenuScene;
    [SerializeField] private string gameSceneName;

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene (mainMenuScene);
    }

    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
