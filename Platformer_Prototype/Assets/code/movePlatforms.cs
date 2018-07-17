using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatforms : MonoBehaviour
{
    public GameObject[] place;
    //public BoxCollider Floor;
    //public BoxCollider PlayerOnPlatform;
    int aim = 0;
    public int speed = 5;
    bool playerIsOn = false;
    player play;
    // Use this for initialization
    void Start()
    {
        play = FindObjectOfType<player>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, place[aim].transform.position, speed * Time.deltaTime);
        //print(play.ExtraVel);
        if (playerIsOn == true)
        {
           
            Vector3 dummy = Vector3.MoveTowards(play.transform.position, transform.position, speed * Time.deltaTime) ;
            dummy.y = play.transform.position.y;
            play.transform.position = dummy;
            print(play.ExtraVel);
        }
        if (Vector3.Distance(transform.position, place[aim].transform.position) <= 0.2)
        {
            changeAim();
        }
        //var move = new Vector3(0, -1, 0);
        //transform.position += move * 2.5f * Time.deltaTime;
    }

    void changeAim()
    {
        if (aim == place.Length - 1)
        {
            aim = 0;

        }
        else
        {
            aim++;

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