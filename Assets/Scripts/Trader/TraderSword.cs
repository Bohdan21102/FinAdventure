using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        shop.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if(isplayerthere)
        { 
            shop.gameObject.SetActive(true);
        }
    }
    public void Buy(int Buying)
    {
        //0-radius
        //1-hurt
        if(Buying == 0)
        {
            if (player.coins >= prices1[cur1++])
            {
                cur1++;
                player.coins -= prices1[cur1];                
                player.gameObject.transform.GetChild(1).transform.localScale=new Vector3(results2[cur2], results2[cur2], 0);
                updatePrices();
            }

        }
        else if (Buying == 1)
        {
            if (player.coins >= prices2[cur2++])
            {
                cur2++;
                player.coins -= prices2[cur1];
                player.gameObject.transform.GetChild(1).transform.localScale = new Vector3(results2[cur2], results2[cur2], 0);
                updatePrices();
            }
        }
    }
    public void updatePrices()
    {
        currentlvl1txt.text = "Current radius:" + results1[cur1];
        currentlvl2txt.text = "Current hurt:"   + results2[cur2];
        nextlvl1txt.text = "Radius:" + results1[cur1++] + "-" + prices1[cur1++];
        nextlvl2txt.text = "Hurt:"   + results2[cur2++] + "-" + prices2[cur2++];
    }
}
