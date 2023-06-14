using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneManagerScript : MonoBehaviour
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

    private void Start()
    {
        Time.timeScale = 1.0f;
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
