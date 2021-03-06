using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMaster : MonoBehaviour
{
    public TicketMaster instance;
    Queue<Ticket> ticketQueue = new Queue<Ticket>();
    ChangeDaWorld cdw;

    private void Start()
    {
        cdw = this.GetComponent<ChangeDaWorld>();

        if (instance) //alert if there is another ticketmaster, which there shouldn't be
            Debug.Log("Another ticket master exists");
        instance = this;
    }

    public void SendTicket(Ticket ticket)
    {
        ticketQueue.Enqueue(ticket); //add ticket to queue
        //Debug.Log("Ticket created from " + ticket.SourcePlanet); //spam? extra tickets made, fine but might need fixing
    }

    void Update()
    {
        if (ticketQueue.Count > 0)
        {
            Ticket ticket = ticketQueue.Peek();
            if (ticket.SourcePlanet && ticket.OtherPlanet)
            {
                //Debug.Log("Kaboom? " + ticket.SourcePlanet);

                if (ticket.SourcePlanet.GetComponent<Rigidbody>().mass > ticket.OtherPlanet.GetComponent<Rigidbody>().mass)
                {
                    Rigidbody rb = ticket.SourcePlanet.GetComponent<Rigidbody>(), rbOther = ticket.OtherPlanet.GetComponent<Rigidbody>();
                    rb.mass += rbOther.mass; //add masses
                    rb.velocity = (rb.velocity + rbOther.velocity) / rb.mass; //add velocities then divide by mass
                    cdw.UpdateSize(rb, ticket.SourcePlanet.GetComponent<Transform>()); //update size
                    StartCoroutine("check", ticket.OtherPlanet);
                }
            }
            ticketQueue.Dequeue();
        }
    }

    IEnumerator check(GameObject planet)
    {
        Destroy(planet);
        yield return new WaitForSeconds(0.1f);
        GetComponent<GameManager>().checkPlanets();
    }

}
