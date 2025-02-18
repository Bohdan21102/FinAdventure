using UnityEngine;
using TMPro;

public class HP_bar : MonoBehaviour
{
    public RectTransform RTC;
    public int maxHPWidth = 250;
    public int maxHP = 5;

    public TextMeshProUGUI HPtext;
    
    
    public void UpdateBar(int HP)
    {
        float HPWidth = HP * maxHPWidth / maxHP;
        RTC.sizeDelta = new Vector2(HPWidth, RTC.sizeDelta.y);

        HPtext.text = HP + "/" + maxHP;
    }
}
