using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class MainButtonCollider : MonoBehaviour
{
    public Rigidbody2D buttonRB;
    Vector3 lastVelocity;
    public GameObject spinSpikeObject, shield_Bounce, rocket;
    public GameObject sword2, sword3, sword4;
    public static float rotationSpeed, rocketRotationSpeed;
    private float currentSpeed;

    public GameObject gun1, gun2, homingGun, bigPiercingBulletGun, gun3, crossbow, trippleShot;
    public GameObject boxingGlove;
    public GameObject stabbingSpikeOBject, stabbingSpikes1, stabbingSpike2, stabbingSpike3, stabbingSpike4, stabbingSpike5, stabbingSpike6, stabbingSpike7, stabbingSpike8;

    private Vector2 gun1Direction, gun2Direction, gun3Direction, gun4Direction, trippleShotDirection, awpDirection;

    public GameObject smallButton;
    public float speed, speed2, speed3;

    public static bool isChargePressed;
    public static bool useBoxingGlove;

    public GameObject invincibilityObject;
    public GameObject sawBladeEmpty, sawBladeObject, sawBlade2, sawBlade3, sawBlade4, sawBlade5, sawBlade6, sawBlade7, sawBlade8;
    public GameObject hammerRotate, hammerObject;
    public GameObject knifeTotateObject;
    public GameObject PointCollider;

    public float rocketForce;
    public float stabbingSpikeRotationSpeed;

    public float sawBladeSpeed;

    public GameObject buttonLeftClickBlock;
    public Transform[] smallShields;
    public float orbitSpeed = 35f;
    public float orbitRadius = 5f;

    private GameObject[] enemies;

    void Start()
    {
        randomPistolEnemy = null;
        boxingGloveCoroutine = null;

        orbitSpeed = 50f;
        isPistolReady = true;
        isShotgunReady = true;
        isMp4Ready = true;
        isCrossbowReady = true;

        buttonMoveSpeed = 17;
        proximityThreshold = 200;

        rocketRotationSpeed = 100;
        stabbingSpikeRotationSpeed = 10;

        sawBladeSpeed = 60;

        speed3 = 35;
        charge = 0;
        speed = 110;
        speed2 = 6.4f;
        buttonRB.GetComponent<Rigidbody2D>();
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // Filter objects with Layer 7
        enemies = System.Array.FindAll(allObjects, obj => obj.layer == 7);
    }
   

    [SerializeField]
    private float proximityThreshold = 5f;

    public Coroutine stabbySpikeCoroutine;
    public static Coroutine boxingGloveCoroutine;

    public Vector2 pistolDir, shotgunDir, crossbowDir, mp4Dir;

    private void Update()
    {
        PointCollider.transform.localPosition = gameObject.transform.localPosition;

        buttonLeftClickBlock.transform.localPosition = gameObject.transform.localPosition;

        lastVelocity = buttonRB.velocity;

        if(ButtonClick.isButtonMoving == true)
        {
            currentSpeed = buttonRB.velocity.magnitude;
            ButtonClick.buttonMovingDamageBonus = currentSpeed;
        }

        #region Small Shields
        if(Choises.choseSmallShields == true)
        {
            for (int i = 0; i < smallShields.Length; i++)
            {
                // Calculate the angle for each shield based on its index
                float angle = Time.time * orbitSpeed + i * (360f / smallShields.Length);

                // Calculate the position around the centerObject using polar coordinates
                float x = gameObject.GetComponent<Transform>().position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * orbitRadius;
                float y = gameObject.GetComponent<Transform>().position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * orbitRadius;

                smallShields[i].position = new Vector2(x, y);
                smallShields[i].rotation = Quaternion.Euler(0, 0, 0);

                smallShields[i].RotateAround(gameObject.GetComponent<Transform>().position, Vector3.forward, orbitSpeed * Time.deltaTime);
            }
        }
        #endregion

        #region spinning knifes
        if (Choises.choseSpinningKnifes == true) { knifeTotateObject.transform.Rotate(Vector3.forward * Choises.knifeSpeed * Time.deltaTime); }
        #endregion

        #region Spinning sword
        if (Choises.chooseBigSpike == true) { spinSpikeObject.transform.Rotate(Vector3.forward * Choises.swordSpeed * Time.deltaTime); }
        #endregion

        #region SawBlade
        if (Choises.chooseSawBlade == true)
        {
            sawBladeEmpty.transform.Rotate(Vector3.forward * -Choises.sawBladeSpeed * Time.deltaTime);
            sawBladeObject.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            if(Choises.sawBladeUpgradeCount > 1) { sawBlade2.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
            if (Choises.sawBladeUpgradeCount > 2) { sawBlade3.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
            if (Choises.sawBladeUpgradeCount > 3) { sawBlade4.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
            if (Choises.sawBladeUpgradeCount > 4) { sawBlade5.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
            if (Choises.sawBladeUpgradeCount > 5) { sawBlade6.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
            if (Choises.sawBladeUpgradeCount > 6) { sawBlade7.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
            if (Choises.sawBladeUpgradeCount > 7) { sawBlade8.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime); }
        }
        #endregion

        #region shield
        if (Choises.choseShield_BounceOff == true) { shield_Bounce.transform.Rotate(Vector3.forward * Choises.shieldBounce_RotateSpeed * Time.deltaTime); }
        #endregion

        #region stabbing spike
        if (Choises.chooseStabbingSpikes == true) 
        {
            stabbingSpikeOBject.transform.Rotate(Vector3.forward * stabbingSpikeRotationSpeed * Time.deltaTime);
           
            if (ButtonClick.stabSpikes == true)
            {
                ButtonClick.stabSpikes = false;
                if(stabbySpikeCoroutine == null) { stabbySpikeCoroutine = StartCoroutine(StabSpikes()); }
            }
        }
        #endregion

        #region Booster
        if (Choises.choseButtonBounceCharge == true && SettingsOptions.isInSettings == false && Choises.isInMainManu == false)
        {
            if(MobileScript.isMobile == false)
            {
                if (Input.GetKey(KeyCode.Mouse0) && isChargePressed == true || Input.GetKey(KeyCode.LeftControl))
                {
                    Booster(true);
                }
                else
                {
                    Booster(false);
                }
            }
            else
            {
                if (MobileBtnPress.holdingDown == true)
                {
                    Booster(true);
                }
                else
                {
                    Booster(false);
                }
            }
        }
        #endregion

        if(Choises.isInMainManu == false)
        {
            #region gun1 Pistol - Movement
            if (Choises.chose_Gun1 == true)
            {
                if (Choises.isPaused == false)
                {
                    if(MobileScript.isMobile == false)
                    {
                        pistolDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        float angle = Mathf.Atan2(pistolDir.y, pistolDir.x) * Mathf.Rad2Deg;
                        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                        gun1.transform.rotation = rotation;
                    }
                }
            }
            #endregion

            #region gun2 Shotgun - Movement
            if (Choises.chose_gun2 == true)
            {
                if (Choises.isPaused == false)
                {
                    if (MobileScript.isMobile == false)
                    {
                        shotgunDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        float angle = Mathf.Atan2(shotgunDir.y, shotgunDir.x) * Mathf.Rad2Deg;
                        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                        gun2.transform.rotation = rotation;
                    }
                }
            }
            #endregion

            #region gun3 Mp4 - Movement
            if (Choises.choseGunMp4 == true)
            {
                if (Choises.isPaused == false)
                {
                    if (MobileScript.isMobile == false)
                    {
                        mp4Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        float angle = Mathf.Atan2(mp4Dir.y, mp4Dir.x) * Mathf.Rad2Deg;
                        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                        gun3.transform.rotation = rotation;
                    }
                }
            }
            #endregion

            #region Crossbow - Movement
            if (Choises.choseCrossBow == true)
            {
                if (Choises.isPaused == false)
                {
                    if (MobileScript.isMobile == false)
                    {
                        crossbowDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        float angle = Mathf.Atan2(crossbowDir.y, crossbowDir.x) * Mathf.Rad2Deg;
                        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                        crossbow.transform.rotation = rotation;
                    }
                }
            }
            #endregion
        }

        #region big piercing bullet pool
        if (Choises.chooseBigPiercingBulletGun == true)
        {
            bigPiercingBulletGun.transform.Rotate(Vector3.forward * speed3 * Time.deltaTime);
            gun3Direction = bigPiercingBulletGun.transform.up;
        }

        if (ButtonClick.shootBigBullet == true)
        {
            StartCoroutine(BigPiceringBullet());
            ButtonClick.shootBigBullet = false;
        }
        #endregion

        #region boxing glove
        if(Choises.choseBoxingGlove == true && useBoxingGlove == true && BossMechanics.fightingBossFight == false && MimicEnding.isPlayingChamptions == false)
        {
            if(boxingGloveCoroutine == null) { boxingGloveCoroutine = StartCoroutine(UseBoxingGlove()); }
            useBoxingGlove = false;
        }
        #endregion

        #region invincibilityAbility
        if(Choises.choseInvincibility == true)
        {
            if(MobileScript.isMobile == false)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    InvinClick();

                  
                }
            }
        }
        #endregion

        #region controllable button
        if(Choises.chooseControllableButton == true && SettingsOptions.isInSettings == false && Choises.isInMainManu == false)
        {
            if(MobileScript.isMobile == false)
            {
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");

                // Calculate the movement direction
                Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

                // Move the player
                transform.Translate(movement * buttonMoveSpeed * Time.deltaTime);
            }
            else
            {
                Vector2 movement = virtualJoystick.inputDirection;

                // Move the player
                transform.Translate(movement * buttonMoveSpeed * Time.deltaTime);
            }
        }
        #endregion

        #region rocket movement
        if (Choises.chooseRocket == true && SettingsOptions.isInSettings == false && Choises.isInMainManu == false)
        {
            if(MobileScript.isMobile == false)
            {
                if (Input.GetKey(KeyCode.A)) { rocket.transform.Rotate(Vector3.forward * rocketRotationSpeed * Time.deltaTime); }
                if (Input.GetKey(KeyCode.D)) { rocket.transform.Rotate(Vector3.forward * -rocketRotationSpeed * Time.deltaTime); }
            }
            else
            {
                Vector2 direction = virtualJoystick.inputDirection;

                if (direction != Vector2.zero)
                {
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    rocket.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                }
            }

            if (Input.GetKey(KeyCode.LeftControl) || MobileBtnPress.holdingDown == true)
            {
                if(MobileScript.isMobile == false)
                {
                    if (isRocketSound == false) { audioManager.Play("rocket"); isRocketSound = true; }
                }

                if (rocketChargeCoroutine == null)
                {
                    ChargeRocket();
                }
            }
            else
            {
                if (isRocketSound == true) { audioManager.Stop("rocket"); isRocketSound = false; }

                rocketFire.SetActive(false);
                if (rocketChargeCoroutine != null)
                {
                    StopCoroutine(rocketChargeCoroutine);
              
                    charge = 0;
                    rocketForce = 0;
                    rocketChargeCoroutine = null;
                }
            }
        }

        #endregion

        #region Hammer. Check position.
        if(ButtonClick.checkIfEnemiesOnScreen == true)
        {
            int random = Random.Range(1,3);
            if(random == 1) 
            {
                if(hammerCoroutine == null) { hammerCoroutine = StartCoroutine(hammerAttack(false)); }
            }
            if (random == 2) 
            {
                if (hammerCoroutine == null) { hammerCoroutine = StartCoroutine(hammerAttack(true)); }
            }

            ButtonClick.checkIfEnemiesOnScreen = false;
        }
        
        #endregion

        if(setCollOff == true)
        {
            Invoke("SetCollOff", 0.6f);
            setCollOff = false;
        }
    }

    #region Booster
    public void Booster(bool charing)
    {
        if(charing == true)
        {
            if (chargeNeeded > 0f)
            {
                //Debug.Log(chargeNeeded);
                smallButton.transform.Rotate(Vector3.forward * speed2 * Time.deltaTime);
            }
            else { smallButton.transform.Rotate(Vector3.forward * speed * Time.deltaTime); }

            if (chargeCoroutine == null)
            {
                ChargeSmallButton();
            }
        }
        else
        {
            smallButton.transform.Rotate(Vector3.forward * speed * Time.deltaTime);

            if (chargeCoroutine != null)
            {
                if (chargeForce > 0) { ApplyOppositeForce(); }
                StopCoroutine(chargeCoroutine);
                charge = 0f;
                chargeForce = 0f;
                chargeNeeded = 0f;
                chargeObject.transform.localScale = new Vector3(0, 0, 0);
                chargeCoroutine = null;
            }
        }
    }
    #endregion

    #region Invin click
    public void InvinClick()
    {
        if (Choises.invincibilityTimer > 0)
        {
            if (Choises.isPaused == false)
            {
                invincibilityObject.SetActive(true);
                if (startTimer == false)
                {
                    invCoroutine = StartCoroutine(InvinAbility());
                    audioManager.Play("invinIn");
                }
                else
                {
                    Choises.buttonHealth = currentHealth;
                    isInvincibilityActive = false;
                    if (invCoroutine != null) { StopCoroutine(invCoroutine); invCoroutine = null; }
                    audioManager.Play("invinOut");
                    startTimer = false;
                    invincibilityObject.SetActive(false);
                }
            }
        }
    }
    #endregion

    public JoystickMechanics virtualJoystick;

    public AudioManager audioManager;

    public GameObject rocketFire;

    #region Reset Charge And Rocket And boxing glove
    public void StopRocketAndBooster()
    {
        rocketFire.SetActive(false);
        if (rocketChargeCoroutine != null)
        {
            StopCoroutine(rocketChargeCoroutine);
            charge = 0;
            rocketForce = 0;
            rocketChargeCoroutine = null;
        }

        if (chargeCoroutine != null)
        {
            StopCoroutine(chargeCoroutine);
            charge = 0;
            chargeForce = 0;
            chargeNeeded = 0;
            chargeObject.transform.localScale = new Vector3(0, 0, 0);
            chargeCoroutine = null;
        }

        if(boxingGloveCoroutine != null) 
        { 
            StopCoroutine(boxingGloveCoroutine);
            boxingGlove.transform.localPosition = new Vector2(0, 2.5f);
            boxingGlove.SetActive(false);
            boxingGloveCoroutine = null;
        }

        isChargeSound = false;
        StartCoroutine(SetBtnStill());
    }

    IEnumerator SetBtnStill()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        yield return new WaitForSeconds(2f);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    #endregion

    #region TrippleShot
    public void ShootDeagle()
    {
        if (enemies.Length > 0)
        {
            GameObject closestEnemy = FindClosestActiveEnemy(enemies);

            if (closestEnemy != null)
            {
                int random = Random.Range(1, 4);
                if (random == 1) { audioManager.Play("Deagle1"); }
                if (random == 2) { audioManager.Play("Deagle2"); }
                if (random == 3) { audioManager.Play("Deagle3"); }

                // Calculate the direction from the trippleShot to the closest enemy
                Vector2 direction = closestEnemy.transform.position - trippleShot.transform.position;

                // Calculate the rotation angle from the direction
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Apply the rotation to the trippleShot
                trippleShot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                trippleShotDirection = direction.normalized;

                GameObject tripple1 = ObjectPool.instance.GetTrippleShotFromPool();
                GameObject tripple2 = ObjectPool.instance.GetTrippleShotFromPool();
                GameObject tripple3 = ObjectPool.instance.GetTrippleShotFromPool();
                tripple1.transform.position = trippleShotStartingPos.transform.position;
                tripple2.transform.position = trippleShotStartingPos.transform.position;
                tripple3.transform.position = trippleShotStartingPos.transform.position;

                Rigidbody2D rb1 = tripple1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = tripple2.GetComponent<Rigidbody2D>();
                Rigidbody2D rb3 = tripple3.GetComponent<Rigidbody2D>();

                Vector2 middleDirection = Quaternion.Euler(0, 0, 0) * trippleShotDirection;
                Vector2 leftDirection = Quaternion.Euler(0, 0, -11) * trippleShotDirection;
                Vector2 rightDirection = Quaternion.Euler(0, 0, 11) * trippleShotDirection;

                rb1.velocity = middleDirection.normalized * Choises.trippleShotSpeed;
                rb2.velocity = leftDirection.normalized * Choises.trippleShotSpeed;
                rb3.velocity = rightDirection.normalized * Choises.trippleShotSpeed;

                float rotationMiddle = Mathf.Atan2(trippleShotDirection.y, trippleShotDirection.x) * Mathf.Rad2Deg;
                tripple1.transform.rotation = Quaternion.Euler(0, 0, rotationMiddle);
                tripple2.transform.rotation = Quaternion.Euler(0, 0, rotationMiddle - 11);
                tripple3.transform.rotation = Quaternion.Euler(0, 0, rotationMiddle + 11);

                StartCoroutine(ShootTrippleShots(tripple1, tripple2, tripple3));
            }
        }
    }

    GameObject FindClosestActiveEnemy(GameObject[] enemies)
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf) // Check if the enemy is active
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }
        }

        return closestEnemy;
    }

    public Transform trippleShotStartingPos;
    IEnumerator ShootTrippleShots(GameObject bullet1, GameObject bullet2, GameObject bullet3)
    {
        yield return new WaitForSeconds(4);
        if (bullet1.activeInHierarchy == true) { ObjectPool.instance.ReturnTrippleShotFromPool(bullet1); }
        if (bullet2.activeInHierarchy == true) { ObjectPool.instance.ReturnTrippleShotFromPool(bullet2); }
        if (bullet3.activeInHierarchy == true) { ObjectPool.instance.ReturnTrippleShotFromPool(bullet3); }
    }
    #endregion

    #region Homing Target
    public void ShootAWP()
    {
        if (enemies.Length > 0)
        {
            GameObject randomEnemy = GetRandomActiveEnemy(enemies);

            if (randomEnemy != null)
            {
                homingGunTarget = randomEnemy.transform;

                Vector3 direction = homingGunTarget.position - homingGun.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                homingGun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                awpDirection = direction.normalized;

                int random = Random.Range(1,3);
                if(random == 1) { audioManager.Play("awp1"); }
                if (random == 2) { audioManager.Play("awp2"); }
                GameObject homingBullet = ObjectPool.instance.GetHomingBulletFromPool();
                homingBullet.transform.position = homingBulletPos.transform.position;

                Rigidbody2D rb = homingBullet.GetComponent<Rigidbody2D>();
                rb.velocity = awpDirection * Choises.homignBulletSpeed;

                StartCoroutine(ShootHomingBullet(homingBullet));
            }
        }
    }


    GameObject GetRandomActiveEnemy(GameObject[] enemies)
    {
        List<GameObject> activeEnemies = new List<GameObject>();

        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeSelf)
            {
                activeEnemies.Add(enemy);
            }
        }

        if (activeEnemies.Count > 0)
        {
            GameObject randomEnemy = null;

            if (MobileScript.isMobile == true)
            {
                if (MimicEnding.isPlayingChamptions == true)
                {
                    if (MimicEnding.championsKilled != 2)
                    {
                        do
                        {
                            enemyTargetArrayPos = Random.Range(0, activeEnemies.Count);
                            randomEnemy = activeEnemies[enemyTargetArrayPos];

                        } while (randomEnemy.name == "Champion3Armored");
                    }
                }
                else
                {
                     enemyTargetArrayPos = Random.Range(0, activeEnemies.Count);
                     randomEnemy = activeEnemies[enemyTargetArrayPos];
                }
            }
            else
            {
                enemyTargetArrayPos = Random.Range(0, activeEnemies.Count);
                randomEnemy = activeEnemies[enemyTargetArrayPos];
            }

            return randomEnemy;
        }

        return null;
    }

    private Transform homingGunTarget;
    public int enemyTargetArrayPos;
    public Transform homingBulletPos;

    IEnumerator ShootHomingBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(4f);
        ObjectPool.instance.ReturnHomingBulletFromPool(bullet);
    }
    #endregion

    #region hammer
    public static bool leftOrRight;
    public GameObject hammerColl;

    public Coroutine hammerCoroutine;
    IEnumerator hammerAttack(bool rightOrLeft)
    {
        hammerRotate.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        hammerObject.transform.localScale = new Vector3(0,0,0);
        //hammerRotate.SetActive(true);
        hammerObject.SetActive(true);
        hammerObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.167f);
        if(rightOrLeft == true)
        {
            hammerRotate.GetComponent<Animation>().Play("HammerRight");
        }
        if (rightOrLeft == false)
        {
            hammerRotate.GetComponent<Animation>().Play("HammerLeft");
        }
        yield return new WaitForSeconds(0.2f);
        hammerObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.36f);
        hammerObject.GetComponent<Collider2D>().enabled = false;
        hammerObject.SetActive(false);
        hammerCoroutine = null;
    }

    public static bool setCollOff;
    public void SetCollOff()
    {
        hammerColl.SetActive(false);
    }

    #endregion

    public static float buttonMoveSpeed = 5f;

    #region Stabbing Spikes
    IEnumerator StabSpikes()
    {
        Vector2 initialPosition = stabbingSpikes1.transform.localPosition; stabbingSpikes1.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition2 = stabbingSpike2.transform.localPosition; stabbingSpike2.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition3 = stabbingSpike3.transform.localPosition; stabbingSpike3.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition4 = stabbingSpike4.transform.localPosition; stabbingSpike4.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition5 = stabbingSpike5.transform.localPosition; stabbingSpike5.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition6 = stabbingSpike6.transform.localPosition; stabbingSpike6.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition7 = stabbingSpike7.transform.localPosition; stabbingSpike7.GetComponent<Collider2D>().enabled = true;
        Vector2 initialPosition8 = stabbingSpike8.transform.localPosition; stabbingSpike8.GetComponent<Collider2D>().enabled = true;

        Vector2 stabDirection = stabbingSpikes1.transform.up;
        Vector2 stabDirection2 = stabbingSpike2.transform.up;
        Vector2 stabDirection3 = stabbingSpike3.transform.up;
        Vector2 stabDirection4 = stabbingSpike4.transform.up;
        Vector2 stabDirection5 = stabbingSpike5.transform.up;
        Vector2 stabDirection6 = stabbingSpike6.transform.up;
        Vector2 stabDirection7 = stabbingSpike7.transform.up;
        Vector2 stabDirection8 = stabbingSpike8.transform.up;

        stabbingSpikes1.transform.Translate(stabDirection * 5f, Space.World);
        stabbingSpike2.transform.Translate(stabDirection2 * 5f, Space.World);
        stabbingSpike3.transform.Translate(stabDirection3 * 5f, Space.World);
        stabbingSpike4.transform.Translate(stabDirection4 * 5f, Space.World);
        stabbingSpike5.transform.Translate(stabDirection5 * 5f, Space.World);
        stabbingSpike6.transform.Translate(stabDirection6 * 5f, Space.World);
        stabbingSpike7.transform.Translate(stabDirection7 * 5f, Space.World);
        stabbingSpike8.transform.Translate(stabDirection8 * 5f, Space.World);

        yield return new WaitForSeconds(0.3f);

        stabbingSpikes1.transform.localPosition = initialPosition; stabbingSpikes1.GetComponent<Collider2D>().enabled = false;
        stabbingSpike2.transform.localPosition = initialPosition2; stabbingSpike2.GetComponent<Collider2D>().enabled = false;
        stabbingSpike3.transform.localPosition = initialPosition3; stabbingSpike3.GetComponent<Collider2D>().enabled = false;
        stabbingSpike4.transform.localPosition = initialPosition4; stabbingSpike4.GetComponent<Collider2D>().enabled = false;
        stabbingSpike5.transform.localPosition = initialPosition5; stabbingSpike5.GetComponent<Collider2D>().enabled = false;
        stabbingSpike6.transform.localPosition = initialPosition6; stabbingSpike6.GetComponent<Collider2D>().enabled = false;
        stabbingSpike7.transform.localPosition = initialPosition7; stabbingSpike7.GetComponent<Collider2D>().enabled = false;
        stabbingSpike8.transform.localPosition = initialPosition8; stabbingSpike8.GetComponent<Collider2D>().enabled = false;

        stabbySpikeCoroutine = null;
    }
    #endregion

    #region Invin

    public void ResetInvin()
    {
        if(invCoroutine != null) { StopCoroutine(invCoroutine); invCoroutine = null; }

        startTimer = false;
        invincibilityObject.SetActive(false);
        isInvincibilityActive = false;
        countdownText.text = "";
    }

    public static float currentHealth;
    public bool startTimer;
    public TextMeshProUGUI countdownText;
    public static bool isInvincibilityActive;
    public Coroutine invCoroutine;

    public IEnumerator InvinAbility()
    {
        currentHealth = Choises.buttonHealth;
        startTimer = true;

        float timer = Choises.invincibilityTimer;

        while (timer > 0f)
        {
            isInvincibilityActive = true;

            countdownText.text = timer.ToString("F2");

            yield return null; 

            float deltaTime = Time.deltaTime;
            timer -= deltaTime;
            Choises.invincibilityTimer -= deltaTime;

            timer = Mathf.Max(timer, 0f);
        }

        audioManager.Play("invinOut");

        startTimer = false;
        invincibilityObject.SetActive(false);
        isInvincibilityActive = false;
    }
    #endregion

    #region Boxing glove
    public float moveSpeed;
    public LayerMask targetLayer;
    public Rigidbody2D gloveRigidbody;

    IEnumerator UseBoxingGlove()
    {
        yield return new WaitForSeconds(0);

        GameObject[] targets1 = GameObject.FindGameObjectsWithTag("SmallEnemy");
        GameObject[] targets2 = GameObject.FindGameObjectsWithTag("Speedster");

        GameObject[] allTargets = targets1.Concat(targets2).ToArray();

        if (allTargets.Length == 0)
        {
            boxingGloveCoroutine = null;
            yield break; // No targets found, so do nothing.
        }
        else
        {
            boxingGlove.SetActive(true);
            moveSpeed = 90f;

            Transform closestTarget = GetClosestTarget(allTargets);

            Vector2 direction = (closestTarget.position - boxingGlove.transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 35f;
            boxingGlove.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Apply force to the boxing glove in the direction of the closest target.
            gloveRigidbody.AddForce(direction * moveSpeed, ForceMode2D.Impulse);


            while (Vector2.Distance(boxingGlove.transform.position, closestTarget.position) > 0.1f)
            {
                yield return null;
            }
        }
       
    }

    Transform GetClosestTarget(GameObject[] targets)
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (var target in targets)
        {
            float distance = Vector2.Distance(boxingGlove.transform.position, target.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = target.transform;
            }
        }

        return closestTarget;
    }
    #endregion

    #region Gun KnockBack
    public Coroutine knockBackCoroutine;
    public bool isPistolReady, isShotgunReady, isMp4Ready, isCrossbowReady;

    IEnumerator ShootGun(GameObject gun, int gunNumber, Vector2 direction, float force)
    {
        if(gunNumber == 1) { isPistolReady = false; }
        if (gunNumber == 2) { isShotgunReady = false; }
        if (gunNumber == 3) { isMp4Ready = false; }
        if (gunNumber == 4) { isCrossbowReady = false; }

        // Move gun1 slightly backward
        Vector2 originalPosition = gun.transform.localPosition;

        Vector2 backwardPosition = originalPosition - (Vector2)direction * force; // Adjust the backward distance as needed

        float elapsedTime = 0f;
        float duration = 0.07f; // Adjust the duration of each movement

        while (elapsedTime < duration)
        {
            gun.transform.localPosition = Vector2.Lerp(originalPosition, backwardPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure gun1 is exactly at the backward position
        gun.transform.localPosition = backwardPosition;

        yield return new WaitForSeconds(0.02f); // Adjust the delay between movements

        // Move gun1 back to its original position
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            gun1.transform.localPosition = Vector2.Lerp(backwardPosition, originalPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure gun1 is exactly at the original position
        gun.transform.localPosition = originalPosition;

        if (gunNumber == 1) { isPistolReady = true; }
        if (gunNumber == 2) { isShotgunReady = true; }
        if (gunNumber == 3) { isMp4Ready = true; }
        if (gunNumber == 4) { isCrossbowReady = true; }
    }
    #endregion

    #region button bounce charge
    public Coroutine chargeCoroutine;

    public void ChargeSmallButton()
    {
        chargeCoroutine = StartCoroutine(ChargeButtonVisual());
    }

    public GameObject chargeObject;
    public float charge, chargeNeeded;
    public static float chargeForce;
    public static bool isChargeSound;

    private IEnumerator ChargeButtonVisual()
    {
        yield return new WaitForSeconds(0.08f);
        while (true)
        {
            yield return new WaitForSeconds(0.04f);
            chargeNeeded += 0.04f;
            if (chargeNeeded > 0.1)
            {
                if(isChargeSound == false)
                {
                    audioManager.Play("charge2");
                    isChargeSound = true;
                }

                if (charge < 0.8f)
                {
                    chargeForce += 1.1f;
                    charge += 0.019f;
                    chargeObject.transform.localScale = new Vector3(charge, charge, charge);
                }

                if(charge >= 0.8f)
                {
                    if (isChargeSound == true)
                    {
                        audioManager.Stop("charge2");
                        isChargeSound = false;
                    }
                }
            }
        }
    }

    public Transform smallBounceSpinningObject;

    private void ApplyOppositeForce()
    {
        if (isChargeSound == true)
        {
            audioManager.Stop("charge2");
            isChargeSound = false;
        }

        audioManager.Play("BoosterRelease");

        Vector2 rotationDirection = smallBounceSpinningObject.up;

        Vector2 oppositeForce = -rotationDirection.normalized * chargeForce;

        buttonRB.AddForce(oppositeForce, ForceMode2D.Impulse);
    }
    #endregion

    #region Rocket charge
    public Coroutine rocketChargeCoroutine;
    public static bool isRocketSound;

    public void ChargeRocket()
    {
        rocketChargeCoroutine = StartCoroutine(ApplyRocketForce());
    }

    private IEnumerator ApplyRocketForce()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.12f);

            if(MobileScript.isMobile == true) 
            {
                if (charge > 0.025) { rocketFire.SetActive(true); } if (isRocketSound == false) { audioManager.Play("rocket"); isRocketSound = true; }
            }
            else
            {
                rocketFire.SetActive(true);
            }

            if (charge < 0.9f)
            {
                rocketForce += 0.23f;
                charge += 0.012f;

                if (MobileScript.isMobile == true)
                {
                    if (charge > 0.025)
                    {
                        Vector2 rotationDirection = rocket.GetComponent<Transform>().up;

                        Vector2 oppositeForce = -rotationDirection.normalized * rocketForce;

                        buttonRB.AddForce(oppositeForce, ForceMode2D.Impulse);
                    }
                }
                else
                {
                    Vector2 rotationDirection = rocket.GetComponent<Transform>().up;

                    Vector2 oppositeForce = -rotationDirection.normalized * rocketForce;

                    buttonRB.AddForce(oppositeForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (isRocketSound == true) { audioManager.Stop("rocket"); isRocketSound = false; }
                rocketFire.SetActive(false);
            }
        }
    }

    #endregion

    #region Shoot Pistol
    private Transform pistolTarget;
    public GameObject randomPistolEnemy;
    public int timesClicked;

    public void ShootPistol()
    {
        if(MobileScript.isMobile == true) 
        {
            if(timesClicked == 1)
            {
                if (randomPistolEnemy == null) { randomPistolEnemy = GetRandomActiveEnemy(enemies); }
                else { if (randomPistolEnemy.activeInHierarchy == false) { randomPistolEnemy = GetRandomActiveEnemy(enemies); } }
            }
            else { randomPistolEnemy = GetRandomActiveEnemy(enemies); }

            if (randomPistolEnemy == null) { return; }
            else { timesClicked = 1; }
           
            pistolTarget = randomPistolEnemy.transform;
            Vector2 direction = randomPistolEnemy.transform.position - gun1.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gun1.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gun1Direction = direction.normalized;
        }
        else
        {
            gun1Direction = pistolDir.normalized;
        }

        if (isPistolReady == true && MobileScript.isMobile == false) { knockBackCoroutine = StartCoroutine(ShootGun(gun1, 1, gun1Direction, 32)); }

        int random = Random.Range(1, 6);
        if (random == 1) { audioManager.Play("Pistol1"); }
        if (random == 2) { audioManager.Play("Pistol2"); }
        if (random == 3) { audioManager.Play("Pistol3"); }
        if (random == 4) { audioManager.Play("Pistol4"); }
        if (random == 5) { audioManager.Play("Pistol5"); }

        GameObject gunBullet = ObjectPool.instance.GetBulletGun1FromPool();
        gunBullet.transform.localScale = new Vector2(ObjectPool.pistolBulletSize, ObjectPool.pistolBulletSize);
        gunBullet.transform.position = gunBulletPos.transform.position;
        Rigidbody2D rb = gunBullet.GetComponent<Rigidbody2D>();

        rb.velocity = gun1Direction * Choises.bulletGun1_Speed;

        StartCoroutine(GunBullet(gunBullet));
    }

    public Transform gunBulletPos;
    IEnumerator GunBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(Choises.bulletGun1_DeSpawnTime);

        if (bullet.activeInHierarchy == true) { StartCoroutine(ScaleDownBullets(bullet, 1)); }
    }
    #endregion

    #region shoot bullet from shotgun
    public Transform shotgunBulletStartingPos;

    public void ShootShotgun()
    {
        GameObject closestEnemy = null;

        if (MobileScript.isMobile == true)
        {
             closestEnemy = FindClosestActiveEnemy(enemies);
            if (closestEnemy == null) { return; }
        }
        else { gun2Direction = shotgunDir.normalized; }

        if (isShotgunReady == true && MobileScript.isMobile == false) { knockBackCoroutine = StartCoroutine(ShootGun(gun2, 2, gun2Direction, 45)); }

        for (int i = 0; i < Choises.shotGunBullets; i++)
        {
            if (MobileScript.isMobile == true) {
                
                Vector2 direction = closestEnemy.transform.position - gun2.transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                gun2.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                gun2Direction = direction.normalized;
            }

            //Gets the shotgun shots
            GameObject shotGunBullet = ObjectPool.instance.GetShotgunBullletFromPool();
            float randomSize = Random.Range(0.35f, 0.55f);
            float randomSpeed = Random.Range(Choises.shotGunBulletSpeed1, Choises.shotGunBulletSpeed2);
            shotGunBullet.transform.position = shotgunBulletStartingPos.transform.position;
            shotGunBullet.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            Rigidbody2D rb = shotGunBullet.GetComponent<Rigidbody2D>();

            //Spread
            float randomAngle = Random.Range(-12, 12); // Adjust spreadAngleRange to control randomness
            Vector2 randomDirection = Quaternion.Euler(0, 0, randomAngle) * gun2Direction;

            rb.velocity = randomDirection.normalized * randomSpeed;

            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("Shotgun1"); }
            if (random == 2) { audioManager.Play("Shotgun2"); }

            StartCoroutine(ShotgunBullet(shotGunBullet));
        }
    }

    IEnumerator ShotgunBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(Choises.shotGunBulletDeSpawnTime1);

        if(bullet.activeInHierarchy == true) { StartCoroutine(ScaleDownBullets(bullet, 2)); }
    }
    #endregion

    #region shootBulletFromMp4
    public GameObject targetMp4Enemy;
    public int timesMp4Clicked;
    private Transform mp4Target;

    public void ShootMp4()
    {
        if (MobileScript.isMobile == true)
        {
            if (timesMp4Clicked == 1)
            {
                if (targetMp4Enemy == null) { targetMp4Enemy = GetRandomActiveEnemy(enemies); }
                else { if (targetMp4Enemy.activeInHierarchy == false) { targetMp4Enemy = GetRandomActiveEnemy(enemies); } }
            }
            else { targetMp4Enemy = GetRandomActiveEnemy(enemies); }

            if (targetMp4Enemy == null) { return; }
            else { timesMp4Clicked = 1; }

            mp4Target = targetMp4Enemy.transform;
            Vector2 direction = targetMp4Enemy.transform.position - gun3.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            gun3.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gun3Direction = direction.normalized;
        }
        else
        {
            gun3Direction = mp4Dir.normalized;
        }
    
        if (isMp4Ready == true && MobileScript.isMobile == false) { knockBackCoroutine = StartCoroutine(ShootGun(gun3, 3, gun3Direction, 25)); }

        int random = Random.Range(1, 5);
        if (random == 1) { audioManager.Play("Mp1"); }
        if (random == 2) { audioManager.Play("Mp2"); }
        if (random == 3) { audioManager.Play("Mp3"); }
        if (random == 4) { audioManager.Play("Mp4"); }

        GameObject gunBullet = ObjectPool.instance.GetMP4BulletFromPool();
        gunBullet.transform.localScale = new Vector2(ObjectPool.mp4BulletSize, ObjectPool.mp4BulletSize);
        gunBullet.transform.position = mp4BulletStartingPos.transform.position;

        Rigidbody2D rb = gunBullet.GetComponent<Rigidbody2D>();
        rb.velocity = gun3Direction * Choises.mp4Speed;

        StartCoroutine(Mp4Bullet(gunBullet));
    }

    public Transform mp4BulletStartingPos;
    IEnumerator Mp4Bullet(GameObject bullet)
    {
        yield return new WaitForSeconds(Choises.mp4DespawnTime);

        if(bullet.activeInHierarchy == true) { StartCoroutine(ScaleDownBullets(bullet, 3)); }
    }
    #endregion

    #region shoot crossbow
    public GameObject targetCrossbowEnemy;
    public int timesCrossbowClicked;
    private Transform crossbowTarget;

    public void ShootCrossbow()
    {
        if (MobileScript.isMobile == true)
        {
            if (timesCrossbowClicked == 1)
            {
                if (targetCrossbowEnemy == null) { targetCrossbowEnemy = GetRandomActiveEnemy(enemies); }
                else { if (targetCrossbowEnemy.activeInHierarchy == false) { targetCrossbowEnemy = GetRandomActiveEnemy(enemies); } }
            }
            else { targetCrossbowEnemy = GetRandomActiveEnemy(enemies); }

            if (targetCrossbowEnemy == null) { return; }
            else { timesCrossbowClicked = 1; }

            crossbowTarget = targetCrossbowEnemy.transform;
            Vector2 direction = targetCrossbowEnemy.transform.position - crossbow.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            crossbow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gun4Direction = direction.normalized;
        }
        else
        {
            gun4Direction = crossbowDir.normalized;
        }
       
        if (isCrossbowReady == true && MobileScript.isMobile == false) { knockBackCoroutine = StartCoroutine(ShootGun(crossbow, 4, gun4Direction, 40)); }

        audioManager.Play("Crossbow");
        GameObject crossbowArrow = ObjectPool.instance.GetCrossbowArrowFromPool();

        Rigidbody2D rb = crossbowArrow.GetComponent<Rigidbody2D>();
        boltIcon.SetActive(false);
        crossbowArrow.transform.localScale = new Vector2(ObjectPool.boltSize, ObjectPool.boltSize);
        crossbowArrow.transform.position = crossbowStartingPos.transform.position;
        rb.simulated = true;

        rb.velocity = gun4Direction * Choises.crossbowSpeed;
        float arrowRotation = Mathf.Atan2(gun4Direction.y, gun4Direction.x) * Mathf.Rad2Deg;
        crossbowArrow.transform.rotation = Quaternion.Euler(0, 0, arrowRotation);

        StartCoroutine(CrossbowArrow());
    }

    public Transform crossbowStartingPos;
    public GameObject boltIcon;
    IEnumerator CrossbowArrow()
    {
        yield return new WaitForSeconds(0.15f);
        boltIcon.SetActive(true);
    }
    #endregion

    #region Button bounce on ARENA
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arena")
        {
            var speed = lastVelocity.magnitude / 3;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            buttonRB.velocity = direction * Mathf.Max(speed, 0);
        }

        lastVelocity = buttonRB.velocity;
    }
    #endregion

    #region shoot big piercing bullets
    public Transform bigPiercingPos;

    IEnumerator BigPiceringBullet()
    {
        int random = Random.Range(1,3);
        if(random == 1) { audioManager.Play("Cannon1"); }
        if (random == 2) { audioManager.Play("Cannon2"); }

        GameObject bigPiecringBullet = ObjectPool.instance.GetBigPiercingBulletFromPool();
        bigPiecringBullet.transform.localScale = new Vector2(ObjectPool.bigPiercingBulletSize, ObjectPool.bigPiercingBulletSize);
        bigPiecringBullet.transform.position = bigPiercingPos.transform.position;
        Rigidbody2D rb = bigPiecringBullet.GetComponent<Rigidbody2D>();

        rb.velocity = gun3Direction * Choises.bigBulletSpeed;

        yield return new WaitForSeconds(Choises.bigBulletLastTime);

        if (bigPiecringBullet.activeInHierarchy == true) { StartCoroutine(ScaleDownBullets(bigPiecringBullet, 4)); }
    }
    #endregion

    #region ScaleDownBullets
    IEnumerator ScaleDownBullets(GameObject bullet, int gunNumber)
    {
        Vector2 bulletScale = bullet.transform.localScale;
        Vector2 zeroScale = new Vector2(0, 0);

        float duration = Random.Range(0.25f, 0.4f);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            bullet.transform.localScale = Vector2.Lerp(bulletScale, zeroScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if(gunNumber == 1) { ObjectPool.instance.ReturnBulletGun1FromPool(bullet); }
        if (gunNumber == 2) { ObjectPool.instance.ReturnShotgunBulletFromPool(bullet); }
        if (gunNumber == 3) { ObjectPool.instance.ReturnMP4BulletFromPool(bullet); }
        if (gunNumber == 4) { ObjectPool.instance.ReturnBigPiercingBulletFromPool(bullet); }
    }
    #endregion

    #region Triggered Enter 2D
    public ButtonClick buttonClickScript;
    public bool isPlaying = false;
    public ParticleSystem skullSuckParticle;

    public GameObject ritualObject;
    public Choises choisesScipt;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 15)
        {
            //SkullHarvestBuff();

            if (!skullSuckParticle.isPlaying)
            {
                //StartCoroutine(PlayParticleAndSetFlag());
            }
        }

        if (other.gameObject.name == "RitualCollider")
        {
            ButtonClick.isRitualSpawnedIn = false;
            buttonClickScript.StopRitual();

            choisesScipt.RandomAbilitites(1);
            SettingsOptions.ritualsEntered += 1;
            audioManager.Play("RitualEnter");
        }
        if (other.gameObject.name == "spikeOut")
        {
            Champion1Movement.hitChampion1Stab = true;
            TextPopUpBehavior.enemyDamageAmount = Champion1Movement.champion1SpikeDamage;
            Choises.buttonHealth -= Champion1Movement.champion1SpikeDamage;
        }
    }
    #endregion

    #region skull harvest

    public void SkullHarvestBuff()
    {
        Choises.skullsConsumedCount += 1;
        //ButtonClick.pointsPerClick += 0.4f;

        int skullHarvestBuffsAviable;
        skullHarvestBuffsAviable = 0;

        //Check how many aviable buffs.
        skullHarvestBuffsAviable += 1;
        #region Adding Aviable Buffs
        //Basic
        if (Choises.choseIdleClicking == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.choseCritClicks == true) { skullHarvestBuffsAviable += 2; }

        //Defense
        if (Choises.choseHealthBar == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chooseHeartCollect == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.choseSmallShields == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseShield_BounceOff == true) { skullHarvestBuffsAviable += 2; }

        //Ranged
        if (Choises.choseShootSmallBullets == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chose_Gun1 == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chose_gun2 == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chooseHomingBullets == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseCrossBow == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseTrippleShot == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chooseBigPiercingBulletGun == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseGunMp4 == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseButtonCharge == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseArrows == true) { skullHarvestBuffsAviable += 1; }

        //Melee
        if (Choises.choseBoxingGlove == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.chooseStabbingSpikes == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.chooseSpikes == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.choseSpinningKnifes == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.chooseSawBlade == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chooseBigSpike == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.chooseHammer == true) { skullHarvestBuffsAviable += 2; }

        //Other
        if (Choises.chosePointsDrop == true) { skullHarvestBuffsAviable += 2; }
        if (Choises.choseInvincibility == true) { skullHarvestBuffsAviable += 1; }
        if (Choises.choseStopTime == true) { skullHarvestBuffsAviable += 1; }
        #endregion

        int random = Random.Range(0, skullHarvestBuffsAviable);
        int skullHarvestMinus;
        skullHarvestMinus = skullHarvestBuffsAviable;

        #region Random 3 Basic Abilitites
        //Points Per Click
        skullHarvestMinus -= 1;
        if (random == skullHarvestMinus)
        { 
            Choises.SHpointPerClick += (100f / Choises.skullHarvestStatDivide);
            ButtonClick.pointsPerClick += (100f / Choises.skullHarvestStatDivide);
           
            //Debug.Log(Choises.SHpointPerClick);
        }

        if (Choises.choseIdleClicking == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus) 
            { 
                if(Choises.timeBetweenClicks > 0.16f)
                {
                    Choises.timeBetweenClicks -= (0.008f / Choises.skullHarvestStatDivide);
                    Choises.SHidleClicks += (0.008f / Choises.skullHarvestStatDivide);
                }
            }
        }
        if (Choises.choseCritClicks == true) 
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus) 
            {   Choises.critClicksChance += (0.5f / Choises.skullHarvestStatDivide);
                Choises.SHcritChance += (0.5f / Choises.skullHarvestStatDivide);
                //Debug.Log(Choises.SHcritChance);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus) {
                Choises.critClicksBonus += (2f / Choises.skullHarvestStatDivide);
                Choises.SHcritIncrease += (2f / Choises.skullHarvestStatDivide);
                //Debug.Log(Choises.SHcritIncrease);
            }
        }
        #endregion

        #region Defense Abilitites
        if (Choises.choseHealthBar == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.maxButtonHealth += (75f / Choises.skullHarvestStatDivide);
                Choises.SHmaxHealth += (75f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.healthRegenPerSecond += (9f / Choises.skullHarvestStatDivide);
                Choises.SHregen += (9f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseHeartCollect == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.bigHeartHPHeal += (32f / Choises.skullHarvestStatDivide);
                Choises.SHbigHEarHP += (32f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseSmallShields == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.smallShieldHP += (13f / Choises.skullHarvestStatDivide);
                Choises.SHsmallShieldHP += (13f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                if(Choises.smallShieldRechargeTimer > 0.5f)
                {
                    Choises.smallShieldRechargeTimer -= (0.9f / Choises.skullHarvestStatDivide);
                    Choises.SHsmallShieldRecharge += (0.9f / Choises.skullHarvestStatDivide);
                }
            }
        }

        if (Choises.choseShield_BounceOff == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.shieldBounce_health += (9f / Choises.skullHarvestStatDivide);
                Choises.SHbounceHP += (9f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                if(Choises.reChargeTimer > 0.8f)
                {
                    Choises.reChargeTimer -= (0.8f / Choises.skullHarvestStatDivide);
                    Choises.SHbouncyRecharge += (0.8f / Choises.skullHarvestStatDivide);
                }
            }
        }
        #endregion

        #region Guns
        if (Choises.choseShootSmallBullets == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.smallBulletDamage += (20f / Choises.skullHarvestStatDivide);
                Choises.SHuziDamage += (20f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.smallBulletSpeed += (9f / Choises.skullHarvestStatDivide);
                Choises.SHuziSpeed += (9f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chose_Gun1 == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.bulletGun1_Damage += (14f / Choises.skullHarvestStatDivide);
                Choises.SHPistolDamage += (14f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.bulletGun1_Speed += (10f / Choises.skullHarvestStatDivide);
                Choises.SHpistolSpeed += (10f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chose_gun2 == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.shotGunBulletDamage += (7f / Choises.skullHarvestStatDivide);
                Choises.shotGunBulletDamage2 += (7f / Choises.skullHarvestStatDivide);
                Choises.SHshotgunDamage += (7f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.shotGunBulletSpeed1 += (7f / Choises.skullHarvestStatDivide);
                Choises.shotGunBulletSpeed2 += (7f / Choises.skullHarvestStatDivide);
                Choises.SHshotgunSpeed += (7f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseHomingBullets == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.homingBulletDamage += (13f / Choises.skullHarvestStatDivide);
                Choises.SHawpDamage += (13f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.homignBulletSpeed += (15f / Choises.skullHarvestStatDivide);
                Choises.SHawpSpeed += (15f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseTrippleShot == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.trippleShotDamage += (12f / Choises.skullHarvestStatDivide);
                Choises.SHdeagleDamage += (12f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.trippleShotSpeed += (8f / Choises.skullHarvestStatDivide);
                Choises.SHdeagleSpeed += (8f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseCrossBow == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.crossbowDamage += (18f / Choises.skullHarvestStatDivide);
                Choises.SHcrossbowDamage += (18f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.crossbowSpeed += (9f / Choises.skullHarvestStatDivide);
                Choises.SHcrossbowSpeed += (9f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseBigPiercingBulletGun == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.bigBulletDamage += (11f / Choises.skullHarvestStatDivide);
                Choises.SHcannonDamage += (11f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.bigBulletSpeed += (8f / Choises.skullHarvestStatDivide);
                Choises.SHcannonSpeed += (8f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseGunMp4 == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.mp4Damage += (11f / Choises.skullHarvestStatDivide);
                Choises.SHmp4Damage += (11f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.mp4Speed += (9f / Choises.skullHarvestStatDivide);
                Choises.SHmp4Speed += (9f / Choises.skullHarvestStatDivide);
            }
        }
        #endregion

        #region Charged And arrow
        if (Choises.choseButtonCharge == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.chargedBulletMaxDamage += (10f / Choises.skullHarvestStatDivide);
                Choises.SHchargeBulletDamage += (10f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                if (Choises.chargedBulletChargeTime > 1f)
                {
                    Choises.chargedBulletChargeTime -= (0.8f / Choises.skullHarvestStatDivide);
                    Choises.SHchargeBulletTime += (0.8f / Choises.skullHarvestStatDivide);
                }
            }
        }

        if (Choises.choseArrows == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.arrowDamage += (14f / Choises.skullHarvestStatDivide);
                Choises.SHarrowDamage += (14f / Choises.skullHarvestStatDivide);
            }
        }
        #endregion

        #region Melee 
        if (Choises.choseBoxingGlove == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.boxingGloveKnockbackAmount += (4f / Choises.skullHarvestStatDivide);
                Choises.SHboxingForce += (4f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseStabbingSpikes == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.stabbingSpikeDamage += (20f / Choises.skullHarvestStatDivide);
                Choises.SHstabbyDamage += (20f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseSpikes == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.spikeDamagePerSecond += (8f / Choises.skullHarvestStatDivide);
                Choises.SHtinySpikeDamage += (8f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseSpinningKnifes == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.knifeDamage += (23f / Choises.skullHarvestStatDivide);
                Choises.SHknifeDamage += (23f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseSawBlade == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.sawBladeDamage += (11f / Choises.skullHarvestStatDivide);
                Choises.SHsawBladeDamage += (11f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.sawBladeSpeed += (11f / Choises.skullHarvestStatDivide);
                Choises.SHsawbladeSpeed += (11f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseBigSpike == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.bigSpikeDamage += (15f / Choises.skullHarvestStatDivide);
                Choises.SHswordDamage += (15f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.swordSpeed += (15f / Choises.skullHarvestStatDivide);
                Choises.SHswordSpeed += (15f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.chooseHammer == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.hammerDamage += (27f / Choises.skullHarvestStatDivide);
                Choises.SHhammerDamage += (27f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.hammerStunTime += (7f / Choises.skullHarvestStatDivide);
                Choises.SHhammerStunTime += (7f / Choises.skullHarvestStatDivide);
            }
        }
        #endregion

        #region Other
        if (Choises.chosePointsDrop == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.pointDropBasicPoints += (7f / Choises.skullHarvestStatDivide);
                Choises.SHpointDropBasic += (7f / Choises.skullHarvestStatDivide);
            }
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.pointDropRarityIncreasePoints += (5f / Choises.skullHarvestStatDivide);
                Choises.SHpointDropRarity += (5f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseInvincibility == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                Choises.invincibilityTimeAdded += (4f / Choises.skullHarvestStatDivide);
                Choises.SHinvinTime += (4f / Choises.skullHarvestStatDivide);
            }
        }

        if (Choises.choseStopTime == true)
        {
            skullHarvestMinus -= 1;
            if (random == skullHarvestMinus)
            {
                if(Choises.stopTimeTimer < 8)
                {
                    Choises.stopTimeTimer += (4f / Choises.skullHarvestStatDivide);
                    Choises.SHstopwatchTime += (4f / Choises.skullHarvestStatDivide);
                }
            }
        }
        #endregion
    }
    #endregion

    private IEnumerator PlayParticleAndSetFlag()
    {
        skullSuckParticle.Stop();
        isPlaying = true;
        skullSuckParticle.Play();

        // Wait for the duration of the particle system
        yield return new WaitForSeconds(skullSuckParticle.main.duration);

        isPlaying = false;
    }
}
