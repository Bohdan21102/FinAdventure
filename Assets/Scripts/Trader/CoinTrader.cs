using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinTrader : MonoBehaviour
{

    public bool isplayerthere = false;
    public GameObject shop;
    public PlayerControler player;
    //1 is names for price
    //2 is names for amount from enemy (+plus)
    public TextMeshProUGUI currentlvl1txt;
    public TextMeshProUGUI nextlvl1txt;
    public TextMeshProUGUI currentlvl2txt;
    public TextMeshProUGUI nextlvl2txt;
    public int[] prices1 = { 0, 500, 1000, 2000 };
    //index 0 is default
    public int[] prices2 = { 0, 500, 1000, 2000 };
    public int[] results1 = { 10, 11, 12, 15 };
    public int[] results2 = { 0, 1, 2, 5 };
    public int cur1;
    public int cur2;

    void Start()
    {
        Save.GetCur1_trader1();
        Save.GetCur2_trader1();
        cur1 = Save.cur1_trader1;
        cur2 = Save.cur2_trader1;
        
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
                    Save.price = results1[cur1];
                    Save.SavePrice();
                    Save.cur1_trader1 = cur1;
                    Save.SaveCur1_trader1();
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

                        Save.coinboost = results2[cur2];

                        Save.Savecoinboost();
                        Save.cur2_trader1 = cur2;
                        Save.SaveCur2_trader1();
                    }
                }

                updatePrices();
            }
        }
    }

    public void updatePrices()
    {
        currentlvl1txt.text = "Current value: " + results1[cur1];

        if (cur1 + 1 < results1.Length)
            nextlvl1txt.text = "Next value: " + results1[cur1 + 1] + " - " + prices1[cur1 + 1];
        else
            nextlvl1txt.text = "Max level reached";

        if (cur1 + 1 < prices1.Length && player.coins >= prices1[cur1 + 1])
            currentlvl1txt.gameObject.GetComponentInParent<Button>().interactable = true;
        else
            currentlvl1txt.gameObject.GetComponentInParent<Button>().interactable = false;

        currentlvl2txt.text = "Current coin boost: " + results2[cur2];

        if (cur2 + 1 < results2.Length)
            nextlvl2txt.text = "Next coin boost: " + results2[cur2 + 1] + " - " + prices2[cur2 + 1];
        else
            nextlvl2txt.text = "Max level reached";

        if (cur2 + 1 < prices2.Length && player.coins >= prices2[cur2 + 1])
            currentlvl2txt.gameObject.GetComponentInParent<Button>().interactable = true;
        else
            currentlvl2txt.gameObject.GetComponentInParent<Button>().interactable = false;
    }

    public void hideShop()
    {
        shop.gameObject.SetActive(false);
        isplayerthere = false;
    }
}
