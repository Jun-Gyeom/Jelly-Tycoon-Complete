using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobBanner : MonoBehaviour
{
    // 광고 단위 ID
    private string adUnitId = "ca-app-pub-3940256099942544/6300978111";

    private BannerView bannerView;

    // 안드로이드 SDK를 초기화하는 메소드
    void Start()
    {
        MobileAds.Initialize(initStatus =>{   });

        CreateBannerView();
    }

    // 광고 인스턴스를 생성하는 메소드
    private void CreateBannerView()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        AdSize adaptiveSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        bannerView.LoadAd(request);
    }

    // 광고를 표시하는 메소드
    public void LoadAd()
    {
        if (bannerView == null)
        {
            CreateBannerView();
        }

        var adRequest = new AdRequest.Builder()
            .AddKeyword("unity-admob-sample")
            .Build();

        bannerView.LoadAd(adRequest);
    }
}
