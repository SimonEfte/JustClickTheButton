using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public static bool bulletHitButton, bossBulletHitButton;
    public static Vector3 damagePos;

    private Transform mainButton, boss;

    Vector3 lastVelocity;
    private Rigidbody2D rb;

    public float bulletSpeed;
    public bool bouncesOffShield;

    public bool isBulletSharpshooter, isBulletSniper, isBulletRagingGunner, isBulletHeavyShot;

    public GameObject damageManagerObject;
    public bool isBossBullet;

    public float xOffset, yOffset;
    private bool endingTransitionSetInactive;

    private Transform childTransform;
    private DamageDealtManager damageManager;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        childTransform = gameObject.transform.Find("bouncedEffect");
        mainButton = GameObject.FindWithTag("Button").transform;
        damageManagerObject = GameObject.Find("BulletDamageManager");
        damageManager = damageManagerObject.GetComponent<DamageDealtManager>();
    }

    private void Start()
    {
        xOffset = Random.Range(-16, 16);
        yOffset = Random.Range(-0, 0);
    }

    private void Update()
    {
        if(Choises.bossChosenSetStuffInactive == true || Choises.playerDied == true || Choises.isInWinScreen)
        {
            if(endingTransitionSetInactive == false)
            {
                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
                endingTransitionSetInactive = true;
            }
        }

        lastVelocity = rb.linearVelocity;
        if (isBossBullet == true && BossMechanics.doneCharging == false)
        {
            Vector2 bossPosition = boss.transform.position;
            Vector2 newPosition = new Vector2(
           bossPosition.x + xOffset,
           bossPosition.y + yOffset
           );

            gameObject.transform.position = newPosition;
        }
    }

    public void OnEnable()
    {
        dangerButtonBulletHitButton = false;
        endingTransitionSetInactive = false;
        isBossBullet = false;
        isBulletSharpshooter = false;
        isBulletSniper = false;
        isBulletRagingGunner = false;
        isBulletHeavyShot = false;
        gameObject.layer = 10;

        StartCoroutine(wait());
        Invoke("BossBulletOff", BossMechanics.bigBulletChargeTime * BossMechanics.bigBulletsCount);
        bouncesOffShield = false;
      
        childTransform.gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        isBossBullet = false;
    }

    public float waitTime;

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameObject.tag == "DangerButtonBullets")
        {
            bulletSpeed = 50f; 
        }
        if (gameObject.tag == "EnemyBullet")
        { 
            bulletSpeed = 48f; isBulletSharpshooter = true; waitTime =  ShootingEnemyMovement.sharpshooterChargeTime;
        }
        if (gameObject.tag == "EnemyBulletSniper") 
        { 
            bulletSpeed = 80f; isBulletSniper = true; waitTime = ShootingEnemyMovement.sniperChargeTime;
        }
        if (gameObject.tag == "RagingGunnerShot") 
        {
            bulletSpeed = 50f; isBulletRagingGunner = true; waitTime = ShootingEnemyMovement.gunnerChargeTime;
        }
        if (gameObject.tag == "EnemyBulletHeavyShot") 
        { 
            bulletSpeed = 26f; isBulletHeavyShot = true; waitTime =  ShootingEnemyMovement.heavyShotChargeTime;
        }

        if (gameObject.tag != "SmallBossBullet" && gameObject.tag != "DangerButtonBullets")
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 directionToButton = mainButton.position - transform.position;

            directionToButton.Normalize();

            rb.linearVelocity = directionToButton * bulletSpeed;

            if (gameObject.transform.localScale.x < 0.4f)
            {
                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
            }
        }

        if (gameObject.tag == "SmallBossBullet")
        {
            if (gameObject.tag == "SmallBossBullet")
            {
                boss = GameObject.FindWithTag("Boss").transform;
                if(bossBulletCoroutine != null) { StopCoroutine(bossBulletCoroutine); bossBulletCoroutine = StartCoroutine(ReturnBullet()); }
                else { bossBulletCoroutine = StartCoroutine(ReturnBullet()); }
            }

            isBossBullet = true;
        }
    }

    public Coroutine bossBulletCoroutine;
    IEnumerator ReturnBullet()
    {
        yield return new WaitForSeconds(10);
        bossBulletCoroutine = null;
        ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
    }

    public void BossBulletOff()
    {
        isBossBullet = false;
    }

    public static bool dangerButtonBulletHitButton;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region Hit Shield BOUNCE
        if (collision.gameObject.tag == "Shield_Bounce")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.linearVelocity = direction * Mathf.Max(speed, 0);

            childTransform.gameObject.SetActive(true);

            gameObject.tag = "BulletBounced";
            gameObject.layer = 6;
            bouncesOffShield = true;
        }
        #endregion

        #region Enemy bullet hit button
        if (gameObject.name == "EnemyBullet(Clone)" && collision.gameObject.tag == "Button")
        {
            if (gameObject.tag == "EnemyBullet")
            {
                Choises.buttonHealth -= Choises.smallEnemyBulletDamage;
                TextPopUpBehavior.enemyDamageAmount = Choises.smallEnemyBulletDamage;
            }

            if (gameObject.tag == "EnemyBulletSniper")
            {
                Choises.buttonHealth -= Choises.sniperEnemyBulletDamage;
                TextPopUpBehavior.enemyDamageAmount = Choises.sniperEnemyBulletDamage;
            }

            if (gameObject.tag == "RagingGunnerShot")
            {
                Choises.buttonHealth -= Choises.raginGunnerBulletDamage;
                TextPopUpBehavior.enemyDamageAmount = Choises.raginGunnerBulletDamage;
            }

            if (gameObject.tag == "EnemyBulletHeavyShot")
            {
                Choises.buttonHealth -= Choises.heavyShotDamage;
                TextPopUpBehavior.enemyDamageAmount = Choises.heavyShotDamage;
            }

            if (gameObject.tag == "SmallBossBullet")
            {
                Choises.buttonHealth -= BossMechanics.bossBulletDamage;
                TextPopUpBehavior.enemyDamageAmount = BossMechanics.bossBulletDamage;
            }

            damagePos = gameObject.transform.localPosition;
            bulletHitButton = true;

            ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
        }
        #endregion

        #region Enemy bullet hit arena
        if (gameObject.name == "EnemyBullet(Clone)" && collision.gameObject.tag == "Arena")
        {
            ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
        }
        #endregion

        #region Enemy bullet bounced - Hit small enemy
        if (collision.gameObject.tag == "SmallEnemy")
        {
            if (bouncesOffShield == true)
            {
                if (isBulletSharpshooter == true) { damageManager.DamageSmallEnemy(Choises.smallEnemyBulletDamage); }
                if (isBulletSniper == true) { damageManager.DamageSmallEnemy(Choises.sniperEnemyBulletDamage); }
                if (isBulletHeavyShot == true) { damageManager.DamageSmallEnemy(Choises.heavyShotDamage); }
                if (isBulletRagingGunner == true) { damageManager.DamageSmallEnemy(Choises.raginGunnerBulletDamage); }

                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject); 
            }
        }
        #endregion

        #region Enemy bullet bounced - Speedster
        if (collision.gameObject.tag == "Speedster")
        {
            if (bouncesOffShield == true)
            {
                if (isBulletSharpshooter == true) { damageManager.DamageSmallEnemy(Choises.smallEnemyBulletDamage); }
                if (isBulletSniper == true) { damageManager.DamageSmallEnemy(Choises.sniperEnemyBulletDamage); }
                if (isBulletHeavyShot == true) { damageManager.DamageSmallEnemy(Choises.heavyShotDamage); }
                if (isBulletRagingGunner == true) { damageManager.DamageSmallEnemy(Choises.raginGunnerBulletDamage); }

                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
            }
        }
        #endregion

        #region Enemy bullet bounced - Hit big enemy
        if (collision.gameObject.tag == "BigEnemy")
        {
            if (bouncesOffShield == true)
            {
                if (isBulletSharpshooter == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.smallEnemyBulletDamage); }
                if (isBulletSniper == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.sniperEnemyBulletDamage); }
                if (isBulletHeavyShot == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.heavyShotDamage); }
                if (isBulletRagingGunner == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.raginGunnerBulletDamage); }

                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
            }
        }
        #endregion'

        #region Enemy bullet bounced - Hit big enemy
        if (collision.gameObject.tag == "Titan")
        {
            if (bouncesOffShield == true)
            {
                if (isBulletSharpshooter == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.smallEnemyBulletDamage); }
                if (isBulletSniper == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.sniperEnemyBulletDamage); }
                if (isBulletHeavyShot == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.heavyShotDamage); }
                if (isBulletRagingGunner == true) { damageManager.DamageBigEnemy_ShieldBounced(Choises.raginGunnerBulletDamage); }

                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
            }
        }
        #endregion'

        #region Bullet Bounces - Hit Gunner
        if (collision.gameObject.tag == "RagingGunner")
        {
            if (bouncesOffShield == true)
            {
                if (isBulletSharpshooter == true) { damageManager.DamageShootingEnemy(Choises.smallEnemyBulletDamage); }
                if (isBulletSniper == true) { damageManager.DamageShootingEnemy(Choises.sniperEnemyBulletDamage); }
                if (isBulletHeavyShot == true) { damageManager.DamageShootingEnemy(Choises.heavyShotDamage); }
                if (isBulletRagingGunner == true) { damageManager.DamageShootingEnemy(Choises.raginGunnerBulletDamage); }

                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
            }
        }
        #endregion

        #region Hit Boss Arena
        if (gameObject.tag == "SmallBossBullet")
        {
            if (collision.gameObject.layer == 16)
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

                rb.linearVelocity = direction * Mathf.Max(speed, 0);
            }
        }
        #endregion

        #region Bouncy Shield Bounce Hit Boss Arena
        if (gameObject.tag == "BulletBounced")
        {
            if (collision.gameObject.layer == 16)
            {
                var speed = lastVelocity.magnitude;
                var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

                rb.linearVelocity = direction * Mathf.Max(speed, 0);
            }
        }
        #endregion

        if (collision.gameObject.tag == "Button")
        {
            if(gameObject.tag == "DangerButtonBullets")
            {
                Choises.buttonHealth -= DangerButtonMovement.dangerButtonBulletDamage;
                TextPopUpBehavior.enemyDamageAmount = DangerButtonMovement.dangerButtonBulletDamage;
                dangerButtonBulletHitButton = true;
                //Debug.Log("Hit");
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Bouncy Shield Bounce Hit Boss
        if (gameObject.tag == "BulletBounced")
        {
            if (collision.gameObject.name == "Boss")
            {
                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
            }
        }
        #endregion

        if (collision.gameObject.tag == "shootingEnemy" || collision.gameObject.tag == "Sniper" || collision.gameObject.tag == "HeavyShot")
        {
            if (bouncesOffShield == true)
            {
                if (isBulletSharpshooter == true) { damageManager.DamageShootingEnemy(Choises.smallEnemyBulletDamage);  }
                if (isBulletSniper == true) { damageManager.DamageShootingEnemy(Choises.sniperEnemyBulletDamage);  }
                if (isBulletRagingGunner == true) { damageManager.DamageShootingEnemy(Choises.raginGunnerBulletDamage); }
                if (isBulletHeavyShot == true) { damageManager.DamageShootingEnemy(Choises.heavyShotDamage); }

                ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject); 
            }
        }

        if (collision.gameObject.tag == "SmallShields")
        {
            ObjectPool.instance.ReturnSmallEnemyBulletFromPool(gameObject);
        }
    }
}
