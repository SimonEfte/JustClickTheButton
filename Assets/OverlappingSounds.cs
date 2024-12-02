using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlappingSounds : MonoBehaviour
{
    public AudioClip impact1, impact2, impact3, impact4;
    public AudioClip pointDrop1, pointDrop2, pointDrop3;
    public AudioClip death1, death2, death3, death4, death5, death6, death7, death8, death9, death10, death11, death12, death13, death14, death15, death16;
    public AudioClip death1Big, death2Big;
    public AudioClip critSound1, critSound2, critSound3;
    public AudioClip damageSound1, damageSound2, damageSound3, damageSound4, damageSound5, damageSound6, damageSound7, damageSound8;

    public AudioSource pointsSource, deathSource, critSource, deathSourceBig, damageTakenSource;
    public int totalEnemiesOnScreen;

    public bool doNotPlayAudio;
    public void DeathSounds()
    {
        doNotPlayAudio = false;
        if (doNotPlayAudio == true)
        {
            float randomPitch = Random.Range(0.7f, 0.9f);
            deathSource.pitch = randomPitch;

            totalEnemiesOnScreen = SpawnEnemies.smallEnemyCount + SpawnEnemies.speedsterCount + SpawnShootingEnemy.shootingEnemyCount + SpawnShootingEnemy.sniperCount + SpawnShootingEnemy.sniperCount + SpawnShootingEnemy.heavyShotCount + SpawnShootingEnemy.ragingGunnerCount + SpawnBigEnemy.bigEnemyCount + SpawnBigEnemy.titanCount;

            if (totalEnemiesOnScreen < 15) { deathSource.volume = 0.75f; }
            else if (totalEnemiesOnScreen < 30) { deathSource.volume = 0.7f; }
            else if (totalEnemiesOnScreen < 50) { deathSource.volume = 0.68f; }
            else if (totalEnemiesOnScreen < 100) { deathSource.volume = 0.64f; }
            else if (totalEnemiesOnScreen < 150) { deathSource.volume = 0.6f; }
            else if (totalEnemiesOnScreen < 200) { deathSource.volume = 0.55f; }

            int random = Random.Range(1, 17);
            if (random == 1) { deathSource.PlayOneShot(death1); }
            if (random == 2) { deathSource.PlayOneShot(death2); }
            if (random == 3) { deathSource.PlayOneShot(death3); }
            if (random == 4) { deathSource.PlayOneShot(death4); }
            if (random == 5) { deathSource.PlayOneShot(death5); }
            if (random == 6) { deathSource.PlayOneShot(death6); }
            if (random == 7) { deathSource.PlayOneShot(death7); }
            if (random == 8) { deathSource.PlayOneShot(death8); }
            if (random == 9) { deathSource.PlayOneShot(death9); }
            if (random == 10) { deathSource.PlayOneShot(death10); }
            if (random == 11) { deathSource.PlayOneShot(death11); }
            if (random == 12) { deathSource.PlayOneShot(death12); }
            if (random == 13) { deathSource.PlayOneShot(death13); }
            if (random == 14) { deathSource.PlayOneShot(death14); }
            if (random == 15) { deathSource.PlayOneShot(death15); }
            if (random == 16) { deathSource.PlayOneShot(death16); }
        }
    }

    public void DeathSoundsBigenemies()
    {
        int random = Random.Range(1, 3);
        if (random == 1) { deathSourceBig.PlayOneShot(death1Big); }
        if (random == 2) { deathSourceBig.PlayOneShot(death2Big); }
    }

    public void ImpactSounds1()
    {
        //int random = Random.Range(1,5);
        //if(random == 1) { gunsImpactsource.PlayOneShot(impact1); }
        //if (random == 2) { gunsImpactsource.PlayOneShot(impact2); }
        //if (random == 3) { gunsImpactsource.PlayOneShot(impact3); }
        //if (random == 4) { gunsImpactsource.PlayOneShot(impact4); }
    }

    public void PointDropSounds()
    {
        int random = Random.Range(1,4);
        if(random == 1) { pointsSource.PlayOneShot(pointDrop1); }
        if (random == 2) { pointsSource.PlayOneShot(pointDrop2); }
        if (random == 3) { pointsSource.PlayOneShot(pointDrop3); }
    }

    public void CritSounds()
    {
        int randomCrit = Random.Range(1, 4);
        if (randomCrit == 1) { critSource.PlayOneShot(critSound1); }
        if (randomCrit == 2) { critSource.PlayOneShot(critSound2); }
        if (randomCrit == 3) { critSource.PlayOneShot(critSound3); }
    }

    public void DamageTakenSounds()
    {
        float randomPitch = Random.Range(0.9f, 1.35f);
        damageTakenSource.pitch = randomPitch;

        int randomDamage = Random.Range(1, 9);
        if (randomDamage == 1) { damageTakenSource.PlayOneShot(damageSound1); }
        if (randomDamage == 2) { damageTakenSource.PlayOneShot(damageSound2); }
        if (randomDamage == 3) { damageTakenSource.PlayOneShot(damageSound3); }
        if (randomDamage == 4) { damageTakenSource.PlayOneShot(damageSound4); }
        if (randomDamage == 5) { damageTakenSource.PlayOneShot(damageSound5); }
        if (randomDamage == 6) { damageTakenSource.PlayOneShot(damageSound6); }
        if (randomDamage == 7) { damageTakenSource.PlayOneShot(damageSound7); }
        if (randomDamage == 8) { damageTakenSource.PlayOneShot(damageSound8); }
    }
}
