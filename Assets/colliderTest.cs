using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderTest : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Collider2D>();
    }
}
