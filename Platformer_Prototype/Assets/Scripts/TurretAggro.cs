using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAggro : MonoBehaviour
{

    public enum eAIMode { Idle, Alert, Aggro };
    public eAIMode myAIMode;
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
