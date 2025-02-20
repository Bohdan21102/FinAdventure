using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static int coins;
    public static int HP;
        
    public static void SaveCoin()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }

    public static void GetCoins()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }
    public static void SaveHP(int health)
    {
        PlayerPrefs.SetInt("PlayerHP", health);
        PlayerPrefs.Save();
    }

    public static void GetHP()
    {
        HP = PlayerPrefs.GetInt("PlayerHP");
    }
    public static void Reset()
    {
        coins = 100;
        PlayerPrefs.SetInt("Coins", 100);
        PlayerPrefs.SetInt("PlayerHP", 100);
        PlayerPrefs.Save();
    }
}
