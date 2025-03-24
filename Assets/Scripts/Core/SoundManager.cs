using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioS;
    
    [SerializeField] AudioClip hurt;
    [SerializeField] AudioClip barrel;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip walk;
    [SerializeField] AudioClip click;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        Save.Getsoundvolume();
        audioS.volume = Save.soundvolume;
    }

    
    void Update()
    {
        Save.Getsoundvolume();
        audioS.volume = Save.soundvolume;
       
    }

    void playsound(AudioClip clip)
    {
        audioS.clip = clip;
        audioS.Play();
    }

    public void Hurt()
    {
        playsound(hurt);
    }
    public void Barrel()
    {
        playsound(barrel);
    }
    public void Coin()
    {
        playsound(coin);
    }
    public void Walk()
    {
        playsound(walk);
    }

    public void Click()
    {
        playsound(click);
    }
}
