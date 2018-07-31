using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    //Character character;
    public int deathDrop;
    public GameObject[] respawn;
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


            respawn = GameObject.FindGameObjectsWithTag("Death");

            for (int i = 0; i < respawn.Length; i++)
            {
                respawn[i].GetComponent<reset>().reload();
            }
        }
        
	}
}
