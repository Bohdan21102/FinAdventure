using UnityEngine;
public class HP_bar : MonoBehaviour
{
    public RectTransform RTC;
    public float maxHPWidth = 250;
    public int maxHP = 5;
    
    public void UpdateBar(float HP)
    {
        float coificient = (HP / maxHP);
        float HPWidth =  coificient * maxHPWidth;
        RTC.sizeDelta = new Vector2(HPWidth, RTC.sizeDelta.y);
    }
}
