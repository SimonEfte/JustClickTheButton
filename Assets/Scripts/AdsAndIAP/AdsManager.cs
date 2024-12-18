using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public InitializaAds initializeAds;
    public InterstitialAds interstitialAds;

    public static AdsManager Instance { get; private set; }

    private void Start()
    {
        if (MobileScript.isMobile == true)
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            interstitialAds.LoadInterstitialAd();
        }
    }
}
