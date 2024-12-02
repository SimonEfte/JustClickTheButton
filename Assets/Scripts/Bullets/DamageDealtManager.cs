using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealtManager : MonoBehaviour
{
    #region Broken Uzi random dir damage
    //Small bullet - random dir
    public void DamageSmallEnemy_SmallBullet()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.smallBulletDamage;
    }
    public void DamageShootingEemy_SmallBullet()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.smallBulletDamage;
    }
    public void DamageBigEnemy_SmallBullet()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.smallBulletDamage;
    }

    #endregion

    #region gun 1 damage
    //Bullet from GUN1
    public void DamageSmallEnemy_BulletFromGun1()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.bulletGun1_Damage;
    }
    public void DamageShootingEemy_BulletFromGun1()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.bulletGun1_Damage;
    }
    public void DamageBigEnemy_BulletFromGun1()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.bulletGun1_Damage;
    }
    #endregion

    #region gun 3 mp4 damage
    //Bullet from GUN1
    public void DamageSmallEnemy_MP4()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.mp4Damage;
    }
    public void DamageShootingEemy_MP4()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.mp4Damage;
    }
    public void DamageBigEnemy_MP4()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.mp4Damage;
    }
    #endregion

    #region homing bullet DAMAGE
    public void DamageSmallEnemy_Homing()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.homingBulletDamage;
    }
    public void DamageShootingEemy_Homing()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.homingBulletDamage;
    }
    public void DamageBigEnemy_Homing()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.homingBulletDamage;
    }
    #endregion

    #region big piercing bullets DAMAGE
    public void DamageSmallEnemy_BigPiercingBullet()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.bigBulletDamage;
    }
    public void DamageShootingEnemy_BigPiercingBullet()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.bigBulletDamage;
    }
    public void DamageBigEnemy_BigPiercingBullet()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.bigBulletDamage;
    }
    #endregion

    #region enemy bullet BOUNCE DAMAGE
    public void DamageSmallEnemy(float damage)
    {
        SmallEnemyMovement.bulletDamageAmount = damage * 3;
    }
    public void DamageShootingEnemy(float damage)
    {
        ShootingEnemyMovement.bulletDamageAmount = damage * 3;
    }
    public void DamageBigEnemy_ShieldBounced(float damage)
    {
        BigEnemyMovement.bulletDamageAmount = damage * 3;
    }
    #endregion

    #region shotgun bullet DAMAGE
    public void DamageSmallEnemy_ShotgunBullet()
    {
        float random = Random.Range(Choises.shotGunBulletDamage, Choises.shotGunBulletDamage2);
        SmallEnemyMovement.bulletDamageAmount = random;
    }
    public void DamageShootingEemy_ShotgunBullet()
    {
        float random = Random.Range(Choises.shotGunBulletDamage, Choises.shotGunBulletDamage2);
        ShootingEnemyMovement.bulletDamageAmount = random;
    }
    public void DamageBigEnemy_ShotgunBullet()
    {
        float random = Random.Range(Choises.shotGunBulletDamage, Choises.shotGunBulletDamage2);
        BigEnemyMovement.bulletDamageAmount = random;
    }
    #endregion

    #region Arrow damage
    public void DamageSmallEnemy_Arrow()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.arrowDamage;
    }
    public void DamageShootingEemy_Arrow()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.arrowDamage;
    }
    public void DamageBigEnemy_Arrow()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.arrowDamage;
    }
    #endregion

    #region Crossbow Arrow damage
    public void DamageSmallEnemy_Crossbow()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.crossbowDamage;
    }
    public void DamageShootingEemy_Crossbow()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.crossbowDamage;
    }
    public void DamageBigEnemy_Crossbow()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.crossbowDamage;
    }
    #endregion

    #region Tripple Damage
    public void DamageSmallEnemy_Tripple()
    {
        SmallEnemyMovement.bulletDamageAmount = Choises.trippleShotDamage;
    }
    public void DamageShootingEnemy_Tripple()
    {
        ShootingEnemyMovement.bulletDamageAmount = Choises.trippleShotDamage;
    }
    public void DamageBigEnemy_Tripple()
    {
        BigEnemyMovement.bulletDamageAmount = Choises.trippleShotDamage;
    }
    #endregion

}
