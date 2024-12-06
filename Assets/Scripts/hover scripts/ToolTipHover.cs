using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ToolTipHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject endingInfoTooltip, achievementToolTip, skinsToolTip, abilitiesTooltip, currentRunToolTip;
    public RectTransform currentRunFrame;
    public bool infoHovering, achHovering, skinsHovering, abilityHover, currentRunHovering;
    public TextMeshProUGUI abilityToolTipText, abilityTooltipNameText, achText;
    public TextMeshProUGUI skinsNameText, skinsUnlockText;
    public TextMeshProUGUI currentRunName, firstStat, secondStat, thirdStar, fourthStat, fifthStat, firstStatAmount, secondStatAmount, thirdStarAmount, fourthStatAmount, fifthStatAmount, onlyInfoText;
    public TextMeshProUGUI unlockRequirmentsText;
    public string unlockReq, unlockedBy;

    public void Start()
    {
        unlockReq = "Unlock Requirements:";
        unlockedBy = "Unlocked By:";

        //  currentRunFrame.sizeDelta = new Vector2(371f, 250f); = 5 Stats

        //   currentRunFrame.sizeDelta = new Vector2(371f, 217f); = 4 Stats

        //   currentRunFrame.sizeDelta = new Vector2(371f, 192f); = 3 Stats

        //   currentRunFrame.sizeDelta = new Vector2(371f, 158f); = 2 Stats
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MobileScript.isMobile == true) { return; }

        string objectName = eventData.pointerEnter.name;

        SetAchText(objectName);

        SetCurrentRun(objectName);

        SetLockedSkin(objectName);

        SetAbilityUnlocks(objectName);

        EndingTooltip(objectName);

        #region All Skins Unlocked
        if (objectName == "Button_Gold")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = "Golden Button";
            skinsUnlockText.text = "Purchasing the DLC :D";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "button_greyBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = "Basic Grey";
            skinsUnlockText.text = "Opening the game!";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "button_yellowBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.basicYellowBtn;
            skinsUnlockText.text = $"Reaching level {Achievements.reachLevelAch1Amount}";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "button_purpleBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.basicPrupleBtn;
            skinsUnlockText.text = $"Reaching level {Achievements.reachLevelAch2Amount}";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "button_greenBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.basicGreeenBtn;
            skinsUnlockText.text = $"Reaching level {Achievements.reachLevelAch3Amount}";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_wood")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.woodenBtn;
            skinsUnlockText.text = $"Clicking the button {Achievements.buttonClicksAch1Amount} times";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_rock")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.rockBtn;
            skinsUnlockText.text = $"Clicking the button {Achievements.buttonClicksAch2Amount} times";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_Smile")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.funBtn;
            skinsUnlockText.text = $"Clicking the button {Achievements.buttonClicksAch3Amount} times";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_greenCheap")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.cheapGreenBtn;
            skinsUnlockText.text = "Hitting 1000 crit clicks";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_Disco")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.discoBtn;
            skinsUnlockText.text = "Having 6 CPS";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_Lightning")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.lightningBtn;
            skinsUnlockText.text = "Acquiring all melee weapons in the same run";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_Fire")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.fireBtn;
            skinsUnlockText.text = $"Defeating {Achievements.enemyKillsAchcount} enemies";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_PureYellow")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.pureYellowBtn;
            skinsUnlockText.text = $"Defeating {Achievements.titansKillAchCount} titans";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_PureYellow")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.pureYellowBtn;
            skinsUnlockText.text = $"Defeating {Achievements.titansKillAchCount} titans";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_blue")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.blueBtn;
            skinsUnlockText.text = $"Acquiring a total of {Achievements.chooseAbilityAchAmount} abilities";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_logo")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.logoBtn;
            skinsUnlockText.text = "Beating any ending";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_Purple")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.purpleBtn;
            skinsUnlockText.text = $"Beating ending 1,2 or 3 at level {Choises.levelToFirstEnding}";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "button_SimonSays")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.simonSaysBtn;
            skinsUnlockText.text = "Acquiring all abilities";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Button_EnemyBtn")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.enemyBtn;
            skinsUnlockText.text = "Beating all endings!";
            unlockRequirmentsText.text = unlockedBy;
        }

        if (objectName == "Background_BlueFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = "Blue Fade";
            skinsUnlockText.text = "Opening the game!";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Backroung_GreenFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.greenFade;
            skinsUnlockText.text = "Acquiring the UZI or Pistol";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "background_pinkFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.pinkFade;
            skinsUnlockText.text = "Acquiring all rare abilities";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Background_PurpleFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.purpleFade;
            skinsUnlockText.text = "Acquiring all legendary abilities";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "BAckground_BlackWave")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.darkWave;
            skinsUnlockText.text = $"Defeating {Achievements.brutesKillAchCount} brutes";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Background_Hexagon")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.hexagon;
            skinsUnlockText.text = "Acquiring the talaria";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Background_GreenThick")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.greenStripes;
            skinsUnlockText.text = "Acquiring all weapons in the same run";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "Background_RedTiles")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.redTiles;
            skinsUnlockText.text = $"Reaching level {Achievements.reachLevelAch4Amount}";
            unlockRequirmentsText.text = unlockedBy;
        }
        if (objectName == "PinkAndStriped")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.redBlackStripes;
            skinsUnlockText.text = "Acquiring all mythic abilities";
            unlockRequirmentsText.text = unlockedBy;
        }
        #endregion
    }

    public void EndingTooltip(string name)
    {
        string objectName = "";

        if (MobileScript.isMobile == true) { objectName = gameObject.name; }
        else { objectName = name; }

        if (objectName == "questionInfoTab")
        {
            endingInfoTooltip.SetActive(true);
            infoHovering = true;
        }
    }

    #region Set Ability unlocked
    public void SetAbilityUnlocks(string name)
    {
        string objectName = "";

        if (MobileScript.isMobile == true) { objectName = gameObject.name; }
        else { objectName = name; }

        if (objectName == "FrameLocked")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.abilityNameNotUnlocked;
            abilityToolTipText.text = LocalizationVariables.abilityInfoNotUnlocked;
        }

        if (objectName == "PointFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.pointsTTN;
            abilityToolTipText.text = LocalizationVariables.pointsTT;
        }

        if (objectName == "IdleFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.idleTTN;
            abilityToolTipText.text = LocalizationVariables.idleTT;
        }

        if (objectName == "CritFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.critTTN;
            abilityToolTipText.text = LocalizationVariables.critTT;
        }

        if (objectName == "PointDropFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.pointDropTTN;
            abilityToolTipText.text = LocalizationVariables.pointDropTT;
        }

        if (objectName == "FrameDoubleTab")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.doubletapTTN;
            abilityToolTipText.text = LocalizationVariables.doubletapTT;
        }

        if (objectName == "UziFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.uziTTN;
            abilityToolTipText.text = LocalizationVariables.uziTT;
        }

        if (objectName == "PistolFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.pistolTTN;
            abilityToolTipText.text = LocalizationVariables.pistolTT;
        }

        if (objectName == "ShotgunFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.shotgunTTN;
            abilityToolTipText.text = LocalizationVariables.shotgunTT;
        }

        if (objectName == "AwpFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.awpTTN;
            abilityToolTipText.text = LocalizationVariables.awpTT;
        }

        if (objectName == "DeagleFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.deagleTTN;
            abilityToolTipText.text = LocalizationVariables.deagleTT;
        }

        if (objectName == "ChargedBulletsFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.chargedBulletTTN;
            abilityToolTipText.text = LocalizationVariables.chargedBulletTT;
        }

        if (objectName == "CrossbowFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.crossbowTTN;
            abilityToolTipText.text = LocalizationVariables.crossbowTT;
        }

        if (objectName == "CannonFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.cannonTTN;
            abilityToolTipText.text = LocalizationVariables.cannonTT;
        }

        if (objectName == "Mp4Frame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.mp4TTN;
            abilityToolTipText.text = LocalizationVariables.mp4TT;
        }

        if (objectName == "ArrowFrame")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.arrosTTN;
            abilityToolTipText.text = LocalizationVariables.arrosTT;
        }

        if (objectName == "FrameBoxingGlove")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.boxinggloveTTN;
            abilityToolTipText.text = LocalizationVariables.boxinggloveTT;
        }

        if (objectName == "FrameStabbySpike")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.stabbyspikeTTN;
            abilityToolTipText.text = LocalizationVariables.stabbyspikeTT;
        }

        if (objectName == "FrameTinySpikes")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.tinySpikeTTN;
            abilityToolTipText.text = LocalizationVariables.tinySpikeTT;
        }

        if (objectName == "FrameKnifes")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.knifeTTN;
            abilityToolTipText.text = LocalizationVariables.knifeTT;
        }

        if (objectName == "FrameSawBlade")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.sawBladeTTN;
            abilityToolTipText.text = LocalizationVariables.sawBladeTT;
        }

        if (objectName == "FrameSword")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.swordTTN;
            abilityToolTipText.text = LocalizationVariables.swordTT;
        }

        if (objectName == "FrameHammer")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.hammerTTN;
            abilityToolTipText.text = LocalizationVariables.hammerTT;
        }

        if (objectName == "FrameDefense")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.defenseTTN;
            abilityToolTipText.text = LocalizationVariables.defenseTT;
        }

        if (objectName == "FrameBigHeart")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.heartTTN;
            abilityToolTipText.text = LocalizationVariables.heartTT;
        }

        if (objectName == "FrameSmallShields")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.smallShieldTTN;
            abilityToolTipText.text = LocalizationVariables.smallShieldTT;
        }

        if (objectName == "FrameBouncyShield")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.bouncyShieldTTN;
            abilityToolTipText.text = LocalizationVariables.bouncyShieldTT;
        }

        if (objectName == "FrameInvin")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.invinTTN;
            abilityToolTipText.text = LocalizationVariables.invinTT;
        }

        if (objectName == "FrameStoptime")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.stopwatchTTN;
            abilityToolTipText.text = LocalizationVariables.stopwatchTT;
        }

        if (objectName == "FrameBooster")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.boosterTTN;
            abilityToolTipText.text = LocalizationVariables.boosterTT;
        }

        if (objectName == "FrameRocket")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.rocketTTN;
            abilityToolTipText.text = LocalizationVariables.rocketTT;
        }

        if (objectName == "FrameTalaria")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.talariaTTN;
            abilityToolTipText.text = LocalizationVariables.talariaTT;
        }

        if (objectName == "Frame2Random")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.random2TTN;
            abilityToolTipText.text = LocalizationVariables.random2TT;
        }

        if (objectName == "Frame3Random")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.random3TTN;
            abilityToolTipText.text = LocalizationVariables.random3TT;
        }

        if (objectName == "Frame5Random")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.random5TTN;
            abilityToolTipText.text = LocalizationVariables.random5TT;
        }

        if (objectName == "FrameRitual")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.ritualTTNN;
            abilityToolTipText.text = LocalizationVariables.ritualTT;
        }

        if (objectName == "FrameEgg")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.eggTTN;
            abilityToolTipText.text = LocalizationVariables.eggTT;
        }

        if (objectName == "FrameArena")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.arenaTTN;
            abilityToolTipText.text = LocalizationVariables.arenaTT;
        }

        if (objectName == "Frame4Abilties")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.abiltites4XTTN;
            abilityToolTipText.text = LocalizationVariables.abiltites4XTT;
        }

        if (objectName == "FrameRerollRare")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.rerollRareTTN;
            abilityToolTipText.text = LocalizationVariables.rerollRareTT;
        }

        if (objectName == "Frame5Abilites")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.abilities5XTTN;
            abilityToolTipText.text = LocalizationVariables.abilities5XTT;
        }

        if (objectName == "FrameRerollLEgendary")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.rerollLegendaryTTN;
            abilityToolTipText.text = LocalizationVariables.rerollLegendaryTT;
        }

        if (objectName == "FrameSkullHarvest")
        {
            abilitiesTooltip.SetActive(true); abilityHover = true;
            abilityTooltipNameText.text = LocalizationVariables.skullHarvestTTN;
            abilityToolTipText.text = LocalizationVariables.skullHarvestTT;
        }
    }
    #endregion

    #region Set locked skin
    public void SetLockedSkin(string name)
    {
        string objectName = "";

        if (MobileScript.isMobile == true) { objectName = gameObject.name; }
        else { objectName = name; }

        if (objectName == "lockedGreenBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.basicGreeenBtn;
            skinsUnlockText.text = LocalizationVariables.basicGreeenBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedPurpleBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.basicPrupleBtn;
            skinsUnlockText.text = LocalizationVariables.basicPrupleBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedYellowBasic")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.basicYellowBtn;
            skinsUnlockText.text = LocalizationVariables.basicYellowBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedGreenCheap")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.cheapGreenBtn;
            skinsUnlockText.text = LocalizationVariables.cheapGreenBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedOnlyYellow")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.pureYellowBtn;
            skinsUnlockText.text = LocalizationVariables.pureYellowBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "discoLocked")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.discoBtn;
            skinsUnlockText.text = LocalizationVariables.discoBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lighningLocked")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.lightningBtn;
            skinsUnlockText.text = LocalizationVariables.lightningBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "fireLocked")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.fireBtn;
            skinsUnlockText.text = LocalizationVariables.fireBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedWooden")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.woodenBtn;
            skinsUnlockText.text = LocalizationVariables.woodenBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "rockLocked")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.rockBtn;
            skinsUnlockText.text = LocalizationVariables.rockBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedPurple")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.purpleBtn;
            skinsUnlockText.text = LocalizationVariables.purpleBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedBlue")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.blueBtn;
            skinsUnlockText.text = LocalizationVariables.blueBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedsimonSais")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.simonSaysBtn;
            skinsUnlockText.text = LocalizationVariables.simonSaysBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedLogo")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.logoBtn;
            skinsUnlockText.text = LocalizationVariables.logoBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedFun")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.funBtn;
            skinsUnlockText.text = LocalizationVariables.funBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "lockedEnemyBtn")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.enemyBtn;
            skinsUnlockText.text = LocalizationVariables.enemyBtnRQ;
            unlockRequirmentsText.text = unlockReq;
        }

        if (objectName == "LockedGreenFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.greenFade;
            skinsUnlockText.text = LocalizationVariables.greenFadeRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedRedWBlackStripes")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.redBlackStripes;
            skinsUnlockText.text = LocalizationVariables.redBlackStripesRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedDarkWave")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.darkWave;
            skinsUnlockText.text = LocalizationVariables.darkWaveRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedPinkFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.pinkFade;
            skinsUnlockText.text = LocalizationVariables.pinkFadeRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedPurpleFade")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.purpleFade;
            skinsUnlockText.text = LocalizationVariables.purpleFadeRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedRedTiles")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.redTiles;
            skinsUnlockText.text = LocalizationVariables.redTilesRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedGreenStripes")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.greenStripes;
            skinsUnlockText.text = LocalizationVariables.greenStripesRQ;
            unlockRequirmentsText.text = unlockReq;
        }
        if (objectName == "LockedHexagon")
        {
            skinsToolTip.SetActive(true); skinsHovering = true;
            skinsNameText.text = LocalizationVariables.hexagon;
            skinsUnlockText.text = LocalizationVariables.hexagonRQ;
            unlockRequirmentsText.text = unlockReq;
        }
    }
    #endregion

    #region Set current run
    public void SetCurrentRun(string name)
    {
        string objectName = "";

        if (MobileScript.isMobile == true) { objectName = gameObject.name; }
        else { objectName = name; }

        if (objectName == "PointFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 158f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.pointsPerClick;
            firstStatAmount.text = Choises.pointsLEVEL.ToString("F0");
            secondStatAmount.text = (ButtonClick.pointsPerClick + Choises.totalIdlePoints).ToString("F0");
            thirdStar.text = ""; fourthStat.text = ""; fifthStat.text = "";
            thirdStarAmount.text = ""; fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.pointsTTN;
        }
        if (objectName == "IdleFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 158f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.CPS;
            thirdStar.text = "";
            firstStatAmount.text = Choises.idleLEVEL.ToString("F0");
            secondStatAmount.text = (1 / Choises.timeBetweenClicks).ToString("F1");
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.idleTTN;
        }
        if (objectName == "CritFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.critChance;
            thirdStar.text = LocalizationVariables.critIncrease;
            firstStatAmount.text = Choises.critLEVEL.ToString("F0");
            secondStatAmount.text = Choises.critClicksChance.ToString("F1") + "%";
            thirdStarAmount.text = (Choises.critClicksBonus * 100).ToString("F0") + "%";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.critTTN;
        }
        if (objectName == "PointDropFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.pointDropPointsString;
            thirdStar.text = LocalizationVariables.pointDropPointIncreaseString;
            firstStatAmount.text = Choises.pointDropLEVEL.ToString("F0");
            secondStatAmount.text = (Choises.pointDropBasicPoints * 100).ToString("F0") + "%";
            thirdStarAmount.text = (Choises.pointDropRarityIncreasePoints * 100).ToString("F0") + "%";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.pointDropTTN;
        }
        if (objectName == "FrameDefenseCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.hp;
            thirdStar.text = LocalizationVariables.regen;
            firstStatAmount.text = Choises.defenseLEVEL.ToString("F0");
            secondStatAmount.text = Choises.maxButtonHealth.ToString("F0");
            thirdStarAmount.text = Choises.healthRegenPerSecond.ToString("F1");
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.defenseTTN;
        }
        if (objectName == "FrameBigHeartCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.heal;
            firstStatAmount.text = Choises.heartLEVEL.ToString("F0");
            secondStatAmount.text = Choises.bigHeartClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.bigHeartHPHeal.ToString("F0");
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.heartTTN;
        }
        if (objectName == "FrameSmallShieldsCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.hp;
            thirdStar.text = LocalizationVariables.rechargeTime;
            firstStatAmount.text = Choises.smallShieldLEVEL.ToString("F0");
            secondStatAmount.text = Choises.smallShieldHP.ToString("F0");
            thirdStarAmount.text = Choises.smallShieldRechargeTimer.ToString("F1") + "s";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.smallShieldTTN;
        }
        if (objectName == "FrameBouncyShieldCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.hp;
            thirdStar.text = LocalizationVariables.rechargeTime;
            firstStatAmount.text = Choises.bouncyShieldLEVEL.ToString("F0");
            secondStatAmount.text = Choises.shieldBounce_health.ToString("F0");
            thirdStarAmount.text = Choises.reChargeTimer.ToString("F1") + "s";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.bouncyShieldTTN;
        }
        if (objectName == "FrameStoptimeCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.stopTime;
            firstStatAmount.text = Choises.stopwatchLEVEL.ToString("F0");
            secondStatAmount.text = Choises.stopTimeClickTotal.ToString("F0");
            thirdStarAmount.text = Choises.stopTimeTimer.ToString("F1") + "s";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.stopwatchTTN;
        }
        if (objectName == "FrameInvinCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.addedTime;
            firstStatAmount.text = Choises.invinLEVEL.ToString("F0");
            secondStatAmount.text = Choises.invincibilityClickPer1Second.ToString("F0");
            thirdStarAmount.text = Choises.invincibilityTimeAdded.ToString("F1") + "s";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.invinTTN;
        }
        if (objectName == "PistolFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.pistolLEVEL.ToString("F0");
            secondStatAmount.text = Choises.pistolClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.bulletGun1_Damage.ToString("F0");
            fourthStatAmount.text = Choises.bulletGun1_Speed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.pistolTTN;
        }
        if (objectName == "UziFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.uziLEVEL.ToString("F0");
            secondStatAmount.text = Choises.clickPerSmallBullet.ToString("F0");
            thirdStarAmount.text = Choises.smallBulletDamage.ToString("F0");
            fourthStatAmount.text = Choises.smallBulletSpeed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.uziTTN;
        }
        if (objectName == "ShotgunFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;
            fifthStat.text = LocalizationVariables.shotgunShotsString;

            firstStatAmount.text = Choises.shotgunLEVEL.ToString("F0");
            secondStatAmount.text = Choises.shotGunClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.shotGunBulletDamage.ToString("F0") + "-" + Choises.shotGunBulletDamage2.ToString("F0");
            fourthStatAmount.text = Choises.shotGunBulletSpeed1.ToString("F0") + "-" + Choises.shotGunBulletSpeed2.ToString("F0");
            fifthStatAmount.text = Choises.shotGunBullets.ToString("F0");
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.shotgunTTN;
        }
        if (objectName == "AwpFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.awpLEVEL.ToString("F0");
            secondStatAmount.text = Choises.clicksPerHomingBullet.ToString("F0");
            thirdStarAmount.text = Choises.homingBulletDamage.ToString("F0");
            fourthStatAmount.text = Choises.homignBulletSpeed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.awpTTN;
        }
        if (objectName == "DeagleFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.deagleLEVEL.ToString("F0");
            secondStatAmount.text = Choises.trippleShotNeeded.ToString("F0");
            thirdStarAmount.text = Choises.trippleShotDamage.ToString("F0");
            fourthStatAmount.text = Choises.trippleShotSpeed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.deagleTTN;
        }
        if (objectName == "CrossbowFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.crossbowLEVEL.ToString("F0");
            secondStatAmount.text = Choises.crossbowClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.crossbowDamage.ToString("F0");
            fourthStatAmount.text = Choises.crossbowSpeed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.crossbowTTN;
        }
        if (objectName == "ChargedBulletsFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = "Max Damage";
            thirdStar.text = LocalizationVariables.chargeTime;
            firstStatAmount.text = Choises.chargedBulletLEVEL.ToString("F0");
            secondStatAmount.text = Choises.chargedBulletMaxDamage.ToString("F0");
            thirdStarAmount.text = Choises.chargedBulletChargeTime.ToString("F1") + "s";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.chargedBulletTTN;
        }
        if (objectName == "CannonFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.cannonLEVEL.ToString("F0");
            secondStatAmount.text = Choises.clicksPerBigBullet.ToString("F0");
            thirdStarAmount.text = Choises.bigBulletDamage.ToString("F0");
            fourthStatAmount.text = Choises.bigBulletSpeed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.cannonTTN;
        }
        if (objectName == "Mp4FrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.mp4LEVEL.ToString("F0");
            secondStatAmount.text = Choises.mp4ClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.mp4Damage.ToString("F0");
            fourthStatAmount.text = Choises.mp4Speed.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.mp4TTN;
        }
        if (objectName == "ArrowFrameCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.arrowsCount;

            firstStatAmount.text = Choises.arrosLEVEL.ToString("F0");
            secondStatAmount.text = Choises.arrowClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.arrowDamage.ToString("F0");
            fourthStatAmount.text = Choises.arrowCountShot.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.arrosTTN;
        }
        if (objectName == "FrameTinySpikesCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 158f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.damage;

            firstStatAmount.text = Choises.tinySpikeLEVEL.ToString("F0");
            secondStatAmount.text = Choises.spikeDamagePerSecond.ToString("F1");

            thirdStar.text = ""; fourthStat.text = ""; fifthStat.text = "";
            thirdStarAmount.text = ""; fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.tinySpikeTTN;
        }
        if (objectName == "FrameStabbySpikeCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;

            firstStatAmount.text = Choises.stabbyspikeLEVEL.ToString("F0");
            secondStatAmount.text = Choises.stabbingSpikesClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.stabbingSpikeDamage.ToString("F0");

            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.stabbyspikeTTN;
        }
        if (objectName == "FrameBoxingGloveCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.knockbackForce;

            firstStatAmount.text = Choises.boxingloveLEVEL.ToString("F0");
            secondStatAmount.text = Choises.boxingGloveClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.boxingGloveKnockbackAmount.ToString("F1");

            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.boxinggloveTTN;
        }
        if (objectName == "FrameKnifesCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.knifesCount;

            firstStatAmount.text = Choises.knifeLEVEL.ToString("F0");
            secondStatAmount.text = Choises.knifeClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.knifeDamage.ToString("F0");
            fourthStatAmount.text = Choises.knifeTotalCount.ToString("F0");
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.knifeTTN;
        }
        if (objectName == "FrameSawBladeCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.damage;
            thirdStar.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.sawBladeLEVEL.ToString("F0");
            secondStatAmount.text = Choises.sawBladeDamage.ToString("F0");
            thirdStarAmount.text = Choises.sawBladeSpeed.ToString("F0");
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.sawBladeTTN;
        }
        if (objectName == "FrameSwordCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.damage;
            thirdStar.text = LocalizationVariables.speed;

            firstStatAmount.text = Choises.swordLEVEL.ToString("F0");
            secondStatAmount.text = Choises.bigSpikeDamage.ToString("F0");
            thirdStarAmount.text = Choises.swordSpeed.ToString("F0");
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.swordTTN;
        }
        if (objectName == "FrameHammerCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 217f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.damage;
            fourthStat.text = LocalizationVariables.stunTime;

            firstStatAmount.text = Choises.hammerLEVEL.ToString("F0");
            secondStatAmount.text = Choises.hammerClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.hammerDamage.ToString("F0");
            fourthStatAmount.text = Choises.hammerStunTime.ToString("F1") + "s";
            fifthStat.text = "";
            fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.hammerTTN;
        }
        if (objectName == "FrameRitualCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.despawnTime;

            firstStatAmount.text = Choises.ritualLEVEL.ToString("F0");
            secondStatAmount.text = Choises.ritualClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.ritualTimer.ToString("F1") + "s";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.ritualTTNN;
        }
        if (objectName == "FrameRerollRareCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 192f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = LocalizationVariables.buttonClicksString;
            thirdStar.text = LocalizationVariables.dice2XChance;

            firstStatAmount.text = Choises.rerollLEVEL.ToString("F0");
            secondStatAmount.text = Choises.rerollClicksNeeded.ToString("F0");
            thirdStarAmount.text = Choises.rerollDoubleChance.ToString("F1") + "%";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.rerollRareTTN;
        }
        if (objectName == "FrameArenaCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 128f);
            currentRunHovering = true;
            firstStat.text = LocalizationVariables.level;
            secondStat.text = "";
            thirdStar.text = "";

            firstStatAmount.text = Choises.arenaLEVEL.ToString("F0");
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            onlyInfoText.text = "";
            currentRunName.text = LocalizationVariables.arenaTTN;
        }

        //Non stat display
        if (objectName == "FrameSkullHarvestCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "Skulls consumed give a really small upgrade to a random ability.";

            firstStat.text = LocalizationVariables.level;
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = Choises.skullHarvestLEVEL.ToString("F0");
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.skullHarvestTTN;
        }

        if (objectName == "Frame4AbiltiesCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "You can now choose between 4 abilities each time you level up.";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.abiltites4XTTN;
        }
        if (objectName == "Frame5AbilitesCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "You can now choose between 5 abilities each time you level up.";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.abilities5XTTN;
        }
        if (objectName == "FrameBoosterCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "Charge and boost your button!";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.boosterTTN;
        }
        if (objectName == "FrameRocketCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "Steer, charge and boost your button!";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.rocketTTN;
        }
        if (objectName == "FrameTalariaCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "Move your button freely.";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.talariaTTN;
        }
        if (objectName == "FrameDoubleTabCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "Each click is now 2 clicks. Does not effect idle clicks.";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.doubletapTTN;
        }
        if (objectName == "FrameEggCurrent")
        {
            currentRunToolTip.SetActive(true);
            currentRunFrame.sizeDelta = new Vector2(371f, 250f);
            currentRunHovering = true;

            onlyInfoText.text = "Chooses an ability to be upgraded each time you level up.";

            firstStat.text = "";
            secondStat.text = "";
            thirdStar.text = "";
            firstStatAmount.text = "";
            secondStatAmount.text = "";
            thirdStarAmount.text = "";
            fourthStat.text = ""; fifthStat.text = "";
            fourthStatAmount.text = ""; fifthStatAmount.text = "";
            currentRunName.text = LocalizationVariables.eggTTN;
        }
    }
    #endregion

    #region Ach texts
    public void SetAchText(string name)
    {
        string objectName = "";

        if (MobileScript.isMobile == true) { objectName = gameObject.name; }
        else { objectName = name; }

        if (objectName == "ach_level30")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achLevel30;
        }

        if (objectName == "ach_level60")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achLevel60;
        }

        if (objectName == "ach_level90")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achLevel90;
        }

        if (objectName == "ach_level120")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achLevel120;
        }

        if (objectName == "ach_crit")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achCrit;
        }

        if (objectName == "ach_idle")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achCPS;
        }

        if (objectName == "ach_PISTOL")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achPistol;
        }

        if (objectName == "ach_Uzi")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achUzi;
        }

        if (objectName == "ach_CROSSBOW")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achCrossbow;
        }

        if (objectName == "ach_SHOTGUN")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achShotgun;
        }

        if (objectName == "ach_DEAGLE")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDeagle;
        }

        if (objectName == "ach_AWP")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAwp;
        }

        if (objectName == "ach_CANNON")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achCannon;
        }

        if (objectName == "ach_MP4")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achMP4;
        }

        if (objectName == "ach_ability")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAbilities;
        }

        if (objectName == "ach_1000Arrows")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achPointBlank;
        }

        if (objectName == "ach_BeatBoss")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achBeatBoss;
        }

        if (objectName == "ach_BeatHorde")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achBeatHorde;
        }

        if (objectName == "ach_BeatChampion")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achBeatChampions;
        }

        if (objectName == "ach_BeatDangerButton")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achBeatDangerButton;
        }

        if (objectName == "ach_beatAllEndings")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllEndings;
        }

        if (objectName == "ach_BeatLevel50")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achBeatEndingLevel;
        }

        if (objectName == "ach_beatEndingTimer")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achBeatRunTimer;
        }

        if (objectName == "ach_Talaria")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achTalaria;
        }

        if (objectName == "ach_DoubleTap")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDoubleTap;
        }

        if (objectName == "ach_StopWatch")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achStopwatch;
        }

        if (objectName == "ach_Egg")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achEgg;
        }

        if (objectName == "ach_SkullHarvest")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achSkullHarvest;
        }

        if (objectName == "ach_1000skulls")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achSkullHarvestConsume;
        }

        if (objectName == "ach_reroll100")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achReroll;
        }

        if (objectName == "ach_defeat5000enemies")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatEnemies;
        }

        if (objectName == "ach_defeatAssassins")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatSssassins;
        }

        if (objectName == "ach_defeatspeedsters")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatSpeedsters;
        }

        if (objectName == "ach_defeatSharpshooters")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatSharpshooters;
        }

        if (objectName == "ach_defeatSnipers")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatSnipers;
        }

        if (objectName == "ach_defeatHEavyshot")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatHeavyshot;
        }

        if (objectName == "ach_defeatGunner")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatGunner;
        }

        if (objectName == "ach_defeatBrute")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatBrutes;
        }

        if (objectName == "ach_defeatTitan")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achDefeatTitans;
        }

        if (objectName == "ach_100Clicks")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achClicks1;
        }

        if (objectName == "ach_5000Clicks")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achClicks2;
        }

        if (objectName == "ach_50000Clicks")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achClicks3;
        }

        if (objectName == "ach_allUncommon")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllUncommon;
        }

        if (objectName == "ach_allrare")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllRare;
        }

        if (objectName == "ach_alllegendary")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllLegendary;
        }

        if (objectName == "ach_allmythic")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllMythic;
        }

        if (objectName == "ach_allAbilities")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllAbilitites;
        }

        if (objectName == "ach_allGuns")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllGuns;
        }

        if (objectName == "ach_allMelee")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achAllMelee;
        }

        if (objectName == "ach_Fun")
        {
            achievementToolTip.SetActive(true); achHovering = true;
            achText.text = LocalizationVariables.achFun;
        }
    }
    #endregion


    public void OnPointerExit(PointerEventData eventData)
    {
        if(MobileScript.isMobile == true) { return; }

        if (skinsHovering == true)
        {
            skinsHovering = false;
            skinsToolTip.SetActive(false);
        }
        else if (abilityHover == true)
        {
            abilityHover = false;
            abilitiesTooltip.SetActive(false);
        }
        else if (currentRunHovering == true)
        {
            currentRunHovering = false;
            currentRunToolTip.SetActive(false);
        }
        else
        {
            endingInfoTooltip.SetActive(false);
            achievementToolTip.SetActive(false);
            skinsToolTip.SetActive(false);
            infoHovering = false;
            achHovering = false;
            abilityHover = false;
        }
    }

    public void Update()
    {
        if (MobileScript.isMobile == false) 
        {
            if (infoHovering == true)
            {
                endingInfoTooltip.transform.position = Input.mousePosition;
            }
            if (achHovering == true)
            {
                achievementToolTip.transform.position = Input.mousePosition;
            }
            if (abilityHover == true)
            {
                abilitiesTooltip.transform.position = Input.mousePosition;
            }
            if (skinsHovering == true)
            {
                skinsToolTip.transform.position = Input.mousePosition;
            }
            if (currentRunHovering == true)
            {
                currentRunToolTip.transform.position = Input.mousePosition;
            }
        }
    }
}
