using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string gameScene;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    public void Play()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void OpenOptions() 
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ReturnFromOptions()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
