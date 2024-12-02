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
        soundManager = GameObject.Find("Audio");
        audioManager = soundManager.GetComponent<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioManager.Play("hoverOther");
    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
