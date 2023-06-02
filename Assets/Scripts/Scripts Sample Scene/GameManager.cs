using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int pontuacao;
    public Text textoPontuacaoAtual;
    public Text HighScoreText;


    void Awake()
    {
        instance = this; 
    }

    void Start()
    {
        textoPontuacaoAtual.text = $"PONTUA��O: {pontuacao}";

        //DontDestroyOnLoad(this.gameObject);
    }

    public void RecordPlus(int pointsForWin)
    {
        pontuacao += pointsForWin;
        textoPontuacaoAtual.text = $"PONTUA��O: {pontuacao}";
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (pontuacao > PlayerPrefs.GetInt("MELHOR PONTUA��O", 0))
        {
            PlayerPrefs.SetInt("MELHOR PONTUA��O", pontuacao);
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        HighScoreText.text = $"MELHOR PONTUA��O: {PlayerPrefs.GetInt("MELHOR PONTUA��O", 0)}";
    }
}