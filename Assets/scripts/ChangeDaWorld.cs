using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDaWorld : MonoBehaviour
{
    public GameObject manager;
    GameManager manScript;
    public GameObject nova;

    void Start()
    {
        manScript = manager.GetComponent<GameManager>();
    }
        

    public void changeTexture(int texInd, GameObject objectToChange)// 1 is blackhole, 2 is volcanic
    {
        objectToChange.GetComponent<Renderer>().material = manScript.textures[texInd];
    }

    public void UpdateSize(Rigidbody rb, Transform planet)
    {
        if (rb.mass < 15) //if under ##, object is a planet
        {
            planet.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(2, planet.GetChild(0).gameObject);

            planet.gameObject.GetComponent<Light>().enabled = false;
        }
        else if(rb.mass < 30) //if under ##, object is a star. Will later add material makeup requirements to do this (gasses majority, obviously)
        {
            planet.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(7, planet.GetChild(0).gameObject);
            planet.GetChild(2).gameObject.active = false;
            planet.GetChild(0).GetComponent<Smash>().isStar = true;

            planet.gameObject.GetComponent<Light>().enabled = true;
            planet.gameObject.GetComponent<Light>().range = planet.localScale.y * 5; //divide by 2 to gett correct size / times by 10 for desired reach
        }
        else //if over any of the limits it becomes a blackhole
        {
            planet.localScale = new Vector3(rb.mass/10, rb.mass/10, rb.mass/10);
            changeTexture(1, planet.GetChild(0).gameObject);
            planet.gameObject.GetComponent<Light>().enabled = false;
            planet.GetChild(2).gameObject.active = false;
            planet.GetChild(0).GetComponent<Smash>().isBHole = true;

            if (planet.GetChild(0).GetComponent<Smash>().isStar)
            {
                //GameObject nover = Instantiate(nova, planet.position, Quaternion.identity);

            }
        }
    }
}
