using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MobAdReward : MonoBehaviour

{
    private RewardedAd rewardedAd;
    private int coints = 0;

    private const string rewardedUnitId = "ca-app-pub-8750346892655914/1197339827";

    private void OnEnable()
    {
        rewardedAd = new RewardedAd(rewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);

        //rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    public void ShowRewardAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
    

   // public void HandleUserEarnedReward()
    //{
        //coints++;
    //}

}