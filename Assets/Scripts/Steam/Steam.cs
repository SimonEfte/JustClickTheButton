using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour
{
    public static bool noSteamInt;
    public void Awake()
    {
        noSteamInt = false;
    }

    void Start()
    {
        if(noSteamInt == false)
        {
            try
            {
                //  Steamworks.SteamClient.Init(2577760);
            }
            catch (System.Exception e)
            {
                // Debug.Log(e);
            }
        }
    }

    private void Update()
    {
        if (noSteamInt == false)
        {
            // Steamworks.SteamClient.RunCallbacks();
        }
    }

    private void OnApplicationQuit()
    {
        if (noSteamInt == false)
        {
            //   Steamworks.SteamClient.Shutdown();
        }
    }

}
