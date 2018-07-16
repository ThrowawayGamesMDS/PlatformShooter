using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    int m_iCurrentWeapon;
    public GameObject[] m_goWeapons;
	// Use this for initialization
	void Start ()
    {
        m_iCurrentWeapon = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            while (m_iCurrentWeapon >= 0)
            {
                m_iCurrentWeapon -= 1;
            }
            print(m_iCurrentWeapon);
            // scroll up
        }
        else if (d < 0f)
        {
            while (m_iCurrentWeapon <= 2)
            {
                m_iCurrentWeapon += 1;
            }
            print(m_iCurrentWeapon);
            // scroll down
        }
    }
}
