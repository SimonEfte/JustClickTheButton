using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargedBullet : MonoBehaviour
{
    private float bulletDamage;
    public static float chargedBossDamage, chargedChampion1Damage, chargedChampion2Damage, chargedChampion3Damage;

    public Transform particle, nonParticle;

    public void Awake()
    {
        particle = transform.Find("chargedBulletParticle");
        nonParticle = transform.Find("chargedNonParticle");
    }

    private void OnEnable()
    {
        if (SettingsOptions.disableParticleEffects == 0)
        {
            particle.gameObject.SetActive(true);
            nonParticle.gameObject.SetActive(false);
        }
        if (SettingsOptions.disableParticleEffects == 1)
        {
            particle.gameObject.SetActive(false);
            nonParticle.gameObject.SetActive(true);
        }

        bulletDamage = ButtonBehiavor.chargedBulletDamage;
        StartCoroutine(SetBulletInactive());
    }

    IEnumerator SetBulletInactive()
    {
        yield return new WaitForSeconds(6f);
        ObjectPool.instance.ReturnChargedBulletFromPool(gameObject);
    }

    //Piercing
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootingEnemy")
        {
            DamageShootingEnemy();
        }

        if (other.gameObject.tag == "Sniper")
        {
            DamageShootingEnemy();
        }

        if (other.gameObject.tag == "HeavyShot")
        {
            DamageShootingEnemy();
        }

        if (other.gameObject.tag == "RagingGunner")
        {
            DamageShootingEnemy();
        }

        if (other.gameObject.tag == "SmallEnemy")
        {
            DamageSmallEnemy();
        }

        if (other.gameObject.tag == "Speedster")
        {
            DamageSmallEnemy();
        }
    
        #region Hit big enemy
        if (other.gameObject.tag == "BigEnemy")
        {
            DamageBigEnemy();
        }
        #endregion

        #region Hit titan
        if (other.gameObject.tag == "Titan")
        {
            DamageBigEnemy();
        }
        #endregion

        #region Hit boss
        if (other.gameObject.tag == "Boss")
        {
            DamageBoss();
        }
        #endregion

        #region Hit champion 1
        if (other.gameObject.name == "Champion1Stab")
        {
            DamageChampion1();
        }
        #endregion

        #region Hit champion 2
        if (other.gameObject.name == "Champion2Ranged")
        {
            DamageChampion2();
        }
        #endregion

        #region Hit champion 3
        if (other.gameObject.name == "Champion3Armored")
        {
            DamageChampion3();
        }
        #endregion
    }

    public void DamageSmallEnemy()
    {
        SmallEnemyMovement.bulletDamageAmount = bulletDamage;
    }

    public void DamageShootingEnemy()
    {
        ShootingEnemyMovement.bulletDamageAmount = bulletDamage;
    }

    public void DamageBigEnemy()
    {
        BigEnemyMovement.bulletDamageAmount = bulletDamage;
    }

    public void DamageBoss()
    {
        BossMechanics.bossHealth -= bulletDamage;
        chargedBossDamage = bulletDamage;
    }

    public void DamageChampion1()
    {
        Champion1Movement.champion1HP -= bulletDamage;
        chargedChampion1Damage = bulletDamage;
    }

    public void DamageChampion2()
    {
        Champion2Movement.champion2HP -= bulletDamage;
        chargedChampion2Damage = bulletDamage;
    }

    public void DamageChampion3()
    {
        MimicEnding.champion3HP -= bulletDamage;
        chargedChampion3Damage = bulletDamage;
    }
}
