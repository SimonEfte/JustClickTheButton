using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossMechanics : MonoBehaviour
{
    public GameObject bossArena, boss, bossHealthbar; 
    public static bool fightingBossFight;

    public Transform mainButton, mainBulletParent;

    public Slider bossHealthSlider;
    public static float bossHealth;
    public TextMeshProUGUI bossHealthText;

    public static bool bossDamaged, bossArrowDamaged, bossDied, doneCharging;
    public static Vector2 bossDamagedPos, bossArrowDamagedPos, bossDiePos;

    public Coroutine startAttackCoroutine, bigBulletCoroutine, movingCoroutine, swordCoroutine;

    public float healthThreshold1, healthThreshold2, healthThreshold3, healthThreshold4, healthThreshold5, healthThreshold6, healthThreshold7, healthThreshold8, healthThreshold9, healthThreshold10, healthThreshold11;
    public bool reachedThrehold1, reachedThrehold2, reachedThrehold3, reachedThrehold4, reachedThrehold5, reachedThrehold6, reachedThrehold7, reachedThrehold8, reachedThrehold9, reachedThrehold10, reachedThrehold11;
    public bool shootBigBullets;
    public bool setSmallShield1;

    public Transform leftPosObject, rightPosObject;

    public float smallBulletSize, smallBulletShootTime;

    private float timeToChangeDirection;
    private float timeElapsed = 0f;
    public float bossMoveSpeed;

    public static float bossBulletDamage;

    private bool isShootingSmallBullet, isBossMoving, stopShootingBigBullets;

    public GameObject spinningShield, bossSword;
    public float smallShielsspeed, bouncyShieldSpeed;

    public Transform centerObject;
    public Transform[] smallShields;
    public float orbitSpeed = 50f;
    public float orbitRadius = 5f;

    public static float bigBulletChargeTime, bigBulletSize;
    public static int bigBulletsCount;

    public static float bossShieldBounceDamage;

    public int arrowStuck;
    public AudioManager audioManager;

    public void Awake()
    {
        //fightingBossFight = true;
        if (fightingBossFight == true)
        {
            boss.SetActive(true);
            bossArena.SetActive(true);
            bossHealthbar.SetActive(true);
        }
    }

    public void OnEnable()
    {
    
        bossSword.transform.rotation = Quaternion.Euler(0f, 0f, -180);

        if (ButtonClick.level > 75)
        {
            scalingIncrease = 150;
            bossHealthScaling = (ButtonClick.level - 75) * scalingIncrease;
        }

        bossHealth = 40000 + bossHealthScaling;
        healthThreshold1 = 39000 + bossHealthScaling;
        healthThreshold2 = 37000 + bossHealthScaling;
        healthThreshold3 = 34000 + bossHealthScaling;
        healthThreshold4 = 30000 + bossHealthScaling;
        healthThreshold5 = 27000 + bossHealthScaling;
        healthThreshold6 = 24000 + bossHealthScaling;
        healthThreshold7 = 22000 + bossHealthScaling;
        healthThreshold8 = 17000 + bossHealthScaling;
        healthThreshold9 = 12500 + bossHealthScaling;
        healthThreshold10 = 7000 + bossHealthScaling;
        healthThreshold11 = 4000 + bossHealthScaling;

        bossHealthSlider.minValue = 0;
        bossHealthSlider.maxValue = bossHealth;
        bossHealthSlider.value = bossHealth;

        bouncyShieldSpeed = 40;
        orbitSpeed = 50f;
        gameObject.transform.localPosition = new Vector2(0, 1120);
        arrowStuck = 0;
        playerDied = true;
        bossDied = false;
        if (gameObject.activeInHierarchy == true)
        {
            Invoke("StartBossFight", Choises.bossEndingTransitionTime);
        }
    }

    public float bossHealthScaling;
    public float scalingIncrease;
    public float swordYPos;

    public float damageScaling, damaceScalingIncrease;

    public void StartBossFight()
    {

        bossShieldBounceDamage = 15;

        bigBulletSize = 1.9f;
        bigBulletChargeTime = 0.37f;
        bigBulletsCount = 7;

        isBossMoving = true;
        isShootingSmallBullet = true;

        if (ButtonClick.level > 75)
        {
            damaceScalingIncrease = 0.15f;
            damageScaling = (ButtonClick.level - 75) * damaceScalingIncrease;
        }

        bossBulletDamage = 30 + damageScaling;
        bossMoveSpeed = 6;
        smallBulletShootTime = 0.55f;

        

        reachedThrehold1 = false;
        reachedThrehold2 = false;
        reachedThrehold3 = false;
        reachedThrehold4 = false;
        reachedThrehold5 = false;
        reachedThrehold6 = false;
        reachedThrehold7 = false;
        reachedThrehold8 = false;
        reachedThrehold9 = false;
        reachedThrehold10 = false;
        reachedThrehold11 = false;


        InvokeRepeating("ShootAFewBullets", 1f, smallBulletShootTime);
        startAttackCoroutine = StartCoroutine(ShootAFewBullets());
    }


    void Update()
    {
        centerObject.transform.localPosition = gameObject.transform.localPosition;

        #region Threshold 1
        if (bossHealth < healthThreshold1 && reachedThrehold1 == false)
        {
            smallBulletSize = 1f;
            smallBulletShootTime = 0.45f;
            reachedThrehold1 = true;
            movingCoroutine = StartCoroutine(MoveBoss());
        }
        #endregion

        #region Threshold 2
        if (bossHealth < healthThreshold2 && reachedThrehold2 == false)
        {
            centerObject.gameObject.SetActive(true);
            setSmallShield1 = true;
            SpawnSmallShield(smallShields[0]);

            reachedThrehold2 = true;
            smallBulletSize = 1.05f;
            smallBulletShootTime = 0.4f;
            bossMoveSpeed = 15;
        }
        #endregion

        #region Threshold 3
        if (bossHealth < healthThreshold3 && reachedThrehold3 == false)
        {
            SpawnSmallShield(smallShields[1]);
            SpawnSmallShield(smallShields[2]);

            reachedThrehold3 = true;
            if(movingCoroutine != null) { StopCoroutine(movingCoroutine); movingCoroutine = null; }
            if (startAttackCoroutine != null) { StopCoroutine(startAttackCoroutine); movingCoroutine = null; }
            StartCoroutine(ShootBigBullets());
        }
        #endregion

        #region SHOOT BIG BULLETS
        if (shootBigBullets == true)
        {
            StartCoroutine(ShootBigBullets());
            shootBigBullets = false;
        }
        #endregion

        #region Threshold 4
        if (bossHealth < healthThreshold4 && reachedThrehold4 == false)
        {
            orbitSpeed = 65;
            reachedThrehold4 = true;

            SpawnSmallShield(smallShields[3]);
            SpawnSmallShield(smallShields[4]);
        }
        #endregion

        #region Threshold 5
        if (bossHealth < healthThreshold5 && reachedThrehold5 == false)
        {
            reachedThrehold5 = true;

            SpawnSmallShield(smallShields[5]);
            SpawnSmallShield(smallShields[6]);
            SpawnSmallShield(smallShields[7]);

            smallBulletShootTime = 0.8f;
            bossMoveSpeed = 35;
        }
        #endregion

        #region Threshold 6
        if (bossHealth < healthThreshold6 && reachedThrehold6 == false)
        {
            orbitSpeed = 80;

            reachedThrehold6 = true;

            smallShields[4].gameObject.SetActive(true);
            smallShields[5].gameObject.SetActive(true);
            smallShields[6].gameObject.SetActive(true);
            smallShields[7].gameObject.SetActive(true);

            smallBulletShootTime = 0.7f;
            bossMoveSpeed = 37;

            bigBulletsCount = 10;
        }
        #endregion

        #region Threshold 7
        if (bossHealth < healthThreshold7 && reachedThrehold7 == false)
        {
            reachedThrehold7 = true;
            spinningShield.SetActive(true);
            bigBulletsCount = 11;
        }
        #endregion

        #region Threshold 8
        if (bossHealth < healthThreshold8 && reachedThrehold8 == false)
        {
            orbitSpeed = 110;

            bouncyShieldSpeed = 45;

            smallBulletShootTime = 0.7f;
            bossSword.SetActive(true);
            //stopShootingBigBullets = true;
            //if (startAttackCoroutine != null) { StopCoroutine(startAttackCoroutine); }

            reachedThrehold8 = true;

            swordStrikeDuration = 0.55f;
            swordPauseTime = 1.7f;
            StartCoroutine(StrikeSwordCoroutine());
        }
        #endregion

        #region Threshold 9
        if (bossHealth < healthThreshold9 && reachedThrehold9 == false)
        {
            bouncyShieldSpeed = 60;

            smallBulletShootTime = 0.5f;
            bossMoveSpeed = 45;
            reachedThrehold9 = true;

            swordStrikeDuration = 0.42f;
            swordPauseTime = 1f;
        }
        #endregion

        #region Threshold 10
        if (bossHealth < healthThreshold10 && reachedThrehold10 == false)
        {
            bouncyShieldSpeed = 70;

            smallBulletShootTime = 0.4f;
            reachedThrehold10 = true;

            swordStrikeDuration = 0.41f;
            swordPauseTime = 0.6f;
        }
        #endregion

        #region Threshold 11
        if (bossHealth < healthThreshold11 && reachedThrehold11 == false)
        {
            reachedThrehold11 = true;
            bossMoveSpeed = 70;

            swordStrikeDuration = 0.37f;
            swordPauseTime = 0.4f;
        }
        #endregion

        bossSword.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - swordYPos);

        spinningShield.transform.position = gameObject.transform.position;
        spinningShield.transform.Rotate(Vector3.forward * bouncyShieldSpeed * Time.deltaTime);

        #region ROTATING SHIELDS
        if (setSmallShield1 == true)
        {
            for (int i = 0; i < smallShields.Length; i++)
            {
                // Calculate the angle for each shield based on its index
                float angle = Time.time * orbitSpeed + i * (360f / smallShields.Length);

                // Calculate the position around the centerObject using polar coordinates
                float x = centerObject.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius;
                float y = centerObject.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius;

                smallShields[i].position = new Vector2(x, y);
                smallShields[i].rotation = Quaternion.Euler(0, 0, 0);

                smallShields[i].RotateAround(centerObject.position, Vector3.forward, orbitSpeed * Time.deltaTime);
            }
        }
        #endregion

        #region Player Died
        if(Choises.didPlayerDie == true && playerDied == true)
        {
            playerDied = false;

            if (startAttackCoroutine != null) { StopCoroutine(startAttackCoroutine); startAttackCoroutine = null; }
            if (bigBulletCoroutine != null) { StopCoroutine(bigBulletCoroutine); bigBulletCoroutine = null; }
            if (movingCoroutine != null) { StopCoroutine(movingCoroutine); movingCoroutine = null; }
            if (swordCoroutine != null) { StopCoroutine(swordCoroutine); swordCoroutine = null; }

            centerObject.gameObject.SetActive(false);
            spinningShield.SetActive(false);
            bossSword.SetActive(false);
            gameObject.SetActive(false);

            gameObject.SetActive(false);
        }
        #endregion
    }

    #region Small shield spawn
    public void SpawnSmallShield(Transform shield)
    {
        shield.gameObject.SetActive(true);
        shield.GetComponent<Animation>().Play("ShieldAnim");
    }
    #endregion

    public bool playerDied;
    public float swordStrikeDuration, swordPauseTime;

    #region Sword Strike
    IEnumerator StrikeSwordCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(swordPauseTime);
            if (swordStrikeDuration > 0.4f)
            {
                int random = Random.Range(1, 3);
                if (random == 1) { audioManager.Play("swordSwingSlow1"); }
                if (random == 2) { audioManager.Play("swordSwingSlow2"); }
            }

            if (swordStrikeDuration <= 0.4f)
            {
                int random = Random.Range(1, 3);
                if (random == 1) { audioManager.Play("swordSwingFast1"); }
                if (random == 2) { audioManager.Play("swordSwingFast2"); }
            }

            // Strike right (rotate to 90)
            float elapsedTime = 0f;
            while (elapsedTime < swordStrikeDuration)
            {
                float targetRotation = Mathf.Lerp(-180f, 180f, elapsedTime / swordStrikeDuration);
                bossSword.transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Set the exact rotation after interpolation
            bossSword.transform.rotation = Quaternion.Euler(0f, 0f, 180f);

            // Pause
            yield return new WaitForSeconds(swordPauseTime);
            if(swordStrikeDuration > 0.4f)
            {
                int random = Random.Range(1,3);
                if(random == 1) { audioManager.Play("swordSwingSlow1"); }
                if (random == 2) { audioManager.Play("swordSwingSlow2"); }
            }

            if (swordStrikeDuration <= 0.4f)
            {
                int random = Random.Range(1, 3);
                if (random == 1) { audioManager.Play("swordSwingFast1"); }
                if (random == 2) { audioManager.Play("swordSwingFast2"); }
            }

            // Strike left (rotate to -90)
            elapsedTime = 0f;
            while (elapsedTime < swordStrikeDuration)
            {
                float targetRotation = Mathf.Lerp(180f, -180f, elapsedTime / swordStrikeDuration);
                bossSword.transform.rotation = Quaternion.Euler(0f, 0f, targetRotation);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Set the exact rotation after interpolation
            bossSword.transform.rotation = Quaternion.Euler(0f, 0f, -180f);

            // Pause
            yield return new WaitForSeconds(swordPauseTime);
        }
    }
    #endregion

    #region BIG BULLETS
    IEnumerator ShootBigBullets()
    {
        if(stopShootingBigBullets == false)
        {
            doneCharging = false;
            int bulletCount = bigBulletsCount;
            float burstSpread = 120f; // Angle spread between each bullet in the burst

            // List to hold all the bullets in the burst
            List<GameObject> bullets = new List<GameObject>();

            // Scaling phase
            for (int i = 0; i < bulletCount; i++)
            {
                GameObject enemyBullet = ObjectPool.instance.GetSmallEnemyBulletFromPool();
                //enemyBullet.transform.SetParent(gameObject.transform);
                enemyBullet.tag = "SmallBossBullet";
                enemyBullet.transform.localScale = Vector2.zero; // Start with zero scale
                bullets.Add(enemyBullet);

                // Gradually increase the scale over 0.7 seconds
                float scaleTime = bigBulletChargeTime;
                float elapsedTime = 0f;

                while (elapsedTime < scaleTime)
                {
                    float scale = Mathf.Lerp(0f, bigBulletSize, elapsedTime / scaleTime);
                    enemyBullet.transform.localScale = new Vector2(scale, scale);

                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }

            // Shooting phase
            foreach (var bullet in bullets)
            {
                // Set the final scale to ensure it's exactly 0.4
                bullet.transform.localScale = new Vector2(bigBulletSize, bigBulletSize);

                // Calculate the angle for each bullet in the burst
                float angle = -burstSpread / 2f + (bullets.IndexOf(bullet) * burstSpread / (bulletCount - 1));
                Vector2 bulletDirection = Quaternion.Euler(0, 0, angle) * Vector2.down;

                // Apply velocity to the bullet
                float bulletSpeed = 100;
                doneCharging = true;
                bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletDirection * bulletSpeed;
                //bullet.transform.SetParent(mainBulletParent);
            }

            yield return new WaitForSeconds(3.8f);
            shootBigBullets = true;
            if (movingCoroutine == null)
            {
                movingCoroutine = StartCoroutine(MoveBoss());
                startAttackCoroutine = StartCoroutine(ShootAFewBullets());
                smallBulletShootTime = 1.3f;
                bossMoveSpeed = 30;
            }
        }
       
    }
    #endregion


    #region Shoot Small Bullets
    private IEnumerator ShootAFewBullets()
    {
        while (isShootingSmallBullet == true)
        {
            BulletShot();
            
            yield return new WaitForSeconds(smallBulletShootTime);
        }
    }

    public void BulletShot()
    {
        StartCoroutine(ShootBulletCoroutine());
    }

    private IEnumerator ShootBulletCoroutine()
    {
        float randomBulletSize = Random.Range(0.6f, 1.15f);
        smallBulletSize = randomBulletSize;

        float bulletSize;
        bulletSize = smallBulletSize;

        if (reachedThrehold2 == true)
        {
            int random = Random.Range(1,101);
            if(random < 5) { bulletSize = smallBulletSize * 2.4f; }
        }

        float bulletSpeed = 125;

        float xOffset = Random.Range(-15, 15);
        float yOffset = Random.Range(-15, 15);
       
        GameObject enemyBullet = ObjectPool.instance.GetSmallEnemyBulletFromPool();
        enemyBullet.tag = "SmallBossBullet";
        enemyBullet.transform.localScale = Vector2.zero; // Start with zero scale
        

        // Gradually increase the scale over 0.7 seconds
        float scaleTime = 5f;
        float elapsedTime = 0f;

        while (elapsedTime < scaleTime)
        {
            Vector2 bossPosition = gameObject.transform.position;
            Vector2 newPosition = new Vector2(
           bossPosition.x + xOffset,
           bossPosition.y + yOffset
           );
            enemyBullet.transform.position = newPosition;
            float scale = Mathf.Lerp(0f, bulletSize, elapsedTime / scaleTime);
            enemyBullet.transform.localScale = new Vector2(scale, scale);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        enemyBullet.transform.localScale = new Vector2(bulletSize, bulletSize);

        //enemyBullet.transform.SetParent(mainBulletParent);
        Vector3 directionToButton = mainButton.position - transform.position;
        directionToButton.Normalize();
        enemyBullet.GetComponent<Rigidbody2D>().linearVelocity = directionToButton * bulletSpeed;
    }

    #endregion

    #region Boss Movement
    private IEnumerator MoveBoss()
    {
        while (isBossMoving == true)
        {
            // Move the boss slowly left or right
            float direction = Random.Range(0, 2) == 0 ? -1f : 1f;

            while (timeElapsed < timeToChangeDirection)
            {
                transform.Translate(Vector3.right * direction * bossMoveSpeed * Time.deltaTime);

                // Check if leftPosObject is out of camera view
                if (!IsObjectInCameraView(leftPosObject))
                {
                    // Move the boss to the right
                    direction = 1f;
                }

                // Check if rightPosObject is out of camera view
                if (!IsObjectInCameraView(rightPosObject))
                {
                    // Move the boss to the left
                    direction = -1f;
                }

                timeElapsed += Time.deltaTime;
                yield return null;
            }

            // Wait for a random time between 5-10 seconds before changing direction
            timeToChangeDirection = Random.Range(5f, 11f);
            timeElapsed = 0f;
        }
    }

    private bool IsObjectInCameraView(Transform objTransform)
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(objTransform.position);
        return viewportPos.x > 0 && viewportPos.x < 1;
    }
    #endregion


    #region COLLISION
    private void OnTriggerEnter2D(Collider2D collision)
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

        #region Charged bullet
        if (collision.gameObject.tag == "ChargedBullet")
        {
            DamageEnemy(collision.transform.localPosition, ChargedBullet.chargedBossDamage);
        }
        #endregion

        #region Bullet hit - damage enemy
        if (collision.gameObject.tag == "BulletBounced")
        {
            DamageEnemy(collision.transform.localPosition, Choises.bulletGun1_Damage);
        }
        #endregion

        #region Big Piecring bullet
        if (collision.gameObject.name == "bigPiercingBulletCollider")
        {
            DamageEnemyArrow(collision.transform.position, Choises.bigBulletDamage);
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

        #region TrippleBullet
        if (collision.gameObject.tag == "TrippleBullet")
        {
            DamageEnemy(collision.transform.localPosition, Choises.trippleShotDamage);
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
    }
    #endregion

    #region Boss Damaged
    public void DamageEnemy(Vector2 damagePos, float damageAmount)
    {
        //Debug.Log("Boss Damages");
        bossHealth -= damageAmount;
        bossHealthSlider.value = bossHealth;

        ButtonBehiavor.damageDone = damageAmount;
        bossDamagedPos = damagePos;
        bossDamaged = true;

        if(bossHealth < 0) { BossDeath(); }
    }

    public void DamageEnemyArrow(Vector2 damagePos, float damageAmount)
    {
        bossHealth -= damageAmount;
        bossHealthSlider.value = bossHealth;

        ButtonBehiavor.damageDone = damageAmount;
        bossArrowDamagedPos = damagePos;
        bossArrowDamaged = true;

        if (bossHealth < 0) { BossDeath(); }
    }
    #endregion

    private string originalParentName = "arrowPool";
    public ParticleEffectSystems particleScripts;
    public Choises choisesScript;

    public void BossDeath()
    {
        if(bossDied == false)
        {
            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("championDeath1"); }
            if (random == 2) { audioManager.Play("championDeath2"); }

            bossDied = true;

            if (startAttackCoroutine != null) { StopCoroutine(startAttackCoroutine); startAttackCoroutine = null; }
            if (bigBulletCoroutine != null) { StopCoroutine(bigBulletCoroutine); bigBulletCoroutine = null; }
            if (movingCoroutine != null) { StopCoroutine(movingCoroutine); movingCoroutine = null; }
            if (swordCoroutine != null) { StopCoroutine(swordCoroutine); swordCoroutine = null; }

            SettingsOptions.runsCompleted += 1;
            SettingsOptions.timesDefeatedBoss += 1;
            if (SettingsOptions.firstTimeDefeatedBoss == false)
            {
                SettingsOptions.endingsCompleted += 1;
                SettingsOptions.firstTimeDefeatedBoss = true;
            }
            choisesScript.BossWin();

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
                GameObject originalParent = GameObject.Find(originalParentName);

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

            bossDiePos = gameObject.transform.position;
            particleScripts.DeathParticle(bossDiePos, 7f);
            particleScripts.BossPieces(bossDiePos, 7f);
            centerObject.gameObject.SetActive(false);
            spinningShield.SetActive(false);
            bossSword.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
