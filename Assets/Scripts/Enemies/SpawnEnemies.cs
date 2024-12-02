using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float maxSpawnRadius;   
    public float minSpawnRadius;

    private float lastSpawnTime;

    public static int smallEnemyCount, speedsterCount;
    public GameObject arenaSize;

    public static bool spawnSpeedster, spawnSmallEnemy;

    public Coroutine smallEnemyCoroutine, speedsterCoroutine;
    public GameObject mainButton;

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    void Start()
    {
        spawnSpeedster = true;
        spawnSmallEnemy = true;

        lastSpawnTime = Time.time;

        maxSpawnRadius = 33f;
        minSpawnRadius = 14f;
    }

    public Coroutine moreSmallEnemyCoroutine, moreSpeedsterCoroutine;

    // Update is called once per frame
    void Update()
    {
        if(Choises.isInMainManu == false && Choises.speedsterSpawn == true && spawnSpeedster == true && BossMechanics.fightingBossFight == false && HordeEnding.hordeSpawnSpeedster == false)
        {
            StartCoroutine(SpawnSpeedsters(true));
            spawnSpeedster = false;
        }

        if (Choises.isInMainManu == false && Choises.smallEnemySpawn == true && spawnSmallEnemy == true && BossMechanics.fightingBossFight == false && HordeEnding.hordeSpawnSmallEnemy == false)
        {
            StartCoroutine(SpawnSmallEnemy(true));
            spawnSmallEnemy = false;
        }
    }

    public int distanceThreshold;
    IEnumerator SpawnSmallEnemy(bool set)
    {
        if (smallEnemyCount < Choises.maxAssasins)
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
                random1 = Random.Range(-900 + -Choises.arenaSpawnPointChangeX, 900 + Choises.arenaSpawnPointChangeX);
                random2 = Random.Range(-475 + -Choises.arenaSpawnPointChangeY, 475 + Choises.arenaSpawnPointChangeY);

                if(randomPosSpawn == 1) { random2 = 475 + Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 2) { random2 = -475 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 3) { random1 = -900 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 4) { random1 = 900 + Choises.arenaSpawnPointChangeY; }

                randomSpawnPosition = new Vector2(random1, random2);

                // Check distance to mainButton (adjust the threshold as needed)
                distanceToMainButton = Vector2.Distance(randomSpawnPosition, mainButton.transform.localPosition);

                attempts++;
                if(attempts > 1) 
                {
                    //Debug.Log(attempts);
                }

                if (randomPosSpawn == 1 || randomPosSpawn == 2)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 475; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 600; }
                    
                }
                if (randomPosSpawn == 3 || randomPosSpawn == 4) 
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 340; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 450; }
                    if (Choises.arenaIncrease > 0.20f) { distanceThreshold = 490; }
                    if (Choises.arenaIncrease > 0.35f) { distanceThreshold = 525; }
                }

                // Check if within threshold or reached maxAttempts
            } while (distanceToMainButton < distanceThreshold);

            Vector2 getPos;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (475 + Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-475 + -Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-900 + -Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((900 + Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }

            smallIndicator.transform.localScale = new Vector2(ObjectPool.smallEnemySize - 0.1f, ObjectPool.smallEnemySize - 0.1f);
            smallIndicator.GetComponent<Animation>().Play();
            yield return new WaitForSeconds(1.4f);

            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);

            GameObject smallEnemy = ObjectPool.instance.GetSmallEnemyFromPool();
            smallEnemyCount += 1;

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (475 + Choises.arenaSpawnPointChangeY)); smallEnemy.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-475 + -Choises.arenaSpawnPointChangeY)); smallEnemy.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-900 + -Choises.arenaSpawnPointChangeX), random2); smallEnemy.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((900 + Choises.arenaSpawnPointChangeX), random2); smallEnemy.transform.localPosition = getPos; }
        }

        yield return new WaitForSeconds(Choises.smallEnemySpawnTimer);
        if(moreSmallEnemyCoroutine == null && HordeEnding.playingHordeEnding == false) { moreSmallEnemyCoroutine = StartCoroutine(SpawnMoreSmallEnemies()); }

        if (HordeEnding.playingHordeEnding == false && set == true) { spawnSmallEnemy = true; }
    }

    
    IEnumerator SpawnSpeedsters(bool set)
    {
        if (speedsterCount < Choises.maxSpeedsters)
        {
            speedsterCount += 1;
            int randomPosSpawn = Random.Range(1, 5);

            int random1, random2;
            Vector2 randomSpawnPosition;
            float distanceToMainButton;

            // Set the maximum attempts to prevent an infinite loop (adjust as needed)
            int attempts = 0;

            do
            {
                // Generate random positions
                random1 = Random.Range(-900 + -Choises.arenaSpawnPointChangeX, 900 + Choises.arenaSpawnPointChangeX);
                random2 = Random.Range(-475 + -Choises.arenaSpawnPointChangeY, 475 + Choises.arenaSpawnPointChangeY);

                if (randomPosSpawn == 1) { random2 = 475 + Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 2) { random2 = -475 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 3) { random1 = -900 + -Choises.arenaSpawnPointChangeY; }
                if (randomPosSpawn == 4) { random1 = 900 + Choises.arenaSpawnPointChangeY; }

                randomSpawnPosition = new Vector2(random1, random2);

                distanceToMainButton = Vector2.Distance(randomSpawnPosition, mainButton.transform.localPosition);

                attempts++;
                if (attempts > 1) 
                {
                    //Debug.Log(attempts);
                }

                if (randomPosSpawn == 1 || randomPosSpawn == 2)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 475; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 600; }

                }
                if (randomPosSpawn == 3 || randomPosSpawn == 4)
                {
                    if (Choises.arenaIncrease == 0) { distanceThreshold = 340; }
                    if (Choises.arenaIncrease > 0.10f) { distanceThreshold = 450; }
                    if (Choises.arenaIncrease > 0.20f) { distanceThreshold = 490; }
                    if (Choises.arenaIncrease > 0.35f) { distanceThreshold = 525; }
                }

            } while (distanceToMainButton < distanceThreshold);

            Vector2 getPos;

            GameObject smallIndicator = ObjectPool.instance.GetSmallEnemyIndicatorFromPool();

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (475 + Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-475 + -Choises.arenaSpawnPointChangeY)); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-900 + -Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((900 + Choises.arenaSpawnPointChangeX), random2); smallIndicator.transform.localPosition = getPos; }

            smallIndicator.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-40f, 40));
            smallIndicator.transform.localScale = new Vector2(ObjectPool.speedsterSize, ObjectPool.speedsterSize);
            smallIndicator.GetComponent<Animation>().Play();

            yield return new WaitForSeconds(1.4f);
            ObjectPool.instance.ReturnSmallEnemyIndicatorFromPool(smallIndicator);
            

            GameObject speedster = ObjectPool.instance.GetSpeedsterFromPool();

            if (randomPosSpawn == 1) { getPos = new Vector2(random1, (475 + Choises.arenaSpawnPointChangeY)); speedster.transform.localPosition = getPos; }
            if (randomPosSpawn == 2) { getPos = new Vector2(random1, (-475 + -Choises.arenaSpawnPointChangeY)); speedster.transform.localPosition = getPos; }
            if (randomPosSpawn == 3) { getPos = new Vector2((-900 + -Choises.arenaSpawnPointChangeX), random2); speedster.transform.localPosition = getPos; }
            if (randomPosSpawn == 4) { getPos = new Vector2((900 + Choises.arenaSpawnPointChangeX), random2); speedster.transform.localPosition = getPos; }
        
            speedster.tag = "Speedster";
        }

        yield return new WaitForSeconds(Choises.speedsterSpawnTimer);
        if (moreSpeedsterCoroutine == null && HordeEnding.playingHordeEnding == false) { moreSpeedsterCoroutine = StartCoroutine(SpawnMoreSpeedsters()); }

        if (HordeEnding.playingHordeEnding == false && set == true) { spawnSpeedster = true; }
    }

    IEnumerator SpawnMoreSmallEnemies()
    {
        yield return new WaitForSeconds(Choises.spawnMoreSmallEnemiesTimer);
        moreSmallEnemyCoroutine = null;
        StartCoroutine(SpawnSmallEnemy(false));
    }

    IEnumerator SpawnMoreSpeedsters()
    {
        yield return new WaitForSeconds(Choises.spawnMoreSpeedsterTimer);
        moreSpeedsterCoroutine = null;
        StartCoroutine(SpawnSpeedsters(false));
    }

}
