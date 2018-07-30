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
    public int m_iShotgunAmmoCount;
    public int m_iPistolAmmoCount;
    public int m_iRifleAmmoCount;
    private int[] m_arriGunLevels; // 0 = pistol, 1 = shotgun, 2 = rifle
    private float[] m_arrfGunEXP; // 0 = pistol, 1 = shotgun, 2 = rifle
    public GameObject[] m_goWeapons;
    public GameObject m_goShotHitOBJ;
    public static GameObject m_gActiveWeapon;
    // Use this for initialization
    void Start()
    {
        m_arriGunLevels = new int[3];
        m_arrfGunEXP = new float[3];
        for (int i = 0; i < 3; i++)
        {
            m_arriGunLevels[i] = 1;
            m_arrfGunEXP[i] = 0.0f;
        }
        m_bPlayerCanShoot = true;
        m_iPlayerHeldShoot = 0;
        m_iCurrentWeapon = 0;
        m_iShotgunPelletDispersionRange = 35;
        m_iRifleBulletDispersionRange = 10;
        m_iShotgunAmmoCount = 10;
        m_iPistolAmmoCount = 10;
        m_iRifleAmmoCount = 10;
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

    private float DetermineDamage(RaycastHit _h) // int or float depending on what we store npc/player health as???
    {
        var _iResult = 2.0f;
        switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType)
        {
            case WeaponStats.WeaponType.PISTOL:
                {
                    //_iResult = (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fPower * m_arriGunLevels[0]/ (_h.distance/10));
                    _iResult = (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fPower * m_arriGunLevels[2]);
                    break;
                }
            case WeaponStats.WeaponType.SHOTGUN:
                {
                    // _iResult = (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fPower * m_arriGunLevels[1] / (_h.distance / 10));
                    _iResult = (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fPower * m_arriGunLevels[2]);
                    break;
                }
            case WeaponStats.WeaponType.RIFLE:
                {
                    // _iResult = (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fPower * m_arriGunLevels[2] / (_h.distance / 10));
                    _iResult = (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fPower * m_arriGunLevels[2]);
                    break;
                }
            default:
                break;
        }

        print("DAMAGE TO DEAL: " + _iResult);
         

        return _iResult;
    }

    private bool PlayerHitSomething(RaycastHit _h)
    {
        if (_h.transform != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckHit(RaycastHit _h, float _fDamageToApply)
    {

        if (_h.transform.tag == "Turret")
        {
            Debug.Log("turret shot");
            _h.transform.SendMessage("TurretShot", _fDamageToApply);
        }
        else if (_h.transform.tag == "Ground")
        {
            GameObject pInstance = Instantiate(m_goShotHitOBJ, _h.point, Quaternion.identity);
            pInstance.transform.up = _h.normal;
        }
        else if (_h.transform.tag == "AMMO_BOX")
        {
            _h.transform.SendMessage("SpawnTheLoot");
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

    private RaycastHit GenerateRayShot(float _fDispersionRange, float _fShotDistance, bool _bAccuracyVarianceActivated)
    {
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(0, 0));
        int _iWidth = Screen.width / 2;
        int _iHeight = Screen.height / 2;

        switch (_bAccuracyVarianceActivated)
        {
            case true:
                {
                    switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType)
                    {
                        case WeaponStats.WeaponType.SHOTGUN:
                            {
                                ray = Camera.main.ScreenPointToRay(new Vector3(Random.Range(_iWidth - _fDispersionRange, _iWidth + _fDispersionRange),
                                        Random.Range(_iHeight - _fDispersionRange, _iHeight + _fDispersionRange / 2)));
                                break;
                            }
                        case WeaponStats.WeaponType.RIFLE:
                            {
                                ray = Camera.main.ScreenPointToRay(new Vector3(Random.Range(_iWidth - _fDispersionRange, _iWidth + _fDispersionRange),
                                        Random.Range(_iHeight - _fDispersionRange, _iHeight + _fDispersionRange)));
                                break;
                            }
                    }
                    break;
                }
            case false:
                {
                    ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
                    break;
                }
        }
        Debug.DrawRay(ray.origin, ray.direction * _fShotDistance, new Color(1f, 0.922f, 0.016f, 1f));
        if (Physics.Raycast(ray.origin, ray.direction * _fShotDistance, out hit, 250.0f))
        {
            return hit;
        }
        else 
        {
            return hit;
        }
    }

    private void GenerateGunShot()
    {
        WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().playSound();
        RaycastHit hit;
        float _fDamageToApply;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Vector3 last_direction = new Vector3(0,0);
        int _iWidth = Screen.width / 2;
        int _iHeight = Screen.height / 2;

            switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType)
            {
                case WeaponStats.WeaponType.PISTOL:
                    hit = GenerateRayShot(0,35,false);
                    if (PlayerHitSomething(hit) == true)
                    {
                        _fDamageToApply = DetermineDamage(hit);
                        CheckHit(hit, _fDamageToApply);
                    }
                break;
            case WeaponStats.WeaponType.SHOTGUN:
                for (int i = 0; i < 9; i++) // random shotgun pellet variance
                {
                    hit = GenerateRayShot(m_iShotgunPelletDispersionRange, 15, true);
                    if (PlayerHitSomething(hit))
                    {
                        _fDamageToApply = DetermineDamage(hit);
                        CheckHit(hit, _fDamageToApply);
                    }
                }
                    break;
            case WeaponStats.WeaponType.RIFLE:
                hit = GenerateRayShot(m_iRifleBulletDispersionRange, 55, true);
                if (PlayerHitSomething(hit))
                {
                    _fDamageToApply = DetermineDamage(hit);
                    CheckHit(hit, _fDamageToApply);
                }
                break;
            }
        Invoke("FireRateRefresh", WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_fFireRate);
        m_bPlayerCanShoot = false;
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
            if (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType != WeaponStats.WeaponType.RIFLE)
            {
                GenerateGunShot();
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && m_bPlayerCanShoot)
        {
           if (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType == WeaponStats.WeaponType.RIFLE)
            {
                GenerateGunShot();
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType)
            {
                case WeaponStats.WeaponType.PISTOL:
                    break;
                case WeaponStats.WeaponType.RIFLE:
                    m_iRifleBulletDispersionRange = 5;
                    break;
                case WeaponStats.WeaponType.SHOTGUN:
                    m_iShotgunPelletDispersionRange = 17;
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1)) // player shooting
        {
            switch (WeaponHandler.m_gActiveWeapon.GetComponent<WeaponStats>().m_eWeaponType)
            {
                case WeaponStats.WeaponType.PISTOL:
                    break;
                case WeaponStats.WeaponType.RIFLE:
                    m_iRifleBulletDispersionRange = 10;
                    break;
                case WeaponStats.WeaponType.SHOTGUN:
                    m_iShotgunPelletDispersionRange = 35;
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
