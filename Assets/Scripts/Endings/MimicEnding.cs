using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MimicEnding : MonoBehaviour
{
    public static bool isPlayingMimicEnding, setMimicCamera;
    public GameObject champion1Stab, champion2Armored, chamipn3Ranged;
    public GameObject sawBlades, sawBlade1, sawBlade2, sawBlade3, sawBlade4, sawBlade5, sawBlade6, sawBlade7, sawBlade8;
    public static bool isPlayingChamptions;
    public float sawBladeSpeed, sawBladeShootSpeed;

    public static int championsKilled;
    public static bool isChampionsDefeated;
    public static float champion3HP;
    public Choises choisesScript;

    void Start()
    {
        win = false;
        sawBladeSpeed = 120;
    }

    public void StartChampionEnding()
    {
        StartCoroutine(TextAnim());
        StartCoroutine(ShootSawBlades());
        isPlayingChamptions = true;
        isChampionsDefeated = false;
    }

    public static bool win;
    public static bool died;

    void Update()
    {
        if (Choises.didPlayerDie == true && died == false)
        {
            died = true;
            StopAllCoroutines();
        }

        if (isPlayingChamptions == true)
        { 
            sawBlades.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);

            sawBlade1.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade2.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade3.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade4.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade5.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade6.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade7.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
            sawBlade8.transform.Rotate(Vector3.forward * -sawBladeSpeed * Time.deltaTime);
        }

        if(championsKilled == 3 && win == false)
        {
            win = true;
            SettingsOptions.runsCompleted += 1;
            SettingsOptions.timesDefeatedChampions += 1;
            if (SettingsOptions.firstTimeDefeatedChampions == false)
            {
                SettingsOptions.endingsCompleted += 1;
                SettingsOptions.firstTimeDefeatedChampions = true;
            }
            choisesScript.ChampionWin();
        }
    }

    IEnumerator ShootSawBlades()
    {
        yield return new WaitForSeconds(2);

        while (!isChampionsDefeated)
        {
            float shootInterval = 0f;

            if (championsKilled == 0)
            {
                sawBladeShootSpeed = 80f;
                shootInterval = 0.2f;
            }
            else if (championsKilled == 1)
            {
                sawBladeShootSpeed = 100f;
                shootInterval = 0.08f;
            }
            else if (championsKilled == 2)
            {
                sawBladeShootSpeed = 145f;
                shootInterval = 0.026f;
            }

            yield return new WaitForSeconds(shootInterval);

            int randomBladeIndex = Random.Range(1, 5);
            GameObject sawBlade = ObjectPool.instance.GetEnemySawBladeFromPool();

            Vector3 shootDirection = Vector3.up;

            // Set shoot direction based on the randomBladeIndex
            switch (randomBladeIndex)
            {
                case 1:
                    shootDirection = Vector3.up;
                    break;
                case 2:
                    shootDirection = Vector3.down;
                    break;
                case 3:
                    shootDirection = Vector3.left;
                    break;
                case 4:
                    shootDirection = Vector3.right;
                    break;
            }

            // Apply the rotation of the sawBlades to the shoot direction
            shootDirection = sawBlades.transform.rotation * shootDirection;

            // Set the starting position of the sawBlade based on the randomBladeIndex
            Vector3 startPosition = Vector3.zero;

            switch (randomBladeIndex)
            {
                case 1:
                    startPosition = sawBlade1.transform.position;
                    break;
                case 2:
                    startPosition = sawBlade2.transform.position;
                    break;
                case 3:
                    startPosition = sawBlade3.transform.position;
                    break;
                case 4:
                    startPosition = sawBlade4.transform.position;
                    break;
            }

            // Instantiate and shoot the sawBlade
            sawBlade.transform.position = startPosition;
            sawBlade.GetComponent<Rigidbody2D>().linearVelocity = shootDirection * sawBladeShootSpeed;
        }
    }

    #region Text Anim
    public TextMeshProUGUI textAnim;
    IEnumerator TextAnim()
    {
        textAnim.gameObject.SetActive(true);
        textAnim.color = Color.green;
        textAnim.text = "3 VERSUS 1";
        textAnim.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
     
        yield return new WaitForSecondsRealtime(1.4f);
        textAnim.text = "FIGHT!";
        textAnim.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");

        yield return new WaitForSecondsRealtime(1f);
        textAnim.gameObject.SetActive(false);
        championsKilled = 0;
    }
    #endregion

}
