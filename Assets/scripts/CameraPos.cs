using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    public GameObject managerObj;
    GameManager manager;

    void Start()
    {
        manager = managerObj.GetComponent<GameManager>();

        transform.position = new Vector3 (0, manager.uniSiz + 30, (manager.uniSiz + 30) * -1);
    }
}
