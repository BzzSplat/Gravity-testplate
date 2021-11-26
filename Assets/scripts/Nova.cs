using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nova : MonoBehaviour
{
    ParticleSystem outerEffect;
    ParticleSystem innerEffect;
    public GameObject sourcePlanet;

    public float radius;
    public float power = 8000f;

    void Start()
    {
        radius = sourcePlanet.transform.localScale.y * 10;

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null && rb.gameObject != sourcePlanet)
                rb.AddExplosionForce(power, explosionPos, radius);
        }
    }
}
