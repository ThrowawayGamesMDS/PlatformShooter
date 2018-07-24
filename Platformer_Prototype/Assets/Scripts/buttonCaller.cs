using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCaller : MonoBehaviour {
    public GameObject[] place;
    public int GoTo = 0;
    public bool rush = false;
    public bool stopped = true;
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
            if (rush == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, place[GoTo].transform.position, speed * Time.deltaTime);

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, place[GoTo].transform.position, speed* 2 * Time.deltaTime);

            }
            if (Vector3.Distance(transform.position, place[GoTo].transform.position) <= 2)
            {
                stopped = false;
                rush = false;
            }
        }
    }
    public void move() {
        stopped = false;
    }
    public void top()
    {

    }
    public void bottom()
    {

    }
}
