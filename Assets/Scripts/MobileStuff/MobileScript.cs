using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MobileScript : MonoBehaviour
{
    public static bool isMobile;
    public static bool isGooglePlayOut, isAppStoreOut;

    public GameObject mobileSettingsBTN;

    public AudioManager audioManager;

    private void Awake()
    {
        isMobile = true;
        isGooglePlayOut = false;
        isAppStoreOut = false;
    }

    bool isEdiror;

    private void Start()
    {
#if UNITY_IOS
        checkOutMoreGamesText.SetActive(true); appStoreBtn.SetActive(true);    isEdiror = false;
#elif UNITY_ANDROID
        isEdiror = false;
        checkOutMoreGamesText.SetActive(true); googlePlayBtn.SetActive(true);
#elif UNITY_EDITOR
isEdiror = true;
        checkOutMoreGamesText.SetActive(true); googlePlayBtn.SetActive(true);
#endif
        if (isMobile == true)
        {
            Application.targetFrameRate = 60;
            SetSettingsStuff();
            ChangeMobileText();
            GunPosition();
            mobileSettingsBTN.SetActive(true);
            SettingsOptions.spaceBarSelected = false;
            SettingsOptions.leftClickSeleced = true;

            if(InAppPurchase.is3CpsPlayerpref == 1 || InAppPurchase.is7CpsPlayerpref == 1 || InAppPurchase.is12CpsPlayerpref == 1 || InAppPurchase.is12Cps == true || InAppPurchase.is3Cps == true || InAppPurchase.is7Cps == true)
            {
                autoClick = true;
            }
        }
        else
        {
            mobileSettingsBTN.SetActive(false);
            bottomBtn.SetActive(false);
        }
    }

    public GameObject switchCameraBtn, joystick, invinBtn, chargeBtn;

    public static bool autoClick;
    public Coroutine idleClicks;

    private void Update()
    {
        #region screenshots
        if (isMobile == true && isEdiror == true)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                ScreenCapture.CaptureScreenshot("screenshot-" + DateTime.Now.ToString("yyyy-mm-dd-hh-sss") + ".png", 1);
            }
        }
        #endregion

        #region mobile btns
        if(isMobile == true)
        {
            if (Choises.choseInvincibility == true) { invinBtn.SetActive(true); }
            else { invinBtn.SetActive(false); }

            if (Choises.choseButtonCharge == true) { chargeBtn.SetActive(true); }
            else { chargeBtn.SetActive(false); }

            if (Choises.choseButtonCharge == true || Choises.choseInvincibility == true)
            {
                if (Choises.choseButtonCharge == true && Choises.choseInvincibility == false) { chargeBtn.transform.localPosition = new Vector2(300, -47); }
                else if (Choises.choseButtonCharge == false && Choises.choseInvincibility == true) { invinBtn.transform.localPosition = new Vector2(300, -47); }
                else if (Choises.choseButtonCharge == true && Choises.choseInvincibility == true) { invinBtn.transform.localPosition = new Vector2(300, -47); chargeBtn.transform.localPosition = new Vector2(172, -47); }
            }

            if (Choises.movementAbilityAquaried == true)
            {
                switchCameraBtn.SetActive(true);
            }
            else
            {
                switchCameraBtn.SetActive(false);
                joystick.SetActive(false);
            }

            if (Choises.choseButtonBounceCharge == true)
            {
                switchCameraBtn.transform.localPosition = new Vector2(32, 0);
                joystick.SetActive(false);
            }

            if (Choises.chooseRocket == true || Choises.chooseControllableButton == true)
            {
                joystick.SetActive(true);
                switchCameraBtn.transform.localPosition = new Vector2(350, 0);
            }
        }
        #endregion

        #region IAP auto clicker
        if (InAppPurchase.is3Cps == true || InAppPurchase.is7Cps == true || InAppPurchase.is12Cps == true)
        {
            if(autoClick == true && idleClicks == null)
            {
                idleClicks = StartCoroutine(AutoButtonClick());
                autoClick = false;
            }
        }
        #endregion
    }

    public ButtonClick btnClickScript;

    IEnumerator AutoButtonClick()
    {
        if (InAppPurchase.is12Cps == true || InAppPurchase.is12CpsPlayerpref == 1)
        {
            yield return new WaitForSecondsRealtime(0.083f);
        }
        else if (InAppPurchase.is7Cps == true || InAppPurchase.is7CpsPlayerpref == 1)
        {
            yield return new WaitForSecondsRealtime(0.14f);
        }
        else if (InAppPurchase.is3Cps == true || InAppPurchase.is3CpsPlayerpref == 1)
        {
            yield return new WaitForSecondsRealtime(0.33f);
        }

        if (Choises.isPaused == false && SettingsOptions.isInSettings == false && Choises.isHordeTransition == false && Choises.isBossTransition == false && Choises.isChampionTransition == false && Choises.isInFirstWeaponScreen == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false && Choises.isInMainManu == false)
        {
            SettingsOptions.totalIdleClicks += 1;
            btnClickScript.AllButtonClickMechanics();
        }

        idleClicks = null;
        autoClick = true;
    }

    #region Gun positions
    public GameObject pistolIcon, pistolShootPos, shotgunIcon, shotgunShootPos, mp4Icon, mp4ShootPos, crossbowIcon, crossbowShootPos, boltIcon;
    public void GunPosition()
    {
        float minus = 51.5792f;

        boltIcon.transform.localPosition = new Vector2(71, -46 + minus);
        boltIcon.transform.rotation = Quaternion.Euler(0, 0, -90);

        pistolIcon.transform.rotation = Quaternion.Euler(0, 0, -90);
        shotgunIcon.transform.rotation = Quaternion.Euler(0, 0, -90);
        mp4Icon.transform.rotation = Quaternion.Euler(0, 0, -90);
        crossbowIcon.transform.rotation = Quaternion.Euler(0, 0, -90);

        pistolIcon.transform.localPosition = new Vector2(35, -50 + minus);
        shotgunIcon.transform.localPosition = new Vector2(47, -47 + minus);
        mp4Icon.transform.localPosition = new Vector2(47, -47 + minus);
        crossbowIcon.transform.localPosition = new Vector2(47, -47 + minus);

        pistolShootPos.transform.localPosition = new Vector2(62, -51 + minus);
        shotgunShootPos.transform.localPosition = new Vector2(76, -46 + minus);
        mp4ShootPos.transform.localPosition = new Vector2(77, -47 + minus);
        crossbowShootPos.transform.localPosition = new Vector2(65, -47 + minus);
    }
    #endregion

    #region settings stuff
    public GameObject clicktheButtonWithText, spaceBar, mouseClick, resAndFullscreen, musicAndAudio, saveBtn, exitBtn, xBtn, steamBtn, discordBtn;
    public GameObject checkOutMoreGamesText, appStoreBtn, googlePlayBtn;
    public GameObject settings, pointAreText;

    public void SetSettingsStuff()
    {
#if UNITY_IOS
        checkOutMoreGamesText.SetActive(true); appStoreBtn.SetActive(true);
#elif UNITY_ANDROID
      checkOutMoreGamesText.SetActive(true); googlePlayBtn.SetActive(true); 
#elif UNITY_EDITOR
        checkOutMoreGamesText.SetActive(true); googlePlayBtn.SetActive(true);
#endif

        pointAreText.transform.localScale = new Vector2(2.04f, 2.04f);
        settings.transform.localScale = new Vector2(0.83f, 0.83f);

        xBtn.transform.localPosition = new Vector2(-887, -351);
        xBtn.transform.localScale = new Vector2(1f, 1f);
        steamBtn.transform.localPosition = new Vector2(-733, -351);
        steamBtn.transform.localScale = new Vector2(1f, 1f);
        discordBtn.transform.localPosition = new Vector2(-580, -351);
        discordBtn.transform.localScale = new Vector2(1f, 1f);

        musicAndAudio.transform.localPosition = new Vector2(420, -45);
        musicAndAudio.transform.localScale = new Vector2(1.76f, 1.76f);

        saveBtn.transform.localScale = new Vector2(0.8f, 0.8f);
        exitBtn.transform.localScale = new Vector2(0.8f, 0.8f);

        clicktheButtonWithText.SetActive(false);
        spaceBar.SetActive(false);
        mouseClick.SetActive(false);
        resAndFullscreen.SetActive(false);
    }

    public SettingsOptions settingsScript;
    public void SettingsBTN()
    {
        settingsScript.SettingsMechanics(true);
    }
    #endregion

    #region ChangeMobileText
    public TextMeshProUGUI pistolTextCommon, uziTextCommon, shotgunTextCommon, cannonTextCommon, awpTextCommon, mp4TextCommon, crossbowTextCommon, deagleTextCommon;

    public TextMeshProUGUI pistolTextInCommon, uziTextUnCommon, shotgunTextRare, cannonTextLegendary, awpTextRare, mp4TextLegendary, crossbowTextRare, deagleTextRare;

    public GameObject controlsBtn;

    public TextMeshProUGUI boosterText, rocketText, wasdText;

    public void ChangeMobileText()
    {
        boosterText.text = "A booster button will move around the button. Hold down the button to charge the booster. Release to boost the button in the boosters opposite direction.";

        rocketText.text = "A rocket will spawn on the button. Move the rocket by using the joystick that appears in the bottom left. Hold down the button to boost.";

        wasdText.text = "You can now freely controll the button. Use the joystick that appears in the bottom left to control the button.";

        controlsBtn.SetActive(false);
        pistolTextCommon.text = "";
        uziTextCommon.text = "";
        shotgunTextCommon.text = "";
        cannonTextCommon.text = "";
        awpTextCommon.text = "";
        mp4TextCommon.text = "";
        crossbowTextCommon.text = "";
        pistolTextInCommon.text = "";
        uziTextUnCommon.text = "";
        shotgunTextRare.text = "";
        cannonTextLegendary.text = "";
        awpTextRare.text = "";
        mp4TextLegendary.text = "";
        crossbowTextRare.text = "";
        deagleTextRare.text = "";
        deagleTextCommon.text = "";
    }
    #endregion

    #region links
    public void GooglePlatBTN()
    {
        Application.OpenURL("https://play.google.com/store/apps/developer?id=EagleEye+Games+Norway");
    }

    public void AppStoreBTN()
    {
        Application.OpenURL("https://apps.apple.com/us/developer/simon-eftest%C3%B8l/id1782530055");
    }
    #endregion

    #region Bottom right button click
    public GameObject bottomBtn;
    public bool isPressed;

    public void MobileButtonClick()
    {
        isPressed = true;
    }
    #endregion

    #region tooltips
    public GameObject achTooltip, achClose, dark, closeCurrentRun, closeSkingTooltip, unlockedAbilityTooltip, closeUnlockedAbility;
    public GameObject currentRunTooltip, skinTooltip;

    public int typeOfTooltip;

    public void OpenAchTooltupMobile()
    {
        if (MobileScript.isMobile == false) { return; }
        audioManager.Play("UI_Click2");

        achTooltip.transform.localPosition = new Vector2(0, -309);
        achTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        achTooltip.SetActive(true);
        achClose.SetActive(true);
    }

    public void OpenCurrentRunTooltip()
    {
        if (MobileScript.isMobile == false) { return; }
        audioManager.Play("UI_Click2");
        currentRunTooltip.transform.localPosition = new Vector2(0, -309);
        currentRunTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        currentRunTooltip.SetActive(true);
        closeCurrentRun.SetActive(true);
    }

    public void OpenLockedSkinTooltip()
    {
        if (MobileScript.isMobile == false) { return; }
        audioManager.Play("UI_Click2");
        skinTooltip.transform.localPosition = new Vector2(0, -309);
        skinTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        skinTooltip.SetActive(true);
        closeSkingTooltip.SetActive(true);
    }

    public void OpenUnlockedAbilityTooltip()
    {
        if (MobileScript.isMobile == false) { return; }
        audioManager.Play("UI_Click2");
        unlockedAbilityTooltip.transform.localPosition = new Vector2(0, -309);
        unlockedAbilityTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        unlockedAbilityTooltip.SetActive(true);
        closeUnlockedAbility.SetActive(true);
    }

    public void CloseAchTooltip()
    {
        dark.SetActive(false);
        audioManager.Play("UI_Click2");
        unlockedAbilityTooltip.SetActive(false);
        closeUnlockedAbility.SetActive(false);

        closeCurrentRun.SetActive(false);
        achClose.SetActive(false);
        closeSkingTooltip.SetActive(false);

        achTooltip.SetActive(false);
        currentRunTooltip.SetActive(false);
        skinTooltip.SetActive(false);
    }

    public GameObject endingTooltip, closeEndingTooltip, endingDark;
    public void OpenEndingTooltip()
    {
        audioManager.Play("UI_Click2");
        endingTooltip.transform.localPosition = new Vector2(-600, 337);
        endingTooltip.transform.localScale = new Vector2(0.92f, 0.92f);
        endingDark.SetActive(true); endingTooltip.SetActive(true); closeEndingTooltip.SetActive(true);
    }

    public void CloseEndingTooltip()
    {
        audioManager.Play("UI_Click2");
        endingDark.SetActive(false); endingTooltip.SetActive(false); closeEndingTooltip.SetActive(false);
    }

    #endregion

    #region Open IAP frame
    public GameObject shopFrame, blockRemoveAds, block3Cps, block7Cps, block12Cps;
    public GameObject mobileShopBtn;
    public static bool openShop;

    public void OpenShopFRame()
    {
        if (InAppPurchase.isAdsRemoved == true && InAppPurchase.is12Cps == true) { return; }
        openShop = true;

        if (InAppPurchase.isAdsRemoved == true) { blockRemoveAds.SetActive(true); }
        if (InAppPurchase.is3Cps == true) { block3Cps.SetActive(true); }
        if (InAppPurchase.is7Cps == true) { block7Cps.SetActive(true); block3Cps.SetActive(true); }
        if (InAppPurchase.is12Cps == true) { block12Cps.SetActive(true); block7Cps.SetActive(true); block3Cps.SetActive(true); }

        settingsScript.SettingsMechanics(false);
        shopFrame.SetActive(true);
    }

    public void CloseShopFrame()
    {
        openShop = false;
        settingsScript.SettingsMechanics(true);
        shopFrame.SetActive(false);
    }
    #endregion
}
