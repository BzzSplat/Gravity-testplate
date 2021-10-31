using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public const float G = 1f; //norm would be 667.4 but real is 6.674
    public Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Planet"))
        {
            return;
        }

        Attractor otherAttractor = other.gameObject.GetComponent<Attractor>();
        if(otherAttractor)
            Attract(otherAttractor);

    }


    void Attract(Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;  //store variable of other object to attract

        Vector3 direction = rb.position - rbToAttract.position; //get direction of other object
        float distance = direction.magnitude;

        if (distance == 0f)
            return;

        float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;  //create force in direction of object with the strength defined above

        rbToAttract.AddForce(force);   //apply the created force


        //create new force type that at distance has gravity acts normal but at closer distances the objects are pushed away
    }

}
