using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    public GameObject player;
    public float dis;
    bool lastOne = false;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 raycastDir = player.transform.position - transform.position;
        raycastDir.y = raycastDir.y + 1.05f;
        
        RaycastHit hit;
        Ray workingray = new Ray(transform.position, raycastDir);

        

        if (lastOne == true)
        {

            //if (Physics.Raycast(transform.position, raycastDir,dis)) 
                 //if (Physics.Raycast(transform.position, raycastDir * dis, out hit))
                if (Physics.Raycast(workingray, out hit))
                {
                if (hit.distance <= 10.0f)
                {
                    if (hit.transform.tag == "Player")
                    {
                        hit.transform.GetComponent<Character>().savehome = new Vector3(transform.position.x, transform.position.y + 1.06f, transform.position.z);
                    }
                    print("check point");
                }

            }
        }
        raycastDir = raycastDir.normalized;
        Debug.DrawRay(transform.position, raycastDir * dis, Color.blue);

    }
}

