using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySawBlade : MonoBehaviour
{
    public static bool enemySawBladeDamaged;

    public void OnEnable()
    {
        if(gameObject.name != "sawBladeOnChampion")
        {
            if (sawBladeCoroutine != null)
            {
                StopCoroutine(sawBladeCoroutine);
                sawBladeCoroutine = null;
                sawBladeCoroutine = StartCoroutine(SetBackSawBlade());
            }

            if (sawBladeCoroutine == null) 
            {
                sawBladeCoroutine = StartCoroutine(SetBackSawBlade()); 
            }
        }
    }

    public Coroutine sawBladeCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SmallShields")
        {
            ObjectPool.instance.ReturnEnemySawBladeFromPool(gameObject);
        }

        if (collision.gameObject.tag == "Shield_Bounce")
        {
            ObjectPool.instance.ReturnEnemySawBladeFromPool(gameObject);
        }

        if (collision.gameObject.tag == "Button")
        {
            Choises.buttonHealth -= Champion3.champion3SawBladeDamage;
            TextPopUpBehavior.enemyDamageAmount = Champion3.champion3SawBladeDamage;
            enemySawBladeDamaged = true;

            if (gameObject.name != "sawBladeOnChampion")
            {
                ObjectPool.instance.ReturnEnemySawBladeFromPool(gameObject);
            }
        }
    }

    IEnumerator SetBackSawBlade()
    {
        yield return new WaitForSeconds(4f);

        ObjectPool.instance.ReturnEnemySawBladeFromPool(gameObject);
    }
}
