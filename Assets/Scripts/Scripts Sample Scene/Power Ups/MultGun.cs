using UnityEngine;

public class MultGun : MonoBehaviour
{
    [SerializeField] private float speedPowerUp;
    private shoot armaPlayer;

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

            armaPlayer = other.GetComponent<shoot>();
            
            if (armaPlayer.PlayerLasersNumber < 2) //Condição para o algoritmo aumentar o número de Lasers ativos.
            {
                armaPlayer.PlayerLasersNumber++; //Aumenta o número de Lasers ativos, até o máximo de dois.
            }
            Destroy(this.gameObject); //Destrói o PowerUp.
        }
    }

}