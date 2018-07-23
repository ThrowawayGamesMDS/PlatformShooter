using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public static int m_iCurrentWeapon;
    private int m_iPlayerHeldShoot;
    public GameObject[] m_goWeapons;
    public static GameObject m_gActiveWeapon;
    // Use this for initialization
    void Start()
    {
        m_iPlayerHeldShoot = 0;
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

    private void CheckHit(RaycastHit _h)
    {
        if (_h.transform.name == "Turret")
        {
            _h.transform.SendMessage("TurretFucked");
        }
    }

    private void GenerateGunShot()
    {
        /*int layerMask = 1 << 8;

        layerMask = ~layerMask;*/
        RaycastHit hit;
        Vector3 randomShotCunt;
       // var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
      
        
        switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName)
        {
            case "Pistol":
                print("SHOOT PISTOL");

                Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));
                if (Physics.Raycast(ray.origin, ray.direction * 1000, out hit, 250.0f))
                {
                    print(hit.transform.name);
                    CheckHit(hit);
                }
                break;
            case "Shonny":
                for (int i = 0; i < 9; i++) // random shotgun pellet variance
                {
                    randomShotCunt = ray.direction;
                    print("Firing shot: " + m_iPlayerHeldShoot);
                    randomShotCunt.x = Random.Range(0.0f, 0.05f);
                    randomShotCunt.y = Random.Range(0.0f, 0.05f);
                    randomShotCunt.z = 0.0f;
                    Debug.DrawRay(ray.origin, (randomShotCunt) * 10000, new Color(1f, 0.922f, 0.016f, 1f));
                }
                break;
            case "Bazzy":
                for (int i = 0; i < WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_iMagCount; i++) // automatic weapon variance in shot..
                {
                    randomShotCunt = ray.direction;
                    print("Firing shot: " + m_iPlayerHeldShoot);
                    randomShotCunt.x = Random.Range(0.1f, 0.5f);
                    randomShotCunt.y = Random.Range(0.1f, 0.5f);
                    randomShotCunt.z = 0.0f;
                    Debug.DrawRay(ray.origin, (randomShotCunt * -1) * 10000, new Color(1f, 0.922f, 0.016f, 1f));
                }
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
            GenerateGunShot();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (m_iPlayerHeldShoot < WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_iMagCount)
            {
                m_iPlayerHeldShoot++;
            }
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
