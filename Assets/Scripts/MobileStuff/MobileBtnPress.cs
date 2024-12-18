using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MobileBtnPress : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float originalScale, scaleDownFactor;

    public static bool holdingDown, isBtnChargeHoldDown;

    bool isMobileClick, isCharge, isInvinClick;

    public ButtonBehiavor clickSoundScript;

    private void Awake()
    {
        if(gameObject.name == "MobileClickButton")
        {
            isMobileClick = true;
        }

        if (gameObject.name == "MobileChargeBulletBtn")
        {
            isCharge = true;
        }

        if (gameObject.name == "MobileStopwatchBTN" || gameObject.name == "MobileCameraSwitch")
        {
            isInvinClick = true;
        }
       
    }

    private void Start()
    {
        originalScale = gameObject.transform.localScale.x;
        scaleDownFactor = 0.95f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isMobileClick == true || isInvinClick == true)
        {
            if (Choises.isInLevelUpScreen == true || Choises.isInChooseEndingScreen == true)
            {
                return;
            }
        }

        if (isMobileClick == true) 
        {
            holdingDown = true;
            clickSoundScript.ButtonClickInNoises();
        }

        if (isCharge == true)
        {
            isBtnChargeHoldDown = true;
        }

        isPressed = true;
        MainButtonCollider.isChargePressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMobileClick == true)
        {
            clickSoundScript.ButtonClickOutNoises();
            holdingDown = false;
        }
        if (isCharge == true)
        {
            isBtnChargeHoldDown = false;
        }

        isPressed = false;
        MainButtonCollider.isChargePressed = false;
    }

    bool isPressed;
    private void Update()
    {
        if (isPressed == true)
        {
            gameObject.transform.localScale = new Vector3(originalScale * scaleDownFactor, originalScale * scaleDownFactor, 1f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(originalScale, originalScale, 1f);
        }
    }
}
