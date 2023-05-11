using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneManagerScript : MonoBehaviour
{
    [SerializeField] private string mainMenuScene;
    [SerializeField] private string gameSceneName;
    //[SerializeField] private string _writeTheNextGameSceneName; //Escrever o nome da pr�xima cena no inspector.

    public Transform PauseMenu; //Inserir, no inspector, o GameObject "CanvasPause".

    public void RestartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene (mainMenuScene);
    }

    /*public void NextGameScene() //M�todo acrescentado. Ap�s vencida a fase, pressionar o bot�o "avan�ar".
    {
        SceneManager.LoadScene(_writeTheNextGameSceneName);
    }*/

    public void ResumeGame() //M�todo acrescentado. Para quando o jogo estiver pausado, pressionar o bot�o "continuar".
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
