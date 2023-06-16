using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Personagem : MonoBehaviour
{
    //Variável Pública para Script:
    public shoot arma;

    //Movement Private Variables:
    private readonly float moveSpeed = 150.0f;

    [Header("Complementar GameObject 1:")]
    public GameObject escudo;

    //Shield Private Variables:
    private bool _escudoAtivo;
    private float _tempoMaximoEscudo = 5.0f;


    [Header("Complementar GameObject 2:")]
    public Slider hpPlayerBar;

    //HP Internal Variables:
    public int vidaPlayer;
    public int vidaPlayerAtual;

    [Header("Complementar GameObject 3:")] //Menu de derrota.
    public Canvas canvas;

    public GameObject[] ammoIcons;

    public GameObject Score;





    void Start()
    {
        PlayerPrefs.SetString("CurrentScore", "0");

        transform.position = Vector3.zero;
        transform.position = new Vector3(-232.5f, 0, 11);

        vidaPlayerAtual = vidaPlayer;
        hpPlayerBar.maxValue = vidaPlayer;
        hpPlayerBar.value = vidaPlayerAtual;
    }

    void Update()
    {
        MovimentacaoPlayer();
        LimiteEixoY();
        LimiteEixoX();
        DefeatMode();
    }

    public void MovimentacaoPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 direction = new Vector3(horizontal, vertical, 0f).normalized;
        Vector3 movement = moveSpeed * Time.deltaTime * direction;

        transform.position += movement;

        //transform.position += moveSpeed * Time.deltaTime * new Vector3(horizontal, vertical, 0).normalized;
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
            case < -289:
                transform.position = new Vector3(-289, transform.position.y, transform.position.z);
                break;
        }
    }

    public void GanharVida(int VidaParaReceber) //Recebendo vida
    {
        if (vidaPlayerAtual + VidaParaReceber <= vidaPlayer)
        {
            vidaPlayerAtual += VidaParaReceber;
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
        if (other.CompareTag("TiroEnemy") && _escudoAtivo == false)
        {
            vidaPlayerAtual--;
            hpPlayerBar.value = vidaPlayerAtual;
            GameManager.instance.RecordPlus(-10);
            shoot tiro = gameObject.GetComponent<shoot>();
            if (tiro.PlayerBulletNumber > 1)
            {
                tiro.PlayerBulletNumber--;
                UpdateAmmoIcons();
            }
        }

        if (other.CompareTag("Inimigo") && _escudoAtivo == true)
        {
            Destroy(other.gameObject);

        }
        else if (other.CompareTag("Inimigo") && _escudoAtivo == false)
        {
            vidaPlayerAtual /= 2;
            hpPlayerBar.value = vidaPlayerAtual;
            Destroy(other.gameObject);
            GameManager.instance.RecordPlus(-100);
        }
        else if (other.CompareTag("Boss") && _escudoAtivo == false)
        {
            vidaPlayerAtual /= 2;
            hpPlayerBar.value = vidaPlayerAtual;
            GameManager.instance.RecordPlus(-100);
        }
    }

    private void DefeatMode()
    {
        if (vidaPlayerAtual < 1)
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

    public void UpdateAmmoIcons()
    {
        shoot tiro = gameObject.GetComponent<shoot>();
        for (int i = 0; i < 5; i++)
        {
            ammoIcons[i].SetActive(false);
        }

        for (int i = 0; i < tiro.PlayerBulletNumber; i++)
        {
            ammoIcons[i].SetActive(true);
        }
    }


}