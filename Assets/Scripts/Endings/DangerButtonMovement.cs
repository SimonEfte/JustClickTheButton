using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerButtonMovement : MonoBehaviour
{
    Vector3 lastVelocity;
    private Rigidbody2D rb;
    public float speed;
    public static float dangerButtonDamage, dangerButtonBulletDamage;
    public AudioManager audioManager;

    public void OnEnable()
    {
        gameObject.transform.localPosition = new Vector2(0, 400);
        gameObject.transform.localScale = new Vector2(1, 1);

        dangerButtonDeath = false;
        startshooting = false;
        StartCoroutine(StartShooting());
        rb = GetComponent<Rigidbody2D>();

        int random = Random.Range(1,5);
        if(random == 1) { StartCoroutine(StartMovemement(42)); }
        if (random == 2) { StartCoroutine(StartMovemement(-42)); }
        if (random == 3) { StartCoroutine(StartMovemement(142)); }
        if (random == 4) { StartCoroutine(StartMovemement(-142)); }
    }

    IEnumerator StartMovemement(float targetAngle)
    {
        yield return new WaitForSeconds(2.3f);
        gameObject.transform.localScale = new Vector2(1, 1);

        // Use the specified angle instead of generating a random one
        Quaternion rotation = Quaternion.Euler(0, 0, targetAngle);

        rb = gameObject.GetComponent<Rigidbody2D>();

        // Convert the angle to a direction vector
        Vector2 direction = new Vector2(Mathf.Cos(targetAngle * Mathf.Deg2Rad), Mathf.Sin(targetAngle * Mathf.Deg2Rad));

        rb.linearVelocity = direction * speed;
        yield return new WaitForSeconds(1f);
        StartCoroutine(IncreaseSize());
    }

    IEnumerator IncreaseSize()
    {
        Vector2 StartScale = new Vector2(1, 1);
        Vector2 endScale = new Vector2(5f, 5f);

        float duration = 100f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            gameObject.transform.localScale = Vector2.Lerp(StartScale, endScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localScale = endScale;
    }

    public int bulletShot;
    public bool startshooting;
    public float bulletSize;
    public float bulletSpeed;

    IEnumerator StartShooting()
    {
        dangerButtonBulletDamage = 8;
        dangerButtonDamage = 5;
        yield return new WaitForSeconds(10);
        startshooting = true;
        bulletShot = 3;
        bulletSize = 0.5f;
        bulletSpeed = 55f;

        yield return new WaitForSeconds(10);
        bulletShot = 4;
        bulletSize = 0.65f;
        bulletSpeed = 6f;
        dangerButtonDamage = 8;
        dangerButtonBulletDamage = 12;

        yield return new WaitForSeconds(10);
        bulletShot = 5;
        bulletSize = 0.75f;
        bulletSpeed = 65f;
        dangerButtonDamage = 12;
        dangerButtonBulletDamage = 14;

        yield return new WaitForSeconds(10);
        bulletShot = 6;
        bulletSize = 0.8f;
        bulletSpeed = 75f;
        dangerButtonDamage = 15;
        dangerButtonBulletDamage = 16;

        yield return new WaitForSeconds(10);
        bulletShot = 7;
        bulletSize = 0.9f;
        bulletSpeed = 85f;
        dangerButtonDamage = 18;
        dangerButtonBulletDamage = 18;

        yield return new WaitForSeconds(10);
        bulletShot = 9;
        bulletSize = 1f;
        bulletSpeed = 100f;
        dangerButtonDamage = 22;
        dangerButtonBulletDamage = 25;

        yield return new WaitForSeconds(10);
        bulletShot = 10;
        bulletSize = 1.15f;
        bulletSpeed = 110f;
        dangerButtonDamage = 25;
        dangerButtonBulletDamage = 30;

        yield return new WaitForSeconds(10);
        bulletShot = 13;
        bulletSize = 0.7f;
        bulletSpeed = 117f;
        dangerButtonDamage = 30;
        dangerButtonBulletDamage = 20;

        yield return new WaitForSeconds(10);
        bulletShot = 15;
        bulletSize = 0.5f;
        bulletSpeed = 120f;
        dangerButtonDamage = 32;
        dangerButtonBulletDamage = 15;

        yield return new WaitForSeconds(10);
        bulletShot = 22;
        bulletSize = 0.3f;
        bulletSpeed = 150f;
        dangerButtonDamage = 33;
        dangerButtonBulletDamage = 15;
    }

    public bool dangerButtonDeath;
    public void Update()
    {
        lastVelocity = rb.linearVelocity;

        if (Choises.didPlayerDie == true && dangerButtonDeath == false)
        {
            StopAllCoroutines();
            SetInactive();
            dangerButtonDeath = true;
        }
    }

    public float speedIncrease;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arena")
        {
            if(gameObject.transform.localScale.x < 2)
            {
                int randomSmall = Random.Range(1,3);
                if (randomSmall == 1) { audioManager.Play("dangerBounceSmall1"); }
                if (randomSmall == 2) { audioManager.Play("dangerBounceSmall2"); }
            }

            if (gameObject.transform.localScale.x < 3.5f && gameObject.transform.localScale.x > 2f)
            {
                int randomMedium = Random.Range(1, 4);
                if (randomMedium == 1) { audioManager.Play("dangerBounceMedium1"); }
                if (randomMedium == 2) { audioManager.Play("dangerBounceMedium2"); }
                if (randomMedium == 3) { audioManager.Play("dangerBounceMedium3"); }
            }

            if (gameObject.transform.localScale.x > 3.5f)
            {
                int randomBig = Random.Range(1, 3);
                if (randomBig == 1) { audioManager.Play("dangerBounceBig1"); }
                if (randomBig == 2) { audioManager.Play("dangerBounceBig2"); }
            }

            var speed = lastVelocity.magnitude;
            if(speed < 50) { speed += 2.5f; }
            if (speed < 70) { speed += 1.5f; }
            if (speed < 85) { speed += 0.8f; }
            if (speed < 100) { speed += 0.45f; }

            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.linearVelocity = direction * Mathf.Max(speed, 0);
            //Debug.Log(rb.velocity);
        }

        if (collision.gameObject.tag == "Arena")
        {
            if (startshooting == true)
            {
                //Debug.Log("Shoot");
                StartCoroutine(ShootLotsOfBullets());
            }
        }
    }


    IEnumerator ShootLotsOfBullets()
    {
        int numberOfBullets = bulletShot;
        float angleIncrement = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject enemybullet = ObjectPool.instance.GetSmallEnemyBulletFromPool();
            enemybullet.tag = "DangerButtonBullets";
            enemybullet.transform.position = gameObject.transform.position;
            enemybullet.transform.localScale = new Vector3(bulletSize, bulletSize, bulletSize);

            float angle = i * angleIncrement;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up; // Convert angle to direction

            Rigidbody2D rb = enemybullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * 75f;
            yield return new WaitForSeconds(0);
        }
    }

    public void SetInactive()
    {
        StartCoroutine(DecreaseSize());
    }

    IEnumerator DecreaseSize()
    {
        Vector2 StartScale = gameObject.transform.localScale;
        Vector2 endScale = new Vector2(0f, 0f);

        float duration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            gameObject.transform.localScale = Vector2.Lerp(StartScale, endScale, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.transform.localScale = endScale;
        gameObject.SetActive(false);
    }
}
