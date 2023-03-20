using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm_Player;
    public AudioSource sfx_Player;

    public AudioClip[] audio_clips;


    // ΩÃ±€≈Ê ∆–≈œ
    public static SoundManager instance;

    private void Awake()
    {
        if  (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }

        bgm_Player = GameObject.Find("BGM Player").GetComponent<AudioSource>();
        sfx_Player = GameObject.Find("SFX Player").GetComponent<AudioSource>();
    }

    public void PlaySound(string type)
    {
        int index = 0;

        switch (type)
        {
            case "jellyTouch": index = 0;
                break;
            case "ButtonClick": index = 1;
                break;
            case "UpgradeJelly": index = 2;
                break;
            case "BuyItem": index = 3;
                break;
            case "BuyFail": index = 4;
                break;
            case "Get_Jelatin": index = 5;
                break;
            case "BuyDeco": index = 6;
                break;
        }

        sfx_Player.clip = audio_clips[index];
        sfx_Player.Play();
    }


}
