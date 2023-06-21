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
    public float _tempoMaximoEscudo;


    [Header("Complementar GameObject 2:")]
    public Slider hpPlayerBar;

    //HP Internal Variables:
    public int vidaPlayer;
    public int vidaPlayerAtual;

    private Animator playerAnimator;

    [Header("Complementar GameObject 3:")] //Menu de derrota.
    public Canvas canvas;

    public GameObject[] ammoIcons;

    public GameObject Score;

    public KeyCode infinityShield = KeyCode.F3;
    public KeyCode allguns = KeyCode.F4;





    void Start()
    {
        PlayerPrefs.SetString("CurrentScore", "0");

        transform.position = Vector3.zero;
        transform.position = new Vector3(-232.5f, 0, 11);

        vidaPlayerAtual = vidaPlayer;
        hpPlayerBar.maxValue = vidaPlayer;
        hpPlayerBar.value = vidaPlayerAtual;

        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        LimiteEixoY();
        LimiteEixoX();
        DefeatMode();
        MovimentacaoPlayer();

        if (Input.GetKeyDown(infinityShield))
        {
            CancelInvoke("DesactivePlayerShield");
            _tempoMaximoEscudo = 90;
            escudo.SetActive(true);
            _escudoAtivo = true;
            Invoke("DesactivePlayerShield", _tempoMaximoEscudo);
            escudo.GetComponent<ParticleSystem>().Play();
        }

    }

    public void MovimentacaoPlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        if (vertical == 0) 
        {
            playerAnimator.SetBool("idle", true);
            playerAnimator.SetBool("up", false);
            playerAnimator.SetBool("down", false);
        }
        else if (vertical > 0)
        {
            playerAnimator.SetBool("idle", false);
            playerAnimator.SetBool("up", true);
            playerAnimator.SetBool("down", false);
        }
        else if (vertical < 0)
        {
            playerAnimator.SetBool("idle", false);
            playerAnimator.SetBool("up", false);
            playerAnimator.SetBool("down", true);
        }

        Vector3 direction = new(horizontal, vertical, 0f);
        Vector3 movement = moveSpeed * Time.deltaTime * direction.normalized;

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