using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    private bool isOpen;

    public GameObject ChangeBackgroundAndButtonsBar;

    public GameObject selectedButton, selectedBackGround;

    public AudioManager audioManager;

    public void Start()
    {
    

        if (!PlayerPrefs.HasKey("ResStriped")) 
        {
            BlueFadeBackground();
            SetBasicGrey();
        }
        else
        {
            choseRedStiped =  PlayerPrefs.GetInt("ResStriped");
            choseGreenFade = PlayerPrefs.GetInt("GreenFade");
            chooseBlueFade = PlayerPrefs.GetInt("BlueFade");
            choseTiltedGreen = PlayerPrefs.GetInt("TiltedGreen");
            choseVerticalGreen = PlayerPrefs.GetInt("VerticalGreen");
            choseHexagon = PlayerPrefs.GetInt("Hexagon");
            choseGreyWave = PlayerPrefs.GetInt("GreyWave");
            chosePinkFade = PlayerPrefs.GetInt("PinkFade");
            choseredTiles = PlayerPrefs.GetInt("RedTiles");

            if(choseRedStiped == 1) { RedStripeds(); }
            if (choseGreenFade == 1) { GreenFadeBackground(); }
            if (chooseBlueFade == 1) { BlueFadeBackground(); }
            if (choseTiltedGreen == 1) { TiltedGreenFade(); }
            if (choseVerticalGreen == 1) { VerticalThick(); }
            if (choseHexagon == 1) { Hexagon(); }
            if (choseGreyWave == 1) { GreyWaveBackground(); }
            if (chosePinkFade == 1) { PinkFadeBackground(); }
            if (choseredTiles == 1) { RedTilesBackground(); }

            cheapGreenChose = PlayerPrefs.GetInt("CheapGreen");
            onlyYellowChose = PlayerPrefs.GetInt("OnlyYellow");
            discoChose = PlayerPrefs.GetInt("Disco");
            lightningChose = PlayerPrefs.GetInt("Lightning");
            fireChose = PlayerPrefs.GetInt("Fire");
            basicGreenChose = PlayerPrefs.GetInt("BasicGreen");
            basicGreyChose = PlayerPrefs.GetInt("BasicGrey");
            basicPurpleChose = PlayerPrefs.GetInt("BasicPurple");
            basicYellowChose = PlayerPrefs.GetInt("BasicYellow");
            woodChose = PlayerPrefs.GetInt("Wood");
            rockChose = PlayerPrefs.GetInt("Rock");
            purpleChose = PlayerPrefs.GetInt("Purple");
            blueChose = PlayerPrefs.GetInt("Blue");
            simonSaysChose = PlayerPrefs.GetInt("SimonSays");
            greenChose = PlayerPrefs.GetInt("Green");
            goldChose = PlayerPrefs.GetInt("Gold");
            smileChose = PlayerPrefs.GetInt("Smile");
            enemyChose = PlayerPrefs.GetInt("Enemy");

            if (cheapGreenChose == 1) { SetCheapGreen(); }
            if (onlyYellowChose == 1) { SetOnlyYellow(); }
            if (discoChose == 1) { SetDisco(); }
            if (lightningChose == 1) { SetLightning(); }
            if (fireChose == 1) { SetFire(); }
            if (basicGreenChose == 1) { SetBasicGreen(); }
            if (basicGreyChose == 1) { SetBasicGrey(); }
            if (basicPurpleChose == 1) { SetBasicPurple(); }
            if (basicYellowChose == 1) { SetBasicYellow(); }
            if (woodChose == 1) { SetWood(); }
            if (rockChose == 1) { SetRock(); }
            if (purpleChose == 1) { SetPurple(); }
            if (blueChose == 1) { SetBlue(); }
            if (simonSaysChose == 1) { SetSimonsSays(); }
            if (greenChose == 1) { SetGreen(); }
            if (goldChose == 1) { SetGold(); }
            if (smileChose == 1) { SetSmile(); }
            if (enemyChose == 1) { SetEnemy(); }
        }

        StartCoroutine(wait());
    }

    public bool playClickSound;
    IEnumerator wait()
    {
        playClickSound = false;
        yield return new WaitForSeconds(0.5f);
        playClickSound = true;
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    OpenBackgroundAndButtons();
        //}
    }
    public void OpenBackgroundAndButtons()
    {
        if (isOpen == false) { ChangeBackgroundAndButtonsBar.SetActive(true); isOpen = true; }
        else { ChangeBackgroundAndButtonsBar.SetActive(false); isOpen = false; }
    }

    #region Change backgrounds

    public GameObject redStripedBackgroundBTN, greedFadeBackgroundBTN, blueFadeBackgroundBTN, tiltedGreenBackgroundBTN, hexagonBackgroundBTN, greyWaveBackgroundBTN, greenVeritcalBackgroundBTN, pinkFadeBackgroundBTN, redTileBackgroundBTN;

    public GameObject redStripedBackground, greedFadeBackground, blueFadeBackground, tiltedGreenBackground, hexagonBackground, greyWaveBackground, greenVeritcalBackground, pinkFadeBackground, redTileBackground;

    public GameObject redStripedBackgroundExample, greedFadeBackgroundExample, blueFadeBackgroundExample, tiltedGreenBackgroundExample, hexagonBackgroundExample, greyWaveBackgroundExample, greenVeritcalBackgroundExample, pinkFadeBackgroundExample, redTileBackgroundExample;

    public int choseRedStiped, choseGreenFade, chooseBlueFade, choseTiltedGreen, choseVerticalGreen, choseHexagon, choseGreyWave, chosePinkFade, choseredTiles;

    public static bool isFunBtnEquipped, isRedTilesEquipped;

    public void SetAllBackgroundOff()
    {
        if (playClickSound == true) { audioManager.Play("UI_Click2"); }

        choseRedStiped = 0; choseGreenFade = 0; chooseBlueFade = 0; choseTiltedGreen = 0; choseVerticalGreen = 0;
        choseHexagon = 0; choseGreyWave = 0; chosePinkFade = 0; choseredTiles = 0;

        PlayerPrefs.SetInt("ResStriped", choseRedStiped);
        PlayerPrefs.SetInt("GreenFade", choseGreenFade);
        PlayerPrefs.SetInt("BlueFade", chooseBlueFade);
        PlayerPrefs.SetInt("TiltedGreen", choseTiltedGreen);
        PlayerPrefs.SetInt("VerticalGreen", choseVerticalGreen);
        PlayerPrefs.SetInt("Hexagon", choseHexagon);
        PlayerPrefs.SetInt("GreyWave", choseGreyWave);
        PlayerPrefs.SetInt("PinkFade", chosePinkFade);
        PlayerPrefs.SetInt("RedTiles", choseredTiles);

        redStripedBackground.SetActive(false);
        greedFadeBackground.SetActive(false);
        blueFadeBackground.SetActive(false);
        tiltedGreenBackground.SetActive(false);
        hexagonBackground.SetActive(false);
        greyWaveBackground.SetActive(false);
        greenVeritcalBackground.SetActive(false);
        pinkFadeBackground.SetActive(false);
        redTileBackground.SetActive(false);

        redStripedBackgroundExample.SetActive(false);
        greedFadeBackgroundExample.SetActive(false);
        blueFadeBackgroundExample.SetActive(false);
        tiltedGreenBackgroundExample.SetActive(false);
        hexagonBackgroundExample.SetActive(false);
        greyWaveBackgroundExample.SetActive(false);
        greenVeritcalBackgroundExample.SetActive(false);
        pinkFadeBackgroundExample.SetActive(false);
        redTileBackgroundExample.SetActive(false);

        isRedTilesEquipped = false;
    }
    public void RedStripeds()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = redStripedBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(redStripedBackgroundBTN.transform);

        choseRedStiped = 1;
        PlayerPrefs.SetInt("ResStriped", choseRedStiped);

        redStripedBackground.SetActive(true);
        redStripedBackgroundExample.SetActive(true);
    }

    public void GreenFadeBackground()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = greedFadeBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(greedFadeBackgroundBTN.transform);

        choseGreenFade = 1;
        PlayerPrefs.SetInt("GreenFade", choseGreenFade);

        greedFadeBackground.SetActive(true);
        greedFadeBackgroundExample.SetActive(true);
    }
    public void BlueFadeBackground()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = blueFadeBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(blueFadeBackgroundBTN.transform);

        chooseBlueFade = 1;
        PlayerPrefs.SetInt("BlueFade", chooseBlueFade);

        blueFadeBackground.SetActive(true);
        blueFadeBackgroundExample.SetActive(true);
    }

    public void TiltedGreenFade()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = tiltedGreenBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(tiltedGreenBackgroundBTN.transform);

        choseTiltedGreen = 1;
        PlayerPrefs.SetInt("TiltedGreen", choseTiltedGreen);

        tiltedGreenBackground.SetActive(true);
        tiltedGreenBackgroundExample.SetActive(true);
    }

    public void VerticalThick()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = greenVeritcalBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(greenVeritcalBackgroundBTN.transform);

        choseVerticalGreen = 1;
        PlayerPrefs.SetInt("VerticalGreen", choseVerticalGreen);

        greenVeritcalBackground.SetActive(true);
        greenVeritcalBackgroundExample.SetActive(true);
    }

    public void Hexagon()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = hexagonBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(hexagonBackgroundBTN.transform);

        choseHexagon = 1;
        PlayerPrefs.SetInt("Hexagon", choseHexagon);

        hexagonBackground.SetActive(true);
        hexagonBackgroundExample.SetActive(true);
    }

    public void GreyWaveBackground()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = greyWaveBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(greyWaveBackgroundBTN.transform);

        choseGreyWave = 1;
        PlayerPrefs.SetInt("GreyWave", choseGreyWave);

        greyWaveBackground.SetActive(true);
        greyWaveBackgroundExample.SetActive(true);
    }

    public void PinkFadeBackground()
    {
        SetAllBackgroundOff();

        selectedBackGround.transform.position = pinkFadeBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(pinkFadeBackgroundBTN.transform);

        chosePinkFade = 1;
        PlayerPrefs.SetInt("PinkFade", chosePinkFade);

        pinkFadeBackground.SetActive(true);
        pinkFadeBackgroundExample.SetActive(true);
    }

    public void RedTilesBackground()
    {
        SetAllBackgroundOff();

        isRedTilesEquipped = true;

        selectedBackGround.transform.position = redTileBackgroundBTN.transform.position;
        selectedBackGround.transform.SetParent(redTileBackgroundBTN.transform);

        choseredTiles = 1;
        PlayerPrefs.SetInt("RedTiles", choseredTiles);

        redTileBackground.SetActive(true);
        redTileBackgroundExample.SetActive(true);
    }
    #endregion

    #region Change buttons
    public GameObject cheapGreenBTN, onlyYellowBTN, discoBTN, lightningBTN, fireBTN, basicGreenBTN, basicGreyBTN, basicPurpleBTN, basicYellowBTN, woodBTN, rockBTN, purpleBTN, blueBTN, simonSaysBTN, greenBTN, goldBTN, smileBTN, enemyBTN;

    public Sprite cheapGreen, onlyYellow, disco, lightning, fire, basicGreen, basicGrey, basicPurple, basicYellow, wood, rock, purple, blue, simonSays, green, gold, smile, enemy;
    public Image mainButton, mainButtonExample, smallButtonCharge, controlsButtonExample;

    public int cheapGreenChose, onlyYellowChose, discoChose, lightningChose, fireChose, basicGreenChose, basicGreyChose, basicPurpleChose, basicYellowChose, woodChose, rockChose, purpleChose, blueChose, simonSaysChose, greenChose, goldChose, smileChose, enemyChose;

    public void SetBackButtonSkins()
    {
        if(playClickSound == true) { audioManager.Play("UI_Click2"); }

        cheapGreenChose = 0; onlyYellowChose = 0; discoChose = 0; lightningChose = 0; fireChose = 0; basicGreenChose = 0; basicGreyChose = 0;
        basicPurpleChose = 0; basicYellowChose = 0; woodChose = 0; rockChose = 0; purpleChose = 0; blueChose = 0;
        simonSaysChose = 0; greenChose = 0; goldChose = 0; smileChose = 0; enemyChose = 0;

        PlayerPrefs.SetInt("CheapGreen", cheapGreenChose);
        PlayerPrefs.SetInt("OnlyYellow", onlyYellowChose);
        PlayerPrefs.SetInt("Disco", discoChose);
        PlayerPrefs.SetInt("Lightning", lightningChose);
        PlayerPrefs.SetInt("Fire", fireChose);
        PlayerPrefs.SetInt("BasicGreen", basicGreenChose);
        PlayerPrefs.SetInt("BasicGrey", basicGreyChose);
        PlayerPrefs.SetInt("BasicPurple", basicPurpleChose);
        PlayerPrefs.SetInt("BasicYellow", basicYellowChose);
        PlayerPrefs.SetInt("Wood", woodChose);
        PlayerPrefs.SetInt("Rock", rockChose);
        PlayerPrefs.SetInt("Purple", purpleChose);
        PlayerPrefs.SetInt("Blue", blueChose);
        PlayerPrefs.SetInt("SimonSays", simonSaysChose);
        PlayerPrefs.SetInt("Green", greenChose);
        PlayerPrefs.SetInt("Gold", goldChose);
        PlayerPrefs.SetInt("Smile", smileChose);
        PlayerPrefs.SetInt("Enemy", enemyChose);

        isFunBtnEquipped = false;
    }

    public void SetCheapGreen()
    {
        SetBackButtonSkins();

        selectedButton.transform.position = cheapGreenBTN.transform.position;
        selectedButton.transform.SetParent(cheapGreenBTN.transform);

        cheapGreenChose = 1;
        PlayerPrefs.SetInt("CheapGreen", cheapGreenChose);

        mainButton.sprite = cheapGreen;
        mainButtonExample.sprite = cheapGreen;
        smallButtonCharge.sprite = cheapGreen;
        controlsButtonExample.sprite = cheapGreen;
    }

    public void SetOnlyYellow()
    {
        SetBackButtonSkins();

        selectedButton.transform.position = onlyYellowBTN.transform.position;
        selectedButton.transform.SetParent(onlyYellowBTN.transform);

        onlyYellowChose = 1;
        PlayerPrefs.SetInt("OnlyYellow", onlyYellowChose);

        mainButton.sprite = onlyYellow;
        mainButtonExample.sprite = onlyYellow;
        smallButtonCharge.sprite = onlyYellow;
        controlsButtonExample.sprite = onlyYellow;
    }

    public void SetDisco()
    {
        SetBackButtonSkins();
        discoChose = 1;
        PlayerPrefs.SetInt("Disco", discoChose);

        selectedButton.transform.position = discoBTN.transform.position;
        selectedButton.transform.SetParent(discoBTN.transform);

        mainButton.sprite = disco;
        mainButtonExample.sprite = disco;
        smallButtonCharge.sprite = disco;
        controlsButtonExample.sprite = disco;
    }

    public void SetLightning()
    {
        SetBackButtonSkins();
        lightningChose = 1;
        PlayerPrefs.SetInt("Lightning", lightningChose);

        selectedButton.transform.position = lightningBTN.transform.position;
        selectedButton.transform.SetParent(lightningBTN.transform);

        mainButton.sprite = lightning;
        mainButtonExample.sprite = lightning;
        smallButtonCharge.sprite = lightning;
        controlsButtonExample.sprite = lightning;
    }

    public void SetFire()
    {
        SetBackButtonSkins();
        fireChose = 1;
        PlayerPrefs.SetInt("Fire", fireChose);

        selectedButton.transform.position = fireBTN.transform.position;
        selectedButton.transform.SetParent(fireBTN.transform);

        mainButton.sprite = fire;
        mainButtonExample.sprite = fire;
        smallButtonCharge.sprite = fire;
        controlsButtonExample.sprite = fire;
    }
    public void SetBasicGreen()
    {
        SetBackButtonSkins();
        basicGreenChose = 1;
        PlayerPrefs.SetInt("BasicGreen", basicGreenChose);

        selectedButton.transform.position = basicGreenBTN.transform.position;
        selectedButton.transform.SetParent(basicGreenBTN.transform);

        mainButton.sprite = basicGreen;
        mainButtonExample.sprite = basicGreen;
        smallButtonCharge.sprite = basicGreen;
        controlsButtonExample.sprite = basicGreen;
    }
    public void SetBasicGrey()
    {
        SetBackButtonSkins();
        basicGreyChose = 1;
        PlayerPrefs.SetInt("BasicGrey", basicGreyChose);

        selectedButton.transform.position = basicGreyBTN.transform.position;
        selectedButton.transform.SetParent(basicGreyBTN.transform);

        mainButton.sprite = basicGrey;
        mainButtonExample.sprite = basicGrey;
        smallButtonCharge.sprite = basicGrey;
        controlsButtonExample.sprite = basicGrey;
    }
    public void SetBasicPurple()
    {
        SetBackButtonSkins();
        basicPurpleChose = 1;
        PlayerPrefs.SetInt("BasicPurple", basicPurpleChose);

        selectedButton.transform.position = basicPurpleBTN.transform.position;
        selectedButton.transform.SetParent(basicPurpleBTN.transform);

        mainButton.sprite = basicPurple;
        mainButtonExample.sprite = basicPurple;
        smallButtonCharge.sprite = basicPurple;
        controlsButtonExample.sprite = basicPurple;
    }
    public void SetBasicYellow()
    {
        SetBackButtonSkins();
        basicYellowChose = 1;
        PlayerPrefs.SetInt("BasicYellow", basicYellowChose);

        selectedButton.transform.position = basicYellowBTN.transform.position;
        selectedButton.transform.SetParent(basicYellowBTN.transform);

        mainButton.sprite = basicYellow;
        mainButtonExample.sprite = basicYellow;
        smallButtonCharge.sprite = basicYellow;
        controlsButtonExample.sprite = basicYellow;
    }
    public void SetWood()
    {
        SetBackButtonSkins();
        woodChose = 1;
        PlayerPrefs.SetInt("Wood", woodChose);

        selectedButton.transform.position = woodBTN.transform.position;
        selectedButton.transform.SetParent(woodBTN.transform);

        mainButton.sprite = wood;
        mainButtonExample.sprite = wood;
        smallButtonCharge.sprite = wood;
        controlsButtonExample.sprite = wood;
    }
    public void SetRock()
    {
        SetBackButtonSkins();
        rockChose = 1;
        PlayerPrefs.SetInt("Rock", rockChose);

        selectedButton.transform.position = rockBTN.transform.position;
        selectedButton.transform.SetParent(rockBTN.transform);

        mainButton.sprite = rock;
        mainButtonExample.sprite = rock;
        smallButtonCharge.sprite = rock;
        controlsButtonExample.sprite = rock;
    }
    public void SetPurple()
    {
        SetBackButtonSkins();
        purpleChose = 1;
        PlayerPrefs.SetInt("Purple", purpleChose);

        selectedButton.transform.position = purpleBTN.transform.position;
        selectedButton.transform.SetParent(purpleBTN.transform);

        mainButton.sprite = purple;
        mainButtonExample.sprite = purple;
        smallButtonCharge.sprite = purple;
        controlsButtonExample.sprite = purple;
    }
    public void SetBlue()
    {
        SetBackButtonSkins();
        blueChose = 1;
        PlayerPrefs.SetInt("Blue", blueChose);

        selectedButton.transform.position = blueBTN.transform.position;
        selectedButton.transform.SetParent(blueBTN.transform);

        mainButton.sprite = blue;
        mainButtonExample.sprite = blue;
        smallButtonCharge.sprite = blue;
        controlsButtonExample.sprite = blue;
    }
    public void SetSimonsSays()
    {
        SetBackButtonSkins();
        simonSaysChose = 1;
        PlayerPrefs.SetInt("SimonSays", simonSaysChose);

        selectedButton.transform.position = simonSaysBTN.transform.position;
        selectedButton.transform.SetParent(simonSaysBTN.transform);

        mainButton.sprite = simonSays;
        mainButtonExample.sprite = simonSays;
        smallButtonCharge.sprite = simonSays;
        controlsButtonExample.sprite = simonSays;
    }
    public void SetGreen()
    {
        SetBackButtonSkins();
        greenChose = 1;
        PlayerPrefs.SetInt("Green", greenChose);

        selectedButton.transform.position = greenBTN.transform.position;
        selectedButton.transform.SetParent(greenBTN.transform);

        mainButton.sprite = green;
        mainButtonExample.sprite = green;
        smallButtonCharge.sprite = green;
        controlsButtonExample.sprite = green;
    }
    public void SetGold()
    {
        SetBackButtonSkins();
        goldChose = 1;
        PlayerPrefs.SetInt("Gold", goldChose);

        selectedButton.transform.position = goldBTN.transform.position;
        selectedButton.transform.SetParent(goldBTN.transform);

        mainButton.sprite = gold;
        mainButtonExample.sprite = gold;
        smallButtonCharge.sprite = gold;
        controlsButtonExample.sprite = gold;
    }
    public void SetSmile()
    {
        SetBackButtonSkins();

        isFunBtnEquipped = true;

        smileChose = 1;
        PlayerPrefs.SetInt("Smile", smileChose);

        selectedButton.transform.position = smileBTN.transform.position;
        selectedButton.transform.SetParent(smileBTN.transform);

        mainButton.sprite = smile;
        mainButtonExample.sprite = smile;
        smallButtonCharge.sprite = smile;
        controlsButtonExample.sprite = smile;
    }

    public void SetEnemy()
    {
        SetBackButtonSkins();
        enemyChose = 1;
        PlayerPrefs.SetInt("Enemy", enemyChose);

        selectedButton.transform.position = enemyBTN.transform.position;
        selectedButton.transform.SetParent(enemyBTN.transform);

        mainButton.sprite = enemy;
        mainButtonExample.sprite = enemy;
        smallButtonCharge.sprite = enemy;
        controlsButtonExample.sprite = enemy;
    }
    #endregion

    /*
    #region enemy testing buttons
    public void SmallEnemyPluss()
    {
        SpawnEnemies.smallEnemyMaxCount += 2;
        if(SpawnEnemies.smallEnemySpawnTimer > 0.06f)
        {
            SpawnEnemies.smallEnemySpawnTimer -= 0.15f;
        }
        if(SpawnEnemies.smallEnemySpawnTimer <= 0)
        {
            SpawnEnemies.smallEnemySpawnTimer = 0.05f;
        }
    }
    public void SpeedsterPluss()
    {
        SpawnEnemies.speedsterMaxCount += 2;
        if (SpawnEnemies.speedsterSpawnTimer > 0.3f)
        {
            SpawnEnemies.speedsterSpawnTimer -= 0.06f;
        }
        if (SpawnEnemies.speedsterSpawnTimer <= 0)
        {
            SpawnEnemies.speedsterSpawnTimer = 0.05f;
        }
    }

    public void SharpShooterPluss()
    {
        SpawnShootingEnemy.shootingEnemyMaxCount += 1;
        if (SpawnShootingEnemy.sharpshooterSpawnTimer > 0.5f)
        {
            SpawnShootingEnemy.sharpshooterSpawnTimer -= 0.3f;
        }
    }

    public void SniperPluss()
    {
        SpawnShootingEnemy.sniperMaxCount += 1;
        if (SpawnShootingEnemy.sniperSpawnTimer > 0.5f)
        {
            SpawnShootingEnemy.sniperSpawnTimer -= 0.3f;
        }
    }

    public void BigEnemyPluss()
    {
        SpawnBigEnemy.bigEnemyMaxCount += 1;
        if (SpawnBigEnemy.bigEnemySpawnTimer > 0.5f)
        {
            SpawnBigEnemy.bigEnemySpawnTimer -= 0.3f;
        }
    }

    public void MaxHealth()
    {
        Choises.buttonHealth = Choises.maxButtonHealth;
    }
    #endregion
  */
}
