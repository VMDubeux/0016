using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int pontuacao;
    public Text textoPontuacaoAtual;
    

    void Start()
    {
        textoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacao;
    }
    void Awake()
    {
        instance = this; 
    }

    public void RecordPlus(int pointsForWin)
    {
        pontuacao += pointsForWin;
        textoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacao;
    }
}
