using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPiercingBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    Vector3 lastVelocity;
    private bool isNearArena;

    private bool endingTransitionSetInactive;

    public void OnEnable()
    {
        endingTransitionSetInactive = false;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Choises.bossChosenSetStuffInactive == true || Choises.playerDied == true || Choises.isInWinScreen == true)
        {
            if (endingTransitionSetInactive == false)
            {
                ObjectPool.instance.ReturnBigPiercingBulletFromPool(gameObject);
                endingTransitionSetInactive = true;
            }
        }

        lastVelocity = rb.velocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region All bullets hit arena and bounces
        if (collision.gameObject.tag == "Arena")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0);
        }
        #endregion

        #region Hit Boss Arena
        if (collision.gameObject.layer == 16)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0);
        }
        #endregion
    }

   

}
