using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncepad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnCollisionEnter(Collider other)
    {
        Debug.Log("bounce");
        if(other.tag == "Player")
        {
            other.transform.gameObject.GetComponent<Character>().AddImpact(Vector3.forward, 100);
        }

    }
}
