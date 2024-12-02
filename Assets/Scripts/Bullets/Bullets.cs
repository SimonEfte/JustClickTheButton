using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D bulletCollider;

    public bool bouncedOffBossShield;

    Vector3 lastVelocity;
    private bool isNearArena;
    public GameObject damageManagerObject;

    public static bool bossShieldBounceHitButton;
    public static Vector2 bossShieldBouncePos;
    private bool endingTransitionSetInactive;
    private DamageDealtManager damageManager;

    public Transform childTransform;

    public GameObject overlappSoundManager;
    public OverlappingSounds overlapp;

    private void Awake()
    {
        overlappSoundManager = GameObject.Find("OverlappingSounds");
        overlapp = overlappSoundManager.GetComponent<OverlappingSounds>();

        bulletCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        damageManagerObject = GameObject.Find("BulletDamageManager");
        damageManager = damageManagerObject.GetComponent<DamageDealtManager>();
        childTransform = gameObject.transform.Find("BossBouncedSprite");
    }

    private void OnEnable()
    {
        bouncedOffBossShield = false;
        endingTransitionSetInactive = false;
        gameObject.layer = 6;

        if (gameObject.tag != "TrippleBullet")
        {
            bulletCollider.isTrigger = false;
            childTransform.gameObject.SetActive(false);
        }
    }

    public void Update()
    {
        lastVelocity = rb.velocity;

        if (Choises.bossChosenSetStuffInactive == true || Choises.playerDied || Choises.isInWinScreen == true)
        {
            if (endingTransitionSetInactive == false)
            {
                if (gameObject.name == "TrippleBullet(Clone)")
                {
                    ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
                }
                if (gameObject.name == "smallBullet(Clone)")
                {
                    ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
                }
                if (gameObject.name == "bulletFromGun_1(Clone)")
                {
                    ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
                }
                if (gameObject.name == "ShotgunBullet(Clone)")
                {
                    ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
                }
                if (gameObject.name == "MP4Bullet(Clone)")
                {
                    ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
                }

                endingTransitionSetInactive = true;
            }
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Small enemy 
        #region SMALL ENEMY - Small bullet - No Piercing
        if (gameObject.name == "smallBullet(Clone)" && collision.gameObject.tag == "SmallEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                SmallBulletDamage_SmallEnemy();
                ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
            }
        }
        #endregion

        #region SMALL ENEMY - Pistol - No piercing
        if (gameObject.name == "bulletFromGun_1(Clone)" && collision.gameObject.tag == "SmallEnemy")
        {
            Gun1Damage_SmallEnemy();
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region SMALL ENEMY - Shotgun - No Piercing
        if (gameObject.name == "ShotgunBullet(Clone)" && collision.gameObject.tag == "SmallEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                ShotgunDamage_SmallEnemy();
                ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
            }
        }
        #endregion

        #region SMALL ENEMY - MP4 - No Piercing
        if (gameObject.name == "MP4Bullet(Clone)" && collision.gameObject.tag == "SmallEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Mp4Damage_SmallEnemy();
                ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
            }
        }
        #endregion

        //Speedster
        #region SEEDSTER - Small bullet - No Piercing
        if (gameObject.name == "smallBullet(Clone)" && collision.gameObject.tag == "Speedster")
        {
            if (Choises.chosePiercingBullets == false)
            {
                SmallBulletDamage_SmallEnemy();
                ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
            }
        }
        #endregion

        #region SPEEDSTER - Gun 1 - No Piercing
        if (gameObject.name == "bulletFromGun_1(Clone)" && collision.gameObject.tag == "Speedster")
        {
            Gun1Damage_SmallEnemy();
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region SPEEDSTER - Shotgun - No Piercing
        if (gameObject.name == "ShotgunBullet(Clone)" && collision.gameObject.tag == "Speedster")
        {
            if (Choises.chosePiercingBullets == false)
            {
                ShotgunDamage_SmallEnemy();
                ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
            }
        }
        #endregion

        #region SPEEDSTER - MP4 - No Piercing
        if (gameObject.name == "MP4Bullet(Clone)" && collision.gameObject.tag == "Speedster")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Mp4Damage_SmallEnemy();
                ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
            }
        }
        #endregion

        //Brute
        #region BRUTE - Small bullets No piercing
        if (gameObject.name == "smallBullet(Clone)" && collision.gameObject.tag == "BigEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                SmallBulletDamage_BigEnemy();
                ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
            }
        }
        #endregion

        #region BRUTE - Gun 1 bullet No piercing
        if (gameObject.name == "bulletFromGun_1(Clone)" && collision.gameObject.tag == "BigEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Gun1Damage_BigEnemy();
                ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
            }
        }
        #endregion

        #region BRUTE - shotgun bullet No piercing
        if (gameObject.name == "ShotgunBullet(Clone)" && collision.gameObject.tag == "BigEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                ShotgunDamage_BigEnemy();
                ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
            }
        }
        #endregion

        #region BRUTE - MP4 - No Piercing
        if (gameObject.name == "MP4Bullet(Clone)" && collision.gameObject.tag == "BigEnemy")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Mp4Damage_BigEnemy();
                ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
            }
        }
        #endregion

        //Titan
        #region Titan - Small bullets 
        if (gameObject.name == "smallBullet(Clone)" && collision.gameObject.tag == "Titan")
        {
            if (Choises.chosePiercingBullets == false)
            {
                SmallBulletDamage_BigEnemy();
                ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
            }
        }
        #endregion

        #region Titan - Gun 1 bullet
        if (gameObject.name == "bulletFromGun_1(Clone)" && collision.gameObject.tag == "Titan")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Gun1Damage_BigEnemy();
                ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
            }
        }
        #endregion

        #region Titan - shotgun bullet
        if (gameObject.name == "ShotgunBullet(Clone)" && collision.gameObject.tag == "Titan")
        {
            if (Choises.chosePiercingBullets == false)
            {
                ShotgunDamage_BigEnemy();
                ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
            }
        }
        #endregion

        #region Titan - MP4 
        if (gameObject.name == "MP4Bullet(Clone)" && collision.gameObject.tag == "Titan")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Mp4Damage_BigEnemy();
                ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
            }
        }
        #endregion

        //Raging Gunner
        #region RagingGunner - Small bullets 
        if (gameObject.name == "smallBullet(Clone)" && collision.gameObject.tag == "RagingGunner")
        {
            SmallBulletDamage_ShootingEnemy();
            ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
        }
        #endregion

        #region RagingGunner - Gun 1 bullet
        if (gameObject.name == "bulletFromGun_1(Clone)" && collision.gameObject.tag == "RagingGunner")
        {
            Gun1Damage_ShootingEnemy();
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region RagingGunner - shotgun bullet
        if (gameObject.name == "ShotgunBullet(Clone)" && collision.gameObject.tag == "RagingGunner")
        {
            ShotgunDamage_ShootingEnemy();
            ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
        }
        #endregion

        #region RagingGunner - MP4 
        if (gameObject.name == "MP4Bullet(Clone)" && collision.gameObject.tag == "RagingGunner")
        {
            Mp4Damage_ShootingEnemy();
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion


        //Arena and Boss
        #region All bullets hit arena - BOUNCING
        if (collision.gameObject.tag == "Arena")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0);
        }
        #endregion

        #region Hit Boss Arena
        if (collision.gameObject.layer == 16)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0);
        }
        #endregion

        #region Hit enemy BOUNCE SHIELD
        if (collision.gameObject.tag == "BossBigShield")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0);

            childTransform.gameObject.SetActive(true);

            //gameObject.tag = "BulletBounced";
            bulletCollider.isTrigger = true;
            gameObject.layer = 10;
            bouncedOffBossShield = true;
        }
        #endregion

        //Champions
        #region Hit champion - Broken Uzi bullet
        if (gameObject.name == "smallBullet(Clone)" && collision.gameObject.tag == "Champion")
        {
            ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
        }
        #endregion

        #region Hit champion - Pistol
        if (gameObject.name == "bulletFromGun_1(Clone)" && collision.gameObject.tag == "Champion")
        {
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region Hit champion - MP4
        if (gameObject.name == "MP4Bullet(Clone)" && collision.gameObject.tag == "Champion")
        {
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion

        #region Hit champion - Shotgun
        if (gameObject.name == "ShotgunBullet(Clone)" && collision.gameObject.tag == "Champion")
        {
            ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Sharpshooter enemy
        #region SHARPSHOOTER - Small bullet
        if (gameObject.name == "smallBullet(Clone)" && other.gameObject.tag == "shootingEnemy")
        {
            SmallBulletDamage_ShootingEnemy();
            if (Choises.chosePiercingBullets == false) { ObjectPool.instance.ReturnSmallBulletFromPool(gameObject); }
        }
        #endregion

        # region SHARPSHOOTER - Gun 1
        if (gameObject.name == "bulletFromGun_1(Clone)" && other.gameObject.tag == "shootingEnemy")
        {
            Gun1Damage_ShootingEnemy();
            if (Choises.chosePiercingBullets == false) { ObjectPool.instance.ReturnBulletGun1FromPool(gameObject); }
        }
        #endregion

        #region SHARPSHOOTER - Shotgun
        if (gameObject.name == "ShotgunBullet(Clone)" && other.gameObject.tag == "shootingEnemy")
        {
            ShotgunDamage_ShootingEnemy();
            if (Choises.chosePiercingBullets == false) { ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject); }
        }
        #endregion

        #region SHARPSHOOTER - MP4 - PIERCING
        if (gameObject.name == "MP4Bullet(Clone)" && other.gameObject.tag == "shootingEnemy")
        {
            Mp4Damage_ShootingEnemy();
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion

        #region SHARPSHOOTER - TRIPPLE 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "shootingEnemy")
        {
            Tripple_ShootingEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        //Sniper
        #region SNIPER - Small bullet
        if (gameObject.name == "smallBullet(Clone)" && other.gameObject.tag == "Sniper")
        {
            SmallBulletDamage_ShootingEnemy();
            if (Choises.chosePiercingBullets == false) { ObjectPool.instance.ReturnSmallBulletFromPool(gameObject); }
        }
        #endregion

        # region SNIPER - Gun 1
        if (gameObject.name == "bulletFromGun_1(Clone)" && other.gameObject.tag == "Sniper")
        {
            Gun1Damage_ShootingEnemy();
            if (Choises.chosePiercingBullets == false) { ObjectPool.instance.ReturnBulletGun1FromPool(gameObject); }
        }
        #endregion

        #region SNIPER - Shotgun
        if (gameObject.name == "ShotgunBullet(Clone)" && other.gameObject.tag == "Sniper")
        {
            ShotgunDamage_ShootingEnemy();
            if (Choises.chosePiercingBullets == false) { ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject); }
        }
        #endregion

        #region SNIPER - MP4 - PIERCING
        if (gameObject.name == "MP4Bullet(Clone)" && other.gameObject.tag == "Sniper")
        {
            Mp4Damage_ShootingEnemy();
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion

        #region SNIPER - TRIPPLE 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "Sniper")
        {
            Tripple_ShootingEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        //HeavyShot
        #region HeavyShot - Small bullets 
        if (gameObject.name == "smallBullet(Clone)" && other.gameObject.tag == "HeavyShot")
        {
            SmallBulletDamage_ShootingEnemy();
            ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
        }
        #endregion

        #region HeavyShot - Gun 1 bullet
        if (gameObject.name == "bulletFromGun_1(Clone)" && other.gameObject.tag == "HeavyShot")
        {
            Gun1Damage_ShootingEnemy();
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region HeavyShot - shotgun bullet
        if (gameObject.name == "ShotgunBullet(Clone)" && other.gameObject.tag == "HeavyShot")
        {
            ShotgunDamage_ShootingEnemy();
            ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
        }
        #endregion

        #region HeavyShot - MP4 
        if (gameObject.name == "MP4Bullet(Clone)" && other.gameObject.tag == "HeavyShot")
        {
            Mp4Damage_ShootingEnemy();
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion

        #region Heavyshot - Tripple 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "HeavyShot")
        {
            Tripple_ShootingEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        //Boss
        #region Hit Boss - Broken Uzi bullet
        if (gameObject.name == "smallBullet(Clone)" && other.gameObject.tag == "Boss")
        {
            ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
        }
        #endregion

        #region Hit Boss - Pistol
        if (gameObject.name == "bulletFromGun_1(Clone)" && other.gameObject.tag == "Boss")
        {
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region Hit Boss - Tripple Bullet
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "Boss")
        {
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        #region Hit Boss - MP4
        if (gameObject.name == "MP4Bullet(Clone)" && other.gameObject.tag == "Boss")
        {
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion

        #region Hit Boss - Shotgun
        if (gameObject.name == "ShotgunBullet(Clone)" && other.gameObject.tag == "Boss")
        {
            ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
        }
        #endregion

        //Tripple
        #region Titan - Tripple
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "Titan")
        {
            if (Choises.chosePiercingBullets == false)
            {
                Tripple_BigEnemy();
                ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
            }
        }
        #endregion

        #region RagingGunner - Tripple 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "RagingGunner")
        {
            Tripple_ShootingEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        #region BRUTE - TRIPPLE 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "BigEnemy")
        {
            Tripple_BigEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        #region SPEEDSTER - TRIPPLE 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "Speedster")
        {
            Tripple_SmallEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        #region SMALL ENEMY - TRIPPLE - 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "SmallEnemy")
        {
            Tripple_SmallEnemy();
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        //BOSS SMALL SHIELDS
        #region SMALL ENEMY - Small bullet - PIERCING
        if (gameObject.name == "smallBullet(Clone)" && other.gameObject.tag == "SmallShield")
        {
            ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
        }
        #endregion

        #region SMALL ENEMY - Gun 1 - PIERCING
        if (gameObject.name == "bulletFromGun_1(Clone)" && other.gameObject.tag == "SmallShield")
        {
            ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
        }
        #endregion

        #region SMALL ENEMY - Shotgun - PIERCING
        if (gameObject.name == "ShotgunBullet(Clone)" && other.gameObject.tag == "SmallShield")
        {
            ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
        }
        #endregion

        #region SMALL ENEMY - MP4 - PIERCING
        if (gameObject.name == "MP4Bullet(Clone)" && other.gameObject.tag == "SmallShield")
        {
            ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
        }
        #endregion

        #region SMALL SHIELD - TRIPPLE 
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "SmallShield")
        {
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        //Champions
        #region Hit champion - Tripple Bullet
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "Champion")
        {
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        #region TRIPPLE - BOSS BOUNCE SHIELD
        if (gameObject.name == "TrippleBullet(Clone)" && other.gameObject.tag == "BossBigShield")
        {
            ObjectPool.instance.ReturnTrippleShotFromPool(gameObject);
        }
        #endregion

        #region HIT BUTTON AFTER BOSS SHIELD BOUNCE
        if(BossMechanics.fightingBossFight == true)
        {
            if (gameObject.layer == 10 && gameObject.name == "bulletFromGun_1(Clone)" && other.gameObject.tag == "Button")
            {
                ObjectPool.instance.ReturnBulletGun1FromPool(gameObject);
                Choises.buttonHealth -= BossMechanics.bossShieldBounceDamage;
                TextPopUpBehavior.enemyDamageAmount = BossMechanics.bossShieldBounceDamage;
                bossShieldBounceHitButton = true;
                bossShieldBouncePos = gameObject.transform.position;
            }
            if (gameObject.layer == 10 && gameObject.tag == "Gun3Bullet" && other.gameObject.tag == "Button")
            {
                ObjectPool.instance.ReturnMP4BulletFromPool(gameObject);
                Choises.buttonHealth -= BossMechanics.bossShieldBounceDamage;
                TextPopUpBehavior.enemyDamageAmount = BossMechanics.bossShieldBounceDamage;
                bossShieldBounceHitButton = true;
                bossShieldBouncePos = gameObject.transform.position;
            }
            if (gameObject.layer == 10 && gameObject.name == "ShotgunBullet(Clone)" && other.gameObject.tag == "Button")
            {
                ObjectPool.instance.ReturnShotgunBulletFromPool(gameObject);
                Choises.buttonHealth -= BossMechanics.bossShieldBounceDamage;
                TextPopUpBehavior.enemyDamageAmount = BossMechanics.bossShieldBounceDamage;
                bossShieldBounceHitButton = true;
                bossShieldBouncePos = gameObject.transform.position;
            }
            if (gameObject.layer == 10 && gameObject.name == "smallBullet(Clone)" && other.gameObject.tag == "Button")
            {
                ObjectPool.instance.ReturnSmallBulletFromPool(gameObject);
                Choises.buttonHealth -= BossMechanics.bossShieldBounceDamage;
                TextPopUpBehavior.enemyDamageAmount = BossMechanics.bossShieldBounceDamage;
                bossShieldBounceHitButton = true;
                bossShieldBouncePos = gameObject.transform.position;
            }
        }
        #endregion
    }

    #region Particle Effect
    public void ParticleEffect()
    {
        GameObject particle = ObjectPool.instance.GetEnemyDamagedParticleFromPool();
        particle.transform.localPosition = gameObject.transform.localPosition;
    }
  
    #endregion

    #region small bullets DAMAGE
    public void SmallBulletDamage_SmallEnemy()
    {
        ParticleEffect();
        damageManager.DamageSmallEnemy_SmallBullet();
    }

    public void SmallBulletDamage_ShootingEnemy()
    {
        ParticleEffect();
        damageManager.DamageShootingEemy_SmallBullet();
    }

    public void SmallBulletDamage_BigEnemy()
    {
        ParticleEffect();
        damageManager.DamageBigEnemy_SmallBullet();
    }
    #endregion

    #region gun1 bullet DAMAGE
    public void Gun1Damage_SmallEnemy()
    {
        ParticleEffect();
        damageManager.DamageSmallEnemy_BulletFromGun1();
    }

    public void Gun1Damage_ShootingEnemy()
    {
        ParticleEffect();
        damageManager.DamageShootingEemy_BulletFromGun1();
    }

    public void Gun1Damage_BigEnemy()
    {
        ParticleEffect();
        damageManager.DamageBigEnemy_BulletFromGun1();
    }
    #endregion

    #region gun3 mp4 bullet DAMAGE
    public void Mp4Damage_SmallEnemy()
    {
        ParticleEffect();
        damageManager.DamageSmallEnemy_MP4();
    }

    public void Mp4Damage_ShootingEnemy()
    {
        ParticleEffect();
        damageManager.DamageShootingEemy_MP4();
    }

    public void Mp4Damage_BigEnemy()
    {
        ParticleEffect();
        damageManager.DamageBigEnemy_MP4();
    }
    #endregion

    #region shotgun bullet damage
    public void ShotgunDamage_SmallEnemy()
    {
        ParticleEffect();
        damageManager.DamageSmallEnemy_ShotgunBullet();
    }

    public void ShotgunDamage_ShootingEnemy()
    {
        ParticleEffect();
        damageManager.DamageShootingEemy_ShotgunBullet();
    }

    public void ShotgunDamage_BigEnemy()
    {
        ParticleEffect();
        damageManager.DamageBigEnemy_ShotgunBullet();
    }
    #endregion

    #region tripple bullet damage
    public void Tripple_SmallEnemy()
    {
        ParticleEffect();
        damageManager.DamageSmallEnemy_Tripple();
    }

    public void Tripple_ShootingEnemy()
    {
        ParticleEffect();
        damageManager.DamageShootingEnemy_Tripple();
    }

    public void Tripple_BigEnemy()
    {
        ParticleEffect();
        damageManager.DamageBigEnemy_Tripple();
    }
    #endregion

}
