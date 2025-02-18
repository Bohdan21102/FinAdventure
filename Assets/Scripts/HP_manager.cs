using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    public TextMeshProUGUI HPtxt;
    public GameObject LastHurtEnemy;
    void Start()
    {
        HPtxt = GameObject.Find("HP_Enemy").GetComponent<TextMeshProUGUI>();
        HPtxt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (LastHurtEnemy!=null)
        {
            HPtxt.gameObject.SetActive(true);
            if (LastHurtEnemy.GetComponent<EnemyControler>() == null)
            {
                HPtxt.text = LastHurtEnemy.GetComponent<Barrel>().health + "";

            }
            else
            {
                HPtxt.text = LastHurtEnemy.GetComponent<EnemyControler>().HP + "";
            }          
        }
        else
        {
            HPtxt.gameObject.SetActive(false);
        }
    }
}
