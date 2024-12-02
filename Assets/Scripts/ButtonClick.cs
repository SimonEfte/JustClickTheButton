using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour, IDataPersistence
{
    public static float pointsPerClick;
    public static float pointsNeeded, pointsGained;
    public Slider slider;

    public static int level;
    public TextMeshProUGUI levelText, pointsNeededText;

    public static bool leveledUp;

    public GameObject buttonObject, buttonObjectBounce;

    public float animationDuration;

    public GameObject choise1Bar, choise2Bar, choise3Bar;
    public float slideSpeed;
    public float slideDistance;
    public float slideDuration;
    private Coroutine slideCoroutine;

    public bool isSliderVisible;

    public GameObject gun_RandomDirection, uziBulletStartingPos;

    //Button bounce
    private Rigidbody2D rb;
    public float minForceMagnitude;  
    public float maxForceMagnitude;

    public static bool checkIfEnemiesOnScreen;
    public AudioManager audioManager;

    public void Start()
    {
        StartCoroutine(WaitForSaves());
    }
   
    IEnumerator WaitForSaves()
    {
        yield return new WaitForSeconds(0.5f);
        buttonObject.GetComponent<Rigidbody2D>();

        minForceMagnitude = 13;
        maxForceMagnitude = 18;

        isSliderVisible = true;

        animationDuration = 0.8f;
        slideSpeed = 100;
        slideDistance = 75;
        slideDuration = 0.25f;

        //pointsNeeded = 100;
        //pointsGained = 0;

        slider.value = pointsGained;
        slider.minValue = 0;
        slider.maxValue = pointsNeeded;

        arrowSpeed = 45;

        //pointsPerClick = 10;

        levelText.text = "LVL " + level;
        pointsNeededText.text = pointsNeeded + "/" + pointsGained;

        initialRotation = buttonObject.transform.rotation;
    }

    public float enemiesExtraPoints;
    public static bool ritualStopped;

    void Update()
    {
        if (Choises.bossChosenSetStuffInactive == true || Choises.playerDied || Choises.isInWinScreen == true)
        {
            if(ritualStopped == false)
            {
                ritualStopped = true;
                StopRitual();
            }
        }

        if (SettingsOptions.leftClickSeleced == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Choises.isPaused == false)
                {
                    JustClickTheButton();
                }
            }
        }

        if (SettingsOptions.spaceBarSelected == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Choises.isPaused == false)
                {
                    JustClickTheButton();
                }
            }
        }

        buttonObject.transform.position = buttonObjectBounce.transform.position;

        if (slider.transform.localPosition.x > 0)
        {
            isSliderVisible = true;
            slider.transform.localPosition = new Vector3(0, slider.transform.localPosition.y, slider.transform.localPosition.z);
            return; // Exit the method if already at or past 0
        }

        pointsNeededText.text = slider.value.ToString("F0") + "/" + slider.maxValue.ToString("F0");
        slider.value = pointsGained;
        slider.maxValue = pointsNeeded;

        //enemiesExtraPoints = 0.04f * Choises.numberOfEnemiesActive;

        if (slider.value >= slider.maxValue && Choises.isInWinScreen == false && Choises.isInDeathScreen == false)
        {
            pointsGained = 0;
            if(Choises.firstWeaponChosen == false)
            {
                if (pointsNeeded >= 2000) { pointsNeeded *= 1.1f; }
                else if (pointsNeeded >= 1000) { pointsNeeded *= 1.15f; }
                else if (pointsNeeded >= 500) { pointsNeeded *= 1.2f; }
                else if (pointsNeeded < 100) { pointsNeeded *= 1.55f; }
                else if (pointsNeeded < 200) { pointsNeeded *= 1.45f; }
                else if (pointsNeeded < 500) { pointsNeeded *= 1.35f; }
            }
            else
            {
                if (pointsNeeded >= 100000000000000) { pointsNeeded *= 1.004f; }
                else if(pointsNeeded >= 10000000000000) { pointsNeeded *= 1.006f; }
                else if(pointsNeeded >= 1000000000000) { pointsNeeded *= 1.008f; }
                else if (pointsNeeded >= 100000000000) { pointsNeeded *= 1.01f; }
                else if (pointsNeeded >= 10000000000) { pointsNeeded *= 1.011f; }
                else if (pointsNeeded >= 1000000000) { pointsNeeded *= 1.012f; }
                else if (pointsNeeded >= 100000000) { pointsNeeded *= 1.013f; }
                else if (pointsNeeded >= 50000000) { pointsNeeded *= 1.015f; }
                else if (pointsNeeded >= 25000000) { pointsNeeded *= 1.025f; }
                else if (pointsNeeded >= 10000000) { pointsNeeded *= 1.033f; }
                else if (pointsNeeded >= 5000000) { pointsNeeded *= 1.042f; }
                else if (pointsNeeded >= 3000000) { pointsNeeded *= 1.052f; }
                else if (pointsNeeded >= 2000000) { pointsNeeded *= 1.062f; }
                else if (pointsNeeded >= 1000000) { pointsNeeded *= 1.073f; }
                else if (pointsNeeded >= 100000) { pointsNeeded *= 1.082f; }
                else if (pointsNeeded >= 20000) { pointsNeeded *= 1.1f; }
                else if (pointsNeeded >= 10000) { pointsNeeded *= 1.12f; }
                else if (pointsNeeded >= 5000) { pointsNeeded *= 1.16f; }
                else if (pointsNeeded >= 2500) { pointsNeeded *= 1.18f; }
                else if (pointsNeeded >= 1250) { pointsNeeded *= 1.2f; }
                else if (pointsNeeded >= 500) { pointsNeeded *= 1.25f; }
                else if (pointsNeeded < 100) { pointsNeeded *= 1.7f; }
                else if (pointsNeeded < 500) { pointsNeeded *= 1.35f; }
            }

            //Debug.Log(pointsNeeded);

            leveledUp = true;

            audioManager.Play("LevelUp1");

            level += 1;
            if(level >= SettingsOptions.furthestRunLevel)
            {
                SettingsOptions.furthestRunLevel = level;
            }

            SettingsOptions.totalLevels += 1;

            StartCoroutine(LevelUpAnim());
        }

        #region autoButtonClick
        if(Choises.choseIdleClicking == true && autoClick == true)
        {
            idleClicks = StartCoroutine(AutoButtonClick());
            autoClick = false;
        }
        #endregion
    }
    
    IEnumerator LevelUpAnim()
    {
        levelText.gameObject.GetComponent<Animator>().SetTrigger("Anim");
        yield return new WaitForSecondsRealtime(0.16f);
        levelText.text = "LVL " + level;
    }


    public static bool autoClick;
    public Coroutine idleClicks;
    IEnumerator AutoButtonClick()
    {
        yield return new WaitForSecondsRealtime(Choises.timeBetweenClicks);
        if (Choises.isPaused == false && SettingsOptions.isInSettings == false && Choises.isHordeTransition == false && Choises.isBossTransition == false && Choises.isChampionTransition == false && Choises.isInFirstWeaponScreen == false)
        {
            SettingsOptions.totalIdleClicks += 1;
            AllButtonClickMechanics();
        }
        autoClick = true;
    }

    public static bool shootPistol, shootShotgun, shootMp4, shootCrossbow, shootTrippleShot;

    public void JustClickTheButton()
    {
        if (Choises.isInMainManu == false && Choises.isInDeathScreen == false && SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && DangerButtonEnding.isPlayingDangerButton == false && Choises.isInFirstWeaponScreen == false)
        {
            AllButtonClickMechanics();
            if (Choises.choseDoubleTap == true) { AllButtonClickMechanics(); }
        }
    }

    public bool hitCrit, didNotHitCrit;
    public float pointsAmount;
    public static bool isStopTimeAbilityActive;
    public static int knifeCount;
    public bool doubleRerooll;
    public static bool stabSpikes;
    public OverlappingSounds overlappAudio;
    public Image stopWatchFillImage;

    public void AllButtonClickMechanics()
    {
        SettingsOptions.totalButtonClicks += 1;

        #region Reroll
        if (Choises.choseReroll == true)
        {
            Choises.rerollClicks += 1;
            if(Choises.rerollClicks >= Choises.rerollClicksNeeded)
            {
                Choises.rerollClicks = 0;
                float random = Random.Range(0f,100f);
                if(random < Choises.rerollDoubleChance)
                {
                    doubleRerooll = true;
                    Choises.rerollsAviable += 2;
                }
                else
                {
                    Choises.rerollsAviable += 1;
                    doubleRerooll = false;
                }
                StartCoroutine(TextAnim(pointsAmount, false, 3));
            }
        }
        #endregion

        #region hammer
        if (Choises.chooseHammer == true)
        {
            Choises.hammerClicks += 1;
            if(Choises.hammerClicks >= Choises.hammerClicksNeeded)
            {
                Choises.hammerClicks = 0;
                checkIfEnemiesOnScreen = true;
            }
        }
        #endregion

        #region points
        if (BossMechanics.fightingBossFight == false && HordeEnding.playingHordeEnding == false && MimicEnding.isPlayingChamptions == false && DangerButtonEnding.isPlayingDangerButton == false)
        {
            if (isSliderVisible == true)
            {
                if (Choises.choseCritClicks == true)
                {
                    float randomCrit = Random.Range(0f, 100f);
                    if (randomCrit < Choises.critClicksChance)
                    {
                        //overlappAudio.CritSounds();

                        SettingsOptions.totalCritClicks += 1;
                        pointsGained += ((pointsPerClick + Choises.totalIdlePoints) * Choises.critClicksBonus);
                        pointsAmount = ((pointsPerClick + Choises.totalIdlePoints) * Choises.critClicksBonus);
                        SettingsOptions.totalCritPoints += ((pointsPerClick + Choises.totalIdlePoints) * Choises.critClicksBonus);
                        SettingsOptions.totalPoints += ((pointsPerClick + Choises.totalIdlePoints) * Choises.critClicksBonus);
                        if(SettingsOptions.disablePointPopUp == 0)
                        {
                            StartCoroutine(TextAnim(pointsAmount, true, 1));
                        }
                    }
                    else
                    {
                        pointsGained += (pointsPerClick + Choises.totalIdlePoints);
                        pointsAmount = (pointsPerClick + Choises.totalIdlePoints);
                        SettingsOptions.totalPoints += (pointsPerClick + Choises.totalIdlePoints);
                        SettingsOptions.totalClickPoints += (pointsPerClick + Choises.totalIdlePoints);
                        if (SettingsOptions.disablePointPopUp == 0) { StartCoroutine(TextAnim(pointsAmount, false, 1)); }
                    }
                }
                if (Choises.choseCritClicks == false)
                {
                    pointsGained += (pointsPerClick + Choises.totalIdlePoints);
                    pointsAmount = (pointsPerClick + Choises.totalIdlePoints);
                    SettingsOptions.totalPoints += (pointsPerClick + Choises.totalIdlePoints);
                    SettingsOptions.totalClickPoints += (pointsPerClick + Choises.totalIdlePoints);
                    if (SettingsOptions.disablePointPopUp == 0) { StartCoroutine(TextAnim(pointsAmount, false, 1)); }
                }
            }
        }
        #endregion

        #region moves level bar
        /*
        if (slider.transform.localPosition.x < 0)
        {
            if (slideCoroutine != null)
            {
                StopCoroutine(slideCoroutine); // Stop the previous coroutine if it's running
            }

            slideCoroutine = StartCoroutine(SlideToPosition(new Vector3(slideDistance, 0, 0))); // Start the new sliding coroutine
        }*/
        #endregion

        #region Shoot uzi
        if (Choises.choseShootSmallBullets == true)
        {
            Choises.smallBulletClicks += 1;
            if (Choises.smallBulletClicks == Choises.clickPerSmallBullet)
            {
                StartCoroutine(CheckBulletCollision());
                Choises.smallBulletClicks = 0;
            }
        }
        #endregion

        #region shootHomingBullet
        if (Choises.chooseHomingBullets == true)
        {
            Choises.homingBulletClicks += 1;
         
            if (Choises.homingBulletClicks >= Choises.clicksPerHomingBullet)
            {
                mainButtonColliderScript.ShootAWP();
                //MainButtonCollider.setShootHoming = true;
                //StartCoroutine(ShootHomingBullet());
                Choises.homingBulletClicks = 0;
            }
        }
        #endregion

        #region shoot gun1
        if (Choises.chose_Gun1 == true)
        {
            Choises.pistolClicks += 1;
            if(Choises.pistolClicks >= Choises.pistolClicksNeeded)
            {
                mainButtonColliderScript.ShootPistol();
                Choises.pistolClicks = 0;
            }
        }
        #endregion

        #region shoot gun 2
        if (Choises.chose_gun2 == true)
        {
            Choises.shotGunClicks += 1;
            if (Choises.shotGunClicks >= Choises.shotGunClicksNeeded)
            {
                Choises.shotGunClicks = 0;
                mainButtonColliderScript.ShootShotgun();
            }
        }
        #endregion

        #region shoot gun 3
        if (Choises.choseGunMp4 == true)
        {
            Choises.mp4Clicks += 1;
            if(Choises.mp4Clicks >= Choises.mp4ClicksNeeded)
            {
                Choises.mp4Clicks = 0;
                mainButtonColliderScript.ShootMp4();
            }
        }
        #endregion

        #region shoot big piercing bullet
        if (Choises.chooseBigPiercingBulletGun == true)
        {
            Choises.bigBulletClicks += 1;
            if (Choises.bigBulletClicks == Choises.clicksPerBigBullet)
            {
                shootBigBullet = true;
                Choises.bigBulletClicks = 0;
            }
        }
        #endregion

        #region stopTime
        if(Choises.choseStopTime == true)
        {
            if(isStopTimeAbilityActive == false)
            {
                Choises.stopTimeClicks += 1;
                if (Choises.stopTimeClicks >= Choises.stopTimeClickTotal)
                {
                    Choises.stopTimeClicks = 0;
                    isStopTimeAbilityActive = true;

                    fillImage.SetActive(true);
                    stopWatchFillImage.fillAmount = 1f;
                    countdownText.text = Choises.stopTimeTimer.ToString("F2");
                    //if (Choises.choseHealthBar == true) { Choises.regenHealth = true; }

                    if(stopTimeCoroutine == null)
                    {
                        stopTimeCoroutine = StartCoroutine(StopTimeAbility());
                    }
                }
            }
        }
        #endregion

        #region invincibility clicks
        if (Choises.choseInvincibility == true)
        {
            Choises.incincibilityClicks += 1;
            if(Choises.incincibilityClicks >= Choises.invincibilityClickPer1Second)
            {
                Choises.incincibilityClicks = 0;
                Choises.invincibilityTimer += Choises.invincibilityTimeAdded;
                gotMoreInvTimer = true;
                StartCoroutine(TextAnim(pointsAmount, false, 2));
            }
        }
        #endregion

        #region Arrows
        if(Choises.choseArrows == true)
        {
            Choises.arrowClicks += 1;
            if (Choises.arrowClicks >= Choises.arrowClicksNeeded)
            {
                ShootArrows();
                Choises.arrowClicks = 0;
            }
        }
        #endregion

        #region Crossbow Arrow
        if (Choises.choseCrossBow == true)
        {
            Choises.crossbowClicks += 1;
            if (Choises.crossbowClicks >= Choises.crossbowClicksNeeded)
            {
                mainButtonColliderScript.ShootCrossbow();
                Choises.crossbowClicks = 0;
            }
        }
        #endregion

        #region Tripple shot
        if (Choises.choseTrippleShot == true)
        {
            Choises.trippleShotClick += 1;
            if (Choises.trippleShotClick >= Choises.trippleShotNeeded)
            {
                mainButtonColliderScript.ShootDeagle();
                Choises.trippleShotClick = 0;
            }
        }
        #endregion

        #region Knifes
        if (Choises.choseSpinningKnifes == true)
        {
            Choises.knifeClicks += 1;
            if (Choises.knifeClicks >= Choises.knifeClicksNeeded)
            {
                GetKnife();
                Choises.knifeClicks = 0;
            }
        }
        #endregion

        #region Big Heart
        if(Choises.chooseHeartCollect == true)
        {
            Choises.bigHearClicks += 1;
            if(Choises.bigHearClicks >= Choises.bigHeartClicksNeeded)
            {
                SpawnHeart();
                Choises.bigHearClicks = 0;
            }
        }
        #endregion

        #region Stabby SPiked
        Choises.stabbingSpikesClicks += 1;
        if (Choises.stabbingSpikesClicks >= Choises.stabbingSpikesClicksNeeded)
        {
            Choises.stabbingSpikesClicks = 0;
            stabSpikes = true;
        }
        #endregion

        #region Boxing glove
        Choises.boxingGloveClicks += 1;
        if (Choises.boxingGloveClicks >= Choises.boxingGloveClicksNeeded)
        {
            Choises.boxingGloveClicks = 0;
            MainButtonCollider.useBoxingGlove = true;
        }
        #endregion

        #region Ritual
        if(Choises.choseRitual == true)
        {
            Choises.ritualClicks += 1;
            if(Choises.ritualClicks >= Choises.ritualClicksNeeded)
            {
                if(HordeEnding.playingHordeEnding == false)
                {
                    if(isRitualSpawnedIn == false) { SpawnRitual(); }
                }
                Choises.ritualClicks = 0;
            }
        }
        #endregion

        AbilityClicksDisplay();
    }

    public MainButtonCollider mainButtonColliderScript;

    #region Spawn heart
    public void SpawnHeart()
    {
        GameObject heart = ObjectPool.instance.GetHeartFromPool();

        float randomScale = Random.Range(0.65f, 0.85f);
        heart.transform.localScale = new Vector2(randomScale, randomScale);

        if (BossMechanics.fightingBossFight == true)
        {
            int randomBossX = Random.Range(-2250, 2250);
            int randomBossY = Random.Range(-500, -500);
            heart.transform.localPosition = new Vector2(randomBossX, randomBossY);
        }
        else
        {
            int random1 = Random.Range(-890 + -Choises.arenaSpawnPointChangeX, 890 + Choises.arenaSpawnPointChangeX);
            int random2 = Random.Range(475 + Choises.arenaSpawnPointChangeY, -475 + -Choises.arenaSpawnPointChangeY);
            heart.transform.localPosition = new Vector2(random1, random2);
        }
    }
    #endregion

    #region Check abilitys
    public void CheckAbilitysActive()
    {
        if (Choises.chose_Gun1 == true)
        {
            pistolTrigger.gameObject.SetActive(true);
            pistolCountdown.text = Choises.pistolClicksNeeded.ToString();
        }
        else { pistolTrigger.gameObject.SetActive(false); }

        if (Choises.choseShootSmallBullets == true)
        {
            uziTrigger.gameObject.SetActive(true);
            uziCountdown.text = Choises.clickPerSmallBullet.ToString();
        }
        else { uziTrigger.gameObject.SetActive(false); }

        if (Choises.chose_gun2 == true)
        {
            shotgunTrigger.gameObject.SetActive(true);
            shotgunCountdown.text = Choises.shotGunClicksNeeded.ToString();
        }
        else { shotgunTrigger.gameObject.SetActive(false); }

        if (Choises.chooseHomingBullets == true)
        {
            awpTrigger.gameObject.SetActive(true);
            awpCountdown.text = Choises.clicksPerHomingBullet.ToString();
        }
        else { awpTrigger.gameObject.SetActive(false); }

        if (Choises.choseCrossBow == true)
        {
            crossbowTrigger.gameObject.SetActive(true);
            crossbowCountdown.text = Choises.crossbowClicksNeeded.ToString();
        }
        else { crossbowTrigger.gameObject.SetActive(false); }

        if (Choises.choseTrippleShot == true)
        {
            trippleTrigger.gameObject.SetActive(true);
            trippleCountdown.text = Choises.trippleShotNeeded.ToString();
        }
        else { trippleTrigger.gameObject.SetActive(false); }

        if (Choises.chooseBigPiercingBulletGun == true)
        {
            cannonTrigger.gameObject.SetActive(true);
            cannonCountdown.text = Choises.clicksPerBigBullet.ToString();
        }
        else { cannonTrigger.gameObject.SetActive(false); }

        if (Choises.choseGunMp4 == true)
        {
            Mp4Trigger.gameObject.SetActive(true);
            Mp4Countdown.text = Choises.mp4ClicksNeeded.ToString();
        }
        else { Mp4Trigger.gameObject.SetActive(false); }

        if (Choises.chooseHeartCollect == true)
        {
            bigHeartTrigger.gameObject.SetActive(true);
            bigHeartCountdown.text = Choises.bigHeartClicksNeeded.ToString();
        }
        else { bigHeartTrigger.gameObject.SetActive(false); }

        if (Choises.chooseStabbingSpikes == true)
        {
            stabbySpikeTrigger.gameObject.SetActive(true);
            stabbySpikeCountdown.text = Choises.stabbingSpikesClicksNeeded.ToString();
        }
        else { stabbySpikeTrigger.gameObject.SetActive(false); }

        if (Choises.choseBoxingGlove == true)
        {
            boxingGloveTrigger.gameObject.SetActive(true);
            boxingGloveCountdown.text = Choises.boxingGloveClicksNeeded.ToString();
        }
        else { boxingGloveTrigger.gameObject.SetActive(false); }

        if (Choises.choseSpinningKnifes == true)
        {
            knifeTrigger.gameObject.SetActive(true);
            knifeCountdown.text = Choises.knifeClicksNeeded.ToString();
        }
        else { knifeTrigger.gameObject.SetActive(false); }

        if (Choises.choseInvincibility == true)
        {
            invinTrigger.gameObject.SetActive(true);
            invinCountdown.text = Choises.invincibilityClickPer1Second.ToString();
        }
        else { invinTrigger.gameObject.SetActive(false); }

        if (Choises.chooseHammer == true)
        {
            hammerTrigger.gameObject.SetActive(true);
            hammerCountdown.text = Choises.hammerClicksNeeded.ToString();
        }
        else { hammerTrigger.gameObject.SetActive(false); }

        if (Choises.choseArrows == true)
        {
            arrowTrigger.gameObject.SetActive(true);
            arrowCountdown.text = Choises.arrowClicksNeeded.ToString();
        }
        else { arrowTrigger.gameObject.SetActive(false); }

        if (Choises.choseRitual == true)
        {
            ritualTrigger.gameObject.SetActive(true);
            ritualCountdown.text = Choises.ritualClicksNeeded.ToString();
        }
        else { ritualTrigger.gameObject.SetActive(false); }

        if (Choises.choseStopTime == true)
        {
            stopwatchTrippger.gameObject.SetActive(true);
            stopwatchCountdown.text = Choises.stopTimeClickTotal.ToString();
        }
        else { stopwatchTrippger.gameObject.SetActive(false); }

        if (Choises.choseReroll == true)
        {
            rerollTrigger.gameObject.SetActive(true);
            rerollCountdown.text = Choises.rerollClicksNeeded.ToString();
        }
        else { rerollTrigger.gameObject.SetActive(false); }
    }
    #endregion

    #region Check active 
    public void CheckOnlyActive()
    {
        if (Choises.chose_Gun1 == true)
        {
            pistolTrigger.gameObject.SetActive(true);
        }
        else { pistolTrigger.gameObject.SetActive(false); }

        if (Choises.choseShootSmallBullets == true)
        {
            uziTrigger.gameObject.SetActive(true);
        }
        else { uziTrigger.gameObject.SetActive(false); }

        if (Choises.chose_gun2 == true)
        {
            shotgunTrigger.gameObject.SetActive(true);
        }
        else { shotgunTrigger.gameObject.SetActive(false); }

        if (Choises.chooseHomingBullets == true)
        {
            awpTrigger.gameObject.SetActive(true);
        }
        else { awpTrigger.gameObject.SetActive(false); }

        if (Choises.choseCrossBow == true)
        {
            crossbowTrigger.gameObject.SetActive(true);
        }
        else { crossbowTrigger.gameObject.SetActive(false); }

        if (Choises.choseTrippleShot == true)
        {
            trippleTrigger.gameObject.SetActive(true);
        }
        else { trippleTrigger.gameObject.SetActive(false); }

        if (Choises.chooseBigPiercingBulletGun == true)
        {
            cannonTrigger.gameObject.SetActive(true);
        }
        else { cannonTrigger.gameObject.SetActive(false); }

        if (Choises.choseGunMp4 == true)
        {
            Mp4Trigger.gameObject.SetActive(true);
        }
        else { Mp4Trigger.gameObject.SetActive(false); }

        if (Choises.chooseHeartCollect == true)
        {
            bigHeartTrigger.gameObject.SetActive(true);
        }
        else { bigHeartTrigger.gameObject.SetActive(false); }

        if (Choises.chooseStabbingSpikes == true)
        {
            stabbySpikeTrigger.gameObject.SetActive(true);
        }
        else { stabbySpikeTrigger.gameObject.SetActive(false); }

        if (Choises.choseBoxingGlove == true)
        {
            boxingGloveTrigger.gameObject.SetActive(true);
        }
        else { boxingGloveTrigger.gameObject.SetActive(false); }

        if (Choises.choseSpinningKnifes == true)
        {
            knifeTrigger.gameObject.SetActive(true);
        }
        else { knifeTrigger.gameObject.SetActive(false); }

        if (Choises.choseInvincibility == true)
        {
            invinTrigger.gameObject.SetActive(true);
        }
        else { invinTrigger.gameObject.SetActive(false); }

        if (Choises.chooseHammer == true)
        {
            hammerTrigger.gameObject.SetActive(true);
        }
        else { hammerTrigger.gameObject.SetActive(false); }

        if (Choises.choseArrows == true)
        {
            arrowTrigger.gameObject.SetActive(true);
        }
        else { arrowTrigger.gameObject.SetActive(false); }

        if (Choises.choseRitual == true)
        {
            ritualTrigger.gameObject.SetActive(true);
        }
        else { ritualTrigger.gameObject.SetActive(false); }

        if (Choises.choseStopTime == true)
        {
            stopwatchTrippger.gameObject.SetActive(true);
        }
        else { stopwatchTrippger.gameObject.SetActive(false); }

        if (Choises.choseReroll == true)
        {
            rerollTrigger.gameObject.SetActive(true);
        }
        else { rerollTrigger.gameObject.SetActive(false); }
    }
    #endregion

    #region Ability Clicks Display
    public Image pistolTrigger, cannonTrigger, uziTrigger, shotgunTrigger, awpTrigger, trippleTrigger, Mp4Trigger, crossbowTrigger, bigHeartTrigger, stabbySpikeTrigger, boxingGloveTrigger, knifeTrigger, invinTrigger, hammerTrigger, arrowTrigger, ritualTrigger, stopwatchTrippger, rerollTrigger;

    public TextMeshProUGUI pistolCountdown, cannonCountdown, uziCountdown, shotgunCountdown, awpCountdown, trippleCountdown, Mp4Countdown, crossbowCountdown, bigHeartCountdown, stabbySpikeCountdown, boxingGloveCountdown, knifeCountdown, invinCountdown, hammerCountdown, arrowCountdown, ritualCountdown, stopwatchCountdown, rerollCountdown;

    public void AbilityClicksDisplay()
    {
        if (Choises.chose_Gun1 == true)
        {
            pistolCountdown.text = (Choises.pistolClicksNeeded - Choises.pistolClicks).ToString();
            pistolTrigger.fillAmount = (float)Choises.pistolClicks / Choises.pistolClicksNeeded;
        }

        if (Choises.choseShootSmallBullets == true)
        {
            uziCountdown.text = (Choises.clickPerSmallBullet - Choises.smallBulletClicks).ToString();
            uziTrigger.fillAmount = (float)Choises.smallBulletClicks / Choises.clickPerSmallBullet;
        }

        if (Choises.chose_gun2 == true)
        {
            shotgunCountdown.text = (Choises.shotGunClicksNeeded - Choises.shotGunClicks).ToString();
            shotgunTrigger.fillAmount = (float)Choises.shotGunClicks / Choises.shotGunClicksNeeded;
        }

        if (Choises.chooseHomingBullets == true)
        {
            awpCountdown.text = (Choises.clicksPerHomingBullet - Choises.homingBulletClicks).ToString();
            awpTrigger.fillAmount = (float)Choises.homingBulletClicks / Choises.clicksPerHomingBullet;
        }

        if (Choises.choseCrossBow == true)
        {
            crossbowCountdown.text = (Choises.crossbowClicksNeeded - Choises.crossbowClicks).ToString();
            crossbowTrigger.fillAmount = (float)Choises.crossbowClicks / Choises.crossbowClicksNeeded;
        }

        if (Choises.choseTrippleShot == true)
        {
            trippleCountdown.text = (Choises.trippleShotNeeded - Choises.trippleShotClick).ToString();
            trippleTrigger.fillAmount = (float)Choises.trippleShotClick / Choises.trippleShotNeeded;
        }

        if (Choises.chooseBigPiercingBulletGun == true)
        {
            cannonCountdown.text = (Choises.clicksPerBigBullet - Choises.bigBulletClicks).ToString();
            cannonTrigger.fillAmount = (float)Choises.bigBulletClicks / Choises.clicksPerBigBullet;
        }

        if (Choises.choseGunMp4 == true)
        {
            Mp4Countdown.text = (Choises.mp4ClicksNeeded - Choises.mp4Clicks).ToString();
            Mp4Trigger.fillAmount = (float)Choises.mp4Clicks / Choises.mp4ClicksNeeded;
        }

        if (Choises.chooseHeartCollect == true)
        {
            bigHeartCountdown.text = (Choises.bigHeartClicksNeeded - Choises.bigHearClicks).ToString();
            bigHeartTrigger.fillAmount = (float)Choises.bigHearClicks / Choises.bigHeartClicksNeeded;
        }

        if (Choises.chooseStabbingSpikes == true)
        {
            stabbySpikeCountdown.text = (Choises.stabbingSpikesClicksNeeded - Choises.stabbingSpikesClicks).ToString();
            stabbySpikeTrigger.fillAmount = (float)Choises.stabbingSpikesClicks / Choises.stabbingSpikesClicksNeeded;
        }

        if (Choises.choseBoxingGlove == true)
        {
            boxingGloveCountdown.text = (Choises.boxingGloveClicksNeeded - Choises.boxingGloveClicks).ToString();
            boxingGloveTrigger.fillAmount = (float)Choises.boxingGloveClicks / Choises.boxingGloveClicksNeeded;
        }

        if (Choises.choseSpinningKnifes == true)
        {
            knifeCountdown.text = (Choises.knifeClicksNeeded - Choises.knifeClicks).ToString();
            knifeTrigger.fillAmount = (float)Choises.knifeClicks / Choises.knifeClicksNeeded;
        }

        if (Choises.choseInvincibility == true)
        {
            invinCountdown.text = (Choises.invincibilityClickPer1Second - Choises.incincibilityClicks).ToString();
            invinTrigger.fillAmount = (float)Choises.incincibilityClicks / Choises.invincibilityClickPer1Second;
        }

        if (Choises.chooseHammer == true)
        {
            hammerCountdown.text = (Choises.hammerClicksNeeded - Choises.hammerClicks).ToString();
            hammerTrigger.fillAmount = (float)Choises.hammerClicks / Choises.hammerClicksNeeded;
        }

        if (Choises.choseArrows == true)
        {
            arrowCountdown.text = (Choises.arrowClicksNeeded - Choises.arrowClicks).ToString();
            arrowTrigger.fillAmount = (float)Choises.arrowClicks / Choises.arrowClicksNeeded;
        }

        if (Choises.choseRitual == true)
        {
            ritualCountdown.text = (Choises.ritualClicksNeeded - Choises.ritualClicks).ToString();
            ritualTrigger.fillAmount = (float)Choises.ritualClicks / Choises.ritualClicksNeeded;
        }

        if (Choises.choseStopTime == true)
        {
            stopwatchCountdown.text = (Choises.stopTimeClickTotal - Choises.stopTimeClicks).ToString();
            stopwatchTrippger.fillAmount = (float)Choises.stopTimeClicks / Choises.stopTimeClickTotal;
        }

        if (Choises.choseReroll == true)
        {
            rerollCountdown.text = (Choises.rerollClicksNeeded - Choises.rerollClicks).ToString();
            rerollTrigger.fillAmount = (float)Choises.rerollClicks / Choises.rerollClicksNeeded;
        }
    }
    #endregion

    public bool gotMoreInvTimer;
    public static bool shootBigBullet;
    public Transform knifeRotateParent, knifeTopParent;

    #region Spawn Ritual
    public GameObject ritualObject, ritualSpawnIndicator;
    public Slider ritualSlider;
    public static Coroutine ritualCoroutine;
    public static bool isRitualSpawnedIn;

    public void StopRitual()
    {
        ritualSpawnIndicator.SetActive(false);
        ritualObject.SetActive(false);

        if (ritualCoroutine != null)
        {
            StopCoroutine(ritualCoroutine); ritualCoroutine = null;
        }
    }

    public void SpawnRitual()
    {
        ritualCoroutine = StartCoroutine(RitualSpawnAndDespawn());
    }

    IEnumerator RitualSpawnAndDespawn()
    {
        isRitualSpawnedIn = true;
        ritualSlider.maxValue = Choises.ritualTimer;
        ritualSlider.value = Choises.ritualTimer;
        ritualSlider.minValue = 0f;

        int randomBossX = Random.Range(-2000, 2000);
        int randomBossY = Random.Range(-450, -450);

        int random1 = Random.Range(-770 + -Choises.arenaSpawnPointChangeX, 770 + Choises.arenaSpawnPointChangeX);
        int random2 = Random.Range(359 + Choises.arenaSpawnPointChangeY, -350 + -Choises.arenaSpawnPointChangeY);

        if (BossMechanics.fightingBossFight == true)
        {
            ritualSpawnIndicator.transform.localPosition = new Vector2(randomBossX, randomBossY);
        }
        else
        {
            ritualSpawnIndicator.transform.localPosition = new Vector2(random1, random2);
        }

        ritualSpawnIndicator.SetActive(true);
        ritualSpawnIndicator.GetComponent<Animation>().Play("SpawnIndicator");
        yield return new WaitForSeconds(1.4f);
        ritualSpawnIndicator.SetActive(false);
       
        ritualObject.SetActive(true);

        if (BossMechanics.fightingBossFight == true)
        {
            ritualObject.transform.localPosition = new Vector2(randomBossX, randomBossY);
        }
        else
        {
            ritualObject.transform.localPosition = new Vector2(random1, random2);
        }

        ritualObject.transform.localScale = new Vector2(0.3f, 0.3f);
        SetAlpha(ritualObject.GetComponent<Image>(), 1f);

        float zeroTime = 0.0f;
        float ritualDeSpawnTime = Choises.ritualTimer;

        while (zeroTime < ritualDeSpawnTime)
        {
            ritualSlider.value -= Time.deltaTime;
            zeroTime += Time.deltaTime;
            yield return null;
        }

        SetAlpha(ritualObject.GetComponent<Image>(), 0f);
        yield return new WaitForSeconds(0.08f);
        ritualObject.SetActive(false);
        ritualCoroutine = null;
        isRitualSpawnedIn = false;
    }

    #endregion

    #region Get knifes
    public void GetKnife()
    {
        if (knifeCount < Choises.knifeTotalCount)
        {
            knifeCount += 1;
            GameObject knife = ObjectPool.instance.GetKnifeFromPool();
            knife.GetComponent<Transform>().SetParent(knifeTopParent);
            knife.transform.localRotation = Quaternion.Euler(0, 0, 180);
            knife.transform.localPosition = new Vector2(0, 225);
            StartCoroutine(SetRotatioKnife(knife));
        }
    }

    IEnumerator SetRotatioKnife(GameObject knife)
    {
        yield return new WaitForSeconds(0.1f);
        knife.GetComponent<Transform>().SetParent(knifeRotateParent);
    }
    #endregion

    #region shootSmallBullet
    IEnumerator CheckBulletCollision()
    {
        int random = Random.Range(1, 5);
        if (random == 1) { audioManager.Play("Uzi1"); }
        if (random == 2) { audioManager.Play("Uzi2"); }
        if (random == 3) { audioManager.Play("Uzi3"); }
        if (random == 4) { audioManager.Play("Uzi4"); }

        GameObject smallBullet = ObjectPool.instance.GetSmallBulletFromPool();
        smallBullet.transform.localScale = new Vector2(ObjectPool.uziBulletSize, ObjectPool.uziBulletSize);
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        float angle = Mathf.Atan2(randomDirection.y, randomDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        gun_RandomDirection.transform.rotation = rotation;

        smallBullet.transform.position = uziBulletStartingPos.transform.position;

        Rigidbody2D rb = smallBullet.GetComponent<Rigidbody2D>();

        rb.velocity = randomDirection * Choises.smallBulletSpeed;

        yield return new WaitForSeconds(Choises.smallBulletDeSpawnTime);

        StartCoroutine(ScaleDownBullets(smallBullet));
    }
    #endregion

    #region Shoot Homing Bullet

    public Transform homingBulletPos;
    IEnumerator ShootHomingBullet()
    {
        GameObject homingBullet = ObjectPool.instance.GetHomingBulletFromPool();
        homingBullet.transform.position = homingBulletPos.transform.position;

        yield return new WaitForSeconds(4f);
        ObjectPool.instance.ReturnHomingBulletFromPool(homingBullet);
    }
    #endregion

    #region slide bar to position
    IEnumerator SlideToPosition(Vector3 targetPosition)
    {
        Vector3 initialPosition = slider.transform.localPosition;
        float elapsedTime = 0.0f;

        while (elapsedTime < slideDuration)
        {
            slider.transform.localPosition = Vector3.Lerp(initialPosition, initialPosition + targetPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        slider.transform.localPosition = initialPosition + targetPosition; // Ensure the final position is accurate
    }
    #endregion

    #region Point Pop Up
    IEnumerator TextAnim(float points, bool crit, int typeOfPopUp)
    {
        GameObject pointText = ObjectPool.instance.GetPointTextFromPool();
        TextMeshProUGUI textMesh = pointText.GetComponent<TextMeshProUGUI>();
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, Mathf.Lerp(1f, 1f, 1f));

        Transform childTransform = pointText.transform.Find("Points");
        Transform childTransform2 = pointText.transform.Find("Invin");
        Transform childTransform3 = pointText.transform.Find("Dice");

        foreach (Transform child in pointText.transform)
        {
            if (typeOfPopUp == 1)
            {
                if (child.name == "Points") { child.gameObject.SetActive(true); }
                else { child.gameObject.SetActive(false); }

                pointText.GetComponent<TextMeshProUGUI>().text = "+" + points.ToString("F0");
                pointText.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (typeOfPopUp == 2)
            {
                if (child.name == "Invin") { child.gameObject.SetActive(true); }
                else { child.gameObject.SetActive(false); }

                if(Choises.invincibilityTimeAdded == 1) 
                {
                    pointText.GetComponent<TextMeshProUGUI>().text = $"+{Choises.invincibilityTimeAdded.ToString("F0")}S";
                }
                if (Choises.invincibilityTimeAdded > 1)
                {
                    pointText.GetComponent<TextMeshProUGUI>().text = $"+{Choises.invincibilityTimeAdded.ToString("F1")}S";
                }
                pointText.transform.GetChild(0).gameObject.SetActive(false);
            }
            if (typeOfPopUp == 3)
            {
                if (child.name == "Dice") { child.gameObject.SetActive(true); }
                else { child.gameObject.SetActive(false); }

                if(doubleRerooll == true) { pointText.GetComponent<TextMeshProUGUI>().text = "+2"; }
                if (doubleRerooll == false) { pointText.GetComponent<TextMeshProUGUI>().text = "+1"; }
                pointText.transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        float preferredWidth = textMesh.GetPreferredValues().x;
        textMesh.rectTransform.sizeDelta = new Vector2(preferredWidth, textMesh.rectTransform.sizeDelta.y);

        pointText.transform.localScale = new Vector3(0f, 0f, 0f);

        float maxOffset = 6.5f;

        // Get the position of the buttonObject
        Vector3 buttonPosition = buttonObject.transform.position;

        // Randomly offset the pointText position
        float xOffset = Random.Range(-maxOffset, maxOffset);
        float yOffset = Random.Range(-maxOffset, maxOffset);

        // Calculate the new position for pointText
        Vector3 newPosition = new Vector3(
            buttonPosition.x + xOffset,
            buttonPosition.y + yOffset,
            buttonPosition.z
        );

        pointText.transform.position = newPosition;

        // Start scaling up
        float scaleStartTime = Time.unscaledTime;
        float scaleEndTime = scaleStartTime + 0.15f; 
        while (Time.unscaledTime < scaleEndTime)
        {
            float t = (Time.unscaledTime - scaleStartTime) / (scaleEndTime - scaleStartTime);

            float randomTexTSize = Random.Range(0.9f, 1.35f);
            float randomTexTSize2 = Random.Range(2f, 2.5f);

            if (typeOfPopUp == 1)
            {
                pointText.GetComponent<TextMeshProUGUI>().color = Color.green;
                if (crit == false) { pointText.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(randomTexTSize, randomTexTSize, randomTexTSize), t); }
                if (crit == true) { pointText.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(randomTexTSize2, randomTexTSize2, randomTexTSize2), t); }
            }
            if (typeOfPopUp == 2)
            {
                pointText.GetComponent<TextMeshProUGUI>().color = Color.yellow;
                pointText.transform.localScale = Vector2.Lerp(Vector2.zero, new Vector2(1.6f, 1.6f), t);
            }
            if (typeOfPopUp == 3)
            {
                pointText.GetComponent<TextMeshProUGUI>().color = Color.yellow;
                pointText.transform.localScale = Vector2.Lerp(Vector2.zero, new Vector2(1.6f, 1.6f), t);
            }

            if (childTransform != null)
            {
                Color childColor = childTransform.GetComponent<Image>().color;
                childTransform.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(0f, 1f, t));
            }

            yield return null;
        }

        // Wait for 0.5 seconds (stand still)
        yield return new WaitForSecondsRealtime(0.6f);

        // Move up animation
        float moveUpStartTime = Time.unscaledTime;
        float moveUpDuration = 0.65f; // Total move up duration
        Vector3 initialPosition = pointText.transform.position;
        Vector3 targetPosition = initialPosition + 11 * Vector3.up * (moveUpDuration - 0.2f); // Adjust the direction as needed

        while (Time.unscaledTime - moveUpStartTime < moveUpDuration)
        {
            float t = (Time.unscaledTime - moveUpStartTime) / moveUpDuration;
            pointText.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            // Fade out gradually after 0.2 seconds
            if (Time.unscaledTime - moveUpStartTime > 0.2f)
            {
                float fadeT = (Time.unscaledTime - moveUpStartTime - 0.2f) / (moveUpDuration - 0.2f);
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, Mathf.Lerp(1f, 0f, fadeT));

                // Fade the child object as well
                if (typeOfPopUp == 1)
                {
                    if (childTransform != null)
                    {
                        Color childColor = childTransform.GetComponent<Image>().color;
                        childTransform.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(1f, 0f, fadeT));
                    }
                }
                if (typeOfPopUp == 2)
                {
                    if (childTransform2 != null)
                    {
                        Color childColor = childTransform2.GetComponent<Image>().color;
                        childTransform2.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(1f, 0f, fadeT));
                    }
                }
                if (typeOfPopUp == 3)
                {
                    if (childTransform3 != null)
                    {
                        Color childColor = childTransform3.GetComponent<Image>().color;
                        childTransform3.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(1f, 0f, fadeT));
                    }
                }

            }

            yield return null;
        }

        //yield return new WaitForSeconds(1.05f);
        ObjectPool.instance.ReturnPointTextFromPool(pointText);
    }


    #endregion

    #region Button Bounce
    public static bool isButtonMoving;
    public static float buttonMovingDamageBonus;
    private Coroutine bounceDamageCoroutine;
    #endregion

    #region Stop time
    public void StopStopTime()
    {
        if(stopTimeCoroutine != null) { StopCoroutine(stopTimeCoroutine); stopTimeCoroutine = null; }

        countdownText.text = "";
        stopWatchFillImage.fillAmount = 0f;
        fillImage.SetActive(false);
        isStopTimeActive = false;
        isStopTimeAbilityActive = false;
        Time.timeScale = 1;
    }

    public TextMeshProUGUI countdownText;
    public GameObject fillImage;
    public static bool isStopTimeActive;
    public Coroutine stopTimeCoroutine;

    IEnumerator StopTimeAbility()
    {
        audioManager.Play("stopTimeStart");

        float timer = Choises.stopTimeTimer;
        Time.timeScale = 0f;

        while (timer > 0f)
        {
            isStopTimeActive = true;
           
            // Update countdown text with decimal points
            countdownText.text = timer.ToString("F2");

            // Update fill amount based on the timer
            stopWatchFillImage.fillAmount = timer / Choises.stopTimeTimer;
            yield return null;

            if (Choises.isPaused == false && SettingsOptions.isInSettings == false) { timer -= Time.unscaledDeltaTime; }
            if (Choises.isPaused == true || SettingsOptions.isInSettings == true) { timer -= 0f; }

          // Decrease the timer by the interval
        }

        isStopTimeAbilityActive = false;
        if (Choises.isPaused == false) { Time.timeScale = 1; }

        // Clear the countdown text and set fill amount to zero after the timer is done
        countdownText.text = "";
        stopWatchFillImage.fillAmount = 0f;
        fillImage.SetActive(false);
        isStopTimeActive = false;
        stopTimeCoroutine = null;

        audioManager.Play("stopTimeOver");
    }
    #endregion

    #region Shoot Arrows
    public static bool shootArrows;
    public static Coroutine arrowCoroutine;

    public void ShootArrows()
    {
        if(arrowCoroutine == null) { arrowCoroutine = StartCoroutine(Arrows()); }
    }

    public static float arrowSpeed;


    IEnumerator Arrows()
    {
        audioManager.Play("ArrowsShow");
        int numberOfArrows = Choises.arrowCountShot;
        float angleIncrement = 360f / numberOfArrows;

        for (int i = 0; i < numberOfArrows; i++)
        {
            if (Choises.choseArrows == true)
            {
                GameObject arrow = ObjectPool.instance.GetArrowFromPool();
                Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
                rb.simulated = true;
                arrow.transform.position = buttonObject.transform.position;
                arrow.transform.localScale = new Vector2(ObjectPool.arrowSize, ObjectPool.arrowSize);

                float angle = i * angleIncrement;
                Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up; // Convert angle to direction

                rb.velocity = direction * arrowSpeed;

                // Set individual rotation for each arrow
                float arrowRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                arrow.transform.rotation = Quaternion.Euler(0, 0, arrowRotation);

                yield return new WaitForSeconds(0.01f);
            }
        }

        arrowCoroutine = null;
    }

    public void StopArrowCoroutine()
    {
        if(arrowCoroutine != null)
        {
            StopCoroutine(arrowCoroutine);
            arrowCoroutine = null;
        }
    }

    #endregion

    #region ScaleDownBullets
    IEnumerator ScaleDownBullets(GameObject bullet)
    {
        Vector2 bulletScale = bullet.transform.localScale;
        Vector2 zeroScale = new Vector2(0, 0);

        float duration = Random.Range(0.25f, 0.4f);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            bullet.transform.localScale = Vector2.Lerp(bulletScale, zeroScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ObjectPool.instance.ReturnSmallBulletFromPool(bullet);
    }
    #endregion

    #region Alpha Fade
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

    private Quaternion initialRotation;
    public void StopAllCoroutiness()
    {
        if(idleClicks != null) { StopCoroutine(idleClicks); }
        autoClick = true;
        arrowCoroutine = null;
    }

    public void LoadData(GameData data)
    {
        level = data.level;
        pointsPerClick = data.pointsPerClick;
        pointsNeeded = data.pointsNeeded;
        pointsGained = data.pointsGained;
    }

    public void SaveData(ref GameData data)
    {
        data.level = level;
        data.pointsPerClick = pointsPerClick;
        data.pointsNeeded = pointsNeeded;
        data.pointsGained = pointsGained;
    }
}
