using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private bool arrowStuck;
    private Transform originalParent;
    private Transform enemyParent;
    public GameObject damageManagerObject;
    public bool firstPlay;
    private DamageDealtManager damageManager;
    private Rigidbody2D rigidbodyArrow;

    public void Awake()
    {
        foundPrent = false;
        damageManagerObject = GameObject.Find("BulletDamageManager");
        rigidbodyArrow = gameObject.GetComponent<Rigidbody2D>();
        damageManager = damageManagerObject.GetComponent<DamageDealtManager>();
    }

    public bool foundPrent;
    public void OnEnable()
    {
        if (gameObject.tag == "Arrow")
        {
            gameObject.transform.localScale = new Vector2(ObjectPool.arrowSize, ObjectPool.arrowSize);

            if (gameObject.transform.parent != null)
            {
                if (gameObject.transform.parent.name != "arrowPool")
                {
                    //Debug.Log("Not arrowPool, but: " + gameObject.transform.parent.name);
                    //Debug.Log("Is Returned to pool");
                    ObjectPool.instance.ReturnArrowFromPool(gameObject);
                    gameObject.transform.SetParent(originalParent.transform);
                }
                else
                {
                    StartCoroutine(ArrowSetInactive());
                }
            }
        }
        if (gameObject.tag == "CrossbowArrow")
        {
            gameObject.transform.localScale = new Vector2(ObjectPool.boltSize, ObjectPool.boltSize);

            if (gameObject.transform.parent != null)
            {
                if (gameObject.transform.parent.name != "arrowPool")
                {
                    //Debug.Log("Not arrowPool, but: " + gameObject.transform.parent.name);
                    //Debug.Log("Is Returned to pool");
                    ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                    gameObject.transform.SetParent(originalParent.transform);
                }
                else
                {
                    StartCoroutine(ArrowSetInactive());
                }
            }
        }

        rigidbodyArrow.constraints = RigidbodyConstraints2D.None;
        arrowStuck = false;
       
        Invoke("Set", 1f);
    }

    public void Set()
    {
        firstPlay = true;

        if(foundPrent == false)
        {
            originalParent = transform.parent;
            foundPrent = true;
        }
    }

    public void OnDisable()
    {
        if(arrowStuck == true)
        {
            //Debug.Log("Off Enemy");
        }
        if(firstPlay == true)
        {
            if (gameObject.tag == "Arrow")
            {
                ObjectPool.instance.ReturnArrowFromPool(gameObject);
              
            }
            if (gameObject.tag == "CrossbowArrow")
            {
                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Small enemy
        if (other.gameObject.tag == "SmallEnemy" || other.gameObject.tag == "Speedster" || other.gameObject.tag == "Sniper" || other.gameObject.tag == "shootingEnemy" || other.gameObject.tag == "BigEnemy" || other.gameObject.tag == "Boss" || other.gameObject.tag == "SmallShield" || other.gameObject.tag == "BossBigShield" || other.gameObject.tag == "Titan" || other.gameObject.tag == "RagingGunner" || other.gameObject.tag == "HeavyShot" || other.gameObject.tag == "Champion")
        {
            SettingsOptions.totalArrowsHit += 1;

            if (Choises.maxArrowsStuck < 70)
            {
                arrowStuck = true;

                // Store the enemy parent
                enemyParent = other.transform;

                transform.SetParent(enemyParent);
                Choises.maxArrowsStuck += 1;

                if (rigidbodyArrow != null)
                {
                    //Arrow
                    if (gameObject.tag == "Arrow")
                    {
                        if (gameObject.transform.localScale.x > 0.35f)
                        {
                            if (other.gameObject.tag == "RagingGunner")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.45f)
                        {
                            if (other.gameObject.tag == "HeavyShot")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.5f)
                        {
                            if (other.gameObject.tag == "Champion")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.7f)
                        {
                            if (other.gameObject.tag == "Sniper")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.6f)
                        {
                            if (other.gameObject.tag == "shootingEnemy")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.3f)
                        {
                            if (other.gameObject.tag == "BigEnemy")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.23f)
                        {
                            if (other.gameObject.tag == "Titan")
                            {
                                ObjectPool.instance.ReturnArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 1.78f)
                        {
                            ObjectPool.instance.ReturnArrowFromPool(gameObject);
                            gameObject.transform.SetParent(originalParent.transform);
                        }
                    }


                    //Crossbow
                    if (gameObject.tag == "CrossbowArrow")
                    {
                        if (gameObject.transform.localScale.x > 0.9f)
                        {
                            if (other.gameObject.tag == "Sniper")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.4f)
                        {
                            if (other.gameObject.tag == "RagingGunner")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.35f)
                        {
                            if (other.gameObject.tag == "BigEnemy")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.55f)
                        {
                            if (other.gameObject.tag == "Champion")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.3f)
                        {
                            if (other.gameObject.tag == "Titan")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.5f)
                        {
                            if (other.gameObject.tag == "HeavyShot")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 0.7f)
                        {
                            if (other.gameObject.tag == "shootingEnemy")
                            {
                                ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                                gameObject.transform.SetParent(originalParent.transform);
                            }
                        }

                        if (gameObject.transform.localScale.x > 1.78f)
                        {
                            ObjectPool.instance.ReturnCrossbowArrowFromPool(gameObject);
                            gameObject.transform.SetParent(originalParent.transform);
                        }
                    }

                    rigidbodyArrow.velocity = Vector2.zero;
                    rigidbodyArrow.simulated = false;
                }

            }
            else 
            { 
                if(gameObject.activeInHierarchy == true) { StartCoroutine(ArrowFalse()); }
            }
        }

        if(gameObject.tag == "Arrow")
        {
            if (other.gameObject.tag == "SmallEnemy" || other.gameObject.tag == "Speedster")
            {
                ArrowDamage_SmallEnemy();
            }
            if (other.gameObject.tag == "Sniper" || other.gameObject.tag == "shootingEnemy" || other.gameObject.tag == "RagingGunner" || other.gameObject.tag == "HeavyShot")
            {
                ArrowDamage_ShootingEnemy();
            }
            if (other.gameObject.tag == "BigEnemy" || other.gameObject.tag == "Titan")
            {
                ArrowDamage_BigEnemy();
            }
        }

        if (gameObject.tag == "CrossbowArrow")
        {
            if (other.gameObject.tag == "SmallEnemy" || other.gameObject.tag == "Speedster")
            {
                //FindObjectOfType<AudioManager>().Play("CrossbowHit");
                CrossbowDamage_SmallEnemy();
            }
            if (other.gameObject.tag == "Sniper" || other.gameObject.tag == "shootingEnemy" || other.gameObject.tag == "RagingGunner" || other.gameObject.tag == "HeavyShot")
            {
                //FindObjectOfType<AudioManager>().Play("CrossbowHit");
                CrossbowDamage_ShootingEnemy();
            }
            if (other.gameObject.tag == "BigEnemy" || other.gameObject.tag == "Titan")
            {
                //FindObjectOfType<AudioManager>().Play("CrossbowHit");
                CrossbowDamage_BigEnemy();
            }
        }
    }


    #region Small arrows damage
    public void ArrowDamage_SmallEnemy()
    {
        damageManager.DamageSmallEnemy_Arrow();
    }

    public void ArrowDamage_ShootingEnemy()
    {
        damageManager.DamageShootingEemy_Arrow();
    }

    public void ArrowDamage_BigEnemy()
    {
        damageManager.DamageBigEnemy_Arrow();
    }
    #endregion

    #region Corssbow arrow damage
    public void CrossbowDamage_SmallEnemy()
    {
        damageManager.DamageSmallEnemy_Crossbow();
    }

    public void CrossbowDamage_ShootingEnemy()
    {
        damageManager.DamageShootingEemy_Crossbow();
    }

    public void CrossbowDamage_BigEnemy()
    {
        damageManager.DamageBigEnemy_Crossbow();
    }
    #endregion


    IEnumerator ArrowSetInactive()
    {
        yield return new WaitForSeconds(7);
        if(arrowStuck == false)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator ArrowFalse()
    {
        yield return new WaitForSeconds(0.05f);
        if (arrowStuck == false)
        {
            gameObject.SetActive(false);
        }
    }

}
