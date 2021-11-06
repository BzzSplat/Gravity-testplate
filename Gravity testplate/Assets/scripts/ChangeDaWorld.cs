using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDaWorld : MonoBehaviour
{

    public GameObject manager;
    ChangeDaWorld cdw;
    public Texture[] textures;

    void Start()
    {
        cdw = manager.GetComponent<ChangeDaWorld>();
    }
        

    public void changeTexture(int texInd)// 1 is blackhole, 2 is volcanic
    {
        Renderer mattyD;
        mattyD = this.transform.GetChild(0).GetComponent<Renderer>();
        if (this.name != "Universe Core")
            mattyD.material.mainTexture = cdw.textures[texInd];
    }

    public void UpdateSize(Rigidbody rb)
    {
        if (rb.mass < 12)
        {
            this.transform.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(2);
        }
        else
        {
            this.transform.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(1);
        }
    }
}
