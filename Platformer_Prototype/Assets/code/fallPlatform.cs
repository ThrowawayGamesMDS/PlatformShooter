using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour {
    bool Falling = false;
    public float time = 60;
    bool playerIsOn = false;
    player play;
    // Use this for initialization
    void Start () {
        play = FindObjectOfType<player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Falling == true)
        {
            if (time == 0)
            {
                var move = new Vector3(0, -1, 0);
                transform.position += move * 2.5f * Time.deltaTime;
                if (playerIsOn == true)
                {
                    play.transform.position += move * 2.5f * Time.deltaTime;
                }
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
    void OnCollisionStay(Collision Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            playerIsOn = true;
            //Col.getcompo
            print("yes");
            //Col.transform.position = Vector3.MoveTowards(Col.transform.position, place[aim].transform.position, speed * Time.deltaTime);
        }
    }
    void OnCollisionExit(Collision Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            play.ExtraVel = Vector3.zero;
            playerIsOn = false;
            print("no");
            //Col.transform.position = Vector3.MoveTowards(Col.transform.position, place[aim].transform.position, speed * Time.deltaTime);
        }
    }
}
