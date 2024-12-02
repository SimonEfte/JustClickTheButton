using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGlove : MonoBehaviour
{
    public Vector2 boxingGloveStartPos;
    public Rigidbody2D boxingRB;
    public AudioManager audioManager;
    public Transform mainButton;

    void Start()
    {
        boxingGloveStartPos = mainButton.transform.position;
        boxingRB = GetComponent<Rigidbody2D>();
    }

    public bool hitEnemy;
    public Coroutine hitEnemyCoroutine;

    public void OnEnable()
    {
        hitEnemyCoroutine = StartCoroutine(SetBackGlove());
        gameObject.transform.position = mainButton.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.tag == "Arena")
        {
            int random = Random.Range(1,3);
            if(random == 1) { audioManager.Play("Punch1"); }
            if (random == 2) { audioManager.Play("Punch2"); }
            //gameObject.transform.position = mainButton.transform.position;

            boxingRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            boxingRB.constraints = RigidbodyConstraints2D.FreezeRotation;

            hitEnemy = true;
            if(hitEnemyCoroutine != null) { StopCoroutine(hitEnemyCoroutine); hitEnemyCoroutine = null; }
            StartCoroutine(SetBackContraints());
        }

        if (collision.gameObject.layer == 7)
        {
            int random = Random.Range(1, 3);
            if (random == 1) { audioManager.Play("Punch1"); }
            if (random == 2) { audioManager.Play("Punch2"); }
        }
    }

    IEnumerator SetBackContraints()
    {
        yield return new WaitForSeconds(0.05f);
        boxingRB.constraints = RigidbodyConstraints2D.None;
        MainButtonCollider.boxingGloveCoroutine = null;
        if(hitEnemyCoroutine != null) { StopCoroutine(hitEnemyCoroutine); hitEnemyCoroutine = null; }
        hitEnemyCoroutine = null;
        gameObject.SetActive(false);
    }

    IEnumerator SetBackGlove()
    {
        yield return new WaitForSeconds(1.5f);
        boxingRB.constraints = RigidbodyConstraints2D.None;
        MainButtonCollider.boxingGloveCoroutine = null;
        hitEnemyCoroutine = null;
        gameObject.SetActive(false);
    }

}
