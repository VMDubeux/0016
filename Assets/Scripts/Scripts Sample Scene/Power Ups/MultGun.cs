using UnityEngine;

public class MultGun : MonoBehaviour
{
    //private float speedPowerUp;
    private shoot armaPlayer;
    private Personagem personagem;
    private AudioManager audioManager;


    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //PlayerLaserEnable playerLaserEnable = other.GetComponent<PlayerLaserEnable>();

            //if (playerLaserEnable)
            {
                //if (playerLaserEnable.ActivatePlayerLasers) 
                //{
                //Continuar codificação.
                //}
            }

            shoot powerUp = other.GetComponent<shoot>();
            personagem = other.GetComponent<Personagem>();

            if (powerUp.PlayerBulletNumber < 5)
            {
                powerUp.PlayerBulletNumber++;
                personagem.UpdateAmmoIcons();
            }
            audioManager.PlaySFX("PickPowerUp", 0.05f);
            armaPlayer = other.GetComponent<shoot>();


            Destroy(this.gameObject); //Destrói o PowerUp
        }
    }

}