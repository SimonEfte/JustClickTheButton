using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed;
    private float bigEnemyHP;

    public static Vector2 bigEnemyDiePos, bigEnemyDamagedPos;

    private Transform mainButton;
    public Transform healthBar, stunIcon;

    public bool dealingSpikeDamage;
    public bool isAttacking, attackecOnce;
    public static bool bigEnemyDied, bigEnemyDamaged;

    private Coroutine movingTowardsButton;
    private bool endingTransitionSetInactive;

    public GameObject particleManager, textPopUpManager;

    public float tickRate = 0.01f;
    private float timeSinceLastTick = 0.01f;

    public GameObject overlappSoundManager;
    public OverlappingSounds overlapp;

    private void Awake()
    {
        overlappSoundManager = GameObject.Find("OverlappingSounds");
        overlapp = overlappSoundManager.GetComponent<OverlappingSounds>();

        particleManager = GameObject.Find("ParticleSystems");
        textPopUpManager = GameObject.Find("TextPopUps");
        mainButton = GameObject.FindWithTag("Button").transform;
        healthBar = transform.Find("HealthBar");
        whiteFlash = transform.Find("WhiteFlash");
        stunIcon = transform.Find("Stun_Icon");

        rb = GetComponent<Rigidbody2D>();
    }

   

    private bool playerDidDie;
    void Update()
    {
        #region Set Stuff Inactive For endings
        if (Choises.bossChosenSetStuffInactive == true)
        {
            if (endingTransitionSetInactive == false)
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

                if (gameObject.tag == "BigEnemy")
                {
                    SpawnBigEnemy.bigEnemyCount -= 1;
                    ObjectPool.instance.ReturnBigEnemyPoolFromPool(gameObject);
                }
                if (gameObject.tag == "Titan")
                {
                    SpawnBigEnemy.titanCount -= 1;
                    ObjectPool.instance.ReturnTitanFromPool(gameObject);
                }

                endingTransitionSetInactive = true;
            }
        }
        #endregion

        #region Player died 
        if (Choises.playerDied == true)
        {
            if(playerDidDie == false)
            {
                StartCoroutine(ScaleDownEnemy());
                playerDidDie = true;
            }
        }
        #endregion

        #region Tiny Spike Damage
        if (isCollidingWithButton == true && Choises.chooseSpikes == true)
        {
            timeSinceLastTick += Time.deltaTime;

            while (timeSinceLastTick >= tickRate)
            {
                SetHealthbar();
                bigEnemyHP -= Choises.spikeDamagePerSecond * tickRate;
                healthBar.GetComponent<Slider>().value = bigEnemyHP;

                timeSinceLastTick -= tickRate;

                if (bigEnemyHP <= 0)
                {
                    EnemyDied();
                }
            }
        }
        #endregion
    }

    #region Scale Up And Down Enemy
    IEnumerator ScaleDownEnemy()
    {
        if (gameObject.tag == "BigEnemy")
        {
            Vector2 bulletScale = new Vector2(ObjectPool.bigEnemySize, ObjectPool.bigEnemySize);
            Vector2 zeroScale = new Vector2(0, 0);

            float duration = Random.Range(0.2f, 0.35f);
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                gameObject.transform.localScale = Vector2.Lerp(bulletScale, zeroScale, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            SpawnBigEnemy.bigEnemyCount -= 1;
            ObjectPool.instance.ReturnBigEnemyPoolFromPool(gameObject);
        }
        if (gameObject.tag == "Titan")
        {
            Vector2 bulletScale = new Vector2(ObjectPool.titanSize, ObjectPool.titanSize);
            Vector2 zeroScale = new Vector2(0, 0);

            float duration = Random.Range(0.2f, 0.35f);
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                gameObject.transform.localScale = Vector2.Lerp(bulletScale, zeroScale, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            SpawnBigEnemy.titanCount -= 1;
            ObjectPool.instance.ReturnTitanFromPool(gameObject);
        }
    }

    IEnumerator ScaleUpEnemy()
    {
        if (gameObject.tag == "BigEnemy")
        {
            Vector2 enemyScale = new Vector2(ObjectPool.bigEnemySize, ObjectPool.bigEnemySize);
            Vector2 zeroScale = new Vector2(0, 0);

            float duration = 0.2f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                gameObject.transform.localScale = Vector2.Lerp(zeroScale, enemyScale, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            gameObject.transform.localScale = enemyScale;
        }
        if (gameObject.tag == "Titan")
        {
            Vector2 enemyScale = new Vector2(ObjectPool.titanSize, ObjectPool.titanSize);
            Vector2 zeroScale = new Vector2(0, 0);

            float duration = 0.2f;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                gameObject.transform.localScale = Vector2.Lerp(zeroScale, enemyScale, t);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            gameObject.transform.localScale = enemyScale;
        }

    }
    #endregion

    public bool isCollidingWithButton;

    public void OnEnable()
    {
        isCollidingWithButton = false;
        arrowStuck = 0;
        StartCoroutine(ScaleUpEnemy());
        dealingSpikeDamage = false;
        playerDidDie = false;
        endingTransitionSetInactive = false;
        stunIcon.gameObject.SetActive(false);

        whiteFlash.gameObject.SetActive(false);

        isEnemyDead = false;
        isStunned = false;
        attackecOnce = false;
        isAttacking = false;

        if(HordeEnding.playingHordeEnding == false)
        {
            if (gameObject.tag == "BigEnemy")
            {
                float randomBruteSpeed = Random.Range(0.75f, 0.95f);
                bigEnemyHP = Choises.bruteHP; moveSpeed = randomBruteSpeed;
            }
            if (gameObject.tag == "Titan")
            {
                float randomTitanSpeed = Random.Range(0.55f, 0.65f);
                bigEnemyHP = Choises.titanHP; moveSpeed = randomTitanSpeed;
            }
        }

        if (HordeEnding.playingHordeEnding == true)
        {
            if (gameObject.tag == "BigEnemy")
            {
                float randomBruteSpeed = Random.Range(1f, 1.4f);
                bigEnemyHP = Choises.bruteHP; moveSpeed = randomBruteSpeed;
            }
            if (gameObject.tag == "Titan")
            {
                float randomTitanSpeed = Random.Range(0.7f, 0.9f);
                bigEnemyHP = Choises.titanHP; moveSpeed = randomTitanSpeed;
            }
        }

        healthBar.gameObject.SetActive(false);
        healthBar.gameObject.GetComponent<Slider>().maxValue = bigEnemyHP;
        healthBar.gameObject.GetComponent<Slider>().value = bigEnemyHP;

        movingTowardsButton = StartCoroutine(MoveTowardsMainButton());
    }

    #region move towards button
    private IEnumerator MoveTowardsMainButton()
    {
        if (isAttacking == false)
        {
            while (Vector3.Distance(transform.position, mainButton.position) > 0.75f)
            {
               
                Vector3 direction = (mainButton.position - transform.position).normalized;

                if (gameObject.tag == "BigEnemy")
                {
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }

                if (gameObject.tag == "Titan")
                {
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
                yield return null;
            }
        }
    }
    #endregion

    #region damage button

    public static bool enemyAttacking;
    public static Vector2 damagePos;

    private IEnumerator DamageButton()
    {
        while (isAttacking || attackecOnce == true)
        {
            if (isAttacking == true)
            {
                if(gameObject.tag == "BigEnemy")
                {
                    Choises.buttonHealth -= Choises.bruteDamage;
                    TextPopUpBehavior.enemyDamageAmount = Choises.bruteDamage;
                }
                if (gameObject.tag == "Titan")
                {
                    Choises.buttonHealth -= Choises.titanDamage;
                    TextPopUpBehavior.enemyDamageAmount = Choises.titanDamage;
                }

                Vector2 enemyPosition = gameObject.transform.localPosition;
                Vector2 mainButtonPosition = mainButton.transform.localPosition;

                Vector2 direction = (mainButtonPosition - enemyPosition).normalized;

                float distance = 110f;
                Vector2 newDamagePos = enemyPosition + direction * distance;

                damagePos = newDamagePos;

                enemyAttacking = true;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
    #endregion

    #region No Piercing Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region Bullet hit Big enemy, DAMAGED
        if (collision.gameObject.tag == "bullets"  || collision.gameObject.tag == "HomingBullet" || collision.gameObject.tag == "BulletBounced" || collision.gameObject.name == "ShotgunBullet(Clone)" || collision.gameObject.tag == "Gun3Bullet")
        {
            DamageEnemy();
        }
        #endregion

        #region DAMAGING BUTTON
        if (collision.gameObject.tag == "Button")
        {
            if (isAttacking == false)
            {
                if (bigEnemyHP > 0) { StopCoroutine(movingTowardsButton); }
                movingTowardsButton = null;
                isAttacking = true;
                if (bigEnemyHP > 0 && attackecOnce == false) { StartCoroutine(DamageButton()); }
                attackecOnce = true;
            }
        }
        #endregion

        #region Damaged by spikes
        if (collision.gameObject.tag == "Button")
        {
            isCollidingWithButton = true;

            if (Choises.chooseSpikes == true)
            {
                dealingSpikeDamage = true;
            }
        }
        #endregion

    }
    #endregion

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Button")
        {
            isCollidingWithButton = false;

            dealingSpikeDamage = false;
            if (isStunned == false)
            {
                isAttacking = false;
                if (bigEnemyHP > 0) { if (movingTowardsButton == null) { movingTowardsButton = StartCoroutine(MoveTowardsMainButton()); } }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region charged bullets
        if (collision.gameObject.tag == "ChargedBullet")
        {
            DamageEnemy();
        }
        #endregion

        #region Big piercing or bullets
        if (collision.gameObject.name == "bigPiercingBulletCollider")
        {
            DamageEnemy();
        }
        #endregion

        #region tripple
        if (collision.gameObject.tag == "TrippleBullet")
        {
            DamageEnemy();
        }
        #endregion

        #region spinning spike/sword
        if (collision.gameObject.tag == "SpinningSword")
        {
            if (Choises.chooseBigSpike == true)
            {
                SetHealthbar();
                bigEnemyDamagedPos = gameObject.transform.localPosition;
                bigEnemyHP -= Choises.bigSpikeDamage;
                healthBar.GetComponent<Slider>().value = bigEnemyHP;

                ButtonBehiavor.damageDone = Choises.bigSpikeDamage;
                bigEnemyDamaged = true;

                if (bigEnemyHP <= 0)
                {
                    EnemyDied();
                }

                if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
                {
                    whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
                }
            }
        }
        #endregion

        #region stabbing spikes
        if (collision.gameObject.tag == "StabbingSpike")
        {
            if (Choises.chooseStabbingSpikes == true)
            {
                SetHealthbar();
                bigEnemyDamagedPos = gameObject.transform.localPosition;
                bigEnemyHP -= Choises.stabbingSpikeDamage;
                healthBar.GetComponent<Slider>().value = bigEnemyHP;

                ButtonBehiavor.damageDone = Choises.stabbingSpikeDamage;
                bigEnemyDamaged = true;

                if (bigEnemyHP <= 0)
                {
                    EnemyDied();
                }
            }

            if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
        #endregion

        #region SawBlade
        if (collision.gameObject.tag == "SawBlade")
        {
            SetHealthbar();
            bigEnemyDamagedPos = gameObject.transform.localPosition;
            bigEnemyHP -= Choises.sawBladeDamage;
            healthBar.GetComponent<Slider>().value = bigEnemyHP;

            ButtonBehiavor.damageDone = Choises.sawBladeDamage;
            bigEnemyDamaged = true;

            if (bigEnemyHP <= 0)
            {
                EnemyDied();
            }

            if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
        #endregion

        #region Hammer
        if (collision.gameObject.tag == "Hammer")
        {
            SetHealthbar();
            Stun();
            bigEnemyDamagedPos = gameObject.transform.localPosition;
            bigEnemyHP -= Choises.hammerDamage;
            healthBar.GetComponent<Slider>().value = bigEnemyHP;

            ButtonBehiavor.damageDone = Choises.hammerDamage;
            bigEnemyDamaged = true;

            if (bigEnemyHP <= 0)
            {
                EnemyDied();
            }

            if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
        #endregion

        #region Arrow
        if (collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "CrossbowArrow")
        {
            arrowStuck += 1;
            DamageEnemy();
        }
        #endregion

        #region Knife
        if (collision.gameObject.tag == "Knife")
        {
            SetHealthbar();

            bigEnemyDamagedPos = gameObject.transform.localPosition;
            bigEnemyDamaged = true;
            ButtonBehiavor.damageDone = Choises.knifeDamage;
            bigEnemyHP -= Choises.knifeDamage;
            healthBar.GetComponent<Slider>().value = bigEnemyHP;

            if (bigEnemyHP <= 0)
            {
                EnemyDied();
            }

            if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
        #endregion
    }

    #region Set HealthBarActive
    public void SetHealthbar()
    {
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(true);
        }
    }
    #endregion

    #region Stun Effect
    public bool isStunned;
    public void Stun()
    {
        stunIcon.gameObject.SetActive(true);

        isAttacking = false;
        isStunned = true;
        if (movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }
        Invoke("UnStun", Choises.hammerStunTime);
    }

    public void UnStun()
    {
        if (gameObject.activeInHierarchy == true)
        {
            isStunned = false;
            SetStunOff();
            movingTowardsButton = StartCoroutine(MoveTowardsMainButton());
        }
    }

    public void SetStunOff()
    {
        stunIcon.gameObject.SetActive(false);
    }
    #endregion

    #region Damage Enemy
    public static float bulletDamageAmount;
    public void DamageEnemy()
    {
        SetHealthbar();

        if (isEnemyDead == false)
        {
            if(whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
            if(SettingsOptions.disableWhiteFlash == 0) { whiteFlashCoroutine = StartCoroutine(whiteFlashEffect()); }
        }

        Vector2 buttonPosition = gameObject.transform.localPosition;

        float xOffset = Random.Range(-40, 40);
        float yOffset = Random.Range(-40, 40);

        Vector2 newPosition = new Vector2(
            buttonPosition.x + xOffset,
            buttonPosition.y + yOffset
        );
        bigEnemyDamagedPos = newPosition;

        bigEnemyHP -= bulletDamageAmount;
        healthBar.GetComponent<Slider>().value = bigEnemyHP;

        ButtonBehiavor.damageDone = bulletDamageAmount;
        bigEnemyDamaged = true;

        //EnemyDie
        if (bigEnemyHP <= 0)
        {
            EnemyDied();
        }
        else
        {
            //Rigidbody2D rb = GetComponent<Rigidbody2D>();
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            //rb.constraints = RigidbodyConstraints2D.None;
            //rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    #endregion

    #region WhiteFlash
    public Coroutine whiteFlashCoroutine;
    public Transform whiteFlash;

    IEnumerator whiteFlashEffect()
    {
        whiteFlash.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.11f);
        whiteFlash.gameObject.SetActive(false);

        whiteFlashCoroutine = null;
    }
    #endregion

    public bool isEnemyDead;
    public int arrowStuck;

    #region Enemy Died
    private string originalParentName = "arrowPool";
    private string originalParentName2 = "arrowPool";
    public void EnemyDied()
    {
        if (isEnemyDead == true)
        {
            return;
        }

        overlapp.DeathSounds();

        if (whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
        whiteFlashCoroutine = null;

        Choises.maxArrowsStuck -= arrowStuck;

        #region Arrows Stuck
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

        SettingsOptions.totalEnemiesDefeated += 1;

        #region point drop
        if (Choises.chosePointsDrop == true && Choises.maxPointDropOnScreen < 65 && HordeEnding.playingHordeEnding == false)
        {
            Choises.maxPointDropOnScreen += 1;
            GameObject basicPoints = ObjectPool.instance.GetBasicPointsFromPool();
            basicPoints.transform.localPosition = gameObject.transform.localPosition;
        }
        #endregion

        isEnemyDead = true;

        bigEnemyDiePos = gameObject.transform.position;
        SetStunOff();

        ParticleEffectSystems particleMan = particleManager.GetComponent<ParticleEffectSystems>();
        TextPopUpBehavior texts = textPopUpManager.GetComponent<TextPopUpBehavior>();

        if(gameObject.tag == "BigEnemy")
        {
            SpawnBigEnemy.bigEnemyCount -= 1;

            if (HordeEnding.playingHordeEnding == false) 
            {
                ButtonClick.pointsGained += Choises.bigEnemyPoint;
                SettingsOptions.totalPoints += Choises.bigEnemyPoint;
                SettingsOptions.totalEnemyPoints += Choises.bigEnemyPoint;
            }

            SettingsOptions.totalBrutedDefeated += 1;

            particleMan.DeathParticle(bigEnemyDiePos, ObjectPool.bigEnemySize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.BigEnemyPieces(bigEnemyDiePos, 1.45f); }
            }
            texts.BigEnemyPointsPopUp(true, false);

            #region skull
            if (Choises.choseSkullHarvest == true)
            {
                GameObject bigEnemySkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in bigEnemySkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_BigEnemy")
                    {
                        // Activate the specific child
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        // Deactivate all other children
                        child.gameObject.SetActive(false);
                    }
                }
                bigEnemySkull.transform.localScale = new Vector2(1.5f, 1.5f);
                bigEnemySkull.transform.position = gameObject.transform.position;
            }
            #endregion

            bigEnemyDied = true;

            StopAllCoroutines();
            ObjectPool.instance.ReturnBigEnemyPoolFromPool(gameObject);
        }

        if (gameObject.tag == "Titan")
        {
            SpawnBigEnemy.titanCount -= 1;

            if (HordeEnding.playingHordeEnding == false)
            { 
                ButtonClick.pointsGained += Choises.titanPoints;
                SettingsOptions.totalPoints += Choises.titanPoints;
                SettingsOptions.totalEnemyPoints += Choises.titanPoints;
            }

            SettingsOptions.totalTitansDefeated += 1;

            particleMan.DeathParticle(bigEnemyDiePos, ObjectPool.titanSize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.TitanPieces(bigEnemyDiePos, 3.1f); }
            }
            texts.BigEnemyPointsPopUp(false, true);

            #region skull
            if (Choises.choseSkullHarvest == true)
            {
                GameObject bigEnemySkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in bigEnemySkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_Titan")
                    {
                        // Activate the specific child
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        // Deactivate all other children
                        child.gameObject.SetActive(false);
                    }
                }
                bigEnemySkull.transform.localScale = new Vector2(1.7f, 1.7f);
                bigEnemySkull.transform.position = gameObject.transform.position;
            }
            #endregion

            bigEnemyDied = true;

            StopAllCoroutines();
            ObjectPool.instance.ReturnTitanFromPool(gameObject);
        }

        //Debug.Log(SpawnBigEnemy.titanCount);
        //Debug.Log(SpawnBigEnemy.bigEnemyCount);
        //Debug.Log(SpawnEnemies.smallEnemyCount);
        //Debug.Log(SpawnEnemies.speedsterCount);
        //Debug.Log(SpawnShootingEnemy.ragingGunnerCount);
    }
    #endregion
}
