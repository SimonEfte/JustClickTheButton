using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjects : MonoBehaviour
{
    public static bool spawnBasicPoin;
    public GameObject arenaSize;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(spawnBasicPoin == true)
        //{
        //    StartCoroutine(SpawnBAsicPoints());
        //    spawnBasicPoin = false;
        //}
    }

    IEnumerator SpawnBAsicPoints()
    {
        yield return new WaitForSeconds(2);
        SetBasicPointPos();
        spawnBasicPoin = true;
    }

    public void SetBasicPointPos()
    {
        GameObject basicPoints = ObjectPool.instance.GetBasicPointsFromPool();

        Vector2 arenaScale = arenaSize.transform.localScale;

        // Calculate the half size of the arena based on its scale
        float halfArenaX = arenaScale.x * 5;
        float halfArenaY = arenaScale.y * 3;

        float randomX = Random.Range(-halfArenaX, halfArenaX);
        float randomY = Random.Range(-halfArenaY, halfArenaY);

        // Calculate the spawn position
        Vector3 spawnPosition = new Vector3(randomX, randomY);

        basicPoints.transform.position = spawnPosition;
    }

}
