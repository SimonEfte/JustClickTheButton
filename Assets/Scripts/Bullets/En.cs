using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En : MonoBehaviour
{
    public static List<GameObject> activeEnemies = new List<GameObject>();

    public static void RegisterEnemy(GameObject enemy)
    {
        activeEnemies.Add(enemy);
    }

    public static void UnregisterEnemy(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
    }
}
