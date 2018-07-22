using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCaller : MonoBehaviour {
    public GameObject[] place;
    bool stopped = true;
    public int speed = 5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X)){
            stopped = false;
        }
        if (stopped == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, place[0].transform.position, speed * Time.deltaTime);

        }
    }
}
