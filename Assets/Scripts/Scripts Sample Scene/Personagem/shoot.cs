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
    private readonly float PlayerFireRateKeyX = 0.75f;
    private readonly float PlayerFireRateKeyZ = 0.25f;
    private float _playerNextShoot = 0.0f;

    private AudioManager audioManager;

    public GameObject[] ammoIcons;


    public KeyCode allGuns = KeyCode.F5;

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
        Atirar();

        if (Input.GetKeyDown(allGuns))
        {

            PlayerBulletNumber++;
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

    public void Atirar()
    {
        if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Mouse1)) && (Time.time > _playerNextShoot) && !Input.GetKeyDown(KeyCode.Z) && Time.timeScale == 1.0f)
        {
            _playerNextShoot = Time.time + PlayerFireRateKeyX;
            audioManager.PlaySFX("Shoot", 0.65f);

            for (int i = 0; i < PlayerBulletNumber; i++)
            {
                var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[i].position, PlayerBulletSpawnPoint[i].rotation);
                _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[i].right * PlayerBulletSpeed;
            }
        }
        else if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Mouse0)) && !Input.GetKey(KeyCode.X) && Time.timeScale == 1.0f)
        {
            _playerNextShoot = Time.time + PlayerFireRateKeyZ;
            audioManager.PlaySFX("Shoot", 0.65f);

            for (int i = 0; i < PlayerBulletNumber; i++)
            {
                var _playerBullet = Instantiate(PlayerNormalBulletPrefab, PlayerBulletSpawnPoint[i].position, PlayerBulletSpawnPoint[i].rotation);
                _playerBullet.GetComponent<Rigidbody>().velocity = PlayerBulletSpawnPoint[i].right * PlayerBulletSpeed;
            }
        }
    }
}
