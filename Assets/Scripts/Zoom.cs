using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera mainCamera;

    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;
    public float zoomSmoothness;

    public float targetZoom;

    public Transform targetToFollow;
    private Vector3 defaultCameraPosition;
    private bool isFollowingTarget = false;
    private bool setFollow;

    float switchDuration = 0.45f;
    Vector3 targetPosition;
    Coroutine lerpCoroutine;

    public static float normalZoomSize;

    public void SetHordeCamera()
    {
        if (isFollowingTarget == true)
        {
            ChangeCamera();
        }

        targetZoom = normalZoomSize + Choises.hordeStartCameraSize;
    }

    public void Start()
    {
        setFollow = false;
        switchDuration = 0.17f;

        //BossMechanics.fightingBossFight = true;
        if (BossMechanics.fightingBossFight == false)
        {
            zoomSpeed = 13f;
            minZoom = 30f;
           
            zoomSmoothness = 6f;

            normalZoomSize = 41f;
            mainCamera.orthographicSize = normalZoomSize;
            targetZoom = mainCamera.orthographicSize;
            defaultCameraPosition = mainCamera.transform.position;
        }
    }

    void Update()
    {
        maxZoom = normalZoomSize + Choises.hordeStartCameraSize + 8;

        if (Choises.isPaused == false)
        {
            if (BossMechanics.fightingBossFight == false && HordeEnding.setHordeCamera == false && DangerButtonEnding.isPlayingDangerButton == false && MimicEnding.setMimicCamera == false && Choises.isInMainManu == false)
            {
                if (Choises.choseBouncingBullets == true)
                {
                    if(Choises.movementAbilityAquaried == true)
                    {
                        if (Input.GetKeyDown(KeyCode.Tab) && MobileScript.isMobile == false)
                        {
                            if (HordeEnding.playingHordeEnding == false)
                            {
                                ChangeCamera();
                            }
                        }
                    }
                   
                    if (isFollowingTarget && setFollow == true)
                    {
                        mainCamera.transform.position = new Vector3(targetToFollow.position.x, targetToFollow.position.y, mainCamera.transform.position.z);
                    }

                    if(MobileScript.isMobile == false)
                    {
                        // Get the scroll wheel input
                        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

                        // Calculate the new target zoom level
                        targetZoom -= scrollInput * zoomSpeed;

                        // Clamp the target zoom within the min and max values
                        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);

                        // Smoothly interpolate towards the target zoom
                        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, Time.deltaTime * zoomSmoothness);
                    }
                    else
                    {
                        if(JoystickMechanics.isUsingJoystick == false)
                        {
                            //Mobile ZOOM
                            if (Input.touchCount == 2) // If there are two fingers on the screen
                            {
                                Touch touch1 = Input.GetTouch(0);
                                Touch touch2 = Input.GetTouch(1);

                                // Calculate the distance between touches in the current and previous frame
                                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

                                float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                                float currentTouchDeltaMag = (touch1.position - touch2.position).magnitude;

                                // Calculate the difference in distances between frames
                                float deltaMagnitudeDiff = prevTouchDeltaMag - currentTouchDeltaMag;

                                // Update the target zoom based on the pinch movement
                                targetZoom += deltaMagnitudeDiff * 1;

                                // Clamp the target zoom within the min and max values
                                targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
                            }

                            // Smoothly interpolate towards the target zoom
                            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, targetZoom, Time.deltaTime * 2.25f);
                        }
                    }
                }
            }
        }
    }

    public void ChangeCamera()
    {
        if (Choises.isInLevelUpScreen == true || Choises.isInChooseEndingScreen == true)
        {
            return;
        }

        isFollowingTarget = !isFollowingTarget;

        if (isFollowingTarget)
        {
            targetZoom = mainCamera.orthographicSize;
            targetPosition = new Vector3(targetToFollow.position.x, targetToFollow.position.y, mainCamera.transform.position.z);
        }
        else
        {
            targetZoom = mainCamera.orthographicSize;
            targetPosition = defaultCameraPosition;
        }

        // Stop any ongoing coroutine and start a new one for smooth transition
        if (lerpCoroutine != null)
        {
            StopCoroutine(lerpCoroutine);
        }

        lerpCoroutine = StartCoroutine(LerpCameraPosition(targetPosition, switchDuration));
    }

    IEnumerator LerpCameraPosition(Vector3 targetPosition, float duration)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = mainCamera.transform.position;

        while (elapsedTime < duration)
        {
            if (isFollowingTarget) { targetPosition = new Vector3(targetToFollow.position.x, targetToFollow.position.y, mainCamera.transform.position.z); }
            mainCamera.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if(setFollow == false) { setFollow = true; }
        else { setFollow = false; }
        mainCamera.transform.position = targetPosition;
    }
}
