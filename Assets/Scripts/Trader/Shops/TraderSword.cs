using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraderSword : MonoBehaviour
{
    public bool isPlayerThere = false;
    public GameObject shop;
    public PlayerControler player;

    public TextMeshProUGUI currentLevel1Text;
    public TextMeshProUGUI nextLevel1Text;
    public TextMeshProUGUI currentLevel2Text;
    public TextMeshProUGUI nextLevel2Text;

    public int[] prices1 = { 0, 200, 1000, 5000 };
    public int[] prices2 = { 0, 100, 500, 1000 };
    public int[] results1 = { 3, 5, 7, 10 };
    public int[] results2 = { 3, 5, 10, 20 };
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
            UpgradeRadius();
        }
        else if (buying == 1)
        {
            UpgradeHurt();
        }
    }

    private void UpgradeRadius()
    {
        if (currentLevel1 + 1 < prices1.Length)
        {
            if (player.coins >= prices1[currentLevel1 + 1])
            {
                player.coins -= prices1[currentLevel1 + 1];
                currentLevel1++;
                player.gameObject.transform.GetChild(1).transform.localScale = new Vector3(results1[currentLevel1], results1[currentLevel1], 0);
                Save.radius = results1[currentLevel1];
                Save.Saveradius();
                Save.cur1_trader3 = currentLevel1;
                Save.SaveCur1_trader3();
            }
        }
    }

    private void UpgradeHurt()
    {
        if (currentLevel2 + 1 < prices2.Length)
        {
            if (player.coins >= prices2[currentLevel2 + 1])
            {
                player.coins -= prices2[currentLevel2 + 1];
                currentLevel2++;
                player.gameObject.GetComponent<PlayerControler>().hurt = results2[currentLevel2];
                Save.hurt = results2[currentLevel2];
                Save.Savehurt();
                Save.cur2_trader3 = currentLevel2;
                Save.SaveCur2_trader3();
            }
        }
        UpdatePrices();
    }

    public void UpdatePrices()
    {
        if (currentLevel1Text == null || nextLevel1Text == null || currentLevel2Text == null || nextLevel2Text == null)
        {
            Debug.LogError("One or more UI references are missing in TraderSword!");
            return;
        }

        currentLevel1Text.text = "Current radius: " + results1[currentLevel1];
        if (currentLevel1 + 1 < results1.Length)
        {
            nextLevel1Text.text = "Next radius: " + results1[currentLevel1 + 1] + " - " + prices1[currentLevel1 + 1];
            nextLevel1Text.gameObject.GetComponentInParent<Button>().interactable = player.coins >= prices1[currentLevel1 + 1];
        }
        else
        {
            nextLevel1Text.text = "Max level reached";
            nextLevel1Text.gameObject.GetComponentInParent<Button>().interactable = false;
        }

        currentLevel2Text.text = "Current hurt: " + results2[currentLevel2];
        if (currentLevel2 + 1 < results2.Length)
        {
            nextLevel2Text.text = "Next hurt: " + results2[currentLevel2 + 1] + " - " + prices2[currentLevel2 + 1];
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
        Save.GetCur1_trader3();
        Save.GetCur2_trader3();
        currentLevel1 = Save.cur1_trader3;
        currentLevel2 = Save.cur2_trader3;
    }
}