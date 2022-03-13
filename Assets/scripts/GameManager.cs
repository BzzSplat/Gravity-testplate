using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //just try remakeing the planet system in the other game, will work out better
{
    public List<GameObject> Planets;
    public Material[] textures;
    public GameObject planetPrefab, restartBoom;
    public long uniSiz; //The size of the universe, basically where planets spawn and where to start pushing things back towards the center
    public int planetCount;
    public Text FPS, PC;
    public float randMov;

    /*void Start() //demo does not start immediatly
    {
        Planets.AddRange(GameObject.FindGameObjectsWithTag("Planet"));

        for(int x = 0; x < planetCount; x++) //create planets withing specified universe range
        {
            GameObject newPlanet =  Instantiate(planetPrefab, new Vector3(Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz)), Quaternion.identity);
            newPlanet.transform.GetChild(0).GetComponent<Smash>().manager = this.gameObject;
            newPlanet.GetComponent<ChangeDaWorld>().manager = this.gameObject;
            Planets.Add(newPlanet);
        }
    }*/


    public void ButtonStart()
    {
        Planets.AddRange(GameObject.FindGameObjectsWithTag("Planet"));

        for (int x = 0; x < planetCount; x++)
        {
            GameObject newPlanet = Instantiate(planetPrefab, new Vector3(Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz)), Quaternion.identity);
            newPlanet.transform.GetChild(0).GetComponent<Smash>().manager = this.gameObject;
            newPlanet.GetComponent<ChangeDaWorld>().manager = this.gameObject;
            Planets.Add(newPlanet);
            newPlanet.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-randMov, randMov), Random.Range(-randMov, randMov), Random.Range(-randMov, randMov)) );
        }

        GetComponent<BoxCollider>().size = new Vector3(uniSiz*2, uniSiz*2, uniSiz*2);
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
        bool starsExist = false;

        for(int i = Planets.Count - 1; i > -1; i--)
        {
            if (!Planets[i])
            {
                Planets.RemoveAt(i);
            }

            if (Planets[i] && Planets[i].GetComponent<Rigidbody>().mass >= 15 && Planets[i].GetComponent<Rigidbody>().mass < 30)
                starsExist = true;
        }

        if (starsExist) //give some ambient lighting when there are no stars
            RenderSettings.ambientLight = new Color(0, 0, 0);
        else
            RenderSettings.ambientLight = new Color(0.1960f, 0.1960f, 0.1960f);

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

    private void FixedUpdate()
    {
        foreach(GameObject planetObj in Planets) //keep planets in the designated universe area
        {
            if (!planetObj)
                break;

            Transform planet = planetObj.transform;
            Rigidbody rb = planet.GetComponent<Rigidbody>();

            if (planet.position.x > uniSiz)
                rb.AddForce(new Vector3(-(planet.position.x - uniSiz), 0, 0)); //check x
            else if (planet.position.x < -uniSiz)
                rb.AddForce(new Vector3(-(planet.position.x + uniSiz), 0, 0));

            if (planet.position.y > uniSiz)
                rb.AddForce(new Vector3(0, -(planet.position.y - uniSiz), 0)); //check y
            else if (planet.position.y < -uniSiz)
                rb.AddForce(new Vector3(0, -(planet.position.y + uniSiz), 0));

            if (planet.position.z > uniSiz)
                rb.AddForce(new Vector3(0, 0, -(planet.position.z - uniSiz))); // check z
            else if (planet.position.z < -uniSiz)
                rb.AddForce(new Vector3(0, 0, -(planet.position.z + uniSiz)));
        }
    }
}
