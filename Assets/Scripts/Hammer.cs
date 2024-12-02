using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Transform particleRightPos, particleLEftPos;
    public ParticleSystem particle1, particle2;
    public GameObject particleObject;
    public Animation hammerRotate;
    public Vector2 rightPos, leftPos;
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 14)
        {
            int random = Random.Range(1,3);
            if(random == 1) { audioManager.Play("hammer1"); }
            if (random == 2) { audioManager.Play("hammer2"); }


            hammerRotate.Stop();
            particleObject.SetActive(true);

            if (MainButtonCollider.leftOrRight == true)
            {
                rightPos = collision.transform.position;
                particleObject.transform.position = rightPos;
            }
            if (MainButtonCollider.leftOrRight == false)
            {
                leftPos = collision.transform.position;
                particleObject.transform.position = leftPos;
            }
            particle1.Play();

            MainButtonCollider.setCollOff = true;
            gameObject.SetActive(false);
        }
    }

    
}
