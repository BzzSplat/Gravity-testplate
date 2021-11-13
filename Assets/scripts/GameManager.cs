using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Planets;
    public Texture[] textures;
    public GameObject planetPrefab;
    public long uniSiz = 50; //The size of the universe, basically where planets spawn and where to start pushing things back towards the center

    void Start()
    {
        Planets.AddRange(GameObject.FindGameObjectsWithTag("Planet"));
        
        for(int x = 0; x < 30; x++) //create planets withing specified universe range
        {
            GameObject newPlanet =  Instantiate(planetPrefab, new Vector3(Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz), Random.Range(-uniSiz, uniSiz)), Quaternion.identity);
            newPlanet.transform.GetChild(0).GetComponent<Smash>().manager = this.gameObject;
            newPlanet.GetComponent<ChangeDaWorld>().manager = this.gameObject;
            Planets.Add(newPlanet);
        }
    }
}
