using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverExlemationMArks : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cheapGreenEXL, onlyYellowEXL, discoEXL, lightningEXL, fireEXL, basicGreenEXL, basicPurpleEXL, basicYellowEXL, woodEXL, rockEXL, purpleEXL, blueEXL, simonSaysEXL, smileEXL, enemyEXL, logoEXL;

    public GameObject redStripedEXL, greedFadeEXL, purpleFadeEXL, hexagonEXL, greyWaveEXL, greenVeritcalEXL, pinkFadeEXL, redTileEXL;


    public void OnPointerEnter(PointerEventData eventData)
    {
        string objectName = eventData.pointerEnter.name;

        if (objectName == "button_greenBasic")
        {
            basicGreenEXL.SetActive(false);
        }

        if (objectName == "button_purpleBasic")
        {
            basicPurpleEXL.SetActive(false);
        }

        if (objectName == "button_yellowBasic")
        {
            basicYellowEXL.SetActive(false);
        }

        if (objectName == "Button_greenCheap")
        {
            cheapGreenEXL.SetActive(false);
        }

        if (objectName == "Button_PureYellow")
        {
            onlyYellowEXL.SetActive(false);
        }
        if (objectName == "Button_Disco")
        {
            discoEXL.SetActive(false);
        }

        if (objectName == "Button_Lightning")
        {
            lightningEXL.SetActive(false);
        }

        if (objectName == "Button_Fire")
        {
            fireEXL.SetActive(false);
        }

        if (objectName == "Button_wood")
        {
            woodEXL.SetActive(false);
        }

        if (objectName == "Button_rock")
        {
            rockEXL.SetActive(false);
        }

        if (objectName == "Button_Purple")
        {
            purpleEXL.SetActive(false);
        }

        if (objectName == "Button_blue")
        {
            blueEXL.SetActive(false);
        }

        if (objectName == "button_SimonSays")
        {
            simonSaysEXL.SetActive(false);
        }

        if (objectName == "Button_logo")
        {
            logoEXL.SetActive(false);
        }

        if (objectName == "Button_Smile")
        {
            smileEXL.SetActive(false);
        }

        if (objectName == "Button_EnemyBtn")
        {
            enemyEXL.SetActive(false);
        }


        if (objectName == "Backroung_GreenFade")
        {
            greedFadeEXL.SetActive(false);
        }

        if (objectName == "PinkAndStriped")
        {
            redStripedEXL.SetActive(false);
        }

        if (objectName == "BAckground_BlackWave")
        {
            greyWaveEXL.SetActive(false);
        }

        if (objectName == "background_pinkFade")
        {
            pinkFadeEXL.SetActive(false);
        }

        if (objectName == "Background_PurpleFade")
        {
            purpleFadeEXL.SetActive(false);
        }

        if (objectName == "Background_RedTiles")
        {
            redTileEXL.SetActive(false);
        }

        if (objectName == "Background_GreenThick")
        {
            greenVeritcalEXL.SetActive(false);
        }

        if (objectName == "Background_Hexagon")
        {
            hexagonEXL.SetActive(false);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
