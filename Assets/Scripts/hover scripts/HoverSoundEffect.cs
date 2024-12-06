using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSoundEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject soundManager;
    public AudioManager audioManager;

    private void Awake()
    {
        if (MobileScript.isMobile == true) { return; }
        soundManager = GameObject.Find("Audio");
        audioManager = soundManager.GetComponent<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (MobileScript.isMobile == true) { return; }
        audioManager.Play("hoverOther");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
