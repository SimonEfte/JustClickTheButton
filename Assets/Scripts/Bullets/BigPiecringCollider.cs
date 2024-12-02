using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPiecringCollider : MonoBehaviour
{
    public GameObject damageManagerObject;
    private DamageDealtManager damageManager;

    private void Awake()
    {
        damageManagerObject = GameObject.Find("BulletDamageManager");
        damageManager = damageManagerObject.GetComponent<DamageDealtManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Hit small enemy
        if (collision.gameObject.tag == "SmallEnemy")
        {
            damageManager.DamageSmallEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit small enemy
        if (collision.gameObject.tag == "Speedster")
        {
            damageManager.DamageSmallEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit shooting enemy
        if (collision.gameObject.tag == "shootingEnemy")
        {
            damageManager.DamageShootingEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit sniper
        if (collision.gameObject.tag == "Sniper")
        {
            damageManager.DamageShootingEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit gunner
        if (collision.gameObject.tag == "RagingGunner")
        {
            damageManager.DamageShootingEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit heavyshot
        if (collision.gameObject.tag == "HeavyShot")
        {
            damageManager.DamageShootingEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit big enemy
        if (collision.gameObject.tag == "BigEnemy")
        {
            damageManager.DamageBigEnemy_BigPiercingBullet();
        }
        #endregion

        #region Hit titan
        if (collision.gameObject.tag == "Titan")
        {
            damageManager.DamageBigEnemy_BigPiercingBullet();
        }
        #endregion
    }
}
