using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    public HP_bar HPtxt;
    public GameObject LastHurtEnemy;
    void Start()
    {
        HPtxt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (LastHurtEnemy!=null)
        {
            HPtxt.gameObject.SetActive(true);
            if (LastHurtEnemy.GetComponent<EnemyControler>() == null)
            {
                HPtxt.maxHP = LastHurtEnemy.GetComponent<Barrel>().MaxHP;
                HPtxt.UpdateBar(LastHurtEnemy.GetComponent<Barrel>().health);

            }
            else
            {
                HPtxt.maxHP = LastHurtEnemy.GetComponent<EnemyControler>().MaxHP;
                HPtxt.UpdateBar(LastHurtEnemy.GetComponent<EnemyControler>().HP);
            }          
        }
        else
        {
            HPtxt.gameObject.SetActive(false);
        }
    }
}
