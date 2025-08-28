using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SmallEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool offScreen;

    public float minTimeBetweenDirectionChanges = 2.0f;
    public float maxTimeBetweenDirectionChanges = 5.1f;
    public float moveSpeedNotAttacking;

    public float smallEnemySpeed, speedsterSpeed;

    private Camera mainCamera;

    public static bool smallEnemyDied, enemyDamaged;
    public static Vector2 enemyDiePos, speedsterDiePos, enemyDamagePos;

    public float enemyHP;
    public bool deSpawnEnemy;

    private Transform mainButton;
    public Transform healthBar, stunIcon, arrowIcon, whiteFlash;
    public bool isAttacking, attackecOnce;

    //SpikeDamage variables
    public float tickRate = 0.01f;
    private float timeSinceLastTick = 0.01f;

    private Coroutine movingTowardsButton;

    public GameObject particleManager, textPopUpManager;
    private bool endingTransitionSetInactive;

    private ParticleEffectSystems particleMan;
    public TextPopUpBehavior texts;

    public GameObject overlappSoundManager;
    public OverlappingSounds overlapp;

    public void Awake()
    {
        overlappSoundManager = GameObject.Find("OverlappingSounds");
        overlapp = overlappSoundManager.GetComponent<OverlappingSounds>();

        stunIcon = transform.Find("Stun_Icon");
        healthBar = transform.Find("HealthBar");
        whiteFlash = transform.Find("WhiteFlash");
        particleManager = GameObject.Find("ParticleSystems");
        particleMan = particleManager.GetComponent<ParticleEffectSystems>();
        textPopUpManager = GameObject.Find("TextPopUps");
        texts = textPopUpManager.GetComponent<TextPopUpBehavior>();
        mainButton = GameObject.FindWithTag("Button").transform;

        maxForce = 2;

        moveSpeedNotAttacking = 4f;

        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 enemySize;

    #region Scale Up And Down Enemy
    IEnumerator ScaleDownEnemy()
    {
        if (gameObject.tag == "Speedster")
        {
            enemySize = new Vector2(ObjectPool.speedsterSize, ObjectPool.speedsterSize);
        }
        if (gameObject.tag == "SmallEnemy")
        {
            enemySize = new Vector2(ObjectPool.smallEnemySize, ObjectPool.smallEnemySize);
        }

        Vector2 zeroScale = new Vector2(0, 0);

        float duration = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            gameObject.transform.localScale = Vector2.Lerp(enemySize, zeroScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (gameObject.tag == "Speedster")
        {
            SpawnEnemies.speedsterCount -= 1;
            ObjectPool.instance.ReturnSpeedsterFromPool(gameObject);
        }
        if (gameObject.tag == "SmallEnemy")
        {
            SpawnEnemies.smallEnemyCount -= 1;
            ObjectPool.instance.ReturnSmallEnemyFromPool(gameObject);
        }
      
    }

    IEnumerator ScaleUpEnemy()
    {
        if (gameObject.tag == "Speedster")
        {
            enemySize = new Vector2(ObjectPool.speedsterSize, ObjectPool.speedsterSize);
        }
        if (gameObject.tag == "SmallEnemy")
        {
            enemySize = new Vector2(ObjectPool.smallEnemySize, ObjectPool.smallEnemySize);
        }

        Vector2 zeroScale = new Vector2(0, 0);

        float duration = 0.2f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            gameObject.transform.localScale = Vector2.Lerp(zeroScale, enemySize, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localScale = enemySize;
    }
    #endregion

    public int arrowStuck;

    public void OnEnable()
    {
        isCollidingWithButton = false;
        arrowStuck = 0;
        StartCoroutine(ScaleUpEnemy());
        playerDidDie = false;
        endingTransitionSetInactive = false;
        whiteFlash.gameObject.SetActive(false);
        stunIcon.gameObject.SetActive(false);

        //gameObject.GetComponent<Animation>().Play("EnemySpawnAnim");
        isEnemyDead = false;
        isStunned = false;
        offScreen = false;
        attackecOnce = false;
        isAttacking = false;

        if(HordeEnding.playingHordeEnding == false)
        {
            float randomAssassinSpeed = Random.Range(2.9f, 3.4f);
            float randomSpeedsterSpeed = Random.Range(6.5f, 7.5f);

            smallEnemySpeed = randomAssassinSpeed;
            speedsterSpeed = randomSpeedsterSpeed;
        }

        if (HordeEnding.playingHordeEnding == true)
        {
            float randomAssassinSpeed = Random.Range(3.5f, 3.8f);
            float randomSpeedsterSpeed = Random.Range(7f, 8f);

            smallEnemySpeed = randomAssassinSpeed;
            speedsterSpeed = randomSpeedsterSpeed;
        }


        if (gameObject.tag == "Speedster") { enemyHP = Choises.speedsterHP; }
        if (gameObject.tag == "SmallEnemy") { enemyHP = Choises.smallEnemyHP; }


        healthBar.gameObject.SetActive(false);
        healthBar.gameObject.GetComponent<Slider>().maxValue = enemyHP;
        healthBar.gameObject.GetComponent<Slider>().value = enemyHP;

        if (Choises.choseHealthBar == true)
        {
            movingTowardsButton = StartCoroutine(MoveTowardsMainButton());
        }

        //Enemies do not attack
        if (Choises.choseHealthBar == false)
        {
            StartCoroutine(wait());
        }
    }

    public static bool enemyAttacking;
    public static Vector2 damagePos;

    #region Enemy Attacking and Deals Damage. Moves towards button
    private IEnumerator MoveTowardsMainButton()
    {
        if(isAttacking == false)
        {
            while (Vector3.Distance(transform.position, mainButton.position) > 0.05f)
            {
                Vector3 direction = (mainButton.position - transform.position).normalized;
                if(gameObject.tag == "Speedster") { transform.position += direction * speedsterSpeed * Time.deltaTime; }
                if(gameObject.tag == "SmallEnemy") { transform.position += direction * smallEnemySpeed * Time.deltaTime; }
                yield return null;
            }
        }
    }

    private IEnumerator DamageButton()
    {
        while (isAttacking == true || attackecOnce == true)
        {
            if(isAttacking == true)
            {
                if (gameObject.tag == "Speedster") { Choises.buttonHealth -= Choises.speedsterDamagePerSecond; TextPopUpBehavior.enemyDamageAmount = Choises.speedsterDamagePerSecond; }
                if (gameObject.tag == "SmallEnemy") { Choises.buttonHealth -= Choises.smallEnemyDamage; TextPopUpBehavior.enemyDamageAmount = Choises.smallEnemyDamage; }

                Vector2 enemyPosition = gameObject.transform.localPosition;
                Vector2 mainButtonPosition = mainButton.transform.localPosition;

                Vector2 direction = (mainButtonPosition - enemyPosition).normalized;

                float distance = 24f;
                Vector2 newDamagePos = enemyPosition + direction * distance;

                damagePos = newDamagePos;

                enemyAttacking = true;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
    #endregion

    #region Change direction - idle movement
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        ChangeDirection();
        InvokeRepeating("ChangeDirection", Random.Range(minTimeBetweenDirectionChanges, maxTimeBetweenDirectionChanges), Random.Range(minTimeBetweenDirectionChanges, maxTimeBetweenDirectionChanges));
    }

    private void ChangeDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rb.linearVelocity = randomDirection * moveSpeedNotAttacking;
    }
    #endregion

    public float maxForce;
    private bool playerDidDie;

    private void Update()
    {
        #region Player died 
        if (Choises.playerDied == true)
        {
            if (playerDidDie == false)
            {
                StartCoroutine(ScaleDownEnemy());
                playerDidDie = true;
            }
        }
        #endregion

        #region Set Stuff Inactive For endings
        if (Choises.bossChosenSetStuffInactive == true)
        {
            if (endingTransitionSetInactive == false)
            {
                enemyHP = 0;
                if (movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }

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

                if (gameObject.tag == "SmallEnemy")
                {
                    SpawnEnemies.smallEnemyCount -= 1;
                    ObjectPool.instance.ReturnSmallEnemyFromPool(gameObject);
                }
                if (gameObject.tag == "Speedster")
                {
                    SpawnEnemies.speedsterCount -= 1;
                    ObjectPool.instance.ReturnSpeedsterFromPool(gameObject);
                }

                endingTransitionSetInactive = true;
            }
        }
        #endregion

        #region spike damage
        if (isCollidingWithButton == true && Choises.chooseSpikes == true)
        {
            timeSinceLastTick += Time.deltaTime;

            while (timeSinceLastTick >= tickRate)
            {
                SetHealthbar();
                enemyHP -= Choises.spikeDamagePerSecond * tickRate;
                healthBar.GetComponent<Slider>().value = enemyHP;

                timeSinceLastTick -= tickRate;

                if(enemyHP <= 0)
                {
                    EnemyDied();
                }
            }
        }
        #endregion

        if (Choises.setEnemiesInactive == true)
        {
            deSpawnEnemy = true;
            if (deSpawnEnemy == true)
            {
                //gameObject.GetComponent<Animation>().Play("EnemyDeSpawnAnim");
                //StartCoroutine(waitForDeSpawn());
                //Debug.Log("DeSpawnEnemy");
                deSpawnEnemy = false;
            }
        }

        if (IsVisibleOnScreen())
        {
            offScreen = false;
        }
        else
        {
            offScreen = true;
            Vector2 moveDirection = -rb.position.normalized;
            rb.linearVelocity = moveDirection * moveSpeedNotAttacking;
        }

        if(Vector3.Distance(transform.position, mainButton.position) > 0.25f)
        {
            //Debug.Log("Away from button");
        }

    }

    #region De spawns enemies if health bar is chosen
    IEnumerator waitForDeSpawn()
    {
        yield return new WaitForSeconds(Random.Range(0.1f,0.4f));
        SpawnEnemies.smallEnemyCount -= 1;
        ObjectPool.instance.ReturnSmallEnemyFromPool(gameObject);
        Choises.setEnemiesInactive = false;
    }
    #endregion

    #region checkPos
    public void CheckPos()
    {
        if (Vector3.Distance(transform.position, mainButton.position) > 0.1f)
        {
            isAttacking = false;
            isCollidingWithButton = false;
            if(enemyHP > 0)
            {
                if (movingTowardsButton == null)
                {
                    if(isEnemyDead == false) { if (isStunned == false) { movingTowardsButton = StartCoroutine(MoveTowardsMainButton()); } }
                }
            }
        }
    }
    #endregion

    public bool isCollidingWithButton;

    #region No Piercing Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If enemies are not attacking
        #region Damage enemy
        if (collision.gameObject.tag == "bullets" ||  collision.gameObject.name == "ShotgunBullet(Clone)" || collision.gameObject.tag == "HomingBullet" || collision.gameObject.tag == "Gun3Bullet")
        {
            DamageEnemy();
        }
        #endregion

        #region not attacking, button and arena
        //If enemy is not attacking
        if (Choises.choseHealthBar == false)
        {
            if (collision.gameObject.tag == "Button")
            {
                ChangeDirection();
            }
            if (collision.gameObject.tag == "Arena")
            {
                ChangeDirection();
            }
        }
        #endregion

        #region is attacking, dealing damage to button
        if (Choises.choseHealthBar == true)
        {
            if (collision.gameObject.tag == "Button")
            {
                if(isAttacking == false)
                {
                    if(movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }
                    movingTowardsButton = null;
                    isAttacking = true;
                    if (enemyHP > 0 && attackecOnce == false) { StartCoroutine(DamageButton()); }
                    attackecOnce = true;
                }
            }
        }
        #endregion

        #region button bounce damage, damage is equal to button speed
        if (ButtonClick.isButtonMoving == true)
        {
            if (collision.gameObject.tag == "Button")
            {
                enemyHP -= ButtonClick.buttonMovingDamageBonus;
                healthBar.GetComponent<Slider>().value = enemyHP;

                enemyDamagePos = gameObject.transform.localPosition;
                ButtonBehiavor.damageDone = ButtonClick.buttonMovingDamageBonus;
                enemyDamaged = true;

                Invoke("CheckPos", 0.25f);

                if (enemyHP <= 0)
                {
                    enemyDiePos = gameObject.transform.position;
                    smallEnemyDied = true;

                    EnemyDied();
                }
            }
        }
        #endregion

        #region spikes
        if (collision.gameObject.tag == "Button")
        {
            isCollidingWithButton = true;
        }
        #endregion

        #region boxing glove
        if (collision.gameObject.tag == "BoxingGlove")
        {
            enemyAttacking = false;
            if(enemyHP > 0) { StartCoroutine(KnockBack2()); }
        }
        #endregion

        if (collision.gameObject.tag == "BulletBounced")
        {
            DamageEnemy();
        }

    }
    #endregion

    #region Piercing Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region charged bullets
        if (collision.gameObject.tag == "ChargedBullet")
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

        #region Piercing bullets
        if (Choises.chosePiercingBullets == true)
        {
            if (collision.gameObject.tag == "bullets" || collision.gameObject.tag == "HomingBullet" || collision.gameObject.tag == "ChargedBullet" || collision.gameObject.tag == "BulletBounced" || collision.gameObject.name == "bigPiercingBullet(Clone)" || collision.gameObject.name == "ShotgunBullet(Clone)" || collision.gameObject.name == "Gun3Bullet")
            {
                DamageEnemy();
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

        #region Sword
        if (collision.gameObject.tag == "SpinningSword")
        {
            if (Choises.chooseBigSpike == true)
            {
                SetHealthbar();
                enemyDamagePos = gameObject.transform.localPosition;
                enemyHP -= Choises.bigSpikeDamage;
                healthBar.GetComponent<Slider>().value = enemyHP;

                ButtonBehiavor.damageDone = Choises.bigSpikeDamage;
                enemyDamaged = true;

                if (enemyHP <= 0)
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
                enemyDamagePos = gameObject.transform.localPosition;
                enemyHP -= Choises.stabbingSpikeDamage;
                healthBar.GetComponent<Slider>().value = enemyHP;

                ButtonBehiavor.damageDone = Choises.stabbingSpikeDamage;
                enemyDamaged = true;

                if (enemyHP <= 0)
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

        #region SawBlade
        if (collision.gameObject.tag == "SawBlade")
        {
            SetHealthbar();
            enemyDamagePos = gameObject.transform.localPosition;
            enemyHP -= Choises.sawBladeDamage;
            healthBar.GetComponent<Slider>().value = enemyHP;

            ButtonBehiavor.damageDone = Choises.sawBladeDamage;
            enemyDamaged = true;

            if (enemyHP <= 0)
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
            float random = Random.Range(0f, 0.1f);
            Invoke("RandomDamPos", random);
            enemyHP -= Choises.hammerDamage;
            healthBar.GetComponent<Slider>().value = enemyHP;

            if (enemyHP <= 0)
            {
                EnemyDied();
            }

            if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
        #endregion

        #region Knife
        if (collision.gameObject.tag == "Knife")
        {
            SetHealthbar();
            enemyDamagePos = gameObject.transform.localPosition;
            enemyDamaged = true;
            enemyHP -= Choises.knifeDamage;
            ButtonBehiavor.damageDone = Choises.knifeDamage;
            healthBar.GetComponent<Slider>().value = enemyHP;

            if (enemyHP <= 0)
            {
                EnemyDied();
            }

            if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
        #endregion

        #region big piercing bullet
        if (collision.gameObject.name == "bigPiercingBulletCollider")
        {
            DamageEnemy();
        }
        #endregion
    }

    public void RandomDamPos()
    {
        enemyDamagePos = gameObject.transform.localPosition;
        ButtonBehiavor.damageDone = Choises.hammerDamage;
        enemyDamaged = true;
    }

    #endregion

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
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Invoke("UnStun", Choises.hammerStunTime);
    }

    public void UnStun()
    {
        if(gameObject.activeInHierarchy == true)
        {
            isStunned = false;
            SetStunOff();
            movingTowardsButton = StartCoroutine(MoveTowardsMainButton());
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void SetStunOff()
    {
        stunIcon.gameObject.SetActive(false);
    }
    #endregion

    #region Collision Exit
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Button") 
        {
            if(Choises.choseHealthBar == true)
            {
                isCollidingWithButton = false;

                if (isStunned == false)
                {
                    isAttacking = false;
                    if (enemyHP > 0) { if (movingTowardsButton == null) { movingTowardsButton = StartCoroutine(MoveTowardsMainButton()); } }
                }
            }
        }
    }
    #endregion


    #region DealDamage and knockback
    public static float bulletDamageAmount;
    public static float knockBackAmount;

    public Coroutine whiteFlashCoroutine;

    IEnumerator whiteFlashEffect()
    {
        whiteFlash.gameObject.SetActive(true);
        float startTime = Time.time;

        while (whiteFlash.GetComponent<Image>().color.a < 1)
        {
            float t = (Time.time - startTime) / 0.04f;
            Color lerpedColor = Color.Lerp(Color.clear, Color.white, t);
            whiteFlash.GetComponent<Image>().color = lerpedColor;
            yield return null;
        }

        yield return new WaitForSeconds(0.08f);

        startTime = Time.time;
        while (whiteFlash.GetComponent<Image>().color.a > 0)
        {
            float t = (Time.time - startTime) / 0.04f;
            Color lerpedColor = Color.Lerp(Color.white, Color.clear, t);
            whiteFlash.GetComponent<Image>().color = lerpedColor;
            yield return null;
        }

        whiteFlash.gameObject.SetActive(false);
        whiteFlashCoroutine = null;
    }

    public void DamageEnemy()
    {
        SetHealthbar();
     

        if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
        {
            whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
        }
       
          Vector2 buttonPosition = gameObject.transform.localPosition;

        float xOffset = Random.Range(-8, 8);
        float yOffset = Random.Range(-8, 8);

        Vector2 newPosition = new Vector2(
            buttonPosition.x + xOffset,
            buttonPosition.y + yOffset
        );
        enemyDamagePos = newPosition;

        enemyHP -= bulletDamageAmount;
        healthBar.GetComponent<Slider>().value = enemyHP;

        ButtonBehiavor.damageDone = bulletDamageAmount;
        enemyDamaged = true;
       
        //EnemyDie
        if (enemyHP <= 0)
        {
            EnemyDied();
        }
        else { StartCoroutine(KnockBack()); }
    }

    IEnumerator KnockBack()
    {
        isAttacking = false;
        knockBackAmount = 0.04f;
        yield return new WaitForSeconds(knockBackAmount);

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if(movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }
        movingTowardsButton = null;
        CheckPos();
        Invoke("CheckPos", 0.3f);
    }

    IEnumerator KnockBack2()
    {
        isAttacking = false;
        knockBackAmount = 1f;
        yield return new WaitForSeconds(knockBackAmount);

        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }
        movingTowardsButton = null;
        CheckPos();
    }

    private bool IsVisibleOnScreen()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x > 0 && viewportPosition.x < 1 && viewportPosition.y > 0 && viewportPosition.y < 1;
    }
    #endregion

    #region Death methods for all code
    private string originalParentName = "arrowPool";
    private string originalParentName2 = "arrowPool";
    public bool isEnemyDead;

    public void EnemyDied()
    {
        if (isEnemyDead == true)
        {
            return;
        }
        //FindObjectOfType<AudioManager>().Play("EnemyDeath");

        overlapp.DeathSounds();

        Choises.maxArrowsStuck -= arrowStuck;

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

        SettingsOptions.totalEnemiesDefeated += 1;

        #region point drop
        if (Choises.chosePointsDrop == true && Choises.maxPointDropOnScreen < 65 && HordeEnding.playingHordeEnding == false)
        {
            Choises.maxPointDropOnScreen += 1;
            GameObject basicPoints = ObjectPool.instance.GetBasicPointsFromPool();
            basicPoints.transform.localPosition = gameObject.transform.localPosition;
        }
        #endregion

        if(whiteFlashCoroutine != null) { StopCoroutine(whiteFlashCoroutine); }
        whiteFlashCoroutine = null;

        isEnemyDead = true;
        SetStunOff();
        enemyDiePos = gameObject.transform.position;
        smallEnemyDied = true;

        StopAllCoroutines();


        if (gameObject.tag == "Speedster") {
            if (HordeEnding.playingHordeEnding == false) 
            {
                ButtonClick.pointsGained += Choises.speedsterPoints;
                SettingsOptions.totalPoints += Choises.speedsterPoints;
                SettingsOptions.totalEnemyPoints += Choises.speedsterPoints;
            }
            SettingsOptions.totalSpeedstersDefeated += 1;
            SpawnEnemies.speedsterCount -= 1;

            particleMan.DeathParticle(enemyDiePos, ObjectPool.speedsterSize);
            if(SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.SmallEnemyPieces(enemyDiePos, 0.6f); }
            }
           
            texts.EnemyPointsPopUp(false, true);

            if (Choises.choseSkullHarvest == true)
            {
                #region skull
                GameObject speedsterSkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in speedsterSkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_Speedster")
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
                speedsterSkull.transform.localScale = new Vector2(0.4f, 0.4f);
                speedsterSkull.transform.position = gameObject.transform.position;
                #endregion
            }

            ObjectPool.instance.ReturnSpeedsterFromPool(gameObject); 
        }
        if (gameObject.tag == "SmallEnemy") {
            if (HordeEnding.playingHordeEnding == false)
            {
                ButtonClick.pointsGained += Choises.smallEnemyPoints;
                SettingsOptions.totalPoints += Choises.smallEnemyPoints;
                SettingsOptions.totalEnemyPoints += Choises.smallEnemyPoints;
            }
            SettingsOptions.totalSmallEnemiesDefeated += 1;
            SpawnEnemies.smallEnemyCount -= 1;

            particleMan.DeathParticle(enemyDiePos, ObjectPool.smallEnemySize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.SmallEnemyPieces(enemyDiePos, 0.9f); }
            }
            texts.EnemyPointsPopUp(true, false);

            if (Choises.choseSkullHarvest == true)
            {
                #region skull
                GameObject smallEnemySkull = ObjectPool.instance.GetSkullsFromPool();

                foreach (Transform child in smallEnemySkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_SmallEnemy")
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
                smallEnemySkull.transform.localScale = new Vector2(0.5f, 0.5f);
                smallEnemySkull.transform.position = gameObject.transform.position;
                #endregion
            }

            ObjectPool.instance.ReturnSmallEnemyFromPool(gameObject); 
        }
    }
    #endregion

}
