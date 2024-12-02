using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public static int setmaxAssasins, setmaxSpeedsters, setmaxSharpshooters, setmaxSnipers, setmaxHeavyshots, setmaxBrutes, setmaxRagingGunners, setmaxTitans;

    public GameData()
    {
        setmaxAssasins = 12;
        setmaxSpeedsters = 11;
        setmaxSharpshooters = 6;
        setmaxSnipers = 5;
        setmaxHeavyshots = 4;
        setmaxBrutes = 4;
        setmaxRagingGunners = 6;
        setmaxTitans = 2;

        setsmallEnemySpawnTimer = 1.7f;
        setspeedsterSpawnTimer = 2.2f;
        setsharpshooterSpawnTimer = 4.5f;
        setsniperSpawnTimer = 5.5f;
        setheavyShotSpawnTiner = 8f;
        setragingGunnerSpawnTimer = 8f;
        settitanSpawnTimer = 25f;
        setbigEnemySpawnTimer = 12f;

        setspawnMoreSmallEnemiesTimer = 8.5f;
        setspawnMoreSpeedsterTimer = 10;
        setspawnMoreSharpshooterTimer = 14;
        setspawnMoreSniperTimer = 17;
        setspawnMoreHeavyShotTimer = 24;
        setspawnMoreRagingGunnerTimer = 22;
        setspawnMoreBruteTimer = 30;
        setspawnMoreTitanTimer = 65;

        setsmallEnemyDamage = 1;
        setspeedsterDamage = 2;
        setsharpshooterDamage = 2;
        setsniperDamage = 3;
        setheavyShotDamage = 7;
        setragingGunnerMeleeDamage = 3.5f;
        setragingGunnerRangedDamage = 1.5f;
        setbruteDamage = 9;
        settitanDamage = 18;

        setsmallEnemyHP = 27;
        setspeedsterHP = 23;
        setsharpshooterHP = 90;
        setsniperHP = 80;
        setheavyShotHP = 180;
        setbruteHP = 600;
        setragingGunnerHP = 260;
        settitanHP = 1100;

        setsmallEnemyPoints = 23;
        setspeedsterPoints = 33;
        setsharpshooterPoints = 50;
        setsniperPoints = 65;
        setheavyShotPoints = 75;
        setragingGunnerPoints = 125;
        setbrutePoints = 300;
        settitanPoints = 700;

        Settings();
        ButtonClick();
        Abilites();
        EnemyStats();
        AchAndSkinsSaved();
    }

    #region FirstTiem/Settings
    public bool pressedOkFirstTImePlaying, isPlayerPlayingARun;

    public bool firstTimeDefeatedBoss, firstTimeDefeatedHorde, firstTimeDefeatedChampions, firstTimeDefeatedDangerButton;

    public int totalButtonClicks, totalCritClicks, totalIdleClicks;
    public float totalPoints, totalClickPoints, totalCritPoints, totalEnemyPoints, totalPointDropPoints;
    public int totalEnemiesDefeated, totalSmallEnemiesDefeated, totalSpeedstersDefeated, totalSharpshootersDefeated, totalSnipersDefeated, totalHeavyshotDefeated, totalBrutedDefeated, totalRagingGunnerDefeated, totalTitansDefeated;
    public int totalLevels, furthestRunLevel, totalTimePlayedHours, totalTimePlayedMinutes;
    public int endingsCompleted, runsCompleted, timesDefeatedBoss, timesDefeatedHorde, timesDefeatedChampions, timesDefeatedDangerButton;
    public int ritualsEntered, weirdEggUpgrades, totalAbilitiesChosen, totalCommonAbilitiesChosen, totalUncommonAbilititesChosen, totalRareAbilitiesChose, totalLegendaryAbilitiesChosen, totalMythicAbilitiesChosen, timesRerolled;
    public  int longestRunMinutes, longestRunSeconds, fastestRunMinutes, fastestRunSeconds;

    public bool firstRunCompleted;
    public int totalArrowsHit;
    public bool spaceBarSelected, leftClickSeleced;

    public void Settings()
    {
        this.spaceBarSelected = true;
        this.leftClickSeleced = false;

        this.totalArrowsHit = 0;

        this.firstRunCompleted = false;

        this.longestRunMinutes = 0;
        this.longestRunSeconds = 0;
        this.fastestRunMinutes = 0;
        this.fastestRunSeconds = 0;

        this.firstTimeDefeatedBoss = false;
        this.firstTimeDefeatedHorde = false;
        this.firstTimeDefeatedChampions = false;
        this.firstTimeDefeatedDangerButton = false;

        this.totalButtonClicks = 0;
        this.totalCritClicks = 0;
        this.totalIdleClicks = 0;
        this.totalPoints = 0f;
        this.totalClickPoints = 0f;
        this.totalCritPoints = 0f;
        this.totalEnemyPoints = 0f;
        this.totalPointDropPoints = 0f;
        this.totalEnemiesDefeated = 0;
        this.totalSmallEnemiesDefeated = 0;
        this.totalSpeedstersDefeated = 0;
        this.totalSharpshootersDefeated = 0;
        this.totalSnipersDefeated = 0;
        this.totalHeavyshotDefeated = 0;
        this.totalBrutedDefeated = 0;
        this.totalRagingGunnerDefeated = 0;
        this.totalTitansDefeated = 0;
        this.totalLevels = 0;
        this.furthestRunLevel = 0;
        this.totalTimePlayedHours = 0;
        this.totalTimePlayedMinutes = 0;
        this.endingsCompleted = 0;
        this.runsCompleted = 0;
        this.timesDefeatedBoss = 0;
        this.timesDefeatedHorde = 0;
        this.timesDefeatedChampions = 0;
        this.timesDefeatedDangerButton = 0;
        this.ritualsEntered = 0;
        this.weirdEggUpgrades = 0;
        this.totalAbilitiesChosen = 0;
        this.totalCommonAbilitiesChosen = 0;
        this.totalUncommonAbilititesChosen = 0;
        this.totalRareAbilitiesChose = 0;
        this.totalLegendaryAbilitiesChosen = 0;
        this.totalMythicAbilitiesChosen = 0;
        this.timesRerolled = 0;

        this.pressedOkFirstTImePlaying = false;
        this.isPlayerPlayingARun = false;

        this.currentTime = 0;
        this.timeMinutes = 0;
        this.totalTimeSeconds = 0;
        this.totalTimeMinutes = 0;
    }
    #endregion

    #region Button Click
    public float pointsPerClick;
    public int level;
    public float pointsNeeded, pointsGained;

    public void ButtonClick()
    {
       
        this.level = 0;
        this.pointsPerClick = 1;
        this.pointsNeeded = 20;
        this.pointsGained = 0;
    }
    #endregion

    #region Abilitites Saves

    //Points, reroll and abiliites
    public float  critClicksBonus;
    public bool choseCritClicks, choseIdleClicking, choseReroll, choseDoubleTap;
    public float critClicksChance, timeBetweenClicks;
    public int numberOfChoises;
    public int rerollClicksNeeded, rerollsAviable;

    //Health, regen and defense
    public bool choseHealthBar, chooseHeartCollect, choseShield_BounceOff;
    public float maxButtonHealth, healthRegenPerSecond, shieldBounce_RotateSpeed, shieldBounce_ReChargeTimer, shieldBounce_health;

    public bool choseStopTime, choseInvincibility;
    public float stopTimeTimer, invincibilityTimer;
    public int stopTimeClickTotal, invincibilityClickPer1Second;

    //Arena
    public bool choseBouncingBullets;
    public int arenaSpawnPointChangeY, arenaSpawnPointChangeX;
    public float hordeStartCameraSize, arenaIncrease;

    //Movment
    public bool movementAbilityAquaried, chooseRocket, choseButtonBounceCharge, chooseControllableButton;

    //Guns
    public bool savedPistol, savedShotgun, savedMp4, savedCrossbow, savedTrippleShot, savedCannon, savedHomingGun, savedUzi;
    public int clicksPerPistol, clicksPerShotgun, clicksPerCrossbow, clicksPerTripple, clicksPerCannon, clicksPerHoming, clicksPerUzi, shotGunBullets;
    public float pistolDamage, shotgunDamage1, shotgunDamage2, mp4Damage, crossbowDamage, trippleDamage, cannonDamage, homingDamage, uziDamage;
    public float pistolSpeed, shotgunSpeed1, shotgunSpeed2, mp4Speed, crossbowSpeed, trippleSpeed, cannonSpeed, homingSpeed, uziSpeed;
    public float pistolDeSpawnTime, shotgunDeSpawnTime, mp4DeSpawnTime, cannonDeSpawnTime, uziDeSpawnTime;
    public int mp4ClicksNeeded, chargedBulletsCount;
    public float chargedBulletChargeTime, chargedBulletMaxDamage;

    public bool choseButtonCharge, choseArrows;
    public int arrowCountShot, arrowClicksNeeded;
    public float chargedBulletDamageIncrement, buttonChargePerSecond, arrowDamage;

    //Melee weapons
    public bool chooseBigSpike, chooseSpiked, chooseStabbingSpikes, choseBoxingGlove, chooseSawBlade, chooseHammer, choseSpinningKnifes;
    public int  hammerClicksNeeded, knifeClicksNeeded, stabbingSpikesClicksNeeded, boxingGloveClicksNeeded;
    public float swordSpeed, spikeDamagePerSecond, boxingGloveKnockbackAmount, sawBladeSpeed, sawBladeDamage, hammerDamage, hammerStunTime, knifeDamage, knifeSpeed, bigSpikeDamage, stabbingSpikeDamage;
    public int knifeTotalCount;

    //Enemies
    public bool smallEnemySpawn, speedsterSpawn, sharpshooterSpawn, sniperSpawn, ragingGunnerSpawn, heavyShotSpawn, bruteSpawn, titanSpawn;
    public float smallEnemyDamage, speedsterDamage, sharpshooterDamage, sniperDamage, ragingGunnerMeleeDamage, ragingGunnerRangedDamage, heavyShotDamage, bruteDamage, titanDamage;
    public float smallEnemyPoints, speedsterPoints, sharpshooterPoints, sniperPoints, ragingGunnerPoints, heavyShotPoints, brutePoints, titanPoints;
    public float smallEnemyHP, speedsterHP, sharpshooterHP, sniperHP, ragingGunnerHP, heavyShotHP, bruteHP, titanHP;
    public float smallEneySpeed, speedsterSpeed, sharpshooterSpeed, sniperSpeed, ragingGunnerSpeed, heavyshotSpeed, bruteSpeed, titanSpeed;

    //Other
    public bool choseSkullHarvest, chosePointsDrop;
    public float randomUncommonPointsDrop, randomRarePointDrop, randomLegendaryPointDrop, randomMythicPointDrop;

    public int commonAbilitesNotAviable, commonAbilitiesAviable;
    public int unCommonAbilitesNotAviable, unCommonAbilitiesAviable;
    public int rareAbilitesNotAviable, rareAbilitiesAviable;
    public int legendaryAbilitiesNotAvailable, legendaryAbilitiesAviable;
    public bool firstTimeEndingShowedUp;

    public bool firstWeaponChosen, choseSmallShields, firstShootingEnemyChose;
    public int bigHeartClicksNeeded;

    public float spawnMoreSmallEnemiesTimer, spawnMoreSpeedsterTimer, spawnMoreSharpshooterTimer, spawnMoreSniperTimer, spawnMoreRagingGunnerTimer, spawnMoreHeavyShotTimer, spawnMoreBruteTimer, spawnMoreTitanTimer, bigHeartHPHeal;

    public int ritualClicksNeeded;
    public float smallShieldRotateSpeed, smallShieldRechargeTimer, invincibilityTimeAdded, smallShieldHP;
    public bool regenHealth;
    public int commonChance, uncommonChance, rareChance, legendaryChance;

    public float smallEnemySpawnTimer, speedsterSpawnTimer, sharpshooterSpawnTimer, sniperSpawnTimer, heavyShotSpawnTiner, ragingGunnerSpawnTimer, titanSpawnTimer, bigEnemySpawnTimer;
    public int skullHarvestStatDivide;

    public float SHpointPerClick, SHcritChance, SHcritIncrease, SHidleClicks;
    public float SHuziSpeed, SHuziDamage, SHpistolSpeed, SHPistolDamage, SHshotgunSpeed, SHshotgunDamage, SHawpSpeed, SHawpDamage, SHcrossbowSpeed, SHcrossbowDamage, SHdeagleSpeed, SHdeagleDamage, SHcannonSpeed, SHcannonDamage, SHmp4Speed, SHmp4Damage, SHchargeBulletDamage, SHchargeBulletTime, SHarrowDamage;
    public float SHmaxHealth, SHregen, SHbigHEarHP, SHsmallShieldHP, SHsmallShieldRecharge, SHbounceHP, SHbouncyRecharge;
    public float SHboxingForce, SHstabbyDamage, SHtinySpikeDamage, SHknifeDamage, SHsawBladeDamage, SHsawbladeSpeed, SHswordSpeed, SHswordDamage, SHhammerDamage, SHhammerStunTime;
    public float SHbasicPointChance, SHrarePointChance, SHlegendaryPointChance, SHmythicChance, SHinvinTime, SHstopwatchTime;

    public int skullsConsumedCount;

    public bool eggPointPerClickChosen, eggCritclickChosen, eggIdleClickChosen, eggDefenseChosen, eggBigHeartChosen, eggSmallShieldChosen, eggBouncyShieldChosen, eggPistolChosen, eggUziChosen, eggShotgunChosen, eggAWPChosen, eggCrossbowChosen, eggDeagleChosen, eggCannonChosen, eggMP4Chosen, eggArenaChosen, eggBoxingGloveChosen, eggStabbySpikeChosen, eggTinySpikeChosen, eggKnifeChosen, eggSwordChosen, eggRitualChosen, eggSawBladeChose, eggHammerChosen, eggArrowChosen, eggChagedBulletsChosen, eggPointDropChosen, eggStopwatchChosen, eggInvinChosen, eggSkullHarvestChosen, eggDiceChose, choseUnlimitedPower;

    public bool choseRitual;
    public bool firstTimeGun;

    public int currentTime;
    public int timeMinutes;
    public int totalTimeSeconds, totalTimeMinutes;

    public int smallShieldUpgradeCount, stabbySpikeUpgradeCount, sawBladeUpgradeCount, bouncyShieldUpgradeCount, swordUpgradeCount;

    public bool firstControlledGun;

    public static float setsmallEnemySpawnTimer, setspeedsterSpawnTimer, setsharpshooterSpawnTimer, setsniperSpawnTimer, setheavyShotSpawnTiner, setragingGunnerSpawnTimer, settitanSpawnTimer, setbigEnemySpawnTimer;
    public static float setspawnMoreSmallEnemiesTimer, setspawnMoreSpeedsterTimer, setspawnMoreSharpshooterTimer, setspawnMoreSniperTimer, setspawnMoreRagingGunnerTimer, setspawnMoreHeavyShotTimer, setspawnMoreBruteTimer, setspawnMoreTitanTimer;
    public static float setsmallEnemyDamage, setspeedsterDamage, setsharpshooterDamage, setsniperDamage, setragingGunnerMeleeDamage, setragingGunnerRangedDamage, setheavyShotDamage, setbruteDamage, settitanDamage;
    public static int setsmallEnemyPoints, setspeedsterPoints, setsharpshooterPoints, setsniperPoints, setragingGunnerPoints, setheavyShotPoints, setbrutePoints, settitanPoints;
    public static float setsmallEnemyHP, setspeedsterHP, setsharpshooterHP, setsniperHP, setragingGunnerHP, setheavyShotHP, setbruteHP, settitanHP;

    public int numberOfEnemiesActive;
    public float totalIdlePoints;

    public int maxAssasins, maxSpeedsters, maxSharpshooters, maxSnipers, maxHeavyshots, maxBrutes, maxRagingGunners, maxTitans;
    public bool skullHarvestChosenFirstTime;

    public bool assassinFirstTime, speedsterFirstTime, sharpshooterFirstTime, sniperFirstTime, heavyshotFirstTime, ragingGunnerFirstTime, bruteFirstTime, titanFirstTime;

    public bool pointsFirst, idleFirst, critFirst, pointDropFirst, doubletapFirst, uziFirst, pistolFirst, shotgunFirst, awpFirst, crossbowFirst, deagleFirst, chargedBulletFirst, cannonFirst, mp4First, arrosFirst, boxinggloveFirst, stabbyspikeFirst, tinySpikeFirst, knifeFirst, sawBladeFirst, swordFirst, hammerFirst, defenseFirst, heartFirst, smallShieldFirst, bouncyShieldFirst, invinFirst, stopwatchFirst, boosterFirst, rocketFirst, talariaFirst, random2First, random3First, random5First, ritualFirst, eggFirst, arenaFirst, abiltites4XFirst, rerollRareFirst, abilities5XFirst, rerollLegendaryFirst, skullHarvestFirst;

    public float pointDropBasicPoints, pointDropRarityIncreasePoints;
    public float SHpointDropBasic, SHpointDropRarity;

    public float ritualTimer, rerollDoubleChance;
    public int arenaUpgradeCount;

    public int totalGunsAcquired;
    public int numberOfGunsCurrentRun, numberOfMeleeCurrentRun;

    public int pointsLEVEL, idleLEVEL, critLEVEL, pointDropLEVEL, uziLEVEL, pistolLEVEL, shotgunLEVEL, awpLEVEL, crossbowLEVEL, deagleLEVEL, chargedBulletLEVEL, cannonLEVEL, mp4LEVEL, arrosLEVEL, boxingloveLEVEL, stabbyspikeLEVEL, tinySpikeLEVEL, knifeLEVEL, sawBladeLEVEL, swordLEVEL, hammerLEVEL, defenseLEVEL, heartLEVEL, smallShieldLEVEL, bouncyShieldLEVEL, invinLEVEL, stopwatchLEVEL, ritualLEVEL, arenaLEVEL, rerollLEVEL, skullHarvestLEVEL;

    public void Abilites()
    {
        this.pointsLEVEL = 1;
        this.idleLEVEL = 0;
        this.critLEVEL = 0;
        this.pointDropLEVEL = 0;
        this.uziLEVEL = 0;
        this.pistolLEVEL = 0;
        this.shotgunLEVEL = 0;
        this.awpLEVEL = 0;
        this.crossbowLEVEL = 0;
        this.deagleLEVEL = 0;
        this.chargedBulletLEVEL = 0;
        this.cannonLEVEL = 0;
        this.mp4LEVEL = 0;
        this.arrosLEVEL = 0;
        this.boxingloveLEVEL = 0;
        this.stabbyspikeLEVEL = 0;
        this.tinySpikeLEVEL = 0;
        this.knifeLEVEL = 0;
        this.sawBladeLEVEL = 0;
        this.swordLEVEL = 0;
        this.hammerLEVEL = 0;
        this.defenseLEVEL = 0;
        this.heartLEVEL = 0;
        this.smallShieldLEVEL = 0;
        this.bouncyShieldLEVEL = 0;
        this.invinLEVEL = 0;
        this.stopwatchLEVEL = 0;
        this.ritualLEVEL = 0;
        this.arenaLEVEL = 0;
        this.rerollLEVEL = 0;
        this.skullHarvestLEVEL = 0;

        this.numberOfGunsCurrentRun = 0;
        this.numberOfMeleeCurrentRun = 0;

        this.totalGunsAcquired = 0;

        this.arenaUpgradeCount = 0;
        this.rerollDoubleChance = 0;
        this.ritualTimer = 0;

        this.SHpointDropBasic = 0;
        this.SHpointDropRarity = 0;

        this.pointDropBasicPoints = 0;
        this.pointDropRarityIncreasePoints = 0;

        this.pointsFirst = false;
        this.idleFirst = false;
        this.critFirst = false;
        this.pointDropFirst = false;
        this.doubletapFirst = false;
        this.uziFirst = false;
        this.pistolFirst = false;
        this.shotgunFirst = false;
        this.awpFirst = false;
        this.crossbowFirst = false;
        this.deagleFirst = false;
        this.chargedBulletFirst = false;
        this.cannonFirst = false;
        this.mp4First = false;
        this.arrosFirst = false;
        this.boxinggloveFirst = false;
        this.stabbyspikeFirst = false;
        this.tinySpikeFirst = false;
        this.knifeFirst = false;
        this.sawBladeFirst = false;
        this.swordFirst = false;
        this.hammerFirst = false;
        this.defenseFirst = false;
        this.heartFirst = false;
        this.smallShieldFirst = false;
        this.bouncyShieldFirst = false;
        this.invinFirst = false;
        this.stopwatchFirst = false;
        this.boosterFirst = false;
        this.rocketFirst = false;
        this.talariaFirst = false;
        this.random2First = false;
        this.random3First = false;
        this.random5First = false;
        this.ritualFirst = false;
        this.eggFirst = false;
        this.arenaFirst = false;
        this.abiltites4XFirst = false;
        this.rerollRareFirst = false;
        this.abilities5XFirst = false;
        this.rerollLegendaryFirst = false;
        this.skullHarvestFirst = false;

        this.assassinFirstTime = false;
        this.speedsterFirstTime = false;
        this.sharpshooterFirstTime = false;
        this.sniperFirstTime = false;
        this.heavyshotFirstTime = false;
        this.ragingGunnerFirstTime = false;
        this.bruteFirstTime = false;
        this.titanFirstTime = false;

        this.skullHarvestChosenFirstTime = false;

        this.maxAssasins = setmaxAssasins;
        this.maxSpeedsters = setmaxSpeedsters;
        this.maxSharpshooters = setmaxSharpshooters;
        this.maxSnipers = setmaxSnipers;
        this.maxHeavyshots = setmaxHeavyshots;
        this.maxBrutes = setmaxBrutes;
        this.maxRagingGunners = setmaxRagingGunners;
        this.maxTitans = setmaxTitans;

        this.totalIdlePoints = 0;

        this.numberOfEnemiesActive = 0;

        this.firstControlledGun = false;

        this.smallShieldUpgradeCount = 0;
        this.stabbySpikeUpgradeCount = 0;
        this.sawBladeUpgradeCount = 0;
        this.bouncyShieldUpgradeCount = 0;
        this.swordUpgradeCount = 0;

      

        this.firstTimeGun = false;
        this.choseRitual = false;

        this.eggPointPerClickChosen = false;
        this.eggCritclickChosen = false;
        this.eggIdleClickChosen = false;
        this.eggDefenseChosen = false;
        this.eggBigHeartChosen = false;
        this.eggSmallShieldChosen = false;
        this.eggBouncyShieldChosen = false;
        this.eggPistolChosen = false;
        this.eggUziChosen = false;
        this.eggShotgunChosen = false;
        this.eggAWPChosen = false; 
        this.eggCrossbowChosen = false;
        this.eggDeagleChosen = false;
        this.eggCannonChosen = false;
        this.eggMP4Chosen = false;
        this.eggArenaChosen = false;
        this.eggBoxingGloveChosen = false;
        this.eggStabbySpikeChosen = false;
        this.eggTinySpikeChosen = false;
        this.eggKnifeChosen = false;
        this.eggSwordChosen = false;
        this.eggRitualChosen = false;
        this.eggSawBladeChose = false;
        this.eggHammerChosen = false;
        this.eggArrowChosen = false;
        this.eggChagedBulletsChosen = false;
        this.eggPointDropChosen = false;
        this.eggStopwatchChosen = false;
        this.eggInvinChosen = false;
        this.eggSkullHarvestChosen = false;
        this.eggDiceChose = false;
        this.choseUnlimitedPower = false;


        this.SHmaxHealth = 0;
        this.SHregen = 0;
        this.SHbigHEarHP = 0;
        this.SHsmallShieldHP = 0;
        this.SHsmallShieldRecharge = 0;
        this.SHbounceHP = 0;
        this.SHbouncyRecharge = 0;
        this.SHboxingForce = 0;
        this.SHstabbyDamage = 0;
        this.SHtinySpikeDamage = 0;
        this.SHknifeDamage = 0;
        this.SHsawBladeDamage = 0;
        this.SHsawbladeSpeed = 0;
        this.SHswordSpeed = 0;
        this.SHswordDamage = 0;
        this.SHhammerDamage = 0;
        this.SHhammerStunTime = 0;
        this.SHbasicPointChance = 0;
        this.SHrarePointChance = 0;
        this.SHlegendaryPointChance = 0;
        this.SHmythicChance = 0;
        this.SHinvinTime = 0;
        this.SHstopwatchTime = 0;
        this.skullsConsumedCount = 0;
        this.SHpointPerClick = 0;
        this.SHcritChance = 0;
        this.SHcritIncrease = 0;
        this.SHidleClicks = 0;
        this.SHuziSpeed = 0;
        this.SHuziDamage = 0;
        this.SHpistolSpeed = 0;
        this.SHPistolDamage = 0;
        this.SHshotgunSpeed = 0;
        this.SHshotgunDamage = 0;
        this.SHawpSpeed = 0;
        this.SHawpDamage = 0;
        this.SHcrossbowSpeed = 0;
        this.SHcrossbowDamage = 0;
        this.SHdeagleSpeed = 0;
        this.SHdeagleDamage = 0;
        this.SHcannonSpeed = 0;
        this.SHcannonDamage = 0;
        this.SHmp4Speed = 0;
        this.SHmp4Damage = 0;
        this.SHchargeBulletTime = 0;
        this.SHchargeBulletDamage = 0;
        this.SHarrowDamage = 0;

        this.skullHarvestStatDivide = 0;

      

        this.commonChance = 99;
        this.uncommonChance = 96;
        this.rareChance = 97;
        this.legendaryChance = 97;

        this.regenHealth = false;
        this.invincibilityTimeAdded = 0;
        this.smallShieldRechargeTimer = 0;
        this.smallShieldRotateSpeed = 0;
        this.smallShieldHP = 0;
        this.ritualClicksNeeded = 0;

        this.chargedBulletMaxDamage = 0;
        this.chargedBulletChargeTime = 0;
        this.chargedBulletsCount = 0;

        this.mp4ClicksNeeded = 0;
       

        this.knifeTotalCount = 0;
        this.bigHeartClicksNeeded = 0;
        this.bigHeartHPHeal = 0;

        //Abilities aviable should always be 1 less how many are actually aviable. This is because of the ARRAY.
        this.commonAbilitesNotAviable = 26;
        this.unCommonAbilitesNotAviable = 8;
        this.rareAbilitesNotAviable = 4;
        this.legendaryAbilitiesNotAvailable = 7;

        this.commonAbilitiesAviable = 2;
        this.unCommonAbilitiesAviable = 2;
        this.rareAbilitiesAviable = 6;
        this.legendaryAbilitiesAviable = 3;

        this.firstTimeEndingShowedUp = false;

        this.choseSkullHarvest = false;
        this.chosePointsDrop = false;
        this.randomUncommonPointsDrop = 0;
        this.randomRarePointDrop = 0;
        this.randomLegendaryPointDrop = 0;
        this.randomMythicPointDrop = 0;

        this.choseButtonCharge = false;
        this.choseArrows = false;
        this.arrowCountShot = 0;
        this.arrowClicksNeeded = 0;
        this.chargedBulletDamageIncrement = 0;
        this.buttonChargePerSecond = 0;
        this.arrowDamage = 0;

        this.movementAbilityAquaried = false;
        this.chooseRocket = false;
        this.choseButtonBounceCharge = false;
        this.chooseControllableButton = false;

        this.choseBouncingBullets = false;
        this.choseStopTime = false;
        this.arenaSpawnPointChangeY = 0;
        this.arenaSpawnPointChangeX = 0;
        this.hordeStartCameraSize = 0;
        this.arenaIncrease = 0;

        this.choseStopTime = false;
        this.choseInvincibility = false;
        this.stopTimeTimer = 0;
        this.invincibilityTimer = 0;
        this.stopTimeClickTotal = 0;
        this.invincibilityClickPer1Second = 0;

        this.choseSmallShields = false;
        this.choseHealthBar = false;
        this.chooseHeartCollect = false;
        this.choseShield_BounceOff = false;
        this.maxButtonHealth = 100;
        this.healthRegenPerSecond = 0;
        this.shieldBounce_RotateSpeed = 0;
        this.shieldBounce_ReChargeTimer = 0;
        this.shieldBounce_health = 0;

        this.firstShootingEnemyChose = false;
        this.smallEnemySpawn = false;
        this.speedsterSpawn = false;
        this.sharpshooterSpawn = false;
        this.sniperSpawn = false;
        this.ragingGunnerSpawn = false;
        this.heavyShotSpawn = false;
        this.bruteSpawn = false;
        this.titanSpawn = false;

        this.smallEneySpeed = 0;
        this.speedsterSpeed = 0;
        this.sharpshooterSpeed = 0;
        this.sniperSpeed = 0;
        this.ragingGunnerSpeed = 0;
        this.heavyshotSpeed = 0;
        this.bruteSpeed = 0;
        this.titanSpeed = 0;

        this.chooseBigSpike = false;
        this.chooseSpiked = false;
        this.chooseStabbingSpikes = false;
        this.choseBoxingGlove = false;
        this.chooseSawBlade = false;
        this.chooseHammer = false;
        this.choseSpinningKnifes = false;

        this.bigSpikeDamage = 0;
        this.stabbingSpikeDamage = 0;
        this.hammerClicksNeeded = 0;
        this.knifeClicksNeeded = 0;
        this.stabbingSpikesClicksNeeded = 0;

        this.swordSpeed = 0;
        this.spikeDamagePerSecond = 0;
        this.boxingGloveKnockbackAmount = 0;
        this.boxingGloveClicksNeeded = 0;
        this.sawBladeSpeed = 0;
        this.sawBladeDamage = 0;
        this.hammerDamage = 0;
        this.hammerStunTime = 0;
        this.knifeDamage = 0;
        this.knifeSpeed = 0;

        this.firstWeaponChosen = false;

        this.critClicksBonus = 0;
        this.choseCritClicks = false;
        this.choseIdleClicking = false;
        this.choseReroll = false;
        this.choseDoubleTap = false;
        this.critClicksChance = 0;
        this.timeBetweenClicks = 5;
        this.numberOfChoises = 3;
        this.rerollClicksNeeded = 0;
        this.rerollsAviable = 0;

        this.pistolDeSpawnTime = 0;
        this.shotgunDeSpawnTime = 0;
        this.mp4DeSpawnTime = 0;
        this.cannonDeSpawnTime = 0;
        this.uziDeSpawnTime = 0;

        this.shotGunBullets = 0;
        this.pistolSpeed = 0;
        this.shotgunSpeed1 = 0;
        this.shotgunSpeed2 = 0;
        this.mp4Speed = 0;
        this.crossbowSpeed = 0;
        this.trippleSpeed = 0;
        this.cannonSpeed = 0;
        this.homingSpeed = 0;
        this.uziSpeed = 0;

        this.savedPistol = false;
        this.savedShotgun = false;
        this.savedMp4 = false;
        this.savedCrossbow = false;
        this.savedTrippleShot = false;
        this.savedCannon = false;
        this.savedHomingGun = false;
        this.savedUzi = false;

        this.clicksPerPistol = 0;
        this.clicksPerShotgun = 0;
        this.clicksPerCrossbow = 0;
        this.clicksPerTripple = 0;
        this.clicksPerCannon = 0;
        this.clicksPerHoming = 0;
        this.clicksPerUzi = 0;

        this.pistolDamage = 0;
        this.shotgunDamage1 = 0;
        this.shotgunDamage2 = 0;
        this.mp4Damage = 0;
        this.crossbowDamage = 0;
        this.trippleDamage = 0;
        this.cannonDamage = 0;
        this.homingDamage = 0;
        this.uziDamage = 0;
    }

    public void EnemyStats()
    {
        //Debug.Log("saves");
        this.smallEnemySpawnTimer = setsmallEnemySpawnTimer;
        this.speedsterSpawnTimer = setspeedsterSpawnTimer;
        this.sharpshooterSpawnTimer = setsharpshooterSpawnTimer;
        this.sniperSpawnTimer = setsniperSpawnTimer;
        this.heavyShotSpawnTiner = setheavyShotSpawnTiner;
        this.ragingGunnerSpawnTimer = setragingGunnerSpawnTimer;
        this.titanSpawnTimer = settitanSpawnTimer;
        this.bigEnemySpawnTimer = setbigEnemySpawnTimer;

        this.spawnMoreSmallEnemiesTimer = setspawnMoreSmallEnemiesTimer;
        this.spawnMoreSpeedsterTimer = setspawnMoreSpeedsterTimer;
        this.spawnMoreSharpshooterTimer = setspawnMoreSharpshooterTimer;
        this.spawnMoreSniperTimer = setspawnMoreSniperTimer;
        this.spawnMoreHeavyShotTimer = setspawnMoreHeavyShotTimer;
        this.spawnMoreRagingGunnerTimer = setspawnMoreRagingGunnerTimer;
        this.spawnMoreBruteTimer = setspawnMoreBruteTimer;
        this.spawnMoreTitanTimer = setspawnMoreTitanTimer;

        this.smallEnemyDamage = setsmallEnemyDamage;
        this.speedsterDamage = setspeedsterDamage;
        this.sharpshooterDamage = setsharpshooterDamage;
        this.sniperDamage = setsniperDamage;
        this.heavyShotDamage = setheavyShotDamage;
        this.ragingGunnerMeleeDamage = setragingGunnerMeleeDamage;
        this.ragingGunnerRangedDamage = setragingGunnerRangedDamage;
        this.bruteDamage = setbruteDamage;
        this.titanDamage = settitanDamage;

        this.smallEnemyHP = setsmallEnemyHP;
        this.speedsterHP = setspeedsterHP;
        this.sharpshooterHP = setsharpshooterHP;
        this.sniperHP = setsniperHP;
        this.heavyShotHP = setheavyShotHP;
        this.bruteHP = setbruteHP;
        this.ragingGunnerHP = setragingGunnerHP;
        this.titanHP = settitanHP;

        this.smallEnemyPoints = setsmallEnemyPoints;
        this.speedsterPoints = setspeedsterPoints;
        this.sharpshooterPoints = setsharpshooterPoints;
        this.sniperPoints = setsniperPoints;
        this.heavyShotPoints = setheavyShotPoints;
        this.ragingGunnerPoints = setragingGunnerPoints;
        this.brutePoints = setbrutePoints;
        this.titanPoints = settitanPoints;
    }
    #endregion

    #region Achievemnts And Skins
    public bool isBasicYellowBTNUnlocked, isBasicGreenBTNUnlocked, isBasicPurpleBTNUnlocked, isCheapGreenBTNUnlocked, isPureYellowBrnUnlcoked, isDiscoBTNUnlcoked, isEnergyBTNUnlocked, isFireBTNUnlcoked, isWoodenBTNUNlocked, isRockBTNUnlcoked, isPurpleBTNUnlocked, isblueBTNUnlocked, isSimonBTNUnlcoked, isLogoBTNUnlocked, isFunBTNUnlocked, isEnemyBTNUnlocked;

    public bool isGreenFadeUnlocked, isRedStripedInlocked, isWaveUnlocked, isPinkWaveUnlocked, isPurpleWaveUnlcoked, isRedTilesUnlocked, isGreenStripesUnlocked, isHexagonUnlocked;

    public bool isUziACHUnlocked, isPistolACHUnlocked, isShotgunACHUnlocked, isTrippledACHUnlocked, isCrossbowACHUnlcoked, isAWPACHUnlocked, isCannonACHUnlocked, isMP4ACHUnlocked, isCritACHUnlcoked, isFunACHUnlockes, isAcquireSkullHarvestACHUnlocked, isAcquireStopwatchACHUnlcoked, isAcquireTalariaACHUnlocked, isAcquireEggACHUnlocked, isAcquireDoubleTapACHUnlocked, isCPSACHUnlocked, isBeatBossACHUnlcockec, isBeatHordeACHUnlockec, isBeatChampionsACHUnlocked, isBeatDangerButtonACHUnlocked, isPointBlankACHUnlocked, isBeatallEndingsAchUnlocked, isConsumeSkullsACHUnlocked, isRerollACHUnlocked, isAllGunsACHUnkocked, isChooseAiblititesACHUnlcoked, isReachLevel1ACHUnlocked, isReachLevel2AchUnlocked, isReachLevel3AchUnlocked, isReachLevel4Unlocked, isDefeatAssassinsACHUnlocked, isDefeatSpeedstersACHUnlocked, isDefeatSharpshootersACHUnlocked, isDefeatSnipersACHUnlocked, isDefeatHeavyshotsACHUnlocked, isDefeatGunnersACHUnlocked, isDefeatBrutesACHUnlocked, isDefeatTitansACHUnlocked, isClickButton1ACHUnlocked, isClickButton2ACHUnlocked, isClickButton3ACHUnlocked, isSpeedrunnerACHUnlocked, isDefeatEnemiesACHUnlocked, isBeatEndingLevel75ACHUnlocked, isAllUncommonACHUnlocked, isAllRareAchUnlocked, isAllLegendaryACHUnlocked, isAllMythicACHUnlocked, isAllAbilitiesACHUnlocked, isAllMeleeACHUnlocked;

    public int totalAchievements;


    public void AchAndSkinsSaved()
    {
        this.isBasicYellowBTNUnlocked = false;
        this.isBasicGreenBTNUnlocked = false;
        this.isBasicPurpleBTNUnlocked = false;
        this.isCheapGreenBTNUnlocked = false;
        this.isPureYellowBrnUnlcoked = false;
        this.isDiscoBTNUnlcoked = false;
        this.isEnergyBTNUnlocked = false;
        this.isFireBTNUnlcoked = false;
        this.isWoodenBTNUNlocked = false;
        this.isRockBTNUnlcoked = false;
        this.isPurpleBTNUnlocked = false;
        this.isblueBTNUnlocked = false;
        this.isSimonBTNUnlcoked = false;
        this.isLogoBTNUnlocked = false;
        this.isFunBTNUnlocked = false;
        this.isEnemyBTNUnlocked = false;

        this.isGreenFadeUnlocked = false;
        this.isRedStripedInlocked = false;
        this.isWaveUnlocked = false;
        this.isPinkWaveUnlocked = false;
        this.isPurpleWaveUnlcoked = false;
        this.isRedTilesUnlocked = false;
        this.isGreenStripesUnlocked = false;
        this.isHexagonUnlocked = false;

        this.isUziACHUnlocked = false;
        this.isPistolACHUnlocked = false;
        this.isShotgunACHUnlocked = false;
        this.isTrippledACHUnlocked = false;
        this.isCrossbowACHUnlcoked = false;
        this.isAWPACHUnlocked = false;
        this.isCannonACHUnlocked = false;
        this.isMP4ACHUnlocked = false;
        this.isCritACHUnlcoked = false;
        this.isFunACHUnlockes = false;
        this.isAcquireSkullHarvestACHUnlocked = false;
        this.isAcquireStopwatchACHUnlcoked = false;
        this.isAcquireTalariaACHUnlocked = false;
        this.isAcquireEggACHUnlocked = false;
        this.isAcquireDoubleTapACHUnlocked = false;
        this.isCPSACHUnlocked = false;
        this.isBeatBossACHUnlcockec = false;
        this.isBeatHordeACHUnlockec = false;
        this.isBeatChampionsACHUnlocked = false;
        this.isBeatDangerButtonACHUnlocked = false;
        this.isPointBlankACHUnlocked = false;
        this.isBeatallEndingsAchUnlocked = false;
        this.isConsumeSkullsACHUnlocked = false;
        this.isRerollACHUnlocked = false;
        this.isAllGunsACHUnkocked = false;
        this.isChooseAiblititesACHUnlcoked = false;
        this.isReachLevel1ACHUnlocked = false;
        this.isReachLevel2AchUnlocked = false;
        this.isReachLevel3AchUnlocked = false;
        this.isReachLevel4Unlocked = false;
        this.isDefeatAssassinsACHUnlocked = false;
        this.isDefeatSpeedstersACHUnlocked = false;
        this.isDefeatSharpshootersACHUnlocked = false;
        this.isDefeatSnipersACHUnlocked = false;
        this.isDefeatHeavyshotsACHUnlocked = false;
        this.isDefeatGunnersACHUnlocked = false;
        this.isDefeatBrutesACHUnlocked = false;
        this.isDefeatTitansACHUnlocked = false;
        this.isClickButton1ACHUnlocked = false;
        this.isClickButton2ACHUnlocked = false;
        this.isClickButton3ACHUnlocked = false;
        this.isSpeedrunnerACHUnlocked = false;
        this.isDefeatEnemiesACHUnlocked = false;
        this.isBeatEndingLevel75ACHUnlocked = false;
        this.isAllUncommonACHUnlocked = false;
        this.isAllRareAchUnlocked = false;
        this.isAllLegendaryACHUnlocked = false;
        this.isAllMythicACHUnlocked = false;
        this.isAllAbilitiesACHUnlocked = false;
        this.isAllMeleeACHUnlocked = false;

        this.totalAchievements = 0;
    }
    #endregion
}

