using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {
    public GameObject platform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            platform.GetComponent<targetPlatformMove>().stopped = false;
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter(Collision Col)
    {

        if (Col.gameObject.tag == "Player")
        {
            platform.GetComponent<targetPlatformMove>().stopped = false;
            Destroy(gameObject);
        }

    }
}
