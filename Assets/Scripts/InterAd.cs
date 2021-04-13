using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAd : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    private const string inteestitialUnitId = "ca-app-pub-8750346892655914/1197339827";
    public int chance;

    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(inteestitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {


        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
            
    }   

    public IEnumerator EndAd()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("AdEnd");
        //interstitialAd.Destroy();

    }

    public void ShowAdDie()
    {
        //chance = Random.Range(0, 3);
        chance = 1;
        if (chance == 1)
        {
            ShowAd();
        }
    }

}
