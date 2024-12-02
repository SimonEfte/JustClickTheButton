using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Achievements : MonoBehaviour, IDataPersistence
{
    public static int enemyKillsAchcount, assassinKillAchCount, speedsterKillAchCount, sharpshooterKillAchCount, sniperkillAchCount, heavyshotKillAchCount, brutesKillAchCount, titansKillAchCount, gunnersKillAchCount;
    public static int speedrunnerAchTime;

    public static int buttonClicksAch1Amount, buttonClicksAch2Amount, buttonClicksAch3Amount;
    public static int speedrunnerTimerAchTime;
    public static int reachLevelAch1Amount, reachLevelAch2Amount, reachLevelAch3Amount, reachLevelAch4Amount;
    public static int rerrollAchAmount;
    public static int skullsComsumedAmountACH, pointBlackAchAmount, chooseAbilityAchAmount, totalCritACHAmount;

    public GameObject unlockedSkinFrame, unlockedBackgroundFrame;
    public Animator unlockFrame;

    public GameObject cheapGreenBTN, onlyYellowBTN, discoBTN, lightningBTN, fireBTN, basicGreenBTN, basicPurpleBTN, basicYellowBTN, woodBTN, rockBTN, purpleBTN, blueBTN, simonSaysBTN, smileBTN, enemyBTN, logoBTN;

    public GameObject redStripedBackground, greedFadeBackground, purpleFadeBackground, hexagonBackground, greyWaveBackground, greenVeritcalBackground, pinkFadeBackground, redTileBackground;


    public GameObject cheapGreenLOCK, onlyYellowLOCK, discoLOCK, lightningLOCK, fireLOCK, basicGreenLOCK, basicPurpleLOCK, basicYellowLOCK, woodLOCK, rockLOCK, purpleLOCK, blueLOCK, simonSaysLOCK, smileLOCK, enemyLOCK, logoLOCK;

    public GameObject redStripedLOCK, greedFadeLOCK, purpleFadeLOCK, hexagonLOCK, greyWaveLOCK, greenVeritcalLOCK, pinkFadeLOCK, redTileLOCK;


    public GameObject cheapGreenEXL, onlyYellowEXL, discoEXL, lightningEXL, fireEXL, basicGreenEXL, basicPurpleEXL, basicYellowEXL, woodEXL, rockEXL, purpleEXL, blueEXL, simonSaysEXL, smileEXL, enemyEXL, logoEXL;

    public GameObject redStripedEXL, greedFadeEXL, purpleFadeEXL, hexagonEXL, greyWaveEXL, greenVeritcalEXL, pinkFadeEXL, redTileEXL;

    public GameObject skinsButtonEXL;


    public Button cheapGreenSettingBTN, onlyYellowSettingBTN, discoSettingBTN, lightningSettingBTN, fireSettingBTN, basicGreenSettingBTN, basicPurpleSettingBTN, basicYellowSettingBTN, woodSettingBTN, rockSettingBTN, purpleSettingBTN, blueSettingBTN, simonSaysSettingBTN, smileSettingBTN, enemySettingBTN, logoSettingBTN;

    public Button redStripedSettingBTN, greenFadeSettingBTN, purpleFadeSettingBTN, hexagonSettingBTN, greyWaveSettingBTN, greenVeritcalSettingBTN, pinkFadeSettingBTN, redTileSettingBTN;

    public static bool isBasicYellowBTNUnlocked, isBasicGreenBTNUnlocked, isBasicPurpleBTNUnlocked, isCheapGreenBTNUnlocked, isPureYellowBrnUnlcoked, isDiscoBTNUnlcoked, isEnergyBTNUnlocked, isFireBTNUnlcoked, isWoodenBTNUNlocked, isRockBTNUnlcoked, isPurpleBTNUnlocked, isblueBTNUnlocked, isSimonBTNUnlcoked, isLogoBTNUnlocked, isFunBTNUnlocked, isEnemyBTNUnlocked;

    public static bool isGreenFadeUnlocked, isRedStripedInlocked, isWaveUnlocked, isPinkWaveUnlocked, isPurpleWaveUnlcoked, isRedTilesUnlocked, isGreenStripesUnlocked, isHexagonUnlocked;

    public static bool isUziACHUnlocked, isPistolACHUnlocked, isShotgunACHUnlocked, isTrippledACHUnlocked, isCrossbowACHUnlcoked, isAWPACHUnlocked, isCannonACHUnlocked, isMP4ACHUnlocked, isCritACHUnlcoked, isFunACHUnlockes, isAcquireSkullHarvestACHUnlocked, isAcquireStopwatchACHUnlcoked, isAcquireTalariaACHUnlocked, isAcquireEggACHUnlocked, isAcquireDoubleTapACHUnlocked, isCPSACHUnlocked, isBeatBossACHUnlcockec, isBeatHordeACHUnlockec, isBeatChampionsACHUnlocked, isBeatDangerButtonACHUnlocked, isPointBlankACHUnlocked, isBeatallEndingsAchUnlocked, isConsumeSkullsACHUnlocked, isRerollACHUnlocked, isAllGunsACHUnkocked, isChooseAiblititesACHUnlcoked, isReachLevel1ACHUnlocked, isReachLevel2AchUnlocked, isReachLevel3AchUnlocked, isReachLevel4Unlocked, isDefeatAssassinsACHUnlocked, isDefeatSpeedstersACHUnlocked, isDefeatSharpshootersACHUnlocked, isDefeatSnipersACHUnlocked, isDefeatHeavyshotsACHUnlocked, isDefeatGunnersACHUnlocked, isDefeatBrutesACHUnlocked, isDefeatTitansACHUnlocked, isClickButton1ACHUnlocked, isClickButton2ACHUnlocked, isClickButton3ACHUnlocked, isSpeedrunnerACHUnlocked, isDefeatEnemiesACHUnlocked, isBeatEndingLevel75ACHUnlocked, isAllUncommonACHUnlocked, isAllRareAchUnlocked, isAllLegendaryACHUnlocked, isAllMythicACHUnlocked, isAllAbilitiesACHUnlocked, isAllMeleeACHUnlocked;

    public static int totalAchievements;

    public GameObject uziACH, pistolACH, shotgunACH, trippledACH, crossbowACH, awpACH, cannonACH, mp4ACH, critACH, funACH, acquireSkullHarvestACH, acquireStopwatchACH, acquireTalariaACH, acquireEggACH, acquireDoubleTapACH, beatBossACH, beatHordeACH, beatChampionsACH, beatDangerButtonACH, pointBlankACH, beatAllEndingsACH, consumeSkullsACH, rerollACH, allGunsACH, chooseAbilitiesACH, reachLevel1ACH, reachLevel2ACH, reachLevel3ACH, reachLevel4ACH, defeatAssassinsACH, defeatSpeedstersACH, defeatSharpshootersACH, defeatSnipersACH, defeatHeavyshotsACH, defeatGunnersACH, defeatBrutesACH, defeatTitansACH, clickButton1ACH, clickButton2ACH, clickButton3ACH, speedrunnerACH, defeatEnemiesACH, beatEndingLevel75ACH, allUncommonACH, allRareACH, allLegendaryACH, allMythicACH, allAbilitiesACH, allMeleeACH, cpsACH;

    public TextMeshProUGUI achievementCountTotal;
    public AudioManager audioManager;
    public void Awake()
    {
        //AchClear("");

        #region All ach and unlock amount
        totalCritACHAmount = 1000;
        speedrunnerAchTime = 20;

        chooseAbilityAchAmount = 250;

        pointBlackAchAmount = 1000;
        skullsComsumedAmountACH = 1000;
        rerrollAchAmount = 100;

        reachLevelAch1Amount = 30;
        reachLevelAch2Amount = 60;
        reachLevelAch3Amount = 90;
        reachLevelAch4Amount = 120;

        speedrunnerTimerAchTime = 20;

        buttonClicksAch1Amount = 100;
        buttonClicksAch2Amount = 5000;
        buttonClicksAch3Amount = 50000;

        enemyKillsAchcount = 10000;

        assassinKillAchCount = 5000;
        speedsterKillAchCount = 3000;
        sharpshooterKillAchCount = 500;
        sniperkillAchCount = 500;
        heavyshotKillAchCount = 300;
        gunnersKillAchCount = 250;
        brutesKillAchCount = 150;
        titansKillAchCount = 100;
        #endregion
    }

    public void Start()
    {
        StartCoroutine(wait());
    }

    public bool unlockSystemIsOn;

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(1);
        unlockSystemIsOn = true;
        achievementCountTotal.text = $"{totalAchievements}/50";

        #region load all skin unlocks
        if (isBasicYellowBTNUnlocked == false) { basicYellowSettingBTN.interactable = false; basicYellowLOCK.SetActive(true); }
        if (isBasicYellowBTNUnlocked == true) { basicYellowSettingBTN.interactable = true; basicYellowLOCK.SetActive(false); }

        if (isBasicGreenBTNUnlocked == false) { basicGreenSettingBTN.interactable = false; basicGreenLOCK.SetActive(true); }
        if (isBasicGreenBTNUnlocked == true) { basicGreenSettingBTN.interactable = true; basicGreenLOCK.SetActive(false); }

        if (isBasicPurpleBTNUnlocked == false) { basicPurpleSettingBTN.interactable = false; basicPurpleLOCK.SetActive(true); }
        if (isBasicPurpleBTNUnlocked == true) { basicPurpleSettingBTN.interactable = true; basicPurpleLOCK.SetActive(false); }

        if (isCheapGreenBTNUnlocked == false) { cheapGreenSettingBTN.interactable = false; cheapGreenLOCK.SetActive(true); }
        if (isCheapGreenBTNUnlocked == true) { cheapGreenSettingBTN.interactable = true; cheapGreenLOCK.SetActive(false); }

        if (isPureYellowBrnUnlcoked == false) { onlyYellowSettingBTN.interactable = false; onlyYellowLOCK.SetActive(true); }
        if (isPureYellowBrnUnlcoked == true) { onlyYellowSettingBTN.interactable = true; onlyYellowLOCK.SetActive(false); }

        if (isDiscoBTNUnlcoked == false) { discoSettingBTN.interactable = false; discoLOCK.SetActive(true); }
        if (isDiscoBTNUnlcoked == true) { discoSettingBTN.interactable = true; discoLOCK.SetActive(false); }

        if (isEnergyBTNUnlocked == false) { lightningSettingBTN.interactable = false; lightningLOCK.SetActive(true); }
        if (isEnergyBTNUnlocked == true) { lightningSettingBTN.interactable = true; lightningLOCK.SetActive(false); }

        if (isFireBTNUnlcoked == false) { fireSettingBTN.interactable = false; fireLOCK.SetActive(true); }
        if (isFireBTNUnlcoked == true) { fireSettingBTN.interactable = true; fireLOCK.SetActive(false); }

        if (isWoodenBTNUNlocked == false) { woodSettingBTN.interactable = false; woodLOCK.SetActive(true); }
        if (isWoodenBTNUNlocked == true) { woodSettingBTN.interactable = true; woodLOCK.SetActive(false); }

        if (isRockBTNUnlcoked == false) { rockSettingBTN.interactable = false; rockLOCK.SetActive(true); }
        if (isRockBTNUnlcoked == true) { rockSettingBTN.interactable = true; rockLOCK.SetActive(false); }

        if (isPurpleBTNUnlocked == false) { purpleSettingBTN.interactable = false; purpleLOCK.SetActive(true); }
        if (isPurpleBTNUnlocked == true) { purpleSettingBTN.interactable = true; purpleLOCK.SetActive(false); }

        if (isblueBTNUnlocked == false) { blueSettingBTN.interactable = false; blueLOCK.SetActive(true); }
        if (isblueBTNUnlocked == true) { blueSettingBTN.interactable = true; blueLOCK.SetActive(false); }

        if (isSimonBTNUnlcoked == false) { simonSaysSettingBTN.interactable = false; simonSaysLOCK.SetActive(true); }
        if (isSimonBTNUnlcoked == true) { simonSaysSettingBTN.interactable = true; simonSaysLOCK.SetActive(false); }

        if (isLogoBTNUnlocked == false) { logoSettingBTN.interactable = false; logoLOCK.SetActive(true); }
        if (isLogoBTNUnlocked == true) { logoSettingBTN.interactable = true; logoLOCK.SetActive(false); }

        if (isFunBTNUnlocked == false) { smileSettingBTN.interactable = false; smileLOCK.SetActive(true); }
        if (isFunBTNUnlocked == true) { smileSettingBTN.interactable = true; smileLOCK.SetActive(false); }

        if (isEnemyBTNUnlocked == false) { enemySettingBTN.interactable = false; enemyLOCK.SetActive(true); }
        if (isEnemyBTNUnlocked == true) { enemySettingBTN.interactable = true; enemyLOCK.SetActive(false); }


        if (isGreenFadeUnlocked == false) { greenFadeSettingBTN.interactable = false; greedFadeLOCK.SetActive(true); }
        if (isGreenFadeUnlocked == true) { greenFadeSettingBTN.interactable = true; greedFadeLOCK.SetActive(false); }

        if (isRedStripedInlocked == false) { redStripedSettingBTN.interactable = false; redStripedLOCK.SetActive(true); }
        if (isRedStripedInlocked == true) { redStripedSettingBTN.interactable = true; redStripedLOCK.SetActive(false); }

        if (isWaveUnlocked == false) { greyWaveSettingBTN.interactable = false; greyWaveLOCK.SetActive(true); }
        if (isWaveUnlocked == true) { greyWaveSettingBTN.interactable = true; greyWaveLOCK.SetActive(false); }

        if (isPinkWaveUnlocked == false) { pinkFadeSettingBTN.interactable = false; pinkFadeLOCK.SetActive(true); }
        if (isPinkWaveUnlocked == true) { pinkFadeSettingBTN.interactable = true; pinkFadeLOCK.SetActive(false); }

        if (isPurpleWaveUnlcoked == false) { purpleFadeSettingBTN.interactable = false; purpleFadeLOCK.SetActive(true); }
        if (isPurpleWaveUnlcoked == true) { purpleFadeSettingBTN.interactable = true; purpleFadeLOCK.SetActive(false); }

        if (isRedTilesUnlocked == false) { redTileSettingBTN.interactable = false; redTileLOCK.SetActive(true); }
        if (isRedTilesUnlocked == true) { redTileSettingBTN.interactable = true; redTileLOCK.SetActive(false); }

        if (isGreenStripesUnlocked == false) { greenVeritcalSettingBTN.interactable = false; greenVeritcalLOCK.SetActive(true); }
        if (isGreenStripesUnlocked == true) { greenVeritcalSettingBTN.interactable = true; greenVeritcalLOCK.SetActive(false); }

        if (isHexagonUnlocked == false) { hexagonSettingBTN.interactable = false; hexagonLOCK.SetActive(true); }
        if (isHexagonUnlocked == true) { hexagonSettingBTN.interactable = true; hexagonLOCK.SetActive(false); }

        #endregion

        #region load all achievmeents
        if (isUziACHUnlocked == true) { uziACH.SetActive(false); }
        if (isPistolACHUnlocked == true) { pistolACH.SetActive(false); }
        if (isShotgunACHUnlocked == true) { shotgunACH.SetActive(false); }
        if (isTrippledACHUnlocked == true) { trippledACH.SetActive(false); }
        if (isCrossbowACHUnlcoked == true) { crossbowACH.SetActive(false); }
        if (isAWPACHUnlocked == true) { awpACH.SetActive(false); }
        if (isCannonACHUnlocked == true) { cannonACH.SetActive(false); }
        if (isMP4ACHUnlocked == true) { mp4ACH.SetActive(false); }
        if (isCritACHUnlcoked == true) { critACH.SetActive(false); }
        if (isFunACHUnlockes == true) { funACH.SetActive(false); }
        if (isAcquireSkullHarvestACHUnlocked == true) { acquireSkullHarvestACH.SetActive(false); }
        if (isAcquireStopwatchACHUnlcoked == true) { acquireStopwatchACH.SetActive(false); }
        if (isAcquireTalariaACHUnlocked == true) { acquireTalariaACH.SetActive(false); }
        if (isAcquireEggACHUnlocked == true) { acquireEggACH.SetActive(false); }
        if (isAcquireDoubleTapACHUnlocked == true) { acquireDoubleTapACH.SetActive(false); }
        if (isCPSACHUnlocked == true) { cpsACH.SetActive(false); }
        if (isBeatBossACHUnlcockec == true) { beatBossACH.SetActive(false); }
        if (isBeatHordeACHUnlockec == true) { beatHordeACH.SetActive(false); }
        if (isBeatChampionsACHUnlocked == true) { beatChampionsACH.SetActive(false); }
        if (isBeatDangerButtonACHUnlocked == true) { beatDangerButtonACH.SetActive(false); }
        if (isPointBlankACHUnlocked == true) { pointBlankACH.SetActive(false); }
        if (isBeatallEndingsAchUnlocked == true) { beatAllEndingsACH.SetActive(false); }
        if (isConsumeSkullsACHUnlocked == true) { consumeSkullsACH.SetActive(false); }
        if (isRerollACHUnlocked == true) { rerollACH.SetActive(false); }
        if (isAllGunsACHUnkocked == true) { allGunsACH.SetActive(false); }
        if (isChooseAiblititesACHUnlcoked == true) { chooseAbilitiesACH.SetActive(false); }
        if (isReachLevel1ACHUnlocked == true) { reachLevel1ACH.SetActive(false); }
        if (isReachLevel2AchUnlocked == true) { reachLevel2ACH.SetActive(false); }
        if (isReachLevel3AchUnlocked == true) { reachLevel3ACH.SetActive(false); }
        if (isReachLevel4Unlocked == true) { reachLevel4ACH.SetActive(false); }
        if (isDefeatAssassinsACHUnlocked == true) { defeatAssassinsACH.SetActive(false); }
        if (isDefeatSpeedstersACHUnlocked == true) { defeatSpeedstersACH.SetActive(false); }
        if (isDefeatSharpshootersACHUnlocked == true) { defeatSharpshootersACH.SetActive(false); }
        if (isDefeatSnipersACHUnlocked == true) { defeatSnipersACH.SetActive(false); }
        if (isDefeatHeavyshotsACHUnlocked == true) { defeatHeavyshotsACH.SetActive(false); }
        if (isDefeatGunnersACHUnlocked == true) { defeatGunnersACH.SetActive(false); }
        if (isDefeatBrutesACHUnlocked == true) { defeatBrutesACH.SetActive(false); }
        if (isDefeatTitansACHUnlocked == true) { defeatTitansACH.SetActive(false); }
        if (isClickButton1ACHUnlocked == true) { clickButton1ACH.SetActive(false); }
        if (isClickButton2ACHUnlocked == true) { clickButton2ACH.SetActive(false); }
        if (isClickButton3ACHUnlocked == true) { clickButton3ACH.SetActive(false); }
        if (isSpeedrunnerACHUnlocked == true) { speedrunnerACH.SetActive(false); }
        if (isDefeatEnemiesACHUnlocked == true) { defeatEnemiesACH.SetActive(false); }
        if (isBeatEndingLevel75ACHUnlocked == true) { beatEndingLevel75ACH.SetActive(false); }
        if (isAllUncommonACHUnlocked == true) { allUncommonACH.SetActive(false); }
        if (isAllRareAchUnlocked == true) { allRareACH.SetActive(false); }
        if (isAllLegendaryACHUnlocked == true) { allLegendaryACH.SetActive(false); }
        if (isAllMythicACHUnlocked == true) { allMythicACH.SetActive(false); }
        if (isAllAbilitiesACHUnlocked == true) { allAbilitiesACH.SetActive(false); }
        if (isAllMeleeACHUnlocked == true) { allMeleeACH.SetActive(false); }
        #endregion
    }

    void Update()
    {
        if (unlockSystemIsOn == true)
        {
            #region BNTS
            //Basic Yellow
            if (ButtonClick.level >= reachLevelAch1Amount && isBasicYellowBTNUnlocked == false)
            {
                basicYellowLOCK.SetActive(false); basicYellowEXL.SetActive(true);
                UnlockSkinOrBackground(false, basicYellowBTN, null);
                isBasicYellowBTNUnlocked = true;
                basicYellowSettingBTN.interactable = true;
            }

            //Basic Purple
            if (ButtonClick.level >= reachLevelAch2Amount && isBasicPurpleBTNUnlocked == false)
            {
                basicPurpleLOCK.SetActive(false); basicPurpleEXL.SetActive(true);
                UnlockSkinOrBackground(false, basicPurpleBTN, null);
                isBasicPurpleBTNUnlocked = true;
                basicPurpleSettingBTN.interactable = true;
            }

            //Basic Green
            if (ButtonClick.level >= reachLevelAch3Amount && isBasicGreenBTNUnlocked == false)
            {
                basicGreenLOCK.SetActive(false); basicGreenEXL.SetActive(true);
                UnlockSkinOrBackground(false, basicGreenBTN, null);
                isBasicGreenBTNUnlocked = true;
                basicGreenSettingBTN.interactable = true;
            }

            //cheap Green
            if (SettingsOptions.totalCritClicks >= totalCritACHAmount && isCheapGreenBTNUnlocked == false)
            {
                cheapGreenLOCK.SetActive(false); cheapGreenEXL.SetActive(true);
                UnlockSkinOrBackground(false, cheapGreenBTN, null);
                isCheapGreenBTNUnlocked = true;
                cheapGreenSettingBTN.interactable = true;
            }

            //Pure Yellow
            if (SettingsOptions.totalTitansDefeated >= titansKillAchCount && isPureYellowBrnUnlcoked == false)
            {
                onlyYellowLOCK.SetActive(false); onlyYellowEXL.SetActive(true);
                UnlockSkinOrBackground(false, onlyYellowBTN, null);
                isPureYellowBrnUnlcoked = true;
                onlyYellowSettingBTN.interactable = true;
            }

            //Disco
            if (Choises.timeBetweenClicks <= 0.166f && isDiscoBTNUnlcoked == false)
            {
                discoLOCK.SetActive(false); discoEXL.SetActive(true);
                UnlockSkinOrBackground(false, discoBTN, null);
                isDiscoBTNUnlcoked = true;
                discoSettingBTN.interactable = true;
            }

            //Energy
            if (Choises.numberOfMeleeCurrentRun == 7 && isEnergyBTNUnlocked == false)
            {
                lightningLOCK.SetActive(false); lightningEXL.SetActive(true);
                UnlockSkinOrBackground(false, lightningBTN, null);
                isEnergyBTNUnlocked = true;
                lightningSettingBTN.interactable = true;
            }

            //Fire
            if (SettingsOptions.totalEnemiesDefeated >= enemyKillsAchcount && isFireBTNUnlcoked == false)
            {
                fireLOCK.SetActive(false); fireEXL.SetActive(true);
                UnlockSkinOrBackground(false, fireBTN, null);
                isFireBTNUnlcoked = true;
                fireSettingBTN.interactable = true;
            }

            //Wooden
            if (SettingsOptions.totalButtonClicks >= buttonClicksAch1Amount && isWoodenBTNUNlocked == false)
            {
                woodLOCK.SetActive(false); woodEXL.SetActive(true);
                UnlockSkinOrBackground(false, woodBTN, null);
                isWoodenBTNUNlocked = true;
                woodSettingBTN.interactable = true;
            }

            //Rock
            if (SettingsOptions.totalButtonClicks >= buttonClicksAch2Amount && isRockBTNUnlcoked == false)
            {
                rockLOCK.SetActive(false); rockEXL.SetActive(true);
                UnlockSkinOrBackground(false, rockBTN, null);
                isRockBTNUnlcoked = true;
                rockSettingBTN.interactable = true;
            }

            //fun
            if (SettingsOptions.totalButtonClicks >= buttonClicksAch3Amount && isFunBTNUnlocked == false)
            {
                smileLOCK.SetActive(false); smileEXL.SetActive(true);
                UnlockSkinOrBackground(false, smileBTN, null);
                isFunBTNUnlocked = true;
                smileSettingBTN.interactable = true;
            }

            //Purple
            if (Choises.beatlEndingAtLevel75 == true && isPurpleBTNUnlocked == false)
            {
                purpleLOCK.SetActive(false); purpleEXL.SetActive(true);
                UnlockSkinOrBackground(false, purpleBTN, null);
                isPurpleBTNUnlocked = true;
                purpleSettingBTN.interactable = true;
            }

            //Blue
            if (SettingsOptions.totalAbilitiesChosen >= chooseAbilityAchAmount && isblueBTNUnlocked == false)
            {
                blueLOCK.SetActive(false); blueEXL.SetActive(true);
                UnlockSkinOrBackground(false, blueBTN, null);
                isblueBTNUnlocked = true;
                blueSettingBTN.interactable = true;
            }

            //Simon Says
            if (isSimonBTNUnlcoked == false && Choises.pointDropFirst == true && Choises.doubletapFirst == true && Choises.uziFirst == true && Choises.pistolFirst == true && Choises.shotgunFirst == true && Choises.awpFirst == true && Choises.deagleFirst == true && Choises.chargedBulletFirst == true && Choises.crossbowFirst == true && Choises.cannonFirst == true && Choises.mp4First == true && Choises.arrosFirst == true && Choises.boxinggloveFirst == true && Choises.stabbyspikeFirst == true && Choises.tinySpikeFirst == true && Choises.knifeFirst == true && Choises.sawBladeFirst == true && Choises.swordFirst == true && Choises.hammerFirst == true && Choises.heartFirst == true && Choises.smallShieldFirst == true && Choises.defenseFirst == true && Choises.bouncyShieldFirst == true && Choises.invinFirst == true && Choises.stopwatchFirst == true && Choises.boosterFirst == true && Choises.rocketFirst == true && Choises.talariaFirst == true && Choises.random2First == true && Choises.random3First == true && Choises.random5First == true && Choises.ritualFirst == true && Choises.eggFirst == true && Choises.arenaFirst == true && Choises.abiltites4XFirst == true && Choises.rerollRareFirst == true && Choises.abilities5XFirst == true && Choises.rerollLegendaryFirst == true && Choises.skullHarvestFirst == true)
            {
                simonSaysLOCK.SetActive(false); simonSaysEXL.SetActive(true);
                UnlockSkinOrBackground(false, simonSaysBTN, null);
                isSimonBTNUnlcoked = true;
                simonSaysSettingBTN.interactable = true;
            }

            //Logo 
            if (SettingsOptions.endingsCompleted > 0 && isLogoBTNUnlocked == false)
            {
                logoLOCK.SetActive(false); logoEXL.SetActive(true);
                UnlockSkinOrBackground(false, logoBTN, null);
                isLogoBTNUnlocked = true;
                logoSettingBTN.interactable = true;
            }

            //Enemy 
            if (SettingsOptions.endingsCompleted > 3 && isEnemyBTNUnlocked == false)
            {
                enemyLOCK.SetActive(false); enemyEXL.SetActive(true);
                UnlockSkinOrBackground(false, enemyBTN, null);
                isEnemyBTNUnlocked = true;
                enemySettingBTN.interactable = true;
            }
            #endregion

            #region background
            //Green Fade
            if ((Choises.chose_Gun1 == true || Choises.choseShootSmallBullets == true) && isGreenFadeUnlocked == false)
            {
                greedFadeLOCK.SetActive(false); greedFadeEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, greedFadeBackground);
                isGreenFadeUnlocked = true;
                greenFadeSettingBTN.interactable = true;
            }

            //Red Stripes 
            if (Choises.doubletapFirst == true && Choises.stopwatchFirst == true && Choises.talariaFirst && Choises.eggFirst == true && Choises.skullHarvestFirst == true && isRedStripedInlocked == false)
            {
                redStripedLOCK.SetActive(false); redStripedEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, redStripedBackground);
                isRedStripedInlocked = true;
                redStripedSettingBTN.interactable = true;
            }

            //Wave
            if (SettingsOptions.totalBrutedDefeated >= brutesKillAchCount && isWaveUnlocked == false)
            {
                greyWaveLOCK.SetActive(false); greyWaveEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, greyWaveBackground);
                isWaveUnlocked = true;
                greyWaveSettingBTN.interactable = true;
            }

            //Pink Fade
            if (Choises.shotgunFirst == true && Choises.awpFirst == true && Choises.crossbowFirst == true && Choises.deagleFirst == true && Choises.chargedBulletFirst  == true && Choises.sawBladeFirst == true && Choises.bouncyShieldFirst == true && Choises.boosterFirst
                == true && Choises.random3First == true && Choises.abiltites4XFirst == true && Choises.rerollRareFirst == true && isPinkWaveUnlocked == false)
            {
                pinkFadeLOCK.SetActive(false); pinkFadeEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, pinkFadeBackground);
                isPinkWaveUnlocked = true;
                pinkFadeSettingBTN.interactable = true;
            }

            //Purple Fade
            if (Choises.cannonFirst == true && Choises.mp4First == true && Choises.arrosFirst == true && Choises.swordFirst == true && Choises.hammerFirst == true && Choises.invinFirst == true && Choises.rocketFirst == true && Choises.random5First == true && Choises.ritualFirst == true && Choises.abilities5XFirst == true && Choises.rerollLegendaryFirst && isPurpleWaveUnlcoked == false)
            {
                purpleFadeLOCK.SetActive(false); purpleFadeEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, purpleFadeBackground);
                isPurpleWaveUnlcoked = true;
                purpleFadeSettingBTN.interactable = true;
            }

            if (ButtonClick.level >= reachLevelAch4Amount && isRedTilesUnlocked == false)
            {
                redTileLOCK.SetActive(false); redTileEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, redTileBackground);
                isRedTilesUnlocked = true;
                redTileSettingBTN.interactable = true;
            }

            if (Choises.numberOfGunsCurrentRun == 8 && isGreenStripesUnlocked == false)
            {
                greenVeritcalLOCK.SetActive(false); greenVeritcalEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, greenVeritcalBackground);
                isGreenStripesUnlocked = true;
                greenVeritcalSettingBTN.interactable = true;
            }

            if (Choises.chooseControllableButton == true && isHexagonUnlocked == false)
            {
                hexagonLOCK.SetActive(false); hexagonEXL.SetActive(true);
                UnlockSkinOrBackground(true, null, hexagonBackground);
                isHexagonUnlocked = true;
                hexagonSettingBTN.interactable = true;
            }
            #endregion

            #region  Achievements
            //Acquire guns ACH
            if (Choises.choseShootSmallBullets == true && isUziACHUnlocked == false) 
            { 
                AchTrigger("ach_uzi"); isUziACHUnlocked = true; uziACH.SetActive(false); AchIncrease();
            }
            if (Choises.chose_Gun1 == true && isPistolACHUnlocked == false)
            { 
                AchTrigger("ach_pistol"); isPistolACHUnlocked = true; pistolACH.SetActive(false); AchIncrease();
            }
            if (Choises.chose_gun2 == true && isShotgunACHUnlocked == false) 
            { 
                AchTrigger("ach_shotgun"); isShotgunACHUnlocked = true; shotgunACH.SetActive(false); AchIncrease();
            }
            if (Choises.choseTrippleShot == true && isTrippledACHUnlocked == false)
            {
                AchTrigger("ach_tripple"); isTrippledACHUnlocked = true;  trippledACH.SetActive(false); AchIncrease();
            }
            if (Choises.choseCrossBow == true && isCrossbowACHUnlcoked == false) 
            {
                AchTrigger("ach_crossbow"); isCrossbowACHUnlcoked = true; crossbowACH.SetActive(false); AchIncrease();
            }
            if (Choises.chooseHomingBullets == true && isAWPACHUnlocked == false) 
            {
                AchTrigger("ach_awp"); isAWPACHUnlocked = true; awpACH.SetActive(false); AchIncrease();
            }
            if (Choises.chooseBigPiercingBulletGun == true && isCannonACHUnlocked == false)
            {
                AchTrigger("ach_cannon"); isCannonACHUnlocked = true; cannonACH.SetActive(false); AchIncrease();
            }
            if (Choises.choseGunMp4 == true && isMP4ACHUnlocked == false) 
            { 
                AchTrigger("ach_mp4"); isMP4ACHUnlocked = true; mp4ACH.SetActive(false); AchIncrease();
            }


            if (Setting.isRedTilesEquipped == true && Setting.isFunBtnEquipped == true && isFunACHUnlockes == false)
            {
                AchTrigger("ach_fun"); isFunACHUnlockes = true; funACH.SetActive(false); AchIncrease();
            }

            //Mythic Abilities
            if (Choises.choseSkullHarvest == true && isAcquireSkullHarvestACHUnlocked == false)
            {
                AchTrigger("ach_skullharvest"); isAcquireSkullHarvestACHUnlocked = true; acquireSkullHarvestACH.SetActive(false); AchIncrease();
            }
            if (Choises.chooseControllableButton == true && isAcquireTalariaACHUnlocked == false)
            {
                AchTrigger("ach_talaria"); isAcquireTalariaACHUnlocked = true; acquireTalariaACH.SetActive(false); AchIncrease();
            }
            if (Choises.choseStopTime == true && isAcquireStopwatchACHUnlcoked == false)
            {
                AchTrigger("ach_stopwatch"); isAcquireStopwatchACHUnlcoked = true; acquireStopwatchACH.SetActive(false); AchIncrease();
            }
            if (Choises.choseUnlimitedPower == true && isAcquireEggACHUnlocked == false)
            {
                AchTrigger("ach_egg"); isAcquireEggACHUnlocked = true; acquireEggACH.SetActive(false); AchIncrease();
            }
            if (Choises.choseDoubleTap == true && isAcquireDoubleTapACHUnlocked == false)
            {
                AchTrigger("ach_doubletap"); isAcquireDoubleTapACHUnlocked = true; acquireDoubleTapACH.SetActive(false); AchIncrease();
            }

            if (Choises.timeBetweenClicks <= 0.166f && isCPSACHUnlocked == false)
            {
                AchTrigger("ach_autoClick"); isCPSACHUnlocked = true; cpsACH.SetActive(false); AchIncrease();
            }

            if (SettingsOptions.totalCritClicks >= totalCritACHAmount && isCritACHUnlcoked == false)
            {
                AchTrigger("ach_crit100"); isCritACHUnlcoked = true; critACH.SetActive(false); AchIncrease();
            }

            //endings
            if (SettingsOptions.firstTimeDefeatedBoss == true && isBeatBossACHUnlcockec == false)
            {
                AchTrigger("ach_boss"); isBeatBossACHUnlcockec = true; beatBossACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.firstTimeDefeatedHorde == true && isBeatHordeACHUnlockec == false)
            {
                AchTrigger("ach_horde"); isBeatHordeACHUnlockec = true; beatHordeACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.firstTimeDefeatedChampions == true && isBeatChampionsACHUnlocked == false)
            {
                AchTrigger("ach_champion"); isBeatChampionsACHUnlocked = true; beatChampionsACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.firstTimeDefeatedDangerButton == true && isBeatDangerButtonACHUnlocked == false)
            {
                AchTrigger("ach_danger"); isBeatDangerButtonACHUnlocked = true; beatDangerButtonACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.endingsCompleted > 3 && isBeatallEndingsAchUnlocked == false)
            {
                AchTrigger("ach_allendings"); isBeatallEndingsAchUnlocked = true; beatAllEndingsACH.SetActive(false); AchIncrease();
            }
            if (Choises.beatSpeedrunner == true && isSpeedrunnerACHUnlocked == false)
            {
                AchTrigger("ach_timer"); isSpeedrunnerACHUnlocked = true; speedrunnerACH.SetActive(false); AchIncrease();
            }
            if (Choises.beatlEndingAtLevel75 == true && isBeatEndingLevel75ACHUnlocked == false)
            {
                AchTrigger("ach_level50beat"); isBeatEndingLevel75ACHUnlocked = true; beatEndingLevel75ACH.SetActive(false); AchIncrease();
            }

            if (SettingsOptions.timesRerolled >= rerrollAchAmount && isRerollACHUnlocked == false)
            {
                AchTrigger("ach_reroll100"); isRerollACHUnlocked = true; rerollACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalArrowsHit >= 1000 && isPointBlankACHUnlocked == false)
            {
                AchTrigger("ach_arrowhit"); isPointBlankACHUnlocked = true; pointBlankACH.SetActive(false); AchIncrease();
            }
            if (Choises.skullsConsumedCount >= skullsComsumedAmountACH && isConsumeSkullsACHUnlocked == false)
            {
                AchTrigger("ach_consume1000"); isConsumeSkullsACHUnlocked = true; consumeSkullsACH.SetActive(false); AchIncrease();
            }
            if (Choises.numberOfGunsCurrentRun == 8 && isAllGunsACHUnkocked == false)
            {
                AchTrigger("ach_allguns"); isAllGunsACHUnkocked = true; allGunsACH.SetActive(false); AchIncrease();
            }
            if (Choises.numberOfMeleeCurrentRun == 7 && isAllMeleeACHUnlocked == false)
            {
                AchTrigger("ach_allmelee"); isAllMeleeACHUnlocked = true; allMeleeACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalAbilitiesChosen >= chooseAbilityAchAmount && isChooseAiblititesACHUnlcoked == false)
            {
                AchTrigger("ach_250abilitites"); isChooseAiblititesACHUnlcoked = true; chooseAbilitiesACH.SetActive(false); AchIncrease();
            }

            //Level
            if (ButtonClick.level >= reachLevelAch1Amount && isReachLevel1ACHUnlocked == false)
            {
                AchTrigger("ach_level25"); isReachLevel1ACHUnlocked = true; reachLevel1ACH.SetActive(false); AchIncrease();
            }
            if (ButtonClick.level >= reachLevelAch2Amount && isReachLevel2AchUnlocked == false)
            {
                AchTrigger("ach_level50"); isReachLevel2AchUnlocked = true; reachLevel2ACH.SetActive(false); AchIncrease();
            }
            if (ButtonClick.level >= reachLevelAch3Amount && isReachLevel3AchUnlocked == false)
            {
                AchTrigger("ach_level75"); isReachLevel3AchUnlocked = true; reachLevel3ACH.SetActive(false); AchIncrease();
            }
            if (ButtonClick.level >= reachLevelAch4Amount && isReachLevel4Unlocked == false)
            {
                AchTrigger("ach_level100"); isReachLevel4Unlocked = true; reachLevel4ACH.SetActive(false); AchIncrease();
            }

            //Enemies Defeated
            if (SettingsOptions.totalSmallEnemiesDefeated >= assassinKillAchCount && isDefeatAssassinsACHUnlocked == false)
            {
                AchTrigger("ach_defeatAssassins"); isDefeatAssassinsACHUnlocked = true; defeatAssassinsACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalSpeedstersDefeated >= speedsterKillAchCount && isDefeatSpeedstersACHUnlocked == false)
            {
                AchTrigger("ach_defeatSpeedsters"); isDefeatSpeedstersACHUnlocked = true; defeatSpeedstersACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalSharpshootersDefeated >= sharpshooterKillAchCount && isDefeatSharpshootersACHUnlocked == false)
            {
                AchTrigger("ach_defeatSharpshooters"); isDefeatSharpshootersACHUnlocked = true; defeatSharpshootersACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalSnipersDefeated >= sniperkillAchCount && isDefeatSnipersACHUnlocked == false)
            {
                AchTrigger("ach_defeatSnipers"); isDefeatSnipersACHUnlocked = true; defeatSnipersACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalHeavyshotDefeated >= heavyshotKillAchCount && isDefeatHeavyshotsACHUnlocked == false)
            {
                AchTrigger("ach_defeatHeavyshots"); isDefeatHeavyshotsACHUnlocked = true; defeatHeavyshotsACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalRagingGunnerDefeated >= gunnersKillAchCount && isDefeatGunnersACHUnlocked == false)
            {
                AchTrigger("ach_defeatRagingGunner"); isDefeatGunnersACHUnlocked = true; defeatGunnersACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalBrutedDefeated >= brutesKillAchCount && isDefeatBrutesACHUnlocked == false)
            {
                AchTrigger("ach_defeatBrutes"); isDefeatBrutesACHUnlocked = true; defeatBrutesACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalTitansDefeated >= titansKillAchCount && isDefeatTitansACHUnlocked == false)
            {
                AchTrigger("ach_titans"); isDefeatTitansACHUnlocked = true; defeatTitansACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalEnemiesDefeated >= enemyKillsAchcount && isDefeatEnemiesACHUnlocked == false)
            {
                AchTrigger("ach_pieces"); isDefeatEnemiesACHUnlocked = true; defeatEnemiesACH.SetActive(false); AchIncrease();
            }

            //Clicks
            if (SettingsOptions.totalButtonClicks >= buttonClicksAch1Amount && isClickButton1ACHUnlocked == false)
            {
                AchTrigger("ach_100clicks"); isClickButton1ACHUnlocked = true; clickButton1ACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalButtonClicks >= buttonClicksAch2Amount && isClickButton2ACHUnlocked == false)
            {
                AchTrigger("ach_5000clicks"); isClickButton2ACHUnlocked = true; clickButton2ACH.SetActive(false); AchIncrease();
            }
            if (SettingsOptions.totalButtonClicks >= buttonClicksAch3Amount && isClickButton3ACHUnlocked == false)
            {
                AchTrigger("ach_50000clicks"); isClickButton3ACHUnlocked = true; clickButton3ACH.SetActive(false); AchIncrease();
            }

            //Abilites
            if (isAllAbilitiesACHUnlocked == false && Choises.pointDropFirst == true && Choises.doubletapFirst == true && Choises.uziFirst == true && Choises.pistolFirst == true && Choises.shotgunFirst == true && Choises.awpFirst == true && Choises.deagleFirst == true && Choises.chargedBulletFirst == true && Choises.crossbowFirst == true && Choises.cannonFirst == true && Choises.mp4First == true && Choises.arrosFirst == true && Choises.boxinggloveFirst == true && Choises.stabbyspikeFirst == true && Choises.tinySpikeFirst == true && Choises.knifeFirst == true && Choises.sawBladeFirst == true && Choises.swordFirst == true && Choises.hammerFirst == true && Choises.heartFirst == true && Choises.smallShieldFirst == true && Choises.defenseFirst == true && Choises.bouncyShieldFirst == true && Choises.invinFirst == true && Choises.stopwatchFirst == true && Choises.boosterFirst == true && Choises.rocketFirst == true && Choises.talariaFirst == true && Choises.random2First == true && Choises.random3First == true && Choises.random5First == true && Choises.ritualFirst == true && Choises.eggFirst == true && Choises.arenaFirst == true && Choises.abiltites4XFirst == true && Choises.rerollRareFirst == true && Choises.abilities5XFirst == true && Choises.rerollLegendaryFirst == true && Choises.skullHarvestFirst == true)
            {
                AchTrigger("all_allAbilities"); isAllAbilitiesACHUnlocked = true; allAbilitiesACH.SetActive(false); AchIncrease();
            }

            if (Choises.doubletapFirst == true && Choises.stopwatchFirst == true && Choises.talariaFirst && Choises.eggFirst == true && Choises.skullHarvestFirst == true && isAllMythicACHUnlocked == false)
            {
                AchTrigger("all_mythic"); isAllMythicACHUnlocked = true; allMythicACH.SetActive(false); AchIncrease();
            }

            if (Choises.cannonFirst == true && Choises.mp4First == true && Choises.arrosFirst == true && Choises.swordFirst == true && Choises.hammerFirst == true && Choises.invinFirst == true && Choises.rocketFirst == true && Choises.random5First == true && Choises.ritualFirst == true && Choises.abilities5XFirst == true && Choises.rerollLegendaryFirst == true && isAllLegendaryACHUnlocked == false)
            {
                AchTrigger("all_legendary"); isAllLegendaryACHUnlocked = true; allLegendaryACH.SetActive(false); AchIncrease();
            }

            if (Choises.shotgunFirst == true && Choises.awpFirst == true && Choises.crossbowFirst == true && Choises.deagleFirst == true && Choises.chargedBulletFirst == true && Choises.sawBladeFirst == true && Choises.bouncyShieldFirst == true && Choises.boosterFirst
               == true && Choises.random3First == true && Choises.abiltites4XFirst == true && Choises.rerollRareFirst == true && isAllRareAchUnlocked == false)
            {
                AchTrigger("ach_allrare"); isAllRareAchUnlocked = true; allRareACH.SetActive(false); AchIncrease();
            }

            if (Choises.pointDropFirst == true && Choises.uziFirst == true && Choises.pistolFirst == true && Choises.boxinggloveFirst == true && Choises.stabbyspikeFirst == true && Choises.tinySpikeFirst == true && Choises.knifeFirst == true && Choises.smallShieldFirst == true && Choises.heartFirst == true && Choises.random2First == true && Choises.arenaFirst == true && isAllUncommonACHUnlocked == false)
            {
                AchTrigger("ach_alluncommon"); isAllUncommonACHUnlocked = true; allUncommonACH.SetActive(false); AchIncrease();
            }

            #endregion
        }
    }

    #region Unlocks Skins
    public void TestUnlock()
    {
        UnlockSkinOrBackground(true, null, greedFadeBackground);
    }


    public void UnlockSkinOrBackground(bool skinOrBackground, GameObject buttonSkin, GameObject background)
    {
        int random = Random.Range(1,3);
        if(random == 1) { audioManager.Play("skinUnlock1"); }
        if (random == 2) { audioManager.Play("skinUnlock2"); }

        skinsButtonEXL.SetActive(true);

        cheapGreenBTN.SetActive(false); onlyYellowBTN.SetActive(false); discoBTN.SetActive(false);
        lightningBTN.SetActive(false); fireBTN.SetActive(false); basicGreenBTN.SetActive(false);
        basicPurpleBTN.SetActive(false); basicYellowBTN.SetActive(false); woodBTN.SetActive(false);
        rockBTN.SetActive(false); purpleBTN.SetActive(false); blueBTN.SetActive(false);
        simonSaysBTN.SetActive(false); logoBTN.SetActive(false);
        smileBTN.SetActive(false); enemyBTN.SetActive(false); 

        redStripedBackground.SetActive(false); greedFadeBackground.SetActive(false); purpleFadeBackground.SetActive(false);
        hexagonBackground.SetActive(false); greyWaveBackground.SetActive(false); greenVeritcalBackground.SetActive(false);
        pinkFadeBackground.SetActive(false); redTileBackground.SetActive(false);

        if (skinOrBackground == false)
        {
            unlockedBackgroundFrame.SetActive(false);
            unlockedSkinFrame.SetActive(true); buttonSkin.SetActive(true);
        }
        if (skinOrBackground == true)
        {
            unlockedSkinFrame.SetActive(false); 
            unlockedBackgroundFrame.SetActive(true); background.SetActive(true);
        }

        unlockFrame.SetTrigger("UnlockUp");
        if(unlock == null) { unlock = StartCoroutine(SetUnlockDown()); }
    }

    public Coroutine unlock;

    IEnumerator SetUnlockDown()
    {
        yield return new WaitForSecondsRealtime(4f);
        unlockFrame.SetTrigger("UnlockDown");
        unlock = null;
    }
    #endregion

    public void AchIncrease()
    {
        totalAchievements += 1;
        achievementCountTotal.text = $"{totalAchievements}/50";
    }

    #region Achievements Unlocks
    public void AchTrigger(string achID)
    {
        if(Steam.noSteamInt == true) { return; }
       
        var ach = new Steamworks.Data.Achievement(achID);
        if (ach.State == false)
        { 
            ach.Trigger();
        }
    }

    public void AchClear(string achID)
    {
        var ach = new Steamworks.Data.Achievement(achID);
        ach.Clear();
    }
    #endregion

    public void LoadData(GameData data)
    {
        totalAchievements = data.totalAchievements;

        isBasicYellowBTNUnlocked = data.isBasicYellowBTNUnlocked;
        isBasicGreenBTNUnlocked = data.isBasicGreenBTNUnlocked;
        isBasicPurpleBTNUnlocked = data.isBasicPurpleBTNUnlocked;
        isCheapGreenBTNUnlocked = data.isCheapGreenBTNUnlocked;
        isPureYellowBrnUnlcoked = data.isPureYellowBrnUnlcoked;
        isDiscoBTNUnlcoked = data.isDiscoBTNUnlcoked;
        isEnergyBTNUnlocked = data.isEnergyBTNUnlocked;
        isFireBTNUnlcoked = data.isFireBTNUnlcoked;
        isWoodenBTNUNlocked = data.isWoodenBTNUNlocked;
        isRockBTNUnlcoked = data.isRockBTNUnlcoked;
        isPurpleBTNUnlocked = data.isPurpleBTNUnlocked;
        isblueBTNUnlocked = data.isblueBTNUnlocked;
        isSimonBTNUnlcoked = data.isSimonBTNUnlcoked;
        isLogoBTNUnlocked = data.isLogoBTNUnlocked;
        isFunBTNUnlocked = data.isFunBTNUnlocked;
        isEnemyBTNUnlocked = data.isEnemyBTNUnlocked;

        isGreenFadeUnlocked = data.isGreenFadeUnlocked;
        isRedStripedInlocked = data.isRedStripedInlocked;
        isWaveUnlocked = data.isWaveUnlocked;
        isPinkWaveUnlocked = data.isPinkWaveUnlocked;
        isPurpleWaveUnlcoked = data.isPurpleWaveUnlcoked;
        isRedTilesUnlocked = data.isRedTilesUnlocked;
        isGreenStripesUnlocked = data.isGreenStripesUnlocked;
        isHexagonUnlocked = data.isHexagonUnlocked;

        isUziACHUnlocked = data.isUziACHUnlocked;
        isPistolACHUnlocked = data.isPistolACHUnlocked;
        isShotgunACHUnlocked = data.isShotgunACHUnlocked;
        isTrippledACHUnlocked = data.isTrippledACHUnlocked;
        isCrossbowACHUnlcoked = data.isCrossbowACHUnlcoked;
        isAWPACHUnlocked = data.isAWPACHUnlocked;
        isCannonACHUnlocked = data.isCannonACHUnlocked;
        isMP4ACHUnlocked = data.isMP4ACHUnlocked;
        isCritACHUnlcoked = data.isCritACHUnlcoked;
        isFunACHUnlockes = data.isFunACHUnlockes;
        isAcquireSkullHarvestACHUnlocked = data.isAcquireSkullHarvestACHUnlocked;
        isAcquireStopwatchACHUnlcoked = data.isAcquireStopwatchACHUnlcoked;
        isAcquireTalariaACHUnlocked = data.isAcquireTalariaACHUnlocked;
        isAcquireEggACHUnlocked = data.isAcquireEggACHUnlocked;
        isAcquireDoubleTapACHUnlocked = data.isAcquireDoubleTapACHUnlocked;
        isCPSACHUnlocked = data.isCPSACHUnlocked;
        isBeatBossACHUnlcockec = data.isBeatBossACHUnlcockec;
        isBeatHordeACHUnlockec = data.isBeatHordeACHUnlockec;
        isBeatChampionsACHUnlocked = data.isBeatChampionsACHUnlocked;
        isBeatDangerButtonACHUnlocked = data.isBeatDangerButtonACHUnlocked;
        isPointBlankACHUnlocked = data.isPointBlankACHUnlocked;
        isBeatallEndingsAchUnlocked = data.isBeatallEndingsAchUnlocked;
        isConsumeSkullsACHUnlocked = data.isConsumeSkullsACHUnlocked;
        isRerollACHUnlocked = data.isRerollACHUnlocked;
        isAllGunsACHUnkocked = data.isAllGunsACHUnkocked;
        isChooseAiblititesACHUnlcoked = data.isChooseAiblititesACHUnlcoked;
        isReachLevel1ACHUnlocked = data.isReachLevel1ACHUnlocked;
        isReachLevel2AchUnlocked = data.isReachLevel2AchUnlocked;
        isReachLevel3AchUnlocked = data.isReachLevel3AchUnlocked;
        isReachLevel4Unlocked = data.isReachLevel4Unlocked;
        isDefeatAssassinsACHUnlocked = data.isDefeatAssassinsACHUnlocked;
        isDefeatSpeedstersACHUnlocked = data.isDefeatSpeedstersACHUnlocked;
        isDefeatSharpshootersACHUnlocked = data.isDefeatSharpshootersACHUnlocked;
        isDefeatSnipersACHUnlocked = data.isDefeatSnipersACHUnlocked;
        isDefeatHeavyshotsACHUnlocked = data.isDefeatHeavyshotsACHUnlocked;
        isDefeatGunnersACHUnlocked = data.isDefeatGunnersACHUnlocked;
        isDefeatBrutesACHUnlocked = data.isDefeatBrutesACHUnlocked;
        isDefeatTitansACHUnlocked = data.isDefeatTitansACHUnlocked;
        isClickButton1ACHUnlocked = data.isClickButton1ACHUnlocked;
        isClickButton2ACHUnlocked = data.isClickButton2ACHUnlocked;
        isClickButton3ACHUnlocked = data.isClickButton3ACHUnlocked;
        isSpeedrunnerACHUnlocked = data.isSpeedrunnerACHUnlocked;
        isDefeatEnemiesACHUnlocked = data.isDefeatEnemiesACHUnlocked;
        isBeatEndingLevel75ACHUnlocked = data.isBeatEndingLevel75ACHUnlocked;
        isAllUncommonACHUnlocked = data.isAllUncommonACHUnlocked;
        isAllRareAchUnlocked = data.isAllRareAchUnlocked;
        isAllLegendaryACHUnlocked = data.isAllLegendaryACHUnlocked;
        isAllMythicACHUnlocked = data.isAllMythicACHUnlocked;
        isAllAbilitiesACHUnlocked = data.isAllAbilitiesACHUnlocked;
        isAllMeleeACHUnlocked = data.isAllMeleeACHUnlocked;
    }

    public void SaveData(ref GameData data)
    {
        data.totalAchievements = totalAchievements;

        data.isBasicYellowBTNUnlocked = isBasicYellowBTNUnlocked;
        data.isBasicGreenBTNUnlocked = isBasicGreenBTNUnlocked;
        data.isBasicPurpleBTNUnlocked = isBasicPurpleBTNUnlocked;
        data.isCheapGreenBTNUnlocked = isCheapGreenBTNUnlocked;
        data.isPureYellowBrnUnlcoked = isPureYellowBrnUnlcoked;
        data.isDiscoBTNUnlcoked = isDiscoBTNUnlcoked;
        data.isEnergyBTNUnlocked = isEnergyBTNUnlocked;
        data.isFireBTNUnlcoked = isFireBTNUnlcoked;
        data.isWoodenBTNUNlocked = isWoodenBTNUNlocked;
        data.isRockBTNUnlcoked = isRockBTNUnlcoked;
        data.isPurpleBTNUnlocked = isPurpleBTNUnlocked;
        data.isblueBTNUnlocked = isblueBTNUnlocked;
        data.isSimonBTNUnlcoked = isSimonBTNUnlcoked;
        data.isLogoBTNUnlocked = isLogoBTNUnlocked;
        data.isFunBTNUnlocked = isFunBTNUnlocked;
        data.isEnemyBTNUnlocked = isEnemyBTNUnlocked;

        data.isGreenFadeUnlocked = isGreenFadeUnlocked;
        data.isRedStripedInlocked = isRedStripedInlocked;
        data.isWaveUnlocked = isWaveUnlocked;
        data.isPinkWaveUnlocked = isPinkWaveUnlocked;
        data.isPurpleWaveUnlcoked = isPurpleWaveUnlcoked;
        data.isRedTilesUnlocked = isRedTilesUnlocked;
        data.isGreenStripesUnlocked = isGreenStripesUnlocked;
        data.isHexagonUnlocked = isHexagonUnlocked;

        data.isUziACHUnlocked = isUziACHUnlocked;
        data.isPistolACHUnlocked = isPistolACHUnlocked;
        data.isShotgunACHUnlocked = isShotgunACHUnlocked;
        data.isTrippledACHUnlocked = isTrippledACHUnlocked;
        data.isCrossbowACHUnlcoked = isCrossbowACHUnlcoked;
        data.isAWPACHUnlocked = isAWPACHUnlocked;
        data.isCannonACHUnlocked = isCannonACHUnlocked;
        data.isMP4ACHUnlocked = isMP4ACHUnlocked;
        data.isCritACHUnlcoked = isCritACHUnlcoked;
        data.isFunACHUnlockes = isFunACHUnlockes;
        data.isAcquireSkullHarvestACHUnlocked = isAcquireSkullHarvestACHUnlocked;
        data.isAcquireStopwatchACHUnlcoked = isAcquireStopwatchACHUnlcoked;
        data.isAcquireTalariaACHUnlocked = isAcquireTalariaACHUnlocked;
        data.isAcquireEggACHUnlocked = isAcquireEggACHUnlocked;
        data.isAcquireDoubleTapACHUnlocked = isAcquireDoubleTapACHUnlocked;
        data.isCPSACHUnlocked = isCPSACHUnlocked;
        data.isBeatBossACHUnlcockec = isBeatBossACHUnlcockec;
        data.isBeatHordeACHUnlockec = isBeatHordeACHUnlockec;
        data.isBeatChampionsACHUnlocked = isBeatChampionsACHUnlocked;
        data.isBeatDangerButtonACHUnlocked = isBeatDangerButtonACHUnlocked;
        data.isPointBlankACHUnlocked = isPointBlankACHUnlocked;
        data.isBeatallEndingsAchUnlocked = isBeatallEndingsAchUnlocked;
        data.isConsumeSkullsACHUnlocked = isConsumeSkullsACHUnlocked;
        data.isRerollACHUnlocked = isRerollACHUnlocked;
        data.isAllGunsACHUnkocked = isAllGunsACHUnkocked;
        data.isChooseAiblititesACHUnlcoked = isChooseAiblititesACHUnlcoked;
        data.isReachLevel1ACHUnlocked = isReachLevel1ACHUnlocked;
        data.isReachLevel2AchUnlocked = isReachLevel2AchUnlocked;
        data.isReachLevel3AchUnlocked = isReachLevel3AchUnlocked;
        data.isReachLevel4Unlocked = isReachLevel4Unlocked;
        data.isDefeatAssassinsACHUnlocked = isDefeatAssassinsACHUnlocked;
        data.isDefeatSpeedstersACHUnlocked = isDefeatSpeedstersACHUnlocked;
        data.isDefeatSharpshootersACHUnlocked = isDefeatSharpshootersACHUnlocked;
        data.isDefeatSnipersACHUnlocked = isDefeatSnipersACHUnlocked;
        data.isDefeatHeavyshotsACHUnlocked = isDefeatHeavyshotsACHUnlocked;
        data.isDefeatGunnersACHUnlocked = isDefeatGunnersACHUnlocked;
        data.isDefeatBrutesACHUnlocked = isDefeatBrutesACHUnlocked;
        data.isDefeatTitansACHUnlocked = isDefeatTitansACHUnlocked;
        data.isClickButton1ACHUnlocked = isClickButton1ACHUnlocked;
        data.isClickButton2ACHUnlocked = isClickButton2ACHUnlocked;
        data.isClickButton3ACHUnlocked = isClickButton3ACHUnlocked;
        data.isSpeedrunnerACHUnlocked = isSpeedrunnerACHUnlocked;
        data.isDefeatEnemiesACHUnlocked = isDefeatEnemiesACHUnlocked;
        data.isBeatEndingLevel75ACHUnlocked = isBeatEndingLevel75ACHUnlocked;
        data.isAllUncommonACHUnlocked = isAllUncommonACHUnlocked;
        data.isAllRareAchUnlocked = isAllRareAchUnlocked;
        data.isAllLegendaryACHUnlocked = isAllLegendaryACHUnlocked;
        data.isAllMythicACHUnlocked = isAllMythicACHUnlocked;
        data.isAllAbilitiesACHUnlocked = isAllAbilitiesACHUnlocked;
        data.isAllMeleeACHUnlocked = isAllMeleeACHUnlocked;
    }

}
