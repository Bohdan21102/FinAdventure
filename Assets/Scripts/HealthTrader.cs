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
    //1 is names for speed
    //2 is names for hp
    public TextMeshProUGUI currentlvl1txt;
    public TextMeshProUGUI nextlvl1txt;
    public TextMeshProUGUI currentlvl2txt;
    public TextMeshProUGUI nextlvl2txt;
    public int[] prices1 = { 0, 100, 200, 500 };
    //index 0 is default
    public int[] prices2 = { 0, 200, 500, 2000 };
    public float[] results1 = { 5, 7, 10, 15 };
    public int[] results2 = { 100, 150, 200, 500 };
    public int cur1;
    public int cur2;

    void Start()
    {
        player.GetComponent<PlayerControler>().HP= player.GetComponent<PlayerControler>().MaxHP;
        shop.gameObject.SetActive(false);
    }

    // Update is called once per frame
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
                    player.gameObject.GetComponent<PlayerControler>().speed = results1[cur1];
                    Save.speed = results1[cur1];
                    Save.Savespeed();
                }
                else
                {
                    //Debug.Log("Недостатньо монет для покупки наступної швидкості");
                }
            }
            else
            {
                //Debug.Log("Досягнуто максимальної швидкості");
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
                    player.gameObject.GetComponent<PlayerControler>().hurt = results2[cur2];
                    Save.maxHP = results2[cur2];
                    player.GetComponent<PlayerControler>().HP = results2[cur2];
                    player.GetComponent<PlayerControler>().MaxHP = results2[cur2];
                    Save.SavemaxHP();
                }
                else
                {
                    //Debug.Log("Недостатньо монет для більшого хп");
                }
            }
            else
            {
                //Debug.Log("Досягнуто максимального хп");
            }
        }

        updatePrices();
    }

    public void updatePrices()
    {
        currentlvl1txt.text = "Current speed: " + results1[cur1];
        currentlvl2txt.text = "Current MaxHP: " + results2[cur2];

        if (cur1 + 1 < results1.Length)
            nextlvl1txt.text = "Next speed: " + results1[cur1 + 1] + " - " + prices1[cur1 + 1];
        else
            nextlvl1txt.text = "Max level reached";
            currentlvl1txt.gameObject.GetComponentInParent<Button>().interactable = false;

        if (cur2 + 1 < results2.Length)
            nextlvl2txt.text = "Next MaxHP: " + results2[cur2 + 1] + " - " + prices2[cur2 + 1];
        else
            nextlvl2txt.text = "Max level reached";
            currentlvl2txt.gameObject.GetComponentInParent<Button>().interactable = false;

    }
    public void hideShop()
    {
        shop.gameObject.SetActive(false);
        isplayerthere = false;
    }
}
