using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonBehiavor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool spaceBarPressed;

    public static float spinForce;
    public Slider slider;
    public float scaleDownFactor;
    public float originalScale;
    private bool isPressed = false;
    private float chargedAmount;
    private Coroutine chargeCoroutineVisual;
    public static float damageDone;
    public Rigidbody2D buttonRB;

    public GameObject buttonPressedObject;
    public AudioManager audioManager;

    private Rigidbody2D rb;
    public bool isButtonClicked;
    public void Start()
    {
        chargeCoroutineVisual = null;
        Choises.chargedBulletsCount = 15;
        Choises.maxButtonCharge = 35;
        Choises.buttonChargePerSecond = 1f;

        rb = GetComponent<Rigidbody2D>();
        bulletSpeed = 50f;
        scaleDownFactor = 0.96f;
        originalScale = 1.03f;
    }

    public void ButtonClickInNoises()
    {
        if(SettingsOptions.isInFirstPlayScreen == false)
        {
            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("ButtonClickIn1"); }
            if (random == 2) { audioManager.Play("ButtonClickIn2"); }
        }
      
    }
    public void ButtonClickOutNoises()
    {
        if (SettingsOptions.isInFirstPlayScreen == false)
        {
            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("ButtonClickOut1"); }
            if (random == 2) { audioManager.Play("ButtonClickOut2"); }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false)
        {
            ButtonClickInNoises();
        }
        isPressed = true;
        MainButtonCollider.isChargePressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false)
        {
            ButtonClickOutNoises();
        }
        
        isPressed = false;
        MainButtonCollider.isChargePressed = false;
    }

    void Update()
    {
        if(Choises.isInDeathScreen == false)
        {
            #region Spacebar selected
            if (SettingsOptions.leftClickSeleced == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false && Choises.isInChooseEndingScreen == false && Choises.isInEggScreen == false && Choises.isInLevelUpScreen == false && Choises.isInMainManu == false)
                    {
                        ButtonClickInNoises();
                    }
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if (SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false && Choises.isInChooseEndingScreen == false && Choises.isInEggScreen == false && Choises.isInLevelUpScreen == false && Choises.isInMainManu == false)
                    {
                        ButtonClickOutNoises();
                    }
                }

                isPressed = false;

                if (Input.GetKey(KeyCode.Space)) { spaceBarPressed = true;  }

                if (!Input.GetKey(KeyCode.Space)) { spaceBarPressed = false; }
            }
            #endregion

            #region Left click selected
            if (SettingsOptions.leftClickSeleced == true)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false && Choises.isInChooseEndingScreen == false && Choises.isInEggScreen == false && Choises.isInLevelUpScreen == false && Choises.isInMainManu == false)
                    {
                        ButtonClickInNoises();
                    }
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    if (SettingsOptions.isInSettings == false && Choises.isInWinScreen == false && Choises.isInDeathScreen == false && Choises.isInChooseEndingScreen == false && Choises.isInEggScreen == false && Choises.isInLevelUpScreen == false && Choises.isInMainManu == false)
                    {
                        ButtonClickOutNoises();
                    }
                }

                spaceBarPressed = false;

                if (Input.GetKey(KeyCode.Mouse0)) { isPressed = true; }

                if (!Input.GetKey(KeyCode.Mouse0)) { isPressed = false; }
            }
            #endregion

            if (Mathf.Approximately(buttonRB.velocity.magnitude, 0f))
            {
                ButtonClick.buttonMovingDamageBonus = 0;
            }
            else
            {
                ButtonClick.buttonMovingDamageBonus = buttonRB.velocity.magnitude;
                //Debug.Log(ButtonClick.buttonMovingDamageBonus);
            }


            if (Choises.isPaused == false && Choises.isInMainManu == false)
            {
                if (isPressed == true || spaceBarPressed == true)
                {
                    // Scale down the button
                    buttonPressedObject.transform.localScale = new Vector3(originalScale * scaleDownFactor, originalScale * scaleDownFactor, 1f);

                    if(SettingsOptions.isInSettings == false && Choises.isInMainManu == false)
                    {
                        if (Choises.choseButtonCharge == true)
                        {
                            if (chargeCoroutineVisual == null)
                            {
                                chargeCoroutineVisual = StartCoroutine(ChargeButtonVisual());
                            }

                            if (chargedAmount >= Choises.maxButtonCharge)
                            {
                                //Do nothing. Max Charge
                            }
                        }
                    }
                }
                else
                {
                    buttonPressedObject.transform.localScale = new Vector3(originalScale, originalScale, 1f);

                    if (Choises.choseButtonCharge == true && setChargeBackOnce == true)
                    {
                        // Return the button to its original scale
                        if (chargedAmount >= 6) { ShootChargedBullets(); }
                        chargedAmount = 0;
                        charge = 0;
                        chargedButtonScale = 0;
                        StartCoroutine(SetChargeDamageZero());
                        chargeObject.transform.localScale = new Vector3(0, 0, 0);

                        // Stop the coroutine if it's running
                        if (chargeCoroutineVisual != null)
                        {
                            StopCoroutine(chargeCoroutineVisual);
                            chargeCoroutineVisual = null;
                        }
                        setChargeBackOnce = false;
                    }
                }
            }
        }
    }

    public bool setChargeBackOnce;

    #region Charge Bullets
    public static float chargedBulletDamage;

    IEnumerator SetChargeDamageZero()
    {
        yield return new WaitForSeconds(0.025f);
        chargedBulletDamage = 0;
    }

    public GameObject chargeObject;
    public float charge = 0f;
    public static bool chargeSoundPlaying;

    private IEnumerator ChargeButtonVisual()
    {
        float maxScale = 0.8f;
        float startTime = Time.time;

        while (charge < Choises.chargedBulletChargeTime)
        {
            float elapsed = Time.time - startTime;

            if (elapsed >= Choises.chargedBulletChargeTime / 100) 
            {
                charge += elapsed;
                float scaleRatio = charge / Choises.chargedBulletChargeTime;
                float scaledValue = maxScale * scaleRatio;
                chargeObject.transform.localScale = new Vector3(scaledValue, scaledValue, scaledValue);

                chargedBulletDamage += (Choises.chargedBulletMaxDamage / 100);
                if(chargedBulletDamage > (Choises.chargedBulletMaxDamage - 1)) { chargedBulletDamage = Choises.chargedBulletMaxDamage; }

               
                chargedButtonScale += 0.045f;
                chargedAmount += Choises.buttonChargePerSecond;
                


                if (Choises.chargedBulletChargeTime < 2)
                {
                    if (chargedAmount >= 9)
                    {
                        if (chargeSoundPlaying == false)
                        {
                            audioManager.Play("charge1");
                            chargeSoundPlaying = true;
                        }
                    }
                }
                else if (Choises.chargedBulletChargeTime < 3)
                {
                    if (chargedAmount >= 8)
                    {
                        if (chargeSoundPlaying == false)
                        {
                            audioManager.Play("charge1");
                            chargeSoundPlaying = true;
                        }
                    }
                }
                else if(Choises.chargedBulletChargeTime < 4)
                {
                    if (chargedAmount >= 7)
                    {
                        if (chargeSoundPlaying == false)
                        {
                            audioManager.Play("charge1");
                            chargeSoundPlaying = true;
                        }
                    }
                }
                else if(Choises.chargedBulletChargeTime < 6)
                {
                    if (chargedAmount >= 6)
                    {
                        if (chargeSoundPlaying == false)
                        {
                            audioManager.Play("charge1");
                            chargeSoundPlaying = true;
                        }
                    }
                }

                if (Choises.chargedBulletChargeTime < 6)
                {
                    if (charge >= Choises.chargedBulletChargeTime)
                    {
                        if (chargeSoundPlaying == true)
                        {
                            chargedBulletDamage = Choises.chargedBulletMaxDamage;
                            chargeSoundPlaying = false;
                            audioManager.Stop("charge1");
                        }
                    }
                }

                setChargeBackOnce = true;

                startTime = Time.time; 
            }
          

            yield return null; 
        }
    }
    #endregion

    #region Shoot Charged Bullets
    public void ShootChargedBullets()
    {
        if(chargeSoundPlaying == true)
        {
            chargeSoundPlaying = false;
            audioManager.Stop("charge1");
        }
        audioManager.Play("chargeRelease");
        StartCoroutine(ChargedBullets());
    }

    public float chargedButtonScale;
    public GameObject buttonObject;
    public static float bulletSpeed;


    IEnumerator ChargedBullets()
    {
        int numberOfBullets = Choises.chargedBulletsCount;
        float angleIncrement = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject chargedBullet = ObjectPool.instance.GetChargedBulletFromPool();
            chargedBullet.transform.position = buttonObject.transform.position;
            chargedBullet.transform.localScale = new Vector3(0.2f + chargedButtonScale, 0.2f + chargedButtonScale, 0.2f + chargedButtonScale);

            float angle = i * angleIncrement;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up; // Convert angle to direction

            Rigidbody2D rb = chargedBullet.GetComponent<Rigidbody2D>();
            rb.velocity = direction * bulletSpeed;
        }

        yield return new WaitForSeconds(0); // Adjust delay between each bullet

        chargedButtonScale = 0;
    }
    #endregion

    public void ResetCharge()
    {
        if(chargeCoroutineVisual != null)
        {
            StopCoroutine(chargeCoroutineVisual);
            chargeCoroutineVisual = null;
        }

        chargedAmount = 0;
        charge = 0;
        chargedButtonScale = 0;
        chargedBulletDamage = 0;
        chargeObject.transform.localScale = new Vector3(0, 0, 0);
        setChargeBackOnce = false;

        if (chargeSoundPlaying == true)
        {
            audioManager.Stop("charge1");
            chargeSoundPlaying = false;
        }
    }
}
