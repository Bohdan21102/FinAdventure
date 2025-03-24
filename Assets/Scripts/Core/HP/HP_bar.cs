using UnityEngine;
public class HP_bar : MonoBehaviour
{
    public RectTransform RTC;
    public float maxHPWidth = 250;
    public int maxHP = 5;

    private void Start()
    {
        

    }
    public void UpdateBar(float HP)
    {
        float coeficient = (HP / maxHP);
        float HPWidth =  coeficient * maxHPWidth;
        RTC.sizeDelta = new Vector2(HPWidth, RTC.sizeDelta.y);
        // resixe bar
    }
}
