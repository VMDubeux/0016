using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal GameObject CurrentScore;
    internal GameObject DefinitiveScore;
    internal GameObject HighScore;

    internal Text CurrentScoreText;
    internal Text DefinitiveScoreText;
    private Text HighScoreText;

    internal int Current = 0;
    internal int Definitive = 0;
    internal int High = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else Destroy(gameObject);
    }

    void Start()
    {
        CurrentScore = GameObject.FindGameObjectWithTag("Score");
        DefinitiveScore = GameObject.FindGameObjectWithTag("Definitive");
        HighScore = GameObject.FindGameObjectWithTag("HighScore");

        CurrentScoreText = CurrentScore.GetComponent<Text>();
        DefinitiveScoreText = DefinitiveScore.GetComponent<Text>();
        HighScoreText = HighScore.GetComponent<Text>();

        CurrentScoreText.text = PlayerPrefs.GetString("CurrentScore");
        //DefinitiveScoreText.text = PlayerPrefs.GetString("DefinitiveScore"); //Desnecess�rio

        Current = System.Convert.ToInt32(PlayerPrefs.GetString("CurrentScore"));
        //Definitive = System.Convert.ToInt32(PlayerPrefs.GetString("DefinitiveScore")); //Desnecess�rio
        High = System.Convert.ToInt32(PlayerPrefs.GetString("HighScore"));

        HighScoreText.text = PlayerPrefs.GetString("HighScore");
        //CurrentScoreText.text = $"{Current}"; //Desnecess�rio
    }

    void Update()
    {
        CurrentScoreText.text = $"{Current}"; //Necess�rio para atualizar ao mudar de fase!
        CheckHighScore();
    }

    public void RecordPlus(int pointsForWin)
    {
        Current += pointsForWin;
        //CurrentScoreText.text = $"{Current}"; //Desnecess�rio
        DefinitiveScoreText.text = $"{Definitive}";
    }

    void CheckHighScore()
    {
        if (Current > High)
        {
            PlayerPrefs.SetString("HighScore", System.Convert.ToString(Current));
        }
    }
}
