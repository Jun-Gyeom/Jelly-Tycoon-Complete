using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobReward : MonoBehaviour
{
    // 광고 단위 ID
    private string adUnitId;

    private RewardedAd rewardedAd;

    public GameManager gm;

    // 리워드 수령 창
    public GameObject rewardPanel; 

    void Start()
    {
        adUnitId = "ca-app-pub-3940256099942544/5224354917";

        rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    //실행
    public void Show() 
    {
        StartCoroutine(ShowRewardAd());
    }

    //광고 보여주기
    IEnumerator ShowRewardAd()
    {
        while (!rewardedAd.IsLoaded())
        {
            yield return null;
        }
        rewardedAd.Show();
    }

    //광고 다시 로드하기
    public void ReloadAd()
    {
        adUnitId = "ca-app-pub-3940256099942544/5224354917";


        rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }

    //광고가 끝나는 시점
    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        ReloadAd();
    }

    //광고가 끝나고 보상을 받는 시점
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        SoundManager.instance.PlaySound("BuyDeco");
        rewardPanel.SetActive(true);
    }

    // 보상 받기 버튼 (실수령)
    public void GetReward()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        rewardPanel.SetActive(false);
        gm.jelatin += 50f; // 50 젤라틴 지급
    }


}
