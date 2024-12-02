using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextPopUpBehavior : MonoBehaviour
{
    public Coroutine whiteFlashCorroutine;
    public GameObject whiteFlash, whiteFlashTopLeft;
    public GameObject buttonDamagedPos, damageOriginalParent, topLeftDamaged;

    public void Update()
    {
        #region enemy damages
        if (SmallEnemyMovement.enemyDamaged == true || ShootingEnemyMovement.enemyDamaged == true || BigEnemyMovement.bigEnemyDamaged == true || BossMechanics.bossDamaged == true || BossMechanics.bossArrowDamaged == true || SmallBossShields.shieldArrowDamaged == true || SmallBossShields.shieldDamaged || Champion1Movement.champion1Damaged || Champion1Movement.champion1ArrowDamaged || Champion2Movement.champion2Damaged || Champion2Movement.champion2ArrowDamaged || Champion3.champion3ArrowDamaged || Champion3.champion3Damaged || HeartBehavior.hitBigHeart == true)
        {
            if(SettingsOptions.disableEnemyDamagePopUp == 0) { StartCoroutine(EnemyDamageTextPupUp()); }
        }
        #endregion

        if (EnemyBullet.bulletHitButton == true || SmallEnemyMovement.enemyAttacking == true || BigEnemyMovement.enemyAttacking == true || EnemyBullet.bossBulletHitButton == true || Bullets.bossShieldBounceHitButton == true || ShootingEnemyMovement.enemyAttacking == true || Champion1Movement.hitChampion1Stab == true || EnemyArrow.enemyArrowDamaged == true || EnemySawBlade.enemySawBladeDamaged == true || BossSword.swordHitButton == true || DangerButtonCollider.buttonDamaged == true || EnemyBullet.dangerButtonBulletHitButton == true)
        {
            if (SettingsOptions.disableWhiteFlash == 0)
            {
                if (whiteFlashCorroutine != null) { StopCoroutine(whiteFlashCorroutine); whiteFlashCorroutine = StartCoroutine(WhiteFlashButtonDamaged()); }
                else
                {
                    whiteFlashCorroutine = StartCoroutine(WhiteFlashButtonDamaged());
                }
            }
           
            StartCoroutine(damageText());
        }

        if(PointsCollision.hitBasicPoints == true)
        {
            if(SettingsOptions.disablePointPopUp == 0) { StartCoroutine(BasicPointsText()); }
            PointsCollision.hitBasicPoints = false;
        }
    }

    #region Button Damaged Indicator
    IEnumerator WhiteFlashButtonDamaged()
    {
        whiteFlashTopLeft.SetActive(true);
        whiteFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        whiteFlash.SetActive(false);
        whiteFlashTopLeft.SetActive(false);
        whiteFlashCorroutine = null;
    }
    #endregion

    #region Damage Amount
    public static float enemyDamageAmount;
    public OverlappingSounds overlappSounds;

    IEnumerator damageText()
    {
        GameObject damageText = ObjectPool.instance.GetDamageTextFromPool();
        damageText.GetComponent<TextMeshProUGUI>().color = Color.red;

        TextMeshProUGUI textMesh = damageText.GetComponent<TextMeshProUGUI>();
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, Mathf.Lerp(1f, 1f, 1f));

        if (MainButtonCollider.isInvincibilityActive == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-0";
        }
        if (MainButtonCollider.isInvincibilityActive == false)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + enemyDamageAmount.ToString("F0");

            overlappSounds.DamageTakenSounds();
        }

        float preferredWidth = textMesh.GetPreferredValues().x;
        textMesh.rectTransform.sizeDelta = new Vector2(preferredWidth, textMesh.rectTransform.sizeDelta.y);

        if (SettingsOptions.healthbarPosition == 0)
        {
            damageText.transform.SetParent(buttonDamagedPos.transform);
        }
        if (SettingsOptions.healthbarPosition == 1)
        {
            damageText.transform.SetParent(topLeftDamaged.transform);
        }

        if (EnemyBullet.bossBulletHitButton == true || Bullets.bossShieldBounceHitButton == true || Champion1Movement.hitChampion1Stab == true || EnemyArrow.enemyArrowDamaged == true || EnemySawBlade.enemySawBladeDamaged == true || BossSword.swordHitButton == true || DangerButtonCollider.buttonDamaged == true || EnemyBullet.dangerButtonBulletHitButton == true)
        {
            damageText.GetComponent<Animation>().Play("ButtonDamagedEndings");
        }
        else
        {
            damageText.GetComponent<Animation>().Play("ButtonDamagedAnim");
        }
     
        if (SettingsOptions.healthbarPosition == 0)
        {
            float randomOffset = Random.Range(-11f, 11f);
            Vector2 pos = new Vector2(buttonDamagedPos.transform.position.x + randomOffset, buttonDamagedPos.transform.position.y);
            damageText.transform.position = pos;
        }
        if (SettingsOptions.healthbarPosition == 1)
        {
            float randomOffset = Random.Range(-165f, 165f);
            Vector2 pos = new Vector2(topLeftDamaged.transform.position.x + randomOffset, topLeftDamaged.transform.position.y);
            damageText.transform.position = pos;
        }

        EnemyBullet.bulletHitButton = false;
        SmallEnemyMovement.enemyAttacking = false;
        BigEnemyMovement.enemyAttacking = false;
        EnemyBullet.bossBulletHitButton = false;
        Bullets.bossShieldBounceHitButton = false;
        ShootingEnemyMovement.enemyAttacking = false;
        Champion1Movement.hitChampion1Stab = false;
        EnemyArrow.enemyArrowDamaged = false;
        EnemySawBlade.enemySawBladeDamaged = false;
        BossSword.swordHitButton = false;
        DangerButtonCollider.buttonDamaged = false;
        EnemyBullet.dangerButtonBulletHitButton = false;

        yield return new WaitForSeconds(0.4f);

        damageText.transform.SetParent(damageOriginalParent.transform);
        ObjectPool.instance.ReturnDamageTextFromPool(damageText);
    }
    #endregion

    #region EnemyTextPointsPopUp
    public void EnemyPointsPopUp(bool smallEnemyDied, bool speedsterEnemyDied)
    {
        if(SettingsOptions.disablePointPopUp == 0) { StartCoroutine(EnemyPointsAnim(smallEnemyDied, speedsterEnemyDied, false, false, false, false, false, false)); }
    }

    public void ShootingEnemyPopUp(bool sharpshooterDied, bool sniperDied, bool ragingGunnerDied, bool heavyShotDied)
    {
        if (SettingsOptions.disablePointPopUp == 0) { StartCoroutine(EnemyPointsAnim(false, false, sharpshooterDied, sniperDied, false, ragingGunnerDied, heavyShotDied, false)); }
    }

    public void BigEnemyPointsPopUp(bool bruteDied, bool titanDied)
    {
        if (SettingsOptions.disablePointPopUp == 0) { StartCoroutine(EnemyPointsAnim(false, false, false, false, bruteDied, false, false, titanDied)); }
    }

    IEnumerator EnemyPointsAnim(bool smallEnemyDied, bool speedsterEnemyDied, bool sharpshooterDied, bool sniperDied, bool bruteDied, bool ragingGinnerDies, bool heavyShotDied, bool titanDied)
    {
        if (HordeEnding.playingHordeEnding == false)
        {
            GameObject pointText = ObjectPool.instance.GetPointTextFromPool();
            TextMeshProUGUI textMesh = pointText.GetComponent<TextMeshProUGUI>();
            Transform childTransform = pointText.transform.Find("Points");

         

            foreach (Transform child in pointText.transform)
            {
                if (child.name == "Points") { child.gameObject.SetActive(true); }
                else { child.gameObject.SetActive(false); }

                Color currentColor = child.gameObject.GetComponent<Image>().color;
                currentColor.a = 1f;

                child.gameObject.GetComponent<Image>().color = currentColor;
            }
               

            if (smallEnemyDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.smallEnemyPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
            }

            if (speedsterEnemyDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.speedsterPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            }

            if (sharpshooterDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.shootingEnemyPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            }

            if (sniperDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.sniperPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }

            if (ragingGinnerDies == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.raginGunnerPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (heavyShotDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.heavyShotPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            if (bruteDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.bigEnemyPoint.ToString("F0");
                pointText.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            }

            if (titanDied == true)
            {
                pointText.GetComponent<TextMeshProUGUI>().text = "<color=green> +" + Choises.titanPoints.ToString("F0");
                pointText.transform.localScale = new Vector3(2.2f, 2.2f, 2.2f);
            }

            float preferredWidth = textMesh.GetPreferredValues().x;
            textMesh.rectTransform.sizeDelta = new Vector2(preferredWidth, textMesh.rectTransform.sizeDelta.y);

            Color initialColor = textMesh.color;
            initialColor.a = 1.0f;
            textMesh.color = initialColor;

            if (smallEnemyDied == true || speedsterEnemyDied == true) { pointText.transform.position = SmallEnemyMovement.enemyDiePos; }
            if (sharpshooterDied == true || sniperDied == true || ragingGinnerDies == true || heavyShotDied == true) { pointText.transform.position = ShootingEnemyMovement.enemyDiePos; }
            if (bruteDied == true || titanDied == true) { pointText.transform.position = BigEnemyMovement.bigEnemyDiePos; }

            speedsterEnemyDied = false;
            smallEnemyDied = false;
            sharpshooterDied = false;
            sniperDied = false;
            bruteDied = false;
            titanDied = false;
            ragingGinnerDies = false;
            heavyShotDied = false;

            float moveSpeed = 6f;
            float animationDuration = 0.9f; // Total animation duration

            float timer = 0.0f;
            while (timer < animationDuration)
            {
                // Move the text upwards
                pointText.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

                if (timer > 0.7f)
                {
                    // Calculate the alpha based on time
                    Color currentColor = textMesh.color;

                    // Calculate the elapsed time for fading only after 0.6 seconds
                    float fadeElapsedTime = timer - 0.5f;

                    // Calculate alpha for fading using fadeElapsedTime and fadeDuration
                    float fadeDuration = animationDuration - 0.5f;
                    currentColor.a = 1.0f - Mathf.Clamp01(fadeElapsedTime / fadeDuration);

                    if (childTransform != null)
                    {
                        Color childColor = childTransform.GetComponent<Image>().color;
                        childTransform.GetComponent<Image>().color = new Color(childColor.r, childColor.g, childColor.b, Mathf.Lerp(1f, 0f, 0.7f));
                    }

                    textMesh.color = currentColor;
                }

                timer += Time.deltaTime;
                yield return null;
            }

            ObjectPool.instance.ReturnPointTextFromPool(pointText);
        }
    }
    #endregion

    #region pointsBasicText
    IEnumerator BasicPointsText()
    {
        GameObject pointText = ObjectPool.instance.GetPointTextFromPool();
        TextMeshProUGUI textMesh = pointText.GetComponent<TextMeshProUGUI>();

        pointText.GetComponent<TextMeshProUGUI>().text = "<color=green>+" + PointsCollision.totalPointDropPoints.ToString("F0");
        pointText.transform.localScale = new Vector3(1f, 1f, 1f);

        float preferredWidth = textMesh.GetPreferredValues().x;
        textMesh.rectTransform.sizeDelta = new Vector2(preferredWidth, textMesh.rectTransform.sizeDelta.y);

        Color initialColor = textMesh.color;
        initialColor.a = 1.0f;
        textMesh.color = initialColor;

        pointText.transform.position = PointsCollision.pointsCollectPos;

        float moveSpeed = 8f;
        float animationDuration = 1.1f; // Total animation duration

        float timer = 0.0f;
        while (timer < animationDuration)
        {
            // Move the text upwards
            pointText.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            if (timer > 0.4f)
            {
                // Calculate the alpha based on time
                Color currentColor = textMesh.color;

                // Calculate the elapsed time for fading only after 0.6 seconds
                float fadeElapsedTime = timer - 0.7f;

                // Calculate alpha for fading using fadeElapsedTime and fadeDuration
                float fadeDuration = animationDuration - 0.5f;
                currentColor.a = 1.0f - Mathf.Clamp01(fadeElapsedTime / fadeDuration);

                textMesh.color = currentColor;
            }

            timer += Time.deltaTime;
            yield return null;
        }

        ObjectPool.instance.ReturnPointTextFromPool(pointText);
    }
    #endregion

    #region EnemyDamageTextPopUp
    IEnumerator EnemyDamageTextPupUp()
    {
        GameObject damageText = ObjectPool.instance.GetDamageTextFromPool();
        TextMeshProUGUI textMesh = damageText.GetComponent<TextMeshProUGUI>();
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, Mathf.Lerp(1f, 1f, 1f));

        if (SmallEnemyMovement.enemyDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.transform.localPosition = SmallEnemyMovement.enemyDamagePos;
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.GetComponent<Animation>().Play("damageTextAnim");
        }

        if (ShootingEnemyMovement.enemyDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.transform.localPosition = ShootingEnemyMovement.enemyDamagePos;
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.GetComponent<Animation>().Play("damageTextAnim");
        }

        if(BigEnemyMovement.bigEnemyDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.transform.localPosition = BigEnemyMovement.bigEnemyDamagedPos;
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.GetComponent<Animation>().Play("damageTextAnim");
        }

        if (BossMechanics.bossDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.transform.localPosition = BossMechanics.bossDamagedPos;
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (BossMechanics.bossArrowDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.transform.position = BossMechanics.bossArrowDamagedPos;
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (SmallBossShields.shieldArrowDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.gray;
            damageText.transform.position = SmallBossShields.shieldDamagedPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (SmallBossShields.shieldDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.gray;
            damageText.transform.localPosition = SmallBossShields.shieldDamagedPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        //Chamiopns
        if (Champion1Movement.champion1Damaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.localPosition = Champion1Movement.champion1DamagedPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (Champion1Movement.champion1ArrowDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.position = Champion1Movement.champion1ArrowDamagesPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (Champion2Movement.champion2Damaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.localPosition = Champion2Movement.champion2DamagedPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (Champion2Movement.champion2ArrowDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.position = Champion2Movement.champion2ArrowDamagesPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (Champion3.champion3ArrowDamaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.position = Champion3.champion3ArrowDamagesPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (Champion3.champion3Damaged == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "-" + ButtonBehiavor.damageDone.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.localPosition = Champion3.champion3DamagedPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        if (HeartBehavior.hitBigHeart == true)
        {
            damageText.GetComponent<TextMeshProUGUI>().text = "+" + Choises.bigHeartHPHeal.ToString("0");
            damageText.GetComponent<TextMeshProUGUI>().color = Color.red;
            damageText.transform.localPosition = HeartBehavior.bigHeartPos;
            damageText.GetComponent<Animation>().Play("BossDamaged");
        }

        float preferredWidth = textMesh.GetPreferredValues().x;
        textMesh.rectTransform.sizeDelta = new Vector2(preferredWidth, textMesh.rectTransform.sizeDelta.y);

        SmallEnemyMovement.enemyDamaged = false; ShootingEnemyMovement.enemyDamaged = false; BigEnemyMovement.bigEnemyDamaged = false; BossMechanics.bossDamaged = false;
        BossMechanics.bossArrowDamaged = false; SmallBossShields.shieldArrowDamaged = false; SmallBossShields.shieldDamaged = false;

        Champion1Movement.champion1Damaged = false;
        Champion1Movement.champion1ArrowDamaged = false;
        Champion2Movement.champion2Damaged = false;
        Champion2Movement.champion2ArrowDamaged = false;
        Champion3.champion3ArrowDamaged = false;
        Champion3.champion3Damaged = false;
        HeartBehavior.hitBigHeart = false;


        yield return new WaitForSeconds(1.05f);

        ObjectPool.instance.ReturnDamageTextFromPool(damageText);
    }
    #endregion
}
