using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [Header("Normal Guns: Bullets")]
    public Transform[] PlayerBulletSpawnPoint;
    public GameObject PlayerNormalBulletPrefab;
    internal float PlayerBulletNumber;
    public AudioSource PlayerIsAudioSource;
    public AudioClip PlayerAudioShoot;
    public float PlayerBulletSpeed;
    public float PlayerFireRateKeyX = 0.15f;
    private float _playerNextShoot = 0.0f;

    private AudioManager audioManager;
    /* 
     public Transform[] PlayerLasersSpawnPoint;
     public GameObject PlayerLasersPrefab;
     public float PlayerLasersNumber = 2.0f;
     public AudioSource PlayerIsAudioSourceLaser;
     public AudioClip PlayerAudioShootLaser;
     public float PlayerLaserSpeed;
     public float PlayerLaserFireRateKeyX = 0.15f;
     private float _playerNextLaser = 0.0f;*/

    private void Awake()
    {

    }

    private void Start()
    {
        PlayerBulletNumber = 1.0f;
       // audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    void Update()
    {
        StartCoroutine(PlayerShootingInputWithKeyZ());
        Atirar();
    }

    public void Atirar()
    {
        if (Input.GetKey(KeyCode.X) && Time.time > _playerNextShoot && !Input.GetKeyDown(KeyCode.Z))
        {
            _playerNextShoot = Time.time + PlayerFireRateKeyX;
            var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[0].position, PlayerBulletSpawnPoint[0].rotation);
            _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[0].right * PlayerBulletSpeed;
            audioManager.PlaySFX("Shoot");
        }

        /*if (Input.GetKey(KeyCode.C) && Time.time > _playerNextLaser)
        {
            _playerNextLaser = Time.time + PlayerLaserFireRateKeyX;
            PlayerIsAudioSourceLaser.PlayOneShot(PlayerAudioShootLaser);
            for (int j = 0; j < PlayerLasersNumber; j++)
            {
                var _playerLasers = Instantiate(PlayerLasersPrefab, PlayerLasersSpawnPoint[j].position, PlayerLasersSpawnPoint[j].rotation);
                _playerLasers.GetComponent<Rigidbody>().velocity = PlayerLasersSpawnPoint[j].right * PlayerLaserSpeed;
            }
        }*/

    }

    IEnumerator PlayerShootingInputWithKeyZ()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.X))
        {
            //audioManager.PlaySFX("Shoot");

            yield return new WaitForSecondsRealtime(0.2f);


            for (int i = 0; i < PlayerBulletNumber; i++)
            {

                var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[i].position, PlayerBulletSpawnPoint[i].rotation);
                _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[i].right * PlayerBulletSpeed;
            }
        }
    }

}