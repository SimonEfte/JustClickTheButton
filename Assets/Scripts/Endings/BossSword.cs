using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSword : MonoBehaviour
{
    public static bool swordHitButton;
    public float bossSwordDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bossSwordDamage = 40;

        if (collision.gameObject.tag == "Button")
        {
            Choises.buttonHealth -= bossSwordDamage;
            TextPopUpBehavior.enemyDamageAmount = bossSwordDamage;

            swordHitButton = true;
        }
    }
}
