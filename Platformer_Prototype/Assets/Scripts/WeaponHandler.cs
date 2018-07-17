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

    public static string CurrentGun()
    {
        var _s = "";
        switch (m_iCurrentWeapon)
        {
            case 0:
                _s = "Pistol";
                break;
            case 1:
                _s = "Shonny";
                break;
            case 2:
                _s = "Bazzy";
                break;
        }
        return _s;
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
                    m_iCurrentWeapon += 1;
                    print(m_iCurrentWeapon);

                }
            }
            HandleWeaponSwitch();
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
