using UnityEngine;

public class MultGun : MonoBehaviour
{
    //private float speedPowerUp;
    private shoot armaPlayer;
    private Personagem personagem;



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

            armaPlayer = other.GetComponent<shoot>();


            Destroy(this.gameObject); //Destrói o PowerUp
        }
    }

}