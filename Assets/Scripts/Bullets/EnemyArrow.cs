using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
    public static bool enemyArrowDamaged;

    public void OnEnable()
    {
        endingTransitionSetInactive = false;
    }

    public bool endingTransitionSetInactive;
    public void Update()
    {
        if (Choises.playerDied || Choises.isInWinScreen == true)
        {
            if(endingTransitionSetInactive == false)
            {
                ObjectPool.instance.ReturnEnemyArrowsFromPool(gameObject);
                endingTransitionSetInactive = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallShields")
        {
            ObjectPool.instance.ReturnEnemyArrowsFromPool(gameObject);
        }

        if (collision.gameObject.tag == "Shield_Bounce")
        {
            ObjectPool.instance.ReturnEnemyArrowsFromPool(gameObject);
        }

        if (collision.gameObject.tag == "Button")
        {
            Choises.buttonHealth -= Champion2Movement.champion2ArrowDamage;
            TextPopUpBehavior.enemyDamageAmount = Champion2Movement.champion2ArrowDamage;
            enemyArrowDamaged = true;
            ObjectPool.instance.ReturnEnemyArrowsFromPool(gameObject);
        }
    }


}
