using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public static int coins;
    public static int HP;
    public static int hurt;
    public static int radius;
    public static float speed;
    public static int maxHP;
        
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
    public static void Reset()
    {
        
        PlayerPrefs.SetInt("Coins", 100);
        PlayerPrefs.SetInt("PlayerHP", 100);
        PlayerPrefs.SetInt("hurt", 3);
        PlayerPrefs.SetInt("radius", 3);
        PlayerPrefs.SetFloat("speed", 5f);
        PlayerPrefs.SetInt("maxHP", 100);
        PlayerPrefs.Save();
    }
}
