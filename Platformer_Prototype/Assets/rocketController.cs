using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketController : MonoBehaviour {
    public float missileSpeed;
    public MeshRenderer mr;
    public float radius;
    public float power;
    [SerializeField] private bool isMoving;
	// Use this for initialization
	void Start () {
        isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(isMoving == true)
        {
            transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
        }

	}
    void OnCollisionEnter(Collision other)
    {
        print("Collide");
        isMoving = false;
        missileSpeed = 0;
        mr.enabled = false;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
                
        }
    }
}
