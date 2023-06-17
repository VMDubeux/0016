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

    private GameObject fase5;
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

        fase5 = GameObject.FindGameObjectWithTag("Fase5"); //teste
        //Enemies = GameObject.FindGameObjectsWithTag("Inimigo");
    }

    void Update()  //Dano do inimigo no player
    {
        //DetectEnemiesDeath();
        DefeatMode();
    }
    public void PerderVida(int quantidade)
    {
        vidaBossAtual -= quantidade;
        if (vidaBossAtual <= 0)
        {
            // O chefe foi derrotado
            DefeatMode();
        }
    }

    /*private void DetectEnemiesDeath()
    {
        _enemiesDestroyed = fase5.GetComponent<Fase5Manager>().enemiesDestroyed; //teste

        for (int i = 0; i < _enemiesDestroyed; i++)
        {
            vidaBossAtual--;
            hpBossBar.value = vidaBossAtual;
        }
    }*/

    public void DefeatMode()
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
