using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthTrader : MonoBehaviour
{
    public bool isPlayerThere = false;
    public GameObject shop;
    public PlayerControler player;

    public TextMeshProUGUI currentLevel1Text;
    public TextMeshProUGUI nextLevel1Text;
    public TextMeshProUGUI currentLevel2Text;
    public TextMeshProUGUI nextLevel2Text;

    public int[] prices1 = { 0, 100, 200, 500 };
    public int[] prices2 = { 0, 200, 500, 2000 };
    public float[] results1 = { 5, 7, 10, 15 };
    public int[] results2 = { 100, 150, 200, 500 };

    public int currentLevel1;
    public int currentLevel2;

    void Start()
    {
        LoadTraderData();
        player.HP = player.MaxHP;
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
        GameObject.FindObjectOfType<SoundManager>().Click();
        if (buying == 0)
        {
            UpgradeSpeed();
        }
        else if (buying == 1)
        {
            UpgradeMaxHP();
        }
    }

    private void UpgradeSpeed()
    {
        if (currentLevel1 + 1 < prices1.Length)
        {
            if (player.coins >= prices1[currentLevel1 + 1])
            {
                player.coins -= prices1[currentLevel1 + 1];
                currentLevel1++;
                player.speed = results1[currentLevel1];
                Save.speed = results1[currentLevel1];
                Save.Savespeed();
                Save.cur1_trader2 = currentLevel1;
                Save.SaveCur1_trader2();
            }
        }
    }

    private void UpgradeMaxHP()
    {
        if (currentLevel2 + 1 < prices2.Length)
        {
            if (player.coins >= prices2[currentLevel2 + 1])
            {
                player.coins -= prices2[currentLevel2 + 1];
                currentLevel2++;
                Save.maxHP = results2[currentLevel2];
                player.HP = results2[currentLevel2];
                player.MaxHP = results2[currentLevel2];
                player.Hpbar.maxHP = results2[currentLevel2];

                Save.SavemaxHP();
                Save.cur2_trader2 = currentLevel2;
                Save.SaveCur2_trader2();
            }
        }
        UpdatePrices();
    }

    public void UpdatePrices()
    {
        if (currentLevel1Text == null || nextLevel1Text == null || currentLevel2Text == null || nextLevel2Text == null)
        {
            Debug.LogError("One or more UI references are missing in HealthTrader!");
            return;
        }

        currentLevel1Text.text = "Current speed: " + results1[currentLevel1];
        if (currentLevel1 + 1 < results1.Length)
        {
            nextLevel1Text.text = "Next speed: " + results1[currentLevel1 + 1] + " - " + prices1[currentLevel1 + 1];
            nextLevel1Text.gameObject.GetComponentInParent<Button>().interactable = player.coins >= prices1[currentLevel1 + 1];
        }
        else
        {
            nextLevel1Text.text = "Max level reached";
            nextLevel1Text.gameObject.GetComponentInParent<Button>().interactable = false;
        }

        currentLevel2Text.text = "Current MaxHP: " + results2[currentLevel2];
        if (currentLevel2 + 1 < results2.Length)
        {
            nextLevel2Text.text = "Next MaxHP: " + results2[currentLevel2 + 1] + " - " + prices2[currentLevel2 + 1];
            nextLevel2Text.gameObject.GetComponentInParent<Button>().interactable = player.coins >= prices2[currentLevel2 + 1];
        }
        else
        {
            nextLevel2Text.text = "Max level reached";
            nextLevel2Text.gameObject.GetComponentInParent<Button>().interactable = false;
        }
    }

    public void HideShop()
    {
        shop.SetActive(false);
        isPlayerThere = false;
    }

    private void LoadTraderData()
    {
        Save.GetCur1_trader2();
        Save.GetCur2_trader2();
        currentLevel1 = Save.cur1_trader2;
        currentLevel2 = Save.cur2_trader2;
    }
}