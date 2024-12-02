using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallBossShields : MonoBehaviour
{
    public Transform healthBar;
    public float shieldMaxHP, shieldHP;
    public static Vector2 shieldDamagedPos;
    public static bool shieldDamaged, shieldArrowDamaged;
    public GameObject whiteFlash;

    public void OnEnable()
    {
        originalParentName = "arrowPool";
        originalParentName2 = "arrowPool";

        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        whiteFlash.SetActive(false);
        shieldMaxHP = 500;
        shieldHP = shieldMaxHP;

        healthBar = transform.Find("Slider10_BasicType_Red");
        if(healthBar == null)
        {
            Debug.Log("null");
        }
        healthBar.gameObject.GetComponent<Slider>().minValue = 0;
        healthBar.gameObject.GetComponent<Slider>().maxValue = shieldMaxHP;
        healthBar.gameObject.GetComponent<Slider>().value = shieldMaxHP;
    }

    #region COLLISION

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Pistol Damage
        if (collision.gameObject.tag == "bullets")
        {
            DamageShield(collision.transform.localPosition, Choises.bulletGun1_Damage);
        }
        #endregion

        #region Homing damage
        if (collision.gameObject.tag == "HomingBullet")
        {
            DamageShield(collision.transform.localPosition, Choises.homingBulletDamage);
        }
        #endregion

        #region Charged bullet
        if (collision.gameObject.tag == "ChargedBullet")
        {
            DamageShield(collision.transform.localPosition, ChargedBullet.chargedBossDamage);
        }
        #endregion

        #region Bullet hit - damage enemy
        if (collision.gameObject.tag == "BulletBounced")
        {
            DamageShield(collision.transform.localPosition, Choises.arrowDamage);
        }
        #endregion

        #region Big Piecring bullet
        if (collision.gameObject.name == "bigPiercingBullet(Clone)")
        {
            DamageShield(collision.transform.localPosition, Choises.bigBulletDamage);
        }
        #endregion

        #region Shotgun
        if (collision.gameObject.name == "ShotgunBullet(Clone)")
        {
            DamageShield(collision.transform.localPosition, Random.Range(Choises.shotGunBulletDamage, Choises.shotGunBulletDamage2));
        }
        #endregion

        #region Mp4
        if (collision.gameObject.tag == "Gun3Bullet")
        {
            DamageShield(collision.transform.localPosition, Choises.mp4Damage);
        }
        #endregion

        #region TrippleBullet
        if (collision.gameObject.tag == "TrippleBullet")
        {
            DamageShield(collision.transform.localPosition, Choises.trippleShotDamage);
        }
        #endregion

        #region Arrow
        if (collision.gameObject.tag == "Arrow")
        {
            DamageShieldArrow(collision.transform.position, Choises.arrowDamage);
        }
        #endregion

        #region Crossbow arrow
        if (collision.gameObject.tag == "CrossbowArrow")
        {
            DamageShieldArrow(collision.transform.position, Choises.crossbowDamage);
        }
        #endregion
    }
    #endregion

    private string originalParentName = "arrowPool";
    private string originalParentName2 = "arrowPool";

    #region Boss Damaged
    public void DamageShield(Vector2 damagePos, float damageAmount)
    {
        if(BossMechanics.bossDied == false)
        {
            if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashHealthbar()); }
        }
     

        healthBar.gameObject.SetActive(true);
        shieldHP -= damageAmount;
        healthBar.gameObject.GetComponent<Slider>().value = shieldHP;

        ButtonBehiavor.damageDone = damageAmount;
        shieldDamagedPos = damagePos;
        shieldDamaged = true;

        if (shieldHP <= 0)
        {
            ShieldDied();
        }
    }

    public void DamageShieldArrow(Vector2 damagePos, float damageAmount)
    {
        if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashHealthbar()); }

        healthBar.gameObject.SetActive(true);
        shieldHP -= damageAmount;
        healthBar.gameObject.GetComponent<Slider>().value = shieldHP;

        ButtonBehiavor.damageDone = damageAmount;
        shieldDamagedPos = damagePos;
        shieldArrowDamaged = true;

        if(shieldHP <= 0)
        {
            ShieldDied();
        }
    }
    #endregion

    public Coroutine whiteFlashCoroutine;
    IEnumerator whiteFlashHealthbar()
    {
        whiteFlash.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        whiteFlash.SetActive(false);
        whiteFlashCoroutine = null;
    }

    public void ShieldDied()
    {
        #region Arrow back
        Transform[] arrowIcons = transform.GetComponentsInChildren<Transform>();

        if (arrowIcons.Length > 0)
        {
            GameObject originalParent = GameObject.Find(originalParentName);

            foreach (Transform arrowIcon in arrowIcons)
            {
                if (arrowIcon.name == "Arrow(Clone)")
                {
                    arrowIcon.gameObject.SetActive(false);
                    arrowIcon.SetParent(originalParent.transform);
                }
            }
        }
        #endregion

        #region Crossbow Arrows Stuck
        Transform[] crossBowIcons = transform.GetComponentsInChildren<Transform>();

        if (crossBowIcons.Length > 0)
        {
            GameObject originalParent = GameObject.Find(originalParentName2);

            foreach (Transform crossBowIcon in crossBowIcons)
            {
                if (crossBowIcon.name == "CrossbowArrow(Clone)")
                {
                    crossBowIcon.gameObject.SetActive(false);
                    crossBowIcon.SetParent(originalParent.transform);
                }
            }
        }
        #endregion

        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
        healthBar.gameObject.SetActive(false);
        StartCoroutine(shiedRecharge());
        whiteFlash.SetActive(false);
    }


    IEnumerator shiedRecharge()
    {
        yield return new WaitForSeconds(22);
        gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        healthBar.gameObject.SetActive(true);
        gameObject.GetComponent<Collider2D>().enabled = true;
        shieldHP = shieldMaxHP;
        healthBar.gameObject.GetComponent<Slider>().maxValue = shieldMaxHP;
        healthBar.gameObject.GetComponent<Slider>().value = shieldMaxHP;
        gameObject.GetComponent<Animation>().Play("ShieldAnim");
      
    }
}
