using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    [Header("Complementars Audio Explosion GameObjects 2:")]
    public GameObject Explosion;
    public AudioClip AudioClipEnemiesExplosion;

    [Header("Complementar Audio Source GameObject 3:")]
    public AudioSource PlayerIsAudioSource;

    [Header("Complementar Bar GameObject 4:")]
    public Slider hpBossBar;

    //private GameObject[] Enemies;

    private GameObject _player;
    private int _enemiesDestroyed;

    //Private Variables:
    //HP:
    public float vidaBoss;
    public float vidaBossAtual;
    //Points:
    public int pointsForGive;

    void Start()
    {
        vidaBossAtual = vidaBoss;
        hpBossBar.maxValue = vidaBoss;
        hpBossBar.value = vidaBossAtual;

        _player = GameObject.FindGameObjectWithTag("Player"); //teste
        //Enemies = GameObject.FindGameObjectsWithTag("Inimigo");
    }

    void Update()  //Dano do inimigo no player
    {
        DetectEnemiesDeath();
        DefeatMode();
    }

    private void DetectEnemiesDeath()
    {
        _enemiesDestroyed = _player.GetComponent<Personagem>().enemiesDestroyed; //teste

        for (int i = 0; i < _enemiesDestroyed; i++)
        {
            vidaBossAtual--;
            hpBossBar.value = vidaBossAtual;
        }
    }

    private void DefeatMode()
    {
        if (vidaBossAtual <= 1.0f)
        {
            PlayerIsAudioSource.PlayOneShot(AudioClipEnemiesExplosion, 0.35f);
            GameManager.instance.RecordPlus(pointsForGive);
            Destroy(gameObject);
            ExplodeEnemyShip();
        }
    }

    void ExplodeEnemyShip()
    {
        GameObject ExplosionFX = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(ExplosionFX, 0.75f);
    }
}
