using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatforms : MonoBehaviour {
    public GameObject[] place;
   
    int aim = 0;
    public int speed = 5;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      
        transform.position = Vector3.MoveTowards(transform.position, place[aim].transform.position, speed*Time.deltaTime);
        if (Vector3.Distance(transform.position, place[aim].transform.position) <= 2)
        {
            changeAim();
        }
        //var move = new Vector3(0, -1, 0);
        //transform.position += move * 2.5f * Time.deltaTime;
    }

    void changeAim()
    {
        if (aim == place.Length-1)
        {
            aim = 0;

        }
        else {
            aim++;

        }
    }
}
