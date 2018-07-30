using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public  enum WeaponType
    {
        PISTOL = 0, SHOTGUN = 1, RIFLE = 2
    }
    public AudioSource src;
    public WeaponType m_eWeaponType;
    public float m_fPower;
    public float m_fFireRate;
    public string m_sWeaponType;
    public int m_iMagCount;
    public string m_sWeaponName;
	// Use this for initialization
	void Start ()
    {
    }
	
    /*private string DetermineType()
    {
        /*var _s = "";
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
    }*/

	// Update is called once per frame
	void Update ()
    {

    }
    public void playSound()
    {
        src.Play();
    }
}
