using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Planets;
    public Material[] textures;
    public GameObject planetPrefab, restartBoom;
    public long uniSiz; //The size of the universe, basically where planets spawn and where to start pushing things back towards the center
    public int planetCount;
    public Text FPS, PC;

    void Start()
    {
        Planets.AddRange(GameObject.FindGameObjectsWithTag("Planet"));

        if (true) //for testing and not needing the whole system
            return;

        for(int x = 0; x < planetCount; x++) //create planets withing specified universe range
        {
            GameObject newPlanet =  Instantiate(planetPrefab, new Vector3(Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz)), Quaternion.identity);
            newPlanet.transform.GetChild(0).GetComponent<Smash>().manager = this.gameObject;
            newPlanet.GetComponent<ChangeDaWorld>().manager = this.gameObject;
            Planets.Add(newPlanet);
        }
    }


    public void ButtonStart()
    {
        Planets.AddRange(GameObject.FindGameObjectsWithTag("Planet"));

        for (int x = 0; x < planetCount; x++)
        {
            GameObject newPlanet = Instantiate(planetPrefab, new Vector3(Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz)), Quaternion.identity);
            newPlanet.transform.GetChild(0).GetComponent<Smash>().manager = this.gameObject;
            newPlanet.GetComponent<ChangeDaWorld>().manager = this.gameObject;
            Planets.Add(newPlanet);
        }
    }

    int avgFrameRate;

    public void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        FPS.text = avgFrameRate.ToString() + " FPS";
        PC.text = "Items:"+Planets.Count.ToString();

        if (Input.GetKeyDown(KeyCode.J))
            StartCoroutine("bigBang");
    }

    public void checkPlanets()
    {
        Debug.Log("Checking Planets");

        for(int i = Planets.Count - 1; i > -1; i--)
                if (!Planets[i])
                    Planets.RemoveAt(i);

        if (Planets.Count <= 1)
            StartCoroutine("bigBang");

    }
    public IEnumerator bigBang()
    {
        yield return new WaitForSeconds(10);
        foreach (GameObject planet in Planets)
        {
            Destroy(planet);
        }
        Instantiate(restartBoom);
        yield return new WaitForSeconds(5);

        ButtonStart();
    }
}
