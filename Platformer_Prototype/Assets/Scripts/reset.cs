using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class reset : MonoBehaviour {
    public string spawnObject;
    public GameObject[] spawn;
    public bool help;
	// Use this for initialization
	void Start () {
        spawnObject = "Fallplatform";

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }
    }
    public void reload()
    {
        switch (spawnObject)
        {
            case "Fallplatform":
                if (help == true)
                {
                    Debug.Log("fall");
                    GameObject die = Instantiate(spawn[0], transform.position, Quaternion.identity);
                }
                else
                {
                    GameObject die = Instantiate(spawn[1], transform.position, Quaternion.identity);
                }

                break;
            default:
                break;
        }
    }
}
