using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserEnable : MonoBehaviour
{
    GameObject PlayerLaserSpawnPointTop;
    GameObject PlayerLaserSpawnPointBottom;

    private void Start()
    {
        PlayerLaserSpawnPointTop = transform.Find("Ponta da arma laser especial 4").gameObject;
        PlayerLaserSpawnPointBottom = transform.Find("Ponta da arma laser especial 5").gameObject;
    }

    public void ActivatePlayerLasers()
    {
        PlayerLaserSpawnPointTop.SetActive(true);
        PlayerLaserSpawnPointBottom.SetActive(true);
    }

    bool PlayerTopLaserActive()
    {
        return PlayerLaserSpawnPointTop.activeSelf;
    }

    bool PlayerBottomLaserActive()
    {
        return PlayerLaserSpawnPointBottom.activeSelf;
    }

    public void InactivatePlayerLasers()
    {
        PlayerLaserSpawnPointTop.SetActive(false);
        PlayerLaserSpawnPointBottom.SetActive(false);
    }
}




/*public GameObject PlayerLaserSpawnPointTop;
public GameObject PlayerLaserSpawnPointBottom;
private MultGun _multGun;
public bool PlayerLasersAreEnabled;

void Start()
{
    InactivePlayerLasers();
}

private void Update()
{
    if (_multGun.GetComponent<MultGun>().LaserPlayerAreEnabled == true)
    {
        PlayerLasersAreEnabled = true;
        if (PlayerLasersAreEnabled == true) ActivePlayerLasers();
    }
}

private void ActivePlayerLasers()
{
    PlayerLaserSpawnPointTop.SetActive(true);
    PlayerLaserSpawnPointBottom.SetActive(true);
}

private void InactivePlayerLasers()
{
    PlayerLaserSpawnPointTop.SetActive(false);
    PlayerLaserSpawnPointBottom.SetActive(false);
}*/

