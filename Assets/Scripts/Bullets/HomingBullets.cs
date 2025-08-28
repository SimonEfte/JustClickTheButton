using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HomingBullets : MonoBehaviour
{
    private Transform target;
    public bool startHoming;

    public GameObject damageManagerObject;
    public bool setNewTarget, setFirstTarget;
    private bool endingTransitionSetInactive;
    private DamageDealtManager damageManager;
    public Vector3 lastVelocity;
    public Rigidbody2D rb;
    private Collider2D bulletCollider;
    public bool bouncedOffBossShield;
    public Transform childTransform;

    public void Awake()
    {
        damageManagerObject = GameObject.Find("BulletDamageManager");
        damageManager = damageManagerObject.GetComponent<DamageDealtManager>();
        bulletCollider = GetComponent<Collider2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        childTransform = gameObject.transform.Find("BossBouncedSprite");
    }


    private void OnEnable()
    {
        gameObject.layer = 6;
        bulletCollider.isTrigger = false;
        bouncedOffBossShield = false;
        childTransform.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (Choises.bossChosenSetStuffInactive == true || Choises.playerDied == true || Choises.isInWinScreen == true)
        {
            if (endingTransitionSetInactive == false)
            {
                ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
                endingTransitionSetInactive = true;
            }
        }

        lastVelocity = rb.linearVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region hit small enemy
        if (collision.gameObject.tag == "SmallEnemy")
        {
            damageManager.DamageSmallEnemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region hit speedster
        if (collision.gameObject.tag == "Speedster")
        {
            damageManager.DamageSmallEnemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region hit big enemy
        if (collision.gameObject.tag == "BigEnemy")
        {
            damageManager.DamageBigEnemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region hit titan
        if (collision.gameObject.tag == "Titan")
        {
            damageManager.DamageBigEnemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region HIT BOSS SMALL SHIELD
        if (collision.gameObject.tag == "SmallShield")
        {
            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region BOSS BOUNCE SHIELD
        if (collision.gameObject.tag == "BossBigShield")
        {
            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region Hit Champions 
        if (gameObject.name == "HomingBullet(Clone)" && collision.gameObject.tag == "Champion")
        {
            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region All bullets hit arena - BOUNCING
        if (collision.gameObject.tag == "Arena")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.linearVelocity = direction * Mathf.Max(speed, 0);
        }
        #endregion

        #region Hit Boss Arena
        if (collision.gameObject.layer == 16)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.linearVelocity = direction * Mathf.Max(speed, 0);
        }
        #endregion

        #region Hit enemy BOUNCE SHIELD
        if (collision.gameObject.tag == "BossBigShield")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.linearVelocity = direction * Mathf.Max(speed, 0);

            childTransform.gameObject.SetActive(true);

            //gameObject.tag = "BulletBounced";
            bulletCollider.isTrigger = true;
            gameObject.layer = 10;
            bouncedOffBossShield = true;
        }
        #endregion

        #region hit gunner
        if (collision.gameObject.tag == "RagingGunner")
        {
            damageManager.DamageShootingEemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Hit Boss 
        if (gameObject.name == "HomingBullet(Clone)" && collision.gameObject.tag == "Boss")
        {
            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region hit heavyshot
        if (collision.gameObject.tag == "HeavyShot")
        {
            damageManager.DamageShootingEemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region hit shooting enemy
        if (collision.gameObject.tag == "shootingEnemy")
        {
            damageManager.DamageShootingEemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

        #region hit sniper
        if (collision.gameObject.tag == "Sniper")
        {
            damageManager.DamageShootingEemy_Homing();

            ObjectPool.instance.ReturnHomingBulletFromPool(gameObject);
        }
        #endregion

       
    }


}
