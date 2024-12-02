using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigEnemy : MonoBehaviour
{
    public GameObject mainButton;
    private float lastSpawnTime;
    public Vector2 spawnPos;
    public static bool spawnBigEnemy, spawnTitan;

    public static int bigEnemyCount;
    public static int titanCount;

    public Coroutine moreBruteCoroutine, moreTitanCoroutine;
    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    void Start()
    {
        lastSpawnTime = Time.time;

        spawnBigEnemy = true;
        spawnTitan = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Choises.isInMainManu == false && Choises.bigEnemySpawn == true && spawnBigEnemy == true && BossMechanics.fightingBossFight == false && HordeEnding.hordeSpawnBrute == false)
        {
            StartCoroutine(SpawnBrute(true));
            spawnBigEnemy = false;
        }

        if (Choises.isInMainManu == false && Choises.titanSpawn == true && spawnTitan == true && BossMechanics.fightingBossFight == false && HordeEnding.hordeSpawnTitan == false)
        {
            StartCoroutine(SpawnTitan(true));
            spawnTitan = false;
        }
    }

    public int distanceThreshold;
    IEnumerator SpawnBrute(bool set)
    {
        if (bigEnemyCount < Choises.maxBrutes)
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
                random1 = Random.Range(-740 + -Choises.arenaSpawnPointChangeX, 740 + Choises.arenaSpawnPointChangeX);
                random2 = Random.Range(-335 + -Choises.arenaSpawnPointChangeY, 335 + Choises.arenaSpawnPointChangeY);

                if (randomPosSpawn == 1) { random2 = 335 + Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 2) { random2 = -335 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 3) { random1 = -740 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 4) { random1 = 740 + Choises.arenaSpawnPointChangeY; }

                randomSpawnPosition = new Vector2(random1, random2);

                distanceToMainButton = Vector2.Distance(randomSpawnPosition, mainButton.transform.localPosition);

                attempts++;
                if (attempts > 1) 
                {
                    //Debug.Log(attempts); 
                }

                if (randomPosSpawn == 1 || randomPosSpawn == 2)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 400; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 600; }

                }
                if (randomPosSpawn == 3 || randomPosSpawn == 4)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 320; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 425; }
                    if (Choises.arenaIncrease > 0.20f) { distanceThreshold = 450; }
                    if (Choises.arenaIncrease > 0.35f) { distanceThreshold = 500; }
                }

            } while (distanceToMainButton < distanceThreshold);


            Vector2 getPos;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (335 + Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-335 + -Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-740 + -Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((740 + Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }

            smallIndicator.transform.localScale = new Vector2(ObjectPool.bigEnemySize - 0.95f, ObjectPool.bigEnemySize - 0.95f);
            smallIndicator.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(1.4f);

            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);

            GameObject brute = ObjectPool.instance.GetBigEnemyFromPool();
            bigEnemyCount += 1;

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (335 + Choises.arenaSpawnPointChangeY)); brute.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-335 + -Choises.arenaSpawnPointChangeY)); brute.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-740 + -Choises.arenaSpawnPointChangeX), random2); brute.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((740 + Choises.arenaSpawnPointChangeX), random2); brute.transform.localPosition = getPos; }
        }

        yield return new WaitForSeconds(Choises.bigEnemySpawnTimer);
        if (moreBruteCoroutine == null && HordeEnding.playingHordeEnding == false) { moreBruteCoroutine = StartCoroutine(SpawnMoreBrutes()); }

        if (HordeEnding.playingHordeEnding == false && set == true) { spawnBigEnemy = true; }
    }

    public float distanceToMainButton;
    IEnumerator SpawnTitan(bool set)
    {
        if (titanCount < Choises.maxTitans)
        {
            titanCount += 1;
            if(Choises.arenaIncrease < 0.4f && HordeEnding.playingHordeEnding == false) 
            {
                #region Titan spawn - Small arena
                int randomCorner = Random.Range(1, 5);

                if (Choises.movementAbilityAquaried == true)
                {
                    if (mainButton.transform.localPosition.y < 1)
                    {
                        int randomSet = Random.Range(1, 3);
                        if (randomSet == 1) { randomCorner = 1; }
                        if (randomSet == 2) { randomCorner = 4; }
                    }
                    if (mainButton.transform.localPosition.y > 0)
                    {
                        randomCorner = Random.Range(2, 4);
                    }
                }

                if (randomCorner == 1) { spawnPos = new Vector2(670 + Choises.arenaSpawnPointChangeX, 255 + Choises.arenaSpawnPointChangeY); }
                if (randomCorner == 2) { spawnPos = new Vector2(670 + Choises.arenaSpawnPointChangeX, -255 - Choises.arenaSpawnPointChangeY); }
                if (randomCorner == 3) { spawnPos = new Vector2(-670 - Choises.arenaSpawnPointChangeX, -255 - Choises.arenaSpawnPointChangeY); }
                if (randomCorner == 4) { spawnPos = new Vector2(-670 - Choises.arenaSpawnPointChangeX, 255 + Choises.arenaSpawnPointChangeY); }

                GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();
                smallIndicator.transform.localPosition = spawnPos;
                smallIndicator.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, 40));
                smallIndicator.transform.localScale = new Vector2(ObjectPool.titanSize - 0.7f, ObjectPool.titanSize - 0.7f);
                smallIndicator.GetComponent<Animation>().Play();
                yield return new WaitForSeconds(1.4f);
                ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);

                GameObject titan = ObjectPool.instance.GetTitanFromPool();
                titan.transform.localPosition = spawnPos;
                #endregion
            }

            if (Choises.arenaIncrease > 0.4f || HordeEnding.playingHordeEnding == true)
            {
                #region Titan spawn - Small arena
                int randomPosSpawn = Random.Range(1, 5);
                int random1, random2;
                Vector2 randomSpawnPosition;
                float distanceToMainButton;

                // Set the maximum attempts to prevent an infinite loop (adjust as needed)
                int attempts = 0;

                do
                {
                    // Generate random positions
                    random1 = Random.Range(-670 + -Choises.arenaSpawnPointChangeX, 670 + Choises.arenaSpawnPointChangeX);
                    random2 = Random.Range(-255 + -Choises.arenaSpawnPointChangeY, 255 + Choises.arenaSpawnPointChangeY);

                    if (randomPosSpawn == 1) { random2 = 255 + Choises.arenaSpawnPointChangeY; }
                    if (randomPosSpawn == 2) { random2 = -255 + -Choises.arenaSpawnPointChangeY; }
                    if (randomPosSpawn == 3) { random1 = -670 + -Choises.arenaSpawnPointChangeY; }
                    if (randomPosSpawn == 4) { random1 = 670 + Choises.arenaSpawnPointChangeY; }

                    randomSpawnPosition = new Vector2(random1, random2);

                    distanceToMainButton = Vector2.Distance(randomSpawnPosition, mainButton.transform.localPosition);

                    attempts++;
                    if (attempts > 1)
                    {
                        //Debug.Log(attempts); 
                    }

                    if (randomPosSpawn == 1 || randomPosSpawn == 2)
                    {
                        distanceThreshold = 750;
                    }
                    if (randomPosSpawn == 3 || randomPosSpawn == 4)
                    {
                        distanceThreshold = 600;
                    }

                } while (distanceToMainButton < distanceThreshold);


                Vector2 getPos;

                GameObject titanIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();

                if (randomPosSpawn == 1) { getPos = new Vector2(random1, (255 + Choises.arenaSpawnPointChangeY)); titanIndicator.transform.localPosition = getPos; }
                if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-255 + -Choises.arenaSpawnPointChangeY)); titanIndicator.transform.localPosition = getPos; }
                if (randomPosSpawn == 3) { getPos = new Vector2((-670 + -Choises.arenaSpawnPointChangeX), random2); titanIndicator.transform.localPosition = getPos; }
                if (randomPosSpawn == 4) { getPos = new Vector2((670 + Choises.arenaSpawnPointChangeX), random2); titanIndicator.transform.localPosition = getPos; }

                titanIndicator.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, 40));
                titanIndicator.transform.localScale = new Vector2(ObjectPool.titanSize - 0.7f, ObjectPool.titanSize - 0.7f);
                titanIndicator.GetComponent<Animation>().Play();
                yield return new WaitForSeconds(1.4f);

                ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(titanIndicator);

                GameObject titan = ObjectPool.instance.GetTitanFromPool();

                if (randomPosSpawn == 1) { getPos = new Vector2(random1, (255 + Choises.arenaSpawnPointChangeY)); titan.transform.localPosition = getPos; }
                if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-255 + -Choises.arenaSpawnPointChangeY)); titan.transform.localPosition = getPos; }
                if (randomPosSpawn == 3) { getPos = new Vector2((-670 + -Choises.arenaSpawnPointChangeX), random2); titan.transform.localPosition = getPos; }
                if (randomPosSpawn == 4) { getPos = new Vector2((670 + Choises.arenaSpawnPointChangeX), random2); titan.transform.localPosition = getPos; }
                #endregion
            }
        }

        yield return new WaitForSeconds(Choises.titanSpawnTimer);
        if(moreTitanCoroutine == null && HordeEnding.playingHordeEnding == false) { moreTitanCoroutine = StartCoroutine(SpawnMoreTitans()); }
        if (HordeEnding.playingHordeEnding == false && set == true) { spawnTitan = true; }
    }

    IEnumerator SpawnMoreBrutes()
    {
        yield return new WaitForSeconds(Choises.spawnMoreBruteTimer);
        moreBruteCoroutine = null;
        StartCoroutine(SpawnBrute(false));
    }

    IEnumerator SpawnMoreTitans()
    {
        yield return new WaitForSeconds(Choises.spawnMoreTitanTimer);
        moreTitanCoroutine = null;
        StartCoroutine(SpawnTitan(false));
    }
}
