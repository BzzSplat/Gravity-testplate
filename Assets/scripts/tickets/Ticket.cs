using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket
{
    public GameObject SourcePlanet;
    public GameObject OtherPlanet;

    public Ticket(GameObject Source, GameObject Other)
    {
        SourcePlanet = Source;
        OtherPlanet = Other;
    }
}
