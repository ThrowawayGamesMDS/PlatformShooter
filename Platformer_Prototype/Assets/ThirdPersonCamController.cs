using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamController : MonoBehaviour {
    public Transform crosshair;
    public Transform crosshairpivot;
    public Transform PlayerObj;
    public Transform campivot;
    private Vector3 offset = new Vector3(0.5f, 3, -6);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = target.localPosition + offset;
        transform.LookAt(crosshair);
        //transform.position = PlayerObj.position + offset;
        crosshairpivot.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * 100);
        crosshairpivot.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * 100);
    }
}
