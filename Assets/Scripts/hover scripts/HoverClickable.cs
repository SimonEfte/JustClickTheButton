using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverClickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(MobileScript.isMobile == true) { return; }
        SetCursors.hoveringClickableStuff = true;
        Cursor.visible = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (MobileScript.isMobile == true) { return; }
        SetCursors.hoveringClickableStuff = false;
        Cursor.visible = true;
    }
}
