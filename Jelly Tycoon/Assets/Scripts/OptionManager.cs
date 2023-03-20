using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Slider bgmBar;
    public Slider sfxBar;

    public GameObject optionPanel;
    public GameObject sound_OptionPanel;

    private void Start()
    {
        // 저장 된 값이 있다면
        if (PlayerPrefs.HasKey("bgmVolume") && PlayerPrefs.HasKey("sfxVolume"))
        {
            // 데이터 불러오기
            bgmBar.value = PlayerPrefs.GetFloat("bgmVolume");
            sfxBar.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        else
        {
            // 기본값
            bgmBar.value = 0.5f;
            sfxBar.value = 0.5f;
        }
    }

    // 볼륨 조절
    public void Set_BGM_Volum(float volume)
    {
        SoundManager.instance.bgm_Player.volume = volume;
        PlayerPrefs.SetFloat("bgmVolume", volume);
    }

    public void Set_SFX_Volum(float volume)
    {
        SoundManager.instance.sfx_Player.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    // 설정 열기
    public void OpenOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        optionPanel.gameObject.SetActive(true);
    }

    // 설정 닫기
    public void CloseOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        optionPanel.gameObject.SetActive(false);
    }

    // 사운드 설정 열기
    public void OpenSoundOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        sound_OptionPanel.gameObject.SetActive(true);
    }

    // 사운드 설정 닫기
    public void CloseSoundOptionMenu()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        sound_OptionPanel.gameObject.SetActive(false);
    }

    // 게임 종료
    public void Quit()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        Application.Quit();
    }
}
