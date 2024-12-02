using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Champion1Movement : MonoBehaviour
{
    public GameObject spikeOut1, spikeOut2, spikeOut3, spikeOut4, spikeOut5, spikeOut6, spikeOut7, spikeOut8;
    public Coroutine stabbingSpikesCoroutine, movingTowardsButton;
    public static bool isChampion1Alive;
    public Transform mainButton;
    private bool isAttacking;

    public static float champion1HP;
    public Slider healthSlider;
    public static Vector2 champion1DamagedPos, champion1ArrowDamagesPos;
    public static bool champion1Damaged, champion1ArrowDamaged;
    public GameObject whiteFlash;

    public static float champion1SpikeDamage;
    public static bool hitChampion1Stab;

    public static Vector2 enemyDiePos;

    public int arrowStuck;

    public float moveSpeed;
    public AudioManager audioManager;

    private void OnEnable()
    {
        moveSpeed = 13f;
        arrowStuck = 0;
        died = false;
        dealingSpikeDamage = false;
        //champion1SpikeDamage = 30;

        whiteFlash.SetActive(false);
        healthSlider.gameObject.SetActive(false);

        //champion1HP = 15000;
        healthSlider.maxValue = champion1HP;
        healthSlider.value = champion1HP;
        healthSlider.minValue = 0;

        championDead = false;
        isAttacking = false;
        isChampion1Alive = true;
        stabbingSpikesCoroutine =  StartCoroutine(Stab());
    }

    public float tickRate = 0.01f;
    private float timeSinceLastTick = 0.01f;
    public bool died;

    private void Update()
    {
        #region spike damage
        if (dealingSpikeDamage == true)
        {
            timeSinceLastTick += Time.deltaTime;

            while (timeSinceLastTick >= tickRate)
            {
                if (healthSlider.gameObject.activeInHierarchy == false) { healthSlider.gameObject.SetActive(true); }
                champion1HP -= Choises.spikeDamagePerSecond * tickRate;
                healthSlider.GetComponent<Slider>().value = champion1HP;
                timeSinceLastTick -= tickRate;

                if (champion1HP <= 0)
                {
                    Champion1Death();
                }
            }
        }
        #endregion

        if (Choises.didPlayerDie == true && died == false)
        {
            died = true;

            if(championDead == false)
            {
                StopAllCoroutines();
            }
        }
    }

    IEnumerator Stab()
    {
        yield return new WaitForSeconds(2f);
        movingTowardsButton = StartCoroutine(MoveTowardsButton());

        while (isChampion1Alive == true)
        {
            yield return new WaitForSeconds(0.5f);
            spikeOut1.SetActive(true); spikeOut2.SetActive(true); spikeOut3.SetActive(true); spikeOut4.SetActive(true);
            spikeOut5.SetActive(true); spikeOut6.SetActive(true); spikeOut7.SetActive(true); spikeOut8.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            spikeOut1.SetActive(false); spikeOut2.SetActive(false); spikeOut3.SetActive(false); spikeOut4.SetActive(false);
            spikeOut5.SetActive(false); spikeOut6.SetActive(false); spikeOut7.SetActive(false); spikeOut8.SetActive(false);
        }
    }


    IEnumerator MoveTowardsButton()
    {
        if (isAttacking == false)
        {
            while (Vector3.Distance(transform.position, mainButton.position) > 0.75f)
            {
                if(MimicEnding.championsKilled == 1) { moveSpeed = 17f; }
                dealingSpikeDamage = false;
                Vector3 direction = (mainButton.position - transform.position).normalized;

                transform.position += direction * moveSpeed * Time.deltaTime;
                
                yield return null;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            if (isAttacking == false)
            {
                if(movingTowardsButton != null) { StopCoroutine(movingTowardsButton); movingTowardsButton = null; }
                isAttacking = true;
                //attackecOnce = true;
            }
        }

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

    public bool dealingSpikeDamage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
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

        #region Sword
        if (collision.gameObject.tag == "SpinningSword")
        {
            if (Choises.chooseBigSpike == true)
            {
                healthSlider.gameObject.SetActive(true);
                champion1DamagedPos = gameObject.transform.localPosition;
                champion1HP -= Choises.bigSpikeDamage;
                healthSlider.GetComponent<Slider>().value = champion1HP;

                ButtonBehiavor.damageDone = Choises.bigSpikeDamage;
                champion1Damaged = true;

                if (champion1HP <= 0)
                {
                    Champion1Death();
                }

                if (whiteFlashCoroutine == null && championDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
            }
        }
        #endregion

        #region stabbing spikes
        if (collision.gameObject.tag == "StabbingSpike")
        {
            if (Choises.chooseStabbingSpikes == true)
            {
                healthSlider.gameObject.SetActive(true);
                champion1DamagedPos = gameObject.transform.localPosition;
                champion1HP -= Choises.stabbingSpikeDamage;
                healthSlider.GetComponent<Slider>().value = champion1HP;

                ButtonBehiavor.damageDone = Choises.stabbingSpikeDamage;
                champion1Damaged = true;

                if (champion1HP <= 0)
                {
                    Champion1Death();
                }

                if (whiteFlashCoroutine == null && championDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
            }
        }
        #endregion

        #region SawBlade
        if (collision.gameObject.tag == "SawBlade")
        {
            healthSlider.gameObject.SetActive(true);
            champion1DamagedPos = gameObject.transform.localPosition;
            champion1HP -= Choises.sawBladeDamage;
            healthSlider.GetComponent<Slider>().value = champion1HP;

            ButtonBehiavor.damageDone = Choises.sawBladeDamage;
            champion1Damaged = true;

            if (champion1HP <= 0)
            {
                Champion1Death();
            }

            if (whiteFlashCoroutine == null && championDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        }
        #endregion

        #region Hammer
        if (collision.gameObject.tag == "Hammer")
        {
            healthSlider.gameObject.SetActive(true);
            champion1DamagedPos = gameObject.transform.localPosition;
            champion1HP -= Choises.hammerDamage;
            ButtonBehiavor.damageDone = Choises.hammerDamage;
            healthSlider.GetComponent<Slider>().value = champion1HP;
            champion1Damaged = true;

            if (champion1HP <= 0)
            {
                Champion1Death();
            }

            if (whiteFlashCoroutine == null && championDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        }
        #endregion

        #region Knife
        if (collision.gameObject.tag == "Knife")
        {
            healthSlider.gameObject.SetActive(true);
            champion1DamagedPos = gameObject.transform.localPosition;
            champion1Damaged = true;
            champion1HP -= Choises.knifeDamage;
            ButtonBehiavor.damageDone = Choises.knifeDamage;
            healthSlider.GetComponent<Slider>().value = champion1HP;

            if (champion1HP < 1)
            {
                Champion1Death();
            }


            if (whiteFlashCoroutine == null && championDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        }
        #endregion

        #region Charged bullet
        if (collision.gameObject.tag == "ChargedBullet")
        {
            DamageEnemy(collision.transform.localPosition, ChargedBullet.chargedChampion1Damage);
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

    public bool isStunned;
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Button")
        {
            if (champion1HP > 0 || died == false)
            {
                dealingSpikeDamage = false;
                isAttacking = false;
                if (champion1HP > 0 || championDead == false) 
                {
                    if(MimicEnding.isPlayingChamptions == true)
                    {
                        if (movingTowardsButton == null)
                        {
                            movingTowardsButton = StartCoroutine(MoveTowardsButton());
                        }
                    }
                   
                }
            }
        }
    }

    #region Champion damagesd
    public void DamageEnemy(Vector2 damagePos, float damageAmount)
    {
        if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        champion1HP -= damageAmount;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = champion1HP;

        ButtonBehiavor.damageDone = damageAmount;
        champion1DamagedPos = damagePos;
        champion1Damaged = true;

        if (champion1HP < 1)
        {
            if (movingTowardsButton != null) { StopCoroutine(movingTowardsButton); movingTowardsButton = null; }
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
            if (stabbingSpikesCoroutine != null) { StopCoroutine(stabbingSpikesCoroutine); }
            Champion1Death();
        }
    }

    public void DamageEnemyArrow(Vector2 damagePos, float damageAmount)
    {
        if(whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        champion1HP -= damageAmount;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = champion1HP;

        ButtonBehiavor.damageDone = damageAmount;
        champion1ArrowDamagesPos = damagePos;
        champion1ArrowDamaged = true;

        if(champion1HP < 1)
        {
            if (movingTowardsButton != null) { StopCoroutine(movingTowardsButton); movingTowardsButton = null; }
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
            if(stabbingSpikesCoroutine != null) { StopCoroutine(stabbingSpikesCoroutine); }
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
    public bool championDead;

    public void Champion1Death()
    {
        if(championDead == false)
        {
            int random = Random.Range(1,3);
            if(random == 1) { audioManager.Play("championDeath1"); }
            if (random == 2) { audioManager.Play("championDeath2"); }

            championDead = true;

            MimicEnding.championsKilled += 1;
            //Debug.Log(MimicEnding.championsKilled);

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
            particleScripts.DeathParticle(enemyDiePos, 2.5f);
            particleScripts.Champion1Pieces(enemyDiePos, 2.2f);
            gameObject.SetActive(false);
        }
    }
}
