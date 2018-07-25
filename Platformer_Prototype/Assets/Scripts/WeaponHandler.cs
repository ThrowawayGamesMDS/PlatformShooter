using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public int m_iShotgunPelletDispersionRange;
    public int m_iRifleBulletDispersionRange;
    public static int m_iCurrentWeapon;
    private int m_iPlayerHeldShoot;
    public bool m_bPlayerCanShoot;
    public GameObject[] m_goWeapons;
    public GameObject m_goShotHitOBJ;
    public static GameObject m_gActiveWeapon;
    // Use this for initialization
    void Start()
    {
        m_bPlayerCanShoot = true;
        m_iPlayerHeldShoot = 0;
        m_iCurrentWeapon = 0;
        m_iShotgunPelletDispersionRange = 35;
        m_iRifleBulletDispersionRange = 10;
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
        if (_h.transform.tag == "Turret")
        {
            _h.transform.SendMessage("TurretShot", 10);
        }
        else if (_h.transform.tag == "Ground")
        {
            GameObject pInstance = Instantiate(m_goShotHitOBJ, _h.point, Quaternion.identity);
            pInstance.transform.up = _h.normal;
        }
        else
        {
            GameObject pInstance = Instantiate(m_goShotHitOBJ, _h.point, Quaternion.identity);
            pInstance.transform.up = _h.normal;
        }
    }

    private void FireRateRefresh()
    {
        m_bPlayerCanShoot = true;
    }

    private void GenerateGunShot()
    {
        /*int layerMask = 1 << 8;

        layerMask = ~layerMask;*/
        RaycastHit hit;
        Vector3 randomShotCunt;
       // var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Vector3 last_direction = new Vector3(0,0);
        int _iWidth = Screen.width / 2;
        int _iHeight = Screen.height / 2;

       // if(WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_iMagCount > 0)
       // {
            switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName)
            {
                case "Pistol":
                    ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
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
                        ray = Camera.main.ScreenPointToRay(new Vector3(Random.Range(_iWidth - m_iShotgunPelletDispersionRange, _iWidth + m_iShotgunPelletDispersionRange),
                            Random.Range(_iHeight - m_iShotgunPelletDispersionRange, _iHeight + m_iShotgunPelletDispersionRange)));
                        Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));
                        if (Physics.Raycast(ray.origin, ray.direction * 1000, out hit, 250.0f))
                        {
                            print(hit.transform.name);
                            CheckHit(hit);
                        }
                    }
                    break;
                case "Rifle":
                    ray = Camera.main.ScreenPointToRay(new Vector3(Random.Range(_iWidth - m_iRifleBulletDispersionRange, _iWidth + m_iRifleBulletDispersionRange),
                           Random.Range(_iHeight - m_iRifleBulletDispersionRange, _iHeight + m_iRifleBulletDispersionRange)));
                    Debug.DrawRay(ray.origin, ray.direction * 1000, new Color(1f, 0.922f, 0.016f, 1f));
                    if (Physics.Raycast(ray.origin, ray.direction * 1000, out hit, 250.0f))
                    {
                        print(hit.transform.name);
                        CheckHit(hit);
                    }
                    break;
            }
        Invoke("FireRateRefresh", WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fFireRate);
        m_bPlayerCanShoot = false;
           // WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_iMagCount--;
           // }
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && m_bPlayerCanShoot) // player shooting
        {
            if (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName != "Rifle")
            {
                GenerateGunShot();
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && m_bPlayerCanShoot)
        {
           if (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName == "Rifle")
            {
                GenerateGunShot();
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            switch(WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName)
            {
                case "Pistol":
                    break;
                case "Shonny":
                    m_iShotgunPelletDispersionRange = 17;
                    break;
                case "Rifle":
                    m_iRifleBulletDispersionRange = 5;
                    break;

            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1)) // player shooting
        {
            switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_sWeaponName)
            {
                case "Pistol":
                    break;
                case "Shonny":
                    m_iShotgunPelletDispersionRange = 35;
                    break;
                case "Rifle":
                    m_iRifleBulletDispersionRange = 10;
                    break;

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
