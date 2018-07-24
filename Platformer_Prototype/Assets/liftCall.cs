using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftCall : MonoBehaviour {
    public GameObject lift;
    public int headTo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            lift.GetComponent<buttonCaller>().rush = true;
            lift.GetComponent<buttonCaller>().stopped = true;
            lift.GetComponent<buttonCaller>().GoTo = headTo;
        }
    }
}
