using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftCall : MonoBehaviour {
    public GameObject lift;
    public GameObject player;
    public int headTo;
    Vector3 raycastDir;
    RaycastHit hit;
    Ray workingray;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        raycastDir = player.transform.position - transform.position;
        raycastDir.y = raycastDir.y + 1.05f;

        float a = player.transform.position.y - transform.position.y;
        //print(a);
        if ((a >= -2)&&(a <= 2))
         {
       
            workingray = new Ray(transform.position, raycastDir);

            if (Physics.Raycast(workingray, out hit))
            {
                if(lift.GetComponent<buttonCaller>().stopped == true){

                    if (hit.distance <= 5)
                    {
                        if (hit.transform.tag == ("Player"))
                        {
                            //print("call");
                            if (lift.GetComponent<buttonCaller>().stopped == true)
                            {
                                //print("go");
                                lift.GetComponent<buttonCaller>().rush = true;
                                lift.GetComponent<buttonCaller>().stopped = false;
                                lift.GetComponent<buttonCaller>().GoTo = headTo;
                            }
                        }
                    }

                }

            }
            raycastDir = raycastDir.normalized;
            Debug.DrawRay(transform.position, raycastDir * 5, Color.blue);
        }
       

        

    }

}
