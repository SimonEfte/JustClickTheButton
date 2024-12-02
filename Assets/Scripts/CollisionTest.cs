using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class CollisionTest : MonoBehaviour
{

    public GameObject normalBackgound, otherBackground, threeUpgrades1, threeupgrades2;

    public void SetNormalBackroung()
    {
        normalBackgound.SetActive(true);
        otherBackground.SetActive(false);
    }

    public void SetOtherBackground()
    {
        normalBackgound.SetActive(false);
        otherBackground.SetActive(true);
    }

    public void set3Upgrades()
    {
        threeUpgrades1.SetActive(true);
        threeupgrades2.SetActive(false);
    }

    public void set3OtherUpgrades()
    {
        threeUpgrades1.SetActive(false);
        threeupgrades2.SetActive(true);
    }



   
}
