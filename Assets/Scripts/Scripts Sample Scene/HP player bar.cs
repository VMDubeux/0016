using UnityEngine;
using UnityEngine.UI;

public class HPplayerbar : MonoBehaviour
{
   [SerializeField] private Image hpPlayerBar;

    public void SwitchHpBar(int ActualHP,int MaxHP)
    {
        hpPlayerBar.fillAmount = (float) ActualHP / MaxHP;
    }
}
