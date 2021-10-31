using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    float mass;
    Rigidbody rb;
    ChangeDaWorld cdw;
    public GameObject manager;
    TicketMaster tickMast;


    void Start()
    {
        rb = this.GetComponentInParent< Rigidbody>();

        if (gameObject.name != "Universe Core")//core of the universe has a fixed manually set size
            rb.mass = Random.Range(0.1f, 4.0f);

        cdw = GetComponent<ChangeDaWorld>();
        tickMast = manager.GetComponent<TicketMaster>();
        cdw.UpdateSize(rb);
        cdw.randTexture(); //hopefull will change this to change biome rather than "atmosphere" texture
    }


    void OnCollisionEnter(Collision otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Planet")) {
            return;
        }
        if (otherObj.gameObject.transform.parent.name == "Universe Core" || this.gameObject.transform.parent.name == "Universe Core")//Universal core dosen't get deleted or bigger
        {
            return;
        }

        Ticket ticket = new Ticket(this.gameObject, otherObj.gameObject);
        tickMast.SendTicket(ticket); //create and send collision ticket, then update size after it has been done
        cdw.UpdateSize(rb);
    }

}
