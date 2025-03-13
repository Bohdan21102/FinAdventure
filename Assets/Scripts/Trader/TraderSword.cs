using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TraderSword : MonoBehaviour
{
    public bool isplayerthere = false;
    public GameObject shop;
    public PlayerControler player;
    //1 is names for radius
    //2 is names for hurt
    public TextMeshProUGUI currentlvl1txt;
    public TextMeshProUGUI nextlvl1txt;
    public TextMeshProUGUI currentlvl2txt;
    public TextMeshProUGUI nextlvl2txt;
    public int[] prices1={0,200,1000,5000};
    //index 0 is default
    public int[] prices2={0,100,500,1000};
    public int[] results1 = {3,5,7,10};
    public int[] results2 = {3,5, 10, 20 };
    public int cur1;
    public int cur2;
    
    void Start()
    {
        Save.GetCur1_trader3();
        Save.GetCur2_trader3();
        cur1 = Save.cur1_trader3;
        cur2 = Save.cur2_trader3;
        
        updatePrices();
        shop.gameObject.SetActive(false);

    }
    void Update()
    {
        if(isplayerthere)
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
                    player.gameObject.transform.GetChild(1).transform.localScale = new Vector3(results1[cur1], results1[cur1], 0);
                    Save.radius = results1[cur1];
                    Save.Saveradius();
                    Save.cur1_trader3 = cur1;
                    Save.SaveCur1_trader3();
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
                        Save.hurt = results2[cur2];
                        Save.Savehurt();
                        Save.cur2_trader3 = cur2;
                        Save.SaveCur2_trader3();
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

        currentlvl1txt.text = "Current radius: " + results1[cur1];
        if (cur1 + 1 < results1.Length)
        {
            nextlvl1txt.text = "Next radius: " + results1[cur1 + 1] + " - " + prices1[cur1 + 1];
            nextlvl1txt.gameObject.GetComponentInParent<Button>().interactable = player.coins >= prices1[cur1 + 1];
        }
        else
        {
            nextlvl1txt.text = "Max level reached";
            nextlvl1txt.gameObject.GetComponentInParent<Button>().interactable = false;
        }

        currentlvl2txt.text = "Current hurt: " + results2[cur2];
        if (cur2 + 1 < results2.Length)
        {
            nextlvl2txt.text = "Next hurt: " + results2[cur2 + 1] + " - " + prices2[cur2 + 1];
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
