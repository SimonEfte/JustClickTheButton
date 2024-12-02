using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class smallShields : MonoBehaviour
{
    public float shieldHP;
    public float shieldRecharge;
    public GameObject healthbar;
    public GameObject whiteFlash;
    public Slider slider;
    public Collider2D colliderObject;
    public Coroutine shieldRechargeCoroutine;
    public Image imageComponent;

    public void Awake()
    {
        colliderObject = GetComponent<Collider2D>();
        imageComponent = gameObject.GetComponent<Image>();
    }

    public void OnEnable()
    {
        if (shieldRechargeCoroutine != null) { StopCoroutine(shieldRechargeCoroutine); shieldRechargeCoroutine = null; }
        if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); whiteFlashCoroutine = null; }
        colliderObject.enabled = true;
        SetAlpha(imageComponent, 1f);

        whiteFlash.SetActive(false);
        healthbar.SetActive(false);
        shieldRecharge = Choises.smallShieldRechargeTimer;
        shieldHP = Choises.smallShieldHP;

        slider.maxValue = shieldHP;
        slider.value = shieldHP;
    }

    public Coroutine whiteFlashCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            HitShield();
        }

        if (collision.gameObject.name == "EnemySawBlade(Clone)")
        {
            HitShield();
        }

        if (collision.gameObject.name == "EnemyArrow(Clone)")
        {
            HitShield();
        }
    }

    public void HitShield()
    {
        healthbar.SetActive(true);
        if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashHealthbar()); }

        shieldHP -= 1;
        slider.value = shieldHP;

        if (shieldHP <= 0)
        {
            SetAlpha(imageComponent, 0f);
            colliderObject.enabled = false;
            if(gameObject.activeInHierarchy == true && shieldRechargeCoroutine == null)
            {
                shieldRechargeCoroutine = StartCoroutine(ReChargeShield(Choises.smallShieldRechargeTimer));
            }
        }
    }
    

    public float reChargeTimer;
    public float shieldRechargeAmount;

    private IEnumerator ReChargeShield(float duration)
    {
        reChargeTimer = Choises.smallShieldRechargeTimer;

        while (reChargeTimer > 0f)
        {
            shieldRechargeAmount += 10 / Choises.smallShieldRechargeTimer;
            yield return new WaitForSeconds(0.1f);
            reChargeTimer -= 0.1f;
        }

        SetAlpha(imageComponent, 1f);
        shieldRechargeAmount = 0;
        colliderObject.enabled = true;

        shieldHP = Choises.smallShieldHP;
        slider.maxValue = shieldHP;
        slider.value = shieldHP;
        shieldRechargeCoroutine = null;
    }


    IEnumerator whiteFlashHealthbar()
    {
        whiteFlash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        whiteFlash.SetActive(false);
        whiteFlashCoroutine = null;
    }

    private System.Collections.IEnumerator FadeAlpha(Graphic graphic, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color startColor = graphic.color;

        while (elapsedTime < 0.10f)
        {
            float newAlpha = Mathf.Lerp(startColor.a, targetAlpha, elapsedTime / 0.10f);
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

    private void SetAlpha(Graphic graphic, float targetAlpha)
    {
        StartCoroutine(FadeAlpha(graphic, targetAlpha));
    }
}
