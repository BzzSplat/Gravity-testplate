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


    void Start() //first segment makes the planet have a random size, third segment randomizes texture
    {
        rb = GetComponentInParent<Rigidbody>();
        rb.mass = Random.Range(0.1f, 4.0f);

        cdw = GetComponentInParent<ChangeDaWorld>();
        tickMast = manager.GetComponent<TicketMaster>();

        cdw.UpdateSize(rb, this.transform.parent);
        cdw.changeTexture(Random.Range(2, 6), this.gameObject); //hopefull will change this to change biome rather than "atmosphere" texture, biomes will hold multiple textures for different planet pieces, props such as rocks and tress, and terrains such as caves and mounatins
    }


    void OnTriggerEnter(Collider otherObj)
    {
        if (!otherObj.gameObject.CompareTag("Planet")) {
            return;
        }

        Ticket ticket = new Ticket(this.transform.parent.gameObject, otherObj.transform.parent.gameObject);
        tickMast.SendTicket(ticket); //create and send collision ticket
    }

}
