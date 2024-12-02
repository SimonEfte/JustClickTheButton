using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShootingEnemy : MonoBehaviour
{
    public float maxSpawnRadius;
    public float minSpawnRadius;

    private float lastSpawnTime;

    public static int shootingEnemyCount, sniperCount, heavyShotCount, ragingGunnerCount;

    public Transform mainButtonPos;

    public static bool spawnSharpshooter, spawnSniper, spawnHeavyShot, spawnRagingGunner;

    public Vector2 spawnPosition;

    public GameObject mainButton;

    public Coroutine moreSharpshooterCoroutine, moreSniperCorotuine, moreHeavyshotCoroutine, moreRaginGunnerCoroutine;
    public void StopSpawning()
    {
        StopAllCoroutines();
    }
    void Start()
    {
        spawnSharpshooter = true;
        spawnSniper = true;
        spawnHeavyShot = true;
        spawnRagingGunner = true;

        lastSpawnTime = Time.time;
    }

    void Update()
    {
        if (Choises.isInMainManu == false && Choises.shootingEnemySpawn == true && spawnSharpshooter == true && BossMechanics.fightingBossFight == false)
        {
            StartCoroutine(SpawnSharpshooter(true));
            spawnSharpshooter = false;
        }

        if (Choises.isInMainManu == false && Choises.sniperSpawn == true && spawnSniper == true && BossMechanics.fightingBossFight == false)
        {
            StartCoroutine(SpawnSniper(true));
            spawnSniper = false;
        }

        if (Choises.isInMainManu == false && Choises.heavyShotSpawn == true && spawnHeavyShot == true && BossMechanics.fightingBossFight == false)
        {
            StartCoroutine(SpawnHeavyShot(true));
            spawnHeavyShot = false;
        }

        if (Choises.isInMainManu == false && Choises.ragingGunnerSpawn == true && spawnRagingGunner == true && BossMechanics.fightingBossFight == false && HordeEnding.hordeSpawnRagingGunner == false)
        {
            StartCoroutine(SpawnRaginGunner(true));
            spawnRagingGunner = false;
        }
    }

    IEnumerator SpawnSharpshooter(bool set)
    {
        if (shootingEnemyCount < Choises.maxSharpshooters)
        {
            shootingEnemyCount += 1;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();
            smallIndicator.transform.localScale = new Vector2(ObjectPool.shootingEnemySize - 0.3f, ObjectPool.shootingEnemySize - 0.3f);
            smallIndicator.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, 40));
            smallIndicator.GetComponent<Animation>().Play();

            GameObject shootingEnemy = ObjectPool.instance.GetShootingEnemyFromPool();
            shootingEnemy.tag = "shootingEnemy";
            SpawnShootingEnemies(shootingEnemy, smallIndicator);
            shootingEnemy.SetActive(false);
            StartCoroutine(SetSharpshooter(shootingEnemy));

            yield return new WaitForSeconds(1.4f);
            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);
        }

        yield return new WaitForSeconds(Choises.sharpshooterSpawnTimer);
        if(moreSharpshooterCoroutine == null) { moreSharpshooterCoroutine = StartCoroutine(SpawnMoreSharpshooter()); }
        if(set == true) { spawnSharpshooter = true; }
    }

    IEnumerator SpawnSniper(bool set)
    {
        if (sniperCount < Choises.maxSnipers)
        {
            sniperCount += 1;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();
            smallIndicator.transform.localScale = new Vector2(ObjectPool.sniperSize - 0.1f, ObjectPool.sniperSize - 0.1f);
            smallIndicator.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, 40));
            smallIndicator.GetComponent<Animation>().Play();

            GameObject sniperEnemy = ObjectPool.instance.GetSniperEnemyFromPool();
            sniperEnemy.tag = "Sniper";
            SpawnShootingEnemies(sniperEnemy, smallIndicator);
            sniperEnemy.SetActive(false);
            StartCoroutine(SetSniper(sniperEnemy));

            yield return new WaitForSeconds(1.4f);
            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);
        }

        yield return new WaitForSeconds(Choises.sniperSpawnTimer);
        if (moreSniperCorotuine == null) { moreSniperCorotuine = StartCoroutine(SpawnMoreSnipers()); }
        if (set == true) { spawnSniper = true; }
    }

    IEnumerator SpawnHeavyShot(bool set)
    {
        if (heavyShotCount < Choises.maxHeavyshots)
        {
            heavyShotCount += 1;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();
            smallIndicator.transform.localScale = new Vector2(ObjectPool.heavyShotSize - 0.4f, ObjectPool.heavyShotSize - 0.4f);
            smallIndicator.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, 40));
            smallIndicator.GetComponent<Animation>().Play();

            GameObject heavyshotEnemy = ObjectPool.instance.GetHeavyShotPoolFromPool();
            heavyshotEnemy.tag = "HeavyShot";
            SpawnShootingEnemies(heavyshotEnemy, smallIndicator);
            heavyshotEnemy.SetActive(false);
            StartCoroutine(SetHeavyShot(heavyshotEnemy));

            yield return new WaitForSeconds(1.4f);
        
            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);
        }

        yield return new WaitForSeconds(Choises.heavyShotSpawnTiner);
        if (moreHeavyshotCoroutine == null) { moreHeavyshotCoroutine = StartCoroutine(SpawnMoreHeavyShot()); }
        if (set == true) { spawnHeavyShot = true; }
    }

    public int distanceThreshold;
    IEnumerator SpawnRaginGunner(bool set)
    {
        if (ragingGunnerCount < Choises.maxRagingGunners)
        {
            int randomPosSpawn = Random.Range(1, 5);

            int random1, random2;
            Vector2 randomSpawnPosition;
            float distanceToMainButton;

            // Set the maximum attempts to prevent an infinite loop (adjust as needed)
            int attempts = 0;

            do
            {
                // Generate random positions
                random1 = Random.Range(-760 + -Choises.arenaSpawnPointChangeX, 760 + Choises.arenaSpawnPointChangeX);
                random2 = Random.Range(-360 + -Choises.arenaSpawnPointChangeY, 360 + Choises.arenaSpawnPointChangeY);

                if (randomPosSpawn == 1) { random2 = 360 + Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 2) { random2 = -360 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 3) { random1 = -760 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 4) { random1 = 760 + Choises.arenaSpawnPointChangeY; }

                randomSpawnPosition = new Vector2(random1, random2);

                distanceToMainButton = Vector2.Distance(randomSpawnPosition, mainButton.transform.localPosition);

                attempts++;
                if (attempts > 1) { 
                    //Debug.Log(attempts); 
                }

                if (randomPosSpawn == 1 || randomPosSpawn == 2)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 410; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 610; }

                }
                if (randomPosSpawn == 3 || randomPosSpawn == 4)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 330; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 435; }
                    if (Choises.arenaIncrease > 0.20f) { distanceThreshold = 460; }
                    if (Choises.arenaIncrease > 0.35f) { distanceThreshold = 525; }
                }

            } while (distanceToMainButton < distanceThreshold);

            Vector2 getPos;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (360 + Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-360 + -Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-760 + -Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((760 + Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }

            smallIndicator.transform.localScale = new Vector2(ObjectPool.raginGunnerSize - 0.75f, ObjectPool.raginGunnerSize - 0.75f);
            smallIndicator.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(1.4f);

            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);

            GameObject gunner = ObjectPool.instance.GetRagingGunnerFromPool();
            ragingGunnerCount += 1;

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (360 + Choises.arenaSpawnPointChangeY)); gunner.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-360 + -Choises.arenaSpawnPointChangeY)); gunner.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-760 + -Choises.arenaSpawnPointChangeX), random2); gunner.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((760 + Choises.arenaSpawnPointChangeX), random2); gunner.transform.localPosition = getPos; }
        }

        yield return new WaitForSeconds(Choises.ragingGunnerSpawnTimer);
        if (moreRaginGunnerCoroutine == null && HordeEnding.playingHordeEnding == false) { moreRaginGunnerCoroutine = StartCoroutine(SpawnMoreRagingGunner()); }

        if (HordeEnding.playingHordeEnding == false && set == true) { spawnRagingGunner = true; }
    }

    IEnumerator SetRagingunner(GameObject ragingGunner)
    {
        yield return new WaitForSeconds(1.4f);
        ragingGunner.SetActive(true);
    }

    IEnumerator SetHeavyShot(GameObject heavyShot)
    {
        yield return new WaitForSeconds(1.4f);
        heavyShot.SetActive(true);
    }

    IEnumerator SetSniper(GameObject sniperEnemy)
    {
        yield return new WaitForSeconds(1.4f);
        sniperEnemy.SetActive(true);
    }
    IEnumerator SetSharpshooter(GameObject sharshooter)
    {
        yield return new WaitForSeconds(1.4f);
        sharshooter.SetActive(true);
    }

    public void SpawnShootingEnemies(GameObject enemy, GameObject spawnPos)
    {
        int randomPosSpawn = Random.Range(1, 5);

        int random1 = Random.Range(-720, 720);
        int random2 = Random.Range(380, -380);

        int randomY = Random.Range(360, 410); int randomY2 = Random.Range(-360, -410);
        int randomX = Random.Range(690, 750); int randomX2 = Random.Range(-690, -750);

        if (Choises.chooseRocket == true || Choises.choseButtonBounceCharge == true || Choises.chooseControllableButton == true)
        {
            Vector2 pos = mainButtonPos.transform.localPosition;
            int randomPos = Random.Range(1, 3);

            //Bottom left
            if (pos.x <= 0 && pos.y <= 0)
            {
                if (randomPos == 1) { spawnPosition = new Vector2(((pos.x + randomX) + Choises.arenaSpawnPointChangeX), random2);  }
                if (randomPos == 2) { spawnPosition = new Vector2(random1 + Choises.arenaSpawnPointChangeX, pos.y + (randomY + Choises.arenaSpawnPointChangeY));  }
            }
            //Botton right
            if (pos.x >= 0 && pos.y <= 0)
            {
                if (randomPos == 1) { spawnPosition = new Vector2(((pos.x - randomX) - Choises.arenaSpawnPointChangeX), random2);  }
                if (randomPos == 2) { spawnPosition = new Vector2(random1 + Choises.arenaSpawnPointChangeX, pos.y + (randomY + Choises.arenaSpawnPointChangeY)); }
            }
            //Top left
            if (pos.x <= 0 && pos.y >= 0)
            {
                if (randomPos == 1) { spawnPosition = new Vector2(random1 + Choises.arenaSpawnPointChangeX, pos.y - (randomY + Choises.arenaSpawnPointChangeY));  }
                if (randomPos == 2) { spawnPosition = new Vector2(((pos.x + randomX) + Choises.arenaSpawnPointChangeX), random2 + Choises.arenaSpawnPointChangeY); }
            }
            //Top right
            if (pos.x >= 0 && pos.y >= 0)
            {
                if (randomPos == 1) { spawnPosition = new Vector2(((pos.x - randomX) + Choises.arenaSpawnPointChangeX), pos.y - (randomY + Choises.arenaSpawnPointChangeY));  }
                if (randomPos == 2) { spawnPosition = new Vector2(random1 + Choises.arenaSpawnPointChangeX, pos.y - (randomY + Choises.arenaSpawnPointChangeY));  }
            }
        }
        else
        {
            if (randomPosSpawn == 1) { spawnPosition = new Vector2(random1 + -Choises.arenaSpawnPointChangeX, randomY + Choises.arenaSpawnPointChangeY); }
            if (randomPosSpawn == 2) { spawnPosition = new Vector2(random1 + Choises.arenaSpawnPointChangeX, randomY2 + -Choises.arenaSpawnPointChangeY); }
            if (randomPosSpawn == 3) { spawnPosition = new Vector2(randomX2 + -Choises.arenaSpawnPointChangeX, random2 + -Choises.arenaSpawnPointChangeY); }
            if (randomPosSpawn == 4) { spawnPosition = new Vector2(randomX + Choises.arenaSpawnPointChangeX, random2 + Choises.arenaSpawnPointChangeY); }
        }

        enemy.transform.localPosition = spawnPosition;
        spawnPos.transform.localPosition = spawnPosition;
    }


    IEnumerator SpawnMoreSharpshooter()
    {
        yield return new WaitForSeconds(Choises.spawnMoreSharpshooterTimer);
        moreSharpshooterCoroutine = null;
        StartCoroutine(SpawnSharpshooter(false));
    }

    IEnumerator SpawnMoreSnipers()
    {
        yield return new WaitForSeconds(Choises.spawnMoreSniperTimer);
        moreSniperCorotuine = null;
        StartCoroutine(SpawnSniper(false));
    }

    IEnumerator SpawnMoreRagingGunner()
    {
        yield return new WaitForSeconds(Choises.spawnMoreRagingGunnerTimer);
        moreRaginGunnerCoroutine = null;
        StartCoroutine(SpawnRaginGunner(false));
    }

    IEnumerator SpawnMoreHeavyShot()
    {
        yield return new WaitForSeconds(Choises.spawnMoreHeavyShotTimer);
        moreHeavyshotCoroutine = null;
        StartCoroutine(SpawnHeavyShot(false));
    }
}
