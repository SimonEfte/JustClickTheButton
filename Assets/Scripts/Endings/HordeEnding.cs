using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HordeEnding : MonoBehaviour
{
    public TextMeshProUGUI waveText;
    public static bool playingHordeEnding, setHordeCamera;
    public static bool hordeSpawnSmallEnemy, hordeSpawnSpeedster, hordeSpawnRagingGunner, hordeSpawnTitan, hordeSpawnBrute;
    public float hordeTimer;

    public float smallEnemySpawnTime1, speedsterTime1, bruteTimer, gunnerTimer, titanTimer;
    public float smallIncrement, speedsterIncrement, bruteIncrement, gunnerIncrement, titanIncrement;

    public bool haveEndingStarted;

    public Slider hordeWaveSlider;

    public Camera mainCamera;
    public bool checkEnding;
    public GameObject mainButton;

    public void Awake()
    {
        playingHordeEnding = false;
        if (playingHordeEnding == true)
        {
            hordeSpawnSmallEnemy = true;
            hordeSpawnSpeedster = true;
            hordeSpawnRagingGunner = true;
            hordeSpawnTitan = true;
            hordeSpawnBrute = true;
            
            hordeWaveSlider.minValue = 0;
            hordeWaveSlider.maxValue = hordeTimer;
            hordeWaveSlider.value = hordeTimer;
        }
    }

    #region Horde Countdown
    public bool startWave2, startWave3;
    IEnumerator StartHordeCountdown()
    {
        float startTime = Time.time;
        float endValue = 0f;
        float startValue = hordeTimer;

        while (Time.time - startTime < hordeTimer)
        {
            float t = (Time.time - startTime) / hordeTimer;
            hordeWaveSlider.value = Mathf.Lerp(startValue, endValue, t);
            if (hordeWaveSlider.value < (hordeTimer / 2) && startWave2 == false)
            {
                StartCoroutine(SecondWave());
                startWave2 = true;
            }
            if (hordeWaveSlider.value < 2 && startWave3 == false)
            {
                StartCoroutine(ThirdWave());
                startWave3 = true;
            }

            yield return null;
        }

        hordeWaveSlider.value = endValue;
    }
    #endregion

    public void StartHordeEnding()
    {
        mainButton.transform.localPosition = new Vector2(0,-36f);

        checkEnding = true;
        startWave2 = false;
        startWave3 = false;
        playerDied = true;
        StartCoroutine(FirstWave());
        playingHordeEnding = true;
        hordeSpawnSmallEnemy = true;
        hordeSpawnSpeedster = true;
        hordeSpawnRagingGunner = true;
        hordeSpawnTitan = true;
        hordeSpawnBrute = true;
        
        Choises.choseHealthBar = true;
        Choises.smallEnemySpawn = true;
        Choises.speedsterSpawn = true;
        Choises.bigEnemySpawn = true;
        Choises.titanSpawn = true;
        Choises.ragingGunnerSpawn = true;

        hordeTimer = 86;
        hordeWaveSlider.minValue = 0;
        hordeWaveSlider.maxValue = hordeTimer;
        hordeWaveSlider.value = hordeTimer;
    }

    #region First Wave
    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnEnemies.smallEnemyCount = 0;
        SpawnEnemies.speedsterCount = 0;
        SpawnShootingEnemy.shootingEnemyCount = 0;
        SpawnShootingEnemy.sniperCount = 0;
        SpawnShootingEnemy.heavyShotCount = 0;
        SpawnShootingEnemy.ragingGunnerCount = 0;
        SpawnBigEnemy.bigEnemyCount = 0;
        SpawnBigEnemy.titanCount = 0;

        waveText.gameObject.SetActive(true);
        waveText.color = Color.red;
        waveText.text = "WAVE 1\nINCOMING!";
        waveText.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
        StartCoroutine(StartHordeCountdown());
        yield return new WaitForSeconds(1f);
        waveText.gameObject.SetActive(false);

        Choises.maxAssasins = 250;
        Choises.maxSpeedsters = 250;

        smallIncrement = 0.14f;
        smallEnemySpawnTime1 = 28f;
        StartCoroutine(SpawnMultipleSmallEnemmies());

        speedsterIncrement = 0.17f;
        speedsterTime1 = 28f;
        StartCoroutine(SpawnMultipleSpeedsters());

        yield return new WaitForSeconds(5);
        haveEndingStarted = true;

        yield return new WaitForSeconds(hordeTimer + 5);
        checkEnding = false;
    }
    #endregion

    #region second wave
    IEnumerator SecondWave()
    {
        yield return new WaitForSeconds(0.4f);
        waveText.gameObject.SetActive(true);
        waveText.text = "WAVE 2\nINCOMING!";
        waveText.color = Color.red;
        waveText.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
        yield return new WaitForSeconds(1f);
        waveText.gameObject.SetActive(false);

        Choises.maxAssasins = 100;
        Choises.maxSpeedsters = 100;
        Choises.maxRagingGunners = 100;
        Choises.maxBrutes = 100;

        smallIncrement = 0.4f;
        smallEnemySpawnTime1 = 20f;
        StartCoroutine(SpawnMultipleSmallEnemmies());

        speedsterIncrement = 0.4f;
        speedsterTime1 = 20f;
        StartCoroutine(SpawnMultipleSpeedsters());

        gunnerIncrement = 0.95f;
        gunnerTimer = 20;
        StartCoroutine(SpawnGunners());

        bruteIncrement = 0.55f;
        bruteTimer = 20;
        StartCoroutine(SpawnBrutes());
    }
    #endregion

    #region Third wave
    IEnumerator ThirdWave()
    {
        yield return new WaitForSeconds(0.4f);
        waveText.gameObject.SetActive(true);
        waveText.text = "WAVE 3\nINCOMING!";
        waveText.color = Color.red;
        waveText.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
        yield return new WaitForSeconds(1f);
        waveText.gameObject.SetActive(false);

        Choises.maxAssasins = 100;
        Choises.maxSpeedsters = 100;
        Choises.maxRagingGunners = 100;
        Choises.maxTitans = 100;
        Choises.maxBrutes = 100;

        smallIncrement = 0.4f;
        smallEnemySpawnTime1 = 16f;
        StartCoroutine(SpawnMultipleSmallEnemmies());

        speedsterIncrement = 0.4f;
        speedsterTime1 = 16f;
        StartCoroutine(SpawnMultipleSpeedsters());

        bruteIncrement = 0.35f;
        bruteTimer = 16f;
        StartCoroutine(SpawnBrutes());

        gunnerIncrement = 1f;
        gunnerTimer = 16f;
        StartCoroutine(SpawnGunners());

        titanIncrement = 0.85f;
        titanTimer = 16;
        StartCoroutine(SpawnTitans());
    }
    #endregion
    public int count;

    #region Spawn Small Enemies
    IEnumerator SpawnMultipleSmallEnemmies()
    {
        float elapsedTime = 0f;
        yield return new WaitForSeconds(0.2f);

        while (elapsedTime < smallEnemySpawnTime1)
        {
            count += 1;
            //Debug.Log(count);
            smallEnemySpawnTime1 -= smallIncrement;
            yield return new WaitForSeconds(smallIncrement);
            hordeSpawnSmallEnemy = false;
            SpawnEnemies.spawnSmallEnemy = true;

            elapsedTime += Time.deltaTime;
        }

        hordeSpawnSmallEnemy = true;
    }
    #endregion

    #region Spawn speedsters
    IEnumerator SpawnMultipleSpeedsters()
    {
        yield return new WaitForSeconds(0.3f);
        float elapsedTime = 0f;

        while (elapsedTime < speedsterTime1)
        {
            //Debug.Log("Speedsterspawn");
            speedsterTime1 -= speedsterIncrement;
            yield return new WaitForSeconds(speedsterIncrement);
            hordeSpawnSpeedster = false;
            SpawnEnemies.spawnSpeedster = true;

            elapsedTime += Time.deltaTime;
        }

        hordeSpawnSpeedster = true;
    }
    #endregion

    #region Spawn brutes
    IEnumerator SpawnBrutes()
    {
        yield return new WaitForSeconds(0.1f);
        float elapsedTime = 0f;

        while (elapsedTime < bruteTimer)
        {
            bruteTimer -= bruteIncrement;
            yield return new WaitForSeconds(bruteIncrement);
            hordeSpawnBrute = false;
            SpawnBigEnemy.spawnBigEnemy = true;

            elapsedTime += Time.deltaTime;
        }

        hordeSpawnBrute = true;
    }
    #endregion

    #region Spawn raging gunner
    IEnumerator SpawnGunners()
    {
        yield return new WaitForSeconds(0.2f);
        float elapsedTime = 0f;

        while (elapsedTime < gunnerTimer)
        {
            gunnerTimer -= gunnerIncrement;
            yield return new WaitForSeconds(gunnerIncrement);
            hordeSpawnRagingGunner = false;
            SpawnShootingEnemy.spawnRagingGunner = true;

            elapsedTime += Time.deltaTime;
        }

        hordeSpawnRagingGunner = true;
    }
    #endregion

    #region Spawn Titan
    IEnumerator SpawnTitans()
    {
        yield return new WaitForSeconds(0.1f);
        float elapsedTime = 0f;

        while (elapsedTime < titanTimer)
        {
            titanTimer -= titanIncrement;
            yield return new WaitForSeconds(titanIncrement);
            hordeSpawnTitan = false;
            SpawnBigEnemy.spawnTitan = true;

            elapsedTime += Time.deltaTime;
        }

        hordeSpawnTitan = true;
    }
    #endregion

    public bool playerDied;
    void Update()
    {
        if (Choises.didPlayerDie == true && playerDied == true)
        {
            playerDied = false;
            haveEndingStarted = false;
            StopAllCoroutines();
        }

        if (haveEndingStarted == true)
        {
            if (SpawnEnemies.smallEnemyCount <= 0 && SpawnEnemies.speedsterCount <= 0 && SpawnShootingEnemy.ragingGunnerCount <= 0 && SpawnBigEnemy.bigEnemyCount <= 0 && SpawnBigEnemy.titanCount <= 0 && checkEnding == false)
            {
                StartCoroutine(BeatHorde());
                SettingsOptions.runsCompleted += 1;
                SettingsOptions.timesDefeatedHorde += 1;
                if (SettingsOptions.firstTimeDefeatedHorde == false)
                {
                    SettingsOptions.endingsCompleted += 1;
                    SettingsOptions.firstTimeDefeatedHorde = true;
                }
                haveEndingStarted = false;
            }
        }
    }

    public Choises choisesScript;
    public SettingsOptions settingScript;
    public GameObject winScreen;
    public string winTimer;
    public TextMeshProUGUI completedEndingText, finishedAtLevelText, finishedInText;
    public AudioManager audioManager;
    public ButtonClick buttonClickScript;
    public MainButtonCollider mainButtonColliderScript;
    public DataPersistanceManager dataScript;
    public ButtonBehiavor buttonBehaviorScript;

    IEnumerator BeatHorde()
    {
        Choises.choseContunieRun = false;
        buttonBehaviorScript.ResetCharge();

        if (ButtonBehiavor.chargeSoundPlaying == true)
        {
            ButtonBehiavor.chargeSoundPlaying = false;
            audioManager.Stop("charge1");
        }

        if (ButtonClick.level == 75 && Choises.beatlEndingAtLevel75 == false)
        {
            Choises.beatlEndingAtLevel75 = true;
        }

        Choises.numberOfGunsCurrentRun = 0;
        Choises.numberOfMeleeCurrentRun = 0;

        mainButtonColliderScript.ResetInvin();
        buttonClickScript.StopStopTime();
        audioManager.Stop("HordeMusic");
        audioManager.Play("Win");

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes == 0) { winTimer = $"00:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 0 && SettingsOptions.timeMinutes < 10) { winTimer = $"0{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        if (SettingsOptions.currentTime < 10 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:0{SettingsOptions.currentTime.ToString("F0")}"; }
        if (SettingsOptions.currentTime > 9 && SettingsOptions.timeMinutes > 9) { winTimer = $"{SettingsOptions.timeMinutes.ToString("F0")}:{SettingsOptions.currentTime.ToString("F0")}"; }

        choisesScript.CheckFastestRunTime();

        completedEndingText.text = "Completed Ending #2 - Horde";
        finishedAtLevelText.text = "Finished at level " + ButtonClick.level;
        finishedInText.text = "Time finished: " + winTimer;

        choisesScript.SetOriginalChances();
        choisesScript.ResetAllGameObject(true);
        settingScript.ResetGame(false);

        Choises.isInWinScreen = true;
        waveText.gameObject.SetActive(true);
        waveText.color = Color.green;
        waveText.text = "WIN!";
        waveText.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
        waveText.gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(0.25f);
        buttonBehaviorScript.ResetCharge();
        mainButtonColliderScript.ResetInvin();
        yield return new WaitForSecondsRealtime(0.75f);

        hordeSpawnSmallEnemy = false;
        hordeSpawnSpeedster = false;
        hordeSpawnTitan = false;
        hordeSpawnBrute = false;
        hordeSpawnRagingGunner = false;

        winScreen.SetActive(true);
        winScreen.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSecondsRealtime(1);
        Choises.isInChooseEndingScreen = false;

        Choises.endingBlockAutoSave = false;

        Choises.noHoverGlow = false;
        HoverUpgrades.endingTransitionPlaying = false;
        dataScript.SaveTheGameData();
    }

}
