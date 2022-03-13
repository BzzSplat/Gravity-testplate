using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nova : MonoBehaviour //maybe no explosion, it laggs hard
{
    ParticleSystem outerEffect;
    ParticleSystem innerEffect;
    public GameObject sourcePlanet;
    public float time;

    public float radius = 300;
    public float power = 120000f;

    void Start()
    {
        /*Collider[] colliders = Physics.OverlapSphere(transform.position, radius); //the overlap sphere can't detect triggers
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponentInParent<Rigidbody>();

            if (rb && rb.gameObject != sourcePlanet)
                rb.AddExplosionForce(power, transform.position, radius);
        }*/

        Destroy(this.gameObject, time);
    }
}
