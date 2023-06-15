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

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }

    private void Start()
    {
        PlayerBulletNumber = 1.0f;

    }

    void Update()
    {
        StartCoroutine(PlayerShootingInputWithKeyZ());
        Atirar();
    }

    public void Atirar()
    {
        if (Input.GetKey(KeyCode.X) && Time.time > _playerNextShoot && !Input.GetKeyDown(KeyCode.Z) && Time.timeScale == 1.0f)
        {
            _playerNextShoot = Time.time + PlayerFireRateKeyX;
            var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[0].position, PlayerBulletSpawnPoint[0].rotation);
            _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[0].right * PlayerBulletSpeed;
            audioManager.PlaySFX("Shoot", 0.65f);
        }
    }

    IEnumerator PlayerShootingInputWithKeyZ()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.X) && Time.timeScale == 1.0f)
        {
            audioManager.PlaySFX("Shoot", 0.65f);

            yield return new WaitForSecondsRealtime(0.2f);


            for (int i = 0; i < PlayerBulletNumber; i++)
            {

                var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[i].position, PlayerBulletSpawnPoint[i].rotation);
                _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[i].right * PlayerBulletSpeed;
            }
        }
    }
}