using UnityEngine;
public class HP_bar : MonoBehaviour
{
    public RectTransform RTC;
    public float maxHPWidth = 250;
    public int maxHP = 5;

    private void Start()
    {
        RTC = gameObject.GetComponent<RectTransform>();
        RTC.localPosition = new Vector3(-715, 472, 0);
        RTC.localScale = new Vector3(1.5f, 1.5f, 1.5f); 

    }
    public void UpdateBar(float HP)
    {
        float coeficient = (HP / maxHP);
        float HPWidth =  coeficient * maxHPWidth;
        RTC.sizeDelta = new Vector2(HPWidth, RTC.sizeDelta.y);
        // resixe bar
    }
}
