﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    public GameObject player;
    public float dis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 raycastDir = player.transform.position - transform.position;
        raycastDir.y = raycastDir.y + 1.05f;
        raycastDir= raycastDir.normalized;
        RaycastHit hit;
        
        Debug.DrawRay(transform.position, raycastDir*dis, Color.blue);
      
        if (Physics.Raycast(transform.position,raycastDir,5.0f)) { 
           print("check point"); 
        }
    }
}

