using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public GameManager manager;
    public Text displaySize;
    public Text displayPlanets;

    void Update()
    {
        displaySize.text = "Universe size: " + manager.uniSiz.ToString();
        displayPlanets.text = "Planets: " + manager.planetCount.ToString();

        if (Input.GetKeyDown(KeyCode.Q))
            manager.uniSiz += 100;
        if (Input.GetKeyDown(KeyCode.W))
            manager.uniSiz -= 100;
        if (Input.GetKeyDown(KeyCode.A))
            manager.uniSiz += 10;
        if (Input.GetKeyDown(KeyCode.S))
            manager.uniSiz -= 10;
        if (Input.GetKeyDown(KeyCode.Z))
            manager.uniSiz += 5;
        if (Input.GetKeyDown(KeyCode.X))
            manager.uniSiz -= 5;

        if (Input.GetKeyDown(KeyCode.E))
            manager.planetCount += 100;
        if (Input.GetKeyDown(KeyCode.R))
            manager.planetCount -= 100;
        if (Input.GetKeyDown(KeyCode.D))
            manager.planetCount += 10;
        if (Input.GetKeyDown(KeyCode.F))
            manager.planetCount -= 10;
        if (Input.GetKeyDown(KeyCode.C))
            manager.planetCount += 5;
        if (Input.GetKeyDown(KeyCode.V))
            manager.planetCount -= 5;

    }

    public void startUniverse()
    {
        manager.ButtonStart();
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(true);
    }
}
