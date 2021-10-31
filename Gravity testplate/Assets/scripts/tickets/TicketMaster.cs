using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketMaster : MonoBehaviour
{
    public TicketMaster instance;
    Queue<Ticket> ticketQueue = new Queue<Ticket>();

    private void Start()
    {
        if (instance)
            Debug.Log("Another ticket master exists");
        instance = this;
    }

    public void SendTicket(Ticket ticket)
    {
        ticketQueue.Enqueue(ticket); //Dequeue to remove, ticketQueue.Peek to get what's there
        Debug.Log("Ticket created from " + ticket.SourcePlanet);
    }

    void Update()
    {
        if (ticketQueue.Count > 0)
        {
            Ticket ticket = ticketQueue.Peek();
            if (ticket.SourcePlanet && ticket.OtherPlanet)
            {
                Debug.Log("Kaboom? " + ticket.SourcePlanet);//log that the function ran

                ticket.SourcePlanet.GetComponent<Rigidbody>().mass += ticket.OtherPlanet.GetComponent<Rigidbody>().mass;
                Destroy(ticket.OtherPlanet);
            }
            ticketQueue.Dequeue();
        }
    }

}
