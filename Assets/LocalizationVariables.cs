using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LocalizationVariables : MonoBehaviour
{
    public static bool englishLanguage, koreanLanguage, chineseLanguage, japaneseLanguage;

    #region Settings Variables
    public TextMeshProUGUI settings1, settings2;
    public TextMeshProUGUI fullscreen;
    #endregion

    #region Strings
    public static string pointPerClickIncrease, critChanceIncrease, critPointsIncrease, idleClicksIncrease;
    public static string healthIncrease, regenIncrease, bigHeartHealIncrease, bigHeartClicksNeededIncrease, bigHeartInfo, bigHeartName;

    public static string brokenUziName, brokenUziInfo, brokenUziSpeed, brokenUziDamage;
    public static string pistolName, pistolInfo, pistolSpeed, pistolDamage;
    public static string shotgunName, shotgunInfo, shotgunShots, shotgunSpeed, shotgunDamage;
    public static string awpName, awpInfo, awpSpeed, awpDamage, awpRarity;
    public static string crossbowName, crossbowInfo, crossbowSpeed, crossbowDamage;
    public static string deagleName, deagleInfo, deagleSpeed, deagleDamage;
    public static string mp4Name, mp4Info, mp4Speed, mp4Damage, mp4Rarity;
    public static string cannonName, cannonInfo, cannonSpeed, cannonDamage;

    public static string chargedBulletName, chargedBulletInfo, chargedBulletCount, chargedBulletDamage, chargedBulletTime;
    public static string arrowName, arrowInfo, arrowCount, arrowDamage;

    public static string smallShieldHP, smallShieldName, smallShieldInfo, smallShieldRechargeTime;
    public static string shieldBounceName, shieldBounceHP, shieldBounceInfo, shieldBounceRechargeTime;

    public static string commonAbility, commonAbilityUpgrade, uncommonAbility, uncommonAbilityUpgrade, rareAbility, rareAbilityUpgrade, legendaryAbility, legendaryAbilityUpgrade, mythicAbility, mythicAbilityUpgrade;

    public static string boxingGloveName, boxingGloveInfo, boxingGloveForce;
    public static string stabbySpikeName, stabbySpikeInfo, stabbySpikedDamage;
    public static string smallSpikeName, smallSpikeInfo, smallSPikedDamage;
    public static string knifeName, knifeInfo, knifeCount, knifeDamage;
    public static string sawBladeName, sawBladeInfo, sawBladeSpeed, sawBladeDamage;
    public static string swordName, swordInfo, swordSpeed, swordDamage;
    public static string hammerName, hammerInfo, hammerDamage, hammerStunTime;

    public static string arenaName, arenaInfo, ritualTimer;
    public static string pointDropName, pointDropInfo, pointDropBasic, pointDropRare, pointDropLegendary, pointDropMythic, pointDropBasicPercent, pointDropRarityIncrease;
    public static string invincibilityName, invincibilityInfo, invincibilityClicks, invincibilityTimeAdded;
    public static string ritualName, ritualInfo, ritualClicks;
    public static string stopwatchName, stopwatchInfo, stopwatchClicks, stopwatchStopTime;
    public static string diceRollName, diceRollInfo, diceRollClicks;
    public static string skullHarvestName, skullHarvestRarity, skullHarvestInfo;
    #endregion

    #region Text Variables
    public TextMeshProUGUI critChanceText, critIncreaseText, idleCPSText, idlePointText;
    public TextMeshProUGUI buttonHealthText, regenText, bigHeartNameText, bigHeartInfoText, bigHeartClicksNeededText, bigHeartHeal, bigHeartRarityText;
    public TextMeshProUGUI smallShieldHPText, smallShieldRechargeTimeText, smallShieldNameText, smallShieldRarityText, smallShieldInfoText;
    public TextMeshProUGUI shieldBounceNameText, shieldBounceRarityText, shieldBounceInfoText, shieldBounceHPText, shieldBounceRechargeText;

    public TextMeshProUGUI brokenUziNameText, brokenUziUncommonRarityText, brokenUziInfoText, brokenUziSpeedText, brokenUziDamageText;
    public TextMeshProUGUI pistolNameText, pistolUncommonRarityText, pistolInfoText, pistolSpeedText, pistolDamageText;
    public TextMeshProUGUI shotgunNameText, shotgunRareRarityText, shotgunInfoText, shotgunShotsText, shotgunSpeedText, shotgunDamageText;
    public TextMeshProUGUI awpNameText, awpRareRarityText, awpInfoText, awpSpeedText, awpDamageText;
    public TextMeshProUGUI crossbowNameText, crossbowRareRarityText, crossbowInfoText, crossbowSpeedText, crossbowDamageText;
    public TextMeshProUGUI deagleNameText, deagleRareRarityText, deagleInfoText, deagleSpeedText, deagleDamageText;
    public TextMeshProUGUI mp4NameText, mp4LegendaryRarityText, mp4InfoText, mp4SpeedText, mp4DamageText;
    public TextMeshProUGUI cannonNameText, cannonLegendaryRarityText, cannonInfoText, cannonSpeedText, cannonDamageText;

    public TextMeshProUGUI chargedBulletNameText, chargedBulletRaritText, chargedBulletInfoText, chargedBulletCountText, chargedBulletDamageText, chargedBulletChargeTimeText;
    public TextMeshProUGUI arrowNameText, arrowRarityText, arrowInfoText, arrowCountText, arrowDamageText;

    public TextMeshProUGUI arenaNameText, arenaRarityText, arenaInfoText;

    public TextMeshProUGUI boxingGloveNameText, boxingGloveRarityText, boxingGloveInfoText, boxingGloveForceText, boxingGloveUselessText;
    public TextMeshProUGUI stabbySpikeNameText, stabbySpikeRarityText, stabbySpikeInfoText, stabbySpikesDamageText;
    public TextMeshProUGUI smallSpikeNameText, smallSpikeRarityText, smallSpikeInfoText, smallSpikeDamageText;
    public TextMeshProUGUI knifeNameText, knifeRarityText, knifeInfoText, knifeCountText, knifeDamageText;
    public TextMeshProUGUI sawBladeNameText, sawBladeRarityText, sawBladeInfoText, sawBladeSpeedText, sawBladeDamageText;
    public TextMeshProUGUI swordNameText, swordRarityText, swordInfoText, swordSpeedText, swordDamageText;
    public TextMeshProUGUI hammerNameText, hammerRarityText, hammerInfoText, hammerDamageText, hammerStunTimeText;

    public TextMeshProUGUI ritualNameText, ritualRarityText, ritualInfoText, ritualClicksText, ritualTimerText, ritualCommonTimerText;
    public TextMeshProUGUI invinClicksText, invinTimeAddedText, invinNameText, invinRarityText, invinInfoText;
    public TextMeshProUGUI stopWatchNameText, stopWatchRarityText, stopWatchInfoText, stopWatchClicksText, stopWatchTimeText;
    public TextMeshProUGUI skullHarvestNameText, skullHarvestRarityText, skullHarvestInfoText;

    public TextMeshProUGUI diceRollNameRareText, diceRollRarityRareText, diceRollInfoRareText, diceRollClicksRareText;
    public TextMeshProUGUI diceRollNameLegendaryText, diceRollRarityLegendaryText, diceRollInfoLegendaryText, diceRollClicksLegendaryText;
    public TextMeshProUGUI pointDropNameText, pointDropRarityText, pointDropInfoText, pointDropBasicText, pointDropRareText, pointDropLegendaryText, pointDropMythicText, pointDropPointTierIncrease, pointDropEachTierInfo, pointdropBasicPointIncrease, pointDropDropChances;

    public TextMeshProUGUI uziCommonSpeedText, uziCommonDamageText, pistolCommonSpeedText, pistolCommonDamageText, shotgunCommonSpeedText, shotgunCommonDamageText, shotgunCommonShotsText, awpCommonSpeedText, awpCommonDamageText, crossbowCommonSpeedText, crossbowCommonDamageText, deagleCommonSpeedText, deagleCommonDamageText, cannonComonSpeedText, cannonCommonDamageText, mp4CommonSpeedText, mp4CommonDamageText;

    public TextMeshProUGUI swordCommonnSpeedText, swordCommonDamageText, boxingGloveCommonForceText, spikeStabCommonDamageText, hammerCommonDamageText, hammerCommonStunTimeText, arrowCountCommonText, arrowDamageCommonText, smallSpikesCommonDamageText, sawBladeCommonSpeedText, sawBladeCommonDamageText, shieldBounceCommonHP, shieldBounceCommonRechargeTimeText, ritualCommonClicksText, smallShieldCommonHPText, smallShieldCommonRechargeText, pointDropCommonBasicChanceText, pointDropCommonRareChanceText, pointDropCommonLegendaryChanceText, pointDropCommonMythicChanceText, bigHeartHealCommonText, knifeCommonKnifesText, knifeCommonDamageText, chargedBulletCommonDamageText, chargedBulletCommonChargeTimeText, invincibilityCommonSecondsAddedText, stopWatchCommonTimeText, stopWatchCommonClicksText, pointDropBasicCommon, pointDropRarityCommon, invinCommonClicks;

    public TextMeshProUGUI addsStabbySpikeText, addsSmallShieldText, addsSawBladeText, addsSwordText;
    public TextMeshProUGUI skullHarvestBuffsShownText;

    public TextMeshProUGUI diceRollRareDoubleChance, diceRollLegendaryRerollChance;
    public string diceRollDoubleChance;


    #endregion

    public GameObject arenaIcon, arenaLargerIcon;
    void Start()
    {
        SetText();
    }

    public void SetText()
    {
        englishLanguage = true;
        AbilityRarityText();
        AllAbilityToolTipString();
        AllACHToolTipStrings();
        AllSkinsTooltips();
        SettingsText();
        AllOtherRangedAbilitites();
        DefenseAbilityTexts();
        First3AbilityTexts();
        GunsAbilityTexts();
        AllMeleeAbilityTexts();
        MovementText();
        OtherAbilitesText();
    }

    public static string playBossString, playHordeString, playChampionsString, playDangerButtonStrung;
    #region Settings Text
    public void SettingsText()
    {
        if(englishLanguage == true)
        {
            playBossString = "Play Ending #1\n Boss?";
            playHordeString = "Play Ending #2\n Horde?";
            playChampionsString = "Play Ending #3\n Angry Champions?";
            playDangerButtonStrung = "Play Ending #4\n Danger Button?";
        }
    }
    #endregion

    #region First 3 Abilities
    public void First3AbilityTexts()
    {
        if(englishLanguage == true)
        {
            PointPerClickText();
            CritText();
            IdleText();
        }
    }

    public void PointPerClickText()
    {
        float totalPoints;
        totalPoints = ButtonClick.pointsPerClick + Choises.totalIdlePoints;

        if(englishLanguage == true)
        {
            pointPerClickIncrease = $"Points per Click: <color=green>{totalPoints.ToString("F0")} (+{Choises.currentPointIncrease.ToString("F0")})";
        }
    }

    public void CritText()
    {
        float critIncrease;
        float critIncreasePluss;

        critIncrease = Choises.critClicksBonus * 100;
        critIncreasePluss = Choises.currectClickCritIncrease * 100;

        if (englishLanguage == true)
        {
            if (Choises.choseCritClicks == false)
            {
                critChanceIncrease = $"Crit chance: <color=green>{Choises.critClicksChance.ToString("F1")}%";
                critPointsIncrease = $"Crit points: <color=green>{critIncrease.ToString("F0")}%";
            }
            else
            {
                critChanceIncrease = $"Crit chance: <color=green>{Choises.critClicksChance.ToString("F1")}% (+{Choises.currentClickCritPercentIncrease.ToString("F1")}%)";
                critPointsIncrease = $"Crit points: <color=green>{critIncrease.ToString("F0")}% (+{critIncreasePluss.ToString("F0")}%)";
            }
        }

        critChanceText.text = critChanceIncrease;
        critIncreaseText.text = critPointsIncrease;
    }

    public void IdleText()
    {
        float totalPoints;
        totalPoints = ButtonClick.pointsPerClick + Choises.totalIdlePoints;

        float idleClickIncrease;
        float currentIdleIncrease;
        idleClickIncrease = 1 / (Choises.timeBetweenClicks - Choises.currentIdleClickIncrease);
        currentIdleIncrease = idleClickIncrease - (1 / Choises.timeBetweenClicks);

        //Debug.Log(Choises.timeBetweenClicks);
        //Debug.Log(Choises.currentIdleClickIncrease);

        //Debug.Log(idleClickIncrease);
        //Debug.Log(currentIdleIncrease);

        if (englishLanguage == true)
        {
            if (Choises.choseIdleClicking == false)
            {
                idleClicksIncrease = $"CPS: <color=green>{(1 / Choises.timeBetweenClicks).ToString("F1")}";
            }
            else
            {
                idleClicksIncrease = $"CPS: <color=green>{(1 / Choises.timeBetweenClicks).ToString("F2")} (+{currentIdleIncrease.ToString("F2")})";
            }

            if (Choises.currentIdlePointIncrease < 10)
            {
                idlePointText.text = $"Points per Click: <color=green>{totalPoints.ToString("F0")} (+{Choises.currentIdlePointIncrease.ToString("F1")})";
            }
            if (Choises.currentIdlePointIncrease > 10)
            {
                idlePointText.text = $"Points per Click: <color=green>{totalPoints.ToString("F0")} (+{Choises.currentIdlePointIncrease.ToString("F0")})";
            }
        }


        idleCPSText.text = idleClicksIncrease;
    }
    #endregion

    #region Defense
    public void DefenseAbilityTexts()
    {
        DefenseText();
        BigHeartText();
        SmallShieldsText();
        BouncyShieldText();
    }

    public void DefenseText()
    {
        if (englishLanguage == true)
        {
            healthIncrease = $"Button health: <color=red>{Choises.maxButtonHealth.ToString("F0")} (+{Choises.currentHealthIncrease.ToString("F0")})";
            regenIncrease = $"Health regen: <color=red>{Choises.healthRegenPerSecond.ToString("F1")}/s (+{Choises.currentHealthRegenIncrease.ToString("F1")}s)";

            buttonHealthText.text = healthIncrease;
            regenText.text = regenIncrease;
        }
    }

    public void BigHeartText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseHeartCollect == false)
            {
                bigHeartHealIncrease = $"Heal amount: <color=red>{Choises.bigHeartHPHeal.ToString("F0")}HP";
            }
            else
            {
                bigHeartHealIncrease = $"Heal amount: <color=red>{Choises.bigHeartHPHeal.ToString("F0")}HP (+{Choises.currentBigHeartHealIncrease.ToString("F0")})";
                bigHeartClicksNeededIncrease = $"Button clicks: <color=green>{Choises.bigHeartClicksNeeded} (-{Choises.currentBigHeartClicksIncrease })";
            }

            if (Choises.chooseHeartCollect == false) { bigHeartInfo = $"Every {Choises.bigHeartClicksNeeded} button clicks spawns a heart in a random position. Shoot it or touch it to consume the heart"; }
            if (Choises.chooseHeartCollect == true) { bigHeartInfo = "Improve the big heart."; }

            if (Choises.chooseHeartCollect == false) { bigHeartName = "Big Heart"; }
            if (Choises.chooseHeartCollect == true) { bigHeartName = "Big Heart+"; }

            if (Choises.chooseHeartCollect == false) { bigHeartClicksNeededText.text = ""; }
            if (Choises.chooseHeartCollect == true) { bigHeartClicksNeededText.text = bigHeartClicksNeededIncrease; }

       
            bigHeartNameText.text = bigHeartName;
            bigHeartInfoText.text = bigHeartInfo;

            bigHeartHeal.text = bigHeartHealIncrease;

            if (Choises.chooseHeartCollect == false) { bigHeartRarityText.text = uncommonAbility; }
            if (Choises.chooseHeartCollect == true) { bigHeartRarityText.text = uncommonAbilityUpgrade; }

            bigHeartHealCommonText.text = $"Heal amount: <color=red>{Choises.bigHeartHPHeal.ToString("F0")}HP (+{Choises.bigHeartCommonHealIncrease.ToString("F0")})"; ;
        }
    }

    public void SmallShieldsText()
    {
        if (englishLanguage == true)
        {
            if (Choises.choseSmallShields == false) { smallShieldName = "Small Shields"; }
            if (Choises.choseSmallShields == true) { smallShieldName = "Small Shields+"; }

            if (Choises.choseSmallShields == false) { smallShieldInfo = "2 small shields will rotate around the button, blocking enemy bullets."; }
            if (Choises.choseSmallShields == true) { smallShieldInfo = "Improve the small shields."; }

            if (Choises.choseSmallShields == false)
            {
                smallShieldHP = $"Shield HP: <color=red>{Choises.smallShieldHP.ToString("F0")}";
                smallShieldRechargeTime = $"Recharge time: <color=green>{Choises.smallShieldRechargeTimer.ToString("F1")}";
                addsSmallShieldText.text = "";
            }
            else
            {
                smallShieldHP = $"Shield HP: <color=red>{Choises.smallShieldHP.ToString("F0")} (+{Choises.smallShieldHPIncrease.ToString("F0")})";
                smallShieldRechargeTime = $"Recharge time: <color=green>{Choises.smallShieldRechargeTimer.ToString("F1")} (-{Choises.smallShiledRechargeDecrease.ToString("F1")})";
                if (Choises.smallShieldUpgradeCount < 7) { addsSmallShieldText.text = "Adds another shield!"; }
                if (Choises.smallShieldUpgradeCount > 6) { addsSmallShieldText.text = ""; }
            }

            smallShieldHPText.text = smallShieldHP;
            smallShieldRechargeTimeText.text = smallShieldRechargeTime;
            smallShieldNameText.text = smallShieldName;
            if (Choises.choseSmallShields == false) { smallShieldRarityText.text = uncommonAbility; }
            if (Choises.choseSmallShields == true) { smallShieldRarityText.text = uncommonAbilityUpgrade; }
            smallShieldInfoText.text = smallShieldInfo;

            smallShieldCommonHPText.text = $"Shield HP: <color=red>{Choises.smallShieldHP.ToString("F0")} (+{Choises.smallShieldCommonHPIncrease.ToString("F0")})";
            smallShieldCommonRechargeText.text = $"Recharge Time: <color=green>{Choises.smallShieldRechargeTimer.ToString("F1")} (-{Choises.smallShiledCommonRechargeDecrease.ToString("F1")})";
        }
    }

    public void BouncyShieldText()
    {
        if (englishLanguage == true)
        {
            if (Choises.choseShield_BounceOff == false) { shieldBounceName = "Bouncy Shield"; }
            if (Choises.choseShield_BounceOff == true) { shieldBounceName = "Bouncy Shield+"; }

            if (Choises.choseShield_BounceOff == false) { shieldBounceInfo = "Button gets 1/4 of the shield. Enemy bullets will bounce back at the enemies if the shield is hit."; }
            if (Choises.choseShield_BounceOff == true)
            {
                if (Choises.bouncyShieldUpgradeCount == 1) { shieldBounceInfo = "Improve the bouncy shield. Button gets 2/4 of the shield"; }
                if (Choises.bouncyShieldUpgradeCount == 2) { shieldBounceInfo = "Improve the bouncy shield. Button gets 3/4 of the shield"; }
                if (Choises.bouncyShieldUpgradeCount == 3) { shieldBounceInfo = "Improve the bouncy shield. Button gets 4/4 of the shield"; }
                if (Choises.bouncyShieldUpgradeCount > 3) { shieldBounceInfo = "Improve the bouncy shield."; }
            }

            if (Choises.choseShield_BounceOff == false)
            {
                shieldBounceHP = $"Shield HP: <color=red>{Choises.shieldBounce_health.ToString("F0")}";
                shieldBounceRechargeTime = $"Recharge time: <color=green>{Choises.reChargeTimer.ToString("F1")}";
            }
            else
            {
                shieldBounceHP = $"Shield HP: <color=red>{Choises.shieldBounce_health.ToString("F0")} (+{Choises.shieldBounceHPIncrease.ToString("F0")})";
                shieldBounceRechargeTime = $"Recharge time: <color=green>{Choises.reChargeTimer.ToString("F1")} (-{Choises.shieldBounceRechargeDecrease.ToString("F1")})";
            }

            shieldBounceNameText.text = shieldBounceName;
            if (Choises.choseShield_BounceOff == false) { shieldBounceRarityText.text = rareAbility; }
            if (Choises.choseShield_BounceOff == true) { shieldBounceRarityText.text = rareAbilityUpgrade; }
            shieldBounceInfoText.text = shieldBounceInfo;
            shieldBounceHPText.text = shieldBounceHP;
            shieldBounceRechargeText.text = shieldBounceRechargeTime;

            shieldBounceCommonHP.text = $"Shield HP: <color=red>{Choises.shieldBounce_health.ToString("F0")} (+{Choises.shieldBounceCommonHPIncrease.ToString("F0")})";
            shieldBounceCommonRechargeTimeText.text = $"Recharge time: <color=green>{Choises.reChargeTimer.ToString("F1")} (-{Choises.shieldBounceCommonRechargeDecrease.ToString("F1")})";
        }
    }

    #endregion

    #region Ability Rarity
    public void AbilityRarityText()
    {
        if (englishLanguage == true)
        {
            commonAbility = "Common Ability";
            commonAbilityUpgrade = "Common Ability Upgrade";
            uncommonAbility = "Uncommon Ability";
            uncommonAbilityUpgrade = "Uncommon Ability Upgrade";
            rareAbility = "Rare Ability";
            rareAbilityUpgrade = "Rare Ability Upgrade";
            legendaryAbility = "Legendary Ability";
            legendaryAbilityUpgrade = "Legendary Ability Upgrade";
            mythicAbility = "Mythic Ability";
            mythicAbilityUpgrade = "Mythic Ability Upgrade";
        }
    }
    #endregion

    #region Guns
    public void GunsAbilityTexts()
    {
        if (englishLanguage == true)
        {
            UziText();
            PistolText();
            ShotgunText();
            AwpText();
            CrossbowText();
            DeagleText();
            CannonText();
            Mp4Text();
        }
    }

    public void UziText()
    {
        if(englishLanguage == true)
        {
            if (Choises.choseShootSmallBullets == false) { brokenUziName = "Broken Uzi"; }
            if (Choises.choseShootSmallBullets == true) { brokenUziName = "Broken Uzi+"; }
            if (Choises.choseShootSmallBullets == false) { brokenUziInfo = $"The uzi shoots a bullet in a random direction every {Choises.clickPerSmallBullet} button clicks."; }
            if (Choises.choseShootSmallBullets == true) { brokenUziInfo = "Improve the broken uzi."; }

            if (Choises.choseShootSmallBullets == false)
            {
                brokenUziDamage = $"Bullet damage: <color=green>{Choises.smallBulletDamage.ToString("F0")}";
                brokenUziSpeed = $"Bullet speed: <color=green>{Choises.smallBulletSpeed.ToString("F0")}";
            }
            if (Choises.choseShootSmallBullets == true)
            {
                brokenUziDamage = $"Bullet damage: <color=green>{Choises.smallBulletDamage.ToString("F0")} (+{Choises.uziDamageIncrease.ToString("F0")})";
                brokenUziSpeed = $"Bullet speed: <color=green>{Choises.smallBulletSpeed.ToString("F0")} (+{Choises.uziSpeedIncrease.ToString("F0")})";
            }

            brokenUziNameText.text = brokenUziName;
            if (Choises.choseShootSmallBullets == false) { brokenUziUncommonRarityText.text = uncommonAbility; }
            if (Choises.choseShootSmallBullets == true) { brokenUziUncommonRarityText.text = uncommonAbilityUpgrade; }
            brokenUziInfoText.text = brokenUziInfo;
            brokenUziSpeedText.text = brokenUziSpeed;
            brokenUziDamageText.text = brokenUziDamage;

            uziCommonSpeedText.text = $"Bullet speed: <color=green>{Choises.smallBulletSpeed.ToString("F0")} (+{Choises.uziCommonSpeedIncrease.ToString("F0")})";
            uziCommonDamageText.text = $"Bullet damage: <color=green>{Choises.smallBulletDamage.ToString("F0")} (+{Choises.uziCommonDamageIncrease.ToString("F0")})";
        }
       
    }

    public void PistolText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chose_Gun1 == false) { pistolName = "Pistol"; }
            if (Choises.chose_Gun1 == true) { pistolName = "Pistol+"; }

            if(MobileScript.isMobile == false)
            {
                if (Choises.chose_Gun1 == false) { pistolInfo = $"The pistol shoots a bullet every {Choises.pistolClicksNeeded} button clicks in the aimed direction."; }
            }
            else
            {
                if (Choises.chose_Gun1 == false) { pistolInfo = $"The pistol shoots a bullet every {Choises.pistolClicksNeeded} button clicks. The pistol targets a random enemy."; }
            }
         
            if (Choises.chose_Gun1 == true) { pistolInfo = "Improve the pistol."; }

            if (Choises.chose_Gun1 == false)
            {
                pistolSpeed = $"Bullet speed: <color=green>{Choises.bulletGun1_Speed.ToString("F0")}";
                pistolDamage = $"Bullet damage: <color=green>{Choises.bulletGun1_Damage.ToString("F0")}";
            }
            if (Choises.chose_Gun1 == true)
            {
                pistolSpeed = $"Bullet speed: <color=green>{Choises.bulletGun1_Speed.ToString("F0")} (+{Choises.pistolSpeedIncrease.ToString("F0")})";
                pistolDamage = $"Bullet damage: <color=green>{Choises.bulletGun1_Damage.ToString("F0")} (+{Choises.pistolDamageIncrease.ToString("F0")})";
            }

            pistolNameText.text = pistolName;
            if (Choises.chose_Gun1 == false) { pistolUncommonRarityText.text = uncommonAbility; }
            if (Choises.chose_Gun1 == true) { pistolUncommonRarityText.text = uncommonAbilityUpgrade; }
            pistolInfoText.text = pistolInfo;
            pistolSpeedText.text = pistolSpeed;
            pistolDamageText.text = pistolDamage;

            pistolCommonSpeedText.text = $"Bullet speed: <color=green>{Choises.bulletGun1_Speed.ToString("F0")} (+{Choises.pistolCommonSpeedIncrease.ToString("F0")})";
            pistolCommonDamageText.text = $"Bullet damage: <color=green>{Choises.bulletGun1_Damage.ToString("F0")} (+{Choises.pistolCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void ShotgunText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chose_gun2 == false) { shotgunName = "Shotgun"; }
            if (Choises.chose_gun2 == true) { shotgunName = "Shotgun+"; }

            if (MobileScript.isMobile == false)
            {
                if (Choises.chose_gun2 == false) { shotgunInfo = $"Every {Choises.shotGunClicksNeeded} button clicks shoots a shotgun blast in the aimed direction."; }
            }
            else
            {
                if (Choises.chose_gun2 == false) { shotgunInfo = $"Every {Choises.shotGunClicksNeeded} button clicks shoots a shotgun blast. The shotgun targets the closest enemy."; }
            }
           
            if (Choises.chose_gun2 == true) { shotgunInfo = "Improve the shotgun."; }

            if (Choises.chose_gun2 == false)
            {
                shotgunSpeed = $"Bullet speed: <color=green>{Choises.shotGunBulletSpeed1.ToString("F0")}-{Choises.shotGunBulletSpeed2.ToString("F0")}";
                shotgunDamage = $"Bullet damage: <color=green>{Choises.shotGunBulletDamage.ToString("F0")}-{Choises.shotGunBulletDamage2.ToString("F0")}";
                shotgunShots = $"Bullets shot: <color=green>{Choises.shotGunBullets}";
            }
            if (Choises.chose_gun2 == true)
            {
                shotgunSpeed = $"Bullet speed: <color=green>{Choises.shotGunBulletSpeed1.ToString("F0")}-{Choises.shotGunBulletSpeed2.ToString("F0")} (+{Choises.shotgunSpeedIncrease.ToString("F0")})";
                shotgunDamage = $"Bullet damage: <color=green>{Choises.shotGunBulletDamage.ToString("F0")}-{Choises.shotGunBulletDamage2.ToString("F0")} (+{Choises.shotgunDamageIncrease.ToString("F0")})";
                shotgunShots = $"Bullets shot: <color=green>{Choises.shotGunBullets} (+{Choises.shotgunShotsIncrease})";
            }

            shotgunNameText.text = shotgunName;
            if (Choises.chose_gun2 == false) { shotgunRareRarityText.text = rareAbility; }
            if (Choises.chose_gun2 == true) { shotgunRareRarityText.text = rareAbilityUpgrade; }
            shotgunInfoText.text = shotgunInfo;
            shotgunShotsText.text = shotgunShots;
            shotgunSpeedText.text = shotgunSpeed;
            shotgunDamageText.text = shotgunDamage;

            shotgunCommonSpeedText.text = $"Bullet speed: <color=green>{Choises.shotGunBulletSpeed1.ToString("F0")}-{Choises.shotGunBulletSpeed2.ToString("F0")} (+{Choises.shotgunCommonSpeedIncrease.ToString("F0")})";
            shotgunCommonDamageText.text = $"Bullet damage: <color=green>{Choises.shotGunBulletDamage.ToString("F0")}-{Choises.shotGunBulletDamage2.ToString("F0")} (+{Choises.shotgunCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void AwpText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseHomingBullets == false) { awpName = "A.W.P"; }
            if (Choises.chooseHomingBullets == true) { awpName = "A.W.P+"; }
            if (Choises.chooseHomingBullets == false) { awpInfo = $"Every {Choises.clicksPerHomingBullet} button clicks shoots a fast bullet that targets a random enemy."; }
            if (Choises.chooseHomingBullets == true) { awpInfo = "Improve the A.W.P"; }

            if (Choises.chooseHomingBullets == false)
            {
                awpSpeed = $"Bullet speed: <color=green>{Choises.homignBulletSpeed.ToString("F0")}";
                awpDamage = $"Bullet damage: <color=green>{Choises.homingBulletDamage.ToString("F0")}";
            }
            if (Choises.chooseHomingBullets == true)
            {
                awpSpeed = $"Bullet speed: <color=green>{Choises.homignBulletSpeed.ToString("F0")} (+{Choises.awpSpeedIncrease.ToString("F0")})";
                awpDamage = $"Bullet damage: <color=green>{Choises.homingBulletDamage.ToString("F0")} (+{Choises.awpDamageIncrease.ToString("F0")})";
            }

            awpNameText.text = awpName;
            if (Choises.chooseHomingBullets == false) { awpRareRarityText.text = rareAbility; }
            if (Choises.chooseHomingBullets == true) { awpRareRarityText.text = rareAbilityUpgrade; }
            awpInfoText.text = awpInfo;
            awpSpeedText.text = awpSpeed;
            awpDamageText.text = awpDamage;

            awpCommonSpeedText.text = $"Bullet speed: <color=green>{Choises.homignBulletSpeed.ToString("F0")} (+{Choises.awpCommonSpeedIncrease.ToString("F0")})";
            awpCommonDamageText.text = $"Bullet damage: <color=green>{Choises.homingBulletDamage.ToString("F0")} (+{Choises.awpCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void DeagleText()
    {
        if (englishLanguage == true)
        {
            //Trippleshot
            if (Choises.choseTrippleShot == false) { deagleName = "Triple Deagle"; }
            if (Choises.choseTrippleShot == true) { deagleName = "Triple Deagle+"; }
            if (Choises.choseTrippleShot == false) { deagleInfo = $"The deagle shoots 3 bullets every {Choises.trippleShotNeeded} button clicks. The deagle targets the closest enemy."; }
            if (Choises.choseTrippleShot == true) { deagleInfo = "Improve the deagle."; }

            if (Choises.choseTrippleShot == false)
            {
                deagleSpeed = $"Bullet speed: <color=green>{Choises.trippleShotSpeed.ToString("F0")}";
                deagleDamage = $"Bullet damage: <color=green>{Choises.trippleShotDamage.ToString("F0")}";
            }
            if (Choises.choseTrippleShot == true)
            {
                deagleSpeed = $"Bullet speed: <color=green>{Choises.trippleShotSpeed.ToString("F0")} (+{Choises.deagleSpeedIncrease.ToString("F0")})";
                deagleDamage = $"Bullet damage: <color=green>{Choises.trippleShotDamage.ToString("F0")} (+{Choises.deagleDamageIncrease.ToString("F0")})";
            }

            deagleNameText.text = deagleName;
            if (Choises.choseTrippleShot == false) { deagleRareRarityText.text = rareAbility; }
            if (Choises.choseTrippleShot == true) { deagleRareRarityText.text = rareAbilityUpgrade; }
            deagleInfoText.text = deagleInfo;
            deagleSpeedText.text = deagleSpeed;
            deagleDamageText.text = deagleDamage;

            deagleCommonSpeedText.text = $"Bullet speed: <color=green>{Choises.trippleShotSpeed.ToString("F0")} (+{Choises.deagleCommonSpeedIncrease.ToString("F0")})";
            deagleCommonDamageText.text = $"Bullet damage: <color=green>{Choises.trippleShotDamage.ToString("F0")} (+{Choises.deagleCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void CrossbowText()
    {
        if (englishLanguage == true)
        {
            if (Choises.choseCrossBow == false) { crossbowName = "Crossbow"; }
            if (Choises.choseCrossBow == true) { crossbowName = "Crossbow+"; }

            if (MobileScript.isMobile == false)
            {
                if (Choises.choseCrossBow == false) { crossbowInfo = $"Every {Choises.crossbowClicksNeeded} button clicks shoots a bolt in the aimed direction."; }
            }
            else
            {
                if (Choises.choseCrossBow == false) { crossbowInfo = $"Every {Choises.crossbowClicksNeeded} button clicks shoots a bolt. The crossbow targets a random enemy."; }
            }

            if (Choises.choseCrossBow == true) { crossbowInfo = "Improve the crossbow."; }

            if (Choises.choseCrossBow == false)
            {
                crossbowSpeed = $"Bolt speed: <color=green>{Choises.crossbowSpeed.ToString("F0")}";
                crossbowDamage = $"Bolt damage: <color=green>{Choises.crossbowDamage.ToString("F0")}";
            }
            if (Choises.choseCrossBow == true)
            {
                crossbowSpeed = $"Bolt speed: <color=green>{Choises.crossbowSpeed.ToString("F0")} (+{Choises.crossbowSpeedIncrease.ToString("F0")})";
                crossbowDamage = $"Bolt damage: <color=green>{Choises.crossbowDamage.ToString("F0")} (+{Choises.crossbowDamageIncrease.ToString("F0")})";
            }

            crossbowNameText.text = crossbowName;
            if (Choises.choseCrossBow == false) { crossbowRareRarityText.text = rareAbility; }
            if (Choises.choseCrossBow == true) { crossbowRareRarityText.text = rareAbilityUpgrade; }
            crossbowInfoText.text = crossbowInfo;
            crossbowSpeedText.text = crossbowSpeed;
            crossbowDamageText.text = crossbowDamage;

            crossbowCommonSpeedText.text = $"Bolt speed: <color=green>{Choises.crossbowSpeed.ToString("F0")} (+{Choises.crossbowCommonSpeedIncrease.ToString("F0")})";
            crossbowCommonDamageText.text = $"Bolt damage: <color=green>{Choises.crossbowDamage.ToString("F0")} (+{Choises.crossbowCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void CannonText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseBigPiercingBulletGun == false) { cannonName = "CANNON"; }
            if (Choises.chooseBigPiercingBulletGun == true) { cannonName = "CANNON+"; }
            if (Choises.chooseBigPiercingBulletGun == false) { cannonInfo = $"The cannon shoots a big bullet every {Choises.clicksPerBigBullet} button clicks that pierces through every enemy"; }
            if (Choises.chooseBigPiercingBulletGun == true) { cannonInfo = "Improve the cannon."; }

            if (Choises.chooseBigPiercingBulletGun == false)
            {
                cannonSpeed = $"Bullet speed: <color=green>{Choises.bigBulletSpeed.ToString("F0")}";
                cannonDamage = $"Bullet damage: <color=green>{Choises.bigBulletDamage.ToString("F0")}";
            }
            if (Choises.chooseBigPiercingBulletGun == true)
            {
                cannonSpeed = $"Bullet speed: <color=green>{Choises.bigBulletSpeed.ToString("F0")} (+{Choises.cannonSpeedIncrease.ToString("F0")})";
                cannonDamage = $"Bullet damage: <color=green>{Choises.bigBulletDamage.ToString("F0")} (+{Choises.cannonDamageIncrease.ToString("F0")})";
            }

            cannonNameText.text = cannonName;
            if (Choises.chooseBigPiercingBulletGun == false) { cannonLegendaryRarityText.text = legendaryAbility; }
            if (Choises.chooseBigPiercingBulletGun == true) { cannonLegendaryRarityText.text = legendaryAbilityUpgrade; }
            cannonInfoText.text = cannonInfo;
            cannonSpeedText.text = cannonSpeed;
            cannonDamageText.text = cannonDamage;

            cannonComonSpeedText.text = $"Bullet speed: <color=green>{Choises.bigBulletSpeed.ToString("F0")} (+{Choises.cannonCommonSpeedIncrease.ToString("F0")})";
            cannonCommonDamageText.text = $"Bullet damage: <color=green>{Choises.bigBulletDamage.ToString("F0")} (+{Choises.cannonCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void Mp4Text()
    {
        if (englishLanguage == true)
        {
            //mp4
            if (Choises.choseGunMp4 == false) { mp4Name = "MP4"; }
            if (Choises.choseGunMp4 == true) { mp4Name = "MP4+"; }

            if (MobileScript.isMobile == false)
            {
                if (Choises.choseGunMp4 == false) { mp4Info = $"The MP4 shoots a bullet every {Choises.mp4ClicksNeeded} button clicks in the aimed direction."; }
            }
            else
            {
                if (Choises.choseGunMp4 == false) { mp4Info = $"The MP4 shoots a bullet every {Choises.mp4ClicksNeeded} button clicks. The MP4 targets a random enemy."; }
            }
           
            if (Choises.choseGunMp4 == true) { mp4Info = "Improve the MP4."; }

            if (Choises.choseGunMp4 == false)
            {
                mp4Speed = $"Bullet speed: <color=green>{Choises.mp4Speed.ToString("F0")}";
                mp4Damage = $"Bullet damage: <color=green>{Choises.mp4Damage.ToString("F0")}";
            }
            if (Choises.choseGunMp4 == true)
            {
                mp4Speed = $"Bullet speed: <color=green>{Choises.mp4Speed.ToString("F0")} (+{Choises.mp4SpeedIncrease.ToString("F0")})";
                mp4Damage = $"Bullet damage: <color=green>{Choises.mp4Damage.ToString("F0")} (+{Choises.mp4DamageIncrease.ToString("F0")})";
            }

            mp4NameText.text = mp4Name;
            if (Choises.choseGunMp4 == false) { mp4LegendaryRarityText.text = legendaryAbility; }
            if (Choises.choseGunMp4 == true) { mp4LegendaryRarityText.text = legendaryAbilityUpgrade; }
            mp4InfoText.text = mp4Info;
            mp4SpeedText.text = mp4Speed;
            mp4DamageText.text = mp4Damage;

            mp4CommonSpeedText.text = $"Bullet speed: <color=green>{Choises.mp4Speed.ToString("F0")} (+{Choises.mp4CommonSpeedIncrease.ToString("F0")})";
            mp4CommonDamageText.text = $"Bullet damage: <color=green>{Choises.mp4Damage.ToString("F0")} (+{Choises.mp4CommonDamageIncrease.ToString("F0")})";
        }
    }
    #endregion

    #region Other Ranged Abilitites
    public void AllOtherRangedAbilitites()
    {
        if (englishLanguage == true)
        {
            ArrowText();
            ChargedBulletsText();
        }
    }

    public void ArrowText()
    {
        if(englishLanguage == true)
        {
            //Arrow
            if (Choises.choseArrows == false) { arrowName = "ARROW STORM"; }
            if (Choises.choseArrows == true) { arrowName = "ARROW STORM+"; }

            if (Choises.choseArrows == false) { arrowInfo = $"Every {Choises.arrowClicksNeeded} button clicks will shoot a huge quantity of arrows around the button."; }
            if (Choises.choseArrows == true) { arrowInfo = "Improve the arrow storm."; }

            if (Choises.choseArrows == false)
            {
                arrowCount = $"Arrow count: <color=green>{Choises.arrowCountShot}";
                arrowDamage = $"Arrow damage: <color=green>{Choises.arrowDamage.ToString("F0")}";
            }
            if (Choises.choseArrows == true)
            {
                arrowCount = $"Arrow count: <color=green>{Choises.arrowCountShot} (+{Choises.arrowCountIncrease})";
                arrowDamage = $"Arrow damage: <color=green>{Choises.arrowDamage.ToString("F0")} (+{Choises.arrowDamageIncrease.ToString("F0")})";
            }

            arrowNameText.text = arrowName;
            if (Choises.choseArrows == false) { arrowRarityText.text = legendaryAbility; }
            if (Choises.choseArrows == true) { arrowRarityText.text = legendaryAbilityUpgrade; }
            arrowInfoText.text = arrowInfo;
            arrowCountText.text = arrowCount;
            arrowDamageText.text = arrowDamage;

          

            arrowCountCommonText.text = $"Arrow count: <color=green>{Choises.arrowCountShot} (+{Choises.arrowCommonCountIncrease})";
            arrowDamageCommonText.text = $"Arrow damage: <color=green>{Choises.arrowDamage.ToString("F0")} (+{Choises.arrowCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void ChargedBulletsText()
    {
        if (englishLanguage == true)
        {
            //Charged bullet
            if (Choises.choseButtonCharge == false) { chargedBulletName = "Charged Bullets"; }
            if (Choises.choseButtonCharge == true) { chargedBulletName = "Charged Bullets+"; }

            if (Choises.choseButtonCharge == false) { chargedBulletInfo = $"Hold down the button to charge it, release to shoot {Choises.chargedBulletsCount} charged bullets around the button."; }
            if (Choises.choseButtonCharge == true) { chargedBulletInfo = "Improve the charged bullets."; }

            if (Choises.choseButtonCharge == false)
            {
                chargedBulletCount = $"";
                chargedBulletDamage = $"Max damage: <color=green>{Choises.chargedBulletMaxDamage.ToString("F0")}";
                chargedBulletTime = $"Charge time: <color=green>{Choises.chargedBulletChargeTime.ToString("F1")}";
            }
            if (Choises.choseButtonCharge == true)
            {
                chargedBulletCount = $"";
                chargedBulletDamage = $"Max damage: <color=green>{Choises.chargedBulletMaxDamage.ToString("F0")} (+{Choises.chargedBulletMaxDamageIncrease.ToString("F0")})";
                chargedBulletTime = $"Charge time: <color=green>{Choises.chargedBulletChargeTime.ToString("F1")} (-{Choises.chargedBulletChargeTimeIncrease.ToString("F1")})";
            }

            chargedBulletNameText.text = chargedBulletName;
            if (Choises.choseButtonCharge == false) { chargedBulletRaritText.text = rareAbility; }
            if (Choises.choseButtonCharge == true) { chargedBulletRaritText.text = rareAbilityUpgrade; }
            chargedBulletCountText.text = chargedBulletCount;
            chargedBulletDamageText.text = chargedBulletDamage;
            chargedBulletChargeTimeText.text = chargedBulletTime;

            chargedBulletCommonDamageText.text = $"Max damage: <color=green>{Choises.chargedBulletMaxDamage.ToString("F0")} (+{Choises.chargedBulletcommonMaxDamageIncrease.ToString("F0")})";
            chargedBulletCommonChargeTimeText.text = $"Charge time: <color=green>{Choises.chargedBulletChargeTime.ToString("F1")} (-{Choises.chargedBulletcommonChargeTimeIncrease.ToString("F1")})";
        }
    }

    #endregion

    #region Melee Weapons
    public void AllMeleeAbilityTexts()
    {
        if (englishLanguage == true)
        {
            TinySpikesText();
            StabbySpikesText();
            BoxingGloveText();
            SawBladeText();
            HammerText();
            SwordText();
        }
    }

    public void TinySpikesText()
    {
        if (englishLanguage == true)
        {
            //Small spikes
            if (Choises.chooseSpikes == false) { smallSpikeName = "Tiny Spikes"; }
            if (Choises.chooseSpikes == true) { smallSpikeName = "Tiny Spikes+"; }

            if (Choises.chooseSpikes == false) { smallSpikeInfo = "A bunch of small spikes will surround the button, dealing damage to enemies that come in contact with the button."; }
            if (Choises.chooseSpikes == true) { smallSpikeInfo = "Improve the tiny spikes."; }

            if (Choises.chooseSpikes == false) { smallSpikeRarityText.text = uncommonAbility; }
            if (Choises.chooseSpikes == true) { smallSpikeRarityText.text = uncommonAbilityUpgrade; }

            if (Choises.chooseSpikes == false) { smallSPikedDamage = $"Spike Damage: <color=green>{Choises.spikeDamagePerSecond.ToString("F1")}"; }
            if (Choises.chooseSpikes == true) { smallSPikedDamage = $"Spike Damage: <color=green>{Choises.spikeDamagePerSecond.ToString("F1")} (+{Choises.smallSpikedDamageIncrease.ToString("F1")})"; }

            smallSpikeNameText.text = smallSpikeName;
            smallSpikeInfoText.text = smallSpikeInfo;
            smallSpikeDamageText.text = smallSPikedDamage;

            smallSpikesCommonDamageText.text = $"Spike Damage: <color=green>{Choises.spikeDamagePerSecond.ToString("F1")} (+{Choises.smallSpikesCommonDamageIncrease.ToString("F1")})";
        }
    }

    public void StabbySpikesText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseStabbingSpikes == false) { stabbySpikeName = "Stabby Spikes"; }
            if (Choises.chooseStabbingSpikes == true) { stabbySpikeName = "Stabby Spikes+"; }

            if (Choises.chooseStabbingSpikes == false)
            {
                stabbySpikeInfo = $"4 Spikes will slowly rotate inside the button and stab enemies every {Choises.stabbingSpikesClicksNeeded} button clicks."; addsStabbySpikeText.text = "";
            }
            if (Choises.chooseStabbingSpikes == true)
            {
                stabbySpikeInfo = "Improve the stabby spikes.";
                if (Choises.stabbySpikeUpgradeCount < 5) { addsStabbySpikeText.text = "Adds another spike!"; }
                if (Choises.stabbySpikeUpgradeCount > 4) { addsStabbySpikeText.text = ""; }
            }

            if (Choises.chooseStabbingSpikes == false) { stabbySpikeRarityText.text = uncommonAbility; }
            if (Choises.chooseStabbingSpikes == true) { stabbySpikeRarityText.text = uncommonAbilityUpgrade; }

            if (Choises.chooseStabbingSpikes == false) { stabbySpikedDamage = $"Spike Damage: <color=green>{Choises.stabbingSpikeDamage.ToString("F0")}"; }
            if (Choises.chooseStabbingSpikes == true) { stabbySpikedDamage = $"Spike Damage: <color=green>{Choises.stabbingSpikeDamage.ToString("F0")} (+{Choises.stabbySpikeDamageIncrease.ToString("F0")})"; }

            stabbySpikeNameText.text = stabbySpikeName;
            stabbySpikeInfoText.text = stabbySpikeInfo;

            stabbySpikesDamageText.text = stabbySpikedDamage;

            spikeStabCommonDamageText.text = $"Spike Damage: <color=green>{Choises.stabbingSpikeDamage.ToString("F0")} (+{Choises.stabbySpikeCommonDamageIncrease.ToString("F0")})";
        }
    }

    public void KnifeText()
    {
        if (englishLanguage == true)
        {
            if (Choises.choseSpinningKnifes == false) { knifeName = "Spinning Knifes"; }
            if (Choises.choseSpinningKnifes == true) { knifeName = "Spinning Knifes+"; }

            if (Choises.choseSpinningKnifes == false) { knifeInfo = $"Every {Choises.knifeClicksNeeded} button clicks will spawn a knife that rotates around the button. The knife will be removed once it hits an enemy."; }
            if (Choises.choseSpinningKnifes == true) { knifeInfo = "Improve the spinning knifes."; }

            if (Choises.choseSpinningKnifes == false) { knifeRarityText.text = uncommonAbility; }
            if (Choises.choseSpinningKnifes == true) { knifeRarityText.text = uncommonAbilityUpgrade; }

            if (Choises.choseSpinningKnifes == false)
            {
                knifeDamage = $"Knife damage: <color=green>{Choises.knifeDamage.ToString("F0")}";
                knifeCount = $"Max knifes: <color=green>{Choises.knifeTotalCount}";
            }
            if (Choises.choseSpinningKnifes == true)
            {
                knifeDamage = $"Knife damage: <color=green>{Choises.knifeDamage.ToString("F0")} (+{Choises.knifeDamageIncrease.ToString("F0")})";
                knifeCount = $"Max knifes: <color=green>{Choises.knifeTotalCount} (+{Choises.knifeCountIncrease})";
            }

            knifeNameText.text = knifeName;
            knifeInfoText.text = knifeInfo;
            knifeDamageText.text = knifeDamage;
            knifeCountText.text = knifeCount;

            knifeCommonDamageText.text = $"Knife damage: <color=green>{Choises.knifeDamage.ToString("F0")} (+{Choises.knifeCommonDamageIncrease.ToString("F0")})";
            knifeCommonKnifesText.text = $"Max knifes: <color=green>{Choises.knifeTotalCount} (+{Choises.knifeCommonCountIncrease})";
        }
    }

    public void SawBladeText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseSawBlade == false) { sawBladeName = "Saw Blade"; }
            if (Choises.chooseSawBlade == true) { sawBladeName = "Saw Blade+"; }

            if (Choises.chooseSawBlade == false) { sawBladeInfo = "A small saw blade will rotate around the button at a fast pace, dealing damage to close enemies"; }
            if (Choises.chooseSawBlade == true) { sawBladeInfo = "Improve the saw blade."; }

            if (Choises.chooseSawBlade == false) { sawBladeRarityText.text = rareAbility; }
            if (Choises.chooseSawBlade == true) { sawBladeRarityText.text = rareAbilityUpgrade; }

            if (Choises.chooseSawBlade == false)
            {
                sawBladeSpeed = $"Saw blade speed: <color=green>{Choises.sawBladeSpeed.ToString("F0")}";
                sawBladeDamage = $"Saw blade damage: <color=green>{Choises.sawBladeDamage.ToString("F0")}";
                addsSawBladeText.text = "";
            }
            if (Choises.chooseSawBlade == true)
            {
                sawBladeSpeed = $"Saw blade speed: <color=green>{Choises.sawBladeSpeed.ToString("F0")} (+{Choises.sawBladeSpeedIncrease.ToString("F0")})";
                sawBladeDamage = $"Saw blade damage: <color=green>{Choises.sawBladeDamage.ToString("F0")} (+{Choises.sawBladeDamageIncrease.ToString("F0")})";
                if (Choises.sawBladeUpgradeCount < 8) { addsSawBladeText.text = "Adds another saw blade!"; }
                if (Choises.sawBladeUpgradeCount > 7) { addsSawBladeText.text = ""; }
            }

            sawBladeNameText.text = sawBladeName;
            sawBladeInfoText.text = sawBladeInfo;
            sawBladeDamageText.text = sawBladeDamage;
            sawBladeSpeedText.text = sawBladeSpeed;

            sawBladeCommonDamageText.text = $"Saw blade damage: <color=green>{Choises.sawBladeDamage.ToString("F0")} (+{Choises.sawBladeCommonDamageIncrease.ToString("F0")})";
            sawBladeCommonSpeedText.text = $"Saw blade speed: <color=green>{Choises.sawBladeSpeed.ToString("F0")} (+{Choises.sawBladeCommonSpeedIncrease.ToString("F0")})";

        }
    }

    public void BoxingGloveText()
    {
        if (englishLanguage == true)
        {
            if (Choises.choseBoxingGlove == false) { boxingGloveName = "Boxing Glove"; }
            if (Choises.choseBoxingGlove == true) { boxingGloveName = "Boxing Glove+"; }

            if (Choises.choseBoxingGlove == false) { boxingGloveInfo = $"Every {Choises.boxingGloveClicksNeeded} button clicks will puch a close enemy with a boxing glove, knocking them away from the button. "; }
            if (Choises.choseBoxingGlove == true) { boxingGloveInfo = "Improve the boxing glove."; }

            if (Choises.choseBoxingGlove == false) { boxingGloveForce = $"Knockback force: <color=green>{Choises.boxingGloveKnockbackAmount.ToString("F1")}"; }
            if (Choises.choseBoxingGlove == true) { boxingGloveForce = $"Knockback force: <color=green>{Choises.boxingGloveKnockbackAmount.ToString("F1")} (+{Choises.boxingGloveForceIncrease.ToString("F1")})"; }

            boxingGloveNameText.text = boxingGloveName;
            boxingGloveInfoText.text = boxingGloveInfo;
            if (Choises.choseBoxingGlove == false) { boxingGloveRarityText.text = uncommonAbility; }
            if (Choises.choseBoxingGlove == true) { boxingGloveRarityText.text = uncommonAbilityUpgrade; }
            if (Choises.choseBoxingGlove == false) { boxingGloveUselessText.text = "Boxing glove can only hit Assasins and Speedsters!"; }
            if (Choises.choseBoxingGlove == true) { boxingGloveUselessText.text = ""; }
            boxingGloveForceText.text = boxingGloveForce;

            boxingGloveCommonForceText.text = $"Knockback force: <color=green>{Choises.boxingGloveKnockbackAmount.ToString("F1")} (+{Choises.boxingGloveCommonForceIncrease.ToString("F1")})";
        }
    }

    public void SwordText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseBigSpike == false) { swordName = "BIG SWORD"; }
            if (Choises.chooseBigSpike == true) { swordName = "BIG SWORD+"; }

            if (Choises.chooseBigSpike == false) { swordInfo = "A big sword will spin around the button, dealing damage to close enemies."; }
            if (Choises.chooseBigSpike == true) { swordInfo = "Improve the big sword."; }

            if (Choises.chooseBigSpike == false) { swordRarityText.text = legendaryAbility; }
            if (Choises.chooseBigSpike == true) { swordRarityText.text = legendaryAbilityUpgrade; }

            if (Choises.chooseBigSpike == false)
            {
                swordSpeed = $"Sword speed: <color=green>{Choises.swordSpeed.ToString("F0")}";
                swordDamage = $"Sword damage: <color=green>{Choises.bigSpikeDamage.ToString("F0")}";
                addsSwordText.text = "";
            }
            if (Choises.chooseBigSpike == true)
            {
                swordSpeed = $"Sword speed: <color=green>{Choises.swordSpeed.ToString("F0")} (+{Choises.swordSpeedIncrease.ToString("F0")})";
                swordDamage = $"Sword damage: <color=green>{Choises.bigSpikeDamage.ToString("F0")} (+{Choises.swordDamageIcrease.ToString("F0")})";
                if (Choises.swordUpgradeCount < 4) { addsSwordText.text = "Adds another sword!"; }
                if (Choises.swordUpgradeCount > 3) { addsSwordText.text = ""; }
            }

            swordNameText.text = swordName;
            swordInfoText.text = swordInfo;
            swordDamageText.text = swordDamage;
            swordSpeedText.text = swordSpeed;


            swordCommonDamageText.text = $"Sword damage: <color=green>{Choises.bigSpikeDamage.ToString("F0")} (+{Choises.swordCommonDamageIcrease.ToString("F0")})";
            swordCommonnSpeedText.text = $"Sword speed: <color=green>{Choises.swordSpeed.ToString("F0")} (+{Choises.swordCommonSpeedIncrease.ToString("F0")})";
        }
    }

    public void HammerText()
    {
        if (englishLanguage == true)
        {
            if (Choises.chooseHammer == false) { hammerName = "HAMMER"; }
            if (Choises.chooseHammer == true) { hammerName = "HAMMER+"; }

            if (Choises.chooseHammer == false) { hammerInfo = $"Every {Choises.hammerClicksNeeded} button clicks spawns a hammer that damages and stuns enemies."; }
            if (Choises.chooseHammer == true) { hammerInfo = "Improve the hammer."; }

            if (Choises.chooseHammer == false) { hammerRarityText.text = legendaryAbility; }
            if (Choises.chooseHammer == true) { hammerRarityText.text = legendaryAbilityUpgrade; }

            if (Choises.chooseHammer == false)
            {
                hammerDamage = $"Hammer damage: <color=green>{Choises.hammerDamage.ToString("F0")}";
                hammerStunTime = $"Hammer stun time: <color=green>{Choises.hammerStunTime.ToString("F1")}s";
            }
            if (Choises.chooseHammer == true)
            {
                hammerDamage = $"Hammer damage: <color=green>{Choises.hammerDamage.ToString("F0")} (+{Choises.hammerDamageIncrease.ToString("F0")})";
                hammerStunTime = $"Hammer stun time: <color=green>{Choises.hammerStunTime.ToString("F1")}s (+{Choises.hammerStunTimeIncrease.ToString("F1")}s)";
            }

            hammerNameText.text = hammerName;
            hammerInfoText.text = hammerInfo;
            hammerDamageText.text = hammerDamage;
            hammerStunTimeText.text = hammerStunTime;

            hammerCommonDamageText.text = $"Hammer damage: <color=green>{Choises.hammerDamage.ToString("F0")} (+{Choises.hammerCommonDamageIncrease.ToString("F0")})";
            hammerCommonStunTimeText.text = $"Hammer stun time: <color=green>{Choises.hammerStunTime.ToString("F1")} (+{Choises.hammerCommonStunTimeIncrease.ToString("F1")})";
        }
    }
    #endregion

    #region Movement abilites
    public TextMeshProUGUI boosterRemoveText, rocketRemoveText, talariaRemoveText;
    public void MovementText()
    {
        if (englishLanguage == true)
        {
            if(Choises.choseButtonBounceCharge == false && Choises.chooseRocket == false && Choises.chooseControllableButton == false) 
            {
                boosterRemoveText.text = ""; rocketRemoveText.text = ""; talariaRemoveText.text = "";
            }

            if(Choises.choseButtonBounceCharge == true) { rocketRemoveText.text = "Choosing this ability will remove your \"Booster\" movement ability."; }
            if (Choises.choseButtonBounceCharge == true) { talariaRemoveText.text = "Choosing this ability will remove your \"Booster\" movement ability."; }

            if (Choises.chooseRocket == true) { boosterRemoveText.text = "Choosing this ability will remove your \"Rocket\" movement ability."; }
            if (Choises.chooseRocket == true) { talariaRemoveText.text = "Choosing this ability will remove your \"Rocket\" movement ability."; }

            if (Choises.chooseControllableButton == true) { boosterRemoveText.text = "Choosing this ability will remove your \"Talaria\" movement ability."; }
            if (Choises.chooseControllableButton == true) { rocketRemoveText.text = "Choosing this ability will remove your \"Talaria\" movement ability."; }
        }
    }
    #endregion

    #region Other Abilitites
    public void OtherAbilitesText()
    {
        if (englishLanguage == true)
        {
            ArenaText();
            PointDropText();
            SkullHarvestText();
            InvincibilityText();
            StopwatchText();
            RitualText();
            DiceText();
        }
    }

    public void SkullHarvestText()
    {
        if (englishLanguage == true)
        {
            //Skull Harvest
            if (Choises.choseSkullHarvest == false) { skullHarvestName = "SKULL HARVEST"; }
            if (Choises.choseSkullHarvest == true) { skullHarvestName = "SKULL HARVEST+"; }

            if (Choises.choseSkullHarvest == false) { skullHarvestInfo = "The button will consume the skull of every enemy defeated. Each skull consumed gives a really small upgrade to a random ability."; }
            if (Choises.choseSkullHarvest == true) { skullHarvestInfo = "Skulls consumed gives slightly better upgades."; }

            if (Choises.choseSkullHarvest == false)
            {
                skullHarvestBuffsShownText.text = "All skull harvest upgrades will be shown inside the STATS tab! Skull harvest stats are not permanent.";
                skullHarvestRarityText.text = mythicAbility;
            }
            if (Choises.choseSkullHarvest == true)
            {
                skullHarvestBuffsShownText.text = "";
                skullHarvestRarityText.text = mythicAbilityUpgrade;
            }

            skullHarvestNameText.text = skullHarvestName;
            skullHarvestInfoText.text = skullHarvestInfo;
        }
    }

    public void ArenaText()
    {
        if (englishLanguage == true)
        {
            //Arena and bouncing bullets
            if (Choises.choseBouncingBullets == false) { arenaName = "Arena + Bullet Bounce"; }
            if (Choises.choseBouncingBullets == true) { arenaName = "Larger Arena"; }

            if(MobileScript.isMobile == false)
            {
                if (Choises.choseBouncingBullets == false) { arenaInfo = "Creates an arena. All round bullets now bounce. Zoom in and out using the scrollwheel."; }
            }
            else
            {
                if (Choises.choseBouncingBullets == false) { arenaInfo = "Creates an arena. All round bullets now bounce. You can  now zoom the game in and out."; }
            }

            if (Choises.choseBouncingBullets == true) { arenaInfo = "Larger arena, enemies spawn further away."; }

            arenaNameText.text = arenaName;
            arenaInfoText.text = arenaInfo;
        }

        if (Choises.choseBouncingBullets == false) { arenaIcon.SetActive(true); arenaLargerIcon.SetActive(false); }
        if (Choises.choseBouncingBullets == true) { arenaIcon.SetActive(false); arenaLargerIcon.SetActive(true); }
    }

    public void DiceText()
    {
        if (englishLanguage == true)
        {
            //Dice Roll
            if (Choises.choseReroll == false) { diceRollName = "Dice Roll"; }
            if (Choises.choseReroll == true) { diceRollName = "Dice Roll+"; }

            if (Choises.choseReroll == false) { diceRollInfo = $"You now get +1 reroll every {Choises.rerollClicksNeeded} button clicks. Rerolling will give you a set of new abilities to choose from. You also have a {Choises.rerollDoubleChance}% chance to get +2 rerolls."; }
            if (Choises.choseReroll == true) { diceRollInfo = "Improve the dice roll."; }

            if (Choises.choseReroll == false) { diceRollClicks = ""; diceRollDoubleChance = ""; }
            if (Choises.choseReroll == true)
            {
                diceRollClicks = $"Button clicks: <color=green>{Choises.rerollClicksNeeded} (-{Choises.rerollClicksDeacreseRare})";
                diceRollDoubleChance = $"+2 Reroll Chance: <color=green>{Choises.rerollDoubleChance}% (+{Choises.rerollDoubleChanceIncrease}%)";
            }

            diceRollRareDoubleChance.text = diceRollDoubleChance;
            diceRollLegendaryRerollChance.text = diceRollDoubleChance;

            diceRollNameRareText.text = diceRollName;
            diceRollNameLegendaryText.text = diceRollName;

            diceRollInfoRareText.text = diceRollInfo;
            diceRollInfoLegendaryText.text = diceRollInfo;
            if (Choises.choseReroll == false) { diceRollRarityRareText.text = rareAbility; diceRollRarityLegendaryText.text = legendaryAbility; }
            if (Choises.choseReroll == true) { diceRollRarityRareText.text = rareAbilityUpgrade; diceRollRarityLegendaryText.text = legendaryAbilityUpgrade; }

            diceRollClicksRareText.text = diceRollClicks;
            diceRollClicksLegendaryText.text = diceRollClicks;
        }
    }

    public void InvincibilityText()
    {
        if (englishLanguage == true)
        {
            //Invincibility
            if (Choises.choseInvincibility == false) { invincibilityName = "INVINCIBILITY"; }
            if (Choises.choseInvincibility == true) { invincibilityName = "INVINCIBILITY+"; }

            if(MobileScript.isMobile == false)
            {
                if (Choises.choseInvincibility == false) { invincibilityInfo = $"You can now turn invincible. Every {Choises.invincibilityClickPer1Second} button clicks adds 1 second to your invincibility.\n\nPress \"Q\" To turn your invincibility ON and OFF. You cannot take damage while invincible."; }
            }
            else
            {
                if (Choises.choseInvincibility == false) { invincibilityInfo = $"You can now turn invincible. Every {Choises.invincibilityClickPer1Second} button clicks adds 1 second to your invincibility.\n\nPress the small button that appears to turn your invincibility ON and OFF. You cannot take damage while invincible."; }
            }
            
            if (Choises.choseInvincibility == true) { invincibilityInfo = "Improve the invincibility."; }

            if (Choises.choseInvincibility == false)
            {
                invincibilityClicks = "";
                invincibilityTimeAdded = "";
            }
            if (Choises.choseInvincibility == true)
            {
                invincibilityClicks = $"Button clicks: <color=green>{Choises.invincibilityClickPer1Second} (-{Choises.invincibilityClicksDecrease})";
                invincibilityTimeAdded = $"Time added: <color=green>{Choises.invincibilityTimeAdded.ToString("F1")}s (+{Choises.invincibilityTimeAddedIncrease.ToString("F1")}s)";
            }


            invinNameText.text = invincibilityName;
            invinInfoText.text = invincibilityInfo;
            if (Choises.choseInvincibility == false) { invinRarityText.text = legendaryAbility; }
            if (Choises.choseInvincibility == true) { invinRarityText.text = legendaryAbilityUpgrade; }

            invinClicksText.text = invincibilityClicks;
            invinTimeAddedText.text = invincibilityTimeAdded;

            invincibilityCommonSecondsAddedText.text = $"Time added: <color=green>{Choises.invincibilityTimeAdded.ToString("F1")}s (+{Choises.invincibilityCommonTimeAddedIncrease.ToString("F1")}s)";
            invinCommonClicks.text = $"Button clicks: <color=green>{Choises.invincibilityClickPer1Second} (-{Choises.invincibilityCommonClicksDecrease})";
        }
    }

    public void StopwatchText()
    {
        if (englishLanguage == true)
        {
            //Stopwatch
            if (Choises.choseStopTime == false) { stopwatchName = "STOPWATCH"; }
            if (Choises.choseStopTime == true) { stopwatchName = "STOPWATCH+"; }

            if (Choises.choseStopTime == false) { stopwatchInfo = $"Time will stop every {Choises.stopTimeClickTotal} button clicks for {Choises.stopTimeTimer} seconds. When time is stopped, you can still fire your guns and regen HP."; }
            if (Choises.choseStopTime == true) { stopwatchInfo = "Improve the stopwatch."; }

            if (Choises.choseStopTime == false)
            {
                stopwatchClicks = "";
                stopwatchStopTime = "";
            }
            if (Choises.choseStopTime == true)
            {
                stopwatchClicks = $"Button clicks: <color=green>{Choises.stopTimeClickTotal} (-{Choises.stopTimeClicksDecrease})";
                stopwatchStopTime = $"Time stopped: <color=green>{Choises.stopTimeTimer.ToString("F1")} (+{Choises.stopTimeTimeIncrease.ToString("F1")})";
            }


            stopWatchNameText.text = stopwatchName;
            stopWatchInfoText.text = stopwatchInfo;
            if (Choises.choseStopTime == false) { stopWatchRarityText.text = mythicAbility; }
            if (Choises.choseStopTime == true) { stopWatchRarityText.text = mythicAbilityUpgrade; }

            stopWatchClicksText.text = stopwatchClicks;
            stopWatchTimeText.text = stopwatchStopTime;

            stopWatchCommonClicksText.text = $"Button clicks: <color=green>{Choises.stopTimeClickTotal} (-{Choises.stopTimeCommonClicksDecrease})";
            stopWatchCommonTimeText.text = $"Time stopped: <color=green>{Choises.stopTimeTimer.ToString("F1")} (+{Choises.stopTimeCommonTimeIncrease.ToString("F1")})";
        }
    }

    public void RitualText()
    {
        if (englishLanguage == true)
        {

            //Ritual
            if (Choises.choseRitual == false) { ritualName = "Button Ritual"; }
            if (Choises.choseRitual == true) { ritualName = "Button Ritual+"; }

            if (Choises.choseRitual == false) { ritualInfo = $"Every {Choises.ritualClicksNeeded} button clicks will spawn a ritual in a random position. Walk over the ritual before it de-spawns to level up a random ability."; }
            if (Choises.choseRitual == true) { ritualInfo = "Improve the button ritual."; }

            if (Choises.choseRitual == false) { ritualClicks = ""; ritualTimer = ""; }
            if (Choises.choseRitual == true)
            {
                ritualClicks = $"Button clicks: <color=green>{Choises.ritualClicksNeeded} (-{Choises.ritualClicksIncrease})";
                ritualTimer = $"Ritual Timer: <color=green>{Choises.ritualTimer.ToString("F1")}s (+{Choises.ritualTimerIncrease.ToString("F2")}s)";
            }

            ritualNameText.text = ritualName;
            ritualInfoText.text = ritualInfo;
            if (Choises.choseRitual == false) { ritualRarityText.text = legendaryAbility; }
            if (Choises.choseRitual == true) { ritualRarityText.text = legendaryAbilityUpgrade; }

            ritualClicksText.text = ritualClicks;
            ritualTimerText.text = ritualTimer;

            ritualCommonTimerText.text = ritualTimer;
            ritualCommonClicksText.text = $"Button clicks: <color=green>{Choises.ritualClicksNeeded} (-{Choises.ritualCommonClicksIncrease})";
        }
    }

    public void PointDropText()
    {
        if (englishLanguage == true)
        {
            //Point Drop
            if (Choises.chosePointsDrop == false) { pointDropName = "Point Drop"; }
            if (Choises.chosePointsDrop == true) { pointDropName = "Point Drop+"; }

            if (Choises.chosePointsDrop == false) { pointDropInfo = $"Enemies will now drop points when defeated. Points are worth {(Choises.pointDropBasicPoints * 100).ToString("F0")}% of a button click."; }
            if (Choises.chosePointsDrop == true) { pointDropInfo = "Improve the point drop."; }

            if (Choises.chosePointsDrop == false)
            {
                pointDropDropChances.text = "Drop Chances";
                pointDropBasicPercent = "";
                pointDropRarityIncrease = "";

                pointDropEachTierInfo.text = $"Each tier of rarity gives +{(Choises.pointDropRarityIncreasePoints * 100).ToString("F0")}% button click points!";

                pointDropBasic = $"Basic point drop chance: <color=green>{Choises.randomUncommonPointsDrop.ToString("F0")}%";
                pointDropRare = $"Rare chance: <color=green>{Choises.randomRarePointDrop.ToString("F0")}%";
                pointDropLegendary = $"Legendary chance: <color=green>{Choises.randomLegendaryPointDrop.ToString("F0")}%";
                pointDropMythic = $"Mythic chance: <color=green>{Choises.randomMythicPointDrop.ToString("F0")}%";
            }
            if (Choises.chosePointsDrop == true)
            {
                pointDropDropChances.text = "";

                pointDropBasicPercent = $"Basic points: <color=green>{(Choises.pointDropBasicPoints * 100).ToString("F0")}% (+{(Choises.uncommonBasicPointIncrease * 100).ToString("F0")}%)";

                pointDropRarityIncrease = $"Rarity increase: <color=green>{(Choises.pointDropRarityIncreasePoints * 100).ToString("F0")}% (+{(Choises.uncommonPointRarityIncrease * 100).ToString("F0")}%)";

                pointDropEachTierInfo.text = "";
                pointDropPointTierIncrease.text = "";
                pointDropBasic = "";
                pointDropRare = "";
                pointDropLegendary = "";
                pointDropMythic = "";
            }

            //Uncommon
            pointdropBasicPointIncrease.text = pointDropBasicPercent;
            pointDropPointTierIncrease.text = pointDropRarityIncrease;

            //Common
            pointDropBasicCommon.text = $"Basic points: <color=green>{(Choises.pointDropBasicPoints * 100).ToString("F0")}% (+{(Choises.commonBasicPointIncrease * 100).ToString("F0")}%)";

            pointDropRarityCommon.text = $"Rarity increase: <color=green>{(Choises.pointDropRarityIncreasePoints * 100).ToString("F0")}% (+{(Choises.commonPointRarityIncrease * 100).ToString("F0")}%)";

            pointDropNameText.text = pointDropName;
            pointDropInfoText.text = pointDropInfo;
            if (Choises.chosePointsDrop == false) { pointDropRarityText.text = uncommonAbility; }
            if (Choises.chosePointsDrop == true) { pointDropRarityText.text = uncommonAbilityUpgrade; }

            pointDropBasicText.text = pointDropBasic;
            pointDropRareText.text = pointDropRare;
            pointDropLegendaryText.text = pointDropLegendary;
            pointDropMythicText.text = pointDropMythic;
        }
    }
    #endregion

    #region Enemy Stats Text
    public TextMeshProUGUI smallEnemyHP, smallEnemyDamage, smallEnemyPoints;
    public TextMeshProUGUI speedsterHP, speedsterDamage, speedsterPoints;
    public TextMeshProUGUI sharpshooterHP, sharpshooterDamage, sharpshooterPoints;
    public TextMeshProUGUI sniperHP, sniperDamage, sniperPoints;
    public TextMeshProUGUI heavyshotHP, heavyshotDamage, heavyshotPoints;
    public TextMeshProUGUI ragingGunnerHP, ragingGunnereMeleeDamage, ragingGunnerRangedDamage, ragingGunnerPoints;
    public TextMeshProUGUI bruteHP, bruteDamage, brutePoints;
    public TextMeshProUGUI titanEnemyHP, titanDamage, titanPoints;

    public void EnemyText()
    {
        if(englishLanguage == true)
        {
            smallEnemyHP.text = $"Assasin HP:<color=red> {Choises.smallEnemyHP.ToString("F0")}";
            smallEnemyDamage.text = $"Assasin damage:<color=red> {Choises.smallEnemyDamage.ToString("F0")}";
            smallEnemyPoints.text = $"Points per Assasin kill:<color=green> {Choises.smallEnemyPoints.ToString("F0")}";

            speedsterHP.text = $"Speedster HP<color=red>: {Choises.speedsterHP.ToString("F0")}";
            speedsterDamage.text = $"Speedster damage:<color=red> {Choises.speedsterDamagePerSecond.ToString("F0")}";
            speedsterPoints.text = $"Points per speedster kill:<color=green> {Choises.speedsterPoints.ToString("F0")}";

            sharpshooterHP.text = $"Sharpshooter HP:<color=red> {Choises.sharpshooterHP.ToString("F0")}";
            sharpshooterDamage.text = $"Sharpshooter damage:<color=red> {Choises.smallEnemyBulletDamage.ToString("F0")}";
            sharpshooterPoints.text = $"Points per sharpshooter kill:<color=green> {Choises.shootingEnemyPoints.ToString("F0")}";

            sniperHP.text = $"Sniper HP:<color=red> {Choises.sniperHP.ToString("F0")}";
            sniperDamage.text = $"Sniper damage:<color=red> {Choises.sniperEnemyBulletDamage.ToString("F0")}";
            sniperPoints.text = $"Points per sniper kill:<color=green> {Choises.sniperPoints.ToString("F0")}";

            heavyshotHP.text = $"Heavyshot HP:<color=red> {Choises.heavyshotHP.ToString("F0")}";
            heavyshotDamage.text = $"Heavyshot damage:<color=red> {Choises.heavyShotDamage.ToString("F0")}";
            heavyshotPoints.text = $"Points per heavyshot kill:<color=green> {Choises.heavyShotPoints.ToString("F0")}";

            ragingGunnerHP.text = $"Gunner HP:<color=red> {Choises.ragingGunnerHP.ToString("F0")}";
            ragingGunnereMeleeDamage.text = $"Gunner melee damage:<color=red> {Choises.raginGunnerMeleeDamage.ToString("F0")}";
            ragingGunnerRangedDamage.text = $"Gunner ranged damage:<color=red> {Choises.raginGunnerBulletDamage.ToString("F0")}";
            ragingGunnerPoints.text = $"Points per gunner kill:<color=green> {Choises.raginGunnerPoints.ToString("F0")}";

            bruteHP.text = $"Brute HP:<color=red> {Choises.bruteHP.ToString("F0")}";
            bruteDamage.text = $"Brute damage:<color=red> {Choises.bruteDamage.ToString("F0")}";
            brutePoints.text = $"Points per brute kill:<color=green> {Choises.bigEnemyPoint.ToString("F0")}";

            titanEnemyHP.text = $"Titan HP:<color=red> {Choises.titanHP.ToString("F0")}";
            titanDamage.text = $"Titan damage:<color=red> {Choises.titanDamage.ToString("F0")}";
            titanPoints.text = $"Points per titan kill:<color=green> {Choises.titanPoints.ToString("F0")}";
        }
        
    }
    #endregion

    #region All stats
    //Skull harvest
    public TextMeshProUGUI SHpointPerClickText, SHcritChanceText, SHcritIncreaseText, SHidleClicksText;
    public TextMeshProUGUI SHuziSpeedText, SHuziDamageText, SHpistolSpeedText, SHPistolDamageText, SHshotgunSpeedText, SHshotgunDamageText, SHawpSpeedText, SHawpDamageText, SHcrossbowSpeedText, SHcrossbowDamageText, SHdeagleSpeedText, SHdeagleDamageText, SHcannonSpeedText, SHcannonDamageText, SHmp4SpeedText, SHmp4DamageText, SHchargeBulletDamageText, SHchargeBulletTimeText, SHarrowDamageText;
    public TextMeshProUGUI SHmaxHealthText, SHregenText, SHbigHEarHPText, SHsmallShieldHPText, SHsmallShieldRechargeText, SHbounceHPText, SHbouncyRechargeText;
    public TextMeshProUGUI SHboxingForceText, SHstabbyDamageText, SHtinySpikeDamageText, SHknifeDamageText, SHsawBladeDamageText, SHsawbladeSpeedText, SHswordSpeedText, SHswordDamageText, SHhammerDamageText, SHhammerStunTimeText;
    public TextMeshProUGUI SHbasicPointChanceText, SHrarePointChanceText, SHlegendaryPointChanceText, SHmythicChanceText, SHinvinTimeText, SHstopwatchTimeText;
    public TextMeshProUGUI skullsConsumedText, SHpointDropPercent, SHpointDropRaritIndrease;

    //All
    public TextMeshProUGUI buttonClicks, critClicks, idleClicks, totalPoints, buttonClickPoints, critClickPoints, enemyPoints, pointDropPoints, enemiesDefeated, assasinsDefeated, speedstersDefeated, sharpshootersDefeated, snipersDefeated, heavyShotDefeated, brutesDefeated, ragingGunnerDefeated, titansDefeated, totalLevels, furthestRunLevel, longestRun, fastestRun, endingsCompleted, runsCompleted, timesDefeatedBoss, timesDefeatedHorde, timesDefeatedChampions, timesDefeatedDangerButton, ritualsEntered, weirdEggUpgrades, abilitiesChosen, commonAbilitites, uncommonAbilitiees, rareAbilities, legendaryAbilitites, mythicAbilities, timesRerolled;

    public TextMeshProUGUI assasinHealthInfo, assasinDamageInfo, assasinPointsInfo, speedsterHealthInfo, speedsterDamageInfo, speedsterPointsInfo, sharpshooterDamageInfo, sharpshooterHealthInfo, sharpshooterPointsInfo, sniperHealthInfo, sniperDamageInfo, sniperPointsInfo, heavyshotDamageInfo, heavyshotHealthInfo, heabyshotPointsInfo, bruteHealthInfo, bruteDamageInfo, brutePointsInfo, gunnerHealthInfo, gunnerMeleeDamgeInfo, gunnerRangedDamgeInfo, gunnerPointsInfo, titanHealthInfo, titanDamageInfo, titanPointsInfo;

    public string longestRunTimer, fastestRunTimer;
    
    void Update()
    {
        if(SettingsOptions.isInStats == true)
        {
            buttonClicks.text = SettingsOptions.totalButtonClicks.ToString("F0");
            critClicks.text = SettingsOptions.totalCritClicks.ToString("F0");
            idleClicks.text = SettingsOptions.totalIdleClicks.ToString("F0");

            totalPoints.text = SettingsOptions.totalPoints.ToString("F0");
            buttonClickPoints.text = SettingsOptions.totalClickPoints.ToString("F0");
            critClickPoints.text = SettingsOptions.totalCritPoints.ToString("F0");
            enemyPoints.text = SettingsOptions.totalEnemyPoints.ToString("F0");
            pointDropPoints.text = SettingsOptions.totalPointDropPoints.ToString("F0");

            enemiesDefeated.text = SettingsOptions.totalEnemiesDefeated.ToString("F0");
            assasinsDefeated.text = SettingsOptions.totalSmallEnemiesDefeated.ToString("F0");
            speedstersDefeated.text = SettingsOptions.totalSpeedstersDefeated.ToString("F0");
            sharpshootersDefeated.text = SettingsOptions.totalSharpshootersDefeated.ToString("F0");
            snipersDefeated.text = SettingsOptions.totalSnipersDefeated.ToString("F0");
            heavyShotDefeated.text = SettingsOptions.totalHeavyshotDefeated.ToString("F0");
            brutesDefeated.text = SettingsOptions.totalBrutedDefeated.ToString("F0");
            ragingGunnerDefeated.text = SettingsOptions.totalRagingGunnerDefeated.ToString("F0");
            titansDefeated.text = SettingsOptions.totalTitansDefeated.ToString("F0");

            totalLevels.text = SettingsOptions.totalLevels.ToString("F0");
            furthestRunLevel.text = SettingsOptions.furthestRunLevel.ToString("F0");

            if (SettingsOptions.longestRunSeconds < 10 && SettingsOptions.longestRunMinutes == 0) { longestRunTimer = $"00:0{SettingsOptions.longestRunSeconds.ToString("F0")}"; }
            if (SettingsOptions.longestRunSeconds > 9 && SettingsOptions.longestRunMinutes == 0) { longestRunTimer = $"00:{SettingsOptions.longestRunSeconds.ToString("F0")}"; }

            if (SettingsOptions.longestRunSeconds < 10 && SettingsOptions.longestRunMinutes > 0 && SettingsOptions.longestRunMinutes < 10) { longestRunTimer = $"0{SettingsOptions.longestRunMinutes.ToString("F0")}:0{SettingsOptions.longestRunSeconds.ToString("F0")}"; }
            if (SettingsOptions.longestRunSeconds > 9 && SettingsOptions.longestRunMinutes > 0 && SettingsOptions.longestRunMinutes < 10) { longestRunTimer = $"0{SettingsOptions.longestRunMinutes.ToString("F0")}:{SettingsOptions.longestRunSeconds.ToString("F0")}"; }

            if (SettingsOptions.longestRunSeconds < 10 && SettingsOptions.longestRunMinutes > 9) { longestRunTimer = $"{SettingsOptions.longestRunMinutes.ToString("F0")}:0{SettingsOptions.longestRunSeconds.ToString("F0")}"; }
            if (SettingsOptions.longestRunSeconds > 9 && SettingsOptions.longestRunMinutes > 9) { longestRunTimer = $"{SettingsOptions.longestRunMinutes.ToString("F0")}:{SettingsOptions.longestRunSeconds.ToString("F0")}"; }

            longestRun.text = longestRunTimer;

            //Fastest Run
            if (SettingsOptions.fastestRunSeconds < 10 && SettingsOptions.fastestRunMinutes == 0) { fastestRunTimer = $"00:0{SettingsOptions.fastestRunSeconds.ToString("F0")}"; }
            if (SettingsOptions.fastestRunSeconds > 9 && SettingsOptions.fastestRunMinutes == 0) { fastestRunTimer = $"00:{SettingsOptions.fastestRunSeconds.ToString("F0")}"; }

            if (SettingsOptions.fastestRunSeconds < 10 && SettingsOptions.fastestRunMinutes > 0 && SettingsOptions.fastestRunMinutes < 10) { fastestRunTimer = $"0{SettingsOptions.fastestRunMinutes.ToString("F0")}:0{SettingsOptions.fastestRunSeconds.ToString("F0")}"; }
            if (SettingsOptions.fastestRunSeconds > 9 && SettingsOptions.fastestRunMinutes > 0 && SettingsOptions.fastestRunMinutes < 10) { fastestRunTimer = $"0{SettingsOptions.fastestRunMinutes.ToString("F0")}:{SettingsOptions.fastestRunSeconds.ToString("F0")}"; }

            if (SettingsOptions.fastestRunSeconds < 10 && SettingsOptions.fastestRunMinutes > 9) { fastestRunTimer = $"{SettingsOptions.fastestRunMinutes.ToString("F0")}:0{SettingsOptions.fastestRunSeconds.ToString("F0")}"; }
            if (SettingsOptions.fastestRunSeconds > 9 && SettingsOptions.fastestRunMinutes > 9) { fastestRunTimer = $"{SettingsOptions.fastestRunMinutes.ToString("F0")}:{SettingsOptions.fastestRunSeconds.ToString("F0")}"; }

            fastestRun.text = fastestRunTimer;

            endingsCompleted.text = SettingsOptions.endingsCompleted.ToString("F0") + "/4";
            runsCompleted.text = SettingsOptions.runsCompleted.ToString("F0");
            timesDefeatedBoss.text = SettingsOptions.timesDefeatedBoss.ToString("F0");
            timesDefeatedHorde.text = SettingsOptions.timesDefeatedHorde.ToString("F0");
            timesDefeatedChampions.text = SettingsOptions.timesDefeatedChampions.ToString("F0");
            timesDefeatedDangerButton.text = SettingsOptions.timesDefeatedDangerButton.ToString("F0");

            ritualsEntered.text = SettingsOptions.ritualsEntered.ToString("F0");
            weirdEggUpgrades.text = SettingsOptions.weirdEggUpgrades.ToString("F0");
            abilitiesChosen.text = SettingsOptions.totalAbilitiesChosen.ToString("F0");
            commonAbilitites.text = SettingsOptions.totalCommonAbilitiesChosen.ToString("F0");
            uncommonAbilitiees.text = SettingsOptions.totalUncommonAbilititesChosen.ToString("F0");
            rareAbilities.text = SettingsOptions.totalRareAbilitiesChose.ToString("F0");
            legendaryAbilitites.text = SettingsOptions.totalLegendaryAbilitiesChosen.ToString("F0");
            mythicAbilities.text = SettingsOptions.totalMythicAbilitiesChosen.ToString("F0");
            timesRerolled.text = SettingsOptions.timesRerolled.ToString("F0");


            skullsConsumedText.text = Choises.skullsConsumedCount.ToString("F0");
            //Debug.Log(Choises.skullsConsumedCount);

            SHpointPerClickText.text = $"+{Choises.SHpointPerClick.ToString("F1")}";
            SHcritChanceText.text = $"+{(Choises.SHcritChance * 100).ToString("F0")}%";
            SHcritIncreaseText.text = $"+{(Choises.SHcritIncrease * 100).ToString("F0")}%";
            SHidleClicksText.text = $"+{Choises.SHidleClicks.ToString("F2")}";
            SHuziSpeedText.text = $"+{Choises.SHuziSpeed.ToString("F1")}";
            SHuziDamageText.text = $"+{Choises.SHuziDamage.ToString("F1")}";
            SHpistolSpeedText.text = $"+{Choises.SHpistolSpeed.ToString("F1")}";
            SHPistolDamageText.text = $"+{Choises.SHPistolDamage.ToString("F1")}";
            SHshotgunSpeedText.text = $"+{Choises.SHshotgunSpeed.ToString("F1")}";
            SHshotgunDamageText.text = $"+{Choises.SHshotgunDamage.ToString("F1")}";
            SHawpSpeedText.text = $"+{Choises.SHawpSpeed.ToString("F1")}";
            SHawpDamageText.text = $"+{Choises.SHawpDamage.ToString("F1")}";
            SHcrossbowSpeedText.text = $"+{Choises.SHcrossbowSpeed.ToString("F1")}";
            SHcrossbowDamageText.text = $"+{Choises.SHcrossbowDamage.ToString("F1")}";
            SHdeagleSpeedText.text = $"+{Choises.SHdeagleSpeed.ToString("F1")}";
            SHdeagleDamageText.text = $"+{Choises.SHdeagleDamage.ToString("F1")}";
            SHcannonSpeedText.text = $"+{Choises.SHcannonSpeed.ToString("F1")}";
            SHcannonDamageText.text = $"+{Choises.SHcannonDamage.ToString("F1")}";
            SHmp4SpeedText.text = $"+{Choises.SHmp4Speed.ToString("F1")}";
            SHmp4DamageText.text = $"+{Choises.SHmp4Damage.ToString("F1")}";
            SHchargeBulletDamageText.text = $"+{Choises.SHchargeBulletDamage.ToString("F1")}";
            SHchargeBulletTimeText.text = $"-{Choises.SHchargeBulletTime.ToString("F1")}s";
            SHarrowDamageText.text = $"+{Choises.SHarrowDamage.ToString("F1")}";
            SHmaxHealthText.text = $"+{Choises.SHmaxHealth.ToString("F1")}";
            SHregenText.text = $"+{Choises.SHregen.ToString("F2")}";
            SHbigHEarHPText.text = $"+{Choises.SHbigHEarHP.ToString("F1")}";
            SHsmallShieldHPText.text = $"+{Choises.SHsmallShieldHP.ToString("F1")}";
            SHsmallShieldRechargeText.text = $"-{Choises.SHsmallShieldRecharge.ToString("F2")}s";
            SHbounceHPText.text = $"+{Choises.SHbounceHP.ToString("F1")}";
            SHbouncyRechargeText.text = $"-{Choises.SHbouncyRecharge.ToString("F2")}s";
            SHboxingForceText.text = $"+{Choises.SHboxingForce.ToString("F1")}";
            SHstabbyDamageText.text = $"+{Choises.SHstabbyDamage.ToString("F1")}";
            SHtinySpikeDamageText.text = $"+{Choises.SHtinySpikeDamage.ToString("F1")}";
            SHknifeDamageText.text = $"+{Choises.SHknifeDamage.ToString("F1")}";
            SHsawBladeDamageText.text = $"+{Choises.SHsawBladeDamage.ToString("F1")}";
            SHsawbladeSpeedText.text = $"+{Choises.SHsawbladeSpeed.ToString("F1")}";
            SHswordSpeedText.text = $"+{Choises.SHswordSpeed.ToString("F1")}";
            SHswordDamageText.text = $"+{Choises.SHswordDamage.ToString("F1")}";
            SHhammerDamageText.text = $"+{Choises.SHhammerDamage.ToString("F1")}";
            SHhammerStunTimeText.text = $"+{Choises.SHhammerStunTime.ToString("F1")}s";
            SHinvinTimeText.text = $"+{Choises.SHinvinTime.ToString("F2")}s";
            SHstopwatchTimeText.text = $"+{Choises.SHstopwatchTime.ToString("F2")}s";

            SHpointDropPercent.text = $"+{(Choises.SHpointDropBasic * 100).ToString("F0")}%";
            SHpointDropRaritIndrease.text = $"+{(Choises.SHpointDropRarity * 100).ToString("F0")}%";

            assasinHealthInfo.text = $"{Choises.smallEnemyHP.ToString("F1")}";
            assasinDamageInfo.text = $"{Choises.smallEnemyDamage.ToString("F1")}";
            assasinPointsInfo.text = $"{Choises.smallEnemyPoints.ToString("F0")}";

            speedsterHealthInfo.text = $"{Choises.speedsterHP.ToString("F1")}";
            speedsterDamageInfo.text = $"{Choises.speedsterDamagePerSecond.ToString("F1")}";
            speedsterPointsInfo.text = $"{Choises.speedsterPoints.ToString("F0")}";

            sharpshooterHealthInfo.text = $"{Choises.sharpshooterHP.ToString("F1")}";
            sharpshooterDamageInfo.text = $"{Choises.smallEnemyBulletDamage.ToString("F1")}";
            sharpshooterPointsInfo.text = $"{Choises.shootingEnemyPoints.ToString("F0")}";

            sniperHealthInfo.text = $"{Choises.sniperHP.ToString("F1")}";
            sniperDamageInfo.text = $"{Choises.sniperEnemyBulletDamage.ToString("F1")}";
            sniperPointsInfo.text = $"{Choises.sniperPoints.ToString("F0")}";

            heavyshotHealthInfo.text = $"{Choises.heavyshotHP.ToString("F1")}";
            heavyshotDamageInfo.text = $"{Choises.heavyShotDamage.ToString("F1")}";
            heabyshotPointsInfo.text = $"{Choises.heavyShotPoints.ToString("F0")}";

            bruteHealthInfo.text = $"{Choises.bruteHP.ToString("F1")}";
            bruteDamageInfo.text = $"{Choises.bruteDamage.ToString("F1")}";
            brutePointsInfo.text = $"{Choises.bigEnemyPoint.ToString("F0")}";

            gunnerHealthInfo.text = $"{Choises.ragingGunnerHP.ToString("F1")}";
            gunnerMeleeDamgeInfo.text = $"{Choises.raginGunnerMeleeDamage.ToString("F1")}";
            gunnerRangedDamgeInfo.text = $"{Choises.raginGunnerBulletDamage.ToString("F1")}";
            gunnerPointsInfo.text = $"{Choises.raginGunnerPoints.ToString("F0")}";

            titanHealthInfo.text = $"{Choises.titanHP.ToString("F1")}";
            titanDamageInfo.text = $"{Choises.titanDamage.ToString("F1")}";
            titanPointsInfo.text = $"{Choises.titanPoints.ToString("F0")}";
        }
     
    }
    #endregion

    #region Tooltip strings
    public static string pointsTT, idleTT, critTT, pointDropTT, doubletapTT, uziTT, pistolTT, shotgunTT, awpTT, crossbowTT, deagleTT, chargedBulletTT, cannonTT, mp4TT, arrosTT, boxinggloveTT, stabbyspikeTT, tinySpikeTT, knifeTT, sawBladeTT, swordTT, hammerTT, defenseTT, heartTT, smallShieldTT, bouncyShieldTT, invinTT, stopwatchTT, boosterTT, rocketTT, talariaTT, random2TT, random3TT, random5TT, ritualTT, eggTT, arenaTT, abiltites4XTT, rerollRareTT, abilities5XTT, rerollLegendaryTT, skullHarvestTT;

    public static string pointsTTN, idleTTN, critTTN, pointDropTTN, doubletapTTN, uziTTN, pistolTTN, shotgunTTN, awpTTN, crossbowTTN, deagleTTN, chargedBulletTTN, cannonTTN, mp4TTN, arrosTTN, boxinggloveTTN, stabbyspikeTTN, tinySpikeTTN, knifeTTN, sawBladeTTN, swordTTN, hammerTTN, defenseTTN, heartTTN, smallShieldTTN, bouncyShieldTTN, invinTTN, stopwatchTTN, boosterTTN, rocketTTN, talariaTTN, random2TTN, random3TTN, random5TTN, ritualTTNN, eggTTN, arenaTTN, abiltites4XTTN, rerollRareTTN, abilities5XTTN, rerollLegendaryTTN, skullHarvestTTN;

    public static string abilityNameNotUnlocked, abilityInfoNotUnlocked;

    public static string damage, speed, level, buttonClicksString, shotgunShotsString, addedTime, stopTime, pointsPerClick, CPS, critChance, critIncrease, pointDropPointsString, pointDropPointIncreaseString, hp, regen, heal, rechargeTime, chargeTime, arrowsCount, knockbackForce, knifesCount, stunTime, despawnTime, dice2XChance;  

    public void AllAbilityToolTipString()
    {
        #region ENGLISH - Ability ToolTip
        if (englishLanguage == true)
        {
            damage = "Damage";
            speed = "Speed";
            level = "Level";
            buttonClicksString = "Button Clicks";
            shotgunShotsString = "Shots";
            addedTime = "Time Added";
            stopTime = "Time Stopped";
            pointsPerClick = "Points Per Click";
            CPS = "Clicks Per Second";
            critChance = "Crit Chance";
            critIncrease = "Crit Increase";
            pointDropPointsString = "Basic Points";
            pointDropPointIncreaseString = "Tier Increase";
            hp = "Health";
            regen = "Regen";
            heal = "Heal Amount";
            rechargeTime = "Recharge Time";
            chargeTime = "Charge Time";
            arrowsCount = "Arrow count";
            knockbackForce = "Knockback Force";
            knifesCount = "Max Knife Count";
            stunTime = "Stun Time";
            despawnTime = "Despawn Time";
            dice2XChance = "2X Reroll Chance";

            abilityNameNotUnlocked = "??????";
            abilityInfoNotUnlocked = "Ability not acquired yet.";

            pointsTTN = "More Points!";
            idleTTN = "Idle Button Clicks";
            critTTN = "Crit Clicks";
            pointDropTTN = "Point Drop";
            doubletapTTN = "Double Tap";
            uziTTN = "Broken Uzi";
            pistolTTN = "Pistol";
            shotgunTTN = "Shotgun";
            awpTTN = "A.W.P";
            crossbowTTN = "Crossbow";
            deagleTTN = "Triple Deagle";
            chargedBulletTTN = "Charged Bullets";
            cannonTTN = "Cannon";
            mp4TTN = "MP4";
            arrosTTN = "Arrow Storm";
            boxinggloveTTN = "Boxing Glove";
            stabbyspikeTTN = "Stabby Spikes";
            tinySpikeTTN = "Tiny Spikes";
            knifeTTN = "Spinning Knifes";
            sawBladeTTN = "Saw Blade";
            swordTTN = "Big Sword";
            hammerTTN = "Hammer";
            defenseTTN = "Defense";
            heartTTN = "Big Heart";
            smallShieldTTN = "Small Shield";
            bouncyShieldTTN = "Bouncy Shield";
            invinTTN = "Invincibility";
            stopwatchTTN = "Stopwatch";
            boosterTTN = "Booster";
            rocketTTN = "Rocket";
            talariaTTN = "Talaria";
            random2TTN = "Student's Magic Book";
            random3TTN = "Teacher's Magic Book";
            random5TTN = "Wizard's Magic Book";
            ritualTTNN = "Button Ritual";
            eggTTN = "Weird Egg";
            arenaTTN = "Arena + Bullet Bounce";
            abiltites4XTTN = "More Choises";
            rerollRareTTN = "Dice Roll";
            abilities5XTTN = "More Choises";
            rerollLegendaryTTN = "Dice Roll";
            skullHarvestTTN = "Skull Harvest";

            //Button click and points
            pointsTT = "Increases points gained per click.";
            idleTT = "Increases idle CPS & increases points per click.";
            critTT = "Increases chances to hit a crit click & points per crit click.";
            pointDropTT = "Points drop from enemies.";
            doubletapTT = "Every single button click acts as 2 clicks. Does not effect idle clicks.";

            //Guns
            uziTT = "Shoots a bullet in a random direction.";
            pistolTT = "Shoots a bullet in the aimed direction.";
            shotgunTT = "Shoots a shotgun blast in the aimed direction.";
            awpTT = "Shoots a homing bullet that targets a random enemy.";
            crossbowTT = "Shoots a bolt in the aimed direction.";
            deagleTT = "Shoots 3 bullets at the closest target.";
            chargedBulletTT = $"Charges the button, and releases {Choises.chargedBulletsCount} charged bullets around the button.";
            cannonTT = "Shoots a big bullet that pierces though all enemies.";
            mp4TT = "Shoots a bullet in the aimed direction.";
            arrosTT = "Shoots a huge quantity of arrows around the button.";

            //Melee
            boxinggloveTT = "Punches the closest Assassin or Speedster and knock them away from the button.";
            stabbyspikeTT = "Stabs close enemies.";
            tinySpikeTT = "Deals damage to enemies that come in contanct with the button.";
            knifeTT = "Spins around the button, dealing damage to close enemies.";
            sawBladeTT = "Spins around the button, dealing damage to close enemies.";
            swordTT = "Spins around the button, dealing damage to close enemies.";
            hammerTT = "Smashes close enemies, dealing damage and stuns enemies.";

            //Defnese
            defenseTT = "Increases button health and regen.";
            heartTT = "Heals the player if the button or a bullet collides with the heart.";
            smallShieldTT = "Rotates around the button, blocking enemy bullets.";
            bouncyShieldTT = "Rotates around the button, blocking enemy bullets. Enemy bullets bounce back.";
            invinTT = "Turn invincible.";
            stopwatchTT = "Stops time. The button can still click, shoot and regen while time is stopped.";

            //Movement
            boosterTT = "Charge the small rotating button, release to boost.";
            rocketTT = "Aim the rocket, and boost in the aimed direction.";
            talariaTT = "Move the button freely around the arena.";

            //Ability upgades
            random2TT = "Upgrades 2 random abilities.";
            random3TT = "Upgrades 3 random abilities.";
            random5TT = "Upgrades 5 random abilities.";
            ritualTT = "Entering the ritual will upgrade a random ability.";
            eggTT = "Choose an ability to upgrade every time you level up.";

            //Other
            arenaTT = "Adds an arena. Round bullets bounce.";
            abiltites4XTT = "Choose from 4 abilities every time you level up.";
            rerollRareTT = "Reroll the abilities. Also has a chance to get +2 rerolls.";
            abilities5XTT = "Choose from 5 abilities every time you level up.";
            rerollLegendaryTT = "Reroll the abilities. Also has a chance to get +2 rerolls.";
            skullHarvestTT = "Consumes the skulls of each enemy defeated, giving a really small buff to a random ability.";
        }
        #endregion
    }

    public static string achUzi, achPistol, achShotgun, achDeagle, achCrossbow, achAwp, achCannon, achMP4, achCrit, achFun, achSkullHarvest, achTalaria, achStopwatch, achEgg, achDoubleTap, achCPS, achBeatBoss, achBeatHorde, achBeatChampions, achBeatDangerButton, achPointBlank, achAllEndings, achSkullHarvestConsume, achReroll, achAbilities, achAllGuns, achLevel30, achLevel60, achLevel90, achLevel120, achDefeatSssassins, achDefeatSpeedsters, achDefeatSharpshooters, achDefeatSnipers, achDefeatHeavyshot, achDefeatGunner, achDefeatBrutes, achDefeatTitans, achClicks1, achClicks2, achClicks3, achBeatRunTimer, achDefeatEnemies, achBeatEndingLevel, achAllUncommon, achAllRare, achAllLegendary, achAllMythic, achAllAbilitites, achAllMelee;


    public void AllACHToolTipStrings()
    {
        #region ENGLISH - ACH ToolTip
        if (englishLanguage == true)
        {
            achUzi = "Acquire the Broken Uzi";
            achPistol = "Acquire the Pistol";
            achShotgun = "Acquire the Shotgun";
            achDeagle = "Acquire the Triple Deagle";
            achCrossbow = "Acquire the Crossbow";
            achAwp = "Acquire the A.W.P";
            achCannon = "Acquire the Cannon";
            achMP4 = "Acquire the MP4";
            achCrit = $"Get {Achievements.totalCritACHAmount} critical clicks!";
            achFun = "Equip the button skin and background that appears in a certain YT video.";
            achSkullHarvest = "Acquire the Skull Harvest";
            achTalaria = "Acquire the Talaria";
            achStopwatch = "Acquire the Stopwatch";
            achEgg = "Acquire the Weird Egg";
            achDoubleTap = "Acquire the Double Tap";
            achCPS = "Get 6 CPS";
            achBeatBoss = "Beat ending #1 - Boss";
            achBeatHorde = "Beat ending #2 - Horde";
            achBeatChampions = "Beat ending #3 - Angry Champions";
            achBeatDangerButton = "Beat ending #4 - Danger Button";
            achPointBlank = "Hit an enemy with an arrow or bolt 1000 times";
            achAllEndings = "Beat all endings!";
            achSkullHarvestConsume = $"Consume {Achievements.skullsComsumedAmountACH} skulls!";
            achReroll = $"Reroll {Achievements.rerrollAchAmount} times";
            achAbilities = $"Choose an ability {Achievements.chooseAbilityAchAmount} times";
            achAllGuns = "Have all the guns in the same run";
            achLevel30 = $"Reach level {Achievements.reachLevelAch1Amount}";
            achLevel60 = $"Reach level {Achievements.reachLevelAch2Amount}";
            achLevel90 = $"Reach level {Achievements.reachLevelAch3Amount}";
            achLevel120 = $"Reach level {Achievements.reachLevelAch4Amount}";
            achDefeatSssassins = $"Defeat {Achievements.assassinKillAchCount} assassins";
            achDefeatSpeedsters = $"Defeat {Achievements.speedsterKillAchCount} speedsters";
            achDefeatSharpshooters = $"Defeat {Achievements.sharpshooterKillAchCount} sharpshooters";
            achDefeatSnipers = $"Defeat {Achievements.sniperkillAchCount} snipers";
            achDefeatHeavyshot = $"Defeat {Achievements.heavyshotKillAchCount} heavyshots";
            achDefeatGunner = $"Defeat {Achievements.gunnersKillAchCount} raging gunners";
            achDefeatBrutes = $"Defeat {Achievements.brutesKillAchCount} brutes";
            achDefeatTitans = $"Defeat {Achievements.titansKillAchCount} titans";
            achClicks1 = $"Just click the button {Achievements.buttonClicksAch1Amount} times";
            achClicks2 = $"Just click the button {Achievements.buttonClicksAch2Amount} times";
            achClicks3 = $"Just click the button {Achievements.buttonClicksAch3Amount} times";
            achBeatRunTimer = $"Beat the game under {Achievements.speedrunnerAchTime} minutes";
            achDefeatEnemies = $"Defeat a total of {Achievements.enemyKillsAchcount} enemy buttons";
            achBeatEndingLevel = "Beat ending 1,2 or 3 at level 75";
            achAllUncommon = "Aqcuire all uncommon abilities";
            achAllRare = "Acquire all rare abilities";
            achAllLegendary = "Acquire all legendary abilities";
            achAllMythic = "Aqcuire all mythic abilities";
            achAllAbilitites = "Acquire all abilities";
            achAllMelee = "Acquire all melee abilities in the same run";
        }
        #endregion
    }


    public static string greenFade, redBlackStripes, darkWave, pinkFade, purpleFade, redTiles, greenStripes, hexagon;
    public static string basicGreeenBtn, basicPrupleBtn, basicYellowBtn, cheapGreenBtn, pureYellowBtn, discoBtn, lightningBtn, fireBtn, woodenBtn, rockBtn, purpleBtn, blueBtn, simonSaysBtn, logoBtn, funBtn, enemyBtn;

    public static string greenFadeRQ, redBlackStripesRQ, darkWaveRQ, pinkFadeRQ, purpleFadeRQ, redTilesRQ, greenStripesRQ, hexagonRQ;
    public static string basicGreeenBtnRQ, basicPrupleBtnRQ, basicYellowBtnRQ, cheapGreenBtnRQ, pureYellowBtnRQ, discoBtnRQ, lightningBtnRQ, fireBtnRQ, woodenBtnRQ, rockBtnRQ, purpleBtnRQ, blueBtnRQ, simonSaysBtnRQ, logoBtnRQ, funBtnRQ, enemyBtnRQ;
    


    public void AllSkinsTooltips()
    {
        #region ENGLISH - ACH ToolTip
        if (englishLanguage == true)
        {
            basicGreeenBtn = "Basic Green Button";
            basicPrupleBtn = "Basic Purple Button";
            basicYellowBtn = "Basic Yellow Button";
            cheapGreenBtn = "Cheap Green Button";
            pureYellowBtn = "Pure Yellow Button";
            discoBtn = "Disco Button";
            lightningBtn = "Energy Button";
            fireBtn = "Fire Button";
            woodenBtn = "Wooden Button";
            rockBtn = "Rock Button";
            purpleBtn = "Purple Button";
            blueBtn = "Blue Button";
            simonSaysBtn = "Simon Says Button";
            logoBtn = "Logo Button";
            funBtn = "Fun Button";
            enemyBtn = "Enemy Button";

            basicGreeenBtnRQ = $"Reach level {Achievements.reachLevelAch3Amount}";
            basicPrupleBtnRQ = $"Reach level {Achievements.reachLevelAch2Amount}";
            basicYellowBtnRQ = $"Reach level {Achievements.reachLevelAch1Amount}";
            cheapGreenBtnRQ = $"Get 1000 crit clicks";
            pureYellowBtnRQ = $"Defeat {Achievements.titansKillAchCount} titans";
            discoBtnRQ = "Have 6 CPS";
            lightningBtnRQ = "Acquire all melee weapons in the same run";
            fireBtnRQ = $"Defeat {Achievements.enemyKillsAchcount} enemies";
            woodenBtnRQ = $"Just click the button {Achievements.buttonClicksAch1Amount} times";
            rockBtnRQ = $"Just click the button {Achievements.buttonClicksAch2Amount} times";
            funBtnRQ = $"Just click the button {Achievements.buttonClicksAch3Amount} times";
            purpleBtnRQ = $"Beat ending 1,2 or 3 at level {Choises.levelToFirstEnding}";
            blueBtnRQ = $"Acquire a total of {Achievements.chooseAbilityAchAmount} abilities";
            simonSaysBtnRQ = "Acquire all abilities";
            logoBtnRQ = "Beat any ending";
            enemyBtnRQ = "Beat all endings";

            greenFade = "Green Fade";
            redBlackStripes = "Red & Stripes";
            darkWave = "Dark Wave";
            pinkFade = "Pink Fade";
            purpleFade = "Purple Fade";
            redTiles = "Red Tiles";
            greenStripes = "Green Stripes";
            hexagon = "Hexagon";

            greenFadeRQ = "Acquire the UZI or Pistol";
            redBlackStripesRQ = "Acquire all mythic abilities";
            darkWaveRQ = $"Defeat {Achievements.brutesKillAchCount} brutes";
            pinkFadeRQ = "Aqcuire all rare abilities";
            purpleFadeRQ = "Aqcuire all legendary abilities";
            redTilesRQ = $"Reach level {Achievements.reachLevelAch4Amount}";
            greenStripesRQ = "Acquire all weapons in the same run";
            hexagonRQ = "Acquire the talaria";
        }
        #endregion
    }

    #endregion


    #region Settings Toggles
    public static string timerToggle, abilityClicksToggle, healthbarToggle, particleEffectsToggle, damagePopUpToggle, pointPopUpToggle, whiteFlashToggle, brokenPiecesToggle;
    public TextMeshProUGUI timerToggleText, abilityClicksToggleText, healthbarToggleText, particleEffectsToggleText, damagePopUpToggleText, pointPopUpToggleText, whiteFlashToggleText, brokenPiecesToggleText;

    public void SettingsToggleText()
    {
        if(SettingsOptions.showTimer == 0) { timerToggle = "DISPLAY TIMER INGAME (DISABLED)"; }
        if (SettingsOptions.showTimer == 1) { timerToggle = "DISPLAY TIMER INGAME (ENABLED)"; }

        if (SettingsOptions.displayAbilityClicks == 0) { abilityClicksToggle = "DISPLAY ABILITY CLICKS (DISABLED)"; }
        if (SettingsOptions.displayAbilityClicks == 1) { abilityClicksToggle = "DISPLAY ABILITY CLICKS (ENABLED)"; }

        if (SettingsOptions.healthbarPosition == 0) { healthbarToggle = "BUTTON HEALTH BAR POSITION (BUTTON)"; }
        if (SettingsOptions.healthbarPosition == 1) { healthbarToggle = "BUTTON HEALTH BAR POSITION (TOP LEFT)"; }

        if (SettingsOptions.disableParticleEffects == 0) { particleEffectsToggle = "DISABLE PARTICLE EFFECTS (ENABLED)"; }
        if (SettingsOptions.disableParticleEffects == 1) { particleEffectsToggle = "DISABLE PARTICLE EFFECTS (DISABLED)"; }

        if (SettingsOptions.disableEnemyDamagePopUp == 0) { damagePopUpToggle = "DISABLE ENEMY DAMAGE POP UP (ENABLED)"; }
        if (SettingsOptions.disableEnemyDamagePopUp == 1) { damagePopUpToggle = "DISABLE ENEMY DAMAGE POP UP (DISABLED)"; }

        if (SettingsOptions.disablePointPopUp == 0) { pointPopUpToggle = "DISABLE POINTS POP UP (ENABLED)"; }
        if (SettingsOptions.disablePointPopUp == 1) { pointPopUpToggle = "DISABLE POINTS POP UP (DISABLED)"; }

        if (SettingsOptions.disableBrokenPieces == 0) { brokenPiecesToggle = "DISABLE ENEMY BROKEN PIECES (ENABLED)"; }
        if (SettingsOptions.disableBrokenPieces == 1) { brokenPiecesToggle = "DISABLE ENEMY BROKEN PIECES (DISABLED)"; }

        if (SettingsOptions.disableWhiteFlash == 0) { whiteFlashToggle = "DISABLE DAMAGE WHITE FLASH (ENABLED)"; }
        if (SettingsOptions.disableWhiteFlash == 1) { whiteFlashToggle = "DISABLE DAMAGE WHITE FLASH (DISABLED)"; }

        timerToggleText.text = timerToggle;
        abilityClicksToggleText.text = abilityClicksToggle;
        healthbarToggleText.text = healthbarToggle;
        particleEffectsToggleText.text = particleEffectsToggle;
        damagePopUpToggleText.text = damagePopUpToggle;
        pointPopUpToggleText.text = pointPopUpToggle;
        whiteFlashToggleText.text = whiteFlashToggle;
        brokenPiecesToggleText.text = brokenPiecesToggle;
    }
    #endregion
}
