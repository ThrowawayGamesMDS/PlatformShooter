﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAggro : MonoBehaviour
{

    public enum eAIMode { Idle, Alert, Aggro };
    public eAIMode myAIMode;
    public GameObject playerObj;
    public float damping;
    // Use this for initialization
    void Start()
    {
        myAIMode = eAIMode.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (myAIMode)
        {
            case eAIMode.Idle:
                {
                    break;
                }
            case eAIMode.Alert:
                {
                    break;
                }
            case eAIMode.Aggro:
                {
                    Vector3 lookpos = playerObj.transform.position - transform.position;
                    lookpos.y = 0;
                    Quaternion rotation = Quaternion.LookRotation(lookpos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
                    break;
                }

        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myAIMode = eAIMode.Aggro;
            Debug.Log(myAIMode);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myAIMode = eAIMode.Idle;
            Debug.Log(myAIMode);
        }
    }
}
