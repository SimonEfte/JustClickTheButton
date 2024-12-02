using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Champion2Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Coroutine moveLeftCoroutine, moveRightCoroutine, moveDownCoroutine, moveUpCoroutine, shootArrowsCoroutine;
    public bool isMovingDownLeft, isMovingDownRight, isMovingDownUp, isMovingUpDown, isMovingUpRight, isMovingUpLeft;

    public float speed;
    public float distanceToMove;
    public Transform mainButton;
    public float crossbowSpeed;

    public static float champion2HP;
    public static float champion2ArrowDamage;

    public GameObject crossbow1, crossbow2, crossbow3, crossbow4;
    public Slider healthSlider;
    public static Vector2 champion2DamagedPos, champion2ArrowDamagesPos;
    public static bool champion2Damaged, champion2ArrowDamaged;
    public GameObject whiteFlash;
    public bool isChampionDead;

    public AudioManager audioManager;

    public int arrowStuck;

    public void OnEnable()
    {
        isDead = false;
        distanceToMove = 500f;

        arrowStuck = 0;
        arrowWaitTime = 0.65f;
        died = false;
        dealingSpikeDamage = false;
        isChampionDead = false;
        //champion2ArrowDamage = 15;
        whiteFlash.SetActive(false);

        healthSlider.gameObject.SetActive(false);
        //champion2HP = 12500;

        healthSlider.maxValue = champion2HP;
        healthSlider.value = champion2HP;
        healthSlider.minValue = 0;


        crossbowSpeed = 90f;
        rb = GetComponent<Rigidbody2D>();
        isMovingDownLeft = true;

        isMovingDownRight = false;
        isMovingDownUp = false;
        isMovingUpDown = false;
        isMovingUpRight = false;
        isMovingUpLeft = false;

        StartCoroutine(StartMove());
        shootArrowsCoroutine = StartCoroutine(ShootCrossbows());
    }

    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(2);
        moveLeftCoroutine = StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        while (distanceToMove > 0)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.left * step);
            distanceToMove -= step;

            yield return null; // Wait for the next frame
        }
    }

    IEnumerator MoveRight()
    {
        while (distanceToMove > 0)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.right * step);
            distanceToMove -= step;

            yield return null; // Wait for the next frame
        }
    }

    IEnumerator MoveUp()
    {
        while (distanceToMove > 0)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.up * step);
            distanceToMove -= step;

            yield return null; // Wait for the next frame
        }
    }

    IEnumerator MoveDown()
    {
        while (distanceToMove > 0)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.down * step);
            distanceToMove -= step;

            yield return null; // Wait for the next frame
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Button")
        {
            dealingSpikeDamage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Big Piecring bullet
        if (collision.gameObject.name == "bigPiercingBulletCollider")
        {
            DamageEnemyArrow(collision.transform.position, Choises.bigBulletDamage);
        }
        #endregion

        #region Position Movements
        if (collision.gameObject.name == "ChampionPosDownLeft")
        {
            if (isMovingDownLeft == true && moveLeftCoroutine != null)
            {
                if(isDead == false)
                {
                    StopCoroutine(moveLeftCoroutine); moveLeftCoroutine = null; distanceToMove = 250; isMovingDownLeft = false;
                    moveUpCoroutine = StartCoroutine(MoveUp()); isMovingDownUp = true;
                }
            }
        }

        if (collision.gameObject.name == "ChampionPosTopLeft")
        {
            if (isMovingDownUp == true && moveUpCoroutine != null)
            {
                if (isDead == false)
                {
                    StopCoroutine(moveUpCoroutine); moveUpCoroutine = null; distanceToMove = 250; isMovingDownUp = false;
                    moveRightCoroutine = StartCoroutine(MoveRight()); isMovingUpRight = true;
                }
            }
        }

        if (collision.gameObject.name == "ChampionPosTopRight")
        {
            if (isMovingUpRight == true && moveRightCoroutine != null)
            {
                if (isDead == false)
                {
                    StopCoroutine(moveRightCoroutine); moveRightCoroutine = null; distanceToMove = 250; isMovingUpRight = false;
                    moveLeftCoroutine = StartCoroutine(MoveLeft()); isMovingUpLeft = true;
                }
            }
        }

        if (collision.gameObject.name == "ChampionPosTopLeft")
        {
            if (isMovingUpLeft == true && moveLeftCoroutine != null)
            {
                if (isDead == false)
                {
                    StopCoroutine(moveLeftCoroutine); moveLeftCoroutine = null; distanceToMove = 250; isMovingUpLeft = false;
                    moveDownCoroutine = StartCoroutine(MoveDown()); isMovingUpDown = true;
                }
            }
        }

        if (collision.gameObject.name == "ChampionPosDownLeft")
        {
            if (isMovingUpDown == true && moveDownCoroutine != null)
            {
                if (isDead == false)
                {
                    StopCoroutine(moveDownCoroutine); moveDownCoroutine = null; distanceToMove = 250; isMovingUpDown = false;
                    moveRightCoroutine = StartCoroutine(MoveRight()); isMovingDownRight = true;
                }
            }
        }

        if (collision.gameObject.name == "ChampionPosDownRight")
        {
            if (isMovingDownRight == true && moveRightCoroutine != null)
            {
                if (isDead == false)
                {
                    StopCoroutine(moveRightCoroutine); moveRightCoroutine = null; distanceToMove = 250; isMovingDownRight = false;
                    moveLeftCoroutine = StartCoroutine(MoveLeft()); isMovingDownLeft = true;
                }
            }
        }
        #endregion

        #region Sword
        if (collision.gameObject.tag == "SpinningSword")
        {
            if (Choises.chooseBigSpike == true)
            {
                healthSlider.gameObject.SetActive(true);
                champion2DamagedPos = gameObject.transform.localPosition;
                champion2HP -= Choises.bigSpikeDamage;
                healthSlider.GetComponent<Slider>().value = champion2HP;

                ButtonBehiavor.damageDone = Choises.bigSpikeDamage;
                champion2Damaged = true;

                if (champion2HP <= 0)
                {
                    Champion2Death();
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
                champion2DamagedPos = gameObject.transform.localPosition;
                champion2HP -= Choises.stabbingSpikeDamage;
                healthSlider.GetComponent<Slider>().value = champion2HP;

                ButtonBehiavor.damageDone = Choises.stabbingSpikeDamage;
                champion2Damaged = true;

                if (champion2HP <= 0)
                {
                    Champion2Death();
                }

                if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
            }
        }
        #endregion

        #region SawBlade
        if (collision.gameObject.tag == "SawBlade")
        {
            healthSlider.gameObject.SetActive(true);
            champion2DamagedPos = gameObject.transform.localPosition;
            champion2HP -= Choises.sawBladeDamage;
            healthSlider.GetComponent<Slider>().value = champion2HP;

            ButtonBehiavor.damageDone = Choises.sawBladeDamage;
            champion2Damaged = true;

            if (champion2HP <= 0)
            {
                Champion2Death();
            }

            if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        }
        #endregion

        #region Hammer
        if (collision.gameObject.tag == "Hammer")
        {
            healthSlider.gameObject.SetActive(true);
            champion2DamagedPos = gameObject.transform.localPosition;
            champion2HP -= Choises.hammerDamage;
            ButtonBehiavor.damageDone = Choises.hammerDamage;
            healthSlider.GetComponent<Slider>().value = champion2HP;
            champion2Damaged = true;
            Debug.Log(champion2HP); Debug.Log(Choises.hammerDamage);

            if (champion2HP <= 0)
            {
                Champion2Death();
            }

            if (whiteFlashCoroutine == null && isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        }
        #endregion

        #region Knife
        if (collision.gameObject.tag == "Knife")
        {
            healthSlider.gameObject.SetActive(true);
            champion2DamagedPos = gameObject.transform.localPosition;
            champion2Damaged = true;
            champion2HP -= Choises.knifeDamage;
            ButtonBehiavor.damageDone = Choises.knifeDamage;
            healthSlider.GetComponent<Slider>().value = champion2HP;

            if (champion2HP < 1)
            {
                Champion2Death();
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
            DamageEnemy(collision.transform.localPosition, ChargedBullet.chargedChampion2Damage);
        }
        #endregion

        #region TrippleBullet
        if (collision.gameObject.tag == "TrippleBullet")
        {
            DamageEnemy(collision.transform.localPosition, Choises.trippleShotDamage);
        }
        #endregion

    }

    public float tickRate = 0.01f;
    private float timeSinceLastTick = 0.01f;
    public Vector2 crossbow1Dir, crossbow2Dir, crossbow3Dir, crossbow4Dir;
    public bool died;

    void Update()
    {
        if(Choises.didPlayerDie == true && died == false)
        {
            died = true;
            if(isChampionDead == false)
            {
                StopAllCoroutines();
            }
        }

        crossbow1Dir = mainButton.position - crossbow1.transform.position;
        crossbow2Dir = mainButton.position - crossbow2.transform.position;
        crossbow3Dir = mainButton.position - crossbow3.transform.position;
        crossbow4Dir = mainButton.position - crossbow4.transform.position;

        float angleToMainButton1 = Mathf.Atan2(crossbow1Dir.y, crossbow1Dir.x) * Mathf.Rad2Deg;
        Quaternion rotationToMainButton1 = Quaternion.Euler(0f, 0f, angleToMainButton1);

        float angleToMainButton2 = Mathf.Atan2(crossbow2Dir.y, crossbow2Dir.x) * Mathf.Rad2Deg;
        Quaternion rotationToMainButton2 = Quaternion.Euler(0f, 0f, angleToMainButton2);

        float angleToMainButton3 = Mathf.Atan2(crossbow3Dir.y, crossbow3Dir.x) * Mathf.Rad2Deg;
        Quaternion rotationToMainButton3 = Quaternion.Euler(0f, 0f, angleToMainButton3);

        float angleToMainButton4 = Mathf.Atan2(crossbow4Dir.y, crossbow4Dir.x) * Mathf.Rad2Deg;
        Quaternion rotationToMainButton4 = Quaternion.Euler(0f, 0f, angleToMainButton4);

        crossbow1.transform.rotation = rotationToMainButton1;
        crossbow2.transform.rotation = rotationToMainButton2;
        crossbow3.transform.rotation = rotationToMainButton3;
        crossbow4.transform.rotation = rotationToMainButton4;

        #region spike damage
        if (dealingSpikeDamage == true)
        {
            timeSinceLastTick += Time.deltaTime;

            while (timeSinceLastTick >= tickRate)
            {
                if (healthSlider.gameObject.activeInHierarchy == false) { healthSlider.gameObject.SetActive(true); }
                champion2HP -= Choises.spikeDamagePerSecond * tickRate;
                healthSlider.GetComponent<Slider>().value = champion2HP;
                timeSinceLastTick -= tickRate;

                if (champion2HP <= 0)
                {
                    Champion2Death();
                }
            }
        }
        #endregion
    }

    public GameObject arrowOnCrossbow1, arrowOnCrossbow2, arrowOnCrossbow3, arrowOnCrossbow4;
    public Transform crossbow1StartingPos, crossbow2StartingPos, crossbow3StartingPos, crossbow4StartingPos;
    public bool isShootingArrows;
    public float arrowWaitTime;

    IEnumerator ShootCrossbows()
    {
        yield return new WaitForSeconds(3);
        isShootingArrows = true;

        while (isShootingArrows == true)
        {
            if (MimicEnding.championsKilled == 1) { arrowWaitTime = 0.4f; crossbowSpeed = 115; }

            int random = Random.Range(1,5);
            if(random == 1) { random = Random.Range(2, 5); }
            else if (random == 2) { random = Random.Range(3, 5); }
            else if(random == 3) { random = Random.Range(1, 5); }
            else if(random == 4) { random = Random.Range(1, 3); }

            int randomSound = Random.Range(1,5);
            if(randomSound == 1) { audioManager.Play("Champion2Arrow1"); }
            if (randomSound == 2) { audioManager.Play("Champion2Arrow2"); }
            if (randomSound == 3) { audioManager.Play("Champion2Arrow3"); }
            if (randomSound == 4) { audioManager.Play("Champion2Arrow4"); }

            if (random == 1) { arrowOnCrossbow1.SetActive(false); }
            if (random == 2) { arrowOnCrossbow2.SetActive(false); }
            if (random == 3) { arrowOnCrossbow3.SetActive(false); }
            if (random == 4) { arrowOnCrossbow4.SetActive(false); }

            GameObject crossbowArrow = ObjectPool.instance.GetEnemyArrowsFromPool();
            Rigidbody2D rb = crossbowArrow.GetComponent<Rigidbody2D>();

            if (random == 1)
            {
                crossbowArrow.transform.position = crossbow1StartingPos.transform.position;
                Vector3 normalizedDirection = crossbow1Dir.normalized;
                rb.velocity = normalizedDirection * crossbowSpeed;
                float arrowRotation = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
                crossbowArrow.transform.rotation = Quaternion.Euler(0, 0, arrowRotation);
            }
            if (random == 2) 
            {
                crossbowArrow.transform.position = crossbow2StartingPos.transform.position;
                Vector3 normalizedDirection = crossbow2Dir.normalized;
                rb.velocity = normalizedDirection * crossbowSpeed;
                float arrowRotation = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
                crossbowArrow.transform.rotation = Quaternion.Euler(0, 0, arrowRotation);
            }
            if (random == 3)
            {
                crossbowArrow.transform.position = crossbow3StartingPos.transform.position;
                Vector3 normalizedDirection = crossbow3Dir.normalized;
                rb.velocity = normalizedDirection * crossbowSpeed;
                float arrowRotation = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
                crossbowArrow.transform.rotation = Quaternion.Euler(0, 0, arrowRotation);
            }
            if (random == 4)
            {
                crossbowArrow.transform.position = crossbow4StartingPos.transform.position;
                Vector3 normalizedDirection = crossbow4Dir.normalized;
                rb.velocity = normalizedDirection * crossbowSpeed;
                float arrowRotation = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
                crossbowArrow.transform.rotation = Quaternion.Euler(0, 0, arrowRotation);
            }

            yield return new WaitForSeconds(0.1f);
            if (random == 1) { arrowOnCrossbow1.SetActive(true); }
            if (random == 2) { arrowOnCrossbow2.SetActive(true); }
            if (random == 3) { arrowOnCrossbow3.SetActive(true); }
            if (random == 4) { arrowOnCrossbow4.SetActive(true); }
            yield return new WaitForSeconds(arrowWaitTime);
            StartCoroutine(ReturnArrow(crossbowArrow));
        }

    }

    IEnumerator ReturnArrow(GameObject arrow)
    {
        yield return new WaitForSeconds(6);
        if(arrow.activeInHierarchy == true) { ObjectPool.instance.ReturnEnemyArrowsFromPool(arrow); }
    }

    #region Champion damagesd
    public void DamageEnemy(Vector2 damagePos, float damageAmount)
    {
        if (whiteFlashCoroutine == null)
        {
            if(isChampionDead == false) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        
        }
        champion2HP -= damageAmount;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = champion2HP;

        ButtonBehiavor.damageDone = damageAmount;
        champion2DamagedPos = damagePos;
        champion2Damaged = true;

        if (champion2HP < 1)
        {
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); whiteFlashCoroutine = null; }
            if (shootArrowsCoroutine != null) { StopCoroutine(shootArrowsCoroutine); shootArrowsCoroutine = null; }

            if (moveLeftCoroutine != null) { StopCoroutine(moveLeftCoroutine); moveLeftCoroutine = null; }
            if (moveRightCoroutine != null) { StopCoroutine(moveRightCoroutine); moveRightCoroutine = null; }
            if (moveUpCoroutine != null) { StopCoroutine(moveUpCoroutine); moveUpCoroutine = null; }
            if (moveDownCoroutine != null) { StopCoroutine(moveDownCoroutine); moveDownCoroutine = null; }
            Champion2Death();
        }
    }

    public void DamageEnemyArrow(Vector2 damagePos, float damageAmount)
    {
        if (whiteFlashCoroutine == null) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        champion2HP -= damageAmount;
        healthSlider.gameObject.SetActive(true);
        healthSlider.value = champion2HP;

        ButtonBehiavor.damageDone = damageAmount;
        champion2ArrowDamagesPos = damagePos;
        champion2ArrowDamaged = true;

        if (champion2HP < 1)
        {
            if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); whiteFlashCoroutine = null; }
            if (shootArrowsCoroutine != null) { StopCoroutine(shootArrowsCoroutine); shootArrowsCoroutine = null; }

            if (moveLeftCoroutine != null) { StopCoroutine(moveLeftCoroutine); moveLeftCoroutine = null; }
            if (moveRightCoroutine != null) { StopCoroutine(moveRightCoroutine); moveRightCoroutine = null; }
            if (moveUpCoroutine != null) { StopCoroutine(moveUpCoroutine); moveUpCoroutine = null; }
            if (moveDownCoroutine != null) { StopCoroutine(moveDownCoroutine); moveDownCoroutine = null; }
            Champion2Death();
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

    public bool dealingSpikeDamage;
    public Vector2 enemyDiePos;
    public ParticleEffectSystems particleScripts;
    public bool isDead;

    public void Champion2Death()
    {
        if(isChampionDead == false)
        {
            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("championDeath1"); }
            if (random == 2) { audioManager.Play("championDeath2"); }

            isChampionDead = true;

            Choises.maxArrowsStuck -= arrowStuck;

            MimicEnding.championsKilled += 1;

            isDead = true;

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
            particleScripts.Champion2Pieces(enemyDiePos, 2.2f);
            gameObject.SetActive(false);
        
        }
    }
}
