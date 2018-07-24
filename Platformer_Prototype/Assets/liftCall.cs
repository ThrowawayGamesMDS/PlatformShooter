using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftCall : MonoBehaviour {
    public GameObject lift;
    public string headTo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "Player")
            {
                //lift.get`
            }
        }
    }

    
}
