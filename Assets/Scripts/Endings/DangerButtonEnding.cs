using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DangerButtonEnding : MonoBehaviour
{
    public static bool isPlayingDangerButton;
    public TextMeshProUGUI dangerButtonTimerText, waveText;
    public float dangerTimer;
    public Slider dangerButtonSlider;
    public Choises choisesScript;
    public DangerButtonMovement dangerButtonMovementScript;
    public GameObject topLeftHealthbar;

    public void StartDangerButton()
    {
        isTickingSound = false;
        if (SettingsOptions.healthbarPosition == 1)
        {
            topLeftHealthbar.SetActive(true);
        }

        dangerButtonDeath = false;
        StartCoroutine(StartDangerButtonEnding());
        isPlayingDangerButton = true;

        dangerTimer = 120;

        dangerButtonSlider.maxValue = dangerTimer;
        dangerButtonSlider.value = dangerTimer;
        dangerButtonSlider.minValue = 0;
        dangerButtonTimerText.text = dangerButtonSlider.value.ToString("F2");
    }

    IEnumerator StartDangerButtonEnding()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        waveText.gameObject.SetActive(true);
        waveText.color = Color.red;
        waveText.text = "START DODGING!";
        waveText.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
        yield return new WaitForSecondsRealtime(1.1f);
        waveText.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.1f);
        waveText.gameObject.SetActive(true);
        waveText.text = "GO!";
        waveText.gameObject.GetComponent<Animator>().SetTrigger("TextAnim");
        yield return new WaitForSecondsRealtime(1.1f);

       
        StartCoroutine(DangerButtonTimer());
        waveText.gameObject.SetActive(false);
        //Debug.Log(MainButtonCollider.buttonMoveSpeed);
    }

    public AudioManager audioManager;
    public bool isTickingSound;

    IEnumerator DangerButtonTimer()
    {
        float startTime = Time.time;
        float endValue = 0f;
        float startValue = dangerTimer;

        while (Time.time - startTime < dangerTimer)
        {
            float t = (Time.time - startTime) / dangerTimer;
            dangerButtonSlider.value = Mathf.Lerp(startValue, endValue, t);

            if(dangerButtonSlider.value < 2 && isTickingSound == false)
            {
                audioManager.Play("dangerTicking");
                isTickingSound = true;
            }

            dangerButtonTimerText.text = dangerButtonSlider.value.ToString("F2");
            yield return null;
        }

        dangerButtonSlider.value = endValue;
        dangerButtonTimerText.text = "0:00";
        choisesScript.DangerButtonWin();
        SettingsOptions.runsCompleted += 1;
        SettingsOptions.timesDefeatedDangerButton += 1;
        if(SettingsOptions.firstTimeDefeatedDangerButton == false)
        {
            SettingsOptions.endingsCompleted += 1;
            SettingsOptions.firstTimeDefeatedDangerButton = true;
        }
        dangerButtonMovementScript.SetInactive();
    }


    public bool dangerButtonDeath;
    void Update()
    {
        if(Choises.didPlayerDie == true && dangerButtonDeath == false) 
        {
            StopAllCoroutines();
            dangerButtonDeath = true;
        }
    }
}
