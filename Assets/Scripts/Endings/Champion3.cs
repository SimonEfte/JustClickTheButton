using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Champion3 : MonoBehaviour
{
    public static float champion3HP;

    public Slider healthSlider;
    public static Vector2 champion3DamagedPos, champion3ArrowDamagesPos;
    public static bool champion3Damaged, champion3ArrowDamaged;
    public GameObject whiteFlash;
    public GameObject shield;

    public static float champion3SawBladeDamage;
    public int arrowStuck;
    public AudioManager audioManager;
    public void OnEnable()
    {
        healthSlider.gameObject.SetActive(false);
        whiteFlash.gameObject.SetActive(false);

        arrowStuck = 0;
        died = false;
        isChampionDead = false;
        dealingSpikeDamage = false;
        //champion3SawBladeDamage = 20;
        //champion3HP = 17500;

        healthSlider.maxValue = champion3HP;
        healthSlider.value = champion3HP;
        healthSlider.minValue = 0;
        shield.SetActive(true);
    }

    public float tickRate = 0.01f;
    private float timeSinceLastTick = 0.01f;
    public bool died;

    public void Update()
    {
        if (Choises.didPlayerDie == true && died == false)
        {
            died = true;
            if (isChampionDead == false)
            {
                StopAllCoroutines();
            }
        }



        if (MimicEnding.championsKilled == 2)
        {
            shield.SetActive(false);
        }

        #region spike damage
        if (dealingSpikeDamage == true)
        {
            timeSinceLastTick += Time.deltaTime;

            while (timeSinceLastTick >= tickRate)
            {
                champion3HP -= Choises.spikeDamagePerSecond * tickRate;
                healthSlider.GetComponent<Slider>().value = champion3HP;
                timeSinceLastTick -= tickRate;

                if (champion3HP <= 0)
                {
                    Champion1Death();
                }
            }
        }
        #endregion

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (MimicEnding.championsKilled == 2)
        {
            //Debug.Log("2 Killed");
            #region UZI Damage
            if (collision.gameObject.name == "smallBullet(Clone)")
            {
                DamageEnemy(collision.transform.localPosition, Choises.smallBulletDamage);
            }
            #endregion

            #region Pistol Damage
            if (collision.gameObject.name == "bulletFromGun_1(Clone)")
            {
                DamageEnemy(collision.transform.localPosition, Choises.bulletGun1_Damage);
            }
            #endregion

            #region Homing damage
            if (collision.gameObject.tag == "HomingBullet")
            {
                DamageEnemy(collision.transform.localPosition, Choises.homingBulletDamage);
            }
            #endregion

            #region Bullet hit - damage enemy
            if (collision.gameObject.tag == "BulletBounced")
            {
                DamageEnemy(collision.transform.localPosition, Choises.bulletGun1_Damage);
            }
            #endregion

            #region Shotgun
            if (collision.gameObject.name == "ShotgunBullet(Clone)")
            {
                DamageEnemy(collision.transform.localPosition, Random.Range(Choises.shotGunBulletDamage, Choises.shotGunBulletDamage2));
            }
            #endregion

            #region Mp4
            if (collision.gameObject.tag == "Gun3Bullet")
            {
                DamageEnemy(collision.transform.localPosition, Choises.mp4Damage);
            }
            #endregion

            #region spikes
            if (collision.gameObject.tag == "Button")
            {
                if (Choises.chooseSpikes == true)
                {
                    dealingSpikeDamage = true;
                }
            }
            #endregion
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (MimicEnding.championsKilled == 2)
        {
            #region Sword
            if (collision.gameObject.tag == "SpinningSword")
            {
                if (Choises.chooseBigSpike == true)
                {
                    healthSlider.gameObject.SetActive(true);
                    champion3DamagedPos = gameObject.transform.localPosition;
                    champion3HP -= Choises.bigSpikeDamage;
                    healthSlider.GetComponent<Slider>().value = champion3HP;

                    ButtonBehiavor.damageDone = Choises.bigSpikeDamage;
                    champion3Damaged = true;

                    if (champion3HP <= 0)
                    {
                        Champion1Death();
                    }

                    if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
                }
            }
            #endregion

            #region stabbing spikes
            if (collision.gameObject.tag == "StabbingSpike")
            {
                if (Choises.chooseStabbingSpikes == true)
                {
                    healthSlider.gameObject.SetActive(true);
                    champion3DamagedPos = gameObject.transform.localPosition;
                    champion3HP -= Choises.stabbingSpikeDamage;
                    healthSlider.GetComponent<Slider>().value = champion3HP;

                    ButtonBehiavor.damageDone = Choises.stabbingSpikeDamage;
                    champion3Damaged = true;

                    if (champion3HP <= 0)
                    {
                        Champion1Death();
                    }

                    if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
                }
            }
            #endregion

            #region SawBlade
            if (collision.gameObject.tag == "SawBlade")
            {
                healthSlider.gameObject.SetActive(true);
                champion3DamagedPos = gameObject.transform.localPosition;
                champion3HP -= Choises.sawBladeDamage;
                healthSlider.GetComponent<Slider>().value = champion3HP;

                ButtonBehiavor.damageDone = Choises.sawBladeDamage;
                champion3Damaged = true;

                if (champion3HP <= 0)
                {
                    Champion1Death();
                }

                if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
            }
            #endregion

            #region Hammer
            if (collision.gameObject.tag == "Hammer")
            {
                healthSlider.gameObject.SetActive(true);
                champion3DamagedPos = gameObject.transform.localPosition;
                champion3HP -= Choises.hammerDamage;
                ButtonBehiavor.damageDone = Choises.hammerDamage;
                healthSlider.GetComponent<Slider>().value = champion3HP;
                champion3Damaged = true;

                if (champion3HP <= 0)
                {
                    Champion1Death();
                }

                if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
            }
            #endregion

            #region Knife
            if (collision.gameObject.tag == "Knife")
            {
                healthSlider.gameObject.SetActive(true);
                champion3DamagedPos = gameObject.transform.localPosition;
                champion3Damaged = true;
                champion3HP -= Choises.knifeDamage;
                ButtonBehiavor.damageDone = Choises.knifeDamage;
                healthSlider.GetComponent<Slider>().value = champion3HP;

                if (champion3HP < 1)
                {
                    Champion1Death();
                }

                if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
            }
            #endregion

            #region Arrow
            if (collision.gameObject.tag == "Arrow")
            {
                arrowStuck += 1;
                DamageEnemyArrow(collision.transform.position, Choises.arrowDamage);
            }
            #endregion

            #region Crossbow arrow
            if (collision.gameObject.tag == "CrossbowArrow")
            {
                arrowStuck += 1;
                DamageEnemyArrow(collision.transform.position, Choises.crossbowDamage);
            }
            #endregion

            #region Charged bullet
            if (collision.gameObject.tag == "ChargedBullet")
            {
                DamageEnemy(collision.transform.localPosition, ChargedBullet.chargedChampion3Damage);
            }
            #endregion

            #region Big Piecring bullet
            if (collision.gameObject.name == "bigPiercingBulletCollider")
            {
                DamageEnemyArrow(collision.transform.position, Choises.bigBulletDamage);
            }
            #endregion

            #region TrippleBullet
            if (collision.gameObject.tag == "TrippleBullet")
            {
                DamageEnemy(collision.transform.localPosition, Choises.trippleShotDamage);
            }
            #endregion
        }
    }


    public bool dealingSpikeDamage;
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Button")
        {
            dealingSpikeDamage = false;
        }
    }


    #region Champion damagesd
    public void DamageEnemy(Vector2 damagePos, float damageAmount)
    {
        if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        champion3HP -= damageAmount;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = champion3HP;

        ButtonBehiavor.damageDone = damageAmount;
        champion3DamagedPos = damagePos;
        champion3Damaged = true;

        if (champion3HP < 1)
        {
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
            Champion1Death();
        }
    }

    public void DamageEnemyArrow(Vector2 damagePos, float damageAmount)
    {
        if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        champion3HP -= damageAmount;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = champion3HP;

        ButtonBehiavor.damageDone = damageAmount;
        champion3ArrowDamagesPos = damagePos;
        champion3ArrowDamaged = true;

        if (champion3HP < 1)
        {
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
            Champion1Death();
        }
    }
    #endregion

    #region WhiteFlash
    public Coroutine whiteFlashCoroutine;

    IEnumerator whiteFlashEffect()
    {
        whiteFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.11f);
        whiteFlash.gameObject.SetActive(false);

        whiteFlashCoroutine = null;
    }
    #endregion

    public ParticleEffectSystems particleScripts;
    public Vector2 enemyDiePos;
    public bool isChampionDead;

    public void Champion1Death()
    {
        if(isChampionDead == false)
        {
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); whiteFlashCoroutine = null; }

            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("championDeath1"); }
            if (random == 2) { audioManager.Play("championDeath2"); }

            MimicEnding.championsKilled += 1;
            MimicEnding.isChampionsDefeated = true;
            isChampionDead = true;

            Choises.maxArrowsStuck -= arrowStuck;

            #region Arrow back
            Transform[] arrowIcons = transform.GetComponentsInChildren<Transform>();

            if (arrowIcons.Length > 0)
            {
                GameObject originalParent = GameObject.Find("arrowPool");

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
                GameObject originalParent = GameObject.Find("arrowPool");

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

            enemyDiePos = gameObject.transform.position;
            particleScripts.DeathParticle(enemyDiePos, 3f);
            particleScripts.Champion3Pieces(enemyDiePos, 4f);
            MimicEnding.isPlayingChamptions = false;
            gameObject.SetActive(false);
        }
    }

}
