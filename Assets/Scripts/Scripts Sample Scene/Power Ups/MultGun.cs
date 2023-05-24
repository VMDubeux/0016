using UnityEngine;

public class MultGun : MonoBehaviour
{
    [SerializeField] private float speedPowerUp;
    private shoot armaPlayer;
    private Personagem personagem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLaserEnable playerLaserEnable = other.GetComponent<PlayerLaserEnable>();

            if (playerLaserEnable)
            {
                //if (playerLaserEnable.ActivatePlayerLasers) 
                //{
                    //Continuar codificação.
                //}
            }

            personagem = other.GetComponent<Personagem>();
            armaPlayer = other.GetComponent<shoot>();
            
            if (armaPlayer.PlayerBulletNumber < 5 && personagem.canvasAmmoNumber < 5) //Condição para o algoritmo aumentar o número de Lasers ativos.
            {
                armaPlayer.PlayerBulletNumber++; //Aumenta o número de SpawnBulletsPoints ativos, até o máximo de cinco.
                personagem.canvasAmmoNumber++; //Aumenta o número de Ammo Sprites ativos na UI, até o máximo de cinco.
            }
            Destroy(this.gameObject); //Destrói o PowerUp
        }
    }

}