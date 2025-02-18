using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static int coins;
        
    public static void SaveCoin()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }

    public static void GetCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }
    public static void Reset()
    {
        coins = 100;
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }
}
