using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Planets;
    public Texture[] textures;

    void Start()
    {
        Planets = GameObject.FindGameObjectsWithTag("Planet");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
