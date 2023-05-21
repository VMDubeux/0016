using UnityEngine;

public class MultGun : MonoBehaviour
{
    [SerializeField] private float speedPowerUp;
    public shoot armaPlayer;

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
            
            if (armaPlayer.PlayerBulletNumber < 5) //Condição para o algoritmo aumentar o número de Lasers ativos.
            {
                armaPlayer.PlayerBulletNumber++; //Aumenta o número de Lasers ativos, até o máximo de dois.
                Debug.Log(armaPlayer);
            }
            Destroy(this.gameObject); //Destrói o PowerUp
        }
    }

}