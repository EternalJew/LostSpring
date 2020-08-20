using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class InterstitialADS : MonoBehaviour

{
    
    [SerializeField] public InterstitialAd interstitial;
    public void IninInerstitialAd()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitial();
    }

    public void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2618512662549592/6154217991";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }
    ///////////////////////////////////////////////////////////////////
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Time.timeScale = 1F;
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            Time.timeScale = 1F;

        }
    }
    
}
    //private InterstitialAd adInterstitial;

    //private string idApp, idInterstitial;

    //[SerializeField] Button BtnInterstitial;


    //void Start()
    //{
    //    BtnInterstitial.interactable = false;

    //    idApp = "ca-app-pub-3940256099942544~3347511713";
    //    idInterstitial = "ca-app-pub-3940256099942544/1033173712";

    //    MobileAds.Initialize(idApp);

    //    RequestInterstitialAd();
    //}

    //#region Interstitial methods ---------------------------------------------

    //public void RequestInterstitialAd()
    //{
    //    adInterstitial = new InterstitialAd(idInterstitial);
    //    AdRequest request = AdRequestBuild();
    //    adInterstitial.LoadAd(request);

    //    //attach events
    //    adInterstitial.OnAdLoaded += this.HandleOnAdLoaded;
    //    adInterstitial.OnAdOpening += this.HandleOnAdOpening;
    //    adInterstitial.OnAdClosed += this.HandleOnAdClosed;
    //}

    //public void ShowInterstitialAd()
    //{
    //    if (adInterstitial.IsLoaded())
    //        adInterstitial.Show();
    //}

    //public void DestroyInterstitialAd()
    //{
    //    adInterstitial.Destroy();
    //}

    ////interstitial ad events
    //public void HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //    //this method executes when interstitial ad is Loaded and ready to show
    //    BtnInterstitial.interactable = true; //button is ready to click (enabled)
    //}

    //public void HandleOnAdOpening(object sender, EventArgs args)
    //{
    //    //this method executes when interstitial ad is shown
    //    BtnInterstitial.interactable = false; //disable the button
    //}

    //public void HandleOnAdClosed(object sender, EventArgs args)
    //{
    //    //this method executes when interstitial ad is closed
    //    adInterstitial.OnAdLoaded -= this.HandleOnAdLoaded;
    //    adInterstitial.OnAdOpening -= this.HandleOnAdOpening;
    //    adInterstitial.OnAdClosed -= this.HandleOnAdClosed;

    //    RequestInterstitialAd(); //request new interstitial ad after close
    //}

    //#endregion


    ////------------------------------------------------------------------------
    //AdRequest AdRequestBuild()
    //{
    //    return new AdRequest.Builder().Build();
    //}

    //void OnDestroy()
    //{
    //    DestroyInterstitialAd();

    //    //dettach events
    //    adInterstitial.OnAdLoaded -= this.HandleOnAdLoaded;
    //    adInterstitial.OnAdOpening -= this.HandleOnAdOpening;
    //    adInterstitial.OnAdClosed -= this.HandleOnAdClosed;
    //}


