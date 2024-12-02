using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerButtonCollider : MonoBehaviour
{
    public void OnEnable()
    {
        buttonDamaged = false;
        dangerButtonDeath = false;
    }

    public bool dangerButtonDeath;
    public void Update()
    {
        if (Choises.didPlayerDie == true && dangerButtonDeath == false)
        {
            dangerButtonDeath = true;
            if(waitCoroutine != null) { StopCoroutine(waitCoroutine); } 
        }
    }

    public bool hitButton;
    public static Vector2 damagePos;
    public static bool buttonDamaged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            if (hitButton == false)
            {
                Choises.buttonHealth -= DangerButtonMovement.dangerButtonDamage;
                TextPopUpBehavior.enemyDamageAmount = DangerButtonMovement.dangerButtonDamage;
                if(waitCoroutine == null && dangerButtonDeath == false) { waitCoroutine = StartCoroutine(Wait()); }
                
                hitButton = true;
                buttonDamaged = true;
            }
        }
    }

    public Coroutine waitCoroutine;
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        hitButton = false;
        waitCoroutine = null;
    }
}
