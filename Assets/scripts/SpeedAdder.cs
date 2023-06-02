using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAdder : MonoBehaviour
{
    [SerializeField]
    Vector3 force;
    [SerializeField]
    Vector3 velocity;
    [SerializeField]
    Rigidbody rb;

    private void FixedUpdate()
    {
        //rb.AddForce(force, ForceMode.VelocityChange);
        velocity = rb.velocity;
    }
}
