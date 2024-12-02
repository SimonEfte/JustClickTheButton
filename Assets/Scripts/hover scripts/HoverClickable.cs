using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        SetCursors.hoveringClickableStuff = true;
        Cursor.visible = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetCursors.hoveringClickableStuff = false;
        Cursor.visible = true;
    }
}
