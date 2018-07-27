using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour {
    bool Falling = false;
    public float time = 60;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Falling == true)
        {
            if (time == 0)
            {
                var move = new Vector3(0, -1, 0);
                transform.position += move * 2.5f * Time.deltaTime;
            }
            else {
                time--;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Falling = true;
        }
	}
    void OnCollisionEnter(Collision Col)
    {

        if (Col.gameObject.tag == "Player") {
            Falling = true;
        }

    }
}
