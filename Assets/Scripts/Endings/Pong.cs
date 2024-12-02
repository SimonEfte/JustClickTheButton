using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pong : MonoBehaviour
{
    public GameObject pongButton;
    public bool isAI;
    public float movementSpeed;

    public Vector2 playerMove;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = pongButton.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }

    public void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    public void AIControl()
    {
        if(pongButton.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0,1);
        }
        else if (pongButton.transform.position.y < transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0, -1);
        }
        else
        {
            playerMove = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed;
    }

}
