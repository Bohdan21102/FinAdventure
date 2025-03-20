using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinTrader : MonoBehaviour
{
    public bool isPlayerThere = false;
    public GameObject shop;
    public PlayerControler player;

    public TextMeshProUGUI currentLevel1Text;
    public TextMeshProUGUI nextLevel1Text;
    public TextMeshProUGUI currentLevel2Text;
    public TextMeshProUGUI nextLevel2Text;

    public int[] prices1 = { 0, 500, 1000, 2000 };
    public int[] prices2 = { 0, 500, 1000, 2000 };
    public int[] results1 = { 10, 11, 12, 15 };
    public int[] results2 = { 0, 1, 2, 5 };
    public int currentLevel1;
    public int currentLevel2;

    void Start()
    {
        LoadTraderData();
        UpdatePrices();
        shop.SetActive(false);
    }

    void Update()
    {
        if (isPlayerThere)
        {
            shop.SetActive(true);
        }
    }

    public void Buy(int buying)
    {
        if (buying == 0)
        {
            UpgradeValue();
        }
        else if (buying == 1)
        {
            UpgradeCoinBoost();
        }
    }

    private void UpgradeValue()
    {
        if (currentLevel1 + 1 < prices1.Length)
        {
            if (player.coins >= prices1[currentLevel1 + 1])
            {
                player.coins -= prices1[currentLevel1 + 1];
                currentLevel1++;
                Save.price = results1[currentLevel1];
                Save.SavePrice();
                Save.cur1_trader1 = currentLevel1;
                Save.SaveCur1_trader1();
            }
        }
    }

    private void UpgradeCoinBoost()
    {
        if (currentLevel2 + 1 < prices2.Length)
        {
            if (player.coins >= prices2[currentLevel2 + 1])
            {
                player.coins -= prices2[currentLevel2 + 1];
                currentLevel2++;
                Save.coinboost = results2[currentLevel2];
                Save.Savecoinboost();
                Save.cur2_trader1 = currentLevel2;
                Save.SaveCur2_trader1();
            }
        }
        UpdatePrices();
    }

    public void UpdatePrices()
    {
        currentLevel1Text.text = "Current value: " + results1[currentLevel1];

        if (currentLevel1 + 1 < results1.Length)
            nextLevel1Text.text = "Next value: " + results1[currentLevel1 + 1] + " - " + prices1[currentLevel1 + 1];
        else
            nextLevel1Text.text = "Max level reached";

        currentLevel1Text.gameObject.GetComponentInParent<Button>().interactable = currentLevel1 + 1 < prices1.Length && player.coins >= prices1[currentLevel1 + 1];

        currentLevel2Text.text = "Current coin boost: " + results2[currentLevel2];

        if (currentLevel2 + 1 < results2.Length)
            nextLevel2Text.text = "Next coin boost: " + results2[currentLevel2 + 1] + " - " + prices2[currentLevel2 + 1];
        else
            nextLevel2Text.text = "Max level reached";

        currentLevel2Text.gameObject.GetComponentInParent<Button>().interactable = currentLevel2 + 1 < prices2.Length && player.coins >= prices2[currentLevel2 + 1];
    }

    public void HideShop()
    {
        shop.SetActive(false);
        isPlayerThere = false;
    }

    private void LoadTraderData()
    {
        Save.GetCur1_trader1();
        Save.GetCur2_trader1();
        currentLevel1 = Save.cur1_trader1;
        currentLevel2 = Save.cur2_trader1;
    }
}