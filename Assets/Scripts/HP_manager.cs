using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_manager : MonoBehaviour
{
    public HP_bar HPbar;
    public GameObject LastHurtEnemy;
    void Start()
    {
        HPbar = GameObject.Find("Enemy_HP_bar").GetComponent<HP_bar>();

        if (HPbar != null) HPbar.gameObject.SetActive(false);
    }

    void Update()
    {
        if(HPbar != null)
        {
            if (LastHurtEnemy != null)
            {
                HPbar.gameObject.SetActive(true);
                if (LastHurtEnemy.GetComponent<EnemyControler>() == null)
                {
                    HPbar.maxHP = LastHurtEnemy.GetComponent<Barrel>().MaxHP;
                    HPbar.UpdateBar(LastHurtEnemy.GetComponent<Barrel>().health);

                }
                else
                {
                    HPbar.maxHP = LastHurtEnemy.GetComponent<EnemyControler>().MaxHP;
                    HPbar.UpdateBar(LastHurtEnemy.GetComponent<EnemyControler>().HP);
                }
            }
            else
            {
                HPbar.gameObject.SetActive(false);
            }
        }
    }
}
