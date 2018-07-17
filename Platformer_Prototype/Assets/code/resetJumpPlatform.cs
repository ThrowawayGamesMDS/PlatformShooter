using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetJumpPlatform : MonoBehaviour {
    GameObject S_Player;
    // Use this for initialization
    void Start () {

        //platform.GetComponent<player>;
        S_Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision Col)
    {

        if (Col.gameObject.tag == "Player")
        {
            S_Player.GetComponent<player>().jump = true;
            // Col.GetComponent<player>().jump = true;
            S_Player.GetComponent<player>().doubleJ = true;
            //Falling = true;
        }

    }
}
