using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrader : MonoBehaviour
{
    public bool isplayerthere = false;
    public GameObject shop;
    public PlayerControler player;

    public TextMeshProUGUI currentlvl1txt;
    public TextMeshProUGUI nextlvl1txt;
    public TextMeshProUGUI currentlvl2txt;
    public TextMeshProUGUI nextlvl2txt;

    public int[] prices1 = { 0, 100, 200, 500 }; 
    public int[] prices2 = { 0, 200, 500, 2000 }; 
    public float[] results1 = { 5, 7, 10, 15 }; 
    public int[] results2 = { 100, 150, 200, 500 }; 

    public int cur1;
    public int cur2;

    void Start()
    {
        Save.GetCur1_trader2();
        Save.GetCur2_trader2();
        cur1 = Save.cur1_trader2;
        cur2 = Save.cur2_trader2;

        player.HP = player.MaxHP;
        updatePrices();
        shop.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isplayerthere)
        {
            shop.gameObject.SetActive(true);
        }
    }

    public void Buy(int Buying)
    {
        if (Buying == 0)
        {
            if (cur1 + 1 < prices1.Length)
            {
                if (player.coins >= prices1[cur1 + 1])
                {
                    player.coins -= prices1[cur1 + 1];
                    cur1++;
                    player.speed = results1[cur1];
                    Save.speed = results1[cur1];
                    Save.Savespeed();
                    Save.cur1_trader2 = cur1;
                    Save.SaveCur1_trader2();
                }

            }
            else if (Buying == 1)
            {
                if (cur2 + 1 < prices2.Length)
                {
                    if (player.coins >= prices2[cur2 + 1])
                    {
                        player.coins -= prices2[cur2 + 1];
                        cur2++;

                        Save.maxHP = results2[cur2];
                        player.HP = results2[cur2];
                        player.MaxHP = results2[cur2];
                        player.Hpbar.maxHP = results2[cur2];

                        Save.SavemaxHP();
                        Save.cur2_trader2 = cur2;
                        Save.SaveCur2_trader2();
                    }

                }

                updatePrices();
            }
        }
    }

    public void updatePrices()
    {
        if (currentlvl1txt == null || nextlvl1txt == null || currentlvl2txt == null || nextlvl2txt == null)
        {
            Debug.LogError("One or more UI references are missing in HealthTrader!");
            return;
        }

        currentlvl1txt.text = "Current speed: " + results1[cur1];
        if (cur1 + 1 < results1.Length)
        {
            nextlvl1txt.text = "Next speed: " + results1[cur1 + 1] + " - " + prices1[cur1 + 1];
            nextlvl1txt.gameObject.GetComponentInParent<Button>().interactable = player.coins >= prices1[cur1 + 1];
        }
        else
        {
            nextlvl1txt.text = "Max level reached";
            nextlvl1txt.gameObject.GetComponentInParent<Button>().interactable = false;
        }

        currentlvl2txt.text = "Current MaxHP: " + results2[cur2];
        if (cur2 + 1 < results2.Length)
        {
            nextlvl2txt.text = "Next MaxHP: " + results2[cur2 + 1] + " - " + prices2[cur2 + 1];
            nextlvl2txt.gameObject.GetComponentInParent<Button>().interactable = player.coins >= prices2[cur2 + 1];
        }
        else
        {
            nextlvl2txt.text = "Max level reached";
            nextlvl2txt.gameObject.GetComponentInParent<Button>().interactable = false;
        }
    }

    public void hideShop()
    {
        shop.gameObject.SetActive(false);
        isplayerthere = false;
    }
}
