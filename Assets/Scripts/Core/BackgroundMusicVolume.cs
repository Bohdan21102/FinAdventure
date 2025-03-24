using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicVolume : MonoBehaviour
{
    private AudioSource audioS;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
       // Debug.Log(Save.musicvolume);
    }

    // Update is called once per frame
    void Update()
    {
        Save.Getmusicvolume();
        audioS.volume=Save.musicvolume;
        //Debug.Log(Save.musicvolume);
    }
}
