using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverUpgrades : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject hoverGlow;
    private GameObject iconGlow;
    private Button button;
    public bool isHovering;
    public static bool endingTransitionPlaying;

    private float hoverTime;
    private float originalYPosition = -135f;
    private float hoverYOffset = 0.15f;

    public bool animPlaying;
    public static bool setSmallEnemy, setSpeedster, setSharpshooter, setSniper, setGunner, setHeavyshot, setBrute, setTitan;
    public Choises choisesScript;

    public GameObject soundManager;
    public AudioManager audioManager;

    private void Awake()
    {
        soundManager = GameObject.Find("Audio");
        audioManager = soundManager.GetComponent<AudioManager>();

        //smallEnemyText = transform.Find("smallEnemiesStartSpawning");
        hoverTime = 0.15f;
        hoverYOffset = 25f;

        // Find the child GameObjects by name
        hoverGlow = transform.Find("HoverGlow").gameObject;
        iconGlow = transform.Find("IconGlow").gameObject;

        // Ensure the child GameObjects are initially inactivefr
        hoverGlow.SetActive(false);
        iconGlow.SetActive(false);

        button = GetComponent<Button>();
        button.onClick.AddListener(ChooseAbility);
      
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Animator>().enabled = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(Choises.abilititesTotalWaitTime);
        gameObject.GetComponent<Animator>().enabled = false;
    }

    private void OnEnable()
    {
        if(Choises.choseShootSmallBullets == true) { choseUzi = true; }
        if (Choises.chose_gun2 == true) { chosePistol = true; }
        if (Choises.chose_gun2 == true) { choseShotgun = true; }
        if (Choises.choseTrippleShot == true) { choseDeagle = true; }
        if (Choises.chooseHomingBullets == true) { choseAwp = true; }
        if (Choises.chooseBigPiercingBulletGun == true) { choseCannon = true; }
        if (Choises.choseGunMp4 == true) { choseMP4 = true; }
        if (Choises.choseCrossBow == true) { choseCrossbow = true; }

        animPlaying = false;
        StartCoroutine(Wait());
        hoverGlow.SetActive(false);
        iconGlow.SetActive(false);
    }

    public void Update()
    {
       if(Choises.noHoverGlow == true)
        {
            hoverGlow.SetActive(false);
            iconGlow.SetActive(false);
        }
    }

    public void CheckChild()
    {
        //Check if this gameObject have a child named "button"
    }

    public static Vector2 abilityPos;
    private bool choseUzi, chosePistol, choseShotgun, choseDeagle, choseAwp, choseCannon, choseMP4, choseCrossbow;

    public void ChooseAbility()
    {
        SettingsOptions.totalAbilitiesChosen += 1;
        abilityPos = gameObject.transform.localPosition;

        if (gameObject.name == "Ending1_BossFight" || gameObject.name == "Ending2_HordeOfEnemies" || gameObject.name == "Ending3_ButtonVSButton" || gameObject.name == "Ending4_DangerButton")
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
        else
        {
        }

        Transform smallEnemyTextChild = transform.Find("smallEnemiesStartSpawning");
        Transform speedsterTextChild = transform.Find("speedsterStartSpawning");
        Transform shaprhsooterTextChild = transform.Find("sharpshooterStartSpawning");
        Transform ragingGunnerTextChild = transform.Find("ragingGunnerStartsSpawning");
        Transform heavyShotTextChild = transform.Find("heavyshotStartsSpawning");
        Transform sniperTextChild = transform.Find("sniperStartSpawning");
        Transform bruteTextChild = transform.Find("bruteSpawning");
        Transform titanTextChild = transform.Find("titanSpawning");

        if (smallEnemyTextChild != null) { setSmallEnemy = true;  }

        if (speedsterTextChild != null) { setSpeedster = true; }

        if (shaprhsooterTextChild != null) { setSharpshooter = true; }

        if (ragingGunnerTextChild != null) { setGunner = true; }

        if (heavyShotTextChild != null) { setHeavyshot = true; }

        if (sniperTextChild != null) { setSniper = true; }

        if (bruteTextChild != null) { setBrute = true; }

        if (titanTextChild != null) { setTitan = true; }

        #region Set Gun Ability Texts
        //Guns
        if (gameObject.gameObject.name == "Choise_Chaotic_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            if (choseUzi == true) { choisesScript.SetEnemyStats(1, false);  }
            Choises.smallBulletSpeed += Choises.uziSpeedIncrease;
            Choises.smallBulletDamage += Choises.uziDamageIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Pistol_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            if (chosePistol == true) { choisesScript.SetEnemyStats(2, false); }
            Choises.bulletGun1_Damage += Choises.pistolDamageIncrease;
            Choises.bulletGun1_Speed += Choises.pistolSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Shotgun_Rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            if (choseShotgun == true) { choisesScript.SetEnemyStats(3, false); }
            Choises.shotGunBulletDamage += Choises.shotgunDamageIncrease;
            Choises.shotGunBulletDamage2 += Choises.shotgunDamageIncrease;
            Choises.shotGunBulletSpeed1 += Choises.shotgunSpeedIncrease;
            Choises.shotGunBulletSpeed2 += Choises.shotgunSpeedIncrease;
            Choises.shotGunBullets += Choises.shotgunShotsIncrease;
        }
        if (gameObject.gameObject.name == "Choise_HomingGun_Rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            if (choseAwp == true) { choisesScript.SetEnemyStats(4, false); }
            Choises.homingBulletDamage += Choises.awpDamageIncrease;
            Choises.homignBulletSpeed += Choises.awpSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_CrossBow_Rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            if (choseCrossbow == true) { choisesScript.SetEnemyStats(5, false); }
            Choises.crossbowDamage += Choises.crossbowDamageIncrease;
            Choises.crossbowSpeed += Choises.crossbowSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_TrippleShot_Rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            if (choseDeagle == true) { choisesScript.SetEnemyStats(6, false); }
            Choises.trippleShotDamage += Choises.deagleDamageIncrease;
            Choises.trippleShotSpeed += Choises.deagleSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Mp4_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            if (choseMP4 == true) { choisesScript.SetEnemyStats(8, false); }
            Choises.mp4Damage += Choises.mp4DamageIncrease;
            Choises.mp4Speed += Choises.mp4SpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Cannon_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            if (choseCannon == true) { choisesScript.SetEnemyStats(7, false); }
            Choises.bigBulletDamage += Choises.cannonDamageIncrease;
            Choises.bigBulletSpeed += Choises.cannonSpeedIncrease;
        }

        //Common
        if (gameObject.gameObject.name == "Choise_ChaticGunImproved_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(1, true);
            Choises.smallBulletSpeed += Choises.uziCommonSpeedIncrease;
            Choises.smallBulletDamage += Choises.uziCommonDamageIncrease;
        }
        if (gameObject.gameObject.name == "Choise_PistolImproved_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(2, true);
            Choises.bulletGun1_Damage += Choises.pistolCommonDamageIncrease;
            Choises.bulletGun1_Speed += Choises.pistolCommonSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_ShotgunImproved_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(3, true);
            Choises.shotGunBulletDamage += Choises.shotgunCommonDamageIncrease;
            Choises.shotGunBulletDamage2 += Choises.shotgunCommonDamageIncrease;
            Choises.shotGunBulletSpeed1 += Choises.shotgunCommonSpeedIncrease;
            Choises.shotGunBulletSpeed2 += Choises.shotgunCommonSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_CannonImproved_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(7, true);
            Choises.bigBulletDamage += Choises.cannonCommonDamageIncrease;
            Choises.bigBulletSpeed += Choises.cannonCommonSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_HomingGunImproved_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(4, true);
            Choises.homingBulletDamage += Choises.awpCommonDamageIncrease;
            Choises.homignBulletSpeed += Choises.awpCommonSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Mp4_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(8, true);
            Choises.mp4Damage += Choises.mp4CommonDamageIncrease;
            Choises.mp4Speed += Choises.mp4CommonSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Crossbow_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(5, true);
            Choises.crossbowDamage += Choises.crossbowCommonDamageIncrease;
            Choises.crossbowSpeed += Choises.crossbowCommonSpeedIncrease;
        }
        if (gameObject.gameObject.name == "Choise_TrippleShot_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(6, true);
            Choises.trippleShotDamage += Choises.deagleCommonDamageIncrease;
            Choises.trippleShotSpeed += Choises.deagleCommonSpeedIncrease;
        }
        #endregion

        #region Set Other Ranged
        if (gameObject.gameObject.name == "Choise_ChargedBullets_rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            choisesScript.SetEnemyStats(9, false);
            Choises.chargedBulletMaxDamage += Choises.chargedBulletMaxDamageIncrease;
            Choises.chargedBulletChargeTime -= Choises.chargedBulletChargeTimeIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Arrows_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(10, false);
            Choises.arrowCountShot += Choises.arrowCountIncrease;
            Choises.arrowDamage += Choises.arrowDamageIncrease;
        }

        if (gameObject.gameObject.name == "Choise_ChargedBullets_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(9, true);
            Choises.chargedBulletMaxDamage += Choises.chargedBulletcommonMaxDamageIncrease;
            Choises.chargedBulletChargeTime -= Choises.chargedBulletcommonChargeTimeIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Arrows_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(10, true);
            Choises.arrowCountShot += Choises.arrowCommonCountIncrease;
            Choises.arrowDamage += Choises.arrowCommonDamageIncrease;
        }
        #endregion

        #region Melee
        if (gameObject.gameObject.name == "Choise_BoxingGlove_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(11, false);
            Choises.boxingGloveKnockbackAmount += Choises.boxingGloveForceIncrease;
        }
        if (gameObject.gameObject.name == "Choise_StabbingSpikes_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(12, false);
            Choises.stabbingSpikeDamage += Choises.stabbySpikeDamageIncrease;
            Choises.stabbySpikeUpgradeCount += 1;
        }
        if (gameObject.gameObject.name == "Choise_SmallSpikes_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(13, false);
            Choises.spikeDamagePerSecond += Choises.smallSpikedDamageIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SpinningKnifes_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(14, false);
            Choises.knifeDamage += Choises.knifeDamageIncrease;
            Choises.knifeTotalCount += Choises.knifeCountIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SawBlade_Rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            choisesScript.SetEnemyStats(15, false);
            Choises.sawBladeSpeed += Choises.sawBladeSpeedIncrease;
            Choises.sawBladeDamage += Choises.sawBladeDamageIncrease;
            Choises.sawBladeUpgradeCount += 1;
        }
        if (gameObject.gameObject.name == "Choise_SpinningSword_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(16, false);
            Choises.swordSpeed += Choises.swordSpeedIncrease;
            Choises.bigSpikeDamage += Choises.swordDamageIcrease;
            Choises.swordUpgradeCount += 1;
        }
        if (gameObject.gameObject.name == "Choise_Hammer_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(17, false);
            Choises.hammerDamage += Choises.hammerDamageIncrease;
            Choises.hammerStunTime += Choises.hammerStunTimeIncrease;
        }

        //Common
        if (gameObject.gameObject.name == "Choise_BoxingGlove_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(11, true);
            Choises.boxingGloveKnockbackAmount += Choises.boxingGloveCommonForceIncrease;
        }
        if (gameObject.gameObject.name == "Choise_StabbingSpikes_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(12, true);
            Choises.stabbingSpikeDamage += Choises.stabbySpikeCommonDamageIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SmallSpikes_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(13, true);
            Choises.spikeDamagePerSecond += Choises.smallSpikesCommonDamageIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SpinningKnifes_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(14, true);
            Choises.knifeDamage += Choises.knifeCommonDamageIncrease;
            Choises.knifeTotalCount += Choises.knifeCommonCountIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SawBlade_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(15, true);
            Choises.sawBladeSpeed += Choises.sawBladeCommonSpeedIncrease;
            Choises.sawBladeDamage += Choises.sawBladeCommonDamageIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SwordImproved_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(16, true);
            Choises.swordSpeed += Choises.swordCommonSpeedIncrease;
            Choises.bigSpikeDamage += Choises.swordCommonDamageIcrease;
        }
        if (gameObject.gameObject.name == "Choise_Hammer_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(17, true);
            Choises.hammerDamage += Choises.hammerCommonDamageIncrease;
            Choises.hammerStunTime += Choises.hammerCommonStunTimeIncrease;
        }
        #endregion

        #region Defense
        if (gameObject.gameObject.name == "Choise_HealthBar_Common")
        {
            CommonSound();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            Choises.buttonHealth += Choises.currentHealthIncrease;
            Choises.maxButtonHealth += Choises.currentHealthIncrease;
            Choises.healthRegenPerSecond += Choises.currentHealthRegenIncrease;
        }
        if (gameObject.gameObject.name == "Choise_BigHeart_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(24, false);
            Choises.bigHeartHPHeal += Choises.currentBigHeartHealIncrease;
            Choises.bigHeartClicksNeeded -= Choises.currentBigHeartClicksIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SmallShields_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(25, false);
            Choises.smallShieldUpgradeCount += 1;
            Choises.smallShieldHP += Choises.smallShieldHPIncrease;
            Choises.smallShieldRechargeTimer -= Choises.smallShiledRechargeDecrease;
        }
        if (gameObject.gameObject.name == "Choise_ButtonShield_Rare")
        {
            RareSound();
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            choisesScript.SetEnemyStats(26, false);
            Choises.bouncyShieldUpgradeCount += 1;
            Choises.shieldBounce_health += Choises.shieldBounceHPIncrease;
            Choises.reChargeTimer -= Choises.shieldBounceRechargeDecrease;
        }

        //Common
        if (gameObject.gameObject.name == "Choise_BigHeart_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(24, true);
            Choises.bigHeartHPHeal += Choises.bigHeartCommonHealIncrease;
        }
        if (gameObject.gameObject.name == "Choise_SmallShields_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(25, true);
            Choises.smallShieldHP += Choises.smallShieldCommonHPIncrease;
            Choises.smallShieldRechargeTimer -= Choises.smallShiledCommonRechargeDecrease;
        }
        if (gameObject.gameObject.name == "Choise_ButtonShieldUpgrade_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(26, true);
            Choises.shieldBounce_health += Choises.shieldBounceCommonHPIncrease;
            Choises.reChargeTimer -= Choises.shieldBounceCommonRechargeDecrease;
        }
        #endregion

        #region Other
        if (gameObject.gameObject.name == "Choise_PointsDrop_Uncommon")
        {
            UncommonSound();
            choisesScript.ChoseUncommonSetChance();
            SettingsOptions.totalUncommonAbilititesChosen += 1;
            choisesScript.SetEnemyStats(27, false);

            Choises.pointDropBasicPoints += Choises.uncommonBasicPointIncrease;
            Choises.pointDropRarityIncreasePoints += Choises.uncommonPointRarityIncrease;
        }
        if (gameObject.gameObject.name == "Choise_ReRoll5X_Rare")
        {
            RareSound();
            Choises.rerollRareFirst = true;
            choisesScript.ChoseRareSetChance();
            SettingsOptions.totalRareAbilitiesChose += 1;
            Choises.rerollClicksNeeded -= Choises.rerollClicksDeacreseRare;
            Choises.rerollDoubleChance += Choises.rerollDoubleChanceIncrease;
        }
        if (gameObject.gameObject.name == "Choise_ReRoll3X_Legendary")
        {
            LegendarySound();
            Choises.rerollLegendaryFirst = true;
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            Choises.rerollClicksNeeded -= Choises.rerollClicksDeacreseRare;
               Choises.rerollDoubleChance += Choises.rerollDoubleChanceIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Invincibility_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(19, false);
            Choises.invincibilityTimeAdded += Choises.invincibilityTimeAddedIncrease;
            Choises.invincibilityClickPer1Second -= Choises.invincibilityClicksDecrease;
        }
        if (gameObject.gameObject.name == "Choise_Ritual_Legendary")
        {
            LegendarySound();
            choisesScript.ChoseLegendarySetChance();
            SettingsOptions.totalLegendaryAbilitiesChosen += 1;
            Choises.ritualClicksNeeded -= Choises.ritualClicksIncrease;
            Choises.ritualTimer += Choises.ritualTimerIncrease;
            choisesScript.SetEnemyStats(32, false);
        }
        if (gameObject.gameObject.name == "Choise_Pausetime_Mythic")
        {
            choisesScript.ChoseMythicSetChance();
            SettingsOptions.totalMythicAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(21, false);
            Choises.stopTimeTimer += Choises.stopTimeTimeIncrease;
            Choises.stopTimeClickTotal -= Choises.stopTimeClicksDecrease;
        }

        //Common
        if (gameObject.gameObject.name == "Choise_PointsDrop_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(27, true);
            Choises.pointDropBasicPoints += Choises.commonBasicPointIncrease;
            Choises.pointDropRarityIncreasePoints += Choises.commonPointRarityIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Invincibility_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(19, true);
            Choises.invincibilityTimeAdded += Choises.invincibilityCommonTimeAddedIncrease;
            Choises.invincibilityClickPer1Second -= Choises.invincibilityCommonClicksDecrease;
        }
        if (gameObject.gameObject.name == "Choise_Ritual_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(32, true);
            Choises.ritualClicksNeeded -= Choises.ritualCommonClicksIncrease;
            Choises.ritualTimer += Choises.ritualTimerIncrease;
        }
        if (gameObject.gameObject.name == "Choise_Pausetime_Common")
        {
            CommonSound();
            choisesScript.ChoseCommonSetChance();
            SettingsOptions.totalCommonAbilitiesChosen += 1;
            choisesScript.SetEnemyStats(21, true);
            Choises.stopTimeTimer += Choises.stopTimeCommonTimeIncrease;
            Choises.stopTimeClickTotal -= Choises.stopTimeCommonClicksDecrease;
        }

        //Skull harvest
        if (Choises.choseSkullHarvest == true)
        {
            if (gameObject.gameObject.name == "Choise_SoulSucker_Mythic")
            {
                MythicSound();
                choisesScript.ChoseMythicSetChance();
                SettingsOptions.totalMythicAbilitiesChosen += 1;

                if (Choises.skullHarvestStatDivide > Choises.minumumSkullHarvest)
                {
                    Choises.skullHarvestStatDivide -= 15;
                }
                choisesScript.SetEnemyStats(22, false);
            }
            if (gameObject.gameObject.name == "Choise_SoulSucker_Common")
            {
                CommonSound();
                choisesScript.ChoseCommonSetChance();
                SettingsOptions.totalCommonAbilitiesChosen += 1;
                if (Choises.skullHarvestStatDivide > Choises.minumumSkullHarvest)
                {
                    Choises.skullHarvestStatDivide -= 3;
                }
                choisesScript.SetEnemyStats(22, true);
            }
        }
        #endregion

        SetCursors.hoveringClickableStuff = false;
        Cursor.visible = true;
    }

    public void CommonSound()
    {
        audioManager.Play("SelectAbility");
    }

    public void UncommonSound()
    {
        audioManager.Play("SelectAbilityUncommon");
    }

    public void RareSound()
    {
        audioManager.Play("SelectAbilityRare");
    }

    public void LegendarySound()
    {
        audioManager.Play("SelectAbilityLegendary");
    }

    public void MythicSound()
    {
        audioManager.Play("SelectAbilityMythic");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MobileScript.isMobile == false) { Cursor.visible = false; }
       
        SetCursors.hoveringClickableStuff = true;
        audioManager.Play("hover");
        if (Choises.noHoverGlow == false)
        {
            if (hoverGlow != null)
                hoverGlow.SetActive(true);

            if (iconGlow != null)
                iconGlow.SetActive(true);
        }

        if (endingTransitionPlaying == false)
        {
              StartCoroutine(MoveObject(transform.localPosition.y, originalYPosition + hoverYOffset, hoverTime)); 
        }
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.visible = true;
        SetCursors.hoveringClickableStuff = false;
        if (Choises.noHoverGlow == false)
        {
            if (hoverGlow != null)
                hoverGlow.SetActive(false);

            if (iconGlow != null)
                iconGlow.SetActive(false);
        }

        if (endingTransitionPlaying == false)
        {
            StartCoroutine(MoveObject(transform.localPosition.y, originalYPosition, hoverTime));
        }
        isHovering = false;
    }

    private IEnumerator MoveObject(float startY, float endY, float time)
    {
        animPlaying = true;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            float newY = Mathf.Lerp(startY, endY, elapsedTime / time);
            transform.localPosition = new Vector3(transform.localPosition.x, newY, transform.localPosition.z);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, endY, transform.localPosition.z);
        animPlaying = false;
    }

}
