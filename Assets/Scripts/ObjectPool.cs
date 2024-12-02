using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    #region text
    [SerializeField] private GameObject pointTextPrefab;
    private Queue<GameObject> pointTextPool = new Queue<GameObject>();
    [SerializeField] private int pointTextPoolSize = 100;

    [SerializeField] private GameObject damageTextPrefab;
    private Queue<GameObject> damageTextPool = new Queue<GameObject>();
    [SerializeField] private int damageTextPoolSize = 100;
    #endregion

    #region enemies
    [SerializeField] private GameObject smallEnemyPrefab;
    private Queue<GameObject> smallEnemyPool = new Queue<GameObject>();
    [SerializeField] private int smallEnemyPoolSize = 75;

    [SerializeField] private GameObject speedsterPrefab;
    private Queue<GameObject> speedsterPool = new Queue<GameObject>();
    [SerializeField] private int speedsterPoolSize = 75;

    [SerializeField] private GameObject shootingEnemyPrefab;
    private Queue<GameObject> shootingEnemyPool = new Queue<GameObject>();
    [SerializeField] private int shootingEnemyPoolSize = 25;

    [SerializeField] private GameObject sniperEnemyPrefab;
    private Queue<GameObject> sniperEnemyPool = new Queue<GameObject>();
    [SerializeField] private int sniperEnemyPoolSize = 15;

    [SerializeField] private GameObject bigEnemyPrefab;
    private Queue<GameObject> bigEnemyPool = new Queue<GameObject>();
    [SerializeField] private int bigEnemyPoolSize = 25;

    [SerializeField] private GameObject titanPrefab;
    private Queue<GameObject> titanPool = new Queue<GameObject>();
    [SerializeField] private int titanPoolSize = 10;

    [SerializeField] private GameObject raginGunnerPrefab;
    private Queue<GameObject> raginGunnerPool = new Queue<GameObject>();
    [SerializeField] private int raginGunnerPoolSize = 35;

    [SerializeField] private GameObject heavyShotPrefab;
    private Queue<GameObject> heavyShotPool = new Queue<GameObject>();
    [SerializeField] private int heavyShotPoolSize = 25;

    #endregion

    #region bullets
    [SerializeField] private GameObject smallBulletPrefab;
    private Queue<GameObject> smallBulletPool = new Queue<GameObject>();
    [SerializeField] private int smallBulletPoolSize = 100;

    [SerializeField] private GameObject bulletGun_1Prefab;
    private Queue<GameObject> bulletGun1Pool = new Queue<GameObject>();
    [SerializeField] private int BulletGun1PoolSize = 100;

    [SerializeField] private GameObject chargedBulletPrefab;
    private Queue<GameObject> chargedBulletPool = new Queue<GameObject>();
    [SerializeField] private int chargedBulletPoolSize = 50;

    [SerializeField] private GameObject smallEnemyBulletRefab;
    private Queue<GameObject> smallEnemyBulletPool = new Queue<GameObject>();
    [SerializeField] private int smallEnemyBulletPoolSize = 50;

    [SerializeField] private GameObject homingBulletPrefab;
    private Queue<GameObject> homingBulletPool = new Queue<GameObject>();
    [SerializeField] private int homingBulletPoolsize = 25;

    [SerializeField] private GameObject bigPiercingBullerPrefab;
    private Queue<GameObject> bigPiercingBulletPool = new Queue<GameObject>();
    [SerializeField] private int bigPiercingBulletPoolSize = 25;

    [SerializeField] private GameObject shotgunBulletPrefab;
    private Queue<GameObject> shotgunBulletPool = new Queue<GameObject>();
    [SerializeField] private int shotgunBulletPoolSize = 25;

    [SerializeField] private GameObject mp4BulletPrefab;
    private Queue<GameObject> mp4BulletPool = new Queue<GameObject>();
    [SerializeField] private int mp4BulletPoolSize = 25;

    [SerializeField] private GameObject arrowPrefab;
    private Queue<GameObject> arrowPool = new Queue<GameObject>();
    [SerializeField] private int arrowPoolSize = 100;

    [SerializeField] private GameObject crossbowArrowPrefab;
    private Queue<GameObject> crossbowArrowPool = new Queue<GameObject>();
    [SerializeField] private int crossbowArrowPoolSize = 100;

    [SerializeField] private GameObject trippleShotPrefab;
    private Queue<GameObject> trippleShotPool = new Queue<GameObject>();
    [SerializeField] private int trippleShotPoolSize = 200;

    #endregion

    #region health
    [SerializeField] private GameObject heartPrefab;
    private Queue<GameObject> heartPool = new Queue<GameObject>();
    [SerializeField] private int heartPoolSize = 25;
    #endregion

    #region points objects spawn
    [SerializeField] private GameObject basicPointPrefab;
    private Queue<GameObject> basicPointsPool = new Queue<GameObject>();
    [SerializeField] private int basicPointsPoolSize = 25;
    #endregion

    #region Particles
    [SerializeField] private GameObject enemyDamagedParticlePrefab;
    private Queue<GameObject> enemyDamagedPool = new Queue<GameObject>();
    [SerializeField] private int enemyDamagedPoolSize = 150;

    [SerializeField] private GameObject enemyDeathGlowPrefab;
    private Queue<GameObject> enemyDeathGlowPool = new Queue<GameObject>();
    [SerializeField] private int enemyDeathGlowPoolSize = 75;
    #endregion

    #region spawn indicators
    [SerializeField] private GameObject smallEnemyIndicatorPrefab;
    private Queue<GameObject> smallEnemyIndicatorPool = new Queue<GameObject>();
    [SerializeField] private int smallEnemyIndicatorPoolSize = 50;
    #endregion

    #region Death Cut Pieces
    [SerializeField] private GameObject smallEnemyPiecesPrefab;
    private Queue<GameObject> smallEnemyPiecesPool = new Queue<GameObject>();
    [SerializeField] private int smallEnemyPiecesPoolSize = 50;

    [SerializeField] private GameObject shootingPiecesPrefab;
    private Queue<GameObject> shootingPiecesPool = new Queue<GameObject>();
    [SerializeField] private int shootingPiecesPoolSize = 30;

    [SerializeField] private GameObject bigPiecesPrefab;
    private Queue<GameObject> bigPiecesPool = new Queue<GameObject>();
    [SerializeField] private int bigPiecesPoolSize = 20;

    [SerializeField] private GameObject titanPiecesPrefab;
    private Queue<GameObject> titanPiecesPool = new Queue<GameObject>();
    [SerializeField] private int titanPiecesPoolSize = 50;

    [SerializeField] private GameObject heavyshotPiecesPrefab;
    private Queue<GameObject> heavyshotPiecesPool = new Queue<GameObject>();
    [SerializeField] private int heavyshotPiecesPoolSize = 50;
    #endregion

    #region Skulls
    [SerializeField] private GameObject skullsPrefab;
    private Queue<GameObject> skullsPool = new Queue<GameObject>();
    [SerializeField] private int skullsPoolSize = 50;
    #endregion

    #region Knifes
    [SerializeField] private GameObject knifePrefab;
    private Queue<GameObject> knifePool = new Queue<GameObject>();
    [SerializeField] private int knifePoolSize = 50;
    #endregion

    #region Other
    [SerializeField] private GameObject randomPrefab;
    private Queue<GameObject> randomPool = new Queue<GameObject>();
    [SerializeField] private int randomPoolSize = 10;

    [SerializeField] private GameObject enemyArrowPrefab;
    private Queue<GameObject> enemyArrowPool = new Queue<GameObject>();
    [SerializeField] private int enemyArrowPoolSize = 50;

    [SerializeField] private GameObject enemySawBladePrefab;
    private Queue<GameObject> enemySawBladePool = new Queue<GameObject>();
    [SerializeField] private int enemySawBladePoolSize = 35;
    #endregion

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static float smallEnemySize, speedsterSize, shootingEnemySize, sniperSize, bigEnemySize, titanSize, raginGunnerSize, heavyShotSize;
    public static float pistolBulletSize, mp4BulletSize, bigPiercingBulletSize, uziBulletSize;

    public static float championArrowSize, champtionSawBladeSize;
    public static float arrowSize, boltSize;

    void Start()
    {
        boltSize = 0.8f;
        arrowSize = 0.65f;

        championArrowSize = 1.1f;
        champtionSawBladeSize = 1.3f;

        pistolBulletSize = 0.35f;
        uziBulletSize = 0.5f;
        bigPiercingBulletSize = 1.2f;
        mp4BulletSize = 0.45f;

        speedsterSize = 0.45f;
        smallEnemySize = 0.7f;
        sniperSize = 1f;
        shootingEnemySize = 1.25f;
        bigEnemySize = 2.6f;
        titanSize = 3.1f;
        raginGunnerSize = 2.5f;
        heavyShotSize = 1.7f;

        #region text
        for (int i = 0; i < pointTextPoolSize; i++)
        {
            GameObject pointText = Instantiate(pointTextPrefab);
            pointTextPool.Enqueue(pointText);
            pointText.SetActive(false);
            pointText.transform.SetParent(GameObject.FindGameObjectWithTag("TextPool").transform, true);
            pointText.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
        }

        for (int i = 0; i < damageTextPoolSize; i++)
        {
            GameObject damageText = Instantiate(damageTextPrefab);
            damageTextPool.Enqueue(damageText);
            damageText.SetActive(false);
            damageText.transform.SetParent(GameObject.FindGameObjectWithTag("TextPool").transform, true);
            damageText.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
        }
        #endregion

        #region enemies
        for (int i = 0; i < smallEnemyPoolSize; i++)
        {
            GameObject smallEnemy = Instantiate(smallEnemyPrefab);
            smallEnemyPool.Enqueue(smallEnemy);
            smallEnemy.SetActive(false);
            smallEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            smallEnemy.transform.localScale = new Vector3(smallEnemySize, smallEnemySize, smallEnemySize);
        }

        for (int i = 0; i < speedsterPoolSize; i++)
        {
            GameObject speedster = Instantiate(speedsterPrefab);
            speedsterPool.Enqueue(speedster);
            speedster.SetActive(false);
            speedster.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            speedster.transform.localScale = new Vector3(speedsterSize, speedsterSize, speedsterSize);
        }

        for (int i = 0; i < shootingEnemyPoolSize; i++)
        {
            GameObject shootingEnemy = Instantiate(shootingEnemyPrefab);
            shootingEnemyPool.Enqueue(shootingEnemy);
            shootingEnemy.SetActive(false);
            shootingEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            shootingEnemy.transform.localScale = new Vector3(shootingEnemySize, shootingEnemySize, shootingEnemySize);
        }

        for (int i = 0; i < sniperEnemyPoolSize; i++)
        {
            GameObject sniperEnemy = Instantiate(sniperEnemyPrefab);
            sniperEnemyPool.Enqueue(sniperEnemy);
            sniperEnemy.SetActive(false);
            sniperEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            sniperEnemy.transform.localScale = new Vector3(sniperSize, sniperSize, sniperSize);
        }

        for (int i = 0; i < bigEnemyPoolSize; i++)
        {
            GameObject bigEnemy = Instantiate(bigEnemyPrefab);
            bigEnemyPool.Enqueue(bigEnemy);
            bigEnemy.SetActive(false);
            bigEnemy.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            bigEnemy.transform.localScale = new Vector3(bigEnemySize, bigEnemySize, bigEnemySize);
        }

        for (int i = 0; i < raginGunnerPoolSize; i++)
        {
            GameObject raginGunner = Instantiate(raginGunnerPrefab);
            raginGunnerPool.Enqueue(raginGunner);
            raginGunner.SetActive(false);
            raginGunner.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            raginGunner.transform.localScale = new Vector3(raginGunnerSize, raginGunnerSize, raginGunnerSize);
        }

        for (int i = 0; i < heavyShotPoolSize; i++)
        {
            GameObject heavyShot = Instantiate(heavyShotPrefab);
            heavyShotPool.Enqueue(heavyShot);
            heavyShot.SetActive(false);
            heavyShot.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            heavyShot.transform.localScale = new Vector3(heavyShotSize, heavyShotSize, heavyShotSize);
        }

        for (int i = 0; i < titanPoolSize; i++)
        {
            GameObject titan = Instantiate(titanPrefab);
            titanPool.Enqueue(titan);
            titan.SetActive(false);
            titan.transform.SetParent(GameObject.FindGameObjectWithTag("enemies").transform, true);
            titan.transform.localScale = new Vector3(titanSize, titanSize, titanSize);
        }

        #endregion

        #region Bullets
        for (int i = 0; i < smallBulletPoolSize; i++)
        {
            GameObject smallBullet = Instantiate(smallBulletPrefab);
            smallBulletPool.Enqueue(smallBullet);
            smallBullet.SetActive(false);
            smallBullet.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            smallBullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        for (int i = 0; i < smallEnemyBulletPoolSize; i++)
        {
            GameObject smallEnemyBullet = Instantiate(smallEnemyBulletRefab);
            smallEnemyBulletPool.Enqueue(smallEnemyBullet);
            smallEnemyBullet.SetActive(false);
            smallEnemyBullet.transform.SetParent(GameObject.FindGameObjectWithTag("EnemyBulletsParent").transform, true);
            smallEnemyBullet.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }

        for (int i = 0; i < chargedBulletPoolSize; i++)
        {
            GameObject chargedBullet = Instantiate(chargedBulletPrefab);
            chargedBulletPool.Enqueue(chargedBullet);
            chargedBullet.SetActive(false);
            chargedBullet.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            chargedBullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        for (int i = 0; i < homingBulletPoolsize; i++)
        {
            GameObject homingBullet = Instantiate(homingBulletPrefab);
            homingBulletPool.Enqueue(homingBullet);
            homingBullet.SetActive(false);
            homingBullet.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            homingBullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        for (int i = 0; i < BulletGun1PoolSize; i++)
        {
            GameObject bulletGun1 = Instantiate(bulletGun_1Prefab);
            bulletGun1Pool.Enqueue(bulletGun1);
            bulletGun1.SetActive(false);
            bulletGun1.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            bulletGun1.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }

        for (int i = 0; i < bigPiercingBulletPoolSize; i++)
        {
            GameObject bigPiercingBullet = Instantiate(bigPiercingBullerPrefab);
            bigPiercingBulletPool.Enqueue(bigPiercingBullet);
            bigPiercingBullet.SetActive(false);
            bigPiercingBullet.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            bigPiercingBullet.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

        for (int i = 0; i < shotgunBulletPoolSize; i++)
        {
            GameObject shotgunBullet = Instantiate(shotgunBulletPrefab);
            shotgunBulletPool.Enqueue(shotgunBullet);
            shotgunBullet.SetActive(false);
            shotgunBullet.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            shotgunBullet.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

        for (int i = 0; i < mp4BulletPoolSize; i++)
        {
            GameObject mp4Bullet = Instantiate(mp4BulletPrefab);
            mp4BulletPool.Enqueue(mp4Bullet);
            mp4Bullet.SetActive(false);
            mp4Bullet.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            mp4Bullet.transform.localScale = new Vector3(0.45f, 0.45f, 0.45f);
        }

        for (int i = 0; i < trippleShotPoolSize; i++)
        {
            GameObject trippleShot = Instantiate(trippleShotPrefab);
            trippleShotPool.Enqueue(trippleShot);
            trippleShot.SetActive(false);
            trippleShot.transform.SetParent(GameObject.FindGameObjectWithTag("bullets").transform, true);
            trippleShot.transform.localScale = new Vector3(0.62f, 0.62f, 0.62f);
        }
        #endregion

        #region health
        for (int i = 0; i < heartPoolSize; i++)
        {
            GameObject heart = Instantiate(heartPrefab);
            heartPool.Enqueue(heart);
            heart.SetActive(false);
            heart.transform.SetParent(GameObject.FindGameObjectWithTag("health").transform, true);
            heart.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        #endregion

        #region pointsPrefab
        for (int i = 0; i < basicPointsPoolSize; i++)
        {
            GameObject basicPoints = Instantiate(basicPointPrefab);
            basicPointsPool.Enqueue(basicPoints);
            basicPoints.SetActive(false);
            basicPoints.transform.SetParent(GameObject.FindGameObjectWithTag("PointsParent").transform, true);
            basicPoints.transform.localScale = new Vector3(0.28f, 0.28f, 0.28f);
        }
        #endregion

        #region Particles
        for (int i = 0; i < enemyDamagedPoolSize; i++)
        {
            GameObject enemyDamaged = Instantiate(enemyDamagedParticlePrefab);
            enemyDamagedPool.Enqueue(enemyDamaged);
            enemyDamaged.SetActive(false);
            enemyDamaged.transform.SetParent(GameObject.FindGameObjectWithTag("Particles").transform, true);
            enemyDamaged.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

        for (int i = 0; i < enemyDeathGlowPoolSize; i++)
        {
            GameObject enemyDeathGlow = Instantiate(enemyDeathGlowPrefab);
            enemyDeathGlowPool.Enqueue(enemyDeathGlow);
            enemyDeathGlow.SetActive(false);
            enemyDeathGlow.transform.SetParent(GameObject.FindGameObjectWithTag("Particles").transform, true);
            enemyDeathGlow.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        #endregion

        #region Small enemy cut pieces
        for (int i = 0; i < smallEnemyPiecesPoolSize; i++)
        {
            GameObject pieces = Instantiate(smallEnemyPiecesPrefab);
            smallEnemyPiecesPool.Enqueue(pieces);
            pieces.SetActive(false);
            pieces.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            pieces.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < shootingPiecesPoolSize; i++)
        {
            GameObject shootingPieces = Instantiate(shootingPiecesPrefab);
            shootingPiecesPool.Enqueue(shootingPieces);
            shootingPieces.SetActive(false);
            shootingPieces.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            shootingPieces.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < bigPiecesPoolSize; i++)
        {
            GameObject bigPieces = Instantiate(bigPiecesPrefab);
            bigPiecesPool.Enqueue(bigPieces);
            bigPieces.SetActive(false);
            bigPieces.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            bigPieces.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < titanPiecesPoolSize; i++)
        {
            GameObject titanPieces = Instantiate(titanPiecesPrefab);
            titanPiecesPool.Enqueue(titanPieces);
            titanPieces.SetActive(false);
            titanPieces.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            titanPieces.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < heavyshotPiecesPoolSize; i++)
        {
            GameObject heavyshotPieces = Instantiate(heavyshotPiecesPrefab);
            heavyshotPiecesPool.Enqueue(heavyshotPieces);
            heavyshotPieces.SetActive(false);
            heavyshotPieces.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            heavyshotPieces.transform.localScale = new Vector3(1, 1, 1);
        }
        #endregion

        #region Spawn indicators
        for (int i = 0; i < smallEnemyIndicatorPoolSize; i++)
        {
            GameObject smallIndicator = Instantiate(smallEnemyIndicatorPrefab);
            smallEnemyIndicatorPool.Enqueue(smallIndicator);
            smallIndicator.SetActive(false);
            smallIndicator.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            smallIndicator.transform.localScale = new Vector3(1, 1, 1);
        }
        #endregion

        #region Arrows
        for (int i = 0; i < arrowPoolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrowPool.Enqueue(arrow);
            arrow.SetActive(false);
            arrow.transform.SetParent(GameObject.FindGameObjectWithTag("arrowPool").transform, true);
            arrow.transform.localScale = new Vector3(arrowSize, arrowSize, arrowSize);
        }

        for (int i = 0; i < crossbowArrowPoolSize; i++)
        {
            GameObject crossbowArrow = Instantiate(crossbowArrowPrefab);
            crossbowArrowPool.Enqueue(crossbowArrow);
            crossbowArrow.SetActive(false);
            crossbowArrow.transform.SetParent(GameObject.FindGameObjectWithTag("arrowPool").transform, true);
            crossbowArrow.transform.localScale = new Vector3(boltSize, boltSize, boltSize);
        }
        #endregion

        #region Skulls
        for (int i = 0; i < skullsPoolSize; i++)
        {
            GameObject skulls = Instantiate(skullsPrefab);
            skullsPool.Enqueue(skulls);
            skulls.SetActive(false);
            skulls.transform.SetParent(GameObject.FindGameObjectWithTag("Indicator").transform, true);
            skulls.transform.localScale = new Vector3(1, 1, 1);
        }
        #endregion

        #region Knifes
        for (int i = 0; i < knifePoolSize; i++)
        {
            GameObject knife = Instantiate(knifePrefab);
            knifePool.Enqueue(knife);
            knife.SetActive(false);
            knife.transform.SetParent(GameObject.FindGameObjectWithTag("KnifePool").transform, true);
            knife.transform.localScale = new Vector3(2, 2, 2);
        }
        #endregion

        #region Other
        for (int i = 0; i < randomPoolSize; i++)
        {
            GameObject random = Instantiate(randomPrefab);
            randomPool.Enqueue(random);
            random.SetActive(false);
            random.transform.SetParent(GameObject.FindGameObjectWithTag("RandomParent").transform, true);
            random.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < enemyArrowPoolSize; i++)
        {
            GameObject enemyArrow = Instantiate(enemyArrowPrefab);
            enemyArrowPool.Enqueue(enemyArrow);
            enemyArrow.SetActive(false);
            enemyArrow.transform.SetParent(GameObject.FindGameObjectWithTag("EnemyBulletsParent").transform, true);
            enemyArrow.transform.localScale = new Vector3(championArrowSize, championArrowSize, championArrowSize);
        }

        for (int i = 0; i < enemySawBladePoolSize; i++)
        {
            GameObject enemySawBlade = Instantiate(enemySawBladePrefab);
            enemySawBladePool.Enqueue(enemySawBlade);
            enemySawBlade.SetActive(false);
            enemySawBlade.transform.SetParent(GameObject.FindGameObjectWithTag("EnemyBulletsParent").transform, true);
            enemySawBlade.transform.localScale = new Vector3(champtionSawBladeSize, champtionSawBladeSize, champtionSawBladeSize);
        }
        #endregion

    }

    #region textPool
    public GameObject GetPointTextFromPool()
    {
        if (pointTextPool.Count > 0)
        {
            GameObject pointPrefab = pointTextPool.Dequeue();
            pointPrefab.SetActive(true);
            return pointPrefab;
        }
        else
        {
            GameObject pointPrefab = Instantiate(pointTextPrefab);
            return pointPrefab;

        }
    }

    public void ReturnPointTextFromPool(GameObject pointPrefab)
    {
        pointTextPool.Enqueue(pointPrefab);
        pointPrefab.SetActive(false);
    }
    #endregion

    #region damageTextPool
    public GameObject GetDamageTextFromPool()
    {
        if (damageTextPool.Count > 0)
        {
            GameObject damageText = damageTextPool.Dequeue();
            damageText.SetActive(true);
            return damageText;
        }
        else
        {
            GameObject damageText = Instantiate(damageTextPrefab);
            return damageText;

        }
    }

    public void ReturnDamageTextFromPool(GameObject damageText)
    {
        damageTextPool.Enqueue(damageText);
        damageText.SetActive(false);
    }
    #endregion

    #region Small bullet pool
    public GameObject GetSmallBulletFromPool()
    {
        if (smallBulletPool.Count > 0)
        {
            GameObject smallBullet = smallBulletPool.Dequeue();
            smallBullet.SetActive(true);
            return smallBullet;
        }
        else
        {
            GameObject smallBullet = Instantiate(smallBulletPrefab);
            return smallBullet;

        }
    }

    public void ReturnSmallBulletFromPool(GameObject smallBullet)
    {
        smallBulletPool.Enqueue(smallBullet);
        smallBullet.SetActive(false);
    }
    #endregion

    #region bullet from gun 1
    public GameObject GetBulletGun1FromPool()
    {
        if (bulletGun1Pool.Count > 0)
        {
            GameObject gunbullet1 = bulletGun1Pool.Dequeue();
            gunbullet1.SetActive(true);
            return gunbullet1;
        }
        else
        {
            GameObject gunbullet1 = Instantiate(bulletGun_1Prefab);
            return gunbullet1;

        }
    }

    public void ReturnBulletGun1FromPool(GameObject gunbullet1)
    {
        bulletGun1Pool.Enqueue(gunbullet1);
        gunbullet1.SetActive(false);
    }
    #endregion

    #region shotgun bullet
    public GameObject GetShotgunBullletFromPool()
    {
        if (shotgunBulletPool.Count > 0)
        {
            GameObject shotgunBullet = shotgunBulletPool.Dequeue();
            shotgunBullet.SetActive(true);
            return shotgunBullet;
        }
        else
        {
            GameObject shotgunBullet = Instantiate(shotgunBulletPrefab);
            return shotgunBullet;

        }
    }

    public void ReturnShotgunBulletFromPool(GameObject shotgunBullet)
    {
        shotgunBulletPool.Enqueue(shotgunBullet);
        shotgunBullet.SetActive(false);
    }
    #endregion

    #region mp4bullet
    public GameObject GetMP4BulletFromPool()
    {
        if (mp4BulletPool.Count > 0)
        {
            GameObject mp4Bullet = mp4BulletPool.Dequeue();
            mp4Bullet.SetActive(true);
            return mp4Bullet;
        }
        else
        {
            GameObject mp4Bullet = Instantiate(mp4BulletPrefab);
            return mp4Bullet;

        }
    }

    public void ReturnMP4BulletFromPool(GameObject mp4Bullet)
    {
        mp4BulletPool.Enqueue(mp4Bullet);
        mp4Bullet.SetActive(false);
    }
    #endregion

    #region tripple shot
    public GameObject GetTrippleShotFromPool()
    {
        if (trippleShotPool.Count > 0)
        {
            GameObject tripple = trippleShotPool.Dequeue();
            tripple.SetActive(true);
            return tripple;
        }
        else
        {
            GameObject tripple = Instantiate(trippleShotPrefab);
            return tripple;

        }
    }

    public void ReturnTrippleShotFromPool(GameObject tripple)
    {
        trippleShotPool.Enqueue(tripple);
        tripple.SetActive(false);
    }
    #endregion

    #region Homing bullet pool
    public GameObject GetHomingBulletFromPool()
    {
        if (homingBulletPool.Count > 0)
        {
            GameObject homingBullet = homingBulletPool.Dequeue();
            homingBullet.SetActive(true);
            return homingBullet;
        }
        else
        {
            GameObject homingBullet = Instantiate(homingBulletPrefab);
            return homingBullet;

        }
    }

    public void ReturnHomingBulletFromPool(GameObject homingBullet)
    {
        homingBulletPool.Enqueue(homingBullet);
        homingBullet.SetActive(false);
    }
    #endregion

    #region small enemy bullet pool
    public GameObject GetSmallEnemyBulletFromPool()
    {
        if (smallEnemyBulletPool.Count > 0)
        {
            GameObject smallEnemyBullet = smallEnemyBulletPool.Dequeue();
            smallEnemyBullet.SetActive(true);
            return smallEnemyBullet;
        }
        else
        {
            GameObject smallEnemyBullet = Instantiate(smallEnemyBulletRefab);
            return smallEnemyBullet;

        }
    }

    public void ReturnSmallEnemyBulletFromPool(GameObject smallEnemyBullet)
    {
        smallEnemyBulletPool.Enqueue(smallEnemyBullet);
        smallEnemyBullet.SetActive(false);
    }
    #endregion

    #region speedster pool
    public GameObject GetSpeedsterFromPool()
    {
        if (speedsterPool.Count > 0)
        {
            GameObject speedster = speedsterPool.Dequeue();
            speedster.SetActive(true);
            return speedster;
        }
        else
        {
            GameObject speedster = Instantiate(speedsterPrefab);
            return speedster;

        }
    }

    public void ReturnSpeedsterFromPool(GameObject speedster)
    {
        speedsterPool.Enqueue(speedster);
        speedster.SetActive(false);
    }
    #endregion

    #region chargedBulletPool
    public GameObject GetChargedBulletFromPool()
    {
        if (chargedBulletPool.Count > 0)
        {
            GameObject chargedBullet = chargedBulletPool.Dequeue();
            chargedBullet.SetActive(true);
            return chargedBullet;
        }
        else
        {
            GameObject chargedBullet = Instantiate(chargedBulletPrefab);
            return chargedBullet;

        }
    }

    public void ReturnChargedBulletFromPool(GameObject chargedBullet)
    {
        chargedBulletPool.Enqueue(chargedBullet);
        chargedBullet.SetActive(false);
    }
    #endregion

    #region smallEnemy pool
    public GameObject GetSmallEnemyFromPool()
    {
        if (smallEnemyPool.Count > 0)
        {
            GameObject smallEnemy = smallEnemyPool.Dequeue();
            smallEnemy.SetActive(true);
            return smallEnemy;
        }
        else
        {
            GameObject smallEnemy = Instantiate(smallEnemyPrefab);
            return smallEnemy;

        }
    }

    public void ReturnSmallEnemyFromPool(GameObject smallEnemy)
    {
        smallEnemyPool.Enqueue(smallEnemy);
        smallEnemy.SetActive(false);
    }
    #endregion

    #region shooting enemy pool
    public GameObject GetShootingEnemyFromPool()
    {
        if (shootingEnemyPool.Count > 0)
        {
            GameObject shootingEnemy = shootingEnemyPool.Dequeue();
            shootingEnemy.SetActive(true);
            return shootingEnemy;
        }
        else
        {
            GameObject shootingEnemy = Instantiate(shootingEnemyPrefab);
            return shootingEnemy;
        }
    }

    public void ReturnShootingEnemyFromPool(GameObject shootingEnemy)
    {
        shootingEnemyPool.Enqueue(shootingEnemy);
        shootingEnemy.SetActive(false);
    }
    #endregion

    #region sniper enemy pool
    public GameObject GetSniperEnemyFromPool()
    {
        if (sniperEnemyPool.Count > 0)
        {
            GameObject sniperEnemy = sniperEnemyPool.Dequeue();
            sniperEnemy.SetActive(true);
            return sniperEnemy;
        }
        else
        {
            GameObject sniperEnemy = Instantiate(sniperEnemyPrefab);
            return sniperEnemy;
        }
    }

    public void ReturnSniperEnemyFromPool(GameObject sniperEnemy)
    {
        sniperEnemyPool.Enqueue(sniperEnemy);
        sniperEnemy.SetActive(false);
    }
    #endregion

    #region bigEnemyPool
    public GameObject GetBigEnemyFromPool()
    {
        if (bigEnemyPool.Count > 0)
        {
            GameObject bigEnemy = bigEnemyPool.Dequeue();
            bigEnemy.SetActive(true);
            return bigEnemy;
        }
        else
        {
            GameObject bigEnemy = Instantiate(bigEnemyPrefab);
            return bigEnemy;
        }
    }

    public void ReturnBigEnemyPoolFromPool(GameObject bigEnemy)
    {
        bigEnemyPool.Enqueue(bigEnemy);
        bigEnemy.SetActive(false);
    }
    #endregion

    #region titan Pool
    public GameObject GetTitanFromPool()
    {
        if (titanPool.Count > 0)
        {
            GameObject titan = titanPool.Dequeue();
            titan.SetActive(true);
            return titan;
        }
        else
        {
            GameObject titan = Instantiate(titanPrefab);
            return titan;
        }
    }

    public void ReturnTitanFromPool(GameObject titan)
    {
        titanPool.Enqueue(titan);
        titan.SetActive(false);
    }
    #endregion

    #region Raging Gunner Pool
    public GameObject GetRagingGunnerFromPool()
    {
        if (raginGunnerPool.Count > 0)
        {
            GameObject raginGunner = raginGunnerPool.Dequeue();
            raginGunner.SetActive(true);
            return raginGunner;
        }
        else
        {
            GameObject raginGunner = Instantiate(raginGunnerPrefab);
            return raginGunner;
        }
    }

    public void ReturnGunnerFromPool(GameObject raginGunner)
    {
        raginGunnerPool.Enqueue(raginGunner);
        raginGunner.SetActive(false);
    }
    #endregion

    #region Heavyshot pool
    public GameObject GetHeavyShotPoolFromPool()
    {
        if (heavyShotPool.Count > 0)
        {
            GameObject heavyshot = heavyShotPool.Dequeue();
            heavyshot.SetActive(true);
            return heavyshot;
        }
        else
        {
            GameObject heavyshot = Instantiate(heavyShotPrefab);
            return heavyshot;
        }
    }

    public void ReturnHeavyShotFromPool(GameObject heavyshot)
    {
        heavyShotPool.Enqueue(heavyshot);
        heavyshot.SetActive(false);
    }
    #endregion

    #region heartPool
    public GameObject GetHeartFromPool()
    {
        if (heartPool.Count > 0)
        {
            GameObject heart = heartPool.Dequeue();
            heart.SetActive(true);
            return heart;
        }
        else
        {
            GameObject heart = Instantiate(heartPrefab);
            return heart;
        }
    }

    public void ReturnHeartFromPool(GameObject heart)
    {
        heartPool.Enqueue(heart);
        heart.SetActive(false);
    }
    #endregion

    #region basicPoint pool
    public GameObject GetBasicPointsFromPool()
    {
        if (basicPointsPool.Count > 0)
        {
            GameObject basicPoint = basicPointsPool.Dequeue();
            basicPoint.SetActive(true);
            return basicPoint;
        }
        else
        {
            GameObject basicPoint = Instantiate(basicPointPrefab);
            return basicPoint;
        }
    }

    public void ReturnBasicPointsFromPool(GameObject basicPoint)
    {
        basicPointsPool.Enqueue(basicPoint);
        basicPoint.SetActive(false);
    }
    #endregion

    #region big piercing bullet pool
    public GameObject GetBigPiercingBulletFromPool()
    {
        if (bigPiercingBulletPool.Count > 0)
        {
            GameObject bigPiercingBullet = bigPiercingBulletPool.Dequeue();
            bigPiercingBullet.SetActive(true);
            return bigPiercingBullet;
        }
        else
        {
            GameObject bigPiercingBullet = Instantiate(bigPiercingBullerPrefab);
            return bigPiercingBullet;

        }
    }

    public void ReturnBigPiercingBulletFromPool(GameObject bigPiercingBullet)
    {
        bigPiercingBulletPool.Enqueue(bigPiercingBullet);
        bigPiercingBullet.SetActive(false);
    }
    #endregion

    #region Enemy Damaged Particle
    public GameObject GetEnemyDamagedParticleFromPool()
    {
        if (enemyDamagedPool.Count > 0)
        {
            GameObject enemyDamaged = enemyDamagedPool.Dequeue();
            enemyDamaged.SetActive(true);
            return enemyDamaged;
        }
        else
        {
            GameObject enemyDamaged = Instantiate(enemyDamagedParticlePrefab);
            return enemyDamaged;

        }
    }

    public void ReturnEnemyDamagedParticleFromPool(GameObject enemyDamaged)
    {
        enemyDamagedPool.Enqueue(enemyDamaged);
        enemyDamaged.SetActive(false);
    }
    #endregion

    #region Enemy Death Glow Particle
    public GameObject GetEnemyDeathGlowFromPool()
    {
        if (enemyDeathGlowPool.Count > 0)
        {
            GameObject enemyDeathGlow = enemyDeathGlowPool.Dequeue();
            enemyDeathGlow.SetActive(true);
            return enemyDeathGlow;
        }
        else
        {
            GameObject enemyDeathGlow = Instantiate(enemyDeathGlowPrefab);
            return enemyDeathGlow;

        }
    }

    public void ReturnEnemyDeathGlowFromPool(GameObject enemyDeathGlow)
    {
        enemyDeathGlowPool.Enqueue(enemyDeathGlow);
        enemyDeathGlow.SetActive(false);
    }
    #endregion

    #region Small Enemy Indicator
    public GameObject GetSmallEnemyIndicatorFromPool()
    {
        if (smallEnemyIndicatorPool.Count > 0)
        {
            GameObject smallIndicator = smallEnemyIndicatorPool.Dequeue();
            smallIndicator.SetActive(true);
            return smallIndicator;
        }
        else
        {
            GameObject smallIndicator = Instantiate(smallEnemyIndicatorPrefab);
            return smallIndicator;

        }
    }

    public void ReturnSmallEnemyIndicatorFromPool(GameObject smallIndicator)
    {
        smallEnemyIndicatorPool.Enqueue(smallIndicator);
        smallIndicator.SetActive(false);
    }
    #endregion

    #region Small Enemy Pieces
    public GameObject GetSmallEnemyPiecesFromPool()
    {
        if (smallEnemyPiecesPool.Count > 0)
        {
            GameObject smallEnemyPieces = smallEnemyPiecesPool.Dequeue();
            smallEnemyPieces.SetActive(true);
            return smallEnemyPieces;
        }
        else
        {
            GameObject smallEnemyPieces = Instantiate(smallEnemyPiecesPrefab);
            return smallEnemyPieces;

        }
    }

    public void ReturnEnemySmallPiecesFromPool(GameObject smallEnemyPieces)
    {
        smallEnemyPiecesPool.Enqueue(smallEnemyPieces);
        smallEnemyPieces.SetActive(false);
    }
    #endregion

    #region Shooting Enemy Pieces
    public GameObject GetShootingEnemyPiecesFromPool()
    {
        if (shootingPiecesPool.Count > 0)
        {
            GameObject shootingPieces = shootingPiecesPool.Dequeue();
            shootingPieces.SetActive(true);
            return shootingPieces;
        }
        else
        {
            GameObject shootingPieces = Instantiate(shootingPiecesPrefab);
            return shootingPieces;
        }
    }

    public void ReturnShootingEnemyPiecesFromPool(GameObject shootingPieces)
    {
        shootingPiecesPool.Enqueue(shootingPieces);
        shootingPieces.SetActive(false);
    }
    #endregion

    #region Big Enemy Pieces
    public GameObject GetBigPiecesFromPool()
    {
        if (bigPiecesPool.Count > 0)
        {
            GameObject bigPieces = bigPiecesPool.Dequeue();
            bigPieces.SetActive(true);
            return bigPieces;
        }
        else
        {
            GameObject bigPieces = Instantiate(bigPiecesPrefab);
            return bigPieces;
        }
    }

    public void ReturnBigPiecesFromPool(GameObject bigPieces)
    {
        bigPiecesPool.Enqueue(bigPieces);
        bigPieces.SetActive(false);
    }
    #endregion
    
    #region Heavyshot Pieces
    public GameObject GetHeavyshotPiecesFromPool()
    {
        if (heavyshotPiecesPool.Count > 0)
        {
            GameObject heavyshotPieces = heavyshotPiecesPool.Dequeue();
            heavyshotPieces.SetActive(true);
            return heavyshotPieces;
        }
        else
        {
            GameObject heavyshotPieces = Instantiate(heavyshotPiecesPrefab);
            return heavyshotPieces;
        }
    }

    public void ReturnHeavyshotPiecesFromPool(GameObject heavyshotPieces)
    {
        heavyshotPiecesPool.Enqueue(heavyshotPieces);
        heavyshotPieces.SetActive(false);
    }
    #endregion

    #region Titan Pieces
    public GameObject GetTitanPiecesFromPool()
    {
        if (titanPiecesPool.Count > 0)
        {
            GameObject titanPieces = titanPiecesPool.Dequeue();
            titanPieces.SetActive(true);
            return titanPieces;
        }
        else
        {
            GameObject titanPieces = Instantiate(titanPiecesPrefab);
            return titanPieces;
        }
    }

    public void ReturnTitanPiecesFromPool(GameObject titanPieces)
    {
        titanPiecesPool.Enqueue(titanPieces);
        titanPieces.SetActive(false);
    }
    #endregion

    #region Arrows
    public GameObject GetArrowFromPool()
    {
        if (arrowPool.Count > 0)
        {
            GameObject arrow = arrowPool.Dequeue();
            arrow.SetActive(true);
            return arrow;
        }
        else
        {
            GameObject arrow = Instantiate(arrowPrefab);
            return arrow;

        }
    }

    public void ReturnArrowFromPool(GameObject arrow)
    {
        arrowPool.Enqueue(arrow);
        arrow.SetActive(false);
    }
    #endregion

    #region Crossbow Arrows
    public GameObject GetCrossbowArrowFromPool()
    {
        if (crossbowArrowPool.Count > 0)
        {
            GameObject crossbow = crossbowArrowPool.Dequeue();
            crossbow.SetActive(true);
            return crossbow;
        }
        else
        {
            GameObject crossbow = Instantiate(crossbowArrowPrefab);
            return crossbow;

        }
    }

    public void ReturnCrossbowArrowFromPool(GameObject crossbow)
    {
        crossbowArrowPool.Enqueue(crossbow);
        crossbow.SetActive(false);
    }
    #endregion

    #region Skulls
    public GameObject GetSkullsFromPool()
    {
        if (skullsPool.Count > 0)
        {
            GameObject skulls = skullsPool.Dequeue();
            skulls.SetActive(true);
            return skulls;
        }
        else
        {
            GameObject skulls = Instantiate(skullsPrefab);
            return skulls;

        }
    }

    public void ReturnSkullsFromPool(GameObject skulls)
    {
        skullsPool.Enqueue(skulls);
        skulls.SetActive(false);
    }
    #endregion

    #region knifes
    public GameObject GetKnifeFromPool()
    {
        if (knifePool.Count > 0)
        {
            GameObject knife = knifePool.Dequeue();
            knife.SetActive(true);
            return knife;
        }
        else
        {
            GameObject knife = Instantiate(knifePrefab);
            return knife;

        }
    }

    public void ReturnKnifeFromPool(GameObject knife)
    {
        knifePool.Enqueue(knife);
        knife.SetActive(false);
    }
    #endregion

    #region Random
    public GameObject GetRandomFromPool()
    {
        if (randomPool.Count > 0)
        {
            GameObject random = randomPool.Dequeue();
            random.SetActive(true);
            return random;
        }
        else
        {
            GameObject random = Instantiate(randomPrefab);
            return random;

        }
    }

    public void ReturnRandomFromPool(GameObject random)
    {
        randomPool.Enqueue(random);
        random.SetActive(false);
    }
    #endregion

    #region Enemy Arrows
    public GameObject GetEnemyArrowsFromPool()
    {
        if (enemyArrowPool.Count > 0)
        {
            GameObject enemyArrow = enemyArrowPool.Dequeue();
            enemyArrow.SetActive(true);
            return enemyArrow;
        }
        else
        {
            GameObject enemyArrow = Instantiate(enemyArrowPrefab);
            return enemyArrow;
        }
    }

    public void ReturnEnemyArrowsFromPool(GameObject enemyArrow)
    {
        enemyArrowPool.Enqueue(enemyArrow);
        enemyArrow.SetActive(false);
    }
    #endregion

    #region Enemy Saw Blades
    public GameObject GetEnemySawBladeFromPool()
    {
        if (enemySawBladePool.Count > 0)
        {
            GameObject enemySaw = enemySawBladePool.Dequeue();
            enemySaw.SetActive(true);
            return enemySaw;
        }
        else
        {
            GameObject enemySaw = Instantiate(enemySawBladePrefab);
            return enemySaw;
        }
    }

    public void ReturnEnemySawBladeFromPool(GameObject enemySaw)
    {
        enemySawBladePool.Enqueue(enemySaw);
        enemySaw.SetActive(false);
    }
    #endregion
}
