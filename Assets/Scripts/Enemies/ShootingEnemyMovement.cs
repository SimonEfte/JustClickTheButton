using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingEnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D objectCollider;


    private Camera mainCamera;

    public static bool shootingEnemyDied, enemyDamaged;
    public static Vector3 enemyDiePos, enemyDamagePos;

    public float enemyHp;

    public Transform mainButton;
    public Transform healthBar, stunIcon, whiteFlash;
    public bool isAttacking, attackecOnce;

    public static float bulletDamageAmount;
    public static float knockBackAmount;

    public float timeBetweenChange;
    public float moveSpeed;
    public Vector3 position;

    private float scaleTime;
    private bool shootBullet;
    private float chargedBulletSize;
    public static bool enemyAttacking;

    public Coroutine chargeCoroutine, movingTowardsButton;

    public GameObject particleManager, textPopUpManager;

    public static float sharpshooterShotWait, sharpshooterChargeTime, sniperShotWait, sniperChargeTime, gunnerShotWait, gunnerChargeTime, heavyShotWait, heavyShotChargeTime;
    private bool endingTransitionSetInactive;

    public bool dealingSpikeDamage;

    public float tickRate = 0.01f;
    private float timeSinceLastTick = 0.01f;
    public bool isGunnerContantWithButton;

    public bool isCollidingWithButton;

    public GameObject overlappSoundManager;
    public OverlappingSounds overlapp;

    public void Awake()
    {
        overlappSoundManager = GameObject.Find("OverlappingSounds");
        overlapp = overlappSoundManager.GetComponent<OverlappingSounds>();

        isCollidingWithButton = false;

        particleManager = GameObject.Find("ParticleSystems");
        textPopUpManager = GameObject.Find("TextPopUps");
        whiteFlash = transform.Find("WhiteFlash");
        healthBar = transform.Find("HealthBar");
        mainButton = GameObject.FindWithTag("Button").transform;
        stunIcon = transform.Find("Stun_Icon");

        sharpshooterShotWait = 2.2f;
        sharpshooterChargeTime = 0.65f;
        sniperShotWait = 4f;
        sniperChargeTime = 0.7f;
        gunnerShotWait = 2.3f;
        gunnerChargeTime = 0.45f;
        heavyShotWait = 8f;
        heavyShotChargeTime = 2f;

        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        objectCollider = GetComponent<CircleCollider2D>();
    }

    private bool playerDidDie;


    public void Update()
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
                if (gameObject.tag == "shootingEnemy")
                {
                    SpawnShootingEnemy.shootingEnemyCount -= 1;
                    ObjectPool.instance.ReturnShootingEnemyFromPool(gameObject);
                }

                if (gameObject.tag == "Sniper")
                {
                    SpawnShootingEnemy.sniperCount -= 1;
                    ObjectPool.instance.ReturnSniperEnemyFromPool(gameObject);
                }

                if (gameObject.tag == "HeavyShot")
                {
                    SpawnShootingEnemy.heavyShotCount -= 1;
                    ObjectPool.instance.ReturnHeavyShotFromPool(gameObject);
                }

                if (gameObject.tag == "RagingGunner")
                {
                    SpawnShootingEnemy.ragingGunnerCount -= 1;
                    ObjectPool.instance.ReturnGunnerFromPool(gameObject);
                }

                endingTransitionSetInactive = true;
            }
        }
        #endregion

        if (shootBullet == true)
        {
            if (gameObject.activeSelf) { chargeCoroutine = StartCoroutine(ChargeBullet()); }
            shootBullet = false;
        }

        #region Tiny Spike Damage
        if (isCollidingWithButton == true && Choises.chooseSpikes == true)
        {
            timeSinceLastTick += Time.deltaTime;

            while (timeSinceLastTick >= tickRate)
            {
                SetHealthbar();
                enemyHp -= Choises.spikeDamagePerSecond * tickRate;
                healthBar.GetComponent<Slider>().value = enemyHp;

                timeSinceLastTick -= tickRate;

                if (enemyHp <= 0)
                {
                    EnemyDied();
                }
            }
        }
        #endregion
    }

    #region ShootBullet and Charge Bullet
    IEnumerator ShootFirstBullet()
    {
        yield return new WaitForSeconds(1);
        shootBullet = true;
    }

    private IEnumerator ChargeBullet()
    {
        if (gameObject.tag == "shootingEnemy")
        {
            yield return new WaitForSeconds(sharpshooterShotWait);
        }

        if (gameObject.tag == "Sniper")
        {
            yield return new WaitForSeconds(sniperShotWait);
        }

        if (gameObject.tag == "HeavyShot")
        {
            yield return new WaitForSeconds(heavyShotWait);
        }

        if (gameObject.tag == "RagingGunner")
        {
            yield return new WaitForSeconds(gunnerShotWait);
        }

        if (Choises.playerDied == false)
        {
            shootBullet = true;
            GameObject enemyBullet = ObjectPool.instance.GetSmallEnemyBulletFromPool();
            if (gameObject.tag == "RagingGunner") { enemyBullet.tag = "RagingGunnerShot"; chargedBulletSize = 0.45f; enemyBullet.transform.localScale = new Vector2(0.35f, 0.35f); }
            if (gameObject.tag == "HeavyShot") { enemyBullet.tag = "EnemyBulletHeavyShot"; chargedBulletSize = 1.2f; enemyBullet.transform.localScale = new Vector2(0.9f, 0.9f); }
            if (gameObject.tag == "shootingEnemy") { enemyBullet.tag = "EnemyBullet"; chargedBulletSize = 0.6f; enemyBullet.transform.localScale = new Vector2(0.5f, 0.5f); }
            if (gameObject.tag == "Sniper") { enemyBullet.tag = "EnemyBulletSniper"; chargedBulletSize = 0.5f; enemyBullet.transform.localScale = new Vector2(0.4f, 0.4f); }

            float bulletSize;
            bulletSize = chargedBulletSize;

            enemyBullet.transform.localScale = Vector2.zero; // Start with zero scale
            enemyBullet.transform.localPosition = gameObject.transform.localPosition;

            if (gameObject.tag == "RagingGunner") { scaleTime = gunnerChargeTime; }
            if (gameObject.tag == "HeavyShot") { scaleTime = heavyShotChargeTime; }
            if (gameObject.tag == "shootingEnemy") { scaleTime = sharpshooterChargeTime; }
            if (gameObject.tag == "Sniper") { scaleTime = sniperChargeTime; }

            // Gradually increase the scale over 0.7 seconds

            float elapsedTime = 0f;

            while (elapsedTime < scaleTime)
            {
                enemyBullet.transform.localPosition = gameObject.transform.localPosition;
                float scale = Mathf.Lerp(0f, bulletSize, elapsedTime / scaleTime);
                enemyBullet.transform.localScale = new Vector2(scale, scale);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            enemyBullet.transform.localScale = new Vector2(bulletSize, bulletSize);

            yield return new WaitForSeconds(20);
            ObjectPool.instance.ReturnSmallEnemyBulletFromPool(enemyBullet);
        }
    }
    #endregion

    private Vector2 enemySize;
    #region Scale Up And Down Enemy
    IEnumerator ScaleDownEnemy()
    {
        if (gameObject.tag == "shootingEnemy")
        {
            enemySize = new Vector2(ObjectPool.shootingEnemySize,ObjectPool.shootingEnemySize);
        }
        if (gameObject.tag == "Sniper")
        {
            enemySize = new Vector2(ObjectPool.sniperSize, ObjectPool.sniperSize);
        }
        if (gameObject.tag == "HeavyShot")
        {
            enemySize = new Vector2(ObjectPool.heavyShotSize, ObjectPool.heavyShotSize);
        }

        if (gameObject.tag == "RagingGunner")
        {
            enemySize = new Vector2(ObjectPool.raginGunnerSize, ObjectPool.raginGunnerSize);
        }

        Vector2 zeroScale = new Vector2(0, 0);

        float duration = Random.Range(0.25f, 0.4f);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            gameObject.transform.localScale = Vector2.Lerp(enemySize, zeroScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (gameObject.tag == "shootingEnemy")
        {
            SpawnShootingEnemy.shootingEnemyCount -= 1;
            ObjectPool.instance.ReturnShootingEnemyFromPool(gameObject);
        }
        if (gameObject.tag == "Sniper")
        {
            SpawnShootingEnemy.sniperCount -= 1;
            ObjectPool.instance.ReturnSniperEnemyFromPool(gameObject);
        }
        if (gameObject.tag == "HeavyShot")
        {
            SpawnShootingEnemy.heavyShotCount -= 1;
            ObjectPool.instance.ReturnHeavyShotFromPool(gameObject);
        }

        if (gameObject.tag == "RagingGunner")
        {
            SpawnShootingEnemy.ragingGunnerCount -= 1;
            ObjectPool.instance.ReturnGunnerFromPool(gameObject);
        }
    }

    IEnumerator ScaleUpEnemy()
    {
        if (gameObject.tag == "shootingEnemy")
        {
            enemySize = new Vector2(ObjectPool.shootingEnemySize, ObjectPool.shootingEnemySize);
        }
        if (gameObject.tag == "Sniper")
        {
            enemySize = new Vector2(ObjectPool.sniperSize, ObjectPool.sniperSize);
        }
        if (gameObject.tag == "HeavyShot")
        {
            enemySize = new Vector2(ObjectPool.heavyShotSize, ObjectPool.heavyShotSize);
        }

        if (gameObject.tag == "RagingGunner")
        {
            enemySize = new Vector2(ObjectPool.raginGunnerSize, ObjectPool.raginGunnerSize);
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

    IEnumerator SetTrigger()
    {
        yield return new WaitForSeconds(0.65f);
        //objectCollider.isTrigger = false;
    }

    #region OnEnable
    private void OnEnable()
    {
        if(gameObject.tag != "RagingGunner")
        {
            objectCollider.isTrigger = true;
            StartCoroutine(SetTrigger());
        }

        isGunnerContantWithButton = false;
        arrowStuck = 0;
        dealingSpikeDamage = false;
        playerDidDie = false;
        StartCoroutine(ScaleUpEnemy());
        endingTransitionSetInactive = false;
        attackecOnce = false;
        hitChargedBullet = false;
        hitBigPiercing = false;

        stunIcon.gameObject.SetActive(false);
        whiteFlash.gameObject.SetActive(false);

        isEnemyDead = false;
        isStunned = false;
        if (gameObject.tag == "shootingEnemy")
        {
            enemyHp = Choises.sharpshooterHP;
            float randomSpeed1 = Random.Range(1.4f, 2f);
            moveSpeed = randomSpeed1;

            int randomChange = Random.Range(3,5);
            timeBetweenChange = randomChange;
            StartCoroutine(CheckPos());
        }
        if (gameObject.tag == "Sniper")
        {
            enemyHp = Choises.sniperHP;
            float randomSpeed2 = Random.Range(4f, 5f);
            moveSpeed = randomSpeed2;

            int randomChange = Random.Range(2, 4);
            timeBetweenChange = randomChange;
            StartCoroutine(CheckPos());
        }
        if (gameObject.tag == "HeavyShot")
        {
            enemyHp = Choises.heavyshotHP;
            float randomSpeed3 = Random.Range(0.5f, 0.6f);
            moveSpeed = randomSpeed3;

            int randomChange = Random.Range(6, 7);
            timeBetweenChange = randomChange;
            StartCoroutine(CheckPos());
        }

        if (gameObject.tag == "RagingGunner")
        {
            enemyHp = Choises.ragingGunnerHP;
            if(HordeEnding.playingHordeEnding == false)
            {
                float randomGunnerspeed = Random.Range(1.7f, 2.3f);
                moveSpeed = randomGunnerspeed;
            }
            if (HordeEnding.playingHordeEnding == true)
            {
                float randomGunnerspeed = Random.Range(2.5f, 3f);
                moveSpeed = randomGunnerspeed;
            }
            StartCoroutine(ShootFirstBullet());
            movingTowardsButton = StartCoroutine(MoveTowardsMainButton());
        }

        healthBar.gameObject.SetActive(false);
        healthBar.gameObject.GetComponent<Slider>().maxValue = enemyHp;
        healthBar.gameObject.GetComponent<Slider>().value = enemyHp;

        SetVariables();
    }
    #endregion

    public void CheckColl()
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int enemyBulletLayer = LayerMask.NameToLayer("EnemyBullet");

        Physics2D.IgnoreLayerCollision(enemyLayer, enemyBulletLayer, true);
    }

    #region Raging Gunner Move Towards Button. And Dealing melee damage
    private IEnumerator MoveTowardsMainButton()
    {
        if (isAttacking == false)
        {
            while (Vector3.Distance(transform.position, mainButton.position) > 0.05f)
            {
                dealingSpikeDamage = false;
                Vector3 direction = (mainButton.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime; 
                yield return null;
            }
        }
    }

    private IEnumerator DamageButton()
    {
        while (isAttacking == true || attackecOnce == true)
        {
            if (isAttacking == true)
            {
                Choises.buttonHealth -= Choises.raginGunnerMeleeDamage; TextPopUpBehavior.enemyDamageAmount = Choises.raginGunnerMeleeDamage; 

                Vector2 enemyPosition = gameObject.transform.localPosition;
                Vector2 mainButtonPosition = mainButton.transform.localPosition;

                Vector2 direction = (mainButtonPosition - enemyPosition).normalized;

                float distance = 24f;
                Vector2 newDamagePos = enemyPosition + direction * distance;

                enemyDamagePos = newDamagePos;

               enemyAttacking = true;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }
    #endregion

    #region Collision Exit
    void OnCollisionExit2D(Collision2D other)
    {
        if(gameObject.tag == "RagingGunner")
        {
            if (other.gameObject.tag == "Button")
            {
                isGunnerContantWithButton = false;

                if (isStunned == false)
                {
                    isAttacking = false;
                    if (enemyHp > 0) { if (movingTowardsButton == null) { movingTowardsButton = StartCoroutine(MoveTowardsMainButton()); } }
                    if (chargeCoroutine == null) { shootBullet = true; }
                }
            }
        }

        if (other.gameObject.tag == "Button")
        {
            isCollidingWithButton = false;

            dealingSpikeDamage = false;
        }
    }
    #endregion

    #region CheckPos
    IEnumerator CheckPos()
    {
        yield return new WaitForSeconds(0.1f);
        Invoke("CheckColl", 5);
        StartCoroutine(ShootFirstBullet());

        //gameObject.GetComponent<Collider2D>().isTrigger = true;
        position = transform.localPosition;

        int randomDir = Random.Range(1, 3);
        int randomDir2 = Random.Range(1, 5);

        if (Choises.chooseRocket == false && Choises.choseButtonBounceCharge == false && Choises.chooseControllableButton == false)
        {
            if (position.y >= 355)
            {
                if (randomDir == 1) { StartCoroutine(ChangeDirectionRightToLeft()); }
                if (randomDir == 2) { StartCoroutine(ChangeDirectionRightToRight()); }
            }
            else if (position.y <= -355)
            {
                if (randomDir == 1) { StartCoroutine(ChangeDirectionRightToLeft()); }
                if (randomDir == 2) { StartCoroutine(ChangeDirectionRightToRight()); }
            }

            if (position.x >= 680)
            {
                if (randomDir == 1) { StartCoroutine(ChangeDirectionUpToDown()); }
                if (randomDir == 2) { StartCoroutine(ChangeDirectionDownToUp()); }
            }
            else if (position.x <= -680)
            {
                if (randomDir == 1) { StartCoroutine(ChangeDirectionUpToDown()); }
                if (randomDir == 2) { StartCoroutine(ChangeDirectionDownToUp()); }
            }
        }
        if (Choises.chooseRocket == true || Choises.choseButtonBounceCharge == true || Choises.chooseControllableButton == true)
        {
           if(randomDir2 == 1) { StartCoroutine(ChangeDirectionRightToLeft()); }
            if (randomDir2 == 2) { StartCoroutine(ChangeDirectionRightToRight()); }
            if (randomDir2 == 3) { StartCoroutine(ChangeDirectionUpToDown()); }
            if (randomDir2 == 4) { StartCoroutine(ChangeDirectionDownToUp()); }
        }
       
    }
    #endregion

    #region Change direction - idle movement
    private bool isMovingRight = true;
    private bool isMovingLeft = true;
    private bool isMovingUp = true;
    private bool isMovingDown = true;

    public Coroutine rightRoRight;

    private IEnumerator ChangeDirectionRightToRight()
    {
        while (true)
        {
            ChangeDirectionRight(isMovingRight);

            yield return new WaitForSeconds(timeBetweenChange);

            isMovingRight = !isMovingRight;
        }
    }

    private void ChangeDirectionRight(bool moveRight)
    {
        if (isStunned == false)
        {
            Vector2 direction = moveRight ? Vector2.right : Vector2.left;
            rb.velocity = direction * moveSpeed;
        }
    }


    private IEnumerator ChangeDirectionRightToLeft()
    {
        while (true)
        {
            ChangeDirectionLeft(isMovingLeft);

            yield return new WaitForSeconds(timeBetweenChange);

            isMovingLeft = !isMovingLeft; 
        }
    }

    private void ChangeDirectionLeft(bool moveRight)
    {
        if (isStunned == false)
        {
            Vector2 direction = moveRight ? Vector2.left : Vector2.right;
            rb.velocity = direction * moveSpeed;
        }
    }


    private IEnumerator ChangeDirectionUpToDown()
    {
        while (true)
        {
            ChangeDirectionUp(isMovingUp);

            yield return new WaitForSeconds(timeBetweenChange);

            isMovingUp = !isMovingUp; 
        }
    }

    private void ChangeDirectionUp(bool moveUp)
    {
        if (isStunned == false)
        {
            Vector2 direction = moveUp ? Vector2.up : Vector2.down;
            rb.velocity = direction * moveSpeed;
        }
    }

    private IEnumerator ChangeDirectionDownToUp()
    {
        while (true)
        {
            ChangeDirectionDown(isMovingDown);

            yield return new WaitForSeconds(timeBetweenChange);

            isMovingDown = !isMovingDown; 
        }
    }

    private void ChangeDirectionDown(bool moveUp)
    {
        if (isStunned == false)
        {
            Vector2 direction = moveUp ? Vector2.down : Vector2.up;
            rb.velocity = direction * moveSpeed;
        }
    }
    #endregion

    #region Set Variables
    public void SetVariables()
    {
        if (gameObject.tag == "shootingEnemy")
        {
            enemyHp = Choises.sharpshooterHP;
        }
        if (gameObject.tag == "Sniper")
        {
            enemyHp = Choises.sniperHP;
        }
        if (gameObject.tag == "RagingGunner") 
        {
            enemyHp = Choises.ragingGunnerHP;
        }
        if (gameObject.tag == "HeavyShot")
        {
            enemyHp = Choises.heavyshotHP;
        }


        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(false);
            healthBar.gameObject.GetComponent<Slider>().maxValue = enemyHp;
            healthBar.gameObject.GetComponent<Slider>().value = enemyHp;
        }
    }
    #endregion

    private bool hitChargedBullet, hitBigPiercing;
    private Coroutine charge, bigPiecring;

    IEnumerator SetChargeFalse()
    {
        yield return new WaitForSeconds(0.3f);
        hitChargedBullet = false;
        charge = null;
    }

    IEnumerator SetBigPiecringFalse()
    {
        yield return new WaitForSeconds(0.4f);
        hitBigPiercing = false;
        bigPiecring = null;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        #region is attacking, dealing damage to button
        if(gameObject.tag == "RagingGunner")
        {
            if (collision.gameObject.tag == "Button")
            {
                if (isAttacking == false)
                {
                    isGunnerContantWithButton = true;
                    if (movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }
                    movingTowardsButton = null;
                    isAttacking = true;
                    if (enemyHp > 0 && attackecOnce == false) { StartCoroutine(DamageButton()); }
                    attackecOnce = true;
                    if (chargeCoroutine != null) { StopCoroutine(chargeCoroutine); chargeCoroutine = null; }
                    shootBullet = false;
                }
            }
        }
        #endregion

        #region Damaged by spikes
        if (collision.gameObject.tag == "Button")
        {
            isCollidingWithButton = true;
        }
        #endregion

        #region Bullet hit - damage enemy
        if (collision.gameObject.tag == "bullets" || collision.gameObject.tag == "HomingBullet" || collision.gameObject.tag == "BulletBounced" || collision.gameObject.name == "ShotgunBullet(Clone)" || collision.gameObject.tag == "Gun3Bullet")
        {
            if(gameObject.tag == "RagingGunner")
            {
                DamageEnemy();
            }
        }
        #endregion

        if (collision.gameObject.tag == "bullets")
        {
            //Debug.Log("Hit Bullet");
            if (gameObject.tag == "shootingEnemy")
            {
                Debug.Log("Hit Center Collider");
            }
            if (gameObject.tag == "Sniper")
            {
                Debug.Log("Hit Center Collider");
            }
        }
    }

    public int arrowStuck;

    //Piercing not enabled
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Bullet hit - damage enemy
        if (collision.gameObject.tag == "bullets" || collision.gameObject.tag == "HomingBullet" || collision.gameObject.tag == "BulletBounced"  || collision.gameObject.name == "ShotgunBullet(Clone)" || collision.gameObject.tag == "Gun3Bullet" || collision.gameObject.tag == "TrippleBullet")
        {
            DamageEnemy();
        }
        #endregion

        #region Bullet hit - Charged Bullet
        if (collision.gameObject.tag == "ChargedBullet")
        {
            if (hitChargedBullet == false)
            {
                DamageEnemy();
                if(enemyHp > 0) { if (charge == null) { charge = StartCoroutine(SetChargeFalse()); } }
            }
            hitChargedBullet = true;
        }
        #endregion

        #region Bullet hit - Big Piercing Bullet
        if (collision.gameObject.name == "bigPiercingBulletCollider")
        {
            if (hitBigPiercing == false)
            {
                DamageEnemy();
                if (enemyHp > 0) { if (bigPiecring == null) { bigPiecring = StartCoroutine(SetBigPiecringFalse()); } }
            }
            hitBigPiercing = true;
        }
        #endregion

        #region spinning spike/sword
        if (collision.gameObject.tag == "SpinningSword")
        {
            if (Choises.chooseBigSpike == true)
            {
                SetHealthbar();
                enemyDamagePos = gameObject.transform.localPosition;
                enemyHp -= Choises.bigSpikeDamage;
                healthBar.GetComponent<Slider>().value = enemyHp;

                ButtonBehiavor.damageDone = Choises.bigSpikeDamage;
                enemyDamaged = true;

                if (enemyHp <= 0)
                {
                    EnemyDied();
                }
            }

            TriggerWhiteFlahs();
        }
        #endregion

        #region stabbing spikes
        if (collision.gameObject.tag == "StabbingSpike")
        {
            if (Choises.chooseStabbingSpikes == true)
            {
                SetHealthbar();
                enemyDamagePos = gameObject.transform.localPosition;
                enemyHp -= Choises.stabbingSpikeDamage;
                healthBar.GetComponent<Slider>().value = enemyHp;

                ButtonBehiavor.damageDone = Choises.stabbingSpikeDamage;
                enemyDamaged = true;

                if (enemyHp <= 0)
                {
                    EnemyDied();
                }
            }

            TriggerWhiteFlahs();
        }
        #endregion

        #region SawBlade
        if (collision.gameObject.tag == "SawBlade")
        {
            SetHealthbar();
            enemyDamagePos = gameObject.transform.localPosition;
            enemyHp -= Choises.sawBladeDamage;
            healthBar.GetComponent<Slider>().value = enemyHp;

            ButtonBehiavor.damageDone = Choises.sawBladeDamage;
            enemyDamaged = true;

            if (enemyHp <= 0)
            {
                EnemyDied();
            }

            TriggerWhiteFlahs();
        }
        #endregion

        #region Hammer
        if (collision.gameObject.tag == "Hammer")
        {
            SetHealthbar();
            Stun();
            enemyDamagePos = gameObject.transform.localPosition;
            enemyHp -= Choises.hammerDamage;
            healthBar.GetComponent<Slider>().value = enemyHp;

            ButtonBehiavor.damageDone = Choises.hammerDamage;
            enemyDamaged = true;

            if (enemyHp <= 0)
            {
                EnemyDied();
            }

            TriggerWhiteFlahs();
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
            enemyDamagePos = gameObject.transform.localPosition;
            enemyDamaged = true;
            ButtonBehiavor.damageDone = Choises.knifeDamage;
            enemyHp -= Choises.knifeDamage;
            healthBar.GetComponent<Slider>().value = enemyHp;

            if (enemyHp <= 0)
            {
                EnemyDied();
            }

            TriggerWhiteFlahs();
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

    #region TriggerWhiteFlash
    public void TriggerWhiteFlahs()
    {
        if(SettingsOptions.disableWhiteFlash == 0)
        {
            if (whiteFlashCoroutine == null && isEnemyDead == false)
            {
                whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
            }
        }
    }
    #endregion

    #region WhiteFlash
    public Coroutine whiteFlashCoroutine;

    IEnumerator whiteFlashEffect()
    {
        whiteFlash.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.09f);

        whiteFlash.gameObject.SetActive(false);
        whiteFlashCoroutine = null;
    }
    #endregion

    #region Stun Effect
    public bool isStunned;
    public void Stun()
    {
        stunIcon.gameObject.SetActive(true);
        isAttacking = false;
        isStunned = true;
        shootBullet = false;

        if(gameObject.tag == "RagingGunner")
        {
            if(movingTowardsButton != null) { StopCoroutine(movingTowardsButton); }
            if (chargeCoroutine != null) { StopCoroutine(chargeCoroutine); }
        }
        else
        {
            if (chargeCoroutine != null) { StopCoroutine(chargeCoroutine); }
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       
        Invoke("UnStun", Choises.hammerStunTime);
    }

    public void UnStun()
    {
        if (gameObject.activeInHierarchy == true)
        {
            isStunned = false;
            SetStunOff();
            shootBullet = true;

            if (gameObject.tag == "RagingGunner")
            {
               if(isGunnerContantWithButton == false) { movingTowardsButton = StartCoroutine(MoveTowardsMainButton()); }
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    public void SetStunOff()
    {
        stunIcon.gameObject.SetActive(false);
    }
    #endregion

    #region Damage Enemy
    public void DamageEnemy()
    {
        SetHealthbar();
       

        if (whiteFlashCoroutine == null && isEnemyDead == false && SettingsOptions.disableWhiteFlash == 0)
        {
            whiteFlashCoroutine = StartCoroutine(whiteFlashEffect());
        }

        Vector2 buttonPosition = gameObject.transform.localPosition;

        float xOffset = Random.Range(-14, 14);
        float yOffset = Random.Range(-14, 14);

        Vector2 newPosition = new Vector2(
            buttonPosition.x + xOffset,
            buttonPosition.y + yOffset
        );
        enemyDamagePos = newPosition;

        enemyHp -= bulletDamageAmount;
        healthBar.GetComponent<Slider>().value = enemyHp;

        ButtonBehiavor.damageDone = bulletDamageAmount;
        enemyDamaged = true;
        //KnockBack();

        if (enemyHp <= 0)
        {
            EnemyDied();
        }
    }
    #endregion

    #region knockback or lack there of
    public void KnockBack()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    #endregion

    #region enemy dies
    public bool isEnemyDead;
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

        #region Arrow stuck
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

        ParticleEffectSystems particleMan = particleManager.GetComponent<ParticleEffectSystems>();
        TextPopUpBehavior texts = textPopUpManager.GetComponent<TextPopUpBehavior>();

        enemyDiePos = gameObject.transform.position;
        shootingEnemyDied = true;

        StopAllCoroutines();

        if (gameObject.tag == "shootingEnemy")
        {
            SpawnShootingEnemy.shootingEnemyCount -= 1;
            if (HordeEnding.playingHordeEnding == false)
            {
                ButtonClick.pointsGained += Choises.shootingEnemyPoints;
                SettingsOptions.totalPoints += Choises.shootingEnemyPoints;
                SettingsOptions.totalEnemyPoints += Choises.shootingEnemyPoints;
            }
            SettingsOptions.totalSharpshootersDefeated += 1;

            particleMan.DeathParticle(enemyDiePos, ObjectPool.shootingEnemySize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.ShootingEnemyPieces(enemyDiePos, ObjectPool.shootingEnemySize); }
            }
            texts.ShootingEnemyPopUp(true, false, false, false);

            if (Choises.choseSkullHarvest == true)
            {
                #region skull
                GameObject sharpshooterSkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in sharpshooterSkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_Sharpshooter")
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
                sharpshooterSkull.transform.localScale = new Vector2(0.6f, 0.6f);
                sharpshooterSkull.transform.position = gameObject.transform.position;
                #endregion
            }

            ObjectPool.instance.ReturnShootingEnemyFromPool(gameObject);
        }
        if (gameObject.tag == "Sniper")
        {
            SpawnShootingEnemy.sniperCount -= 1;
            if (HordeEnding.playingHordeEnding == false)
            {
                ButtonClick.pointsGained += Choises.sniperPoints;
                SettingsOptions.totalPoints += Choises.sniperPoints;
                SettingsOptions.totalEnemyPoints += Choises.sniperPoints;
            }
            SettingsOptions.totalSnipersDefeated += 1;

            particleMan.DeathParticle(enemyDiePos, ObjectPool.sniperSize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.ShootingEnemyPieces(enemyDiePos, ObjectPool.sniperSize); }
            }
            texts.ShootingEnemyPopUp(false, true, false, false);

            if (Choises.choseSkullHarvest == true)
            {
                #region skull
                GameObject sniperSkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in sniperSkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_Sniper")
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
                sniperSkull.transform.localScale = new Vector2(0.35f, 0.35f);
                sniperSkull.transform.position = gameObject.transform.position;
                #endregion
            }

            ObjectPool.instance.ReturnSniperEnemyFromPool(gameObject);
        }

        if (gameObject.tag == "RagingGunner")
        {
            SpawnShootingEnemy.ragingGunnerCount -= 1;
            if (HordeEnding.playingHordeEnding == false)
            { 
                ButtonClick.pointsGained += Choises.raginGunnerPoints;
                SettingsOptions.totalPoints += Choises.raginGunnerPoints;
                SettingsOptions.totalEnemyPoints += Choises.raginGunnerPoints;
            }
            SettingsOptions.totalRagingGunnerDefeated += 1;

            particleMan.DeathParticle(enemyDiePos, ObjectPool.raginGunnerSize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.TitanPieces(enemyDiePos, ObjectPool.raginGunnerSize - 0.6f); }
            }
            texts.ShootingEnemyPopUp(false, false, true, false);

            if (Choises.choseSkullHarvest == true)
            {
                #region skull
                GameObject ragingGunnerSkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in ragingGunnerSkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_RagingGunner")
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
                ragingGunnerSkull.transform.localScale = new Vector2(0.4f, 0.4f);
                ragingGunnerSkull.transform.position = gameObject.transform.position;
                #endregion
            }
            ObjectPool.instance.ReturnGunnerFromPool(gameObject);
        }

        if (gameObject.tag == "HeavyShot")
        {
            SpawnShootingEnemy.heavyShotCount -= 1;
            if (HordeEnding.playingHordeEnding == false) 
            {
                ButtonClick.pointsGained += Choises.heavyShotPoints;
                SettingsOptions.totalPoints += Choises.heavyShotPoints;
                SettingsOptions.totalEnemyPoints += Choises.heavyShotPoints;
            }
            SettingsOptions.totalHeavyshotDefeated += 1;

            particleMan.DeathParticle(enemyDiePos, ObjectPool.heavyShotSize);
            if (SettingsOptions.disableBrokenPieces == 0)
            {
                if (Choises.maxBrokenPieces < 100) { particleMan.HeavyshotPieces(enemyDiePos, ObjectPool.heavyShotSize - 0.3f); }
            }
            texts.ShootingEnemyPopUp(false, false, false, true);

            if (Choises.choseSkullHarvest == true)
            {
                #region skull
                GameObject heavyShotSkull = ObjectPool.instance.GetSkullsFromPool();
                foreach (Transform child in heavyShotSkull.transform)
                {
                    // Check if the current child has the specified name
                    if (child.name == "Skull_Heavyshot")
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
                heavyShotSkull.transform.localScale = new Vector2(0.5f, 0.5f);
                heavyShotSkull.transform.position = gameObject.transform.position;
                #endregion
            }

            ObjectPool.instance.ReturnHeavyShotFromPool(gameObject);
        }
    }
    #endregion
}
