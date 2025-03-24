using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private void Start()
    {
        Save.Getmusicvolume();
        Save.Getsoundvolume();
        GameObject.Find("MusicVolume").GetComponent<Slider>().value=Save.musicvolume;
        GameObject.Find("SoundVolume").GetComponent<Slider>().value=Save.soundvolume;
    }
    public void Reset()
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        Save.Reset();
        SceneManager.LoadScene(0);
    }
    public void Menu()
    {
        GameObject.FindObjectOfType<SoundManager>().Click();
        SceneManager.LoadScene(0);
    }
    public void ChangeMusicVolume()
    {
        Save.musicvolume=GameObject.Find("MusicVolume").GetComponent<Slider>().value;
        //Debug.Log(Save.musicvolume); 
        Save.Savemusicvolume();
    }

    public void ChangeSoundVolume()
    {
        Save.soundvolume = GameObject.Find("SoundVolume").GetComponent<Slider>().value;
        Save.Savesoundvolume();
    }
}
