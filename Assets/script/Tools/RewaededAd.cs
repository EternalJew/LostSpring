using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;

public class RewaededAd : MonoBehaviour
{
    
    private RewardedAd rewardedAd;
    public Text rewardText;
    private int RewardedCount = 0;
    public GameObject panel;
    public GameObject Controller;
    public GameObject player1;
    public GameObject bonuses;
    public void Start()
    {
        this.RequestRewardedAd();
        Time.timeScale = 1;
    }

    public void OnClick()
    {
        if (this.rewardedAd.IsLoaded())
        {
            
            panel.SetActive(false);
            Controller.SetActive(true);
            player1.SetActive(true);
            bonuses.SetActive(true);
            this.rewardedAd.Show();
            Time.timeScale = 1F;

        }
        else            
        {
            panel.SetActive(true);
            Controller.SetActive(false);
            player1.SetActive(false);
            bonuses.SetActive(false);
            this.rewardedAd.Show();
            Time.timeScale = 1F;

            // не показано
        }
    }

    public void RequestRewardedAd()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-2618512662549592/5715427810";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdLoaded event received");
        //Time.timeScale = 0F;
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdClosed event received");
        Time.timeScale = 1F;
    }////////////////////////////////////////////////////
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        //Time.timeScale = 1F;
        transform.position = GetComponent<character>().currentRespawn.transform.position;
    }
}  
