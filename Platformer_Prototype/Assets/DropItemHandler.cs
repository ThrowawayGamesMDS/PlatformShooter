using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemHandler : MonoBehaviour
{
    public GameObject[] m_goDropables; // the items this script is going to drop..
    public int m_iArraySize; // could do a funct to check when the array doesn't equal a go an then it is therefore returned and -1 to equal the size of arr... but fuck it

	// Use this for initialization
	void Start ()
    {
		
	}

    private void SpawnTheLoot()
    {
        GameObject pInstance = Instantiate(m_goDropables[Random.Range(0,m_iArraySize)], this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
