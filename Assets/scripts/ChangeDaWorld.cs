using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDaWorld : MonoBehaviour
{
    public GameObject manager;
    GameManager manScript;

    void Start()
    {
        manScript = manager.GetComponent<GameManager>();
    }
        

    public void changeTexture(int texInd, GameObject objectToChange)// 1 is blackhole, 2 is volcanic
    {
        Renderer mattyD = objectToChange.GetComponent<Renderer>();
        mattyD.material.mainTexture = manScript.textures[texInd]; //will cause null reference exeptions if there are only two planets?
    }

    public void UpdateSize(Rigidbody rb, Transform planet)
    {
        if (rb.mass < 20)
        {
            planet.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(2, planet.GetChild(0).gameObject);
        }
        else //if mass if over the set limit turn it into a blackhole
        {
            planet.localScale = new Vector3(rb.mass/10, rb.mass/10, rb.mass/10);
            changeTexture(1, planet.GetChild(0).gameObject);
        }
    }
}
