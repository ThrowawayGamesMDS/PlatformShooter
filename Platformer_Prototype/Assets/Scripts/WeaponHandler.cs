using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static int m_iCurrentWeapon;
    public GameObject[] m_goWeapons;
    public static GameObject m_gActiveWeapon;
    // Use this for initialization
    void Start()
    {
        m_iCurrentWeapon = 0;
        for (int i = 0; i < 3; i++)
        {
            if (i != m_iCurrentWeapon)
            {
                m_goWeapons[i].SetActive(false);
            }
        }
        m_gActiveWeapon = m_goWeapons[m_iCurrentWeapon];
        // m_goWeapons = new GameObject[3];
    }

    private void HandleWeaponSwitch()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != m_iCurrentWeapon)
            {
                m_goWeapons[i].SetActive(false);
            }
            else
            {
                m_goWeapons[i].SetActive(true);
            }
        }
        m_gActiveWeapon = m_goWeapons[m_iCurrentWeapon];
    }

    private void GenerateGunShot()
    {
        /*int layerMask = 1 << 8;

        layerMask = ~layerMask;*/
        RaycastHit hit;
        
        switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName)
        {
            case "Pistol":
                Debug.DrawRay(this.transform.position, this.transform.TransformDirection(Vector3.forward), Color.red);
                if (Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out hit, 15))
                {
                    //Debug.DrawRay(WeaponHandler.m_gActiveWeapon.transform.position, WeaponHandler.m_gActiveWeapon.transform.TransformDirection(Vector3.forward), Color.red);
                }
                break;
            case "Shonny":
                break;
            case "Bazzy":
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d != 0)
        {
            if (d > 0f)
            {
                if (m_iCurrentWeapon > 0)
                {
                    m_iCurrentWeapon -= 1;
                    print(m_iCurrentWeapon);
                }
                // scroll up
            }
            else if (d < 0f)
            {
                if (m_iCurrentWeapon <= 2)
                {
                    if (m_iCurrentWeapon != 2)
                    m_iCurrentWeapon += 1;

                    print(m_iCurrentWeapon);

                }
            }
            HandleWeaponSwitch();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) // player shooting
        {
            print("fire");
            GenerateGunShot();
        }

        if (m_iCurrentWeapon > 2 || m_iCurrentWeapon < 0)
        {
            if (m_iCurrentWeapon > 2)
            {
                m_iCurrentWeapon = 2;
            }
            else
            {
                m_iCurrentWeapon = 0;
            }
        }
    }
}
