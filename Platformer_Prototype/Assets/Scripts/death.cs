using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    //Character character;
    public int deathDrop;
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y <= deathDrop) { 
            //Input.GetKeyDown(KeyCode.H)) {

            GameObject thePlayer = GameObject.Find("ThePlayer");
            Character Self = GetComponent<Character>();
            transform.position = Self.savehome;
        }
        
	}
}
