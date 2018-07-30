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
    public Vector3 m_v3StartPos;
    public Vector3 m_v3ControlPoint;
    public Vector3 m_v3EndPos; // target pos
    private float m_fXCurve;
    private float m_fYCurve;
    private float m_fZCurve;
    public float BezierTime;

    // Use this for initialization
    void Start ()
    {
        m_v3ControlPoint.x = 5;
        m_v3ControlPoint.y = 5;
        m_v3ControlPoint.z = 5;
        if (m_bRandomAmount)
        m_iAmount = Random.Range(5, 25);
        m_eCurrState = m_LootState.DEFAULT;
        BezierTime = 0;
    }

    private void ApplyLootableToPlayer()
    {
        switch (m_eThisLoot)
        {
            case m_LootType.PISTOL_AMMO:
                GameObject.FindGameObjectWithTag("WEAPON_HANDLER").GetComponent<WeaponHandler>().m_iPistolAmmoCount += m_iAmount;
                break;
            case m_LootType.RIFLE_AMMO:
                GameObject.FindGameObjectWithTag("WEAPON_HANDLER").GetComponent<WeaponHandler>().m_iRifleAmmoCount += m_iAmount;
                break;
            case m_LootType.SHOTGUN_AMMO:
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
           // m_tTarget = other.gameObject.transform;
            m_tTarget = GameObject.Find("playercentre").transform;

           // m_v3EndPos = m_tTarget.transform.position;
           // m_v3StartPos = gameObject.transform.position;
            /*
            // apply explosion to rigidbody
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Vector3 Pos = gameObject.transform.position;
            Pos.y -= 0.5f;
            Pos.z -= 0.5f;
            Pos.x -= 0.5f;
            if (rb != null)
            {
                rb.AddExplosionForce(150.0f, Pos, 5.0f, 13.0f);
                print("applied rb explosionforce to ammo pickup");
            }*/
        }
    }

    // Update is called once per frame
    void Update ()
    {
		if (m_eCurrState == m_LootState.ATTRACTED)
        {
            /*if (this.transform.position != m_tTarget.transform.position)
            {
                BezierTime = BezierTime + Time.deltaTime;
                if (BezierTime >= 1)
                {
                    BezierTime = 0;
                }
                m_fXCurve = (((1 - BezierTime) * (1 - BezierTime)) * m_v3StartPos.x) + (2 * BezierTime * (1 - BezierTime) * m_v3ControlPoint.x) + ((BezierTime * BezierTime) * m_v3EndPos.x);
                m_fYCurve = (((1 - BezierTime) * (1 - BezierTime)) * m_v3StartPos.y) + (2 * BezierTime * (1 - BezierTime) * m_v3ControlPoint.y) + ((BezierTime * BezierTime) * m_v3EndPos.y);
                m_fZCurve = (((1 - BezierTime) * (1 - BezierTime)) * m_v3StartPos.z) + (2 * BezierTime * (1 - BezierTime) * m_v3ControlPoint.z) + ((BezierTime * BezierTime) * m_v3EndPos.z);
                transform.position = new Vector3(m_fXCurve, m_fYCurve, m_fZCurve);
            }*/
            
            if (this.transform.position != m_tTarget.transform.position)
            {
                float step = 8 * Time.deltaTime;

                // Move our position a step closer to the target.
                transform.position = Vector3.MoveTowards(transform.position, m_tTarget.position, step);
            }
            if (Vector3.Distance(transform.position, m_tTarget.transform.position) < 1) 
            {
                ApplyLootableToPlayer();
                Destroy(gameObject);
            }
        }
	}
}