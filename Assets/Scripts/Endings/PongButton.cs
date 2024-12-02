using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongButton : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * 600, ForceMode2D.Impulse);
        lastVelocity = rb.velocity; // Initialize lastVelocity here
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    #region Button bounce on ARENA
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(lastVelocity);

        #region Hit Arena
        if (collision.gameObject.layer == 19)
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
        #endregion
    }
    #endregion
}
