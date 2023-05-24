using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Personagem : MonoBehaviour
{
    //Variável Pública para Script:
    public shoot arma;

    //Movement Private Variables:
    private float moveSpeed = 150.0f;
    private Vector3 limitMove;

    [Header("Complementar GameObject 1:")]
    public GameObject escudo;

    //Shield Private Variables:
    private bool _escudoAtivo;
    private float _tempoMaximoEscudo = 5.0f;


    [Header("Complementar GameObject 2:")]
    public Slider hpPlayerBar;

    //HP Internal Variables:
    internal float vidaPlayer = 30.0f;
    internal float vidaPlayerAtual = 30.0f;

    [Header("Complementar GameObject 3:")] //Menu de derrota.
    public Canvas canvas;

    [Header("Complementar GameObject 4:")] //GameObject Canvas contendo as Ammos (1 a 5).
    public GameObject[] CanvasAmmoSpawnPoint;
    public GameObject AmmoPrefab;
    internal float canvasAmmoNumber;

    void Start()
    {
        transform.position = Vector3.zero;
        transform.position = new Vector3(-232.5f, 0, 11);

        vidaPlayerAtual = vidaPlayer;
        hpPlayerBar.maxValue = vidaPlayer;
        hpPlayerBar.value = vidaPlayerAtual;

        canvasAmmoNumber = 1.0f;
    }

    void Update()
    {
        MovimentacaoPlayer();
        LimiteEixoY();
        LimiteEixoX();

        switch (canvasAmmoNumber)
        {
            case 1:
                CanvasAmmoSpawnPoint[0].SetActive(true);
                CanvasAmmoSpawnPoint[1].SetActive(false);
                CanvasAmmoSpawnPoint[2].SetActive(false);
                CanvasAmmoSpawnPoint[3].SetActive(false);
                CanvasAmmoSpawnPoint[4].SetActive(false);
                break;
            case 2:
                CanvasAmmoSpawnPoint[0].SetActive(true);
                CanvasAmmoSpawnPoint[1].SetActive(true);
                CanvasAmmoSpawnPoint[2].SetActive(false);
                CanvasAmmoSpawnPoint[3].SetActive(false);
                CanvasAmmoSpawnPoint[4].SetActive(false);
                break;
            case 3:
                CanvasAmmoSpawnPoint[0].SetActive(true);
                CanvasAmmoSpawnPoint[1].SetActive(true);
                CanvasAmmoSpawnPoint[2].SetActive(true);
                CanvasAmmoSpawnPoint[3].SetActive(false);
                CanvasAmmoSpawnPoint[4].SetActive(false);
                break;
            case 4:
                CanvasAmmoSpawnPoint[0].SetActive(true);
                CanvasAmmoSpawnPoint[1].SetActive(true);
                CanvasAmmoSpawnPoint[2].SetActive(true);
                CanvasAmmoSpawnPoint[3].SetActive(true);
                CanvasAmmoSpawnPoint[4].SetActive(false);
                break;
            case 5:
                CanvasAmmoSpawnPoint[0].SetActive(true);
                CanvasAmmoSpawnPoint[1].SetActive(true);
                CanvasAmmoSpawnPoint[2].SetActive(true);
                CanvasAmmoSpawnPoint[3].SetActive(true);
                CanvasAmmoSpawnPoint[4].SetActive(true);
                break;
        }
    }

    public void MovimentacaoPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
    }

    private void LimiteEixoY()
    {
        switch (transform.position.y)
        {
            case > 130.5f:
                transform.position = new Vector3(transform.position.x, 130.5f, transform.position.z);
                break;
            case < -153:
                transform.position = new Vector3(transform.position.x, -153, transform.position.z);
                break;
        }
    }

    private void LimiteEixoX()
    {
        switch (transform.position.x)
        {
            case > 295:
                transform.position = new Vector3(295, transform.position.y, transform.position.z);
                break;
            case < -300:
                transform.position = new Vector3(-300, transform.position.y, transform.position.z);
                break;
        }
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
        if (other.tag == "TiroEnemy" && _escudoAtivo == false)
        {
            vidaPlayerAtual--;
            hpPlayerBar.value = vidaPlayerAtual;
            GameManager.instance.RecordPlus(-10);

            if (arma.PlayerBulletNumber > 1 && canvasAmmoNumber > 1)
            {
                GetComponent<shoot>().PlayerBulletNumber--;
                canvasAmmoNumber--;
            }
        }

        if (vidaPlayerAtual == 0 || other.tag == "Inimigo")
        {
            Destroy(gameObject);
            Time.timeScale = 0.0f;
            canvas.gameObject.SetActive(true);
        }
    }

    public void PlayerShield()
    {
        CancelInvoke("DesactivePlayerShield");
        _tempoMaximoEscudo = 5;
        escudo.SetActive(true);
        _escudoAtivo = true;
        Invoke("DesactivePlayerShield", _tempoMaximoEscudo);
        escudo.GetComponent<ParticleSystem>().Play();
    }

    public void DesactivePlayerShield()
    {
        escudo.SetActive(false);
        _escudoAtivo = false;
    }
}

