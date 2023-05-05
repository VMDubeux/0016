using UnityEngine;
using UnityEngine.UI;
public class Personagem : MonoBehaviour
{


    [SerializeField] private float moveSpeed; //Apliquei Serialize
    [SerializeField] private float vidaPlayer; //Apliquei Serialize
    [SerializeField] private float vidaPlayerAtual;
    public Canvas canvas;
    public Slider hpPlayerBar;
    public shoot arma;
    public bool speedUp; //Criei variável lógica
    public Vector2 limitMove;
    


     void Start()
     {
        vidaPlayerAtual = vidaPlayer;

        hpPlayerBar.maxValue = vidaPlayer;
        hpPlayerBar.value = vidaPlayerAtual;

     }

    void Update()
    {
        MovimentacaoPlayer();
    }

    public void MovimentacaoPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
    }

    public void ganharVida(float VidaParaReceber) //Recebendo vida
    {
        if (vidaPlayerAtual + VidaParaReceber <= vidaPlayer)
        {
            vidaPlayerAtual = VidaParaReceber;
        }
        else
        {
            vidaPlayerAtual = vidaPlayer;
        }

        hpPlayerBar.value = vidaPlayerAtual;
    }

    
    void OnTriggerEnter(Collider other) 
    {
        PlayerTakeDamage(other);
    }

    public void PlayerTakeDamage(Collider other)  //Dano do inimigo no player
    {
        if (other.tag == "TiroEnemy")
        {
            vidaPlayerAtual--;
            hpPlayerBar.value = vidaPlayerAtual;
            GameManager.instance.RecordPlus(-10);
            if (arma.quantidadeArmas != 1)
            {
                arma.quantidadeArmas--;
            }
        }

        if (vidaPlayerAtual == 0 || other.tag == "Inimigo")
        {
            Destroy(gameObject);
            canvas.gameObject.SetActive(true);

        }
    }
}
