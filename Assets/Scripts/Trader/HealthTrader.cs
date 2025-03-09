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

    public int[] prices1 = { 0, 100, 200, 500 }; // Speed upgrade prices
    public int[] prices2 = { 0, 200, 500, 2000 }; // MaxHP upgrade prices
    public float[] results1 = { 5, 7, 10, 15 }; // Speed upgrade results
    public int[] results2 = { 100, 150, 200, 500 }; // MaxHP upgrade results

    public int cur1;
    public int cur2;

    void Start()
    {
        // Load current values for cur1 and cur2 from save system
        Save.GetCur1_trader2();
        Save.GetCur2_trader2();
        cur1 = Save.cur1_trader2;
        cur2 = Save.cur2_trader2;

        // Ensure the shop is hidden initially
        

        // Check if player reference is set
        if (player == null)
        {
            Debug.LogError("Player reference is missing in HealthTrader!");
            return;
        }

        // Set initial HP to MaxHP
        player.HP = player.MaxHP;
        updatePrices();
        shop.gameObject.SetActive(false);
    }

    void Update()
    {
        // Show the shop if the player is nearby
        if (isplayerthere)
        {
            shop.gameObject.SetActive(true);
        }
    }

    public void Buy(int Buying)
    {
        if (player == null)
        {
            Debug.LogError("Player reference is missing in HealthTrader!");
            return;
        }

        // Buying speed upgrade (cur1)
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
                else
                {
                    Debug.Log("Not enough coins for speed upgrade.");
                }
            }
            else
            {
                Debug.Log("Max speed level reached.");
            }
        }
        // Buying MaxHP upgrade (cur2)
        else if (Buying == 1)
        {
            if (cur2 + 1 < prices2.Length)
            {
                if (player.coins >= prices2[cur2 + 1])
                {
                    player.coins -= prices2[cur2 + 1];
                    cur2++;

                    // Update HP and MaxHP for the player
                    Save.maxHP = results2[cur2];
                    player.HP = results2[cur2];
                    player.MaxHP = results2[cur2];
                    player.tHp.maxHP = results2[cur2]; // Assuming tHp is a health component

                    Save.SavemaxHP();
                    Save.cur2_trader2 = cur2;
                    Save.SaveCur2_trader2(); // Fixed typo here
                }
                else
                {
                    Debug.Log("Not enough coins for MaxHP upgrade.");
                }
            }
            else
            {
                Debug.Log("Max MaxHP level reached.");
            }
        }

        // Update UI after the purchase
        updatePrices();
    }

    public void updatePrices()
    {
        if (currentlvl1txt == null || nextlvl1txt == null || currentlvl2txt == null || nextlvl2txt == null)
        {
            Debug.LogError("One or more UI references are missing in HealthTrader!");
            return;
        }

        // Update current and next speed value
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

        // Update current and next MaxHP value
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
