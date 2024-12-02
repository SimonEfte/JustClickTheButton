using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollision : MonoBehaviour
{
    private GameObject levelTextObject;
    public float moveSpeed;
    public static bool hitBasicPoints;
    public static Vector3 pointsCollectPos;

    public Transform uncommonIcon, rareIcon, legendaryIcon, mythicIcon;
    public Transform mainButton;

    public GameObject soundManager;

    public void Awake()
    {
        soundManager = GameObject.Find("OverlappingSounds");
        soundsScript = soundManager.GetComponent<OverlappingSounds>();

        levelTextObject = GameObject.Find("LevelText");

        mainButton = GameObject.FindWithTag("Button").transform;

        uncommonIcon = transform.Find("Point_Common");
        rareIcon = transform.Find("Point_Rare");
        legendaryIcon = transform.Find("Point_Legendary");
        mythicIcon = transform.Find("Point_Mythic");
    }


    public void OnEnable()
    {
        died = false;
        endingTransitionSetInactive = false;
        isPointCollHit = false;
        moveToButton = false;

        uncommonIcon.gameObject.SetActive(false);
        rareIcon.gameObject.SetActive(false);
        legendaryIcon.gameObject.SetActive(false);
        mythicIcon.gameObject.SetActive(false);

        int random = Random.Range(1,101);
    

        if (random <= 80) { uncommonIcon.gameObject.SetActive(true); }

        if (random > 80 && random <= 91) { rareIcon.gameObject.SetActive(true); }

        if (random > 91 && random < 98) { legendaryIcon.gameObject.SetActive(true); }

        if (random > 97) { mythicIcon.gameObject.SetActive(true); }
    }

    public static float totalPointDropPoints;
    private bool isPointCollHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointColl" && isPointCollHit == false)
        {
            isPointCollHit = true;
            //2-3, 3, 3-4, 7-8
            if (uncommonIcon.gameObject.activeInHierarchy == true) { totalPointDropPoints = (ButtonClick.pointsPerClick * Choises.pointDropBasicPoints); }

            if (rareIcon.gameObject.activeInHierarchy == true) { totalPointDropPoints = (ButtonClick.pointsPerClick * (Choises.pointDropBasicPoints + Choises.pointDropRarityIncreasePoints)); }

            if (legendaryIcon.gameObject.activeInHierarchy == true)
            { 
                totalPointDropPoints = (ButtonClick.pointsPerClick * (Choises.pointDropBasicPoints + (Choises.pointDropRarityIncreasePoints * 2))); 
            }

            if (mythicIcon.gameObject.activeInHierarchy == true)
            {
                totalPointDropPoints = (ButtonClick.pointsPerClick * (Choises.pointDropBasicPoints + (Choises.pointDropRarityIncreasePoints * 3))); 
            }

            StartCoroutine(MoveToPoint(collision.transform.position));
            //ReturnToPool();
        }
        if (collision.gameObject.tag == "Button" && moveToButton == true)
        {
            moveToButton = false;
            ReturnToPool();
        }
    }
    private IEnumerator MoveToPoint(Vector3 playerPosition)
    {
        pointsCollectPos = gameObject.transform.position;

        float moveSpeed1 = 1.1f;

        float moveBackTime = Random.Range(0.09f, 0.14f);

        Vector3 moveBackTarget = CalculateMoveBackTarget(playerPosition);
        float elapsedTime = 0f;

        while (elapsedTime < moveBackTime)
        {
            gameObject.transform.position = Vector3.Lerp(pointsCollectPos, moveBackTarget, (elapsedTime / moveBackTime) * moveSpeed1);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        moveToButton = true;

    }
    private bool moveToButton, endingTransitionSetInactive, died;

    public void Update()
    {
        if (Choises.bossChosenSetStuffInactive == true)
        {
            if (endingTransitionSetInactive == false)
            {
                StopAllCoroutines();
                ObjectPool.instance.ReturnBasicPointsFromPool(gameObject);

                endingTransitionSetInactive = true;
            }
        }

        if (moveToButton == true)
        {
            float step = 23 * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(transform.position, mainButton.position, step);
        }

        if (Choises.playerDied == true)
        {
            if (died == false)
            {
                StopAllCoroutines();
                ObjectPool.instance.ReturnBasicPointsFromPool(gameObject);
                died = true;
            }
        }
    }

    private Vector3 CalculateMoveBackTarget(Vector3 playerPosition)
    {
        Vector3 direction = (pointsCollectPos - playerPosition).normalized;
        float distance = 5.5f; 
        return pointsCollectPos + direction * distance;
    }

    private OverlappingSounds soundsScript;

    private void ReturnToPool()
    {
        soundsScript.PointDropSounds();

        Choises.maxPointDropOnScreen -= 1;
        ButtonClick.pointsGained += totalPointDropPoints;
        SettingsOptions.totalPointDropPoints += totalPointDropPoints;
        hitBasicPoints = true;
        pointsCollectPos = gameObject.transform.position;
        ObjectPool.instance.ReturnBasicPointsFromPool(gameObject);
    }

}
