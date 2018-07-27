using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoplayer : MonoBehaviour {
    private bool isMove;
	// Use this for initialization
	void Start () {
        Invoke("gotoplayerF", 1f);
        isMove = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("PlayerCentre").transform.position, 10 * Time.deltaTime);
        }
	}
    void gotoplayerF()
    {
        isMove = true;
    }
}
