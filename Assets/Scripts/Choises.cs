using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Advertisements;

public class Choises : MonoBehaviour, IDataPersistence
{
    public GameObject choisePupUp, choisePopUp2;
    public GameObject arenaObject;
    public TextMeshProUGUI healthText, healthbarTopLeftText;

    public DataPersistanceManager dataScript;

    public float normalArenaSize;
    public static bool firstTimeEndingShowedUp;

    public Transform gunHolderTopLeft, gunHolderTopRight, gunHolderBottomLeft, gunHolderBottomRight;
    public Transform controlledPosLeft, controlledPosRight, controlledPosDown, controlledPosUp, controlledCenteredPos;
    public GameObject gun_RandomDirection, gun_Homing, gun_bigPiercing, gun_trippleShot;

    public static int numberOfChoises;
    public int choiseYPos, choise1Xpos, choise2Xpos, choise3Xpos, choise4Xpos, choise5Xpos;
    public float choiseScale;

    public GameObject levelUpText;
    public bool choseAbility;

    public GameObject levelUpBlockScreen, blockAbilititesObject;
    public GameObject choiseRare;

    public static int commonAbilitesNotAviable, commonAbilitiesAviable;
    public static int unCommonAbilitesNotAviable, unCommonAbilitiesAviable;
    public static int rareAbilitesNotAviable, rareAbilitiesAviable;
    public static int legendaryAbilitiesNotAvailable, legendaryAbilitiesAviable;

    public TextMeshProUGUI rerollAmounText;
    public GameObject rerollButton;

    public ParticleSystem LevelUpParticle;

    public GameObject ending1, ending2, ending3, ending4, ending5, endingUiElements;
    private bool waitBool;
    public static float abilititesTotalWaitTime;
    public GameObject chooseAbilityAnim;
    public int setLoadCommonAbilites, setUncommonAbilitites, setRareAbilitites, setLegendaryAbilitires;

    public LocalizationVariables localizationScript;
    public float originalCritChance, originalCritIncrease;

    public static int smallShieldUpgradeCount, stabbySpikeUpgradeCount, sawBladeUpgradeCount, bouncyShieldUpgradeCount, swordUpgradeCount;

    public static int maxArrowsStuck, maxPointDropOnScreen, maxBrokenPieces;
    public static int maxAssasins, maxSpeedsters, maxSharpshooters, maxSnipers, maxHeavyshots, maxBrutes, maxRagingGunners, maxTitans;

    public static int minumumSkullHarvest;
    public static int levelToFirstEnding;

    public AudioManager audioManager;

    public static Choises Instance { get; private set; }

    public void Awake()
    {
        levelToFirstEnding = 75;
        minumumSkullHarvest = 175;
        endingBlockAutoSave = false;
        choseContunieRun = false;
        originalCritChance = 2f;
        originalCritIncrease = 2f;
        isInMainManu = true;
    }

    public void Start()
    {
        totalLevelForAds = 15;

        mainCamera.GetComponent<Animator>().enabled = false;
        //ButtonClick.level = 49;

        controlledSpotFilled = 0;

        normalArenaSize = 1;
        ButtonBehiavor.spinForce = -5;

        bool setAllActive;
        setAllActive = false;

        #region Set All Abilitites Active
        if (setAllActive == true)
        {
            ChooseGun1Pistol();
            ChooseGun2Shotgun();
            ChooseGun3Mp4();
            ChooseCrossBow();
            ChooseButtonCharge();
            ChooseHomingBullets();
            ChooseCannon();
            ChooseChaoticGun();
            ChooseArrows();
            ChooseTrippleShot();
            ChoosePiercingBullets();
            ChooseSawBlade();
            ChooseBigSpike();
            ChooseBoxingGlove();
            ChooseHammer();
            ChooseSpikes();
            ChoseStabbingSpikes();
            ChooseKnifes();
            ChooseHeartCollect();
            ChooseMoreRegen();
            ChooseShieldBounce();
            ChooseIdleClicking();
            ChooseDoubleTap();
            ChooseCritClicks();
            ChooseSpawnBrute();
            ChooseSpawnSharpShooter();
            ChooseSpawnSniper();
            ChooseSpawnSpeedster();
            ChooseSpawnTitan();
            ChooseSpawnHeavyShot();
            ChooseSpawnRagingGunner();
            ChooseControllableButton();
            Choose4XChoises();
            Choose5XChoises();
            ChooseArenaAndBouncingBullets();
            ChooseInvincibility();
            //ChooseMagnets();
            //ChooseReroll3Levels();
            //ChooseReroll5Levels();
            //ChooseRerollEverylevel();
            //ChooseSlowDownTime();
            ChooseSkullHarvest();
            ChoosePointsDrop();
        }
        #endregion

        //All abilitites
        #region All Abilitites
        //Weapons - Ranged
        //ChooseGun1Pistol();
        //ChooseGun2Shotgun();
        //ChooseGun3Mp4();
        //ChooseCrossBow();
        //ChooseButtonCharge();
        //ChooseHomingBullets();
        //ChooseCannon();
        //ChooseChaoticGun();
        //ChooseArrows();
        //ChooseTrippleShot();
        //ChoosePiercingBullets();

        //Weapons - Melee
        //ChooseSawBlade();
        //ChooseBigSpike();
        //ChooseBoxingGlove();
        //ChooseHammer();
        //ChooseSpikes();
        //ChoseStabbingSpikes();
        //ChooseKnifes();


        //Health and defense
        //ChooseHeartCollect();
        //ChooseHealthBar();
        //ChooseMoreRegen();
        //ChooseShieldBounce();


        //Clicking
        //ChooseIdleClicking();
        //ChooseDoubleTap();
        //ChooseCritClicks();

        //Enemies
        //ChooseSpawnBrute();
        //ChooseSpawnSharpShooter();
        //ChooseSpawnSniper();
        //ChooseSpawnSpeedster();
        //ChooseSpawnTitan();
        //ChooseSpawnHeavyShot();
        //ChooseSpawnRagingGunner();

        //Movement
        //ChooseButtonBounceCharge();
        //ChooseControllableButton();
        //ChooseRocket();

        //Other
        //Choose4XChoises();
        //Choose5XChoises();
        //ChooseArenaAndBouncingBullets();
        //ChooseInvincibility();
        //ChooseMagnets();
        //ChooseReroll3Levels();
        //ChooseReroll5Levels();
        //ChooseRerollEverylevel();
        //ChooseSlowDownTime();
        //ChooseSkullHarvest();
        //ChoosePointsDrop();
        #endregion

        Invoke("WaitWait", 1f);
        StartCoroutine(LoadCHoisesSaved());
    }

    #region LoadSaves
    IEnumerator LoadCHoisesSaved()
    {
        yield return new WaitForSeconds(0.5f);

        if(rerollsAviable < 1) { rerollAmounText.text = "<color=red>" + rerollsAviable + ""; }
        if (rerollsAviable > 0) { rerollAmounText.text = "<color=green>" + rerollsAviable + ""; }

        eggPointPerClick.SetActive(true);
        eggCritClicks.SetActive(true);
        eggIdleClicks.SetActive(true);

        //SetOriginalChances();
        //Debug.Log(commonAbilitesNotAviable); Debug.Log(commonAbilitiesAviable);

        if(skullHarvestChosenFirstTime == true)
        {
            skullHarvestStatLocked.SetActive(false);
        }
        else 
        {
            skullHarvestStatLocked.SetActive(true); 
        }

        if (SettingsOptions.firstTimeOpenedGame == false)
        {
            SetStoredStart();
        }

        if(chose_Gun1 == true) { gun1.SetActive(true); SetControlledGunPos(gun1); eggPisto.SetActive(true); }
        if (chose_gun2 == true) { gun2.SetActive(true); SetControlledGunPos(gun2); eggShotgun.SetActive(true); }
        if (choseGunMp4 == true) { gun3.SetActive(true); SetControlledGunPos(gun3); eggMP4.SetActive(true); }
        if (choseCrossBow == true) { crossbow.SetActive(true); SetControlledGunPos(crossbow); eggCrossbow.SetActive(true); }

        if (choseShootSmallBullets == true) { gun_RandomDirection.SetActive(true); SetAutoGunPosition(gun_RandomDirection); eggUZI.SetActive(true); }
        if (chooseBigPiercingBulletGun == true) { gun_bigPiercing.SetActive(true); SetAutoGunPosition(gun_bigPiercing); eggCannon.SetActive(true); }
        if (chooseHomingBullets == true) { gun_Homing.SetActive(true); SetAutoGunPosition(gun_Homing); eggAWP.SetActive(true); }
        if (choseTrippleShot == true) { gun_trippleShot.SetActive(true); SetAutoGunPosition(gun_trippleShot); eggDeagle.SetActive(true); }

        if(choseBouncingBullets == true)
        {
            eggArena.SetActive(true);
            normalArenaSize = 1;
            arenaObject.SetActive(true);
            arenaObject.transform.localScale = new Vector3(normalArenaSize + arenaIncrease, normalArenaSize + arenaIncrease, normalArenaSize + arenaIncrease);
        }

        if(chooseBigSpike == true) { bigSpike.SetActive(true); eggSword.SetActive(true); }
        if (chooseSpikes == true) { spikes.SetActive(true); eggTinySpiked.SetActive(true); }
        if (chooseStabbingSpikes == true) { stabbingSpikes.SetActive(true); eggStabbySpikes.SetActive(true); }
        if (choseBoxingGlove == true) { eggBoxingGlove.SetActive(true); }
        if (chooseSawBlade == true) { sawBlade.SetActive(true); eggSawBlade.SetActive(true); }

        if (chooseRocket == true) { rocket.SetActive(true); }
        if (choseButtonBounceCharge == true) { smallChargeButton.SetActive(true); }

        if(choseHealthBar == true)
        {
            eggDefense.SetActive(true);
            healthBarSlider.minValue = 0;
            healthBarSlider.maxValue = maxButtonHealth;
            buttonHealth = maxButtonHealth;
            healthBarSlider.value = maxButtonHealth;
            regenHealth = true;

            if(SettingsOptions.healthbarPosition == 0)
            {
                healthText.gameObject.SetActive(true);
                healthBar.SetActive(true);

                healthBarTopRight.SetActive(false);
            }
        }

        if(choseShield_BounceOff == true) { shield_BounceOff.SetActive(true); eggBouncyShield.SetActive(true); }

        //ChooseControllableButton();
       // Debug.Log(choseButtonCharge);

        #region Load Abilitites
        //Common Abilitites
        /////
        ///
        setLoadCommonAbilites = -1;
        setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[0]; //Idle Clicks 
        setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[1]; //More Points
        setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[2]; //Crit Clicks

        //Guns
        if(chose_Gun1 == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[5]; } //Pistol
        if (chose_gun2 == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[6]; } //Shotgun
        if (choseGunMp4 == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[18]; } //mp4
        if (choseCrossBow == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[27]; } //crossbow
        if (choseShootSmallBullets == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[4]; } //uzi
        if (chooseBigPiercingBulletGun == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[7]; } //cannon
        if (choseTrippleShot == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[19]; } //trippleshot
        if (chooseHomingBullets == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[8]; } //awp

        //Other Ranged Abilitites
        if (choseButtonCharge == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[28]; } //Charged Bullets
        if (choseArrows == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[13]; eggArrow.SetActive(true); } //Arrows

        if (choseButtonCharge == true)
        {
            eggChargedBullet.SetActive(true);
            maxButtonCharge = 35;
            buttonChargePerSecond = 1;
        }

        //Melee
        if (chooseBigSpike == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[9]; } //Sword
        if (chooseSpikes == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[14]; } //Small Spikes
        if (chooseStabbingSpikes == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[11]; } //Stabbing Spikes
        if (choseBoxingGlove == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[10]; } //Boxing Glove
        if (chooseSawBlade == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[15]; } //Saw Blade
        if (chooseHammer == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[12]; eggHammer.SetActive(true); } //Hammer
        if (choseSpinningKnifes == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[26]; eggKnife.SetActive(true); } //Knifes

        //Health And Defense
        if(firstWeaponChosen == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[3]; } //Defense+
        if (chooseHeartCollect == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[25]; eggBigHeart.SetActive(true); } //Big Heart+
        if (choseShield_BounceOff == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[17]; } //Bounce Shield+
        if (choseSmallShields == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[23]; eggSmallShield.SetActive(true); } //Small Shield+
        if (choseStopTime == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[21]; eggStopTime.SetActive(true); } //Stop Time
        if (choseInvincibility == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[16]; eggInvincibility.SetActive(true); } //Invincibility

       

        //Other
        if (choseSkullHarvest == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[22]; eggSkullHarvest.SetActive(true); } //Skull Harvest
        if (chosePointsDrop == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[24]; eggPointDrop.SetActive(true); } //Point Drop
        if (choseRitual == true) { setLoadCommonAbilites += 1; activeCommonAbilities[setLoadCommonAbilites] = allCommonAbilitites[20]; eggRitual.SetActive(true); } //Ritual


        //Uncommon Abilitites
        ////
        ///
        setUncommonAbilitites = -1;
        setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[0]; //Uzi
        setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[1]; //Pistol
        setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[9]; //2Random

        if (firstWeaponChosen == true) {
            setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[3]; //Big Heart
            setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[4]; //Boxing Glove
            setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[2]; //Arena
            setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[5]; //Stabbing Spikes
            setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[6]; //Small Spikes
            setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[7]; //Spinning Knifes
        } 

        if(movementAbilityAquaried == true) {   setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[8]; } //Point Drop
        if(firstShootingEnemyChose == true) { setUncommonAbilitites += 1; activeUnCommonAbilities[setUncommonAbilitites] = allUncommonAbilities[10]; } //Small Shield


        //Rare Abilitites
        ////
        ///

        setRareAbilitites = -1;
        if (numberOfChoises < 4) { setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[0]; } //4X Choises
        setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[1]; //Reroll
        setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[4]; //3 Random
        setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[6]; //Shotgun
        setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[7]; //Homing Gun
        setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[9]; //Crossbow
        setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[10]; //TrippleShot

        if (firstWeaponChosen == true) { setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[2]; } //Charged Bullets
        if (firstShootingEnemyChose == true) { setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[3]; } //Shield Bounce
        if (choseBouncingBullets == true && choseButtonBounceCharge == false) { setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[5]; } //Booster
        if (firstWeaponChosen == true) { setRareAbilitites += 1; activeRareAbilities[setRareAbilitites] = allRareAbilitites[8]; } //Saw Blade


        //Legenary Abilitites
        ////
        ///

        setLegendaryAbilitires = -1;
        if (numberOfChoises == 4) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[0]; } //4X Choises
        setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[3]; //Cannom
        setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[8]; //Mp4
        setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[10]; //5 Random
        setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[1]; //Reroll

        if (choseBouncingBullets == true && chooseRocket == false) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[2]; } //Rocket
        if (firstWeaponChosen == true) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[4]; } //Sword
        if (firstWeaponChosen == true) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[5]; } //Invincibility
        if (firstWeaponChosen == true) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[6]; } //Hammer
        if (firstWeaponChosen == true) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[7]; } //Arrows
        if (movementAbilityAquaried == true) { setLegendaryAbilitires += 1; activeLegendaryAbilities[setLegendaryAbilitires] = allLegendaryAbilities[9]; } //Ritual




        if (choseSmallShields == true)
        {
            smallShields.SetActive(true);
            if (smallShieldUpgradeCount > 1) { smallShield3.SetActive(true); }
            if (smallShieldUpgradeCount > 2) { smallShield4.SetActive(true); }
            if (smallShieldUpgradeCount > 3) { smallShield5.SetActive(true); }
            if (smallShieldUpgradeCount > 4) { smallShield6.SetActive(true); }
            if (smallShieldUpgradeCount > 5) { smallShield7.SetActive(true); }
            if (smallShieldUpgradeCount > 6) { smallShield8.SetActive(true); }
        }

        if (chooseStabbingSpikes == true)
        {
            stabbingSpikes.SetActive(true);
            if (stabbySpikeUpgradeCount > 1) { stabbingSpike5.SetActive(true); }
            if (stabbySpikeUpgradeCount > 2) { stabbingSpike6.SetActive(true); }
            if (stabbySpikeUpgradeCount > 3) { stabbingSpike7.SetActive(true); }
            if (stabbySpikeUpgradeCount > 4) { stabbingSpike8.SetActive(true); }
        }

        if (chooseSawBlade == true)
        {
            sawBlade.SetActive(true);
            if (sawBladeUpgradeCount > 1) { sawBlade2.SetActive(true); }
            if (sawBladeUpgradeCount > 2) { sawBlade3.SetActive(true); }
            if (sawBladeUpgradeCount > 3) { sawBlade4.SetActive(true); }
            if (sawBladeUpgradeCount > 4) { sawBlade5.SetActive(true); }
            if (sawBladeUpgradeCount > 5) { sawBlade6.SetActive(true); }
            if (sawBladeUpgradeCount > 6) { sawBlade7.SetActive(true); }
            if (sawBladeUpgradeCount > 7) { sawBlade8.SetActive(true); }
        }

        if (chooseBigSpike == true)
        {
            bigSpike.SetActive(true);
            if (swordUpgradeCount > 1) { sword2.SetActive(true); }
            if (swordUpgradeCount > 2) { sword3.SetActive(true); }
            if (swordUpgradeCount > 3) { sword4.SetActive(true); }
        }


        if (choseShield_BounceOff == true)
        {
            shield_BounceOff.SetActive(true);
            if (bouncyShieldUpgradeCount > 1) { bouncyShield2.SetActive(true); }
            if (bouncyShieldUpgradeCount > 2) { bouncyShield3.SetActive(true); }
            if (bouncyShieldUpgradeCount > 3) { bouncyShield4.SetActive(true); }
        }

        #endregion
    }
    #endregion

    public void WaitWait()
    {
        //knifeTotalCount = 15;
        SetGunVolume();
        waitBool = true;
        //ButtonClick.level = 70;
    }

    #region Death Anim, Restart and Main menu
    public static bool didPlayerDie;
    public static bool playerDied, isInMainManu, isInDeathScreen;
    public GameObject redFade, deathScreen;
    public TextMeshProUGUI reachedLevelText;
    public GameObject mainMenu, settingsPopUp;

    public void RestartRun()
    {
        weirdEggChooseScreen.SetActive(false);
        weirdEggScreen.SetActive(false);
        isInEggScreen = false;
        choseContunieRun = false;
        ending1.GetComponent<Button>().interactable = true;
        ending2.GetComponent<Button>().interactable = true;
        ending3.GetComponent<Button>().interactable = true;
        ending4.GetComponent<Button>().interactable = true;
        noHoverGlow = false;
        numberOfGunsCurrentRun = 0;
        numberOfMeleeCurrentRun = 0;
        mainButtonColliderScript.ResetInvin();
        buttonClickScript.StopStopTime();
        SetChosenAbilititesInactive();
        buttonBehaviorScript.ResetCharge();
        saveButton.interactable = true;
        endingBlockAutoSave = false; 
        isInWinScreen = false;
        StartCoroutine(RestartRunTransition());
        ResetAbilites();
    }

    IEnumerator RestartRunTransition()
    {
        bossMusicPlaying = false; hordMusicPlaying = false; championsMusicPlaying = false; dangerButtonMusicPlaying = false;
        SettingsOptions.isMobileSettingBTN = true;
        SetOriginalChances();
        rerollButton.SetActive(false);
        SettingsOptions.isInSettings = false;
        SettingsOptions.isPlayerPlayingARun = true;
        StartCoroutine(SetCircleTransition(false, 0.5f));
        didPlayerDie = true;
        playerDied = true;
        yield return new WaitForSecondsRealtime(0.5f);
        isInLevelUpScreen = false;
        settingScript.SetOnlyArrowsBack();
        settingScript.SetObjectOnScreenBack();
        settingScript.PlayRandomSong(1); 
        mainButtonColliderScript.StopRocketAndBooster();
        spaceForUIElementsTopLeft.SetActive(true);
        spaceForTopRightTimer.SetActive(true);
        SetAllEndingsStufFInactive();
        winScreen.SetActive(false);
        mainButton.transform.localPosition = new Vector2(0, -36f);
        mainMenu.SetActive(false);
        mainXPBar.SetActive(true);
        playerDied = false;
        didPlayerDie = false;
        isInDeathScreen = false;
        ResetAllGameObject(true);
        spawnEnemiesScript.StopSpawning();
        spawnShootingScript.StopSpawning();
        spawnBigScript.StopSpawning();
        redFade.SetActive(false);
        deathScreen.SetActive(false);
        mainCamera.GetComponent<Animator>().enabled = false;
        mainCamera.orthographicSize = 41f;
        mainCamera.transform.localPosition = new Vector3(0, 0, -10);
        settingsPopUp.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(SetCircleTransition(true, 0.5f));
        ButtonClick.ritualStopped = false;
        yield return new WaitForSecondsRealtime(0.7f);
        SetCursors.hoveringClickableStuff = false;
        Cursor.visible = true;
        dataScript.SaveTheGameData();
        SetGunVolume();
        ButtonClick.arrowCoroutine = null;
    }
    public Button mainMenuResetBTN;
    public GameObject timerTopRight;

    public void MainMenu()
    {
        isInEggScreen = false;
        choseContunieRun = false;
        isInDeathScreen = false;
        ending1.GetComponent<Button>().interactable = true;
        ending2.GetComponent<Button>().interactable = true;
        ending3.GetComponent<Button>().interactable = true;
        ending4.GetComponent<Button>().interactable = true;
        HoverUpgrades.endingTransitionPlaying = false;
        noHoverGlow = false;
        numberOfGunsCurrentRun = 0;
        numberOfMeleeCurrentRun = 0;
        mainButtonColliderScript.ResetInvin();
        SetChosenAbilititesInactive();
        buttonBehaviorScript.ResetCharge();
        saveButton.interactable = true;
        endingBlockAutoSave = false; 
        timerTopRight.SetActive(false);
        skullsConsumedCount = 0;
        didPlayerDie = false;
        ButtonClick.pointsGained = 0;
        ButtonClick.pointsNeeded = 20;
        continueButton.interactable = false;
        isInWinScreen = false;
        ResetAbilites();
        SetOriginalChances();
        ResetAllGameObject(true);
        winScreen.SetActive(false);
        SettingsOptions.isPlayerPlayingARun = false;
        isInMainManu = true;
        mainMenuResetBTN.interactable = false;
        StartCoroutine(MainMenuTransition());
        ButtonClick.ritualStopped = false;
    }

    public void NewRun()
    {
        HoverUpgrades.endingTransitionPlaying = false;
        buttonBehaviorScript.ResetCharge();
        saveButton.interactable = true;
        endingBlockAutoSave = false;
        skullsConsumedCount = 0;
        isInWinScreen = false;
        didPlayerDie = false;
        SetOriginalChances();
        rerollButton.SetActive(false);
        SettingsOptions.isPlayerPlayingARun = true;
        mainMenuResetBTN.interactable = true;
        mainCamera.orthographicSize = 29;
        mainCamera.transform.localPosition = new Vector3(-27, -1.9f, -10);
        mainCamera.GetComponent<Animator>().enabled = true;
        mainMenu.GetComponent<Animator>().enabled = true;
        mainMenu.GetComponent<Animator>().SetTrigger("MenuIn");
        mainCamera.GetComponent<Animator>().SetTrigger("CameraIn");
        mainXPBar.SetActive(true);
        StartCoroutine(WaitForRestartRun());
        ButtonClick.ritualStopped = false;
    }

    IEnumerator WaitForRestartRun()
    {
        bossMusicPlaying = false; hordMusicPlaying = false; championsMusicPlaying = false; dangerButtonMusicPlaying = false;
        SettingsOptions.isInSettings = false;
        yield return new WaitForSeconds(0.6f);
        isInLevelUpScreen = false;
        EnemyCountZero();
        SetCursors.hoveringClickableStuff = false;
        mainButtonColliderScript.StopRocketAndBooster();
        mainMenu.SetActive(false);
        isInMainManu = false;
        isInDeathScreen = false;
        if(MobileScript.isMobile == true) { SettingsOptions.isMobileSettingBTN = true; }
        mainCamera.GetComponent<Animator>().enabled = false;
        dataScript.SaveTheGameData();
    }

    IEnumerator MainMenuTransition()
    {
        bossMusicPlaying = false; hordMusicPlaying = false; championsMusicPlaying = false; dangerButtonMusicPlaying = false;
        StartCoroutine(SetCircleTransition(false, 0.5f));
        yield return new WaitForSeconds(0.4f);
        isInLevelUpScreen = false;
        settingScript.SetOnlyArrowsBack();
        settingScript.SetObjectOnScreenBack();
        settingScript.PlayRandomSong(1);
        EnemyCountZero();
        SetCursors.hoveringClickableStuff = false;
        mainButtonColliderScript.StopRocketAndBooster();
        spaceForUIElementsTopLeft.SetActive(true);
        spaceForTopRightTimer.SetActive(true);
        SetAllEndingsStufFInactive();

        mainButton.transform.localPosition = new Vector2(0,-36f);
        ResetAllGameObject(true);
        dangerButtonTimerSlider.SetActive(false);
        mainXPBar.SetActive(false);
        redFade.SetActive(false);
        deathScreen.SetActive(false);
        mainMenu.SetActive(true);
        mainMenu.GetComponent<Animator>().enabled = false;
        mainMenu.transform.localPosition = new Vector2(0,0);
        mainCamera.GetComponent<Animator>().enabled = true;
        mainCamera.GetComponent<Animator>().SetTrigger("CameraOut");
        StartCoroutine(SetCircleTransition(true, 0.5f));
        ButtonClick.ritualStopped = false;
        dataScript.SaveTheGameData();
        SetGunVolume();
        ButtonClick.arrowCoroutine = null;
    }

    public TextMeshProUGUI deathTimerText;

    IEnumerator DeathAnim()
    {
        SetOriginalChances();
        rerollButton.SetActive(false); 
        playerDied = true;
        redFade.SetActive(true);

        Image red = redFade.GetComponent<Image>();
        SetAlpha(red, 1f);
        yield return new WaitForSecondsRealtime(0.5f);
        playerDied = false;
        deathScreen.SetActive(true);
        deathScreen.GetComponent<Animator>().SetTrigger("Death");
        dataScript.SaveTheGameData();
    }

    public GameObject champion1Pieces, champion2Pieces, champion3Pieces, bossPieces;
    public void SetAllEndingsStufFInactive()
    {
        DangerButtonEnding.isPlayingDangerButton = false;
        HordeEnding.playingHordeEnding = false;
        MimicEnding.isPlayingMimicEnding = false;
        MimicEnding.isPlayingChamptions = false;
        BossMechanics.fightingBossFight = false;

        champion1Stab.SetActive(false);
        champion2Ranged.SetActive(false);
        champion3Armored.SetActive(false);

        dangerButtonTimerSlider.gameObject.SetActive(false);
        dangerButtonArena.SetActive(false);

        champion1Pieces.SetActive(false);
        champion2Pieces.SetActive(false);
        champion3Pieces.SetActive(false);
        mimicSlider.SetActive(false);

        hordeSlider.SetActive(false);
        wave1.SetActive(false);
        wave2.SetActive(false);
        wave3.SetActive(false);

        bossPieces.SetActive(false);
        bossArena.SetActive(false);
        bossHEalthBar.SetActive(false);
    }

    #endregion

    public SettingsOptions settingScript;
    public SpawnEnemies spawnEnemiesScript;
    public SpawnShootingEnemy spawnShootingScript;
    public SpawnBigEnemy spawnBigScript;
    public ButtonBehiavor buttonBehaviorScript;
    public GameObject aimCursor;
    public Button saveButton;
    public MainButtonCollider mainButtonColliderScript;
    public static bool isInLevelUpScreen;

    public static int totalLevelForAds, levelupsForAds;

    void Update()
    {
        #region Spawn Enemies First Time
        if(HoverUpgrades.setSmallEnemy == true) { numberOfEnemiesActive += 1; SpawnSmallEnemies(); HoverUpgrades.setSmallEnemy = false; }
        if (HoverUpgrades.setSpeedster == true) { numberOfEnemiesActive += 1; ChooseSpawnSpeedster(); HoverUpgrades.setSpeedster = false; }
        if (HoverUpgrades.setSharpshooter == true) { numberOfEnemiesActive += 1; ChooseSpawnSharpShooter(); HoverUpgrades.setSharpshooter = false; }
        if (HoverUpgrades.setGunner == true) { numberOfEnemiesActive += 1; ChooseSpawnRagingGunner(); HoverUpgrades.setGunner = false; }
        if (HoverUpgrades.setHeavyshot == true) { numberOfEnemiesActive += 1; ChooseSpawnHeavyShot(); HoverUpgrades.setHeavyshot = false; }
        if (HoverUpgrades.setSniper == true) { numberOfEnemiesActive += 1; ChooseSpawnSniper(); HoverUpgrades.setSniper = false; }
        if (HoverUpgrades.setBrute == true) { numberOfEnemiesActive += 1; ChooseSpawnBrute(); HoverUpgrades.setBrute = false; }
        if (HoverUpgrades.setTitan == true) { numberOfEnemiesActive += 1; ChooseSpawnTitan(); HoverUpgrades.setTitan = false; }
        #endregion

        #region Death
        if(choseHealthBar == true)
        {
            if (buttonHealth < 0)
            {
                buttonHealth = 0;
                if (didPlayerDie == false)
                {
                    HordeEnding.hordeSpawnSmallEnemy = false;
                    HordeEnding.hordeSpawnSpeedster = false;
                    HordeEnding.hordeSpawnTitan = false;
                    HordeEnding.hordeSpawnBrute = false;
                    HordeEnding.hordeSpawnRagingGunner = false;

                    numberOfGunsCurrentRun = 0;
                    numberOfMeleeCurrentRun = 0;

                    mainButtonColliderScript.ResetInvin();
                    buttonClickScript.StopStopTime();

                    choseContunieRun = false;
                    Cursor.visible = true;
                    if(regenCoroutine != null) { StopCoroutine(regenCoroutine); }
                    regenHealth = false;

                    audioManager.Play("GameOver");
                    if(bossMusicPlaying == true) { audioManager.Stop("BossMusic"); }
                    if (hordMusicPlaying == true) { audioManager.Stop("HordeMusic"); }
                    if (championsMusicPlaying == true) { audioManager.Stop("ChampionMusic"); }
                    if (dangerButtonMusicPlaying == true) { audioManager.Stop("DangerMusic"); }

                    isInDeathScreen = true;
                    didPlayerDie = true;

                    CheckMusicPlaying();
                    CheckSoundsPlaying();

                    bossMusicPlaying = false; hordMusicPlaying = false; championsMusicPlaying = false; dangerButtonMusicPlaying = false; 

                    if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:0{SettingsOptions.currentTime.ToString("F0")}"; }
                    if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:{SettingsOptions.currentTime.ToString("F0")}"; }

                    if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
                    if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

                    if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
                    if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

                    deathTimerText.text = "Run Time: " + winTimer;
                    reachedLevelText.text = "YOU REACHED LEVEL " + ButtonClick.level;
                    buttonBehaviorScript.ResetCharge();
                    settingScript.ResetGame(false);
                    spawnEnemiesScript.StopSpawning();
                    spawnShootingScript.StopSpawning();
                    spawnBigScript.StopSpawning();
                    mainButtonColliderScript.StopRocketAndBooster();
                    StartCoroutine(DeathAnim());
                    endingBlockAutoSave = false;
                    saveButton.interactable = true;
                    dataScript.SaveTheGameData();
                }
            }
        }
        #endregion

        #region Health Bar Health Display
        if (buttonHealth > maxButtonHealth)
        {
            buttonHealth = maxButtonHealth;
        }

        if(MainButtonCollider.isInvincibilityActive == true)
        {
            buttonHealth = MainButtonCollider.currentHealth;
            healthBarSlider.value = buttonHealth;
            healthbarSliderTopRight.value = buttonHealth;

            healthbarTopLeftText.text = buttonHealth.ToString("F0") + " / " + maxButtonHealth.ToString("F0");
            healthText.text = buttonHealth.ToString("F0") + " / " + maxButtonHealth.ToString("F0");
        }
        else
        {
            healthBarSlider.value = buttonHealth;
            healthBarSlider.maxValue = maxButtonHealth;

            healthbarSliderTopRight.value = buttonHealth;
            healthbarSliderTopRight.maxValue = maxButtonHealth;

            healthbarTopLeftText.text = buttonHealth.ToString("F0") + " / " + maxButtonHealth.ToString("F0");
            healthText.text = buttonHealth.ToString("F0") + " / " + maxButtonHealth.ToString("F0");
        }
        #endregion

        #region Level Up And Pause
        if (choseAbility == true)
        {
            levelUpText.SetActive(false);
            levelUpBlockScreen.SetActive(false);
            choseAbility = false;
        }

        if(isPaused == true && setVariables == true)
        {
            if(isInDeathScreen == false)
            {
                CheckSoundsPlaying();

                chose1Mythic = false; chose2Mythic = false; chose3Mythic = false; chose4Mythic = false; chose5Mythic = false;
                uncommonGunsAppeared = 0; rareGunsAppeared = 0; legendaryGunsAppeared = 0;
                numberOfCommonChoises = 0; numberOfUnCommonChoises = 0; numberOfRareChoises = 0; numberOfLegendaryChoices = 0;
                fadeInTime = 0;
                levelUpBlockScreen.SetActive(true);

                got1CommonChoise = false; got2CommonChoise = false; got3CommonChoise = false; got4CommonChoise = false;
                got1UnCommonChoise = false; got2UnCommonChoise = false; got3UnCommonChoise = false; got4UnCommonChoise = false;
                got1RareChoise = false; got2RareChoise = false; got3RareChoise = false; got4RareChoise = false;
                got1LegendaryChoice = false; got2LegendaryChoice = false; got3LegendaryChoice = false; got4LegendaryChoice = false;
                chose1Common = 50; chose2Common = 50; chose3Common = 50; chose4Common = 50;
                chose1UnCommon = 50; chose2UnCommon = 50; chose3UnCommon = 50; chose4UnCommon = 50;
                chose1Rare = 50; chose2Rare = 50; chose3Rare = 50; chose4Rare = 50;
                chose1Legendary = 50; chose2Legendary = 50; chose3Legendary = 50; chose4Legendary = 50;

                choisesChosen = 0;

                if (ButtonClick.level == levelToFirstEnding && choseContunieRun == false)
                {
                    StartCoroutine(Endings());
                    endingBlockAutoSave = true;
                    saveButton.interactable = false;
                }
                else
                {
                    isInLevelUpScreen = true;
                    AbilitiesChoose();
                    StartCoroutine(SetBlockAbilitesInactive());
                    //if (choseReroll == true) { StartCoroutine(FadeInReroll()); }
                }
            }
            
            setVariables = false;
        }

        if (ButtonClick.leveledUp == true)
        {
            if(isInDeathScreen == false)
            {
                if (MobileScript.isMobile == false) { aimCursor.SetActive(true); }
                else
                {
                    levelupsForAds += 1;
                }

                Cursor.visible = true;
                SetEnemyPoints(1);
                if (ButtonClick.level == levelToFirstEnding) { abilititesTotalWaitTime = 1.6f; }
                if (choseUnlimitedPower == true) { EggUpgradeAbility(); }
                fadeSounds = 0;
                blockAbilititesObject.SetActive(true);
                choisePopUp2.SetActive(true);

                levelUpText.SetActive(true);
                levelUpText.GetComponent<Animator>().SetTrigger("PopUP");
                if (SettingsOptions.disableParticleEffects == 0) { LevelUpParticle.Play(); }

                PauseGame();
                ButtonClick.leveledUp = false;
            }
        }
        #endregion

        #region Big Heart And Regen
       

        if (regenHealth == true)
        {
            regenCoroutine = StartCoroutine(AutoHealthRegen());
            regenHealth = false;
        }
        #endregion
    }

    public static bool endingBlockAutoSave;

    #region FadeInReroll
    IEnumerator FadeInReroll()
    {
        yield return new WaitForSecondsRealtime(0.13f + fadeInTime);
        rerollButtonObject.SetActive(true);
        rerollButtonObject.GetComponent<Animator>().SetTrigger("In");

        if (rerollsAviable < 1) 
        {
            rerollAmounText.text = "<color=red>" + rerollsAviable + "";
            rerollDiceObject.GetComponent<Button>().interactable = false; 
        }
        if (rerollsAviable > 0)
        {
            rerollAmounText.text = "<color=green>" + rerollsAviable + "";
            rerollDiceObject.GetComponent<Button>().interactable = true;
        }
    }
    #endregion

    #region Egg
    public void EggUpgradeAbility()
    {
        //Points Per Click
        if (eggPointPerClickChosen == true)
        {
            pointsLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetMorePointsText();
            ButtonClick.pointsPerClick += currentPointIncrease;
            //Debug.Log(ButtonClick.pointsPerClick);
        }
        if (eggIdleClickChosen == true)
        {
            idleLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            if (choseIdleClicking == false)
            {
                ButtonClick.autoClick = true;
                choseIdleClicking = true;
                timeBetweenClicks = 2;
            }
            else
            {
                SetIdleUpgrade();
                timeBetweenClicks -= currentIdleClickIncrease;
                totalIdlePoints += currentIdlePointIncrease;
            }
        }
        if (eggCritclickChosen == true)
        {
            critLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            if (choseCritClicks == false) { choseCritClicks = true; critClicksChance = originalCritChance; critClicksBonus = originalCritIncrease; }
            else
            {
                SetCritUpgrade();
                Choises.critClicksChance += currentClickCritPercentIncrease;
                Choises.critClicksBonus += currectClickCritIncrease;
            }
        }

        if (eggDefenseChosen == true)
        {
            defenseLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetHealthUpgrade();
            Choises.maxButtonHealth += currentHealthIncrease;
            buttonHealth += currentHealthIncrease;
            Choises.healthRegenPerSecond += currentHealthRegenIncrease;
        }

        if (eggBigHeartChosen == true)
        {
            heartLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetHeartCollect(true);
            Choises.bigHeartHPHeal += bigHeartCommonHealIncrease;
        }

        if (eggSmallShieldChosen == true)
        {
            smallShieldLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetSmallShieldUpgrade(true);
            Choises.smallShieldHP += smallShieldCommonHPIncrease;
            Choises.smallShieldRechargeTimer -= smallShiledCommonRechargeDecrease;
        }

        if (eggBouncyShieldChosen == true)
        {
            bouncyShieldLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetShieldBounceUpgrade(true);
            Choises.shieldBounce_health += shieldBounceCommonHPIncrease;
            Choises.reChargeTimer -= shieldBounceCommonRechargeDecrease;
        }

        if (eggUziChosen == true)
        {
            uziLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetUziUpgrade(true);
            Choises.smallBulletDamage += uziCommonDamageIncrease;
            Choises.smallBulletSpeed += uziCommonSpeedIncrease;
        }

        if (eggPistolChosen == true)
        {
            pistolLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetPistolUpgrade(true);
            Choises.bulletGun1_Damage += pistolCommonDamageIncrease;
            Choises.bulletGun1_Speed += pistolCommonSpeedIncrease;
        }

        if (eggShotgunChosen == true)
        {
            shotgunLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetShotgunUpgrade(true);
            Choises.shotGunBulletDamage += shotgunCommonDamageIncrease;
            Choises.shotGunBulletDamage2 += shotgunCommonDamageIncrease;
            Choises.shotGunBulletSpeed1 += shotgunCommonSpeedIncrease;
            Choises.shotGunBulletSpeed2 += shotgunCommonSpeedIncrease;
        }

        if (eggAWPChosen == true)
        {
            awpLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetAWPUpgrade(true);
            Choises.homingBulletDamage += awpCommonDamageIncrease;
            Choises.homignBulletSpeed += awpCommonSpeedIncrease;
        }

        if (eggDeagleChosen == true)
        {
            deagleLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetTrippleShotUpgrade(true);
            Choises.trippleShotDamage += deagleCommonDamageIncrease;
            Choises.trippleShotSpeed += deagleCommonSpeedIncrease;
        }

        if (eggCrossbowChosen == true)
        {
            crossbowLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetCrossbowUpgrade(true);
            Choises.crossbowDamage += crossbowCommonDamageIncrease;
            Choises.crossbowSpeed += crossbowCommonSpeedIncrease;
        }

        if (eggCannonChosen == true)
        {
            cannonLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetCannonUpgrade(true);
            Choises.bigBulletDamage += cannonCommonDamageIncrease;
            Choises.bigBulletSpeed += cannonCommonSpeedIncrease;
        }

        if (eggMP4Chosen == true)
        {
            mp4LEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetMP4Upgrade(true);
            Choises.mp4Damage += mp4CommonDamageIncrease;
            Choises.mp4Speed += mp4CommonSpeedIncrease;
        }

        if (eggChagedBulletsChosen == true)
        {
            chargedBulletLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetChargedBulletUpgrade(true);
            Choises.chargedBulletMaxDamage += chargedBulletcommonMaxDamageIncrease;
            Choises.chargedBulletChargeTime -= chargedBulletcommonChargeTimeIncrease;
        }

        if (eggArrowChosen == true)
        {
            arrosLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetArrowUpgrade(true);
            arrowCountShot += arrowCommonCountIncrease;
            arrowDamage += arrowCommonDamageIncrease;
        }

        if (eggBoxingGloveChosen == true)
        {
            boxingloveLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetBoxingGloveUpgrade(true);
            Choises.boxingGloveKnockbackAmount += boxingGloveCommonForceIncrease;
        }

        if (eggStabbySpikeChosen == true)
        {
            stabbyspikeLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetStabbySpikedUpgrade(true);
            Choises.stabbingSpikeDamage += stabbySpikeCommonDamageIncrease;
        }

        if (eggTinySpikeChosen == true)
        {
            tinySpikeLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetSmallSpikesUpgrade(true);
            Choises.spikeDamagePerSecond += smallSpikesCommonDamageIncrease;
        }

        if (eggKnifeChosen == true)
        {
            knifeLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetKnifeUpgrade(true);
            Choises.knifeDamage += knifeCommonDamageIncrease;
        }

        if (eggSawBladeChose == true)
        {
            sawBladeLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetSawBladeUpgrade(true);
            Choises.sawBladeDamage += sawBladeCommonDamageIncrease;
            Choises.sawBladeSpeed += sawBladeCommonSpeedIncrease;
        }

        if (eggSwordChosen == true)
        {
            swordLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetSwordUpgrade(true);
            Choises.bigSpikeDamage += swordCommonDamageIcrease;
            Choises.swordSpeed += swordCommonSpeedIncrease;
        }

        if (eggHammerChosen == true)
        {
            hammerLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetHammeRUpgrade(true);
            Choises.hammerDamage += hammerCommonDamageIncrease;
            Choises.hammerStunTime += hammerCommonStunTimeIncrease;
        }
        if (eggPointDropChosen == true)
        {
            pointDropLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetPointDropUpgrade(true);
            Choises.pointDropBasicPoints += Choises.commonBasicPointIncrease;
            Choises.pointDropRarityIncreasePoints += Choises.commonPointRarityIncrease;
        }

        if (eggInvinChosen == true)
        {
            invinLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetInvincibilityUpgrade(true);
            Choises.invincibilityTimeAdded += invincibilityCommonTimeAddedIncrease;
            Choises.invincibilityClickPer1Second -= Choises.invincibilityCommonClicksDecrease;
        }

        if (eggSkullHarvestChosen == true)
        {
            skullHarvestLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            if(skullHarvestStatDivide > minumumSkullHarvest)
            {
                skullHarvestStatDivide -= 3;
                //Debug.Log(skullHarvestStatDivide);
            }
        }

        if (eggDiceChose == true)
        {
            rerollLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetRerollUpgrade(true);
            Choises.rerollClicksNeeded -= rerollClicksDeacreseRare;
            rerollDoubleChance += rerollDoubleChanceIncrease;
        }

        if (eggStopwatchChosen == true)
        {
            stopwatchLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetStopWatchUpgrade(true);
            Choises.stopTimeTimer += stopTimeCommonTimeIncrease;
        }

        if (eggArenaChosen == true)
        {
            arenaLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetArenaSize();
        }

        if (eggRitualChosen == true)
        {
            ritualLEVEL += 1;
            SettingsOptions.weirdEggUpgrades += 1;
            SetRitualUpgrade(true);
            ritualClicksNeeded -= ritualCommonClicksIncrease;
            Choises.ritualTimer += Choises.ritualTimerIncrease;
        }
    }
    #endregion

    public static bool beatlEndingAtLevel75;
    public Coroutine regenCoroutine;
    public static bool isBossTransition, isHordeTransition, isChampionTransition;

    #region Abilitites CHOSEN
    public void AbilitiesChoose()
    {
        if (numberOfChoises == 3)
        {
            abilititesTotalWaitTime = 1.1f;
            choiseScale = 0.95f;

            if(MobileScript.isMobile == false) { choise1Xpos = -550; choise2Xpos = 0; choise3Xpos = 550; }
            else { choise1Xpos = -515; choise2Xpos = 0; choise3Xpos = 515; }

            RandomChoises(); RandomChoises(); RandomChoises();
        }

        if (numberOfChoises == 4)
        {
            abilititesTotalWaitTime = 1.35f;

            if (MobileScript.isMobile == false)
            {
                choiseScale = 0.95f;
                choise1Xpos = -635; choise2Xpos = -213; choise3Xpos = 213; choise4Xpos = 635;
            }
            else 
            {
                choiseScale = 0.89f;
                choise1Xpos = -532; choise2Xpos = -178; choise3Xpos = 178; choise4Xpos = 532;
            }
            RandomChoises(); RandomChoises(); RandomChoises(); RandomChoises();
        }

        if (numberOfChoises == 5)
        {
            abilititesTotalWaitTime = 1.6f;

            if (MobileScript.isMobile == false)
            {
                choiseScale = 0.84f;
                choise1Xpos = -646; choise2Xpos = -323; choise3Xpos = 0; choise4Xpos = 323; choise5Xpos = 646;
            }
            else
            {
                choiseScale = 0.74f;
                choise1Xpos = -564; choise2Xpos = -282; choise3Xpos = 0; choise4Xpos = 282; choise5Xpos = 564;
            }

           
            RandomChoises(); RandomChoises(); RandomChoises(); RandomChoises(); RandomChoises();
        }
    }
    #endregion

    #region REGEN
    public static bool regenHealth;
    public float healthIncrement;

    IEnumerator AutoHealthRegen()
    {
        healthIncrement = 0f;

        while (healthIncrement < 1f)
        {
            if (Choises.isPaused == true) { yield return new WaitForSeconds(0.1f); }
            if (Choises.isPaused == false) { yield return new WaitForSecondsRealtime(0.1f); }

            if (buttonHealth >= maxButtonHealth)
            {
                buttonHealth = maxButtonHealth;
            }
            else
            {
                if (Choises.isPaused == false && SettingsOptions.isInSettings == false)
                {
                    //Debug.Log("Regen");
                    buttonHealth += healthRegenPerSecond / 10;
                    MainButtonCollider.currentHealth += healthRegenPerSecond / 10;

                    //Debug.Log(buttonHealth);
                }
            }
            healthIncrement += 0.1f;
        }

        regenHealth = true;
    }
    #endregion

    #region First Ending Pop Up
    public GameObject firstEndingPopUp;
    public void OkButtonFirstEndingPopUp()
    {
        audioManager.Play("UI_Click2");
        blockAbilititesObject.SetActive(false);
        firstTimeEndingShowedUp = true;
        firstEndingPopUp.SetActive(false);
    }
    #endregion

    #region Endings Choose Animations

    public static bool isInChooseEndingScreen;
    public GameObject ending1CheckMark, ending2Checkmark, ending3Checkmark, ending4Checkmark;

    IEnumerator Endings()
    {
        Image ending1Image = ending1.GetComponent<Image>();
        SetAlpha(ending1Image, 1f);
        Image ending2Image = ending2.GetComponent<Image>();
        SetAlpha(ending2Image, 1f);
        Image ending3Image = ending3.GetComponent<Image>();
        SetAlpha(ending3Image, 1f);
        Image ending4Image = ending4.GetComponent<Image>();
        SetAlpha(ending4Image, 1f);

        if (SettingsOptions.firstTimeDefeatedBoss == true) { ending1CheckMark.SetActive(true); }
        else { ending1CheckMark.SetActive(false); }
        if (SettingsOptions.firstTimeDefeatedHorde == true) { ending2Checkmark.SetActive(true); }
        else { ending2Checkmark.SetActive(false); }
        if (SettingsOptions.firstTimeDefeatedChampions == true) { ending3Checkmark.SetActive(true); }
        else { ending3Checkmark.SetActive(false); }
        if (SettingsOptions.firstTimeDefeatedDangerButton == true) { ending4Checkmark.SetActive(true); }
        else { ending4Checkmark.SetActive(false); }

        isInChooseEndingScreen = true;
        ending1.GetComponent<Animator>().enabled = true;
        ending2.GetComponent<Animator>().enabled = true;
        ending3.GetComponent<Animator>().enabled = true;
        ending4.GetComponent<Animator>().enabled = true;

        endingUiElements.SetActive(true);
        ending1.SetActive(true); ending2.SetActive(true); ending3.SetActive(true); ending4.SetActive(true);
        //ending5.SetActive(true);
        audioManager.Play("FadeIn1");
        ending1.GetComponent<Animator>().SetTrigger("AbilityDown");
        yield return new WaitForSecondsRealtime(0.35f);
        audioManager.Play("FadeIn2");
        ending2.GetComponent<Animator>().SetTrigger("AbilityDown");
        yield return new WaitForSecondsRealtime(0.35f);
        audioManager.Play("FadeIn3");
        ending3.GetComponent<Animator>().SetTrigger("AbilityDown");
        yield return new WaitForSecondsRealtime(0.35f);
        audioManager.Play("FadeIn4");
        ending4.GetComponent<Animator>().SetTrigger("AbilityDown");
        //ending5.GetComponent<Animator>().SetTrigger("AbilityDown");
        endingUiElements.GetComponent<Animator>().SetTrigger("GoDown");

        if(firstWeaponChosen == false) { blockPlayEnding.SetActive(true); }
        else { blockPlayEnding.SetActive(false); }

        yield return new WaitForSecondsRealtime(0.35f);

        ending1.GetComponent<Animator>().enabled = false;
        ending2.GetComponent<Animator>().enabled = false;
        ending3.GetComponent<Animator>().enabled = false;
        ending4.GetComponent<Animator>().enabled = false;

        if (firstTimeEndingShowedUp == false) { firstEndingPopUp.SetActive(true); }
        if (firstTimeEndingShowedUp == true) { blockAbilititesObject.SetActive(false); }
    }

    public GameObject blockPlayEnding;
    #endregion

    #region Pick Endings
    public void YesTalaria()
    {
        talariaCross.SetActive(false); talariaCheckmark.SetActive(true);
        pickTalariaForEnding = true;
    }

    public void NoTalaria()
    {
        talariaCross.SetActive(true); talariaCheckmark.SetActive(false);
        pickTalariaForEnding = false;
    }

    public GameObject circle, blockEndings;
    public GameObject endingBackButton, endingPlayEndingButton;
    public static bool noHoverGlow;
    public static bool choosingBoss, choosingHorde, choosingMimic, choosingDangerbutton, choosingPong;
    public TextMeshProUGUI hordeRemoveMovement, noMovementGiveTalariaText;
    public GameObject endingTalariaIcon, endingTalariaYesButton, endingTalariaNoButton;
    public GameObject talariaCross, talariaCheckmark;
    public static bool pickTalariaForEnding;

    public void MultipleVaribales()
    {
        StartCoroutine(SetCircleTransition(false, 0.37f));
        endingUiElements.GetComponent<Animator>().SetTrigger("GoBack");
        HoverUpgrades.endingTransitionPlaying = true;

        isEndingTransition = true;
        blockEndings.SetActive(true);
        noHoverGlow = true;
        choosingBoss = false;
        choosingHorde = false;
        choosingMimic = false;
        choosingDangerbutton = false;
        choosingPong = false;

        endingBackButton.SetActive(true);
        endingPlayEndingButton.SetActive(true);

        endingBackButton.GetComponent<Animator>().SetTrigger("LeftIn");
        endingPlayEndingButton.GetComponent<Animator>().SetTrigger("RightIn");
    }

    public void PickBossEnding()
    {
        CheckMovement();
        MultipleVaribales();
        choosingBoss = true;
        ending1.GetComponent<Button>().interactable = false;
        Image ending2Image = ending2.GetComponent<Image>();
        SetAlpha(ending2Image, 0f);
        Image ending3Image = ending3.GetComponent<Image>();
        SetAlpha(ending3Image, 0f);
        Image ending4Image = ending4.GetComponent<Image>();
        SetAlpha(ending4Image, 0f);
        //Image ending5Image = ending5.GetComponent<Image>();
        //SetAlpha(ending5Image, 0f);
        ending1.GetComponent<Animator>().SetTrigger("BossIn");
    }

    public void PickHordeEnding()
    {
        noMovementGiveTalariaText.text = "";
        endingTalariaIcon.SetActive(false); endingTalariaYesButton.SetActive(false); endingTalariaNoButton.SetActive(false); talariaCheckmark.SetActive(false);
        talariaCross.SetActive(false);
        if (movementAbilityAquaried == true) { hordeRemoveMovement.text = "<color=red>This ending will remove your current movement ability."; }
        if (movementAbilityAquaried == false) { hordeRemoveMovement.text = ""; }
        MultipleVaribales();
        choosingHorde = true;
        ending2.GetComponent<Animator>().SetTrigger("HordeIn");

        ending2.GetComponent<Button>().interactable = false;
        Image ending1Image = ending1.GetComponent<Image>();
        SetAlpha(ending1Image, 0f);
        Image ending3Image = ending3.GetComponent<Image>();
        SetAlpha(ending3Image, 0f);
        Image ending4Image = ending4.GetComponent<Image>();
        SetAlpha(ending4Image, 0f);
        //Image ending5Image = ending5.GetComponent<Image>();
        //SetAlpha(ending5Image, 0f);
    }

    public void PickMimicEnding()
    {
        CheckMovement();
        MultipleVaribales();
        choosingMimic = true;
        ending3.GetComponent<Animator>().SetTrigger("MimicIn");

        ending3.GetComponent<Button>().interactable = false;
        Image ending1Image = ending1.GetComponent<Image>();
        SetAlpha(ending1Image, 0f);
        Image ending2Image = ending2.GetComponent<Image>();
        SetAlpha(ending2Image, 0f);
        Image ending4Image = ending4.GetComponent<Image>();
        SetAlpha(ending4Image, 0f);
        //Image ending5Image = ending5.GetComponent<Image>();
        //SetAlpha(ending5Image, 0f);
    }

    public void PickDangerbuttonEnding()
    {
        CheckMovement();
        MultipleVaribales();
        choosingDangerbutton = true;
        ending4.GetComponent<Animator>().SetTrigger("DangerButtonIn");

        ending4.GetComponent<Button>().interactable = false;
        Image ending1Image = ending1.GetComponent<Image>();
        SetAlpha(ending1Image, 0f);
        Image ending2Image = ending2.GetComponent<Image>();
        SetAlpha(ending2Image, 0f);
        Image ending3Image = ending3.GetComponent<Image>();
        SetAlpha(ending3Image, 0f);
        //Image ending5Image = ending5.GetComponent<Image>();
        //SetAlpha(ending5Image, 0f);
    }

    public void CheckMovement()
    {
        pickTalariaForEnding = false;
        if (movementAbilityAquaried == false)
        {
            pickTalariaForEnding = true;
            endingTalariaIcon.SetActive(true); endingTalariaYesButton.SetActive(false); endingTalariaNoButton.SetActive(false); talariaCheckmark.SetActive(true);
            talariaCross.SetActive(false);

            if(MobileScript.isMobile == false)
            {
                noMovementGiveTalariaText.text = "<color=green>You do not have any movement abilities. You will be given the \"TALARIA.\" Controll the button using WASD.\n ";
            }
            else
            {
                noMovementGiveTalariaText.text = "<size=8.6><color=green>You do not have any movement abilities. You will be given the \"TALARIA.\" Controll the button using the joystick that appears in the bottom left.";
            }
        }
        if (movementAbilityAquaried == true && chooseControllableButton == false)
        {
            pickTalariaForEnding = false;
            endingTalariaIcon.SetActive(true); endingTalariaYesButton.SetActive(true); endingTalariaNoButton.SetActive(true); talariaCheckmark.SetActive(false);
            talariaCross.SetActive(true);

            if (MobileScript.isMobile == false)
            {
                if (choseButtonBounceCharge == true) { noMovementGiveTalariaText.text = "<color=green>You have the Booster movement ability. Would you like the \"TALARIA\" instead for this ending? You controll the button with WASD."; }

                if (chooseRocket == true) { noMovementGiveTalariaText.text = "<color=green>You have the Rocket movement ability. Would you like the \"TALARIA\" instead for this ending? You controll the button with WASD."; }
            }
            else
            {
                if (choseButtonBounceCharge == true) { noMovementGiveTalariaText.text = "<size=8.2><color=green>You have the Booster movement ability. Would you like the \"TALARIA\" instead for this ending? You controll the button with the joystick that appears in the bottom left."; }

                if (chooseRocket == true) { noMovementGiveTalariaText.text = "<size=8.2><color=green>You have the Rocket movement ability. Would you like the \"TALARIA\" instead for this ending? You controll the button with the joystick that appears in the bottom left."; }
            }
        }
        if (chooseControllableButton == true)
        {
            endingTalariaIcon.SetActive(false); endingTalariaYesButton.SetActive(false); endingTalariaNoButton.SetActive(false); talariaCheckmark.SetActive(false);
            talariaCross.SetActive(false);
            noMovementGiveTalariaText.text = "";
        }
    }

    #endregion

    #region ActuallyChooseEnding
    public static bool isEndingTransition;
    public GameObject mainArena, bossObject, bossArena, bossHEalthBar, mainXPBar;
    public GameObject dangerButtonArena, dangerButtonTimerSlider, dangerButtonObject;
    public GameObject hordeSlider, wave1, wave2, wave3;
    public Camera mainCamera;
    public GameObject bossTextBubble;
    public GameObject mainButton;
    public GameObject mimicSlider, champion1Stab, champion2Ranged, champion3Armored;
    public MimicEnding championScript;
    public GameObject spaceForUIElementsTopLeft, spaceForTopRightTimer;
    public static bool bossMusicPlaying, hordMusicPlaying, championsMusicPlaying, dangerButtonMusicPlaying;

    public float champion1HPIncrease, champion2HPIncrease, champion3HPIncrease;
    public float champion1HPScaling, champion2HPScaling, champion3HPScaling;

    public float champion1DamageIncrease, champion2DamageIncrease, champion3DamageIncrease;
    public float champion1DamageScaling, champion2DamageScaling, champion3DamageScaling;

    public void PlayEndingButton()
    {
        rerollButtonObject.SetActive(false);
        isEndingTransition = true;
        audioManager.Play("UI_Click2");
        buttonClickScript.StopStopTime();
        buttonClickScript.StopArrowCoroutine();
        SetCursors.hoveringClickableStuff = false;
        levelUpBlockScreen.SetActive(false);
        bossChosenSetStuffInactive = true;
        blockEndings.SetActive(false);
        endingBackButton.SetActive(false);
        endingPlayEndingButton.SetActive(false);
        endingUiElements.SetActive(false);
        mainXPBar.SetActive(false);
        ending1.SetActive(false); ending2.SetActive(false); ending3.SetActive(false); ending4.SetActive(false);

        if (choosingBoss == true)
        {
            isBossTransition = true;
            mainButton.transform.localPosition = new Vector2(0f, -36f);
            mainArena.SetActive(false);

            bossTextBubble.SetActive(true);
            bossObject.SetActive(true);
            bossArena.SetActive(true);
            bossHEalthBar.SetActive(true);
            BossMechanics.fightingBossFight = true;

            mainCamera.GetComponent<Animator>().enabled = true;
            mainCamera.GetComponent<Animator>().SetTrigger("BossTransition");
            ending1.GetComponent<Animator>().SetTrigger("BossOut");

            //mainCamera.transform.localPosition = new Vector3(0, 80.1f, -10);
            //mainCamera.orthographicSize = 44f;

            StartCoroutine(SetCircleTransition(true, 0.5f));
            StartCoroutine(WaitForBossAnim());
        }
        if (choosingHorde == true)
        {
            isHordeTransition = true;
            Time.timeScale = 1;

            if (movementAbilityAquaried == true) 
            { 
                rocket.SetActive(false);
                chooseRocket = false;
                smallChargeButton.SetActive(false);
                choseButtonBounceCharge = false;
                chooseControllableButton = false;
            }

            arenaIncrease = 0.15f * 5;
            hordeStartCameraSize = 5.36f * 5;
            arenaSpawnPointChangeY = 80 * 5;
            arenaSpawnPointChangeX = 140 * 5;

            choseBouncingBullets = true;
            arenaObject.SetActive(true);

            arenaObject.transform.localScale = new Vector2(1.75f, 1.75f);

            StartCoroutine(WaitForHordeAnim());
            HordeEnding.setHordeCamera = true;
            hordeSlider.SetActive(true);
            wave1.SetActive(true);
            wave2.SetActive(true);
            wave3.SetActive(true);

            StartCoroutine(SetCircleTransition(true, 0.5f));
        }
        if (choosingMimic == true)
        {
            isChampionTransition = true;
            HordeEnding.setHordeCamera = true;
            mainCamera.orthographicSize = 41f;
            mainCamera.transform.localPosition = new Vector3(0, 0, -10);
            //mimicSlider.SetActive(true);
            arenaObject.SetActive(true);
            choseBouncingBullets = true;

            arenaIncrease = (0.15f * 6);
            hordeStartCameraSize = (5.36f * 6);
            arenaSpawnPointChangeY = (85 * 6);
            arenaSpawnPointChangeX = (140 * 6);
            arenaObject.transform.localScale = new Vector2(1.90f, 1.90f);


            if (ButtonClick.level > 75)
            {
                champion1HPIncrease = 50;
                champion1HPScaling = (ButtonClick.level - 75) * champion1HPIncrease;

                champion2HPIncrease = 35;
                champion2HPScaling = (ButtonClick.level - 75) * champion2HPIncrease;

                champion3HPIncrease = 80;
                champion3HPScaling = (ButtonClick.level - 75) * champion3HPIncrease;

                champion1DamageIncrease = 0.1f;
                champion1DamageScaling = (ButtonClick.level - 75) * champion1DamageIncrease;

                champion2DamageIncrease = 0.08f;
                champion2DamageScaling = (ButtonClick.level - 75) * champion2DamageIncrease;

                champion3DamageIncrease = 0.1f;
                champion3DamageScaling = (ButtonClick.level - 75) * champion3DamageIncrease;
            }

            Champion1Movement.champion1HP = 13500 + champion1HPScaling;
            Champion1Movement.champion1SpikeDamage = 37 + champion1DamageScaling;

            Champion2Movement.champion2HP = 12000 + champion2HPScaling;
            Champion2Movement.champion2ArrowDamage = 30 + champion2DamageScaling;

            Champion3.champion3HP = 17000 + champion3HPScaling;
            Champion3.champion3SawBladeDamage = 35 + champion3DamageScaling;

            //Debug.Log(Champion1Movement.champion1HP);
            //Debug.Log(Champion1Movement.champion1SpikeDamage);
            //Debug.Log(Champion2Movement.champion2HP);
            //Debug.Log(Champion2Movement.champion2ArrowDamage);
            //Debug.Log(Champion3.champion3HP);
            //Debug.Log(Champion3.champion3SawBladeDamage);


            mainCamera.orthographicSize = 36 + hordeStartCameraSize;
            mainButton.transform.localPosition = new Vector2(-670f + -arenaSpawnPointChangeX, -0f);

            champion1Stab.SetActive(true); champion2Ranged.SetActive(true); champion3Armored.SetActive(true);

            champion1Stab.transform.localPosition = new Vector2(670 + arenaSpawnPointChangeX, 270 + arenaSpawnPointChangeY);

            champion2Ranged.transform.localPosition = new Vector2(620f + arenaSpawnPointChangeX, -195 + -arenaSpawnPointChangeY);

            champion3Armored.transform.localPosition = new Vector2(620 + arenaSpawnPointChangeX, 0);

            StartCoroutine(SetCircleTransition(true, 0.5f));
            StartCoroutine(WaitForMimicAnim());
        }
        if (choosingDangerbutton == true)
        {
            mainButton.transform.localPosition = new Vector2(0f, -350f);
            mainArena.SetActive(false);
            DangerButtonEnding.isPlayingDangerButton = true;
            dangerButtonArena.SetActive(true);
            dangerButtonObject.SetActive(true);
            dangerButtonTimerSlider.SetActive(true);
            mainCamera.transform.localPosition = new Vector3(0, 4.9f, -10);
            mainCamera.orthographicSize = 80f;

            StartCoroutine(SetCircleTransition(true, 0.5f));
            StartCoroutine(WaitForDangerButtonAnim());

        }

        isInChooseEndingScreen = false;

    }

    public static float bossEndingTransitionTime;
    public static bool bossChosenSetStuffInactive;

    IEnumerator WaitForBossAnim()
    {
        CheckMusicPlaying();

        settingScript.SetOnlyEndingTransitionObjectsBack();

        yield return new WaitForSecondsRealtime(1);
        EnemyCountZero();
      
        audioManager.Play("BossMusic");
        bossMusicPlaying = true;

        buttonBehaviorScript.ResetCharge();
        bossEndingTransitionTime = 4;
        mainButtonColliderScript.StopRocketAndBooster();
        yield return new WaitForSecondsRealtime(2);
        if (pickTalariaForEnding == true) { ChooseControllableButton();  }
        Choises.isPaused = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(1.1f);
        settingScript.SetOnlyArrowsBack();
        isBossTransition = false;

        bossChosenSetStuffInactive = false;
        bossTextBubble.SetActive(false);
        buttonHealth = maxButtonHealth;

        yield return new WaitForSecondsRealtime(0.5f);

        MainButtonCollider.buttonMoveSpeed = 43f;
        isEndingTransition = false;
    }

    public Zoom zoomScript;
    public HordeEnding hordeScript;

    IEnumerator WaitForHordeAnim()
    {
        CheckMusicPlaying();

        buttonBehaviorScript.ResetCharge();
        mainButton.transform.localPosition = new Vector2(0f, -36f);
        mainButtonColliderScript.StopRocketAndBooster();
        zoomScript.SetHordeCamera();

        settingScript.SetOnlyEndingTransitionObjectsBack();

        yield return new WaitForSecondsRealtime(1.1f);
        settingScript.SetOnlyArrowsBack();
        isHordeTransition = false;

        audioManager.Play("HordeMusic");
        hordMusicPlaying = true;

        buttonHealth = maxButtonHealth;
        bossChosenSetStuffInactive = false;
        Choises.isPaused = false;
        HordeEnding.setHordeCamera = false;
        hordeScript.StartHordeEnding();
        buttonHealth = maxButtonHealth;

        yield return new WaitForSecondsRealtime(0.5f);
        isEndingTransition = false;
    }

    IEnumerator WaitForMimicAnim()
    {
        CheckMusicPlaying();

        buttonBehaviorScript.ResetCharge();
        mainButtonColliderScript.StopRocketAndBooster();
        spaceForUIElementsTopLeft.SetActive(false);
        spaceForTopRightTimer.SetActive(false);

        zoomScript.SetHordeCamera();

        settingScript.SetOnlyEndingTransitionObjectsBack();

        yield return new WaitForSecondsRealtime(1.1f);
        settingScript.SetOnlyArrowsBack();
        isChampionTransition = false;

        EnemyCountZero();
        if (pickTalariaForEnding == true) { ChooseControllableButton(); }

        audioManager.Play("ChampionMusic");
        championsMusicPlaying = true;
       
        championScript.StartChampionEnding();

        HordeEnding.setHordeCamera = false;
        Choises.isPaused = false;
        Time.timeScale = 1;
        bossChosenSetStuffInactive = false;
        buttonHealth = maxButtonHealth;
        yield return new WaitForSecondsRealtime(0.5f);
        MainButtonCollider.buttonMoveSpeed = 37;
        isEndingTransition = false;
    }

    public DangerButtonEnding dangerButtonscript;
    IEnumerator WaitForDangerButtonAnim()
    {
        CheckMusicPlaying();

        buttonBehaviorScript.ResetCharge();
        mainButtonColliderScript.StopRocketAndBooster();
        settingScript.ResetGame(true);
        SetOriginalChances();
        ResetAllGameObject(false);

        settingScript.SetKnifesBack();
        settingScript.SetOnlyEndingTransitionObjectsBack();

        yield return new WaitForSecondsRealtime(1.1f);
        settingScript.SetOnlyArrowsBack();
        EnemyCountZero();
        audioManager.Play("DangerMusic");
        buttonClickScript.StopArrowCoroutine();
        dangerButtonMusicPlaying = true;

        if (pickTalariaForEnding == true) { ChooseControllableButton(); choseHealthBar = true;
            rocket.SetActive(false);
            smallChargeButton.SetActive(false);
            choseHealthBar = true;
        }
        if(pickTalariaForEnding == false) 
        { 
            if(smallChargeButton.activeInHierarchy == true) { choseButtonBounceCharge = true; }
            if(rocket.activeInHierarchy == true) { chooseRocket = true; }
        }

        isPaused = false;
        Time.timeScale = 1;
        bossChosenSetStuffInactive = false;
        dangerButtonscript.StartDangerButton();
        buttonHealth = maxButtonHealth;

        yield return new WaitForSecondsRealtime(0.5f);
        buttonClickScript.StopArrowCoroutine();
        MainButtonCollider.buttonMoveSpeed = 51;

        isEndingTransition = false;
    }

    public void CheckMusicPlaying()
    {
        if (SettingsOptions.music1Playing == true) { audioManager.Stop("Music1"); SettingsOptions.music1Playing = false; }
        if (SettingsOptions.music2Playing == true) { audioManager.Stop("Music2"); SettingsOptions.music2Playing = false; }
        if (SettingsOptions.music3Playing == true) { audioManager.Stop("Music3"); SettingsOptions.music3Playing = false; }
        if (SettingsOptions.music4Playing == true) { audioManager.Stop("Music4"); SettingsOptions.music4Playing = false; }
        if (SettingsOptions.music5Playing == true) { audioManager.Stop("Music5"); SettingsOptions.music5Playing = false; }
        if (SettingsOptions.music6Playing == true) { audioManager.Stop("Music6"); SettingsOptions.music6Playing = false; }
        if (SettingsOptions.music7Playing == true) { audioManager.Stop("Music7"); SettingsOptions.music7Playing = false; }

        settingScript.StopSongTimer();
    }

    #endregion

    #region Circular Transition And Alpha Fades
    IEnumerator SetCircleTransition(bool fadeInOrOut, float duration)
    {
        if(fadeInOrOut == false) { audioManager.Play("CircleTranIn"); }
        if (fadeInOrOut == true) { audioManager.Play("CircleTranIn"); }

        if (fadeInOrOut == false) { circle.transform.localPosition = new Vector2(0, 0); }
        if (fadeInOrOut == true) { circle.transform.localPosition = new Vector2(0, 0); }

        float elapsedTime = 0f;
        Vector2 startScale = fadeInOrOut ? new Vector2(35, 35) : Vector2.zero;
        Vector2 targetScale = fadeInOrOut ? Vector2.zero : new Vector2(35, 35);

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            circle.transform.localScale = Vector2.Lerp(startScale, targetScale, t);

            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        circle.transform.localScale = targetScale;
        circle.transform.localPosition = new Vector2(0, 0);
    }

    private void SetAlpha(Graphic graphic, float targetAlpha)
    {
        StartCoroutine(FadeAlpha(graphic, targetAlpha));
    }

    private System.Collections.IEnumerator FadeAlpha(Graphic graphic, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color startColor = graphic.color;

        while (elapsedTime < 0.07f)
        {
            float newAlpha = Mathf.Lerp(startColor.a, targetAlpha, elapsedTime / 0.07f);
            graphic.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

            for (int i = 0; i < graphic.transform.childCount; i++)
            {
                Graphic childGraphic = graphic.transform.GetChild(i).GetComponent<Graphic>();
                if (childGraphic != null)
                {
                    // Recursively fade the alpha of child graphics
                    SetAlpha(childGraphic, targetAlpha);
                }
            }

            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        // Ensure the final alpha value is set
        graphic.color = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
    }
    #endregion

    #region Choose Another Ending
    public void ChooseAnotherEnding()
    {
        endingUiElements.GetComponent<Animator>().SetTrigger("GoDown");
        StartCoroutine(SetCircleTransition(true, 0.37f));
        noHoverGlow = false;
        blockEndings.SetActive(false);
        StartCoroutine(SetEndingButtonsBack());
        blockAbilititesObject.SetActive(true);

        Image ending1Image = ending1.GetComponent<Image>();
        Image ending2Image = ending2.GetComponent<Image>();
        Image ending3Image = ending3.GetComponent<Image>();
        Image ending4Image = ending4.GetComponent<Image>();
        //Image ending5Image = ending5.GetComponent<Image>();


        if (choosingBoss == true)
        {
            ending1.GetComponent<Animator>().SetTrigger("BossOut");

            SetAlpha(ending2Image, 1f);
            SetAlpha(ending3Image, 1f);
            SetAlpha(ending4Image, 1f);
            //SetAlpha(ending5Image, 1f);
        }
        if (choosingHorde == true) 
        { 
            ending2.GetComponent<Animator>().SetTrigger("HordeOut");

            SetAlpha(ending1Image, 1f);
            SetAlpha(ending3Image, 1f);
            SetAlpha(ending4Image, 1f);
            //SetAlpha(ending5Image, 1f);
        }
        if (choosingMimic == true) 
        { 
            ending3.GetComponent<Animator>().SetTrigger("MimicOut");

            SetAlpha(ending1Image, 1f);
            SetAlpha(ending2Image, 1f);
            SetAlpha(ending4Image, 1f);
            //SetAlpha(ending5Image, 1f);
        }
        if (choosingDangerbutton == true)
        {
            ending4.GetComponent<Animator>().SetTrigger("DangerButtonOut");

            SetAlpha(ending1Image, 1f);
            SetAlpha(ending2Image, 1f);
            SetAlpha(ending3Image, 1f);
            //SetAlpha(ending5Image, 1f);
        }
        if (choosingPong == true)
        {
            //ending5.GetComponent<Animator>().SetTrigger("PongOut");

            SetAlpha(ending1Image, 1f);
            SetAlpha(ending2Image, 1f);
            SetAlpha(ending3Image, 1f);
            SetAlpha(ending4Image, 1f);
        }
    }

    IEnumerator SetEndingButtonsBack()
    {
        endingBackButton.GetComponent<Animator>().SetTrigger("LeftOut");
        endingPlayEndingButton.GetComponent<Animator>().SetTrigger("RightOut");

        yield return new WaitForSecondsRealtime(0.4f);

        ending1.GetComponent<Animator>().enabled = false;
        ending2.GetComponent<Animator>().enabled = false;
        ending3.GetComponent<Animator>().enabled = false;
        ending4.GetComponent<Animator>().enabled = false;

        HoverUpgrades.endingTransitionPlaying = false;

        choosingBoss = false;
        choosingHorde = false;
        choosingMimic = false;
        choosingDangerbutton = false;
        choosingPong = false;

        ending1.GetComponent<Button>().interactable = true;
        ending2.GetComponent<Button>().interactable = true;
        ending3.GetComponent<Button>().interactable = true;
        ending4.GetComponent<Button>().interactable = true;
        //ending5.GetComponent<Button>().interactable = true;

        endingBackButton.SetActive(false);
        endingPlayEndingButton.SetActive(false);
        blockAbilititesObject.SetActive(false);
    }
    #endregion

    #region Pick No Ending - Continue Run
    public static bool choseContunieRun;
    public void PickNoEnding()
    {
        isEndingTransition = false;
        audioManager.Play("CircleTranIn");
        saveButton.interactable = true;
        endingBlockAutoSave = false;
        StartCoroutine(EndingsBack());
        choseContunieRun = true;
    }

    IEnumerator EndingsBack()
    {
        isInChooseEndingScreen = false;
        blockAbilititesObject.SetActive(true);

        ending1.GetComponent<Animator>().enabled = true;
        ending2.GetComponent<Animator>().enabled = true;
        ending3.GetComponent<Animator>().enabled = true;
        ending4.GetComponent<Animator>().enabled = true;
        ending5.GetComponent<Animator>().enabled = true;

        endingUiElements.GetComponent<Animator>().SetTrigger("GoBack");
        ending1.GetComponent<Animator>().SetTrigger("AbilityUp");
        ending2.GetComponent<Animator>().SetTrigger("AbilityUp");
        ending3.GetComponent<Animator>().SetTrigger("AbilityUp");
        ending4.GetComponent<Animator>().SetTrigger("AbilityUp");
        //ending5.GetComponent<Animator>().SetTrigger("AbilityUp");
        yield return new WaitForSecondsRealtime(0.25f);
        blockPlayEnding.SetActive(false);
        yield return new WaitForSecondsRealtime(0.25f);

        AbilitiesChoose();
        StartCoroutine(SetBlockAbilitesInactive());
        ending1.SetActive(false); ending2.SetActive(false); ending3.SetActive(false); ending4.SetActive(false);
        //ending5.SetActive(false);
    }
    #endregion

    #region EndingsWin
    public GameObject winScreen;
    public TextMeshProUGUI finishedInText, finishedAtLevelText, completedEndingText;
    public static bool isInWinScreen;
    public string winTimer;
    public GameObject newRunButton, mainMenuButton, exitGameButton;

    public void BossWin()
    {
        buttonBehaviorScript.ResetCharge();

        if (ButtonClick.level == 75 && beatlEndingAtLevel75 == false)
        {
            beatlEndingAtLevel75 = true;
        }

        numberOfGunsCurrentRun = 0;
        numberOfMeleeCurrentRun = 0;

        mainButtonColliderScript.ResetInvin();
        buttonClickScript.StopStopTime();
        choseContunieRun = false;
        BossMechanics.fightingBossFight = false;
        isInWinScreen = true;
        StartCoroutine(BossWinTransition());
    }

    public Button continueButton;
    IEnumerator BossWinTransition()
    {
        audioManager.Stop("BossMusic");
        audioManager.Play("Win");

        newRunButton.GetComponent<Button>().interactable = false;
        mainMenuButton.GetComponent<Button>().interactable = false;
        exitGameButton.GetComponent<Button>().interactable = false;

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        CheckFastestRunTime();
        CheckSoundsPlaying();
        completedEndingText.text = "Completed Ending #1 - Boss";
        finishedAtLevelText.text = "Finished at level " + ButtonClick.level;
        finishedInText.text = "Time finished: " + winTimer;

        settingScript.ResetGame(false);
        SetOriginalChances();
        ResetAllGameObject(true);
        yield return new WaitForSecondsRealtime(0.25f);
        buttonBehaviorScript.ResetCharge();
        mainButtonColliderScript.ResetInvin();
        yield return new WaitForSecondsRealtime(1.75f);
        chooseControllableButton = false;
        winScreen.SetActive(true);
        winScreen.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSecondsRealtime(2);

        newRunButton.GetComponent<Button>().interactable = true;
        mainMenuButton.GetComponent<Button>().interactable = true;
        exitGameButton.GetComponent<Button>().interactable = true;

        endingBlockAutoSave = false;
        dataScript.SaveTheGameData();
    }

    public void DangerButtonWin()
    {
        buttonBehaviorScript.ResetCharge();

        numberOfGunsCurrentRun = 0;
        numberOfMeleeCurrentRun = 0;

        mainButtonColliderScript.ResetInvin();
        choseContunieRun = false;
        DangerButtonEnding.isPlayingDangerButton = false;
        isInWinScreen = true;
        StartCoroutine(DangerbuttonWinTransition());
    }

    IEnumerator DangerbuttonWinTransition()
    {
        audioManager.Stop("DangerMusic");
        audioManager.Play("Win");

        newRunButton.GetComponent<Button>().interactable = false;
        mainMenuButton.GetComponent<Button>().interactable = false;
        exitGameButton.GetComponent<Button>().interactable = false;

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        CheckFastestRunTime();
        CheckSoundsPlaying();

        completedEndingText.text = "Completed Ending #4 - Danger Button";
        finishedAtLevelText.text = "Finished at level " + ButtonClick.level;
        finishedInText.text = "Time finished: " + winTimer;

        yield return new WaitForSecondsRealtime(0.4f);
        winScreen.SetActive(true);
        winScreen.GetComponent<Animator>().SetTrigger("Death");
        settingScript.ResetGame(false);
        SetOriginalChances();
        ResetAllGameObject(true);
        chooseControllableButton = false;

        yield return new WaitForSecondsRealtime(2);
        newRunButton.GetComponent<Button>().interactable = true;
        mainMenuButton.GetComponent<Button>().interactable = true;
        exitGameButton.GetComponent<Button>().interactable = true;

        endingBlockAutoSave = false;
        dataScript.SaveTheGameData();
    }


    public void ChampionWin()
    {
        buttonBehaviorScript.ResetCharge();

        numberOfGunsCurrentRun = 0;
        numberOfMeleeCurrentRun = 0;

        mainButtonColliderScript.ResetInvin();
        buttonClickScript.StopStopTime();
        choseContunieRun = false;
        MimicEnding.isPlayingMimicEnding = false;
        isInWinScreen = true;
        StartCoroutine(ChampionWinTransition());
    }

    IEnumerator ChampionWinTransition()
    {
        if (ButtonClick.level == 75 && beatlEndingAtLevel75 == false)
        {
            beatlEndingAtLevel75 = true;
        }

        audioManager.Stop("ChampionMusic");
        audioManager.Play("Win");

        newRunButton.GetComponent<Button>().interactable = false;
        mainMenuButton.GetComponent<Button>().interactable = false;
        exitGameButton.GetComponent<Button>().interactable = false;

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        CheckFastestRunTime();
        CheckSoundsPlaying();

        completedEndingText.text = "Completed Ending #3 - Angry Champions";
        finishedAtLevelText.text = "Finished at level " + ButtonClick.level;
        finishedInText.text = "Time finished: " + winTimer;

        yield return new WaitForSecondsRealtime(0.2f);
        buttonBehaviorScript.ResetCharge();
        mainButtonColliderScript.ResetInvin();
        yield return new WaitForSecondsRealtime(0.2f);
        winScreen.SetActive(true);
        winScreen.GetComponent<Animator>().SetTrigger("Death");
        settingScript.ResetGame(false);
        SetOriginalChances();
        ResetAllGameObject(true);
        chooseControllableButton = false;

        yield return new WaitForSecondsRealtime(2);
        newRunButton.GetComponent<Button>().interactable = true;
        mainMenuButton.GetComponent<Button>().interactable = true;
        exitGameButton.GetComponent<Button>().interactable = true;

        endingBlockAutoSave = false;
        dataScript.SaveTheGameData();
        
    }

    public void CheckSoundsPlaying()
    {
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
    }

    public static bool beatSpeedrunner;

    public void CheckFastestRunTime()
    {
        saveButton.interactable = true;

        isInChooseEndingScreen = false;
        Cursor.visible = true;
        if (SettingsOptions.firstRunCompleted == false)
        {
            if (SettingsOptions.timeMinutes >= SettingsOptions.fastestRunMinutes)
            {
                SettingsOptions.fastestRunMinutes = SettingsOptions.timeMinutes;
            }

            if (SettingsOptions.currentTime >= SettingsOptions.fastestRunSeconds)
            {
                SettingsOptions.fastestRunSeconds = SettingsOptions.currentTime;
                if (SettingsOptions.currentTime == 59 && SettingsOptions.fastestRunSeconds == 59)
                {
                    SettingsOptions.fastestRunSeconds = 59;
                }
            }

            if (SettingsOptions.currentTime != 59 && SettingsOptions.fastestRunSeconds == 59)
            {
                SettingsOptions.fastestRunSeconds = 0;
            }

            SettingsOptions.firstRunCompleted = true;
        }
        else
        {
            if (SettingsOptions.timeMinutes < SettingsOptions.fastestRunMinutes)
            {
                SettingsOptions.fastestRunMinutes = SettingsOptions.timeMinutes;
            }

            if (SettingsOptions.currentTime < SettingsOptions.fastestRunSeconds)
            {
                SettingsOptions.fastestRunSeconds = SettingsOptions.currentTime;
                if (SettingsOptions.currentTime == 59 && SettingsOptions.fastestRunSeconds == 59)
                {
                    SettingsOptions.fastestRunSeconds = 59;
                }
            }

            if (SettingsOptions.currentTime != 59 && SettingsOptions.fastestRunSeconds == 59)
            {
                SettingsOptions.fastestRunSeconds = 0;
            }
        }

        if(SettingsOptions.timeMinutes < Achievements.speedrunnerAchTime)
        {
            beatSpeedrunner = true;
        }

        noHoverGlow = false;
        HoverUpgrades.endingTransitionPlaying = false;
    }
    #endregion

    #region PauseGame
    public static bool isPaused, setVariables;
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        setVariables = true;
    }
    #endregion

    #region Play Endings Inside Settings Tab
    public GameObject endingsSettingButton, endingFrameSetting, chooseToPlayEndingScreen, settingFrame, settingPopUp, settingGlow, settingButton;
    public TextMeshProUGUI playEndingText, noMovementSettingsText;

    public void PlayBoss()
    {
        choosingBoss = false;
        choosingHorde = false;
        choosingMimic = false;
        choosingDangerbutton = false;
        chooseToPlayEndingScreen.SetActive(true);
        PlayEndingFromSetting(1);
        playEndingText.text = LocalizationVariables.playBossString;
    }
    public void PlayHorde()
    {
        choosingBoss = false;
        choosingHorde = false;
        choosingMimic = false;
        choosingDangerbutton = false;
        chooseToPlayEndingScreen.SetActive(true);
        PlayEndingFromSetting(2);
        playEndingText.text = LocalizationVariables.playHordeString;
    }
    public void PlayChampions()
    {
        choosingBoss = false;
        choosingHorde = false;
        choosingMimic = false;
        choosingDangerbutton = false;
        chooseToPlayEndingScreen.SetActive(true);
        PlayEndingFromSetting(3);
        playEndingText.text = LocalizationVariables.playChampionsString;
    }
    public void PlayDangerButton()
    {
        choosingBoss = false;
        choosingHorde = false;
        choosingMimic = false;
        choosingDangerbutton = false;
        chooseToPlayEndingScreen.SetActive(true);
        PlayEndingFromSetting(4);
        playEndingText.text = LocalizationVariables.playDangerButtonStrung;
    }

    public void PlayEndingYes()
    {
        SetChosenAbilititesInactive();
        saveButton.interactable = false;
        SettingsOptions.isInSettings = false;
        settingPopUp.SetActive(false);
        settingGlow.transform.position = settingButton.transform.position;
        settingFrame.SetActive(true);
        endingsSettingButton.SetActive(false);
        endingFrameSetting.SetActive(false);
        chooseToPlayEndingScreen.SetActive(false);
        PlayEndingButton();
    }

    public void PlayEndingNo()
    {
        audioManager.Play("UI_Click2");
        chooseToPlayEndingScreen.SetActive(false);
    }

    public void PlayEndingFromSetting(int ending)
    {
        endingBlockAutoSave = true;
        audioManager.Play("UI_Click2");
        if (ending == 1) { choosingBoss = true; NoMovementSetting(); }
        if (ending == 2)
        {
            choosingHorde = true; 
            talariaYesButtonSetting.SetActive(false); talariaNoButtonSetting.SetActive(false);
            talariaFrameSettings.SetActive(false); talariaCrossSettings.SetActive(false);
            talariaCheckMarkSetting.SetActive(false);
            noMovementSettingsText.text = "";
        }
        if (ending == 3) { choosingMimic = true; NoMovementSetting(); }
        if (ending == 4) { choosingDangerbutton = true; NoMovementSetting(); }
    }


    public void NoMovementSetting()
    {
        if(movementAbilityAquaried == false)
        {
            pickTalariaForEnding = true;
            talariaYesButtonSetting.SetActive(false); talariaNoButtonSetting.SetActive(false);
            talariaFrameSettings.SetActive(true); talariaCrossSettings.SetActive(false);
            talariaCheckMarkSetting.SetActive(true);
            noMovementSettingsText.text = "<color=green>You do not have any movement abilities. You will be given the \"TALARIA.\" Controll the button using WASD.";
        }
        else
        {
            if(chooseControllableButton == false)
            {
                talariaYesButtonSetting.SetActive(true); talariaNoButtonSetting.SetActive(true);
                talariaFrameSettings.SetActive(true); talariaCrossSettings.SetActive(true);
                talariaCheckMarkSetting.SetActive(false);
                pickTalariaForEnding = false;

                if (choseButtonBounceCharge == true) { noMovementSettingsText.text = "<color=green>You have the Booster movement ability. Would you like the \"TALARIA\" instead for this ending? You controll the button with WASD."; }

                if (chooseRocket == true) { noMovementSettingsText.text = "<color=green>You have the Rocket movement ability. Would you like the \"TALARIA\" instead for this ending? You controll the button with WASD."; }
            }
            if (chooseControllableButton == true)
            {
                talariaYesButtonSetting.SetActive(false); talariaNoButtonSetting.SetActive(false);
                talariaFrameSettings.SetActive(false); talariaCrossSettings.SetActive(false);
                talariaCheckMarkSetting.SetActive(false);
                noMovementSettingsText.text = "";
            }
        }
    }

    public GameObject talariaCheckMarkSetting, talariaCrossSettings, talariaFrameSettings, talariaYesButtonSetting, talariaNoButtonSetting;

    public void YesTalariaSettings()
    {
        talariaCrossSettings.SetActive(false); talariaCheckMarkSetting.SetActive(true);
        pickTalariaForEnding = true;
    }

    public void NoTalariaSettings()
    {
        talariaCrossSettings.SetActive(true); talariaCheckMarkSetting.SetActive(false);
        pickTalariaForEnding = false; 
    }

    #endregion

    #region set enemy count 0
    public void EnemyCountZero()
    {
        SpawnEnemies.smallEnemyCount = 0;
        SpawnEnemies.speedsterCount = 0;
        SpawnShootingEnemy.shootingEnemyCount = 0;
        SpawnShootingEnemy.sniperCount = 0;
        SpawnShootingEnemy.heavyShotCount = 0;
        SpawnShootingEnemy.ragingGunnerCount = 0;
        SpawnBigEnemy.bigEnemyCount = 0;
        SpawnBigEnemy.titanCount = 0;
    }
    #endregion

    public float fadeInTime;

    #region Block Abilites
    IEnumerator SetBlockAbilitesInactive()
    {
        blockAbilititesObject.SetActive(true);

        if (choseReroll == true) { StartCoroutine(FadeInReroll()); }

        if (numberOfChoises == 3)
        {
            yield return new WaitForSecondsRealtime(0.82f);
        }
        if (numberOfChoises == 4)
        {
            yield return new WaitForSecondsRealtime(1.02f);
        }
        if (numberOfChoises == 5)
        {
            yield return new WaitForSecondsRealtime(1.22f);
        }

        if(MobileScript.isMobile == true)
        {
            if (levelupsForAds >= totalLevelForAds)
            {
                levelupsForAds = 0;
                if(InAppPurchase.isAdsRemoved == false && InAppPurchase.isAdsRemovedPlayerprefs == 0)
                {
                    if(ButtonClick.level != 75)
                    {
                        if (numberOfChoises == 3)
                        {
                            yield return new WaitForSecondsRealtime(0.25f);
                        }
                        if (numberOfChoises == 4)
                        {
                            yield return new WaitForSecondsRealtime(0.32f);
                        }
                        if (numberOfChoises == 5)
                        {
                            yield return new WaitForSecondsRealtime(0.42f);
                        }

                        if (MobileScript.isThisIOS == false)
                        {
                            AdsManager.Instance.interstitialAds.ShowInterstitialAd();
                        }
                    }
                }
            }
        }

        blockAbilititesObject.SetActive(false);
    }
    #endregion

    public static bool allAbiliitesSpawnedIn;


    //Fade in abilites
    #region Fade IN Abilitites

    public bool choseAnimPlaying;
    public static bool pistolSpawnedEnemy, uziSpawnedEnemy;
    public static int random2ArrayPos, random3ArrayPos, random5ArrayPos;
    public bool random2Appeared, random3Appeared, random5Appeared;

    public int fadeSounds;
    IEnumerator FadeInAbilitites(GameObject ability)
    {
        choiseYPos = 900;

        if (choisesChosen == 1) { ability.transform.localPosition = new Vector2(choise1Xpos, choiseYPos); }
        if (choisesChosen == 2) { ability.transform.localPosition = new Vector2(choise2Xpos, choiseYPos); }
        if (choisesChosen == 3) { ability.transform.localPosition = new Vector2(choise3Xpos, choiseYPos); }
        if (choisesChosen == 4) { ability.transform.localPosition = new Vector2(choise4Xpos, choiseYPos); }
        if (choisesChosen == 5) { ability.transform.localPosition = new Vector2(choise5Xpos, choiseYPos); }

        //Debug.Log("Fade IN");
        ability.SetActive(true);
        SetAlpha(ability.GetComponent<Image>(), 1f);
        
        if (chose_Gun1 == false) { if (ability.gameObject.name == "Choise_Pistol_Uncommon") { SetRandomEnemyText(ability, 1);  } }
        if(choseShootSmallBullets == false) { if (ability.gameObject.name == "Choise_Chaotic_Uncommon") { SetRandomEnemyText(ability, 2);  }  }
        if (chose_gun2 == false) { if (ability.name == "Choise_Shotgun_Rare") { SetRandomEnemyText(ability, 3); } }
        if (chooseHomingBullets == false) { if (ability.name == "Choise_HomingGun_Rare") { SetRandomEnemyText(ability, 4); } }
        if (choseCrossBow == false) { if (ability.name == "Choise_CrossBow_Rare") { SetRandomEnemyText(ability, 5); } }
        if (choseTrippleShot == false) { if (ability.name == "Choise_TrippleShot_Rare") { SetRandomEnemyText(ability, 6); } }
        if (chooseBigPiercingBulletGun == false) { if (ability.name == "Choise_Cannon_Legendary") { SetRandomEnemyText(ability, 7); } }
        if (choseGunMp4 == false) { if (ability.name == "Choise_Mp4_Legendary") { SetRandomEnemyText(ability, 8); } }

        if (ability.gameObject.name == "Choise_MorePoints_Common") { SetMorePointsText(); }
        if (ability.gameObject.name == "Choise_IdleClicks_Common") { SetIdleUpgrade(); }
        if (ability.gameObject.name == "Choise_CritClicks_Common") { SetCritUpgrade(); }

        #region Set Gun Ability Texts
        //Guns
        if (ability.gameObject.name == "Choise_Chaotic_Uncommon") { SetUziUpgrade(false); }
        if (ability.gameObject.name == "Choise_Pistol_Uncommon") { SetPistolUpgrade(false); }
        if (ability.gameObject.name == "Choise_Shotgun_Rare") { SetShotgunUpgrade(false); }
        if (ability.gameObject.name == "Choise_HomingGun_Rare") { SetAWPUpgrade(false); }
        if (ability.gameObject.name == "Choise_CrossBow_Rare") { SetCrossbowUpgrade(false); }
        if (ability.gameObject.name == "Choise_TrippleShot_Rare") { SetTrippleShotUpgrade(false); }
        if (ability.gameObject.name == "Choise_Mp4_Legendary") { SetMP4Upgrade(false); }
        if (ability.gameObject.name == "Choise_Cannon_Legendary") { SetCannonUpgrade(false); }

        if (ability.gameObject.name == "Choise_ChaticGunImproved_Common") { SetUziUpgrade(true); }
        if (ability.gameObject.name == "Choise_PistolImproved_Common") { SetPistolUpgrade(true); }
        if (ability.gameObject.name == "Choise_ShotgunImproved_Common") { SetShotgunUpgrade(true); }
        if (ability.gameObject.name == "Choise_CannonImproved_Common") { SetCannonUpgrade(true); }
        if (ability.gameObject.name == "Choise_HomingGunImproved_Common") { SetAWPUpgrade(true); }
        if (ability.gameObject.name == "Choise_Mp4_Common") { SetMP4Upgrade(true); }
        if (ability.gameObject.name == "Choise_Crossbow_Common") { SetCrossbowUpgrade(true); }
        if (ability.gameObject.name == "Choise_TrippleShot_Common") { SetTrippleShotUpgrade(true); }
        #endregion

        #region Set Other Ranged
        if (ability.gameObject.name == "Choise_ChargedBullets_rare") { SetChargedBulletUpgrade(false); }
        if (ability.gameObject.name == "Choise_Arrows_Legendary") { SetArrowUpgrade(false); }

        if (ability.gameObject.name == "Choise_ChargedBullets_Common") { SetChargedBulletUpgrade(true); }
        if (ability.gameObject.name == "Choise_Arrows_Common") { SetArrowUpgrade(true); }
        #endregion

        #region Melee
        if (ability.gameObject.name == "Choise_BoxingGlove_Uncommon") { SetBoxingGloveUpgrade(false); }
        if (ability.gameObject.name == "Choise_StabbingSpikes_Uncommon") { SetStabbySpikedUpgrade(false); }
        if (ability.gameObject.name == "Choise_SmallSpikes_Uncommon") { SetSmallSpikesUpgrade(false); }
        if (ability.gameObject.name == "Choise_SpinningKnifes_Uncommon") { SetKnifeUpgrade(false); }
        if (ability.gameObject.name == "Choise_SawBlade_Rare") { SetSawBladeUpgrade(false); }
        if (ability.gameObject.name == "Choise_SpinningSword_Legendary") { SetSwordUpgrade(false); }
        if (ability.gameObject.name == "Choise_Hammer_Legendary") { SetHammeRUpgrade(false); }

        if (ability.gameObject.name == "Choise_BoxingGlove_Common") { SetBoxingGloveUpgrade(true); }
        if (ability.gameObject.name == "Choise_StabbingSpikes_Common") { SetStabbySpikedUpgrade(true); }
        if (ability.gameObject.name == "Choise_SmallSpikes_Common") { SetSmallSpikesUpgrade(true); }
        if (ability.gameObject.name == "Choise_SpinningKnifes_Common") { SetKnifeUpgrade(true); }
        if (ability.gameObject.name == "Choise_SawBlade_Common") { SetSawBladeUpgrade(true); }
        if (ability.gameObject.name == "Choise_SwordImproved_Common") { SetSwordUpgrade(true); }
        if (ability.gameObject.name == "Choise_Hammer_Common") { SetHammeRUpgrade(true); }
        #endregion

        #region Defense
        if (ability.gameObject.name == "Choise_HealthBar_Common") { SetHealthUpgrade(); }
        if (ability.gameObject.name == "Choise_BigHeart_Uncommon") { SetHeartCollect(false); }
        if (ability.gameObject.name == "Choise_SmallShields_Uncommon") { SetSmallShieldUpgrade(false); }
        if (ability.gameObject.name == "Choise_ButtonShield_Rare") { SetShieldBounceUpgrade(false); }

        if (ability.gameObject.name == "Choise_BigHeart_Common") { SetHeartCollect(true); }
        if (ability.gameObject.name == "Choise_SmallShields_Common") { SetSmallShieldUpgrade(true); }
        if (ability.gameObject.name == "Choise_ButtonShieldUpgrade_Common") { SetShieldBounceUpgrade(true); }
        #endregion

        #region Other
        if (ability.gameObject.name == "Choise_CreateArena_Uncommon") { SetArenaUpgrade(); }
        if (ability.gameObject.name == "Choise_PointsDrop_Uncommon") { SetPointDropUpgrade(false); }
        if (ability.gameObject.name == "Choise_ReRoll5X_Rare") { SetRerollUpgrade(true); }
        if (ability.gameObject.name == "Choise_ReRoll3X_Legendary") { SetRerollUpgrade(false); }
        if (ability.gameObject.name == "Choise_Invincibility_Legendary") { SetInvincibilityUpgrade(false); }
        if (ability.gameObject.name == "Choise_Ritual_Legendary") { SetRitualUpgrade(false); }
        if (ability.gameObject.name == "Choise_SoulSucker_Mythic") { SetSkullHarvestUpgrade(); }
        if (ability.gameObject.name == "Choise_Pausetime_Mythic") { SetStopWatchUpgrade(false); }

        if (ability.gameObject.name == "Choise_PointsDrop_Common") { SetPointDropUpgrade(true); }
        if (ability.gameObject.name == "Choise_Invincibility_Common") { SetInvincibilityUpgrade(true); }
        if (ability.gameObject.name == "Choise_Ritual_Common") { SetRitualUpgrade(true); }
        if (ability.gameObject.name == "Choise_SoulSucker_Common") { SetSkullHarvestUpgrade(); }
        if (ability.gameObject.name == "Choise_Pausetime_Common") { SetStopWatchUpgrade(true); }
        #endregion

        if (ability.gameObject.name == "Choise_Booster_Rare") { localizationScript.MovementText(); }
        if (ability.gameObject.name == "Choise_Rocket_Legendary") { localizationScript.MovementText(); }
        if (ability.gameObject.name == "Choise_ControllButton_Mythic") { localizationScript.MovementText(); }

        allAbiliitesSpawnedIn = true;

        if(choisesChosen == 1) { abilitesToReroll[0] = ability; }
        if (choisesChosen == 2) { abilitesToReroll[1] = ability; }
        if (choisesChosen == 3) { abilitesToReroll[2] = ability; }
        if (choisesChosen == 4) { abilitesToReroll[3] = ability; }
        if (choisesChosen == 5) { abilitesToReroll[4] = ability; }

        #region Random 

        if(ability.gameObject.name == "Choise_2RandomAbilitites_Uncommon") { ability.gameObject.GetComponent<Button>().interactable = true; }
        if (ability.gameObject.name == "Choise_3RandomAbilititesRare") { ability.gameObject.GetComponent<Button>().interactable = true; }
        if (ability.gameObject.name == "Choise_5RandomAbilitites") { ability.gameObject.GetComponent<Button>().interactable = true; }

        if (choisesChosen == 1) { if (abilitesToReroll[0].name == "Choise_2RandomAbilitites_Uncommon") { random2ArrayPos = 0; random2Appeared = true; } }
        if (choisesChosen == 2) { if (abilitesToReroll[1].name == "Choise_2RandomAbilitites_Uncommon") { random2ArrayPos = 1; random2Appeared = true; } }
        if (choisesChosen == 3) { if (abilitesToReroll[2].name == "Choise_2RandomAbilitites_Uncommon") { random2ArrayPos = 2; random2Appeared = true; } }
        if (choisesChosen == 4) { if (abilitesToReroll[3].name == "Choise_2RandomAbilitites_Uncommon") { random2ArrayPos = 3; random2Appeared = true; } }
        if (choisesChosen == 5) { if (abilitesToReroll[4].name == "Choise_2RandomAbilitites_Uncommon") { random2ArrayPos = 4; random2Appeared = true; } }

        if (choisesChosen == 1) { if (abilitesToReroll[0].name == "Choise_3RandomAbilititesRare") { random3ArrayPos = 0; random3Appeared = true; } }
        if (choisesChosen == 2) { if (abilitesToReroll[1].name == "Choise_3RandomAbilititesRare") { random3ArrayPos = 1; random3Appeared = true; } }
        if (choisesChosen == 3) { if (abilitesToReroll[2].name == "Choise_3RandomAbilititesRare") { random3ArrayPos = 2; random3Appeared = true; } }
        if (choisesChosen == 4) { if (abilitesToReroll[3].name == "Choise_3RandomAbilititesRare") { random3ArrayPos = 3; random3Appeared = true; } }
        if (choisesChosen == 5) { if (abilitesToReroll[4].name == "Choise_3RandomAbilititesRare") { random3ArrayPos = 4; random3Appeared = true; } }

        if (choisesChosen == 1) { if (abilitesToReroll[0].name == "Choise_5RandomAbilitites") { random5ArrayPos = 0; random5Appeared = true; } }
        if (choisesChosen == 2) { if (abilitesToReroll[1].name == "Choise_5RandomAbilitites") { random5ArrayPos = 1; random5Appeared = true; } }
        if (choisesChosen == 3) { if (abilitesToReroll[2].name == "Choise_5RandomAbilitites") { random5ArrayPos = 2; random5Appeared = true; } }
        if (choisesChosen == 4) { if (abilitesToReroll[3].name == "Choise_5RandomAbilitites") { random5ArrayPos = 3; random5Appeared = true; } }
        if (choisesChosen == 5) { if (abilitesToReroll[4].name == "Choise_5RandomAbilitites") { random5ArrayPos = 4; random5Appeared = true; } }
        #endregion

        ability.transform.localScale = new Vector2(choiseScale, choiseScale);

        if (choisesChosen == 1) { ability.transform.localPosition = new Vector2(choise1Xpos, choiseYPos); }
        if (choisesChosen == 2) { ability.transform.localPosition = new Vector2(choise2Xpos, choiseYPos); }
        if (choisesChosen == 3) { ability.transform.localPosition = new Vector2(choise3Xpos, choiseYPos); }
        if (choisesChosen == 4) { ability.transform.localPosition = new Vector2(choise4Xpos, choiseYPos); }
        if (choisesChosen == 5) { ability.transform.localPosition = new Vector2(choise5Xpos, choiseYPos); }

        yield return new WaitForSecondsRealtime(fadeInTime);

        fadeSounds += 1;
        if(fadeSounds == 1) { audioManager.Play("FadeIn1"); }
        if (fadeSounds == 2) { audioManager.Play("FadeIn2"); }
        if (fadeSounds == 3) { audioManager.Play("FadeIn3"); }
        if (fadeSounds == 4) { audioManager.Play("FadeIn4"); }
        if (fadeSounds == 5) { audioManager.Play("FadeIn4"); }

        if (numberOfChoises == 3 && choisesChosen == 3)
        {
            if (choseAnimPlaying == false) { chooseAbilityAnim.GetComponent<Animator>().SetTrigger("In");  }
            choseAnimPlaying = true;
        }
        if (numberOfChoises == 4 && choisesChosen == 4) 
        {
            if (choseAnimPlaying == false) { chooseAbilityAnim.GetComponent<Animator>().SetTrigger("In");  }
            choseAnimPlaying = true;
        }
        if (numberOfChoises == 5 && choisesChosen == 5)
        {
            if (choseAnimPlaying == false) { chooseAbilityAnim.GetComponent<Animator>().SetTrigger("In");  }
            choseAnimPlaying = true;
        }

        ability.GetComponent<Animator>().enabled = true;
        ability.GetComponent<Animator>().SetTrigger("FadeIn");
    }
    #endregion


    #region Random Ability Choises
    public static int commonChance, uncommonChance, rareChance, legendaryChance;

    public void SetOriginalChances()
    {
        commonChance = 99;
        uncommonChance = 95;
        rareChance = 97;
        legendaryChance = 97;
    }

    public void DecreaseOrIncreaseChances(int rarity, int common, int uncommon, int rare, int legendary)
    {
        //if(rarity == 1) { Debug.Log("Common"); }
        //if (rarity == 2) { Debug.Log("Uncommon"); }
        //if (rarity == 3) { Debug.Log("Rare"); }
        //if (rarity == 4) { Debug.Log("Legendary"); }
        //if (rarity == 5) { Debug.Log("Mythic"); }

        if (rarity == 1)
        {
            commonChance -= common; 
            uncommonChance -= uncommon; 
            rareChance -= rare; 
            legendaryChance -= legendary;
        }

        if (rarity == 2)
        {
            commonChance += common; 
            uncommonChance += uncommon; 
            rareChance -= rare; 
            legendaryChance -= legendary; 
        }

        if (rarity == 3)
        {
             commonChance += common; 
             uncommonChance += uncommon; 
             rareChance += rare; 
             legendaryChance -= legendary; 
        }

        if (rarity == 4)
        {
            commonChance += common;
            uncommonChance += uncommon;
            rareChance += rare;
            legendaryChance += legendary;
        }

        if (rarity == 5)
        {
            commonChance += common;
            uncommonChance += uncommon;
            rareChance += rare;
            legendaryChance += legendary;
        }

        if (commonChance < 10) { commonChance = 10; }

        if(ButtonClick.level < 20)
        {
            if (commonChance > 99) { commonChance = 99; }
        }
        if (ButtonClick.level >= 20)
        {
            if (commonChance > 94) { commonChance = 94; }
        }

        if (uncommonChance < 20) { uncommonChance = 20; }
        if (uncommonChance > 95) { uncommonChance = 95; }

        if (rareChance < 15) { rareChance = 15; }
        if (rareChance > 97) { rareChance = 97; }

        if (legendaryChance < 20) { legendaryChance = 20; }
        if (legendaryChance > 97) { legendaryChance = 97; }
    }

    public void ChoseCommonSetChance()
    {
        int randomChange = Random.Range(5,7);
        DecreaseOrIncreaseChances(1, randomChange, 3, 2, 0);
    }
    public void ChoseUncommonSetChance()
    {
        DecreaseOrIncreaseChances(2, 3, 2, 1, 1);
    }
    public void ChoseRareSetChance()
    {
        DecreaseOrIncreaseChances(3, 5, 3, 3, 1);
    }
    public void ChoseLegendarySetChance()
    {
        DecreaseOrIncreaseChances(4, 6, 5, 4, 4);
    }
    public void ChoseMythicSetChance()
    {
        DecreaseOrIncreaseChances(5, 6, 4, 4, 4);
    }

    public void RandomChoises()
    {
        fadeInTime += 0.23f;
        int randomGetCommon = Random.Range(1, 101);
        int randomGetUnCommon = Random.Range(1, 101);
        int randomGetRare = Random.Range(1, 101);
        int randomGetLegendary = Random.Range(1, 101);

        //Checks all Common abilities
        if(randomGetCommon < commonChance)
        {
            RandomCommonAbilites();
            //Debug.Log("Chose: COMMON");
        }
        else if( randomGetUnCommon < uncommonChance)
        {
            RandomUnCommonAbilites();
            //Debug.Log("Chose: UNCOMMON");
        }
        else if (randomGetRare < rareChance)
        {
            RandomRareAbilites();
            //Debug.Log("Chose: RARE");
        }
        else if (randomGetLegendary < legendaryChance)
        {
            RandomLegendaryAbilites();
            //Debug.Log("Chose: LEGENDARY");
        }
        else {
            //Debug.Log("Chose: MYTHIC");
            RandomMythicAbilites(); 
        }
    }
    #endregion

    #region All Random Abilites
    public bool gotBulletOrGun;

    public GameObject[] allCommonAbilitites, allUncommonAbilities, allRareAbilitites, allLegendaryAbilities;
    public GameObject[] activeCommonAbilities, activeUnCommonAbilities, activeRareAbilities, activeLegendaryAbilities;
    public int chose1Common,chose2Common,chose3Common, chose4Common;
    public bool got1CommonChoise, got2CommonChoise, got3CommonChoise, got4CommonChoise;

    public int chose1UnCommon, chose2UnCommon, chose3UnCommon, chose4UnCommon;
    public bool got1UnCommonChoise, got2UnCommonChoise, got3UnCommonChoise, got4UnCommonChoise;

    public int chose1Rare, chose2Rare, chose3Rare, chose4Rare;
    public bool got1RareChoise, got2RareChoise, got3RareChoise, got4RareChoise;

    public int chose1Legendary, chose2Legendary, chose3Legendary, chose4Legendary;
    public bool got1LegendaryChoice, got2LegendaryChoice, got3LegendaryChoice, got4LegendaryChoice;

    public int numberOfCommonChoises, numberOfUnCommonChoises, numberOfRareChoises, numberOfLegendaryChoices;
    public int choisesChosen;

    public void RandomCommonAbilites()
    {
        int commonChoises = commonAbilitiesAviable + 1;
        if(numberOfCommonChoises == commonChoises)
        {
            RandomUnCommonAbilites();
            return;
        }

        numberOfCommonChoises += 1;
        choisesChosen += 1;

        #region choose common ability
        if (got1CommonChoise == false)
        {
            int randomCommon1 = Random.Range(0, activeCommonAbilities.Length - commonAbilitesNotAviable);
            //Debug.Log(randomCommon1);
            //activeCommonAbilities[randomCommon1].SetActive(true);
            chose1Common = randomCommon1;
            StartCoroutine(FadeInAbilitites(activeCommonAbilities[randomCommon1]));
        }

        if(got1CommonChoise == true && got2CommonChoise == false)
        {
            int randomCommon2;

            do
            {
                randomCommon2 = Random.Range(0, activeCommonAbilities.Length - commonAbilitesNotAviable);
            } while (randomCommon2 == chose1Common);

            //Debug.Log(randomCommon2);
            //activeCommonAbilities[randomCommon2].SetActive(true);
            chose2Common = randomCommon2;
            StartCoroutine(FadeInAbilitites(activeCommonAbilities[randomCommon2]));
        }

        if (got2CommonChoise == true && got3CommonChoise == false)
        {
            int randomCommon3;

            do
            {
                randomCommon3 = Random.Range(0, activeCommonAbilities.Length - commonAbilitesNotAviable);
            } while (randomCommon3 == chose1Common || randomCommon3 == chose2Common);

            //Debug.Log(randomCommon3);
            //activeCommonAbilities[randomCommon3].SetActive(true);
            chose3Common = randomCommon3;
            StartCoroutine(FadeInAbilitites(activeCommonAbilities[randomCommon3]));
        }

        if (got3CommonChoise == true && got4CommonChoise == false)
        {
            int randomCommon4;

            do
            {
                randomCommon4 = Random.Range(0, activeCommonAbilities.Length - commonAbilitesNotAviable);
            } while (randomCommon4 == chose1Common || randomCommon4 == chose2Common || randomCommon4 == chose3Common);

            //Debug.Log(randomCommon4);
            //activeCommonAbilities[randomCommon4].SetActive(true);
            chose4Common = randomCommon4;
            StartCoroutine(FadeInAbilitites(activeCommonAbilities[randomCommon4]));
        }

        if (got4CommonChoise == true)
        {
            int randomCommon5;

            do
            {
                randomCommon5 = Random.Range(0, activeCommonAbilities.Length - commonAbilitesNotAviable);
            } while (randomCommon5 == chose1Common || randomCommon5 == chose2Common || randomCommon5 == chose3Common || randomCommon5 == chose4Common);

            //Debug.Log(randomCommon5);
            //activeCommonAbilities[randomCommon5].SetActive(true);
            StartCoroutine(FadeInAbilitites(activeCommonAbilities[randomCommon5]));
        }
        #endregion

        if (got3CommonChoise == true) { got4CommonChoise = true; }
        if (got2CommonChoise == true) { got3CommonChoise = true; }
        if (got1CommonChoise == true) { got2CommonChoise = true; }
        got1CommonChoise = true;
    }

    public void RandomUnCommonAbilites()
    {
        int uncommonChoises = unCommonAbilitiesAviable +1;
        if (numberOfUnCommonChoises == uncommonChoises)
        {
            RandomRareAbilites();
            return;
        }

        numberOfUnCommonChoises += 1;
        choisesChosen += 1;

        #region choose uncommon ability
        if (got1UnCommonChoise == false)
        {
            int randomUnCommon1 = Random.Range(0, activeUnCommonAbilities.Length - unCommonAbilitesNotAviable);
            //Debug.Log(randomUnCommon1);
            //activeUnCommonAbilities[randomUnCommon1].SetActive(true);
            chose1UnCommon = randomUnCommon1;
            StartCoroutine(FadeInAbilitites(activeUnCommonAbilities[randomUnCommon1]));
        }

        if (got1UnCommonChoise == true && got2UnCommonChoise == false)
        {
            int randomUnCommon2;

            do
            {
                randomUnCommon2 = Random.Range(0, activeUnCommonAbilities.Length - unCommonAbilitesNotAviable);
            } while (randomUnCommon2 == chose1UnCommon);

            //Debug.Log(randomUnCommon2);
            //  activeUnCommonAbilities[randomUnCommon2].SetActive(true);
            chose2UnCommon = randomUnCommon2;
            StartCoroutine(FadeInAbilitites(activeUnCommonAbilities[randomUnCommon2]));
        }

        if (got2UnCommonChoise == true && got3UnCommonChoise == false)
        {
            int randomUnCommon3;

            do
            {
                randomUnCommon3 = Random.Range(0, activeUnCommonAbilities.Length - unCommonAbilitesNotAviable);
            } while (randomUnCommon3 == chose1UnCommon || randomUnCommon3 == chose2UnCommon);

            //Debug.Log(randomUnCommon3);
            //  activeUnCommonAbilities[randomUnCommon3].SetActive(true);
            chose3UnCommon = randomUnCommon3;
            StartCoroutine(FadeInAbilitites(activeUnCommonAbilities[randomUnCommon3]));
        }

        if (got3UnCommonChoise == true && got4UnCommonChoise == false)
        {
            int randomUnCommon4;

            do
            {
                randomUnCommon4 = Random.Range(0, activeUnCommonAbilities.Length - unCommonAbilitesNotAviable);
            } while (randomUnCommon4 == chose1UnCommon || randomUnCommon4 == chose2UnCommon || randomUnCommon4 == chose3UnCommon);

            //Debug.Log(randomUnCommon4);
            //  activeUnCommonAbilities[randomUnCommon4].SetActive(true);
            chose4UnCommon = randomUnCommon4;
            StartCoroutine(FadeInAbilitites(activeUnCommonAbilities[randomUnCommon4]));
        }

        if (got4UnCommonChoise == true)
        {
            int randomUnCommon5;

            do
            {
                randomUnCommon5 = Random.Range(0, activeUnCommonAbilities.Length - unCommonAbilitesNotAviable);
            } while (randomUnCommon5 == chose1UnCommon || randomUnCommon5 == chose2UnCommon || randomUnCommon5 == chose3UnCommon || randomUnCommon5 == chose4UnCommon);

            //Debug.Log(randomUnCommon5);
            //  activeUnCommonAbilities[randomUnCommon5].SetActive(true);
            StartCoroutine(FadeInAbilitites(activeUnCommonAbilities[randomUnCommon5]));
        }
        #endregion

        if (got3UnCommonChoise == true) { got4UnCommonChoise = true; }
        if (got2UnCommonChoise == true) { got3UnCommonChoise = true; }
        if (got1UnCommonChoise == true) { got2UnCommonChoise = true; }
        got1UnCommonChoise = true;
    }

    public void RandomRareAbilites()
    {
        int rareAbilitites = rareAbilitiesAviable + 1;
        if (numberOfRareChoises == rareAbilitites)
        {
            RandomLegendaryAbilites();
            return;
        }

        numberOfRareChoises += 1;
        choisesChosen += 1;

        #region choose rare ability
        if (got1RareChoise == false)
        {
            int randomRare1 = Random.Range(0, activeRareAbilities.Length - rareAbilitesNotAviable);
            //Debug.Log(randomRare1);
            //  activeRareAbilities[randomRare1].SetActive(true);
            chose1Rare = randomRare1;
            StartCoroutine(FadeInAbilitites(activeRareAbilities[randomRare1]));
        }

        if (got1RareChoise == true && got2RareChoise == false)
        {
            int randomRare2;

            do
            {
                randomRare2 = Random.Range(0, activeRareAbilities.Length - rareAbilitesNotAviable);
            } while (randomRare2 == chose1Rare);

            //Debug.Log(randomRare2);
            //   activeRareAbilities[randomRare2].SetActive(true);
            chose2Rare = randomRare2;
            StartCoroutine(FadeInAbilitites(activeRareAbilities[randomRare2]));
        }

        if (got2RareChoise == true && got3RareChoise == false)
        {
            int randomRare3;

            do
            {
                randomRare3 = Random.Range(0, activeRareAbilities.Length - rareAbilitesNotAviable);
            } while (randomRare3 == chose1Rare || randomRare3 == chose2Rare);

            //Debug.Log(randomRare3);
            // activeRareAbilities[randomRare3].SetActive(true);
            chose3Rare = randomRare3;
            StartCoroutine(FadeInAbilitites(activeRareAbilities[randomRare3]));
        }

        if (got3RareChoise == true && got4RareChoise == false)
        {
            int randomRare4;

            do
            {
                randomRare4 = Random.Range(0, activeRareAbilities.Length - rareAbilitesNotAviable);
            } while (randomRare4 == chose1Rare || randomRare4 == chose2Rare || randomRare4 == chose3Rare);

            // Debug.Log(randomRare4);
            //activeRareAbilities[randomRare4].SetActive(true);
            chose4Rare = randomRare4;
            StartCoroutine(FadeInAbilitites(activeRareAbilities[randomRare4]));
        }

        if (got4RareChoise == true)
        {
            int randomRare5;

            do
            {
                randomRare5 = Random.Range(0, activeRareAbilities.Length - rareAbilitesNotAviable);
            } while (randomRare5 == chose1Rare || randomRare5 == chose2Rare || randomRare5 == chose3Rare || randomRare5 == chose4Rare);

            //Debug.Log(randomRare5);
            //activeRareAbilities[randomRare5].SetActive(true);
            StartCoroutine(FadeInAbilitites(activeRareAbilities[randomRare5]));
        }
        #endregion

        if (got3RareChoise == true) { got4RareChoise = true; }
        if (got2RareChoise == true) { got3RareChoise = true; }
        if (got1RareChoise == true) { got2RareChoise = true; }
        got1RareChoise = true;
    }
    public void RandomLegendaryAbilites()
    {
        int legedaryAbilites = legendaryAbilitiesAviable + 1;
        if (numberOfLegendaryChoices == legedaryAbilites)
        {
            RandomMythicAbilites();
            return;
        }

        numberOfLegendaryChoices += 1;
        choisesChosen += 1;

        #region choose legendary ability
        if (got1LegendaryChoice == false)
        {
            int randomLegendary1 = Random.Range(0, activeLegendaryAbilities.Length - legendaryAbilitiesNotAvailable);
            // Debug.Log(randomLegendary1);
            //activeLegendaryAbilities[randomLegendary1].SetActive(true);
            chose1Legendary = randomLegendary1;
            StartCoroutine(FadeInAbilitites(activeLegendaryAbilities[randomLegendary1]));
        }

        if (got1LegendaryChoice == true && got2LegendaryChoice == false)
        {
            int randomLegendary2;

            do
            {
                randomLegendary2 = Random.Range(0, activeLegendaryAbilities.Length - legendaryAbilitiesNotAvailable);
            } while (randomLegendary2 == chose1Legendary);

            // Debug.Log(randomLegendary2);
            //activeLegendaryAbilities[randomLegendary2].SetActive(true);
            chose2Legendary = randomLegendary2;
            StartCoroutine(FadeInAbilitites(activeLegendaryAbilities[randomLegendary2]));
        }

        if (got2LegendaryChoice == true && got3LegendaryChoice == false)
        {
            int randomLegendary3;

            do
            {
                randomLegendary3 = Random.Range(0, activeLegendaryAbilities.Length - legendaryAbilitiesNotAvailable);
            } while (randomLegendary3 == chose1Legendary || randomLegendary3 == chose2Legendary);

            // Debug.Log(randomLegendary3);
            //activeLegendaryAbilities[randomLegendary3].SetActive(true);
            chose3Legendary = randomLegendary3;
            StartCoroutine(FadeInAbilitites(activeLegendaryAbilities[randomLegendary3]));
        }

        if (got3LegendaryChoice == true && got4LegendaryChoice == false)
        {
            int randomLegendary4;

            do
            {
                randomLegendary4 = Random.Range(0, activeLegendaryAbilities.Length - legendaryAbilitiesNotAvailable);
            } while (randomLegendary4 == chose1Legendary || randomLegendary4 == chose2Legendary || randomLegendary4 == chose3Legendary);

            //Debug.Log(randomLegendary4);
            //activeLegendaryAbilities[randomLegendary4].SetActive(true);
            chose4Legendary = randomLegendary4;
            StartCoroutine(FadeInAbilitites(activeLegendaryAbilities[randomLegendary4]));
        }

        if (got4LegendaryChoice == true)
        {
            int randomLegendary5;

            do
            {
                randomLegendary5 = Random.Range(0, activeLegendaryAbilities.Length - legendaryAbilitiesNotAvailable);
            } while (randomLegendary5 == chose1Legendary || randomLegendary5 == chose2Legendary || randomLegendary5 == chose3Legendary || randomLegendary5 == chose4Legendary);

            //  Debug.Log(randomLegendary5);
            //activeLegendaryAbilities[randomLegendary5].SetActive(true);
            StartCoroutine(FadeInAbilitites(activeLegendaryAbilities[randomLegendary5]));
        }
        #endregion

        if (got3LegendaryChoice == true) { got4LegendaryChoice = true; }
        if (got2LegendaryChoice == true) { got3LegendaryChoice = true; }
        if (got1LegendaryChoice == true) { got2LegendaryChoice = true; }
        got1LegendaryChoice = true;
    }

    public static int gotDoubleTapMythic, gotUnlimitedPowerMythic, gotControlledButtonMythic;
    public GameObject doubleTap, unlimitedPower, controlledButton, pauseTime, skullHarvest;
    public int mythicAbilitiesChosen;

    public bool chose1Mythic, chose2Mythic, chose3Mythic, chose4Mythic, chose5Mythic;

    public void RandomMythicAbilites()
    {
        //Double tap and unlimited power can be achieved at all times.
        //Egg can be achieved multiple times.
        //Controlled Button will be active once arena is unlcoked.
        //Stopwatch and skull harvest will be active once any gun is aquaired. 

        choisesChosen += 1;

        int RandomMythic = Random.Range(1, 6);
        //Debug.Log(RandomMythic);
        #region Random = 1 | Double Tap
        if (RandomMythic == 1)
        {
            if(chose1Mythic == true) { RandomMythic = 2; }
            else
            {
                chose1Mythic = true;

                if (choseDoubleTap == false) { StartCoroutine(FadeInAbilitites(doubleTap)); }
                if (choseDoubleTap == true)
                {
                    if (firstWeaponChosen == true)
                    {
                        if (choseBouncingBullets == true && chooseControllableButton == false) 
                        { 
                            StartCoroutine(FadeInAbilitites(controlledButton)); 
                        }
                        else
                        {
                            int random3 = Random.Range(1, 3);
                            if (random3 == 1) { StartCoroutine(FadeInAbilitites(pauseTime)); }
                            if (random3 == 2) { StartCoroutine(FadeInAbilitites(skullHarvest)); }
                        }
                    }
                    else
                    {
                       StartCoroutine(FadeInAbilitites(unlimitedPower));
                    }
                }
            }
        }
        #endregion

        #region Random = 2 | Unlimited Power/Egg
        if (RandomMythic == 2) 
        {
            if (chose2Mythic == true) { RandomMythic = 3; }
            else { chose2Mythic = true; StartCoroutine(FadeInAbilitites(unlimitedPower)); }
        }
        #endregion

        #region Random = 3 | Controlled Button
        if (RandomMythic == 3) 
        {
            if (chose3Mythic == true) { RandomMythic = 4; }
            else
            {
                chose3Mythic = true;

                if (choseBouncingBullets == true && chooseControllableButton == false) {  StartCoroutine(FadeInAbilitites(controlledButton)); }

                if (choseBouncingBullets == false)
                {
                    if (firstWeaponChosen == true)
                    {
                        int random3 = Random.Range(1, 3);
                        if (random3 == 1) 
                        {
                            if (chose4Mythic == true) {  StartCoroutine(FadeInAbilitites(skullHarvest)); }
                            else { StartCoroutine(FadeInAbilitites(pauseTime)); }
                        }
                        if (random3 == 2) 
                        { 
                            if(chose5Mythic == true) { StartCoroutine(FadeInAbilitites(pauseTime)); }
                            else {  StartCoroutine(FadeInAbilitites(skullHarvest)); }
                        }
                    }
                    if (firstWeaponChosen == false)
                    {
                        if (choseDoubleTap == false)
                        {
                            int random4 = Random.Range(1, 3);
                            if (random4 == 1) {  StartCoroutine(FadeInAbilitites(unlimitedPower)); }
                            if (random4 == 2) { StartCoroutine(FadeInAbilitites(doubleTap)); }
                        }
                        else
                        {
                          StartCoroutine(FadeInAbilitites(unlimitedPower));
                        }
                    }
                }
                if (choseBouncingBullets == true && chooseControllableButton == true)
                {
                    int random3 = Random.Range(1, 3);
                    if (random3 == 1) { RandomMythic = 4; }
                    if (random3 == 2) { RandomMythic = 5; }
                }
            }
        }
        #endregion

        #region Random = 4 | Stop Watch
        if (RandomMythic == 4) 
        {
            if (chose4Mythic == true) { RandomMythic = 5; }
            else
            {
                chose4Mythic = true;

                if (firstWeaponChosen == true) {  StartCoroutine(FadeInAbilitites(pauseTime)); }
                else
                {
                    if (choseDoubleTap == false)
                    {
                        int random4 = Random.Range(1, 3);
                        if (random4 == 1) {  StartCoroutine(FadeInAbilitites(unlimitedPower)); }
                        if (random4 == 2) {  StartCoroutine(FadeInAbilitites(doubleTap)); }
                    }
                    else
                    {
                         StartCoroutine(FadeInAbilitites(unlimitedPower));
                    }
                }
            }
        }
        #endregion

        #region Random = 5 | Skull Harvest
        if (RandomMythic == 5) 
        {
            if (chose5Mythic == true) { StartCoroutine(FadeInAbilitites(pauseTime)); }
            else
            {
                chose5Mythic = true;
                if (firstWeaponChosen == true) { StartCoroutine(FadeInAbilitites(skullHarvest)); }
                else
                {
                    if (choseDoubleTap == false)
                    {
                        int random4 = Random.Range(1, 3);
                        if (random4 == 1) { StartCoroutine(FadeInAbilitites(unlimitedPower)); }
                        if (random4 == 2) { StartCoroutine(FadeInAbilitites(doubleTap)); }
                    }
                    else
                    {
                        StartCoroutine(FadeInAbilitites(unlimitedPower));
                    }
                }
            }
        }
        #endregion
    }
    #endregion

    //REROLL
    #region Reroll Abilibites BUTTON
    public GameObject[] abilitesToReroll;
    private float rerollWait;
    public GameObject rerollButtonObject;
    public GameObject rerollDiceObject;

    public void RerollAbilities1()
    {
        audioManager.Play("Dice");
        //StartCoroutine(SetBlockAbilitesInactive());

        SettingsOptions.timesRerolled += 1;

        if(choseReroll == true)
        {
            rerollDiceObject.GetComponent<Button>().interactable = false;
            rerollButtonObject.GetComponent<Animator>().SetTrigger("Out");
        }
     
        chose1Mythic = false; chose2Mythic = false; chose3Mythic = false; chose4Mythic = false; chose5Mythic = false;

        //commonChance = 35;
        //uncommonChance = 45;
        //rareChance = 45;
        //legendaryChance = 45;

        fadeSounds = 0;
        rerollsAviable -= 1;
        if (rerollsAviable <= 0)
        {
            rerollAmounText.text = "<color=red>" + rerollsAviable +"";
        }
        else
        {
            rerollAmounText.text = "<color=green>" + rerollsAviable+ "";
        }

        rerollWait = 0;
        if (numberOfChoises > 2)
        {
            abilitesToReroll[0].GetComponent<Animator>().enabled = true;
            abilitesToReroll[1].GetComponent<Animator>().enabled = true;
            abilitesToReroll[2].GetComponent<Animator>().enabled = true;
            StartCoroutine(Reroll(abilitesToReroll[0]));
            StartCoroutine(Reroll(abilitesToReroll[1]));
            StartCoroutine(Reroll(abilitesToReroll[2]));
            if (numberOfChoises > 3) { abilitesToReroll[3].GetComponent<Animator>().enabled = true; StartCoroutine(Reroll(abilitesToReroll[3])); }
            if (numberOfChoises > 4) { abilitesToReroll[4].GetComponent<Animator>().enabled = true; StartCoroutine(Reroll(abilitesToReroll[4])); }
        }

        StartCoroutine(Wait());
    }

    IEnumerator Reroll(GameObject abilityReroll)
    {
        yield return new WaitForSecondsRealtime(rerollWait);
        abilityReroll.SetActive(true);
        abilityReroll.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(rerollWait + 0.16f);
        SetRerollsInactive();

        //rerollDiceObject.GetComponent<Button>().interactable = true;
        //rerollButtonObject.GetComponent<Animator>().SetTrigger("In");

        SetEnemyTextsInactive();
        setVariables = true;
    }
    #endregion

    //Methods for mutiple abilitites

    public static bool firstWeaponChosen;
    public static bool firstShootingEnemyChose;
    public static bool pointsFirst, idleFirst, critFirst, pointDropFirst, doubletapFirst, uziFirst, pistolFirst, shotgunFirst, awpFirst, crossbowFirst, deagleFirst, chargedBulletFirst, cannonFirst, mp4First, arrosFirst, boxinggloveFirst, stabbyspikeFirst, tinySpikeFirst, knifeFirst, sawBladeFirst, swordFirst, hammerFirst, defenseFirst, heartFirst, smallShieldFirst, bouncyShieldFirst, invinFirst, stopwatchFirst, boosterFirst, rocketFirst, talariaFirst, random2First, random3First, random5First, ritualFirst, eggFirst, arenaFirst, abiltites4XFirst, rerollRareFirst, abilities5XFirst, rerollLegendaryFirst, skullHarvestFirst;

    public static int pointsLEVEL, idleLEVEL, critLEVEL, pointDropLEVEL, uziLEVEL, pistolLEVEL, shotgunLEVEL, awpLEVEL, crossbowLEVEL, deagleLEVEL, chargedBulletLEVEL, cannonLEVEL, mp4LEVEL, arrosLEVEL, boxingloveLEVEL, stabbyspikeLEVEL, tinySpikeLEVEL, knifeLEVEL, sawBladeLEVEL, swordLEVEL, hammerLEVEL, defenseLEVEL, heartLEVEL, smallShieldLEVEL, bouncyShieldLEVEL, invinLEVEL, stopwatchLEVEL, ritualLEVEL, arenaLEVEL, rerollLEVEL,  skullHarvestLEVEL;

    #region Set First Weapon
    public static float uziSpeedIncrease, uziDamageIncrease, pistolSpeedIncrease, pistolDamageIncrease, shotgunDamageIncrease, shotgunSpeedIncrease, awpSpeedIncrease, awpDamageIncrease, crossbowSpeedIncrease, crossbowDamageIncrease, deagleSpeedIncrease, deagleDamageIncrease, mp4DamageIncrease, mp4SpeedIncrease, cannonSpeedIncrease, cannonDamageIncrease;
    public static int shotgunShotsIncrease;

    public static float uziCommonSpeedIncrease, uziCommonDamageIncrease, pistolCommonSpeedIncrease, pistolCommonDamageIncrease, shotgunCommonShotsIncrease, shotgunCommonDamageIncrease, shotgunCommonSpeedIncrease, awpCommonSpeedIncrease, awpCommonDamageIncrease, crossbowCommonSpeedIncrease, crossbowCommonDamageIncrease, deagleCommonSpeedIncrease, deagleCommonDamageIncrease, mp4CommonDamageIncrease, mp4CommonSpeedIncrease, cannonCommonSpeedIncrease, cannonCommonDamageIncrease;
    public static bool firstTimeGun;
    public GameObject firstTimeGunScreen;
    public GameObject healthBarTopRight;
    public static bool isInFirstWeaponScreen;

    public void GotItButton()
    {
        audioManager.Play("UI_Click2");
        isInFirstWeaponScreen = false;
        firstTimeGunScreen.SetActive(false);
        Time.timeScale = 1;
        firstTimeGun = true;
        SetCursors.hoveringClickableStuff = false;
        if(firstControlledGun == false)
        {
            Cursor.visible = true;
        }
        else 
        {
            if (MobileScript.isMobile == false) { Cursor.visible = false; }
        }
    }

    IEnumerator SetFirstGunScreen()
    {
        isInFirstWeaponScreen = true;
        yield return new WaitForSecondsRealtime(0.07f);
        firstTimeGunScreen.SetActive(true);
        SetAlpha(firstTimeGunScreen.GetComponent<Image>(), 1f);
        Time.timeScale = 0;
    }
  
    public GameObject abilityClicks;
    public void SetFirstWeapon()
    {
        //First gun should set these abilites active
        //Common = Defense+
        //Uncommon = Arena, Big Heart, Boxing glove, spike stab, smallSpikes, knifes.
        //Rare = Charged bullets, saw blade.
        //Legendary = Big Sword, Invincibility, hamemr, arrow storm.

        commonAbilitesNotAviable -= 1;
        commonAbilitiesAviable += 1;
        activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[3]; //Defense+

        unCommonAbilitesNotAviable -= 6;
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[2]; //Arena
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[3]; //BigHeart
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[4]; //BoxingGlove
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[5]; //Spike Stab
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[6]; //Small spikes
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[7]; //Knifes

        rareAbilitesNotAviable -= 2;
        rareAbilitiesAviable += 1;
        activeRareAbilities[rareAbilitiesAviable] = allRareAbilitites[2]; //Charged Bullets
        rareAbilitiesAviable += 1;
        activeRareAbilities[rareAbilitiesAviable] = allRareAbilitites[8]; //Saw blade

        legendaryAbilitiesNotAvailable -= 4;
        legendaryAbilitiesAviable += 1;
        activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[4]; //Sword
        legendaryAbilitiesAviable += 1;
        activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[5]; //Invincibility
        legendaryAbilitiesAviable += 1;
        activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[6]; //Hammer
        legendaryAbilitiesAviable += 1;
        activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[7]; //Arrows

        //Sets health and gives the player healthbar
        defenseLEVEL += 1;
        buttonHealth = 100;
        maxButtonHealth = 100;
        healthRegenPerSecond = 2.5f;
        regenHealth = true;
        eggDefense.SetActive(true);

        if(SettingsOptions.healthbarPosition == 0)
        {
            healthText.gameObject.SetActive(true);
            healthBar.SetActive(true);

            healthBarTopRight.SetActive(false);
        }
        else
        {
            healthText.gameObject.SetActive(false);
            healthBar.SetActive(false);

            healthBarTopRight.SetActive(true);
        }
     

        choseHealthBar = true;
        setEnemiesInactive = true;

        //Set to false
        if (firstTimeGun == false) { 
            SetAlpha(firstTimeGunScreen.GetComponent<Image>(), 0f);
            StartCoroutine(SetFirstGunScreen());
        }
    }

    public static bool choseHealthBar, setEnemiesInactive;
    public static float buttonHealth, maxButtonHealth;
    public GameObject healthBar;
    public Slider healthBarSlider, healthbarSliderTopRight;
    public static float healthRegenPerSecond;
    
    #endregion

    #region Set First Shield
    public void SetFirstShield()
    {
        unCommonAbilitesNotAviable -= 1;
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[10]; //SMall shield

        rareAbilitesNotAviable -= 1;
        rareAbilitiesAviable += 1;
        activeRareAbilities[rareAbilitiesAviable] = allRareAbilitites[3]; //Shield Bounce
        firstShootingEnemyChose = true;
    }
    #endregion

    #region spawnSmallEnemies
    public void SpawnSmallEnemies()
    {
        EnemiesStartSpawning();
        StartCoroutine(waitForFirstEnemy());
    }

    IEnumerator waitForFirstEnemy()
    {
        yield return new WaitForSeconds(0.3f);
        smallEnemySpawn = true;
    }
    #endregion

    #region Set First Movement
    public void SetFirstMovementActive()
    {
        unCommonAbilitesNotAviable -= 1;
        unCommonAbilitiesAviable += 1;
        activeUnCommonAbilities[unCommonAbilitiesAviable] = allUncommonAbilities[8]; //Points Drop

        legendaryAbilitiesNotAvailable -= 1;
        legendaryAbilitiesAviable += 1;
        activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[9]; //Ritual
    }
    #endregion

    //Basic abilities. Player can always achieve
    #region Points Per Click Choice - COMMON
    public static float currentPointIncrease;
    public float pointsIncreaseTotal;
    public float clicksNeedForLevel;
    public float newPointIncrease;

    public TextMeshProUGUI pointsPerClickText;

    public void ClickPerPointUpgrade()
    {
        pointsLEVEL += 1;
        audioManager.Play("SelectAbility");
        pointsFirst = true;
        SettingsOptions.totalCommonAbilitiesChosen += 1;
        ChoseCommonSetChance();
        ButtonClick.pointsPerClick += currentPointIncrease;
        UnPauseGame();
    }

    public void SetMorePointsText()
    {
        //Debug.Log(ButtonClick.pointsPerClick);
        if (ButtonClick.pointsNeeded < 100)
        {
            if (ButtonClick.pointsPerClick == 1) { currentPointIncrease = 1; }
            if (ButtonClick.pointsPerClick == 2) { currentPointIncrease = 1; }
            if (ButtonClick.pointsPerClick == 3) { currentPointIncrease = 1; }
            if (ButtonClick.pointsPerClick == 4) { currentPointIncrease = 1; }
            if (ButtonClick.pointsPerClick == 5) { currentPointIncrease = 2; }
            if (ButtonClick.pointsPerClick == 7) { currentPointIncrease = 2; }
            if (ButtonClick.pointsPerClick == 9) { currentPointIncrease = 2; }
            if (ButtonClick.pointsPerClick > 10) { currentPointIncrease = ButtonClick.pointsPerClick / 5; }
            if (ButtonClick.pointsPerClick > 35) { currentPointIncrease = ButtonClick.pointsPerClick / 9; }
            if (ButtonClick.pointsPerClick > 60) { currentPointIncrease = ButtonClick.pointsPerClick / 12; }
        }
        if (ButtonClick.pointsNeeded > 100)
        {
            if(ButtonClick.pointsNeeded < 250) { currentPointIncrease = ButtonClick.pointsNeeded / 75;  }
            else if (ButtonClick.pointsNeeded < 400) { currentPointIncrease = ButtonClick.pointsNeeded / 130;  }
            else if (ButtonClick.pointsNeeded < 600) { currentPointIncrease = ButtonClick.pointsNeeded / 145;  }
            else if (ButtonClick.pointsNeeded < 1000) { currentPointIncrease = ButtonClick.pointsNeeded / 155;  }
            else if (ButtonClick.pointsNeeded < 2500) { currentPointIncrease = ButtonClick.pointsNeeded / 190; }
            else if (ButtonClick.pointsNeeded < 5000) { currentPointIncrease = ButtonClick.pointsNeeded / 220;  }
            else if (ButtonClick.pointsNeeded < 10000) { currentPointIncrease = ButtonClick.pointsNeeded / 240;  }
            else if (ButtonClick.pointsNeeded < 25000) { currentPointIncrease = ButtonClick.pointsNeeded / 270;  }
            else if (ButtonClick.pointsNeeded < 50000) { currentPointIncrease = ButtonClick.pointsNeeded / 330;  }
            else if (ButtonClick.pointsNeeded < 75000) { currentPointIncrease = ButtonClick.pointsNeeded / 420; }
            else if (ButtonClick.pointsNeeded < 100000) { currentPointIncrease = ButtonClick.pointsNeeded / 550;  }
            else if (ButtonClick.pointsNeeded < 150000) { currentPointIncrease = ButtonClick.pointsNeeded / 670;  }
            else if (ButtonClick.pointsNeeded < 300000) { currentPointIncrease = ButtonClick.pointsNeeded / 770;  }
            else if (ButtonClick.pointsNeeded < 500000) { currentPointIncrease = ButtonClick.pointsNeeded / 880;  }
            else if (ButtonClick.pointsNeeded < 1000000) { currentPointIncrease = ButtonClick.pointsNeeded / 1000;  }
            else if (ButtonClick.pointsNeeded < 2000000) { currentPointIncrease = ButtonClick.pointsNeeded / 1100;  }
            else if (ButtonClick.pointsNeeded < 5000000) { currentPointIncrease = ButtonClick.pointsNeeded / 1200;  }
            else if (ButtonClick.pointsNeeded < 10000000) { currentPointIncrease = ButtonClick.pointsNeeded / 1300; }
            else if (ButtonClick.pointsNeeded < 50000000) { currentPointIncrease = ButtonClick.pointsNeeded / 1400; }
            else if (ButtonClick.pointsNeeded < 100000000) { currentPointIncrease = ButtonClick.pointsNeeded / 1500;  }
            else if (ButtonClick.pointsNeeded > 500000000) { currentPointIncrease = ButtonClick.pointsNeeded / 2000;  }
            //Debug.Log(currentPointIncrease);

            pointsIncreaseTotal = ButtonClick.pointsPerClick + currentPointIncrease;
            clicksNeedForLevel = ButtonClick.pointsNeeded / pointsIncreaseTotal;

            //Debug.Log(pointsIncreaseTotal);
            //Debug.Log(clicksNeedForLevel);

            if (ButtonClick.pointsNeeded > 1000000)
            {
                if (clicksNeedForLevel < 500)
                {
                    newPointIncrease = ButtonClick.pointsNeeded / 500;
                    currentPointIncrease = (newPointIncrease - ButtonClick.pointsPerClick);
                    if (currentPointIncrease < 3) { currentPointIncrease = 2; }

                    //Debug.Log(currentPointIncrease);
                }
            }
            else if (ButtonClick.pointsNeeded > 500000)
            {
                if (clicksNeedForLevel < 350)
                {
                    newPointIncrease = ButtonClick.pointsNeeded / 350;
                    currentPointIncrease = (newPointIncrease - ButtonClick.pointsPerClick);
                    if (currentPointIncrease < 3) { currentPointIncrease = 2; }

                    //Debug.Log(currentPointIncrease);
                }
            }
            else if (ButtonClick.pointsNeeded > 100000)
            {
                if (clicksNeedForLevel < 200)
                {
                    newPointIncrease = ButtonClick.pointsNeeded / 200;
                    currentPointIncrease = (newPointIncrease - ButtonClick.pointsPerClick);
                    if (currentPointIncrease < 3) { currentPointIncrease = 2; }

                    //Debug.Log(currentPointIncrease);
                }
            }
            else if (ButtonClick.pointsNeeded > 10000)
            {
                if (clicksNeedForLevel < 125)
                {
                    newPointIncrease = ButtonClick.pointsNeeded / 125;
                    currentPointIncrease = (newPointIncrease - ButtonClick.pointsPerClick);
                    if (currentPointIncrease < 3) { currentPointIncrease = 2; }

                    //Debug.Log(currentPointIncrease);
                }
            }
            else if (ButtonClick.pointsNeeded > 3000)
            {  
                if(clicksNeedForLevel < 50)
                {
                    newPointIncrease = ButtonClick.pointsNeeded / 50;
                    currentPointIncrease = (newPointIncrease - ButtonClick.pointsPerClick);
                    if(currentPointIncrease < 3) { currentPointIncrease = 2; }

                    //Debug.Log(currentPointIncrease);
                }
            }
        }

        localizationScript.PointPerClickText();
        pointsPerClickText.text = LocalizationVariables.pointPerClickIncrease;
    }
    #endregion 

    #region crit clicks
    public static bool choseCritClicks;
    public static float critClicksChance;
    public static float critClicksBonus;

    public static float currentClickCritPercentIncrease, currectClickCritIncrease;
    public void ChooseCritClicks()
    {
        critLEVEL += 1;
        audioManager.Play("SelectAbility");
        critFirst = true;
        SettingsOptions.totalCommonAbilitiesChosen += 1;
        ChoseCommonSetChance();
        choseCritClicks = true;
        critClicksChance += currentClickCritPercentIncrease;
        critClicksBonus += currectClickCritIncrease;
        UnPauseGame();
    }

    public void SetCritUpgrade()
    {
        //Increase
        if(choseCritClicks == false) { critClicksBonus = originalCritIncrease; currectClickCritIncrease = 0; }
        else
        {
            if (critClicksBonus > 1.9f) { currectClickCritIncrease = 0.35f; }
            if (critClicksBonus > 3.5f) { currectClickCritIncrease = 0.2f; }
            if (critClicksBonus > 5.5f) { currectClickCritIncrease = 0.05f; }
            if (critClicksBonus > 7f) { currectClickCritIncrease = 0.04f; }
            if (critClicksBonus > 9f) { currectClickCritIncrease = 0.03f; }
            if (critClicksBonus > 10f) { currectClickCritIncrease = 0.02f; }
            if (critClicksBonus > 11f) { currectClickCritIncrease = 0.01f; }
            if (critClicksBonus > 12f) { currectClickCritIncrease = 0.005f; }
            if (critClicksBonus > 12f) { currectClickCritIncrease = 0f; }
        }

        //Chance
        if (choseCritClicks == false) { critClicksChance = originalCritChance; currentClickCritPercentIncrease = 0; }
        else
        {
            if (critClicksChance > 0.7f) { currentClickCritPercentIncrease = 1f; }
            if (critClicksChance > 3f) { currentClickCritPercentIncrease = 0.8f; }
            if (critClicksChance > 5f) { currentClickCritPercentIncrease = 0.5f; }
            if (critClicksChance > 10f) { currentClickCritPercentIncrease = 0.45f; }
            if (critClicksChance > 25f) { currentClickCritPercentIncrease = 0.4f; }
            if (critClicksChance > 50f) { currentClickCritPercentIncrease = 0.3f; }
            if (critClicksChance > 50f) { currentClickCritPercentIncrease = 0.1f; }
            if (critClicksChance > 70f) { currentClickCritPercentIncrease = 0.07f; }
            if (critClicksChance > 80f) { currentClickCritPercentIncrease = 0.05f; }
            if (critClicksChance > 90f) { currentClickCritPercentIncrease = 0.02f; }
            if (critClicksChance > 100f) { currentClickCritPercentIncrease = 0f; }
        }

        localizationScript.CritText();
    }
    #endregion

    #region idleButtonClick
    public static bool choseIdleClicking;
    public static float timeBetweenClicks;

    public static float currentIdleClickIncrease;
    public static float currentIdlePointIncrease;
    public static float totalIdlePoints;

    public void ChooseIdleClicking()
    {
        idleLEVEL += 1;
        audioManager.Play("SelectAbility");
        idleFirst = true;
        SettingsOptions.totalCommonAbilitiesChosen += 1;
        ChoseCommonSetChance();

        if (choseIdleClicking == true)
        { 
           timeBetweenClicks -= currentIdleClickIncrease;
            //Debug.Log(timeBetweenClicks);
        }
        else
        {
            ButtonClick.autoClick = true;
        }

        //Debug.Log(timeBetweenClicks);

        totalIdlePoints += currentIdlePointIncrease;
        choseIdleClicking = true;

        UnPauseGame();
    }

    public void SetIdleUpgrade()
    {
        //Debug.Log(timeBetweenClicks);
        if (choseIdleClicking == false) { timeBetweenClicks = 2; currentIdleClickIncrease = 0; }
        else
        {
            //Debug.Log(timeBetweenClicks);
            if (timeBetweenClicks < 0.1f) { currentIdleClickIncrease = 0f; }
            else if (timeBetweenClicks < 0.12f) { currentIdleClickIncrease = 0.001f; }
            else if (timeBetweenClicks < 0.14f) { currentIdleClickIncrease = 0.0025f; }
            else if (timeBetweenClicks < 0.16f) { currentIdleClickIncrease = 0.0055f; }
            else if (timeBetweenClicks < 0.18f) { currentIdleClickIncrease = 0.008f; }
            else if (timeBetweenClicks < 0.2f) { currentIdleClickIncrease = 0.01f; }
            else if (timeBetweenClicks < 0.26f) { currentIdleClickIncrease = 0.02f; }
            else if (timeBetweenClicks < 0.29f) { currentIdleClickIncrease = 0.03f; }
            else if (timeBetweenClicks < 0.35f) { currentIdleClickIncrease = 0.05f; }
            else if (timeBetweenClicks < 0.4f) { currentIdleClickIncrease = 0.06f; }
            else if (timeBetweenClicks < 0.45f) { currentIdleClickIncrease = 0.09f; }
            else if (timeBetweenClicks < 0.6f) { currentIdleClickIncrease = 0.1f; }
            else if (timeBetweenClicks < 0.75f) { currentIdleClickIncrease = 0.15f; }
            else if (timeBetweenClicks < 1.1f) { currentIdleClickIncrease = 0.35f; }
            else if (timeBetweenClicks < 3) { currentIdleClickIncrease = 1f; }

            if(MobileScript.isMobile == true)
            {
                if (timeBetweenClicks < 0.1f) { currentIdleClickIncrease = 0f; }
                else if (timeBetweenClicks < 0.12f) { currentIdleClickIncrease = 0.001f; }
                else if (timeBetweenClicks < 0.14f) { currentIdleClickIncrease = 0.0025f; }
                else if (timeBetweenClicks < 0.16f) { currentIdleClickIncrease = 0.0055f; }
                else if (timeBetweenClicks < 0.18f) { currentIdleClickIncrease = 0.008f; }
                else if (timeBetweenClicks < 0.2f) { currentIdleClickIncrease = 0.02f; }
                else if (timeBetweenClicks < 0.26f) { currentIdleClickIncrease = 0.03f; }
                else if (timeBetweenClicks < 0.29f) { currentIdleClickIncrease = 0.04f; }
                else if (timeBetweenClicks < 0.35f) { currentIdleClickIncrease = 0.06f; }
                else if (timeBetweenClicks < 0.4f) { currentIdleClickIncrease = 0.08f; }
                else if (timeBetweenClicks < 0.45f) { currentIdleClickIncrease = 0.1f; }
                else if (timeBetweenClicks < 0.6f) { currentIdleClickIncrease = 0.15f; }
                else if (timeBetweenClicks < 0.75f) { currentIdleClickIncrease = 0.25f; }
                else if (timeBetweenClicks < 1.1f) { currentIdleClickIncrease = 0.45f; }
                else if (timeBetweenClicks < 3) { currentIdleClickIncrease = 1.15f; }
            }

            if (timeBetweenClicks <= 0 && choseIdleClicking == true)
            {
                timeBetweenClicks = 0.09949993f;
            }
        }

        SetMorePointsText();

        if (ButtonClick.pointsPerClick == 1) { currentIdlePointIncrease = (1f / 3f);  }
        if (ButtonClick.pointsPerClick == 2) { currentIdlePointIncrease = (1f / 3f); }
        if (ButtonClick.pointsPerClick == 3) { currentIdlePointIncrease = (1f / 3f); }
        if (ButtonClick.pointsPerClick == 4) { currentIdlePointIncrease = (1f / 3f); }
        if (ButtonClick.pointsPerClick == 5) { currentIdlePointIncrease = (2f / 3f); }
        if (ButtonClick.pointsPerClick == 7) { currentIdlePointIncrease = (2f / 3f); }
        if (ButtonClick.pointsPerClick == 9) { currentIdlePointIncrease = (2f / 3f); }
        if (ButtonClick.pointsPerClick > 10) { currentIdlePointIncrease = 1; }
        if (ButtonClick.pointsPerClick > 35) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 22); }
        if (ButtonClick.pointsPerClick > 60) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 25); }
        if (ButtonClick.pointsPerClick > 100) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 50); }
        if (ButtonClick.pointsPerClick > 250) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 75); }
        if (ButtonClick.pointsPerClick > 500) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 100); }
        if (ButtonClick.pointsPerClick > 1000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 125); }
        if (ButtonClick.pointsPerClick > 2500) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 150); }
        if (ButtonClick.pointsPerClick > 5000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 175); }
        if (ButtonClick.pointsPerClick > 10000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 200); }
        if (ButtonClick.pointsPerClick > 25000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 250); }
        if (ButtonClick.pointsPerClick > 50000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 300); }
        if (ButtonClick.pointsPerClick > 100000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 350); }
        if (ButtonClick.pointsPerClick > 500000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 450); }
        if (ButtonClick.pointsPerClick > 1000000) { currentIdlePointIncrease = (ButtonClick.pointsPerClick / 500); }

        localizationScript.IdleText();
    }
    #endregion

    #region 4XChoises
    public int fourChoisesPos = -1;
    public void Choose4XChoises()
    {
        audioManager.Play("SelectAbilityRare");
        abilititesTotalWaitTime = 1.35f;
        abiltites4XFirst = true;
        SetEnemyStats(33, true);
        ChoseRareSetChance();
        for (int i = 0; i < activeRareAbilities.Length; i++)
        {
            if (activeRareAbilities[i] != null && activeRareAbilities[i].name == "Choise_4Choises_Rare")
            {
                fourChoisesPos = i;
                break; 
            }
        }
        //Debug.Log("Found at array position: " + fourChoisesPos);

        activeRareAbilities[fourChoisesPos] = null;
        RemoveAbilityFromArray(3, fourChoisesPos);
        rareAbilitesNotAviable += 1;
        rareAbilitiesAviable -= 1;

        legendaryAbilitiesNotAvailable -= 1;
        legendaryAbilitiesAviable += 1;
        activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[0];

        UnPauseGame();
        Invoke("Set4X", 0.3f);
    }

    public void Set4X()
    {
        numberOfChoises = 4;
    }
    #endregion

    #region 5XChoises
    public void Choose5XChoises()
    {
        audioManager.Play("SelectAbilityLegendary");
        abilititesTotalWaitTime = 1.6f;
        abilities5XFirst = true;
        SetEnemyStats(33, false);
        ChoseLegendarySetChance();
        for (int i = 0; i < activeLegendaryAbilities.Length; i++)
        {
            if (activeLegendaryAbilities[i] != null && activeLegendaryAbilities[i].name == "Choise_MoreChoises5X_Legendary")
            {
                fourChoisesPos = i;
                break;
            }
        }
        //Debug.Log("Found at array position: " + fourChoisesPos);

        activeLegendaryAbilities[fourChoisesPos] = null;
        RemoveAbilityFromArray(4, fourChoisesPos);
        legendaryAbilitiesNotAvailable += 1;
        legendaryAbilitiesAviable -= 1;


        UnPauseGame();
        Invoke("Set5X", 0.3f);
    }
    public void Set5X()
    {
        numberOfChoises = 5;
    }
    #endregion

    #region Reroll
    public static bool choseReroll;
    public static int rerollClicksNeeded, rerollClicks;
    public static int rerollsAviable, rerollsNeed;

    public static int rerollClicksDeacreseRare, rerollClickDecreaseLegendary;
    public static float rerollDoubleChance, rerollDoubleChanceIncrease;


    public void ChooseReroll()
    {
        rerollLEVEL += 1;
        if (choseReroll == true)
        {
            SetEnemyStats(28, false);
        }
        else
        {
            SetEnemyStats(28, false);
            eggDice.SetActive(true);
            choseReroll = true;
            rerollClicks = 0;
            rerollsAviable = 1;
        }

        UnPauseGame();
    }

    public void SetRerollUpgrade(bool common)
    {
        if (choseReroll == false)
        {
            rerollDoubleChance = 5f;
            rerollClicksNeeded = 190;
            localizationScript.OtherAbilitesText();
        }
        else
        {
            if (common == false)
            {
                if (rerollClicksNeeded < 75) { rerollClicksDeacreseRare = 0; }
                else if (rerollClicksNeeded < 100) { rerollClicksDeacreseRare = 7; }
                else if(rerollClicksNeeded < 200) { rerollClicksDeacreseRare = 8; }

                if (rerollDoubleChance > 3f) { rerollDoubleChanceIncrease = 1.5f; }
                else if (rerollDoubleChance > 10) { rerollDoubleChanceIncrease = 1f; }
                else if (rerollDoubleChance > 15) { rerollDoubleChanceIncrease = 0.5f; }

                localizationScript.OtherAbilitesText();
            }
            if (common == true)
            {
                if (rerollClicksNeeded < 75) { rerollClicksDeacreseRare = 0; }
                else if (rerollClicksNeeded < 100) { rerollClicksDeacreseRare = 3; }
                else if(rerollClicksNeeded < 200) { rerollClicksDeacreseRare = 4; }

                if (rerollDoubleChance > 3f) { rerollDoubleChanceIncrease = 1; }
                else if (rerollDoubleChance > 10) { rerollDoubleChanceIncrease = 0.5f; }
                else if (rerollDoubleChance > 15) { rerollDoubleChanceIncrease = 0.25f; }

                localizationScript.OtherAbilitesText();
            }
        }
    }
    #endregion

    #region DoubleTap
    public static bool choseDoubleTap;
    public void ChooseDoubleTap()
    {
        IncreaseMaxEnemyspawn(4, 3, 2, 2, 1, 1, 1, 1);
        audioManager.Play("SelectAbilityMythic");
        Choises.doubletapFirst = true;
        SettingsOptions.totalMythicAbilitiesChosen += 1;
        SetEnemyStats(34, false);
        ChoseMythicSetChance();
        choseDoubleTap = true;
        SetGunVolume();
        UnPauseGame();
    }
    #endregion

    //Guns, weapons and bullets
    public static bool firstControlledGun;
    public static int totalGunsAcquired;
    public static int numberOfGunsCurrentRun;

    #region chaotic gun, random dir
    public static int clickPerSmallBullet, smallBulletClicks;
    public static bool choseShootSmallBullets;
    public static float smallBulletDamage, smallBulletDeSpawnTime, smallBulletSpeed;

    public void ChooseChaoticGun()
    {
        uziLEVEL += 1;
        Choises.uziFirst = true;
        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if (choseShootSmallBullets == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.03f, 0.02f, 0.02f, 0.02f, 0.03f, 0.03f, 0.03f, 0.03f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
               totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(1,1,0,0,0,0,0,0);

            eggUZI.SetActive(true);
            //smallEnemy, speedster, sharpshooter, sniper, heavyShot, ragingGunner, brute, titan
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f);
            
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[4];

            choseShootSmallBullets = true;
            smallBulletDeSpawnTime = 8;
           

            SetAutoGunPosition(gun_RandomDirection);
            gun_RandomDirection.SetActive(true);
        }
        
    }

    public static bool gotBothUzi;
    public void SetUziUpgrade(bool common)
    {
        if(choseShootSmallBullets == false)
        {
            uziCommonDamageIncrease = 0; uziCommonSpeedIncrease = 0;
            uziDamageIncrease = 0; uziSpeedIncrease = 0;

            smallBulletClicks = 0;
            clickPerSmallBullet = 5;
            smallBulletDamage = 30f;
            smallBulletSpeed = 45;
            localizationScript.UziText();
        }
        else
        {
            if(common == true)
            {
                if (smallBulletDamage > 25f) { uziCommonDamageIncrease = 6f; }
                if (smallBulletDamage > 35f) { uziCommonDamageIncrease = 6f; }
                if (smallBulletDamage > 50f) { uziCommonDamageIncrease = 5f; }

                if (smallBulletSpeed > 35f) { uziCommonSpeedIncrease = 8f; }
                if (smallBulletSpeed > 50f) { uziCommonSpeedIncrease = 8f; }
                if (smallBulletSpeed > 75f) { uziCommonSpeedIncrease = 7f; }
                if (smallBulletSpeed > 200f) { uziCommonSpeedIncrease = 0f; }
                localizationScript.UziText();
            }
            if (common == false)
            {
                if (smallBulletDamage > 25f) { uziDamageIncrease = 10f; }
                if (smallBulletDamage > 35f) { uziDamageIncrease = 10f; }
                if (smallBulletDamage > 50f) { uziDamageIncrease = 8f; }

                if (smallBulletSpeed > 35f) { uziSpeedIncrease = 10f; }
                if (smallBulletSpeed > 50f) { uziSpeedIncrease = 10f; }
                if (smallBulletSpeed > 75f) { uziSpeedIncrease = 8f; }
                if (smallBulletSpeed > 200f) { uziSpeedIncrease = 0f; }
                localizationScript.UziText();
            }
        }
    }

    #endregion

    #region GUN 1 - Pistol
    public GameObject gun1;

    public static bool chose_Gun1;
    public static float bulletGun1_Damage, bulletGun1_Speed, bulletGun1_DeSpawnTime;
    public static int pistolClicks, pistolClicksNeeded;

    public void ChooseGun1Pistol()
    {
        pistolLEVEL += 1;
        Choises.pistolFirst = true;
        if (firstControlledGun == false) { firstControlledGun = true; }

        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if (chose_Gun1 == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.03f, 0.02f, 0.03f, 0.02f, 0.03f, 0.03f, 0.03f, 0.03f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(1, 1, 0, 0, 0, 0, 0, 0);

            eggPisto.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[5];

            bulletGun1_DeSpawnTime = 4;

            SetControlledGunPos(gun1);
            chose_Gun1 = true;
            gun1.SetActive(true);
        }
      
    }

    public void SetPistolUpgrade(bool common)
    {
        if (chose_Gun1 == false)
        {
            pistolCommonDamageIncrease = 0; pistolCommonSpeedIncrease = 0;
            pistolDamageIncrease = 0; pistolDamageIncrease = 0;

            pistolClicks = 0;
            pistolClicksNeeded = 3;
            if(MobileScript.isMobile == false)
            {
                bulletGun1_Damage = 9;
                bulletGun1_Speed = 65;
            }
            else
            {
                bulletGun1_Damage = 6;
                bulletGun1_Speed = 75;
            }
          
            localizationScript.PistolText();
        }
        else
        {
            if (common == true)
            {
                if (bulletGun1_Damage > 5f) { pistolCommonDamageIncrease = 3f; }
                if (bulletGun1_Damage > 15f) { pistolCommonDamageIncrease = 2f; }
                if (bulletGun1_Damage > 50f) { pistolCommonDamageIncrease = 1f; }

                if (bulletGun1_Speed > 50f) { pistolCommonSpeedIncrease = 4f; }
                if (bulletGun1_Speed > 75f) { pistolCommonSpeedIncrease = 3f; }
                if (bulletGun1_Speed > 100f) { pistolCommonSpeedIncrease = 2f; }
                if (bulletGun1_Speed > 200f) { pistolCommonSpeedIncrease = 0f; }
                localizationScript.PistolText();
            }
            if (common == false)
            {
                if (bulletGun1_Damage > 5f) { pistolDamageIncrease = 5f; }
                if (bulletGun1_Damage > 15f) { pistolDamageIncrease = 4f; }
                if (bulletGun1_Damage > 25f) { pistolDamageIncrease = 3f; }
                if (bulletGun1_Damage > 40f) { pistolDamageIncrease = 2f; }

                if (bulletGun1_Speed > 50f) { pistolSpeedIncrease = 5f; }
                if (bulletGun1_Speed > 75f) { pistolSpeedIncrease = 4f; }
                if (bulletGun1_Speed > 100f) { pistolSpeedIncrease = 3f; }
                if (bulletGun1_Speed > 200f) { pistolSpeedIncrease = 0f; }
                localizationScript.PistolText();
            }
        }
    }
    #endregion

    #region GUN 2 SHOTGUN
    public GameObject gun2;

    public static bool chose_gun2;
    public static float shotGunBulletDamage, shotGunBulletDamage2;
    public static float shotGunBulletSpeed1, shotGunBulletSpeed2;
    public static float shotGunBulletDeSpawnTime1, shotGunBulletDeSpawnTime2;

    public static int shotGunBullets;
    public static int shotGunClicks, shotGunClicksNeeded;

    public void ChooseGun2Shotgun()
    {
        shotgunLEVEL += 1;
        Choises.shotgunFirst = true;
        if (firstControlledGun == false) { firstControlledGun = true; }

        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if(chose_gun2 == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(2, 2, 1, 0, 0, 0, 0, 0);

            eggShotgun.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.2f, 0.2f, 0.1f, 0.2f, 0.3f);
         
            SetControlledGunPos(gun2);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[6];

            chose_gun2 = true;
           
            shotGunBulletDeSpawnTime1 = 1.7f; shotGunBulletDeSpawnTime2 = 1.7f;


            gun2.SetActive(true);
        }
    }

    public void SetShotgunUpgrade(bool common)
    {
        if (chose_gun2 == false)
        {
            shotgunCommonDamageIncrease = 0; shotgunCommonSpeedIncrease = 0;
            shotgunDamageIncrease = 0; shotgunSpeedIncrease = 0;
            shotgunShotsIncrease = 0;

            if(MobileScript.isMobile == false) { shotGunBulletDamage = 6; shotGunBulletDamage2 = 8; }
            else { shotGunBulletDamage = 4; shotGunBulletDamage2 = 6; }

            shotGunBulletSpeed1 = 50; shotGunBulletSpeed2 = 70;
            shotGunBullets = 10;
            shotGunClicks = 0;
            shotGunClicksNeeded = 8;

            localizationScript.ShotgunText();
        }
        else
        {
            if (common == true)
            {
                if (shotGunBulletDamage2 > 5f) { shotgunCommonDamageIncrease = 2f; }
                if (shotGunBulletDamage2 > 15f) { shotgunCommonDamageIncrease = 1f; }
                if (shotGunBulletDamage2 > 25f) { shotgunCommonDamageIncrease = 1f; }

                if (shotGunBulletSpeed2 > 50f) { shotgunCommonSpeedIncrease = 2f; }
                if (shotGunBulletSpeed2 > 90f) { shotgunCommonSpeedIncrease = 1f; }
                if (shotGunBulletSpeed2 > 125f) { shotgunCommonSpeedIncrease = 1f; }
                if (shotGunBulletSpeed2 > 200f) { shotgunCommonSpeedIncrease = 0f; }

                localizationScript.ShotgunText();
            }
            if (common == false)
            {
                if (shotGunBulletDamage2 > 5f) { shotgunDamageIncrease = 4f; }
                if (shotGunBulletDamage2 > 15f) { shotgunDamageIncrease = 3f; }
                if (shotGunBulletDamage2 > 25f) { shotgunDamageIncrease = 2f; }

                if (shotGunBulletSpeed2 > 50f) { shotgunSpeedIncrease = 4f; }
                if (shotGunBulletSpeed2 > 89f) { shotgunSpeedIncrease = 3f; }
                if (shotGunBulletSpeed2 > 125f) { shotgunSpeedIncrease = 2f; }
                if (shotGunBulletSpeed2 > 200f) { shotgunSpeedIncrease = 0f; }

                if (shotGunBullets > 9) { shotgunShotsIncrease = 1; }
                if (shotGunBullets > 13) { shotgunShotsIncrease = 0; }

                localizationScript.ShotgunText();
            }
        }
    }
    #endregion

    #region GUN 3 Mp4
    public GameObject gun3;

    public static bool choseGunMp4;

    public static float mp4Damage, mp4Speed, mp4DespawnTime;
    public static int mp4Clicks, mp4ClicksNeeded;

    public void ChooseGun3Mp4()
    {
        mp4LEVEL += 1;
        mp4First = true;
        if (firstControlledGun == false) { firstControlledGun = true; }

        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if (choseGunMp4 == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(7, 6, 3, 2, 2, 2, 2, 1);

            eggMP4.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.2f, 0.2f, 0.3f, 0.3f, 0.4f, 0.2f, 0.5f, 0.8f);

            SetControlledGunPos(gun3);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[18];
     
            mp4DespawnTime = 5;

            choseGunMp4 = true;

            gun3.SetActive(true);
        }
    }

    public void SetMP4Upgrade(bool common)
    {
        if (choseGunMp4 == false)
        {
            mp4CommonDamageIncrease = 0; mp4CommonSpeedIncrease = 0;
            mp4DamageIncrease = 0; mp4SpeedIncrease = 0;

            mp4Clicks = 0;

            if(MobileScript.isMobile == false)
            {
                mp4Damage = 8;
                mp4Speed = 55;
            }
            else
            {
                mp4Damage = 6;
                mp4Speed = 65;
            }
          
            mp4ClicksNeeded = 2;

            localizationScript.Mp4Text();
        }
        else
        {
            if (common == true)
            {
                if (mp4Damage > 2f) { mp4CommonDamageIncrease = 2f; }
                if (mp4Damage > 12f) { mp4CommonDamageIncrease = 2f; }
                if (mp4Damage > 20f) { mp4CommonDamageIncrease = 1f; }

                if (mp4Speed > 30f) { mp4CommonSpeedIncrease = 3f; }
                if (mp4Speed > 65f) { mp4CommonSpeedIncrease = 3f; }
                if (mp4Speed > 80f) { mp4CommonSpeedIncrease = 2f; }
                if (mp4Speed > 200f) { mp4CommonSpeedIncrease = 0f; }

                localizationScript.Mp4Text();
            }
            if (common == false)
            {
                if (mp4Damage > 2f) { mp4DamageIncrease = 4f; }
                if (mp4Damage > 12f) { mp4DamageIncrease = 3f; }
                if (mp4Damage > 20f) { mp4DamageIncrease = 3f; }

                if (mp4Speed > 30f) { mp4SpeedIncrease = 6f; }
                if (mp4Speed > 65f) { mp4SpeedIncrease = 5f; }
                if (mp4Speed > 80f) { mp4SpeedIncrease = 4f; }
                if (mp4Speed > 200f) { mp4SpeedIncrease = 0f; }

                localizationScript.Mp4Text();
            }
        }
    }
    #endregion

    #region GUN 4 crossBow
    public GameObject crossbow;

    public static bool choseCrossBow;

    public static int crossbowClicks, crossbowClicksNeeded;
    public static float crossbowDamage, crossbowSpeed;

    public void ChooseCrossBow()
    {
        crossbowLEVEL += 1;
        crossbowFirst = true;
        if (firstControlledGun == false) { firstControlledGun = true; }

        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if (choseCrossBow == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(2, 2, 1, 1, 0, 0, 1, 0);

            eggCrossbow.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.2f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f);
       

            SetControlledGunPos(crossbow);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[27];

         
            choseCrossBow = true;

            crossbow.SetActive(true);
        }
    }

    public void SetCrossbowUpgrade(bool common)
    {
        if (choseCrossBow == false)
        {
            crossbowClicks = 0;
            crossbowCommonDamageIncrease = 0; crossbowCommonSpeedIncrease = 0;
            crossbowDamageIncrease = 0; crossbowSpeedIncrease = 0;

            crossbowSpeed = 92;

            if (MobileScript.isMobile == false) 
            {
                crossbowDamage = 22;
            }
            else
            {
                crossbowDamage = 15;
            }

            crossbowClicksNeeded = 4;

            localizationScript.CrossbowText();
        }
        else
        {
            if (common == true)
            {
                if (crossbowDamage > 10f) { crossbowCommonDamageIncrease = 4f; }
                if (crossbowDamage > 35f) { crossbowCommonDamageIncrease = 4f; }
                if (crossbowDamage > 50f) { crossbowCommonDamageIncrease = 3f; }

                if (crossbowSpeed > 70f) { crossbowCommonSpeedIncrease = 5f; }
                if (crossbowSpeed > 110f) { crossbowCommonSpeedIncrease = 5f; }
                if (crossbowSpeed > 150f) { crossbowCommonSpeedIncrease = 5f; }
                if (crossbowSpeed > 200f) { crossbowCommonSpeedIncrease = 0f; }

                localizationScript.CrossbowText();
            }
            if (common == false)
            {
                if (crossbowDamage > 10f) { crossbowDamageIncrease = 7f; }
                if (crossbowDamage > 35f) { crossbowDamageIncrease = 7f; }
                if (crossbowDamage > 50f) { crossbowDamageIncrease = 6f; }

                if (crossbowSpeed > 70f) { crossbowSpeedIncrease = 7f; }
                if (crossbowSpeed > 110f) { crossbowSpeedIncrease = 7f; }
                if (crossbowSpeed > 150f) { crossbowSpeedIncrease = 6f; }
                if (crossbowSpeed > 200f) { crossbowSpeedIncrease = 0f; }

                localizationScript.CrossbowText();
            }
        }
    }
    #endregion

    #region AWP
    public static bool chooseHomingBullets;
    public static int clicksPerHomingBullet, homingBulletClicks;
    public static float homingBulletDamage, homignBulletSpeed;

    public void ChooseHomingBullets()
    {
        awpLEVEL += 1;
        awpFirst = true;
        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if (chooseHomingBullets == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(3, 2, 1, 1, 1, 1, 1, 0);

            eggAWP.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f);
           

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[8];
           
         
            chooseHomingBullets = true;
            //MainButtonCollider.setHomingTarget = true;

            SetAutoGunPosition(gun_Homing);
            gun_Homing.SetActive(true);
        }
    }

    public void SetAWPUpgrade(bool common)
    {
        if (chooseHomingBullets == false)
        {
            awpCommonDamageIncrease = 0; awpCommonSpeedIncrease = 0;
            awpDamageIncrease = 0; awpSpeedIncrease = 0;

            homingBulletClicks = 0;

            if(MobileScript.isMobile == false)
            {
                homignBulletSpeed = 115;
                homingBulletDamage = 23;
            }
            else
            {
                homignBulletSpeed = 120;
                homingBulletDamage = 20;
            }

            clicksPerHomingBullet = 5;

            localizationScript.AwpText();
        }
        else
        {
            if (common == true)
            {
                if (homingBulletDamage > 5f) { awpCommonDamageIncrease = 5f; }
                if (homingBulletDamage > 25f) { awpCommonDamageIncrease = 5f; }
                if (homingBulletDamage > 35f) { awpCommonDamageIncrease = 4f; }

                if (homignBulletSpeed > 100f) { awpCommonSpeedIncrease = 8f; }
                if (homignBulletSpeed > 140f) { awpCommonSpeedIncrease = 8f; }
                if (homignBulletSpeed > 170f) { awpCommonSpeedIncrease = 7f; }
                if (homignBulletSpeed > 200f) { awpCommonSpeedIncrease = 0f; }

                localizationScript.AwpText();
            }
            if (common == false)
            {
                if (homingBulletDamage > 5f) { awpDamageIncrease = 8f; }
                if (homingBulletDamage > 25f) { awpDamageIncrease = 8f; }
                if (homingBulletDamage > 35f) { awpDamageIncrease = 7f; }

                if (homignBulletSpeed > 100f) { awpSpeedIncrease = 10f; }
                if (homignBulletSpeed > 140f) { awpSpeedIncrease = 10f; }
                if (homignBulletSpeed > 170f) { awpSpeedIncrease = 8f; }
                if (homignBulletSpeed > 200f) { awpSpeedIncrease = 0f; }

                localizationScript.AwpText();
            }
        }
    }
    #endregion

    #region tripple shot
    public static bool choseTrippleShot;
    public static int trippleShotClick, trippleShotNeeded;
    public static float trippleShotDamage, trippleShotSpeed;

    public void ChooseTrippleShot()
    {
        deagleLEVEL += 1;
        deagleFirst = true;
        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if (choseTrippleShot == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(3, 2, 1, 1, 1, 1, 1, 0);

            eggDeagle.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.3f, 0.4f);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[19];

            choseTrippleShot = true;

            SetAutoGunPosition(gun_trippleShot);
            gun_trippleShot.SetActive(true);
        }
    }
    public void SetTrippleShotUpgrade(bool common)
    {
        if (choseTrippleShot == false)
        {
            deagleCommonDamageIncrease = 0; deagleCommonSpeedIncrease = 0;
            deagleDamageIncrease = 0; deagleSpeedIncrease = 0;

            if (MobileScript.isMobile == false)
            {
                trippleShotDamage = 7;
                trippleShotSpeed = 70;
            }
            else
            {
                trippleShotDamage = 5;
                trippleShotSpeed = 60;
            }

            trippleShotClick = 0;
           
            trippleShotNeeded = 3;

            localizationScript.DeagleText();
        }
        else
        {
            if (common == true)
            {
                if (trippleShotDamage > 4f) { deagleCommonDamageIncrease = 3f; }
                if (trippleShotDamage > 15f) { deagleCommonDamageIncrease = 2f; }
                if (trippleShotDamage > 25f) { deagleCommonDamageIncrease = 2f; }

                if (trippleShotSpeed > 45f) { deagleCommonSpeedIncrease = 5f; }
                if (trippleShotSpeed > 90f) { deagleCommonSpeedIncrease = 5f; }
                if (trippleShotSpeed > 115f) { deagleCommonSpeedIncrease = 5f; }
                if (trippleShotSpeed > 200f) { deagleCommonSpeedIncrease = 0f; }

                localizationScript.DeagleText();
            }
            if (common == false)
            {
                if (trippleShotDamage > 4f) { deagleDamageIncrease = 4f; }
                if (trippleShotDamage > 15f) { deagleDamageIncrease = 4f; }
                if (trippleShotDamage > 25f) { deagleDamageIncrease = 3f; }

                if (trippleShotSpeed > 45f) { deagleSpeedIncrease = 9f; }
                if (trippleShotSpeed > 90f) { deagleSpeedIncrease = 8f; }
                if (trippleShotSpeed > 115f) { deagleSpeedIncrease = 8f; }
                if (trippleShotSpeed > 200f) { deagleSpeedIncrease = 0f; }

                localizationScript.DeagleText();
            }
        }
    }
    #endregion

    #region CANNON
    public static bool chooseBigPiercingBulletGun;
    public static int clicksPerBigBullet, bigBulletClicks;
    public static float bigBulletDamage, bigBulletSpeed, bigBulletLastTime;

    public void ChooseCannon()
    {
        cannonLEVEL += 1;
        cannonFirst = true;
        if (firstWeaponChosen == false)
        {
            SetFirstWeapon();
            firstWeaponChosen = true;
        }

        if(chooseBigPiercingBulletGun == true)
        {
            UnPauseGame();
            DecreaseNormalEnemySpawnTime(0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.09f, 0.1f);
        }
        else
        {
            numberOfGunsCurrentRun += 1;
            totalGunsAcquired += 1; SetGunVolume();
            IncreaseMaxEnemyspawn(8, 7, 3, 2, 2, 2, 3, 2);

            eggCannon.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.2f, 0.3f, 0.3f, 0.4f, 0.5f, 0.4f, 0.7f, 1f);
           
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[7];

            bigBulletLastTime = 11;
            bigBulletClicks = 0;

         
            SetAutoGunPosition(gun_bigPiercing);
            gun_bigPiercing.SetActive(true);
            chooseBigPiercingBulletGun = true;
        }
    }
    public void SetCannonUpgrade(bool common)
    {
        if (chooseBigPiercingBulletGun == false)
        {
            cannonCommonDamageIncrease = 0; cannonCommonSpeedIncrease = 0;
            cannonDamageIncrease = 0; cannonSpeedIncrease = 0;

            bigBulletSpeed = 35;
            bigBulletDamage = 33;
            clicksPerBigBullet = 16;

            localizationScript.CannonText();
        }
        else
        {
            if (common == true)
            {
                if (bigBulletDamage > 20f) { cannonCommonDamageIncrease = 4f; }
                if (bigBulletDamage > 55f) { cannonCommonDamageIncrease = 3f; }
                if (bigBulletDamage > 75f) { cannonCommonDamageIncrease = 2f; }

                if (bigBulletSpeed > 20f) { cannonCommonSpeedIncrease = 3f; }
                if (bigBulletSpeed > 45f) { cannonCommonSpeedIncrease = 2f; }
                if (bigBulletSpeed > 60f) { cannonCommonSpeedIncrease = 2f; }
                if (bigBulletSpeed > 200f) { cannonCommonSpeedIncrease = 0f; }

                localizationScript.CannonText();
            }
            if (common == false)
            {
                if (bigBulletDamage > 20f) { cannonDamageIncrease = 9f; }
                if (bigBulletDamage > 50f) { cannonDamageIncrease = 8f; }
                if (bigBulletDamage > 75f) { cannonDamageIncrease = 7f; }

                if (bigBulletSpeed > 20f) { cannonSpeedIncrease = 8f; }
                if (bigBulletSpeed > 45f) { cannonSpeedIncrease = 7f; }
                if (bigBulletSpeed > 60f) { cannonSpeedIncrease = 6f; }
                if (bigBulletSpeed > 200f) { cannonSpeedIncrease = 0f; }

                localizationScript.CannonText();
            }
        }
    }
    #endregion

    #region piercing bullets
    public static bool chosePiercingBullets;
    public void ChoosePiercingBullets()
    {
        chosePiercingBullets = true;
        UnPauseGame();
    }
    #endregion

    #region bouncing bullets & game arena
    public static int arenaSpawnPointChangeY, arenaSpawnPointChangeX;
    public GameObject gameArena;
    public static float hordeStartCameraSize;
    public static bool choseBouncingBullets;
    public static float arenaIncrease;
    public static int arenaUpgradeCount;

    //3 Arena Size Max
    public void SetArenaSize()
    {
        if (arenaUpgradeCount > 34)
        {
            arenaIncrease += 0f;
            hordeStartCameraSize += 0f;
            arenaSpawnPointChangeY += 0;
            arenaSpawnPointChangeX += 0;
        }
        else if (arenaUpgradeCount > 15)
        {
            arenaIncrease += 0.01f;
            hordeStartCameraSize += 0.357f;
            arenaSpawnPointChangeY += 5;
            arenaSpawnPointChangeX += 9;
        }
        else if(arenaUpgradeCount > 11)
        {
            arenaIncrease += 0.05f;
            hordeStartCameraSize += 1.78f;
            arenaSpawnPointChangeY += 26;
            arenaSpawnPointChangeX += 46;
        }
        else if(arenaUpgradeCount > 6)
        {
            arenaIncrease += 0.1f;
            hordeStartCameraSize += 3.57f;
            arenaSpawnPointChangeY += 53;
            arenaSpawnPointChangeX += 93;
        }
        else if (arenaUpgradeCount > 0)
        {
            arenaIncrease += 0.15f;
            hordeStartCameraSize += 5.36f;
            arenaSpawnPointChangeY += 80;
            arenaSpawnPointChangeX += 140;
        }
        arenaUpgradeCount += 1;

        //Debug.Log(arenaUpgradeCount);
        //Debug.Log(arenaIncrease);

        gameArena.transform.localScale = new Vector3(normalArenaSize + arenaIncrease, normalArenaSize + arenaIncrease, normalArenaSize + arenaIncrease);
    }

    public void ChooseArenaAndBouncingBullets()
    {
        arenaLEVEL += 1;
        audioManager.Play("SelectAbilityUncommon");

        arenaFirst = true;
        ChoseUncommonSetChance();
        SetEnemyStats(18, false);
        if (choseBouncingBullets == true)
        {
            IncreaseMaxEnemyspawn(1, 1, 0, 0, 0, 0, 0, 0);

            SetArenaSize();
        }
        else
        {
            IncreaseMaxEnemyspawn(4, 3, 1, 1, 1, 1, 1, 1);

            eggArena.SetActive(true);
            gameArena.transform.localScale = new Vector3(1, 1, 1);
            DecreaseEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.2f);
            rareAbilitesNotAviable -= 1;
            rareAbilitiesAviable += 1;
            activeRareAbilities[rareAbilitiesAviable] = allRareAbilitites[5]; //Button Bounce Charge

            legendaryAbilitiesNotAvailable -= 1;
            legendaryAbilitiesAviable += 1;
            activeLegendaryAbilities[legendaryAbilitiesAviable] = allLegendaryAbilities[2]; //Rocket

            choseBouncingBullets = true;
            arenaObject.SetActive(true);
            arenaUpgradeCount += 1;
        }

      
        UnPauseGame();
    }
    public void SetArenaUpgrade()
    {
        localizationScript.ArenaText();
    }
    #endregion

    #region Charged Bullets 
    public static bool choseButtonCharge;
    public static float maxButtonCharge;
    public static float buttonChargePerSecond;
    public static float chargedBulletDamageIncrement, chargedBulletMaxDamage;
    public static float chargedBulletChargeTime;
    public static int chargedBulletsCount;

    public static int chargedBulletsCountIncrease;
    public static float chargedBulletMaxDamageIncrease, chargedBulletChargeTimeIncrease;
    public static float chargedBulletcommonMaxDamageIncrease, chargedBulletcommonChargeTimeIncrease;

    public void ChooseButtonCharge()
    {
        chargedBulletLEVEL += 1;
        chargedBulletFirst = true;
        if (choseButtonCharge == true)
        {
          
        }
        else
        {
            IncreaseMaxEnemyspawn(3, 2, 1, 1, 0, 0, 0, 0);

            eggChargedBullet.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.2f, 0.2f, 0.2f, 0.2f, 0.3f, 0.4f);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[28];

            maxButtonCharge = 35;
            buttonChargePerSecond = 1f;

            if (MobileScript.isMobile == false)
            {
                chargedBulletChargeTime = 5;
            }
            else
            {
                chargedBulletChargeTime = 4;
            }
        }

      
        choseButtonCharge = true;
        UnPauseGame();
    }

    public void SetChargedBulletUpgrade(bool common)
    {
        if (choseButtonCharge == false)
        {
            chargedBulletcommonMaxDamageIncrease = 0; chargedBulletcommonChargeTimeIncrease = 0;
            chargedBulletMaxDamageIncrease = 0; chargedBulletChargeTimeIncrease = 0;

            if(MobileScript.isMobile == false)
            {
                chargedBulletMaxDamage = 12;
                chargedBulletChargeTime = 5;
            }
            else
            {
                chargedBulletMaxDamage = 18;
                chargedBulletChargeTime = 4;
            }

            chargedBulletsCount = 15;

            localizationScript.ChargedBulletsText();
        }
        else
        {
            if (common == true)
            {
                if (chargedBulletMaxDamage > 10f) { chargedBulletcommonMaxDamageIncrease = 3f; }
                if (chargedBulletMaxDamage > 25) { chargedBulletcommonMaxDamageIncrease = 2f; }
                if (chargedBulletMaxDamage > 45f) { chargedBulletcommonMaxDamageIncrease = 1f; }

                if (chargedBulletChargeTime < 6f) { chargedBulletcommonChargeTimeIncrease = 0.2f; }
                if (chargedBulletChargeTime < 3.5f) { chargedBulletcommonChargeTimeIncrease = 0.2f; }
                if (chargedBulletChargeTime < 2.5f) { chargedBulletcommonChargeTimeIncrease = 0.15f; }
                if (chargedBulletChargeTime < 2f) { chargedBulletcommonChargeTimeIncrease = 0.1f; }
                if (chargedBulletChargeTime < 1.5f) { chargedBulletcommonChargeTimeIncrease = 0.1f; }
                if (chargedBulletChargeTime <= 1) { chargedBulletcommonChargeTimeIncrease = 0f; }

                localizationScript.ChargedBulletsText();
            }
            if (common == false)
            {
                if (chargedBulletMaxDamage > 10f) { chargedBulletMaxDamageIncrease = 4f; }
                if (chargedBulletMaxDamage > 25) { chargedBulletMaxDamageIncrease = 4f; }
                if (chargedBulletMaxDamage > 45f) { chargedBulletMaxDamageIncrease = 3f; }

                if (chargedBulletChargeTime < 6f) { chargedBulletChargeTimeIncrease = 0.4f; }
                if (chargedBulletChargeTime < 3.5f) { chargedBulletChargeTimeIncrease = 0.5f; }
                if (chargedBulletChargeTime < 2.5f) { chargedBulletChargeTimeIncrease = 0.2f; }
                if (chargedBulletChargeTime < 2f) { chargedBulletChargeTimeIncrease = 0.15f; }
                if (chargedBulletChargeTime < 1.5f) { chargedBulletChargeTimeIncrease = 0.1f; }
                if (chargedBulletChargeTime <= 1) { chargedBulletChargeTimeIncrease = 0f; }

                localizationScript.ChargedBulletsText();
            }
        }
    }
    #endregion

    #region Arrows
    public static bool choseArrows;
    public static int arrowCountShot;
    public static float arrowDamage;
    public static int arrowClicks, arrowClicksNeeded;

    public static int arrowCountIncrease;
    public static float arrowDamageIncrease;

    public static int arrowCommonCountIncrease;
    public static float arrowCommonDamageIncrease;

    public void ChooseArrows()
    {
        arrosLEVEL += 1;
        arrosFirst = true;
        if (choseArrows == true)
        {
            DecreaseNormalEnemySpawnTime(0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f);
        }
        else
        {
            IncreaseMaxEnemyspawn(5, 4, 2, 1, 1, 3, 2, 1);

            eggArrow.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.2f, 0.2f, 0.2f, 0.2f, 0.4f, 0.3f, 0.5f, 0.8f);
           
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[13];

            choseArrows = true;
        }
       
        UnPauseGame();
    }

    public void SetArrowUpgrade(bool common)
    {
        if (choseArrows == false)
        {
            arrowCommonDamageIncrease = 0; arrowCommonCountIncrease = 0;
            arrowDamageIncrease = 0; arrowCountIncrease = 0;

            arrowClicks = 0;
            arrowClicksNeeded = 50;
            arrowCountShot = 40;
            arrowDamage = 14f;

            localizationScript.ArrowText();
        }
        else
        {
            if (common == true)
            {
                if (arrowDamage > 5f) { arrowCommonDamageIncrease = 4f; }
                if (arrowDamage > 20) { arrowCommonDamageIncrease = 3f; }
                if (arrowDamage > 45f) { arrowCommonDamageIncrease = 2f; }

                if (arrowCountShot > 30) { arrowCommonCountIncrease = 2; }
                if (arrowCountShot > 50) { arrowCommonCountIncrease = 1; }
                if (arrowCountShot > 60) { arrowCommonCountIncrease = 0; }

                localizationScript.ArrowText();
            }
            if (common == false)
            {
                if (arrowDamage > 5f) { arrowDamageIncrease = 7f; }
                if (arrowDamage > 20) { arrowDamageIncrease = 7f; }
                if (arrowDamage > 45f) { arrowDamageIncrease = 6f; }

                if (arrowCountShot > 30) { arrowCountIncrease = 4; }
                if (arrowCountShot > 50) { arrowCountIncrease = 3; }
                if (arrowCountShot > 60) { arrowCountIncrease = 0; }

                localizationScript.ArrowText();
            }
        }
       
    }
    #endregion

    #region Controlled weapon spot fill out
    public static int controlledSpotFilled;
    public void SetControlledGunPos(GameObject weapon)
    {
        controlledSpotFilled += 1;
        if (controlledSpotFilled == 1) { weapon.transform.SetParent(controlledCenteredPos); weapon.transform.position = controlledCenteredPos.transform.position; }
        if (controlledSpotFilled == 2)
        {
            weapon.transform.SetParent(controlledPosLeft);
            weapon.transform.position = controlledPosLeft.transform.position;

            // Find the child gameobject of "controlledCenteredPos"
            Transform centeredChild = controlledCenteredPos.transform.GetChild(0);

            // Set the child as a child of "controlledPosRight" with the same position
            centeredChild.SetParent(controlledPosRight);
            centeredChild.position = controlledPosRight.transform.position;
        }
        if (controlledSpotFilled == 3) { weapon.transform.SetParent(controlledPosUp); weapon.transform.position = controlledPosUp.transform.position; }
        if (controlledSpotFilled == 4) { weapon.transform.SetParent(controlledPosDown); weapon.transform.position = controlledPosDown.transform.position; }
    }
    #endregion

    #region Auto Controlled Weapon Spots fill out
    public static int weaponSpotsFilledOut;
    public void SetAutoGunPosition(GameObject weapon)
    {
        weaponSpotsFilledOut += 1;
        if (weaponSpotsFilledOut == 1) { weapon.transform.SetParent(gunHolderTopLeft); weapon.transform.position = gunHolderTopLeft.transform.position; }
        if (weaponSpotsFilledOut == 2) { weapon.transform.SetParent(gunHolderTopRight); weapon.transform.position = gunHolderTopRight.transform.position; }
        if (weaponSpotsFilledOut == 3) { weapon.transform.SetParent(gunHolderBottomLeft); weapon.transform.position = gunHolderBottomLeft.transform.position; }
        if (weaponSpotsFilledOut == 4) { weapon.transform.SetParent(gunHolderBottomRight); weapon.transform.position = gunHolderBottomRight.transform.position; }
    }
    #endregion


    #region Change Gun VOLUME
    public float uziVolume, pistolVolume, shotgunVolume, crossbowVolume, deagleVolume, awpVolume, cannonVolume, mp4Volume;

    public float uziVolumeDouble, pistolVolumeDouble, shotgunVolumeDouble, crossbowVolumeDouble, deagleVolumeDouble, awpVolumeDouble, cannonVolumeDouble, mp4VolumeDouble;

    public float clickSoundvolume;

    public void SetGunVolume()
    {
        if(choseDoubleTap == true)
        {
            uziVolumeDouble = 0.04f; pistolVolumeDouble = 0.01f; shotgunVolumeDouble = 0.08f;
            crossbowVolumeDouble = 0.08f; deagleVolumeDouble = 0.011f; awpVolumeDouble = 0.08f;
            cannonVolumeDouble = 0.08f; mp4VolumeDouble = 0.12f;
        }

        if (totalGunsAcquired == 0)
        {
            clickSoundvolume = 0.4f;
        }

        if (totalGunsAcquired == 1)
        {
            clickSoundvolume = 0.3f;

            uziVolume = 0.27f - uziVolumeDouble; pistolVolume = 0.1f - pistolVolumeDouble; shotgunVolume = 0.61f - shotgunVolumeDouble;
            crossbowVolume = 0.39f - crossbowVolumeDouble; deagleVolume = 0.112f - deagleVolumeDouble; awpVolume = 0.30f - awpVolumeDouble;
            cannonVolume = 0.29f - cannonVolumeDouble; mp4Volume = 0.52f - mp4VolumeDouble;
        }
        if (totalGunsAcquired == 2)
        {
            clickSoundvolume = 0.25f;

            uziVolume = 0.24f - uziVolumeDouble; pistolVolume = 0.078f - pistolVolumeDouble; shotgunVolume = 0.59f - shotgunVolumeDouble;
            crossbowVolume = 0.36f - crossbowVolumeDouble; deagleVolume = 0.104f - deagleVolumeDouble; awpVolume = 0.28f - awpVolumeDouble;
            cannonVolume = 0.27f - cannonVolumeDouble; mp4Volume = 0.48f - mp4VolumeDouble;
        }

        if (totalGunsAcquired == 3)
        {
            clickSoundvolume = 0.22f;

            uziVolume = 0.23f - uziVolumeDouble; pistolVolume = 0.073f - pistolVolumeDouble; shotgunVolume = 0.56f - shotgunVolumeDouble;
            crossbowVolume = 0.34f - crossbowVolumeDouble; deagleVolume = 0.097f - deagleVolumeDouble; awpVolume = 0.25f - awpVolumeDouble;
            cannonVolume = 0.26f - cannonVolumeDouble; mp4Volume = 0.42f - mp4VolumeDouble;
        }

        if (totalGunsAcquired == 4)
        {
            clickSoundvolume = 0.2f;

            uziVolume = 0.2f - uziVolumeDouble; pistolVolume = 0.065f - pistolVolumeDouble; shotgunVolume = 0.39f - shotgunVolumeDouble;
            crossbowVolume = 0.31f - crossbowVolumeDouble; deagleVolume = 0.093f - deagleVolumeDouble; awpVolume = 0.243f - awpVolumeDouble;
            cannonVolume = 0.251f - cannonVolumeDouble; mp4Volume = 0.4f - mp4VolumeDouble;
        }

        if (totalGunsAcquired == 5)
        {
            clickSoundvolume = 0.18f;

            uziVolume = 0.208f - uziVolumeDouble; pistolVolume = 0.067f - pistolVolumeDouble; shotgunVolume = 0.384f - shotgunVolumeDouble;
            crossbowVolume = 0.302f - crossbowVolumeDouble; deagleVolume = 0.082f - deagleVolumeDouble; awpVolume = 0.238f - awpVolumeDouble;
            cannonVolume = 0.245f - cannonVolumeDouble; mp4Volume = 0.39f - mp4VolumeDouble;
        }

        if (totalGunsAcquired == 6)
        {
            clickSoundvolume = 0.14f;

            uziVolume = 0.2f - uziVolumeDouble; pistolVolume = 0.06f - pistolVolumeDouble; shotgunVolume = 0.37f - shotgunVolumeDouble;
            crossbowVolume = 0.295f - crossbowVolumeDouble; deagleVolume = 0.08f - deagleVolumeDouble; awpVolume = 0.23f - awpVolumeDouble;
            cannonVolume = 0.24f - cannonVolumeDouble; mp4Volume = 0.38f - mp4VolumeDouble;
        }

        if (totalGunsAcquired == 7)
        {
            clickSoundvolume = 0.12f;

            uziVolume = 0.17f - uziVolumeDouble; pistolVolume = 0.055f - pistolVolumeDouble; shotgunVolume = 0.34f - shotgunVolumeDouble;
            crossbowVolume = 0.27f - crossbowVolumeDouble; deagleVolume = 0.076f - deagleVolumeDouble; awpVolume = 0.21f - awpVolumeDouble;
            cannonVolume = 0.21f - cannonVolumeDouble; mp4Volume = 0.34f - mp4VolumeDouble;
        }

        if (totalGunsAcquired == 8)
        {
            clickSoundvolume = 0.15f;

            uziVolume = 0.16f - uziVolumeDouble; pistolVolume = 0.043f - pistolVolumeDouble; shotgunVolume = 0.29f - shotgunVolumeDouble;
            crossbowVolume = 0.25f - crossbowVolumeDouble; deagleVolume = 0.072f - deagleVolumeDouble; awpVolume = 0.19f - awpVolumeDouble;
            cannonVolume = 0.19f - cannonVolumeDouble; mp4Volume = 0.3f - mp4VolumeDouble;
        }

        audioManager.ChangeVolume("ButtonClickIn1", clickSoundvolume);
        audioManager.ChangeVolume("ButtonClickIn2", clickSoundvolume);

        audioManager.ChangeVolume("ButtonClickOut1", clickSoundvolume);
        audioManager.ChangeVolume("ButtonClickOut2", clickSoundvolume);

        audioManager.ChangeVolume("Uzi1", uziVolume);
        audioManager.ChangeVolume("Uzi2", uziVolume);
        audioManager.ChangeVolume("Uzi3", uziVolume);
        audioManager.ChangeVolume("Uzi4", uziVolume);

        audioManager.ChangeVolume("Pistol1", pistolVolume);
        audioManager.ChangeVolume("Pistol2", pistolVolume);
        audioManager.ChangeVolume("Pistol3", pistolVolume);
        audioManager.ChangeVolume("Pistol4", pistolVolume);
        audioManager.ChangeVolume("Pistol5", pistolVolume);

        audioManager.ChangeVolume("awp1", awpVolume);
        audioManager.ChangeVolume("awp2", awpVolume);

        audioManager.ChangeVolume("Deagle1", deagleVolume);
        audioManager.ChangeVolume("Deagle2", deagleVolume);
        audioManager.ChangeVolume("Deagle3", deagleVolume);

        audioManager.ChangeVolume("Cannon1", cannonVolume);
        audioManager.ChangeVolume("Cannon2", cannonVolume);

        audioManager.ChangeVolume("Mp1", mp4Volume);
        audioManager.ChangeVolume("Mp2", mp4Volume);
        audioManager.ChangeVolume("Mp3", mp4Volume);
        audioManager.ChangeVolume("Mp4", mp4Volume);

        audioManager.ChangeVolume("Crossbow", crossbowVolume);

        audioManager.ChangeVolume("Shotgun1", shotgunVolume);
        audioManager.ChangeVolume("Shotgun2", shotgunVolume);
    }
    #endregion


    //Choose which enemy to spawn
    #region random enemy spawn choose
    public GameObject[] enemyTextArray;

    public GameObject smallEnemySpawnText, speedsterSpawnText, sharpshooterSpawnText, sniperSpawnText, gunnerSpawnText, heavyshotSpawnText, bruteSpawnText, titanSpawnText;
    public bool got1GunAbility;
    public bool got1RareGunAbility, got2RareGunAbility, got3RareGunAbility;
    public int uncommonGunsAppeared, rareGunsAppeared, legendaryGunsAppeared;
    public Transform originalEnemyTextParent;

    public void SetEnemyTextsInactive()
    {
        smallEnemySpawnText.transform.SetParent(originalEnemyTextParent);
        speedsterSpawnText.transform.SetParent(originalEnemyTextParent);
        sharpshooterSpawnText.transform.SetParent(originalEnemyTextParent);
        sniperSpawnText.transform.SetParent(originalEnemyTextParent);
        gunnerSpawnText.transform.SetParent(originalEnemyTextParent);
        heavyshotSpawnText.transform.SetParent(originalEnemyTextParent);
        bruteSpawnText.transform.SetParent(originalEnemyTextParent);
        titanSpawnText.transform.SetParent(originalEnemyTextParent);

        got1GunAbility = false;
        got1RareGunAbility = false;
        got2RareGunAbility = false;
        got3RareGunAbility = false;
        smallEnemySpawnText.SetActive(false);
        speedsterSpawnText.SetActive(false);
        sharpshooterSpawnText.SetActive(false);
        sniperSpawnText.SetActive(false);
        gunnerSpawnText.SetActive(false);
        heavyshotSpawnText.SetActive(false);
        bruteSpawnText.SetActive(false);
        titanSpawnText.SetActive(false);
    }


    //enemyDifficulty. 1-2 = easy. 3-6 = mid. 7-8 = Hard
    public void SetRandomEnemyText(GameObject gunAbility, int enemyDifficulty)
    {
        #region Small enemy and speedster
        if (speedsterSpawn == false && smallEnemySpawn == false)
        {
            if (got1GunAbility == false && (enemyDifficulty == 1 || enemyDifficulty == 2))
            {
                got1GunAbility = true;
                uncommonGunsAppeared += 1;
                smallEnemySpawnText.gameObject.SetActive(true);
                smallEnemySpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                smallEnemySpawnText.transform.position = gunAbility.transform.position;
                smallEnemySpawnText.transform.localScale = new Vector2(1, 1);
            }
            else if (got1GunAbility == true && (enemyDifficulty == 1 || enemyDifficulty == 2))
            {
                uncommonGunsAppeared += 1;
                speedsterSpawnText.gameObject.SetActive(true);
                speedsterSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                speedsterSpawnText.transform.position = gunAbility.transform.position;
                speedsterSpawnText.transform.localScale = new Vector2(1, 1);
            }
        }
        else
        {
            if (smallEnemySpawn == false && (enemyDifficulty == 1 || enemyDifficulty == 2))
            {
                smallEnemySpawnText.gameObject.SetActive(true);
                smallEnemySpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                smallEnemySpawnText.transform.position = gunAbility.transform.position;
                smallEnemySpawnText.transform.localScale = new Vector2(1, 1);
            }
            if (speedsterSpawn == false && (enemyDifficulty == 1 || enemyDifficulty == 2))
            {
                speedsterSpawnText.gameObject.SetActive(true);
                speedsterSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                speedsterSpawnText.transform.position = gunAbility.transform.position;
                speedsterSpawnText.transform.localScale = new Vector2(1, 1);
            }
        }
        #endregion

        #region Brute, sharpshooter
        if (bigEnemySpawn == false && shootingEnemySpawn == false)
        {
            if(enemyDifficulty == 3 || enemyDifficulty == 4)
            {
                if (got1RareGunAbility == false)
                {
                    got1RareGunAbility = true;
                    rareGunsAppeared += 1;
                    sharpshooterSpawnText.gameObject.SetActive(true);
                    sharpshooterSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    sharpshooterSpawnText.transform.position = gunAbility.transform.position;
                    sharpshooterSpawnText.transform.localScale = new Vector2(1,1);
                }
                else if (got1RareGunAbility == true)
                {
                    rareGunsAppeared += 1;
                    bruteSpawnText.gameObject.SetActive(true);
                    bruteSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    bruteSpawnText.transform.position = gunAbility.transform.position;
                    bruteSpawnText.transform.localScale = new Vector2(1, 1);
                }
            }
        }
        else
        {
            if (enemyDifficulty == 3 || enemyDifficulty == 4)
            {
                if (bigEnemySpawn == false )
                {
                    bruteSpawnText.gameObject.SetActive(true);
                    bruteSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    bruteSpawnText.transform.position = gunAbility.transform.position;
                    bruteSpawnText.transform.localScale = new Vector2(1, 1);
                }
                if (shootingEnemySpawn == false)
                {
                    sharpshooterSpawnText.gameObject.SetActive(true);
                    sharpshooterSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    sharpshooterSpawnText.transform.position = gunAbility.transform.position;
                    sharpshooterSpawnText.transform.localScale = new Vector2(1, 1);
                }
            }
        }
        #endregion

        #region Heavy, sniper
        if (heavyShotSpawn == false && sniperSpawn == false)
        {
            if (enemyDifficulty == 5 || enemyDifficulty == 6)
            {
                if (got2RareGunAbility == false)
                {
                    got2RareGunAbility = true;
                    rareGunsAppeared += 1;
                    sniperSpawnText.gameObject.SetActive(true);
                    sniperSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    sniperSpawnText.transform.position = gunAbility.transform.position;
                    sniperSpawnText.transform.localScale = new Vector2(1, 1);
                }
                else if (got2RareGunAbility == true)
                {
                    rareGunsAppeared += 1;
                    heavyshotSpawnText.gameObject.SetActive(true);
                    heavyshotSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    heavyshotSpawnText.transform.position = gunAbility.transform.position;
                    heavyshotSpawnText.transform.localScale = new Vector2(1, 1);
                }
            }
        }
        else
        {
            if (enemyDifficulty == 5 || enemyDifficulty == 6)
            {
                if (heavyShotSpawn == false)
                {
                    heavyshotSpawnText.gameObject.SetActive(true);
                    heavyshotSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    heavyshotSpawnText.transform.position = gunAbility.transform.position;
                    heavyshotSpawnText.transform.localScale = new Vector2(1, 1);
                }
                if (sniperSpawn == false)
                {
                    sniperSpawnText.gameObject.SetActive(true);
                    sniperSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    sniperSpawnText.transform.position = gunAbility.transform.position;
                    sniperSpawnText.transform.localScale = new Vector2(1, 1);
                }
            }
        }
        #endregion

        #region RagingGunner, Titan
        if (ragingGunnerSpawn == false && titanSpawn == false)
        {
            if (enemyDifficulty == 7 || enemyDifficulty == 8)
            {
                if (got3RareGunAbility == false)
                {
                    got3RareGunAbility = true;
                    rareGunsAppeared += 1;
                    gunnerSpawnText.gameObject.SetActive(true);
                    gunnerSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    gunnerSpawnText.transform.position = gunAbility.transform.position;
                    gunnerSpawnText.transform.localScale = new Vector2(1, 1);
                }
                else if (got3RareGunAbility == true)
                {
                    rareGunsAppeared += 1;
                    titanSpawnText.gameObject.SetActive(true);
                    titanSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    titanSpawnText.transform.position = gunAbility.transform.position;
                    titanSpawnText.transform.localScale = new Vector2(1, 1);
                }
            }
        }
        else
        {
            if (enemyDifficulty == 7 || enemyDifficulty == 8)
            {
                if (ragingGunnerSpawn == false)
                {
                    gunnerSpawnText.gameObject.SetActive(true);
                    gunnerSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    gunnerSpawnText.transform.position = gunAbility.transform.position;
                    gunnerSpawnText.transform.localScale = new Vector2(1, 1);
                }
                if (titanSpawn == false)
                {
                    titanSpawnText.gameObject.SetActive(true);
                    titanSpawnText.transform.SetParent(gunAbility.GetComponent<Transform>());
                    titanSpawnText.transform.position = gunAbility.transform.position;
                    titanSpawnText.transform.localScale = new Vector2(1, 1);
                }
            }
        }
        #endregion

        localizationScript.EnemyText();
    }

    public void SetChosenEnemy()
    {

    }
    #endregion

    //Melle weapons
    public static int numberOfMeleeCurrentRun;
    #region SWORD
    public GameObject bigSpike, sword2, sword3, sword4;

    public static bool chooseBigSpike;
    public static float bigSpikeDamage;
    public static float swordSpeed;

    public static int swordDamageIcrease, swordCommonDamageIcrease;
    public static float swordSpeedIncrease, swordCommonSpeedIncrease;

    public void AddSword()
    {
        if(bigSpike.activeInHierarchy == false) { bigSpike.SetActive(true); }
        else if (sword2.activeInHierarchy == false) { sword2.SetActive(true); }
        else if (sword3.activeInHierarchy == false) { sword3.SetActive(true); }
        else if (sword4.activeInHierarchy == false) { sword4.SetActive(true); }
    }

    public void ChooseBigSpike()
    {
        swordLEVEL += 1;
        swordFirst = true;
        if (chooseBigSpike == true)
        {
            DecreaseNormalEnemySpawnTime(0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f);
        }
        else
        {
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(5, 4, 0, 0, 0, 1, 2, 1);

            eggSword.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.15f, 0.12f, 0.07f, 0.07f, 0.07f, 0.1f, 0.4f, 0.5f);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[9];

            chooseBigSpike = true;
        }

        UnPauseGame();
    }

    public void SetSwordUpgrade(bool common)
    {
        if (chooseBigSpike == false)
        {
            swordCommonDamageIcrease = 0; swordCommonSpeedIncrease = 0;
            swordDamageIcrease = 0; swordSpeedIncrease = 0;

            swordSpeed = 100;
            bigSpikeDamage = 13;

            localizationScript.SwordText();
        }
        else
        {
            if (common == true)
            {
                if (bigSpikeDamage > 10f) { swordCommonDamageIcrease = 4; }
                if (bigSpikeDamage > 30) { swordCommonDamageIcrease = 3; }
                if (bigSpikeDamage > 50) { swordCommonDamageIcrease = 3; }

                if (swordSpeed > 90) { swordCommonSpeedIncrease = 7; }
                if (swordSpeed > 120) { swordCommonSpeedIncrease = 7; }
                if (swordSpeed > 140) { swordCommonSpeedIncrease = 6; }
                if (swordSpeed > 250) { swordCommonSpeedIncrease = 1; }

                localizationScript.SwordText();
            }
            if (common == false)
            {
                if (bigSpikeDamage > 10f) { swordDamageIcrease = 7; }
                if (bigSpikeDamage > 30) { swordDamageIcrease = 6; }
                if (bigSpikeDamage > 50f) { swordDamageIcrease = 4; }

                if (swordSpeed > 90) { swordSpeedIncrease = 10; }
                if (swordSpeed > 120) { swordSpeedIncrease = 9; }
                if (swordSpeed > 140) { swordSpeedIncrease = 8; }
                if (swordSpeed > 250) { swordSpeedIncrease = 1; }

                localizationScript.SwordText();
            }
        }
    }
    #endregion

    #region Tiny Spikes
    public GameObject spikes;

    public static bool chooseSpikes;
    public static float spikeDamagePerSecond;

    public static float smallSpikedDamageIncrease, smallSpikesCommonDamageIncrease;

    public void ChooseSpikes()
    {
        tinySpikeLEVEL += 1;
        tinySpikeFirst = true;
        if (chooseSpikes == true)
        {
            DecreaseNormalEnemySpawnTime(0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f);
        }
        else
        {
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(2, 1, 0, 0, 0, 0, 0, 0);

            eggTinySpiked.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.04f, 0.03f, 0.03f, 0.1f, 0.1f, 0.1f);
         
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[14];

            spikes.SetActive(true);
            chooseSpikes = true;
        }
       
        UnPauseGame();
    }

    public void SetSmallSpikesUpgrade(bool common)
    {
        if (chooseSpikes == false)
        {
            smallSpikesCommonDamageIncrease = 0; smallSpikedDamageIncrease = 0;


            spikeDamagePerSecond = 2.5f;

            localizationScript.TinySpikesText();
        }
        else
        {
            if (common == true)
            {
                if (spikeDamagePerSecond > 1f) { smallSpikesCommonDamageIncrease = 1; }
                if (spikeDamagePerSecond > 6) { smallSpikesCommonDamageIncrease = 1; }
                if (spikeDamagePerSecond > 12) { smallSpikesCommonDamageIncrease = 1; }

                localizationScript.TinySpikesText();
            }
            if (common == false)
            {
                if (spikeDamagePerSecond > 1f) { smallSpikedDamageIncrease = 2f; }
                if (spikeDamagePerSecond > 6) { smallSpikedDamageIncrease = 2f; }
                if (spikeDamagePerSecond > 12f) { smallSpikedDamageIncrease = 2f; }

                localizationScript.TinySpikesText();
            }
        }
    }
    #endregion

    #region smallStabbingSpikes
    public GameObject stabbingSpikes, stabbingSpike5, stabbingSpike6, stabbingSpike7, stabbingSpike8;

    public static bool chooseStabbingSpikes;
    public static float stabbingSpikeDamage;
    public static int stabbingSpikesClicksNeeded, stabbingSpikesClicks;

    public static int stabbySpikeDamageIncrease, stabbySpikeCommonDamageIncrease;

    public void AddSpike()
    {
        if(stabbingSpikes.activeInHierarchy == false) { stabbingSpikes.SetActive(true); }
        else if (stabbingSpike5.activeInHierarchy == false) { stabbingSpike5.SetActive(true); }
        else if (stabbingSpike6.activeInHierarchy == false) { stabbingSpike6.SetActive(true); }
        else if (stabbingSpike7.activeInHierarchy == false) { stabbingSpike7.SetActive(true); }
        else if (stabbingSpike8.activeInHierarchy == false) { stabbingSpike8.SetActive(true); }
    }

    public void ChoseStabbingSpikes()
    {
        stabbyspikeLEVEL += 1;
        stabbyspikeFirst = true;
        if (chooseStabbingSpikes == true)
        {
            DecreaseNormalEnemySpawnTime(0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f);
        }
        else
        {
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(2, 1, 0, 0, 0, 0, 0, 0);

            eggStabbySpikes.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.04f, 0.03f, 0.03f, 0.1f, 0.1f, 0.1f);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[11];

            stabbingSpikesClicks = 0;

            stabbingSpikesClicksNeeded = 7;
            chooseStabbingSpikes = true;
        }
        
        UnPauseGame();
    }

    public void SetStabbySpikedUpgrade(bool common)
    {
        if (chooseStabbingSpikes == false)
        {
            stabbySpikeCommonDamageIncrease = 0; stabbySpikeDamageIncrease = 0;

            stabbingSpikesClicksNeeded = 7;
            stabbingSpikeDamage = 14;
            localizationScript.StabbySpikesText();
        }
        else
        {
            if (common == true)
            {
                if (stabbingSpikeDamage > 10f) { stabbySpikeCommonDamageIncrease = 4; }
                if (stabbingSpikeDamage > 25) { stabbySpikeCommonDamageIncrease = 4; }
                if (stabbingSpikeDamage > 45) { stabbySpikeCommonDamageIncrease = 3; }

                localizationScript.StabbySpikesText();
            }
            if (common == false)
            {
                if (stabbingSpikeDamage > 10f) { stabbySpikeDamageIncrease = 6; }
                if (stabbingSpikeDamage > 25) { stabbySpikeDamageIncrease = 6; }
                if (stabbingSpikeDamage > 45f) { stabbySpikeDamageIncrease = 5; }

                localizationScript.StabbySpikesText();
            }
        }
    }
    #endregion

    #region Boxing glove
    public static bool choseBoxingGlove;
    public static float boxingGloveKnockbackAmount;
    public static int boxingGloveClicksNeeded, boxingGloveClicks;
    public GameObject boxingGlove;

    public static float boxingGloveForceIncrease, boxingGloveCommonForceIncrease;

    public void ChooseBoxingGlove()
    {
        boxingloveLEVEL += 1;
        boxinggloveFirst = true;
        if (choseBoxingGlove == true)
        {
            DecreaseNormalEnemySpawnTime(0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f);
        }
        else
        {
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(2, 1, 0, 0, 0, 0, 0, 0);

            eggBoxingGlove.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.04f, 0.03f, 0.03f, 0.1f, 0.1f, 0.1f);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[10];

            boxingGloveClicks = 0;
         
            //boxingGlove.SetActive(true);
            choseBoxingGlove = true;
        }

        UnPauseGame();
    }

    public void SetBoxingGloveUpgrade(bool common)
    {
        if (choseBoxingGlove == false)
        {
            boxingGloveCommonForceIncrease = 0; boxingGloveForceIncrease = 0;

            boxingGloveKnockbackAmount = 0.7f;
            boxingGloveClicksNeeded = 11;

            localizationScript.BoxingGloveText();
        }
        else
        {
            if (common == true)
            {
                if (boxingGloveKnockbackAmount > 0.5f) { boxingGloveCommonForceIncrease = 0.2f; }
                if (boxingGloveKnockbackAmount > 1) { boxingGloveCommonForceIncrease = 0.1f; }
                if (boxingGloveKnockbackAmount > 2) { boxingGloveCommonForceIncrease = 0.1f; }

                localizationScript.BoxingGloveText();
            }
            if (common == false)
            {
                if (boxingGloveKnockbackAmount > 0.5f) { boxingGloveForceIncrease = 0.3f; }
                if (boxingGloveKnockbackAmount > 1) { boxingGloveForceIncrease = 0.2f; }
                if (boxingGloveKnockbackAmount > 2) { boxingGloveForceIncrease = 0.1f; }

                localizationScript.BoxingGloveText();
            }
        }
    }
    #endregion

    #region Saw blade
    public static bool chooseSawBlade;
    public static float sawBladeSpeed, sawBladeDamage;
    public GameObject sawBlade, sawBlade2, sawBlade3, sawBlade4, sawBlade5, sawBlade6, sawBlade7, sawBlade8;

    public static float sawBladeDamageIncrease, sawBladeSpeedIncrease;
    public static float sawBladeCommonDamageIncrease, sawBladeCommonSpeedIncrease;

    public void AddSawBlade()
    {
        if(sawBlade.activeInHierarchy == false) { sawBlade.SetActive(true); }
        else if (sawBlade2.activeInHierarchy == false) { sawBlade2.SetActive(true); }
        else if (sawBlade3.activeInHierarchy == false) { sawBlade3.SetActive(true); }
        else if (sawBlade4.activeInHierarchy == false) { sawBlade4.SetActive(true); }
        else if (sawBlade5.activeInHierarchy == false) { sawBlade5.SetActive(true); }
        else if (sawBlade6.activeInHierarchy == false) { sawBlade6.SetActive(true); }
        else if (sawBlade7.activeInHierarchy == false) { sawBlade7.SetActive(true); }
        else if (sawBlade8.activeInHierarchy == false) { sawBlade8.SetActive(true); }
    }

    public void ChooseSawBlade()
    {
        sawBladeLEVEL += 1;
        sawBladeFirst = true;
        if (chooseSawBlade == true)
        {
            DecreaseNormalEnemySpawnTime(0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f, 0.04f);
        }
        else
        {
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(2, 2, 0, 0, 0, 0, 0, 0);

            eggSawBlade.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.15f, 0.15f, 0.06f, 0.05f, 0.06f, 0.2f, 0.4f, 0.5f);
           
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[15];

            chooseSawBlade = true;
        }

        UnPauseGame();
    }

    public void SetSawBladeUpgrade(bool common)
    {
        if (chooseSawBlade == false)
        {
            sawBladeCommonDamageIncrease = 0; sawBladeCommonSpeedIncrease = 0;
            sawBladeDamageIncrease = 0; sawBladeSpeedIncrease = 0;

            sawBladeDamage = 8f;
            sawBladeSpeed = 175f;

            localizationScript.SawBladeText();
        }
        else
        {
            if (common == true)
            {
                if (sawBladeDamage > 3f) { sawBladeCommonDamageIncrease = 3; }
                if (sawBladeDamage > 12) { sawBladeCommonDamageIncrease = 2; }
                if (sawBladeDamage > 20) { sawBladeCommonDamageIncrease = 2; }

                if (sawBladeSpeed > 150) { sawBladeCommonSpeedIncrease = 9; }
                if (sawBladeSpeed > 215) { sawBladeCommonSpeedIncrease = 8; }
                if (sawBladeSpeed > 240) { sawBladeCommonSpeedIncrease = 7; }

                localizationScript.SawBladeText();
            }
            if (common == false)
            {
                if (sawBladeDamage > 3f) { sawBladeDamageIncrease = 5f; }
                if (sawBladeDamage > 12) { sawBladeDamageIncrease = 3f; }
                if (sawBladeDamage > 20f) { sawBladeDamageIncrease = 3f; }

                if (sawBladeSpeed > 150) { sawBladeSpeedIncrease = 13; }
                if (sawBladeSpeed > 215) { sawBladeSpeedIncrease = 10; }
                if (sawBladeSpeed > 240) { sawBladeSpeedIncrease = 8; }

                localizationScript.SawBladeText();
            }
        }
    }
    #endregion

    #region Hammer
    public static bool chooseHammer;
    public static float  hammerDamage, hammerStunTime;
    public static int hammerClicks, hammerClicksNeeded;

    public static float hammerDamageIncrease, hammerStunTimeIncrease;
    public static float hammerCommonDamageIncrease, hammerCommonStunTimeIncrease;

    public void ChooseHammer()
    {
        hammerLEVEL += 1;
        hammerFirst = true;
        if (chooseHammer == true)
        {
            DecreaseNormalEnemySpawnTime(0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f, 0.06f);
        }
        else
        {
            hammerClicks = 0;
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(4, 3, 0, 0, 0, 0, 2, 1);

            eggHammer.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.18f, 0.15f, 0.1f, 0.1f, 0.1f, 0.15f, 0.4f, 0.5f);
          
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[12];

            chooseHammer = true;
        }
        UnPauseGame();
    }

    public void SetHammeRUpgrade(bool common)
    {
        if (chooseHammer == false)
        {
            hammerCommonDamageIncrease = 0; hammerCommonStunTimeIncrease = 0;
            hammerDamageIncrease = 0; hammerStunTimeIncrease = 0;

            hammerDamage = 50;
            hammerStunTime = 2;
            hammerClicksNeeded = 15;

            localizationScript.HammerText();
        }
        else
        {
            if (common == true)
            {
                if (hammerDamage > 40f) { hammerCommonDamageIncrease = 5; }
                 if (hammerDamage > 65) { hammerCommonDamageIncrease = 4; }
                 if (hammerDamage > 80) { hammerCommonDamageIncrease = 3; }

                if (hammerStunTime > 1) { hammerCommonStunTimeIncrease = 0.2f; }
                if (hammerStunTime > 3) { hammerCommonStunTimeIncrease = 0.2f; }
                if (hammerStunTime > 5) { hammerCommonStunTimeIncrease = 0.1f; }

                localizationScript.HammerText();
            }
            if (common == false)
            {
                if (hammerDamage > 40f) { hammerDamageIncrease = 15f; }
                if (hammerDamage > 65) { hammerDamageIncrease = 12f; }
                if (hammerDamage > 80) { hammerDamageIncrease = 9f; }

                if (hammerStunTime > 1) { hammerStunTimeIncrease = 0.4f; }
                if (hammerStunTime > 3) { hammerStunTimeIncrease = 0.3f; }
                if (hammerStunTime > 5) { hammerStunTimeIncrease = 0.1f; }

                localizationScript.HammerText();
            }
        }
    }
    #endregion

    #region Knife
    public static bool choseSpinningKnifes;
    public static float knifeDamage, knifeSpeed;
    public static int knifeClicks, knifeClicksNeeded, knifeTotalCount;

    public static float knifeDamageIncrease, knifeCommonDamageIncrease;
    public static int knifeCountIncrease, knifeCommonCountIncrease;

    public void ChooseKnifes()
    {
        knifeLEVEL += 1;
        knifeFirst = true;
        if (choseSpinningKnifes == true)
        {
            DecreaseNormalEnemySpawnTime(0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f);
        }
        else
        {
            numberOfMeleeCurrentRun += 1;
            IncreaseMaxEnemyspawn(3, 2, 0, 0, 0, 0, 1, 0);

            eggKnife.SetActive(true);
            DecreaseNormalEnemySpawnTime(0.1f, 0.1f, 0.04f, 0.03f, 0.03f, 0.1f, 0.1f, 0.1f);

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[26];

            choseSpinningKnifes = true;
           
            knifeSpeed = 120;
        }

        UnPauseGame();
    }

    public void SetKnifeUpgrade(bool common)
    {
        if (choseSpinningKnifes == false)
        {
            knifeCommonCountIncrease = 0; knifeCommonDamageIncrease = 0;
            knifeDamageIncrease = 0; knifeCountIncrease = 0;

            knifeClicks = 0;
            knifeClicksNeeded = 8;
            knifeTotalCount = 15;
            knifeDamage = 11;

            localizationScript.KnifeText();
        }
        else
        {
            if (common == true)
            {
                if (knifeDamage > 5f) { knifeCommonDamageIncrease = 2; }
                if (knifeDamage > 20) { knifeCommonDamageIncrease = 2; }
                if (knifeDamage > 35) { knifeCommonDamageIncrease = 1; }

                if (knifeTotalCount > 10) { knifeCommonCountIncrease = 1; }
                if (knifeTotalCount > 20) { knifeCommonCountIncrease = 1; }
                if (knifeTotalCount > 30) { knifeCommonCountIncrease = 0; }

                localizationScript.KnifeText();
            }
            if (common == false)
            {
                if (knifeDamage > 5f) { knifeDamageIncrease = 4f; }
                if (knifeDamage > 20) { knifeDamageIncrease = 4f; }
                if (knifeDamage > 35f) { knifeDamageIncrease = 3f; }

                if (knifeTotalCount > 10) { knifeCountIncrease = 3; }
                if (knifeTotalCount > 20) { knifeCountIncrease = 2; }
                if (knifeTotalCount > 30) { knifeCountIncrease = 0; }

                localizationScript.KnifeText();
            }
        }
    }
    #endregion

    public static bool movementAbilityAquaried;
    //Button movement. Bouncing and ETC..
    #region rocket
    public static bool chooseRocket;
    public GameObject rocket;
    public void ChooseRocket()
    {
        audioManager.Play("SelectAbilityLegendary");
        rocketFirst = true;
        IncreaseMaxEnemyspawn(4, 3, 1, 1, 1, 1, 1, 1);

        SetEnemyStats(30, false);
        ChoseLegendarySetChance();
        for (int i = 0; i < activeLegendaryAbilities.Length; i++)
        {
            if (activeLegendaryAbilities[i] != null && activeLegendaryAbilities[i].name == "Choise_Rocket_Legendary")
            {
                fourChoisesPos = i;
                break;
            }
        }
        //Debug.Log("Found at array position: " + fourChoisesPos);

        activeLegendaryAbilities[fourChoisesPos] = null;
        RemoveAbilityFromArray(4, fourChoisesPos);
        legendaryAbilitiesNotAvailable += 1;
        legendaryAbilitiesAviable -= 1;

        movementAbilityAquaried = true;
        rocket.SetActive(true);

        if (chooseRocket == false && choseButtonBounceCharge == false && chooseControllableButton == false)
        {
            SetFirstMovementActive();
        }

        if (choseButtonBounceCharge == true)
        {
            choseButtonBounceCharge = false;
            smallChargeButton.SetActive(false);
        }

        if (chooseControllableButton == true)
        {
            chooseControllableButton = false;
        }

        chooseRocket = true;
        UnPauseGame();
    }
    #endregion

    #region charge button bounce
    public GameObject smallChargeButton;

    public static bool choseButtonBounceCharge;

    public void ChooseButtonBounceCharge()
    {
        boosterFirst = true;
        IncreaseMaxEnemyspawn(3, 2, 1, 1, 1, 1, 1, 1);

        SetEnemyStats(29, false);
        ChoseRareSetChance();
        for (int i = 0; i < activeRareAbilities.Length; i++)
        {
            if (activeRareAbilities[i] != null && activeRareAbilities[i].name == "Choise_Booster_Rare")
            {
                fourChoisesPos = i;
                break;
            }
        }
        //Debug.Log("Found at array position: " + fourChoisesPos);

        activeRareAbilities[fourChoisesPos] = null;
        RemoveAbilityFromArray(3, fourChoisesPos);

        rareAbilitesNotAviable += 1;
        rareAbilitiesAviable -= 1;

        movementAbilityAquaried = true;
        if (chooseRocket == false && choseButtonBounceCharge == false && chooseControllableButton == false)
        {
            SetFirstMovementActive();
        }

        if (chooseRocket == true)
        {
            chooseRocket = false;
            rocket.SetActive(false);
        }

        if (chooseControllableButton == true)
        {
            chooseControllableButton = false;
        }

        choseButtonBounceCharge = true;
        smallChargeButton.SetActive(true);
        UnPauseGame();
    }
    #endregion

    #region cotnrollable button
    public static bool chooseControllableButton;
    public void ChooseControllableButton()
    {
        MainButtonCollider.buttonMoveSpeed = 19;
        audioManager.Play("SelectAbilityMythic");
        talariaFirst = true;
        if (chooseRocket == false && choseButtonBounceCharge == false && chooseControllableButton == false)
        {
            SetFirstMovementActive();
        }

        if (chooseRocket == true)
        {
            chooseRocket = false;
            rocket.SetActive(false);
        }

        if(choseButtonBounceCharge == true)
        {
            choseButtonBounceCharge = false;
            smallChargeButton.SetActive(false);
        }

        IncreaseMaxEnemyspawn(6, 5, 2, 1, 1, 2, 2, 1);

        SettingsOptions.totalMythicAbilitiesChosen += 1;
        SetEnemyStats(31, false);
        ChoseMythicSetChance();
        movementAbilityAquaried = true;

        chooseControllableButton = true;
        UnPauseGame();
    }
    #endregion

    #region Ritual
    public static bool choseRitual;
    public static int ritualClicks, ritualClicksNeeded;

    public static int ritualClicksIncrease, ritualCommonClicksIncrease;
    public static float ritualTimer, ritualTimerIncrease;

    public void ChooseRitual()
    {
        ritualLEVEL += 1;
        ritualFirst = true;
        if (choseRitual == true)
        {
      
        }
        else
        {
            IncreaseMaxEnemyspawn(4, 4, 2, 1, 1, 1, 1, 1);
            ritualClicks = 0;

            eggRitual.SetActive(true);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[20];

            choseRitual = true;
        }

        UnPauseGame();
    }

    public void SetRitualUpgrade(bool common)
    {
        if (choseRitual == false)
        {
            ritualCommonClicksIncrease = 0; ritualClicksIncrease = 0;

            ritualTimer = 5;
            ritualClicksNeeded = 165;

            localizationScript.RitualText();
        }
        else
        {
            if (common == true)
            {
                if (ritualClicksNeeded < 120) { ritualCommonClicksIncrease = 2; }
                if (ritualClicksNeeded < 140) { ritualCommonClicksIncrease = 3; }
                if (ritualClicksNeeded < 200) { ritualCommonClicksIncrease = 4; }
                if (ritualClicksNeeded <= 80) { ritualCommonClicksIncrease = 0; }

                if (ritualTimer > 4) { ritualTimerIncrease = 0.7f; }
                if (ritualTimer > 6) { ritualTimerIncrease = 0.7f; }
                if (ritualTimer > 8) { ritualTimerIncrease = 0.4f; }
                if (ritualTimer > 9) { ritualTimerIncrease = 0.3f; }
                if (ritualTimer > 10) { ritualTimerIncrease = 0.1f; }
                if (ritualTimer > 11) { ritualTimerIncrease = 0.05f; }
                if (ritualTimer > 12) { ritualTimerIncrease = 0.02f; }

                localizationScript.RitualText();
            }
            if (common == false)
            {
                if (ritualClicksNeeded < 120) { ritualClicksIncrease = 5; }
                if (ritualClicksNeeded < 140) { ritualClicksIncrease = 10; }
                if (ritualClicksNeeded < 200) { ritualClicksIncrease = 12; }
                if (ritualClicksNeeded <= 80) { ritualClicksIncrease = 0; }

                if (ritualTimer > 4) { ritualTimerIncrease = 2; }
                if (ritualTimer > 6) { ritualTimerIncrease = 1; }
                if (ritualTimer > 8) { ritualTimerIncrease = 0.5f; }
                if (ritualTimer > 9) { ritualTimerIncrease = 0.3f; }
                if (ritualTimer > 10) { ritualTimerIncrease = 0.2f; }
                if (ritualTimer > 11) { ritualTimerIncrease = 0.1f; }
                if (ritualTimer > 12) { ritualTimerIncrease = 0.05f; }

                localizationScript.RitualText();
            }
        }
    }
    #endregion

    //Enemies spawning, HP and DAMAGE
    public static int numberOfEnemiesActive;
    public static bool assassinFirstTime, speedsterFirstTime, sharpshooterFirstTime, sniperFirstTime, heavyshotFirstTime, ragingGunnerFirstTime, bruteFirstTime, titanFirstTime;

    #region Enemies Spawning
    public static bool smallEnemySpawn;
    public static float smallEnemyPoints;
    public static float smallEnemySpeed, smallEnemyDamage, smallEnemyHP;
    public static float smallEnemyDamagePerSecond;

    public void EnemiesStartSpawning()
    {
        if(assassinFirstTime == false)
        {
            assassinFirstTime = true;
        }
        smallEnemySpeed = 3.2f;
        UnPauseGame();
    }

    #endregion

    #region Sharpshooter spawn
    public static float sharpshooterHP;
    public static bool shootingEnemySpawn;
    public static float shootingEnemyPoints;
    public static float smallEnemyBulletDamage;
    public static float sharpshooterSpeed;

    public void ChooseSpawnSharpShooter()
    {
        if(sharpshooterFirstTime == false)
        {
            sharpshooterFirstTime = true;
        }

        if(firstShootingEnemyChose == false)
        {
            SetFirstShield();
        }
       

        if (shootingEnemySpawn == true)
        {

        }
        else
        {
            shootingEnemySpawn = true;
        }
        UnPauseGame();
    }

    #endregion

    #region bigEnemyspawm
    public static float bruteHP;
    public static bool bigEnemySpawn;
    public static float bigEnemyPoint;
    public static float bruteDamage;
    public static float bruteSpeed;

    public void ChooseSpawnBrute()
    {
        if(bruteFirstTime == false)
        {
            bruteFirstTime = true;
        }

        bigEnemySpawn = true;
        UnPauseGame();
    }
    #endregion

    #region speedster spawn
    public static float speedsterHP;
    public static bool speedsterSpawn;
    public static float speedsterSpeed;
    public static float speedsterPoints;
    public static float speedsterDamagePerSecond;

    public void ChooseSpawnSpeedster()
    {
        if(speedsterFirstTime == false)
        {
            speedsterFirstTime = true;
        }

        if(speedsterSpawn == true)
        {

        }
        else
        {
            speedsterSpeed = 7f;

            speedsterSpawn = true;
        }
        UnPauseGame();
    }
    #endregion

    #region sniper enemy spawn
    public static float sniperHP;
    public static bool sniperSpawn;
    public static float sniperPoints;
    public static float sniperSpeed;
    public static float sniperEnemyBulletDamage;

    public void ChooseSpawnSniper()
    {
        if(sniperFirstTime == false)
        {
            sniperFirstTime = true;
        }

        if (firstShootingEnemyChose == false)
        {
            SetFirstShield();
        }
        

        if(sniperSpawn == true)
        {
            
        }
        else
        {
            sniperSpawn = true;
        }
        UnPauseGame();
    }
    #endregion

    #region Titan Spawn
    public static float titanHP;
    public static bool titanSpawn;
    public static float titanPoints;
    public static float titanDamage;
    public static float titanSpeed;

    public void ChooseSpawnTitan()
    {
        if(titanFirstTime == false)
        {
            titanFirstTime = true;
        }

        if (titanSpawn == true)
        {

        }
        else
        {
            titanSpawn = true;
        }
        UnPauseGame();
    }
    #endregion

    #region Raging Gunner Spawn
    public static float ragingGunnerHP;
    public static bool ragingGunnerSpawn;
    public static float raginGunnerPoints;
    public static float raginGunnerBulletDamage, raginGunnerMeleeDamage;
    public static float ragingGunnerSpeed;

    public void ChooseSpawnRagingGunner()
    {
        if(ragingGunnerFirstTime == false)
        {
            ragingGunnerFirstTime = true;
        }

        if (firstShootingEnemyChose == false)
        {
            SetFirstShield();
        }


        if (ragingGunnerSpawn == true)
        {

        }
        else
        {
            ragingGunnerSpawn = true;
        }
        UnPauseGame();
    }
    #endregion

    #region HeavyShot Spawn
    public static float heavyshotHP;
    public static bool heavyShotSpawn;
    public static float heavyShotPoints;
    public static float heavyShotDamage;
    public static float heavyShotSpeed;

    public void ChooseSpawnHeavyShot()
    {
        if(heavyshotFirstTime == false)
        {
            heavyshotFirstTime = true;
        }

        if (firstShootingEnemyChose == false)
        {
            SetFirstShield();
        }

        if (heavyShotSpawn == true)
        {

        }
        else
        {
            heavyShotSpawn = true;
        }

        UnPauseGame();
    }
    #endregion

    //Button health, regen and shield
    #region more regen - COMMON
    public static float currentHealthIncrease, currentHealthRegenIncrease;

    public void ChooseMoreRegen()
    {
        defenseLEVEL += 1;
        defenseFirst = true;
        SetEnemyStats(23, false);
        ChoseCommonSetChance();
       
        if(buttonHealth > maxButtonHealth) { buttonHealth = maxButtonHealth; }
        UnPauseGame();
    }

    public void SetHealthUpgrade()
    {
        if (maxButtonHealth > 90)
        {
            currentHealthIncrease = 25;
        }
        if (maxButtonHealth > 150)
        {
            currentHealthIncrease = 25;
        }
        if (maxButtonHealth > 300)
        {
            currentHealthIncrease = 20;
        }
        if (maxButtonHealth > 400)
        {
            currentHealthIncrease = 15;
        }

        if (healthRegenPerSecond > 0.5f)
        {
            currentHealthRegenIncrease = 1.5f;
        }
        if (healthRegenPerSecond > 5)
        {
            currentHealthRegenIncrease = 1.5f;
        }
        if (healthRegenPerSecond > 10)
        {
            currentHealthRegenIncrease = 1.2f;
        }
        if (healthRegenPerSecond > 15)
        {
            currentHealthRegenIncrease = 1f;
        }
        if (healthRegenPerSecond > 25)
        {
            currentHealthRegenIncrease = 0.7f;
        }
        if (healthRegenPerSecond > 35)
        {
            currentHealthRegenIncrease = 0.5f;
        }

        localizationScript.DefenseText();

    }
    #endregion

    #region heartCollect
    public static bool chooseHeartCollect;
    public static bool setHeart;
    public static int bigHearClicks, bigHeartClicksNeeded;
    public static float bigHeartHPHeal;

    public static int currentBigHeartHealIncrease, currentBigHeartClicksIncrease;
    public static int bigHeartCommonHealIncrease, bigHeartCommonClicksIncrease;

    public void ChooseHeartCollect()
    {
        heartLEVEL += 1;
        heartFirst = true;
        if (chooseHeartCollect == true)
        {
       
        }
        else
        {
            IncreaseMaxEnemyspawn(2, 2, 1, 0, 0, 0, 1, 0);

            eggBigHeart.SetActive(true);
            bigHearClicks = 0;
           
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[25];

            chooseHeartCollect = true;
        }

        UnPauseGame();
    }
    public void SetHeartCollect(bool common)
    {
        if (chooseHeartCollect == false)
        {
            bigHeartCommonHealIncrease = 0; currentBigHeartHealIncrease = 0; currentBigHeartClicksIncrease = 0;

            bigHeartHPHeal = 10;
            bigHeartClicksNeeded = 55;

            localizationScript.BigHeartText();
        }
        else
        {
            if (common == true)
            {
                if (bigHeartHPHeal > 5f) { bigHeartCommonHealIncrease = 3; }
                if (bigHeartHPHeal > 20) { bigHeartCommonHealIncrease = 3; }
                if (bigHeartHPHeal > 30) { bigHeartCommonHealIncrease = 2; }

                localizationScript.BigHeartText();
            }
            if (common == false)
            {
                if (bigHeartHPHeal > 5f) { currentBigHeartHealIncrease = 5; }
                if (bigHeartHPHeal > 20) { currentBigHeartHealIncrease = 4; }
                if (bigHeartHPHeal > 30) { currentBigHeartHealIncrease = 3; }

                if (bigHeartClicksNeeded < 70) { currentBigHeartClicksIncrease = 4; }
                if (bigHeartClicksNeeded < 25) { currentBigHeartClicksIncrease = 0; }

                localizationScript.BigHeartText();
            }
        }
    }
    #endregion

    #region bounce of SHIELD
    public GameObject shield_BounceOff, bouncyShield2, bouncyShield3, bouncyShield4;
    public static int shieldBounceHPIncrease, shieldBounceCommonHPIncrease;
    public static float shieldBounceRechargeDecrease, shieldBounceCommonRechargeDecrease;

    public static bool choseShield_BounceOff;
    public static float shieldBounce_health;
    public static float shieldBounce_RotateSpeed;
    public static float reChargeTimer;

    public void AddBouncyShield()
    {
        if(shield_BounceOff.activeInHierarchy == false) { shield_BounceOff.SetActive(true); }
        else if (bouncyShield2.activeInHierarchy == false) { bouncyShield2.SetActive(true); }
        else if(bouncyShield3.activeInHierarchy == false) { bouncyShield3.SetActive(true); }
        else if(bouncyShield4.activeInHierarchy == false) { bouncyShield4.SetActive(true); }
    }

    public void ChooseShieldBounce()
    {
        bouncyShieldLEVEL += 1;
        bouncyShieldFirst = true;
        ChoseRareSetChance();
        if (choseShield_BounceOff == true)
        {
            DecreaseNormalEnemySpawnTime(0f, 0f, 0.04f, 0.04f, 0.04f, 0.04f, 0f, 0f);
        }
        else
        {
            IncreaseMaxEnemyspawn(0, 0, 2, 1, 1, 1, 0, 0);

            eggBouncyShield.SetActive(true);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[17];

            shieldBounce_RotateSpeed = 50;
        }
        UnPauseGame();
        choseShield_BounceOff = true;
    }
    public void SetShieldBounceUpgrade(bool common)
    {
        if (choseShield_BounceOff == false)
        {
            shieldBounceCommonHPIncrease = 0; shieldBounceCommonRechargeDecrease = 0;
            shieldBounceHPIncrease = 0; shieldBounceRechargeDecrease = 0;

            shieldBounce_health = 7;
            reChargeTimer = 15;

            localizationScript.BouncyShieldText();
        }
        else
        {
            if (common == true)
            {
                if (shieldBounce_health > 5f) { shieldBounceCommonHPIncrease = 1; }
                if (shieldBounce_health > 15) { shieldBounceCommonHPIncrease = 1; }
                if (shieldBounce_health > 25) { shieldBounceCommonHPIncrease = 1; }

                if (reChargeTimer < 20) { shieldBounceCommonRechargeDecrease = 0.25f; }
                if (reChargeTimer < 7) { shieldBounceCommonRechargeDecrease = 0.2f; }
                if (reChargeTimer < 5) { shieldBounceCommonRechargeDecrease = 0.1f; }
                if (reChargeTimer < 4) { shieldBounceCommonRechargeDecrease = 0f; }

                localizationScript.BouncyShieldText();
            }
            if (common == false)
            {
                if (shieldBounce_health > 5) { shieldBounceHPIncrease = 2; }
                if (shieldBounce_health > 15) { shieldBounceHPIncrease = 1; }
                if (shieldBounce_health > 25) { shieldBounceHPIncrease = 1; }

                if (reChargeTimer < 20) { shieldBounceRechargeDecrease = 0.4f; }
                if (reChargeTimer < 7) { shieldBounceRechargeDecrease = 0.35f; }
                if (reChargeTimer < 5) { shieldBounceRechargeDecrease = 0.1f; }
                if (reChargeTimer < 4) { shieldBounceRechargeDecrease = 0f; }
                //Min 2

                localizationScript.BouncyShieldText();
            }
        }
    }
    #endregion

    #region Small shield
    public GameObject smallShields, smallShield3, smallShield4, smallShield5, smallShield6, smallShield7, smallShield8;
    public static int smallShieldHPIncrease, smallShieldCommonHPIncrease;
    public static float smallShiledRechargeDecrease, smallShiledCommonRechargeDecrease;

    public static bool choseSmallShields;
    public static float smallShieldHP;
    public static float smallShieldRotateSpeed;
    public static float smallShieldRechargeTimer;

    public void AddSmallShield()
    {
        if(smallShields.activeInHierarchy == false) { smallShields.SetActive(true); }
        else if (smallShield3.activeInHierarchy == false) { smallShield3.SetActive(true);  }
        else if (smallShield4.activeInHierarchy == false) { smallShield4.SetActive(true);  }
        else if (smallShield5.activeInHierarchy == false) { smallShield5.SetActive(true);  }
        else if (smallShield6.activeInHierarchy == false) { smallShield6.SetActive(true);  }
        else if (smallShield7.activeInHierarchy == false) { smallShield7.SetActive(true);  }
        else if (smallShield8.activeInHierarchy == false) { smallShield8.SetActive(true);  }
    }

    public void ChooseSmallShield()
    {
        smallShieldLEVEL += 1;
        smallShieldFirst = true;
        if (choseSmallShields == true)
        {
            DecreaseNormalEnemySpawnTime(0f, 0f, 0.04f, 0.04f, 0.04f, 0.04f, 0f, 0f);
        }
        else
        {
            IncreaseMaxEnemyspawn(0, 0, 2, 1, 1, 1, 0, 0);

            eggSmallShield.SetActive(true);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[23];
        }
        choseSmallShields = true;
        UnPauseGame();
    }

    public void SetSmallShieldUpgrade(bool common)
    {
        if (choseSmallShields == false)
        {
            smallShieldCommonHPIncrease = 0; smallShiledCommonRechargeDecrease = 0;
            smallShieldHPIncrease = 0; smallShiledRechargeDecrease = 0;

            smallShieldHP = 5;
            smallShieldRechargeTimer = 11;

            localizationScript.SmallShieldsText();
        }
        else
        {
            if (common == true)
            {
                if (smallShieldHP > 3f) { smallShieldCommonHPIncrease = 1; }
                if (smallShieldHP > 12) { smallShieldCommonHPIncrease = 1; }
                if (smallShieldHP > 18) { smallShieldCommonHPIncrease = 1; }

                if (smallShieldRechargeTimer < 14) { smallShiledCommonRechargeDecrease = 0.15f; }
                if (smallShieldRechargeTimer < 6f) { smallShiledCommonRechargeDecrease = 0.13f; }
                if (smallShieldRechargeTimer < 4f) { smallShiledCommonRechargeDecrease = 0.1f; }
                if (smallShieldRechargeTimer < 2f) { smallShiledCommonRechargeDecrease = 0f; }
                localizationScript.SmallShieldsText();
            }
            if (common == false)
            {
                if (smallShieldHP > 3) { smallShieldHPIncrease = 2; }
                if (smallShieldHP > 12) { smallShieldHPIncrease = 1; }
                if (smallShieldHP > 18) { smallShieldHPIncrease = 1; }

                if (smallShieldRechargeTimer < 14) { smallShiledRechargeDecrease = 0.3f; }
                if (smallShieldRechargeTimer < 6f) { smallShiledRechargeDecrease = 0.25f; }
                if (smallShieldRechargeTimer < 4f) { smallShiledRechargeDecrease = 0.15f; }
                if (smallShieldRechargeTimer < 2f) { smallShiledRechargeDecrease = 0f; }
                //Min 2

                localizationScript.SmallShieldsText();
            }
        }
    }
    #endregion

    //OTHER
    #region Unlimited Power
    public static bool choseUnlimitedPower;
    public GameObject weirdEggScreen, weirdEggChooseScreen;
    public TextMeshProUGUI chooseEggText;
    public static string chosenEggText;
    public GameObject noMoreUpgradesButton;
    public static bool isInEggScreen;

    public GameObject eggPointPerClick, eggIdleClicks, eggCritClicks, eggDefense, eggBigHeart, eggSmallShield, eggBouncyShield, eggPisto, eggUZI, eggShotgun, eggAWP, eggDeagle, eggCannon, eggMP4, eggCrossbow, eggArena, eggBoxingGlove, eggStabbySpikes, eggTinySpiked, eggKnife, eggSword, eggRitual, eggSawBlade, eggHammer, eggArrow, eggChargedBullet, eggPointDrop, eggStopTime, eggInvincibility, eggSkullHarvest, eggDice;

    public static bool eggPointPerClickChosen, eggCritclickChosen, eggIdleClickChosen, eggDefenseChosen, eggBigHeartChosen, eggSmallShieldChosen, eggBouncyShieldChosen, eggPistolChosen, eggUziChosen, eggShotgunChosen, eggAWPChosen, eggCrossbowChosen, eggDeagleChosen, eggCannonChosen, eggMP4Chosen, eggArenaChosen, eggBoxingGloveChosen, eggStabbySpikeChosen, eggTinySpikeChosen, eggKnifeChosen, eggSwordChosen, eggRitualChosen, eggSawBladeChose, eggHammerChosen, eggArrowChosen, eggChagedBulletsChosen, eggPointDropChosen, eggStopwatchChosen, eggInvinChosen, eggSkullHarvestChosen, eggDiceChose;

    public int totalEggUpgrades;
    public void ChoseUnlimitedPower()
    {
        isInEggScreen = true;
        audioManager.Play("SelectAbilityMythic");
        eggFirst = true;
        ChoseMythicSetChance();
        IncreaseMaxEnemyspawn(4, 4, 2, 1, 1, 1, 1, 1);

        SettingsOptions.totalMythicAbilitiesChosen += 1;
        SetEnemyStats(20, false);
        SetAlpha(weirdEggScreen.GetComponent<Image>(), 0f);
        StartCoroutine(TransitionEggScreen());

        totalEggUpgrades = 0;
        totalEggUpgrades += 3;

         eggPointPerClick.SetActive(true);
         eggIdleClicks.SetActive(true);
         eggCritClicks.SetActive(true); 

        if (choseHealthBar == true) { totalEggUpgrades += 1; eggDefense.SetActive(true); }
        if (chooseHeartCollect == true) { totalEggUpgrades += 1; eggBigHeart.SetActive(true); }
        if (choseSmallShields == true) { totalEggUpgrades += 1; eggSmallShield.SetActive(true); }
        if (choseShield_BounceOff == true) { totalEggUpgrades += 1; eggBouncyShield.SetActive(true); }
        if (chose_Gun1 == true) { totalEggUpgrades += 1; eggPisto.SetActive(true); }
        if (choseShootSmallBullets == true) { totalEggUpgrades += 1; eggUZI.SetActive(true); }
        if (chose_gun2 == true) { totalEggUpgrades += 1; eggShotgun.SetActive(true); }
        if (chooseHomingBullets == true) { totalEggUpgrades += 1; eggAWP.SetActive(true); }
        if (choseCrossBow == true) { totalEggUpgrades += 1; eggCrossbow.SetActive(true); }
        if (choseTrippleShot == true) { totalEggUpgrades += 1; eggDeagle.SetActive(true); }
        if (chooseBigPiercingBulletGun == true) { totalEggUpgrades += 1; eggCannon.SetActive(true); }
        if (choseGunMp4 == true) { totalEggUpgrades += 1; eggMP4.SetActive(true); }
        if (choseBouncingBullets == true) { totalEggUpgrades += 1; eggArena.SetActive(true); }
        if (choseBoxingGlove == true) { totalEggUpgrades += 1; eggBoxingGlove.SetActive(true); }
        if (chooseStabbingSpikes == true) { totalEggUpgrades += 1; eggStabbySpikes.SetActive(true); }
        if (chooseSpikes == true) { totalEggUpgrades += 1; eggTinySpiked.SetActive(true);  }
        if (choseSpinningKnifes == true) { totalEggUpgrades += 1; eggKnife.SetActive(true); }
        if (chooseBigSpike == true) { totalEggUpgrades += 1; eggSword.SetActive(true); }
        if (choseRitual == true) { totalEggUpgrades += 1; eggRitual.SetActive(true); }
        if (chooseSawBlade == true) { totalEggUpgrades += 1; eggSawBlade.SetActive(true); }
        if (chooseHammer == true) { totalEggUpgrades += 1; eggHammer.SetActive(true); }
        if (choseArrows == true) { totalEggUpgrades += 1; eggArrow.SetActive(true); }
        if (choseButtonCharge == true) { totalEggUpgrades += 1; eggChargedBullet.SetActive(true); }
        if (chosePointsDrop == true) { totalEggUpgrades += 1; eggPointDrop.SetActive(true); }
        if (choseStopTime == true) { totalEggUpgrades += 1; eggStopTime.SetActive(true); }
        if (choseInvincibility == true) { totalEggUpgrades += 1; eggInvincibility.SetActive(true); }
        if (choseSkullHarvest == true) { totalEggUpgrades += 1; eggSkullHarvest.SetActive(true); }
        if (choseReroll == true) { totalEggUpgrades += 1; eggDice.SetActive(true); }


        if (eggPointPerClickChosen) { eggPointPerClick.SetActive(false); totalEggUpgrades -= 1; }
        if (eggIdleClickChosen) { eggIdleClicks.SetActive(false); totalEggUpgrades -= 1; }
        if (eggCritclickChosen) { eggCritClicks.SetActive(false); totalEggUpgrades -= 1; }
        if (eggDefenseChosen) { eggDefense.SetActive(false); totalEggUpgrades -= 1; }
        if (eggBigHeartChosen) { eggBigHeart.SetActive(false); totalEggUpgrades -= 1; }
        if (eggSmallShieldChosen) { eggSmallShield.SetActive(false); totalEggUpgrades -= 1; }
        if (eggBouncyShieldChosen) { eggBouncyShield.SetActive(false); totalEggUpgrades -= 1; }
        if (eggPistolChosen) { eggPisto.SetActive(false); totalEggUpgrades -= 1; }
        if (eggUziChosen) { eggUZI.SetActive(false); totalEggUpgrades -= 1; }
        if (eggShotgunChosen) { eggShotgun.SetActive(false); totalEggUpgrades -= 1; }
        if (eggAWPChosen) { eggAWP.SetActive(false); totalEggUpgrades -= 1; }
        if (eggCrossbowChosen) { eggCrossbow.SetActive(false); totalEggUpgrades -= 1; }
        if (eggDeagleChosen) { eggDeagle.SetActive(false); totalEggUpgrades -= 1; }
        if (eggCannonChosen) { eggCannon.SetActive(false); totalEggUpgrades -= 1; }
        if (eggMP4Chosen) { eggMP4.SetActive(false); totalEggUpgrades -= 1; }
        if (eggArenaChosen) { eggArena.SetActive(false); totalEggUpgrades -= 1; }
        if (eggBoxingGloveChosen) { eggBoxingGlove.SetActive(false); totalEggUpgrades -= 1; }
        if (eggStabbySpikeChosen) { eggStabbySpikes.SetActive(false); totalEggUpgrades -= 1; }
        if (eggTinySpikeChosen) { eggTinySpiked.SetActive(false); totalEggUpgrades -= 1; }
        if (eggKnifeChosen) { eggKnife.SetActive(false); totalEggUpgrades -= 1; }
        if (eggSwordChosen) { eggSword.SetActive(false); totalEggUpgrades -= 1; }
        if (eggRitualChosen) { eggRitual.SetActive(false); totalEggUpgrades -= 1; }
        if (eggSawBladeChose) { eggSawBlade.SetActive(false); totalEggUpgrades -= 1; }
        if (eggHammerChosen) { eggHammer.SetActive(false); totalEggUpgrades -= 1; }
        if (eggArrowChosen) { eggArrow.SetActive(false); totalEggUpgrades -= 1; }
        if (eggChagedBulletsChosen) { eggChargedBullet.SetActive(false); totalEggUpgrades -= 1; }
        if (eggPointDropChosen) { eggPointDrop.SetActive(false); totalEggUpgrades -= 1; }
        if (eggStopwatchChosen) { eggStopTime.SetActive(false); totalEggUpgrades -= 1; }
        if (eggInvinChosen) { eggInvincibility.SetActive(false); totalEggUpgrades -= 1; }
        if (eggSkullHarvestChosen) { eggSkullHarvest.SetActive(false); totalEggUpgrades -= 1; }
        if (eggDiceChose) { eggDice.SetActive(false); totalEggUpgrades -= 1; }

        if(totalEggUpgrades < 1) { noMoreUpgradesButton.SetActive(true); }
        else { noMoreUpgradesButton.SetActive(false); }
    }

    IEnumerator TransitionEggScreen()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        weirdEggScreen.SetActive(true);
        Cursor.visible = true;
        SetAlpha(weirdEggScreen.GetComponent<Image>(), 1f);
    }

    public void ChooseEggAbility()
    {
        audioManager.Play("UI_Click2");
        choseUnlimitedPower = true;
        SetAlpha(weirdEggChooseScreen.GetComponent<Image>(), 0f);
        if(chosenEggText == "More Points") { eggPointPerClickChosen = true; }
        if (chosenEggText == "Idle Button Clicks") { eggIdleClickChosen = true; }
        if (chosenEggText == "Crit Clicks") { eggCritclickChosen = true; }
        if (chosenEggText == "Defense") { eggDefenseChosen = true; }
        if (chosenEggText == "Big Heart") { eggBigHeartChosen = true; }
        if (chosenEggText == "Small Shield") { eggSmallShieldChosen = true; }
        if (chosenEggText == "Bouncy Shield") { eggBouncyShieldChosen = true; }
        if (chosenEggText == "Pistol") { eggPistolChosen = true; }
        if (chosenEggText == "Broken Uzi") { eggUziChosen = true; }
        if (chosenEggText == "Shotgun") { eggShotgunChosen = true; }
        if (chosenEggText == "AWP") { eggAWPChosen = true; }
        if (chosenEggText == "Crossbow") { eggCrossbowChosen = true; }
        if (chosenEggText == "Tripple Deagle") { eggDeagleChosen = true; }
        if (chosenEggText == "Cannon") { eggCannonChosen = true; }
        if (chosenEggText == "MP4") { eggMP4Chosen = true; }
        if (chosenEggText == "Arena") { eggArenaChosen = true; }
        if (chosenEggText == "Boxing Glove") { eggBoxingGloveChosen = true; }
        if (chosenEggText == "Stabby Spikes") { eggStabbySpikeChosen = true; }
        if (chosenEggText == "Tiny Spikes") { eggTinySpikeChosen = true; }
        if (chosenEggText == "Spinning Knifes") { eggKnifeChosen = true; }
        if (chosenEggText == "Sword") { eggSwordChosen = true; }
        if (chosenEggText == "Button Ritual") { eggRitualChosen = true; }
        if (chosenEggText == "Saw Blade") { eggSawBladeChose = true; }
        if (chosenEggText == "Hammer") { eggHammerChosen = true; }
        if (chosenEggText == "Arrow Storm") { eggArrowChosen = true; }
        if (chosenEggText == "Charged Bullets") { eggChagedBulletsChosen = true; }
        if (chosenEggText == "Point Drop") { eggPointDropChosen = true; }
        if (chosenEggText == "Stopwatch") { eggStopwatchChosen = true; }
        if (chosenEggText == "Invincibility") { eggInvinChosen = true; }
        if (chosenEggText == "Skull Harvest") { eggSkullHarvestChosen = true; }
        if (chosenEggText == "Dice Roll") { eggDiceChose = true; }
        UnPauseGame();
        if(firstControlledGun == true)
        { 
            if(MobileScript.isMobile == false) { Cursor.visible = false; }
        }
        else
        {
            Cursor.visible = true;
        }

        isInEggScreen = false;
    }

    public void CloseEggScreen()
    {
        isInEggScreen = false;

        audioManager.Play("UI_Click2");
        weirdEggScreen.SetActive(false);
    }

    public void ChooseDifferentEggAbility()
    {
        audioManager.Play("UI_Click2");
        SetAlpha(weirdEggChooseScreen.GetComponent<Image>(), 0f);
        StartCoroutine(SetEggScreenInactive(false));
    }

    IEnumerator SetEggScreenInactive(bool trueOrFalse)
    {
        yield return new WaitForSecondsRealtime(0.1f);
        if(trueOrFalse == false) { weirdEggChooseScreen.SetActive(false); }
        if (trueOrFalse == true) { weirdEggChooseScreen.SetActive(true); }
    }

    public void EggText(string text)
    {
        audioManager.Play("UI_Click2");
        weirdEggChooseScreen.SetActive(true);
        SetAlpha(weirdEggChooseScreen.GetComponent<Image>(), 1f);
        chooseEggText.text = $"Choose the \"{text}\" ability to be upgraded every time you level up?";
        chosenEggText = text;
        StartCoroutine(SetEggPickButtons());
    }

    public GameObject eggYesButton, eggChooseDifferentButton;
    IEnumerator SetEggPickButtons()
    {
        eggYesButton.GetComponent<Button>().interactable = false;
        eggChooseDifferentButton.GetComponent<Button>().interactable = false;
        yield return new WaitForSecondsRealtime(0.4f);
        eggYesButton.GetComponent<Button>().interactable = true;
        eggChooseDifferentButton.GetComponent<Button>().interactable = true;
    }

    #endregion

    #region Stopwatch
    public static bool choseStopTime;
    public static float stopTimeTimer;
    public static int stopTimeClicks, stopTimeClickTotal;

    public static float stopTimeTimeIncrease, stopTimeCommonTimeIncrease;
    public static int stopTimeClicksDecrease, stopTimeCommonClicksDecrease;

    public void ChooseSlowDownTime()
    {
        stopwatchLEVEL += 1;
        audioManager.Play("SelectAbilityMythic");
        stopwatchFirst = true;

        if (choseStopTime == true)
        {
          
        }
        else
        {
            IncreaseMaxEnemyspawn(6, 5, 3, 3, 3, 2, 2, 2);

            eggStopTime.SetActive(true);
            DecreaseEnemySpawnTime(0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.2f, 0.2f);
          
            choseStopTime = true;

            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[21];
            stopTimeClicks = 0;
            
            choisePupUp.SetActive(false);
        }
        UnPauseGame();
    }

    public void SetStopWatchUpgrade(bool common)
    {
        if (choseStopTime == false)
        {
            stopTimeCommonTimeIncrease = 0; stopTimeCommonClicksDecrease = 0;
            stopTimeTimeIncrease = 0; stopTimeClicksDecrease = 0;

            stopTimeTimer = 3.5f;
            stopTimeClickTotal = 160;

            localizationScript.StopwatchText();
        }
        else
        {
            if (common == true)
            {
                if (stopTimeTimer > 2f) { stopTimeCommonTimeIncrease = 0.15f; }
                if (stopTimeTimer > 4.5f) { stopTimeCommonTimeIncrease = 0.12f; }
                if (stopTimeTimer > 5.5f) { stopTimeCommonTimeIncrease = 0.1f; }
                if (stopTimeTimer > 6f) { stopTimeCommonTimeIncrease = 0.07f; }
                if (stopTimeTimer > 7f) { stopTimeCommonTimeIncrease = 0.03f; }
                if (stopTimeTimer > 8f) { stopTimeCommonTimeIncrease = 0.005f; }

                if (stopTimeClickTotal < 250) { stopTimeCommonClicksDecrease = 4; }
                if (stopTimeClickTotal < 150f) { stopTimeCommonClicksDecrease = 3; }
                if (stopTimeClickTotal < 115f) { stopTimeCommonClicksDecrease = 2; }
                if (stopTimeClickTotal < 90f) { stopTimeCommonClicksDecrease = 0; }
                localizationScript.StopwatchText();
            }
            if (common == false)
            {
                if (stopTimeTimer > 2) { stopTimeTimeIncrease = 0.4f; }
                if (stopTimeTimer > 4.5f) { stopTimeTimeIncrease = 0.3f; }
                if (stopTimeTimer > 5.5f) { stopTimeTimeIncrease = 0.15f; }
                if (stopTimeTimer > 6f) { stopTimeTimeIncrease = 0.1f; }
                if (stopTimeTimer > 7f) { stopTimeTimeIncrease = 0.05f; }
                if (stopTimeTimer > 8f) { stopTimeTimeIncrease = 0.01f; }
                //max 10s

                if (stopTimeClickTotal < 250) { stopTimeClicksDecrease = 8; }
                if (stopTimeClickTotal < 150) { stopTimeClicksDecrease = 7; }
                if (stopTimeClickTotal < 115) { stopTimeClicksDecrease =  5; }
                if (stopTimeClickTotal < 90) { stopTimeClicksDecrease = 0; }
                //Min 80 clicks

                localizationScript.StopwatchText();
            }
        }
      
    }
    #endregion

    #region Invincibility
    public static bool choseInvincibility;
    public static float invincibilityTimer,invincibilityTimeAdded;
    public static int invincibilityClickPer1Second, incincibilityClicks;

    public static int invincibilityClicksDecrease, invincibilityCommonClicksDecrease;
    public static float invincibilityTimeAddedIncrease, invincibilityCommonTimeAddedIncrease;

    public void ChooseInvincibility()
    {
        invinLEVEL += 1;
        invinFirst = true;
        if (choseInvincibility == true)
        {
         
        }
        else
        {
            incincibilityClicks = 0;
            IncreaseMaxEnemyspawn(3, 2, 2, 1, 1, 1, 1, 1);

            eggInvincibility.SetActive(true);
            DecreaseEnemySpawnTime(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.2f);
           
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[16];

            choseInvincibility = true;

            invincibilityTimer = 0;
        }

        UnPauseGame();
    }
    public void SetInvincibilityUpgrade(bool common)
    {
        if (choseInvincibility == false)
        {
            invincibilityCommonTimeAddedIncrease = 0; invincibilityCommonClicksDecrease = 0;
            invincibilityTimeAddedIncrease = 0; invincibilityClicksDecrease = 0;

            invincibilityClickPer1Second = 135;
            invincibilityTimeAdded = 1;

            localizationScript.InvincibilityText();
        }
        else
        {
            if (common == true)
            {
                if (invincibilityTimeAdded > 0.5f) { invincibilityCommonTimeAddedIncrease = 0.1f; }
                if (invincibilityTimeAdded > 1.7f) { invincibilityCommonTimeAddedIncrease = 0.1f; }
                if (invincibilityTimeAdded > 2.4f) { invincibilityCommonTimeAddedIncrease = 0.1f; }

                if (invincibilityClickPer1Second < 150) { invincibilityCommonClicksDecrease = 2; }
                if (invincibilityClickPer1Second < 75) { invincibilityCommonClicksDecrease = 1; }
                if (invincibilityClickPer1Second <= 50) { invincibilityCommonClicksDecrease = 0; }

                localizationScript.InvincibilityText();
            }
            if (common == false)
            {
                if (invincibilityTimeAdded > 0.5f) { invincibilityTimeAddedIncrease = 0.2f; }
                if (invincibilityTimeAdded > 1.7f) { invincibilityTimeAddedIncrease = 0.1f; }
                if (invincibilityTimeAdded > 2.4f) { invincibilityTimeAddedIncrease = 0.1f; }

                if (invincibilityClickPer1Second < 150) { invincibilityClicksDecrease = 6; }
                if (invincibilityClickPer1Second < 75) { invincibilityClicksDecrease = 5; }
                if (invincibilityClickPer1Second <= 50) { invincibilityClicksDecrease = 0; }

                localizationScript.InvincibilityText();
            }
        }
    }
    #endregion

    #region Skull Harvest
    public static bool choseSkullHarvest;
    public static int skullHarvestStatDivide;

    public static float SHpointPerClick, SHcritChance, SHcritIncrease, SHidleClicks;
    public static float SHuziSpeed, SHuziDamage, SHpistolSpeed, SHPistolDamage, SHshotgunSpeed, SHshotgunDamage, SHawpSpeed, SHawpDamage, SHcrossbowSpeed, SHcrossbowDamage, SHdeagleSpeed, SHdeagleDamage, SHcannonSpeed, SHcannonDamage, SHmp4Speed, SHmp4Damage, SHchargeBulletDamage, SHchargeBulletTime, SHarrowDamage;
    public static float SHmaxHealth, SHregen, SHbigHEarHP, SHsmallShieldHP, SHsmallShieldRecharge, SHbounceHP, SHbouncyRecharge;
    public static float SHboxingForce, SHstabbyDamage, SHtinySpikeDamage, SHknifeDamage, SHsawBladeDamage, SHsawbladeSpeed, SHswordSpeed, SHswordDamage, SHhammerDamage, SHhammerStunTime;
    public static float SHinvinTime, SHstopwatchTime;
    public static float SHpointDropBasic, SHpointDropRarity;

    public static int skullsConsumedCount;

    public static bool skullHarvestChosenFirstTime;
    public GameObject skullHarvestStatLocked;

    public void ChooseSkullHarvest()
    {
        skullHarvestLEVEL += 1;
        skullHarvestFirst = true;
        if (choseSkullHarvest == true)
        {
           
        }
        else
        {
            audioManager.Play("SelectAbilityMythic");
            IncreaseMaxEnemyspawn(8, 8, 3, 3, 3, 3, 3, 2);

            eggSkullHarvest.SetActive(true);
            skullHarvestStatDivide = 415;
            DecreaseEnemySpawnTime(0.2f, 0.2f, 0.3f, 0.4f, 0.5f, 0.3f, 1f, 1.2f);
           
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[22];

            choseSkullHarvest = true;
        }

        skullHarvestStatLocked.SetActive(false);
        skullHarvestChosenFirstTime = true;
        UnPauseGame();
    }

    public void SetSkullHarvestUpgrade()
    {
        localizationScript.SkullHarvestText();
    }
    #endregion

    #region Point drop
    public static bool chosePointsDrop;
    public static float randomUncommonPointsDrop, randomRarePointDrop, randomLegendaryPointDrop, randomMythicPointDrop;

    public static float commonBasicPointIncrease, uncommonBasicPointIncrease;
    public static float commonPointRarityIncrease, uncommonPointRarityIncrease;

    public static float pointDropBasicPoints, pointDropRarityIncreasePoints;
    public void ChoosePointsDrop()
    {
        pointDropLEVEL += 1;
        pointDropFirst = true;
        if (chosePointsDrop == true)
        {
           
        }
        else
        {
            eggPointDrop.SetActive(true);
            commonAbilitesNotAviable -= 1;
            commonAbilitiesAviable += 1;
            activeCommonAbilities[commonAbilitiesAviable] = allCommonAbilitites[24];
        }

        chosePointsDrop = true;

        UnPauseGame();
    }

    public void SetPointDropUpgrade(bool common)
    {
        if (chosePointsDrop == false)
        {
            pointDropBasicPoints = 2f;
            pointDropRarityIncreasePoints = 1f;

            randomUncommonPointsDrop = 80;
            randomRarePointDrop = 10;
            randomLegendaryPointDrop = 7;
            randomMythicPointDrop = 3;

            localizationScript.PointDropText();
        }
        else
        {
            if (common == true)
            {
                if(pointDropBasicPoints > 1) { commonBasicPointIncrease = 0.2f; }
                if (pointDropBasicPoints > 3f) { commonBasicPointIncrease = 0.1f; }
                if (pointDropBasicPoints > 4f) { commonBasicPointIncrease = 0.08f; }
                if (pointDropBasicPoints > 5f) { commonBasicPointIncrease = 0.05f; }
                if (pointDropBasicPoints > 7f) { commonBasicPointIncrease = 0.01f; }
                if (pointDropBasicPoints > 10f) { commonBasicPointIncrease = 0f; }

                if (pointDropRarityIncreasePoints > 0.6f) { commonPointRarityIncrease = 0.2f; }
                if (pointDropRarityIncreasePoints > 1.5f) { commonPointRarityIncrease = 0.1f; }
                if (pointDropRarityIncreasePoints > 3f) { commonPointRarityIncrease = 0.05f; }
                if (pointDropRarityIncreasePoints > 5f) { commonPointRarityIncrease = 0.01f; }
                if (pointDropRarityIncreasePoints > 10f) { commonPointRarityIncrease = 0f; }

                localizationScript.PointDropText();
            }
            if (common == false)
            {
                if (pointDropBasicPoints > 1) { uncommonBasicPointIncrease = 0.3f; }
                if (pointDropBasicPoints > 3f) { uncommonBasicPointIncrease = 0.2f; }
                if (pointDropBasicPoints > 4f) { uncommonBasicPointIncrease = 0.15f; }
                if (pointDropBasicPoints > 5f) { uncommonBasicPointIncrease = 0.1f; }
                if (pointDropBasicPoints > 7f) { uncommonBasicPointIncrease = 0.01f; }
                if (pointDropBasicPoints > 10f) { uncommonBasicPointIncrease = 0f; }

                if (pointDropRarityIncreasePoints > 0.6f) { uncommonPointRarityIncrease = 0.4f; }
                if (pointDropRarityIncreasePoints > 1.5f) { uncommonPointRarityIncrease = 0.4f; }
                if (pointDropRarityIncreasePoints > 3f) { uncommonPointRarityIncrease = 0.4f; }
                if (pointDropRarityIncreasePoints > 5f) { uncommonPointRarityIncrease = 0.01f; }
                if (pointDropRarityIncreasePoints > 10f) { uncommonPointRarityIncrease = 0f; }

                localizationScript.PointDropText();
            }
        }
    }
    #endregion

    public Button random2, random3, random5;

    #region 2X Abilites
    public void Choose2X()
    {
        random2.interactable = false;
        StartCoroutine(RandomSounds(2));
        random2First = true;
        SetEnemyStats(35, false);
        RandomAbilitites(2);
        ChoseUncommonSetChance();
        StartCoroutine(FadeOutOtherAbilittes(random2ArrayPos));
        blockAbilititesObject.SetActive(true);
    }
    #endregion

    #region 3X Abilites
    public void Choose3X()
    {
        random3.interactable = false;
        StartCoroutine(RandomSounds(3));
        random3First = true;
        SetEnemyStats(36, false);
        RandomAbilitites(3);
        ChoseRareSetChance();
        StartCoroutine(FadeOutOtherAbilittes(random3ArrayPos));
        blockAbilititesObject.SetActive(true);
    }
    #endregion

    #region 5X Abilites
    public void Choose5X()
    {
        random5.interactable = false;
        StartCoroutine(RandomSounds(5));
        random5First = true;
        SetEnemyStats(37, false);
        RandomAbilitites(5);
        ChoseLegendarySetChance();
        StartCoroutine(FadeOutOtherAbilittes(random5ArrayPos));
        blockAbilititesObject.SetActive(true);
    }
    #endregion

    #region RandomSounds
    IEnumerator RandomSounds(int randomCount)
    {
        if(randomCount == 2)
        {
            audioManager.Play("Random1");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random2");
        }

        if (randomCount == 3)
        {
            audioManager.Play("Random1");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random2");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random3");
        }

        if (randomCount == 5)
        {
            audioManager.Play("Random1");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random2");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random3");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random4");
            yield return new WaitForSecondsRealtime(0.25f);
            audioManager.Play("Random5");
        }

        yield return new WaitForSecondsRealtime(0.4f);

        if(blockAbilititesObject.activeInHierarchy == true)
        {
            blockAbilititesObject.SetActive(false);
        }
    }

    #endregion


    #region Random Abilities
    public float waitTime;
    public void RandomAbilitites(int count)
    {
        #region Adding Aviable Buffs
        int abilititesAviable;
        abilititesAviable = 0;
        //Basic | First 3
        abilititesAviable += 3;

        //Defense
        if (Choises.choseHealthBar == true) { abilititesAviable += 1; }
        if (Choises.chooseHeartCollect == true) { abilititesAviable += 1; }
        if (Choises.choseSmallShields == true) { abilititesAviable += 1; }
        if (Choises.choseShield_BounceOff == true) { abilititesAviable += 1; }

        //Ranged
        if (Choises.choseShootSmallBullets == true) { abilititesAviable += 1; }
        if (Choises.chose_Gun1 == true) { abilititesAviable += 1; }
        if (Choises.chose_gun2 == true) { abilititesAviable += 1; }
        if (Choises.chooseHomingBullets == true) { abilititesAviable += 1; }
        if (Choises.choseCrossBow == true) { abilititesAviable += 1; }
        if (Choises.choseTrippleShot == true) { abilititesAviable += 1; }
        if (Choises.chooseBigPiercingBulletGun == true) { abilititesAviable += 1; }
        if (Choises.choseGunMp4 == true) { abilititesAviable += 1; }
        if (Choises.choseButtonCharge == true) { abilititesAviable += 1; }
        if (Choises.choseArrows == true) { abilititesAviable += 1; }

        //Melee
        if (Choises.choseBoxingGlove == true) { abilititesAviable += 1; }
        if (Choises.chooseStabbingSpikes == true) { abilititesAviable += 1; }
        if (Choises.chooseSpikes == true) { abilititesAviable += 1; }
        if (Choises.choseSpinningKnifes == true) { abilititesAviable += 1; }
        if (Choises.chooseSawBlade == true) { abilititesAviable += 1; }
        if (Choises.chooseBigSpike == true) { abilititesAviable += 1; }
        if (Choises.chooseHammer == true) { abilititesAviable += 1; }

        //Other
        if (Choises.chosePointsDrop == true) { abilititesAviable += 1; }
        if (Choises.choseInvincibility == true) { abilititesAviable += 1; }
        if (Choises.choseSkullHarvest == true) { abilititesAviable += 1; }
        #endregion

        waitTime = 0.25f;
        randomWaitTime = 0;

        if (count == 5 && abilititesAviable == 3) 
        {
            Pick5XWithOnly3();
        }
        else
        {
            randomAbilitiesPicked = 0;
            storeRandom1 = -1; storeRandom2 = -1; storeRandom3 = -1; storeRandom4 = -1; storeRandom5 = -1;

            if (count == 1) { PickRandomAbility(abilititesAviable, true); }
            if (count == 2) { PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); }
            if (count == 3) { PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); }
            if (count == 5) { PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); PickRandomAbility(abilititesAviable, false); }
        }
    }

    public void Pick5XWithOnly3()
    {
        SetMorePointsText(); ButtonClick.pointsPerClick += currentPointIncrease;
        StartCoroutine(RandomPopUPAnim("pointIcon", false)); randomWaitTime += waitTime;
        pointsLEVEL += 2;

        SetMorePointsText(); ButtonClick.pointsPerClick += currentPointIncrease;
        StartCoroutine(RandomPopUPAnim("pointIcon", false)); randomWaitTime += waitTime;

        SetCritUpgrade();
        if (choseCritClicks == false) { critClicksChance = originalCritChance; critClicksChance = originalCritIncrease; choseCritClicks = true; }
        else { critClicksChance += currentClickCritPercentIncrease; critClicksBonus += currectClickCritIncrease; }
        StartCoroutine(RandomPopUPAnim("cloverIcon", false)); randomWaitTime += waitTime;

        SetCritUpgrade();
        if (choseCritClicks == false) { critClicksChance = originalCritChance; critClicksChance = originalCritIncrease; choseCritClicks = true; }
        else { critClicksChance += currentClickCritPercentIncrease; critClicksBonus += currectClickCritIncrease; }
        StartCoroutine(RandomPopUPAnim("cloverIcon", false)); randomWaitTime += waitTime;
        critLEVEL += 2;

        SetIdleUpgrade();
        if (choseIdleClicking == false) { timeBetweenClicks = 2; choseIdleClicking = true; ButtonClick.autoClick = true; totalIdlePoints += currentIdlePointIncrease; }
        else { timeBetweenClicks -= currentIdleClickIncrease; totalIdlePoints += currentIdlePointIncrease; }
        StartCoroutine(RandomPopUPAnim("idleIcon", false)); randomWaitTime += waitTime;
        idleLEVEL += 1;
    }

    public int randomAbilitiesPicked;
    public int storeRandom1, storeRandom2, storeRandom3, storeRandom4, storeRandom5;

    public void PickRandomAbility(int abilitiesAviable, bool ritual)
    {
        int count;
        count = abilitiesAviable;

        int random = Random.Range(0, abilitiesAviable);

        while (random == storeRandom1 || random == storeRandom2 || random == storeRandom3 || random == storeRandom4 || random == storeRandom5)
        {
            random = Random.Range(0, abilitiesAviable);
        }

        randomAbilitiesPicked += 1; 
        if(randomAbilitiesPicked == 1) { storeRandom1 = random; }
        if (randomAbilitiesPicked == 2) { storeRandom2 = random; }
        if (randomAbilitiesPicked == 3) { storeRandom3 = random; }
        if (randomAbilitiesPicked == 4) { storeRandom4 = random; }
        if (randomAbilitiesPicked == 5) { storeRandom5 = random; }

        #region 3 Basic
        count -= 1;
        if (random == count) 
        {
            pointsLEVEL += 1;
            SetMorePointsText(); ButtonClick.pointsPerClick += currentPointIncrease;
            if (ritual == true) { StartCoroutine(RandomPopUPAnim("pointIcon", true)); }
            if (ritual == false) { StartCoroutine(RandomPopUPAnim("pointIcon", false)); randomWaitTime += waitTime; }
        }
        count -= 1;
        if (random == count)
        {
            critLEVEL += 1;
            SetCritUpgrade();
            if(choseCritClicks == false) { critClicksChance = originalCritChance; critClicksChance = originalCritIncrease; choseCritClicks = true; }
            else { critClicksChance += currentClickCritPercentIncrease; critClicksBonus += currectClickCritIncrease; }
            if (ritual == true) { StartCoroutine(RandomPopUPAnim("cloverIcon",true)); }
            if (ritual == false) { StartCoroutine(RandomPopUPAnim("cloverIcon", false)); randomWaitTime += waitTime; }
        }
        count -= 1;
        if (random == count)
        {
            idleLEVEL += 1;
            SetIdleUpgrade();
            if(choseIdleClicking == false) { timeBetweenClicks = 2; choseIdleClicking = true; ButtonClick.autoClick = true; totalIdlePoints += currentIdlePointIncrease; }
            else { timeBetweenClicks -= currentIdleClickIncrease; totalIdlePoints += currentIdlePointIncrease; }
            if (ritual == true) { StartCoroutine(RandomPopUPAnim("idleIcon", true));  }
            if (ritual == false) { StartCoroutine(RandomPopUPAnim("idleIcon", false)); randomWaitTime += waitTime; }
        }
        #endregion

        #region Defense
        if (Choises.choseHealthBar == true)
        {
            count -= 1;
            if (random == count)
            {
                defenseLEVEL += 1;
                SetHealthUpgrade(); maxButtonHealth += currentHealthIncrease; buttonHealth += currentHealthIncrease; healthRegenPerSecond += currentHealthRegenIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("heartIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("heartIcon", false)); randomWaitTime += waitTime; }
            }
        }
       
        if (Choises.chooseHeartCollect == true)
        {
            count -= 1;
            if (random == count)
            {
                heartLEVEL += 1;
                SetHeartCollect(true); bigHeartHPHeal += bigHeartCommonHealIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("bigHeartIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("bigHeartIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseSmallShields == true)
        {
            count -= 1;
            if (random == count)
            {
                smallShieldLEVEL += 1;
                SetSmallShieldUpgrade(true); smallShieldHP += smallShieldCommonHPIncrease; smallShieldRechargeTimer -= smallShiledCommonRechargeDecrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("smallShieldIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("smallShieldIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseShield_BounceOff == true)
        {
            count -= 1;
            if (random == count)
            {
                bouncyShieldLEVEL += 1;
                SetShieldBounceUpgrade(true); shieldBounce_health += shieldBounceCommonHPIncrease; reChargeTimer -= shieldBounceCommonRechargeDecrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("bouncyShieldIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("bouncyShieldIcon", false)); randomWaitTime += waitTime; }
            }
        }
        #endregion

        #region Ranged
        //Ranged
        if (Choises.choseShootSmallBullets == true)
        {
            count -= 1;
            if (random == count)
            {
                uziLEVEL += 1;
                SetUziUpgrade(true); smallBulletDamage += uziCommonDamageIncrease; smallBulletSpeed += uziCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("uziIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("uziIcon", false)); randomWaitTime += waitTime; }
            }
        }
        
        if (Choises.chose_Gun1 == true)
        {
            count -= 1;
            if (random == count)
            {
                pistolLEVEL += 1;
                SetPistolUpgrade(true); bulletGun1_Damage += pistolCommonDamageIncrease; bulletGun1_Speed += pistolCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("pistolIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("pistolIcon", false)); randomWaitTime += waitTime; }
            }
        }

        if (Choises.chose_gun2 == true)
        {
            count -= 1;
            if (random == count)
            {
                shotgunLEVEL += 1;
                SetShotgunUpgrade(true);
                shotGunBulletDamage += shotgunCommonDamageIncrease; shotGunBulletDamage2 += shotgunCommonDamageIncrease;
                shotGunBulletSpeed1 += shotgunCommonSpeedIncrease; shotGunBulletSpeed2 += shotgunCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("shotgunIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("shotgunIcon", false)); randomWaitTime += waitTime; }
            }
        }

        if (Choises.chooseHomingBullets == true)
        {
            count -= 1;
            if (random == count)
            {
                awpLEVEL += 1;
                SetAWPUpgrade(true);
                homingBulletDamage += awpCommonDamageIncrease; homignBulletSpeed += awpCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("awpIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("awpIcon", false)); randomWaitTime += waitTime; }
            }
        }

        if (Choises.choseCrossBow == true)
        {
            count -= 1;
            if (random == count)
            {
                crossbowLEVEL += 1;
                SetCrossbowUpgrade(true); crossbowDamage += crossbowDamageIncrease; crossbowSpeed += crossbowSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("crossbowIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("crossbowIcon", false)); randomWaitTime += waitTime; }
            }
        }

        if (Choises.choseTrippleShot == true)
        {
            count -= 1;
            if (random == count)
            {
                deagleLEVEL += 1;
                SetTrippleShotUpgrade(true); trippleShotDamage += deagleCommonDamageIncrease; trippleShotSpeed += deagleCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("deagleIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("deagleIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.chooseBigPiercingBulletGun == true) 
        {
            count -= 1;
            if (random == count)
            {
                cannonLEVEL += 1;
                SetCannonUpgrade(true);
                bigBulletDamage += cannonCommonDamageIncrease; bigBulletSpeed += cannonCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("cannonIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("cannonIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseGunMp4 == true) 
        {
            count -= 1;
            if (random == count)
            {
                mp4LEVEL += 1;
                SetMP4Upgrade(true);
                mp4Damage += mp4CommonDamageIncrease; mp4Speed += mp4CommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("mp4Icon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("mp4Icon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseButtonCharge == true)
        {
            count -= 1;
            if (random == count)
            {
                chargedBulletLEVEL += 1;
                SetChargedBulletUpgrade(true);
                chargedBulletMaxDamage += chargedBulletcommonMaxDamageIncrease; chargedBulletChargeTime -= chargedBulletcommonChargeTimeIncrease;
            
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("chargedBulletIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("chargedBulletIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseArrows == true)
        {
            count -= 1;
            if (random == count)
            {
                arrosLEVEL += 1;
                SetArrowUpgrade(true);
                arrowDamage += arrowCommonDamageIncrease; arrowCountShot += arrowCommonCountIncrease;
             
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("arrowIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("arrowIcon", false)); randomWaitTime += waitTime; }
            }
        }
        #endregion

        #region Melee
        if (Choises.choseBoxingGlove == true)
        {
            count -= 1;
            if (random == count)
            {
                boxingloveLEVEL += 1;
                SetBoxingGloveUpgrade(true); boxingGloveKnockbackAmount += boxingGloveCommonForceIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("boxingGloveIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("boxingGloveIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.chooseStabbingSpikes == true) 
        {
            count -= 1;
            if (random == count)
            {
                stabbyspikeLEVEL += 1;
                SetStabbySpikedUpgrade(true); stabbingSpikeDamage += stabbySpikeCommonDamageIncrease;
        
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("stabbySpikeIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("stabbySpikeIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.chooseSpikes == true)
        {
            count -= 1;
            if (random == count)
            {
                tinySpikeLEVEL += 1;
                SetSmallSpikesUpgrade(true); spikeDamagePerSecond += smallSpikesCommonDamageIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("tinySpikeIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("tinySpikeIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseSpinningKnifes == true) 
        {
            count -= 1;
            if (random == count)
            {
                knifeLEVEL += 1;
                SetKnifeUpgrade(true); knifeDamage += knifeCommonDamageIncrease; knifeTotalCount += knifeCommonCountIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("knifeIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("knifeIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.chooseSawBlade == true) 
        {
            count -= 1;
            if (random == count)
            {
                sawBladeLEVEL += 1;
                SetSawBladeUpgrade(true); sawBladeDamage += sawBladeCommonDamageIncrease; sawBladeSpeed += sawBladeCommonSpeedIncrease;
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("sawBladeIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("sawBladeIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.chooseBigSpike == true) 
        {
            count -= 1;
            if (random == count)
            {
                swordLEVEL += 1;
                SetSwordUpgrade(true); bigSpikeDamage += swordCommonDamageIcrease; swordSpeed += swordCommonSpeedIncrease;
            
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("swordIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("swordIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.chooseHammer == true)
        {
            count -= 1;
            if (random == count)
            {
                hammerLEVEL += 1;
                SetHammeRUpgrade(true); hammerDamage += hammerCommonDamageIncrease; hammerStunTime += hammerCommonStunTimeIncrease;
          
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("hammerIcon", true));  }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("hammerIcon", false)); randomWaitTime += waitTime; }
            }
        }
        #endregion

        #region Other
        //Other
        if (Choises.chosePointsDrop == true) 
        {
            count -= 1;
            if (random == count)
            {
                pointDropLEVEL += 1;
                SetPointDropUpgrade(true);
                Choises.pointDropBasicPoints += Choises.commonBasicPointIncrease;
                Choises.pointDropRarityIncreasePoints += Choises.commonPointRarityIncrease;

                if (ritual == true) { StartCoroutine(RandomPopUPAnim("pointDropIcon", true));}
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("pointDropIcon", false)); randomWaitTime += waitTime; }
            }
           
        }
        if (Choises.choseInvincibility == true)
        {
            count -= 1;
            if (random == count)
            {
                invinLEVEL += 1;
                SetInvincibilityUpgrade(true); invincibilityTimer += invincibilityCommonTimeAddedIncrease; invincibilityClickPer1Second -= invincibilityCommonClicksDecrease;
             
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("invinIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("invinIcon", false)); randomWaitTime += waitTime; }
            }
        }
        if (Choises.choseSkullHarvest == true)
        {
            count -= 1;
            if (random == count)
            {
                skullHarvestLEVEL += 1;
                if (Choises.skullHarvestStatDivide > Choises.minumumSkullHarvest)
                {
                    Choises.skullHarvestStatDivide -= 3;
                }
                if (ritual == true) { StartCoroutine(RandomPopUPAnim("skullHarvestIcon", true)); }
                if (ritual == false) { StartCoroutine(RandomPopUPAnim("skullHarvestIcon", false)); randomWaitTime += waitTime; }
            }
        }
        #endregion
    }

    public float randomWaitTime;
    public Transform ritualRandomParent, randomParenT;
    public GameObject ritualObject;

    IEnumerator RandomPopUPAnim(string randomName, bool ritual)
    {
        yield return new WaitForSecondsRealtime(randomWaitTime);
        GameObject randomPopUP = ObjectPool.instance.GetRandomFromPool();
        if(ritual == true) { randomPopUP.transform.SetParent(ritualRandomParent); }
        if (ritual == false) { randomPopUP.transform.SetParent(randomParenT); }

        Image image = randomPopUP.GetComponent<Image>();
        Color imageAlpha = image.color; imageAlpha.a = 0f;
        image.color = imageAlpha;

        if(ritual == true) { randomPopUP.transform.localPosition = ritualObject.transform.localPosition; }
        if(ritual == false)
        {
            if (HoverUpgrades.abilityPos.x < 0) { randomPopUP.transform.localPosition = new Vector2(HoverUpgrades.abilityPos.x + 350, -100); }
            if (HoverUpgrades.abilityPos.x == 0) { randomPopUP.transform.localPosition = new Vector2(HoverUpgrades.abilityPos.x + 350, -100); }
            if (HoverUpgrades.abilityPos.x > 0) { randomPopUP.transform.localPosition = new Vector2(HoverUpgrades.abilityPos.x - 350, -100); }
        }

        SetAlpha(image, 1f);

        foreach (Transform child in randomPopUP.transform)
        {
            if (child.name != "ArrowPoint" && child.name != randomName && child.name != "frame")
            {
                child.gameObject.SetActive(false);
            }
            if(child.name == randomName) { child.gameObject.SetActive(true); }
        }

        if(ritual == true) { randomPopUP.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f); }
        if(ritual == false) { randomPopUP.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f); }
      

        float moveSpeed = 535f;
        float movespeedRitual = 33;
        float animationDuration = 2f; 

        float timer = 0.0f;
        while (timer < animationDuration)
        {
            if(ritual == false) { randomPopUP.transform.Translate(Vector3.up * moveSpeed * Time.unscaledDeltaTime); }
            if (ritual == true) { randomPopUP.transform.Translate(Vector3.up * movespeedRitual * Time.unscaledDeltaTime); }

            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        SetAlpha(image, 0f);
        //Debug.Log("End Of Anim");
        ObjectPool.instance.ReturnRandomFromPool(randomPopUP);
    }
    #endregion


    #region Set Chosen Abilites Inactive
    public void SetRerollsInactive()
    {
        //Debug.Log("Rerolls Inactive");
        abilitesToReroll[0].SetActive(false);
        abilitesToReroll[1].SetActive(false);
        abilitesToReroll[2].SetActive(false);
        if (numberOfChoises > 3) { abilitesToReroll[3].SetActive(false); }
        if (numberOfChoises > 4) { abilitesToReroll[4].SetActive(false); }
    }

    public void SetChosenAbilititesInactive()
    {
        if (allAbiliitesSpawnedIn == true) 
        {
            //Debug.Log(allAbiliitesSpawnedIn);
            chooseAbilityAnim.GetComponent<Animator>().SetTrigger("Out");
            if(abilitesToReroll[0] != null) { abilitesToReroll[0].SetActive(false); }
            if (abilitesToReroll[1] != null) { abilitesToReroll[1].SetActive(false); }
            if (abilitesToReroll[2] != null) { abilitesToReroll[2].SetActive(false); }
            if (numberOfChoises > 3) { if (abilitesToReroll[3] != null) { abilitesToReroll[3].SetActive(false); } }
            if (numberOfChoises > 4) { if (abilitesToReroll[4] != null) { abilitesToReroll[4].SetActive(false); } }
            allAbiliitesSpawnedIn = false;

            allAbiliitesSpawnedIn = false;
            choseAbility = true;
            choisePupUp.SetActive(false);
            choisePopUp2.SetActive(false);
            isPaused = false;
        }
    }

    IEnumerator FadeOutOtherAbilittes(int randomArrayPos)
    {
        if (allAbiliitesSpawnedIn == true)
        {
            //Debug.Log(allAbiliitesSpawnedIn);
            chooseAbilityAnim.GetComponent<Animator>().SetTrigger("Out");

            Image image1 = abilitesToReroll[0].GetComponent<Image>();
            Image image2 = abilitesToReroll[1].GetComponent<Image>();
            Image image3 = abilitesToReroll[2].GetComponent<Image>();

            if (randomArrayPos != 0) { SetAlpha(image1, 0f); }
            if (randomArrayPos != 1) { SetAlpha(image2, 0f); }
            if (randomArrayPos != 2) { SetAlpha(image3, 0f); }
            if (numberOfChoises > 3)
            {
                if (randomArrayPos != 3) { SetAlpha(abilitesToReroll[3].GetComponent<Image>(), 0f); }
            }
            if (numberOfChoises > 4)
            {
                if (randomArrayPos != 4) { SetAlpha(abilitesToReroll[4].GetComponent<Image>(), 0f); }
            }
            StartCoroutine(StartTimeScale());

            yield return new WaitForSecondsRealtime(randomWaitTime);
            SetAlpha(abilitesToReroll[randomArrayPos].GetComponent<Image>(), 0f);

            yield return new WaitForSecondsRealtime(0.1f);
            if (abilitesToReroll[0] != null) { abilitesToReroll[0].SetActive(false); }
            if (abilitesToReroll[1] != null) { abilitesToReroll[1].SetActive(false); }
            if (abilitesToReroll[2] != null) { abilitesToReroll[2].SetActive(false); }
            if (numberOfChoises > 3) { if (abilitesToReroll[3] != null) { abilitesToReroll[3].SetActive(false); } }
            if (numberOfChoises > 4) { if (abilitesToReroll[4] != null) { abilitesToReroll[4].SetActive(false); } }

            allAbiliitesSpawnedIn = false;
            choseAbility = true;
            choisePupUp.SetActive(false);
            choisePopUp2.SetActive(false);
            isPaused = false;

           
            rerollButton.SetActive(false);
            choseAnimPlaying = false;

            if(SettingsOptions.isInSettings == false && ButtonClick.isStopTimeAbilityActive == false) { Time.timeScale = 1;  }
            isInLevelUpScreen = false;

            SetCursors.hoveringClickableStuff = false;

            if (firstControlledGun == false)
            {
                Cursor.visible = true;
            }
            else 
            {
                if (MobileScript.isMobile == false) { Cursor.visible = false; }
            }
        }
    }
    #endregion

    public static float smallEnemySpawnTimer, speedsterSpawnTimer, sharpshooterSpawnTimer, sniperSpawnTimer, heavyShotSpawnTiner, ragingGunnerSpawnTimer, titanSpawnTimer, bigEnemySpawnTimer;

    public static float spawnMoreSmallEnemiesTimer, spawnMoreSpeedsterTimer, spawnMoreSharpshooterTimer, spawnMoreSniperTimer, spawnMoreRagingGunnerTimer, spawnMoreHeavyShotTimer, spawnMoreBruteTimer, spawnMoreTitanTimer;
    public void SetEnemyStats(int abilityNumber, bool common)
    {
        //1 = Uzi. 2 = Pistol. 3 = Shotgun. 4 = AWP. 5 = Crossbow. 6 = Deagle. 7 = Cannon. 8 = MP4.
        //9 = Charged Bullets. 10 = Arrows.
        #region Uzi
        if (abilityNumber == 1)
        { 
            if(common == true)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.15f, 0.07f, 0.2f, 0.2f, 0.3f, 0.5f);
                IncreaseEnemyHP(0.3f, 0.2f, 0.3f, 0.2f, 0.6f, 0.7f, 2f, 3f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.08f, 0.07f, 0.05f, 0.1f, 0.25f);
            }
            if(common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.3f, 0.2f, 0.15f, 0.3f, 0.3f, 0.65f, 0.8f);
                IncreaseEnemyHP(1.5f, 1f, 1.5f, 2.5f, 3f, 3f, 5f, 7f);
                IncreaseEnemyDamage(0.1f, 0.14f, 0.1f, 0.14f, 0.25f, 0.35f, 0.2f, 0.5f, 0.6f);
            }
        }
        #endregion

        #region Pistol
        if (abilityNumber == 2)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.15f, 0.07f, 0.2f, 0.2f, 0.3f, 0.5f);
                IncreaseEnemyHP(0.3f, 0.2f, 0.3f, 0.2f, 0.6f, 0.7f, 2f, 3f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.08f, 0.07f, 0.05f, 0.1f, 0.25f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.3f, 0.2f, 0.15f, 0.3f, 0.3f, 0.65f, 0.8f);
                IncreaseEnemyHP(1.5f, 1f, 1.5f, 2.5f, 3f, 3f, 5f, 7f);
                IncreaseEnemyDamage(0.1f, 0.14f, 0.1f, 0.14f, 0.25f, 0.35f, 0.2f, 0.5f, 0.6f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Shotgun
        if (abilityNumber == 3)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.2f, 0.15f, 0.2f, 0.15f, 0.2f, 0.15f, 0.4f, 0.5f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2f, 3f, 4f, 5f);
                IncreaseEnemyDamage(0.06f, 0.08f, 0.06f, 0.08f, 0.07f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.6f, 0.4f, 0.6f, 0.4f, 0.6f, 1.1f, 2f, 2.6f);
                IncreaseEnemyHP(2f, 1f, 2f, 2f, 3f, 3f, 7f, 8f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.15f, 0.2f, 0.3f, 0.4f, 0.2f, 0.4f, 0.7f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region AWP
        if (abilityNumber == 4)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.2f, 0.15f, 0.2f, 0.15f, 0.2f, 0.15f, 0.4f, 0.5f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2f, 3f, 4f, 5f);
                IncreaseEnemyDamage(0.06f, 0.08f, 0.06f, 0.08f, 0.07f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.3f, 0.2f, 0.1f, 0.2f, 0.2f, 0.2f, 0.2f);
                IncreaseEnemyHP(2f, 1f, 2f, 3f, 4f, 4f, 7f, 8f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.15f, 0.2f, 0.3f, 0.4f, 0.2f, 0.4f, 0.7f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Crossbow
        if (abilityNumber == 5)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.2f, 0.15f, 0.2f, 0.15f, 0.2f, 0.15f, 0.4f, 0.5f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2f, 3f, 4f, 5f);
                IncreaseEnemyDamage(0.06f, 0.08f, 0.06f, 0.08f, 0.07f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.3f, 0.2f, 0.1f, 0.2f, 0.2f, 0.2f, 0.2f);
                IncreaseEnemyHP(2f, 1f, 2f, 3f, 4f, 4f, 7f, 8f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.15f, 0.2f, 0.3f, 0.4f, 0.2f, 0.4f, 0.7f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Deagle
        if (abilityNumber == 6)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.2f, 0.15f, 0.2f, 0.15f, 0.2f, 0.15f, 0.4f, 0.5f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2f, 3f, 4f, 5f);
                IncreaseEnemyDamage(0.06f, 0.08f, 0.06f, 0.08f, 0.07f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.3f, 0.2f, 0.1f, 0.2f, 0.2f, 0.2f, 0.2f);
                IncreaseEnemyHP(2f, 1f, 2f, 3f, 4f, 4f, 7f, 8f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.15f, 0.2f, 0.3f, 0.4f, 0.2f, 0.4f, 0.7f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Cannon
        if (abilityNumber == 7)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.3f, 0.25f, 0.3f, 0.25f, 0.3f, 0.25f, 0.6f, 0.9f);
                IncreaseEnemyHP(2f, 1f, 2f, 1f, 2f, 3f, 6f, 7f);
                IncreaseEnemyDamage(0.07f, 0.08f, 0.07f, 0.1f, 0.15f, 0.2f, 0.1f, 0.5f, 0.7f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(1f, 1f, 1f, 1.5f, 2f, 3f, 5f, 6f);
                IncreaseEnemyHP(4f, 2f, 5f, 3f, 5f, 5f, 20f, 40f);
                IncreaseEnemyDamage(0.2f, 0.3f, 0.2f, 0.3f, 0.35f, 0.25f, 0.1f, 0.7f, 1f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region MP4
        if (abilityNumber == 8)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.3f, 0.25f, 0.3f, 0.25f, 0.3f, 0.25f, 0.6f, 0.9f);
                IncreaseEnemyHP(2f, 1f, 2f, 1f, 2f, 3f, 6f, 7f);
                IncreaseEnemyDamage(0.07f, 0.08f, 0.07f, 0.1f, 0.15f, 0.15f, 0.1f, 0.5f, 0.7f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(1f, 1f, 1f, 1.5f, 2f, 2.5f, 5f, 6f);
                IncreaseEnemyHP(4f, 2f, 5f, 3f, 5f, 5f, 20f, 40f);
                IncreaseEnemyDamage(0.2f, 0.3f, 0.2f, 0.3f, 0.35f, 0.25f, 0.15f, 0.7f, 1.1f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Charged Bullets
        if (abilityNumber == 9)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.2f, 0.15f, 0.2f, 0.15f, 0.2f, 0.15f, 0.4f, 0.5f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2f, 3f, 4f, 5f);
                IncreaseEnemyDamage(0.06f, 0.08f, 0.06f, 0.08f, 0.07f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.55f, 0.55f, 0.55f, 0.85f, 0.90f, 1.8f, 2.2f, 3.2f);
                IncreaseEnemyHP(3f, 2f, 3f, 4f, 5f, 5f, 8f, 9f);
                IncreaseEnemyDamage(0.1f, 0.15f, 0.1f, 0.15f, 0.3f, 0.3f, 0.2f, 0.35f, 0.6f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Arrows
        if (abilityNumber == 10)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.3f, 0.25f, 0.3f, 0.25f, 0.3f, 0.25f, 0.6f, 0.9f);
                IncreaseEnemyHP(2f, 1f, 2f, 1f, 2f, 3f, 5f, 6f);
                IncreaseEnemyDamage(0.07f, 0.08f, 0.07f, 0.1f, 0.15f, 0.2f, 0.1f, 0.5f, 0.7f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.65f, 0.55f, 0.65f, 0.65f, 0.8f, 0.8f, 1f, 2f);
                IncreaseEnemyHP(2f, 1f, 3f, 2f, 5f, 7f, 14f, 20f);
                IncreaseEnemyDamage(0.2f, 0.3f, 0.2f, 0.3f, 0.4f, 0.4f, 0.2f, 0.8f, 1f);
                IncreamyEnemyPoints(16, 22, 29, 49, 57, 84, 93, 142);
            }
        }
        #endregion

        //11 = Boxing glove. 12 = Stabby Spike. 13 = Tiny Spikes. 14 = Knifes. 15 = Saw Blade. 16 = Sword. 17 = Hammer.
        #region Boxing glove
        if (abilityNumber == 11)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.06f, 0.06f, 0.05f, 0.06f, 0.1f, 0.1f, 0.1f, 0.1f);
                IncreaseEnemyHP(0.3f, 0.2f, 0.4f, 0.4f, 1f, 1f, 2f, 3f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.08f, 0.07f, 0.05f, 0.1f, 0.1f);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.3f, 0.3f, 0.1f, 0.07f, 0.07f, 0.2f, 0.4f, 0.45f);
                IncreaseEnemyHP(1f, 1f, 1, 1f, 2f, 2f, 3f, 4f);
                IncreaseEnemyDamage(0.08f, 0.13f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.2f, 0.4f);
            }
        }
        #endregion

        #region Stabby Spike
        if (abilityNumber == 12)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.06f, 0.06f, 0.06f, 0.15f, 0.4f, 0.6f);
                IncreaseEnemyHP(0.3f, 0.2f, 0.4f, 0.4f, 1f, 1f, 2f, 3f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.08f, 0.07f, 0.05f, 0.1f, 0.1f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.3f, 0.25f, 0.1f, 0.1f, 0.1f, 0.3f, 0.6f, 0.9f);
                IncreaseEnemyHP(1f, 1f, 1, 1f, 2f, 2f, 3f, 4f);
                IncreaseEnemyDamage(0.1f, 0.15f, 0.05f, 0.1f, 0.15f, 0.3f, 0.15f, 0.4f, 0.6f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Tiny Spike
        if (abilityNumber == 13)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.06f, 0.06f, 0.06f, 0.15f, 0.4f, 0.6f);
                IncreaseEnemyHP(0.3f, 0.2f, 0.4f, 0.4f, 1f, 1f, 2f, 3f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.08f, 0.07f, 0.05f, 0.1f, 0.25f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.3f, 0.25f, 0.1f, 0.1f, 0.1f, 0.3f, 0.6f, 0.9f);
                IncreaseEnemyHP(1f, 1f, 1, 1f, 2f, 2f, 3f, 4f);
                IncreaseEnemyDamage(0.1f, 0.15f, 0.05f, 0.1f, 0.15f, 0.3f, 0.15f, 0.4f, 0.6f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Knifes
        if (abilityNumber == 14)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.06f, 0.06f, 0.06f, 0.15f, 0.4f, 0.6f);
                IncreaseEnemyHP(0.3f, 0.2f, 0.4f, 0.4f, 1f, 1f, 2f, 3f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.08f, 0.07f, 0.05f, 0.1f, 0.25f);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.3f, 0.25f, 0.1f, 0.1f, 0.1f, 0.3f, 0.6f, 0.9f);
                IncreaseEnemyHP(1f, 1f, 1, 1f, 2f, 2f, 3f, 4f);
                IncreaseEnemyDamage(0.1f, 0.15f, 0.05f, 0.1f, 0.15f, 0.3f, 0.15f, 0.4f, 0.6f);
            }
        }
        #endregion

        #region Saw Blade
        if (abilityNumber == 15)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.05f, 0.03f, 0.03f, 0.1f, 0.3f, 0.45f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 1f, 2f, 3f, 3f);
                IncreaseEnemyDamage(0.05f, 00.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.35f, 0.35f, 0.1f, 0.1f, 0.1f, 0.35f, 0.65f, 0.75f);
                IncreaseEnemyHP(2f, 1f, 2f, 3f, 4f, 4f, 7f, 8f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.05f, 0.1f, 0.15f, 0.3f, 0.15f, 0.5f, 0.8f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Sword
        if (abilityNumber == 16)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.25f, 0.2f, 0.1f, 0.05f, 0.05f, 0.2f, 0.5f, 0.7f);
                IncreaseEnemyHP(2f, 1f, 1f, 1f, 3f, 6f, 7f, 8f);
                IncreaseEnemyDamage(0.06f, 0.05f, 0.03f, 0.03f, 0.03f, 0.15f, 0.04f, 0.6f, 1f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.65f, 0.55f, 0.25f, 0.15f, 0.1f, 0.7f, 1f, 1.1f);
                IncreaseEnemyHP(3f, 2f, 5f, 4f, 7f, 10f, 28f, 27f);
                IncreaseEnemyDamage(0.2f, 0.3f, 0.05f, 0.05f, 0.15f, 0.5f, 0.1f, 0.6f, 1f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Hammer
        if (abilityNumber == 17)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.25f, 0.2f, 0.1f, 0.05f, 0.05f, 0.2f, 0.5f, 0.7f);
                IncreaseEnemyHP(2f, 1f, 1f, 1f, 3f, 6f, 7f, 8f);
                IncreaseEnemyDamage(0.06f, 0.05f, 0.03f, 0.03f, 0.03f, 0.15f, 0.04f, 0.6f, 1f);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.65f, 0.55f, 0.25f, 0.15f, 0.1f, 0.7f, 1f, 1.1f);
                IncreaseEnemyHP(2f, 2f, 3f, 4f, 7f, 10f, 20f, 24f);
                IncreaseEnemyDamage(0.2f, 0.25f, 0.05f, 0.05f, 0.15f, 0.4f, 0.1f, 0.6f, 1f);
            }
        }
        #endregion

        //18 = Arena. 19 == Invinciiblity. 20 = Unlimited power. 21 = Stopwatch. 22 = Skull harvest. 
        #region Arena
        if (abilityNumber == 18)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.05f, 0.1f, 0.15f);
                IncreaseEnemyHP(1f, 1f, 2f, 1f, 2f, 2f, 4f, 8f);
                IncreaseEnemyDamage(0.03f, 0.05f, 0.03f, 0.05f, 0.06f, 0.05f, 0.03f, 0.15f, 0.20f);
            }
        }
        #endregion

        #region Invincibility
        if (abilityNumber == 19)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.07f, 0.07f, 0.1f, 0.1f, 0.2f, 0.25f, 0.35f, 0.45f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2f, 2f, 3f, 4f);
                IncreaseEnemyDamage(0.05f, 00.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.3f, 0.3f, 0.3f, 0.6f, 1f, 2f, 2.5f);
                IncreaseEnemyHP(2f, 1f, 3f, 3f, 5f, 6f, 12f, 18f);
                IncreaseEnemyDamage(0.2f, 0.2f, 0.3f, 0.4f, 0.4f, 0.7f, 0.5f, 1f, 1.2f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Egg
        if (abilityNumber == 20)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.4f, 0.4f, 0.6f, 1f, 2f, 3f, 4f);
                IncreaseEnemyHP(5f, 3f, 6f, 5f, 10f, 12f, 25f, 30f);
                IncreaseEnemyDamage(0.2f, 0.2f, 0.3f, 0.4f, 0.4f, 0.7f, 0.5f, 1f, 1.2f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        #region Stopwatch
        if (abilityNumber == 21)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.05f, 0.05f, 00.05f, 0.05f, 0.05f, 0.1f, 0.2f, 0.25f);
                IncreaseEnemyHP(1f, 1f, 3f, 2f, 4f, 5f, 6f, 7f);
                IncreaseEnemyDamage(0.05f, 00.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.35f, 0.35f, 0.35f, 0.35f, 0.6f, 1.5f, 2.4f, 3.6f);
                IncreaseEnemyHP(5f, 3f, 6f, 5f, 10f, 12f, 25f, 30f);
                IncreaseEnemyDamage(0.2f, 0.2f, 0.3f, 0.4f, 0.4f, 0.7f, 0.4f, 1f, 1.2f);
            }
        }
        #endregion

        #region Skull Harvest
        if (abilityNumber == 22)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.1f, 0.1f, 0.2f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f);
                IncreaseEnemyHP(2f, 1f, 4f, 3f, 5f, 6f, 7f, 8f);
                IncreaseEnemyDamage(0.05f, 00.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.4f, 0.4f, 0.4f, 0.6f, 1f, 2f, 3f, 4f);
                IncreaseEnemyHP(5f, 4f, 6f, 6f, 15f, 15f, 35f, 40f);
                IncreaseEnemyDamage(0.2f, 0.2f, 0.3f, 0.4f, 0.4f, 0.7f, 0.5f, 1f, 1f);
                IncreamyEnemyPoints(15, 20, 28, 46, 56, 80, 90, 130);
            }
        }
        #endregion

        //23 = Defense. 24 = Big Heart. 25 = Small shields. 26 = Bouncy Shield. 27 = Point drop. 28 = Reroll. 29 = Booster. 30 = Rocket. 31 = Talaria. 32 = Ritual. 
        //33 = More Choises. 34 = Double Tap. 35 = 2 Random. 36 = 3 Random. 37 = 5 Random.

        #region Defense
        if (abilityNumber == 23)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.8f, 0.07f, 0.08f, 0.06f, 0.06f, 0.1f, 0.2f, 0.2f);
                IncreaseEnemyHP(0.5f, 0.5f, 1f, 2f, 3f, 3f, 4f, 6f);
                //IncreaseEnemyDamage(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreamyEnemyPoints(12, 18, 27, 35, 47, 61, 76, 115);
            }
        }
        #endregion

        #region Big Heart
        if (abilityNumber == 24)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.05f, 0.05f, 0.04f, 0.06f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreaseEnemyHP(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 3f, 4f);
                IncreaseEnemyDamage(0.03f, 0.04f, 0.03f, 0.04f, 0.05f, 0.05f, 0.03f, 0.08f, 0.09f);
                IncreamyEnemyPoints(15, 20, 30, 40, 60, 70, 90, 120);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.15f, 0.1f, 0.1f, 0.15f, 0.2f, 0.3f);
                IncreaseEnemyHP(1f, 2f, 3f, 2f, 4f, 4f, 5f, 7f);
                IncreaseEnemyDamage(0.05f, 0.07f, 0.05f, 0.07f, 0.09f, 0.08f, 0.06f, 0.1f, 0.15f);
                IncreamyEnemyPoints(17, 22, 35, 45, 65, 75, 95, 128);
            }
        }
        #endregion

        #region Small shield
        if (abilityNumber == 25)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.05f, 0.05f, 0.04f, 0.06f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreaseEnemyHP(1f, 1f, 3f, 2f, 4f, 4f, 6f, 7f);
                IncreaseEnemyDamage(0.05f, 0.05f, 0.07f, 0.08f, 0.09f, 0.1f, 0.1f, 0.2f, 0.3f);
                IncreamyEnemyPoints(15, 20, 30, 40, 60, 70, 90, 120);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.15f, 0.1f, 0.2f, 0.2f, 0.2f, 0.2f, 0.3f, 0.4f);
                IncreaseEnemyHP(2f, 2f, 2f, 3f, 5f, 5f, 7f, 9f);
                IncreaseEnemyDamage(0.1f, 0.15f, 0.1f, 0.15f, 0.2f, 0.2f, 0.1f, 0.4f, 0.7f);
                IncreamyEnemyPoints(17, 22, 35, 45, 65, 75, 95, 128);
            }
        }
        #endregion

        #region Bouncy Shield
        if (abilityNumber == 26)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.05f, 0.05f, 0.04f, 0.06f, 0.06f, 0.1f, 0.15f, 0.2f);
                IncreaseEnemyHP(1f, 1f, 3f, 2f, 4f, 4f, 6f, 7f);
                IncreaseEnemyDamage(0.07f, 0.07f, 0.09f, 0.12f, 0.11f, 0.2f, 0.09f, 0.15f, 0.25f);
                IncreamyEnemyPoints(15, 20, 30, 40, 60, 70, 90, 120);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.2f, 0.15f, 0.3f, 0.25f, 0.25f, 0.25f, 0.35f, 0.45f);
                IncreaseEnemyHP(2f, 2f, 4f, 3f, 5f, 6f, 7f, 9f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.15f, 0.2f, 0.25f, 0.25f, 0.15f, 0.5f, 0.9f);
                IncreamyEnemyPoints(17, 22, 35, 45, 65, 75, 95, 128);
            }
        }
        #endregion

        #region Point drop
        if (abilityNumber == 27)
        {
            if (common == true)
            {
                //DecreaseEnemySpawnTime(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
                //IncreaseEnemyDamage(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
            }
            if (common == false)
            {
                //DecreaseEnemySpawnTime(0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f);
                IncreaseEnemyHP(1f, 1f, 2f, 2f, 2f, 2f, 3f, 3f);
                //IncreaseEnemyDamage(0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f);
            }
        }
        #endregion

        #region Reroll
        if (abilityNumber == 28)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                //IncreaseEnemyHP(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
                //IncreaseEnemyDamage(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreamyEnemyPoints(15, 20, 30, 40, 60, 70, 90, 120);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f);
                //IncreaseEnemyHP(1f, 1f, 2f, 2f, 2f, 2f, 3f, 3f);
                //IncreaseEnemyDamage(0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f, 0.07f);
                IncreamyEnemyPoints(17, 22, 35, 45, 65, 75, 95, 128);
            }
        }
        #endregion

        #region More choises
        if (abilityNumber == 33)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                //IncreaseEnemyHP(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f);
                //IncreaseEnemyDamage(0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f, 0.05f);
                IncreamyEnemyPoints(15, 20, 30, 40, 60, 70, 90, 120);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f, 0.08f);
                //IncreaseEnemyHP(1f, 1f, 2f, 2f, 2f, 2f, 3f, 3f);
                //IncreaseEnemyDamage(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.07f, 0.07f);
                IncreamyEnemyPoints(17, 22, 35, 45, 65, 75, 95, 128);
            }
        }
        #endregion

        #region Booster/Button bounce
        if (abilityNumber == 29)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.15f, 0.15f, 0.1f, 0.1f, 0.1f, 0.25f, 1f, 2f);
                IncreaseEnemyHP(3f, 2f, 3f, 4f, 6f, 6f, 10f, 15f);
                IncreaseEnemyDamage(0.07f, 0.1f, 0.07f, 0.1f, 0.2f, 0.35f, 0.2f, 0.6f, 0.9f);
                IncreamyEnemyPoints(25, 35, 45, 60, 75, 90, 120, 145);
            }
        }
        #endregion

        #region Rocket
        if (abilityNumber == 30)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.35f, 0.35f, 0.2f, 0.15f, 0.15f, 0.35f, 1f, 2f);
                IncreaseEnemyHP(5f, 4f, 7f, 5f, 9f, 7f, 24f, 45f);
                IncreaseEnemyDamage(0.1f, 0.1f, 0.1f, 0.15f, 0.25f, 0.4f, 0.25f, 0.8f, 1.3f);
                IncreamyEnemyPoints(27, 39, 50, 66, 82, 93, 124, 170);
            }
        }
        #endregion

        #region Talaria
        if (abilityNumber == 31)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(1f, 0.8f, 1f, 1f, 1f, 1f, 3f, 4f);
                IncreaseEnemyHP(6f, 5f, 8f, 6f, 11f, 9f, 27f, 50f);
                IncreaseEnemyDamage(0.5f, 0.6f, 0.5f, 0.6f, 0.7f, 0.6f, 0.25f, 1f, 2f);
                IncreamyEnemyPoints(35, 45, 60, 75, 86, 100, 135, 190);
            }
        }
        #endregion

        #region Ritual
        if (abilityNumber == 32)
        {
            if (common == true)
            {
                DecreaseEnemySpawnTime(0.25f, 0.15f, 0.2f, 0.2f, 0.2f, 0.25f, 0.45f, 0.65f);
                IncreaseEnemyHP(1f, 1f, 2f, 1f, 3f, 3f, 5f, 7f);
                IncreaseEnemyDamage(0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f);
                IncreamyEnemyPoints(15, 20, 30, 40, 60, 70, 90, 120);
            }
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.5f, 0.4f, 0.4f, 0.5f, 0.7f, 1f, 1f, 2f);
                IncreaseEnemyHP(3f, 4f, 3f, 5f, 7f, 7f, 10f, 20f);
                IncreaseEnemyDamage(0.2f, 0.25f, 0.15f, 0.2f, 0.25f, 0.2f, 0.15f, 0.25f, 0.55f);
                IncreamyEnemyPoints(19, 24, 35, 45, 65, 75, 95, 128);
            }
        }
        #endregion

        #region Double Tap
        if (abilityNumber == 34)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(4f, 3f, 3f, 3f, 3f, 3f, 6f, 8f);
                IncreaseEnemyHP(9f, 11f, 13f, 16f, 20f, 24f, 35f, 65f);
                IncreaseEnemyDamage(1f, 2f, 1f, 2f, 3f, 3f, 1f, 3f, 4f);
            }
        }
        #endregion

        #region 2 Random
        if (abilityNumber == 35)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.25f, 0.25f, 0.2f, 0.15f, 0.15f, 0.25f, 0.45f, 0.65f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 2, 2f, 3f, 4f);
                IncreaseEnemyDamage(0.1f, 0.1f, 0.1f, 0.15f, 0.2f, 0.2f, 0.1f, 0.4f, 0.6f);
                IncreamyEnemyPoints(13, 23, 27, 35, 45, 55, 80, 120);
            }
        }
        #endregion

        #region 3 Random
        if (abilityNumber == 36)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.35f, 0.35f, 0.25f, 0.2f, 0.2f, 0.3f, 0.7f, 0.9f);
                IncreaseEnemyHP(1f, 1f, 1f, 1f, 3f, 3f, 4f, 6f);
                IncreaseEnemyDamage(0.15f, 0.2f, 0.15f, 0.2f, 0.25f, 0.4f, 0.2f, 0.65f, 0.8f);
                IncreamyEnemyPoints(25, 35, 45, 65, 75, 89, 120, 160);
            }
        }
        #endregion

        #region 5 Random
        if (abilityNumber == 37)
        {
            if (common == false)
            {
                DecreaseEnemySpawnTime(0.55f, 0.55f, 0.4f, 0.3f, 0.25f, 0.45f, 1f, 1.2f);
                IncreaseEnemyHP(2f, 1f, 2f, 3f, 4f, 5f, 7f, 8f);
                IncreaseEnemyDamage(0.2f, 0.25f, 0.2f, 0.25f, 0.4f, 0.5f, 0.2f, 0.9f, 1.1f);
                IncreamyEnemyPoints(35, 45, 55, 75, 90, 105, 135, 180);
            }
        }
        #endregion
    }

    #region Decrease Spawn Time
    public void DecreaseEnemySpawnTime(float smallEnemy, float speedster, float sharpshooter, float sniper, float heavyShot, float ragingGunner, float brute, float titan)
    {
        if (spawnMoreSmallEnemiesTimer > 0.25f) { spawnMoreSmallEnemiesTimer -= smallEnemy; }
        if (spawnMoreSpeedsterTimer > 0.45f) { spawnMoreSpeedsterTimer -= speedster; }
        if (spawnMoreSharpshooterTimer > 0.9f) { spawnMoreSharpshooterTimer -= sharpshooter; }
        if (spawnMoreSniperTimer > 1.1f) { spawnMoreSniperTimer -= sniper; }
        if (spawnMoreHeavyShotTimer > 1.2f) { spawnMoreHeavyShotTimer -= heavyShot; }
        if (spawnMoreRagingGunnerTimer > 1.3f) { spawnMoreRagingGunnerTimer -= ragingGunner; }
        if (spawnMoreBruteTimer > 2f) { spawnMoreBruteTimer -= brute; }
        if (spawnMoreTitanTimer > 4f) { spawnMoreTitanTimer -= titan; }

        //Min spawn time
        if (spawnMoreSmallEnemiesTimer < 0.25f) { spawnMoreSmallEnemiesTimer = 0.25f; }
        if (spawnMoreSpeedsterTimer < 0.35f) { spawnMoreSpeedsterTimer = 0.35f; }
        if (spawnMoreSharpshooterTimer < 0.8f) { spawnMoreSharpshooterTimer = 0.8f; }
        if (spawnMoreSniperTimer < 1f) { spawnMoreSniperTimer = 1f; }
        if (spawnMoreHeavyShotTimer < 2f) { spawnMoreHeavyShotTimer = 2f; }
        if (spawnMoreRagingGunnerTimer < 2.5f) { spawnMoreRagingGunnerTimer = 2.5f; }
        if (spawnMoreBruteTimer < 6f) { spawnMoreBruteTimer = 6f; }
        if (spawnMoreTitanTimer < 8f) { spawnMoreTitanTimer = 8f; }
    }
    #endregion

    #region Increase Enemy HP
    public void IncreaseEnemyHP(float smallEnemy, float speedster, float sharpshooter, float sniper, float heavyShot, float ragingGunner, float brute, float titan)
    {
        if (smallEnemyHP < 500f) { smallEnemyHP += smallEnemy; }
        if (speedsterHP < 650f) { speedsterHP += speedster; }
        if (sharpshooterHP < 800f) { sharpshooterHP += sharpshooter; }
        if (sniperHP < 900f) { sniperHP += sniper; }
        if (heavyshotHP < 2000f) { heavyshotHP += heavyShot; }
        if (ragingGunnerHP < 4000f) { ragingGunnerHP += ragingGunner; }
        if (bruteHP < 7000f) { bruteHP += brute; }
        if (titanHP < 10000f) { titanHP += titan; }
    }
    #endregion

    #region Increase Enemy Damage
    public void IncreaseEnemyDamage(float smallEnemy, float speedster, float sharpshooter, float sniper, float heavyShot, float ragingGunnerMelle, float ragingGunnerRanged, float brute, float titan)
    {
        if (smallEnemyDamage < 150f) { smallEnemyDamage += smallEnemy; }
        if (speedsterDamagePerSecond < 250f) { speedsterDamagePerSecond += speedster; }
        if (smallEnemyBulletDamage < 500) { smallEnemyBulletDamage += sharpshooter; }
        if (sniperEnemyBulletDamage < 500f) { sniperEnemyBulletDamage += sniper; }
        if (heavyShotDamage < 500f) { heavyShotDamage += heavyShot; }
        if (raginGunnerMeleeDamage < 500f) { raginGunnerMeleeDamage += ragingGunnerMelle; }
        if (raginGunnerBulletDamage < 500f) { raginGunnerBulletDamage += ragingGunnerRanged; }
        if (bruteDamage < 500f) { bruteDamage += brute; }
        if (titanDamage < 500f) { titanDamage += titan; }
    }
    #endregion

    #region Increase Enemy Points
    public void IncreamyEnemyPoints(int smallEnemy, int speedster, int sharpshooter, int sniper, int heavyShot, int ragingGunner, int brute, int titan)
    {
        //Debug.Log(sniperPoints);

        //if (smallEnemyPoints < 100000000) { smallEnemyPoints += smallEnemy; }
        //if (speedsterPoints < 100000000) { speedsterPoints += speedster; }
        //if (shootingEnemyPoints < 100000000) { shootingEnemyPoints += sharpshooter; }
        //if (sniperPoints < 100000000) { sniperPoints += sniper; }
        //if (heavyShotPoints < 100000000) { heavyShotPoints += heavyShot; }
        //if (raginGunnerPoints < 100000000) { raginGunnerPoints += ragingGunner; }
        //if (bigEnemyPoint < 100000000) { bigEnemyPoint += brute; }
        //if (titanPoints < 100000000) { titanPoints += titan; }

        //Debug.Log(sniperPoints);
    }
    #endregion

    #region Set Enemy Points

    public int levelScaleAssassin, levelScaleSpeedster, levelScaleSharpshooter, levelScaleSniper, levelScaleHeavyshot, levelScaleGunner, levelScaleBrute, levelScaleTitan;

    public void SetEnemyPoints(int enemiesActive)
    {
        int totalEnemiesActive = numberOfEnemiesActive + enemiesActive;

        #region After Level 75
        if (ButtonClick.level > Choises.levelToFirstEnding) 
        {
            levelScaleAssassin = 15;
            levelScaleSpeedster = 10;
            levelScaleSharpshooter = 7;
            levelScaleSniper = 6;
            levelScaleHeavyshot = 4;
            levelScaleGunner = 3;
            levelScaleBrute = 2;
            levelScaleTitan = 1;
        }
        #endregion

        //13784

        #region After Level 90
        if (ButtonClick.level > 90)
        {
            levelScaleAssassin = 30;
            levelScaleSpeedster = 22;
            levelScaleSharpshooter = 15;
            levelScaleSniper = 14;
            levelScaleHeavyshot = 10;
            levelScaleGunner = 6;
            levelScaleBrute = 4;
            levelScaleTitan = 2;
        }
        #endregion

        #region After Level 110
        if (ButtonClick.level > 110)
        {
            levelScaleAssassin = 60;
            levelScaleSpeedster = 45;
            levelScaleSharpshooter = 30;
            levelScaleSniper = 25;
            levelScaleHeavyshot = 20;
            levelScaleGunner = 15;
            levelScaleBrute = 10;
            levelScaleTitan = 5;
        }
        #endregion

        #region After Level 130
        if (ButtonClick.level > 130)
        {
            levelScaleAssassin = 90;
            levelScaleSpeedster = 75;
            levelScaleSharpshooter = 50;
            levelScaleSniper = 40;
            levelScaleHeavyshot = 30;
            levelScaleGunner = 20;
            levelScaleBrute = 15;
            levelScaleTitan = 7;
        }
        #endregion

        #region After Level 180
        if (ButtonClick.level > 180)
        {
            levelScaleAssassin = 130;
            levelScaleSpeedster = 100;
            levelScaleSharpshooter = 65;
            levelScaleSniper = 50;
            levelScaleHeavyshot = 38;
            levelScaleGunner = 28;
            levelScaleBrute = 19;
            levelScaleTitan = 9;
        }
        #endregion

        #region After Level 240
        if (ButtonClick.level > 240)
        {
            levelScaleAssassin = 200;
            levelScaleSpeedster = 150;
            levelScaleSharpshooter = 100;
            levelScaleSniper = 80;
            levelScaleHeavyshot = 60;
            levelScaleGunner = 40;
            levelScaleBrute = 25;
            levelScaleTitan = 15;
        }
        #endregion

        #region After Level 300
        if (ButtonClick.level > 300)
        {
            levelScaleAssassin = 300;
            levelScaleSpeedster = 220;
            levelScaleSharpshooter = 175;
            levelScaleSniper = 125;
            levelScaleHeavyshot = 80;
            levelScaleGunner = 55;
            levelScaleBrute = 35;
            levelScaleTitan = 25;
        }
        #endregion

        #region After Level 400
        if (ButtonClick.level > 400)
        {
            levelScaleAssassin = 400;
            levelScaleSpeedster = 330;
            levelScaleSharpshooter = 230;
            levelScaleSniper = 180;
            levelScaleHeavyshot = 130;
            levelScaleGunner = 90;
            levelScaleBrute = 50;
            levelScaleTitan = 35;
        }
        #endregion

        //Assasin
        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { smallEnemyPoints = ButtonClick.pointsNeeded / (18 + levelScaleAssassin); }
        if (totalEnemiesActive == 2) { smallEnemyPoints = ButtonClick.pointsNeeded / (29 + levelScaleAssassin); }
        if (totalEnemiesActive == 3) { smallEnemyPoints = ButtonClick.pointsNeeded / (42 + levelScaleAssassin); }
        if (totalEnemiesActive == 4) { smallEnemyPoints = ButtonClick.pointsNeeded / (60 + levelScaleAssassin); }
        if (totalEnemiesActive == 5) { smallEnemyPoints = ButtonClick.pointsNeeded / (100 + levelScaleAssassin); }
        if (totalEnemiesActive == 6) { smallEnemyPoints = ButtonClick.pointsNeeded / (160 + levelScaleAssassin); }
        if (totalEnemiesActive == 7) { smallEnemyPoints = ButtonClick.pointsNeeded / (230 + levelScaleAssassin); }
        if (totalEnemiesActive == 8) { smallEnemyPoints = ButtonClick.pointsNeeded / (340 + levelScaleAssassin); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { speedsterPoints = ButtonClick.pointsNeeded / (15 + levelScaleSpeedster); }
        if (totalEnemiesActive == 2) { speedsterPoints = ButtonClick.pointsNeeded / (25 + levelScaleSpeedster); }
        if (totalEnemiesActive == 3) { speedsterPoints = ButtonClick.pointsNeeded / (36 + levelScaleSpeedster); }
        if (totalEnemiesActive == 4) { speedsterPoints = ButtonClick.pointsNeeded / (55 + levelScaleSpeedster); }
        if (totalEnemiesActive == 5) { speedsterPoints = ButtonClick.pointsNeeded / (90 + levelScaleSpeedster); }
        if (totalEnemiesActive == 6) { speedsterPoints = ButtonClick.pointsNeeded / (125 + levelScaleSpeedster); }
        if (totalEnemiesActive == 7) { speedsterPoints = ButtonClick.pointsNeeded / (200 + levelScaleSpeedster); }
        if (totalEnemiesActive == 8) { speedsterPoints = ButtonClick.pointsNeeded / (320 + levelScaleSpeedster); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { shootingEnemyPoints = ButtonClick.pointsNeeded / (9 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 2) { shootingEnemyPoints = ButtonClick.pointsNeeded / (13 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 3) { shootingEnemyPoints = ButtonClick.pointsNeeded / (20 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 4) { shootingEnemyPoints = ButtonClick.pointsNeeded / (28 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 5) { shootingEnemyPoints = ButtonClick.pointsNeeded / (39 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 6) { shootingEnemyPoints = ButtonClick.pointsNeeded / (57 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 7) { shootingEnemyPoints = ButtonClick.pointsNeeded / (80 + levelScaleSharpshooter); }
        if (totalEnemiesActive == 8) { shootingEnemyPoints = ButtonClick.pointsNeeded / (110 + levelScaleSharpshooter); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { sniperPoints = ButtonClick.pointsNeeded / (8 + levelScaleSniper); }
        if (totalEnemiesActive == 2) { sniperPoints = ButtonClick.pointsNeeded / (11 + levelScaleSniper); }
        if (totalEnemiesActive == 3) { sniperPoints = ButtonClick.pointsNeeded / (18 + levelScaleSniper); }
        if (totalEnemiesActive == 4) { sniperPoints = ButtonClick.pointsNeeded / (24 + levelScaleSniper); }
        if (totalEnemiesActive == 5) { sniperPoints = ButtonClick.pointsNeeded / (34 + levelScaleSniper); }
        if (totalEnemiesActive == 6) { sniperPoints = ButtonClick.pointsNeeded / (51 + levelScaleSniper); }
        if (totalEnemiesActive == 7) { sniperPoints = ButtonClick.pointsNeeded / (71 + levelScaleSniper); }
        if (totalEnemiesActive == 8) { sniperPoints = ButtonClick.pointsNeeded / (110 + levelScaleSniper); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { heavyShotPoints = ButtonClick.pointsNeeded / (7 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 2) { heavyShotPoints = ButtonClick.pointsNeeded / (9 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 3) { heavyShotPoints = ButtonClick.pointsNeeded / (13 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 4) { heavyShotPoints = ButtonClick.pointsNeeded / (21 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 5) { heavyShotPoints = ButtonClick.pointsNeeded / (28 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 6) { heavyShotPoints = ButtonClick.pointsNeeded / (35 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 7) { heavyShotPoints = ButtonClick.pointsNeeded / (65 + levelScaleHeavyshot); }
        if (totalEnemiesActive == 8) { heavyShotPoints = ButtonClick.pointsNeeded / (95 + levelScaleHeavyshot); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { bigEnemyPoint = ButtonClick.pointsNeeded / (4 + levelScaleBrute); }
        if (totalEnemiesActive == 2) { bigEnemyPoint = ButtonClick.pointsNeeded / (7 + levelScaleBrute); }
        if (totalEnemiesActive == 3) { bigEnemyPoint = ButtonClick.pointsNeeded / (10 + levelScaleBrute); }
        if (totalEnemiesActive == 4) { bigEnemyPoint = ButtonClick.pointsNeeded / (15 + levelScaleBrute); }
        if (totalEnemiesActive == 5) { bigEnemyPoint = ButtonClick.pointsNeeded / (21 + levelScaleBrute); }
        if (totalEnemiesActive == 6) { bigEnemyPoint = ButtonClick.pointsNeeded / (26 + levelScaleBrute); }
        if (totalEnemiesActive == 7) { bigEnemyPoint = ButtonClick.pointsNeeded / (35 + levelScaleBrute); }
        if (totalEnemiesActive == 8) { bigEnemyPoint = ButtonClick.pointsNeeded / (50 + levelScaleBrute); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { raginGunnerPoints = ButtonClick.pointsNeeded / (6 + levelScaleGunner); }
        if (totalEnemiesActive == 2) { raginGunnerPoints = ButtonClick.pointsNeeded / (8 + levelScaleGunner); }
        if (totalEnemiesActive == 3) { raginGunnerPoints = ButtonClick.pointsNeeded / (12 + levelScaleGunner); }
        if (totalEnemiesActive == 4) { raginGunnerPoints = ButtonClick.pointsNeeded / (18 + levelScaleGunner); }
        if (totalEnemiesActive == 5) { raginGunnerPoints = ButtonClick.pointsNeeded / (24 + levelScaleGunner); }
        if (totalEnemiesActive == 6) { raginGunnerPoints = ButtonClick.pointsNeeded / (30 + levelScaleGunner); }
        if (totalEnemiesActive == 7) { raginGunnerPoints = ButtonClick.pointsNeeded / (55 + levelScaleGunner); }
        if (totalEnemiesActive == 8) { raginGunnerPoints = ButtonClick.pointsNeeded / (80 + levelScaleGunner); }

        if (totalEnemiesActive == 1 || totalEnemiesActive == 0) { titanPoints = ButtonClick.pointsNeeded / (3 + levelScaleTitan); }
        if (totalEnemiesActive == 2) { titanPoints = ButtonClick.pointsNeeded / (4 + levelScaleTitan); }
        if (totalEnemiesActive == 3) { titanPoints = ButtonClick.pointsNeeded / (6 + levelScaleTitan); }
        if (totalEnemiesActive == 4) { titanPoints = ButtonClick.pointsNeeded / (8 + levelScaleTitan); }
        if (totalEnemiesActive == 5) { titanPoints = ButtonClick.pointsNeeded / (10 + levelScaleTitan); }
        if (totalEnemiesActive == 6) { titanPoints = ButtonClick.pointsNeeded / (14 + levelScaleTitan); }
        if (totalEnemiesActive == 7) { titanPoints = ButtonClick.pointsNeeded / (20 + levelScaleTitan); }
        if (totalEnemiesActive == 8) { titanPoints = ButtonClick.pointsNeeded / (29 + levelScaleTitan); }
    }
    #endregion

    #region Decrease normal spawn time
    public void DecreaseNormalEnemySpawnTime(float smallEnemy, float speedster, float sharpshooter, float sniper, float heavyShot, float ragingGunner, float brute, float titan)
    {
        if (smallEnemySpawnTimer > 0.1f) { smallEnemySpawnTimer -= smallEnemy; }
        if (speedsterSpawnTimer > 0.15f) { speedsterSpawnTimer -= speedster; }
        if (sharpshooterSpawnTimer > 0.7f) { sharpshooterSpawnTimer -= sharpshooter; }
        if (sniperSpawnTimer > 0.8f) { sniperSpawnTimer -= sniper; }
        if (heavyShotSpawnTiner > 1f) { heavyShotSpawnTiner -= heavyShot; }
        if (ragingGunnerSpawnTimer > 2f) { ragingGunnerSpawnTimer -= ragingGunner; }
        if (bigEnemySpawnTimer > 5f) { bigEnemySpawnTimer -= brute; }
        if (titanSpawnTimer > 7f) { titanSpawnTimer -= titan; }

        if (smallEnemySpawnTimer < 0.1f) { smallEnemySpawnTimer = 0.1f; }
        if (speedsterSpawnTimer < 0.15f) { speedsterSpawnTimer = 0.15f; }
        if (sharpshooterSpawnTimer < 0.7f) { sharpshooterSpawnTimer = 0.7f; }
        if (sniperSpawnTimer < 0.8f) { sniperSpawnTimer = 0.8f; }
        if (heavyShotSpawnTiner < 1f) { heavyShotSpawnTiner = 1f; }
        if (ragingGunnerSpawnTimer < 2f) { ragingGunnerSpawnTimer = 2f; }
        if (bigEnemySpawnTimer < 5f) { bigEnemySpawnTimer = 5f; }
        if (titanSpawnTimer < 7f) { titanSpawnTimer = 7f; }
    }
    #endregion

    #region Increase Max Enemy Spawn
    public void IncreaseMaxEnemyspawn(int smallEnemy, int speedster, int sharpshooter, int sniper, int heavyShot, int ragingGunner, int brute, int titan)
    {
        if (maxAssasins < 75) { maxAssasins += smallEnemy; }
        if (maxSpeedsters < 60) { maxSpeedsters += speedster; }
        if (maxSharpshooters < 31) { maxSharpshooters += sharpshooter; }
        if (maxSnipers < 28) { maxSnipers += sniper; }
        if (maxHeavyshots < 21) { maxHeavyshots += heavyShot; }
        if (maxRagingGunners < 25) { maxRagingGunners += ragingGunner; }
        if (maxBrutes < 25) { maxBrutes += brute; }
        if (maxTitans < 15) { maxTitans += titan; }
    }
    #endregion

    //Check Button
    #region Check Spawn time, hp and points
    public void CheckSpawnTimer()
    {
        Debug.Log("Enemy Span Timers:");
        Debug.Log("Small Enemy =" + spawnMoreSmallEnemiesTimer + "s");
        Debug.Log("Speedster =" + spawnMoreSpeedsterTimer + "s");
        Debug.Log("Sharpshooter=" + spawnMoreSharpshooterTimer + "s");
        Debug.Log("Sniper =" + spawnMoreSniperTimer + "s");
        Debug.Log("Heavyshot =" + spawnMoreHeavyShotTimer + "s");
        Debug.Log("Raging Gunner =" + spawnMoreRagingGunnerTimer + "s");
        Debug.Log("Brute =" + spawnMoreBruteTimer + "s");
        Debug.Log("Titan =" + spawnMoreTitanTimer + "s");
    }


    public void CheckEnemyHP()
    {
        Debug.Log("Enemy HP");
        Debug.Log("Small Enemy =" + smallEnemyHP + "HP");
        Debug.Log("Speedster =" + speedsterHP + "HP");
        Debug.Log("Sharpshooter=" + sharpshooterHP + "HP");
        Debug.Log("Sniper =" + sniperHP + "HP");
        Debug.Log("Heavyshot =" + heavyshotHP + "HP");
        Debug.Log("Raging Gunner =" + ragingGunnerHP + "HP");
        Debug.Log("Brute =" + bruteHP + "HP");
        Debug.Log("Titan =" + titanHP + "HP");
    }

    public void CheckEnemyDamage()
    {
        Debug.Log("Enemy DAMAGE");
        Debug.Log("Small Enemy =" + smallEnemyDamage + " DAMAGE");
        Debug.Log("Speedster =" + speedsterDamagePerSecond + " DAMAGE");
        Debug.Log("Sharpshooter=" + smallEnemyBulletDamage + " DAMAGE");
        Debug.Log("Sniper =" + sniperEnemyBulletDamage + " DAMAGE");
        Debug.Log("Heavyshot =" + heavyShotDamage + " DAMAGE");
        Debug.Log("Raging Gunner =" + raginGunnerBulletDamage + " RANGED DAMAGE");
        Debug.Log("Raging Gunner =" + raginGunnerMeleeDamage + " MELEE DAMAGE");
        Debug.Log("Brute =" + bruteDamage + " DAMAGE");
        Debug.Log("Titan =" + titanDamage + " DAMAGE");
    }

    public void CheckEnemyPoints()
    {
        Debug.Log("Enemy POINTS");
        Debug.Log("Small Enemy =" + smallEnemyPoints + " POINTS");
        Debug.Log("Speedster =" + speedsterPoints + " POINTS");
        Debug.Log("Sharpshooter=" + shootingEnemyPoints + " POINTS");
        Debug.Log("Sniper =" + sniperPoints + " POINTS");
        Debug.Log("Heavyshot =" + heavyShotPoints + " POINTS");
        Debug.Log("Raging Gunner =" + raginGunnerPoints + " RANGED POINTS");
        Debug.Log("Brute =" + bigEnemyPoint + " POINTS");
        Debug.Log("Titan =" + titanPoints + " POINTS");
    }

    public void CheckNormalSpawnTime()
    {
        Debug.Log("Enemy NORMAL SPAWN TIME");
        Debug.Log("Small Enemy =" + smallEnemySpawnTimer + "s");
        Debug.Log("Speedster =" + speedsterSpawnTimer + "s");
        Debug.Log("Sharpshooter=" + sharpshooterSpawnTimer + "s");
        Debug.Log("Sniper =" + sniperSpawnTimer + "s");
        Debug.Log("Heavyshot =" + heavyShotSpawnTiner + "s");
        Debug.Log("Raging Gunner =" + ragingGunnerSpawnTimer + "s");
        Debug.Log("Brute =" + bigEnemySpawnTimer + "s");
        Debug.Log("Titan =" + titanSpawnTimer + "s");
    }

    public void CheckAbilityChances()
    {
        Debug.Log("Ability Chances:");
        Debug.Log("Common =" + commonChance + "%");
        Debug.Log("Uncommon =" + uncommonChance + "%");
        Debug.Log("Rare =" + rareChance + "%");
        Debug.Log("Legendary =" + legendaryChance + "%");
        Debug.Log("Mythic =" + (100 - legendaryChance) + "%");
    }

    public void CheckMaxEnemyCount()
    {
        Debug.Log("Max Enemies:");
        Debug.Log("Max Assasins = " + maxAssasins);
        Debug.Log("Max Speedsters = " + maxSpeedsters);
        Debug.Log("Max Sharpshooters = " + maxSharpshooters);
        Debug.Log("Max Snipers = " + maxSnipers);
        Debug.Log("Max Heavyshots = " + maxHeavyshots);
        Debug.Log("Max Raging Gunners = " + maxRagingGunners);
        Debug.Log("Max Brutes = " + maxBrutes);
        Debug.Log("Max Titans = " + maxTitans);
    }

    public void CheckEnemiesOnScreen()
    {
        Debug.Log("Enemies On Screen:");
        Debug.Log("Assasins = " + SpawnEnemies.smallEnemyCount);
        Debug.Log("Speedsters = " + SpawnEnemies.speedsterCount);
        Debug.Log("Sharpshooters = " + SpawnShootingEnemy.shootingEnemyCount);
        Debug.Log("Snipers = " + SpawnShootingEnemy.sniperCount);
        Debug.Log("Heavyshots = " + SpawnShootingEnemy.heavyShotCount);
        Debug.Log("Raging Gunners = " + SpawnShootingEnemy.ragingGunnerCount);
        Debug.Log("Brutes = " + SpawnBigEnemy.bigEnemyCount);
        Debug.Log("Titans = " + SpawnBigEnemy.titanCount);
    }
    #endregion


    #region Reset Gameobjects
    public void ResetAllGameObject(bool resetHealthbar)
    {
        //Remeber to reset Auto and Controlled guns position

        sawBlade2.SetActive(false);
        sawBlade3.SetActive(false);
        sawBlade4.SetActive(false);
        sawBlade5.SetActive(false);
        sawBlade6.SetActive(false);
        sawBlade7.SetActive(false);
        sawBlade8.SetActive(false);

        bouncyShield2.SetActive(false);
        bouncyShield3.SetActive(false);
        bouncyShield4.SetActive(false);

        stabbingSpike5.SetActive(false);
        stabbingSpike6.SetActive(false);
        stabbingSpike7.SetActive(false);
        stabbingSpike8.SetActive(false);

        smallShield3.SetActive(false);
        smallShield4.SetActive(false);
        smallShield5.SetActive(false);
        smallShield6.SetActive(false);
        smallShield7.SetActive(false);
        smallShield8.SetActive(false);

        sword2.SetActive(false);
        sword3.SetActive(false);
        sword4.SetActive(false);

        smallShields.SetActive(false);
        movementAbilityAquaried = false;
        gun_RandomDirection.SetActive(false);
        gun1.SetActive(false);
        gun2.SetActive(false);
        gun3.SetActive(false);
        crossbow.SetActive(false);
        gun_Homing.SetActive(false);
        gun_trippleShot.SetActive(false);
        gun_bigPiercing.SetActive(false);
        arenaObject.SetActive(false);
        bigSpike.SetActive(false);
        spikes.SetActive(false);
        stabbingSpikes.SetActive(false);
        boxingGlove.SetActive(false);
        sawBlade.SetActive(false);
        

        if(resetHealthbar == true)
        {
            healthText.gameObject.SetActive(false);
            healthBar.SetActive(false);
            smallChargeButton.SetActive(false);
            rocket.SetActive(false);

        }
        shield_BounceOff.SetActive(false);

        controlledSpotFilled = -0;
        weaponSpotsFilledOut = 0;

        SetEnemyPoints(0);
    }
    #endregion

    public static int stored4Choises, storedRerollRare, storedChargedBullets, storedShieldBounce, stored3Random, storedBooster, storedShotgun, storedAWP, storedSawBlade, storedCrossbow, storedTripple;

    #region Check Uncommon Spots

    public void TestButton()
    {
        //activeRareAbilities[0] = null;
        RemoveAbilityFromArray(3, 0);

        Invoke("Set", 1f);
    }

    public void Set()
    {
     

       
    }

    public void SetLeg()
    {
      

       
    }


    public void RemoveAbilityFromArray(int rarity, int arrayPosition)
    {
        //rarity - 1 = common, 2 = uncommon, 3 = rare, 4 = legendary.
        if (rarity == 3)
        {
            int currentRareArrayLenght = rareAbilitiesAviable + 1;

            //C
            for (int i = 0; i < currentRareArrayLenght; i++)
            {
                if(i > arrayPosition)
                {
                    //Debug.Log(i);
                    activeRareAbilities[i - 1] = activeRareAbilities[i];
                }
            }

            activeRareAbilities[rareAbilitiesAviable] = null;
        }


        //rarity - 1 = common, 2 = uncommon, 3 = rare, 4 = legendary.
        if (rarity == 4)
        {
            int currentLEgendaryArray = legendaryAbilitiesAviable + 1;

            for (int i = 0; i < currentLEgendaryArray; i++)
            {
                if (i > arrayPosition)
                {
                    //Debug.Log(i);
                    activeLegendaryAbilities[i - 1] = activeLegendaryAbilities[i];
                }
            }

            activeLegendaryAbilities[legendaryAbilitiesAviable] = null;
        }
    }
    #endregion

    #region Set Stored Start
    public void SetStoredStart()
    {
        stored4Choises = 0;
        storedRerollRare = 1;
        stored3Random = 2;
        storedShotgun = 3;
        storedAWP = 4;
        storedCrossbow = 5;
        storedTripple = 6;
    }
    #endregion

    public void OpButton()
    {
        timeBetweenClicks = 0;
        //ButtonClick.level = 74;
        //maxButtonHealth += 500;
        //buttonHealth += 500;
        //bulletGun1_Damage += 500;
    }


    public ButtonClick buttonClickScript;

    //Resume game
    public void UnPauseGame()
    {
        isInLevelUpScreen = false;
        if (firstControlledGun == true) 
        { 
            if(MobileScript.isMobile == false) { aimCursor.SetActive(true); }
        }
        rerollButtonObject.SetActive(false);
        StartCoroutine(StartTimeScale());
        rerollButton.SetActive(false);
        choseAnimPlaying = false;
      
        if (waitBool == true)
        {
            SetChosenAbilititesInactive();
        }

        if(ButtonClick.isStopTimeAbilityActive == false) { Time.timeScale = 1; }
        SetCursors.hoveringClickableStuff = false;
        SetEnemyPoints(0);
        buttonClickScript.CheckOnlyActive();
    }

    IEnumerator StartTimeScale()
    {
        yield return new WaitForSecondsRealtime(0.07f);
        weirdEggScreen.SetActive(false);
        weirdEggChooseScreen.SetActive(false);
        SetEnemyTextsInactive();
    }

    #region Reset Abilitites
    public void ResetAbilites()
    {
        regenHealth = false;
        if(regenCoroutine != null) { StopCoroutine(regenCoroutine); }

        abilitesToReroll[0] = null;
        abilitesToReroll[1] = null;
        abilitesToReroll[2] = null;
        abilitesToReroll[3] = null;
        abilitesToReroll[4] = null;

        //Common
        activeCommonAbilities[0] = allCommonAbilitites[0];
        activeCommonAbilities[1] = allCommonAbilitites[1];
        activeCommonAbilities[2] = allCommonAbilitites[2];
        activeCommonAbilities[3] = null; activeCommonAbilities[4] = null; activeCommonAbilities[5] = null; activeCommonAbilities[6] = null; activeCommonAbilities[7] = null; activeCommonAbilities[8] = null; activeCommonAbilities[9] = null; activeCommonAbilities[10] = null; activeCommonAbilities[11] = null; activeCommonAbilities[12] = null; activeCommonAbilities[13] = null; activeCommonAbilities[14] = null; activeCommonAbilities[15] = null; activeCommonAbilities[16] = null; activeCommonAbilities[17] = null; activeCommonAbilities[18] = null; activeCommonAbilities[19] = null; activeCommonAbilities[20] = null; activeCommonAbilities[21] = null; activeCommonAbilities[22] = null; activeCommonAbilities[23] = null; activeCommonAbilities[24] = null; activeCommonAbilities[25] = null; activeCommonAbilities[26] = null; activeCommonAbilities[27] = null; activeCommonAbilities[28] = null;

        //Uncommon
        activeUnCommonAbilities[0] = allUncommonAbilities[0];
        activeUnCommonAbilities[1] = allUncommonAbilities[1];
        activeUnCommonAbilities[2] = allUncommonAbilities[9];
        activeUnCommonAbilities[3] = null;
        activeUnCommonAbilities[4] = null;
        activeUnCommonAbilities[5] = null;
        activeUnCommonAbilities[6] = null;
        activeUnCommonAbilities[7] = null;
        activeUnCommonAbilities[8] = null;
        activeUnCommonAbilities[9] = null;
        activeUnCommonAbilities[10] = null;

        //Rare
        activeRareAbilities[0] = allRareAbilitites[0];
        activeRareAbilities[1] = allRareAbilitites[1];
        activeRareAbilities[2] = allRareAbilitites[4];
        activeRareAbilities[3] = allRareAbilitites[6];
        activeRareAbilities[4] = allRareAbilitites[7];
        activeRareAbilities[5] = allRareAbilitites[9];
        activeRareAbilities[6] = allRareAbilitites[10];
        activeRareAbilities[7] = null;
        activeRareAbilities[8] = null;
        activeRareAbilities[9] = null;
        activeRareAbilities[10] = null;

        //Legendary
        activeLegendaryAbilities[0] = allLegendaryAbilities[1];
        activeLegendaryAbilities[1] = allLegendaryAbilities[3];
        activeLegendaryAbilities[2] = allLegendaryAbilities[8];
        activeLegendaryAbilities[3] = allLegendaryAbilities[10];
        activeLegendaryAbilities[4] = null;
        activeLegendaryAbilities[5] = null;
        activeLegendaryAbilities[6] = null;
        activeLegendaryAbilities[7] = null;
        activeLegendaryAbilities[8] = null;
        activeLegendaryAbilities[9] = null;
        activeLegendaryAbilities[10] = null;

        eggDefense.SetActive(false);
        eggBigHeart.SetActive(false);
        eggSmallShield.SetActive(false);
        eggBouncyShield.SetActive(false);
        eggPisto.SetActive(false);
        eggUZI.SetActive(false);
        eggShotgun.SetActive(false);
        eggAWP.SetActive(false);
        eggCrossbow.SetActive(false);
        eggDeagle.SetActive(false);
        eggCannon.SetActive(false);
        eggMP4.SetActive(false);
        eggArena.SetActive(false);
        eggBoxingGlove.SetActive(false);
        eggStabbySpikes.SetActive(false);
        eggTinySpiked.SetActive(false);
        eggKnife.SetActive(false);
        eggSword.SetActive(false);
        eggRitual.SetActive(false);
        eggSawBlade.SetActive(false);
        eggHammer.SetActive(false);
        eggArrow.SetActive(false);
        eggChargedBullet.SetActive(false);
        eggPointDrop.SetActive(false);
        eggStopTime.SetActive(false);
        eggInvincibility.SetActive(false);
        eggSkullHarvest.SetActive(false);
        eggDice.SetActive(false);
    }
    #endregion

    #region SaveAndLoad
    public void LoadData(GameData data)
    {
        pointsLEVEL = data.pointsLEVEL;
        idleLEVEL = data.idleLEVEL;
        critLEVEL = data.critLEVEL;
        pointDropLEVEL = data.pointDropLEVEL;
        uziLEVEL = data.uziLEVEL;
        pistolLEVEL = data.pistolLEVEL;
        shotgunLEVEL = data.shotgunLEVEL;
        awpLEVEL = data.awpLEVEL;
        crossbowLEVEL = data.crossbowLEVEL;
        deagleLEVEL = data.deagleLEVEL;
        chargedBulletLEVEL = data.chargedBulletLEVEL;
        cannonLEVEL = data.cannonLEVEL;
        mp4LEVEL = data.mp4LEVEL;
        arrosLEVEL = data.arrosLEVEL;
        boxingloveLEVEL = data.boxingloveLEVEL;
        stabbyspikeLEVEL = data.stabbyspikeLEVEL;
        tinySpikeLEVEL = data.tinySpikeLEVEL;
        knifeLEVEL = data.knifeLEVEL;
        sawBladeLEVEL = data.sawBladeLEVEL;
        swordLEVEL = data.swordLEVEL;
        hammerLEVEL = data.hammerLEVEL;
        defenseLEVEL = data.defenseLEVEL;
        heartLEVEL = data.heartLEVEL;
        smallShieldLEVEL = data.smallShieldLEVEL;
        bouncyShieldLEVEL = data.bouncyShieldLEVEL;
        invinLEVEL = data.invinLEVEL;
        stopwatchLEVEL = data.stopwatchLEVEL;
        ritualLEVEL = data.ritualLEVEL;
        arenaLEVEL = data.arenaLEVEL;
        rerollLEVEL = data.rerollLEVEL;
        skullHarvestLEVEL = data.skullHarvestLEVEL;

        numberOfGunsCurrentRun = data.numberOfGunsCurrentRun;
        numberOfMeleeCurrentRun = data.numberOfMeleeCurrentRun;

        totalGunsAcquired = data.totalGunsAcquired;

        rerollDoubleChance = data.rerollDoubleChance;
        ritualTimer = data.ritualTimer;

        SHpointDropBasic = data.SHpointDropBasic;
        SHpointDropRarity = data.SHpointDropRarity;

        pointDropBasicPoints = data.pointDropBasicPoints;
        pointDropRarityIncreasePoints = data.pointDropRarityIncreasePoints;

        pointsFirst = data.pointsFirst;
        idleFirst = data.idleFirst;
        critFirst = data.critFirst;
        pointDropFirst = data.pointDropFirst;
        doubletapFirst = data.doubletapFirst;
        uziFirst = data.uziFirst;
        pistolFirst = data.pistolFirst;
        shotgunFirst = data.shotgunFirst;
        awpFirst = data.awpFirst;
        crossbowFirst = data.crossbowFirst;
        deagleFirst = data.deagleFirst;
        chargedBulletFirst = data.chargedBulletFirst;
        cannonFirst = data.cannonFirst;
        mp4First = data.mp4First;
        arrosFirst = data.arrosFirst;
        boxinggloveFirst = data.boxinggloveFirst;
        stabbyspikeFirst = data.stabbyspikeFirst;
        tinySpikeFirst = data.tinySpikeFirst;
        knifeFirst = data.knifeFirst;
        sawBladeFirst = data.sawBladeFirst;
        swordFirst = data.swordFirst;
        hammerFirst = data.hammerFirst;
        defenseFirst = data.defenseFirst;
        heartFirst = data.heartFirst;
        smallShieldFirst = data.smallShieldFirst;
        bouncyShieldFirst = data.bouncyShieldFirst;
        invinFirst = data.invinFirst;
        stopwatchFirst = data.stopwatchFirst;
        boosterFirst = data.boosterFirst;
        rocketFirst = data.rocketFirst;
        talariaFirst = data.talariaFirst;
        random2First = data.random2First;
        random3First = data.random3First;
        random5First = data.random5First;
        ritualFirst = data.ritualFirst;
        eggFirst = data.eggFirst;
        arenaFirst = data.arenaFirst;
        abiltites4XFirst = data.abiltites4XFirst;
        rerollRareFirst = data.rerollRareFirst;
        abilities5XFirst = data.abilities5XFirst;
        rerollLegendaryFirst = data.rerollLegendaryFirst;
        skullHarvestFirst = data.skullHarvestFirst;

        assassinFirstTime = data.assassinFirstTime;
        speedsterFirstTime = data.speedsterFirstTime;
        sharpshooterFirstTime = data.sharpshooterFirstTime;
        sniperFirstTime = data.sniperFirstTime;
        heavyshotFirstTime = data.heavyshotFirstTime;
        ragingGunnerFirstTime = data.ragingGunnerFirstTime;
        bruteFirstTime = data.bruteFirstTime;
        titanFirstTime = data.titanFirstTime;

        skullHarvestChosenFirstTime = data.skullHarvestChosenFirstTime;

        maxAssasins = data.maxAssasins;
        maxSpeedsters = data.maxSpeedsters;
        maxSharpshooters = data.maxSharpshooters;
        maxSnipers = data.maxSnipers;
        maxHeavyshots = data.maxHeavyshots;
        maxBrutes = data.maxBrutes;
        maxRagingGunners = data.maxRagingGunners;
        maxTitans = data.maxTitans;

        totalIdlePoints = data.totalIdlePoints;

        numberOfEnemiesActive = data.numberOfEnemiesActive;

        firstControlledGun = data.firstControlledGun;

        smallShieldUpgradeCount = data.smallShieldUpgradeCount;
        stabbySpikeUpgradeCount = data.stabbySpikeUpgradeCount;
        sawBladeUpgradeCount = data.sawBladeUpgradeCount;
        bouncyShieldUpgradeCount = data.bouncyShieldUpgradeCount;
        swordUpgradeCount = data.swordUpgradeCount;

        firstTimeGun = data.firstTimeGun;
        choseRitual = data.choseRitual;

        eggPointPerClickChosen = data.eggPointPerClickChosen;
        eggCritclickChosen = data.eggCritclickChosen;
        eggIdleClickChosen = data.eggIdleClickChosen;
        eggDefenseChosen = data.eggDefenseChosen;
        eggBigHeartChosen = data.eggBigHeartChosen;
        eggSmallShieldChosen = data.eggSmallShieldChosen;
        eggBouncyShieldChosen = data.eggBouncyShieldChosen;
        eggPistolChosen = data.eggPistolChosen;
        eggUziChosen = data.eggUziChosen;
        eggShotgunChosen = data.eggShotgunChosen;
        eggAWPChosen = data.eggAWPChosen;
        eggCrossbowChosen = data.eggCrossbowChosen;
        eggDeagleChosen = data.eggDeagleChosen;
        eggCannonChosen = data.eggCannonChosen;
        eggMP4Chosen = data.eggMP4Chosen;
        eggArenaChosen = data.eggArenaChosen;
        eggBoxingGloveChosen = data.eggBoxingGloveChosen;
        eggStabbySpikeChosen = data.eggStabbySpikeChosen;
        eggTinySpikeChosen = data.eggTinySpikeChosen;
        eggKnifeChosen = data.eggKnifeChosen;
        eggSwordChosen = data.eggSwordChosen;
        eggRitualChosen = data.eggRitualChosen;
        eggSawBladeChose = data.eggSawBladeChose;
        eggHammerChosen = data.eggHammerChosen;
        eggArrowChosen = data.eggArrowChosen;
        eggChagedBulletsChosen = data.eggChagedBulletsChosen;
        eggPointDropChosen = data.eggPointDropChosen;
        eggStopwatchChosen = data.eggStopwatchChosen;
        eggInvinChosen = data.eggInvinChosen;
        eggSkullHarvestChosen = data.eggSkullHarvestChosen;
        eggDiceChose = data.eggDiceChose;
        choseUnlimitedPower = data.choseUnlimitedPower;

        SHmaxHealth = data.SHmaxHealth;
        SHregen = data.SHregen;
        SHbigHEarHP = data.SHbigHEarHP;
        SHsmallShieldHP = data.SHsmallShieldHP;
        SHsmallShieldRecharge = data.SHsmallShieldRecharge;
        SHbounceHP = data.SHbounceHP;
        SHbouncyRecharge = data.SHbouncyRecharge;
        SHboxingForce = data.SHboxingForce;
        SHstabbyDamage = data.SHstabbyDamage;
        SHtinySpikeDamage = data.SHtinySpikeDamage;
        SHknifeDamage = data.SHknifeDamage;
        SHsawBladeDamage = data.SHsawBladeDamage;
        SHsawbladeSpeed = data.SHsawbladeSpeed;
        SHswordSpeed = data.SHswordSpeed;
        SHswordDamage = data.SHswordDamage;
        SHhammerDamage = data.SHhammerDamage;
        SHhammerStunTime = data.SHhammerStunTime;
        SHinvinTime = data.SHinvinTime;
        SHstopwatchTime = data.SHstopwatchTime;
        skullsConsumedCount = data.skullsConsumedCount;
        SHpointPerClick = data.SHpointPerClick;
        SHcritChance = data.SHcritChance;
        SHcritIncrease = data.SHcritIncrease;
        SHidleClicks = data.SHidleClicks;
        SHuziSpeed = data.SHuziSpeed;
        SHuziDamage = data.SHuziDamage;
        SHpistolSpeed = data.SHpistolSpeed;
        SHPistolDamage = data.SHPistolDamage;
        SHshotgunSpeed = data.SHshotgunSpeed;
        SHshotgunDamage = data.SHshotgunDamage;
        SHawpSpeed = data.SHawpSpeed;
        SHawpDamage = data.SHawpDamage;
        SHcrossbowSpeed = data.SHcrossbowSpeed;
        SHcrossbowDamage = data.SHcrossbowDamage;
        SHdeagleSpeed = data.SHdeagleSpeed;
        SHdeagleDamage = data.SHdeagleDamage;
        SHcannonSpeed = data.SHcannonSpeed;
        SHcannonDamage = data.SHcannonDamage;
        SHmp4Speed = data.SHmp4Speed;
        SHmp4Damage = data.SHmp4Damage;
        SHchargeBulletTime = data.SHchargeBulletTime;
        SHchargeBulletDamage = data.SHchargeBulletDamage;
        SHarrowDamage = data.SHarrowDamage;

        skullHarvestStatDivide = data.skullHarvestStatDivide;

        smallEnemySpawnTimer = data.smallEnemySpawnTimer;
        speedsterSpawnTimer = data.speedsterSpawnTimer;
        sharpshooterSpawnTimer = data.sharpshooterSpawnTimer;
        sniperSpawnTimer = data.sniperSpawnTimer;
        heavyShotSpawnTiner = data.heavyShotSpawnTiner;
        ragingGunnerSpawnTimer = data.ragingGunnerSpawnTimer;
        titanSpawnTimer = data.titanSpawnTimer;
        bigEnemySpawnTimer = data.bigEnemySpawnTimer;

        commonChance = data.commonChance;
        uncommonChance = data.uncommonChance;
        rareChance = data.rareChance;
        legendaryChance = data.legendaryChance;
        regenHealth = data.regenHealth;
        invincibilityTimeAdded = data.invincibilityTimeAdded;
        smallShieldRechargeTimer = data.smallShieldRechargeTimer;
        smallShieldRotateSpeed = data.smallShieldRotateSpeed;
        smallShieldHP = data.smallShieldHP;
        ritualClicksNeeded = data.ritualClicksNeeded;

        chargedBulletMaxDamage = data.chargedBulletMaxDamage;
        chargedBulletChargeTime = data.chargedBulletChargeTime;
        chargedBulletsCount = data.chargedBulletsCount;

        mp4ClicksNeeded = data.mp4ClicksNeeded;
        spawnMoreSmallEnemiesTimer = data.spawnMoreSmallEnemiesTimer;
        spawnMoreSpeedsterTimer = data.spawnMoreSpeedsterTimer;
        spawnMoreSharpshooterTimer = data.spawnMoreSharpshooterTimer;
        spawnMoreSniperTimer = data.spawnMoreSniperTimer;
        spawnMoreHeavyShotTimer = data.spawnMoreHeavyShotTimer;
        spawnMoreRagingGunnerTimer = data.spawnMoreRagingGunnerTimer;
        spawnMoreBruteTimer = data.spawnMoreBruteTimer;
        spawnMoreTitanTimer = data.spawnMoreTitanTimer;

        bigHeartHPHeal = data.bigHeartHPHeal;
        bigHeartClicksNeeded = data.bigHeartClicksNeeded;
        knifeTotalCount = data.knifeTotalCount;
        firstShootingEnemyChose = data.firstShootingEnemyChose;
        choseSmallShields = data.choseSmallShields;
        firstWeaponChosen = data.firstWeaponChosen;

        commonAbilitesNotAviable = data.commonAbilitesNotAviable;
        unCommonAbilitesNotAviable = data.unCommonAbilitesNotAviable;
        rareAbilitesNotAviable = data.rareAbilitesNotAviable;
        legendaryAbilitiesNotAvailable = data.legendaryAbilitiesNotAvailable;

        commonAbilitiesAviable = data.commonAbilitiesAviable;
        unCommonAbilitiesAviable = data.unCommonAbilitiesAviable;
        rareAbilitiesAviable = data.rareAbilitiesAviable;
        legendaryAbilitiesAviable = data.legendaryAbilitiesAviable;

        firstTimeEndingShowedUp = data.firstTimeEndingShowedUp;

        chose_Gun1 = data.savedPistol;
        chose_gun2 = data.savedShotgun;
        choseGunMp4 = data.savedMp4;
        choseCrossBow = data.savedCrossbow;
        choseShootSmallBullets = data.savedUzi;
        chooseBigPiercingBulletGun = data.savedCannon;
        chooseHomingBullets = data.savedHomingGun;
        choseTrippleShot = data.savedTrippleShot;

        choseSkullHarvest = data.choseSkullHarvest;
        chosePointsDrop = data.chosePointsDrop;
        randomUncommonPointsDrop = data.randomUncommonPointsDrop;
        randomRarePointDrop = data.randomRarePointDrop;
        randomLegendaryPointDrop = data.randomLegendaryPointDrop;
        randomMythicPointDrop = data.randomMythicPointDrop;

        choseButtonCharge = data.choseButtonCharge;
        choseArrows = data.choseArrows;
        arrowCountShot = data.arrowCountShot;
        arrowClicksNeeded = data.arrowClicksNeeded;
        chargedBulletDamageIncrement = data.chargedBulletDamageIncrement;
        buttonChargePerSecond = data.buttonChargePerSecond;
        arrowDamage = data.arrowDamage;

        movementAbilityAquaried = data.movementAbilityAquaried;
        chooseRocket = data.chooseRocket;
        choseButtonBounceCharge = data.choseButtonBounceCharge;
        chooseControllableButton = data.chooseControllableButton;

        choseBouncingBullets = data.choseBouncingBullets;
        choseStopTime = data.choseStopTime;
        arenaSpawnPointChangeY = data.arenaSpawnPointChangeY;
        arenaSpawnPointChangeX = data.arenaSpawnPointChangeX;
        hordeStartCameraSize = data.hordeStartCameraSize;
        arenaIncrease = data.arenaIncrease;

        choseStopTime = data.choseStopTime;
        choseInvincibility = data.choseInvincibility;
        stopTimeTimer = data.stopTimeTimer;
        invincibilityTimer = data.invincibilityTimer;
        stopTimeClickTotal = data.stopTimeClickTotal;
        invincibilityClickPer1Second = data.invincibilityClickPer1Second;

        choseHealthBar = data.choseHealthBar;
        chooseHeartCollect = data.chooseHeartCollect;
        choseShield_BounceOff = data.choseShield_BounceOff;
        maxButtonHealth = data.maxButtonHealth;
        healthRegenPerSecond = data.healthRegenPerSecond;
        shieldBounce_RotateSpeed = data.shieldBounce_RotateSpeed;
        reChargeTimer = data.shieldBounce_ReChargeTimer;
        shieldBounce_health = data.shieldBounce_health;

        smallEnemySpawn = data.smallEnemySpawn;
        speedsterSpawn = data.speedsterSpawn; 
        shootingEnemySpawn = data.sharpshooterSpawn;
        sniperSpawn = data.sniperSpawn;
        ragingGunnerSpawn = data.ragingGunnerSpawn;
        heavyShotSpawn = data.heavyShotSpawn;
        bigEnemySpawn = data.bruteSpawn;
        titanSpawn = data.titanSpawn;

        smallEnemySpeed = data.smallEneySpeed;
        speedsterSpeed = data.speedsterSpeed;
        sharpshooterSpeed = data.sharpshooterSpeed;
        sniperSpeed = data.sniperSpeed;
        ragingGunnerSpeed = data.ragingGunnerSpeed;
        heavyShotSpeed = data.heavyshotSpeed;
        bruteSpeed = data.bruteSpeed;
        titanSpeed = data.titanSpeed;

        smallEnemyHP = data.smallEnemyHP;
        speedsterHP = data.speedsterHP;
        sharpshooterHP = data.sharpshooterHP;
        sniperHP = data.sniperHP;
        ragingGunnerHP = data.ragingGunnerHP;
        heavyshotHP = data.heavyShotHP;
        bruteHP = data.bruteHP;
        titanHP = data.titanHP;

        smallEnemyPoints = data.smallEnemyPoints;
        speedsterPoints = data.speedsterPoints;
        shootingEnemyPoints = data.sharpshooterPoints;
        sniperPoints = data.sniperPoints;
        raginGunnerPoints = data.ragingGunnerPoints;
        heavyShotPoints = data.heavyShotPoints;
        bigEnemyPoint = data.brutePoints;
        titanPoints = data.titanPoints;

        smallEnemyDamage = data.smallEnemyDamage;
        speedsterDamagePerSecond = data.speedsterDamage;
        smallEnemyBulletDamage = data.sharpshooterDamage;
        sniperEnemyBulletDamage = data.sniperDamage;
        raginGunnerMeleeDamage = data.ragingGunnerMeleeDamage;
        raginGunnerBulletDamage = data.ragingGunnerRangedDamage;
        heavyShotDamage = data.heavyShotDamage;
        bruteDamage = data.bruteDamage;
        titanDamage = data.titanDamage;

        chooseBigSpike = data.chooseBigSpike;
        chooseSpikes = data.chooseSpiked;
        chooseStabbingSpikes = data.chooseStabbingSpikes;
        choseBoxingGlove = data.choseBoxingGlove;
        chooseSawBlade = data.chooseSawBlade;
        chooseHammer = data.chooseHammer;
        choseSpinningKnifes = data.choseSpinningKnifes;

        bigSpikeDamage = data.bigSpikeDamage;
        stabbingSpikeDamage = data.stabbingSpikeDamage;
        hammerClicksNeeded = data.hammerClicksNeeded;
        knifeClicksNeeded = data.knifeClicksNeeded;
        stabbingSpikesClicksNeeded = data.stabbingSpikesClicksNeeded;

        swordSpeed = data.swordSpeed;
        spikeDamagePerSecond = data.spikeDamagePerSecond;
        boxingGloveKnockbackAmount = data.boxingGloveKnockbackAmount;
        boxingGloveClicksNeeded = data.boxingGloveClicksNeeded;
        sawBladeSpeed = data.sawBladeSpeed;
        sawBladeDamage = data.sawBladeDamage;
        hammerDamage = data.hammerDamage;
        hammerStunTime = data.hammerStunTime;
        knifeDamage = data.knifeDamage;
        knifeSpeed = data.knifeSpeed;

        critClicksBonus = data.critClicksBonus;
        choseCritClicks = data.choseCritClicks;
        choseIdleClicking = data.choseIdleClicking;
        choseReroll = data.choseReroll;
        choseDoubleTap = data.choseDoubleTap;
        critClicksChance = data.critClicksChance;
        timeBetweenClicks = data.timeBetweenClicks;
        numberOfChoises = data.numberOfChoises;
        rerollClicksNeeded = data.rerollClicksNeeded;
        rerollsAviable = data.rerollsAviable;

        bulletGun1_DeSpawnTime = data.pistolDeSpawnTime;
        shotGunBulletDeSpawnTime1 = data.shotgunDeSpawnTime;
        mp4DespawnTime = data.mp4DeSpawnTime;
        bigBulletLastTime = data.cannonDeSpawnTime;
        smallBulletDeSpawnTime = data.uziDeSpawnTime;

        shotGunBullets = data.shotGunBullets;
        bulletGun1_Speed = data.pistolSpeed;
        shotGunBulletSpeed1 = data.shotgunSpeed1;
        shotGunBulletSpeed2 = data.shotgunSpeed2;
        mp4Speed = data.mp4Speed;
        crossbowSpeed = data.crossbowSpeed;
        trippleShotSpeed = data.trippleSpeed;
        bigBulletSpeed = data.cannonSpeed;
        homignBulletSpeed = data.homingSpeed;
        smallBulletSpeed = data.uziSpeed;

        pistolClicksNeeded = data.clicksPerPistol;
        shotGunClicksNeeded = data.clicksPerShotgun;
        crossbowClicksNeeded = data.clicksPerCrossbow;
        trippleShotNeeded = data.clicksPerTripple;
        clicksPerBigBullet = data.clicksPerCannon;
        clicksPerHomingBullet = data.clicksPerHoming;
        clickPerSmallBullet = data.clicksPerUzi;

        bulletGun1_Damage = data.pistolDamage;
        shotGunBulletDamage = data.shotgunDamage1;
        shotGunBulletDamage2 = data.shotgunDamage2;
        mp4Damage = data.mp4Damage;
        crossbowDamage = data.crossbowDamage;
        trippleShotDamage = data.trippleDamage;
        bigBulletDamage = data.cannonDamage;
        homingBulletDamage = data.homingDamage;
        smallBulletDamage = data.uziDamage;

        arenaUpgradeCount = data.arenaUpgradeCount;
    }

    public void SaveData(ref GameData data)
    {
        data.pointsLEVEL = pointsLEVEL;
        data.idleLEVEL = idleLEVEL;
        data.critLEVEL = critLEVEL;
        data.pointDropLEVEL = pointDropLEVEL;
        data.uziLEVEL = uziLEVEL;
        data.pistolLEVEL = pistolLEVEL;
        data.shotgunLEVEL = shotgunLEVEL;
        data.awpLEVEL = awpLEVEL;
        data.crossbowLEVEL = crossbowLEVEL;
        data.deagleLEVEL = deagleLEVEL;
        data.chargedBulletLEVEL = chargedBulletLEVEL;
        data.cannonLEVEL = cannonLEVEL;
        data.mp4LEVEL = mp4LEVEL;
        data.arrosLEVEL = arrosLEVEL;
        data.boxingloveLEVEL = boxingloveLEVEL;
        data.stabbyspikeLEVEL = stabbyspikeLEVEL;
        data.tinySpikeLEVEL = tinySpikeLEVEL;
        data.knifeLEVEL = knifeLEVEL;
        data.sawBladeLEVEL = sawBladeLEVEL;
        data.swordLEVEL = swordLEVEL;
        data.hammerLEVEL = hammerLEVEL;
        data.defenseLEVEL = defenseLEVEL;
        data.heartLEVEL = heartLEVEL;
        data.smallShieldLEVEL = smallShieldLEVEL;
        data.bouncyShieldLEVEL = bouncyShieldLEVEL;
        data.invinLEVEL = invinLEVEL;
        data.stopwatchLEVEL = stopwatchLEVEL;
        data.ritualLEVEL = ritualLEVEL;
        data.arenaLEVEL = arenaLEVEL;
        data.rerollLEVEL = rerollLEVEL;
        data.skullHarvestLEVEL = skullHarvestLEVEL;

        data.numberOfGunsCurrentRun = numberOfGunsCurrentRun;
        data.numberOfMeleeCurrentRun = numberOfMeleeCurrentRun;

        data.totalGunsAcquired = totalGunsAcquired;

        data.ritualTimer = ritualTimer;

        data.SHpointDropBasic = SHpointDropBasic;
        data.SHpointDropRarity = SHpointDropRarity;

        data.pointDropBasicPoints = pointDropBasicPoints;
        data.pointDropRarityIncreasePoints = pointDropRarityIncreasePoints;

        data.pointsFirst = pointsFirst;
        data.idleFirst = idleFirst;
        data.critFirst = critFirst;
        data.pointDropFirst = pointDropFirst;
        data.doubletapFirst = doubletapFirst;
        data.uziFirst = uziFirst;
        data.pistolFirst = pistolFirst;
        data.shotgunFirst = shotgunFirst;
        data.awpFirst = awpFirst;
        data.crossbowFirst = crossbowFirst;
        data.deagleFirst = deagleFirst;
        data.chargedBulletFirst = chargedBulletFirst;
        data.cannonFirst = cannonFirst;
        data.mp4First = mp4First;
        data.arrosFirst = arrosFirst;
        data.boxinggloveFirst = boxinggloveFirst;
        data.stabbyspikeFirst = stabbyspikeFirst;
        data.tinySpikeFirst = tinySpikeFirst;
        data.knifeFirst = knifeFirst;
        data.sawBladeFirst = sawBladeFirst;
        data.swordFirst = swordFirst;
        data.hammerFirst = hammerFirst;
        data.defenseFirst = defenseFirst;
        data.heartFirst = heartFirst;
        data.smallShieldFirst = smallShieldFirst;
        data.bouncyShieldFirst = bouncyShieldFirst;
        data.invinFirst = invinFirst;
        data.stopwatchFirst = stopwatchFirst;
        data.boosterFirst = boosterFirst;
        data.rocketFirst = rocketFirst;
        data.talariaFirst = talariaFirst;
        data.random2First = random2First;
        data.random3First = random3First;
        data.random5First = random5First;
        data.ritualFirst = ritualFirst;
        data.eggFirst = eggFirst;
        data.arenaFirst = arenaFirst;
        data.abiltites4XFirst = abiltites4XFirst;
        data.rerollRareFirst = rerollRareFirst;
        data.abilities5XFirst = abilities5XFirst;
        data.rerollLegendaryFirst = rerollLegendaryFirst;
        data.skullHarvestFirst = skullHarvestFirst;

        data.assassinFirstTime = assassinFirstTime;
        data.speedsterFirstTime = speedsterFirstTime;
        data.sharpshooterFirstTime = sharpshooterFirstTime;
        data.sniperFirstTime = sniperFirstTime;
        data.heavyshotFirstTime = heavyshotFirstTime;
        data.ragingGunnerFirstTime = ragingGunnerFirstTime;
        data.bruteFirstTime = bruteFirstTime;
        data.titanFirstTime = titanFirstTime;

        data.skullHarvestChosenFirstTime = skullHarvestChosenFirstTime;

        data.maxAssasins = maxAssasins;
        data.maxSpeedsters = maxSpeedsters;
        data.maxSharpshooters = maxSharpshooters;
        data.maxSnipers = maxSnipers;
        data.maxHeavyshots = maxHeavyshots;
        data.maxBrutes = maxBrutes;
        data.maxRagingGunners = maxRagingGunners;
        data.maxTitans = maxTitans;

        data.totalIdlePoints = totalIdlePoints;

        data.numberOfEnemiesActive = numberOfEnemiesActive;

        data.firstControlledGun = firstControlledGun;

        data.smallShieldUpgradeCount = smallShieldUpgradeCount;
        data.stabbySpikeUpgradeCount = stabbySpikeUpgradeCount;
        data.sawBladeUpgradeCount = sawBladeUpgradeCount;
        data.bouncyShieldUpgradeCount = bouncyShieldUpgradeCount;
        data.swordUpgradeCount = swordUpgradeCount;

        data.firstTimeGun = firstTimeGun;
        data.choseRitual = choseRitual;

        data.eggPointPerClickChosen = eggPointPerClickChosen;
        data.eggCritclickChosen = eggCritclickChosen;
        data.eggIdleClickChosen = eggIdleClickChosen;
        data.eggDefenseChosen = eggDefenseChosen;
        data.eggBigHeartChosen = eggBigHeartChosen;
        data.eggSmallShieldChosen = eggSmallShieldChosen;
        data.eggBouncyShieldChosen = eggBouncyShieldChosen;
        data.eggPistolChosen = eggPistolChosen;
        data.eggUziChosen = eggUziChosen;
        data.eggShotgunChosen = eggShotgunChosen;
        data.eggAWPChosen = eggAWPChosen;
        data.eggCrossbowChosen = eggCrossbowChosen;
        data.eggDeagleChosen = eggDeagleChosen;
        data.eggCannonChosen = eggCannonChosen;
        data.eggMP4Chosen = eggMP4Chosen;
        data.eggArenaChosen = eggArenaChosen;
        data.eggBoxingGloveChosen = eggBoxingGloveChosen;
        data.eggStabbySpikeChosen = eggStabbySpikeChosen;
        data.eggTinySpikeChosen = eggTinySpikeChosen;
        data.eggKnifeChosen = eggKnifeChosen;
        data.eggSwordChosen = eggSwordChosen;
        data.eggRitualChosen = eggRitualChosen;
        data.eggSawBladeChose = eggSawBladeChose;
        data.eggHammerChosen = eggHammerChosen;
        data.eggArrowChosen = eggArrowChosen;
        data.eggChagedBulletsChosen = eggChagedBulletsChosen;
        data.eggPointDropChosen = eggPointDropChosen;
        data.eggStopwatchChosen = eggStopwatchChosen;
        data.eggInvinChosen = eggInvinChosen;
        data.eggSkullHarvestChosen = eggSkullHarvestChosen;
        data.eggDiceChose = eggDiceChose;
        data.choseUnlimitedPower = choseUnlimitedPower;

        data.SHmaxHealth = SHmaxHealth;
        data.SHregen = SHregen;
        data.SHbigHEarHP = SHbigHEarHP;
        data.SHsmallShieldHP = SHsmallShieldHP;
        data.SHsmallShieldRecharge = SHsmallShieldRecharge;
        data.SHbounceHP = SHbounceHP;
        data.SHbouncyRecharge = SHbouncyRecharge;
        data.SHboxingForce = SHboxingForce;
        data.SHstabbyDamage = SHstabbyDamage;
        data.SHtinySpikeDamage = SHtinySpikeDamage;
        data.SHknifeDamage = SHknifeDamage;
        data.SHsawBladeDamage = SHsawBladeDamage;
        data.SHsawbladeSpeed = SHsawbladeSpeed;
        data.SHswordSpeed = SHswordSpeed;
        data.SHswordDamage = SHswordDamage;
        data.SHhammerDamage = SHhammerDamage;
        data.SHhammerStunTime = SHhammerStunTime;
        data.SHinvinTime = SHinvinTime;
        data.SHstopwatchTime = SHstopwatchTime;
        data.skullsConsumedCount = skullsConsumedCount;
        data.SHpointPerClick = SHpointPerClick;
        data.SHcritChance = SHcritChance;
        data.SHcritIncrease = SHcritIncrease;
        data.SHidleClicks = SHidleClicks;
        data.SHuziSpeed = SHuziSpeed;
        data.SHuziDamage = SHuziDamage;
        data.SHpistolSpeed = SHpistolSpeed;
        data.SHPistolDamage = SHPistolDamage;
        data.SHshotgunSpeed = SHshotgunSpeed;
        data.SHshotgunDamage = SHshotgunDamage;
        data.SHawpSpeed = SHawpSpeed;
        data.SHawpDamage = SHawpDamage;
        data.SHcrossbowSpeed = SHcrossbowSpeed;
        data.SHcrossbowDamage = SHcrossbowDamage;
        data.SHdeagleSpeed = SHdeagleSpeed;
        data.SHdeagleDamage = SHdeagleDamage;
        data.SHcannonSpeed = SHcannonSpeed;
        data.SHcannonDamage = SHcannonDamage;
        data.SHmp4Speed = SHmp4Speed;
        data.SHmp4Damage = SHmp4Damage;
        data.SHchargeBulletTime = SHchargeBulletTime;
        data.SHchargeBulletDamage = SHchargeBulletDamage;
        data.SHarrowDamage = SHarrowDamage;

        data.skullHarvestStatDivide = skullHarvestStatDivide;

        data.commonChance = commonChance;
        data.uncommonChance = uncommonChance;
        data.rareChance = rareChance;
        data.legendaryChance = legendaryChance;
        data.regenHealth = regenHealth;
        data.invincibilityTimeAdded = invincibilityTimeAdded;
        data.smallShieldRechargeTimer = smallShieldRechargeTimer;
        data.smallShieldRotateSpeed = smallShieldRotateSpeed;
        data.smallShieldHP = smallShieldHP;
        data.ritualClicksNeeded = ritualClicksNeeded;

        data.chargedBulletMaxDamage = chargedBulletMaxDamage;
        data.chargedBulletChargeTime = chargedBulletChargeTime;
        data.chargedBulletsCount = chargedBulletsCount;

        data.mp4ClicksNeeded = mp4ClicksNeeded;
        data.spawnMoreSmallEnemiesTimer = spawnMoreSmallEnemiesTimer;
        data.spawnMoreSpeedsterTimer = spawnMoreSpeedsterTimer;
        data.spawnMoreSharpshooterTimer = spawnMoreSharpshooterTimer;
        data.spawnMoreSniperTimer = spawnMoreSniperTimer;
        data.spawnMoreHeavyShotTimer = spawnMoreHeavyShotTimer;
        data.spawnMoreRagingGunnerTimer = spawnMoreRagingGunnerTimer;
        data.spawnMoreBruteTimer = spawnMoreBruteTimer;
        data.spawnMoreTitanTimer = spawnMoreTitanTimer;

        data.bigHeartHPHeal = bigHeartHPHeal;
        data.bigHeartClicksNeeded = bigHeartClicksNeeded;
        data.knifeTotalCount = knifeTotalCount;
        data.firstShootingEnemyChose = firstShootingEnemyChose;
        data.choseSmallShields = choseSmallShields;
        data.firstWeaponChosen = firstWeaponChosen;

        data.commonAbilitesNotAviable = commonAbilitesNotAviable;
        data.unCommonAbilitesNotAviable = unCommonAbilitesNotAviable;
        data.rareAbilitesNotAviable = rareAbilitesNotAviable;
        data.legendaryAbilitiesNotAvailable = legendaryAbilitiesNotAvailable;

        data.commonAbilitiesAviable = commonAbilitiesAviable;
        data.unCommonAbilitiesAviable = unCommonAbilitiesAviable;
        data.rareAbilitiesAviable = rareAbilitiesAviable;
        data.legendaryAbilitiesAviable = legendaryAbilitiesAviable;

        data.firstTimeEndingShowedUp = firstTimeEndingShowedUp;

        data.savedPistol = chose_Gun1;
        data.savedShotgun = chose_gun2;
        data.savedMp4 = choseGunMp4;
        data.savedCrossbow = choseCrossBow;
        data.savedUzi = choseShootSmallBullets;
        data.savedCannon = chooseBigPiercingBulletGun;
        data.savedHomingGun = chooseHomingBullets;
        data.savedTrippleShot = choseTrippleShot;

        data.choseSkullHarvest = choseSkullHarvest;
        data.chosePointsDrop = chosePointsDrop;
        data.randomUncommonPointsDrop = randomUncommonPointsDrop;
        data.randomRarePointDrop = randomRarePointDrop;
        data.randomLegendaryPointDrop = randomLegendaryPointDrop;
        data.randomMythicPointDrop =randomMythicPointDrop;

        data.choseButtonCharge = choseButtonCharge;
        data.choseArrows = choseArrows;
        data.arrowCountShot = arrowCountShot;
        data.arrowClicksNeeded = arrowClicksNeeded;
        data.chargedBulletDamageIncrement = chargedBulletDamageIncrement;
        data.buttonChargePerSecond = buttonChargePerSecond;
        data.arrowDamage = arrowDamage;

        data.movementAbilityAquaried = movementAbilityAquaried;
        data.chooseRocket = chooseRocket;
        data.choseButtonBounceCharge = choseButtonBounceCharge;
        data.chooseControllableButton = chooseControllableButton;

        data.choseBouncingBullets = choseBouncingBullets;
        data.choseStopTime = choseStopTime;
        data.arenaSpawnPointChangeY = arenaSpawnPointChangeY;
        data.arenaSpawnPointChangeX = arenaSpawnPointChangeX;
        data.hordeStartCameraSize = hordeStartCameraSize;
        data.arenaIncrease = arenaIncrease;

        data.choseStopTime = choseStopTime;
        data.choseInvincibility = choseInvincibility;
        data.stopTimeTimer = stopTimeTimer;
        data.invincibilityTimer = invincibilityTimer;
        data.stopTimeClickTotal = stopTimeClickTotal;
        data.invincibilityClickPer1Second = invincibilityClickPer1Second;

        data.choseHealthBar = choseHealthBar;
        data.chooseHeartCollect = chooseHeartCollect;
        data.choseShield_BounceOff = choseShield_BounceOff;
        data.maxButtonHealth = maxButtonHealth;
        data.healthRegenPerSecond = healthRegenPerSecond;
        data.shieldBounce_RotateSpeed = shieldBounce_RotateSpeed;
        data.shieldBounce_ReChargeTimer = reChargeTimer;
        data.shieldBounce_health = shieldBounce_health;

        data.smallEnemySpawn = smallEnemySpawn;
        data.speedsterSpawn = speedsterSpawn;
        data.sharpshooterSpawn = shootingEnemySpawn;
        data.sniperSpawn = sniperSpawn;
        data.ragingGunnerSpawn = ragingGunnerSpawn;
        data.heavyShotSpawn = heavyShotSpawn;
        data.bruteSpawn = bigEnemySpawn;
        data.titanSpawn = titanSpawn;

        data.smallEneySpeed = smallEnemySpeed;
        data.speedsterSpeed = speedsterSpeed;
        data.sharpshooterSpeed = sharpshooterSpeed;
        data.sniperSpeed = sniperSpeed;
        data.ragingGunnerSpeed = ragingGunnerSpeed;
        data.heavyshotSpeed = heavyShotSpeed;
        data.bruteSpeed = bruteSpeed;
        data.titanSpeed = titanSpeed;

        data.smallEnemyHP = smallEnemyHP;
        data.speedsterHP = speedsterHP;
        data.sharpshooterHP = sharpshooterHP;
        data.sniperHP = sniperHP;
        data.ragingGunnerHP = ragingGunnerHP;
        data.heavyShotHP = heavyshotHP;
        data.bruteHP = bruteHP;
        data.titanHP = titanHP;

        data.smallEnemySpawnTimer = smallEnemySpawnTimer;
        data.speedsterSpawnTimer = speedsterSpawnTimer;
        data.sharpshooterSpawnTimer =sharpshooterSpawnTimer;
        data.sniperSpawnTimer = sniperSpawnTimer;
        data.heavyShotSpawnTiner = heavyShotSpawnTiner;
        data.ragingGunnerSpawnTimer = ragingGunnerSpawnTimer;
        data.titanSpawnTimer = titanSpawnTimer;
        data.bigEnemySpawnTimer = bigEnemySpawnTimer;

        data.smallEnemyPoints = smallEnemyPoints;
        data.speedsterPoints = speedsterPoints;
        data.sharpshooterPoints = shootingEnemyPoints;
        data.sniperPoints = sniperPoints;
        data.ragingGunnerPoints = raginGunnerPoints;
        data.heavyShotPoints = heavyShotPoints;
        data.brutePoints = bigEnemyPoint;
        data.titanPoints = titanPoints;

        data.smallEnemyDamage = smallEnemyDamage;
        data.speedsterDamage = speedsterDamagePerSecond;
        data.sharpshooterDamage = smallEnemyBulletDamage;
        data.sniperDamage = sniperEnemyBulletDamage;
        data.ragingGunnerMeleeDamage = raginGunnerMeleeDamage;
        data.ragingGunnerRangedDamage = raginGunnerBulletDamage;
        data.heavyShotDamage = heavyShotDamage; 
        data.bruteDamage = bruteDamage;
        data.titanDamage = titanDamage;

        data.chooseBigSpike = chooseBigSpike;
        data.chooseSpiked = chooseSpikes;
        data.chooseStabbingSpikes = chooseStabbingSpikes;
        data.choseBoxingGlove = choseBoxingGlove;
        data.chooseSawBlade = chooseSawBlade;
        data.chooseHammer = chooseHammer;
        data.choseSpinningKnifes = choseSpinningKnifes;

        data.bigSpikeDamage = bigSpikeDamage;
        data.stabbingSpikeDamage = stabbingSpikeDamage;
        data.hammerClicksNeeded = hammerClicksNeeded;
        data.knifeClicksNeeded = knifeClicksNeeded;
        data.stabbingSpikesClicksNeeded = stabbingSpikesClicksNeeded;

        data.swordSpeed = swordSpeed;
        data.spikeDamagePerSecond = spikeDamagePerSecond;
        data.boxingGloveKnockbackAmount = boxingGloveKnockbackAmount;
        data.boxingGloveClicksNeeded = boxingGloveClicksNeeded;
        data.sawBladeSpeed = sawBladeSpeed;
        data.sawBladeDamage = sawBladeDamage;
        data.hammerDamage = hammerDamage;
        data.hammerStunTime = hammerStunTime;
        data.knifeDamage = knifeDamage;
        data.knifeSpeed = knifeSpeed;

        data.critClicksBonus = critClicksBonus;
        data.choseCritClicks = choseCritClicks;
        data.choseIdleClicking = choseIdleClicking;
        data.choseReroll = choseReroll;
        data.choseDoubleTap = choseDoubleTap;
        data.critClicksChance = critClicksChance;
        data.timeBetweenClicks = timeBetweenClicks;
        data.numberOfChoises = numberOfChoises;
        data.rerollClicksNeeded = rerollClicksNeeded;
        data.rerollDoubleChance = rerollDoubleChance;
        data.rerollsAviable = rerollsAviable;

        data.pistolDeSpawnTime = bulletGun1_DeSpawnTime;
        data.shotgunDeSpawnTime = shotGunBulletDeSpawnTime1;
        data.mp4DeSpawnTime = mp4DespawnTime;
        data.cannonDeSpawnTime = bigBulletLastTime;
        data.uziDeSpawnTime = smallBulletDeSpawnTime;

        data.shotGunBullets = shotGunBullets;
        data.pistolSpeed = bulletGun1_Speed;
        data.shotgunSpeed1 = shotGunBulletSpeed1;
        data.shotgunSpeed2 = shotGunBulletSpeed2;
        data.mp4Speed = mp4Speed;
        data.crossbowSpeed = crossbowSpeed;
        data.trippleSpeed = trippleShotSpeed;
        data.cannonSpeed = bigBulletSpeed;
        data.homingSpeed = homignBulletSpeed;
        data.uziSpeed = smallBulletSpeed;

        data.clicksPerPistol = pistolClicksNeeded;
        data.clicksPerShotgun = shotGunClicksNeeded;
        data.clicksPerCrossbow = crossbowClicksNeeded;
        data.clicksPerTripple = trippleShotNeeded;
        data.clicksPerCannon = clicksPerBigBullet;
        data.clicksPerHoming = clicksPerHomingBullet;
        data.clicksPerUzi = clickPerSmallBullet;

        data.pistolDamage = bulletGun1_Damage;
        data.shotgunDamage1 = shotGunBulletDamage;
        data.shotgunDamage2 = shotGunBulletDamage2;
        data.mp4Damage = mp4Damage;
        data.crossbowDamage = crossbowDamage;
        data.trippleDamage = trippleShotDamage;
        data.cannonDamage = bigBulletDamage;
        data.homingDamage = homingBulletDamage;
        data.uziDamage = smallBulletDamage;

        data.arenaUpgradeCount = arenaUpgradeCount;
    }
    #endregion
}
