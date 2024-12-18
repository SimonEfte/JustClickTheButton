using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursors : MonoBehaviour
{
    public static bool hoveringClickableStuff;
    public GameObject clickableCursor, aimCursor;

    public void Update()
    {
        if(hoveringClickableStuff == true)
        {
            if(MobileScript.isMobile == false)
            {
                aimCursor.SetActive(false);
                clickableCursor.SetActive(true);
                clickableCursor.transform.position = Input.mousePosition;
            }
        }
        else
        {
            if(Choises.isInMainManu == false && SettingsOptions.isInSettings == false && Choises.isInDeathScreen == false && Choises.firstControlledGun == true && Choises.isPaused == false)
            {
                if(Cursor.visible == true) 
                { 
                    if(MobileScript.isMobile == false) { Cursor.visible = false; }
                }

                if(MobileScript.isMobile == false)
                {
                    aimCursor.SetActive(true);
                    aimCursor.transform.position = Input.mousePosition;
                }
            }
            else
            {
                if (Cursor.visible == false) 
                {
                    aimCursor.SetActive(false);
                    Cursor.visible = true;
                }
            }

            clickableCursor.SetActive(false);
        }

        if(Choises.isInDeathScreen == true) 
        {
            if (Cursor.visible == false) 
            { 
                Cursor.visible = true; 
            }

            //clickableCursor.SetActive(false);
            aimCursor.SetActive(false);
        }


        if (Choises.isInWinScreen == true)
        {
            if (Cursor.visible == false)
            {
                Cursor.visible = true;
            }

            //clickableCursor.SetActive(false);
            aimCursor.SetActive(false);
        }

    }
}
