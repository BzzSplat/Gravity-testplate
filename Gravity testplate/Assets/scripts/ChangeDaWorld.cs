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
        Material matt;
        mattyD = this.GetComponent<Renderer>();
        matt = this.GetComponent<Material>();
        if (this.transform.parent.name != "Universe Core")
            mattyD.material.mainTexture = cdw.textures[texInd];
    }


    public void randTexture()
    {
        Renderer mattyD;
        Material matt;
        mattyD = this.GetComponent<Renderer>();
        matt = this.GetComponent<Material>();
        if (this.transform.parent.name != "Universe Core")
            mattyD.material.mainTexture = cdw.textures[Random.Range(2, 6)];
    }


    public void UpdateSize(Rigidbody rb)
    {
        //gameObject

        if (rb.mass < 12)
        {
            //transform.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            this.transform.parent.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(2);
        }
        else
        {
            this.transform.parent.localScale = new Vector3(rb.mass, rb.mass, rb.mass);
            changeTexture(1);
        }
    }
}
