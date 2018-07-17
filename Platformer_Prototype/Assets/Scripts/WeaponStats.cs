using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public enum WeaponType
    {
        SINGLE, BURST, AUTO
    }

    public float m_fWeaponPower;
    public int m_iMagazineCapacity;
    public int m_iWeaponLevel;
    public WeaponType m_eWeaponType;
    public float m_fWeaponEXP;
    public float m_fPower;
    public int m_iMagCap;
    public string m_sWeaponType;
    public int m_iMagCount;
    public string m_sWeaponName;
	// Use this for initialization
	void Start ()
    {
        m_fPower = m_fWeaponPower;
        m_iMagCap = m_iMagazineCapacity;
        m_sWeaponType = DetermineType();
        m_iMagCount = m_iMagCap;
        //m_fWeaponEXP = 0.0f;
        //m_iWeaponLevel = 1;
    }
	
    private string DetermineType()
    {
        var _s = "";
        switch(m_eWeaponType)
        {
            case WeaponType.SINGLE:
                {
                    _s = "SINGLE";
                    break;
                }
            case WeaponType.BURST:
                {
                    _s = "BURST";
                    break;
                }
            case WeaponType.AUTO:
                {
                    _s =  "AUTO";
                    break;
                }
        }
        return _s;
    }

	// Update is called once per frame
	void Update ()
    {

    }
}
