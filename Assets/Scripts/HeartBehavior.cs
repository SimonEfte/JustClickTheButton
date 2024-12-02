using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    public static bool hitBigHeart;
    public static Vector2 bigHeartPos;

    public GameObject soundManager;
    public AudioManager audioManager;
    public bool hitHeart;

    public void Awake()
    {
        soundManager = GameObject.Find("Audio");
        audioManager = soundManager.GetComponent<AudioManager>();
    }

    private void OnEnable()
    {
        hitHeart = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if(hitHeart == false)
            {
                hitHeart = true;
                Choises.buttonHealth += Choises.bigHeartHPHeal;
                ObjectPool.instance.ReturnHeartFromPool(gameObject);
                hitBigHeart = true;
                bigHeartPos = gameObject.transform.localPosition;
                audioManager.Play("Heal");
            }
        }

        if (other.gameObject.tag == "Button")
        {
            if (hitHeart == false)
            {
                hitHeart = true;
                Choises.buttonHealth += Choises.bigHeartHPHeal;
                ObjectPool.instance.ReturnHeartFromPool(gameObject);
                hitBigHeart = true;
                bigHeartPos = gameObject.transform.localPosition;
                audioManager.Play("Heal");
            }
        }
    }
}
