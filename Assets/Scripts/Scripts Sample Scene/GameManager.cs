using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal GameObject CurrentScore;
    internal GameObject HighScore;

    private Text CurrentScoreText;
    private Text HighScoreText;

    internal int Current = 0;
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
        HighScore = GameObject.FindGameObjectWithTag("HighScore");

        CurrentScoreText = CurrentScore.GetComponent<Text>();
        HighScoreText = HighScore.GetComponent<Text>();

        CurrentScoreText.text = PlayerPrefs.GetString("CurrentScore");

        Current = System.Convert.ToInt32(PlayerPrefs.GetString("CurrentScore"));
        High = System.Convert.ToInt32(PlayerPrefs.GetString("HighScore"));

        HighScoreText.text = PlayerPrefs.GetString("HighScore");
    }

    public void RecordPlus(int pointsForWin)
    {
        Current += pointsForWin;
        CurrentScoreText.text = $"{Current}";
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (Current > High)
        {
            PlayerPrefs.SetString("HighScore", System.Convert.ToString(Current));
        }
    }
}
