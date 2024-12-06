using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileScript : MonoBehaviour
{
    public static bool isMobile;
    public static bool isGooglePlayOut, isAppStoreOut, isThisGooglePlay, isThisAppStore;

    public GameObject mobileSettingsBTN;

    private void Start()
    {
        isMobile = true;
        isGooglePlayOut = false;
        isAppStoreOut = false;

        isThisAppStore = false;
        isThisGooglePlay = true;

        if (isMobile == true)
        {
            Application.targetFrameRate = 60;
            SetSettingsStuff();
            mobileSettingsBTN.SetActive(true);
        }
        else
        {
            mobileSettingsBTN.SetActive(false);
        }
    }

    public GameObject clicktheButtonWithText, spaceBar, mouseClick, resAndFullscreen, musicAndAudio, saveBtn, exitBtn, xBtn, steamBtn, discordBtn;

    public GameObject checkOutMoreGamesText, appStoreBtn, googlePlayBtn;

    public void SetSettingsStuff()
    {
        if(isThisAppStore == true) { checkOutMoreGamesText.SetActive(true); appStoreBtn.SetActive(true); }
        if(isThisGooglePlay == true) { checkOutMoreGamesText.SetActive(true); googlePlayBtn.SetActive(true); }

        xBtn.transform.localPosition = new Vector2(-887, -351);
        xBtn.transform.localScale = new Vector2(1f, 1f);
        steamBtn.transform.localPosition = new Vector2(-745, -351);
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
        settingsScript.SettingsMechanics();
    }

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


    #region tooltips
    public GameObject achTooltip, achClose, dark, closeCurrentRun, closeSkingTooltip, unlockedAbilityTooltip, closeUnlockedAbility;
    public GameObject currentRunTooltip, skinTooltip;

    public int typeOfTooltip;

    public void OpenAchTooltupMobile()
    {
        if (MobileScript.isMobile == false) { return; }

        achTooltip.transform.localPosition = new Vector2(0, -309);
        achTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        achTooltip.SetActive(true);
        achClose.SetActive(true);
    }

    public void OpenCurrentRunTooltip()
    {
        if (MobileScript.isMobile == false) { return; }

        currentRunTooltip.transform.localPosition = new Vector2(0, -309);
        currentRunTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        currentRunTooltip.SetActive(true);
        closeCurrentRun.SetActive(true);
    }

    public void OpenLockedSkinTooltip()
    {
        if (MobileScript.isMobile == false) { return; }

        skinTooltip.transform.localPosition = new Vector2(0, -309);
        skinTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        skinTooltip.SetActive(true);
        closeSkingTooltip.SetActive(true);
    }

    public void OpenUnlockedAbilityTooltip()
    {
        if (MobileScript.isMobile == false) { return; }

        unlockedAbilityTooltip.transform.localPosition = new Vector2(0, -309);
        unlockedAbilityTooltip.transform.localScale = new Vector2(3.5f, 3.5f);

        dark.SetActive(true);
        unlockedAbilityTooltip.SetActive(true);
        closeUnlockedAbility.SetActive(true);
    }

    public void CloseAchTooltip()
    {
        dark.SetActive(false);

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
        endingTooltip.transform.localPosition = new Vector2(-600, 337);
        endingTooltip.transform.localScale = new Vector2(0.92f, 0.92f);
        endingDark.SetActive(true); endingTooltip.SetActive(true); closeEndingTooltip.SetActive(true);
    }

    public void CloseEndingTooltip()
    {
        endingDark.SetActive(false); endingTooltip.SetActive(false); closeEndingTooltip.SetActive(false);
    }

    #endregion
}
