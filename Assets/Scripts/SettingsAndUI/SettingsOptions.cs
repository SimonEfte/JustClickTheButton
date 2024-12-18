using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsOptions : MonoBehaviour, IDataPersistence
{
    public static bool firstTimeOpenedGame;
    public static bool spaceBarSelected, leftClickSeleced;
    public GameObject firstPlayPopUp, firstPlayFrame;
    public GameObject spaceBarButton, spaceBarButtonSettings, leftClickButton, leftClickButtonSettings;

    public GameObject mobileShopBtn;

    public GameObject checkMarkSpacebar, checkMArkLeftClick, crossSpacebar, crossLeftClick, buttonLeftClickBlock;
    public GameObject checkMarkSpacebarSettings, checkMArkLeftClickSettings, crossSpacebarSettings, crossLeftClickSettings;

    public GameObject settingsPopUp, mobileShopFrame;
    public GameObject settingFrame, achFrame, skinsFrame, statsFrame, infoFrame;

    public GameObject selectedSettingGlow, settingText, achText, skinsText, statsText, infoText, controlsText, endingsText, currentRunText;

    public TextMeshProUGUI topText;

    public TMP_Dropdown resolutionDropdown;

    private List<Resolution> resolutions = new List<Resolution>();
    public Camera mainCamera;

    public int saveHeight, saveWidth;
    public int saveFullsScreen;
    public bool triggerResolution;
    public GameObject mainMenu, firstTimePlayingScreen;
    public static bool pressedOkFirstTImePlaying, isPlayerPlayingARun;
    public Button continueRunBTN, mainMenuResetBTN;
    public GameObject mainXPBar;
    public static bool isInSettings;

    public TextMeshProUGUI timerTextSettings, timerTextTopRight, totalPlayTimeStat;

    public AudioManager audioManager;

    #region All Sats Variables
    public static int currentTime = 0;
    public static int timeMinutes = 0;
    public static int totalTimeSeconds, totalTimeMinutes;

    public static int totalButtonClicks, totalCritClicks, totalIdleClicks;
    public static float totalPoints, totalClickPoints, totalCritPoints, totalEnemyPoints, totalPointDropPoints;
    public static int totalEnemiesDefeated, totalSmallEnemiesDefeated, totalSpeedstersDefeated, totalSharpshootersDefeated, totalSnipersDefeated, totalHeavyshotDefeated, totalBrutedDefeated, totalRagingGunnerDefeated, totalTitansDefeated;
    public static int totalLevels, furthestRunLevel, totalTimePlayedHours, totalTimePlayedMinutes;
    public static int endingsCompleted, runsCompleted, timesDefeatedBoss, timesDefeatedHorde, timesDefeatedChampions, timesDefeatedDangerButton;
    public static int ritualsEntered, weirdEggUpgrades, totalAbilitiesChosen, totalCommonAbilitiesChosen, totalUncommonAbilititesChosen, totalRareAbilitiesChose, totalLegendaryAbilitiesChosen, totalMythicAbilitiesChosen, timesRerolled;

    public static bool firstTimeDefeatedBoss, firstTimeDefeatedHorde, firstTimeDefeatedChampions, firstTimeDefeatedDangerButton;

    public static int longestRunMinutes, longestRunSeconds, fastestRunMinutes, fastestRunSeconds;

    public static bool firstRunCompleted;

    public static bool gameLoaded;

    public static int totalArrowsHit;

    #endregion

    public GameObject aimCursor;
    public Coroutine timerCoroutine;

    private void UpdateTimerText()
    {
        //In top left
        if (currentTime == 60) { timeMinutes += 1; currentTime = 0; }

        if (currentTime < 10 && timeMinutes == 0) { timerTextTopRight.text = $"00:0{currentTime.ToString("F0")}"; }
        if (currentTime > 9 && timeMinutes == 0) { timerTextTopRight.text = $"00:{currentTime.ToString("F0")}"; }

        if (currentTime < 10 && timeMinutes > 0 && timeMinutes < 10) { timerTextTopRight.text = $"0{timeMinutes.ToString("F0")}:0{currentTime.ToString("F0")}"; }
        if (currentTime > 9 && timeMinutes > 0 && timeMinutes < 10) { timerTextTopRight.text = $"0{timeMinutes.ToString("F0")}:{currentTime.ToString("F0")}"; }

        if (currentTime < 10 && timeMinutes > 9) { timerTextTopRight.text = $"{timeMinutes.ToString("F0")}:0{currentTime.ToString("F0")}"; }
        if (currentTime > 9 && timeMinutes > 9) { timerTextTopRight.text = $"{timeMinutes.ToString("F0")}:{currentTime.ToString("F0")}"; }

        //In Settings
        if (currentTime == 60) { timeMinutes += 1; currentTime = 0; }

        if (currentTime < 10 && timeMinutes == 0) { timerTextSettings.text = $"00:0{currentTime.ToString("F0")}"; }
        if (currentTime > 9 && timeMinutes == 0) { timerTextSettings.text = $"00:{currentTime.ToString("F0")}"; }

        if (currentTime < 10 && timeMinutes > 0 && timeMinutes < 10) { timerTextSettings.text = $"0{timeMinutes.ToString("F0")}:0{currentTime.ToString("F0")}"; }
        if (currentTime > 9 && timeMinutes > 0 && timeMinutes < 10) { timerTextSettings.text = $"0{timeMinutes.ToString("F0")}:{currentTime.ToString("F0")}"; }

        if (currentTime < 10 && timeMinutes > 9) { timerTextSettings.text = $"{timeMinutes.ToString("F0")}:0{currentTime.ToString("F0")}"; }
        if (currentTime > 9 && timeMinutes > 9) { timerTextSettings.text = $"{timeMinutes.ToString("F0")}:{currentTime.ToString("F0")}"; }


        //Total
        if (totalTimeSeconds == 60) { totalTimeMinutes += 1; totalTimeSeconds = 0; }

        if (totalTimeSeconds < 10 && totalTimeMinutes == 0) { totalPlayTimeStat.text = $"00:0{totalTimeSeconds.ToString("F0")}"; }
        if (totalTimeSeconds > 9 && totalTimeMinutes == 0) { totalPlayTimeStat.text = $"00:{totalTimeSeconds.ToString("F0")}"; }

        if (totalTimeSeconds < 10 && totalTimeMinutes > 0 && totalTimeMinutes < 10) { totalPlayTimeStat.text = $"0{totalTimeMinutes.ToString("F0")}:0{totalTimeSeconds.ToString("F0")}"; }
        if (totalTimeSeconds > 9 && totalTimeMinutes > 0 && totalTimeMinutes < 10) { totalPlayTimeStat.text = $"0{totalTimeMinutes.ToString("F0")}:{totalTimeSeconds.ToString("F0")}"; }

        if (totalTimeSeconds < 10 && totalTimeMinutes > 9) { totalPlayTimeStat.text = $"{totalTimeMinutes.ToString("F0")}:0{totalTimeSeconds.ToString("F0")}"; }
        if (totalTimeSeconds > 9 && totalTimeMinutes > 9) { totalPlayTimeStat.text = $"{totalTimeMinutes.ToString("F0")}:{totalTimeSeconds.ToString("F0")}"; }

        if (timeMinutes >= longestRunMinutes)
        {
            longestRunMinutes = timeMinutes;
        }

        if (currentTime >= longestRunSeconds)
        {
            longestRunSeconds = currentTime;
            if (currentTime == 59 && longestRunSeconds == 59)
            {
                longestRunSeconds = 59;
            }
        }

        if (currentTime != 59 && longestRunSeconds == 59)
        {
            longestRunSeconds = 0;
        }
    }

    IEnumerator UpdateTimerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            if (isInSettings == false && Choises.isInMainManu == false && Choises.isInDeathScreen == false && Choises.isInWinScreen == false)
            {
                currentTime += 1;
                totalTimeSeconds += 1;
                UpdateTimerText();
            }
        }
    }

    public void Awake()
    {
        gameLoaded = false;
        spaceBarSelected = false;
        leftClickSeleced = false;

        triggerResolution = true;

        if (!PlayerPrefs.HasKey("saveIndex"))
        {
            FindResolutionIndex();
        }
        else
        {
            resolutionIndexSave = PlayerPrefs.GetInt("saveIndex");
        }


        if (!PlayerPrefs.HasKey("ScreenWidth"))
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            saveFullsScreen = PlayerPrefs.GetInt("SaveFullScreen");
            saveWidth = PlayerPrefs.GetInt("ScreenWidth");
            saveHeight = PlayerPrefs.GetInt("ScreenHeight");

            if (saveFullsScreen == 1)
            {
                fullScreenToggleOn.SetActive(false);
                fullSreenToggleOff.SetActive(true);
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
            }
            else
            {
                fullScreenToggleOn.SetActive(true);
                fullSreenToggleOff.SetActive(false);
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }

            Screen.SetResolution(saveWidth, saveHeight, Screen.fullScreenMode);

        }

        StartCoroutine(wait());
    }

    public void FindResolutionIndex()
    {
        if (Screen.width == 600 && Screen.height == 800) { resolutionIndexSave = 0; }
        if (Screen.width == 1024 && Screen.height == 768) { resolutionIndexSave = 1; }
        if (Screen.width == 1280 && Screen.height == 720) { resolutionIndexSave = 2; }
        if (Screen.width == 1280 && Screen.height == 800) { resolutionIndexSave = 3; }
        if (Screen.width == 1280 && Screen.height == 1024) { resolutionIndexSave = 4; }
        if (Screen.width == 1366 && Screen.height == 768) { resolutionIndexSave = 5; }
        if (Screen.width == 1600 && Screen.height == 900) { resolutionIndexSave = 6; }
        if (Screen.width == 1920 && Screen.height == 1080) { resolutionIndexSave = 7; }
        if (Screen.width == 1920 && Screen.height == 1200) { resolutionIndexSave = 8; }
        if (Screen.width == 2560 && Screen.height == 1440) { resolutionIndexSave = 9;  }
        if (Screen.width == 2560 && Screen.height == 1600) { resolutionIndexSave = 10; }
        if (Screen.width == 2560 && Screen.height == 1080) { resolutionIndexSave = 11; }
        if (Screen.width == 3440 && Screen.height == 1440) { resolutionIndexSave = 12; }
        if (Screen.width == 3840 && Screen.height == 1440) { resolutionIndexSave = 13; }
        if (Screen.width == 3840 && Screen.height == 2160) { resolutionIndexSave = 14; }
        if (Screen.width == 3840 && Screen.height == 2400) { resolutionIndexSave = 15; }
    }

    public Coroutine waitForSongCoroutine;

    public bool resetStats;
    public static bool music1Playing, music2Playing, music3Playing, music4Playing, music5Playing, music6Playing, music7Playing;

    public void PlayRandomSong(int songNumber)
    {
        if(music1Playing == false && music2Playing == false && music3Playing == false && music4Playing == false && music5Playing == false && music6Playing == false && music7Playing == false)
        {
            int randomSong;

            do
            {
                randomSong = Random.Range(1, 8); // Generates a number between 1 and 8
            } while (randomSong == songNumber);

            if (randomSong == 1) { audioManager.Play("Music1"); music1Playing = true;  }
            if (randomSong == 2) { audioManager.Play("Music2"); music2Playing = true; }
            if (randomSong == 3) { audioManager.Play("Music3"); music3Playing = true; }
            if (randomSong == 4) { audioManager.Play("Music4"); music4Playing = true; }
            if (randomSong == 5) { audioManager.Play("Music5"); music5Playing = true; }
            if (randomSong == 6) { audioManager.Play("Music6"); music6Playing = true; }
            if (randomSong == 7) { audioManager.Play("Music7"); music7Playing = true; }

            //Debug.Log(musicLength);
            //waitForSongCoroutine = StartCoroutine(CheckSongPlaying(randomSong));
        }
    }

    public static float musicLength;

    IEnumerator CheckSongPlaying(int songNumber)
    {
        float startTime = Time.realtimeSinceStartup;
        float elapsedTime = 0f;

        while (elapsedTime < musicLength)
        {
            elapsedTime = Time.realtimeSinceStartup - startTime;

            Debug.Log("Time Remaining: " + (musicLength - elapsedTime).ToString("F2") + " seconds");

            yield return null; // Yielding null makes it wait for the next frame
        }

        //Debug.Log("Song Ended");

        music1Playing = false; music2Playing = false; music3Playing = false; music4Playing = false;
        music5Playing = false; music6Playing = false; music7Playing = false;

        if (Choises.bossMusicPlaying == false && Choises.hordMusicPlaying == false && Choises.championsMusicPlaying == false && Choises.dangerButtonMusicPlaying == false)
        {

            int randomSong;

            do
            {
                randomSong = Random.Range(1, 8); // Generates a number between 1 and 5
            } while (randomSong == songNumber);

            if (randomSong == 1) { audioManager.Play("Music1"); music1Playing = true; }
            if (randomSong == 2) { audioManager.Play("Music2"); music2Playing = true; }
            if (randomSong == 3) { audioManager.Play("Music3"); music3Playing = true; }
            if (randomSong == 4) { audioManager.Play("Music4"); music4Playing = true; }
            if (randomSong == 5) { audioManager.Play("Music5"); music5Playing = true; }
            if (randomSong == 6) { audioManager.Play("Music6"); music6Playing = true; }
            if (randomSong == 7) { audioManager.Play("Music7"); music7Playing = true; }

            PlayNewsong(randomSong);
            waitForSongCoroutine = null;
        }
    }

    public void PlayNewsong(int songNumber)
    {
        StartCoroutine(CheckSongPlaying(songNumber));
    }

    public void StopSongTimer()
    {
        if(waitForSongCoroutine != null)
        {
            StopCoroutine(waitForSongCoroutine);
            waitForSongCoroutine = null;
        }
    }

    public static bool isInFirstPlayScreen;
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);

        PlayRandomSong(1);

        gameLoaded = true;

        timerCoroutine = StartCoroutine(UpdateTimerCoroutine());

        resetStats = false;
        #region Reset Stats
        if(resetStats == true)
        {
            totalButtonClicks = 0;
            totalCritClicks = 0;
            totalIdleClicks = 0;
            totalPoints = 0f;
            totalClickPoints = 0f;
            totalCritPoints = 0f;
            totalEnemyPoints = 0f;
            totalPointDropPoints = 0f;
            totalEnemiesDefeated = 0;
            totalSmallEnemiesDefeated = 0;
            totalSpeedstersDefeated = 0;
            totalSharpshootersDefeated = 0;
            totalSnipersDefeated = 0;
            totalHeavyshotDefeated = 0;
            totalBrutedDefeated = 0;
            totalRagingGunnerDefeated = 0;
            totalTitansDefeated = 0;
            totalLevels = 0;
            furthestRunLevel = 0;
            totalTimePlayedHours = 0;
            totalTimePlayedMinutes = 0;
            endingsCompleted = 0;
            runsCompleted = 0;
            timesDefeatedBoss = 0;
            timesDefeatedHorde = 0;
            timesDefeatedChampions = 0;
            timesDefeatedDangerButton = 0;
            ritualsEntered = 0;
            weirdEggUpgrades = 0;
            totalAbilitiesChosen = 0;
            totalCommonAbilitiesChosen = 0;
            totalUncommonAbilititesChosen = 0;
            totalRareAbilitiesChose = 0;
            totalLegendaryAbilitiesChosen = 0;
            totalMythicAbilitiesChosen = 0;
            timesRerolled = 0;

            firstTimeDefeatedBoss = false;
            firstTimeDefeatedHorde = false;
            firstTimeDefeatedChampions = false;
            firstTimeDefeatedDangerButton = false;

            firstRunCompleted = false;

            longestRunMinutes = 0;
            longestRunSeconds = 0;
            fastestRunMinutes = 0;
            fastestRunSeconds = 0;

            totalTimeSeconds = 0;
            totalTimeMinutes = 0;

        }
        #endregion

        UpdateTimerText();
        
        if(MobileScript.isMobile == true)
        {
            pressedOkFirstTImePlaying = true;
        }

        triggerResolution = false;
        if(pressedOkFirstTImePlaying == false)
        {
            isInFirstPlayScreen = true;
            spaceBarSelected = true;
            leftClickSeleced = false;
            
            mainXPBar.SetActive(true);
            Choises.isInMainManu = true;
            firstTimePlayingScreen.SetActive(true);
            mainMenu.SetActive(false);
        }
        if (pressedOkFirstTImePlaying == true)
        {
            isInFirstPlayScreen = false;
            if (leftClickSeleced == true)
            {
                checkMarkSpacebar.SetActive(false);
                checkMarkSpacebarSettings.SetActive(false);
                checkMArkLeftClick.SetActive(true);
                checkMArkLeftClickSettings.SetActive(true);
                crossSpacebar.SetActive(true);
                crossSpacebarSettings.SetActive(true);
                crossLeftClick.SetActive(false);
                crossLeftClickSettings.SetActive(false);

                Image image1 = leftClickButton.GetComponent<Image>();
                SetAlpha(image1, 1f);
                Image image11 = leftClickButtonSettings.GetComponent<Image>();
                SetAlpha(image11, 1f);

                Image image2 = spaceBarButton.GetComponent<Image>();
                SetAlpha(image2, 0.6f);
                Image image22 = spaceBarButtonSettings.GetComponent<Image>();
                SetAlpha(image22, 0.6f);
            }
            if (spaceBarSelected == true)
            {
                checkMarkSpacebar.SetActive(true);
                checkMarkSpacebarSettings.SetActive(true);
                checkMArkLeftClick.SetActive(false);
                checkMArkLeftClickSettings.SetActive(false);
                crossSpacebar.SetActive(false);
                crossSpacebarSettings.SetActive(false);
                crossLeftClick.SetActive(true);
                crossLeftClickSettings.SetActive(true);
                Image image1 = spaceBarButton.GetComponent<Image>();
                SetAlpha(image1, 1f);
                Image image11 = spaceBarButtonSettings.GetComponent<Image>();
                SetAlpha(image11, 1f);

                Image image2 = leftClickButton.GetComponent<Image>();
                SetAlpha(image2, 0.6f);
                Image image22 = leftClickButtonSettings.GetComponent<Image>();
                SetAlpha(image22, 0.6f);
            }

            mainXPBar.SetActive(false);
            Choises.isInMainManu = true;
            firstTimePlayingScreen.SetActive(false);
            mainMenu.SetActive(true);
            mainCamera.orthographicSize = 29f;
            mainCamera.transform.localPosition = new Vector3(-27, -1.9f, -10);
        }


        if (isPlayerPlayingARun == true)
        {
            mainMenuResetBTN.interactable = true;
            continueRunBTN.interactable = true;
        }
        if (isPlayerPlayingARun == false)
        {
            mainMenuResetBTN.interactable = false;
            continueRunBTN.interactable = false;
        }

        if (!PlayerPrefs.HasKey("ShowTimer")) 
        {
            if (MobileScript.isMobile == false) { showTimer = 0; }
            else { showTimer = 1; }

            PlayerPrefs.SetInt("ShowTimer", showTimer);
        }

        if (!PlayerPrefs.HasKey("DisplayAbilityClicks"))
        {
            if(MobileScript.isMobile == false) { displayAbilityClicks = 0; }
            else { displayAbilityClicks = 1; }

            PlayerPrefs.SetInt("DisplayAbilityClicks", displayAbilityClicks);
        }

        if (!PlayerPrefs.HasKey("DisablePointPopUp")) { disablePointPopUp = 0; }
        if (!PlayerPrefs.HasKey("DisableParticleEffects")) { disableParticleEffects = 0; }
        if (!PlayerPrefs.HasKey("DisableDamagePopUp")) { disableEnemyDamagePopUp = 0; }
        if (!PlayerPrefs.HasKey("HealthbarPosition")) { healthbarPosition = 0; }
        if (!PlayerPrefs.HasKey("DisableBrokenPieces")) { disableBrokenPieces = 0; }
        if (!PlayerPrefs.HasKey("DisableWhiteFlash")) { disableWhiteFlash = 0; }

        if (PlayerPrefs.HasKey("ShowTimer"))
        {
            showTimer = PlayerPrefs.GetInt("ShowTimer");
        }

        if (showTimer == 1) { timerToggleOff.SetActive(false); timerToggleOn.SetActive(true); }
        if (showTimer == 0) { timerToggleOff.SetActive(true); timerToggleOn.SetActive(false); }

        if (PlayerPrefs.HasKey("DisplayAbilityClicks"))
        {
            displayAbilityClicks = PlayerPrefs.GetInt("DisplayAbilityClicks");
        }

        if (displayAbilityClicks == 1) { clicksToggleOff.SetActive(false); clicksToggleOn.SetActive(true); }
        if (displayAbilityClicks == 0) { clicksToggleOff.SetActive(true); clicksToggleOn.SetActive(false); }

        if (PlayerPrefs.HasKey("HealthbarPosition"))
        {
            healthbarPosition = PlayerPrefs.GetInt("HealthbarPosition");
            if (healthbarPosition == 1) { healthbarToggleOff.SetActive(true); healthbarToggleOn.SetActive(false); }
            if (healthbarPosition == 0) { healthbarToggleOff.SetActive(false); healthbarToggleOn.SetActive(true); }
        }

        if (PlayerPrefs.HasKey("DisablePointPopUp")) 
        {
            disablePointPopUp = PlayerPrefs.GetInt("DisablePointPopUp");
            if (disablePointPopUp == 0) { pointsToggleOff.SetActive(false); pointsToggleOn.SetActive(true); }
            if (disablePointPopUp == 1) { pointsToggleOff.SetActive(true); pointsToggleOn.SetActive(false); }
        }

        if (PlayerPrefs.HasKey("DisableParticleEffects"))
        {
            disableParticleEffects = PlayerPrefs.GetInt("DisableParticleEffects");
            if (disableParticleEffects == 0) { particleToggleOff.SetActive(false); particleToggleOn.SetActive(true); }
            if (disableParticleEffects == 1) { particleToggleOff.SetActive(true); particleToggleOn.SetActive(false); }
        }

        if (PlayerPrefs.HasKey("DisableDamagePopUp")) 
        {
            disableEnemyDamagePopUp = PlayerPrefs.GetInt("DisableDamagePopUp");
            if (disableEnemyDamagePopUp == 0) { damageToggleOff.SetActive(false); damageToggleOn.SetActive(true); }
            if (disableEnemyDamagePopUp == 1) { damageToggleOff.SetActive(true); damageToggleOn.SetActive(false); }
        }

        if (PlayerPrefs.HasKey("DisableBrokenPieces")) 
        {
            disableBrokenPieces = PlayerPrefs.GetInt("DisableBrokenPieces");
            if (disableBrokenPieces == 0) { brokenPiecesToggleOff.SetActive(false); brokenPiecesToggleOn.SetActive(true); }
            if (disableBrokenPieces == 1) { brokenPiecesToggleOff.SetActive(true); brokenPiecesToggleOn.SetActive(false); }
        }

        if (PlayerPrefs.HasKey("DisableWhiteFlash"))
        {
            disableWhiteFlash = PlayerPrefs.GetInt("DisableWhiteFlash");
            if (disableWhiteFlash == 0) { whiteFlashToggleOff.SetActive(false); whiteFlashToggleOn.SetActive(true); }
            if (disableWhiteFlash == 1) { whiteFlashToggleOff.SetActive(true); whiteFlashToggleOn.SetActive(false); }
        }

        locScript.SettingsToggleText();

        yield return new WaitForSeconds(2);
        loaded = true;
        PlayerPrefs.Save();
    }

    bool loaded;

    public GameObject timerToggleOff, timerToggleOn, clicksToggleOff, clicksToggleOn, pointsToggleOff, pointsToggleOn, particleToggleOff, particleToggleOn, damageToggleOff, damageToggleOn, healthbarToggleOff, healthbarToggleOn, brokenPiecesToggleOff, brokenPiecesToggleOn, whiteFlashToggleOn, whiteFlashToggleOff;

    public LocalizationVariables locScript;

    //Toggles
    #region Display timer
    public GameObject timerTopRight;
    public static int showTimer;

    public void ShowTimer()
    {
        if(showTimer == 0)
        {
            timerToggleOff.SetActive(false);
            timerToggleOn.SetActive(true);

            timerTopRight.SetActive(true);
            showTimer = 1;
        }
        else
        {
            timerToggleOff.SetActive(true);
            timerToggleOn.SetActive(false);

            timerTopRight.SetActive(false);
            showTimer = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("ShowTimer", showTimer);
        locScript.SettingsToggleText();

       // Debug.Log(showTimer);
    }
    #endregion

    #region DisplayAbilityClicks
    public GameObject abilityClicks;
    public static int displayAbilityClicks;

    public void DisplayAbilityClicks()
    {
        if(displayAbilityClicks == 0)
        {
            clicksToggleOff.SetActive(false);
            clicksToggleOn.SetActive(true);

            abilityClicks.SetActive(true);
            displayAbilityClicks = 1;
            buttonClickScript.CheckOnlyActive();
        }
        else
        {
            buttonClickScript.CheckAbilitysActive();
            clicksToggleOff.SetActive(true);
            clicksToggleOn.SetActive(false);

            abilityClicks.SetActive(false);
            displayAbilityClicks = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("DisplayAbilityClicks", displayAbilityClicks);
        locScript.SettingsToggleText();

        //Debug.Log(displayAbilityClicks);
    }
    #endregion

    #region disable point pop up
    public static int disablePointPopUp;

    public void DisablePointPopUp()
    {
        if (disablePointPopUp == 0)
        {
            pointsToggleOff.SetActive(true);
            pointsToggleOn.SetActive(false);

            disablePointPopUp = 1;
        }
        else
        {
            pointsToggleOff.SetActive(false);
            pointsToggleOn.SetActive(true);

            disablePointPopUp = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("DisablePointPopUp", disablePointPopUp);
        locScript.SettingsToggleText();
    }
    #endregion

    #region  disable particle effects
    public static int disableParticleEffects;

    public void DisableParticleEffects()
    {
        if (disableParticleEffects == 0)
        {
            particleToggleOff.SetActive(true);
            particleToggleOn.SetActive(false);

            disableParticleEffects = 1;
        }
        else
        {
            particleToggleOff.SetActive(false);
            particleToggleOn.SetActive(true);

            disableParticleEffects = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("DisableParticleEffects", disableParticleEffects);
        locScript.SettingsToggleText();
    }
    #endregion

    #region disable enemy damage pop up
    public static int disableEnemyDamagePopUp;

    public void DisableDamagePopUp()
    {
        if (disableEnemyDamagePopUp == 0)
        {
            damageToggleOff.SetActive(true);
            damageToggleOn.SetActive(false);

            disableEnemyDamagePopUp = 1;
        }
        else
        {
            damageToggleOff.SetActive(false);
            damageToggleOn.SetActive(true);

            disableEnemyDamagePopUp = 0;
        }
        SwitchAduio();

        PlayerPrefs.SetInt("DisableDamagePopUp", disableEnemyDamagePopUp);
        locScript.SettingsToggleText();
    }
    #endregion

    #region Button healthbar position
    public static int healthbarPosition;
    public GameObject healthbarOnButton, HealthbarOnButtonText;
    public GameObject healthbarTopRight;

    public void SetHealthBarPotition()
    {
        if (healthbarPosition == 0)
        {
            healthbarToggleOff.SetActive(true);
            healthbarToggleOn.SetActive(false);

            if (Choises.choseHealthBar == true)
            {
                healthbarTopRight.SetActive(true);
                healthbarOnButton.SetActive(false);
                HealthbarOnButtonText.SetActive(false);
            }

            healthbarPosition = 1;
        }
        else
        {
            healthbarToggleOff.SetActive(false);
            healthbarToggleOn.SetActive(true);

            if (Choises.choseHealthBar == true)
            {
                healthbarTopRight.SetActive(false);
                healthbarOnButton.SetActive(true);
                HealthbarOnButtonText.SetActive(true);
            }

            healthbarPosition = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("HealthbarPosition", healthbarPosition);
        locScript.SettingsToggleText();
    }
    #endregion

    #region disable broken pieces
    public static int disableBrokenPieces;

    public void DisableBrokenPieces()
    {
        if (disableBrokenPieces == 0)
        {
            brokenPiecesToggleOff.SetActive(true);
            brokenPiecesToggleOn.SetActive(false);

            disableBrokenPieces = 1;
        }
        else
        {
            brokenPiecesToggleOff.SetActive(false);
            brokenPiecesToggleOn.SetActive(true);

            disableBrokenPieces = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("DisableBrokenPieces", disableBrokenPieces);
        locScript.SettingsToggleText();
    }
    #endregion

    #region disable white flash
    public static int disableWhiteFlash;

    public void DisableWhiteFlashes()
    {
        if (disableWhiteFlash == 0)
        {
            whiteFlashToggleOff.SetActive(true);
            whiteFlashToggleOn.SetActive(false);

            disableWhiteFlash = 1;
        }
        else
        {
            whiteFlashToggleOff.SetActive(false);
            whiteFlashToggleOn.SetActive(true);

            disableWhiteFlash = 0;
        }

        SwitchAduio();
        PlayerPrefs.SetInt("DisableWhiteFlash", disableWhiteFlash);
        locScript.SettingsToggleText();
    }
    #endregion

    #region ContinueRun
    public static bool isMobileSettingBTN;

    public void ContinueRun()
    {
        audioManager.Play("CircleTranIn");

        PlayRandomSong(1);

        if (Choises.choseIdleClicking == true)
        {
            ButtonClick.autoClick = true;
        }

        //ButtonClick.autoClick = true;

        //Choises.choseIdleClicking = true;
        //Choises.timeBetweenClicks = 0.2f;

        Choises.isInMainManu = false;
        Image image = mainXPBar.GetComponent<Image>();
        mainXPBar.SetActive(true);
       
        mainCamera.GetComponent<Animator>().enabled = true;
        mainMenu.GetComponent<Animator>().SetTrigger("MenuIn");
        mainCamera.GetComponent<Animator>().SetTrigger("CameraIn");
        Invoke("SetCameraANimFalse", 0.5f);


        if (PlayerPrefs.HasKey("HealthbarPosition"))
        {
            healthbarPosition = PlayerPrefs.GetInt("HealthbarPosition");
            if (healthbarPosition == 0)
            {
                healthbarToggleOff.SetActive(false); healthbarToggleOn.SetActive(true);

                if(Choises.choseHealthBar == true)
                {
                    healthbarTopRight.SetActive(false);
                    healthbarOnButton.SetActive(true);
                    HealthbarOnButtonText.SetActive(true);
                }
            }
            if (healthbarPosition == 1)
            {
                healthbarToggleOff.SetActive(true); healthbarToggleOn.SetActive(false);

                if (Choises.choseHealthBar == true)
                {
                    healthbarTopRight.SetActive(true);
                    healthbarOnButton.SetActive(false);
                    HealthbarOnButtonText.SetActive(false);
                }
            }
        }

        if (PlayerPrefs.HasKey("ShowTimer"))
        {
            showTimer = PlayerPrefs.GetInt("ShowTimer");
            if (showTimer == 0) { timerToggleOff.SetActive(true); timerToggleOn.SetActive(false); timerTopRight.SetActive(false); }
            if (showTimer == 1) { timerToggleOff.SetActive(false); timerToggleOn.SetActive(true); timerTopRight.SetActive(true); }
        }

        if (PlayerPrefs.HasKey("DisplayAbilityClicks"))
        {
            displayAbilityClicks = PlayerPrefs.GetInt("DisplayAbilityClicks");
            if (displayAbilityClicks == 0) 
            { 
                clicksToggleOff.SetActive(true); clicksToggleOn.SetActive(false); abilityClicks.SetActive(false);
            }
            if (displayAbilityClicks == 1)
            { 
                clicksToggleOff.SetActive(false); clicksToggleOn.SetActive(true); abilityClicks.SetActive(true);

                buttonClickScript.CheckAbilitysActive();
            }
        }
    }
    #endregion

    public void CheckTimerAndStuff()
    {
        if (displayAbilityClicks == 0)
        {
            clicksToggleOff.SetActive(true); clicksToggleOn.SetActive(false); abilityClicks.SetActive(false);
        }
        if (displayAbilityClicks == 1)
        {
            clicksToggleOff.SetActive(false); clicksToggleOn.SetActive(true); abilityClicks.SetActive(true);
            buttonClickScript.CheckAbilitysActive();
        }

        if (showTimer == 0) { timerToggleOff.SetActive(true); timerToggleOn.SetActive(false); timerTopRight.SetActive(false); }
        if (showTimer == 1) { timerToggleOff.SetActive(false); timerToggleOn.SetActive(true); timerTopRight.SetActive(true); }
    }

    public void SwitchAduio()
    {
        audioManager.Play("Switch");
    }


    public ButtonClick buttonClickScript;
    public Zoom zoomScipt;

    public void SetCameraANimFalse()
    {
        mainCamera.GetComponent<Animator>().enabled = false;
        zoomScipt.SetHordeCamera();

        if (MobileScript.isMobile == true)
        {
            mobileSettingsBTN.SetActive(true);
            isMobileSettingBTN = true;
        }
    }

    public GameObject wouldYouLikeToReset;
    public Choises choisesScript;

    public void NewRun()
    {
        audioManager.Play("UI_Click2");
        wouldYouLikeToReset.SetActive(true); 
    }

    public void NewRunMainMenun()
    {
        SetObjectOnScreenBack();   

        PlayRandomSong(1);

        if (isPlayerPlayingARun == false)
        {
            audioManager.Play("CircleTranIn");
            choisesScript.NewRun();
            isInSettings = false; 
            ButtonClick.pointsGained = 0;
            ButtonClick.pointsNeeded = 20;

            if (showTimer == 1) { timerTopRight.SetActive(true); }
            CheckTimerAndStuff();
        }
        else 
        { 
            wouldYouLikeToReset.SetActive(true); audioManager.Play("UI_Click2");
        }
    }

    public void NoReset()
    {
        audioManager.Play("UI_Click2");
        wouldYouLikeToReset.SetActive(false);
    }

    public void OptionsButton()
    {
        audioManager.Play("UI_Click2");
        settingsPopUp.SetActive(true);
    }

    #region Set Alpha
    private void SetAlpha(Graphic graphic, float alpha)
    {
        Color currentColor = graphic.color;
        currentColor.a = alpha;
        graphic.color = currentColor;

        for (int i = 0; i < graphic.transform.childCount; i++)
        {
            Graphic childGraphic = graphic.transform.GetChild(i).GetComponent<Graphic>();
            if (childGraphic != null)
            {
                SetAlpha(childGraphic, alpha);
            }
        }
    }
    #endregion

    #region SetAlphaFade
    private void SetAlphaFade(Graphic graphic, float targetAlpha)
    {
        StartCoroutine(FadeAlpha(graphic, targetAlpha));
    }

    private System.Collections.IEnumerator FadeAlpha(Graphic graphic, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color startColor = graphic.color;

        while (elapsedTime < 0.10f)
        {
            float newAlpha = Mathf.Lerp(startColor.a, targetAlpha, elapsedTime / 0.10f);
            graphic.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

            for (int i = 0; i < graphic.transform.childCount; i++)
            {
                Graphic childGraphic = graphic.transform.GetChild(i).GetComponent<Graphic>();
                if (childGraphic != null)
                {
                    // Recursively fade the alpha of child graphics
                    SetAlphaFade(childGraphic, targetAlpha);
                }
            }

            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        // Ensure the final alpha value is set
        graphic.color = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
    }
    #endregion

    void Start()
    {
        #region Resolution
        // Define a list of supported resolutions
        resolutions = new List<Resolution>
        {
            new Resolution { width = 800, height = 600 },
            new Resolution { width = 1024, height = 768 },
            new Resolution { width = 1280, height = 720 },
            new Resolution { width = 1280, height = 800 },
            new Resolution { width = 1280, height = 1024 },
            new Resolution { width = 1366, height = 768 },
            new Resolution { width = 1600, height = 900 },
            new Resolution { width = 1920, height = 1080 },
            new Resolution { width = 1920, height = 1200 },
            new Resolution { width = 2560, height = 1440 },
            new Resolution { width = 2560, height = 1600 },
            new Resolution { width = 2560, height = 1080 },
            new Resolution { width = 3440, height = 1440 },
            new Resolution { width = 3840, height = 1440 },
            new Resolution { width = 3840, height = 2160 },
            new Resolution { width = 3840, height = 2400 }
            // Add any other resolutions you want to support here
        };

        // Add the supported resolutions to the dropdown
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Count; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.value = resolutionIndexSave;
        #endregion
        buttonLeftClickBlock.SetActive(true);
    }

    public GameObject currentRunScreen;
    public GameObject endingSettingButton, endingSettingScreen;
    public GameObject ending1CheckMark, ending2CheckMark, ending3CheckMark, ending4CheckMark;
    public TextMeshProUGUI endingFrameEndingsCompleted;
    public GameObject lockedAssasin, lockedSpeedster, lockedSharpshooter, lockedSniper, lockedHeavyshot, lockedBrute, lockedGunner, lockedTitan;

    public GameObject lockedPointDrop, lockedDoubleTap, lockedUzi, lockedPistol, lockedShotgun, lockedAwp, lockedDeagle, lockedChargedBullet, lockedBrossbow, lockedCannon, lockedMp4, lockedArrow, lockedBoxingGlove, lockedStabbySpike, lockedTinySpike, lockedKnifes, lockedSawBlade, lockedSword, lockedHammer, lockedDefense, lockedBigHeart, lockedSmallShields, lockedBouncyShield, lockedInvin, lockedStopwatch, lockedBooster, lockedRocker, lockedTalaria, lockedRandom2, lockedRandom3, lockedRandom5, lockedRitual, lockedEgg, lockedArena, locked4Abilites, lockedRerollRare, locked5Abilities, lockedRerollLegendary, lockedSkullHarvest;

    public GameObject skinsButtonEXL;
    public GameObject achTooltip, skinToolTip, abilityToolTip, currentRunToolTip;

    public GameObject PointPerClick, IdleClicks, CritClicks, Defense, BigHeart, SmallShield, BouncyShield, Pisto, UZI, Shotgun, AWP, Deagle, Cannon, MP4, Crossbow, Arena, BoxingGlove, StabbySpikes, TinySpiked, Knife, Sword, Ritual, SawBlade, Hammer, Arrow, ChargedBullet, PointDrop, StopTime, Invincibility, SkullHarvest, Dice, abilites4X, abilites5X, booster, rocket, talraia, doubleTap, egg;

    public GameObject noNonControllableAcquired;
    public GameObject chargeSpacebar, chargeLeftClick, justClickLeftClick, justClickSpacebar;

    public GameObject PointPerClickEgg, IdleClicksEgg, CritClicksEgg, DefenseEgg, BigHeartEgg, SmallShieldEgg, BouncyShieldEgg, PistoEgg, UZIEgg, ShotgunEgg, AWPEgg, DeagleEgg, CannonEgg, MP4Egg, CrossbowEgg, ArenaEgg, BoxingGloveEgg, StabbySpikesEgg, TinySpikedEgg, KnifeEgg, SwordEgg, RitualEgg, SawBladeEgg, HammerEgg, ArrowEgg, ChargedBulletEgg, PointDropEgg, StopTimeEgg, InvincibilityEgg, SkullHarvestEgg, DiceEgg;

    public GameObject mobileSettingsBTN;

    #region Update
    void Update()
    {
        if (statsFrame.activeInHierarchy == true || infoFrame.activeInHierarchy == true)
        {
            isInStats = true;
            #region Locked Abilities Frames
            if (Choises.pointDropFirst == true) { lockedPointDrop.SetActive(false); }
            else { lockedPointDrop.SetActive(true); }
            if (Choises.doubletapFirst == true) { lockedDoubleTap.SetActive(false); }
            else { lockedDoubleTap.SetActive(true); }

            //Guns
            if (Choises.uziFirst == true) { lockedUzi.SetActive(false); }
            else { lockedUzi.SetActive(true); }
            if (Choises.pistolFirst == true) { lockedPistol.SetActive(false); }
            else { lockedPistol.SetActive(true); }
            if (Choises.shotgunFirst == true) { lockedShotgun.SetActive(false); }
            else { lockedShotgun.SetActive(true); }
            if (Choises.awpFirst == true) { lockedAwp.SetActive(false); }
            else { lockedAwp.SetActive(true); }
            if (Choises.deagleFirst == true) { lockedDeagle.SetActive(false); }
            else { lockedDeagle.SetActive(true); }
            if (Choises.chargedBulletFirst == true) { lockedChargedBullet.SetActive(false); }
            else { lockedChargedBullet.SetActive(true); }
            if (Choises.crossbowFirst == true) { lockedBrossbow.SetActive(false); }
            else { lockedBrossbow.SetActive(true); }
            if (Choises.cannonFirst == true) { lockedCannon.SetActive(false); }
            else { lockedCannon.SetActive(true); }
            if (Choises.mp4First == true) { lockedMp4.SetActive(false); }
            else { lockedMp4.SetActive(true); }
            if (Choises.arrosFirst == true) { lockedArrow.SetActive(false); }
            else { lockedArrow.SetActive(true); }

            //Melee
            if (Choises.boxinggloveFirst == true) { lockedBoxingGlove.SetActive(false); }
            else { lockedBoxingGlove.SetActive(true); }
            if (Choises.stabbyspikeFirst == true) { lockedStabbySpike.SetActive(false); }
            else { lockedStabbySpike.SetActive(true); }
            if (Choises.tinySpikeFirst == true) { lockedTinySpike.SetActive(false); }
            else { lockedTinySpike.SetActive(true); }
            if (Choises.knifeFirst == true) { lockedKnifes.SetActive(false); }
            else { lockedKnifes.SetActive(true); }
            if (Choises.sawBladeFirst == true) { lockedSawBlade.SetActive(false); }
            else { lockedSawBlade.SetActive(true); }
            if (Choises.swordFirst == true) { lockedSword.SetActive(false); }
            else { lockedSword.SetActive(true); }
            if (Choises.hammerFirst == true) { lockedHammer.SetActive(false); }
            else { lockedHammer.SetActive(true); }

            //Defense
            if (Choises.defenseFirst == true) { lockedDefense.SetActive(false); }
            else { lockedDefense.SetActive(true); }
            if (Choises.heartFirst == true) { lockedBigHeart.SetActive(false); }
            else { lockedBigHeart.SetActive(true); }
            if (Choises.smallShieldFirst == true) { lockedSmallShields.SetActive(false); }
            else { lockedSmallShields.SetActive(true); }
            if (Choises.bouncyShieldFirst == true) { lockedBouncyShield.SetActive(false); }
            else { lockedBouncyShield.SetActive(true); }
            if (Choises.invinFirst == true) { lockedInvin.SetActive(false); }
            else { lockedInvin.SetActive(true); }
            if (Choises.stopwatchFirst == true) { lockedStopwatch.SetActive(false); }
            else { lockedStopwatch.SetActive(true); }

            //Movement
            if (Choises.boosterFirst == true) { lockedBooster.SetActive(false); }
            else { lockedBooster.SetActive(true); }
            if (Choises.rocketFirst == true) { lockedRocker.SetActive(false); }
            else { lockedRocker.SetActive(true); }
            if (Choises.talariaFirst == true) { lockedTalaria.SetActive(false); }
            else { lockedTalaria.SetActive(true); }

            //Ability upgrades
            if (Choises.random2First == true) { lockedRandom2.SetActive(false); }
            else { lockedRandom2.SetActive(true); }
            if (Choises.random3First == true) { lockedRandom3.SetActive(false); }
            else { lockedRandom3.SetActive(true); }
            if (Choises.random5First == true) { lockedRandom5.SetActive(false); }
            else { lockedRandom5.SetActive(true); }
            if (Choises.ritualFirst == true) { lockedRitual.SetActive(false); }
            else { lockedRitual.SetActive(true); }
            if (Choises.eggFirst == true) { lockedEgg.SetActive(false); }
            else { lockedEgg.SetActive(true); }

            //Other
            if (Choises.arenaFirst == true) { lockedArena.SetActive(false); }
            else { lockedArena.SetActive(true); }
            if (Choises.abiltites4XFirst == true) { locked4Abilites.SetActive(false); }
            else { locked4Abilites.SetActive(true); }
            if (Choises.rerollRareFirst == true) { lockedRerollRare.SetActive(false); }
            else { lockedRerollRare.SetActive(true); }
            if (Choises.abilities5XFirst == true) { locked5Abilities.SetActive(false); }
            else { locked5Abilities.SetActive(true); }
            if (Choises.rerollLegendaryFirst == true) { lockedRerollLegendary.SetActive(false); }
            else { lockedRerollLegendary.SetActive(true); }
            if (Choises.skullHarvestFirst == true) { lockedSkullHarvest.SetActive(false); }
            else { lockedSkullHarvest.SetActive(true); }
            #endregion
        }
        else
        {
            isInStats = false;
        }

        if(MobileScript.isMobile == true)
        {
            if(Choises.isInMainManu == true) { isMobileSettingBTN = false;   }

            if (Choises.isInFirstWeaponScreen == true || Choises.isInChooseEndingScreen == true || Choises.isInWinScreen == true || Choises.isInDeathScreen == true || Choises.isEndingTransition == true || Choises.isInEggScreen == true)
            {
                mobileSettingsBTN.SetActive(false);
                mobileShopBtn.SetActive(false);
            }
            else 
            { 
                if (isMobileSettingBTN == true)
                {
                    mobileSettingsBTN.SetActive(true);

                    if (InAppPurchase.isAdsRemoved == true && InAppPurchase.is12Cps == true)
                    {
                        mobileShopBtn.SetActive(false);
                    }
                    else
                    {
                        mobileShopBtn.SetActive(true);
                    }
                }
                else { mobileSettingsBTN.SetActive(false); mobileShopBtn.SetActive(false); }
            }
        }

        #region Pause and unpause
        if (Choises.isInFirstWeaponScreen == false && Choises.isInChooseEndingScreen == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false && Choises.isEndingTransition == false)
        {
            if(MobileScript.isMobile == false)
            {
                if (Input.GetKeyDown(KeyCode.Escape) && loaded == true)
                {
                    SettingsMechanics(true);
                }
            }
        }
        #endregion

        #region controls
        if (controlsFrame.activeInHierarchy == true)
        {
            if(spaceBarSelected == true)
            {
                justClickSpacebar.SetActive(true);
                chargeSpacebar.SetActive(true);

                justClickLeftClick.SetActive(false);
                chargeLeftClick.SetActive(false);
            }
            else
            {
                justClickSpacebar.SetActive(false);
                chargeSpacebar.SetActive(false);

                justClickLeftClick.SetActive(true);
                chargeLeftClick.SetActive(true);
            }

            if(Choises.choseInvincibility == true) { blockInvinControls.SetActive(false);  }
            else { blockInvinControls.SetActive(true); }

            if(Choises.choseButtonCharge == true) { blockChargedBulletControls.SetActive(false); }
            else { blockChargedBulletControls.SetActive(true); }

            if(Choises.chooseControllableButton == true) { talariaControls.SetActive(true); }
            else { talariaControls.SetActive(false); }

            if (Choises.choseButtonBounceCharge == true) { boosterControls.SetActive(true); }
            else { boosterControls.SetActive(false); }

            if (Choises.chooseRocket == true) { rocketControls.SetActive(true); }
            else { rocketControls.SetActive(false); }

            if (Choises.choseBouncingBullets == true) { blockArenaControls.SetActive(false); }
            else { blockArenaControls.SetActive(true); }

            if (Choises.movementAbilityAquaried == true)
            {
                blockMovementControls.SetActive(false);
                tabSwitch.SetActive(true);
            }
            else { blockMovementControls.SetActive(true); tabSwitch.SetActive(false); }
        }
        #endregion

        #region Enemies
        //Locked enemies
        if (Choises.assassinFirstTime == true) { lockedAssasin.SetActive(false); }
        else { lockedAssasin.SetActive(true); }

        if (Choises.speedsterFirstTime == true) { lockedSpeedster.SetActive(false); }
        else { lockedSpeedster.SetActive(true); }

        if (Choises.sharpshooterFirstTime == true) { lockedSharpshooter.SetActive(false); }
        else { lockedSharpshooter.SetActive(true); }

        if (Choises.sniperFirstTime == true) { lockedSniper.SetActive(false); }
        else { lockedSniper.SetActive(true); }

        if (Choises.heavyshotFirstTime == true) { lockedHeavyshot.SetActive(false); }
        else { lockedHeavyshot.SetActive(true); }

        if (Choises.bruteFirstTime == true) { lockedBrute.SetActive(false); }
        else { lockedBrute.SetActive(true); }

        if (Choises.ragingGunnerFirstTime == true) { lockedGunner.SetActive(false); }
        else { lockedGunner.SetActive(true); }

        if (Choises.titanFirstTime == true) { lockedTitan.SetActive(false); }
        else { lockedTitan.SetActive(true); }
        #endregion

        #region Currentrun
        if(currentRunScreen.activeInHierarchy == true)
        {
            PointPerClick.SetActive(true);
            if(Choises.choseCritClicks == true) { CritClicks.SetActive(true); }
            if (Choises.choseCritClicks == false) { CritClicks.SetActive(false); }

            if (Choises.choseIdleClicking == true) { IdleClicks.SetActive(true); }
            if (Choises.choseIdleClicking == false) { IdleClicks.SetActive(false); }

            if (Choises.choseHealthBar == true) {  Defense.SetActive(true); }
            if (Choises.choseHealthBar == false) { Defense.SetActive(false); }

            if (Choises.chooseHeartCollect == true) {  BigHeart.SetActive(true); }
            if (Choises.chooseHeartCollect == false) { BigHeart.SetActive(false); }

            if (Choises.choseSmallShields == true) { SmallShield.SetActive(true); }
            if (Choises.choseSmallShields == false) { SmallShield.SetActive(false); }

            if (Choises.choseShield_BounceOff == true) {BouncyShield.SetActive(true); }
            if (Choises.choseShield_BounceOff == false) { BouncyShield.SetActive(false); }

            if (Choises.chose_Gun1 == true) {Pisto.SetActive(true); }
            if (Choises.chose_Gun1 == false) { Pisto.SetActive(false); }

            if (Choises.choseShootSmallBullets == true) { UZI.SetActive(true); }
            if (Choises.choseShootSmallBullets == false) { UZI.SetActive(false); }

            if (Choises.chose_gun2 == true) {  Shotgun.SetActive(true); }
            if (Choises.chose_gun2 == false) { Shotgun.SetActive(false); }

            if (Choises.chooseHomingBullets == true) { AWP.SetActive(true); }
            if (Choises.chooseHomingBullets == false) { AWP.SetActive(false); }

            if (Choises.choseCrossBow == true) { Crossbow.SetActive(true); }
            if (Choises.choseCrossBow == false) { Crossbow.SetActive(false); }

            if (Choises.choseTrippleShot == true) {  Deagle.SetActive(true); }
            if (Choises.choseTrippleShot == false) { Deagle.SetActive(false); }

            if (Choises.chooseBigPiercingBulletGun == true) {  Cannon.SetActive(true); }
            if (Choises.chooseBigPiercingBulletGun == false) { Cannon.SetActive(false); }

            if (Choises.choseGunMp4 == true) { MP4.SetActive(true); }
            if (Choises.choseGunMp4 == false) { MP4.SetActive(false); }

            if (Choises.choseBouncingBullets == true) { Arena.SetActive(true); }
            if (Choises.choseBouncingBullets == false) { Arena.SetActive(false); }

            if (Choises.choseBoxingGlove == true) { BoxingGlove.SetActive(true); }
            if (Choises.choseBoxingGlove == false) { BoxingGlove.SetActive(false); }

            if (Choises.chooseStabbingSpikes == true) {  StabbySpikes.SetActive(true); }
            if (Choises.chooseStabbingSpikes == false) { StabbySpikes.SetActive(false); }

            if (Choises.chooseSpikes == true) { TinySpiked.SetActive(true); }
            if (Choises.chooseSpikes == false) { TinySpiked.SetActive(false); }

            if (Choises.choseSpinningKnifes == true) { Knife.SetActive(true); }
            if (Choises.choseSpinningKnifes == false) { Knife.SetActive(false); }

            if (Choises.chooseBigSpike == true) { Sword.SetActive(true); }
            if (Choises.chooseBigSpike == false) { Sword.SetActive(false); }

            if (Choises.choseRitual == true) { Ritual.SetActive(true); }
            if (Choises.choseRitual == false) { Ritual.SetActive(false); }

            if (Choises.chooseSawBlade == true) { SawBlade.SetActive(true); }
            if (Choises.chooseSawBlade == false) { SawBlade.SetActive(false); }

            if (Choises.chooseHammer == true) { Hammer.SetActive(true); }
            if (Choises.chooseHammer == false) { Hammer.SetActive(false); }

            if (Choises.choseArrows == true) { Arrow.SetActive(true); }
            if (Choises.choseArrows == false) { Arrow.SetActive(false); }

            if (Choises.choseButtonCharge == true) { ChargedBullet.SetActive(true); }
            if (Choises.choseButtonCharge == false) { ChargedBullet.SetActive(false); }

            if (Choises.chosePointsDrop == true) { PointDrop.SetActive(true); }
            if (Choises.chosePointsDrop == false) { PointDrop.SetActive(false); }

            if (Choises.choseStopTime == true) { StopTime.SetActive(true); }
            if (Choises.choseStopTime == false) { StopTime.SetActive(false); }

            if (Choises.choseInvincibility == true) { Invincibility.SetActive(true); }
            if (Choises.choseInvincibility == false) { Invincibility.SetActive(false); }

            if (Choises.choseSkullHarvest == true) { SkullHarvest.SetActive(true); }
            if (Choises.choseSkullHarvest == false) { SkullHarvest.SetActive(false); }

            if (Choises.choseReroll == true) { Dice.SetActive(true); }
            if (Choises.choseReroll == false) { Dice.SetActive(false); }

            if (Choises.numberOfChoises == 3) { abilites4X.SetActive(false); abilites5X.SetActive(false); }
            if (Choises.numberOfChoises == 4) { abilites4X.SetActive(true); abilites5X.SetActive(false); }
            if (Choises.numberOfChoises == 5) { abilites5X.SetActive(true); abilites4X.SetActive(true); }

            if (Choises.choseButtonBounceCharge == true) { booster.SetActive(true); }
            if (Choises.choseButtonBounceCharge == false) { booster.SetActive(false); }

            if (Choises.chooseRocket == true) { rocket.SetActive(true); }
            if (Choises.chooseRocket == false) { rocket.SetActive(false); }

            if (Choises.chooseControllableButton == true) { talraia.SetActive(true); }
            if (Choises.chooseControllableButton == false) { talraia.SetActive(false); }

            if (Choises.choseDoubleTap == true) { doubleTap.SetActive(true); }
            if (Choises.choseDoubleTap == false) { doubleTap.SetActive(false); }

            if (Choises.choseUnlimitedPower == true) { egg.SetActive(true); }
            if (Choises.choseUnlimitedPower == false) { egg.SetActive(false); }

            if (Choises.numberOfChoises == 3 && Choises.choseButtonBounceCharge == false && Choises.chooseRocket == false && Choises.chooseControllableButton == false && Choises.choseDoubleTap == false && Choises.choseUnlimitedPower == false)
            {
                noNonControllableAcquired.SetActive(true);
            }
            else
            {
                noNonControllableAcquired.SetActive(false);
            }
        }
        #endregion

        #region Egg selected current run
        if (currentRunScreen.activeInHierarchy == true)
        {
            if(Choises.eggPointPerClickChosen == true) { PointPerClickEgg.SetActive(true); }
            else { PointPerClickEgg.SetActive(false); }

            if (Choises.eggIdleClickChosen == true) { IdleClicksEgg.SetActive(true); }
            else { IdleClicksEgg.SetActive(false); }

            if (Choises.eggCritclickChosen == true) { CritClicksEgg.SetActive(true); }
            else { CritClicksEgg.SetActive(false); }

            if (Choises.eggPointDropChosen == true) { PointDropEgg.SetActive(true); }
            else { PointDropEgg.SetActive(false); }

            if (Choises.eggDefenseChosen == true) { DefenseEgg.SetActive(true); }
            else { DefenseEgg.SetActive(false); }

            if (Choises.eggBigHeartChosen == true) { BigHeartEgg.SetActive(true); }
            else { BigHeartEgg.SetActive(false); }

            if (Choises.eggSmallShieldChosen == true) { SmallShieldEgg.SetActive(true); }
            else { SmallShieldEgg.SetActive(false); }

            if (Choises.eggBouncyShieldChosen == true) { BouncyShieldEgg.SetActive(true); }
            else { BouncyShieldEgg.SetActive(false); }

            if (Choises.eggStopwatchChosen == true) { StopTimeEgg.SetActive(true); }
            else { StopTimeEgg.SetActive(false); }

            if (Choises.eggInvinChosen == true) { InvincibilityEgg.SetActive(true); }
            else { InvincibilityEgg.SetActive(false); }

            if (Choises.eggPistolChosen == true) { PistoEgg.SetActive(true); }
            else { PistoEgg.SetActive(false); }

            if (Choises.eggUziChosen == true) { UZIEgg.SetActive(true); }
            else { UZIEgg.SetActive(false); }

            if (Choises.eggShotgunChosen == true) { ShotgunEgg.SetActive(true); }
            else { ShotgunEgg.SetActive(false); }

            if (Choises.eggAWPChosen == true) { AWPEgg.SetActive(true); }
            else { AWPEgg.SetActive(false); }

            if (Choises.eggDeagleChosen == true) { DeagleEgg.SetActive(true); }
            else { DeagleEgg.SetActive(false); }

            if (Choises.eggCrossbowChosen == true) { CrossbowEgg.SetActive(true); }
            else { CrossbowEgg.SetActive(false); }

            if (Choises.eggChagedBulletsChosen == true) { ChargedBulletEgg.SetActive(true); }
            else { ChargedBulletEgg.SetActive(false); }

            if (Choises.eggCannonChosen == true) { CannonEgg.SetActive(true); }
            else { CannonEgg.SetActive(false); }

            if (Choises.eggMP4Chosen == true) { MP4Egg.SetActive(true); }
            else { MP4Egg.SetActive(false); }

            if (Choises.eggArrowChosen == true) { ArrowEgg.SetActive(true); }
            else { ArrowEgg.SetActive(false); }

            if (Choises.eggTinySpikeChosen == true) { TinySpikedEgg.SetActive(true); }
            else { TinySpikedEgg.SetActive(false); }

            if (Choises.eggStabbySpikeChosen == true) { StabbySpikesEgg.SetActive(true); }
            else { StabbySpikesEgg.SetActive(false); }

            if (Choises.eggBoxingGloveChosen == true) { BoxingGloveEgg.SetActive(true); }
            else { BoxingGloveEgg.SetActive(false); }

            if (Choises.eggKnifeChosen == true) { KnifeEgg.SetActive(true); }
            else { KnifeEgg.SetActive(false); }

            if (Choises.eggSawBladeChose == true) { SawBladeEgg.SetActive(true); }
            else { SawBladeEgg.SetActive(false); }

            if (Choises.eggSwordChosen == true) { SwordEgg.SetActive(true); }
            else { SwordEgg.SetActive(false); }

            if (Choises.eggHammerChosen == true) { HammerEgg.SetActive(true); }
            else { HammerEgg.SetActive(false); }

            if (Choises.eggRitualChosen == true) { RitualEgg.SetActive(true); }
            else { RitualEgg.SetActive(false); }

            if (Choises.eggDiceChose == true) { DiceEgg.SetActive(true); }
            else { DiceEgg.SetActive(false); }

            if (Choises.eggArenaChosen == true) { ArenaEgg.SetActive(true); }
            else { ArenaEgg.SetActive(false); }

            if (Choises.eggSkullHarvestChosen == true) { SkullHarvestEgg.SetActive(true); }
            else { SkullHarvestEgg.SetActive(false); }
        }
        #endregion

        if (skinsFrame.activeInHierarchy == true)
        {
            skinsButtonEXL.SetActive(false);
        }

        if (endingSettingScreen.activeInHierarchy == true)
        {
            if(Choises.firstWeaponChosen == false)
            {
                blockPlayEnding.SetActive(true);
            }
            else { blockPlayEnding.SetActive(false); }
        }
    }

    public GameObject blockPlayEnding;
    #endregion

    #region Settings mechaincs
    public void SettingsMechanics(bool openSettings)
    {
        if(loaded == false) { return; }
        if (ButtonBehiavor.chargeSoundPlaying == true)
        {
            ButtonBehiavor.chargeSoundPlaying = false;
            audioManager.Stop("charge1");
        }

        if (MainButtonCollider.isRocketSound == true)
        {
            audioManager.Stop("rocket");
            MainButtonCollider.isRocketSound = false;
        }

        if (MainButtonCollider.isChargeSound == true)
        {
            audioManager.Stop("charge2");
            MainButtonCollider.isChargeSound = false;
        }

        audioManager.Play("UI_Click2");

        if (settingsPopUp.activeInHierarchy == false && mobileShopFrame.activeInHierarchy == false)
        {
            if(MobileScript.openShop == false)
            {
                if (Choises.isInChooseEndingScreen == false && ButtonClick.level > 74 && BossMechanics.fightingBossFight == false && MimicEnding.isPlayingChamptions == false && DangerButtonEnding.isPlayingDangerButton == false && HordeEnding.playingHordeEnding == false)
                {
                    endingSettingButton.SetActive(true);
                    if (firstTimeDefeatedBoss == true) { ending1CheckMark.SetActive(true); }
                    else { ending1CheckMark.SetActive(false); }

                    if (firstTimeDefeatedHorde == true) { ending2CheckMark.SetActive(true); }
                    else { ending2CheckMark.SetActive(false); }

                    if (firstTimeDefeatedChampions == true) { ending3CheckMark.SetActive(true); }
                    else { ending3CheckMark.SetActive(false); }

                    if (firstTimeDefeatedDangerButton == true) { ending4CheckMark.SetActive(true); }
                    else { ending4CheckMark.SetActive(false); }

                    endingFrameEndingsCompleted.text = endingsCompleted + "/4";
                }
                else
                {
                    endingSettingButton.SetActive(false);
                }
            }

            Cursor.visible = true;
            isInSettings = true;
            Time.timeScale = 0;

            if (MobileScript.openShop == false)
            {
                settingsPopUp.SetActive(true);
                achTooltip.SetActive(false);
                skinToolTip.SetActive(false);
                abilityToolTip.SetActive(false);
                currentRunToolTip.SetActive(false);
            }
        }
        else
        {
            SetCursors.hoveringClickableStuff = false;

            isInSettings = false;
            //Debug.Log(isInSettings);
            if (Choises.isPaused == false)
            {
                if (ButtonClick.isStopTimeAbilityActive == false) { Time.timeScale = 1; }
            }
            settingsPopUp.SetActive(false);
            if (wouldYouLikeToReset.activeInHierarchy == true)
            {
                wouldYouLikeToReset.SetActive(false);
            }
        }
    }
    #endregion

    #region Resolution And Fullscreen
    public int resolutionIndexSave;
    public void SetResolution(int resolutionIndex)
    {
        if (triggerResolution == false)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

            saveWidth = resolution.width;
            saveHeight = resolution.height;

            PlayerPrefs.SetInt("ScreenWidth", saveWidth);
            PlayerPrefs.SetInt("ScreenHeight", saveHeight);

            resolutionIndexSave = resolutionIndex;
            PlayerPrefs.SetInt("saveIndex", resolutionIndexSave);
        }
    }

    public GameObject fullSreenToggleOff, fullScreenToggleOn;
    public void SetFullSCreen()
    {
        fullScreenToggleOn.SetActive(false);
        fullSreenToggleOff.SetActive(true);
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;

        saveFullsScreen = 1;
        PlayerPrefs.SetInt("SaveFullScreen", saveFullsScreen);
    }

    public void SetWindowed()
    {
        fullScreenToggleOn.SetActive(true);
        fullSreenToggleOff.SetActive(false);
        Screen.fullScreenMode = FullScreenMode.Windowed;

        saveFullsScreen = 0;
        PlayerPrefs.SetInt("SaveFullScreen", saveFullsScreen);
    }
    #endregion

    #region SpaceBOrMouseClick
    public void SelectSpaceBar()
    {
        audioManager.Play("UI_Click2");
        spaceBarSelected = true;
        leftClickSeleced = false;

        checkMarkSpacebar.SetActive(true);
        checkMarkSpacebarSettings.SetActive(true);
        checkMArkLeftClick.SetActive(false);
        checkMArkLeftClickSettings.SetActive(false);
        crossSpacebar.SetActive(false);
        crossSpacebarSettings.SetActive(false);
        crossLeftClick.SetActive(true);
        crossLeftClickSettings.SetActive(true);
        Image image1 = spaceBarButton.GetComponent<Image>();
        SetAlpha(image1, 1f);
        Image image11 = spaceBarButtonSettings.GetComponent<Image>();
        SetAlpha(image11, 1f);

        Image image2 = leftClickButton.GetComponent<Image>();
        SetAlpha(image2, 0.6f);
        Image image22 = leftClickButtonSettings.GetComponent<Image>();
        SetAlpha(image22, 0.6f);
    }
    public void SelectLeftClick()
    {
        audioManager.Play("UI_Click2");
        leftClickSeleced = true;
        spaceBarSelected = false;

        checkMarkSpacebar.SetActive(false);
        checkMarkSpacebarSettings.SetActive(false);
        checkMArkLeftClick.SetActive(true);
        checkMArkLeftClickSettings.SetActive(true);
        crossSpacebar.SetActive(true);
        crossSpacebarSettings.SetActive(true);
        crossLeftClick.SetActive(false);
        crossLeftClickSettings.SetActive(false);

        Image image1 = leftClickButton.GetComponent<Image>();
        SetAlpha(image1, 1f);
        Image image11 = leftClickButtonSettings.GetComponent<Image>();
        SetAlpha(image11, 1f);

        Image image2 = spaceBarButton.GetComponent<Image>();
        SetAlpha(image2, 0.6f);
        Image image22 = spaceBarButtonSettings.GetComponent<Image>();
        SetAlpha(image22, 0.6f);
    }


    public void PlayGame()
    {
        isInFirstPlayScreen = false;
        Choises.isInMainManu = false;
        continueRunBTN.interactable = true;
        isPlayerPlayingARun = true;
        pressedOkFirstTImePlaying = true;
        audioManager.Play("CircleTranIn");
        firstPlayFrame.GetComponent<Animation>().Play();
        Invoke("SetFalse", 0.45f);
        Choises.isInMainManu = false;
        mainMenuResetBTN.interactable = true;
    }

    public void SetFalse()
    {
        firstPlayPopUp.SetActive(false);
       
    }
    #endregion

    #region Tabs
    public void SettingsTab()
    {
        isInStats = false;
        topText.fontSize = 100;
        AllFramesInactive();
        SetTopText("Settings", settingText.transform, selectedSettingGlow, settingFrame);
    }

    public void AchievementsTab()
    {
        isInStats = false;
        topText.fontSize = 71;
        AllFramesInactive();
        SetTopText("Achievements", achText.transform, selectedSettingGlow, achFrame);
    }

    public void SkinsTab()
    {
        isInStats = false;
        topText.fontSize = 108;
        AllFramesInactive();
        SetTopText("Skins", skinsText.transform, selectedSettingGlow, skinsFrame);
    }

    public static bool isInStats;
    public void StatsTab()
    {
        isInStats = true;
        topText.fontSize = 108;
        AllFramesInactive();
        SetTopText("Statistics", statsText.transform, selectedSettingGlow, statsFrame);
    }

    public void InfoTab()
    {
        isInStats = true;
        topText.fontSize = 108;
        AllFramesInactive();
        SetTopText("Unlocks", infoText.transform, selectedSettingGlow, infoFrame);
    }

    public static bool isInControls;
    public GameObject controlsFrame, blockMovementControls, blockInvinControls, blockChargedBulletControls, blockArenaControls, tabSwitch;
    public GameObject boosterControls, rocketControls, talariaControls;

    public void ControlsTab()
    {
        topText.fontSize = 100;
        AllFramesInactive();
        SetTopText("Controls", controlsText.transform, selectedSettingGlow, controlsFrame);
    }

    public void EndingsTab()
    {
        topText.fontSize = 108;
        AllFramesInactive();
        SetTopText("Endings", endingsText.transform, selectedSettingGlow, endingSettingScreen);
    }

    public void CurrentRunTab()
    {
        topText.fontSize = 80;
        AllFramesInactive();
        SetTopText("Current Run", currentRunText.transform, selectedSettingGlow, currentRunScreen);
    }

    public void SetTopText(string text, Transform selectGlowPos, GameObject selectGlow, GameObject settingScreen)
    {
        settingScreen.SetActive(true);
        topText.text = text;
        selectGlow.transform.position = selectGlowPos.transform.position;
    }

    public void AllFramesInactive()
    {
        audioManager.Play("UI_Click2");
        currentRunScreen.SetActive(false);
        endingSettingScreen.SetActive(false);
        settingFrame.SetActive(false);
        achFrame.SetActive(false);
        skinsFrame.SetActive(false);
        statsFrame.SetActive(false);
        infoFrame.SetActive(false);
        controlsFrame.SetActive(false);
    }
    #endregion

    #region Social Media Links
    public void DiscordButton()
    {
        Application.OpenURL("https://discord.gg/eVBcVJJuBz");
    }
    public void SteamButton()
    {
        Application.OpenURL("https://store.steampowered.com/curator/43674917");
    }

    public void XButton()
    {
        Application.OpenURL("https://twitter.com/Sniceman");
    }
    #endregion


    public void CloseSettings()
    {
        isInStats = false;
        isInSettings = false;
        settingsPopUp.SetActive(false);
        if(Choises.isPaused == false)
        {
            audioManager.Play("UI_Click2");
            if (Choises.isPaused == false)
            {
                if (ButtonClick.isStopTimeAbilityActive == false) { Time.timeScale = 1; }
            }
        }

        SetCursors.hoveringClickableStuff = false;
        Cursor.visible = true;
    }

    public void ResetGame(bool keepDangerbutton)
    {
        audioManager.Play("UI_Click2");
        Choises.isInMainManu = false;
        SetAllStatsBack();
        CheckTimerAndStuff();

        if (keepDangerbutton == false)
        {
            Choises.choseHealthBar = false;
            Choises.regenHealth = false;

            //Movement
            Choises.chooseRocket = false;
            Choises.choseButtonBounceCharge = false;
            Choises.chooseControllableButton = false;
            Choises.movementAbilityAquaried = false;

            currentTime = 0;
            timeMinutes = 0;

            ButtonClick.level = 0;
            levelText.text = "LVL " + ButtonClick.level;
        }
    }

    public TextMeshProUGUI levelText;

    #region ResetGame - Reset Variables

    public Slider pointsSlider;

    public void SetAllStatsBack()
    {
        Choises.pointsLEVEL = 1;
        Choises.idleLEVEL = 0;
        Choises.critLEVEL = 0;
        Choises.pointDropLEVEL = 0;
        Choises.uziLEVEL = 0;
        Choises.pistolLEVEL = 0;
        Choises.shotgunLEVEL = 0;
        Choises.awpLEVEL = 0;
        Choises.crossbowLEVEL = 0;
        Choises.deagleLEVEL = 0;
        Choises.chargedBulletLEVEL = 0;
        Choises.cannonLEVEL = 0;
        Choises.mp4LEVEL = 0;
        Choises.arrosLEVEL = 0;
        Choises.boxingloveLEVEL = 0;
        Choises.stabbyspikeLEVEL = 0;
        Choises.tinySpikeLEVEL = 0;
        Choises.knifeLEVEL = 0;
        Choises.sawBladeLEVEL = 0;
        Choises.swordLEVEL = 0;
        Choises.hammerLEVEL = 0;
        Choises.defenseLEVEL = 0;
        Choises.heartLEVEL = 0;
        Choises.smallShieldLEVEL = 0;
        Choises.bouncyShieldLEVEL = 0;
        Choises.invinLEVEL = 0;
        Choises.stopwatchLEVEL = 0;
        Choises.ritualLEVEL = 0;
        Choises.arenaLEVEL = 0;
        Choises.rerollLEVEL = 0;
        Choises.skullHarvestLEVEL = 0;

        Choises.totalGunsAcquired = 0;
        Cursor.visible = true;
        SetCursors.hoveringClickableStuff = false;

        Choises.arenaUpgradeCount = 0;
        Choises.pointDropBasicPoints = 0;
        Choises.pointDropRarityIncreasePoints = 0;

        healthbarTopRight.SetActive(false);

        MimicEnding.died = false;
        MimicEnding.championsKilled = 0;
        MimicEnding.win = false;

        Choises.maxAssasins = GameData.setmaxAssasins;
        Choises.maxSpeedsters = GameData.setmaxSpeedsters;
        Choises.maxSharpshooters = GameData.setmaxSharpshooters;
        Choises.maxSnipers = GameData.setmaxSnipers;
        Choises.maxHeavyshots = GameData.setmaxHeavyshots;
        Choises.maxBrutes = GameData.setmaxBrutes;
        Choises.maxRagingGunners = GameData.setmaxRagingGunners;
        Choises.maxTitans = GameData.setmaxTitans;

        Choises.totalIdlePoints = 0;

        Choises.firstControlledGun = false;

        Choises.numberOfEnemiesActive = 0;

        Choises.maxBrokenPieces = 0;
        Choises.maxArrowsStuck = 0;
        Choises.maxPointDropOnScreen = 0;

        Choises.smallShieldUpgradeCount = 0;
        Choises.bouncyShieldUpgradeCount = 0;
        Choises.sawBladeUpgradeCount = 0;
        Choises.swordUpgradeCount = 0;
        Choises.stabbySpikeUpgradeCount = 0;

        Choises.choseRitual = false;
        Choises.arenaIncrease = 0;

        Choises.eggPointPerClickChosen = false;
        Choises.eggCritclickChosen = false;
        Choises.eggIdleClickChosen = false;
        Choises.eggDefenseChosen = false;
        Choises.eggBigHeartChosen = false;
        Choises.eggSmallShieldChosen = false;
        Choises.eggBouncyShieldChosen = false;
        Choises.eggPistolChosen = false;
        Choises.eggUziChosen = false;
        Choises.eggShotgunChosen = false;
        Choises.eggAWPChosen = false;
        Choises.eggCrossbowChosen = false;
        Choises.eggDeagleChosen = false;
        Choises.eggCannonChosen = false;
        Choises.eggMP4Chosen = false;
        Choises.eggArenaChosen = false;
        Choises.eggBoxingGloveChosen = false;
        Choises.eggStabbySpikeChosen = false;
        Choises.eggTinySpikeChosen = false;
        Choises.eggKnifeChosen = false;
        Choises.eggSwordChosen = false;
        Choises.eggRitualChosen = false;
        Choises.eggSawBladeChose = false;
        Choises.eggHammerChosen = false;
        Choises.eggArrowChosen = false;
        Choises.eggChagedBulletsChosen = false;
        Choises.eggPointDropChosen = false;
        Choises.eggStopwatchChosen = false;
        Choises.eggInvinChosen = false;
        Choises.eggSkullHarvestChosen = false;
        Choises.eggDiceChose = false;
        Choises.choseUnlimitedPower = false;

        Choises.commonChance = 99;
        Choises.uncommonChance = 95;
        Choises.rareChance = 95;
        Choises.legendaryChance = 95;

        ButtonClick.knifeCount = 0;

        //Abilities aviable should always be 1 less how many are actually aviable. This is because of the ARRAY.
        Choises.commonAbilitiesAviable = 2;
        Choises.unCommonAbilitiesAviable = 2;
        Choises.rareAbilitiesAviable = 6;
        Choises.legendaryAbilitiesAviable = 3;

        Choises.commonAbilitesNotAviable = 26;
        Choises.unCommonAbilitesNotAviable = 8;
        Choises.rareAbilitesNotAviable = 4;
        Choises.legendaryAbilitiesNotAvailable = 7;

        continueRunBTN.interactable = false;
        SpawnEnemies.smallEnemyCount = 0;
        SpawnEnemies.speedsterCount = 0;
        SpawnShootingEnemy.shootingEnemyCount = 0;
        SpawnShootingEnemy.sniperCount = 0;
        SpawnShootingEnemy.ragingGunnerCount = 0;
        SpawnShootingEnemy.heavyShotCount = 0;
        SpawnBigEnemy.bigEnemyCount = 0;
        SpawnBigEnemy.titanCount = 0;

        //Basic Clicking Stats
     
        ButtonClick.pointsGained = 0;
        ButtonClick.pointsNeeded = 20;

        pointsSlider.minValue = 0;
        pointsSlider.value = 0;
        pointsSlider.maxValue = ButtonClick.pointsNeeded;

        ButtonClick.pointsPerClick = 1;
        Choises.critClicksChance = 0f;
        Choises.critClicksBonus = 0;
        Choises.choseIdleClicking = false;
        Choises.choseCritClicks = false;

        //Abilites and reroll
        Choises.numberOfChoises = 3;
        Choises.rerollsAviable = 0;
        Choises.choseReroll = false;

        //Weapons
        Choises.weaponSpotsFilledOut = 0;
        Choises.controlledSpotFilled = 0;
        
        Choises.firstWeaponChosen = false;
        Choises.choseShootSmallBullets = false;
        Choises.chose_Gun1 = false;
        Choises.chose_gun2 = false;
        Choises.choseGunMp4 = false;
        Choises.choseCrossBow = false;
        Choises.chooseHomingBullets = false;
        Choises.choseTrippleShot = false;
        Choises.chooseBigPiercingBulletGun = false;
        Choises.choseButtonCharge = false;
        Choises.choseArrows = false;

        SpawnEnemies.spawnSpeedster = true;
        SpawnEnemies.spawnSmallEnemy = true;
        SpawnShootingEnemy.spawnSharpshooter = true;
        SpawnShootingEnemy.spawnSniper = true;
        SpawnShootingEnemy.spawnHeavyShot = true;
        SpawnShootingEnemy.spawnRagingGunner = true;
        SpawnBigEnemy.spawnBigEnemy = true;
        SpawnBigEnemy.spawnTitan = true;

        //Melee
        Choises.chooseBigSpike = false;
        Choises.chooseSpikes = false;
        Choises.chooseStabbingSpikes = false;
        Choises.choseBoxingGlove = false;
        Choises.chooseSawBlade = false;
        Choises.chooseHammer = false;
        Choises.choseSpinningKnifes = false;

        //Arena
        Choises.choseBouncingBullets = false;
        Choises.arenaSpawnPointChangeX = 0;
        Choises.arenaSpawnPointChangeY = 0;
        Choises.hordeStartCameraSize = 0;
        Choises.arenaIncrease = 0;

        //Enemies spawning
        Choises.firstShootingEnemyChose = false;
        Choises.smallEnemySpawn = false;
        Choises.speedsterSpawn = false;
        Choises.shootingEnemySpawn = false;
        Choises.sniperSpawn = false;
        Choises.heavyShotSpawn = false;
        Choises.ragingGunnerSpawn = false;
        Choises.bigEnemySpawn = false;
        Choises.titanSpawn = false;

        //Health and defense
     
        Choises.chooseHeartCollect = false;
        Choises.choseShield_BounceOff = false;
        Choises.choseSmallShields = false;

        //Other
        Choises.choseDoubleTap = false;
        Choises.choseStopTime = false;
        Choises.choseInvincibility = false;
        Choises.choseSkullHarvest = false;
        Choises.chosePointsDrop = false;

        Choises.spawnMoreSmallEnemiesTimer = GameData.setspawnMoreSmallEnemiesTimer;
        Choises.spawnMoreSpeedsterTimer = GameData.setspawnMoreSpeedsterTimer;
        Choises.spawnMoreSharpshooterTimer = GameData.setspawnMoreSharpshooterTimer;
        Choises.spawnMoreSniperTimer = GameData.setspawnMoreSniperTimer;
        Choises.spawnMoreHeavyShotTimer = GameData.setspawnMoreHeavyShotTimer;
        Choises.spawnMoreRagingGunnerTimer = GameData.setspawnMoreRagingGunnerTimer;
        Choises.spawnMoreBruteTimer = GameData.setspawnMoreBruteTimer;
        Choises.spawnMoreTitanTimer = GameData.setspawnMoreTitanTimer;

        Choises.smallEnemyDamage = GameData.setsmallEnemyDamage;
        Choises.speedsterDamagePerSecond = GameData.setspeedsterDamage;
        Choises.smallEnemyBulletDamage = GameData.setsharpshooterDamage;
        Choises.sniperEnemyBulletDamage = GameData.setsniperDamage;
        Choises.heavyShotDamage = GameData.setheavyShotDamage;
        Choises.raginGunnerMeleeDamage = GameData.setragingGunnerMeleeDamage;
        Choises.raginGunnerBulletDamage = GameData.setragingGunnerRangedDamage;
        Choises.bruteDamage = GameData.setbruteDamage;
        Choises.titanDamage = GameData.settitanDamage;

        Choises.smallEnemyHP = GameData.setsmallEnemyHP;
        Choises.speedsterHP = GameData.setspeedsterHP;
        Choises.sharpshooterHP = GameData.setsharpshooterHP;
        Choises.sniperHP = GameData.setsniperHP;
        Choises.heavyshotHP = GameData.setheavyShotHP;
        Choises.ragingGunnerHP = GameData.setragingGunnerHP;
        Choises.bruteHP = GameData.setbruteHP;
        Choises.titanHP = GameData.settitanHP;

        Choises.smallEnemyPoints = GameData.setsmallEnemyPoints;
        Choises.speedsterPoints = GameData.setspeedsterPoints;
        Choises.shootingEnemyPoints = GameData.setsharpshooterPoints;
        Choises.sniperPoints = GameData.setsniperPoints;
        Choises.heavyShotPoints = GameData.setheavyShotPoints;
        Choises.raginGunnerPoints = GameData.setragingGunnerPoints;
        Choises.bigEnemyPoint = GameData.setbrutePoints;
        Choises.titanPoints = GameData.settitanPoints;

        Choises.smallEnemySpawnTimer = GameData.setsmallEnemySpawnTimer;
        Choises.speedsterSpawnTimer = GameData.setspeedsterSpawnTimer;
        Choises.sharpshooterSpawnTimer = GameData.setsharpshooterSpawnTimer;
        Choises.sniperSpawnTimer = GameData.setsniperSpawnTimer;
        Choises.heavyShotSpawnTiner = GameData.setheavyShotSpawnTiner;
        Choises.ragingGunnerSpawnTimer = GameData.setragingGunnerSpawnTimer;
        Choises.bigEnemySpawnTimer = GameData.setbigEnemySpawnTimer;
        Choises.titanSpawnTimer = GameData.settitanSpawnTimer;

        buttonClickScript.CheckAbilitysActive();
    }
    #endregion



    #region Reset Skull Harvest

    private void OnApplicationQuit()
    {
        if(Choises.isInWinScreen == true || Choises.isInDeathScreen == true)
        {
            ResetSkullHarvestStats();
            dataManager.SaveTheGameData();
        }
    }

    public DataPersistanceManager dataManager;

    public void ResetSkullHarvestStats()
    {
        Choises.skullsConsumedCount = 0;
        Choises.SHmaxHealth = 0;
        Choises.SHregen = 0;
        Choises.SHbigHEarHP = 0;
        Choises.SHsmallShieldHP = 0;
        Choises.SHsmallShieldRecharge = 0;
        Choises.SHbounceHP = 0;
        Choises.SHbouncyRecharge = 0;
        Choises.SHboxingForce = 0;
        Choises.SHstabbyDamage = 0;
        Choises.SHtinySpikeDamage = 0;
        Choises.SHknifeDamage = 0;
        Choises.SHsawBladeDamage = 0;
        Choises.SHsawbladeSpeed = 0;
        Choises.SHswordSpeed = 0;
        Choises.SHswordDamage = 0;
        Choises.SHhammerDamage = 0;
        Choises.SHhammerStunTime = 0;
        Choises.SHinvinTime = 0;
        Choises.SHstopwatchTime = 0;
        Choises.SHpointPerClick = 0;
        Choises.SHcritChance = 0;
        Choises.SHcritIncrease = 0;
        Choises.SHidleClicks = 0;
        Choises.SHuziSpeed = 0;
        Choises.SHuziDamage = 0;
        Choises.SHpistolSpeed = 0;
        Choises.SHPistolDamage = 0;
        Choises.SHshotgunSpeed = 0;
        Choises.SHshotgunDamage = 0;
        Choises.SHawpSpeed = 0;
        Choises.SHawpDamage = 0;
        Choises.SHcrossbowSpeed = 0;
        Choises.SHcrossbowDamage = 0;
        Choises.SHdeagleSpeed = 0;
        Choises.SHdeagleDamage = 0;
        Choises.SHcannonSpeed = 0;
        Choises.SHcannonDamage = 0;
        Choises.SHmp4Speed = 0;
        Choises.SHmp4Damage = 0;
        Choises.SHchargeBulletTime = 0;
        Choises.SHchargeBulletDamage = 0;
        Choises.SHarrowDamage = 0;
        Choises.SHpointDropBasic = 0;
        Choises.SHpointDropRarity = 0;

        //dataManager.SaveGame();
    }
    #endregion

    #region Set Active Object Back to pool

    public GameObject arrowParent;

    public int count;

    public void SetObjectOnScreenBack()
    {
        SetKnifesBack();
        SetBackBoth();
    }

    public void SetOnlyEndingTransitionObjectsBack()
    {
        SetBackBoth();
    }


    public void SetOnlyArrowsBack()
    {
        //Arrow
        GameObject[] arrowObjects = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject arrowObject in arrowObjects)
        {
            // Only return active objects to the object pool
            if (arrowObject.activeSelf)
            {
                arrowObject.transform.SetParent(arrowParent.transform);
                ObjectPool.instance.ReturnArrowFromPool(arrowObject);
            }
        }

        //Crossbow
        GameObject[] crossbowArrowObjects = GameObject.FindGameObjectsWithTag("CrossbowArrow");
        foreach (GameObject crossbowArrowObject in crossbowArrowObjects)
        {
            if (crossbowArrowObject.activeSelf)
            {
                crossbowArrowObject.transform.SetParent(arrowParent.transform);
                ObjectPool.instance.ReturnCrossbowArrowFromPool(crossbowArrowObject);
            }
        }
    }

    public void SetBackBoth()
    {
        //Arrow
        GameObject[] arrowObjects = GameObject.FindGameObjectsWithTag("Arrow");
        foreach (GameObject arrowObject in arrowObjects)
        {
            // Only return active objects to the object pool
            if (arrowObject.activeSelf)
            {
                arrowObject.transform.SetParent(arrowParent.transform);
                ObjectPool.instance.ReturnArrowFromPool(arrowObject);
            }
        }

        //Crossbow
        GameObject[] crossbowArrowObjects = GameObject.FindGameObjectsWithTag("CrossbowArrow");
        foreach (GameObject crossbowArrowObject in crossbowArrowObjects)
        {
            if (crossbowArrowObject.activeSelf)
            {
                crossbowArrowObject.transform.SetParent(arrowParent.transform);
                ObjectPool.instance.ReturnCrossbowArrowFromPool(crossbowArrowObject);
            }
        }

        //Charged Bullets
        GameObject[] chargedbulletObjects = GameObject.FindGameObjectsWithTag("ChargedBullet");
        foreach (GameObject chargedBullets in chargedbulletObjects)
        {
            if (chargedBullets.activeSelf)
            {
                ObjectPool.instance.ReturnChargedBulletFromPool(chargedBullets);
            }
        }

        //Heart
        GameObject[] heartObjects = GameObject.FindGameObjectsWithTag("BigHeart");
        foreach (GameObject heart in heartObjects)
        {
            if (heart.activeSelf)
            {
                ObjectPool.instance.ReturnHeartFromPool(heart);
            }
        }

        //Damage Text
        GameObject[] damageTexts = GameObject.FindGameObjectsWithTag("DamageText");
        foreach (GameObject damage in damageTexts)
        {
            if (damage.activeSelf)
            {
                ObjectPool.instance.ReturnDamageTextFromPool(damage);
            }
        }

        //Point Text
        GameObject[] pointsText = GameObject.FindGameObjectsWithTag("PointText");
        foreach (GameObject point in pointsText)
        {
            if (point.activeSelf)
            {
                ObjectPool.instance.ReturnPointTextFromPool(point);
            }
        }

        //Damage Particle
        GameObject[] particleObjects = GameObject.FindGameObjectsWithTag("ParticleDamaged");
        foreach (GameObject particle in particleObjects)
        {
            if (particle.activeSelf)
            {
                ObjectPool.instance.ReturnEnemyDamagedParticleFromPool(particle);
            }
        }

        //Skulls
        GameObject[] skullsObject = GameObject.FindGameObjectsWithTag("Skulls");
        foreach (GameObject skulls in skullsObject)
        {
            if (skulls.activeSelf)
            {
                ObjectPool.instance.ReturnSkullsFromPool(skulls);
            }
        }

        //Indicators
        GameObject[] idicatorObjects = GameObject.FindGameObjectsWithTag("IndicatorObject");
        foreach (GameObject indicator in idicatorObjects)
        {
            if (indicator.activeSelf)
            {
                ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(indicator);
            }
        }

        //Small Pieces
        GameObject[] smallPiecesObjects = GameObject.FindGameObjectsWithTag("SmallPieces");
        foreach (GameObject smallPieces in smallPiecesObjects)
        {
            if (smallPieces.activeSelf)
            {
                ObjectPool.instance.ReturnEnemySmallPiecesFromPool(smallPieces);
            }
        }

        //Shooting Pieces
        GameObject[] shootingPiecesObjects = GameObject.FindGameObjectsWithTag("RangedPieces");
        foreach (GameObject shootingPieces in shootingPiecesObjects)
        {
            if (shootingPieces.activeSelf)
            {
                ObjectPool.instance.ReturnShootingEnemyPiecesFromPool(shootingPieces);
            }
        }

        //Brute Pieces
        GameObject[] brutePiecesObjects = GameObject.FindGameObjectsWithTag("BrutePieces");
        foreach (GameObject brutePieces in brutePiecesObjects)
        {
            if (brutePieces.activeSelf)
            {
                ObjectPool.instance.ReturnBigPiecesFromPool(brutePieces);
            }
        }

        //Heavyshot Pieces
        GameObject[] heavyshotPiecesObjects = GameObject.FindGameObjectsWithTag("HeavyshotPieces");
        foreach (GameObject heavyshotPieces in heavyshotPiecesObjects)
        {
            if (heavyshotPieces.activeSelf)
            {
                ObjectPool.instance.ReturnHeavyshotPiecesFromPool(heavyshotPieces);
            }
        }

        //Brute Pieces
        GameObject[] titanPiecesObjects = GameObject.FindGameObjectsWithTag("TitanPieces");
        foreach (GameObject titanPieces in titanPiecesObjects)
        {
            if (titanPieces.activeSelf)
            {
                ObjectPool.instance.ReturnTitanPiecesFromPool(titanPieces);
            }
        }

        //Enemy Saw Blade
        GameObject[] sawBladeObjects = GameObject.FindGameObjectsWithTag("EnemySawBlade");
        foreach (GameObject sawBlade in sawBladeObjects)
        {
            if (sawBlade.activeSelf)
            {
                ObjectPool.instance.ReturnEnemySawBladeFromPool(sawBlade);
            }
        }
    }

    public void SetKnifesBack()
    {
        //Knife Objects
        GameObject[] knifeObjects = GameObject.FindGameObjectsWithTag("Knife");
        foreach (GameObject knife in knifeObjects)
        {
            if (knife.activeSelf)
            {
                ObjectPool.instance.ReturnKnifeFromPool(knife);
            }
        }
    }

    #endregion

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadData(GameData data)
    {
        spaceBarSelected = data.spaceBarSelected;
        leftClickSeleced = data.leftClickSeleced;

        totalArrowsHit = data.totalArrowsHit;

        firstRunCompleted = data.firstRunCompleted;

        longestRunMinutes = data.longestRunMinutes;
        longestRunSeconds = data.longestRunSeconds;
        fastestRunMinutes = data.fastestRunMinutes;
        fastestRunSeconds = data.fastestRunSeconds;

        firstTimeDefeatedBoss = data.firstTimeDefeatedBoss;
        firstTimeDefeatedHorde = data.firstTimeDefeatedHorde;
        firstTimeDefeatedChampions = data.firstTimeDefeatedChampions;
        firstTimeDefeatedDangerButton = data.firstTimeDefeatedDangerButton;

        totalButtonClicks = data.totalButtonClicks;
        totalCritClicks = data.totalCritClicks;
        totalIdleClicks = data.totalIdleClicks;
        totalPoints = data.totalPoints;
        totalClickPoints = data.totalClickPoints;
        totalCritPoints = data.totalCritPoints;
        totalEnemyPoints = data.totalEnemyPoints;
        totalPointDropPoints = data.totalPointDropPoints;
        totalEnemiesDefeated = data.totalEnemiesDefeated;
        totalSmallEnemiesDefeated = data.totalSmallEnemiesDefeated;
        totalSpeedstersDefeated = data.totalSpeedstersDefeated;
        totalSharpshootersDefeated = data.totalSharpshootersDefeated;
        totalSnipersDefeated = data.totalSnipersDefeated;
        totalHeavyshotDefeated = data.totalHeavyshotDefeated;
        totalBrutedDefeated = data.totalBrutedDefeated;
        totalRagingGunnerDefeated = data.totalRagingGunnerDefeated;
        totalTitansDefeated = data.totalTitansDefeated;
        totalLevels = data.totalLevels;
        furthestRunLevel = data.furthestRunLevel;
        totalTimePlayedHours = data.totalTimePlayedHours;
        totalTimePlayedMinutes = data.totalTimePlayedMinutes;
        
        endingsCompleted = data.endingsCompleted;
        runsCompleted = data.runsCompleted;
        timesDefeatedBoss = data.timesDefeatedBoss;
        timesDefeatedHorde = data.timesDefeatedHorde;
        timesDefeatedChampions = data.timesDefeatedChampions;
        timesDefeatedDangerButton = data.timesDefeatedDangerButton;
        ritualsEntered = data.ritualsEntered;
        weirdEggUpgrades = data.weirdEggUpgrades;
        totalAbilitiesChosen = data.totalAbilitiesChosen;
        totalCommonAbilitiesChosen = data.totalCommonAbilitiesChosen;
        totalUncommonAbilititesChosen = data.totalUncommonAbilititesChosen;
        totalRareAbilitiesChose = data.totalRareAbilitiesChose;
        totalLegendaryAbilitiesChosen = data.totalLegendaryAbilitiesChosen;
        totalMythicAbilitiesChosen = data.totalMythicAbilitiesChosen;
        timesRerolled = data.timesRerolled;

        currentTime = data.currentTime;
        timeMinutes = data.timeMinutes;
        totalTimeSeconds = data.totalTimeSeconds;
        totalTimeMinutes = data.totalTimeMinutes;
        pressedOkFirstTImePlaying = data.pressedOkFirstTImePlaying;
        isPlayerPlayingARun = data.isPlayerPlayingARun;
    }

    public void SaveData(ref GameData data)
    {
        data.spaceBarSelected = spaceBarSelected;
        data.leftClickSeleced = leftClickSeleced;
        data.totalArrowsHit = totalArrowsHit;

        data.firstRunCompleted = firstRunCompleted;

        data.longestRunMinutes = longestRunMinutes;
        data.longestRunSeconds = longestRunSeconds;
        data.fastestRunMinutes = fastestRunMinutes;
        data.fastestRunSeconds = fastestRunSeconds;

        data.firstTimeDefeatedBoss = firstTimeDefeatedBoss;
        data.firstTimeDefeatedHorde = firstTimeDefeatedHorde;
        data.firstTimeDefeatedChampions = firstTimeDefeatedChampions;
        data.firstTimeDefeatedDangerButton = firstTimeDefeatedDangerButton;

        data.totalButtonClicks = totalButtonClicks;
        data.totalCritClicks = totalCritClicks;
        data.totalIdleClicks = totalIdleClicks;
        data.totalPoints = totalPoints;
        data.totalClickPoints = totalClickPoints;
        data.totalCritPoints = totalCritPoints;
        data.totalEnemyPoints = totalEnemyPoints;
        data.totalPointDropPoints = totalPointDropPoints;
        data.totalEnemiesDefeated = totalEnemiesDefeated;
        data.totalSmallEnemiesDefeated = totalSmallEnemiesDefeated;
        data.totalSpeedstersDefeated = totalSpeedstersDefeated;
        data.totalSharpshootersDefeated = totalSharpshootersDefeated;
        data.totalSnipersDefeated = totalSnipersDefeated;
        data.totalHeavyshotDefeated = totalHeavyshotDefeated;
        data.totalBrutedDefeated = totalBrutedDefeated;
        data.totalRagingGunnerDefeated = totalRagingGunnerDefeated;
        data.totalTitansDefeated = totalTitansDefeated;
        data.totalLevels = totalLevels;
        data.furthestRunLevel = furthestRunLevel;
        data.totalTimePlayedHours = totalTimePlayedHours;
        data.totalTimePlayedMinutes = totalTimePlayedMinutes;
       
        data.endingsCompleted = endingsCompleted;
        data.runsCompleted = runsCompleted;
        data.timesDefeatedBoss = timesDefeatedBoss;
        data.timesDefeatedHorde = timesDefeatedHorde;
        data.timesDefeatedChampions = timesDefeatedChampions;
        data.timesDefeatedDangerButton = timesDefeatedDangerButton;
        data.ritualsEntered = ritualsEntered;
        data.weirdEggUpgrades = weirdEggUpgrades;
        data.totalAbilitiesChosen = totalAbilitiesChosen;
        data.totalCommonAbilitiesChosen = totalCommonAbilitiesChosen;
        data.totalUncommonAbilititesChosen = totalUncommonAbilititesChosen;
        data.totalRareAbilitiesChose = totalRareAbilitiesChose;
        data.totalLegendaryAbilitiesChosen = totalLegendaryAbilitiesChosen;
        data.totalMythicAbilitiesChosen = totalMythicAbilitiesChosen;
        data.timesRerolled = timesRerolled;

        data.currentTime = currentTime;
        data.timeMinutes = timeMinutes;
        data.totalTimeSeconds = totalTimeSeconds;
        data.totalTimeMinutes = totalTimeMinutes;
        data.pressedOkFirstTImePlaying = pressedOkFirstTImePlaying;
        data.isPlayerPlayingARun = isPlayerPlayingARun;
    }
}
