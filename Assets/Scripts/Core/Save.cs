using UnityEngine;

public class Save : MonoBehaviour
{
    public static int coins;
    public static int HP;
    public static int hurt;
    public static int radius;
    public static float speed;
    public static int maxHP;
    public static int price;
    public static int coinboost;
    public static bool playedBefore;

    public static int cur1_trader1;  // Trader 1's cur1
    public static int cur2_trader1;  // Trader 1's cur2

    public static int cur1_trader2;  // Trader 2's cur1
    public static int cur2_trader2;  // Trader 2's cur2

    public static int cur1_trader3;  // Trader 3's cur1
    public static int cur2_trader3;  // Trader 3's cur2

    public static float musicvolume;
    public static float soundvolume;

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

    public static void Savehurt()
    {
        PlayerPrefs.SetInt("hurt", hurt);
        PlayerPrefs.Save();
    }

    public static void Gethurt()
    {
        hurt = PlayerPrefs.GetInt("hurt");
    }

    public static void Saveradius()
    {
        PlayerPrefs.SetInt("radius", radius);
        PlayerPrefs.Save();
    }

    public static void Getradius()
    {
        radius = PlayerPrefs.GetInt("radius");
    }

    public static void Savespeed()
    {
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.Save();
    }

    public static void Getspeed()
    {
        speed = PlayerPrefs.GetFloat("speed");
    }

    public static void SavemaxHP()
    {
        PlayerPrefs.SetInt("maxHP", maxHP);
        PlayerPrefs.Save();
    }

    public static void GetmaxHP()
    {
        maxHP = PlayerPrefs.GetInt("maxHP");
    }

    public static void SavePrice()
    {
        PlayerPrefs.SetInt("price", price);
        PlayerPrefs.Save();
    }

    public static void GetPrice()
    {
        price = PlayerPrefs.GetInt("price");
    }

    public static void Savecoinboost()
    {
        PlayerPrefs.SetInt("coinboost", coinboost);
        PlayerPrefs.Save();
    }

    public static void Getcoinboost()
    {
        coinboost = PlayerPrefs.GetInt("coinboost");
    }

    public static int convertboolinint(bool booler)
    {
        return booler ? 1 : 0;
    }

    public static bool convertintinbool(int integer)
    {
        return integer != 0;
    }

    public static void SaveCur1_trader1()
    {
        PlayerPrefs.SetInt("cur1_trader1", cur1_trader1);
        PlayerPrefs.Save();
    }

    public static void SaveCur2_trader1()
    {
        PlayerPrefs.SetInt("cur2_trader1", cur2_trader1);
        PlayerPrefs.Save();
    }

    public static void GetCur1_trader1()
    {
        cur1_trader1 = PlayerPrefs.GetInt("cur1_trader1");
    }

    public static void GetCur2_trader1()
    {
        cur2_trader1 = PlayerPrefs.GetInt("cur2_trader1");
    }

    public static void SaveCur1_trader2()
    {
        PlayerPrefs.SetInt("cur1_trader2", cur1_trader2);
        PlayerPrefs.Save();
    }

    public static void SaveCur2_trader2()
    {
        PlayerPrefs.SetInt("cur2_trader2", cur2_trader2);
        PlayerPrefs.Save();
    }

    public static void GetCur1_trader2()
    {
        cur1_trader2 = PlayerPrefs.GetInt("cur1_trader2");
    }

    public static void GetCur2_trader2()
    {
        cur2_trader2 = PlayerPrefs.GetInt("cur2_trader2");
    }

    public static void SaveCur1_trader3()
    {
        PlayerPrefs.SetInt("cur1_trader3", cur1_trader3);
        PlayerPrefs.Save();
    }

    public static void SaveCur2_trader3()
    {
        PlayerPrefs.SetInt("cur2_trader3", cur2_trader3);
        PlayerPrefs.Save();
    }

    public static void GetCur1_trader3()
    {
        cur1_trader3 = PlayerPrefs.GetInt("cur1_trader3");
    }

    public static void GetCur2_trader3()
    {
        cur2_trader3 = PlayerPrefs.GetInt("cur2_trader3");
    }

    public static void Savemusicvolume()
    {
        PlayerPrefs.SetFloat("Musicvolume", musicvolume);
        PlayerPrefs.Save();
    }

    public static void Getmusicvolume()
    {
        musicvolume = PlayerPrefs.GetFloat("Musicvolume");
    }

    public static void Savesoundvolume()
    {
        PlayerPrefs.SetFloat("Soundvolume", soundvolume);
        PlayerPrefs.Save();
    }

    public static void Getsoundvolume()
    {
        soundvolume = PlayerPrefs.GetFloat("Soundvolume");
    }

    public static void Reset()
    {
        playedBefore = false;
        PlayerPrefs.SetInt("playedBefore", convertboolinint(playedBefore));
        PlayerPrefs.SetInt("Coins", 100);
        PlayerPrefs.SetInt("PlayerHP", 100);
        PlayerPrefs.SetInt("hurt", 3);
        PlayerPrefs.SetInt("radius", 3);
        PlayerPrefs.SetFloat("speed", 5f);
        PlayerPrefs.SetInt("maxHP", 100);
        PlayerPrefs.SetInt("price", 10);

        PlayerPrefs.SetInt("cur1_trader1", 0);
        PlayerPrefs.SetInt("cur2_trader1", 0);
        PlayerPrefs.SetInt("cur1_trader2", 0);
        PlayerPrefs.SetInt("cur2_trader2", 0);
        PlayerPrefs.SetInt("cur1_trader3", 0);
        PlayerPrefs.SetInt("cur2_trader3", 0);

        PlayerPrefs.SetFloat("musicvolume", 1f);
        PlayerPrefs.SetFloat("soundvolume", 1f);

        PlayerPrefs.Save();
    }
}