using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedParticle : MonoBehaviour
{
    //private ParticleSystem damageEffect;
    public ParticleSystem particleSystemm;

    public void Awake()
    {
        particleSystemm = GetComponent<ParticleSystem>();
    }


    public void OnEnable()
    {
        particleSystemm.Play();
        StartCoroutine(StopEffect());
        //damageEffect.Play();
    }

    IEnumerator StopEffect()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        ObjectPool.instance.ReturnEnemyDamagedParticleFromPool(gameObject);
    }

}
