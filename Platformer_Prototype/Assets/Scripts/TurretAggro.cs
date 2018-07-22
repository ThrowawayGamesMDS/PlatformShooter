using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAggro : MonoBehaviour
{

    public enum eAIMode { Idle, Alert, Aggro };
    public eAIMode myAIMode;
    public GameObject playerObj;
    public float damping;
    public Transform endofturret;
    public float fireRate;
    public float turretAccuracy;
    private float turretCooldown;
    public AudioSource gunShotSound;
    public GameObject ball;

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
                    //lookpos.y = 0;
                    Quaternion rotation = Quaternion.LookRotation(lookpos);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

                    if(Time.time > turretCooldown)
                    {
                        Vector3 rayOrigin = endofturret.position;
                        Vector3 rayDirection = playerObj.transform.position - endofturret.position;
                        RaycastHit hit;
                        if(Physics.Raycast(endofturret.position, rayDirection, out hit, 100))
                        {
                            if(hit.transform.tag == "Player")
                            {
                                rayDirection.x += Random.Range(-turretAccuracy, turretAccuracy);
                                rayDirection.z += Random.Range(-turretAccuracy, turretAccuracy);
                                rayDirection.y += Random.Range(-turretAccuracy, turretAccuracy);

                                if (Physics.Raycast(endofturret.position, rayDirection, out hit, 100))
                                {
                                    Debug.DrawRay(endofturret.position, rayDirection, Color.yellow);
                                    //Debug.Log(hit.transform.name);
                                    Instantiate(ball, hit.point, ball.transform.rotation);
                                }
                                else
                                {
                                    Debug.DrawRay(endofturret.position, rayDirection, Color.white);
                                }
                                gunShotSound.Play();
                                turretCooldown = Time.time + fireRate;
                            }
                        }
                        
                    }
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
