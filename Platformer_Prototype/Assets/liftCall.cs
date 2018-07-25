using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftCall : MonoBehaviour {
    public GameObject lift;
    public GameObject player;
    public int headTo;
    Vector3 raycastDir;
    RaycastHit hit;
    Ray workingray;
    // Use this for initialization
    void Start () {
        raycastDir = player.transform.position - transform.position;
        raycastDir.y = raycastDir.y + 1.05f;
    }
	
	// Update is called once per frame
	void Update () {
        
        workingray = new Ray(transform.position, raycastDir);

        if (Physics.Raycast(workingray, out hit))
        {
            if (hit.distance <= 10)
            {
                if (hit.transform.tag == ("Player"))
                {
                    print("call");
                    if (lift.GetComponent<buttonCaller>().stopped == true)
                    {
                        print("go");
                        lift.GetComponent<buttonCaller>().rush = true;
                        lift.GetComponent<buttonCaller>().stopped = false;
                        lift.GetComponent<buttonCaller>().GoTo = headTo;
                    }
                }
               
            }

        }
    }
    
}
