using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private string originalParentName;
    public GameObject originalParent;

    public void Start()
    {
        originalParentName = "knifePool";
        originalParent = GameObject.Find(originalParentName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7 || collision.gameObject.tag == "RagingGunner" || collision.gameObject.tag == "Sniper" || collision.gameObject.tag == "HeavyShot" || collision.gameObject.tag == "shootingEnemy")
        {
            gameObject.GetComponent<Transform>().SetParent(originalParent.transform);

            ButtonClick.knifeCount -= 1;
            if(ButtonClick.knifeCount < 1) { ButtonClick.knifeCount = 0; }
            ObjectPool.instance.ReturnKnifeFromPool(gameObject);
        }
    }
}
