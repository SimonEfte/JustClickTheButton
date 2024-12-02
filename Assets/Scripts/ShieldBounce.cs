using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldBounce : MonoBehaviour
{
    public float shield_health;
    public float shieldAlpha;

    public float reChargeTimer;
    public float shieldRechargeAmount;

    public Image image;
    public bool setInactive;

    public void Awake()
    {
        image = GetComponent<Image>();
    }

    public void DeathOrReset()
    {
        StopAllCoroutines();
    }


    public void Update()
    {
        if (Choises.playerDied == true && setInactive == true)
        {
            DeathOrReset();
            setInactive = false;
        }
    }

    private void OnEnable()
    {
        setInactive = true;
        shield_health = Choises.shieldBounce_health;
        reChargeTimer = Choises.reChargeTimer;

        shieldAlpha = 1;

        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "EnemySawBlade(Clone)")
        {
            HitShield();
        }

        if (collision.gameObject.name == "EnemyArrow(Clone)")
        {
            HitShield();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "BulletBounced")
        {
            HitShield();
        }
    }

    public void HitShield()
    {
        shield_health -= 1;

        var tempColor = image.color;
        shieldAlpha -= (1f / Choises.shieldBounce_health);
        tempColor.a = shieldAlpha;
        image.color = tempColor;

        if (shield_health <= 0) 
        {
            gameObject.GetComponent<Collider2D>().isTrigger = true; 
            StartCoroutine(ReChargeShield(Choises.reChargeTimer));
            shieldAlpha = 0f;
            tempColor.a = shieldAlpha;
            image.color = tempColor;
        }
    }

    private IEnumerator ReChargeShield(float duration)
    {
        reChargeTimer = Choises.reChargeTimer;

        while (reChargeTimer > 0f)
        {
            shieldRechargeAmount += 10 / Choises.reChargeTimer;
            yield return new WaitForSeconds(0.1f);
            reChargeTimer -= 0.1f;
        }

        gameObject.SetActive(false);
        gameObject.SetActive(true);
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        shieldRechargeAmount = 0;

        shield_health = Choises.shieldBounce_health;
        reChargeTimer = Choises.reChargeTimer;
    }
}
