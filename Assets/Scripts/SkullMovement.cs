using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMovement : MonoBehaviour
{
    private Transform buttonTransform;
    public float speed;
    public GameObject button;

    public MainButtonCollider mainButtonScript;
    public GameObject mainButton;

    public void Awake()
    {
        mainButton = GameObject.Find("MainButtonCollider");
        mainButtonScript = mainButton.GetComponent<MainButtonCollider>();

        speed = 60f;
        button = GameObject.FindWithTag("Button");
    }


    private void OnEnable()
    {
        if (button != null)
        {
            // Get the transform of the button
            buttonTransform = button.transform;
        }
        else
        {
            //Debug.LogError("Button not found with the specified tag!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "MainButton")
        {
            mainButtonScript.SkullHarvestBuff();
            ObjectPool.instance.ReturnSkullsFromPool(gameObject);
        }
    }

    private void Update()
    {
        // Move towards the button
        if (buttonTransform != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, buttonTransform.position, step);
        }
    }
}
