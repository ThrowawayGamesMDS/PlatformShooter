using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHandler : MonoBehaviour
{
    public enum m_LootType
    {
        SHOTGUN_AMMO,PISTOL_AMMO,RIFLE_AMMO, HEALTH_PICKUP,DEFAULT
    }
    public enum m_LootState
    {
        DEFAULT, ATTRACTED // ATTRACTED STATE MEANS THAT THE LOOT WILL MAKE IT'S WAY TOO THE PLAYER UNTIL IT'S POSITION IS EQUAL THEN APPLY THE AMMO..
    }
    public m_LootState m_eCurrState;
    public m_LootType m_eThisLoot; // the type of loot this script is attached to...
    public int m_iAmount; // the amount of loot of this stack (m_loottype) - this will be attached to say the shotgun shell.
    public bool m_bRandomAmount;
    public Transform m_tTarget;
    // Use this for initialization
    void Start ()
    {
        if (m_bRandomAmount)
        m_iAmount = Random.Range(5, 25);
        m_eCurrState = m_LootState.DEFAULT;
    }

    private void ApplyLootableToPlayer()
    {
        switch (m_eThisLoot)
        {
            case m_LootType.PISTOL_AMMO:
                //other.GetComponent<WeaponHandler>().m_iPistolAmmoCount += m_iAmount;
                GameObject.FindGameObjectWithTag("WEAPON_HANDLER").GetComponent<WeaponHandler>().m_iPistolAmmoCount += m_iAmount;
                break;
            case m_LootType.RIFLE_AMMO:
                GameObject.FindGameObjectWithTag("WEAPON_HANDLER").GetComponent<WeaponHandler>().m_iRifleAmmoCount += m_iAmount;
                //other.GetComponent<WeaponHandler>().m_iRifleAmmoCount += m_iAmount;
                break;
            case m_LootType.SHOTGUN_AMMO:
                //other.GetComponent<WeaponHandler>().m_iShotgunAmmoCount += m_iAmount;
                GameObject.FindGameObjectWithTag("WEAPON_HANDLER").GetComponent<WeaponHandler>().m_iShotgunAmmoCount += m_iAmount;
                break;
            case m_LootType.HEALTH_PICKUP:
                //INCREASE THE PLAYERS HEALTH
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Player")
        {
            m_eCurrState = m_LootState.ATTRACTED;
            m_tTarget = other.gameObject.transform;
        }
    }

    // Update is called once per frame
    void Update ()
    {
		if (m_eCurrState == m_LootState.ATTRACTED)
        {
            if (this.transform.position != m_tTarget.transform.position)
            {
                float step = 8 * Time.deltaTime;

                // Move our position a step closer to the target.
                transform.position = Vector3.MoveTowards(transform.position, m_tTarget.position, step);
            }
            else
            {
                ApplyLootableToPlayer();
                Destroy(gameObject);
            }
        }
	}
}
