using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_HP : MonoBehaviour {
    public Image HPImage;
    public int MaxHP = 150;
    public int tempHP = 100;
    Color changColor;
	// Use this for initialization
	void Start () {
        changColor.r = 0.81f;
        changColor.g = 0;
        changColor.b = 0;
        changColor.a = 0.20f;
    }
	
	// Update is called once per frame
	void Update () {

        if (75 <= tempHP)
        {
            changColor.r = 0.81f;
            changColor.g = 0;
            changColor.b = 0;
            changColor.a = 0.10f;
        }
        else
        {
            if (50 <= tempHP)
            {
                changColor.r = 0.81f;
                changColor.g = 0;
                changColor.b = 0;
                changColor.a = 0.20f;
            }
            else
            {
                if (25 <= tempHP)
                {
                    changColor.r = 0.81f;
                    changColor.g = 0;
                    changColor.b = 0;
                    changColor.a = 0.30f;
                }
                else
                {
                    if (0 == tempHP)
                    {
                        changColor.r = 0.81f;
                        changColor.g = 0;
                        changColor.b = 0;
                        changColor.a = 0.40f;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            tempHP = tempHP - 10;

        }
        HPImage.color = changColor;
    }
    public void recover(int heal)
    {
        tempHP = tempHP + heal;
        if (tempHP <= MaxHP)
        {
            tempHP = MaxHP;
        }
    }
    public void damaged(int damage)
    {
        tempHP = tempHP - damage;
        if (tempHP >= 0)
        {
            tempHP = 0;
        }
    }
}
