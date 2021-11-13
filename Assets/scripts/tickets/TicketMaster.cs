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
        ticketQueue.Enqueue(ticket); //add ticket to queue and log in console
        //Debug.Log("Ticket created from " + ticket.SourcePlanet); //removed due to weird spam, might fix some day
    }

    void Update()
    {
        if (ticketQueue.Count > 0)
        {
            Ticket ticket = ticketQueue.Peek();
            if (ticket.SourcePlanet && ticket.OtherPlanet)
            {
                //Debug.Log("Kaboom? " + ticket.SourcePlanet);//log that the function ran, remvoed because it is uneeded at the moment

                ticket.SourcePlanet.GetComponent<Rigidbody>().mass += ticket.OtherPlanet.GetComponent<Rigidbody>().mass; //add masses
                ticket.SourcePlanet.GetComponent<Rigidbody>().velocity = (ticket.OtherPlanet.GetComponent<Rigidbody>().velocity + ticket.SourcePlanet.GetComponent<Rigidbody>().velocity) / ticket.SourcePlanet.GetComponent<Rigidbody>().mass; //add velocities then divide by mass
                cdw.UpdateSize(ticket.SourcePlanet.GetComponent<Rigidbody>(), ticket.SourcePlanet.GetComponent<Transform>()); //update size
                Destroy(ticket.OtherPlanet);
            }
            ticketQueue.Dequeue();
        }
    }

}
