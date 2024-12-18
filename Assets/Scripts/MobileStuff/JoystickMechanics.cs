using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickMechanics : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform joystickBase; 
    public RectTransform joystickHandle; 
    public Vector2 inputDirection; 
    private Vector2 joystickPosition;

    public static bool isUsingJoystick;

    private void Start()
    {
        joystickPosition = joystickBase.position; // Store the initial position
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Choises.isInLevelUpScreen == true || Choises.isInChooseEndingScreen == true)
        {
            return;
        }
        OnDrag(eventData); isUsingJoystick = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Choises.isInLevelUpScreen == true || Choises.isInChooseEndingScreen == true)
        {
            return;
        }

        isUsingJoystick = true;

        Vector2 touchPosition = eventData.position;
        Vector2 offset = touchPosition - joystickPosition;
        float radius = joystickBase.sizeDelta.x / 2.5f;

        // Clamp the handle movement within the joystick base
        inputDirection = Vector2.ClampMagnitude(offset / radius, 1f);
        joystickHandle.anchoredPosition = inputDirection * radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Choises.isInLevelUpScreen == true || Choises.isInChooseEndingScreen == true)
        {
            return;
        }

        isUsingJoystick = false;

        inputDirection = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }
}
