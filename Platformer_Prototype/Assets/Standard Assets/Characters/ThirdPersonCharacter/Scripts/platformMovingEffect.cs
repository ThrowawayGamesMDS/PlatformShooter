using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovingEffect : MonoBehaviour {
    public Vector3 lastPlace;
	// Use this for initialization
	void Start () {
		
	}

   
	// Update is called once per frame
	void LateUpdate() {
        lastPlace = transform.position;

    }
    public Vector3 Action()
    {
        print("goog");
        return lastPlace - transform.position;
    }
}
